using System;
using System.Globalization;
using MvvmCross.Converters;

namespace MyLog.Droid.Custom.Converters
{
    public class DistanceStringConverter : MvxValueConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return $"{value:F1} км";
        }
    }
}