using System;
using MvvmCross.Plugins.Location;
using MvvmCross.Plugins.Messenger;
using MyLog.Core.Messenger;

namespace MyLog.Core.Services
{
    public class LocationService
    {
        private readonly IMvxLocationWatcher _watcher;
        private readonly IMvxMessenger _messenger;

        public LocationService(IMvxLocationWatcher watcher, IMvxMessenger messenger)
        {
            _watcher = watcher;
            _messenger = messenger;
        }

        public void Start() => _watcher.Start(new MvxLocationOptions {
            Accuracy = MvxLocationAccuracy.Fine,
            TimeBetweenUpdates = TimeSpan.FromSeconds(1)
        }, OnLocation, OnError);

        public void Stop() => _watcher.Stop();

        private void OnLocation(MvxGeoLocation location)
        {
            var message = new LocationMessage(this, location.Coordinates);
            _messenger.Publish(message);
        }

        private void OnError(MvxLocationError error)
        {
            throw new Exception(error.ToString());
        }
    }
}
