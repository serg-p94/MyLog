using MvvmCross.Droid.Views.Attributes;
using MvvmCross.Platform;
using MyLog.Core.Services;
using MyLog.Core.ViewModels;
using MyLog.Core.ViewModels.Pages;

namespace MyLog.Droid.Pages
{
    [MvxFragmentPresentation(typeof(SlideMenuHostViewModel), Resource.Id.FragmentContainer, addToBackStack: true)]
    public class JourneyLogView : BaseLogFragment<JourneyLogViewModel>
    {
        private LocationService LocationService { get; } = Mvx.GetSingleton<LocationService>();

        public override void OnStart()
        {
            base.OnStart();
            LocationService.Start();
        }

        public override void OnStop()
        {
            base.OnStop();
            LocationService.Stop();
        }
    }
}