namespace ArvidZetterberg.Components.Windows
{
	public record WindowStartMeasures
	{
		public int Width { get; init; } = 300;
		public int Height { get; init; } = 250;
		public int Top { get; init; } = 100;
		public int Left { get; init; } = 200;
	}
}
