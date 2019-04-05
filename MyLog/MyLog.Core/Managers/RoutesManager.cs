using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using MyLog.Core.Csv;
using MyLog.Core.Csv.Models;
using MyLog.Core.Data.Interfaces;
using MyLog.Core.Data.RealmModels;
using MyLog.Core.Managers.Interfaces;
using MyLog.Core.Models.Navigation;
using MyLog.Core.Services.Abstract;
using Realms;

namespace MyLog.Core.Managers
{
    public class RoutesManager : IRoutesManager
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

        public IRealmCollection<RouteDbModel> StoredRoutes {
            get
            {
                try
                {
                    var d = DbService.GetData(r => r.All<RouteDbModel>());
                    return DbService.GetData(r => r.All<RouteDbModel>().AsRealmCollection());
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public async Task ImportRoute()
        {
            var csvData = await FileInputService.ImportTextAsync();
            var csvModel = CsvParser.ParseComplex<RouteDefinitionCsvModel>(csvData);
            var routeModel = RouteDefinition.FromCsvModel(csvModel);
            DbService.EditData(r => r.Add(new RouteDbModel { Definition = routeModel }));
        }
    }
}
