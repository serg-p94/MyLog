using System;
using System.Globalization;
using MvvmCross.Converters;
using MyLog.Core.Enums;

namespace MyLog.Droid.Custom.Converters
{
    public class TrackingStateIconIdConverter : MvxValueConverter<TrackingState, int>
    {
        protected override int Convert(TrackingState value, Type targetType, object parameter, CultureInfo culture)
        {
            var iconResId = 0;

            switch (value)
            {
                case TrackingState.Paused:
                case TrackingState.Stopped:
                    iconResId = Resource.Drawable.ic_play;
                    break;
                case TrackingState.Started:
                    iconResId = Resource.Drawable.ic_pause;
                    break;
            }

            return iconResId;
        }
    }
}