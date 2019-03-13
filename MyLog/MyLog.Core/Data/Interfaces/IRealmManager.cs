using Realms;

namespace Common.DB.Interfaces
{
    public interface IRealmManager
    {
        Realm Realm { get; }
    }
}
