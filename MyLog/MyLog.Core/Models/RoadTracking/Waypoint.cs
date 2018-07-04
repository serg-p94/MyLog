using CsvHelper.Configuration.Attributes;
using MvvmCross.Plugins.Location;

namespace MyLog.Core.Models.RoadTracking
{
    public class Waypoint
    {
        [Name("Название")]
        public string Name { get; set; }

        [Name("Координаты")]
        public MvxCoordinates Coordinates { get; set; }
    }
}
