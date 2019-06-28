using System;
using System.Collections.Generic;
using System.Linq;
using MyLog.Core.Csv.Models;

namespace MyLog.Core.Models.Navigation
{
    public class RouteDefinition : IEquatable<RouteDefinition>
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

        public override bool Equals(object obj)
        {
            return Equals(obj as RouteDefinition);
        }

        // TODO: fix
        public bool Equals(RouteDefinition other)
        {
            return other != null &&
                   Name == other.Name &&
                   EqualityComparer<Coordinates?>.Default.Equals(Origin, other.Origin) &&
                   EqualityComparer<Coordinates>.Default.Equals(Destination, other.Destination)/* &&
                   EqualityComparer<List<Coordinates>>.Default.Equals(Waypoints, other.Waypoints)*/;
        }
    }
}
