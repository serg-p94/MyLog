using System;
using System.Collections.Generic;
using MyLog.Core.ViewModels.Abstract;
using MyLog.Core.ViewModels.RoadTracking;

namespace MyLog.Core.ViewModels.Pages
{
    public class RoadTrackingViewModel : BasePageViewModel
    {
        public override string Title { get; } = "Road Tracking";

        public IList<BaseItemViewModel> RoadItems { get; } = new List<BaseItemViewModel> {
            new WaypointItemViewModel{Name = "First"},
            new WayItemViewModel(){Distance = 123.45f, Duration = new TimeSpan(1,2,3),StartTime = DateTime.Now, EndTime = DateTime.Now},
            new WaypointItemViewModel{Name = "Second"},
            new WayItemViewModel(){Distance = 123.45f, Duration = new TimeSpan(1,2,3),StartTime = DateTime.Now, EndTime = DateTime.Now},
            new WaypointItemViewModel{Name = "Third"},
            new WayItemViewModel(){Distance = 123.45f, Duration = new TimeSpan(1,2,3),StartTime = DateTime.Now, EndTime = DateTime.Now},
            new WaypointItemViewModel{Name = "Fourth"},
            new WayItemViewModel(){Distance = 123.45f, Duration = new TimeSpan(1,2,3),StartTime = DateTime.Now, EndTime = DateTime.Now},
            new WaypointItemViewModel{Name = "Fifth"},
        };
    }
}
