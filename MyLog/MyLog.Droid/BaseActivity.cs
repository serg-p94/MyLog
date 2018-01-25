using Android.OS;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Views;

namespace MyLog.Droid
{
    public abstract class BaseActivity<TViewModel> : MvxActivity<TViewModel>
        where TViewModel : MvxViewModel
    {
        protected abstract int LayoutId { get; }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(LayoutId);
        }
    }
}