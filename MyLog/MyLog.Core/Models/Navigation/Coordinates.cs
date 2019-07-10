using System.Globalization;
using System.Linq;
using MyLog.Core.Converters;
using Newtonsoft.Json;

namespace MyLog.Core.Models.Navigation
{
    [JsonConverter(typeof(CoordinatesJsonConverter))]
    public struct Coordinates
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public override string ToString() => $"{Latitude:F6},{Longitude:F6}";

        public static Coordinates Parse(string text)
        {
            var parts = text.Split(',').Select(s => s.Trim()).ToArray();
            return new Coordinates {
                Latitude = double.Parse(parts[0], NumberStyles.Number),
                Longitude = double.Parse(parts[1])
            };
        }
    }
}
