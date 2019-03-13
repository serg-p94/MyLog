using System;
using System.Collections.Generic;
using MvvmCross.Plugins.Location;
using MyLog.Core.Models.RoadTracking;
using MyLog.Core.ViewModels.Abstract;

namespace MyLog.Core.ViewModels.Pages
{
    public class RoadTrackingReportViewModel : BasePageViewModel
    {
        public IList<LocationMeasurement> LogItems { get; } = new List<LocationMeasurement> {};
    }
}
