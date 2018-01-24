using MvvmCross.Droid.Views;
using MyLog.Core.ViewModels.Abstract;

namespace MyLog.Droid
{
    public abstract class BaseActivity<TViewModel> : MvxActivity<TViewModel>
        where TViewModel : BasePageViewModel
    {
        protected abstract int LayoutId { get; }
    }
}