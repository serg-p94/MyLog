using MvvmCross.Droid.Views.Attributes;
using MyLog.Core.ViewModels;
using MyLog.Core.ViewModels.Pages;
using MyLog.Droid.Views.Models;

namespace MyLog.Droid.Views.Pages
{
    [MvxFragmentPresentation(typeof(SlideMenuHostViewModel), Resource.Id.FragmentContainer, true)]
    public class RoadTrackingView : BasePageFragment<RoadTrackingViewModel>
    {
        public override int LayoutId => Resource.Layout.RoadTrackingView;

        public override void OnViewModelSet()
        {
            base.OnViewModelSet();
            MenuOptions = new[] {
                new MenuOption { Text = "Import", Command = ViewModel.ImportCommand }
            };
        }
    }
}