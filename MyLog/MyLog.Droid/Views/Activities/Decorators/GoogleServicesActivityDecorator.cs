using Android.App;
using Android.Content;
using Android.Gms.Common;
using Android.Gms.Common.Apis;
using Android.Gms.Drive;
using Android.OS;

namespace MyLog.Droid.Views.Activities.Decorators
{
    public class GoogleServicesActivityDecorator : IActivityDecorator
    {
        private const int ResolutionRequestCode = 113;

        private readonly Activity _activity;
        private GoogleApiClient _googleApiClient;

        private GoogleApiClient GoogleApiClient => _googleApiClient =
            _googleApiClient ?? new GoogleApiClient.Builder(_activity)
                .AddApi(DriveClass.API)
                //.AddScope(DriveClass.ScopeFile)
                .AddConnectionCallbacks(OnConnected, OnConnectionSuspended)
                .AddOnConnectionFailedListener(OnConnectionFailed)
                .Build();


        public GoogleServicesActivityDecorator(Activity activity)
        {
            _activity = activity;
        }

        public void OnStart()
        {
            GoogleApiClient.Connect();
        }

        public void OnStop()
        {
            GoogleApiClient.Disconnect();
        }

        public void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (requestCode == ResolutionRequestCode)
            {
                switch (resultCode)
                {
                    case Result.Ok:
                        break;

                    case Result.Canceled:
                        break;

                    case Result.FirstUser:
                    default:
                        break;
                }
            }
        }

        private void OnConnected(Bundle connectionHint) { }

        private void OnConnectionSuspended(int cause) { }

        private void OnConnectionFailed(ConnectionResult result)
        {
            if (result.HasResolution)
            {
                result.StartResolutionForResult(_activity, ResolutionRequestCode);
            }
        }
    }
}