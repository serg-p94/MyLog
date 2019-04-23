using MyLog.Core.Enums;
using MyLog.Core.Extensions;
using MyLog.Core.Managers.Interfaces;
using MyLog.Core.Models.Navigation;
using MyLog.Core.Services.Abstract;

namespace MyLog.Core.Services
{
    internal class NavigatorManagementService : INavigatorService
    {
        protected ISettingsManager SettingsManager;

        private readonly INavigatorService _googleNavigatorService;
        private readonly INavigatorService _yandexNavigatorService;

        public NavigatorManagementService(ISettingsManager settingsManager, IWebService webService)
        {
            SettingsManager = settingsManager;
            _googleNavigatorService = new GoogleNavigatorService(webService);
            _yandexNavigatorService = new YandexNavigatorService(webService);
        }

        private INavigatorService NavigatorService
        {
            get
            {
                var navigatorType = SettingsManager.GetValue<NavigatorType>(SettingType.NavigatorType.ToIntString());
                return navigatorType == NavigatorType.Yandex ? _yandexNavigatorService : _googleNavigatorService;
            }
        }

        public void StartNavigation(RouteDefinition route)
        {
            NavigatorService.StartNavigation(route);
        }
    }
}
