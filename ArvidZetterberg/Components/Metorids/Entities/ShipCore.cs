using ArvidZetterberg.Components.Metorids.Extensions;

namespace ArvidZetterberg.Components.Metorids.Entities
{
	public partial class ShipCore : ICollision, IUpdate
	{
		public ICollision.Shape Form => ICollision.Shape.Circle;

        public void HandleCollision()
        {
			//Remove life
        }

        public void Update(double milliseconds)
		{
			((IPosition)this).Move(milliseconds);
		}
	}
}
