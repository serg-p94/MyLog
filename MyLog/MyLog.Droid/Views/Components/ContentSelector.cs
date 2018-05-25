using Android.App;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.BindingContext;
using MyLog.Core.ViewModels.Records;

namespace MyLog.Droid.Views.Components
{
    public class ContentSelector
    {
        private readonly IMvxBindingContextOwner _bindingContextOwner;

        public ContentSelector(IMvxBindingContextOwner bindingContextOwner)
        {
            _bindingContextOwner = bindingContextOwner;
        }

        public View GetContent(object dataContext)
        {
            if (dataContext is string strContext)
            {
                return new TextView(Application.Context) { Text = strContext };
            }
            else if (dataContext is JourneyRecordViewModel)
            {
                return _bindingContextOwner.BindingInflate(Resource.Layout.recordContent_Journey, null);
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