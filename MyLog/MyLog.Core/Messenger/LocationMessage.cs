using MvvmCross.Plugins.Messenger;
using MyLog.Core.Models.RoadTracking;

namespace MyLog.Core.Messenger
{
    public class LocationMessage : MvxMessage
    {
        public LocationMessage(object sender, Coordinates coordinates) : base(sender)
        {
            Coordinates = coordinates;
        }

        public Coordinates Coordinates { get; }
    }
}
