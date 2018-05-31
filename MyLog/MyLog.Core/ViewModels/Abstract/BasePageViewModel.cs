using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace MyLog.Core.ViewModels.Abstract
{
    public abstract class BasePageViewModel : MvxViewModel
    {
        protected IMvxNavigationService NavigationService { get; } = Mvx.Resolve<IMvxNavigationService>();

        public virtual string Title { get; }
    }
}
