namespace ArvidZetterberg.Store
{
    public abstract class Store
    {
        private Action? Actions;
        public void Subscribe(Action action) => Actions += action;
        public void Unsubscribe(Action action) => Actions -= action;
        protected void InvokeUpdates() => Actions?.Invoke();
    }
}
