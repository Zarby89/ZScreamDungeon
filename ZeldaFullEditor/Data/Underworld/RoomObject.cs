namespace ZeldaFullEditor.Data.Underworld
{
	[Serializable]
	public class RoomObject : IDungeonPlaceable, IByteable, IFreelyPlaceable, IDelegatedDraw, IMouseCollidable, IMultilayered, ITypeID
	{
		public ushort ID => ObjectType.FullID;
		public int TypeID => ObjectType.FullID;
		public string Name => ObjectType.VanillaName;
		public bool IsChest => ObjectType.Specialness == SpecialObjectType.Chest || IsBigChest;
		public bool IsBigChest => ObjectType.Specialness == SpecialObjectType.BigChest;
		public bool IsStairs => ObjectType.Specialness == SpecialObjectType.InterroomStairs;
		public DungeonLimits LimitClass => ObjectType.LimitClass;

		public bool Resizable => ObjectType.Resizeability != DungeonObjectSizeability.None;

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

		public byte Size { get; set; }

		public int Width { get; set; } = 8;
		public int Height { get; set; } = 8;
		public Rectangle BoundingBox => new(RealX, RealY, Width, Height);

		public bool DiagonalFix { get; set; }

		public RoomObjectType ObjectType { get; }

		public TilesList Tiles { get; }

		public List<Rectangle> CollisionRectangles { get; } = new List<Rectangle>();

		public RoomObject(RoomObjectType type, TilesList tiles)
		{
			ObjectType = type;
			Tiles = tiles;
		}

		public RoomObject Clone()
		{
			return new RoomObject(ObjectType, Tiles)
			{
				GridX = GridX,
				GridY = GridY,
				Layer = Layer,
				Size = Size,
				Width = Width,
				Height = Height,
				DiagonalFix = DiagonalFix
			};
		}


		public void Draw(Artist art)
		{
			Width = 8;
			Height = 8;
			CollisionRectangles.Clear();
			ObjectType.Draw(art, this);
		}

		public bool DecreaseSize()
		{
			// Size > 0 will short circuit faster for unresizable objects
			if (Size > 0 && ObjectType.Resizeability != DungeonObjectSizeability.None)
			{
				Size--;
				return true;
			}
			return false;
		}

		/// <summary>
		/// Increases the object's size by 1.
		/// </summary>
		/// <returns><see langword="true"/> when successful</returns>
		public bool IncreaseSize()
		{
			if (ObjectType.Resizeability != DungeonObjectSizeability.None && Size < 15)
			{
				Size++;
				return true;
			}
			return false;
		}

		public bool PointIsInHitbox(int x, int y)
		{
			int yfix = DiagonalFix
					? -(6 + Size)
					: 0;
			throw new NotImplementedException();
		}

		public byte[] GetByteData()
		{
			return ObjectType.ObjectSet switch
			{
				DungeonObjectSet.Subtype1 => new byte[]
									{
						(byte) ((GridX << 2) | ((Size & 0x0C) >> 2)),
						(byte) ((GridY << 2) | (Size & 0x03)),
						(byte) ID
									},
				DungeonObjectSet.Subtype2 => new byte[]
				{
						(byte) (0xFC | (GridX >> 4)),
						(byte) ((GridX << 4) | ((GridY & 0x3C) >> 2)),
						(byte) ((GridY << 6) | (ID & 0x3F))
				},
				DungeonObjectSet.Subtype3 => new byte[]
				{
						(byte) ((GridX << 2) | (ID & 0x03)),
						(byte) ((GridY << 2) | ((ID & 0x0C) >> 2)),
						(byte) (0xF8 | ((ID & 0x70) >> 4))
				},
				_ => Array.Empty<byte>(),
			};
		}
	}

	/// <summary>
	/// Just a version of room objects for UI preview.
	/// </summary>
	public class RoomObjectPreview : RoomObject
	{
		public RoomObjectPreview(RoomObjectType type, TilesList tiles) : base(type, tiles)
		{
			Size = 4;
		}
	}
}
