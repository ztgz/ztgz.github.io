using ArvidZetterberg.Components.Windows;

namespace ArvidZetterberg.MessageService
{
    public class WindowMessageService : MessageService<WindowMessage>
    {
        public void FocusWindow(WindowContent windowContent) 
            => InvokeUpdates(new FocusWindowMsg(windowContent));
        public void RemoveWidnow(WindowContent windowContent)
            => InvokeUpdates(new RemoveWindowMsg(windowContent));

    }

    public record WindowMessage (WindowContent WindowContent);
    public record FocusWindowMsg (WindowContent WindowContent) : WindowMessage(WindowContent);
    public record RemoveWindowMsg (WindowContent WindowContent) : WindowMessage(WindowContent);
}
