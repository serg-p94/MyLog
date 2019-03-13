using System.Linq;
using System.Text;
using MyLog.Core.Models.Navigation;
using MyLog.Core.Services.Abstract;

namespace MyLog.Core.Services
{
    public class GoogleMapsService : NavigatorService
    {
        public GoogleMapsService(IWebService webService) : base(webService) { }

        protected override string GetRouteUriString(RouteDefinition route)
        {
            var paramsBuilder = new StringBuilder("https://www.google.com/maps/dir/?api=1");

            if (route.Origin.HasValue)
            {
                paramsBuilder.Append($"&origin={route.Origin.Value.ToString()}");
            }

            paramsBuilder.Append($"&destination={route.Destination}");
            paramsBuilder.Append($"&waypoints={string.Join("|", route.Waypoints.Select(c => c.ToString()))}");

            return paramsBuilder.ToString();
        }
    }
}