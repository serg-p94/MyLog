using MyLog.Core.Data.Interfaces;
using Realms;

namespace MyLog.Core.Data
{
    internal class RealmManager : IRealmManager
    {
        private const ulong SchemaVersion = 1;

        public RealmManager()
        {
            // This is necessary to initialize Realm (perform migration) during application start instead of first DB request
            var ignored = Realm;
        }

        public Realm Realm => Realm.GetInstance(Configuration);

        private RealmConfigurationBase Configuration { get; } = new RealmConfiguration {
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
