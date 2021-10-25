namespace ArvidZetterberg.Components.Metorids.Extensions
{
    public interface IRemovable
    {
        public bool ShallBeRemoved();
        public IEnumerable<object> ShallBeCreatedOnRemove();
    }
}
