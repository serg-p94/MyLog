using Android.Content;
using MyLog.Core.Services.Abstract;
using Plugin.CurrentActivity;

namespace MyLog.Droid.Services
{
    public class WebService : IWebService
    {
        public void OpenUri(string uri)
        {
            OpenUri(Android.Net.Uri.Parse(uri));
        }

        private void OpenUri(Android.Net.Uri uri)
        {
            var intent = new Intent(Intent.ActionView, uri);
            CrossCurrentActivity.Current.Activity.StartActivity(intent);
        }
    }
}