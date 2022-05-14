namespace ZeldaFullEditor.Data.Underworld
{
	[Serializable]
	public class DungeonSecret : IDungeonPlaceable, IByteable, IFreelyPlaceable, IDelegatedDraw, IMouseCollidable, IMultilayered, IDrawableSprite, ITypeID, IHaveInfo
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

		public byte ID => SecretType.ID;
		public int TypeID => SecretType.ID;

		public Rectangle BoundingBox => new(RealX, RealY, 16, 16);

		public RoomLayer Layer { get; set; } = RoomLayer.Layer1;

		public SecretItemType SecretType { get; set; }
		public string Name => SecretType.VanillaName;

		public DungeonSecret(SecretItemType s)
		{
			SecretType = s;
		}

		public void Draw(Artist art)
		{
			SecretType.Draw(art, this);
		}

		public bool PointIsInHitbox(int x, int y)
		{
			return x >= (GridX * 8) && x <= (GridX * 8) + 16 &&
					y >= (GridY * 8) && y <= (GridY * 8) + 16;
		}

		public bool Equals(DungeonSecret s)
		{
			return GridX == s.GridX && GridY == s.GridY && SecretType.ID == s.SecretType.ID;
		}

		public byte[] GetByteData()
		{
			UWTilemapPosition.CreateLowAndHighBytesFromXYZ(GridX, GridY, (byte) Layer, out byte low, out byte high);
			return new byte[] { low, high, SecretType.ID };
			//ushort xy = (ushort) ((Y << 6) | (X << 1) | (Layer << 13));
			//return new byte[]
			//	{
			//		(byte) xy,
			//		(byte) (xy >> 8),
			//		SecretType.ID
			//	};

		}
	}
}
