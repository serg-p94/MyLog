using System;
using System.Linq;
using MvvmCross.ViewModels;
using MyLog.Core.Models.Navigation;

namespace MyLog.Core.ViewModels
{
    public class RouteItemViewModel : MvxNotifyPropertyChanged
    {
        private bool _isSelected;

        public RouteDefinition Model { get; set; }

        public string Name => Model.Name;

        public double Distance => Model.Waypoints.Sum(w => w.Distance);

        public TimeSpan Time => TimeSpan.FromSeconds(Model.Waypoints.Sum(w => w.Time.TotalSeconds));

        public double Speed
        {
            get
            {
                var totalTime = Model.Waypoints.Sum(w => w.Speed > 0 ? w.Distance / w.Speed : 0);
                var totalDistance = Model.Waypoints.Sum(w => w.Distance);
                return totalTime > 0 ? totalDistance / totalTime : 0;
            }
        }

        public int WaypointsCount => Model.Waypoints.Count;

        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }
    }
}
