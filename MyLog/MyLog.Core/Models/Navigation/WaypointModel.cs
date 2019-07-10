using System;
using MyLog.Core.Csv.Models;

namespace MyLog.Core.Models.Navigation
{
    public class WaypointModel
    {
        public Coordinates Coordinates { get; set; }

        public string Name { get; set; }

        public double Distance { get; set; }

        public TimeSpan Time { get; set; }

        public double Speed { get; set; }

        public static WaypointModel FromCsv(WaypointCsvModel csvModel) => new WaypointModel {
            Name = csvModel.Name,
            Coordinates = csvModel.Coordinates,
            Distance = csvModel.Distance,
            Time = csvModel.Time,
            Speed = csvModel.Speed
        };
    }
}
