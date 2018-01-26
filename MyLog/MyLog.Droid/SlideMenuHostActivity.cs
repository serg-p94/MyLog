using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Widget;
using MvvmCross.Binding.Droid.Views;
using MyLog.Core.ViewModels;

namespace MyLog.Droid
{
    [Activity(Label = "SlideMenuHostActivity", ScreenOrientation = ScreenOrientation.Portrait, Theme = "@style/AppTheme")]
    public class SlideMenuHostActivity : BaseActivity<SlideMenuHostViewModel>
    {
        protected override int LayoutId => Resource.Layout.SlideMenuHostActivity;

        protected DrawerLayout DrawerLayout;
        protected FrameLayout PageContainer;
        protected MvxListView SlideMenu;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            DrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            PageContainer = FindViewById<FrameLayout>(Resource.Id.FragmentContainer);
            SlideMenu = FindViewById<MvxListView>(Resource.Id.navigation);

            SlideMenu.ItemTemplateId = Resource.Layout.item_SlideMenu;
        }
    }
}

