namespace MyLog.Core.Services.Abstract
{
    public interface IStorageService
    {
        void SaveData(string key, object data);

        TData Restore<TData>(string key);

        bool TryRestore<TData>(string key, out TData data);
    }
}
