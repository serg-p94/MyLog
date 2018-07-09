using Android.OS;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;

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
    }
}