using System.Collections.ObjectModel;
using System.Windows.Input;
using MvvmCross.Commands;
using MyLog.Core.Managers.Interfaces;
using MyLog.Core.ViewModels.Abstract;

namespace MyLog.Core.ViewModels.Pages
{
    public class RoutesCatalogViewModel : BasePageViewModel
    {
        protected readonly IRoutesManager RoutesManager;

        public RoutesCatalogViewModel(IRoutesManager routesManager)
        {
            RoutesManager = routesManager;
        }

        public override string Title => "Routes";

        public ObservableCollection<RouteItemViewModel> Routes =>
            RoutesManager.GetRoutesCollection(RouteItemViewModel.FromModel);


        public ICommand AddRouteCommand => new MvxAsyncCommand(RoutesManager.ImportRouteAsync);
    }
}
