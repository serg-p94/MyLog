using MvvmCross.Core.ViewModels;

namespace MyLog.Core.ViewModels.Dialogs
{
    public class DialogOptionViewModel : MvxNotifyPropertyChanged
    {
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
