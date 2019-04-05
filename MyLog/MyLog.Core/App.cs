﻿using System.Globalization;
using MvvmCross;
using MvvmCross.Plugin.Location;
using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;
using MyLog.Core.Csv;
using MyLog.Core.Services;
using MyLog.Core.ViewModels.Pages;

namespace MyLog.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();
            ConfigCulture();
            RegisterServices();
            RegisterAppStart<RoutesCatalogViewModel>();
        }

        private void RegisterServices()
        {
            Mvx.IoCProvider.RegisterSingleton(new LocationService(Mvx.IoCProvider.Resolve<IMvxLocationWatcher>(), Mvx.IoCProvider.Resolve<IMvxMessenger>()));
            Mvx.IoCProvider.RegisterSingleton(new RoadTrackingService());
            Mvx.IoCProvider.RegisterType<ICsvParser, CsvParser>();
        }

        private void ConfigCulture()
        {
            var culture = (CultureInfo)CultureInfo.InvariantCulture.Clone();
            culture.NumberFormat.NumberDecimalSeparator = ".";
            CultureInfo.DefaultThreadCurrentCulture = culture;
        }
    }
}
