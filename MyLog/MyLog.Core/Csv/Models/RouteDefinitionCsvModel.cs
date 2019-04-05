using System.Collections.Generic;
using CsvHelper.Configuration.Attributes;
using MyLog.Core.Models.Navigation;

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

        [Name("Путевые точки")]
        public IList<Coordinates> Waypoints { get; } = new List<Coordinates>();
    }
}
