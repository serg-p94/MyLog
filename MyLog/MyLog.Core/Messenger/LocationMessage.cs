using MvvmCross.Plugins.Location;
using MvvmCross.Plugins.Messenger;

namespace MyLog.Core.Messenger
{
    public class LocationMessage : MvxMessage
    {
        public LocationMessage(object sender, MvxCoordinates coordinates) : base(sender)
        {
            Coordinates = coordinates;
        }

        public MvxCoordinates Coordinates { get; }
    }
}
