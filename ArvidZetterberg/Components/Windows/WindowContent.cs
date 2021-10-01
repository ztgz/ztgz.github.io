namespace ArvidZetterberg.Components.Windows
{
    public record WindowContent(Type type, Dictionary<string, object> parameters)
    {
        public Guid Id = Guid.NewGuid();
        public string? Name { get; init; }

        public string? Icon { get; init; }
        public WindowStartMeasures StartMeasuers { get; init; } = new();
    };
}
