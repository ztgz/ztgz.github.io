namespace ArvidZetterberg.MessageService;

public abstract class MessageService<T>
{
    private Action<T>? Actions;
    public void Subscribe(Action<T> action) => Actions += action;
    public void Unsubscribe(Action<T> action) => Actions -= action;
    protected void InvokeUpdates(T message) => Actions?.Invoke(message);
}

