using ArvidZetterberg.Components.Common;
using ArvidZetterberg.Components.Metorids;
using ArvidZetterberg.Components.Sweeper;
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
            },
            new WindowContent(typeof(Sweeper), new Dictionary<string, object>(){ })
            {
                Icon = "fa-question-circle",
                Name = "Sweeper",
                StartMeasuers = new() { Width = 400, Height = 400, Left = 0 }
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

        private bool isMobile = false;
        public bool IsMobile
        {
            get => isMobile;
            set 
            {
                isMobile = value;
                InvokeUpdates();
            }
        }
    }
}
