using System;
using System.Globalization;
using MvvmCross.Converters;

namespace MyLog.Droid.Custom.Converters
{
    public class SpeedStringConverter : MvxValueConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return $"{value:F0} км/ч";
        }
    }
}