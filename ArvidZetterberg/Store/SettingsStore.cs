namespace ArvidZetterberg.Store
{
    public class SettingsStore : Store
    {
        private string backgroundColor = "#008080";
        public string BackgroundColor {
            get => backgroundColor;
            set
            {
                backgroundColor = value;
                InvokeUpdates();
            } 
        }

        private string windowColor = "#00008b";
        public string WindowColor
        {
            get => windowColor;
            set
            {
                windowColor = value;
                InvokeUpdates();
            }
        }
    }
}
