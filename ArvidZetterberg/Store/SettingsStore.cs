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

        private string windowFontColor = "#fffaf0";
        public string WindowFontColor
        {
            get => windowFontColor;
            set
            {
                windowFontColor = value;
                InvokeUpdates();
            }
        }

        private string windowContentBackgroundColor = "#FFFFFF";
        public string WindowContentBackgroundColor
        {
            get => windowContentBackgroundColor;
            set
            {
                windowContentBackgroundColor = value;
                InvokeUpdates();
            }
        }

        private string iconColor = "#000";
        public string IconColor
        {
            get => iconColor;
            set
            {
                iconColor = value;
                InvokeUpdates();
            }
        }

        private string textColor = "#000";
        public string TextColor
        {
            get => textColor;
            set
            {
                textColor = value;
                InvokeUpdates();
            }
        }

        private string toolbarColor = "#d3d3d3";
        public string ToolbarColor
        {
            get => toolbarColor;
            set
            {
                toolbarColor = value;
                InvokeUpdates();
            }
        }
    }
}
