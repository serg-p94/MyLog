using Android.OS;
using Android.Views;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Views.Fragments;
using MyLog.Core.ViewModels.Abstract;

namespace MyLog.Droid.Pages
{
    public abstract class BasePageFragment<TViewModel> : MvxFragment<TViewModel>
        where TViewModel : BasePageViewModel
    {
        public abstract int LayoutId { get; }

        public new SlideMenuHostActivity Activity => (SlideMenuHostActivity) base.Activity;

        public string Title
        {
            get => Activity.SupportActionBar.Title;
            set => Activity.SupportActionBar.Title = value;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);

            return this.BindingInflate(LayoutId, null);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            var bindingSet = this.CreateBindingSet<BasePageFragment<TViewModel>, TViewModel>();
            AddBindings(bindingSet);
            bindingSet.Apply();
        }

        public override void OnStart()
        {
            base.OnStart();
            SubscribeEvents();
        }

        public override void OnStop()
        {
            base.OnStop();
            UnsubscribeEvents();
        }

        protected virtual void AddBindings(MvxFluentBindingDescriptionSet<BasePageFragment<TViewModel>, TViewModel> bindingSet)
        {
            bindingSet.Bind().For(v => v.Title).To(vm => vm.Title);
        }

        protected virtual void SubscribeEvents() { }

        protected virtual void UnsubscribeEvents() { }
    }
}