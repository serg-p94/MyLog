using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CsvHelper;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Location;
using MvvmCross.Plugins.Messenger;
using MyLog.Core.Csv.Converters;
using MyLog.Core.Enums;
using MyLog.Core.Extensions;
using MyLog.Core.Helpers;
using MyLog.Core.Messenger;
using MyLog.Core.Models.RoadTracking;
using MyLog.Core.Services;
using MyLog.Core.ViewModels.Abstract;
using MyLog.Core.ViewModels.RoadTracking;

namespace MyLog.Core.ViewModels.Pages
{
    public class RoadTrackingViewModel : BasePageViewModel
    {
        private const bool UseMockData = false;
        private const int ShortPeriod = 1_000;
        private const int LongPeriod = 10_000;

        private TrackingState _state;

        private Timer _shortPeriodTimer;
        private Timer _longPeriodTimer;

        private MvxSubscriptionToken _locationSubscriptionToken;

        public override string Title { get; } = "Road Tracking";

        public TrackingState State
        {
            get => _state;
            set
            {
                SetProperty(ref _state, value);
                RaisePropertyChanged(() => IsStarted);
            }
        }

        public bool IsStarted => State == TrackingState.Started;

        public MvxObservableCollection<WayItemViewModel> RoadItems { get; } =
            new MvxObservableCollection<WayItemViewModel>();

        public IMvxCommand ImportCommand => new MvxAsyncCommand(ImportAsync);

        public IMvxCommand StartStopCommand => new MvxCommand(StartStopHandler);

        private LocationService LocationService { get; } = Mvx.GetSingleton<LocationService>();

        private IMvxMessenger Messenger { get; } = Mvx.Resolve<IMvxMessenger>();

        private async Task ImportAsync()
        {
            var waypointsData =
                UseMockData ? WaypointsDataRaw : await Mvx.Resolve<IFileInputService>().ImportTextAsync();

            using (var stringReader = new StringReader(waypointsData))
            using (var csvReader = new CsvReader(stringReader))
            {
                try
                {
                    csvReader.Configuration.TypeConverterCache.AddConverter<MvxCoordinates>(new MvxCoordinatesConverter());
                    var waypoints = csvReader.GetRecords<Waypoint>().ToList();
                    CoordinatesToWaypointConverter.AvailableWaypoints.UnionWith(waypoints);
                }
                catch (Exception e)
                {
                }
            }

            var waysData = UseMockData ? WaysDataRaw : await Mvx.Resolve<IFileInputService>().ImportTextAsync();

            using (var stringReader = new StringReader(waysData))
            using (var csvReader = new CsvReader(stringReader))
            {
                try
                {
                    csvReader.Configuration.TypeConverterCache.AddConverter<Waypoint>(new CoordinatesToWaypointConverter());
                    var ways = csvReader.GetRecords<Way>().ToList();
                    ways.Select(w => new WayItemViewModel {
                        StartTime = w.StartTime,
                        From = w.From,
                        To = w.To,
                        Distance = w.Distance,
                        FinishTime = w.FinishTime,
                        RestTime = w.PauseTime
                    }).ForEach(RoadItems.Add);
                }
                catch (Exception e)
                {
                }
            }
        }

        private void StartStopHandler()
        {
            State = (TrackingState) (((int) State + 1) % 2);

            switch (State)
            {
                case TrackingState.Started:
                    StartTracking();
                    break;
                case TrackingState.Stopped:
                case TrackingState.Paused:
                    StopTracking();
                    break;
            }
        }

        private void StartTracking()
        {
            _locationSubscriptionToken = Messenger.Subscribe<LocationMessage>(msg => CurrentLocation = msg.Coordinates);
            LocationService.Start();
            _shortPeriodTimer = new Timer(ShortPeriodCallback, null, 0, ShortPeriod);
            _longPeriodTimer = new Timer(LongPeriodCallback, null, 0, LongPeriod);
        }

