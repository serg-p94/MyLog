using System.Windows.Input;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using MyLog.Core.Models.Navigation;
using MyLog.Core.Services.Abstract;

namespace MyLog.Core.ViewModels
{
    public class RouteItemViewModel : MvxNotifyPropertyChanged
    {
        protected INavigatorService NavigatorService;

        private RouteDefinition _model;

        public RouteItemViewModel(INavigatorService navigatorService)
        {
            NavigatorService = navigatorService;
        }

        private RouteDefinition Model
        {
            get => _model;
            set => _model = value;
        }

        public string Name => Model.Name;

        public ICommand Command => new MvxCommand(() => NavigatorService.StartNavigation(Model));

        public static RouteItemViewModel FromModel(RouteDefinition model)
            => new RouteItemViewModel(Mvx.IoCProvider.Resolve<INavigatorService>()) { Model = model };
    }
}
