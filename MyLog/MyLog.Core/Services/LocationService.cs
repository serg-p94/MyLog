using System;
using System.Threading.Tasks;
using MvvmCross.Plugins.Location;
using MvvmCross.Plugins.Messenger;
using MyLog.Core.Helpers;
using MyLog.Core.Messenger;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

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

        public async void Start()
        {
            await EnsurePermissionExists();
            _watcher.Start(new MvxLocationOptions {
                Accuracy = MvxLocationAccuracy.Fine,
                TimeBetweenUpdates = TimeSpan.FromSeconds(1),
                MovementThresholdInM = 1,
                TrackingMode = MvxLocationTrackingMode.Foreground
            }, OnLocation, OnError);
        }

        public void Stop() => _watcher.Stop();

        private void OnLocation(MvxGeoLocation location)
        {
            var message = new LocationMessage(this, location.Coordinates.ToCoordinates());
            _messenger.Publish(message);
        }

        private void OnError(MvxLocationError error)
        {
            throw new Exception(error.ToString());
        }

        private async Task EnsurePermissionExists()
        {
            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
            if (status != PermissionStatus.Granted)
            {
                await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
            }
        }
    }
}
