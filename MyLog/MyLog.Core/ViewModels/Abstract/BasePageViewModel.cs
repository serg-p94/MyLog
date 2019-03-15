using MvvmCross;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace MyLog.Core.ViewModels.Abstract
{
    public abstract class BasePageViewModel : MvxViewModel
    {
        protected IMvxNavigationService NavigationService { get; } = Mvx.IoCProvider.Resolve<IMvxNavigationService>();

        public virtual string Title { get; }
    }
}
