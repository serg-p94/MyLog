using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Location;
using MvvmCross.Plugins.Messenger;
using MyLog.Core.Data.RealmModels;
using MyLog.Core.Messenger;
using MyLog.Core.ViewModels.Abstract;
using Realms;

namespace MyLog.Core.ViewModels.Pages
{
    public class JourneyLogViewModel : BasePageViewModel
    {
        private readonly Realm _realm;

        public JourneyLogViewModel()
        {
            Messenger.Subscribe<LocationMessage>(msg => CurrentCoordinates = msg.Coordinates);

            _realm = Realm.GetInstance();
            Records = _realm.All<JourneyRecord>();
        }

        public override string Title => "Journey Log";

        public MvxCoordinates CurrentCoordinates { get; set; }

        private IMvxMessenger Messenger { get; } = Mvx.Resolve<IMvxMessenger>();

        public IEnumerable<JourneyRecord> Records { get; }

        public ICommand AddRecordCommand => new MvxAsyncCommand(async () => {
            await _realm.WriteAsync(r =>
                r.Add(new JourneyRecord
                {
                    Date = DateTimeOffset.Now,
                    Header = $"Added item number {r.All<JourneyRecord>().Count()}"
                }));
        });
    }
}
