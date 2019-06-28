using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using MvvmCross.Commands;
using MyLog.Core.Extensions;
using MyLog.Core.Managers.Interfaces;
using MyLog.Core.Services.Abstract;
using MyLog.Core.ViewModels.Abstract;

namespace MyLog.Core.ViewModels.Pages
{
    public class RoutesCatalogViewModel : BasePageViewModel
    {
        protected readonly IRoutesManager RoutesManager;
        protected readonly INavigatorService NavigatorService;

        private bool _isEditMode;

        public RoutesCatalogViewModel(IRoutesManager routesManager, INavigatorService navigatorService)
        {
            RoutesManager = routesManager;
            NavigatorService = navigatorService;
            Routes = RoutesManager.GetRoutesCollection(model => new RouteItemViewModel { Model = model });
        }

        public override string Title => "Routes";

        public ObservableCollection<RouteItemViewModel> Routes { get; }

        public bool IsEditMode
        {
            get => _isEditMode;
            set
            {
                if (SetProperty(ref _isEditMode, value))
                {
                    if (!IsEditMode)
                    {
                        Routes.ForEach(r => r.IsSelected = false);
                    }
                }
            }
        }


        public ICommand AddRouteCommand => new MvxAsyncCommand(RoutesManager.ImportRouteAsync);

        public ICommand ItemClickCommand => new MvxCommand<RouteItemViewModel>(item => {
            if (IsEditMode)
            {
                item.IsSelected = !item.IsSelected;
            }
            else
            {
                NavigatorService.StartNavigation(item.Model);
            }
        });

        public ICommand ItemLongClickCommand => new MvxCommand<RouteItemViewModel>(item => {
            IsEditMode = true;
            item.IsSelected = true;
        });

        public void RemoveSelectedItems()
        {
            RoutesManager.Remove(Routes.Where(r => r.IsSelected).Select(r => r.Model).ToList());
        }
    }
}
