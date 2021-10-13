namespace ArvidZetterberg.Components.Metorids
{
    public class ShipCore
    {
        public double X { get; private set; } = 40;
        public double Y { get; private set; } = 40;


        double xSpeed = 0;
        double ySpeed = 0;
        double speedIncrease = .02;
        double maxSpeed = 0.3;

		public void SetXDirection(XDirection xDirection) => this.xDirection = xDirection;
		XDirection xDirection;
		public enum XDirection
		{
			None,
			Left,
			Right
		}

		public void SetYDirection(YDirection yDirection) => this.yDirection = yDirection;
		YDirection yDirection;
		public enum YDirection
		{
			None,
			Up,
			Down
		}

        public void Update(double milliseconds)
		{
			UpdateYSpeed(milliseconds);
			UpdateXSpeed(milliseconds);
		}

		void UpdateYSpeed(double milliseconds)
		{
			if (yDirection == YDirection.Down)
			{
				ySpeed += speedIncrease * milliseconds;
				if (ySpeed > maxSpeed)
					ySpeed = maxSpeed;
			}
			else if (yDirection == YDirection.Up)
			{
				ySpeed -= speedIncrease * milliseconds;
				if (ySpeed < -maxSpeed)
					ySpeed = -maxSpeed;
			}
			else
			{
				ySpeed = GetAdjustedSpeed(ySpeed, milliseconds);
			}

			Y += ySpeed * milliseconds;
			if (Y < 0)
				Y = 0;
		}

		void UpdateXSpeed(double milliseconds)
		{
			if (xDirection == XDirection.Right)
			{
				xSpeed += speedIncrease * milliseconds;
				if (xSpeed > maxSpeed)
					xSpeed = maxSpeed;
			}
			else if (xDirection == XDirection.Left)
			{
				xSpeed -= speedIncrease * milliseconds;
				if (xSpeed < -maxSpeed)
					xSpeed = -maxSpeed;
			}
			else
			{
				xSpeed = GetAdjustedSpeed(xSpeed, milliseconds);
			}

			X += xSpeed * milliseconds;
			if (X < 0)
				X = 0;
		}

		double GetAdjustedSpeed(double speed, double milliseconds)
        {
            if (speed > speedIncrease * milliseconds)
                return speed - speedIncrease;
            else if (speed < -speedIncrease * milliseconds)
                return speed + speedIncrease * milliseconds;

            return 0;
        }

    }
}
