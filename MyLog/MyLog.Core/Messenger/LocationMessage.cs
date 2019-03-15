using MvvmCross.Plugin.Messenger;
using MyLog.Core.Models.Navigation;

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
