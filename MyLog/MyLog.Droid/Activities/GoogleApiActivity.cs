using Android.App;
using Android.Content;
using Android.Gms.Common;
using Android.Gms.Common.Apis;
using Android.Gms.Drive;
using MvvmCross.Core.ViewModels;

namespace MyLog.Droid.Activities
{
    public abstract class GoogleApiActivity<TViewModel> : BaseActivity<TViewModel> where TViewModel : MvxViewModel
    {
        private const int ResolutionRequestCode = 1234;

        private GoogleApiClient _googleApiClient;

        protected override void OnStart()
        {
            base.OnStart();

            _googleApiClient = new GoogleApiClient.Builder(this)
                .AddApi(DriveClass.API)
                .AddScope(DriveClass.ScopeFile)
                .AddConnectionCallbacks(OnConnected)
                .AddOnConnectionFailedListener(OnConnectionFailed)
                .Build();

            _googleApiClient.Connect();
        }

        private void OnConnected()
        {
            var t = "success";
        }

        private void OnConnectionFailed(ConnectionResult result)
        {
            if (result.HasResolution)
            {
                result.StartResolutionForResult(this, ResolutionRequestCode);
            }
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == ResolutionRequestCode)
            {
                switch (resultCode)
                {
                    case Result.Ok:
                        break;

                    case Result.Canceled:
                    case Result.FirstUser:
                    default:
                        break;
                }
            }
        }
    }
}