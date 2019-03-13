using MyLog.Core.Models.Navigation;

namespace MyLog.Core.Services.Abstract
{
    public abstract class NavigatorService
    {
        protected IWebService WebService { get; }

        protected NavigatorService(IWebService webService)
        {
            WebService = webService;
        }

        public void StartNavigation(RouteDefinition route)
        {
            var routeUri = GetRouteUriString(route);
            WebService.OpenUri(routeUri);
        }

        protected abstract string GetRouteUriString(RouteDefinition route);
    }
}
