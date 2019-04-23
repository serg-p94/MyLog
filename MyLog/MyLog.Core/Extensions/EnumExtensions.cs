using System;
using System.Globalization;

namespace MyLog.Core.Extensions
{
    public static class EnumExtensions
    {
        public static string ToIntString<T>(this T enumValue) where T : struct, IConvertible
        {
            return enumValue.ToInt32(CultureInfo.CurrentCulture).ToString();
        }
    }
}
