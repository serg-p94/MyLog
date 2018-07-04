using System;
using System.Globalization;
using MvvmCross.Platform.Converters;
using MvvmCross.Plugins.Location;
using MyLog.Core.Helpers;

namespace MyLog.Droid.Custom.Converters
{
    public class CoordinatesToStringConverter : MvxValueConverter<MvxCoordinates, string>
    {
        protected override string Convert(MvxCoordinates value, Type targetType, object parameter,
            CultureInfo culture) => value.ConvertToString();
    }
}