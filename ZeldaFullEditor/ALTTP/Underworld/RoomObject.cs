namespace ZeldaFullEditor.ALTTP.Underworld
{
	/// <summary>
	/// Represents a room object; i.e. a dungeon entity that constitutes the physical make up of a room and is not
	/// a door, lightable torch, or pushable block object.
	/// </summary>
	[Serializable]
	public class RoomObject : IDungeonPlaceable, IByteable, IFreelyPlaceable, IDelegatedDraw, IMouseCollidable, IMultilayered, ITypeID
	{
		public ushort ID => ObjectType.FullID;
		public int TypeID => ObjectType.FullID;
		public string Name => ObjectType.Name;
		public bool IsChest => ObjectType.Specialness == ObjectSpecialType.Chest || IsBigChest;
		public bool IsBigChest => ObjectType.Specialness == ObjectSpecialType.BigChest;
		public bool IsStairs => ObjectType.Specialness == ObjectSpecialType.InterroomStairs;
		public DungeonLimits LimitClass => ObjectType.LimitClass;

		public bool Resizable => ObjectType.Resizeability != ObjectResizability.None;

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

		public List<Rectangle> CollisionRectangles { get; } = new();

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


		public virtual void Draw(IDrawArt art)
		{
			Width = 8;
			Height = 8;
			CollisionRectangles.Clear();
			((RoomArtist) art)?.AddTilesToTilemap(this);
		}

		/// <summary>
		/// Decreases the object's size by 1.
		/// </summary>
		/// <returns><see langword="true"/> when successful</returns>
		public bool DecreaseSize()
		{
			// Size > 0 will short circuit faster for unresizable objects
			if (ObjectType.Resizeability != ObjectResizability.None && Size > 0)
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
			if (ObjectType.Resizeability != ObjectResizability.None && Size < 15)
			{
				Size++;
				return true;
			}
			return false;
		}

		public bool PointIsInHitbox(int x, int y)
		{
			if (CollisionRectangles.Count == 0)
			{
				return this.PointIsInBoundingBox(x, y);
			}

			foreach (var v in CollisionRectangles)
			{
				if (v.Contains(x, y))
				{
					return true;
				}
			}

			return false;
		}

		public byte[] GetByteData() => ObjectType.ObjectSet switch
		{
			ObjectSubtype.Subtype1 => new[]
			{
					(byte) (GridX << 2 | (Size & 0x0C) >> 2),
					(byte) (GridY << 2 | Size & 0x03),
					(byte) ID
			},

			ObjectSubtype.Subtype2 => new[]
			{
					(byte) (0xFC | GridX >> 4),
					(byte) (GridX << 4 | (GridY & 0x3C) >> 2),
					(byte) (GridY << 6 | ID & 0x3F)
			},

			ObjectSubtype.Subtype3 => new[]
			{
					(byte) (GridX << 2 | ID & 0x03),
					(byte) (GridY << 2 | (ID & 0x0C) >> 2),
					(byte) (0xF8 | (ID & 0x70) >> 4)
			},

			_ => Array.Empty<byte>(),
		};
	}

	/// <summary>
	/// Just a version of room objects for UI preview.
	/// </summary>
	public class RoomObjectPreview : RoomObject, IPreview
	{
		public ImmutableArray<SearchCategory> Categories => ObjectType.Categories;
		public object EntityType => ObjectType;

		public RoomObjectPreview(RoomObjectType type, TilesList tiles) : base(type, tiles)
		{
		}

		public override void Draw(IDrawArt art)
		{
			var prv = (PreviewArtist) art;

			if (prv is null) return;

			var instructions = ObjectType.GetDrawingForSize(4);

			List<PreviewInfo> addooo = new(instructions.Length);

			foreach (DrawInfo d in instructions)
			{
				Tile t = Tiles[d.TileIndex].CloneModified(hflip: d.HFlip, vflip: d.VFlip);
				addooo.Add(new(t.ID, d.XOff, d.YOff, t.Palette, t.HFlip, t.VFlip));
			}
			prv.AddToObjectsPreview(this, addooo);
		}
	}
}
