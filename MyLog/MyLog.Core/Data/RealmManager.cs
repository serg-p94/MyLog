using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Common.DB.Interfaces;
using Realms;

namespace MyLog.Core.Data
{
    internal class RealmManager : IRealmManager
    {
        public Realm Realm => Realm.GetInstance(Configuration);

        public void ClearStorage(IEnumerable<Type> ignoredClasses)
        {
            var ignoredClassNames = ignoredClasses.Select(type => type.GetCustomAttribute<MapToAttribute>().Mapping);
            var classNamesToDelete = Realm.Schema.Select(s => s.Name).Except(ignoredClassNames).ToList();

            Realm.Write(() => classNamesToDelete.ForEach(Realm.RemoveAll));
        }

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
