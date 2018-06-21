﻿using System;
using System.Collections.Generic;
using MvvmCross.Plugins.Location;
using MyLog.Core.Models.RoadTracking;
using MyLog.Core.ViewModels.Abstract;
using MyLog.Core.ViewModels.RoadTracking;

namespace MyLog.Core.ViewModels.Pages
{
    public class RoadTrackingViewModel : BasePageViewModel
    {
        public override string Title { get; } = "Road Tracking";

        private static Waypoint From => new Waypoint {
            Name = "From point",
            Coordinates = new MvxCoordinates()
        };

        private static Waypoint To => new Waypoint
        {
            Name = "To point",
            Coordinates = new MvxCoordinates()
        };

        public IList<WayItemViewModel> RoadItems { get; } = new List<WayItemViewModel> {
            new WayItemViewModel(){Distance = 123.45f, StartTime = DateTime.Now, FinishTime = DateTime.Now, RestTime = TimeSpan.FromMinutes(15),
                AverageSpeed = 74.5f,
                From = From, To = To},
            new WayItemViewModel(){Distance = 123.45f, StartTime = DateTime.Now, FinishTime = DateTime.Now, RestTime = TimeSpan.FromMinutes(30),
                AverageSpeed = 74.5f, From = From, To = To},
            new WayItemViewModel(){Distance = 123.45f, StartTime = DateTime.Now, FinishTime = DateTime.Now, RestTime = TimeSpan.FromMinutes(90),
                AverageSpeed = 74.5f, From = From, To = To},
            new WayItemViewModel(){Distance = 123.45f, StartTime = DateTime.Now, FinishTime = DateTime.Now, AverageSpeed = 74.5f,
                From = From, To = To},
            new WayItemViewModel(){Distance = 123.45f, StartTime = DateTime.Now, FinishTime = DateTime.Now, AverageSpeed = 74.5f,
                From = From, To = To},
            new WayItemViewModel(){Distance = 123.45f, StartTime = DateTime.Now, FinishTime = DateTime.Now, AverageSpeed = 74.5f,
                From = From, To = To},

        };
    }
}
