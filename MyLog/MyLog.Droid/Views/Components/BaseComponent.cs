using System;
using Android.Content;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Binding.Droid.Views;

namespace MyLog.Droid.Views.Components
{
    [Register("mylog.droid.views.components.BaseComponent")]
    public class BaseComponent : MvxFrameControl
    {
        public BaseComponent(Context context):this(context, null) { }

        public BaseComponent(Context context, IAttributeSet attrs) : this(Resource.Layout.view_ComponentLayout, context, attrs) { }

        public BaseComponent(int templateId, Context context, IAttributeSet attrs) : base(templateId, context, attrs)
        {
            Initialize();
        }

        protected BaseComponent(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer) { }

        protected CardView Container { get; private set; }

        public new View Content
        {
            get => Container.ChildCount > 0 ? Container.GetChildAt(0) : null;
            set
            {
                Container.RemoveAllViews();
                Container.AddView(value);
            }
        }

        protected override void OnContentSet()
        {
            base.OnContentSet();
            Container = base.Content.FindViewById<CardView>(Resource.Id.Container);
            Content = new ContentSelector(this).GetContent(DataContext);
        }

        private void Initialize()
        {
            //DataContext = "Test string DataContext";
        }
    }
}