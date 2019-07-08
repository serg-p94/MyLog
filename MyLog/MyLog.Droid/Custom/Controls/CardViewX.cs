using System;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;

namespace MyLog.Droid.Custom.Controls
{
    public class CardViewX : CardView
    {
        protected CardViewX(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer) { }

        public CardViewX(Context context) : base(context)
        {
            Init();
        }

        public CardViewX(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Init();
        }

        public CardViewX(Context context, IAttributeSet attrs, int defStyleAttr) :
            base(context, attrs, defStyleAttr)
        {
            Init();
        }

        private Color SelectionColor { get; set; }

        private void Init()
        {
            // HACK: this is necessary to prevent linking the property
            Selected = Selected;

            SelectionColor = Resources.GetColor(Resource.Color.primaryLightColor, Context.Theme);

            using (var drawableSelector = new StateListDrawable())
            using (var selectableBackgroundColor = GetBackgroundColorSelector())
            using (var originalBackground = Background)
            using (var rippleColor = GetRippleColorSelector())
            using (var rippleDrawable = new RippleDrawable(rippleColor, originalBackground, originalBackground))
            {
                CardBackgroundColor = selectableBackgroundColor;
                drawableSelector.AddState(new[] { Android.Resource.Attribute.StateSelected }, originalBackground);
                drawableSelector.AddState(new int[0], rippleDrawable);
                Background = drawableSelector;
            }
        }

        private ColorStateList GetRippleColorSelector() => new ColorStateList(
            new[] {
                new[] { Android.Resource.Attribute.StatePressed },
                new int [0]
            }, new int[] {
                SelectionColor,
                Color.Transparent
            });

        private ColorStateList GetBackgroundColorSelector() => new ColorStateList(
            new[] {
                new[] { Android.Resource.Attribute.StateSelected },
                new int[0]
            },
            new int[] {
                SelectionColor,
                Color.White
            });
    }
}