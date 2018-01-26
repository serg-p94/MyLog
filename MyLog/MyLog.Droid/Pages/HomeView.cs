using MvvmCross.Droid.Views.Attributes;
using MyLog.Core.ViewModels;
using MyLog.Core.ViewModels.Pages;
using MyLog.Droid.Views.Pages;

namespace MyLog.Droid.Pages
{
    [MvxFragmentPresentation(typeof(SlideMenuHostViewModel), Resource.Id.FragmentContainer, addToBackStack: true)]
    public class HomeView : BasePageFragment<HomeViewModel>
    {
        public override int LayoutId => Resource.Layout.HomeView;
    }
}