using System;
using System.Collections.Generic;
using System.Linq;
using MvvmCross.ViewModels;
using MyLog.Core.Models.Navigation;

namespace MyLog.Core.ViewModels
{
    public class RouteItemViewModel : MvxNotifyPropertyChanged
    {
        private bool _isSelected;

        public RouteDefinition Model { get; set; }

        private IEnumerable<WaypointModel> AllWaypoints => Model.Origin != null
            ? Model.Waypoints.Append(Model.Destination).Prepend(Model.Origin)
            : Model.Waypoints.Append(Model.Destination);

        public string Name => Model.Name;

        public double Distance => AllWaypoints.Sum(w => w.Distance);

        public TimeSpan Time => TimeSpan.FromSeconds(AllWaypoints.Sum(w => w.Time.TotalSeconds));

        public double Speed
        {
            get
            {
                var totalTime = AllWaypoints.Sum(w => w.Speed > 0 ? w.Distance / w.Speed : 0);
                var totalDistance = AllWaypoints.Sum(w => w.Distance);
                return totalTime > 0 ? totalDistance / totalTime : 0;
            }
        }

        public int StopsCount => Model.Waypoints.Count;

        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }
    }
}
