using System;
using MvvmCross.Plugins.Location;

namespace MyLog.Core.Models.RoadTracking
{
    public struct LocationMeasurement
    {
        public DateTime DateTime { get; set; }

        public MvxCoordinates Coordinates { get; set; }
    }
}
