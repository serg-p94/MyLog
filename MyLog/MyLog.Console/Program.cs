using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLog.Core.Csv;
using MyLog.Core.Models.Navigation;

namespace MyLog.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = CsvParser.ToCsv(new RouteDefinition {
                Name = "Some name",
                Origin = Coordinates.Parse("0.123, 0.456"),
                Destination = Coordinates.Parse("0.111, 0.222"),
                Waypoints = {
                    Coordinates.Parse("0.001, 0.002"),
                    Coordinates.Parse("0.011, 0.022")
                }
            });

            var r = CsvParser.Parse<RouteDefinition>(s);

            System.Console.WriteLine(s);
        }

        static string CsvData = "Name,Origin,Destination"+Environment.NewLine+
                                "N1,\"0.111000,0.111001\""
    }
}
