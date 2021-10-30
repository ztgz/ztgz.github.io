namespace ArvidZetterberg.Components.Metorids.Extensions
{
    public interface ICollision
    {
        public int Value { get; }
        public int Damage { get; }
        Shape Form { get; }
        public enum Shape
        {
            None,
            Circle
        }

        public void HandleCollision(int damage);

        public static bool IsCollision<U>(object obj1, U obj2)
            where U : IPosition, ICollision
        {
            var pos = obj1 as IPosition;
            var col = obj1 as ICollision;
            bool isCollision = false;

            if (pos is null || col is null)
            {
                return isCollision;
            }
            else if (col.Form is Shape.Circle && obj2.Form is Shape.Circle)
            {
                // Get distance between  cirlces
                var distanceX = (pos.X + pos.Width / 2) - (obj2.X + obj2.Width / 2);
                var distanceY = (pos.Y + pos.Height / 2) - (obj2.Y + obj2.Height / 2);
                var distance = Math.Sqrt(distanceX * distanceX + distanceY * distanceY);
                // If distance is larger then the combined radius then there is a overlapp 
                isCollision = distance < (pos.Width + obj2.Width) / 2;
            }

            return isCollision;
        }
    }
}
