using System;
using System.Collections.Generic;
using MvvmCross.Plugins.Location;
using MyLog.Core.Models.RoadTracking;
using MyLog.Core.ViewModels.Abstract;

namespace MyLog.Core.ViewModels.Pages
{
    public class RoadTrackingReportViewModel : BasePageViewModel
    {
        public IList<LocationLogItem> LogItems { get; } = new List<LocationLogItem> {
            new LocationLogItem { DateTime = DateTime.Now, Coordinates = new MvxCoordinates() },
            new LocationLogItem { DateTime = DateTime.Now, Coordinates = new MvxCoordinates() },
            new LocationLogItem { DateTime = DateTime.Now, Coordinates = new MvxCoordinates() },
            new LocationLogItem { DateTime = DateTime.Now, Coordinates = new MvxCoordinates() },
            new LocationLogItem { DateTime = DateTime.Now, Coordinates = new MvxCoordinates() },
            new LocationLogItem { DateTime = DateTime.Now, Coordinates = new MvxCoordinates() },
        };
    }
}
