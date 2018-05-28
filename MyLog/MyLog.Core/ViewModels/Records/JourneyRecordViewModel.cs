using System;
using System.Collections.Generic;
using System.Linq;
using MyLog.Core.ViewModels.Components;

namespace MyLog.Core.ViewModels.Records
{
    public class JourneyRecordViewModel : BaseRecordViewModel
    {
        private string _title = "Title";
        private DateComponentViewModel _dateComponent = new DateComponentViewModel { Date = DateTime.Now };

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public DateComponentViewModel DateComponent
        {
            get => _dateComponent;
            set => SetProperty(ref _dateComponent, value);
        }

        public override IList<BaseComponentViewModel> Components { get; } = new List<BaseComponentViewModel> {
            new TextComponentViewModel { Label = "Location Name", Value = "Minsk, Chapaeva" },
            new TextComponentViewModel { Label = "Comment", Value = "This is a test comment" },
            new LocationComponentViewModel()
        };

        public IList<BaseComponentViewModel> CardComponents => Components.Where(c => c is ILabeledValue).ToList();
    }
}
