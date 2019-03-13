using System.Threading.Tasks;

namespace MyLog.Core.Services.Abstract
{
    public interface IFileInputService
    {
        Task<string> ImportTextAsync();
    }
}
