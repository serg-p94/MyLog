using Android.App;
using Android.Content.PM;
using MvvmCross.Platforms.Android.Views;

namespace MyLog.Droid
{
    [Activity(MainLauncher = true,
        NoHistory = true,
        ScreenOrientation = ScreenOrientation.Portrait,
        Theme = "@style/AppTheme.Launcher")]
    public class SplashScreen : MvxSplashScreenActivity { }
}