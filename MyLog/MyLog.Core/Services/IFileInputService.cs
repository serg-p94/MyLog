using System.Threading.Tasks;

namespace MyLog.Core.Services
{
    public interface IFileInputService
    {
        Task<string> ImportTextAsync();
    }
}
