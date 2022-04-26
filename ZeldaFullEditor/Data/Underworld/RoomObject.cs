using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data.Underworld
{
	// TODO new way to handle objects that change with the floor settings
	[Serializable]
	public unsafe class RoomObject : DungeonPlaceable, IByteable, IFreelyPlaceable, IDelegatedDraw, IMouseCollidable, IMultilayered, ITypeID
	{
		public ushort ID => ObjectType.FullID;
		public int TypeID => ObjectType.FullID;
		public string Name => ObjectType.VanillaName;

		public byte GridX { get; set; } = 0;
		public byte GridY { get; set; } = 0;

		public int RealX => NewX * 8;
		public int RealY => NewY * 8;

		public byte NewX { get; set; }
		public byte NewY { get; set; }
		public byte Layer { get; set; } = 0;
		public byte Size { get; set; } = 0;

		public int Width { get; set; } = 16;
		public int Height { get; set; } = 16;
		public Rectangle OutlineBox => new Rectangle(RealX, RealY, Width, Height);

		public bool IsChest => ObjectType.Specialness == SpecialObjectType.Chest || IsBigChest;
		public bool IsBigChest => ObjectType.Specialness == SpecialObjectType.BigChest;
		public bool IsStairs => ObjectType.Specialness == SpecialObjectType.InterroomStairs;

		public bool DiagonalFix { get; set; } = false;

		public RoomObjectType ObjectType { get; }

		public TilesList Tiles { get; }

		public List<Point> CollisionPoints { get; } = new List<Point>();

		public RoomObject(RoomObjectType type, TilesList tiles)
		{
			ObjectType = type;
			Tiles = tiles;
			ResetSize();
		}

		public RoomObject Clone()
		{
			RoomObject ret = new RoomObject(ObjectType, Tiles)
			{
				GridX = GridX,
				GridY = GridY,
				Layer = Layer,
				Size = Size,
				Width = Width,
				Height = Height,
				NewX = NewX,
				NewY = NewY,
				DiagonalFix = DiagonalFix
			};
			ret.CollisionPoints.Clear();
			// TODO do we need to set collision points?
			return ret;
		}


		public void Draw(ZScreamer ZS)
		{
			CollisionPoints.Clear();
			ObjectType.Draw(ZS, this);
		}

		private void ResetSize()
		{
			Width = 8;
			Height = 8;
		}

		public bool DecreaseSize()
		{
			// Size > 0 will short circuit faster for unresizable objects
			if (Size > 0 && ObjectType.Resizeability != DungeonObjectSizeability.None)
			{
				ResetSize();
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
				ResetSize();
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
			return false;
		}
		public byte[] GetByteData()
		{
			switch (ObjectType.ObjectSet)
			{
				case DungeonObjectSet.Subtype1:
					return new byte[]
					{
						(byte) ((GridX << 2) | ((Size & 0x0C) >> 2)),
						(byte) ((GridY << 2) | (Size & 0x03)),
						(byte) ID
					};

				case DungeonObjectSet.Subtype2:
					return new byte[]
					{
						(byte) (0xFC | (GridX >> 4)),
						(byte) ((GridX << 4) | ((GridY & 0x3C) >> 2)),
						(byte) ((GridY << 6) | (ID & 0x3F))
					};

				case DungeonObjectSet.Subtype3:
					return new byte[]
					{
						(byte) ((GridX << 2) | (ID & 0x03)),
						(byte) ((GridY << 2) | ((ID & 0x0C) >> 2)),
						(byte) (0xF8 | (ID >> 4))
					};

				default:
					return new byte[0];
			}
		}
	}

	/// <summary>
	/// Just a version of room objects for UI preview.
	/// </summary>
	public unsafe class RoomObjectPreview : RoomObject
	{
		public RoomObjectPreview(RoomObjectType type, TilesList tiles) : base(type, tiles) { }
	}
}
