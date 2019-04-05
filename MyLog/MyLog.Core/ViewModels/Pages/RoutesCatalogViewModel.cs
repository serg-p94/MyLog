using System.Collections.ObjectModel;
using System.Windows.Input;
using MvvmCross;
using MvvmCross.Commands;
using MyLog.Core.Data;
using MyLog.Core.Data.Interfaces;
using MyLog.Core.Data.RealmModels;
using MyLog.Core.Managers.Interfaces;
using MyLog.Core.ViewModels.Abstract;

namespace MyLog.Core.ViewModels.Pages
{
    public class RoutesCatalogViewModel : BasePageViewModel
    {
        protected readonly IRoutesManager RoutesManager = Mvx.IoCProvider.Resolve<IRoutesManager>();

        public override string Title => "Routes";

        public ObservableCollection<RouteItemViewModel> Routes =>
            new RealmObservableCollection<RouteDbModel, RouteItemViewModel>(RoutesManager.StoredRoutes,
                db => new RouteItemViewModel { Model = db.Definition });


        public ICommand AddRouteCommand => new MvxAsyncCommand(async () => {
            await RoutesManager.ImportRoute();
        });

        public RoutesCatalogViewModel()
        {
            var r = Mvx.IoCProvider.Resolve<IRealmManager>().Realm;

//            var rr = RoutesManager.StoredRoutes;
//
//            Task.Run(() => {
//                Routes = new RealmObservableCollection<RouteDbModel, RouteItemViewModel>(RoutesManager.StoredRoutes,
//                    db => new RouteItemViewModel { Model = db.Definition });
//                RaisePropertyChanged(() => Routes);
//            });
        }
    }
}
