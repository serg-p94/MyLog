using System;
using MvvmCross.ViewModels;

namespace MyLog.Core.ViewModels.Dialogs
{
    public class DatePickerDialogViewModel : MvxViewModel<DateTime, DateTime>
    {
        private DateTime _date;

        public DateTime Date
        {
            get => _date;
            set => SetProperty(ref _date, value);
        }

        public override void Prepare(DateTime parameter)
        {
            Date = parameter;
        }
    }
}
