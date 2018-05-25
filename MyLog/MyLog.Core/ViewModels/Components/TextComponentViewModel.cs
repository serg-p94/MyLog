namespace MyLog.Core.ViewModels.Components
{
    public class TextComponentViewModel : BaseComponentViewModel
    {
        private string _text;

        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }
    }
}
