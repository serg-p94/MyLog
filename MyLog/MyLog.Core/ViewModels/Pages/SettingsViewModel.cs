using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using MvvmCross.Commands;
using MyLog.Core.Enums;
using MyLog.Core.Extensions;
using MyLog.Core.Managers.Interfaces;
using MyLog.Core.ViewModels.Abstract;
using MyLog.Core.ViewModels.Dialogs;

namespace MyLog.Core.ViewModels.Pages
{
    public class SettingsViewModel : BasePageViewModel
    {
        protected ISettingsManager SettingsManager;

        private NavigatorType _navigatorType;

        public SettingsViewModel(ISettingsManager settingsManager)
        {
            SettingsManager = settingsManager;
            NavigatorType = SettingsManager.GetValue<NavigatorType>(SettingType.NavigatorType.ToIntString());
        }

        public override string Title => "Settings";

        private NavigatorType NavigatorType
        {
            get => _navigatorType;
            set
            {
                if (SetProperty(ref _navigatorType, value))
                {
                    SettingsManager.SetValue(SettingType.NavigatorType.ToIntString(), value);
                    RaisePropertyChanged(() => NavigatorName);
                }
            }
        }

        public string NavigatorName => NavigatorType.ToString();

        public ICommand SelectNavigatorCommand => new MvxCommand(async () => {
            var selectedResult = await NavigationService.Navigate<ListDialogViewModel,
                IEnumerable<DialogOptionViewModel>, DialogOptionViewModel>(
                new[] { NavigatorType.Google, NavigatorType.Yandex }.Select(t =>
                    new DialogOptionViewModel<NavigatorType> {
                        Data = t, IsSelected = NavigatorType == t
                    }));

            if (selectedResult != null)
            {
                NavigatorType = ((DialogOptionViewModel<NavigatorType>)selectedResult).Data;
            }
        });
    }
}
