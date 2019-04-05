using MyLog.Core.Data.Interfaces;
using Realms;

namespace MyLog.Core.Data
{
    internal class RealmManager : IRealmManager
    {
        public Realm Realm => Realm.GetInstance(Configuration);

        private const ulong SchemaVersion = 1;

        private static RealmConfigurationBase Configuration { get; } = new RealmConfiguration {
            SchemaVersion = SchemaVersion,
            MigrationCallback = MigrationCallback,
#if DEBUG
            ShouldDeleteIfMigrationNeeded = true
#endif
        };

        private static void MigrationCallback(Migration migration, ulong oldSchemaVersion)
        {
        }
    }
}
