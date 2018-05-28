using MyLog.Core.ViewModels.Abstract;
using MyLog.Droid.Views.Pages;

namespace MyLog.Droid.Pages
{
    public abstract class BaseLogFragment<TViewModel> : BasePageFragment<TViewModel>
        where TViewModel : BasePageViewModel
    {
        public override int LayoutId => Resource.Layout.LogView;
    }
}