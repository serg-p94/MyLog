using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace MyLog.Core.ViewModels
{
    public class SlideMenuItemViewModel : MvxNotifyPropertyChanged
    {
        public string Title { get; set; }

        public ICommand Command { get; set; }
    }
}
