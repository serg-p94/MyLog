using System.Collections.Generic;
using MvvmCross.ViewModels;

namespace MyLog.Core.ViewModels.Dialogs
{
    public class ListDialogViewModel : MvxViewModel<IEnumerable<DialogOptionViewModel>, DialogOptionViewModel>
    {
        public IList<DialogOptionViewModel> Options { get; private set; }

        public override void Prepare(IEnumerable<DialogOptionViewModel> parameter)
        {
            Options = new List<DialogOptionViewModel>(parameter);
        }
    }
}
