using System.Windows.Input;
using MvvmCross.ViewModels;

namespace MyLog.Core.ViewModels
{
    public class SlideMenuItemViewModel : MvxNotifyPropertyChanged
    {
        public string Title { get; set; }

        public ICommand Command { get; set; }
    }
}
