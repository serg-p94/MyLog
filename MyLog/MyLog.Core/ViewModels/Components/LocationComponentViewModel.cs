using MyLog.Core.Models;

namespace MyLog.Core.ViewModels.Components
{
    public class LocationComponentViewModel : BaseComponentViewModel
    {
        private string _name;
        private GpsCoordinates _gpsCoordinates;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public GpsCoordinates GpsCoordinates
        {
            get => _gpsCoordinates;
            set => SetProperty(ref _gpsCoordinates, value);
        }
    }
}
