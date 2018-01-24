using Android.App;
using MyLog.Core.ViewModels;

namespace MyLog.Droid
{
    [Activity(Label = "Main Activity")]
    public class MainActivity : BaseActivity<MainViewModel>
    {
        protected override int LayoutId => Resource.Layout.Main;
    }
}

