using System;
using MvvmCross.Plugins.Location;

namespace MyLog.Core.Models.RoadTracking
{
    public struct LocationLogItem
    {
        public DateTime DateTime { get; set; }

        public MvxCoordinates Coordinates { get; set; }
    }
}
