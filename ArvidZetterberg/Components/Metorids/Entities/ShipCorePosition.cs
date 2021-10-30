using ArvidZetterberg.Components.Metorids.Extensions;
using static ArvidZetterberg.Components.Metorids.Extensions.IPosition;

namespace ArvidZetterberg.Components.Metorids.Entities
{
	public partial class ShipCore : IPosition
	{
		double x = 300;
		double IPosition.X { get => x; set => x = value; }

		double y = 300;
		double IPosition.Y { get => y; set => y = value; }

		double xSpeed = 0;
		double IPosition.XSpeed { get => xSpeed; set => xSpeed = value; }

		double ySpeed = 0;
		double IPosition.YSpeed { get => ySpeed; set => ySpeed = value; }

        XDirection xDirection = XDirection.None;
        XDirection XDir { get => xDirection; set => xDirection = value; }

        YDirection yDirection = YDirection.None;
        YDirection YDir { get => yDirection; set => yDirection = value; }

        public double SpeedIncrease => .02;
		public double MaxSpeed => 0.3;

        public int Width => 40;
        public int Height => 40;

        public void SetXDirection(XDirection xDirection) => this.xDirection = xDirection;

		public void SetYDirection(YDirection yDirection) => this.yDirection = yDirection;

        private void UpdateYSpeed(double milliseconds)
        {
            if (YDir == YDirection.Down)
            {
                ySpeed += SpeedIncrease * milliseconds;
                if (ySpeed > MaxSpeed)
                    ySpeed = MaxSpeed;
            }
            else if (YDir == YDirection.Up)
            {
                ySpeed -= SpeedIncrease * milliseconds;
                if (ySpeed < -MaxSpeed)
                    ySpeed = -MaxSpeed;
            }
            else
            {
                ySpeed = GetAdjustedSpeed(ySpeed, milliseconds);
            }
        }

        private void UpdateXSpeed(double milliseconds)
        {
            if (XDir == XDirection.Right)
            {
                xSpeed += SpeedIncrease * milliseconds;
                if (xSpeed > MaxSpeed)
                    xSpeed = MaxSpeed;
            }
            else if (XDir == XDirection.Left)
            {
                xSpeed -= SpeedIncrease * milliseconds;
                if (xSpeed < -MaxSpeed)
                    xSpeed = -MaxSpeed;
            }
            else
            {
                xSpeed = GetAdjustedSpeed(xSpeed, milliseconds);
            }
        }

        private double GetAdjustedSpeed(double speed, double milliseconds)
        {
            if (speed > SpeedIncrease * milliseconds)
                return speed - SpeedIncrease;
            else if (speed < -SpeedIncrease * milliseconds)
                return speed + SpeedIncrease * milliseconds;

            return 0;
        }

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
	}
}
