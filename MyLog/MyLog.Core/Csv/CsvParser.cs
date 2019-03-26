using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using MyLog.Core.Csv.Converters;
using MyLog.Core.Models.Navigation;

namespace MyLog.Core.Csv
{
    public static class CsvParser
    {
        public static IList<TModel> Parse<TModel>(string data)
        {
            using (var stringReader = new StringReader(data))
            using (var csvReader = new CsvReader(stringReader))
            {
                try
                {
                    csvReader.Configuration.TypeConverterCache.AddConverter<Coordinates>(new CoordinatesConverter());
                    return csvReader.GetRecords<TModel>().ToList();

                    /*csvReader.Configuration.TypeConverterCache.AddConverter<Waypoint>(new CoordinatesToWaypointConverter());
                    var ways = csvReader.GetRecords<Way>().ToList();
                    ways.Select(w => new WayItemViewModel
                    {
                        StartTime = w.StartTime,
                        From = w.From,
                        To = w.To,
                        Distance = w.Distance,
                        FinishTime = w.FinishTime,
                        RestTime = w.PauseTime
                    }).ForEach(RoadItems.Add);*/
                }
                catch (Exception e)
                {
                    return new List<TModel>();
                }
            }
        }

        public static string ToCsv<TModel>(TModel model)
        {
            using(var tw = new StringWriter())
            using (var csvWriter = new CsvWriter(tw))
            {
                /*csvWriter.WriteHeader<TModel>();
                csvWriter.Flush();*/

                tw.WriteLine("Name,Origin,Destination,Waypoints");
                csvWriter.WriteRecord(model);
                csvWriter.Flush();

                return tw.ToString();
            }
        }
    }
}
