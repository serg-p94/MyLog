using MvvmCross.Droid.Views.Attributes;
using MyLog.Core.ViewModels;
using MyLog.Core.ViewModels.Pages;
using MyLog.Droid.Navigation;

namespace MyLog.Droid.Pages
{
    [MvxFragmentPresentation(typeof(SlideMenuHostViewModel), Resource.Id.FragmentContainer, addToBackStack: true)]
    public class AddRecordView : BasePageFragment<AddRecordViewModel>
    {
        public override int LayoutId => Resource.Layout.AddRecordView;

        public override NavigationType NavigationType => NavigationType.Forward;
    }
}