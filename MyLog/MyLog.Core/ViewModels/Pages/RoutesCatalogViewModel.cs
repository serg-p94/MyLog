using System;
using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using MyLog.Core.Csv;
using MyLog.Core.Models.Navigation;
using MyLog.Core.ViewModels.Abstract;

namespace MyLog.Core.ViewModels.Pages
{
    public class RoutesCatalogViewModel : BasePageViewModel
    {
        public override string Title => "Routes";

        public MvxObservableCollection<RouteDefinition> Routes { get; } =
            new MvxObservableCollection<RouteDefinition>();

        /*public ICommand AddRouteCommand => new MvxCommand(() => {
            CsvParser.Parse<Coordinates>(@"Latitude, Longitude
""53.931073"", ""27.576931""
""53.907636"", ""27.433679""");
        });*/

        private RouteDefinition MockRoute => new RouteDefinition {
            Name = $"Test route #{Routes.Count + 1}",
            Destination = new Coordinates { Latitude = 53.834381, Longitude = 27.60872 },
            Waypoints = {
                Coordinates.Parse("53.931073, 27.576931"),
                Coordinates.Parse("53.907636, 27.433679")
            }
        };
    }
}
