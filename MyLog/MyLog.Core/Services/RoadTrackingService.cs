using System;
using System.Diagnostics;
using System.Threading;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;
using MyLog.Core.Messenger;
using MyLog.Core.Models.RoadTracking;

namespace MyLog.Core.Services
{
    public class RoadTrackingService
    {
        private const int Period = 1_000;

        private MvxSubscriptionToken _locationSubscriptionToken;

        private Timer _updateTimer;

        private LocationService LocationService { get; } = Mvx.GetSingleton<LocationService>();

        private IMvxMessenger Messenger { get; } = Mvx.Resolve<IMvxMessenger>();

        #region State

        public Coordinates CurrentCoordinates { get; private set; }

        public double Speed { get; set; }

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
            IsStarted = false;
        }

        private void UpdateCallback(object state)
        {
            StateChanged?.Invoke(this, EventArgs.Empty);
            Debug.WriteLine($"[{DateTime.Now}] {nameof(RoadTrackingService)}.{nameof(UpdateCallback)}: {nameof(Speed)} = {Speed:F1} m/s");
        }
    }
}
