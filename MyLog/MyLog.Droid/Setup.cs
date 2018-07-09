using System.Collections.Generic;
using Android.Content;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using MvvmCross.Platform;
using MyLog.Core;
using MyLog.Core.Services;
using MyLog.Droid.Services;

namespace MyLog.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override void InitializePlatformServices()
        {
            base.InitializePlatformServices();
            Mvx.RegisterSingleton((IFileInputService) new FileInputService());
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