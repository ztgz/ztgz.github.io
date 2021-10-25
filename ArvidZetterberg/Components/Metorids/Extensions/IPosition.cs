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
		public XDirection XDir { get; protected set; }
		public YDirection YDir { get; protected set; }
		public double SpeedIncrease { get; }
		public double MaxSpeed { get; }

		public enum XDirection
		{
			None,
			Left,
			Right
		}

		public enum YDirection
		{
			None,
			Up,
			Down
		}

		void Move(double milliseconds)
        {
			UpdateXSpeed(milliseconds);
			UpdateYSpeed(milliseconds);
        }

		public string CssPosition() => $"top: {Y}px; left: {X}px; width: {Width}px; height: {Height}px;";

		private void UpdateYSpeed(double milliseconds)
		{
			if (YDir == YDirection.Down)
			{
				YSpeed += SpeedIncrease * milliseconds;
				if (YSpeed > MaxSpeed)
					YSpeed = MaxSpeed;
			}
			else if (YDir == YDirection.Up)
			{
				YSpeed -= SpeedIncrease * milliseconds;
				if (YSpeed < -MaxSpeed)
					YSpeed = -MaxSpeed;
			}
			else
			{
				YSpeed = GetAdjustedSpeed(YSpeed, milliseconds);
			}

			Y += YSpeed * milliseconds;
			if (Y + (Height / 2) < 0)
				Y = ScreenHeight - (Height /2);
            else if (Y + (Height / 2) > ScreenHeight)
                Y = -(Height/2);
        }

		private void UpdateXSpeed(double milliseconds)
		{
			if (XDir == XDirection.Right)
			{
				XSpeed += SpeedIncrease * milliseconds;
				if (XSpeed > MaxSpeed)
					XSpeed = MaxSpeed;
			}
			else if (XDir == XDirection.Left)
			{
				XSpeed -= SpeedIncrease * milliseconds;
				if (XSpeed < -MaxSpeed)
					XSpeed = -MaxSpeed;
			}
			else
			{
				XSpeed = GetAdjustedSpeed(XSpeed, milliseconds);
			}

			X += XSpeed * milliseconds;
			if (X + (Width / 2) < 0)
				X = ScreenWidth - (Width / 2);
			else if (X	 + (Width / 2) > ScreenWidth)
				X = -(Width / 2);

		}

		private double GetAdjustedSpeed(double speed, double milliseconds)
		{
			if (speed > SpeedIncrease * milliseconds)
				return speed - SpeedIncrease;
			else if (speed < -SpeedIncrease * milliseconds)
				return speed + SpeedIncrease * milliseconds;

			return 0;
		}

		static Random rand = new Random();
		public static int GetRandomX() => rand.Next(0, ScreenWidth);
		public static int GetRandomY() => rand.Next(0, ScreenHeight);
	}
}
