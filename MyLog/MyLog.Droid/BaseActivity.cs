using Android.OS;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;
using MyLog.Droid.Views;

namespace MyLog.Droid
{
    public abstract class BaseActivity<TViewModel> : MvxAppCompatActivity<TViewModel>, IСonfigurableLifecycleView
        where TViewModel : MvxViewModel
    {
        protected abstract int LayoutId { get; }

        public virtual void Subscribe() { }

        public virtual void Unsubscribe() { }

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