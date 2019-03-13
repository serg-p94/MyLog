using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

using Common.DB.Interfaces;

using Realms;

namespace Common.DB.Abstract
{
    public abstract class BaseDbService
    {
        protected IRealmManager RealmManager { get; }

        protected BaseDbService(IRealmManager realmManager)
        {
            RealmManager = realmManager;
        }

        protected TData GetData<TData>(Func<Realm, TData> select, [CallerMemberName] string caller = null)
        {
            try
            {
                return select(RealmManager.Realm);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Realm error in {0}: {1}", caller, ex.Message);

                throw;
            }
        }

        protected void EditData(Action<Realm> action, [CallerMemberName] string caller = null)
        {
            try
            {
                var realm = RealmManager.Realm;

                using (var transaction = realm.BeginWrite())
                {
                    action(realm);
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Realm error in {0}: {1}", caller, ex.Message);

                throw;
            }
        }
    }
}
