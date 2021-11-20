using ArvidZetterberg.MessageService;
using ArvidZetterberg.Store;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace ArvidZetterberg.Components.Windows
{
    public partial class Window
    {
        [Parameter]
        [EditorRequired]
        public WindowContent Content { get; set; } = null !;
        
        [CascadingParameter]
        public WindowContainer WindowContainer { get; set; } = null !;

        double left;
        double top;
        double width;
        double height;
        double mouseOffsetX = 0;
        double mouseOffsetY = 0;
        bool maximized = false;
        bool visible = true;

        const int windowMinHeight = 120;
        const int windowMinWidth = 200;

        protected override void OnInitialized()
        {
            left = Content.StartMeasuers.Left;
            top = Content.StartMeasuers.Top;
            width = Content.StartMeasuers.Width;
            height = Content.StartMeasuers.Height;
            maximized = WindowStore.IsMobile;
            WindowContainer.AddWindow(this);
            WindowMessageService.Subscribe(HandleMessages);
            base.OnInitialized();
        }

        void HandleMessages(WindowMessage msg)
        {
            if (msg is FocusWindowMsg && msg.WindowContent.Id == Content.Id)
                visible = true;
        }

        #region Move window
        void HandleDrag(DragEventArgs eventArgs)
        {
            if (IsDragFinished(eventArgs) == false)
            {
                left = eventArgs.PageX - mouseOffsetX;
                top = eventArgs.PageY - mouseOffsetY;
            }
        }

        void HandleDragStart(DragEventArgs eventArgs)
        {
            SelectWindow();
            mouseOffsetX = eventArgs.OffsetX;
            mouseOffsetY = eventArgs.OffsetY;
        }

        long? touchMoveIdentifier;
        void HandleTouchStart(TouchEventArgs eventArgs)
        {
            if (touchMoveIdentifier is null)
            {
                SelectWindow();
                mouseOffsetX = eventArgs.Touches[0].PageX;
                mouseOffsetY = eventArgs.Touches[0].PageY;
                touchMoveIdentifier = eventArgs.Touches[0].Identifier;
            }
        }

        void HandleTouchMove(TouchEventArgs eventArgs)
        {
            var touch = eventArgs.Touches.FirstOrDefault(touch => touch.Identifier == touchMoveIdentifier);
            if (touch is not null)
            {
                left += eventArgs.Touches[0].PageX - mouseOffsetX;
                top += eventArgs.Touches[0].PageY - mouseOffsetY;
                mouseOffsetX = eventArgs.Touches[0].PageX;
                mouseOffsetY = eventArgs.Touches[0].PageY;
            }
        }

        void HandleTouchEnd(TouchEventArgs eventArgs)
        {
            bool touchEnded = eventArgs.Touches.All(touch => touch.Identifier == touchMoveIdentifier);
            if (touchEnded)
                touchMoveIdentifier = null;
        }
        #endregion

        #region ResizeWindow
        void HandleResizeXAndY(DragEventArgs eventArgs) => ResizeWindow(eventArgs, true, true);
        void ResizeWindow(DragEventArgs eventArgs, bool resizeX = false, bool resizeY = false, bool isStart = false)
        {
            if (IsDragFinished(eventArgs))
                return;
            if (resizeX)
                ResizeX(eventArgs, isStart);
            if (resizeY)
                ResizeY(eventArgs, isStart);
            SelectWindow();
        }

        void ResizeX(DragEventArgs eventArgs, bool resizeLeft = false)
        {
            width += (resizeLeft ? -eventArgs.OffsetX : eventArgs.OffsetX);
            if (width < windowMinWidth)
                width = windowMinWidth;
            else if (resizeLeft)
                left += eventArgs.OffsetX;
        }

        void ResizeY(DragEventArgs eventArgs, bool resizeTop = false)
        {
            height += (resizeTop ? -eventArgs.OffsetY : eventArgs.OffsetY);
            if (height < windowMinHeight)
                height = windowMinHeight;
            else if (resizeTop)
                top += eventArgs.OffsetY;
        }

        #endregion

        #region TouchResize
        //TODO Check for identifier
        void HandleResizeXAndYTouch(TouchEventArgs eventArgs)
        {
            TouchResizeX(eventArgs);
            TouchResizeY(eventArgs);
        }

        void TouchResizeX(TouchEventArgs eventArgs)
        {
            width = eventArgs.Touches[0].PageX - left;
            if (width < windowMinWidth)
                width = windowMinWidth;
        }
        void TouchResizeY(TouchEventArgs eventArgs)
        {
            height = eventArgs.Touches[0].PageY - top;
            if (height < windowMinHeight)
                height = windowMinHeight;
        }

        void TouchResizeYStart(TouchEventArgs eventArgs)
        {
            height -= eventArgs.Touches[0].PageY - top;
            if (height < windowMinHeight)
                height = windowMinHeight;
            else
                top = eventArgs.Touches[0].PageY;
        }

        void TouchResizeXStart(TouchEventArgs eventArgs)
        {
            width -= eventArgs.Touches[0].PageX - left;
            if (width < windowMinWidth)
                width = windowMinWidth;
            else
                left = eventArgs.Touches[0].PageX;
        }
        #endregion

        #region IconActions
        void HandleClose()
        {
            WindowMessageService.RemoveWidnow(Content);
            WindowStore.RemoveWindow(Content);
        }

        void MinimizeWindow()
        {
            visible = false;
            if (WindowStore.SelectedWindow == this)
                WindowStore.SelectedWindow = null;
        }
        #endregion

        void SelectWindow() => WindowMessageService.FocusWindow(Content);
        private string CalculateX() => maximized ? "left: 0" : "left: " + left + "px";
        private string CalculateY() => maximized ? "top: 0" : "top: " + top + "px";
        private string CalculateWidth() => "width:" + (maximized ? "calc(100% - 1px)" : (width + "px"));
        private string CalculateHeight() => "height:" + (maximized ? "calc(100% - 52px)" : (height + "px"));
        bool IsDragFinished(DragEventArgs eventArgs) => eventArgs.PageX == 0 && eventArgs.PageY == 0; // Navie solution
        public void Dispose() => WindowMessageService.Unsubscribe(HandleMessages);
    }
}