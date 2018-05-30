using System.Collections.Generic;
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
                Title = "First"
            },
            new JourneyRecordViewModel {
                Title = "Second"
            },
            new JourneyRecordViewModel {
                Title = "Third"
            },
            new JourneyRecordViewModel {
                Title = "Fourth"
            },
            new JourneyRecordViewModel {
                Title = "Fifth"
            },
            new JourneyRecordViewModel {
                Title = "Sixth"
            },
        };
    }
}
