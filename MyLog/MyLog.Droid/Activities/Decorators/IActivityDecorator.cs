using Android.App;
using Android.Content;

namespace MyLog.Droid.Activities.Decorators
{
    public interface IActivityDecorator
    {
        void OnStart();
        void OnStop();
        void OnActivityResult(int requestCode, Result resultCode, Intent data);
    }
}