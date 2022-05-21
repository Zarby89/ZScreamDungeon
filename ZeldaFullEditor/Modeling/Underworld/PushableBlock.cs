namespace ZeldaFullEditor.Modeling.Underworld
{
	public class PushableBlock : IDungeonPlaceable, IFreelyPlaceable, IDelegatedDraw, IMouseCollidable, IMultilayered, IHaveInfo
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

		public string Name => "Push block";

		public RoomLayer Layer { get; set; }

		public Rectangle BoundingBox => new(RealX, RealY, 16, 16);

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
