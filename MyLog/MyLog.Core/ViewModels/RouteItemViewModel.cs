using System;
using System.Collections.Generic;
using System.Text;
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
        private RouteDefinition _model;

        protected NavigatorService NavigatorService { get; } = Mvx.IoCProvider.Resolve<NavigatorService>();

        // TODO: remove
        public RouteDefinition Model
        {
            private get => _model;
            set => SetProperty(ref _model, value);
        }

        public string Name => Model.Name;

        public ICommand Command => new MvxCommand(() => NavigatorService.StartNavigation(Model));
    }
}
