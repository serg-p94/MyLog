﻿using Android.OS;
using Android.Views;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Views;
using MvvmCross.Platforms.Android.Views.Fragments;
using MyLog.Core.ViewModels.Abstract;
using MyLog.Droid.Activities;
using MyLog.Droid.Navigation;

namespace MyLog.Droid.Views.Pages
{
    public abstract class BasePageFragment<TViewModel> : MvxFragment<TViewModel>, IPageFragment
        where TViewModel : BasePageViewModel
    {
        public abstract int LayoutId { get; }

        public virtual NavigationType NavigationType => NavigationType.Lateral;

        public virtual int? MenuId { get; }

        public new SlideMenuHostActivity Activity => (SlideMenuHostActivity) base.Activity;

        public string Title
        {
            get => Activity.SupportActionBar.Title;
            set => Activity.SupportActionBar.Title = value;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetHasOptionsMenu(MenuId.HasValue);
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
            Activity.OnFragmentStart(this);
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

        public override void OnCreateOptionsMenu(IMenu menu, MenuInflater inflater)
        {
            inflater.Inflate(MenuId.Value, menu);
        }
    }

    public interface IPageFragment : IMvxFragmentView
    {
        string Title { get; set; }

        NavigationType NavigationType { get; }

        int? MenuId { get; }
    }
}