﻿using System.Collections.Generic;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MyLog.Core.ViewModels.Pages;

namespace MyLog.Core.ViewModels
{
    public class SlideMenuHostViewModel : MvxViewModel
    {
        private bool _isMenuOpen;

        public SlideMenuHostViewModel()
        {
            InitMenuItems();
        }

        public IMvxNavigationService NavigationService { get; } = Mvx.Resolve<IMvxNavigationService>();

        public IList<SlideMenuItemViewModel> MenuItems { get; private set; } = new List<SlideMenuItemViewModel>();

        public IMvxCommand<SlideMenuItemViewModel> MenuNavigationCommand => new MvxCommand<SlideMenuItemViewModel>(
            item => {
                IsMenuOpen = false;
                item.Command?.Execute(null);
            });

        public bool IsMenuOpen
        {
            get => _isMenuOpen;
            set => SetProperty(ref _isMenuOpen, value);
        }

        private void InitMenuItems()
        {
            MenuItems = new List<SlideMenuItemViewModel> {
                new SlideMenuItemViewModel {
                    Title = "Home",
                    Command = new MvxAsyncCommand(async () => await NavigationService.Navigate<HomeViewModel>())
                },
                new SlideMenuItemViewModel {
                    Title = "Second",
                    Command = new MvxAsyncCommand(async () => await NavigationService.Navigate<SecondViewModel>())
                }
            };
        }
    }
}
