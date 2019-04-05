using System;
using System.Runtime.CompilerServices;
using Realms;

namespace MyLog.Core.Data.Interfaces
{
    public interface IDbService
    {
        TData GetData<TData>(Func<Realm, TData> select, [CallerMemberName] string caller = null);

        void EditData(Action<Realm> action, [CallerMemberName] string caller = null);
    }
}
