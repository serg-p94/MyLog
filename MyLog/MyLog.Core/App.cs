using System.Globalization;
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
            ConfigCulture();
            RegisterServices();
            RegisterNavigationServiceAppStart<RoadTrackingViewModel>();
        }

        private void RegisterServices()
        {
            Mvx.RegisterSingleton(new LocationService(Mvx.Resolve<IMvxLocationWatcher>(), Mvx.Resolve<IMvxMessenger>()));
        }

        private void ConfigCulture()
        {
            var culture = (CultureInfo) CultureInfo.CurrentCulture.Clone();
            culture.NumberFormat.NumberDecimalSeparator = ".";
            CultureInfo.DefaultThreadCurrentCulture = culture;
        }
    }
}
