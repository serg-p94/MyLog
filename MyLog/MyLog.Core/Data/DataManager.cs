using System.Collections.Generic;
using MyLog.Core.ViewModels.Records;

namespace MyLog.Core.Data
{
    public class DataManager
    {
        public IList<JourneyRecordViewModel> Records { get; } = new List<JourneyRecordViewModel>();
    }
}
