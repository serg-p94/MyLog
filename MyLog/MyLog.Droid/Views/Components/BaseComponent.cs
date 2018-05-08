using System;
using Android.Content;
using Android.Runtime;
using Android.Util;
using MvvmCross.Binding.Droid.Views;

namespace MyLog.Droid.Views.Components
{
    [Register("mylog.droid.views.components.BaseComponent")]
    public class BaseComponent : MvxFrameControl
    {
        public BaseComponent(Context context, IAttributeSet attrs) : this(Resource.Layout.view_ComponentLayout, context, attrs) { }

        public BaseComponent(int templateId, Context context, IAttributeSet attrs) : base(templateId, context, attrs)
        {
            Initialize();
        }

        protected BaseComponent(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer) { }

        private void Initialize()
        {
            DataContext = new object();
        }
    }
}