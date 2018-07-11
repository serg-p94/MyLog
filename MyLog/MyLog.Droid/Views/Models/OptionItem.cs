using System.Windows.Input;

namespace MyLog.Droid.Views.Models
{
    public class MenuOption
    {
        public string Text { get; set; }

        public ICommand Command { get; set; }
    }
}