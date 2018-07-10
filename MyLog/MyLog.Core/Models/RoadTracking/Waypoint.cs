using CsvHelper.Configuration.Attributes;
using MvvmCross.Plugins.Location;
using MyLog.Core.Csv.Converters;

namespace MyLog.Core.Models.RoadTracking
{
    public class Waypoint
    {
        [Name("Название")]
        public string Name { get; set; }

        [Name("Координаты")]
        [TypeConverter(typeof(MvxCoordinatesConverter))]
        public MvxCoordinates Coordinates { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Waypoint waypoint && Equals(waypoint);
        }

        protected bool Equals(Waypoint other)
        {
            return string.Equals(Name, other.Name) && Equals(Coordinates, other.Coordinates);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0) * 397) ^ (Coordinates != null ? Coordinates.GetHashCode() : 0);
            }
        }
    }
}
