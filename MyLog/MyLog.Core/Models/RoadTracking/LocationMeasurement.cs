using System;
using MyLog.Core.Models.Navigation;

namespace MyLog.Core.Models.RoadTracking
{
    public struct LocationMeasurement
    {
        public DateTimeOffset Timestamp { get; set; }

        public Coordinates Coordinates { get; set; }
    }
}
