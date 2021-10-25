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
		XDirection IPosition.XDir { get => xDirection; set => xDirection = value; }

		YDirection yDirection = YDirection.None;
		YDirection IPosition.YDir { get => yDirection; set => yDirection = value; }

		public double SpeedIncrease => .02;
		public double MaxSpeed => 0.3;

        public int Width => 40;
        public int Height => 40;

        public void SetXDirection(XDirection xDirection) => this.xDirection = xDirection;

		public void SetYDirection(YDirection yDirection) => this.yDirection = yDirection;
	}
}
