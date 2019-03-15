using System.Collections.Generic;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
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

        public IMvxNavigationService NavigationService { get; } = Mvx.IoCProvider.Resolve<IMvxNavigationService>();

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
                    Title = "Road Tracking",
                    Command = new MvxAsyncCommand(async () => await NavigationService.Navigate<RoadTrackingViewModel>())
                },
                new SlideMenuItemViewModel {
                    Title = "Settings",
                    Command = new MvxAsyncCommand(async () => await NavigationService.Navigate<SettingsViewModel>())
                }
            };
        }
    }
}
