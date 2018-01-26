using MvvmCross.Core.ViewModels;
using MyLog.Core.ViewModels.Pages;

namespace MyLog.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();
            RegisterNavigationServiceAppStart<HomeViewModel>();
        }
    }
}
