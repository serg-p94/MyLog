namespace MyLog.Core.Models
{
    public struct GpsCoordinates
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public override string ToString() => $"{Latitude:F6}, {Longitude:F6}";
    }
}
