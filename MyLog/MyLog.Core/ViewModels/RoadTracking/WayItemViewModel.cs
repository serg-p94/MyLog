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

        public float Distance { get; set; }

        public float AverageSpeed { get; set; }

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
