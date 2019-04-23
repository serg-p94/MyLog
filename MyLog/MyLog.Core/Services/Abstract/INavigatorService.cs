using MyLog.Core.Models.Navigation;

namespace MyLog.Core.Services.Abstract
{
    public interface INavigatorService
    {
        void StartNavigation(RouteDefinition route);
    }
}
