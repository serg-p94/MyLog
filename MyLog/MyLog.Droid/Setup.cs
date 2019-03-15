using System.Collections.Generic;
using MvvmCross;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.ViewModels;
using MyLog.Core;
using MyLog.Core.Services;
using MyLog.Core.Services.Abstract;
using MyLog.Droid.Services;

namespace MyLog.Droid
{
    public class Setup : MvxAndroidSetup
    {
        protected override void InitializePlatformServices()
        {
            base.InitializePlatformServices();

            Mvx.IoCProvider.RegisterSingleton((IFileInputService) new FileInputService());
            Mvx.IoCProvider.RegisterSingleton((IStorageService) new StorageService());

            Mvx.IoCProvider.RegisterType<IWebService, WebService>();
            Mvx.IoCProvider.RegisterType<NavigatorService, GoogleMapsService>();
        }

        protected override IMvxApplication CreateApp() => new App();

        protected override IDictionary<string, string> ViewNamespaceAbbreviations
        {
            get
            {
                var abbrs = base.ViewNamespaceAbbreviations;
                abbrs["controls"] = "MyLog.Droid.Custom.Controls";
                return abbrs;
            }
        }
    }
}