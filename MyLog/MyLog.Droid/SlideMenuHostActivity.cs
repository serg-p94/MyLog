using System;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.Views;
using MyLog.Core.ViewModels;
using MyLog.Droid.Navigation;
using MyLog.Droid.Views.Pages;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace MyLog.Droid
{
    [Activity(Label = "SlideMenuHostActivity", ScreenOrientation = ScreenOrientation.Portrait, Theme = "@style/AppTheme")]
    public class SlideMenuHostActivity : BaseActivity<SlideMenuHostViewModel>
    {
        private NavigationType _navigationType;

        protected override int LayoutId => Resource.Layout.SlideMenuHostActivity;

        protected DrawerLayout DrawerLayout;
        protected FrameLayout FragmentContainer;
        protected MvxListView SlideMenu;

        public event EventHandler IsDrawerOpenChanged;

        public bool IsDrawerOpen
        {
            get => DrawerLayout.IsDrawerOpen(GravityCompat.Start);
            set
            {
                if (value)
                {
                    DrawerLayout.OpenDrawer(GravityCompat.Start);
                }
                else
                {
                    DrawerLayout.CloseDrawer(GravityCompat.Start);
                }
            }
        }

        public NavigationType NavigationType
        {
            get => _navigationType;
            set
            {
                _navigationType = value;
                UpdateToolbar();
            }
        }

        internal void OnFragmentStart(IPageFragment fragment)
        {
            NavigationType = fragment.NavigationType;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    if (NavigationType == NavigationType.Lateral)
                    {
                        IsDrawerOpen = true;
                    }
                    else if (NavigationType == NavigationType.Forward)
                    {
                        OnBackPressed();
                    }
                    break;
            }

            return base.OnOptionsItemSelected(item);
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            DrawerLayout = FindViewById<DrawerLayout>(Resource.Id.DrawerLayout);
            FragmentContainer = FindViewById<FrameLayout>(Resource.Id.FragmentContainer);
            SlideMenu = FindViewById<MvxListView>(Resource.Id.SlideMenu);

            var toolbar = (Toolbar)FindViewById(Resource.Id.Toolbar);
            SetSupportActionBar(toolbar);

            this.CreateBinding().For(v => v.IsDrawerOpen).To<SlideMenuHostViewModel>(vm => vm.IsMenuOpen).TwoWay().Apply();
        }

        protected override void Subscribe()
        {
            base.Subscribe();
            DrawerLayout.DrawerStateChanged += DrawerStateChangedHandler;
        }

        protected override void Unsubscribe()
        {
            base.Unsubscribe();
            DrawerLayout.DrawerStateChanged -= DrawerStateChangedHandler;
        }

        private void DrawerStateChangedHandler(object s, DrawerLayout.DrawerStateChangedEventArgs e)
        {
            IsDrawerOpenChanged?.Invoke(s, EventArgs.Empty);
        }

        private void UpdateToolbar()
        {
            var iconId = 0;

            switch (NavigationType)
            {
                case NavigationType.Lateral:
                    iconId = Resource.Drawable.ic_menu;
                    break;

                case NavigationType.Forward:
                    iconId = Resource.Drawable.ic_back_arrow;
                    break;
            }

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeAsUpIndicator(iconId);
        }
    }
}

