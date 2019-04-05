using System.Threading.Tasks;
using MyLog.Core.Data.RealmModels;
using Realms;

namespace MyLog.Core.Managers.Interfaces
{
    public interface IRoutesManager
    {
        IRealmCollection<RouteDbModel> StoredRoutes { get; }
        Task ImportRoute();
    }
}