        private void StopTracking()
        {
            LocationService.Stop();
            Messenger.Unsubscribe<LocationMessage>(_locationSubscriptionToken);
            _shortPeriodTimer.Dispose();
            _shortPeriodTimer = null;
            _longPeriodTimer.Dispose();
            _longPeriodTimer = null;
        }

        private readonly LinkedList<LocationLogItem> _coordinatesLog = new LinkedList<LocationLogItem>();

        public MvxCoordinates CurrentLocation { get; set; }

        private LocationLogItem _lastMeasuredLocation;
        private double _currentSpeed;

        public double CurrentSpeed
        {
            get => _currentSpeed;
            set => SetProperty(ref _currentSpeed, value);
        }

        private void ShortPeriodCallback(object state)
        {
            CheckCurrentWayPassed();

            if (_lastMeasuredLocation.Coordinates != null)
            {
                var distance = CurrentLocation.DistanceTo(_lastMeasuredLocation.Coordinates) / 1000;
                var time = (DateTime.Now - _lastMeasuredLocation.DateTime).TotalHours;
                CurrentSpeed = distance / time;
            }

            _lastMeasuredLocation = new LocationLogItem
            {
                DateTime = DateTime.Now,
                Coordinates = CurrentLocation
            };

            RaisePropertyChanged(() => DistanceToStopString);

            Debug.WriteLine($"[{DateTime.Now}] - {nameof(ShortPeriodCallback)}: {nameof(CurrentSpeed)} = {CurrentSpeed}");
        }

        private void LongPeriodCallback(object state)
        {
            if (CurrentLocation != null)
            {
                _coordinatesLog.AddLast(new LinkedListNode<LocationLogItem>(new LocationLogItem {
                    DateTime = DateTime.Now,
                    Coordinates = CurrentLocation
                }));
                Debug.WriteLine(
                    $"[{DateTime.Now}] - {nameof(LongPeriodCallback)}: {nameof(CurrentLocation)} = {CurrentLocation.ConvertToString()}");
            }
        }

        private WayItemViewModel CurrentWay => RoadItems.FirstOrDefault(w => !w.IsPassed);

        public double DistanceToStop
        {
            get
            {
                if (CurrentWay != null && CurrentLocation != null)
                {
                    return CurrentLocation.DistanceTo(CurrentWay.To.Coordinates);
                }

                return double.NaN;
            }
        }

        public string DistanceToStopString =>
            DistanceToStop < 1000 ? $"{DistanceToStop:F0} m" : $"{DistanceToStop / 1000:F1} km";

        private void CheckCurrentWayPassed()
        {
            if (CurrentWay != null && CurrentLocation != null)
            {
                CurrentWay.IsPassed = CurrentWay.To.Coordinates.DistanceTo(CurrentLocation) < 10;
            }
        }

        private const string WaypointsDataRaw = @"Название,Координаты
Минск,""53.835505, 27.609153""
""АЗС, Ивацевичи"",""52.694758, 25.352463""
""АЗС, Домачево"",""51.789418, 23.654755""
""ПТО, Домачево"",""51.765549, 23.592854""
""АЗС ORLEN, Красник"",""50.929217, 22.249868""
""TESCO, Жешув"",""50.018610, 22.012777""
""АЗС ORLEN, Дукля"",""49.565610, 21.691450""
Bajusz Vendégház,""48.521228, 21.252782""";

        private const string WaysDataRaw = @"Откуда,Куда,Расстояние,Выезд,Прибытие,Остановка
""53.835505, 27.609153"",""52.694758, 25.352463"",211,5:00,7:15,0:30
""52.694758, 25.352463"",""51.789418, 23.654755"",172,7:45,10:00,0:30
""51.789418, 23.654755"",""51.765549, 23.592854"",7,10:30,10:40,1:00
""51.765549, 23.592854"",""50.929217, 22.249868"",170,11:40,14:10,0:15
""50.929217, 22.249868"",""50.018610, 22.012777"",124,14:25,16:25,0:30
""50.018610, 22.012777"",""49.565610, 21.691450"",75,16:55,18:25,0:15
""49.565610, 21.691450"",""48.521228, 21.252782"",150,18:40,21:10,00:00";
    }
}
