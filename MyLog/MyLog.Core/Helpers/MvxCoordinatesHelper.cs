using System;
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

        public static bool IsEqual(this MvxCoordinates c1, MvxCoordinates c2) =>
            c1.Latitude == c2.Latitude && c1.Longitude == c2.Longitude;

        public static double DistanceTo(this MvxCoordinates c1, MvxCoordinates c2)
        {
            var theta = c1.Longitude - c2.Longitude;

            var distance = Math.Sin(DegToRad(c1.Latitude)) * Math.Sin(DegToRad(c2.Latitude)) +
                           Math.Cos(DegToRad(c1.Latitude)) * Math.Cos(DegToRad(c2.Latitude)) *
                           Math.Cos(DegToRad(theta));

            distance = Math.Acos(distance);
            distance = RadToDeg(distance);
            distance = distance * 60 * 1.1515 * 1609.344;

            return distance;
        }

        private static double DegToRad(double deg)
        {
            return deg * Math.PI / 180;
        }

        private static double RadToDeg(double rad)
        {
            return rad / Math.PI * 180;
        }
    }
}
