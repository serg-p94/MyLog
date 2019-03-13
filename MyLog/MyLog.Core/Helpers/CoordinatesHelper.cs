using System;
using MvvmCross.Plugins.Location;
using MyLog.Core.Models.Navigation;
using MyLog.Core.Models.RoadTracking;

namespace MyLog.Core.Helpers
{
    public static class CoordinatesHelper
    {
        public static Coordinates ToCoordinates(this MvxCoordinates mvxCoordinates) => new Coordinates {
            Latitude = mvxCoordinates.Latitude, Longitude = mvxCoordinates.Longitude
        };

        public static double DistanceTo(this Coordinates c1, Coordinates c2)
        {
            if (c1.Equals(c2))
            {
                return 0;
            }

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
