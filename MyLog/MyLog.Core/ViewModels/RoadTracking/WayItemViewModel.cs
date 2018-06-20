using System;

namespace MyLog.Core.ViewModels.RoadTracking
{
    public class WayItemViewModel : BaseItemViewModel
    {
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public float Distance { get; set; }

        public TimeSpan Duration { get; set; }
    }
}
