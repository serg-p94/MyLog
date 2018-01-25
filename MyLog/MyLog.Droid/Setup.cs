using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Android.Content;
using Android.Views;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using MvvmCross.Platform.IoC;
using MyLog.Core;

namespace MyLog.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext) { }

        protected override IMvxApplication CreateApp() => new App();

        protected override IEnumerable<string> ViewNamespaces => new List<string>(base.ViewNamespaces) {
            "MyLog.Droid.Custom.Controls"
        }.Distinct();

        protected override IEnumerable<Assembly> AndroidViewAssemblies =>
            new List<Assembly>(base.AndroidViewAssemblies) {
                GetType().Assembly
            }.Distinct();

        protected override IDictionary<string, string> ViewNamespaceAbbreviations =>
            new Dictionary<string, string>(base.ViewNamespaceAbbreviations) {
                {"Controls", "MyLog.Droid.Custom.Controls"}
            };
    }
}