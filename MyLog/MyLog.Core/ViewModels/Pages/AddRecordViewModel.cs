using System;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MyLog.Core.ViewModels.Abstract;
using MyLog.Core.ViewModels.Dialogs;
using MyLog.Core.ViewModels.Records;

namespace MyLog.Core.ViewModels.Pages
{
    public class AddRecordViewModel : BasePageViewModel
    {
        public override string Title => "Add Record";

        public JourneyRecordViewModel RecordModel { get; } = new JourneyRecordViewModel {
            Header = "Header",
            Date = DateTime.Now
        };

        public ICommand SelectDateCommand => new MvxAsyncCommand(async () => RecordModel.Date =
            await NavigationService.Navigate<DatePickerDialogViewModel, DateTime, DateTime>(RecordModel.Date));
    }
}
