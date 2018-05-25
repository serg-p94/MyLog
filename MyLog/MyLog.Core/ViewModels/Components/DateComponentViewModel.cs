using System;

namespace MyLog.Core.ViewModels.Components
{
    public class DateComponentViewModel : BaseComponentViewModel
    {
        private DateTime _date;

        public DateTime Date
        {
            get => _date;
            set => SetProperty(ref _date, value);
        }
    }
}
