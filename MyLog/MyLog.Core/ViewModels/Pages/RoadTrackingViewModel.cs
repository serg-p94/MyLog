using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Location;
using MyLog.Core.Csv.Converters;
using MyLog.Core.Enums;
using MyLog.Core.Extensions;
using MyLog.Core.Models.RoadTracking;
using MyLog.Core.Services;
using MyLog.Core.ViewModels.Abstract;
using MyLog.Core.ViewModels.RoadTracking;

namespace MyLog.Core.ViewModels.Pages
{
    public class RoadTrackingViewModel : BasePageViewModel
    {
        private const bool UseMockData = false;

        private TrackingState _state;

        public override string Title { get; } = "Road Tracking";

        public MvxObservableCollection<WayItemViewModel> RoadItems { get; } =
            new MvxObservableCollection<WayItemViewModel>();

        public TrackingState State
        {
            get => _state;
            set => SetProperty(ref _state, value);
        }

        public IMvxCommand ImportCommand => new MvxAsyncCommand(ImportAsync);

        public IMvxCommand StartCommand => new MvxCommand(StartTracking);

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

        private void StartTracking()
        {
            State = (TrackingState) (((int) State + 1) % 3);
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
