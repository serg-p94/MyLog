using System;
using System.Collections.Generic;
using MyLog.Core.ViewModels.Components;

namespace MyLog.Core.ViewModels.Records
{
    public class JourneyRecordViewModel : BaseRecordViewModel
    {
        private string _title = "Title";

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public override IList<BaseComponentViewModel> Components { get; } = new List<BaseComponentViewModel> {
            new TextComponentViewModel { Label = "Location Name", Text = "Text" },
            new TextComponentViewModel { Label = "Comment", Text = "Text" },
            new DateComponentViewModel { Date = DateTime.Now },
            new LocationComponentViewModel()
        };
    }
}
