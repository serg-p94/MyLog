using System;
using CsvHelper.Configuration.Attributes;
using MyLog.Core.Csv.Converters;

namespace MyLog.Core.Models.RoadTracking
{
    public class Way
    {
        [Name("Откуда")]
        //[TypeConverter(typeof(CoordinatesToWaypointConverter))]
        public Waypoint From { get; set; }

        [Name("Куда")]
        //[TypeConverter(typeof(CoordinatesToWaypointConverter))]
        public Waypoint To { get; set; }

        [Name("Расстояние")]
        public float Distance { get; set; }

        [Name("Выезд")]
        public TimeSpan StartTime { get; set; }

        [Name("Прибытие")]
        public TimeSpan FinishTime { get; set; }

        [Name("Остановка")]
        public TimeSpan PauseTime { get; set; }
    }
}
