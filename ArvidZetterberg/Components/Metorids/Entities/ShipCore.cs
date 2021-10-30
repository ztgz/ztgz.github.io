using ArvidZetterberg.Components.Metorids.Extensions;

namespace ArvidZetterberg.Components.Metorids.Entities
{
	public partial class ShipCore : ICollision, IUpdate
	{
		public ICollision.Shape Form => ICollision.Shape.Circle;
        public int MaxLife => 5;
        private int life = 5;
        public int Damage => 0;
        public int CurrentLife
        {
            get => life;
            private set
            {
                life = value;
            }
        }

        public int Value => 0;

        public void HandleCollision(int damage)
        {
            life -= damage;
            if (life < 0)
                life = 0;
        }

        public void Update(double milliseconds)
		{
            UpdateXSpeed(milliseconds);
            UpdateYSpeed(milliseconds);
			((IPosition)this).Move(milliseconds);
		}
	}
}
