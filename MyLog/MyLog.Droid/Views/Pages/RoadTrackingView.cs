using Android.Views;
using MvvmCross.Droid.Views.Attributes;
using MyLog.Core.ViewModels;
using MyLog.Core.ViewModels.Pages;

namespace MyLog.Droid.Views.Pages
{
    [MvxFragmentPresentation(typeof(SlideMenuHostViewModel), Resource.Id.FragmentContainer, true)]
    public class RoadTrackingView : BasePageFragment<RoadTrackingViewModel>
    {
        public override int LayoutId => Resource.Layout.RoadTrackingView;

        public override int? MenuId => Resource.Menu.road_tracking;

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            return base.OnOptionsItemSelected(item);
        }
    }
}