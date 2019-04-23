using System;
using System.Linq;
using Android.App;
using Android.Content;
using Android.OS;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views.Fragments;
using MyLog.Core.ViewModels.Dialogs;

namespace MyLog.Droid.Views.Dialogs
{
    [MvxDialogFragmentPresentation]
    public class ListDialogView : MvxDialogFragment<ListDialogViewModel>
    {
        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            var builder = new AlertDialog.Builder(Context);

            if (ViewModel.IsSingleChoice)
            {
                var selectedItem = ViewModel.Options.FirstOrDefault(item => item.IsSelected);
                builder.SetSingleChoiceItems(ViewModel.Options.Select(o => o.ToString()).ToArray(),
                    ViewModel.Options.IndexOf(selectedItem), ItemSelected);
            }
            else
            {
                builder.SetMultiChoiceItems(ViewModel.Options.Select(o => o.ToString()).ToArray(),
                    ViewModel.Options.Select(o => o.IsSelected).ToArray(),
                    (EventHandler<DialogMultiChoiceClickEventArgs>)null);
            }

            return builder.Create();
        }

        private void ItemSelected(object s, DialogClickEventArgs e)
        {
            Dismiss();
            ViewModel.CloseCompletionSource.SetResult(ViewModel.Options[e.Which]);
        }
    }
}