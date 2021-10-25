using ArvidZetterberg.Components.Metorids.Extensions;

namespace ArvidZetterberg.Components.Metorids.Entities
{
    public partial class EnemyCore : ICollision, IUpdate, IRemovable
    {
        static Random rand = new Random();
        public EnemyCore(double? startX = null, double? startY = null)
        {
            y = startY ?? IPosition.GetRandomY();
            x = startX ?? IPosition.GetRandomX();
            maxSpeed = rand.NextDouble() / 20 + .1;
            
            xDirection = rand.Next(0, 2) switch
            {
                0 => IPosition.XDirection.Left,
                1 => IPosition.XDirection.Right,
                _ => IPosition.XDirection.None
            };

            yDirection = rand.Next(0, 2) switch
            {
                0 => IPosition.YDirection.Up,
                1 => IPosition.YDirection.Down,
                _ => IPosition.YDirection.None
            };
        }

        public ICollision.Shape Form => ICollision.Shape.Circle;

        public int Damage => 1;
        bool isDestroyed = false;
        public void HandleCollision(int damage) => isDestroyed = true;
        public bool ShallBeRemoved() => isDestroyed;
        public IEnumerable<object> ShallBeCreatedOnRemove() => new List<object>(0);


        public void Update(double milliseconds)
        {
            ((IPosition)this).Move(milliseconds);
        }
    }
}
