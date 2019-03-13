using Realms;

namespace MyLog.Core.Data
{
    internal class DbManager
    {
        public Realm Realm => Realm.GetInstance(Configuration);

        private static RealmConfigurationBase Configuration { get; } = new RealmConfiguration {
            ShouldDeleteIfMigrationNeeded = true
        };
    }
}
