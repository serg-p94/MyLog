using MvvmCross.Plugins.Location;

namespace MyLog.Core.ViewModels.RoadTracking
{
    public class WaypointItemViewModel: BaseItemViewModel
    {
        public string Name { get; set; }

        public MvxCoordinates Coordinates { get; set; } = new MvxCoordinates();
    }
}
