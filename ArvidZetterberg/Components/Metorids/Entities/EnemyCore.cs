using ArvidZetterberg.Components.Metorids.Extensions;

namespace ArvidZetterberg.Components.Metorids.Entities
{
    public partial class EnemyCore : ICollision, IUpdate, IRemovable
    {
        public static Random Random = new Random(DateTime.Now.Millisecond * DateTime.Now.Millisecond);
        public EnemyCore(double? startX = null, double? startY = null)
        {
            y = startY ?? IPosition.GetRandomY();
            x = startX ?? IPosition.GetRandomX();
            ySpeed = RandomSpeed();
            xSpeed = RandomSpeed();
        }

        public ICollision.Shape Form => ICollision.Shape.Circle;

        public int Damage => 1;

        public int Value => 0;

        bool isDestroyed = false;
        public void HandleCollision(int damage) => isDestroyed = true;
        public bool ShallBeRemoved() => isDestroyed;
        public IEnumerable<object> ShallBeCreatedOnRemove() => new List<object>(0);

        public void Update(double milliseconds)
        {
            ((IPosition)this).Move(milliseconds);
        }

        private double RandomSpeed() => (Random.Next(100, 300) * 0.0005 + .00001) // The speed
            * (Random.Next(0, 2) == 0 ? -1 : 1); // Randomize positive and negative numbers;

    }
}
