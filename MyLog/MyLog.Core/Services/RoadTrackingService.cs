using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using MvvmCross;
using MvvmCross.Plugin.Messenger;
using MyLog.Core.Helpers;
using MyLog.Core.Messenger;
using MyLog.Core.Models.Navigation;
using MyLog.Core.Models.RoadTracking;

namespace MyLog.Core.Services
{
    public class RoadTrackingService
    {
        private const int Period = 1_000;

        private MvxSubscriptionToken _locationSubscriptionToken;

        private Timer _updateTimer;

        private LocationService LocationService { get; } = Mvx.IoCProvider.GetSingleton<LocationService>();

        private IMvxMessenger Messenger { get; } = Mvx.IoCProvider.Resolve<IMvxMessenger>();

        #region State

        public Coordinates CurrentCoordinates { get; private set; }

        public double Speed { get; private set; }

        public event EventHandler StateChanged;

        public bool IsStarted { get; private set; }

        #endregion

        public void StartTracking()
        {
            _locationSubscriptionToken = Messenger.Subscribe<LocationMessage>(msg => CurrentCoordinates = msg.Coordinates);
            LocationService.Start();
            _updateTimer = new Timer(UpdateCallback, null, 0, Period);
            IsStarted = true;
        }

        public void StopTracking()
        {
            LocationService.Stop();
            Messenger.Unsubscribe<LocationMessage>(_locationSubscriptionToken);
            _updateTimer.Dispose();
            _updateTimer = null;
            _measurementsHistory.Clear();
            IsStarted = false;
        }

        private void UpdateCallback(object state)
        {
            UpdateSpeed(new LocationMeasurement {
                Timestamp = DateTimeOffset.Now,
                Coordinates = CurrentCoordinates
            });

            StateChanged?.Invoke(this, EventArgs.Empty);
            Debug.WriteLine($"[{DateTime.Now}] {nameof(RoadTrackingService)}.{nameof(UpdateCallback)}: {nameof(Speed)} = {Speed:F1} m/s");
        }


        private readonly IList<LocationMeasurement> _measurementsHistory = new List<LocationMeasurement>();

        private void UpdateSpeed(LocationMeasurement locationMeasurement)
        {
            _measurementsHistory.Add(locationMeasurement);

            while (EarliestMeasurementOffset.TotalSeconds > 3)
            {
                _measurementsHistory.RemoveAt(0);
            }

            Speed = CalculateSpeed();
        }

        private double CalculateSpeed()
        {
            var time = (_measurementsHistory.Last().Timestamp - _measurementsHistory.First().Timestamp).TotalSeconds;

            var distance = 0d;

            for (var i = 1; i < _measurementsHistory.Count; i++)
            {
                distance += _measurementsHistory[i].Coordinates.DistanceTo(_measurementsHistory[i - 1].Coordinates);
            }

            return time > 0 ? distance / time : 0;
        }

        private TimeSpan EarliestMeasurementOffset => _measurementsHistory.Any()
            ? DateTimeOffset.Now - _measurementsHistory[0].Timestamp
            : TimeSpan.Zero;
    }
}
