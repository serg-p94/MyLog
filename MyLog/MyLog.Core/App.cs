using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Location;
using MvvmCross.Plugins.Messenger;
using MyLog.Core.Services;
using MyLog.Core.ViewModels.Pages;

namespace MyLog.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();
            RegisterServices();
            RegisterNavigationServiceAppStart<JourneyLogViewModel>();
        }

        private void RegisterServices()
        {
            Mvx.RegisterSingleton(new LocationService(Mvx.Resolve<IMvxLocationWatcher>(), Mvx.Resolve<IMvxMessenger>()));
        }
    }
}
