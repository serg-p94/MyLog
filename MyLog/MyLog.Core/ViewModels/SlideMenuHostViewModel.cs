using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.Core.ViewModels;

namespace MyLog.Core.ViewModels
{
    public class SlideMenuHostViewModel : MvxViewModel
    {
        public IList<string> MenuItems { get; } = new List<string> {"Home", "Second", "Third"};
    }
}
