using Android.OS;
using Android.Support.Design.Widget;
using Android.Views;
using MyLog.Core.ViewModels.Abstract;
using MyLog.Droid.Custom.Controls;

namespace MyLog.Droid.Views.Pages
{
    public abstract class BaseLogFragment<TViewModel> : BasePageFragment<TViewModel>
        where TViewModel : BasePageViewModel
    {
        private MvxRecyclerViewX _recordsList;
        private FloatingActionButton _floatingActionButton;

        public override int LayoutId => Resource.Layout.LogView;

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            _recordsList = View.FindViewById<MvxRecyclerViewX>(Resource.Id.List);
            _floatingActionButton = View.FindViewById<FloatingActionButton>(Resource.Id.fab);
        }

        protected override void SubscribeEvents()
        {
            base.SubscribeEvents();
            _recordsList.Scrolled += ListScrollHandler;
        }

        protected override void UnsubscribeEvents()
        {
            base.UnsubscribeEvents();
            _recordsList.Scrolled -= ListScrollHandler;
        }

        private void ListScrollHandler(object sender, (int dx, int dy) scrollArgs)
        {
            var scrollingUp = scrollArgs.dy < 0;
            var scrollingDown = scrollArgs.dy > 0;

            if (scrollingUp)
            {
                _floatingActionButton.Show();
            }
            else if (scrollingDown)
            {
                _floatingActionButton.Hide();
            }
        }
    }
}