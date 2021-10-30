using ArvidZetterberg.Components.Metorids.Extensions;

namespace ArvidZetterberg.Components.Metorids.Entities
{
    public class ItemCore : IPosition, IUpdate, ICollision, IRemovable
    {
        static Random Random = new Random();
        public double lifeLeftMilliseconds;
        public ItemCore(double x, double y)
        {
            lifeLeftMilliseconds = Random.Next(5000, 10000);
            Rotation = Random.Next(0, 365);
            this.x = x;
            this.y = y;
        }

        public int Rotation { get; set;}
        public int Width => 30;

        public int Height => 30;

        public int Damage => 0;

        public ICollision.Shape Form => ICollision.Shape.Circle;

        double x = 200;
        double IPosition.X { get => x; set => x = value; }

        double y = 150;
        double IPosition.Y { get => y; set => y = value; }

        double IPosition.XSpeed { get => 0; set => throw new NotImplementedException(); }
        double IPosition.YSpeed { get => 0; set => throw new NotImplementedException(); }

        public int Value => 10;

        public void HandleCollision(int damage) => isAlive = false;

        public void Update(double milliseconds)
        {
            lifeLeftMilliseconds -= milliseconds;
            Rotation += 1;
            while (Rotation >= 365)
                Rotation -= 365;
        }

        bool isAlive = true;
        public bool ShallBeRemoved() => !isAlive || lifeLeftMilliseconds < 0;

        public IEnumerable<object> ShallBeCreatedOnRemove()
        {
            return new List<object>();
        }
    }
}
