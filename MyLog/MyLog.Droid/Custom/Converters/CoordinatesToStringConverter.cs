using System;
using System.Globalization;
using MvvmCross.Platform.Converters;
using MvvmCross.Plugins.Location;

namespace MyLog.Droid.Custom.Converters
{
    public class CoordinatesToStringConverter : MvxValueConverter<MvxCoordinates, string>
    {
        protected override string Convert(MvxCoordinates value, Type targetType, object parameter,
            CultureInfo culture) => $"{value.Latitude:F6}, {value.Longitude:F6}";
    }
}