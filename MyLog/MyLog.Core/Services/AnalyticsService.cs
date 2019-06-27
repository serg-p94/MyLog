using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using MyLog.Core.Services.Abstract;

namespace MyLog.Core.Services
{
    internal class AnalyticsService : IAnalyticsService
    {
        public void Initialize(string appId)
        {
            AppCenter.Start(appId, typeof(Analytics), typeof(Crashes));
        }
    }
}
