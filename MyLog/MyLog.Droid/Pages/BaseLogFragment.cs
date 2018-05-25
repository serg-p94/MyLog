using Android.OS;
using Android.Views;
using MvvmCross.Binding.Droid.Views;
using MyLog.Core.ViewModels.Abstract;
using MyLog.Droid.Views.Pages;

namespace MyLog.Droid.Pages
{
    public abstract class BaseLogFragment<TViewModel> : BasePageFragment<TViewModel>
        where TViewModel : BasePageViewModel
    {
        public override int LayoutId => Resource.Layout.LogView;

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            var list = View.FindViewById<MvxListView>(Resource.Id.List);
            list.ItemTemplateId = Resource.Layout.item_Record;
        }
    }
}