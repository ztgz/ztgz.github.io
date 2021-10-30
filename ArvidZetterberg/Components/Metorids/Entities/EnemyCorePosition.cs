using ArvidZetterberg.Components.Metorids.Extensions;
using static ArvidZetterberg.Components.Metorids.Extensions.IPosition;

namespace ArvidZetterberg.Components.Metorids.Entities
{
    public partial class EnemyCore : IPosition
    {
		double x;
		double IPosition.X { get => x; set => x = value; }

		double y;
		double IPosition.Y { get => y; set => y = value; }

		double xSpeed = 1;
		double IPosition.XSpeed { get => xSpeed; set => xSpeed = value; }

		double ySpeed = 1;
		double IPosition.YSpeed { get => ySpeed; set => ySpeed = value; }

        public int Width => 20;
        public int Height => 20;
	}
}
