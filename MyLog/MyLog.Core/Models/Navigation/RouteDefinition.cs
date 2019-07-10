using System;
using System.Collections.Generic;
using System.Linq;
using MyLog.Core.Csv.Models;

namespace MyLog.Core.Models.Navigation
{
    public class RouteDefinition
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public WaypointModel Origin { get; set; }

        public WaypointModel Destination { get; set; }

        public List<WaypointModel> Waypoints { get; } = new List<WaypointModel>();

        public static RouteDefinition FromCsvModel(RouteDefinitionCsvModel csvModel)
        {
            var routeModel = new RouteDefinition { Name = csvModel.Name };
            routeModel.Waypoints.AddRange(csvModel.Waypoints.Select(WaypointModel.FromCsv));

            if (csvModel.IsStartFromFirstPoint)
            {
                routeModel.Origin = routeModel.Waypoints.First();
                routeModel.Waypoints.Remove(routeModel.Waypoints.First());
            }

            routeModel.Destination = routeModel.Waypoints.Last();
            routeModel.Waypoints.Remove(routeModel.Waypoints.Last());

            return routeModel;
        }
    }
}
