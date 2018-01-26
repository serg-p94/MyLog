using Android.OS;
using Android.Views;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Views.Fragments;
using MyLog.Core.ViewModels.Abstract;

namespace MyLog.Droid.Views.Pages
{
    public abstract class BasePageFragment<TViewModel> : MvxFragment<TViewModel>
        where TViewModel : BasePageViewModel
    {
        public abstract int LayoutId { get; }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);

            return this.BindingInflate(LayoutId, null);
        }
    }
}