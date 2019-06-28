using MvvmCross.ViewModels;
using MyLog.Core.Models.Navigation;

namespace MyLog.Core.ViewModels
{
    public class RouteItemViewModel : MvxNotifyPropertyChanged
    {
        private bool _isSelected;

        public RouteDefinition Model { get; set; }

        public string Name => Model.Name;

        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }
    }
}
