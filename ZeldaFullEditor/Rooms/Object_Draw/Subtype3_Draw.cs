using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
	[Serializable]
	public class object_200 : Room_Object
	{
		public object_200(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x200, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x00].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(12, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int yy = 0; yy < 3; yy++)
			{
				for (int xx = 0; xx < 4; xx++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_201 : Room_Object
	{
		public object_201(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x201, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x01].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			sort = Sorting.NonScalable;
			addTiles(20, pos); // ??
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int yy = 0; yy < 5; yy++)
			{
				for (int xx = 0; xx < 4; xx++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_202 : Room_Object
	{
		public object_202(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x202, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x02].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			sort = Sorting.NonScalable;
			addTiles(28, pos); // ??
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int yy = 0; yy < 7; yy++)
			{
				for (int xx = 0; xx < 4; xx++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_203 : Room_Object
	{
		public object_203(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x203, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x03].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			sort = Sorting.NonScalable;
			addTiles(1, pos); // ??
		}

		public override void Draw()
		{
			base.Draw();

			draw_tile(tiles[0], 0, 0);
		}
	}

	[Serializable]
	public class object_204 : Room_Object
	{
		public object_204(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x204, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x04].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			sort = Sorting.NonScalable;
			addTiles(1, pos); // ??
		}
		public override void Draw()
		{
			base.Draw();

			draw_tile(tiles[0], 0, 0);
		}
	}

	[Serializable]
	public class object_205 : Room_Object
	{
		public object_205(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x205, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x05].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			sort = Sorting.NonScalable;
			addTiles(1, pos); // ??
		}

		public override void Draw()
		{
			base.Draw();

			draw_tile(tiles[0], 0, 0);
		}
	}

	[Serializable]
	public class object_206 : Room_Object
	{
		public object_206(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x206, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x06].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			sort = Sorting.NonScalable;
			addTiles(1, pos); // ??
		}
		public override void Draw()
		{
			base.Draw();

			draw_tile(tiles[0], 0, 0);
		}
	}

	[Serializable]
	public class object_207 : Room_Object
	{
		public object_207(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x207, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x07].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			sort = Sorting.NonScalable;
			addTiles(1, pos); // ??
		}

		public override void Draw()
		{
			base.Draw();

			draw_tile(tiles[0], 0, 0);
		}
	}

	[Serializable]
	public class object_208 : Room_Object
	{
		public object_208(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x208, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x08].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			sort = Sorting.NonScalable;
			addTiles(1, pos); // ??
		}

		public override void Draw()
		{
			base.Draw();

			draw_tile(tiles[0], 0, 0);
		}
	}

	[Serializable]
	public class object_209 : Room_Object
	{
		public object_209(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x209, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x09].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			sort = Sorting.NonScalable;
			addTiles(1, pos); // ??
		}

		public override void Draw()
		{
			base.Draw();

			draw_tile(tiles[0], 0, 0);
		}
	}

	[Serializable]
	public class object_20A : Room_Object
	{
		public object_20A(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x20A, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x0A].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(1, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			draw_tile(tiles[0], 0, 0);
		}
	}

	[Serializable]
	public class object_20B : Room_Object
	{
		public object_20B(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x20B, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x0B].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(1, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			draw_tile(tiles[0], 0, 0);
		}
	}

	[Serializable]
	public class object_20C : Room_Object
	{
		public object_20C(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x20C, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x0C].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(1, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			draw_tile(tiles[0], 0, 0);
		}
	}

	[Serializable]
	public class object_20D : Room_Object
	{
		public object_20D(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x20D, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x0D].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(6, pos);
			addTiles(6, pos);
			sort = Sorting.NonScalable;

			for (int i = 6; i < 12; i++)
			{
				tiles[i].HFlip = true;
			}
		}

		public override void Draw()
		{
			base.Draw();

			draw_tile(tiles[0], 0, 0);
			draw_tile(tiles[1], 8, 0);

			draw_tile(tiles[6], 120, 0);
			draw_tile(tiles[7], 112, 0);

			draw_tile(tiles[3], 8, 2 * 8);
			draw_tile(tiles[9], 112, 2 * 8);

			for (int xx = 0; xx < 5; xx++)
			{
				draw_tile(tiles[1], (xx + 2) * 8, 0); draw_tile(tiles[7], (xx + 9) * 8, 0);
				draw_tile(tiles[2], (xx + 2) * 8, 8); draw_tile(tiles[8], (xx + 9) * 8, 8);
				draw_tile(tiles[4], (xx + 2) * 8, 16); draw_tile(tiles[10], (xx + 9) * 8, 16);
				draw_tile(tiles[5], (xx + 2) * 8, 24); draw_tile(tiles[11], (xx + 9) * 8, 24);
			}
		}
	}
	[Serializable]
	public class object_20E : Room_Object
	{
		public object_20E(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x20E, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x0E].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(1, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			draw_tile(tiles[0], 0, 0);
		}
	}

	[Serializable]
	public class object_20F : Room_Object
	{
		public object_20F(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x20F, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x0F].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(1, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			draw_tile(tiles[0], 0, 0);
		}
	}

	[Serializable]
	public class object_210 : Room_Object
	{
		public object_210(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x210, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x10].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(4, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 2; xx++)
			{
				for (int yy = 0; yy < 2; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_211 : Room_Object
	{
		public object_211(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x211, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x11].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(4, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 2; xx++)
			{
				for (int yy = 0; yy < 2; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_212 : Room_Object
	{
		public object_212(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x212, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x12].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(4, pos); // ??
			sort = Sorting.Floors | Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();
			for (int yy = 0; yy < 3; yy++)
			{
				for (int xx = 0; xx < 3; xx++)
				{
					draw_tile(tiles[0], (xx * 2) * 8, ((yy * 3)) * 8);
					draw_tile(tiles[1], (xx * 2) * 8, (1 + (yy * 3)) * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_213 : Room_Object
	{
		public object_213(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x213, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x13].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			sort = Sorting.NonScalable;
			addTiles(4, pos); // ??
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;

			for (int xx = 0; xx < 2; xx++)
			{
				for (int yy = 0; yy < 2; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_214 : Room_Object
	{
		public object_214(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x214, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x14].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			sort = Sorting.NonScalable;
			addTiles(12, pos); // ??
		}
		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int yy = 0; yy < 3; yy++)
			{
				for (int xx = 0; xx < 4; xx++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_215 : Room_Object
	{
		public object_215(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x215, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x15].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			sort = Sorting.NonScalable;

			addTiles(80, pos); // ??
		}
		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int yy = 0; yy < 8; yy++)
			{
				for (int xx = 0; xx < 10; xx++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_216 : Room_Object
	{
		public object_216(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x216, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x16].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			sort = Sorting.NonScalable;
			addTiles(4, pos); // ??
		}
		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 2; xx++)
			{
				for (int yy = 0; yy < 2; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}


	[Serializable]
	public class object_217 : Room_Object
	{
		public object_217(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x217, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x17].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			sort = Sorting.NonScalable;
			addTiles(6, pos);
			addTiles(6, pos);

			for (int i = 6; i < 12; i++)
			{
				tiles[i].HFlip = true;
			}
		}

		public override void Draw()
		{
			base.Draw();

			draw_tile(tiles[0], 0, 0);
			draw_tile(tiles[1], 8, 0);

			draw_tile(tiles[6], 120, 0);
			draw_tile(tiles[7], 112, 0);

			draw_tile(tiles[3], 8, 2 * 8);
			draw_tile(tiles[9], 112, 2 * 8);

			for (int xx = 0; xx < 5; xx++)
			{
				draw_tile(tiles[1], (xx + 2) * 8, 0); draw_tile(tiles[7], (xx + 9) * 8, 0);
				draw_tile(tiles[2], (xx + 2) * 8, 8); draw_tile(tiles[8], (xx + 9) * 8, 8);
				draw_tile(tiles[4], (xx + 2) * 8, 16); draw_tile(tiles[10], (xx + 9) * 8, 16);
				draw_tile(tiles[5], (xx + 2) * 8, 24); draw_tile(tiles[11], (xx + 9) * 8, 24);
			}
		}
	}


	[Serializable]
	public class object_218 : Room_Object
	{
		public object_218(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x218, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x18].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			sort = Sorting.NonScalable;
			addTiles(4, pos); // ??
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;

			for (int xx = 0; xx < 2; xx++)
			{
				for (int yy = 0; yy < 2; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}


	[Serializable]
	public class object_219 : Room_Object
	{
		public object_219(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x219, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x19].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			sort = Sorting.NonScalable;
			addTiles(4, pos); // ??
			this.options |= ObjectOption.Chest;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 2; xx++)
			{
				for (int yy = 0; yy < 2; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}


	[Serializable]
	public class object_21A : Room_Object
	{
		public object_21A(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x21A, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x1A].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			sort = Sorting.NonScalable;
			addTiles(4, pos); // ??
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 2; xx++)
			{
				for (int yy = 0; yy < 2; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_21B : Room_Object
	{
		public object_21B(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x21B, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x1B].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			sort = Sorting.NonScalable | Sorting.Stairs;
			allBgs = true;
			addTiles(16, pos); // ??
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 4; xx++)
			{
				for (int yy = 0; yy < 4; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_21C : Room_Object
	{
		public object_21C(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x21C, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x1C].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			allBgs = true;
			sort = Sorting.NonScalable | Sorting.Stairs;
			addTiles(16, pos); // ??
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 4; xx++)
			{
				for (int yy = 0; yy < 4; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_21D : Room_Object
	{
		public object_21D(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x21D, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x1D].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			allBgs = true;
			sort = Sorting.NonScalable | Sorting.Stairs;
			addTiles(16, pos); // ??
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 4; xx++)
			{
				for (int yy = 0; yy < 4; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_21E : Room_Object
	{
		public object_21E(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x21E, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x1E].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(16, pos); // ??
			sort = Sorting.NonScalable | Sorting.Stairs;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 4; xx++)
			{
				for (int yy = 0; yy < 4; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_21F : Room_Object
	{
		public object_21F(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x21F, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x1F].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(16, pos); // ??
			sort = Sorting.NonScalable | Sorting.Stairs;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 4; xx++)
			{
				for (int yy = 0; yy < 4; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_220 : Room_Object
	{
		public object_220(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x220, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x20].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(16, pos); // ??
			sort = Sorting.NonScalable | Sorting.Stairs;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 4; xx++)
			{
				for (int yy = 0; yy < 4; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_221 : Room_Object
	{
		public object_221(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x221, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x21].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(16, pos); // ??
			sort = Sorting.NonScalable | Sorting.Stairs;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 4; xx++)
			{
				for (int yy = 0; yy < 4; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_222 : Room_Object
	{
		public object_222(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x222, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x22].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(4, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 2; xx++)
			{
				for (int yy = 0; yy < 2; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_223 : Room_Object
	{
		public object_223(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x223, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x23].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(4, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 2; xx++)
			{
				for (int yy = 0; yy < 2; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_224 : Room_Object
	{
		public object_224(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x224, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x24].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(4, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 2; xx++)
			{
				for (int yy = 0; yy < 2; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_225 : Room_Object
	{
		public object_225(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x225, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x25].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(4, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 2; xx++)
			{
				for (int yy = 0; yy < 2; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_226 : Room_Object
	{
		public object_226(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x226, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x26].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(16, pos); // ??
			sort = Sorting.NonScalable | Sorting.Stairs;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 4; xx++)
			{
				for (int yy = 0; yy < 4; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_227 : Room_Object
	{
		public object_227(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x227, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x27].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			sort = Sorting.NonScalable | Sorting.Stairs;
			addTiles(16, pos); // ??
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 4; xx++)
			{
				for (int yy = 0; yy < 4; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_228 : Room_Object
	{
		public object_228(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x228, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x28].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			sort = Sorting.NonScalable | Sorting.Stairs;
			addTiles(16, pos); // ??
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 4; xx++)
			{
				for (int yy = 0; yy < 4; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_229 : Room_Object
	{
		public object_229(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x229, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x29].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			sort = Sorting.NonScalable | Sorting.Stairs;
			addTiles(16, pos); // ??
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 4; xx++)
			{
				for (int yy = 0; yy < 4; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_22A : Room_Object
	{
		public object_22A(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x22A, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x2A].Name;
			allBgs = true;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(16, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 4; xx++)
			{
				for (int yy = 0; yy < 4; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_22B : Room_Object
	{
		public object_22B(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x22B, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x2B].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			sort = Sorting.NonScalable | Sorting.Stairs;
			addTiles(4, pos); // ??
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 2; xx++)
			{
				for (int yy = 0; yy < 2; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_22C : Room_Object
	{
		public object_22C(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x22C, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x2C].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			sort = Sorting.NonScalable;
			addTiles(16, pos); // ??
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 2; xx++)
			{
				for (int yy = 0; yy < 2; yy++)
				{
					draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
					draw_tile(tiles[tid + 4], (xx + 2) * 8, (yy) * 8);
					draw_tile(tiles[tid + 8], (xx) * 8, (yy + 2) * 8);
					draw_tile(tiles[tid + 12], (xx + 2) * 8, (yy + 2) * 8);
					tid++;
				}
			}
		}
	}


	[Serializable]
	public class object_22D : Room_Object
	{
		public object_22D(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x22D, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x2D].Name;
			// Harcoded position wtf ?!?
			int pos = ZS.Offsets.tile_address + 0x1B4A;
			sort = Sorting.NonScalable;
			addTiles(84, pos); // ??
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int yy = 0; yy < 14; yy++)
			{
				// 390

				tiles[tid].HFlip = false;
				draw_tile(tiles[tid], 0, (yy) * 8);
				tiles[tid + 14].HFlip = false;
				draw_tile(tiles[tid + 14], 8, (yy) * 8);
				draw_tile(tiles[tid + 14], 16, (yy) * 8);
				tiles[tid + 28].HFlip = false;
				draw_tile(tiles[tid + 28], 24, (yy) * 8);
				tiles[tid + 48].HFlip = true;
				draw_tile(tiles[tid + 42], (4) * 8, (yy) * 8);
				tiles[tid + 56].HFlip = false;
				draw_tile(tiles[tid + 56], (5) * 8, (yy) * 8);

				tiles[tid + 70].HFlip = false;
				draw_tile(tiles[tid + 70], (6) * 8, (yy) * 8);
				tiles[tid + 70].HFlip = true;
				draw_tile(tiles[tid + 70], (7) * 8, (yy) * 8);
				tiles[tid + 56].HFlip = true;
				draw_tile(tiles[tid + 56], (8) * 8, (yy) * 8);
				tiles[tid + 48].HFlip = true;
				draw_tile(tiles[tid + 42], (9) * 8, (yy) * 8);
				tiles[tid + 28].HFlip = true;
				draw_tile(tiles[tid + 28], (10) * 8, (yy) * 8);
				tiles[tid + 14].HFlip = true;
				draw_tile(tiles[tid + 14], (11) * 8, (yy) * 8);
				draw_tile(tiles[tid + 14], (12) * 8, (yy) * 8);
				tiles[tid].HFlip = true;
				draw_tile(tiles[tid], (13) * 8, (yy) * 8);
				tid++;
			}
		}
	}

	[Serializable]
	public class object_22E : Room_Object
	{
		public object_22E(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x22E, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x2E].Name;
			int pos = ZS.Offsets.tile_address + 0x1BF2;
			addTiles(127, pos); // ??
			sort = Sorting.NonScalable;

			// 6x4 (top wall) 24
			// 1x5 (diago left) 5
			// 4x6 (side wall) (left need to be mirrored to right) 24
			// 6x2 (top light) 12
			// 2x6 (left light) 12
			// 5x5 (diagonal light) 25
		}

		public override void Draw()
		{
			base.Draw();

			// Top Wall
			int tid = 0;
			for (int i = 0; i < 3; i++)
			{
				tid = 0;
				for (int xx = 0; xx < 6; xx++)
				{
					for (int yy = 0; yy < 4; yy++)
					{
						// 5
						draw_tile(tiles[tid], (7 + xx + (i * 6)) * 8, (4 + yy) * 8);
						tid++;
					}

				}
			}

			// Diagonals wall
			for (int xx = 0; xx < 7; xx++)
			{
				// 5
				tiles[24].HFlip = false;
				tiles[25].HFlip = false;
				tiles[26].HFlip = false;
				tiles[27].HFlip = false;
				tiles[28].HFlip = false;
				draw_tile(tiles[24], (8 - xx) * 8, (4 + xx) * 8);
				draw_tile(tiles[25], (8 - xx) * 8, (5 + xx) * 8);
				draw_tile(tiles[26], (8 - xx) * 8, (6 + xx) * 8);
				draw_tile(tiles[27], (8 - xx) * 8, (7 + xx) * 8);
				draw_tile(tiles[28], (8 - xx) * 8, (8 + xx) * 8);

				tiles[24].HFlip = true;
				tiles[25].HFlip = true;
				tiles[26].HFlip = true;
				tiles[27].HFlip = true;
				tiles[28].HFlip = true;
				draw_tile(tiles[24], (23 + xx) * 8, (4 + xx) * 8);
				draw_tile(tiles[25], (23 + xx) * 8, (5 + xx) * 8);
				draw_tile(tiles[26], (23 + xx) * 8, (6 + xx) * 8);
				draw_tile(tiles[27], (23 + xx) * 8, (7 + xx) * 8);
				draw_tile(tiles[28], (23 + xx) * 8, (8 + xx) * 8);
			}

			// Sides walls
			for (int i = 0; i < 3; i++)
			{
				tid = 29;
				for (int yy = 0; yy < 6; yy++)
				{
					for (int xx = 0; xx < 4; xx++)
					{
						// 5
						tiles[tid].HFlip = false;
						draw_tile(tiles[tid], (2 + xx) * 8, (11 + yy + (i * 6)) * 8);
						tiles[tid].HFlip = true;
						draw_tile(tiles[tid], (29 - xx) * 8, (11 + yy + (i * 6)) * 8);
						tid++;
					}
				}
			}

			// 53
			for (int i = 0; i < 2; i++)
			{
				tid = 53;
				for (int yy = 0; yy < 2; yy++)
				{
					for (int xx = 0; xx < 6; xx++)
					{
						draw_tile(tiles[tid], (12 + xx + (i * 6)) * 8, (9 + yy) * 8);
						//tiles[tid].HFlip = true;
						//draw_tile(tiles[tid], (29 - xx + (i * 6)) * 8, (8 + yy ) * 8);
						tid++;
					}
				}
			}

			for (int i = 0; i < 2; i++)
			{
				tid = 65;
				for (int yy = 0; yy < 6; yy++)
				{
					for (int xx = 0; xx < 2; xx++)
					{
						draw_tile(tiles[tid], (7 + xx) * 8, (14 + yy + (i * 6)) * 8);
						//tiles[tid].HFlip = true;
						//draw_tile(tiles[tid], (29 - xx + (i * 6)) * 8, (8 + yy ) * 8);
						tid++;
					}

				}
			}

			tid = 77;

			for (int xx = 0; xx < 5; xx++)
			{
				for (int yy = 0; yy < 5; yy++)
				{
					draw_tile(tiles[tid], (7 + xx) * 8, (9 + yy) * 8);
					tid++;
				}
			}
		}
	}

	[Serializable]
	public class object_22F : Room_Object
	{
		public object_22F(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x22F, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x2F].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			// 0x0E92; for skulls
			addTiles(4, pos); // ??
			sort = Sorting.NonScalable | Sorting.Dungeons;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 2; xx++)
			{
				for (int yy = 0; yy < 2; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_230 : Room_Object
	{
		public object_230(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x230, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x30].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(4, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 2; xx++)
			{
				for (int yy = 0; yy < 2; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_231 : Room_Object
	{
		public object_231(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x231, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x31].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(12, pos); // ??
			sort = Sorting.NonScalable | Sorting.Dungeons;
			options |= ObjectOption.Chest;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 4; xx++)
			{
				for (int yy = 0; yy < 3; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}


	[Serializable]
	public class object_232 : Room_Object
	{
		public object_232(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x232, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x32].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(12, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 4; xx++)
			{
				for (int yy = 0; yy < 3; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}


	[Serializable]
	public class object_233 : Room_Object
	{
		public object_233(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x233, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x33].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			allBgs = true;
			addTiles(16, pos); // ??
			sort = Sorting.NonScalable | Sorting.Stairs;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 4; xx++)
			{
				for (int yy = 0; yy < 4; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_234 : Room_Object
	{
		public object_234(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x234, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x34].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			sort = Sorting.NonScalable;
			addTiles(6, pos); // ??
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 3; xx++)
			{
				for (int yy = 0; yy < 2; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_235 : Room_Object
	{
		public object_235(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x235, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x35].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(6, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 3; xx++)
			{
				for (int yy = 0; yy < 2; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_236 : Room_Object
	{
		public object_236(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x236, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x36].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(18, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 6; xx++)
			{
				for (int yy = 0; yy < 3; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_237 : Room_Object
	{
		public object_237(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x237, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x37].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(18, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 6; xx++)
			{
				for (int yy = 0; yy < 3; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_238 : Room_Object
	{
		public object_238(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x238, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x38].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(18, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 6; xx++)
			{
				for (int yy = 0; yy < 3; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_239 : Room_Object
	{
		public object_239(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x239, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x39].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(18, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 6; xx++)
			{
				for (int yy = 0; yy < 3; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_23A : Room_Object
	{
		public object_23A(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x23A, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x3A].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(24, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 2; xx++)
			{
				for (int yy = 0; yy < 3; yy++)
				{
					draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
					draw_tile(tiles[tid + 6], (xx + 2) * 8, (yy) * 8);
					tid++;
				}
			}

			for (int yy = 0; yy < 3; yy++)
			{
				draw_tile(tiles[tid + 6], 0, (yy + 3) * 8);
				draw_tile(tiles[tid + 9], 8, (yy + 3) * 8);
				draw_tile(tiles[tid + 12], 16, (yy + 3) * 8);
				draw_tile(tiles[tid + 15], 24, (yy + 3) * 8);
				tid++;
			}
		}
	}

	[Serializable]
	public class object_23B : Room_Object
	{
		public object_23B(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x23B, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x3B].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(24, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 2; xx++)
			{
				for (int yy = 0; yy < 3; yy++)
				{
					draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
					draw_tile(tiles[tid + 6], (xx + 2) * 8, (yy) * 8);
					tid++;
				}
			}

			for (int yy = 0; yy < 3; yy++)
			{
				draw_tile(tiles[tid + 6], 0, (yy + 3) * 8);
				draw_tile(tiles[tid + 9], 8, (yy + 3) * 8);
				draw_tile(tiles[tid + 12], 16, (yy + 3) * 8);
				draw_tile(tiles[tid + 15], 24, (yy + 3) * 8);
				tid++;
			}
		}
	}

	[Serializable]
	public class object_23C : Room_Object
	{
		public object_23C(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x23C, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x3C].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(24, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 6; xx++)
			{
				for (int yy = 0; yy < 4; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}

		}
	}

	[Serializable]
	public class object_23D : Room_Object
	{
		public object_23D(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x23D, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x3D].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(24, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 6; xx++)
			{
				for (int yy = 0; yy < 4; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_23E : Room_Object
	{
		public object_23E(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x23E, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x3E].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(4, pos);//??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 2; xx++)
			{
				for (int yy = 0; yy < 2; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_23F : Room_Object
	{
		public object_23F(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x23F, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x3F].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(4, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 2; xx++)
			{
				for (int yy = 0; yy < 2; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_240 : Room_Object
	{
		public object_240(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x240, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x40].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(4, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 2; xx++)
			{
				for (int yy = 0; yy < 2; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_241 : Room_Object
	{
		public object_241(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x241, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x41].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(4, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 2; xx++)
			{
				for (int yy = 0; yy < 2; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_242 : Room_Object
	{
		public object_242(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x242, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x42].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(4, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 2; xx++)
			{
				for (int yy = 0; yy < 2; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_243 : Room_Object
	{
		public object_243(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x243, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x43].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(4, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 2; xx++)
			{
				for (int yy = 0; yy < 2; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_244 : Room_Object
	{
		public object_244(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x244, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x44].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(4, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 2; xx++)
			{
				for (int yy = 0; yy < 2; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_245 : Room_Object
	{
		public object_245(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x245, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x45].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(4, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 2; xx++)
			{
				for (int yy = 0; yy < 2; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_246 : Room_Object
	{
		public object_246(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x246, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x46].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(4, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 2; xx++)
			{
				for (int yy = 0; yy < 2; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_247 : Room_Object
	{
		public object_247(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x247, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x47].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(16, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			// 00 04 02 06
			// 08 12 10 14
			// 01 05 03 07
			// 09 13 11 15
			draw_tile(tiles[00], 0, 0); draw_tile(tiles[04], 8, 0); draw_tile(tiles[02], 16, 0); draw_tile(tiles[06], 24, 0);
			draw_tile(tiles[08], 0, 8); draw_tile(tiles[12], 8, 8); draw_tile(tiles[10], 16, 8); draw_tile(tiles[14], 24, 8);
			draw_tile(tiles[01], 0, 16); draw_tile(tiles[05], 8, 16); draw_tile(tiles[03], 16, 16); draw_tile(tiles[07], 24, 16);
			draw_tile(tiles[09], 0, 24); draw_tile(tiles[13], 8, 24); draw_tile(tiles[11], 16, 24); draw_tile(tiles[15], 24, 24);
		}
	}

	[Serializable]
	public class object_248 : Room_Object
	{
		public object_248(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x248, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x48].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(16, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 4; xx++)
			{
				for (int yy = 0; yy < 4; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_249 : Room_Object
	{
		public object_249(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x249, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x49].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(4, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 2; xx++)
			{
				for (int yy = 0; yy < 2; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_24A : Room_Object
	{
		public object_24A(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x24A, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x4A].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(4, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 2; xx++)
			{
				for (int yy = 0; yy < 2; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_24B : Room_Object
	{
		public object_24B(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x24B, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x4B].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(24, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 8; xx++)
			{
				for (int yy = 0; yy < 3; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_24C : Room_Object
	{
		public object_24C(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x24C, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x4C].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(48, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int yy = 0; yy < 8; yy++)
			{
				for (int xx = 0; xx < 6; xx++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_24D : Room_Object
	{
		public object_24D(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x24D, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x4D].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(18, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 6; xx++)
			{
				for (int yy = 0; yy < 3; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
				for (int yy = 0; yy < 3; yy++)
				{
					//TODO: Add something here?
				}
			}
		}
	}

	[Serializable]
	public class object_24E : Room_Object
	{
		public object_24E(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x24E, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x4E].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(12, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 4; xx++)
			{
				for (int yy = 0; yy < 3; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}


	[Serializable]
	public class object_24F : Room_Object
	{
		public object_24F(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x24F, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x4F].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(4, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 2; xx++)
			{
				for (int yy = 0; yy < 2; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_250 : Room_Object
	{
		public object_250(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x250, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x50].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(4, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 2; xx++)
			{
				for (int yy = 0; yy < 2; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}


	[Serializable]
	public class object_251 : Room_Object
	{
		public object_251(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x251, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x51].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(4, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 2; xx++)
			{
				for (int yy = 0; yy < 2; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_252 : Room_Object
	{
		public object_252(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x252, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x52].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(4, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 2; xx++)
			{
				for (int yy = 0; yy < 2; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}


	[Serializable]
	public class object_253 : Room_Object
	{
		public object_253(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x253, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x53].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(4, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 2; xx++)
			{
				for (int yy = 0; yy < 2; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}


	[Serializable]
	public class object_254 : Room_Object
	{
		public object_254(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x254, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x54].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(26, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			for (int xx = 0; xx < 12; xx++)
			{
				tiles[1].HFlip = (xx & 0x01) == 0x01;
				for (int yy = 0; yy < 3; yy++)
				{
					if (yy < 2)
					{
						draw_tile(tiles[0], (xx + 1) * 8, (yy) * 8);
					}
					else
					{
						draw_tile(tiles[1], (xx + 1) * 8, (yy) * 8);
					}
				}
			}
			for (int xx = 0; xx < 7; xx++)
			{
				for (int yy = 0; yy < 3; yy++)
				{
					draw_tile(tiles[2 + yy], (xx * 2) * 8, (yy + 3) * 8);
					Tile t = new Tile(tiles[2 + yy].ID, tiles[2 + yy].Palette, tiles[2 + yy].Priority, tiles[2 + yy].HFlip, tiles[2 + yy].VFlip);
					t.HFlip = true;
					draw_tile(t, ((1 + (xx * 2)) * 8), (yy + 3) * 8);
				}
			}

			// xx 4, yy 4
			for (int xx = 0; xx < 6; xx++)
			{
				tiles[6].HFlip = xx.BitIsOn(0x01);
				for (int yy = 0; yy < 1; yy++)
				{
					draw_tile(tiles[6], (((xx + 4)) * 8), (yy + 4) * 8);
					draw_tile(tiles[7], (((xx + 4)) * 8), (yy + 5) * 8);
				}
			}

			tiles[8].HFlip = false;
			tiles[9].HFlip = false;
			draw_tile(tiles[8], (0), 0);
			draw_tile(tiles[8], (0), 8);
			draw_tile(tiles[9], (0), 16);
			tiles[8].HFlip = true;
			tiles[9].HFlip = true;
			draw_tile(tiles[8], ((13) * 8), 0);
			draw_tile(tiles[8], ((13) * 8), 8);
			draw_tile(tiles[9], ((13) * 8), 16);

			int tid = 10;
			for (int xx = 0; xx < 4; xx++)
			{
				for (int yy = 0; yy < 4; yy++)
				{
					tiles[tid].HFlip = false;
					draw_tile(tiles[tid], (((xx + 3)) * 8), (yy + 10) * 8);
					tid++;
				}
			}

			tid = 10;
			for (int xx = 4; xx > 0; xx--)
			{
				for (int yy = 0; yy < 4; yy++)
				{
					tiles[tid].HFlip = true;
					draw_tile(tiles[tid], (((xx + 6)) * 8), (yy + 10) * 8);
					tid++;
				}
			}
		}
	}

	[Serializable]
	public class object_255 : Room_Object
	{
		public object_255(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x255, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x55].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(16, pos); // ??
			sort = Sorting.NonScalable;
		}
		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 4; xx++)
			{
				for (int yy = 0; yy < 4; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_256 : Room_Object
	{
		public object_256(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x256, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x56].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(4, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 2; xx++)
			{
				for (int yy = 0; yy < 2; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_257 : Room_Object
	{
		public object_257(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x257, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x57].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(4, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 2; xx++)
			{
				for (int yy = 0; yy < 2; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_258 : Room_Object
	{
		public object_258(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x258, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x58].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(6, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 2; xx++)
			{
				for (int yy = 0; yy < 2; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_259 : Room_Object
	{
		public object_259(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x259, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x59].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(4, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 2; xx++)
			{
				for (int yy = 0; yy < 2; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_25A : Room_Object
	{
		public object_25A(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x25A, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x5A].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(8, pos); // ??
			sort = Sorting.NonScalable;
		}
		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int yy = 0; yy < 2; yy++)
			{
				for (int xx = 0; xx < 4; xx++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_25B : Room_Object
	{
		public object_25B(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x25B, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x5B].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(32, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;

			for (int xx = 0; xx < 3; xx++)
			{
				tid = 0 + xx;
				for (int yy = 0; yy < 1; yy++)
				{
					draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
				}

				tid = 1 + xx;
				for (int yy = 0; yy < 3; yy++)
				{
					draw_tile(tiles[tid], (xx) * 8, (yy + 1) * 8);
					draw_tile(tiles[tid + 1], (xx) * 8, (yy + 1) * 8);
					draw_tile(tiles[tid + 2], (xx) * 8, (yy + 1) * 8);
				}

				tid = 6 + xx;
				for (int yy = 0; yy < 1; yy++)
				{
					draw_tile(tiles[tid], (xx) * 8, (yy + 4) * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_25C : Room_Object
	{
		public object_25C(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x25C, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x5C].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(24, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 6; xx++)
			{
				for (int yy = 0; yy < 4; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_25D : Room_Object
	{
		public object_25D(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x25D, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x5D].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(18, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 6; xx++)
			{
				for (int yy = 0; yy < 3; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_25E : Room_Object
	{
		public object_25E(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x25E, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x5E].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(4, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 2; xx++)
			{
				for (int yy = 0; yy < 2; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_25F : Room_Object
	{
		public object_25F(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x25F, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x5F].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(4, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 2; xx++)
			{
				for (int yy = 0; yy < 2; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}


	[Serializable]
	public class object_260 : Room_Object
	{
		public object_260(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x260, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x60].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(18, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 3; xx++)
			{
				for (int yy = 0; yy < 3; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
				for (int yy = 0; yy < 3; yy++)
				{
					draw_tile(tiles[tid], (xx) * 8, (yy + 2) * 8);
					tid++;
				}
			}
		}
	}

	[Serializable]
	public class object_261 : Room_Object
	{
		public object_261(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x261, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x61].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(18, pos); // ??
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 3; xx++)
			{
				for (int yy = 0; yy < 3; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
				for (int yy = 0; yy < 3; yy++)
				{
					draw_tile(tiles[tid], (xx) * 8, (yy + 2) * 8);
					tid++;
				}
			}
		}
	}

	[Serializable]
	public class object_262 : Room_Object
	{
		public object_262(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x262, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x62].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(242, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 22; xx++)
			{
				for (int yy = 0; yy < 11; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_263 : Room_Object
	{
		public object_263(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x263, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x63].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(4, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 2; xx++)
			{
				for (int yy = 0; yy < 2; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_264 : Room_Object
	{
		public object_264(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x264, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x64].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(4, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 2; xx++)
			{
				for (int yy = 0; yy < 2; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_265 : Room_Object
	{
		public object_265(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x265, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x65].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(4, pos); // ??
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 2; xx++)
			{
				for (int yy = 0; yy < 2; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_266 : Room_Object
	{
		public object_266(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x266, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x66].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(16, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 4; xx++)
			{
				for (int yy = 0; yy < 4; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_267 : Room_Object
	{
		public object_267(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x267, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x67].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(12, pos); // ??
			sort = Sorting.NonScalable | Sorting.Wall;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;

			for (int xx = 0; xx < 4; xx++)
			{
				for (int yy = 0; yy < 3; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_268 : Room_Object
	{
		public object_268(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x268, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x68].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(12, pos); // ??
			sort = Sorting.NonScalable | Sorting.Wall;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 4; xx++)
			{
				for (int yy = 0; yy < 3; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_269 : Room_Object
	{
		public object_269(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x269, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x69].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(12, pos); // ??
			sort = Sorting.NonScalable | Sorting.Wall;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 3; xx++)
			{
				for (int yy = 0; yy < 4; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_26A : Room_Object
	{
		public object_26A(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x26A, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x6A].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(12, pos); // ??
			sort = Sorting.NonScalable | Sorting.Wall;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 3; xx++)
			{
				for (int yy = 0; yy < 4; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_26B : Room_Object
	{
		public object_26B(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x26B, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x6B].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			sort = Sorting.NonScalable;
			addTiles(16, pos); // ??
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 4; xx++)
			{
				for (int yy = 0; yy < 4; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}

		}
	}

	[Serializable]
	public class object_26C : Room_Object
	{
		public object_26C(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x26C, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x6C].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			sort = Sorting.NonScalable;
			addTiles(12, pos); // ??
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 4; xx++)
			{
				for (int yy = 0; yy < 3; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_26D : Room_Object
	{
		public object_26D(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x26D, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x6D].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			sort = Sorting.NonScalable;
			addTiles(12, pos); // ??
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 4; xx++)
			{
				for (int yy = 0; yy < 3; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_26E : Room_Object
	{
		public object_26E(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x26E, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x6E].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			sort = Sorting.NonScalable;
			addTiles(12, pos); // ??
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 3; xx++)
			{
				for (int yy = 0; yy < 4; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_26F : Room_Object
	{
		public object_26F(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x26F, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x6F].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			sort = Sorting.NonScalable;
			addTiles(12, pos); // ??
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 3; xx++)
			{
				for (int yy = 0; yy < 4; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_270 : Room_Object
	{
		public object_270(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x270, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x70].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			sort = Sorting.NonScalable;
			addTiles(32, pos); //? ?
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 4; xx++)
			{
				for (int yy = 0; yy < 4; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}

			draw_tile(tiles[0], 0, (4) * 8);
			draw_tile(tiles[1], 8, (4) * 8);
			draw_tile(tiles[2], 16, (4) * 8);
			draw_tile(tiles[3], 24, (4) * 8);

			draw_tile(tiles[0], 0, (5) * 8);
			draw_tile(tiles[1], 8, (5) * 8);
			draw_tile(tiles[2], 16, (5) * 8);
			draw_tile(tiles[3], 24, (5) * 8);

			tid = 16;
			for (int xx = 0; xx < 4; xx++)
			{
				for (int yy = 0; yy < 4; yy++)
				{
					draw_tile(tiles[tid], (xx) * 8, (yy + 6) * 8);
					tid++;
				}
			}
		}
	}

	[Serializable]
	public class object_271 : Room_Object
	{
		public object_271(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x271, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x71].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			sort = Sorting.NonScalable;
			addTiles(64, pos); // ??
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 8; xx++)
			{
				for (int yy = 0; yy < 4; yy++)
				{
					draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
					draw_tile(tiles[tid + 32], (xx) * 8, (yy + 4) * 8);
					tid++;
				}
			}
		}
	}

	[Serializable]
	public class object_272 : Room_Object
	{
		public object_272(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x272, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x72].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(80, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int yy = 0; yy < 8; yy++)
			{
				for (int xx = 0; xx < 10; xx++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_273 : Room_Object
	{
		public object_273(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x273, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x73].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(1, pos);//??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			for (int yy = 0; yy < 4; yy++)
			{
				for (int xx = 0; xx < 4; xx++)
				{
					draw_tile(tiles[0], (xx) * 8, (yy) * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_274 : Room_Object
	{
		public object_274(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x274, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x74].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(64, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 8; xx++)
			{
				for (int yy = 0; yy < 4; yy++)
				{
					draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
					draw_tile(tiles[tid + 32], (xx) * 8, (yy + 4) * 8);
					tid++;
				}
			}
		}
	}


	[Serializable]
	public class object_275 : Room_Object
	{
		public object_275(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x275, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x75].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(4, pos); // ??
			sort = Sorting.NonScalable;
		}
		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 2; xx++)
			{
				for (int yy = 0; yy < 2; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_276 : Room_Object
	{
		public object_276(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x276, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x76].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(24, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 8; xx++)
			{
				for (int yy = 0; yy < 3; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_277 : Room_Object
	{
		public object_277(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x277, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x77].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(24, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 8; xx++)
			{
				for (int yy = 0; yy < 3; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_278 : Room_Object
	{
		public object_278(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x278, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x78].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(32, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			// Top triforce
			for (int xx = 0; xx < 4; xx++)
			{
				for (int yy = 0; yy < 4; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}

			// Bottom left
			for (int xx = 0; xx < 4; xx++)
			{
				for (int yy = 0; yy < 4; yy++)
				{
					draw_tile(tiles[tid], (xx - 2) * 8, (yy + 4) * 8);
					tid++;
				}
			}

			tid = 16;
			for (int xx = 0; xx < 4; xx++)
			{
				for (int yy = 0; yy < 4; yy++)
				{
					draw_tile(tiles[tid], (xx + 2) * 8, (yy + 4) * 8);
					tid++;
				}
			}
		}
	}

	[Serializable]
	public class object_279 : Room_Object
	{
		public object_279(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x279, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x79].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(12, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 4; xx++)
			{
				for (int yy = 0; yy < 3; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_27A : Room_Object
	{
		public object_27A(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x27A, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x7A].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(16, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 4; xx++)
			{
				for (int yy = 0; yy < 4; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_27B : Room_Object
	{
		public object_27B(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x27B, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x7B].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(8, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			for (int xx = 0; xx < 5; xx++)
			{
				for (int yy = 0; yy < 2; yy++)
				{
					draw_tile(tiles[0], (xx * 4) * 8, (yy * 4) * 8); draw_tile(tiles[1], ((xx * 4) + 1) * 8, (yy * 4) * 8);
					draw_tile(tiles[2], ((xx * 4) + 2) * 8, (yy * 4) * 8); draw_tile(tiles[3], ((xx * 4) + 3) * 8, (yy * 4) * 8);

					draw_tile(tiles[4], (xx * 4) * 8, ((yy * 4) + 1) * 8); draw_tile(tiles[5], ((xx * 4) + 1) * 8, ((yy * 4) + 1) * 8);
					draw_tile(tiles[6], ((xx * 4) + 2) * 8, ((yy * 4) + 1) * 8); draw_tile(tiles[7], ((xx * 4) + 3) * 8, ((yy * 4) + 1) * 8);

					draw_tile(tiles[0], (xx * 4) * 8, ((yy * 4) + 2) * 8); draw_tile(tiles[1], ((xx * 4) + 1) * 8, ((yy * 4) + 2) * 8);
					draw_tile(tiles[2], ((xx * 4) + 2) * 8, ((yy * 4) + 2) * 8); draw_tile(tiles[3], ((xx * 4) + 3) * 8, ((yy * 4) + 2) * 8);

					draw_tile(tiles[4], (xx * 4) * 8, ((yy * 4) + 3) * 8); draw_tile(tiles[5], ((xx * 4) + 1) * 8, ((yy * 4) + 3) * 8);
					draw_tile(tiles[6], ((xx * 4) + 2) * 8, ((yy * 4) + 3) * 8); draw_tile(tiles[7], ((xx * 4) + 3) * 8, ((yy * 4) + 3) * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_27C : Room_Object
	{
		public object_27C(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x27C, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x7C].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(4, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 2; xx++)
			{
				for (int yy = 0; yy < 2; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_27D : Room_Object
	{
		public object_27D(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x27D, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x7D].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(4, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 2; xx++)
			{
				for (int yy = 0; yy < 2; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_27E : Room_Object
	{
		public object_27E(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x27E, x, y, size, layer)
		{
			name = Data.DefaultEntities.ListOfSet2RoomObjects[0x7E].Name;
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype3TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(4, pos); // ??
			sort = Sorting.NonScalable;
		}

		public override void Draw()
		{
			base.Draw();

			int tid = 0;
			for (int xx = 0; xx < 2; xx++)
			{
				for (int yy = 0; yy < 2; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
		}
	}
}
