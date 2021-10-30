namespace ArvidZetterberg.Components.Metorids.Extensions
{
    public interface IPosition
    {
		public static int ScreenWidth = 0;
		public static int ScreenHeight = 0;

        public double X { get; protected set; }
        public double Y { get; protected set; }
		public int Width { get; }
		public int Height { get; }
		public double XSpeed { get; protected set; }
		public double YSpeed { get; protected set; }

		public string CssPosition() => $"top: {Y}px; left: {X}px; width: {Width}px; height: {Height}px;";

		void Move(double milliseconds)
        {
			UpdateXSpeed(milliseconds);
			UpdateYSpeed(milliseconds);
        }

		private void UpdateYSpeed(double milliseconds)
		{
			Y += YSpeed * milliseconds;
			if (Y + (Height / 2) < 0)
				Y = ScreenHeight - (Height /2);
            else if (Y + (Height / 2) > ScreenHeight)
                Y = -(Height/2);
        }

		private void UpdateXSpeed(double milliseconds)
		{
			X += XSpeed * milliseconds;
			if (X + (Width / 2) < 0)
				X = ScreenWidth - (Width / 2);
			else if (X	 + (Width / 2) > ScreenWidth)
				X = -(Width / 2);
		}

		static Random rand = new Random();
		public static int GetRandomX() => rand.Next(0, ScreenWidth);
		public static int GetRandomY() => rand.Next(0, ScreenHeight);
	}
}
