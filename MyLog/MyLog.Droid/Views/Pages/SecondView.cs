﻿using MvvmCross.Droid.Views.Attributes;
using MyLog.Core.ViewModels;
using MyLog.Core.ViewModels.Pages;

namespace MyLog.Droid.Views.Pages
{
    [MvxFragmentPresentation(typeof(SlideMenuHostViewModel), Resource.Id.FragmentContainer, true)]
    public class SecondView : BasePageFragment<SecondViewModel>
    {
        public override int LayoutId => Resource.Layout.SecondView;
    }
}