using System;
using Android.Content;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using MvvmCross.Binding.Droid.Views;

namespace MyLog.Droid.Views.Records
{
    [Register("mylog.droid.views.records.RecordCardView")]
    public class RecordCardView : MvxFrameControl
    {
        public RecordCardView(Context context):this(context, null) { }

        public RecordCardView(Context context, IAttributeSet attrs) : this(Resource.Layout.view_RecordCard, context, attrs) { }

        public RecordCardView(int templateId, Context context, IAttributeSet attrs) : base(templateId, context, attrs)
        {
        }

        protected RecordCardView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer) { }

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
            Content = new RecordContentSelector(this).GetContent(DataContext);
        }
    }
}