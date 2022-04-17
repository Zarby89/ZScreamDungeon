﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data.DungeonObjects
{
	// TODO new way to handle objects that change with the floor settings
	[Serializable]
	public unsafe class RoomObject : DungeonObject, IByteable, IFreelyPlaceable
	{

		public ushort ID { get; }
		public byte X { get; set; } = 0;
		public byte Y { get; set; } = 0;
		public byte NX { get; set; }
		public byte NY { get; set; }
		public byte Layer { get; set; } = 0;
		public byte Size { get; set; } = 0;

		public int Width { get; set; } = 16;
		public int Height { get; set; } = 16;

		public bool IsChest => ObjectType.Specialness == SpecialObjectType.Chest || ObjectType.Specialness == SpecialObjectType.BigChest;
		public bool DiagonalFix { get; set; } = false;

		public RoomObjectType ObjectType { get; }

		public override TilesList Tiles { get; }

		public override byte[] Data
		{
			get
			{
				switch (ObjectType.ObjectSet)
				{
					case DungeonObjectSet.Subtype1:
						return new byte[]
						{
							(byte) (0xFC | (X >> 4)),
							(byte) ((X << 4) | ((Y & 0x3C) >> 2)),
							(byte) ((Y << 6) | (ID & 0x3F))
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
			ID = type.FullID;
			Tiles = tiles;
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


		override public void Draw(ZScreamer ZS)
		{
			CollisionPoints.Clear();
			ObjectType.Draw(ZS, this);
		}

		public void ResetSize()
		{
			Width = 8;
			Height = 8;
		}

		public virtual bool DecreaseSize()
		{
			ResetSize();
			if (Size > 0)
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
		public virtual bool IncreaseSize()
		{
			ResetSize();
			if (Size < 15)
			{
				Size++;
				return true;
			}
			return false;
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
