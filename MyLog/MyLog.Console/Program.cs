using System.Globalization;
using MyLog.Core.Csv;
using MyLog.Core.Csv.Models;

namespace MyLog.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            var r = CsvParser.ParseComplex<RouteDefinitionCsvModel>(CsvData);

            System.Console.WriteLine(r);
        }

        private static string CsvData = @"Название,Выезд из первой точки
Тестовый маршрут,
,
Путевые точки,
""53.675735, 27.222174"",
""53.951938, 27.983312"",
""54.185150, 27.816942"",
""54.118319, 26.596178"",
""53.904024, 27.586986"",";
    }
}
