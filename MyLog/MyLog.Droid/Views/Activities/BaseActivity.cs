using Android.OS;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;
using MyLog.Droid.Views.Activities.Decorators;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using MyLog.Core.Extensions;

namespace MyLog.Droid.Views.Activities
{
    public abstract class BaseActivity<TViewModel> : MvxAppCompatActivity<TViewModel> where TViewModel : MvxViewModel
    {
        protected abstract int LayoutId { get; }

        protected virtual void Subscribe() { }

        protected virtual void Unsubscribe() { }

        private IList<IActivityDecorator> Decorators { get; }

        protected BaseActivity()
        {
            Decorators = new List<IActivityDecorator> {
                new GoogleServicesActivityDecorator(this)
            };
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(LayoutId);
        }

        protected override void OnStart()
        {
            base.OnStart();
            Subscribe();
            Decorators.ForEach(d => d.OnStart());
        }

        protected override void OnStop()
        {
            base.OnStop();
            Unsubscribe();
            Decorators.ForEach(d => d.OnStop());
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            Decorators.ForEach(d => d.OnActivityResult(requestCode, resultCode, data));
        }
    }
}