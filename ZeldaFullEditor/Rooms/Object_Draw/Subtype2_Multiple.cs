using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
/*
	[Serializable]
	public class Subtype2_Multiple : Room_Object
	{
		public int tx = 0;
		public int ty = 0;

		public Subtype2_Multiple(ushort id, byte x, byte y, byte size, byte layer, ZScreamer zs) : base(zs, id, x, y, size, layer)
		{
			byte oid = (byte) id;

			switch (oid)
			{
				case 0x00:
					setData(4, 4);
					sort = Sorting.Wall | Sorting.NonScalable;
					break;

				case 0x01:
					setData(4, 4);
					sort = Sorting.Wall | Sorting.NonScalable;
					break;

				case 0x02:
					setData(4, 4);
					sort = Sorting.Wall | Sorting.NonScalable;
					break;

				case 0x03:
					setData(4, 4);
					sort = Sorting.Wall | Sorting.NonScalable;
					break;

				case 0x04:
					setData(4, 4);
					sort = Sorting.Wall | Sorting.NonScalable;
					break;

				case 0x05:
					setData(4, 4);
					sort = Sorting.Wall | Sorting.NonScalable;
					break;

				case 0x06:
					setData(4, 4);
					sort = Sorting.Wall | Sorting.NonScalable;
					break;

				case 0x07:
					setData(4, 4);
					sort = Sorting.Wall | Sorting.NonScalable;
					break;

				case 0x08:
					setData(4, 4, true);
					sort = Sorting.Wall | Sorting.NonScalable;
					break;

				case 0x09:
					setData(4, 4, true);
					sort = Sorting.Wall | Sorting.NonScalable;
					break;

				case 0x0A:
					setData(4, 4, true);
					sort = Sorting.Wall | Sorting.NonScalable;
					break;

				case 0x0B:
					setData(4, 4, true);
					sort = Sorting.Wall | Sorting.NonScalable;
					break;

				case 0x0D:
					setData(4, 4, true);
					sort = Sorting.Wall | Sorting.NonScalable;
					break;

				case 0x0C:
					setData(4, 4, true);
					sort = Sorting.Wall | Sorting.NonScalable;
					break;

				case 0x0E:
					setData(4, 4, true);
					sort = Sorting.Wall | Sorting.NonScalable;
					break;

				case 0x0F:
					setData(4, 4, true);
					sort = Sorting.Wall | Sorting.NonScalable;
					break;

				case 0x10:
					setData(3, 4, true);
					sort = Sorting.Wall | Sorting.NonScalable;
					break;

				case 0x11:
					setData(3, 4, true);
					sort = Sorting.Wall | Sorting.NonScalable;
					break;

				case 0x12:
					setData(3, 4, true);
					sort = Sorting.Wall | Sorting.NonScalable;
					break;

				case 0x13:
					setData(3, 4, true);
					sort = Sorting.Wall | Sorting.NonScalable;
					break;

				case 0x14:
					setData(4, 3, true);
					sort = Sorting.Wall | Sorting.NonScalable;
					break;

				case 0x15:
					setData(4, 3, true);
					sort = Sorting.Wall | Sorting.NonScalable;
					break;

				case 0x16:
					setData(4, 3, true);
					sort = Sorting.Wall | Sorting.NonScalable;
					break;

				case 0x17:
					setData(4, 3, true);
					sort = Sorting.Wall | Sorting.NonScalable;
					break;

				case 0x18:
					setData(2, 2);
					sort = Sorting.Wall | Sorting.NonScalable;
					break;

				case 0x19:
					setData(2, 2);
					sort = Sorting.Wall | Sorting.NonScalable;
					break;

				case 0x1A:
					setData(2, 2);
					sort = Sorting.Wall | Sorting.NonScalable;
					break;

				case 0x1B:
					setData(2, 2);
					sort = Sorting.Wall | Sorting.NonScalable;
					break;

				case 0x1C:
					setData(4, 4);
					sort = Sorting.Dungeons | Sorting.NonScalable;
					break;

				case 0x1D:
					setData(2, 3);
					sort = Sorting.Dungeons | Sorting.NonScalable;
					break;

				case 0x1E:
					setData(2, 2);
					sort = Sorting.Dungeons | Sorting.NonScalable;
					break;

				case 0x1F:
					setData(2, 2);
					sort = Sorting.Dungeons | Sorting.NonScalable;
					break;

				case 0x20:
					setData(2, 2);
					sort = Sorting.Dungeons | Sorting.NonScalable;
					break;

				case 0x21:
					setData(2, 3);
					sort = Sorting.NonScalable;
					break;

				case 0x22:
					setData(4, 5);
					sort = Sorting.NonScalable;
					break;

				case 0x23:
					setData(4, 3);
					sort = Sorting.NonScalable;
					break;

				case 0x24:
					setData(4, 4);
					sort = Sorting.NonScalable;
					break;

				case 0x25:
					setData(4, 4);
					sort = Sorting.NonScalable;
					break;

				case 0x26:
					setData(2, 3);
					sort = Sorting.NonScalable;
					break;

				case 0x27:
					setData(2, 2);
					sort = Sorting.NonScalable;
					break;

				case 0x28:
					setData(4, 5);
					sort = Sorting.NonScalable;
					break;

				case 0x29:
					setData(4, 4);
					sort = Sorting.NonScalable;
					break;

				case 0x2A:
					setData(4, 2);
					sort = Sorting.NonScalable;
					break;

				case 0x2B:
					setData(2, 2);
					sort = Sorting.NonScalable;
					break;

				case 0x2C:
					setData(6, 3);
					sort = Sorting.NonScalable;
					break;

				case 0x2D:
					setData(4, 4);
					sort = Sorting.Stairs | Sorting.NonScalable;
					break;

				case 0x2E:
					setData(4, 4);
					sort = Sorting.Stairs | Sorting.NonScalable;
					break;

				case 0x2F:
					setData(4, 4);
					sort = Sorting.Stairs | Sorting.NonScalable;
					break;

				case 0x30:
					setData(4, 4, true);
					sort = Sorting.Stairs | Sorting.NonScalable;
					break;

				case 0x31:
					setData(4, 4, true);
					sort = Sorting.Stairs | Sorting.NonScalable;
					break;

				case 0x32:
					setData(4, 4);
					sort = Sorting.Stairs | Sorting.NonScalable;
					break;

				case 0x33:
					setData(4, 4);
					sort = Sorting.Stairs | Sorting.NonScalable;
					break;

				case 0x34:
					setData(2, 2);
					sort = Sorting.NonScalable;
					break;

				case 0x35:
					setData(4, 2);
					sort = Sorting.Stairs | Sorting.NonScalable;
					break;

				case 0x36:
					setData(4, 2, true);
					sort = Sorting.Stairs | Sorting.NonScalable;
					break;

				case 0x37:
					setData(10, 4);
					sort = Sorting.NonScalable;
					break;

				case 0x38:
					setData(4, 3);
					sort = Sorting.Stairs | Sorting.NonScalable;
					break;

				case 0x39:
					setData(4, 3);
					sort = Sorting.Stairs | Sorting.NonScalable;
					break;

				case 0x3A:
					setData(4, 3);
					sort = Sorting.Stairs | Sorting.NonScalable;
					break;

				case 0x3B:
					setData(4, 3);
					sort = Sorting.Stairs | Sorting.NonScalable;
					break;

				case 0x3C:
					setData(4, 6);
					sort = Sorting.NonScalable;
					break;

				case 0x3D:
					setData(4, 3);
					sort = Sorting.NonScalable;
					break;

				case 0x3E:
					setData(6, 3);
					sort = Sorting.NonScalable;
					break;

				case 0x3F:
					setData(8, 7);
					sort = Sorting.NonScalable;
					break;

				case 0x50: // Special object id doesnt matter (Torches)
						   //setdata("Torch", 2, 2);
					tiles.Add(new Tile(480, 3, false, false, false));
					tiles.Add(new Tile(496, 3, false, false, false));
					tiles.Add(new Tile(480, 3, false, true, false));
					tiles.Add(new Tile(496, 3, false, true, false));
					options |= ObjectOption.Torch;
					this.name = "Torch";
					tx = 2;
					ty = 2;
					break;

				default:
					// TODO: should we handle this?
					break;
			}
		}

		public override void Draw()
		{
			base.Draw();

			byte oid = (byte) id;
			if (oid == 0x3C)
			{
				// Collumn
				for (int i = 0; i < 2; i++)
				{
					for (int xx = 0; xx < 2; xx++)
					{
						for (int yy = 0; yy < 6; yy++)
						{
							//tiles[yy].HFlip = xx.BitIsOn(0x01);
							//tiles[yy + 6].HFlip = xx.BitIsOn(0x01);
							draw_tile(tiles[yy], ((xx + (i * 14))) * 8, yy * 8);
							draw_tile(tiles[yy + 6], (((xx + (i * 14) + 2))) * 8, yy * 8);

							draw_tile(tiles[yy], ((xx + (i * 14) + 4)) * 8, yy * 8);
							draw_tile(tiles[yy + 6], (((xx + (i * 14) + 6))) * 8, yy * 8);

							draw_tile(tiles[yy], ((xx + (i * 14) + 8)) * 8, yy * 8);
						}
					}
				}

				int tid = 12;
				for (int xx = 0; xx < 4; xx++)
				{
					for (int yy = 0; yy < 3; yy++)
					{
						draw_tile(tiles[tid++], (xx + 10) * 8, yy * 8);
					}
				}

				return;
			}

			if (oid == 0x28 || oid == 0x35 || oid == 0x36 || oid == 0x2A)
			{
				// Bed ? WTF WHY THIS IS REVERSED...
				int tid = 0;
				for (int yy = 0; yy < ty; yy++)
				{
					for (int xx = 0; xx < tx; xx++)
					{
						draw_tile(tiles[tid++], xx * 8, yy * 8);
					}
				}
			}
			else
			{
				int tid = 0;
				for (int xx = 0; xx < tx; xx++)
				{
					for (int yy = 0; yy < ty; yy++)
					{
						draw_tile(tiles[tid++], xx * 8, yy * 8);
					}
				}
			}
		}

		public void setData(int tx, int ty, bool allbg = false)
		{
			int pos = ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subtype2TileDataPointers + ((id & 0xFF) * 2), 2];
			addTiles(tx * ty, pos);
			name = Data.DefaultEntities.ListOfSet1RoomObjects[id & 0xFF].Name;
			this.tx = tx;
			this.ty = ty;
			this.allBgs = allbg;
		}
	}
*/
}
