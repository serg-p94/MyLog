using Android.App;
using Android.Views;
using Android.Widget;

namespace MyLog.Droid.Views.Components
{
    public class ContentSelector
    {
        public View GetContent(object dataContext)
        {
            if (dataContext is string strContext)
            {
                return new TextView(Application.Context) { Text = strContext };
            }
            else
            {
                return new TextView(Application.Context) {
                    Text = $"View not found for {nameof(dataContext)}: {dataContext.ToString()}"
                };
            }
        }
    }
}