using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using MyLog.Core.ViewModels.Components;

namespace MyLog.Core.ViewModels.Records
{
    public abstract class BaseRecordViewModel : MvxNotifyPropertyChanged
    {
        public abstract IList<BaseComponentViewModel> Components { get; }
    }
}
