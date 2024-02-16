using System;

namespace ZeldaFullEditor
{
	[Serializable]
	public class PotItem
	{
		public byte x, y, id;
		public byte nx, ny;
		public bool selected = false;
		public byte layer = 0;
		public bool bg2 = false;
		public int uniqueID = 0;
		public PotItem(byte id, byte x, byte y, bool bg2)
		{
			this.id = id;
			this.x = x;
			this.y = y;
			this.nx = x;
			this.ny = y;
			this.bg2 = bg2;
			this.uniqueID = ROM.uniqueItemID++;
		}

		// Pots items
		public void Draw()
		{
			byte x = nx;
			byte y = ny;
			int id = this.id;
			if ((id & 0x80) == 0x80)
			{
				id = (byte) ((id - 0x80) / 2);
				id += 23;
			}

			if (id == 0)// Nothing
			{
				// draw_item_tile(x * 8, y * 8, 16, 16, 0x6C, 10, true);
			}
			else if (id == 1)// Rupee
			{
				draw_item_tile(x * 8 + 4, y * 8, 0, 828, 11, false, false, 1);
			}
			else if (id == 2) // Rock Crab
			{
				draw_item_tile(x * 8, y * 8, 10, 520, 5);
			}
			else if (id == 3) // Bee
			{
				drawSpriteTile((x * 8) + 4, (y * 8) + 4, 4, 14, 11, false, false, 1, 1);
			}
			else if (id == 4) // Random
			{
				//draw_item_tile(x*8+4, y*8+4, 8, 8);
			}
			else if (id == 5) // Bomb
			{
				draw_item_tile(x * 8 + 0, y * 8 + 0, 4, 824, 7);
			}
			else if (id == 6) // Rupee
			{
				draw_item_tile(x * 8 + 4, y * 8, 0, 828, 11, false, false, 1);
			}
			else if (id == 7) // Blue rupee
			{
				draw_item_tile(x * 8 + 4, y * 8, 0, 828, 7, false, false, 1);
			}
			else if (id == 8) // Key*8
			{
				draw_item_tile(x * 8 + 4, y * 8 + 0, 14, 822, 11, false, false, 1);
			}
			else if (id == 9) // Arrow
			{
				draw_item_tile(x * 8 + 4, y * 8, 8, 830, 11, false, false, 1);
			}
			else if (id == 10) // 1bomb
			{
				draw_item_tile(x * 8 + 0, y * 8 + 0, 4, 824, 7);
			}
			else if (id == 11) // Heart
			{
				draw_item_tile(x * 8 + 4, y * 8, 6, 830, 5, false, false, 1);
			}
			else if (id == 12) // Magic
			{
				draw_item_tile(x * 8 + 4, y * 8, 7, 830, 11, false, false, 1);
			}
			else if (id == 13) // Big magic - need gfx
			{
				draw_item_tile(x * 8 + 4, y * 8, 2, 466, 11, false, false, 1);
			}
			else if (id == 14) // Chicken 
			{
				drawSpriteTile((x * 8), (y * 8), 10, 30, 5);
			}
			else if (id == 15) // Green soldier
			{
				drawSpriteTile((x * 8), (y * 8), 0, 20, 12);
			}
			else if (id == 16) // Alive rock
			{
				draw_item_tile(x * 8, y * 8, 10, 520, 5);
			}
			else if (id == 17) // Blue soldier
			{
				drawSpriteTile((x * 8), (y * 8), 0, 20, 10);
			}
			else if (id == 18) // Ground bomb
			{
				draw_item_tile(x * 8, y * 8 + 4, 0, 467, 7, false, false, 1, 1);
				draw_item_tile(x * 8 + 8, y * 8 + 4, 0, 467, 7, true, false, 1, 1);
			}
			else if (id == 19) // Heart
			{
				draw_item_tile(x * 8 + 4, y * 8, 6, 830, 5, false, false, 1);
			}
			else if (id == 20) // Fairy*8
			{
				draw_item_tile(x * 8, y * 8, 10, 490, 10);
			}
			else if (id == 21) // Heart
			{
				draw_item_tile(x * 8 + 4, y * 8, 6, 830, 5, false, false, 1);
			}
			else if (id == 22) // Nothing
			{
				//draw_item_tile(x*8, y*8, 16, 16, 0x6C, 10, true);
			}
			else if (id == 23) // Hole
			{
				//draw_item_tile(x * 8, y * 8, 16, 16, 0x60, 9, false);
			}
			else if (id == 24) // Warp
			{
				draw_item_tile(x * 8, y * 8, 6, 832, 11);
			}
			else if (id == 25) // Staircase
			{
				// TODO: Add draw here?
			}
			else if (id == 26) // Bombale
			{
				// TODO: Add draw here?
			}
			else if (id == 27) // Switch
			{
				draw_item_tile(x * 8, y * 8, 11, 56, 5, false, false, 1);
			}
		}

