namespace MyLog.Core.Managers.Interfaces
{
    public interface ISettingsManager
    {
        TValue GetValue<TValue>(string key);

        void SetValue(string key, object value);
    }
}
