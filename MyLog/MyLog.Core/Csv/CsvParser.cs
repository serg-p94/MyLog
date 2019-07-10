using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using MyLog.Core.Csv.Converters;
using MyLog.Core.Extensions;
using MyLog.Core.Models.Navigation;
using Newtonsoft.Json;

namespace MyLog.Core.Csv
{
    public class CsvParser : ICsvParser
    {
        public static TModel Parse<TModel>(string data)
        {
            using (var stringReader = new StringReader(data))
            using (var csvReader = new CsvReader(stringReader))
            {
                try
                {
                    csvReader.Configuration.TypeConverterCache.AddConverter<Coordinates>(new CoordinatesConverter());

                    csvReader.Read();
                    csvReader.ReadHeader();
                    csvReader.ValidateHeader<TModel>();

                    csvReader.Read();
                    return csvReader.GetRecord<TModel>();
                }
                catch (Exception e)
                {
                    return default(TModel);
                }
            }
        }

        public static IList<TModel> ParseList<TModel>(string data)
        {
            using (var stringReader = new StringReader(data))
            using (var csvReader = new CsvReader(stringReader))
            {
                try
                {
                    csvReader.Configuration.TypeConverterCache.AddConverter<Coordinates>(new CoordinatesConverter());
                    return csvReader.GetRecords<TModel>().ToList();
                }
                catch (Exception e)
                {
                    return new List<TModel>();
                }
            }
        }

        public TModel ParseComplex<TModel>(string complexData)
        {
            using (var stringReader = new StringReader(complexData))
            using (var csvReader = new CsvReader(stringReader))
            {
                csvReader.Configuration.TypeConverterCache.AddConverter<Coordinates>(new CoordinatesConverter());

                csvReader.Read();
                csvReader.ReadHeader();
                csvReader.ValidateHeader<TModel>();

                csvReader.Read();
                var model = csvReader.GetRecord<TModel>();
                var unparsedData = complexData.Split(new[] { csvReader.Context.RawRecord },
                    StringSplitOptions.None).Last();
                FillModelList(model, unparsedData);

                return model;
            }
        }

        private static void FillModelList<TModel>(TModel model, string data)
        {
            data.GetParts(Environment.NewLine, out _, out data);
            var jsonData = GetJsonString(data);

            var listProperty = typeof(TModel).GetProperties()
                .FirstOrDefault(pi => pi.HasAttribute<ListAttribute>());
            if (listProperty != null)
            {
                var listData = JsonConvert.DeserializeObject(jsonData, listProperty.PropertyType);
                listProperty.SetValue(model, listData);
            }
        }

        private static string GetJsonString(string csvString)
        {
            var lines = csvString.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var headers = lines.First().Split(',').Select(s => s.Trim());
            var data = new List<Dictionary<string, string>>(lines.Length - 1);

            for (int i = 1; i < lines.Length; i++)
            {
                var row = new Dictionary<string, string>();
                var values = new List<string>();

                using (var stringReader = new StringReader(lines[i]))
                using (var csvReader = new CsvReader(stringReader))
                {
                    csvReader.Configuration.TypeConverterCache.AddConverter<Coordinates>(new CoordinatesConverter());

                    if (csvReader.Read())
                    {
                        while (csvReader.TryGetField(values.Count, out string s))
                        {
                            values.Add(s);
                        }
                    }
                }

                headers.ForEach((h, n) => row[h] = values[n]);

                data.Add(row);
            }

            return JsonConvert.SerializeObject(data);
        }
    }
}
