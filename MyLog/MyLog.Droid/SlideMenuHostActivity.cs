﻿using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.Views;
using MyLog.Core.ViewModels;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace MyLog.Droid
{
    [Activity(Label = "SlideMenuHostActivity", ScreenOrientation = ScreenOrientation.Portrait, Theme = "@style/AppTheme")]
    public class SlideMenuHostActivity : BaseActivity<SlideMenuHostViewModel>
    {
        protected override int LayoutId => Resource.Layout.SlideMenuHostActivity;

        protected DrawerLayout DrawerLayout;
        protected FrameLayout FragmentContainer;
        protected MvxListView SlideMenu;

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

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            DrawerLayout = FindViewById<DrawerLayout>(Resource.Id.DrawerLayout);
            FragmentContainer = FindViewById<FrameLayout>(Resource.Id.FragmentContainer);
            SlideMenu = FindViewById<MvxListView>(Resource.Id.SlideMenu);

            var toolbar = (Toolbar) FindViewById(Resource.Id.Toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu);

            SlideMenu.ItemTemplateId = Resource.Layout.item_SlideMenu;

            this.CreateBinding().For(v => v.IsDrawerOpen).To<SlideMenuHostViewModel>(vm => vm.IsMenuOpen).Apply();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    ViewModel.IsMenuOpen = true;
                    break;
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}

