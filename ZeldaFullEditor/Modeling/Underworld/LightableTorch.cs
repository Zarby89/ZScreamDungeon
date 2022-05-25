namespace ZeldaFullEditor.Modeling.Underworld
{
	public class LightableTorch : IDungeonPlaceable, IFreelyPlaceable, IMouseCollidable, IMultilayered, IByteable, IHaveInfo
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

		public RoomLayer Layer { get; set; } = RoomLayer.Layer1;

		public bool Lit { get; set; } = false;

		public Rectangle BoundingBox => new(RealX, RealY, 16, 16);

		public string Name => "Torch";

		public LightableTorch()
		{

		}

		public void Draw(Artist art)
		{
			throw new NotImplementedException();
		}

		public bool PointIsInHitbox(int x, int y)
		{
			throw new NotImplementedException();
		}

		public byte[] GetByteData()
		{
			var (low, high) = UWTilemapPosition.CreateLowAndHighBytesFromXYZ(GridX, GridY, (byte) Layer);
			return new byte[] { low, high };
		}
	}
}
