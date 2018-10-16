using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Location;
using MvvmCross.Plugins.Messenger;
using MyLog.Core.Enums;
using MyLog.Core.Helpers;
using MyLog.Core.Messenger;
using MyLog.Core.Models.RoadTracking;
using MyLog.Core.Services;
using MyLog.Core.ViewModels.Abstract;

namespace MyLog.Core.ViewModels.Pages
{
    public class RoadTrackingViewModel : BasePageViewModel
    {
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

        public IMvxCommand StartStopCommand => new MvxCommand(StartStopHandler);

        private LocationService LocationService { get; } = Mvx.GetSingleton<LocationService>();

        private IMvxMessenger Messenger { get; } = Mvx.Resolve<IMvxMessenger>();

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
    }
}
