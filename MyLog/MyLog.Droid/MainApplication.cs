using System;
using Android.App;
using Android.Runtime;
using Plugin.CurrentActivity;

namespace MyLog.Droid
{
#if DEBUG
    [Application(Debuggable = true, Theme = "@style/AppTheme")]
#else
    [Application(Debuggable = false, Theme = "@style/AppTheme")]
#endif
    public class MainApplication : Application
    {
        public MainApplication(IntPtr handle, JniHandleOwnership transer) : base(handle, transer) { }

        public override void OnCreate()
        {
            base.OnCreate();
            CrossCurrentActivity.Current.Init(this);
        }
    }
}