using System.Collections.Generic;

namespace MyLog.Core.Models.Navigation
{
    public class RouteDefinition
    {
        public string Name { get; set; }

        public Coordinates? Origin { get; set; }

        public Coordinates Destination { get; set; }

        public IList<Coordinates> Waypoints { get; } = new List<Coordinates>();
    }
}
