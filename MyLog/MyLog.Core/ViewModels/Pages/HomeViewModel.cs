using System.Collections.Generic;
using MyLog.Core.ViewModels.Abstract;
using MyLog.Core.ViewModels.Records;

namespace MyLog.Core.ViewModels.Pages
{
    public class HomeViewModel : BasePageViewModel
    {
        public IList<JourneyRecordViewModel> Records { get; } = new List<JourneyRecordViewModel> {
            new JourneyRecordViewModel {
                Title = "First"
            },
            new JourneyRecordViewModel {
                Title = "Second"
            }
        };
    }
}
