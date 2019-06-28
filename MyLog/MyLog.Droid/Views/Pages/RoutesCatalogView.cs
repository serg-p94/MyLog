using System;
using MvvmCross.Binding;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MyLog.Core.ViewModels;
using MyLog.Core.ViewModels.Pages;
using MyLog.Droid.Extensions;

namespace MyLog.Droid.Views.Pages
{
    [MvxFragmentPresentation(typeof(SlideMenuHostViewModel), Resource.Id.FragmentContainer, true)]
    public class RoutesCatalogView : BasePageFragment<RoutesCatalogViewModel>
    {
        private bool _isEditMode;

        public event EventHandler IsEditModeChanged;

        public override int LayoutId => Resource.Layout.RoutesCatalogView;

        public bool IsEditMode
        {
            get => _isEditMode;
            set
            {
                if (_isEditMode != value)
                {
                    _isEditMode = value;
                    IsEditModeChanged?.Invoke(this, EventArgs.Empty);

                    if (IsEditMode)
                    {
                        StartEditMode();
                    }
                }
            }
        }

        protected override void AddBindings(MvxFluentBindingDescriptionSet<BasePageFragment<RoutesCatalogViewModel>, RoutesCatalogViewModel> bindingSet)
        {
            base.AddBindings(bindingSet);

            bindingSet.Bind(this).For(v => v.IsEditMode).To(vm => vm.IsEditMode).Mode(MvxBindingMode.TwoWay);
        }

        private async void StartEditMode()
        {
            var actionModeResult = await Activity.StartActionModeAsync(Resource.Menu.road_tracking);

            switch (actionModeResult)
            {
                case Resource.Id.action_delete:
                    ViewModel.RemoveSelectedItems();
                    break;
            }

            IsEditMode = false;
        }
    }
}