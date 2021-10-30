using ArvidZetterberg.Components.Metorids.Extensions;

namespace ArvidZetterberg.Components.Metorids.Entities
{
    public class SpawnCore : IUpdate, IRemovable
    {
        static Random Random = new Random();
        public int X { get; private set; }
        public int Y { get; private set; }


        public List<ParticleCore> Particles = new List<ParticleCore>();

        private double lifeTimeMilliseconds = 3000;

        public SpawnCore(int x, int y)
        {
            X = x;
            Y = y;

            for (int i = 0; i < 10; i++)
                Particles.Add(new(X, Y, ParticleCore.GetRandomLifeTime()));
        }

        public void Update(double milliseconds)
        {
            foreach(ParticleCore particle in Particles)
            {
                if (particle is IPosition)
                    ((IPosition)particle).Move(milliseconds);

                particle.Update(milliseconds);
            }

            Particles = Particles.Where(particle => particle.LifetimeLeftMilliseconds > 0).ToList();

            lifeTimeMilliseconds -= milliseconds;
        }

        public bool ShallBeRemoved() => lifeTimeMilliseconds <= 0;

        public IEnumerable<object> ShallBeCreatedOnRemove()
        {
            object obj = Random.Next(0, 10) switch
            {
                < 6 => new EnemyCore(X, Y),
                < 9 => new ItemCore(X,Y),
                _ => new SpawnCore(IPosition.GetRandomX(), IPosition.GetRandomY())

            };

            return new List<object>() { 
                obj,
                new SpawnCore(IPosition.GetRandomX(), IPosition.GetRandomY())
            };
        }
    }
}
