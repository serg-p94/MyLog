using System;
using System.Collections.Generic;
using System.Text;
using MyLog.Core.Models.Navigation;

namespace MyLog.Core.Csv.Models
{
    public class RouteDefinitionCsvModel
    {
        public string Name { get; set; }

        public Coordinates? Origin { get; set; }

        public Coordinates Destination { get; set; }

        public IList<Coordinates> Waypoints { get; } = new List<Coordinates>();

    }
}
