using System;
using MyLog.Core.ViewModels.Abstract;
using MyLog.Core.ViewModels.Components;
using MyLog.Core.ViewModels.Records;

namespace MyLog.Core.ViewModels.Pages
{
    public class AddRecordViewModel : BasePageViewModel
    {
        public override string Title => "Add Record";

        public JourneyRecordViewModel RecordModel { get; } = new JourneyRecordViewModel {
            Title = "Title",
            DateComponent = new DateComponentViewModel { Date = DateTime.Now }
        };
    }
}
