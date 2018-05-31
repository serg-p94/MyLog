using System.Collections.Generic;
using Android.Content;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using MyLog.Core;

namespace MyLog.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
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