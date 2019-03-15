using MvvmCross.ViewModels;

namespace MyLog.Core.ViewModels.Components
{
    public abstract class BaseComponentViewModel : MvxNotifyPropertyChanged
    {
        private bool _isEditMode;

        public bool IsEditMode
        {
            get => _isEditMode;
            set => SetProperty(ref _isEditMode, value);
        }
    }
}
