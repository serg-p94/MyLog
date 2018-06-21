using MvvmCross.Plugins.Location;

namespace MyLog.Core.Models.RoadTracking
{
    public class Waypoint
    {
        public string Name { get; set; }

        public MvxCoordinates Coordinates { get; set; }
    }
}
