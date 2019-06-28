using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MyLog.Core.Models.Navigation;

namespace MyLog.Core.Managers.Interfaces
{
    public interface IRoutesManager
    {
        ObservableCollection<TModel> GetRoutesCollection<TModel>(Func<RouteDefinition, TModel> convert);
        Task ImportRouteAsync();
        void Remove(IList<RouteDefinition> routes);
    }
}
