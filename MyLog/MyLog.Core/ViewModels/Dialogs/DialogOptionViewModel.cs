using MvvmCross.ViewModels;

namespace MyLog.Core.ViewModels.Dialogs
{
    public class DialogOptionViewModel : MvxNotifyPropertyChanged
    {
        private bool _isSelected;

        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }
    }

    public class DialogOptionViewModel<T> : DialogOptionViewModel
    {
        public T Data { get; set; }

        public override string ToString()
        {
            return Data?.ToString() ?? nameof(DialogOptionViewModel);
        }
    }
}
