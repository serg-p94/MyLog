using Android.OS;
using Android.Views;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Droid.Views.Attributes;
using MvvmCross.Droid.Views.Fragments;
using MyLog.Core.ViewModels.Dialogs;

namespace MyLog.Droid.Views.Dialogs
{
    [MvxDialogFragmentPresentation]
    public class DatePickerDialogView : MvxDialogFragment<DatePickerDialogViewModel>
    {
        private MvxDatePicker _datePicker;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            //return base.OnCreateView(inflater, container, savedInstanceState);

            _datePicker = new MvxDatePicker(Context);
            return _datePicker;
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

//            var bindingSet = this.CreateBindingSet<DatePickerDialogView, DatePickerDialogViewModel>();
//            bindingSet.Bind(_datePicker).For(v => v.Value).To(vm => vm.Date);
//            bindingSet.Apply();
        }
    }
}