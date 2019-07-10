using System;
using System.Collections.Generic;
using CsvHelper.Configuration.Attributes;
using MyLog.Core.Models.Navigation;
using Newtonsoft.Json;

namespace MyLog.Core.Csv.Models
{
    public class RouteDefinitionCsvModel
    {
        [Name("Название")]
        public string Name { get; set; }

        [Name("Выезд из первой точки")] 
        public string StartFromFirstPoint { get; set; }

        [Ignore]
        public bool IsStartFromFirstPoint => !string.IsNullOrWhiteSpace(StartFromFirstPoint);

        [List]
        public IList<WaypointCsvModel> Waypoints { get; set; } = new List<WaypointCsvModel>();
    }

    public class WaypointCsvModel
    {
        [Name("Путевые точки")]
        [JsonProperty("Путевые точки")]
        public Coordinates Coordinates { get; set; }

        [Name("Названия")]
        [JsonProperty("Названия")]
        public string Name { get; set; }

        [Name("Раcстояние")]
        [JsonProperty("Раcстояние")]
        public double Distance { get; set; }

        [Name("Время")]
        [JsonProperty("Время")]
        public TimeSpan Time { get; set; }

        [Name("Скорость")]
        [JsonProperty("Скорость")]
        public double Speed { get; set; }
    }
}
