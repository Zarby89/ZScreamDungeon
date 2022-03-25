using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
	/*
     ALL THESE ARRAYS CONTAINS LOCATION IN TILEMAP SNES FORMAT TO WHERE TO DRAW DOOR ON SCREEN

     ALL PC ADDRESS

     doors are 4x3 up/down, 3x4 left/right

     X = position(0, 2, 4, ..., 24)

     Door_Up
    */

	[Serializable]
	public class object_door : Room_Object
	{
		public byte door_pos = 0;
		public byte door_dir = 0;
		public byte door_type = 0;

		public object_door(ushort id, byte x, byte y, byte size, byte layer, ZScreamer parent) : base(parent, id, x, y, size, layer)
		{
			options |= ObjectOption.Door;
			door_pos = (byte) ((id & 0xF0) >> 3); //*2
			door_dir = (byte) (id & 0x03);
			door_type = (byte) (id >> 8);
			name = "Door";
		}

		public void updateId()
		{
			byte b1 = (byte) ((door_pos << 3) + door_dir);
			byte b2 = door_type;
			id = (ushort) ((b2 << 8) | b1);
		}

		/* 
        public void setDoorDir(byte dir)
        {
            id = (short)((id & 0xFFFC)+dir);
            door_dir = dir;
        }

        public void setDoorPos(byte pos)
        {
            door_pos = pos;
            id = (short)(id | (short)(pos << 4));
        }
        */

		public override void Draw()
		{
			layer = 2;
			//allBgs = true;
			tiles.Clear();
			DrawMirror();
			tiles.Clear();
			int address = 0;
			if (door_dir == 0) { address = Constants.door_gfx_up; }
			if (door_dir == 1) { address = Constants.door_gfx_down; }
			if (door_dir == 2) { address = Constants.door_gfx_left; }
			if (door_dir == 3) { address = Constants.door_gfx_right; }
			int pos = Constants.tile_address + ZS.ROM[address + (id >> 8), 2];
			addTiles(12, pos); // ??

			int addresspos = 0;
			if (door_dir == 0) { addresspos = Constants.door_pos_up; }
			if (door_dir == 1) { addresspos = Constants.door_pos_down; }
			if (door_dir == 2) { addresspos = Constants.door_pos_left; }
			if (door_dir == 3) { addresspos = Constants.door_pos_right; }

			ushort posxy = (ushort) (ZS.ROM[addresspos + door_pos, 2] / 2);
			float n = (((float) posxy / 64) - (byte) (posxy / 64)) * 64;
			x = (byte) n;
			y = (byte) (posxy / 64);


			int w = 0, h = 0;
			if (door_dir == 0 || door_dir == 1) // up / down
			{
				w = 4;
				h = 3;
				if (door_dir == 1) // If direction is down y+=1 ? why
				{
					y += 1;
				}
			}
			else if (door_dir == 2 || door_dir == 3) // left / right
			{
				h = 4;
				w = 3;
				if (door_dir == 3)
				{
					x += 1;
				}
			}


			// TODO oh my fuck
			// 0x26,0x40,0x46,0x0C
			if ((((id >> 8) & 0xFF) == 0x26) || (((id >> 8) & 0xFF) == 0x40) || (((id >> 8) & 0xFF) == 0x46) || (((id >> 8) & 0xFF) == 0x0C))
			{
				layer = 1;
			}
			if ((((id >> 8) & 0xFF) == 22) || (((id >> 8) & 0xFF) == 18))
			{

				//tiles.Clear();
				//addTiles(12, 0);//??
				width = w * 8;
				height = h * 8;
				nx = x;
				ny = y;
				ox = x;
				oy = y;
				return;
			}
			if ((((id >> 8) & 0xFF) == 0x0E))
			{
				tiles.Clear();
				addTiles(16, Constants.tile_address + 0x26F6);
				w = 4;
				h = 4;
				y -= 1;
			}
			int tid = 0;

			if ((((id >> 8) & 0xFF) == 0x0A))
			{
				tiles.Clear();
				addTiles(80, Constants.tile_address + 0x2656);
				w = 10;
				h = 8;
				x -= 3;
				y -= 5;
				nx = x;
				ny = y;
				ox = x;
				oy = y;
				for (int yy = 0; yy < h; yy++)
				{
					for (int xx = 0; xx < w; xx++)
					{
						draw_tile(tiles[tid++], xx * 8, yy * 8);
					}
				}
				return;
			}

			if (((id >> 8) & 0xFF) == 0x30) // Hole in wall
			{
				if (door_pos == 0)
				{
					x = 5;
					y = 33;
				}
				if (door_pos == 2)
				{
					x = 21;
					y = 33;
				}
				if (door_pos == 4)
				{
					x = 37;
					y = 33;
				}

				// Only valid position are 0,1,2
				tiles.Clear();
				addTiles(6, Constants.tile_address + 0x2BE8);
				addTiles(6, 0x1B5E + 0x2926);
				nx = x;
				ny = y;
				ox = x;
				oy = y;
				h = 6;
				w = 0x12;

				// Left Side tiles

				for (int yy = 5; yy >= 0; yy--)
				{
					tiles[tid].VFlip = false;
					tiles[tid].HFlip = false;
					draw_tile(tiles[tid++], 0 * 8, yy * 8);
				}
				for (int yy = 5; yy >= 0; yy--)
				{
					tiles[tid].VFlip = false;
					tiles[tid].HFlip = false;
					draw_tile(tiles[tid++], 1 * 8, yy * 8);
				}

				tid = 0;

				// Rigt Side Tiles (Must mirror them)
				for (int yy = 5; yy >= 0; yy--)
				{
					tiles[tid].VFlip = false;
					tiles[tid].HFlip = true;
					draw_tile(tiles[tid++], 21 * 8, yy * 8);
				}
				for (int yy = 5; yy >= 0; yy--)
				{
					tiles[tid].VFlip = false;
					tiles[tid].HFlip = true;
					draw_tile(tiles[tid++], 20 * 8, yy * 8);
				}

				// Draw Top Mirror
				tid = 11;
				// Left Side tiles
				for (int yy = 5; yy >= 0; yy--)
				{
					tiles[tid].VFlip = true;
					tiles[tid].HFlip = false;
					draw_tile(tiles[tid--], 1 * 8, (yy - 6) * 8);
				}
				for (int yy = 5; yy >= 0; yy--)
				{
					tiles[tid].VFlip = true;
					tiles[tid].HFlip = false;
					draw_tile(tiles[tid--], 0 * 8, (yy - 6) * 8);
				}
				tid = 11;
				for (int yy = 5; yy >= 0; yy--)
				{
					tiles[tid].VFlip = false;
					tiles[tid].HFlip = true;
					draw_tile(tiles[tid--], 20 * 8, (yy - 6) * 8);
				}
				for (int yy = 5; yy >= 0; yy--)
				{
					tiles[tid].VFlip = false;
					tiles[tid].HFlip = true;
					draw_tile(tiles[tid--], 21 * 8, (yy - 6) * 8);
				}

				tiles.Clear();
				addTiles(1, Constants.tile_address + 0x293E);
				tid = 0;

				// Middle ground
				for (int xx = 0; xx < w; xx++)
				{
					for (int yy = 0; yy < h * 2; yy++) // FAcePALM
					{
						draw_tile(tiles[tid], (xx + 2) * 8, (yy - 6) * 8); // ??
					}
				}

				return;
			}

			if ((((id >> 8) & 0xFF) == 0x32))
			{
				tiles.Clear();
				addTiles(16, Constants.tile_address + 0x078A);
				nx = x;
				ny = y;
				ox = x;
				oy = y;
				h = 4;
				w = 4;
			}
			if ((((id >> 8) & 0xFF) == 0x09))
			{
				return;
			}

			// 078A
			nx = x;
			ny = y;
			ox = x;
			oy = y;

			for (int xx = 0; xx < w; xx++)
			{
				for (int yy = 0; yy < h; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}
			layer = 2;

			// 26F6
		}

		public void DrawMirror()
		{
			if (door_pos >= 12 && door_pos <= 24)
			{
				// TODO: Add condition here?
			}
			else
			{
				return;
			}

			tiles.Clear();
			int address = 0;
			if (door_dir == 0) { address = Constants.door_gfx_down; }
			else if (door_dir == 1) { return; }
			else if (door_dir == 2) { address = Constants.door_gfx_right; }
			else if (door_dir == 3) { return; }
			int pos = Constants.tile_address + ZS.ROM[address + ((id >> 8) & 0xFF), 2];
			addTiles(12, pos);//??

			int addresspos = 0;
			if (door_dir == 0) { addresspos = Constants.door_pos_down; }
			else if (door_dir == 1) { return; }
			else if (door_dir == 2) { addresspos = Constants.door_pos_right; }
			else if (door_dir == 3) { return; }

			byte tempPos = (byte) (door_pos - 12);
			ushort posxy = (ushort) (ZS.ROM[addresspos + tempPos, 2] / 2);
			float n = (((float) posxy / 64) - (byte) (posxy / 64)) * 64;
			x = (byte) n;
			y = (byte) (posxy / 64);

			int w = 0, h = 0;
			if (door_dir == 0 || door_dir == 1) // up / down
			{
				w = 4;
				h = 3;
			}
			if (door_dir == 0) // If direction is down y+=1 ? why
			{
				y++;
			}

			else if (door_dir == 2 || door_dir == 3) // left / right
			{
				h = 4;
				w = 3;
			}
			if (door_dir == 2)
			{
				x++;
			}
			if ((((id >> 8) & 0xFF) == 22) || (((id >> 8) & 0xFF) == 18))
			{
				tiles.Clear();
				addTiles(12, 0); // ??
			}
			if ((((id >> 8) & 0xFF) == 0x0E))
			{
				tiles.Clear();
				addTiles(16, Constants.tile_address + 0x26F6);
				w = 4;
				h = 4;
				y--;
			}

			int tid = 0;
			if ((((id >> 8) & 0xFF) == 0x0A))
			{
				tiles.Clear();
				addTiles(80, Constants.tile_address + 0x2656);
				w = 10;
				h = 8;
				x -= 3;
				y -= 5;
				nx = x;
				ny = y;
				ox = x;
				oy = y;

				for (int yy = 0; yy < h; yy++)
				{
					for (int xx = 0; xx < w; xx++)
					{
						draw_tile(tiles[tid++], xx * 8, yy * 8);
					}
				}

				return;
			}

			if ((((id >> 8) & 0xFF) == 0x30)) // Hole in wall
			{
				if (tempPos == 0)
				{
					x = 5;
					y = 33;
				}
				if (tempPos == 2)
				{
					x = 21;
					y = 33;
				}
				if (tempPos == 4)
				{
					x = 37;
					y = 33;
				}

				// Only valid position are 0,1,2
				tiles.Clear();
				addTiles(6, Constants.tile_address + 0x2BE8);
				addTiles(6, 0x1B5E + 0x2926);
				nx = x;
				ny = y;
				ox = x;
				oy = y;
				h = 6;
				w = 0x12;

				// Left Side tiles
				for (int yy = 5; yy >= 0; yy--)
				{
					tiles[tid].VFlip = false;
					tiles[tid].HFlip = false;
					draw_tile(tiles[tid++], 0 * 8, yy * 8);
				}
				for (int yy = 5; yy >= 0; yy--)
				{
					tiles[tid].VFlip = false;
					tiles[tid].HFlip = false;
					draw_tile(tiles[tid++], 1 * 8, yy * 8);
				}

				tid = 0;
				// Rigt Side Tiles (Must mirror them)
				for (int yy = 5; yy >= 0; yy--)
				{
					tiles[tid].VFlip = false;
					tiles[tid].HFlip = true;
					draw_tile(tiles[tid++], 21 * 8, yy * 8);
				}
				for (int yy = 5; yy >= 0; yy--)
				{
					tiles[tid].VFlip = false;
					tiles[tid].HFlip = true;
					draw_tile(tiles[tid++], 20 * 8, yy * 8);
				}

				// Draw Top Mirror
				tid = 11;
				// Left Side tiles
				for (int yy = 5; yy >= 0; yy--)
				{
					tiles[tid].VFlip = true;
					tiles[tid].HFlip = false;
					draw_tile(tiles[tid--], 1 * 8, (yy - 6) * 8);
				}
				for (int yy = 5; yy >= 0; yy--)
				{
					tiles[tid].VFlip = true;
					tiles[tid].HFlip = false;
					draw_tile(tiles[tid--], 0 * 8, (yy - 6) * 8);
				}

				tid = 11;
				for (int yy = 5; yy >= 0; yy--)
				{
					tiles[tid].VFlip = false;
					tiles[tid].HFlip = true;
					draw_tile(tiles[tid--], 20 * 8, (yy - 6) * 8);
				}
				for (int yy = 5; yy >= 0; yy--)
				{
					tiles[tid].VFlip = false;
					tiles[tid].HFlip = true;
					draw_tile(tiles[tid--], 21 * 8, (yy - 6) * 8);
				}

				tiles.Clear();
				addTiles(1, Constants.tile_address + 0x293E);
				tid = 0;

				// Middle ground
				for (int xx = 0; xx < w; xx++)
				{
					for (int yy = 0; yy < h * 2; yy++) // FAcePALM
					{
						draw_tile(tiles[tid], (xx + 2) * 8, (yy - 6) * 8); // ??
					}
				}

				return;
			}

			if ((((id >> 8) & 0xFF) == 0x32))
			{
				tiles.Clear();
				addTiles(16, Constants.tile_address + 0x078A);
				nx = x;
				ny = y;
				ox = x;
				oy = y;
				h = 4;
				w = 4;
			}
			if ((((id >> 8) & 0xFF) == 0x09))
			{
				return;
			}

			// 078A
			nx = x;
			ny = y;
			ox = x;
			oy = y;

			for (int xx = 0; xx < w; xx++)
			{
				for (int yy = 0; yy < h; yy++)
				{
					draw_tile(tiles[tid++], xx * 8, yy * 8);
				}
			}

			// 26F6
		}
	}
}
