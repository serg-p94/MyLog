using System.Collections.Generic;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using MyLog.Core.Helpers;
using MyLog.Core.Models.RoadTracking;

namespace MyLog.Core.Csv.Converters
{
    public class CoordinatesToWaypointConverter : TypeConverter<Waypoint>
    {
        public static HashSet<Waypoint> AvailableWaypoints { get; } = new HashSet<Waypoint>();

        protected override Waypoint CreateFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            var coordinates = MvxCoordinatesHelper.Parse(text);
            var waypoint = AvailableWaypoints.FirstOrDefault(w => w.Coordinates.IsEqual(coordinates));
            return waypoint ?? new Waypoint();
        }
    }
}
