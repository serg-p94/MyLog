using Android.OS;
using Android.Runtime;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.ViewModels;
using Plugin.Permissions;

namespace MyLog.Droid.Activities
{
    public abstract class BaseActivity<TViewModel> : MvxAppCompatActivity<TViewModel> where TViewModel : MvxViewModel
    {
        protected abstract int LayoutId { get; }

        protected virtual void Subscribe() { }

        protected virtual void Unsubscribe() { }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(LayoutId);
        }

        protected override void OnStart()
        {
            base.OnStart();
            Subscribe();
        }

        protected override void OnStop()
        {
            base.OnStop();
            Unsubscribe();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}