using System.Linq;
using Android.App;
using Android.Content;
using Android.OS;
using MvvmCross.Droid.Views.Attributes;
using MvvmCross.Droid.Views.Fragments;
using MyLog.Core.ViewModels.Dialogs;

namespace MyLog.Droid.Views.Dialogs
{
    [MvxDialogFragmentPresentation]
    public class ListDialogView : MvxDialogFragment<ListDialogViewModel>
    {
        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            var builder = new AlertDialog.Builder(Context);
            builder.SetSingleChoiceItems(ViewModel.Options.Select(o => o.ToString()).ToArray(), 0, ItemSelected);

            return builder.Create();
        }

        private void ItemSelected(object s, DialogClickEventArgs e)
        {
            Dismiss();
            ViewModel.CloseCompletionSource.SetResult(ViewModel.Options[e.Which]);
        }
    }
}