using System;
using MvvmCross.Core.ViewModels;
using MyLog.Core.Models.RoadTracking;

namespace MyLog.Core.ViewModels.RoadTracking
{
    public class WayItemViewModel : MvxNotifyPropertyChanged
    {
        private bool _isDetailedMode;

        public Waypoint From { get; set; }

        public Waypoint To { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan FinishTime { get; set; }

        public TimeSpan Duration => FinishTime - StartTime;

        public TimeSpan RestTime { get; set; }

        public float Distance { get; set; }

        public string DistanceString => $"{Distance} км";

        public double AverageSpeed => Distance / Duration.TotalHours;

        public string AverageSpeedString => $"{AverageSpeed:F0} км/ч";

        public bool  IsDetailedMode
        {
            get => _isDetailedMode;
            set => SetProperty(ref _isDetailedMode, value);
        }

        private IMvxCommand _detailedModeCommand;

        public IMvxCommand DetailedModeCommand =>
            _detailedModeCommand = _detailedModeCommand ?? new MvxCommand(() => IsDetailedMode = !IsDetailedMode);
    }
}
