using System.Collections.Generic;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MyLog.Core.ViewModels.Pages;

namespace MyLog.Core.ViewModels
{
    public class SlideMenuHostViewModel : MvxViewModel
    {
        public IMvxNavigationService NavigationService { get; } = Mvx.Resolve<IMvxNavigationService>();

        public IList<SlideMenuItemViewModel> MenuItems { get; private set; } = new List<SlideMenuItemViewModel>();

        public SlideMenuHostViewModel()
        {
            InitMenuItems();
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
