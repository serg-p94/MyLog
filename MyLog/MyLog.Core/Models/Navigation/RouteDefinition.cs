using System.Collections.Generic;
using System.Linq;
using MyLog.Core.Csv.Models;

namespace MyLog.Core.Models.Navigation
{
    public class RouteDefinition
    {
        public string Name { get; set; }

        public Coordinates? Origin { get; set; }

        public Coordinates Destination { get; set; }

        public List<Coordinates> Waypoints { get; } = new List<Coordinates>();

        public static RouteDefinition FromCsvModel(RouteDefinitionCsvModel csvModel)
        {
            var routeModel = new RouteDefinition { Name = csvModel.Name };
            routeModel.Waypoints.AddRange(csvModel.Waypoints);

            if (csvModel.IsStartFromFirstPoint)
            {
                routeModel.Origin = csvModel.Waypoints.First();
                routeModel.Waypoints.Remove(routeModel.Origin.Value);
            }

            routeModel.Destination = csvModel.Waypoints.Last();
            routeModel.Waypoints.Remove(routeModel.Destination);

            return routeModel;
        }
    }
}
