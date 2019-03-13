using System.Text;
using MyLog.Core.Extensions;
using MyLog.Core.Models.Navigation;
using MyLog.Core.Services.Abstract;

namespace MyLog.Core.Services
{
    public class YandexNavigatorService : NavigatorService
    {
        public YandexNavigatorService(IWebService webService) : base(webService) { }

        protected override string GetRouteUriString(RouteDefinition route)
        {
            var paramsBuilder = new StringBuilder("yandexnavi://build_route_on_map?");

            if (route.Origin.HasValue)
            {
                paramsBuilder.Append($"lat_from={route.Origin.Value.Latitude}&lon_from={route.Origin.Value.Longitude}&");
            }

            paramsBuilder.Append($"lat_to={route.Destination.Latitude}&lon_to={route.Destination.Longitude}");
            route.Waypoints.ForEach((c, i) => paramsBuilder.Append($"&lat_via_{i}={c.Latitude}&lon_via_{i}={c.Longitude}"));

            return paramsBuilder.ToString();
        }
    }
}