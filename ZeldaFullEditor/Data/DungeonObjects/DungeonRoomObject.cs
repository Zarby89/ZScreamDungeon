using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data.DungeonObjects
{
	// TODO new way to handle objects that change with the floor settings
	[Serializable]
	public unsafe class RoomObject : DungeonPlaceable, IByteable, IFreelyPlaceable, IDelegatedDraw, IMouseCollidable, IMultilayered
	{
		public ushort ID => ObjectType.FullID;
		public string Name => ObjectType.VanillaName;

		public byte X { get; set; } = 0;
		public byte Y { get; set; } = 0;
		public byte NX { get; set; }
		public byte NY { get; set; }
		public byte Layer { get; set; } = 0;
		public byte Size { get; set; } = 0;

		public int Width { get; set; } = 16;
		public int Height { get; set; } = 16;

		public bool IsChest => ObjectType.Specialness == SpecialObjectType.Chest || IsBigChest;
		public bool IsBigChest => ObjectType.Specialness == SpecialObjectType.BigChest;
		public bool IsStairs => ObjectType.Specialness == SpecialObjectType.InterroomStairs;

		public bool DiagonalFix { get; set; } = false;

		public RoomObjectType ObjectType { get; }

		public TilesList Tiles { get; }

		public List<Point> CollisionPoints { get; } = new List<Point>();

		public byte[] Data
		{
			get
			{
				switch (ObjectType.ObjectSet)
				{
					case DungeonObjectSet.Subtype1:
						return new byte[]
						{
							(byte) ((X << 2) | ((Size & 0x0C) >> 2)),
							(byte) ((Y << 2) | (Size & 0x03)),
							(byte) ID
						};

					case DungeonObjectSet.Subtype2:
						return new byte[]
						{
							(byte) (0xFC | (X >> 4)),
							(byte) ((X << 4) | ((Y & 0x3C) >> 2)),
							(byte) ((Y << 6) | (ID & 0x3F))
						};

					case DungeonObjectSet.Subtype3:
						return new byte[]
						{
							(byte) ((X << 2) | (ID & 0x03)),
							(byte) ((Y << 2) | ((ID & 0x0C) >> 2)),
							(byte) (0xF8 | (ID >> 4))
						};

					default:
						return new byte[0];
				}
			}
		}

		public RoomObject(RoomObjectType type, TilesList tiles)
		{
			ObjectType = type;
			//ID = type.FullID;
			Tiles = tiles;
			ResetSize();
		}

		public RoomObject Clone()
		{
			RoomObject ret = new RoomObject(ObjectType, Tiles)
			{
				X = X,
				Y = Y,
				Layer = Layer,
				Size = Size,
				Width = Width,
				Height = Height,
				NX = NX,
				NY = NY,
				DiagonalFix = DiagonalFix
			};
			ret.CollisionPoints.Clear();
			// TODO do we need to set collision points?
			return ret;
		}


		public override void Draw(ZScreamer ZS)
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

		public override bool PointIsInHitbox(int x, int y)
		{
			throw new NotImplementedException();
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
