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

        public DateTime StartTime { get; set; }

        public DateTime FinishTime { get; set; }

        public TimeSpan Duration => FinishTime - StartTime;

        public TimeSpan RestTime { get; set; }

        public float Distance { get; set; }

        public string DistanceString => $"{Distance} км";

        public float AverageSpeed { get; set; }

        public string AverageSpeedString => $"{AverageSpeed} км/ч";

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
