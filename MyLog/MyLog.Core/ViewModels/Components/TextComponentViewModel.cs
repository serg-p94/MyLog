namespace MyLog.Core.ViewModels.Components
{
    // TODOL Create an interface to render it in card
    public class TextComponentViewModel : BaseComponentViewModel
    {
        private string _label;
        private string _text;

        public string Label
        {
            get => _label;
            set => SetProperty(ref _label, value);
        }

        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }
    }
}
