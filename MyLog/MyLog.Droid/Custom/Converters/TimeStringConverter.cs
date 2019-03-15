using System;
using System.Globalization;
using MvvmCross.Converters;

namespace MyLog.Droid.Custom.Converters
{
    public class TimeStringConverter : MvxValueConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string timeString = null;

            if (value is DateTime date)
            {
                if (date.Date == DateTime.Today)
                {
                    timeString = date.ToShortTimeString();
                }
                else
                {
                    timeString = date.ToString(culture);
                }
            }
            else if (value is TimeSpan time)
            {
                timeString = time.ToString("hh\\:mm");
            }

            return timeString;
        }
    }
}