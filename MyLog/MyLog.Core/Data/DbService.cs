using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MyLog.Core.Data.Interfaces;
using Realms;

namespace MyLog.Core.Data
{
    internal class DbService : IDbService
    {
        protected readonly IRealmManager RealmManager;

        public DbService(IRealmManager realmManager)
        {
            RealmManager = realmManager;
        }

        public TData GetData<TData>(Func<Realm, TData> select, [CallerMemberName] string caller = null)
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

        public void EditData(Action<Realm> action, [CallerMemberName] string caller = null)
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
