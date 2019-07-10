using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using MyLog.Core.Csv;
using MyLog.Core.Csv.Models;
using MyLog.Core.Data;
using MyLog.Core.Data.Interfaces;
using MyLog.Core.Data.RealmModels;
using MyLog.Core.Extensions;
using MyLog.Core.Managers.Interfaces;
using MyLog.Core.Models.Navigation;
using MyLog.Core.Services.Abstract;
using Realms;

namespace MyLog.Core.Managers
{
    internal class RoutesManager : IRoutesManager
    {
        protected readonly ICsvParser CsvParser;
        protected readonly IFileInputService FileInputService;
        protected readonly IDbService DbService;

        public RoutesManager(ICsvParser csvParser, IFileInputService fileInputService, IDbService dbService)
        {
            CsvParser = csvParser;
            FileInputService = fileInputService;
            DbService = dbService;
        }

        public ObservableCollection<TModel> GetRoutesCollection<TModel>(Func<RouteDefinition, TModel> convert)
        {
            var realmCollection = DbService.GetData(r => r.All<RouteDbModel>().AsRealmCollection());
            return new RealmObservableCollection<RouteDbModel, TModel>(realmCollection, db => {
                var definition = db.Definition;
                definition.Id = db.Id;
                return convert(definition);
            });
        }

        public async Task ImportRouteAsync()
        {
            var csvData = await FileInputService.ImportTextAsync();
            var csvModel = CsvParser.ParseComplex<RouteDefinitionCsvModel>(csvData);
            var routeModel = RouteDefinition.FromCsvModel(csvModel);
            DbService.EditData(r => r.Add(new RouteDbModel {
                Id = Guid.NewGuid().ToString(),
                Definition = routeModel
            }));
        }

        // TODO: Optimize
        public void Remove(IList<RouteDefinition> routes) => DbService.EditData(realm => {
            routes.ForEach(r => {
                var dbModel = realm.Find<RouteDbModel>(r.Id);
                realm.Remove(dbModel);
            });
        });
    }
}
