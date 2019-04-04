using System.Linq;
using System.Windows.Input;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using MyLog.Core.Csv.Models;
using MyLog.Core.Extensions;
using MyLog.Core.Models.Navigation;
using MyLog.Core.Services.Abstract;
using MyLog.Core.ViewModels.Abstract;
using CsvParser = MyLog.Core.Csv.CsvParser;

namespace MyLog.Core.ViewModels.Pages
{
    public class RoutesCatalogViewModel : BasePageViewModel
    {
        public override string Title => "Routes";

        public MvxObservableCollection<RouteItemViewModel> Routes { get; } =
            new MvxObservableCollection<RouteItemViewModel>();

        public ICommand AddRouteCommand => new MvxAsyncCommand(async () => {
            var csvData = await Mvx.IoCProvider.Resolve<IFileInputService>().ImportTextAsync();
            var csvModel = CsvParser.ParseComplex<RouteDefinitionCsvModel>(csvData);
            var routeModel = new RouteDefinition() {
                Name = csvModel.Name,
                Destination =  csvModel.Waypoints.Last()
            };
            csvModel.Waypoints.Remove(csvModel.Waypoints.Last());

            if (!string.IsNullOrWhiteSpace(csvModel.StartFromFirstPoint))
            {
                routeModel.Origin = csvModel.Waypoints.First();
                csvModel.Waypoints.Remove(routeModel.Origin.Value);
            }

            csvModel.Waypoints.ForEach(routeModel.Waypoints.Add);

            Routes.Add(new RouteItemViewModel { Model = routeModel });
        });

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
