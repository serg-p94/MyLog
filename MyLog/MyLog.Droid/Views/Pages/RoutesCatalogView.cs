using MvvmCross.Platforms.Android.Presenters.Attributes;
using MyLog.Core.ViewModels;
using MyLog.Core.ViewModels.Pages;

namespace MyLog.Droid.Views.Pages
{
    [MvxFragmentPresentation(typeof(SlideMenuHostViewModel), Resource.Id.FragmentContainer, true)]
    public class RoutesCatalogView : BasePageFragment<RoutesCatalogViewModel>
    {
        public override int LayoutId => Resource.Layout.RoutesCatalogView;
    }
}