using System;
using MvvmCross.Core.ViewModels;

namespace MyLog.Core.ViewModels.Records
{
    public abstract class BaseRecordViewModel : MvxNotifyPropertyChanged
    {
        private string _header;
        private DateTime _date;

        public string Header
        {
            get => _header;
            set => SetProperty(ref _header, value);
        }

        public DateTime Date
        {
            get => _date;
            set => SetProperty(ref _date, value);
        }
    }
}
