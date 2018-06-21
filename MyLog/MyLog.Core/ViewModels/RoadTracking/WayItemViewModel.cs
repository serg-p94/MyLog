using System;
using MvvmCross.Core.ViewModels;
using MyLog.Core.Models.RoadTracking;

namespace MyLog.Core.ViewModels.RoadTracking
{
    public class WayItemViewModel : MvxNotifyPropertyChanged
    {
        public Waypoint From { get; set; }

        public Waypoint To { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public float Distance { get; set; }

        public float AverageSpeed { get; set; }
    }
}
