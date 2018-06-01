using System.Collections.Generic;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Location;
using MvvmCross.Plugins.Messenger;
using MyLog.Core.Messenger;
using MyLog.Core.ViewModels.Abstract;
using MyLog.Core.ViewModels.Records;

namespace MyLog.Core.ViewModels.Pages
{
    public class JourneyLogViewModel : BasePageViewModel
    {
        public JourneyLogViewModel()
        {
            Messenger.Subscribe<LocationMessage>(msg => CurrentCoordinates = msg.Coordinates);
        }

        public override string Title => "Journey Log";

        public MvxCoordinates CurrentCoordinates { get; set; }

        private IMvxMessenger Messenger { get; } = Mvx.Resolve<IMvxMessenger>();

        public IList<JourneyRecordViewModel> Records { get; } = new List<JourneyRecordViewModel> {
            new JourneyRecordViewModel {
                Header = "First"
            },
            new JourneyRecordViewModel {
                Header = "Second"
            },
            new JourneyRecordViewModel {
                Header = "Third"
            },
            new JourneyRecordViewModel {
                Header = "Fourth"
            },
            new JourneyRecordViewModel {
                Header = "Fifth"
            },
            new JourneyRecordViewModel {
                Header = "Sixth"
            },
        };

        public ICommand AddRecordCommand => new MvxCommand(() => NavigationService.Navigate<AddRecordViewModel>());
    }
}
