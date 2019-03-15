using System.Collections.Generic;
using System.Windows.Input;
using MvvmCross;
using MvvmCross.Commands;
using MyLog.Core.Models.Navigation;
using MyLog.Core.Services;
using MyLog.Core.Services.Abstract;
using MyLog.Core.ViewModels.Abstract;
using MyLog.Core.ViewModels.Dialogs;

namespace MyLog.Core.ViewModels.Pages
{
    public class SettingsViewModel : BasePageViewModel
    {
        private NavigatorType _navigator = Mvx.IoCProvider.Resolve<NavigatorService>() is GoogleMapsService
            ? NavigatorType.Google
            : NavigatorType.Yandex;

        public override string Title => "Settings";

        private NavigatorType Navigator
        {
            get => _navigator;
            set
            {
                if (SetProperty(ref _navigator, value))
                {
                    switch (_navigator)
                    {
                        case NavigatorType.Google:
                            Mvx.IoCProvider.RegisterType<NavigatorService, GoogleMapsService>();
                            break;
                        case NavigatorType.Yandex:
                            Mvx.IoCProvider.RegisterType<NavigatorService, YandexNavigatorService>();
                            break;
                    }

                    RaisePropertyChanged(() => NavigatorName);
                    Mvx.IoCProvider.Resolve<NavigatorService>().StartNavigation(new RouteDefinition {
                        Destination = new Coordinates { Latitude = 53.834381, Longitude = 27.60872 },
                        Waypoints = {
                            Coordinates.Parse("53.931073, 27.576931"),
                            Coordinates.Parse("53.907636, 27.433679")
                        }
                    });
                }
            }
        }

        public string NavigatorName => Navigator.ToString();

        public ICommand SelectNavigatorCommand => new MvxCommand(async () => {
            var selectedResult = await NavigationService.Navigate<ListDialogViewModel,
                IEnumerable<DialogOptionViewModel>, DialogOptionViewModel>(
                new[] {
                    new DialogOptionViewModel<NavigatorType> { Data = NavigatorType.Google },
                    new DialogOptionViewModel<NavigatorType> { Data = NavigatorType.Yandex }
                });

            if (selectedResult != null)
            {
                Navigator = ((DialogOptionViewModel<NavigatorType>)selectedResult).Data;
            }
        });

        private enum NavigatorType
        {
            Google, Yandex
        }
    }
}