		public unsafe void draw_item_tile(int x, int y, int srcx, int srcy, int pal, bool mirror_x = false, bool mirror_y = false, int sizex = 2, int sizey = 2)
		{
			var alltilesData = (byte*) GFX.allgfx16Ptr.ToPointer();
			byte* ptr = (byte*) GFX.roomBg1Ptr.ToPointer();

			int drawid = (srcx + (srcy * 16));
			for (var yl = 0; yl < sizey * 8; yl++)
			{
				for (var xl = 0; xl < (sizex * 8) / 2; xl++)
				{
					int mx = xl;
					int my = yl;
					byte r = 0;

					if (mirror_x)
					{
						mx = (((sizex * 8) / 2) - 1) - xl;
						r = 1;
					}
					if (mirror_y)
					{
						my = (((sizey * 8)) - 1) - yl;
					}

					// Formula information to get tile index position in the array
					//((ID / nbrofXtiles) * (imgwidth/2) + (ID - ((ID/16)*16) ))
					int tx = ((drawid / 16) * 512) + ((drawid - ((drawid / 16) * 16)) * 4);
					var pixel = alltilesData[tx + (yl * 64) + xl];
					//nx,ny = object position, xx,yy = tile position, xl,yl = pixel position

					int index = (x) + (y * 512) + ((mx * 2) + (my * (512)));
					if ((pixel & 0x0F) != 0)
					{
						ptr[index + r ^ 1] = (byte) ((pixel & 0x0F) + 112 + (pal * 8));
					}
					if (((pixel >> 4) & 0x0F) != 0)
					{
						ptr[index + r] = (byte) (((pixel >> 4) & 0x0F) + 112 + (pal * 8));
					}
				}
			}
		}

		public unsafe void drawSpriteTile(int x, int y, int srcx, int srcy, int pal, bool mirror_x = false, bool mirror_y = false, int sizex = 2, int sizey = 2, bool iskey = false)
		{
			var alltilesData = (byte*) GFX.currentgfx16Ptr.ToPointer();
			byte* ptr = (byte*) GFX.roomBg1Ptr.ToPointer();
			int drawid = (srcx + (srcy * 16)) + 512;
			for (var yl = 0; yl < sizey * 8; yl++)
			{
				for (var xl = 0; xl < (sizex * 8) / 2; xl++)
				{
					int mx = xl;
					int my = yl;
					byte r = 0;

					if (mirror_x)
					{
						mx = (((sizex * 8) / 2) - 1) - xl;
						r = 1;
					}
					if (mirror_y)
					{
						my = (((sizey * 8)) - 1) - yl;
					}

					// Formula information to get tile index position in the array
					//((ID / nbrofXtiles) * (imgwidth/2) + (ID - ((ID/16)*16) ))
					int tx = ((drawid / 16) * 512) + ((drawid - ((drawid / 16) * 16)) * 4);
					var pixel = alltilesData[tx + (yl * 64) + xl];
					//nx,ny = object position, xx,yy = tile position, xl,yl = pixel position
					int index = (x) + (y * 512) + ((mx * 2) + (my * (512)));

					if ((pixel & 0x0F) != 0)
					{
						ptr[index + r ^ 1] = (byte) ((pixel & 0x0F) + 112 + (pal * 8));
					}
					if (((pixel >> 4) & 0x0F) != 0)
					{
						ptr[index + r] = (byte) (((pixel >> 4) & 0x0F) + 112 + (pal * 8));
					}
				}
			}
		}
	}
}
