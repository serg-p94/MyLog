using Android.App;
using Android.Content;
using MyLog.Core.Services;
using Newtonsoft.Json;

namespace MyLog.Droid.Services
{
    public class StorageService : IStorageService
    {
        public string GetStringPreference(string propertyKey)
        {
            ISharedPreferences pref = Application.Context.GetSharedPreferences(
                Application.Context.PackageName,
                FileCreationMode.Private);
            return pref.GetString(propertyKey, "");
        }

        public void SaveStringPreference(string propertyKey, string value)
        {
            ISharedPreferences pref = Application.Context.GetSharedPreferences(
                Application.Context.PackageName,
                FileCreationMode.Private);
            ISharedPreferencesEditor prefEditor = pref.Edit();
            prefEditor.PutString(propertyKey, value);
            prefEditor.Commit();
        }

        public void SaveData(string key, object data)
        {
            var json = JsonConvert.SerializeObject(data);
            SaveStringPreference(key, json);
        }

        public TData Restore<TData>(string key)
        {
            var json = GetStringPreference(key);
            return JsonConvert.DeserializeObject<TData>(json);
        }

        public bool TryRestore<TData>(string key, out TData data)
        {
            data = Restore<TData>(key);
            return data != null;
        }

        public void Remove(string key)
        {
            using (var preferences = Application.Context.GetSharedPreferences(Application.Context.PackageName, FileCreationMode.Private))
            using (var editor = preferences.Edit())
            {
                editor.Remove(key);
                editor.Commit();
            }
        }
    }
}