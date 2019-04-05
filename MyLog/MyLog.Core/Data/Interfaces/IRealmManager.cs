using Realms;

namespace MyLog.Core.Data.Interfaces
{
    public interface IRealmManager
    {
        Realm Realm { get; }
    }
}
