using System;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MyLog.Core.Enums;
using MyLog.Core.Services;
using MyLog.Core.ViewModels.Abstract;

namespace MyLog.Core.ViewModels.Pages
{
    public class RoadTrackingViewModel : BasePageViewModel
    {
        private TrackingState _state;

        protected RoadTrackingService RoadTrackingService { get; } = Mvx.Resolve<RoadTrackingService>();

        public override string Title { get; } = "Road Tracking";

        public string SpeedText => $"{RoadTrackingService.Speed:F1} m/s";

        public string CoordinatesText => RoadTrackingService.CurrentCoordinates.ToString();

        public TrackingState State
        {
            get => _state;
            set
            {
                SetProperty(ref _state, value);
                RaisePropertyChanged(() => IsStarted);
            }
        }

        public bool IsStarted => State == TrackingState.Started;

        public IMvxCommand StartStopCommand => new MvxCommand(StartStopHandler);

        public override async Task Initialize()
        {
            await base.Initialize();
            State = RoadTrackingService.IsStarted ? TrackingState.Started : TrackingState.Stopped;
        }

        private void StartStopHandler()
        {
            State = (TrackingState) (((int) State + 1) % 2);

            switch (State)
            {
                case TrackingState.Started:
                    RoadTrackingService.StartTracking();
                    RoadTrackingService.StateChanged += OnStateChanged;
                    break;
                case TrackingState.Stopped:
                case TrackingState.Paused:
                    RoadTrackingService.StopTracking();
                    RoadTrackingService.StateChanged -= OnStateChanged;
                    break;
            }
        }

        private void OnStateChanged(object sender, EventArgs e)
        {
            RaisePropertyChanged(() => CoordinatesText);
            RaisePropertyChanged(() => SpeedText);
        }
    }
}
