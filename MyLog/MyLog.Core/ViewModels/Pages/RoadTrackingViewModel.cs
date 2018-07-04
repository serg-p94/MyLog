using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using MvvmCross.Plugins.Location;
using MyLog.Core.Csv.Converters;
using MyLog.Core.Models.RoadTracking;
using MyLog.Core.ViewModels.Abstract;
using MyLog.Core.ViewModels.RoadTracking;

namespace MyLog.Core.ViewModels.Pages
{
    public class RoadTrackingViewModel : BasePageViewModel
    {
        public override string Title { get; } = "Road Tracking";

        private static Waypoint From => new Waypoint {
            Name = "From point",
            Coordinates = new MvxCoordinates()
        };

        private static Waypoint To => new Waypoint
        {
            Name = "To point",
            Coordinates = new MvxCoordinates()
        };

        public IList<WayItemViewModel> RoadItems { get; } = new List<WayItemViewModel> {
            new WayItemViewModel(){Distance = 123.45f, StartTime = DateTime.Now, FinishTime = DateTime.Now, RestTime = TimeSpan.FromMinutes(15),
                AverageSpeed = 74.5f,
                From = From, To = To},
            new WayItemViewModel(){Distance = 123.45f, StartTime = DateTime.Now, FinishTime = DateTime.Now, RestTime = TimeSpan.FromMinutes(30),
                AverageSpeed = 74.5f, From = From, To = To},
            new WayItemViewModel(){Distance = 123.45f, StartTime = DateTime.Now, FinishTime = DateTime.Now, RestTime = TimeSpan.FromMinutes(90),
                AverageSpeed = 74.5f, From = From, To = To},
            new WayItemViewModel(){Distance = 123.45f, StartTime = DateTime.Now, FinishTime = DateTime.Now, AverageSpeed = 74.5f,
                From = From, To = To},
            new WayItemViewModel(){Distance = 123.45f, StartTime = DateTime.Now, FinishTime = DateTime.Now, AverageSpeed = 74.5f,
                From = From, To = To},
            new WayItemViewModel(){Distance = 123.45f, StartTime = DateTime.Now, FinishTime = DateTime.Now, AverageSpeed = 74.5f,
                From = From, To = To},

        };

        public RoadTrackingViewModel()
        {
            using (var stringReader = new StringReader(RoadDataRaw))
            using (var csvReader = new CsvReader(stringReader))
            {
                try
                {
                    csvReader.Configuration.TypeConverterCache.AddConverter<MvxCoordinates>(new MvxCoordinatesConverter());
                    var items = csvReader.GetRecords<Waypoint>().ToList();
                }
                catch (Exception e)
                {
                }
            }
        }

        private const string RoadDataRaw = @"Название,Координаты
Минск,""53.835505, 27.609153""
""АЗС, Ивацевичи"",""52.694758, 25.352463""
""АЗС, Домачево"",""51.789418, 23.654755""
""ПТО, Домачево"",""51.765549, 23.592854""
""АЗС ORLEN, Красник"",""50.929217, 22.249868""
""TESCO, Жешув"",""50.018610, 22.012777""
""АЗС ORLEN, Дукля"",""49.565610, 21.691450""
Bajusz Vendégház,""48.521228, 21.252782""";
    }
}
