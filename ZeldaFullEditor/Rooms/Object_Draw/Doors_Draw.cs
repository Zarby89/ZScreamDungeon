﻿using System;

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
    public class object_door : Room_Object {

		private byte dpos = 0;
		public byte door_pos {
			get => dpos;
			set {
				dpos = value;
				updateId();
			}
		}

		private byte ddir = 0;
		public byte door_dir {
			get => ddir;
			set {
				ddir = value;
				updateId();
			}
		}

		private byte dtype = 0;

        public byte door_type {
            get => dtype;
            set {
                dtype = value;
				updateId();
				FixLimitClass();
			}
        }


		public object_door(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            options |= ObjectOption.Door;
            dpos = (byte)((id & 0xF0) >> 3); //*2
            ddir = (byte)((id & 0x03));
            dtype = (byte)((id >> 8) & 0xFF);
            name = "Door";
            updateId();
			FixLimitClass();

		}

        public void updateId()
        {
            byte b1 = (byte)((dpos << 3) + ddir);
            id = (ushort)((dtype << 8) + b1);

		}

        private void FixLimitClass() {

            switch (door_type) {
				case 0x1C: // key doors
				case 0x26:
				case 0x1E:
				case 0x2E:
				case 0x28:
				case 0x32:
				case 0x30:
                case 0x20:
				case 0x22:
				case 0x24:
					LimitClass = DungeonLimits.SpecialDoors;
					break;

				case 0x44: // shutter doors
				case 0x18:
				case 0x36:
				case 0x38:
				case 0x48:
				case 0x4A:
					LimitClass = DungeonLimits.SpecialDoors;
					break;

                case 0x12: // exit mod
					LimitClass = DungeonLimits.ExitMods;
                    break;

                default:
					LimitClass = DungeonLimits.Doors;
                    break;
			}
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
            Layer = LayerType.BG3;
            //allBgs = true;
            tiles.Clear();
            DrawMirror();
            tiles.Clear();
            int address = 0;
            if (door_dir == 0) { address = Constants.door_gfx_up; }
            if (door_dir == 1) { address = Constants.door_gfx_down; }
            if (door_dir == 2) { address = Constants.door_gfx_left; }
            if (door_dir == 3) { address = Constants.door_gfx_right; }
            int pos = Constants.tile_address + (short)((ROM.DATA[(address + ((id >> 8) & 0xFF)) + 1] << 8) + ROM.DATA[address + ((id >> 8) & 0xFF)]);
            addTiles(12, pos); // ??

            int addresspos = 0;
            if (door_dir == 0) { addresspos = Constants.door_pos_up; }
            if (door_dir == 1) { addresspos = Constants.door_pos_down; }
            if (door_dir == 2) { addresspos = Constants.door_pos_left; }
            if (door_dir == 3) { addresspos = Constants.door_pos_right; }

            short posxy = (short)(((ROM.DATA[(addresspos + 1 + (door_pos))] << 8) + ROM.DATA[(addresspos + (door_pos))]) / 2);
            float n = (((float)posxy / 64) - (byte)(posxy / 64)) * 64;
            X = (byte)n;
            Y = (byte)(posxy / 64);


            int w = 0, h = 0;
            if (door_dir == 0 || door_dir == 1) // up / down
            {
                w = 4;
                h = 3;

				if (door_dir == 1) // If direction is down y+=1 ? why
                {
					Y += 1;
				}
			}

            else if (door_dir == 2 || door_dir == 3) // left / right
            {
                h = 4;
                w = 3;

				if (door_dir == 3)
                {
					X += 1;
				}
			}

            // 0x26,0x40,0x46,0x0C
            if (dtype == 0x26 || dtype == 0x40 || dtype == 0x46 || dtype == 0x0C)
            {
                Layer = LayerType.BG2;
            }
            else if (dtype == 22 || dtype == 18)
            {

                //tiles.Clear();
                //addTiles(12, 0);//??
                width = w * 8;
                height = h * 8;
                nx = X;
                ny = Y;
                ox = X;
                oy = Y;
                return;
            }
            else if (dtype == 0x0E)
            {
                tiles.Clear();
                addTiles(16, Constants.tile_address + 0x26F6);
                w = 4;
                h = 4;
                Y -= 1;
            }
            int tid = 0;

            if (dtype == 0x0A)
            {
                tiles.Clear();
                addTiles(80, Constants.tile_address + 0x2656);
                w = 10;
                h = 8;
                X -= 3;
                Y -= 5;
                nx = X;
                ny = Y;
                ox = X;
                oy = Y;
                for (int yy = 0; yy < h; yy++)
                {
                    for (int xx = 0; xx < w; xx++)
                    {
                        draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                        tid++;
                    }
                }
                return;
            }

            if (dtype == 0x30) // Hole in wall
            {
                if (door_pos == 0)
                {
                    X = 5;
                    Y = 33;
                }
                else if (door_pos == 2)
                {
                    X = 21;
                    Y = 33;
                }
                else if (door_pos == 4)
                {
                    X = 37;
                    Y = 33;
                }

                // Only valid position are 0,1,2
                tiles.Clear();
                addTiles(6, Constants.tile_address + 0x2BE8);
                addTiles(6, 0x1B5E + 0x2926);
                nx = X;
                ny = Y;
                ox = X;
                oy = Y;
                h = 6;
                w = 0x12;

                // Left Side tiles

                for (int yy = 5; yy >= 0; yy--)
                {
                    tiles[tid].VFlip = false;
                    tiles[tid].HFlip = false;
                    draw_tile(tiles[tid], 0 * 8, yy * 8);
                    tid++;
                }
                for (int yy = 5; yy >= 0; yy--)
                {
                    tiles[tid].VFlip = false;
                    tiles[tid].HFlip = false;
                    draw_tile(tiles[tid], 1 * 8, yy * 8);
                    tid++;
                }

                tid = 0;

                // Rigt Side Tiles (Must mirror them)
                for (int yy = 5; yy >= 0; yy--)
                {
                    tiles[tid].VFlip = false;
                    tiles[tid].HFlip = true;
                    draw_tile(tiles[tid], 21 * 8, yy * 8);
                    tid++;
                }
                for (int yy = 5; yy >= 0; yy--)
                {
                    tiles[tid].VFlip = false;
                    tiles[tid].HFlip = true;
                    draw_tile(tiles[tid], 20 * 8, yy * 8);
                    tid++;
                }

                // Draw Top Mirror
                tid = 11;
                // Left Side tiles
                for (int yy = 5; yy >= 0; yy--)
                {
                    tiles[tid].VFlip = true;
                    tiles[tid].HFlip = false;
                    draw_tile(tiles[tid], 1 * 8, (yy - 6) * 8);
                    tid--;
                }
                for (int yy = 5; yy >= 0; yy--)
                {
                    tiles[tid].VFlip = true;
                    tiles[tid].HFlip = false;
                    draw_tile(tiles[tid], 0 * 8, (yy - 6) * 8);
                    tid--;
                }
                tid = 11;
                for (int yy = 5; yy >= 0; yy--)
                {
                    tiles[tid].VFlip = false;
                    tiles[tid].HFlip = true;
                    draw_tile(tiles[tid], 20 * 8, (yy - 6) * 8);
                    tid--;
                }
                for (int yy = 5; yy >= 0; yy--)
                {
                    tiles[tid].VFlip = false;
                    tiles[tid].HFlip = true;
                    draw_tile(tiles[tid], 21 * 8, (yy - 6) * 8);
                    tid--;
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

            if (dtype == 0x32)
            {
                tiles.Clear();
                addTiles(16, Constants.tile_address + 0x078A);
                nx = X;
                ny = Y;
                ox = X;
                oy = Y;
                h = 4;
                w = 4;
            }
            if (dtype == 0x09)
            {
                return;
            }

            // 078A
            nx = X;
            ny = Y;
            ox = X;
            oy = Y;

            for (int xx = 0; xx < w; xx++)
            {
                for (int yy = 0; yy < h; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

            Layer = LayerType.BG3;

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
            if (door_dir == 1) { return; }
            if (door_dir == 2) { address = Constants.door_gfx_right; }
            if (door_dir == 3) { return; }
            int pos = Constants.tile_address + (short)((ROM.DATA[(address + ((id >> 8) & 0xFF)) + 1] << 8) + ROM.DATA[address + ((id >> 8) & 0xFF)]);
            addTiles(12, pos);//??

            int addresspos = 0;
            if (door_dir == 0) { addresspos = Constants.door_pos_down; }
            if (door_dir == 1) { return; }
            if (door_dir == 2) { addresspos = Constants.door_pos_right; }
            if (door_dir == 3) { return; }

            byte tempPos = (byte)(door_pos - 12);
            short posxy = (short)(((ROM.DATA[(addresspos + 1 + (tempPos))] << 8) + ROM.DATA[(addresspos + (tempPos))]) / 2);
            float n = (((float)posxy / 64) - (byte)(posxy / 64)) * 64;
            X = (byte)n;
            Y = (byte)(posxy / 64);

            int w = 0, h = 0;
            if (door_dir == 0 || door_dir == 1) // up / down
            {
                w = 4;
                h = 3;
            }
            if (door_dir == 0) // If direction is down y+=1 ? why
            {
                Y += 1;
            }

            else if (door_dir == 2 || door_dir == 3) // left / right
            {
                h = 4;
                w = 3;
            }
            if (door_dir == 2)
            {
                X += 1;
            }
            if (dtype == 22 || dtype == 18)
            {
                tiles.Clear();
                addTiles(12, 0); // ??
            }
            if (dtype == 0x0E)
            {
                tiles.Clear();
                addTiles(16, Constants.tile_address + 0x26F6);
                w = 4;
                h = 4;
                Y -= 1;
            }

            int tid = 0;
            if (dtype == 0x0A)
            {
                tiles.Clear();
                addTiles(80, Constants.tile_address + 0x2656);
                w = 10;
                h = 8;
                X -= 3;
                Y -= 5;
                nx = X;
                ny = Y;
                ox = X;
                oy = Y;

                for (int yy = 0; yy < h; yy++)
                {
                    for (int xx = 0; xx < w; xx++)
                    {
                        draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                        tid++;
                    }
                }

                return;
            }

            if (dtype == 0x30) // Hole in wall
            {
                if (tempPos == 0)
                {
                    X = 5;
                    Y = 33;
                }
                if (tempPos == 2)
                {
                    X = 21;
                    Y = 33;
                }
                if (tempPos == 4)
                {
                    X = 37;
                    Y = 33;
                }

                // Only valid position are 0,1,2
                tiles.Clear();
                addTiles(6, Constants.tile_address + 0x2BE8);
                addTiles(6, 0x1B5E + 0x2926);
                nx = X;
                ny = Y;
                ox = X;
                oy = Y;
                h = 6;
                w = 0x12;

                // Left Side tiles
                for (int yy = 5; yy >= 0; yy--)
                {
                    tiles[tid].VFlip = false;
                    tiles[tid].HFlip = false;
                    draw_tile(tiles[tid], (0) * 8, (yy) * 8);
                    tid++;
                }
                for (int yy = 5; yy >= 0; yy--)
                {
                    tiles[tid].VFlip = false;
                    tiles[tid].HFlip = false;
                    draw_tile(tiles[tid], (1) * 8, (yy) * 8);
                    tid++;
                }

                tid = 0;
                // Rigt Side Tiles (Must mirror them)
                for (int yy = 5; yy >= 0; yy--)
                {
                    tiles[tid].VFlip = false;
                    tiles[tid].HFlip = true;
                    draw_tile(tiles[tid], (21) * 8, (yy) * 8);
                    tid++;
                }
                for (int yy = 5; yy >= 0; yy--)
                {
                    tiles[tid].VFlip = false;
                    tiles[tid].HFlip = true;
                    draw_tile(tiles[tid], (20) * 8, (yy) * 8);
                    tid++;
                }

                // Draw Top Mirror
                tid = 11;
                // Left Side tiles
                for (int yy = 5; yy >= 0; yy--)
                {
                    tiles[tid].VFlip = true;
                    tiles[tid].HFlip = false;
                    draw_tile(tiles[tid], (1) * 8, (yy - 6) * 8);
                    tid--;
                }
                for (int yy = 5; yy >= 0; yy--)
                {
                    tiles[tid].VFlip = true;
                    tiles[tid].HFlip = false;
                    draw_tile(tiles[tid], (0) * 8, (yy - 6) * 8);
                    tid--;
                }

                tid = 11;
                for (int yy = 5; yy >= 0; yy--)
                {
                    tiles[tid].VFlip = false;
                    tiles[tid].HFlip = true;
                    draw_tile(tiles[tid], (20) * 8, (yy - 6) * 8);
                    tid--;
                }
                for (int yy = 5; yy >= 0; yy--)
                {
                    tiles[tid].VFlip = false;
                    tiles[tid].HFlip = true;
                    draw_tile(tiles[tid], (21) * 8, (yy - 6) * 8);
                    tid--;
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

            if (dtype == 0x32)
            {
                tiles.Clear();
                addTiles(16, Constants.tile_address + 0x078A);
                nx = X;
                ny = Y;
                ox = X;
                oy = Y;
                h = 4;
                w = 4;
            }
            if (dtype == 0x09)
            {
                return;
            }

            // 078A
            nx = X;
            ny = Y;
            ox = X;
            oy = Y;

            for (int xx = 0; xx < w; xx++)
            {
                for (int yy = 0; yy < h; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

            // 26F6
        }
    }
}
