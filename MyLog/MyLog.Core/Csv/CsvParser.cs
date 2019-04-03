using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration.Attributes;
using MyLog.Core.Csv.Converters;
using MyLog.Core.Extensions;
using MyLog.Core.Models.Navigation;

namespace MyLog.Core.Csv
{
    public static class CsvParser
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

        public static TModel ParseComplex<TModel>(string complexData)
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
                FillModelLists(model, unparsedData);

                return model;
            }
        }

        private static void FillModelLists<TModel>(TModel model, string data)
        {
            var proptertiesToFill = typeof(TModel).GetProperties()
                .Where(p => p.PropertyType.Name.Contains("IList"));

            var lineEndIndex = data.IndexOf(Environment.NewLine);
            var emptyLine = Environment.NewLine + data.Substring(0, lineEndIndex + Environment.NewLine.Length);
            data.GetParts(Environment.NewLine, out var _, out data);
            var listSections = data.Split(new[] { emptyLine }, StringSplitOptions.RemoveEmptyEntries);

            var listSectionsDictionary = new Dictionary<string, string>(listSections.Length);
            listSections.ForEach(section =>
            {
                section.GetParts(Environment.NewLine, out var nameLine, out var content);
                var name = nameLine.Contains('"') ? nameLine.Split('"')[1] : nameLine.Substring(0, nameLine.IndexOf(','));
                listSectionsDictionary[name] = content;
            });

            foreach (var property in proptertiesToFill)
            {
                var nameAttribute = property.GetCustomAttributes(typeof(NameAttribute), false)
                    .OfType<NameAttribute>().FirstOrDefault();
                var name = nameAttribute?.Names?.FirstOrDefault() ?? property.Name;
                var content = listSectionsDictionary[name];

                using (var stringReader = new StringReader(content))
                using (var csvReader = new CsvReader(stringReader))
                {
                    csvReader.Configuration.TypeConverterCache.AddConverter<Coordinates>(new CoordinatesConverter());

                    var itemType = property.PropertyType.GetGenericArguments().First();
                    var itemConverter = csvReader.Configuration.TypeConverterCache.GetConverter(itemType);

                    if (itemConverter ==null)
                    {
                        var records = csvReader.GetRecords(itemType);
                        throw new NotImplementedException();
                    }
                    else
                    {
                        var list = property.GetValue(model);
                        var addMethod = list.GetType().GetMethod(nameof(ICollection<object>.Add));

                        while (csvReader.Read())
                        {
                            var listItem = csvReader.GetField(itemType, 0);
                            addMethod?.Invoke(list, new[] { listItem });
                        }
                    }
                }
            }
        }
    }
}
