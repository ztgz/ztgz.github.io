using ArvidZetterberg.Components.Metorids.Extensions;

namespace ArvidZetterberg.Components.Metorids.Entities
{
    public class ParticleCore : IPosition, IUpdate
    {
        public static Random Random = new Random(DateTime.Now.Millisecond * DateTime.Now.Second);
        public ParticleCore(double x, double y, double totalLifetimeMilliseconds = 3000)
        {
            this.x = x;
            this.y = y;

            ySpeed = RandomSpeed();
            xSpeed = RandomSpeed();
            var size = Random.Next(10, 20);
            width = size;
            height = size;
            LifetimeLeftMilliseconds = totalLifetimeMilliseconds;
        }

        public double LifetimeLeftMilliseconds { get; private set; }

        private double RandomSpeed() => (Random.Next(1, 20) * 0.0005 + .00001) // The speed
            * (Random.Next(0, 2) == 0 ? -1 : 1); // Randomize positive and negative numbers;

		public void Update(double milliseconds)
		{
            LifetimeLeftMilliseconds -= milliseconds;
		}

		double x = 0;
        double IPosition.X { get => x; set => x = value; }

        double y = 0;
        double IPosition.Y { get => y; set => y = value; }

        private int width;
        int IPosition.Width => width;

        private int height;
        int IPosition.Height => height;

        double xSpeed;
        double IPosition.XSpeed { get => xSpeed; set => xSpeed = value; }

        double ySpeed;
        double IPosition.YSpeed { get => ySpeed; set => ySpeed = value; }
        public static int GetRandomLifeTime() => Random.Next(2000, 4000);
    }
}
