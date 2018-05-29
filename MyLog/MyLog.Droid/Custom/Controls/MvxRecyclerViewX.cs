using System;
using Android.Content;
using Android.Runtime;
using Android.Util;
using MvvmCross.Droid.Support.V7.RecyclerView;

namespace MyLog.Droid.Custom.Controls
{
    public class MvxRecyclerViewX : MvxRecyclerView
    {
        public MvxRecyclerViewX(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer) { }
        public MvxRecyclerViewX(Context context, IAttributeSet attrs) : base(context, attrs) { }
        public MvxRecyclerViewX(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle) { }

        public MvxRecyclerViewX(Context context, IAttributeSet attrs, int defStyle, IMvxRecyclerAdapter adapter) : base(
            context, attrs, defStyle, adapter) { }

        public event EventHandler<(int dx, int dy)> Scrolled;

        public override void OnScrolled(int dx, int dy)
        {
            base.OnScrolled(dx, dy);
            Scrolled?.Invoke(this, (dx, dy));
        }
    }
}