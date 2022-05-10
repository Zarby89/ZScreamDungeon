namespace ZeldaFullEditor.Data.Underworld
{
	public class DungeonBlock : IDungeonPlaceable, IFreelyPlaceable, IDelegatedDraw, IMouseCollidable, IMultilayered
	{
		private const int Scale = 8;
		public byte GridX { get; set; }
		public byte GridY { get; set; }

		public int RealX
		{
			get => GridX * Scale;
			set => GridX = (byte) (value / Scale);
		}

		public int RealY
		{
			get => GridY * Scale;
			set => GridY = (byte) (value / Scale);
		}

		public RoomLayer Layer { get; set; }

		public Rectangle SquareHitbox => new(RealX, RealY, 16, 16);

		public void Draw(Artist art)
		{
			throw new NotImplementedException();
		}

		public bool PointIsInHitbox(int x, int y)
		{
			throw new NotImplementedException();
		}
	}
}
