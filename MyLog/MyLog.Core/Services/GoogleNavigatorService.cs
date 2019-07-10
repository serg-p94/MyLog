using System.Linq;
using System.Text;
using MyLog.Core.Models.Navigation;
using MyLog.Core.Services.Abstract;

namespace MyLog.Core.Services
{
    internal class GoogleNavigatorService : NavigatorService
    {
        public GoogleNavigatorService(IWebService webService) : base(webService) { }

        protected override string GetRouteUriString(RouteDefinition route)
        {
            var paramsBuilder = new StringBuilder("https://www.google.com/maps/dir/?api=1");

            if (route.Origin != null)
            {
                paramsBuilder.Append($"&origin={route.Origin.Coordinates}");
            }

            paramsBuilder.Append($"&destination={route.Destination.Coordinates}");
            paramsBuilder.Append($"&waypoints={string.Join("|", route.Waypoints.Select(w => w.Coordinates.ToString()))}");

            return paramsBuilder.ToString();
        }
    }
}