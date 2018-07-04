using System.Globalization;
using System.Linq;
using MvvmCross.Plugins.Location;

namespace MyLog.Core.Helpers
{
    public static class MvxCoordinatesHelper
    {
        public static string ConvertToString(this MvxCoordinates coordinates) =>
            $"{coordinates.Latitude:F6}, {coordinates.Longitude:F6}";

        public static MvxCoordinates Parse(string text)
        {
            var parts = text.Split(',').Select(s => s.Trim()).ToArray();

            return new MvxCoordinates
            {
                Latitude = double.Parse(parts[0], NumberStyles.Number),
                Longitude = double.Parse(parts[1])
            };
        }
    }
}
