using ArvidZetterberg.Components.Common;
using ArvidZetterberg.Components.Windows;

namespace ArvidZetterberg.Store
{
    public sealed class WindowStore : Store
    {
        private IconLink? selectedIcon;
        public IconLink? SelectedIcon
		{
            get {  return selectedIcon; }
            set 
            {  
                selectedIcon = value;
                InvokeUpdates();
            }
		}

        public List<WindowContent> WindowContents { get; private set; } = new List<WindowContent>()
        {
            new WindowContent(typeof(Help), new Dictionary<string, object>(){ })
            {
                Icon = "fa-question-circle",
                Name = "Help",
                StartMeasuers = new() { Width = 400, Height = 400 }
            }
        };

        public void AddWindow(WindowContent windowContent)
		{
            WindowContents.Add(windowContent);
            InvokeUpdates();
		}

        public void RemoveWindow(WindowContent windowContent)
		{
            WindowContents.Remove(windowContent);
            InvokeUpdates();
		}

        private Window? selectedWindow;
        public Window? SelectedWindow {
            get => selectedWindow;
            set
			{
                selectedWindow = value;
                InvokeUpdates();
			} 
        }
    }

}
