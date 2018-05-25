using System.Collections.Generic;
using MyLog.Core.ViewModels.Abstract;
using MyLog.Core.ViewModels.Records;

namespace MyLog.Core.ViewModels.Pages
{
    public class JourneyLogViewModel : BasePageViewModel
    {
        public override string Title => "Journey Log";

        public IList<JourneyRecordViewModel> Records { get; } = new List<JourneyRecordViewModel> {
            new JourneyRecordViewModel {
                Title = "First"
            },
            new JourneyRecordViewModel {
                Title = "Second"
            },
            new JourneyRecordViewModel {
                Title = "Third"
            },
            new JourneyRecordViewModel {
                Title = "Fourth"
            },
            new JourneyRecordViewModel {
                Title = "Fifth"
            },
            new JourneyRecordViewModel {
                Title = "Sixth"
            },
        };
    }
}
