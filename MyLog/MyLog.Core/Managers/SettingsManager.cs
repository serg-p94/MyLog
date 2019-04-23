using MyLog.Core.Managers.Interfaces;
using Newtonsoft.Json;
using Plugin.Settings;

namespace MyLog.Core.Managers
{
    internal class SettingsManager : ISettingsManager
    {
        public TValue GetValue<TValue>(string key)
        {
            var jsonValue = CrossSettings.Current.GetValueOrDefault(key, null);
            return jsonValue != null ? JsonConvert.DeserializeObject<TValue>(jsonValue) : default(TValue);
        }

        public void SetValue(string key, object value)
        {
            var jsonValue = JsonConvert.SerializeObject(value);
            CrossSettings.Current.AddOrUpdateValue(key, jsonValue);
        }
    }
}
