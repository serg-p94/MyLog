using Android.Content;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using MyLog.Core;

namespace MyLog.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext) { }

        protected override IMvxApplication CreateApp() => new App();
    }
}