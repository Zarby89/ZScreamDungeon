using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{

	[Serializable]
	public class object_00 : Room_Object
	{
		public object_00(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x00, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x00];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(4, pos);
			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();
			if (this.size == 0)
			{
				this.size = 32;
			}

			for (int s = 0; s < size; s++)
			{
				draw_tile(tiles[0], ((s * 2)) * 8, 0); draw_tile(tiles[2], (1 + (s * 2)) * 8, 0);
				draw_tile(tiles[1], ((s * 2)) * 8, (1) * 8); draw_tile(tiles[3], (1 + (s * 2)) * 8, (1) * 8);
			}
		}
	}

	[Serializable]
	public class object_01 : Room_Object
	{
		public object_01(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x01, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x01];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(8, pos);
			sort = Sorting.Horizontal | Sorting.Wall;
		}

		public override void Draw()
		{
			base.Draw();
			if (this.size == 0)
			{
				this.size = 26;
			}

			for (int s = 0; s < size; s++)
			{
				draw_tile(tiles[0], ((s * 2)) * 8, (0) * 8); draw_tile(tiles[4], (1 + (s * 2)) * 8, (0) * 8);
				draw_tile(tiles[1], ((s * 2)) * 8, (1) * 8); draw_tile(tiles[5], (1 + (s * 2)) * 8, (1) * 8);
				draw_tile(tiles[2], ((s * 2)) * 8, (2) * 8); draw_tile(tiles[6], (1 + (s * 2)) * 8, (2) * 8);
				draw_tile(tiles[3], ((s * 2)) * 8, (3) * 8); draw_tile(tiles[7], (1 + (s * 2)) * 8, (3) * 8);
			}
		}
	}

	[Serializable]
	public class object_02 : Room_Object
	{
		public object_02(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x02, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x02];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(8, pos);
			sort = Sorting.Horizontal | Sorting.Wall;
		}

		public override void Draw()
		{
			base.Draw();
			if (this.size == 0)
			{
				this.size = 26;
			}

			for (int s = 0; s < size; s++)
			{
				draw_tile(tiles[0], ((s * 2)) * 8, (0) * 8); draw_tile(tiles[4], (1 + (s * 2)) * 8, (0) * 8);
				draw_tile(tiles[1], ((s * 2)) * 8, (1) * 8); draw_tile(tiles[5], (1 + (s * 2)) * 8, (1) * 8);
				draw_tile(tiles[2], ((s * 2)) * 8, (2) * 8); draw_tile(tiles[6], (1 + (s * 2)) * 8, (2) * 8);
				draw_tile(tiles[3], ((s * 2)) * 8, (3) * 8); draw_tile(tiles[7], (1 + (s * 2)) * 8, (3) * 8);
			}
		}
	}

	[Serializable]
	public class object_03 : Room_Object
	{
		public object_03(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x03, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x03];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(8, pos);
			allBgs = true;
			sort = Sorting.Horizontal | Sorting.Wall;
		}

		public override void Draw()
		{
			base.Draw();
			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[0], ((s * 2)) * 8, (0) * 8); draw_tile(tiles[4], (1 + (s * 2)) * 8, (0) * 8);
				draw_tile(tiles[1], ((s * 2)) * 8, (1) * 8); draw_tile(tiles[5], (1 + (s * 2)) * 8, (1) * 8);
				draw_tile(tiles[2], ((s * 2)) * 8, (2) * 8); draw_tile(tiles[6], (1 + (s * 2)) * 8, (2) * 8);
				draw_tile(tiles[3], ((s * 2)) * 8, (3) * 8); draw_tile(tiles[7], (1 + (s * 2)) * 8, (3) * 8);
			}
		}
	}

	[Serializable]
	public class object_04 : Room_Object
	{
		public object_04(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x04, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x04];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(8, pos);
			allBgs = true;
			sort = Sorting.Horizontal | Sorting.Wall;
		}

		public override void Draw()
		{
			base.Draw();
			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[0], ((s * 2)) * 8, (0) * 8); draw_tile(tiles[4], (1 + (s * 2)) * 8, (0) * 8);
				draw_tile(tiles[1], ((s * 2)) * 8, (1) * 8); draw_tile(tiles[5], (1 + (s * 2)) * 8, (1) * 8);
				draw_tile(tiles[2], ((s * 2)) * 8, (2) * 8); draw_tile(tiles[6], (1 + (s * 2)) * 8, (2) * 8);
				draw_tile(tiles[3], ((s * 2)) * 8, (3) * 8); draw_tile(tiles[7], (1 + (s * 2)) * 8, (3) * 8);
			}
		}
	}

	[Serializable]
	public class object_05 : Room_Object
	{
		public object_05(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x05, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x05];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(8, pos);
			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();
			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[0], ((s * 6)) * 8, (0) * 8); draw_tile(tiles[4], (1 + (s * 6)) * 8, (0) * 8);
				draw_tile(tiles[1], ((s * 6)) * 8, (1) * 8); draw_tile(tiles[5], (1 + (s * 6)) * 8, (1) * 8);
				draw_tile(tiles[2], ((s * 6)) * 8, (2) * 8); draw_tile(tiles[6], (1 + (s * 6)) * 8, (2) * 8);
				draw_tile(tiles[3], ((s * 6)) * 8, (3) * 8); draw_tile(tiles[7], (1 + (s * 6)) * 8, (3) * 8);
			}
		}
	}

	[Serializable]
	public class object_06 : Room_Object
	{
		public object_06(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x06, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x06];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(8, pos);
			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();
			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[0], ((s * 6)) * 8, (0) * 8); draw_tile(tiles[4], (1 + (s * 6)) * 8, (0) * 8);
				draw_tile(tiles[1], ((s * 6)) * 8, (1) * 8); draw_tile(tiles[5], (1 + (s * 6)) * 8, (1) * 8);
				draw_tile(tiles[2], ((s * 6)) * 8, (2) * 8); draw_tile(tiles[6], (1 + (s * 6)) * 8, (2) * 8);
				draw_tile(tiles[3], ((s * 6)) * 8, (3) * 8); draw_tile(tiles[7], (1 + (s * 6)) * 8, (3) * 8);
			}
		}
	}

	[Serializable]
	public class object_07 : Room_Object
	{
		public object_07(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x07, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x07];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(4, pos);
			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();
			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[0], ((s * 2)) * 8, (0) * 8); draw_tile(tiles[2], (1 + (s * 2)) * 8, (0) * 8);
				draw_tile(tiles[1], ((s * 2)) * 8, (1) * 8); draw_tile(tiles[3], (1 + (s * 2)) * 8, (1) * 8);
			}
		}
	}

	[Serializable]
	public class object_08 : Room_Object
	{
		public object_08(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x08, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x08];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(4, pos);
			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();
			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[0], ((s * 2)) * 8, (0) * 8); draw_tile(tiles[2], (1 + (s * 2)) * 8, (0) * 8);
				draw_tile(tiles[1], ((s * 2)) * 8, (1) * 8); draw_tile(tiles[3], (1 + (s * 2)) * 8, (1) * 8);
			}
		}
	}

	[Serializable]
	public class object_09 : Room_Object
	{
		public object_09(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x09, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x09];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(5, pos);
			sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
		}

		public override void Draw()
		{
			base.Draw();
			draw_diagonal_up();
		}
	}

	[Serializable]
	public class object_0A : Room_Object
	{
		public object_0A(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x0A, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x0A];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(5, pos);
			sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
		}

		public override void Draw()
		{
			base.Draw();
			draw_diagonal_down();
		}
	}

	[Serializable]
	public class object_0B : Room_Object
	{
		public object_0B(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x0B, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x0B];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(5, pos);
			sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
		}

		public override void Draw()
		{
			base.Draw();
			draw_diagonal_down();
		}
	}

	[Serializable]
	public class object_0C : Room_Object
	{
		public object_0C(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x0C, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x0C];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(5, pos);
			sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
		}

		public override void Draw()
		{
			base.Draw();
			draw_diagonal_up();
		}
	}

	[Serializable]
	public class object_0D : Room_Object
	{
		public object_0D(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x0D, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x0D];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(5, pos);
			sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
		}

		public override void Draw()
		{
			base.Draw();
			draw_diagonal_up();
		}
	}

	[Serializable]
	public class object_0E : Room_Object
	{
		public object_0E(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x0E, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x0E];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(5, pos);
			sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
		}

		public override void Draw()
		{
			base.Draw();
			draw_diagonal_down();
		}
	}

	[Serializable]
	public class object_0F : Room_Object
	{
		public object_0F(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x0F, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x0F];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(5, pos);
			sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
		}

		public override void Draw()
		{
			base.Draw();
			draw_diagonal_down();
		}
	}

	[Serializable]
	public class object_10 : Room_Object
	{
		public object_10(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x10, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x10];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(5, pos);
			sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
		}

		public override void Draw()
		{
			base.Draw();
			draw_diagonal_up();
		}
	}

	[Serializable]
	public class object_11 : Room_Object
	{
		public object_11(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x11, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x11];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(5, pos);
			sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
		}

		public override void Draw()
		{
			base.Draw();
			draw_diagonal_up();
		}
	}

	[Serializable]
	public class object_12 : Room_Object
	{
		public object_12(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x12, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x12];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(5, pos);
			sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
		}

		public override void Draw()
		{
			base.Draw();
			draw_diagonal_down();
		}
	}

	[Serializable]
	public class object_13 : Room_Object
	{
		public object_13(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x13, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x13];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(5, pos);
			sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
		}

		public override void Draw()
		{
			base.Draw();
			draw_diagonal_down();
		}
	}

	[Serializable]
	public class object_14 : Room_Object
	{
		public object_14(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x14, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x14];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(5, pos);
			sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
		}

		public override void Draw()
		{
			base.Draw();
			draw_diagonal_up();
		}
	}

	[Serializable]
	public class object_15 : Room_Object
	{
		public object_15(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x15, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x15];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(5, pos);
			sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
			allBgs = true;
		}

		public override void Draw()
		{
			base.Draw();
			draw_diagonal_up();
		}
	}

	[Serializable]
	public class object_16 : Room_Object
	{
		public object_16(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x16, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x16];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(5, pos);
			sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
			allBgs = true;
		}

		public override void Draw()
		{
			base.Draw();
			draw_diagonal_down();
		}
	}

	[Serializable]
	public class object_17 : Room_Object
	{
		public object_17(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x17, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x17];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(5, pos);
			sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
			allBgs = true;
		}

		public override void Draw()
		{
			base.Draw();
			draw_diagonal_down();
		}
	}

	[Serializable]
	public class object_18 : Room_Object
	{
		public object_18(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x18, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x18];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(5, pos);
			sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
			allBgs = true;
		}

		public override void Draw()
		{
			base.Draw();
			draw_diagonal_up();
		}
	}

	[Serializable]
	public class object_19 : Room_Object
	{
		public object_19(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x19, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x19];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(5, pos);
			sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
			allBgs = true;
		}

		public override void Draw()
		{
			base.Draw();
			draw_diagonal_up();
		}
	}

	[Serializable]
	public class object_1A : Room_Object
	{
		public object_1A(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x1A, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x1A];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(5, pos);
			sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
			allBgs = true;
		}

		public override void Draw()
		{
			base.Draw();
			draw_diagonal_down();
		}
	}

	[Serializable]
	public class object_1B : Room_Object
	{
		public object_1B(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x1B, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x1B];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(5, pos);
			sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
			allBgs = true;
		}

		public override void Draw()
		{
			base.Draw();
			draw_diagonal_down();
		}
	}

	[Serializable]
	public class object_1C : Room_Object
	{
		public object_1C(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x1C, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x1C];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(5, pos);
			sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
			allBgs = true;
		}

		public override void Draw()
		{
			base.Draw();
			draw_diagonal_up();
		}
	}

	[Serializable]
	public class object_1D : Room_Object
	{
		public object_1D(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x1D, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x1D];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(5, pos);
			sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
			allBgs = true;
		}

		public override void Draw()
		{
			base.Draw();
			draw_diagonal_up();
		}
	}

	[Serializable]
	public class object_1E : Room_Object
	{
		public object_1E(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x1E, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x1E];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(5, pos);
			sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
			allBgs = true;
		}

		public override void Draw()
		{
			base.Draw();
			draw_diagonal_down();
		}
	}

	[Serializable]
	public class object_1F : Room_Object
	{
		public object_1F(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x1F, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x1F];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(5, pos);
			sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
			allBgs = true;
		}

		public override void Draw()
		{
			base.Draw();
			draw_diagonal_down();
		}
	}

	[Serializable]
	public class object_20 : Room_Object
	{
		public object_20(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x20, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x20];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(5, pos);
			sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
			allBgs = true;
		}

		public override void Draw()
		{
			base.Draw();
			draw_diagonal_up();
		}
	}


	[Serializable]
	public class object_21 : Room_Object
	{
		public object_21(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x21, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x21];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(9, pos);
			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[3], (1 + (s * 2)) * 8, (0) * 8); draw_tile(tiles[3], (2 + (s * 2)) * 8, (0) * 8);
				draw_tile(tiles[4], (1 + (s * 2)) * 8, (1) * 8); draw_tile(tiles[4], (2 + (s * 2)) * 8, (1) * 8);
				draw_tile(tiles[5], (1 + (s * 2)) * 8, (2) * 8); draw_tile(tiles[5], (2 + (s * 2)) * 8, (2) * 8);
			}

			draw_tile(tiles[0], 0, (0) * 8);
			draw_tile(tiles[1], 0, (1) * 8);
			draw_tile(tiles[2], 0, (2) * 8);

			draw_tile(tiles[6], ((size * 2) + 3) * 8, (0) * 8);
			draw_tile(tiles[7], ((size * 2) + 3) * 8, (1) * 8);
			draw_tile(tiles[8], ((size * 2) + 3) * 8, (2) * 8);
		}
	}


	[Serializable]
	public class object_22 : Room_Object
	{
		public object_22(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x22, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x22];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(3, pos);
			sort = Sorting.Horizontal | Sorting.Dungeons;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 2; s++)
			{
				draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
			}

			draw_tile(tiles[0], (0) * 8, (0) * 8, tiles[1].getshortileinfo());
			draw_tile(tiles[2], ((size + 2) + 1) * 8, (0) * 8);
		}
	}

	[Serializable]
	public class object_23 : Room_Object
	{
		public object_23(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x23, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x23];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(3, pos);
			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
			}

			draw_tile(tiles[0], 0, (0) * 8, tiles[1].getshortileinfo());
			draw_tile(tiles[2], ((size + 1) + 1) * 8, (0) * 8);
		}
	}

	[Serializable]
	public class object_24 : Room_Object
	{
		public object_24(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x24, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x24];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(3, pos);
			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
			}

			draw_tile(tiles[0], (0) * 8, (0) * 8, tiles[1].getshortileinfo());
			draw_tile(tiles[2], ((size + 1) + 1) * 8, (0) * 8);
		}
	}

	[Serializable]
	public class object_25 : Room_Object
	{
		public object_25(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x25, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x25];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(3, pos);
			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
			}

			draw_tile(tiles[0], (0) * 8, (0) * 8, tiles[1].getshortileinfo());
			draw_tile(tiles[2], ((size + 1) + 1) * 8, (0) * 8);
		}
	}

	[Serializable]
	public class object_26 : Room_Object
	{
		public object_26(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x26, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x26];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(3, pos);
			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
			}

			draw_tile(tiles[0], (0) * 8, (0) * 8, tiles[1].getshortileinfo());
			draw_tile(tiles[2], ((size + 1) + 1) * 8, (0) * 8);
		}
	}

	[Serializable]
	public class object_27 : Room_Object
	{
		public object_27(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x27, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x27];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(3, pos);
			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
			}

			draw_tile(tiles[0], (0) * 8, (0) * 8, tiles[1].getshortileinfo());
			draw_tile(tiles[2], ((size + 1) + 1) * 8, (0) * 8);
		}
	}

	[Serializable]
	public class object_28 : Room_Object
	{
		public object_28(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x28, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x28];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(3, pos);
			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
			}

			draw_tile(tiles[0], (0) * 8, (0) * 8, tiles[1].getshortileinfo());
			draw_tile(tiles[2], ((size + 1) + 1) * 8, (0) * 8);

		}
	}

	[Serializable]
	public class object_29 : Room_Object
	{
		public object_29(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x29, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x29];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(3, pos);
			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
			}

			draw_tile(tiles[0], (0) * 8, (0) * 8, tiles[1].getshortileinfo());
			draw_tile(tiles[2], ((size + 1) + 1) * 8, (0) * 8);

		}
	}

	[Serializable]
	public class object_2A : Room_Object
	{
		public object_2A(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x2A, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x2A];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(3, pos);
			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
			}

			draw_tile(tiles[0], (0) * 8, (0) * 8, tiles[1].getshortileinfo());
			draw_tile(tiles[2], ((size + 1) + 1) * 8, (0) * 8);
		}
	}

	[Serializable]
	public class object_2B : Room_Object
	{
		public object_2B(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x2B, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x2B];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(3, pos);
			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
			}

			draw_tile(tiles[0], (0) * 8, (0) * 8, tiles[1].getshortileinfo());
			draw_tile(tiles[2], ((size + 1) + 1) * 8, (0) * 8);
		}
	}

	[Serializable]
	public class object_2C : Room_Object
	{
		public object_2C(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x2C, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x2C];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(3, pos);

			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
			}

			draw_tile(tiles[0], (0) * 8, (0) * 8, tiles[1].getshortileinfo());
			draw_tile(tiles[2], ((size + 1) + 1) * 8, (0) * 8);
		}
	}

	[Serializable]
	public class object_2D : Room_Object
	{
		public object_2D(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x2D, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x2D];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(3, pos);

			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
			}

			draw_tile(tiles[0], (0) * 8, (0) * 8, tiles[1].getshortileinfo());
			draw_tile(tiles[2], ((size + 1) + 1) * 8, (0) * 8);
		}
	}

	[Serializable]
	public class object_2E : Room_Object
	{
		public object_2E(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x2E, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x2E];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(3, pos);

			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
			}

			draw_tile(tiles[0], (0) * 8, (0) * 8, tiles[1].getshortileinfo());
			draw_tile(tiles[2], ((size + 1) + 1) * 8, (0) * 8);
		}
	}

	[Serializable]
	public class object_2F : Room_Object
	{
		public object_2F(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x2F, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x2F];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(6, pos);
			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 14; s++)
			{
				draw_tile(tiles[3], ((s * 1)) * 8, (0) * 8);
				draw_tile(tiles[0], ((s * 1)) * 8, (1) * 8);
			}

			draw_tile(tiles[1], (0) * 8, (0) * 8);
			draw_tile(tiles[2], (1) * 8, (0) * 8);

			draw_tile(tiles[4], (size + 12) * 8, (0) * 8);
			draw_tile(tiles[5], (size + 12 + 1) * 8, (0) * 8);
		}
	}

	[Serializable]
	public class object_30 : Room_Object
	{
		public object_30(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x30, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x30];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(6, pos);
			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 14; s++)
			{
				draw_tile(tiles[3], ((s * 1)) * 8, (1) * 8);
				draw_tile(tiles[0], ((s * 1)) * 8, (0) * 8);
			}

			draw_tile(tiles[1], (0) * 8, (1) * 8);
			draw_tile(tiles[2], (1) * 8, (1) * 8);

			draw_tile(tiles[4], (size + 12) * 8, (1) * 8);
			draw_tile(tiles[5], (size + 12 + 1) * 8, (1) * 8);
		}
	}

	[Serializable]
	public class object_31 : Room_Object
	{
		public object_31(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x31, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x31];
		}

		public override void Draw()
		{
			base.Draw();
			draw_tile(new Tile(0, 0, false, false, false), 0, 0);
			draw_tile(new Tile(0, 0, false, false, false), 8, 0);
			draw_tile(new Tile(0, 0, false, false, false), 8, 8);
			draw_tile(new Tile(0, 0, false, false, false), 0, 8);
		}
	}

	[Serializable]
	public class object_32 : Room_Object
	{
		public object_32(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x32, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x32];
		}

		public override void Draw()
		{
			base.Draw();
			draw_tile(new Tile(0, 0, false, false, false), 0, 0);
			draw_tile(new Tile(0, 0, false, false, false), 8, 0);
			draw_tile(new Tile(0, 0, false, false, false), 8, 8);
			draw_tile(new Tile(0, 0, false, false, false), 0, 8);
		}
	}

	[Serializable]
	public class object_33 : Room_Object
	{
		public object_33(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x33, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x33];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(16, pos);
			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				int tid = 0;
				for (int xx = 0; xx < 4; xx++)
				{
					for (int yy = 0; yy < 4; yy++)
					{
						draw_tile(tiles[tid], (xx + (s * 4)) * 8, (yy) * 8);
						tid++;
					}
				}
			}
		}
	}

	[Serializable]
	public class object_34 : Room_Object

	{
		public object_34(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x34, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x34];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(1, pos);
			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 4; s++)
			{
				draw_tile(tiles[0], ((s * 1)) * 8, (0) * 8);
			}
		}
	}

	[Serializable]
	public class object_35 : Room_Object
	{
		public object_35(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x35, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x35];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(1, pos);
		}

		public override void Draw()
		{
			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[0], ((s * 1)) * 8, (0) * 8);
			}

			base.Draw();
		}
	}

	[Serializable]
	public class object_36 : Room_Object
	{
		public object_36(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x36, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x36];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(16, pos);
			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				int tid = 0;
				for (int xx = 0; xx < 4; xx++)
				{
					for (int yy = 0; yy < 4; yy++)
					{
						draw_tile(tiles[tid], (xx + (s * 6)) * 8, (yy) * 8);
						tid++;
					}
				}
			}
		}
	}

	[Serializable]
	public class object_37 : Room_Object
	{
		public object_37(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x37, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x37];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(16, pos);
			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				int tid = 0;
				for (int xx = 0; xx < 4; xx++)
				{
					for (int yy = 0; yy < 4; yy++)
					{
						draw_tile(tiles[tid], (xx + (s * 6)) * 8, (yy) * 8);
						tid++;
					}
				}
			}
		}
	}


	[Serializable]
	public class object_38 : Room_Object
	{
		public object_38(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x38, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x38];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(6, pos);
			sort = Sorting.Horizontal | Sorting.Dungeons;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[0], ((s * 4)) * 8, (0) * 8); draw_tile(tiles[3], (1 + (s * 4)) * 8, (0) * 8);
				draw_tile(tiles[1], ((s * 4)) * 8, (1) * 8); draw_tile(tiles[4], (1 + (s * 4)) * 8, (1) * 8);
				draw_tile(tiles[2], ((s * 4)) * 8, (2) * 8); draw_tile(tiles[5], (1 + (s * 4)) * 8, (2) * 8);
			}
		}
	}

	[Serializable]
	public class object_39 : Room_Object
	{
		public object_39(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x39, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x39];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(8, pos);
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[0], ((s * 6)) * 8, (0) * 8); draw_tile(tiles[4], (1 + (s * 6)) * 8, (0) * 8);
				draw_tile(tiles[1], ((s * 6)) * 8, (1) * 8); draw_tile(tiles[5], (1 + (s * 6)) * 8, (1) * 8);
				draw_tile(tiles[2], ((s * 6)) * 8, (2) * 8); draw_tile(tiles[6], (1 + (s * 6)) * 8, (2) * 8);
				draw_tile(tiles[3], ((s * 6)) * 8, (3) * 8); draw_tile(tiles[7], (1 + (s * 6)) * 8, (3) * 8);
			}

			sort = Sorting.Horizontal;
		}
	}

	[Serializable]
	public class object_3A : Room_Object
	{
		public object_3A(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x3A, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x3A];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(12, pos);
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				int tid = 0;
				for (int xx = 0; xx < 4; xx++)
				{
					for (int yy = 0; yy < 3; yy++)
					{
						draw_tile(tiles[tid], (xx + (s * 8)) * 8, (yy) * 8);
						tid++;
					}
				}
			}

			sort = Sorting.Horizontal;
		}
	}

	[Serializable]
	public class object_3B : Room_Object
	{
		public object_3B(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x3B, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x3B];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(12, pos);
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				int tid = 0;
				for (int xx = 0; xx < 4; xx++)
				{
					for (int yy = 0; yy < 3; yy++)
					{
						draw_tile(tiles[tid], (xx + (s * 8)) * 8, (yy) * 8);
						tid++;
					}
				}
			}

			sort = Sorting.Horizontal;
		}
	}

	[Serializable]
	public class object_3C : Room_Object
	{
		public object_3C(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x3C, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x3C];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(4, pos);
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[0], ((s * 4)) * 8, (0) * 8); draw_tile(tiles[2], (1 + (s * 4)) * 8, (0) * 8);
				draw_tile(tiles[1], ((s * 4)) * 8, (1) * 8); draw_tile(tiles[3], (1 + (s * 4)) * 8, (1) * 8);

				draw_tile(tiles[0], ((s * 4)) * 8, (6) * 8); draw_tile(tiles[2], (1 + (s * 4)) * 8, (6) * 8);
				draw_tile(tiles[1], ((s * 4)) * 8, (7) * 8); draw_tile(tiles[3], (1 + (s * 4)) * 8, (7) * 8);
			}

			sort = Sorting.Horizontal;
		}
	}

	[Serializable]
	public class object_3D : Room_Object
	{
		public object_3D(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x3D, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x3D];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(8, pos);
			sort = Sorting.Horizontal | Sorting.Dungeons;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[0], ((s * 6)) * 8, (0) * 8); draw_tile(tiles[4], (1 + (s * 6)) * 8, (0) * 8);
				draw_tile(tiles[1], ((s * 6)) * 8, (1) * 8); draw_tile(tiles[5], (1 + (s * 6)) * 8, (1) * 8);
				draw_tile(tiles[2], ((s * 6)) * 8, (2) * 8); draw_tile(tiles[6], (1 + (s * 6)) * 8, (2) * 8);
				draw_tile(tiles[3], ((s * 6)) * 8, (3) * 8); draw_tile(tiles[7], (1 + (s * 6)) * 8, (3) * 8);
			}
		}
	}


	[Serializable]
	public class object_3E : Room_Object
	{
		public object_3E(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x3E, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x3E];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(4, pos);
			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[0], ((s * 14)) * 8, (0) * 8); draw_tile(tiles[2], (1 + (s * 14)) * 8, (0) * 8);
				draw_tile(tiles[1], ((s * 14)) * 8, (1) * 8); draw_tile(tiles[3], (1 + (s * 14)) * 8, (1) * 8);
			}
		}
	}

	[Serializable]
	public class object_3F : Room_Object
	{
		public object_3F(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x3F, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x3F];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(3, pos);
			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
			}

			draw_tile(tiles[0], (0) * 8, (0) * 8, tiles[1].getshortileinfo());
			draw_tile(tiles[2], ((size + 1) + 1) * 8, (0) * 8);
		}
	}

	[Serializable]
	public class object_40 : Room_Object
	{
		public object_40(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x40, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x40];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(3, pos);
			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
			}

			draw_tile(tiles[0], (0) * 8, (0) * 8, tiles[1].getshortileinfo());
			draw_tile(tiles[2], ((size + 1) + 1) * 8, (0) * 8);
		}
	}

	[Serializable]
	public class object_41 : Room_Object
	{
		public object_41(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x41, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x41];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(3, pos);
			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
			}

			draw_tile(tiles[0], (0) * 8, (0) * 8, tiles[1].getshortileinfo());
			draw_tile(tiles[2], ((size + 1) + 1) * 8, (0) * 8);
		}
	}

	[Serializable]
	public class object_42 : Room_Object
	{
		public object_42(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x42, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x42];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(3, pos);
			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
			}

			draw_tile(tiles[0], (0) * 8, (0) * 8, tiles[1].getshortileinfo());
			draw_tile(tiles[2], ((size + 1) + 1) * 8, (0) * 8);
		}
	}

	[Serializable]
	public class object_43 : Room_Object
	{
		public object_43(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x43, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x43];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(3, pos);
			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
			}

			draw_tile(tiles[0], (0) * 8, (0) * 8, tiles[1].getshortileinfo());
			draw_tile(tiles[2], ((size + 1) + 1) * 8, (0) * 8);
		}
	}

	[Serializable]
	public class object_44 : Room_Object
	{
		public object_44(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x44, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x44];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(3, pos);
			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
			}

			draw_tile(tiles[0], (0) * 8, (0) * 8, tiles[1].getshortileinfo());
			draw_tile(tiles[2], ((size + 1) + 1) * 8, (0) * 8);
		}
	}

	[Serializable]
	public class object_45 : Room_Object
	{
		public object_45(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x45, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x45];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(3, pos);
			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
			}

			draw_tile(tiles[0], (0) * 8, (0) * 8, tiles[1].getshortileinfo());
			draw_tile(tiles[2], ((size + 1) + 1) * 8, (0) * 8);
		}
	}


	[Serializable]
	public class object_46 : Room_Object
	{
		public object_46(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x46, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x46];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(3, pos);
			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
			}

			draw_tile(tiles[0], (0) * 8, (0) * 8, tiles[1].getshortileinfo());
			draw_tile(tiles[2], ((size + 1) + 1) * 8, (0) * 8);
		}
	}

	[Serializable]
	public class object_47 : Room_Object
	{
		public object_47(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x47, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x47];
			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();
			// TODO:
		}
	}

	[Serializable]
	public class object_48 : Room_Object
	{
		public object_48(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x48, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x48];
			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();
			// TODO:
		}
	}

	[Serializable]
	public class object_49 : Room_Object
	{
		public object_49(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x49, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x49];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(8, pos);
		}

		public override void Draw()
		{
			base.Draw();
			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[0], (0 + (s * 4)) * 8, (0) * 8); draw_tile(tiles[2], (1 + (s * 4)) * 8, (0) * 8); draw_tile(tiles[4], (2 + (s * 4)) * 8, (0) * 8); draw_tile(tiles[6], (3 + (s * 4)) * 8, (0) * 8);
				draw_tile(tiles[1], (0 + (s * 4)) * 8, (1) * 8); draw_tile(tiles[3], (1 + (s * 4)) * 8, (1) * 8); draw_tile(tiles[5], (2 + (s * 4)) * 8, (1) * 8); draw_tile(tiles[7], (3 + (s * 4)) * 8, (1) * 8);
			}
		}
	}

	[Serializable]
	public class object_4A : Room_Object

	{
		public object_4A(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x4A, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x4A];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(8, pos);
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[0], (0 + (s * 4)) * 8, (0) * 8); draw_tile(tiles[2], (1 + (s * 4)) * 8, (0) * 8); draw_tile(tiles[4], (2 + (s * 4)) * 8, (0) * 8); draw_tile(tiles[6], (3 + (s * 4)) * 8, (0) * 8);
				draw_tile(tiles[1], (0 + (s * 4)) * 8, (1) * 8); draw_tile(tiles[3], (1 + (s * 4)) * 8, (1) * 8); draw_tile(tiles[5], (2 + (s * 4)) * 8, (1) * 8); draw_tile(tiles[7], (3 + (s * 4)) * 8, (1) * 8);
			}
		}
	}

	[Serializable]
	public class object_4B : Room_Object
	{
		public object_4B(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x4B, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x4B];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(4, pos);
			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[0], ((s * 14)) * 8, (0) * 8); draw_tile(tiles[2], (1 + (s * 14)) * 8, (0) * 8);
				draw_tile(tiles[1], ((s * 14)) * 8, (1) * 8); draw_tile(tiles[3], (1 + (s * 14)) * 8, (1) * 8);
			}
		}
	}

	[Serializable]
	public class object_4C : Room_Object
	{
		public object_4C(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x4C, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x4C];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(9, pos);
			sort = Sorting.Horizontal;
		}
		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[3], (1 + (s * 2)) * 8, (0) * 8); draw_tile(tiles[3], (2 + (s * 2)) * 8, (0) * 8);
				draw_tile(tiles[4], (1 + (s * 2)) * 8, (1) * 8); draw_tile(tiles[4], (2 + (s * 2)) * 8, (1) * 8);
				draw_tile(tiles[5], (1 + (s * 2)) * 8, (2) * 8); draw_tile(tiles[5], (2 + (s * 2)) * 8, (2) * 8);
			}

			draw_tile(tiles[0], (0) * 8, (0) * 8);
			draw_tile(tiles[1], (0) * 8, (1) * 8);
			draw_tile(tiles[2], (0) * 8, (2) * 8);

			draw_tile(tiles[6], ((size * 2) + 3) * 8, (0) * 8);
			draw_tile(tiles[7], ((size * 2) + 3) * 8, (1) * 8);
			draw_tile(tiles[8], ((size * 2) + 3) * 8, (2) * 8);
		}
	}

	[Serializable]
	public class object_4D : Room_Object
	{
		public object_4D(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x4D, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x4D];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(16, pos);
			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[4], (1 + (s * 2)) * 8, (0) * 8); draw_tile(tiles[8], (2 + (s * 2)) * 8, (0) * 8);
				draw_tile(tiles[5], (1 + (s * 2)) * 8, (1) * 8); draw_tile(tiles[9], (2 + (s * 2)) * 8, (1) * 8);
				draw_tile(tiles[6], (1 + (s * 2)) * 8, (2) * 8); draw_tile(tiles[10], (2 + (s * 2)) * 8, (2) * 8);
				draw_tile(tiles[7], (1 + (s * 2)) * 8, (3) * 8); draw_tile(tiles[11], (2 + (s * 2)) * 8, (3) * 8);
			}

			draw_tile(tiles[0], (0) * 8, (0) * 8);
			draw_tile(tiles[1], (0) * 8, (1) * 8);
			draw_tile(tiles[2], (0) * 8, (2) * 8);
			draw_tile(tiles[3], (0) * 8, (3) * 8);

			draw_tile(tiles[12], ((size * 2) + 3) * 8, (0) * 8);
			draw_tile(tiles[13], ((size * 2) + 3) * 8, (1) * 8);
			draw_tile(tiles[14], ((size * 2) + 3) * 8, (2) * 8);
			draw_tile(tiles[15], ((size * 2) + 3) * 8, (3) * 8);
		}
	}

	[Serializable]
	public class object_4E : Room_Object
	{
		public object_4E(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x4E, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x4E];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(16, pos);
			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[4], (1 + (s * 2)) * 8, (0) * 8); draw_tile(tiles[8], (2 + (s * 2)) * 8, (0) * 8);
				draw_tile(tiles[5], (1 + (s * 2)) * 8, (1) * 8); draw_tile(tiles[9], (2 + (s * 2)) * 8, (1) * 8);
				draw_tile(tiles[6], (1 + (s * 2)) * 8, (2) * 8); draw_tile(tiles[10], (2 + (s * 2)) * 8, (2) * 8);
				draw_tile(tiles[7], (1 + (s * 2)) * 8, (3) * 8); draw_tile(tiles[11], (2 + (s * 2)) * 8, (3) * 8);
			}

			draw_tile(tiles[0], (0) * 8, (0) * 8);
			draw_tile(tiles[1], (0) * 8, (1) * 8);
			draw_tile(tiles[2], (0) * 8, (2) * 8);
			draw_tile(tiles[3], (0) * 8, (3) * 8);

			draw_tile(tiles[12], ((size * 2) + 3) * 8, (0) * 8);
			draw_tile(tiles[13], ((size * 2) + 3) * 8, (1) * 8);
			draw_tile(tiles[14], ((size * 2) + 3) * 8, (2) * 8);
			draw_tile(tiles[15], ((size * 2) + 3) * 8, (3) * 8);
		}
	}

	[Serializable]
	public class object_4F : Room_Object
	{
		public object_4F(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x4F, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x4F];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(16, pos);
			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[4], (1 + (s * 2)) * 8, (0) * 8); draw_tile(tiles[8], (2 + (s * 2)) * 8, (0) * 8);
				draw_tile(tiles[5], (1 + (s * 2)) * 8, (1) * 8); draw_tile(tiles[9], (2 + (s * 2)) * 8, (1) * 8);
				draw_tile(tiles[6], (1 + (s * 2)) * 8, (2) * 8); draw_tile(tiles[10], (2 + (s * 2)) * 8, (2) * 8);
				draw_tile(tiles[7], (1 + (s * 2)) * 8, (3) * 8); draw_tile(tiles[11], (2 + (s * 2)) * 8, (3) * 8);
			}

			draw_tile(tiles[0], (0) * 8, (0) * 8);
			draw_tile(tiles[1], (0) * 8, (1) * 8);
			draw_tile(tiles[2], (0) * 8, (2) * 8);
			draw_tile(tiles[3], (0) * 8, (3) * 8);

			draw_tile(tiles[12], ((size * 2) + 3) * 8, (0) * 8);
			draw_tile(tiles[13], ((size * 2) + 3) * 8, (1) * 8);
			draw_tile(tiles[14], ((size * 2) + 3) * 8, (2) * 8);
			draw_tile(tiles[15], ((size * 2) + 3) * 8, (3) * 8);
		}
	}

	[Serializable]
	public class object_50 : Room_Object
	{
		public object_50(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x50, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x50];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(1, pos);
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 2; s++)
			{
				draw_tile(tiles[0], ((s * 1)) * 8, (0) * 8);
			}
		}
	}

	[Serializable]
	public class object_51 : Room_Object
	{
		public object_51(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x51, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x51];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(18, pos);
			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size; s++)
			{
				draw_tile(tiles[6], (2 + (s * 2)) * 8, (0) * 8); draw_tile(tiles[9], (3 + (s * 2)) * 8, (0) * 8);
				draw_tile(tiles[7], (2 + (s * 2)) * 8, (1) * 8); draw_tile(tiles[10], (3 + (s * 2)) * 8, (1) * 8);
				draw_tile(tiles[8], (2 + (s * 2)) * 8, (2) * 8); draw_tile(tiles[11], (3 + (s * 2)) * 8, (2) * 8);
			}

			draw_tile(tiles[0], (0) * 8, (0) * 8); draw_tile(tiles[3], (1) * 8, (0) * 8);
			draw_tile(tiles[1], (0) * 8, (1) * 8); draw_tile(tiles[4], (1) * 8, (1) * 8);
			draw_tile(tiles[2], (0) * 8, (2) * 8); draw_tile(tiles[5], (1) * 8, (2) * 8);

			draw_tile(tiles[12], ((size * 2) + 2) * 8, (0) * 8); draw_tile(tiles[15], ((size * 2) + 3) * 8, (0) * 8);
			draw_tile(tiles[13], ((size * 2) + 2) * 8, (1) * 8); draw_tile(tiles[16], ((size * 2) + 3) * 8, (1) * 8);
			draw_tile(tiles[14], ((size * 2) + 2) * 8, (2) * 8); draw_tile(tiles[17], ((size * 2) + 3) * 8, (2) * 8);
		}
	}

	[Serializable]
	public class object_52 : Room_Object
	{
		public object_52(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x52, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x52];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(18, pos);
			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size; s++)
			{
				draw_tile(tiles[6], (2 + (s * 2)) * 8, (0) * 8); draw_tile(tiles[9], (3 + (s * 2)) * 8, (0) * 8);
				draw_tile(tiles[7], (2 + (s * 2)) * 8, (1) * 8); draw_tile(tiles[10], (3 + (s * 2)) * 8, (1) * 8);
				draw_tile(tiles[8], (2 + (s * 2)) * 8, (2) * 8); draw_tile(tiles[11], (3 + (s * 2)) * 8, (2) * 8);
			}

			draw_tile(tiles[0], (0) * 8, (0) * 8); draw_tile(tiles[3], (1) * 8, (0) * 8);
			draw_tile(tiles[1], (0) * 8, (1) * 8); draw_tile(tiles[4], (1) * 8, (1) * 8);
			draw_tile(tiles[2], (0) * 8, (2) * 8); draw_tile(tiles[5], (1) * 8, (2) * 8);

			draw_tile(tiles[12], ((size * 2) + 2) * 8, (0) * 8); draw_tile(tiles[15], ((size * 2) + 3) * 8, (0) * 8);
			draw_tile(tiles[13], ((size * 2) + 2) * 8, (1) * 8); draw_tile(tiles[16], ((size * 2) + 3) * 8, (1) * 8);
			draw_tile(tiles[14], ((size * 2) + 2) * 8, (2) * 8); draw_tile(tiles[17], ((size * 2) + 3) * 8, (2) * 8);
		}
	}

	[Serializable]
	public class object_53 : Room_Object
	{
		public object_53(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x53, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x53];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(4, pos);
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[0], (0 + (s * 2)) * 8, (0) * 8); draw_tile(tiles[2], (1 + (s * 2)) * 8, (0) * 8);
				draw_tile(tiles[1], (0 + (s * 2)) * 8, (1) * 8); draw_tile(tiles[3], (1 + (s * 2)) * 8, (1) * 8);
			}
		}
	}

	[Serializable]
	public class object_54 : Room_Object
	{
		public object_54(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x54, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x54];
		}

		public override void Draw()
		{
			base.Draw();
		}
	}

	[Serializable]
	public class object_55 : Room_Object
	{
		public object_55(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x55, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x55];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(8, pos);
			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();
			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[0], (0 + (s * 12)) * 8, (0) * 8); draw_tile(tiles[2], (1 + (s * 12)) * 8, (0) * 8); draw_tile(tiles[1], (2 + (s * 12)) * 8, (0) * 8); draw_tile(tiles[3], (3 + (s * 12)) * 8, (0) * 8);
				draw_tile(tiles[4], (0 + (s * 12)) * 8, (1) * 8); draw_tile(tiles[6], (1 + (s * 12)) * 8, (1) * 8); draw_tile(tiles[5], (2 + (s * 12)) * 8, (1) * 8); draw_tile(tiles[7], (3 + (s * 12)) * 8, (1) * 8);
			}
		}
	}

	[Serializable]
	public class object_56 : Room_Object
	{
		public object_56(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x56, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x56];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(8, pos);
			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();
			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[0], (0 + (s * 12)) * 8, (0) * 8); draw_tile(tiles[1], (1 + (s * 12)) * 8, (0) * 8); draw_tile(tiles[2], (2 + (s * 12)) * 8, (0) * 8); draw_tile(tiles[3], (3 + (s * 12)) * 8, (0) * 8);
				draw_tile(tiles[4], (0 + (s * 12)) * 8, (1) * 8); draw_tile(tiles[5], (1 + (s * 12)) * 8, (1) * 8); draw_tile(tiles[6], (2 + (s * 12)) * 8, (1) * 8); draw_tile(tiles[7], (3 + (s * 12)) * 8, (1) * 8);
			}
		}
	}

	[Serializable]
	public class object_57 : Room_Object
	{
		public object_57(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x57, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x57];
		}

		public override void Draw()
		{
			base.Draw();
		}
	}

	[Serializable]
	public class object_58 : Room_Object
	{
		public object_58(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x58, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x58];
		}

		public override void Draw()
		{
			base.Draw();
		}
	}

	[Serializable]
	public class object_59 : Room_Object
	{
		public object_59(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x59, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x59];
		}

		public override void Draw()
		{
			base.Draw();
		}
	}

	[Serializable]
	public class object_5A : Room_Object
	{
		public object_5A(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x5A, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x5A];
		}

		public override void Draw()
		{
			base.Draw();
		}
	}

	[Serializable]
	public class object_5B : Room_Object
	{
		public object_5B(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x5B, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x5B];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(18, pos);
			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size; s++)
			{
				draw_tile(tiles[6], (2 + (s * 2)) * 8, (0) * 8); draw_tile(tiles[9], (3 + (s * 2)) * 8, (0) * 8);
				draw_tile(tiles[7], (2 + (s * 2)) * 8, (1) * 8); draw_tile(tiles[10], (3 + (s * 2)) * 8, (1) * 8);
				draw_tile(tiles[8], (2 + (s * 2)) * 8, (2) * 8); draw_tile(tiles[11], (3 + (s * 2)) * 8, (2) * 8);
			}

			draw_tile(tiles[0], (0) * 8, (0) * 8); draw_tile(tiles[3], (1) * 8, (0) * 8);
			draw_tile(tiles[1], (0) * 8, (1) * 8); draw_tile(tiles[4], (1) * 8, (1) * 8);
			draw_tile(tiles[2], (0) * 8, (2) * 8); draw_tile(tiles[5], (1) * 8, (2) * 8);

			draw_tile(tiles[12], ((size * 2) + 2) * 8, (0) * 8); draw_tile(tiles[15], ((size * 2) + 3) * 8, (0) * 8);
			draw_tile(tiles[13], ((size * 2) + 2) * 8, (1) * 8); draw_tile(tiles[16], ((size * 2) + 3) * 8, (1) * 8);
			draw_tile(tiles[14], ((size * 2) + 2) * 8, (2) * 8); draw_tile(tiles[17], ((size * 2) + 3) * 8, (2) * 8);
		}
	}

	[Serializable]
	public class object_5C : Room_Object
	{
		public object_5C(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x5C, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x5C];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(18, pos);
			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size; s++)
			{
				draw_tile(tiles[6], (2 + (s * 2)) * 8, (0) * 8); draw_tile(tiles[9], (3 + (s * 2)) * 8, (0) * 8);
				draw_tile(tiles[7], (2 + (s * 2)) * 8, (1) * 8); draw_tile(tiles[10], (3 + (s * 2)) * 8, (1) * 8);
				draw_tile(tiles[8], (2 + (s * 2)) * 8, (2) * 8); draw_tile(tiles[11], (3 + (s * 2)) * 8, (2) * 8);
			}

			draw_tile(tiles[0], (0) * 8, (0) * 8); draw_tile(tiles[3], (1) * 8, (0) * 8);
			draw_tile(tiles[1], (0) * 8, (1) * 8); draw_tile(tiles[4], (1) * 8, (1) * 8);
			draw_tile(tiles[2], (0) * 8, (2) * 8); draw_tile(tiles[5], (1) * 8, (2) * 8);

			draw_tile(tiles[12], ((size * 2) + 2) * 8, (0) * 8); draw_tile(tiles[15], ((size * 2) + 3) * 8, (0) * 8);
			draw_tile(tiles[13], ((size * 2) + 2) * 8, (1) * 8); draw_tile(tiles[16], ((size * 2) + 3) * 8, (1) * 8);
			draw_tile(tiles[14], ((size * 2) + 2) * 8, (2) * 8); draw_tile(tiles[17], ((size * 2) + 3) * 8, (2) * 8);
		}
	}

	[Serializable]
	public class object_5D : Room_Object
	{
		public object_5D(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x5D, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x5D];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(15, pos);
			sort = Sorting.Horizontal | Sorting.Dungeons;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 2; s++)
			{
				draw_tile(tiles[6], (2 + (s * 1)) * 8, (0) * 8);
				draw_tile(tiles[7], (2 + (s * 1)) * 8, (1) * 8);
				draw_tile(tiles[8], (2 + (s * 1)) * 8, (2) * 8);
			}

			draw_tile(tiles[0], (0) * 8, (0) * 8); draw_tile(tiles[3], (1) * 8, (0) * 8);
			draw_tile(tiles[1], (0) * 8, (1) * 8); draw_tile(tiles[4], (1) * 8, (1) * 8);
			draw_tile(tiles[2], (0) * 8, (2) * 8); draw_tile(tiles[5], (1) * 8, (2) * 8);

			draw_tile(tiles[9], ((size * 1) + 4) * 8, (0) * 8); draw_tile(tiles[12], ((size * 1) + 5) * 8, (0) * 8);
			draw_tile(tiles[10], ((size * 1) + 4) * 8, (1) * 8); draw_tile(tiles[13], ((size * 1) + 5) * 8, (1) * 8);
			draw_tile(tiles[11], ((size * 1) + 4) * 8, (2) * 8); draw_tile(tiles[14], ((size * 1) + 5) * 8, (2) * 8);
		}
	}

	[Serializable]
	public class object_5E : Room_Object
	{
		public object_5E(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x5E, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x5E];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(4, pos);
			sort = Sorting.Horizontal | Sorting.Dungeons;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[0], (0 + (s * 4)) * 8, (0) * 8); draw_tile(tiles[2], (1 + (s * 4)) * 8, (0) * 8);
				draw_tile(tiles[1], (0 + (s * 4)) * 8, (1) * 8); draw_tile(tiles[3], (1 + (s * 4)) * 8, (1) * 8);
			}
		}
	}


	[Serializable]
	public class object_5F : Room_Object
	{
		public object_5F(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x5F, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x5F];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(3, pos);
			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 22; s++)
			{
				draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
			}

			draw_tile(tiles[0], (0) * 8, (0) * 8);
			draw_tile(tiles[2], ((size + 22)) * 8, (0) * 8);
		}
	}

	[Serializable]
	public class object_60 : Room_Object
	{
		public object_60(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x60, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x60];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(4, pos);
			sort = Sorting.Vertical;
		}

		public override void Draw()
		{
			base.Draw();

			if (this.size == 0)
			{
				this.size = 32;
			}

			for (int s = 0; s < size; s++)
			{
				draw_tile(tiles[0], (0) * 8, ((s * 2)) * 8); draw_tile(tiles[2], (1) * 8, ((s * 2)) * 8);
				draw_tile(tiles[1], (0) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[3], (1) * 8, (1 + (s * 2)) * 8);
			}
		}
	}

	[Serializable]
	public class object_61 : Room_Object
	{
		public object_61(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x61, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x61];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(8, pos);
			sort = Sorting.Vertical | Sorting.Wall;
		}

		public override void Draw()
		{
			base.Draw();

			if (this.size == 0)
			{
				this.size = 26;
			}

			for (int s = 0; s < size; s++)
			{
				draw_tile(tiles[0], (0) * 8, ((s * 2)) * 8); draw_tile(tiles[1], (1) * 8, ((s * 2)) * 8); draw_tile(tiles[2], (2) * 8, ((s * 2)) * 8); draw_tile(tiles[3], (3) * 8, ((s * 2)) * 8);
				draw_tile(tiles[4], (0) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[5], (1) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[6], (2) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[7], (3) * 8, (1 + (s * 2)) * 8);
			}
		}
	}

	[Serializable]
	public class object_62 : Room_Object
	{
		public object_62(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x62, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x62];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(8, pos);
			sort = Sorting.Vertical | Sorting.Wall;
		}

		public override void Draw()
		{
			base.Draw();

			if (this.size == 0)
			{
				this.size = 26;
			}

			for (int s = 0; s < size; s++)
			{
				draw_tile(tiles[0], (0) * 8, ((s * 2)) * 8); draw_tile(tiles[1], (1) * 8, ((s * 2)) * 8); draw_tile(tiles[2], (2) * 8, ((s * 2)) * 8); draw_tile(tiles[3], (3) * 8, ((s * 2)) * 8);
				draw_tile(tiles[4], (0) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[5], (1) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[6], (2) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[7], (3) * 8, (1 + (s * 2)) * 8);
			}
		}
	}

	[Serializable]
	public class object_63 : Room_Object
	{
		public object_63(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x63, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x63];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(8, pos);
			sort = Sorting.Vertical | Sorting.Wall;
			allBgs = true;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[0], (0) * 8, ((s * 2)) * 8); draw_tile(tiles[1], (1) * 8, ((s * 2)) * 8); draw_tile(tiles[2], (2) * 8, ((s * 2)) * 8); draw_tile(tiles[3], (3) * 8, ((s * 2)) * 8);
				draw_tile(tiles[4], (0) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[5], (1) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[6], (2) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[7], (3) * 8, (1 + (s * 2)) * 8);
			}
		}
	}

	[Serializable]
	public class object_64 : Room_Object
	{
		public object_64(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x64, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x64];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(8, pos);
			sort = Sorting.Vertical | Sorting.Wall;
			allBgs = true;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[0], (0) * 8, ((s * 2)) * 8); draw_tile(tiles[1], (1) * 8, ((s * 2)) * 8); draw_tile(tiles[2], (2) * 8, ((s * 2)) * 8); draw_tile(tiles[3], (3) * 8, ((s * 2)) * 8);
				draw_tile(tiles[4], (0) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[5], (1) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[6], (2) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[7], (3) * 8, (1 + (s * 2)) * 8);
			}
		}
	}

	[Serializable]
	public class object_65 : Room_Object
	{
		public object_65(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x65, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x65];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(8, pos);
			sort = Sorting.Vertical;

		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[0], (0) * 8, ((s * 6)) * 8); draw_tile(tiles[1], (1) * 8, ((s * 6)) * 8); draw_tile(tiles[2], (2) * 8, ((s * 6)) * 8); draw_tile(tiles[3], (3) * 8, ((s * 6)) * 8);
				draw_tile(tiles[4], (0) * 8, (1 + (s * 6)) * 8); draw_tile(tiles[5], (1) * 8, (1 + (s * 6)) * 8); draw_tile(tiles[6], (2) * 8, (1 + (s * 6)) * 8); draw_tile(tiles[7], (3) * 8, (1 + (s * 6)) * 8);
			}
		}
	}


	[Serializable]
	public class object_66 : Room_Object
	{
		public object_66(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x66, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x66];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(8, pos);
			sort = Sorting.Vertical;

		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[0], (0) * 8, ((s * 6)) * 8); draw_tile(tiles[1], (1) * 8, ((s * 6)) * 8); draw_tile(tiles[2], (2) * 8, ((s * 6)) * 8); draw_tile(tiles[3], (3) * 8, ((s * 6)) * 8);
				draw_tile(tiles[4], (0) * 8, (1 + (s * 6)) * 8); draw_tile(tiles[5], (1) * 8, (1 + (s * 6)) * 8); draw_tile(tiles[6], (2) * 8, (1 + (s * 6)) * 8); draw_tile(tiles[7], (3) * 8, (1 + (s * 6)) * 8);
			}
		}
	}

	[Serializable]
	public class object_67 : Room_Object
	{
		public object_67(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x67, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x67];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(4, pos);
			sort = Sorting.Vertical;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[0], (0) * 8, ((s * 2)) * 8); draw_tile(tiles[2], (1) * 8, ((s * 2)) * 8);
				draw_tile(tiles[1], (0) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[3], (1) * 8, (1 + (s * 2)) * 8);
			}
		}
	}

	[Serializable]
	public class object_68 : Room_Object
	{
		public object_68(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x68, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x68];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(4, pos);
			sort = Sorting.Vertical;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[0], (0) * 8, ((s * 2)) * 8); draw_tile(tiles[2], (1) * 8, ((s * 2)) * 8);
				draw_tile(tiles[1], (0) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[3], (1) * 8, (1 + (s * 2)) * 8);
			}
		}
	}

	[Serializable]
	public class object_69 : Room_Object
	{

		public object_69(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x69, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x69];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(3, pos);
			sort = Sorting.Vertical | Sorting.Dungeons;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 2; s++)
			{
				draw_tile(tiles[1], (0) * 8, (1 + (s * 1)) * 8);
			}

			draw_tile(tiles[0], (0) * 8, (0) * 8, tiles[1].getshortileinfo());
			draw_tile(tiles[2], (0) * 8, ((size + 2) + 1) * 8);
		}
	}


	[Serializable]
	public class object_6A : Room_Object
	{
		public object_6A(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x6A, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x6A];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(1, pos);
			sort = Sorting.Vertical;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[0], (0) * 8, ((s * 1)) * 8);
			}
		}
	}

	[Serializable]
	public class object_6B : Room_Object
	{
		public object_6B(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x6B, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x6B];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(1, pos);
			sort = Sorting.Vertical;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[0], (0) * 8, ((s * 1)) * 8);
			}
		}
	}


	[Serializable]
	public class object_6C : Room_Object
	{
		public object_6C(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x6C, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x6C];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(6, pos);
			sort = Sorting.Vertical;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 14; s++)
			{
				draw_tile(tiles[3], (0) * 8, (0 + (s * 1)) * 8);
				draw_tile(tiles[0], (0 + 1) * 8, (((s * 1)) * 8));
			}

			draw_tile(tiles[1], (0) * 8, (0) * 8);
			draw_tile(tiles[2], (0) * 8, (1) * 8);

			draw_tile(tiles[4], (0) * 8, (size + 12) * 8);
			draw_tile(tiles[5], (0) * 8, (size + 12 + 1) * 8);
		}
	}

	[Serializable]
	public class object_6D : Room_Object
	{
		public object_6D(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x6D, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x6D];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(6, pos);
			sort = Sorting.Vertical;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 14; s++)
			{
				draw_tile(tiles[3], (0 + 1) * 8, (0 + (s * 1)) * 8);
				draw_tile(tiles[0], (0) * 8, (((s * 1)) * 8));
			}

			draw_tile(tiles[1], (0 + 1) * 8, (0) * 8);
			draw_tile(tiles[2], (0 + 1) * 8, (1) * 8);

			draw_tile(tiles[4], (0 + 1) * 8, (size + 12) * 8);
			draw_tile(tiles[5], (0 + 1) * 8, (size + 12 + 1) * 8);
		}
	}

	[Serializable]
	public class object_6E : Room_Object
	{
		public object_6E(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x6E, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x6E];
		}

		public override void Draw()
		{
			base.Draw();
		}
	}

	[Serializable]
	public class object_6F : Room_Object
	{
		public object_6F(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x6F, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x6F];
		}

		public override void Draw()
		{
			base.Draw();
		}
	}

	[Serializable]
	public class object_70 : Room_Object
	{
		public object_70(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x70, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x70];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(16, pos);
			sort = Sorting.Vertical;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				int tid = 0;
				for (int xx = 0; xx < 4; xx++)
				{
					for (int yy = 0; yy < 4; yy++)
					{
						draw_tile(tiles[tid], (xx) * 8, (yy + (s * 4)) * 8);
						tid++;
					}
				}
			}
		}
	}

	[Serializable]
	public class object_71 : Room_Object
	{
		public object_71(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x71, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x71];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(1, pos);
			sort = Sorting.Vertical;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 4; s++)
			{
				draw_tile(tiles[0], (0) * 8, ((s * 1)) * 8);
			}
		}
	}


	[Serializable]
	public class object_72 : Room_Object
	{
		public object_72(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x72, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x72];
		}

		public override void Draw()
		{
			base.Draw();
		}
	}

	[Serializable]
	public class object_73 : Room_Object
	{
		public object_73(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x73, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x73];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(16, pos);
			sort = Sorting.Vertical;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				int tid = 0;
				for (int xx = 0; xx < 4; xx++)
				{
					for (int yy = 0; yy < 4; yy++)
					{
						draw_tile(tiles[tid], (xx) * 8, (yy + (s * 6)) * 8);
						tid++;
					}
				}
			}
		}
	}

	[Serializable]
	public class object_74 : Room_Object
	{
		public object_74(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x74, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x74];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(16, pos);
			sort = Sorting.Vertical;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				int tid = 0;
				for (int xx = 0; xx < 4; xx++)
				{
					for (int yy = 0; yy < 4; yy++)
					{
						draw_tile(tiles[tid], (xx) * 8, (yy + (s * 6)) * 8);
						tid++;
					}
				}
			}
		}
	}

	[Serializable]
	public class object_75 : Room_Object
	{
		public object_75(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x75, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x75];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(8, pos);
			sort = Sorting.Vertical;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[0], (0) * 8, ((s * 6)) * 8); draw_tile(tiles[4], (1) * 8, ((s * 6)) * 8);
				draw_tile(tiles[1], (0) * 8, (1 + (s * 6)) * 8); draw_tile(tiles[5], (1) * 8, (1 + (s * 6)) * 8);
				draw_tile(tiles[2], (0) * 8, (2 + (s * 6)) * 8); draw_tile(tiles[6], (1) * 8, (2 + (s * 6)) * 8);
				draw_tile(tiles[3], (0) * 8, (3 + (s * 6)) * 8); draw_tile(tiles[7], (1) * 8, (3 + (s * 6)) * 8);
			}
		}
	}

	[Serializable]
	public class object_76 : Room_Object
	{
		public object_76(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x76, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x76];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(16, pos);
			sort = Sorting.Vertical;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				int tid = 0;
				for (int xx = 0; xx < 3; xx++)
				{
					for (int yy = 0; yy < 4; yy++)
					{
						draw_tile(tiles[tid], (xx) * 8, (yy + (s * 8)) * 8);
						tid++;
					}
				}
			}
		}
	}


	[Serializable]
	public class object_77 : Room_Object
	{
		public object_77(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x77, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x77];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(16, pos);
			sort = Sorting.Vertical;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				int tid = 0;
				for (int xx = 0; xx < 3; xx++)
				{
					for (int yy = 0; yy < 4; yy++)
					{
						draw_tile(tiles[tid], (xx) * 8, (yy + (s * 8)) * 8);
						tid++;
					}
				}
			}
		}
	}

	[Serializable]
	public class object_78 : Room_Object
	{
		public object_78(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x78, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x78];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(4, pos);
			sort = Sorting.Vertical;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				int tid = 0;
				for (int xx = 0; xx < 2; xx++)
				{
					for (int yy = 0; yy < 2; yy++)
					{
						draw_tile(tiles[tid], (xx) * 8, (yy + (s * 14)) * 8);
						tid++;
					}
				}
			}
		}
	}

	[Serializable]
	public class object_79 : Room_Object
	{
		public object_79(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x79, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x79];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(1, pos);
			sort = Sorting.Vertical;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[0], (0) * 8, ((s * 1)) * 8);
			}
		}
	}

	[Serializable]
	public class object_7A : Room_Object
	{
		public object_7A(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x7A, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x7A];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(1, pos);
			sort = Sorting.Vertical;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[0], (0) * 8, ((s * 1)) * 8);
			}
		}
	}

	[Serializable]
	public class object_7B : Room_Object
	{
		public object_7B(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x7B, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x7B];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(4, pos);
			sort = Sorting.Vertical;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				int tid = 0;
				for (int xx = 0; xx < 2; xx++)
				{
					for (int yy = 0; yy < 2; yy++)
					{
						draw_tile(tiles[tid], (xx) * 8, (yy + (s * 14)) * 8);
						tid++;
					}
				}
			}
		}
	}

	[Serializable]
	public class object_7C : Room_Object
	{
		public object_7C(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x7C, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x7C];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(1, pos);
			sort = Sorting.Vertical;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 2; s++)
			{
				draw_tile(tiles[0], (0) * 8, ((s * 1)) * 8);
			}
		}
	}

	[Serializable]
	public class object_7D : Room_Object
	{
		public object_7D(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x7D, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x7D];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(4, pos);
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				int tid = 0;
				for (int xx = 0; xx < 2; xx++)
				{
					for (int yy = 0; yy < 2; yy++)
					{
						draw_tile(tiles[tid], (xx) * 8, (yy + (s * 2)) * 8);
						tid++;
					}
				}
			}
		}
	}


	[Serializable]
	public class object_7E : Room_Object
	{
		public object_7E(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x7E, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x7E];
		}

		public override void Draw()
		{
			base.Draw();
		}
	}

	[Serializable]
	public class object_7F : Room_Object
	{
		public object_7F(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x7F, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x7F];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(8, pos);
			sort = Sorting.Vertical;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				int tid = 0;
				for (int xx = 0; xx < 2; xx++)
				{
					for (int yy = 0; yy < 4; yy++)
					{
						draw_tile(tiles[tid], (xx) * 8, (yy + (s * 12)) * 8);
						tid++;
					}
				}
			}
		}
	}


	[Serializable]
	public class object_80 : Room_Object
	{
		public object_80(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x80, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x80];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(8, pos);
			sort = Sorting.Vertical;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				int tid = 0;
				for (int xx = 0; xx < 2; xx++)
				{
					for (int yy = 0; yy < 4; yy++)
					{
						draw_tile(tiles[tid], (xx) * 8, (yy + (s * 12)) * 8);
						tid++;
					}
				}
			}
		}
	}

	[Serializable]
	public class object_81 : Room_Object
	{
		public object_81(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x81, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x81];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(12, pos);
			sort = Sorting.Vertical;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				int tid = 0;
				for (int xx = 0; xx < 3; xx++)
				{
					for (int yy = 0; yy < 4; yy++)
					{
						draw_tile(tiles[tid], (xx) * 8, (yy + (s * 6)) * 8);
						tid++;
					}
				}
			}
		}
	}

	[Serializable]
	public class object_82 : Room_Object
	{
		public object_82(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x82, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x82];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(12, pos);
			sort = Sorting.Vertical;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				int tid = 0;
				for (int xx = 0; xx < 3; xx++)
				{
					for (int yy = 0; yy < 4; yy++)
					{
						draw_tile(tiles[tid], (xx) * 8, (yy + (s * 6)) * 8);
						tid++;
					}
				}
			}
		}
	}

	[Serializable]
	public class object_83 : Room_Object
	{
		public object_83(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x83, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x83];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(12, pos);
			sort = Sorting.Vertical;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				int tid = 0;
				for (int xx = 0; xx < 3; xx++)
				{
					for (int yy = 0; yy < 4; yy++)
					{
						draw_tile(tiles[tid], (xx) * 8, (yy + (s * 6)) * 8);
						tid++;
					}
				}
			}
		}
	}

	[Serializable]
	public class object_84 : Room_Object
	{
		public object_84(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x84, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x84];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(12, pos);
			sort = Sorting.Vertical;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				int tid = 0;
				for (int xx = 0; xx < 3; xx++)
				{
					for (int yy = 0; yy < 4; yy++)
					{
						draw_tile(tiles[tid], (xx) * 8, (yy + (s * 6)) * 8);
						tid++;
					}
				}
			}
		}
	}

	[Serializable]
	public class object_85 : Room_Object
	{
		public object_85(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x85, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x85];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(18, pos);
			sort = Sorting.Vertical;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size; s++)
			{
				draw_tile(tiles[6], (0) * 8, (2 + (s * 2)) * 8); draw_tile(tiles[9], (0) * 8, (3 + (s * 2)) * 8);
				draw_tile(tiles[7], (1) * 8, (2 + (s * 2)) * 8); draw_tile(tiles[10], (1) * 8, (3 + (s * 2)) * 8);
				draw_tile(tiles[8], (2) * 8, (2 + (s * 2)) * 8); draw_tile(tiles[11], (2) * 8, (3 + (s * 2)) * 8);
			}

			draw_tile(tiles[0], (0) * 8, (0) * 8); draw_tile(tiles[3], (0) * 8, (1) * 8);
			draw_tile(tiles[1], (1) * 8, (0) * 8); draw_tile(tiles[4], (1) * 8, (1) * 8);
			draw_tile(tiles[2], (2) * 8, (0) * 8); draw_tile(tiles[5], (2) * 8, (1) * 8);

			draw_tile(tiles[12], (0) * 8, ((size * 2) + 2) * 8); draw_tile(tiles[15], (0) * 8, ((size * 2) + 3) * 8);
			draw_tile(tiles[13], (1) * 8, ((size * 2) + 2) * 8); draw_tile(tiles[16], (1) * 8, ((size * 2) + 3) * 8);
			draw_tile(tiles[14], (2) * 8, ((size * 2) + 2) * 8); draw_tile(tiles[17], (2) * 8, ((size * 2) + 3) * 8);
		}
	}

	[Serializable]
	public class object_86 : Room_Object
	{
		public object_86(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x86, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x86];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(18, pos);
			sort = Sorting.Vertical;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size; s++)
			{
				draw_tile(tiles[6], (0) * 8, (2 + (s * 2)) * 8); draw_tile(tiles[9], (0) * 8, (3 + (s * 2)) * 8);
				draw_tile(tiles[7], (1) * 8, (2 + (s * 2)) * 8); draw_tile(tiles[10], (1) * 8, (3 + (s * 2)) * 8);
				draw_tile(tiles[8], (2) * 8, (2 + (s * 2)) * 8); draw_tile(tiles[11], (2) * 8, (3 + (s * 2)) * 8);
			}

			draw_tile(tiles[0], (0) * 8, (0) * 8); draw_tile(tiles[3], (0) * 8, (1) * 8);
			draw_tile(tiles[1], (1) * 8, (0) * 8); draw_tile(tiles[4], (1) * 8, (1) * 8);
			draw_tile(tiles[2], (2) * 8, (0) * 8); draw_tile(tiles[5], (2) * 8, (1) * 8);

			draw_tile(tiles[12], (0) * 8, ((size * 2) + 2) * 8); draw_tile(tiles[15], (0) * 8, ((size * 2) + 3) * 8);
			draw_tile(tiles[13], (1) * 8, ((size * 2) + 2) * 8); draw_tile(tiles[16], (1) * 8, ((size * 2) + 3) * 8);
			draw_tile(tiles[14], (2) * 8, ((size * 2) + 2) * 8); draw_tile(tiles[17], (2) * 8, ((size * 2) + 3) * 8);
		}
	}

	[Serializable]
	public class object_87 : Room_Object
	{
		public object_87(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x87, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x87];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(8, pos);
			sort = Sorting.Vertical | Sorting.Dungeons;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[0], (0) * 8, ((s * 6)) * 8); draw_tile(tiles[4], (1) * 8, ((s * 6)) * 8);
				draw_tile(tiles[1], (0) * 8, (1 + (s * 6)) * 8); draw_tile(tiles[5], (1) * 8, (1 + (s * 6)) * 8);
				draw_tile(tiles[2], (0) * 8, (2 + (s * 6)) * 8); draw_tile(tiles[6], (1) * 8, (2 + (s * 6)) * 8);
				draw_tile(tiles[3], (0) * 8, (3 + (s * 6)) * 8); draw_tile(tiles[7], (1) * 8, (3 + (s * 6)) * 8);
			}
		}
	}

	[Serializable]
	public class object_88 : Room_Object
	{
		public object_88(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x88, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x88];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(12, pos);
			sort = Sorting.Vertical | Sorting.Dungeons;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 2; s++)
			{
				draw_tile(tiles[4], (0) * 8, (0 + 2 + s) * 8); draw_tile(tiles[5], (1) * 8, (0 + 2 + s) * 8);
			}

			draw_tile(tiles[0], (0) * 8, (0) * 8); draw_tile(tiles[2], (1) * 8, (0) * 8);
			draw_tile(tiles[1], (0) * 8, (0 + 1) * 8); draw_tile(tiles[3], (1) * 8, (1) * 8);

			draw_tile(tiles[6], (0) * 8, (size + 3) * 8); draw_tile(tiles[9], (1) * 8, (size + 3) * 8);
			draw_tile(tiles[7], (0) * 8, (1 + size + 3) * 8); draw_tile(tiles[10], (1) * 8, (1 + size + 3) * 8);
			draw_tile(tiles[8], (0) * 8, (2 + size + 3) * 8); draw_tile(tiles[11], (1) * 8, (2 + size + 3) * 8);
		}
	}

	[Serializable]
	public class object_89 : Room_Object
	{
		public object_89(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x89, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x89];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(4, pos);
			sort = Sorting.Vertical | Sorting.Dungeons;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[0], (0) * 8, ((s * 4)) * 8); draw_tile(tiles[2], (1) * 8, ((s * 4)) * 8);
				draw_tile(tiles[1], (0) * 8, (1 + (s * 4)) * 8); draw_tile(tiles[3], (1) * 8, (1 + (s * 4)) * 8);
			}
		}
	}

	[Serializable]
	public class object_8A : Room_Object
	{
		public object_8A(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x8A, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x8A];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(3, pos);
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 21; s++)
			{
				draw_tile(tiles[1], (0) * 8, (1 + (s * 1)) * 8);
			}

			draw_tile(tiles[0], (0) * 8, (0) * 8);
			draw_tile(tiles[2], (0) * 8, ((size + 21) + 1) * 8);
		}
	}

	[Serializable]
	public class object_8B : Room_Object
	{
		public object_8B(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x8B, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x8B];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(3, pos);
			sort = Sorting.Vertical;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 8; s++)
			{
				draw_tile(tiles[0], (0) * 8, ((s * 1)) * 8);
			}
		}
	}

	[Serializable]
	public class object_8C : Room_Object
	{
		public object_8C(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x8C, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x8C];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(3, pos);
			sort = Sorting.Vertical;
		}

		public override void Draw()
		{
			base.Draw();
			for (int s = 0; s < size + 8; s++)
			{
				draw_tile(tiles[0], (0) * 8, ((s * 1)) * 8);
			}
		}
	}


	[Serializable]
	public class object_8D : Room_Object
	{
		public object_8D(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x8D, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x8D];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(1, pos);
			sort = Sorting.Vertical;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[0], (0) * 8, ((s * 1)) * 8);
			}
		}
	}

	[Serializable]
	public class object_8E : Room_Object
	{
		public object_8E(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x8E, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x8E];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(1, pos);
			sort = Sorting.Vertical;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[0], (0) * 8, ((s * 1)) * 8);
			}
		}
	}

	[Serializable]
	public class object_8F : Room_Object
	{
		public object_8F(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x8F, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x8F];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(6, pos);
		}

		public override void Draw()
		{
			base.Draw();
			for (int s =
				0; s < size + 2; s++)
			{
				draw_tile(tiles[2], (0) * 8, (0 + 1 + (s * 2)) * 8); draw_tile(tiles[3], (0 + 1) * 8, (0 + 1 + (s * 2)) * 8);
				draw_tile(tiles[2], (0) * 8, (2 + (s * 2)) * 8); draw_tile(tiles[3], (1) * 8, (2 + (s * 2)) * 8);
			}

			draw_tile(tiles[0], (0) * 8, (0) * 8); draw_tile(tiles[1], (0 + 1) * 8, (0) * 8);
		}
	}



	[Serializable]
	public class object_90 : Room_Object
	{
		public object_90(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x90, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x90];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(8, pos);
			sort = Sorting.Vertical | Sorting.Wall;
		}

		public override void Draw()
		{
			base.Draw();

			if (this.size == 0)
			{
				this.size = 26;
			}

			for (int s = 0; s < size; s++)
			{
				draw_tile(tiles[0], (0) * 8, ((s * 2)) * 8); draw_tile(tiles[1], (1) * 8, ((s * 2)) * 8); draw_tile(tiles[2], (2) * 8, ((s * 2)) * 8); draw_tile(tiles[3], (3) * 8, ((s * 2)) * 8);
				draw_tile(tiles[4], (0) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[5], (1) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[6], (2) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[7], (3) * 8, (1 + (s * 2)) * 8);
			}
		}
	}

	[Serializable]
	public class object_91 : Room_Object
	{
		public object_91(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x91, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x91];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(8, pos);
			sort = Sorting.Vertical | Sorting.Wall;
		}

		public override void Draw()
		{
			base.Draw();

			if (this.size == 0)
			{
				this.size = 26;
			}

			for (int s = 0; s < size; s++)
			{
				draw_tile(tiles[0], (0) * 8, ((s * 2)) * 8); draw_tile(tiles[1], (1) * 8, ((s * 2)) * 8); draw_tile(tiles[2], (2) * 8, ((s * 2)) * 8); draw_tile(tiles[3], (3) * 8, ((s * 2)) * 8);
				draw_tile(tiles[4], (0) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[5], (1) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[6], (2) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[7], (3) * 8, (1 + (s * 2)) * 8);
			}
		}
	}


	[Serializable]
	public class object_92 : Room_Object
	{
		public object_92(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x92, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x92];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(4, pos);
			sort = Sorting.Vertical | Sorting.Dungeons;
		}

		public override void Draw()
		{
			base.Draw();

			if (size == 0)
			{
				size = 26;
			}

			for (int s = 0; s < size; s++)
			{
				draw_tile(tiles[0], (0) * 8, ((s * 2)) * 8); draw_tile(tiles[2], (1) * 8, ((s * 2)) * 8);
				draw_tile(tiles[1], (0) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[3], (1) * 8, (1 + (s * 2)) * 8);
			}
		}
	}

	[Serializable]
	public class object_93 : Room_Object
	{
		public object_93(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x93, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x93];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(4, pos);
			sort = Sorting.Vertical | Sorting.Dungeons;
		}

		public override void Draw()
		{
			base.Draw();

			if (size == 0)
			{
				size = 26;
			}

			for (int s = 0; s < size; s++)
			{
				draw_tile(tiles[0], (0) * 8, ((s * 2)) * 8); draw_tile(tiles[2], (1) * 8, ((s * 2)) * 8);
				draw_tile(tiles[1], (0) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[3], (1) * 8, (1 + (s * 2)) * 8);
			}
		}
	}

	[Serializable]
	public class object_94 : Room_Object
	{
		public object_94(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x94, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x94];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(16, pos);
			sort = Sorting.Vertical | Sorting.Dungeons | Sorting.Floors;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				int tid = 0;
				for (int xx = 0; xx < 4; xx++)
				{
					for (int yy = 0; yy < 4; yy++)
					{
						draw_tile(tiles[tid], (xx) * 8, (yy + (s * 4)) * 8);
						tid++;
					}
				}
			}
		}
	}

	[Serializable]
	public class object_95 : Room_Object
	{
		public object_95(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x95, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x95];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(4, pos);
			sort = Sorting.Vertical;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[0], (0) * 8, ((s * 2)) * 8); draw_tile(tiles[2], (1) * 8, ((s * 2)) * 8);
				draw_tile(tiles[1], (0) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[3], (1) * 8, (1 + (s * 2)) * 8);
			}
		}
	}

	[Serializable]
	public class object_96 : Room_Object
	{
		public object_96(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x96, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x96];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(4, pos);
			sort = Sorting.Vertical | Sorting.Dungeons;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[0], (0) * 8, ((s * 2)) * 8); draw_tile(tiles[2], (1) * 8, ((s * 2)) * 8);
				draw_tile(tiles[1], (0) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[3], (1) * 8, (1 + (s * 2)) * 8);
			}
		}
	}

	[Serializable]
	public class object_97 : Room_Object
	{
		public object_97(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x97, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x97];
		}

		public override void Draw()
		{
			base.Draw();
		}
	}

	[Serializable]
	public class object_98 : Room_Object
	{
		public object_98(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x98, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x98];
		}

		public override void Draw()
		{
			base.Draw();
		}
	}

	[Serializable]
	public class object_99 : Room_Object
	{
		public object_99(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x99, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x99];
		}

		public override void Draw()
		{
			base.Draw();
		}
	}

	[Serializable]
	public class object_9A : Room_Object
	{
		public object_9A(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x9A, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x9A];
		}

		public override void Draw()
		{
			base.Draw();
		}
	}

	[Serializable]
	public class object_9B : Room_Object
	{
		public object_9B(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x9B, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x9B];
		}

		public override void Draw()
		{
			base.Draw();
		}
	}

	[Serializable]
	public class object_9C : Room_Object
	{
		public object_9C(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x9C, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x9C];
		}

		public override void Draw()
		{
			base.Draw();
		}
	}

	[Serializable]
	public class object_9D : Room_Object
	{
		public object_9D(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x9D, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x9D];
		}

		public override void Draw()
		{
			base.Draw();
		}
	}

	[Serializable]
	public class object_9E : Room_Object
	{
		public object_9E(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x9E, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x9E];
		}

		public override void Draw()
		{
			base.Draw();
		}
	}

	[Serializable]
	public class object_9F : Room_Object
	{
		public object_9F(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0x9F, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0x9F];
		}

		public override void Draw()
		{
			base.Draw();
		}
	}

	[Serializable]
	public class object_A0 : Room_Object
	{
		public object_A0(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xA0, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xA0];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(1, pos);
			sort = Sorting.Horizontal | Sorting.Vertical;
		}

		public override void Draw()
		{
			base.Draw();

			int lenght = size + 4;
			for (int s = 0; s < size + 4; s++)
			{
				for (int i = 0; i < lenght; i++)
				{
					draw_tile(tiles[0], (0 + i) * 8, ((s)) * 8);
				}

				lenght -= 1;
			}
		}
	}

	[Serializable]
	public class object_A1 : Room_Object
	{
		public object_A1(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xA1, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xA1];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(1, pos);
			sort = Sorting.Horizontal | Sorting.Vertical;
		}

		public override void Draw()
		{
			//height = (size + 10) * 8;
			//width = (size + 6) * 8;
			//diagonalFix = true;

			base.Draw();

			int lenght = 1;
			for (int s = 0; s < size + 4; s++)
			{
				for (int i = 0; i < lenght; i++)
				{
					draw_tile(tiles[0], (i) * 8, ((s)) * 8);
				}

				lenght += 1;
			}
		}
	}


	[Serializable]
	public class object_A2 : Room_Object
	{
		public object_A2(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xA2, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xA2];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(1, pos);
			sort = Sorting.Horizontal | Sorting.Vertical;
		}

		public override void Draw()
		{
			base.Draw();

			int lenght = size + 4;
			for (int s = 0; s < size + 4; s++)
			{
				for (int i = 0; i < lenght; i++)
				{
					draw_tile(tiles[0], ((i) + s) * 8, ((s)) * 8);
				}

				lenght -= 1;
			}
		}
	}


	[Serializable]
	public class object_A3 : Room_Object
	{
		public object_A3(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xA3, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xA3];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(1, pos);
			sort = Sorting.Horizontal | Sorting.Vertical;
		}

		public override void Draw()
		{
			base.Draw();
			height = (size + 10) * 8;
			width = (size + 6) * 8;
			diagonalFix = true;
			int lenght = size + 4;

			for (int s = 0; s < size + 4; s++)
			{
				for (int i = 0; i < lenght; i++)
				{
					draw_tile(tiles[0], ((i) + s) * 8, (0 - (s)) * 8);
				}

				lenght -= 1;
			}
		}
	}

	[Serializable]
	public class object_A4 : Room_Object
	{
		public object_A4(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xA4, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xA4];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(24, pos);
			sort = Sorting.Horizontal | Sorting.Vertical;
		}

		public override void Draw()
		{
			base.Draw();

			draw_tile(tiles[8], (0) * 8, (0) * 8);//top left corner
			draw_tile(tiles[9], (1) * 8, (0) * 8); //vertical tile
												   //horizontal tile
			draw_tile(tiles[23], (size + 3) * 8, (size + 3) * 8);

			draw_tile(tiles[17], (0) * 8, (size + 3) * 8);//bottom left corner

			draw_tile(tiles[14], (size + 3) * 8, (0) * 8);

			for (int xx = 1; xx < size + 3; xx++)
			{
				for (int yy = 1; yy < size + 3; yy++)
				{
					draw_tile(tiles[0], (xx) * 8, (yy) * 8);
				}
				draw_tile(tiles[19], (xx) * 8, (size + 3) * 8);
				draw_tile(tiles[10], (xx) * 8, (0) * 8);
			}

			for (int yy = 1; yy < size + 3; yy++)
			{
				draw_tile(tiles[9], (0) * 8, (yy) * 8);
				draw_tile(tiles[15], (size + 3) * 8, (yy) * 8);
			}
		}
	}

	[Serializable]
	public class object_A5 : Room_Object
	{
		public object_A5(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xA5, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xA5];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(1, pos);
			sort = Sorting.Horizontal | Sorting.Vertical;
		}

		public override void Draw()
		{
			base.Draw();

			int lenght = size + 4;
			for (int s = 0; s < size + 4; s++)
			{
				for (int i = 0; i < lenght; i++)
				{
					draw_tile(tiles[0], (i) * 8, ((s)) * 8);
				}

				lenght -= 1;
			}
		}
	}

	[Serializable]
	public class object_A6 : Room_Object
	{
		public object_A6(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xA6, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xA6];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(1, pos);
			sort = Sorting.Horizontal | Sorting.Vertical;
		}

		public override void Draw()
		{
			base.Draw();

			int lenght = 1;
			for (int s = 0; s < size + 4; s++)
			{
				for (int i = 0; i < lenght; i++)
				{
					draw_tile(tiles[0], (i) * 8, ((s)) * 8);
				}

				lenght += 1;
			}
		}
	}


	[Serializable]
	public class object_A7 : Room_Object
	{
		public object_A7(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xA7, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xA7];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(1, pos);
			sort = Sorting.Horizontal | Sorting.Vertical;
		}

		public override void Draw()
		{
			base.Draw();

			int lenght = size + 4;
			for (int s = 0; s < size + 4; s++)
			{
				for (int i = 0; i < lenght; i++)
				{
					draw_tile(tiles[0], ((i) + s) * 8, ((s)) * 8);
				}

				lenght -= 1;
			}
		}
	}


	[Serializable]
	public class object_A8 : Room_Object
	{
		public object_A8(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xA8, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xA8];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(1, pos);
			sort = Sorting.Horizontal | Sorting.Vertical;
		}

		public override void Draw()
		{
			base.Draw();

			int lenght = size + 4;
			for (int s = 0; s < size + 4; s++)
			{
				for (int i = 0; i < lenght; i++)
				{
					draw_tile(tiles[0], ((i) + s) * 8, (0 - (s)) * 8);
				}

				lenght -= 1;
			}
		}
	}

	[Serializable]
	public class object_A9 : Room_Object
	{
		public object_A9(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xA9, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xA9];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(1, pos);
			sort = Sorting.Horizontal | Sorting.Vertical;
			showRectangle = true;
		}

		public override void Draw()
		{
			base.Draw();

			int lenght = size + 4;
			for (int s = 0; s < size + 4; s++)
			{
				for (int i = 0; i < lenght; i++)
				{
					draw_tile(tiles[0], (i) * 8, ((s)) * 8);
				}

				lenght -= 1;
			}
		}
	}

	[Serializable]
	public class object_AA : Room_Object
	{
		public object_AA(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xAA, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xAA];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(1, pos);
			sort = Sorting.Horizontal | Sorting.Vertical;
			showRectangle = true;
		}

		public override void Draw()
		{
			base.Draw();

			int lenght = 1;
			for (int s = 0; s < size + 4; s++)
			{
				for (int i = 0; i < lenght; i++)
				{
					draw_tile(tiles[0], (i) * 8, ((s)) * 8);
				}

				lenght += 1;
			}
		}
	}

	[Serializable]
	public class object_AB : Room_Object
	{
		public object_AB(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xAB, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xAB];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(1, pos);
			sort = Sorting.Horizontal | Sorting.Vertical;
			showRectangle = true;
		}

		public override void Draw()
		{
			base.Draw();

			int lenght = size + 4;
			for (int s = 0; s < size + 4; s++)
			{
				for (int i = 0; i < lenght; i++)
				{
					draw_tile(tiles[0], ((i) + s) * 8, ((s)) * 8);
				}

				lenght -= 1;
			}
		}
	}


	[Serializable]
	public class object_AC : Room_Object
	{
		public object_AC(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xAC, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xAC];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(1, pos);
			sort = Sorting.Horizontal | Sorting.Vertical;
			showRectangle = true;


			diagonalFix = true;
		}

		public override void Draw()
		{
			base.Draw();

			int lenght = size + 4;
			for (int s = 0; s < size + 4; s++)
			{
				for (int i = 0; i < lenght; i++)
				{
					draw_tile(tiles[0], ((i) + s) * 8, (0 - (s)) * 8);
				}

				lenght -= 1;
			}

			height = (size + 7) * 8;
			width = (size + 4) * 8;
		}
	}


	[Serializable]
	public class object_AD : Room_Object
	{
		public object_AD(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xAD, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xAD];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(1, pos);

		}

		public override void Draw()
		{
			base.Draw();

			draw_tile(tiles[0], ((0) * 8), (0) * 8);
		}
	}

	[Serializable]
	public class object_AE : Room_Object
	{
		public object_AE(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xAE, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xAE];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(1, pos);
		}

		public override void Draw()
		{
			base.Draw();

			draw_tile(tiles[0], ((0) * 8), (0) * 8);
		}
	}

	[Serializable]
	public class object_AF : Room_Object
	{
		public object_AF(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xAF, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xAF];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(1, pos);
		}

		public override void Draw()
		{
			base.Draw();

			draw_tile(tiles[0], ((0) * 8), (0) * 8);
		}
	}

	[Serializable]
	public class object_B0 : Room_Object
	{
		public object_B0(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xB0, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xB0];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(1, pos);
			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 8; s++)
			{
				draw_tile(tiles[0], ((s * 1)) * 8, (0) * 8);
			}
		}
	}

	[Serializable]
	public class object_B1 : Room_Object
	{

		public object_B1(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xB1, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xB1];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(1, pos);
			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 8; s++)
			{
				draw_tile(tiles[0], ((s * 1)) * 8, (0) * 8);
			}
		}
	}


	[Serializable]
	public class object_B2 : Room_Object
	{
		public object_B2(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xB2, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xB2];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(16, pos);
			sort = Sorting.Horizontal | Sorting.Floors;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				int tid = 0;
				for (int xx = 0; xx < 4; xx++)
				{
					for (int yy = 0; yy < 4; yy++)
					{
						draw_tile(tiles[tid], (xx + (s * 4)) * 8, (yy) * 8);
						tid++;
					}
				}
			}
		}
	}

	[Serializable]
	public class object_B3 : Room_Object
	{
		public object_B3(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xB3, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xB3];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(3, pos);
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
			}

			draw_tile(tiles[0], (0) * 8, (0) * 8);
			draw_tile(tiles[2], ((size + 2)) * 8, (0) * 8);
		}
	}

	[Serializable]
	public class object_B4 : Room_Object
	{
		public object_B4(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xB4, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xB4];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(3, pos);
		}

		public override void Draw()
		{

			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
			}

			draw_tile(tiles[0], (0) * 8, (0) * 8);
			draw_tile(tiles[2], ((size + 2)) * 8, (0) * 8);
		}
	}

	[Serializable]
	public class object_B5 : Room_Object
	{

		public object_B5(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xB5, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xB5];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(8, pos);
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				int tid = 0;
				for (int xx = 0; xx < 2; xx++)
				{
					for (int yy = 0; yy < 4; yy++)
					{
						draw_tile(tiles[tid], (xx + (s * 2)) * 8, (yy) * 8);
						tid++;
					}
				}
			}
		}
	}

	[Serializable]
	public class object_B6 : Room_Object
	{
		public object_B6(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xB6, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xB6];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(8, pos);
			sort = Sorting.Horizontal | Sorting.Wall;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				int tid = 0;
				for (int xx = 0; xx < 2; xx++)
				{
					for (int yy = 0; yy < 4; yy++)
					{
						draw_tile(tiles[tid], (xx + (s * 2)) * 8, (yy) * 8);
						tid++;
					}
				}
			}
		}
	}

	[Serializable]
	public class object_B7 : Room_Object
	{
		public object_B7(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xB7, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xB7];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(8, pos);
			sort = Sorting.Horizontal | Sorting.Wall;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size; s++)
			{
				int tid = 0;
				for (int xx = 0; xx < 2; xx++)
				{
					for (int yy = 0; yy < 4; yy++)
					{
						draw_tile(tiles[tid], (xx + (s * 2)) * 8, (yy) * 8);
						tid++;
					}
				}
			}
		}
	}

	[Serializable]
	public class object_B8 : Room_Object
	{
		public object_B8(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xB8, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xB8];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(4, pos);
			sort = Sorting.Horizontal | Sorting.Dungeons;
		}

		public override void Draw()
		{
			base.Draw();

			if (size == 0)
			{
				size = 26;
			}

			for (int s = 0; s < size; s++)
			{
				int tid = 0;
				for (int xx = 0; xx < 2; xx++)
				{
					for (int yy = 0; yy < 2; yy++)
					{
						draw_tile(tiles[tid], (xx + (s * 2)) * 8, (yy) * 8);
						tid++;
					}
				}
			}
		}
	}

	[Serializable]
	public class object_B9 : Room_Object
	{
		public object_B9(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xB9, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xB9];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(4, pos);
			sort = Sorting.Horizontal | Sorting.Dungeons;
		}

		public override void Draw()
		{
			base.Draw();

			if (size == 0)
			{
				size = 26;
			}

			for (int s = 0; s < size; s++)
			{
				int tid = 0;
				for (int xx = 0; xx < 2; xx++)
				{
					for (int yy = 0; yy < 2; yy++)
					{
						draw_tile(tiles[tid], (xx + (s * 2)) * 8, (yy) * 8);
						tid++;
					}
				}
			}
		}
	}

	[Serializable]
	public class object_BA : Room_Object
	{
		public object_BA(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xBA, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xBA];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(16, pos);
			sort = Sorting.Horizontal | Sorting.Floors;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				int tid = 0;
				for (int xx = 0; xx < 4; xx++)
				{
					for (int yy = 0; yy < 4; yy++)
					{
						draw_tile(tiles[tid], (xx + (s * 4)) * 8, (yy) * 8);
						tid++;
					}
				}
			}
		}
	}

	[Serializable]
	public class object_BB : Room_Object
	{

		public object_BB(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xBB, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xBB];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(4, pos);
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[0], (0 + (s * 4)) * 8, (0) * 8); draw_tile(tiles[2], (1 + (s * 4)) * 8, (0) * 8);
				draw_tile(tiles[1], (0 + (s * 4)) * 8, (1) * 8); draw_tile(tiles[3], (1 + (s * 4)) * 8, (1) * 8);
			}
		}
	}

	[Serializable]
	public class object_BC : Room_Object
	{
		public object_BC(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xBC, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xBC];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(4, pos);
			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();
			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[0], (0 + (s * 2)) * 8, (0) * 8); draw_tile(tiles[2], (1 + (s * 2)) * 8, (0) * 8);
				draw_tile(tiles[1], (0 + (s * 2)) * 8, (1) * 8); draw_tile(tiles[3], (1 + (s * 2)) * 8, (1) * 8);
			}
		}
	}


	[Serializable]
	public class object_BD : Room_Object
	{
		public object_BD(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xBD, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xBD];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(4, pos);
			sort = Sorting.Horizontal;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[0], (0 + (s * 2)) * 8, (0) * 8); draw_tile(tiles[2], (1 + (s * 2)) * 8, (0) * 8);
				draw_tile(tiles[1], (0 + (s * 2)) * 8, (1) * 8); draw_tile(tiles[3], (1 + (s * 2)) * 8, (1) * 8);
			}
		}
	}


	[Serializable]
	public class object_BE : Room_Object
	{
		public object_BE(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xBE, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xBE];
		}

		public override void Draw()
		{
			base.Draw();
		}
	}


	[Serializable]
	public class object_BF : Room_Object
	{
		public object_BF(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xBF, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xBF];
		}

		public override void Draw()
		{
			base.Draw();
		}
	}

	[Serializable]
	public class object_C0 : Room_Object
	{
		public object_C0(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xC0, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xC0];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			sort = Sorting.Horizontal | Sorting.Vertical;
			addTiles(1, pos);
		}

		public override void Draw()
		{
			base.Draw();

			int sizex = ((size >> 2) & 0x03);
			int sizey = ((size) & 0x03);

			for (int xx = 0; xx < sizex + 1; xx++)
			{
				for (int yy = 0; yy < sizey + 1; yy++)
				{
					for (int xxxx = 0; xxxx < 4; xxxx++)
					{
						for (int yyyy = 0; yyyy < 4; yyyy++)
						{
							draw_tile(tiles[0], (xxxx + (xx * 4)) * 8, (yyyy + (yy * 4)) * 8);
						}
					}
				}
			}
		}
	}

	[Serializable]
	public class object_C1 : Room_Object
	{
		public object_C1(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xC1, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xC1];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(68, pos); // ??
			sort = Sorting.Horizontal | Sorting.Vertical;
		}

		public override void Draw()
		{
			base.Draw();

			int sizex = ((size >> 2) & 0x03);
			int sizey = ((size) & 0x03);

			int i = 0;
			for (int xx = 0; xx < 3; xx++)
			{
				for (int yy = 0; yy < 3; yy++)
				{
					draw_tile(tiles[i], xx * 8, yy * 8); // Top left corner
					draw_tile(tiles[i + 15], (xx + ((sizex + 4) * 2) + 3) * 8, yy * 8); // Top right corner
					draw_tile(tiles[i + 40], xx * 8, (yy + ((sizey + 1) * 2) + 3) * 8); // bottom left corner
					draw_tile(tiles[i + 55], (xx + ((sizex + 4) * 2) + 3) * 8, (yy + ((sizey + 1) * 2) + 3) * 8); // Bottom left corner
					i++;
				}
			}

			for (int sx = 0; sx < sizex + 4; sx++)
			{
				for (int sy = 0; sy < sizey + 1; sy++)
				{
					draw_tile(tiles[30], (3 + (sx * 2)) * 8, (3 + (sy * 2)) * 8); draw_tile(tiles[31], (4 + (sx * 2)) * 8, (3 + (sy * 2)) * 8);
					draw_tile(tiles[32], (3 + (sx * 2)) * 8, (4 + (sy * 2)) * 8); draw_tile(tiles[33], (4 + (sx * 2)) * 8, (4 + (sy * 2)) * 8);
				}
			}

			draw_tile(tiles[64], (6 + (sizex * 1)) * 8, (3 + (sizey * 1)) * 8); draw_tile(tiles[66], (7 + (sizex * 1)) * 8, (3 + (sizey * 1)) * 8);
			draw_tile(tiles[65], (6 + (sizex * 1)) * 8, (4 + (sizey * 1)) * 8); draw_tile(tiles[67], (7 + (sizex * 1)) * 8, (4 + (sizey * 1)) * 8);

			for (int sx = 0; sx < sizex + 4; sx++)
			{
				draw_tile(tiles[9], (3 + (sx * 2)) * 8, 0 * 8); draw_tile(tiles[12], (4 + (sx * 2)) * 8, 0 * 8);
				draw_tile(tiles[10], (3 + (sx * 2)) * 8, 1 * 8); draw_tile(tiles[13], (4 + (sx * 2)) * 8, 1 * 8);
				draw_tile(tiles[11], (3 + (sx * 2)) * 8, 2 * 8); draw_tile(tiles[14], (4 + (sx * 2)) * 8, 2 * 8);

				draw_tile(tiles[49], (3 + (sx * 2)) * 8, (((sizey + 1) * 2) + 3) * 8); draw_tile(tiles[52], (4 + (sx * 2)) * 8, (((sizey + 1) * 2) + 3) * 8);
				draw_tile(tiles[50], (3 + (sx * 2)) * 8, (((sizey + 1) * 2) + 4) * 8); draw_tile(tiles[53], (4 + (sx * 2)) * 8, (((sizey + 1) * 2) + 4) * 8);
				draw_tile(tiles[51], (3 + (sx * 2)) * 8, (((sizey + 1) * 2) + 5) * 8); draw_tile(tiles[54], (4 + (sx * 2)) * 8, (((sizey + 1) * 2) + 5) * 8);
			}

			// 30,31
			// 32,33 // middle

			for (int sy = 0; sy < sizey + 1; sy++)
			{
				draw_tile(tiles[24], (0) * 8, (3 + sy * 2) * 8); draw_tile(tiles[25], (1) * 8, (3 + sy * 2) * 8); draw_tile(tiles[26], (2) * 8, (3 + sy * 2) * 8);
				draw_tile(tiles[27], (0) * 8, (4 + sy * 2) * 8); draw_tile(tiles[28], (1) * 8, (4 + sy * 2) * 8); draw_tile(tiles[29], (2) * 8, (4 + sy * 2) * 8);

				draw_tile(tiles[34], (((sizex + 4) * 2) + 3) * 8, (3 + sy * 2) * 8); draw_tile(tiles[35], (((sizex + 4) * 2) + 4) * 8, (3 + sy * 2) * 8); draw_tile(tiles[36], (((sizex + 4) * 2) + 5) * 8, (3 + sy * 2) * 8);
				draw_tile(tiles[37], (((sizex + 4) * 2) + 3) * 8, (4 + sy * 2) * 8); draw_tile(tiles[38], (((sizex + 4) * 2) + 4) * 8, (4 + sy * 2) * 8); draw_tile(tiles[39], (((sizex + 4) * 2) + 5) * 8, (4 + sy * 2) * 8);
			}
		}
	}

	[Serializable]
	public class object_C2 : Room_Object
	{
		public object_C2(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xC2, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xC2];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(1, pos); // ??
			sort = Sorting.Horizontal | Sorting.Vertical;
			showRectangle = true;
		}

		public override void Draw()
		{
			base.Draw();

			int sizex = ((size >> 2) & 0x03);
			int sizey = ((size) & 0x03);

			for (int xx = 0; xx < sizex + 1; xx++)
			{
				for (int yy = 0; yy < sizey + 1; yy++)
				{
					for (int xxxx = 0; xxxx < 4; xxxx++)
					{
						for (int yyyy = 0; yyyy < 4; yyyy++)
						{
							draw_tile(tiles[0], (xxxx + (xx * 4)) * 8, (yyyy + (yy * 4)) * 8);
						}
					}
				}
			}
		}
	}

	[Serializable]
	public class object_C3 : Room_Object
	{
		public object_C3(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xC3, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xC3];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(1, pos);//??
			sort = Sorting.Horizontal | Sorting.Vertical;
			showRectangle = true;
		}

		public override void Draw()
		{
			base.Draw();

			int sizex = ((size >> 2) & 0x03);
			int sizey = ((size) & 0x03);

			for (int xx = 0; xx < sizex + 1; xx++)
			{
				for (int yy = 0; yy < sizey + 1; yy++)
				{
					for (int xxxx = 0; xxxx < 3; xxxx++)
					{
						for (int yyyy = 0; yyyy < 3; yyyy++)
						{
							draw_tile(tiles[0], (xxxx + (xx * 3)) * 8, (yyyy + (yy * 3)) * 8);
						}
					}
				}
			}
		}
	}

	[Serializable]
	public class object_C4 : Room_Object
	{
		public object_C4(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xC4, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xC4];
			sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
		}

		public override void Draw()
		{
			base.Draw();

			int sizex = ((size >> 2) & 0x03);
			int sizey = ((size) & 0x03);

			byte f = (byte) (room.floor1 << 4); // How can it be null oO ?
			int pos = Constants.tile_address + f;
			addTiles(8, pos);//??

			for (int xx = 0; xx < sizex + 1; xx++)
			{
				for (int yy = 0; yy < sizey + 1; yy++)
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
	public class object_C5 : Room_Object
	{
		public object_C5(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xC5, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xC5];
			sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(8, pos); // ??
		}

		public override void Draw()
		{
			base.Draw();
			int sizex = ((size >> 2) & 0x03);
			int sizey = ((size) & 0x03);

			for (int xx = 0; xx < sizex + 1; xx++)
			{
				for (int yy = 0; yy < sizey + 1; yy++)
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
	public class object_C6 : Room_Object
	{
		public object_C6(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xC6, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xC6];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(8, pos); // ??
			sort = Sorting.Horizontal | Sorting.Vertical;
			showRectangle = true;
		}

		public override void Draw()
		{
			base.Draw();

			int sizex = ((size >> 2) & 0x03);
			int sizey = ((size) & 0x03);

			for (int xx = 0; xx < sizex + 1; xx++)
			{
				for (int yy = 0; yy < sizey + 1; yy++)
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
	public class object_C7 : Room_Object
	{
		public object_C7(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xC7, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xC7];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(8, pos);//??
			sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
		}

		public override void Draw()
		{
			base.Draw();

			int sizex = ((size >> 2) & 0x03);
			int sizey = ((size) & 0x03);

			for (int xx = 0; xx < sizex + 1; xx++)
			{
				for (int yy = 0; yy < sizey + 1; yy++)
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
	public class object_C8 : Room_Object
	{
		public object_C8(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xC8, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xC8];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
			addTiles(8, pos);//??
		}

		public override void Draw()
		{
			base.Draw();

			int sizex = ((size >> 2) & 0x03);
			int sizey = ((size) & 0x03);

			for (int xx = 0; xx < sizex + 1; xx++)
			{
				for (int yy = 0; yy < sizey + 1; yy++)
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
	public class object_C9 : Room_Object
	{
		public object_C9(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xC9, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xC9];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
			addTiles(8, pos);//??
		}

		public override void Draw()
		{
			base.Draw();

			int sizex = ((size >> 2) & 0x03);
			int sizey = ((size) & 0x03);

			for (int xx = 0; xx < sizex + 1; xx++)
			{
				for (int yy = 0; yy < sizey + 1; yy++)
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
	public class object_CA : Room_Object
	{
		public object_CA(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xCA, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xCA];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
			addTiles(8, pos); // ??
		}

		public override void Draw()
		{
			base.Draw();

			int sizex = ((size >> 2) & 0x03);
			int sizey = ((size) & 0x03);

			for (int xx = 0; xx < sizex + 1; xx++)
			{
				for (int yy = 0; yy < sizey + 1; yy++)
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
	public class object_CB : Room_Object
	{
		public object_CB(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xCB, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xCB];
		}

		public override void Draw()
		{
			base.Draw();
		}
	}

	[Serializable]
	public class object_CC : Room_Object
	{
		public object_CC(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xCC, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xCC];
		}

		public override void Draw()
		{
			base.Draw();
		}
	}

	[Serializable]
	public class object_CD : Room_Object
	{
		public object_CD(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xCD, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xCD];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
			addTiles(24, pos); // ??
			pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((0 & 0xFF) * 2), 2];
			addTiles(4, pos);
			offsetX = -8;
		}

		public override void Draw()
		{
			base.Draw();

			int sizey = ((size >> 2) & 0x03);
			int sizex = ((size) & 0x03);
			draw_tile(tiles[0], ((sizex * 8) + 8) * 8, (0) * 8); draw_tile(tiles[3], ((sizex * 8) + 9) * 8, (0) * 8); draw_tile(tiles[6], ((sizex * 8) + 10) * 8, (0) * 8);
			draw_tile(tiles[1], ((sizex * 8) + 8) * 8, (1) * 8); draw_tile(tiles[4], ((sizex * 8) + 9) * 8, (1) * 8); draw_tile(tiles[7], ((sizex * 8) + 10) * 8, (1) * 8);
			draw_tile(tiles[2], ((sizex * 8) + 8) * 8, (2) * 8); draw_tile(tiles[5], ((sizex * 8) + 9) * 8, (2) * 8); draw_tile(tiles[8], ((sizex * 8) + 10) * 8, (2) * 8);

			draw_tile(tiles[15], ((sizex * 8) + 8) * 8, ((0 + 13) + sizey * 4) * 8); draw_tile(tiles[18], ((sizex * 8) + 9) * 8, ((0 + 13) + sizey * 4) * 8); draw_tile(tiles[21], ((sizex * 8) + 10) * 8, ((0 + 13) + sizey * 4) * 8);
			draw_tile(tiles[16], ((sizex * 8) + 8) * 8, ((1 + 13) + sizey * 4) * 8); draw_tile(tiles[19], ((sizex * 8) + 9) * 8, ((1 + 13) + sizey * 4) * 8); draw_tile(tiles[22], ((sizex * 8) + 10) * 8, ((1 + 13) + sizey * 4) * 8);
			draw_tile(tiles[17], ((sizex * 8) + 8) * 8, ((2 + 13) + sizey * 4) * 8); draw_tile(tiles[20], ((sizex * 8) + 9) * 8, ((2 + 13) + sizey * 4) * 8); draw_tile(tiles[23], ((sizex * 8) + 10) * 8, ((2 + 13) + sizey * 4) * 8);

			for (int xx = 0; xx < 4 + (sizex * 4); xx++)
			{
				for (int yy = 0; yy < 8 + (sizey * 2); yy++)
				{
					draw_tile(tiles[24], ((xx * 2)) * 8, (yy * 2) * 8); draw_tile(tiles[25], ((xx * 2) + 1) * 8, (yy * 2) * 8);
					draw_tile(tiles[26], ((xx * 2)) * 8, ((yy * 2) + 1) * 8); draw_tile(tiles[27], ((xx * 2) + 1) * 8, ((yy * 2) + 1) * 8);
				}
			}

			for (int yy = 0; yy < 5 + (sizey * 2); yy++)
			{
				draw_tile(tiles[9], ((sizex * 8) + 8) * 8, ((yy * 2) + 3) * 8); draw_tile(tiles[10], ((sizex * 8) + 9) * 8, ((yy * 2) + 3) * 8); draw_tile(tiles[11], ((sizex * 8) + 10) * 8, ((yy * 2) + 3) * 8);
				draw_tile(tiles[12], ((sizex * 8) + 8) * 8, ((yy * 2) + 4) * 8); draw_tile(tiles[13], ((sizex * 8) + 9) * 8, ((yy * 2) + 4) * 8); draw_tile(tiles[14], ((sizex * 8) + 10) * 8, ((yy * 2) + 4) * 8);
			}
		}
	}

	[Serializable]
	public class object_CE : Room_Object
	{
		public object_CE(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xCE, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xCE];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
			addTiles(24, pos); // ??
							   // Ceiling tiles
			pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((0 & 0xFF) * 2), 2];
			addTiles(4, pos);
		}

		public override void Draw()
		{
			base.Draw();

			int sizey = ((size >> 2) & 0x03);
			int sizex = ((size) & 0x03);

			draw_tile(tiles[0], (0) * 8, (0) * 8); draw_tile(tiles[3], (1) * 8, (0) * 8); draw_tile(tiles[6], (2) * 8, (0) * 8);
			draw_tile(tiles[1], (0) * 8, (1) * 8); draw_tile(tiles[4], (1) * 8, (1) * 8); draw_tile(tiles[7], (2) * 8, (1) * 8);
			draw_tile(tiles[2], (0) * 8, (2) * 8); draw_tile(tiles[5], (1) * 8, (2) * 8); draw_tile(tiles[8], (2) * 8, (2) * 8);

			draw_tile(tiles[15], (0) * 8, ((0 + 13) + sizey * 4) * 8); draw_tile(tiles[18], (1) * 8, ((0 + 13) + sizey * 4) * 8); draw_tile(tiles[21], (2) * 8, ((0 + 13) + sizey * 4) * 8);
			draw_tile(tiles[16], (0) * 8, ((1 + 13) + sizey * 4) * 8); draw_tile(tiles[19], (1) * 8, ((1 + 13) + sizey * 4) * 8); draw_tile(tiles[22], (2) * 8, ((1 + 13) + sizey * 4) * 8);
			draw_tile(tiles[17], (0) * 8, ((2 + 13) + sizey * 4) * 8); draw_tile(tiles[20], (1) * 8, ((2 + 13) + sizey * 4) * 8); draw_tile(tiles[23], (2) * 8, ((2 + 13) + sizey * 4) * 8);

			for (int xx = 0; xx < 4 + (sizex * 4); xx++)
			{
				for (int yy = 0; yy < 8 + (sizey * 2); yy++)
				{
					draw_tile(tiles[24], ((xx * 2) + 3) * 8, (yy * 2) * 8); draw_tile(tiles[25], ((xx * 2) + 4) * 8, (yy * 2) * 8);
					draw_tile(tiles[26], ((xx * 2) + 3) * 8, ((yy * 2) + 1) * 8); draw_tile(tiles[27], ((xx * 2) + 4) * 8, ((yy * 2) + 1) * 8);
				}
			}

			for (int yy = 0; yy < 5 + (sizey * 2); yy++)
			{
				draw_tile(tiles[9], (0) * 8, ((yy * 2) + 3) * 8); draw_tile(tiles[10], (1) * 8, ((yy * 2) + 3) * 8); draw_tile(tiles[11], (2) * 8, ((yy * 2) + 3) * 8);
				draw_tile(tiles[12], (0) * 8, ((yy * 2) + 4) * 8); draw_tile(tiles[13], (1) * 8, ((yy * 2) + 4) * 8); draw_tile(tiles[14], (2) * 8, ((yy * 2) + 4) * 8);
			}

		}
	}

	[Serializable]
	public class object_CF : Room_Object
	{
		public object_CF(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xCF, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xCF];
		}

		public override void Draw()
		{
			base.Draw();
		}
	}

	[Serializable]
	public class object_D0 : Room_Object
	{
		public object_D0(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xD0, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xD0];
		}

		public override void Draw()
		{
			base.Draw();
		}
	}

	[Serializable]
	public class object_D1 : Room_Object
	{
		public object_D1(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xD1, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xD1];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(8, pos); // ??
			sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
		}

		public override void Draw()
		{
			base.Draw();

			int sizex = ((size >> 2) & 0x03);
			int sizey = ((size) & 0x03);

			for (int xx = 0; xx < sizex + 1; xx++)
			{
				for (int yy = 0; yy < sizey + 1; yy++)
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
	public class object_D2 : Room_Object
	{
		public object_D2(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xD2, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xD2];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(8, pos); // ??
			sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
		}

		public override void Draw()
		{
			base.Draw();

			int sizex = ((size >> 2) & 0x03);
			int sizey = ((size) & 0x03);

			for (int xx = 0; xx < sizex + 1; xx++)
			{
				for (int yy = 0; yy < sizey + 1; yy++)
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
	public class object_D3 : Room_Object
	{
		public object_D3(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xD3, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xD3];
		}

		public override void Draw()
		{
			base.Draw();
		}
	}

	[Serializable]
	public class object_D4 : Room_Object
	{
		public object_D4(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xD4, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xD4];
		}

		public override void Draw()
		{
			base.Draw();
		}
	}

	[Serializable]
	public class object_D5 : Room_Object
	{
		public object_D5(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xD5, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xD5];
		}

		public override void Draw()
		{
			base.Draw();
		}
	}

	[Serializable]
	public class object_D6 : Room_Object
	{
		public object_D6(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xD6, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xD6];
		}

		public override void Draw()
		{
			base.Draw();
		}
	}

	[Serializable]
	public class object_D7 : Room_Object
	{
		public object_D7(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xD7, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xD7];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(1, pos); // ??
			sort = Sorting.Horizontal | Sorting.Vertical;
		}

		public override void Draw()
		{
			base.Draw();

			int sizex = ((size >> 2) & 0x03);
			int sizey = ((size) & 0x03);

			for (int xx = 0; xx < sizex + 1; xx++)
			{
				for (int yy = 0; yy < sizey + 1; yy++)
				{
					draw_tile(tiles[0], (xx * 3) * 8, (yy * 3) * 8); draw_tile(tiles[0], ((xx * 3) + 1) * 8, (yy * 3) * 8);
					draw_tile(tiles[0], ((xx * 3) + 2) * 8, (yy * 3) * 8);

					draw_tile(tiles[0], (xx * 3) * 8, ((yy * 3) + 1) * 8); draw_tile(tiles[0], ((xx * 3) + 1) * 8, ((yy * 3) + 1) * 8);
					draw_tile(tiles[0], ((xx * 3) + 2) * 8, ((yy * 3) + 1) * 8);

					draw_tile(tiles[0], (xx * 3) * 8, ((yy * 3) + 2) * 8); draw_tile(tiles[0], ((xx * 3) + 1) * 8, ((yy * 3) + 2) * 8);
					draw_tile(tiles[0], ((xx * 3) + 2) * 8, ((yy * 3) + 2) * 8);
				}
			}
		}
	}

	[Serializable]
	public class object_D8 : Room_Object
	{
		public object_D8(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xD8, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xD8];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
			addTiles(8, pos); // ??
		}

		public override void Draw()
		{
			base.Draw();

			int sizex = ((size >> 2) & 0x03);
			int sizey = ((size) & 0x03);

			for (int xx = 0; xx < sizex + 2; xx++)
			{
				for (int yy = 0; yy < sizey + 2; yy++)
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
	public class object_D9 : Room_Object
	{
		public object_D9(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xD9, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xD9];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(8, pos); // ??
			sort = Sorting.Horizontal | Sorting.Vertical;
		}

		public override void Draw()
		{
			base.Draw();

			int sizex = ((size >> 2) & 0x03);
			int sizey = ((size) & 0x03);

			for (int xx = 0; xx < sizex + 1; xx++)
			{
				for (int yy = 0; yy < sizey + 1; yy++)
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
	public class object_DA : Room_Object
	{
		public object_DA(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xDA, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xDA];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
			addTiles(8, pos); // ??
		}

		public override void Draw()
		{
			base.Draw();

			int sizex = ((size >> 2) & 0x03);
			int sizey = ((size) & 0x03);

			for (int xx = 0; xx < sizex + 2; xx++)
			{
				for (int yy = 0; yy < sizey + 2; yy++)
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
	public class object_DB : Room_Object
	{

		public object_DB(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xDB, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xDB];
			sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
		}

		public override void Draw()
		{
			base.Draw();

			int sizex = ((size >> 2) & 0x03);
			int sizey = ((size) & 0x03);

			byte f = (byte) (room.floor2 << 4);
			int pos = Constants.tile_address + f;
			tiles.Clear();
			addTiles(8, pos);// ??

			for (int xx = 0; xx < sizex + 1; xx++)
			{
				for (int yy = 0; yy < sizey + 1; yy++)
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
	public class object_DC : Room_Object
	{
		public object_DC(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xDC, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xDC];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(21, pos); // ??
			sort = Sorting.Horizontal | Sorting.Vertical;
		}

		public override void Draw()
		{
			base.Draw();

			int sizex = ((size >> 2) & 0x03);
			int sizey = ((size) & 0x03);

			draw_tile(tiles[18], (9 + (sizex * 2)) * 8, 0); // Top left rail border with size
			draw_tile(tiles[0], 0, 0); // Top left rail border
			draw_tile(tiles[1], 0, (5 + (sizey * 2)) * 8); // Bottom left rail border // Not sure why that tile exist but meh
			draw_tile(tiles[2], 0, (6 + (sizey * 2)) * 8); // Bottom left rail corner

			draw_tile(tiles[19], (9 + (sizex * 2)) * 8, (5 + (sizey * 2)) * 8); // Bottom right rail border // Not sure why that tile exist but meh
			draw_tile(tiles[20], (9 + (sizex * 2)) * 8, (6 + (sizey * 2)) * 8); // Bottom right rail corner

			for (int yy = 0; yy < sizey + 2; yy++) // Set size on 4 already
			{
				draw_tile(tiles[0], 0, (1 + (yy * 2)) * 8); // Top left rail border with size
				draw_tile(tiles[0], 0, (2 + (yy * 2)) * 8); // Top left rail border with size

				for (int xx = 0; xx < sizex + 1; xx++)
				{
					draw_tile(tiles[3], ((xx + 1) * 8), (0 + (yy * 2)) * 8); // Left side chunk
					draw_tile(tiles[3], ((xx + 1) * 8), (1 + (yy * 2)) * 8); // Left side chunk

					draw_tile(tiles[15], ((xx + 8 + sizex) * 8), (0 + (yy * 2)) * 8); // Right side chunk
					draw_tile(tiles[15], ((xx + 8 + sizex) * 8), (1 + (yy * 2)) * 8); // Right side chunk
				}

				draw_tile(tiles[6], (2 + sizex) * 8, (0 + (yy * 2)) * 8); // Left side extra line
				draw_tile(tiles[6], (2 + sizex) * 8, (1 + (yy * 2)) * 8); // Left side extra line

				draw_tile(tiles[12], (7 + sizex) * 8, (0 + (yy * 2)) * 8); // Right side extra line
				draw_tile(tiles[12], (7 + sizex) * 8, (1 + (yy * 2)) * 8); // Right side extra line

				draw_tile(tiles[9], (3 + sizex) * 8, (1 + (yy * 2)) * 8); // Middle
				draw_tile(tiles[9], (4 + sizex) * 8, (1 + (yy * 2)) * 8); // Middle
				draw_tile(tiles[9], (5 + sizex) * 8, (1 + (yy * 2)) * 8); // Middle
				draw_tile(tiles[9], (6 + sizex) * 8, (1 + (yy * 2)) * 8); // Middle
				draw_tile(tiles[9], (3 + sizex) * 8, (2 + (yy * 2)) * 8); // Middle
				draw_tile(tiles[9], (4 + sizex) * 8, (2 + (yy * 2)) * 8); // Middle
				draw_tile(tiles[9], (5 + sizex) * 8, (2 + (yy * 2)) * 8); // Middle
				draw_tile(tiles[9], (6 + sizex) * 8, (2 + (yy * 2)) * 8); // Middle

				draw_tile(tiles[18], (9 + (sizex * 2)) * 8, (1 + (yy * 2)) * 8); // Top left rail border with size
				draw_tile(tiles[18], (9 + (sizex * 2)) * 8, (2 + (yy * 2)) * 8); // Top left rail border with size   

				// draw_tile(tiles[15], ((xx + 8 + sizex) * 8), (4 + (sizey * 2)) * 8); // Last line of carpet right side chunk
			}

			draw_tile(tiles[9], (3 + sizex) * 8, (0) * 8); // Middle
			draw_tile(tiles[9], (4 + sizex) * 8, (0) * 8); // Middle
			draw_tile(tiles[9], (5 + sizex) * 8, (0) * 8); // Middle
			draw_tile(tiles[9], (6 + sizex) * 8, (0) * 8); // Middle

			draw_tile(tiles[10], (3 + sizex) * 8, (5 + (sizey * 2)) * 8); // Stairs1
			draw_tile(tiles[10], (4 + sizex) * 8, (5 + (sizey * 2)) * 8); // Stairs1
			draw_tile(tiles[10], (5 + sizex) * 8, (5 + (sizey * 2)) * 8); // Stairs1
			draw_tile(tiles[10], (6 + sizex) * 8, (5 + (sizey * 2)) * 8); // Stairs1

			draw_tile(tiles[11], (3 + sizex) * 8, (6 + (sizey * 2)) * 8); // Stairs2
			draw_tile(tiles[11], (4 + sizex) * 8, (6 + (sizey * 2)) * 8); // Stairs2
			draw_tile(tiles[11], (5 + sizex) * 8, (6 + (sizey * 2)) * 8); // Stairs2
			draw_tile(tiles[11], (6 + sizex) * 8, (6 + (sizey * 2)) * 8); // Stairs2

			draw_tile(tiles[7], (2 + sizex) * 8, (5 + (sizey * 2)) * 8);
			draw_tile(tiles[6], (2 + sizex) * 8, (4 + (sizey * 2)) * 8);
			draw_tile(tiles[12], (7 + sizex) * 8, (4 + (sizey * 2)) * 8);
			draw_tile(tiles[13], (7 + sizex) * 8, (5 + (sizey * 2)) * 8);
			draw_tile(tiles[14], (7 + sizex) * 8, (6 + (sizey * 2)) * 8);
			draw_tile(tiles[8], (2 + sizex) * 8, (6 + (sizey * 2)) * 8);

			//draw_tile(tiles[6], (2 + sizex) * 8, (5 + (sizey * 2)) * 8); // Last new line of carpet left side
			//draw_tile(tiles[6], (1 * 8), (5 + (sizey * 2)) * 8); // Last new line of carpet left side

			for (int xx = 0; xx < sizex + 1; xx++)
			{
				draw_tile(tiles[3], ((1 + xx) * 8), (4 + (sizey * 2)) * 8); // Last line of carpet left side
				draw_tile(tiles[15], ((xx + 8 + sizex) * 8), (4 + (sizey * 2)) * 8); // Last line of carpet right side chunk
				draw_tile(tiles[4], ((1 + xx) * 8), (5 + (sizey * 2)) * 8); // last new line of carpet left side
				draw_tile(tiles[5], (1 + (xx)) * 8, (6 + (sizey * 2)) * 8); // Last line bottom left rail

				draw_tile(tiles[16], (8 + sizex + xx) * 8, (5 + (sizey * 2)) * 8); // Last new line of carpet left side
				draw_tile(tiles[17], (8 + sizex + xx) * 8, (6 + (sizey * 2)) * 8); // Last line bottom left rail
			}
		}
	}

	[Serializable]
	public class object_DD : Room_Object
	{
		public object_DD(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xDD, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xDD];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			sort = Sorting.Horizontal | Sorting.Vertical;
			addTiles(16, pos);
		}

		public override void Draw()
		{
			base.Draw();

			int sizex = ((size >> 2) & 0x03);
			int sizey = ((size) & 0x03);

			for (int xx = 0; xx < sizex + 1; xx++)
			{
				for (int yy = 0; yy < sizey + 1; yy++)
				{
					draw_tile(tiles[5], (1 + (xx * 2)) * 8, (1 + (yy * 2)) * 8); // Middle top
					draw_tile(tiles[6], (2 + (xx * 2)) * 8, (1 + (yy * 2)) * 8); // middle top

					draw_tile(tiles[9], (1 + (xx * 2)) * 8, (2 + (yy * 2)) * 8); // Middle bottom
					draw_tile(tiles[10], (2 + (xx * 2)) * 8, (2 + (yy * 2)) * 8); // Middle bottom
				}
			}

			for (int yy = 0; yy < sizey + 1; yy++)
			{
				draw_tile(tiles[4], (0) * 8, (1 + (yy * 2)) * 8); // Left border
				draw_tile(tiles[8], (0) * 8, (2 + (yy * 2)) * 8); // Left border

				draw_tile(tiles[7], (3 + (sizex * 2)) * 8, (1 + (yy * 2)) * 8); // Right border
				draw_tile(tiles[11], (3 + (sizex * 2)) * 8, (2 + (yy * 2)) * 8); // Right border
			}

			draw_tile(tiles[0], (0) * 8, (0) * 8); // Top left corner
			draw_tile(tiles[12], (0) * 8, (3 + (sizey * 2)) * 8); // Bottom left corner

			for (int xx = 0; xx < sizex + 1; xx++)
			{
				draw_tile(tiles[1], (1 + (xx * 2)) * 8, (0) * 8); // Top border
				draw_tile(tiles[2], (2 + (xx * 2)) * 8, (0) * 8); // Top border

				draw_tile(tiles[13], (1 + (xx * 2)) * 8, (3 + (sizey * 2)) * 8); // Bottom border
				draw_tile(tiles[14], (2 + (xx * 2)) * 8, (3 + (sizey * 2)) * 8); // Bottom border
			}

			draw_tile(tiles[3], (3 + (sizex * 2)) * 8, (0) * 8); // Top right corner
			draw_tile(tiles[15], (3 + (sizex * 2)) * 8, (3 + (sizey * 2)) * 8); // Bottom right corner
		}
	}

	[Serializable]
	public class object_DE : Room_Object
	{
		public object_DE(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xDE, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xDE];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(4, pos);
			sort = Sorting.Horizontal | Sorting.Vertical;
		}

		public override void Draw()
		{
			base.Draw();

			int sizex = ((size >> 2) & 0x03);
			int sizey = ((size) & 0x03);

			for (int xx = 0; xx < sizex + 1; xx++)
			{
				for (int yy = 0; yy < sizey + 1; yy++)
				{
					draw_tile(tiles[0], (0 + (xx * 2)) * 8, (0 + (yy * 2)) * 8); // Middle top
					draw_tile(tiles[2], (1 + (xx * 2)) * 8, (0 + (yy * 2)) * 8); // Middle top

					draw_tile(tiles[1], (0 + (xx * 2)) * 8, (1 + (yy * 2)) * 8); // Middle bottom
					draw_tile(tiles[3], (1 + (xx * 2)) * 8, (1 + (yy * 2)) * 8); // Middle bottom
				}
			}
		}
	}

	[Serializable]
	public class object_DF : Room_Object
	{
		public object_DF(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xDF, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xDF];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(8, pos);
			sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
		}

		public override void Draw()
		{
			base.Draw();

			int sizex = ((size >> 2) & 0x03);
			int sizey = ((size) & 0x03);

			for (int xx = 0; xx < sizex + 1; xx++)
			{
				for (int yy = 0; yy < sizey + 1; yy++)
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
	public class object_E0 : Room_Object
	{
		public object_E0(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xE0, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xE0];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(8, pos);//??
			sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
		}

		public override void Draw()
		{
			base.Draw();

			int sizex = ((size >> 2) & 0x03);
			int sizey = ((size) & 0x03);

			for (int xx = 0; xx < sizex + 1; xx++)
			{
				for (int yy = 0; yy < sizey + 1; yy++)
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
	public class object_E1 : Room_Object
	{
		public object_E1(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xE1, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xE1];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(8, pos); // ??
			sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
		}

		public override void Draw()
		{
			base.Draw();

			int sizex = ((size >> 2) & 0x03);
			int sizey = ((size) & 0x03);

			for (int xx = 0; xx < sizex + 1; xx++)
			{
				for (int yy = 0; yy < sizey + 1; yy++)
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
	public class object_E2 : Room_Object
	{
		public object_E2(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xE2, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xE2];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(8, pos); // ??
			sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
		}

		public override void Draw()
		{
			base.Draw();

			int sizex = ((size >> 2) & 0x03);
			int sizey = ((size) & 0x03);

			for (int xx = 0; xx < sizex + 1; xx++)
			{
				for (int yy = 0; yy < sizey + 1; yy++)
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
	public class object_E3 : Room_Object
	{
		public object_E3(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xE3, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xE3];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(8, pos); // ??
			sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
		}

		public override void Draw()
		{
			base.Draw();

			int sizex = ((size >> 2) & 0x03);
			int sizey = ((size) & 0x03);

			for (int xx = 0; xx < sizex + 1; xx++)
			{
				for (int yy = 0; yy < sizey + 1; yy++)
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
	public class object_E4 : Room_Object
	{
		public object_E4(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xE4, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xE4];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(8, pos); // ??
			sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
		}

		public override void Draw()
		{
			base.Draw();
			int sizex = ((size >> 2) & 0x03);
			int sizey = ((size) & 0x03);

			for (int xx = 0; xx < sizex + 1; xx++)
			{
				for (int yy = 0; yy < sizey + 1; yy++)
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
	public class object_E5 : Room_Object
	{
		public object_E5(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xE5, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xE5];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(8, pos); // ??
			sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
		}

		public override void Draw()
		{
			base.Draw();

			int sizex = ((size >> 2) & 0x03);
			int sizey = ((size) & 0x03);

			for (int xx = 0; xx < sizex + 1; xx++)
			{
				for (int yy = 0; yy < sizey + 1; yy++)
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
	public class object_E6 : Room_Object
	{
		public object_E6(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xE6, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xE6];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(8, pos); // ??
			sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
		}

		public override void Draw()
		{
			base.Draw();

			int sizex = ((size >> 2) & 0x03);
			int sizey = ((size) & 0x03);

			for (int xx = 0; xx < sizex + 1; xx++)
			{
				for (int yy = 0; yy < sizey + 1; yy++)
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
	public class object_E7 : Room_Object
	{
		public object_E7(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xE7, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xE7];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(8, pos); // ??
			sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
		}

		public override void Draw()
		{
			base.Draw();

			int sizex = ((size >> 2) & 0x03);
			int sizey = ((size) & 0x03);

			for (int xx = 0; xx < sizex + 1; xx++)
			{
				for (int yy = 0; yy < sizey + 1; yy++)
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
	public class object_E8 : Room_Object
	{

		public object_E8(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xE8, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xE8];
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((id & 0xFF) * 2), 2];
			addTiles(8, pos); // ??
			sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
		}

		public override void Draw()
		{
			base.Draw();

			int sizex = ((size >> 2) & 0x03);
			int sizey = ((size) & 0x03);

			for (int xx = 0; xx < sizex + 1; xx++)
			{
				for (int yy = 0; yy < sizey + 1; yy++)
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
	public class object_E9 : Room_Object
	{
		public object_E9(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xE9, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xE9];
		}
	}

	[Serializable]
	public class object_EA : Room_Object
	{
		public object_EA(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xEA, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xEA];
		}
	}

	[Serializable]
	public class object_EB : Room_Object
	{
		public object_EB(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xEB, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xEB];
		}
	}

	[Serializable]
	public class object_EC : Room_Object
	{
		public object_EC(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xEC, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xEC];
		}
	}

	[Serializable]
	public class object_ED : Room_Object
	{
		public object_ED(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xED, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xED];
		}
	}

	[Serializable]
	public class object_EE : Room_Object
	{
		public object_EE(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xEE, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xEE];
		}
	}

	[Serializable]
	public class object_EF : Room_Object
	{
		public object_EF(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xEF, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xEF];
		}
	}

	[Serializable]
	public class object_F0 : Room_Object
	{
		public object_F0(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xF0, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xF0];
		}
	}

	[Serializable]
	public class object_F1 : Room_Object
	{
		public object_F1(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xF1, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xF1];
		}
	}

	[Serializable]
	public class object_F2 : Room_Object
	{
		public object_F2(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xF2, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xF2];
		}
	}

	[Serializable]
	public class object_F3 : Room_Object
	{
		public object_F3(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xF3, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xF3];
		}
	}

	[Serializable]
	public class object_F4 : Room_Object
	{
		public object_F4(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xF4, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xF4];
		}
	}

	[Serializable]
	public class object_F5 : Room_Object
	{
		public object_F5(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xF5, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xF5];
		}
	}

	[Serializable]
	public class object_F6 : Room_Object
	{
		public object_F6(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xF6, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xF6];
		}
	}

	[Serializable]
	public class object_F7 : Room_Object
	{
		public object_F7(byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, 0xF7, x, y, size, layer)
		{
			name = Constants.Type1RoomObjectNames[0xF7];
		}
	}

	[Serializable]
	public class object_Block : Room_Object
	{
		public object_Block(ushort id, byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, id, x, y, size, layer)
		{
			int pos = Constants.tile_address + ZS.ROM[Constants.subtype1_tiles + ((0x5E & 0xFF) * 2), 2];
			addTiles(4, pos);
			name = "Pushable Block"; // ID E00
			options = ObjectOption.Block;
		}

		public override void Draw()
		{
			base.Draw();

			for (int s = 0; s < size + 1; s++)
			{
				draw_tile(tiles[0], (0 + (s * 4)) * 8, (0) * 8); draw_tile(tiles[2], (1 + (s * 4)) * 8, (0) * 8);
				draw_tile(tiles[1], (0 + (s * 4)) * 8, (1) * 8); draw_tile(tiles[3], (1 + (s * 4)) * 8, (1) * 8);
			}
		}
	}
}
