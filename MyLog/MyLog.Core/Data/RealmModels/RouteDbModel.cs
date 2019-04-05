using MyLog.Core.Models.Navigation;
using Newtonsoft.Json;
using Realms;

namespace MyLog.Core.Data.RealmModels
{
    [MapTo("Routes")]
    public class RouteDbModel : RealmObject
    {
        [MapTo("Definition")]
        private string _definition { get; set; }

        public RouteDefinition Definition
        {
            get => JsonConvert.DeserializeObject<RouteDefinition>(_definition);
            set => _definition = JsonConvert.SerializeObject(value);
        }
    }
}
