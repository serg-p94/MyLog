using System.Collections.Generic;
using System.Linq;
using Android.Content;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using MyLog.Core;
using MyLog.Droid.Views.Components;

namespace MyLog.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext) { }

        protected override IMvxApplication CreateApp() => new App();

        protected override IEnumerable<string> ViewNamespaces =>
            base.ViewNamespaces.Concat(new[] {
                typeof(BaseComponent).Namespace
            });

        protected override IDictionary<string, string> ViewNamespaceAbbreviations
        {
            get
            {
                var abbrs = base.ViewNamespaceAbbreviations;
                abbrs["components"] = typeof(BaseComponent).Namespace;
                return abbrs;
            }
        } 
    }
}