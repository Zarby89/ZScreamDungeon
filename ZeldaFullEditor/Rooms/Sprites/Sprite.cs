using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
//	[Serializable]
//	public class Sprite
//	{
//		public byte x, y, id;
//		public byte nx, ny;
//		public byte layer = 0;
//		public byte subtype = 0;
//		public byte overlord = 0;
//		public string name;
//		public byte keyDrop = 0;
//		public int sizeMap = 512;
//		bool overworld = false;
//		public bool preview = false;
//		public byte mapid = 0;
//		public int map_x = 0;
//		public int map_y = 0;
//		readonly Room room;
//		public ushort roomid = 0;
//		public Rectangle boundingbox;
//		bool picker = false;
//		public bool selected = false;
//
//		int lowerX = 32;
//		int lowerY = 32;
//		int higherX = 0;
//		int higherY = 0;
//		int width = 16;
//		int height = 16;
//
//		private readonly ZScreamer ZS;
//		public Sprite(Room room, byte id, byte x, byte y, byte subtype, byte layer)
//		{
//			ZS = room.Screamer;
//			this.id = id;
//			this.x = x;
//			this.y = y;
//			this.room = room;
//			this.subtype = subtype;
//			this.layer = layer;
//			this.nx = x;
//			this.ny = y;
//			this.name = Sprites_Names.name[id];
//
//			if (subtype.BitsAllSet(0x07))
//			{
//				if (id > 0 && id <= 0x19)
//				{
//					this.name = Sprites_Names.overlordnames[id - 1];
//				}
//			}
//
//			this.roomid = (ushort) room.index;
//		}
//
//		public Sprite(byte mapid, byte id, byte x, byte y, int map_x, int map_y)
//		{
//			overworld = true;
//			this.mapid = mapid;
//			this.id = id;
//			this.x = x;
//			this.y = y;
//			this.nx = x;
//			this.ny = y;
//			this.name = Sprites_Names.name[id];
//			this.map_x = map_x;
//			this.map_y = map_y;
//		}
//
//		public void updateBBox()
//		{
//			lowerX = 1;
//			lowerY = 1;
//			higherX = 15;
//			higherY = 15;
//		}
//
//		public void DrawKey(bool bigKey)
//		{
//			int dx = (boundingbox.X + boundingbox.Width / 2) - 8;
//			int dy = boundingbox.Y - 10;
//
//			if (bigKey)
//			{
//				draw_item_tile(dx, dy, 14, 826, 11);
//			}
//			else
//			{
//				draw_item_tile(dx + 4, dy, 14, 822, 11, false, false, 1);
//			}
//		}
//
//		public void Draw(bool picker = false)
//		{
//
//			int x = 16 * nx;
//			int y = 16 * ny;
//			this.picker = picker;
//
//			if (overlord == 0x07)
//			{
//				if (id == 0x1A)
//				{
//					drawSpriteTile(x, y, 14, 6, 11);//bomb
//				}
//				else if (id == 0x05)
//				{
//					drawSpriteTile(x, y - 12, 12, 16, 12, false, true);
//					drawSpriteTile(x, y, 0, 16, 12, false, true);
//				}
//				else if (id == 0x06)
//				{
//					drawSpriteTile(x, y, 10, 26, 14, true, true, 2, 2);//snek
//				}
//				else if (id == 0x09)
//				{
//					drawSpriteTile(x, y, 6, 26, 14);
//					drawSpriteTile(x + 8, y + 8, 8, 26, 14);
//					drawSpriteTile(x, y + 16, 10, 27, 14, false, false, 1, 1);
//				}
//				else if (id == 0x14)
//				{
//					drawSpriteTile(x, y + 8, 12, 06, 12, false, false, 2, 1);//shadow tile
//					drawSpriteTile(x, y - 8, 3, 29, 8, false, false, 1, 1);//tile
//					drawSpriteTile(x + 8, y - 8, 3, 29, 8, true, false, 1, 1);//tile
//					drawSpriteTile(x, y, 3, 29, 8, false, true, 1, 1);//tile
//					drawSpriteTile(x + 8, y, 3, 29, 8, true, true, 1, 1);//tile
//				}
//				else
//				{
//					drawSpriteTile(x, y, 4, 4, 5);
//				}
//
//				boundingbox = new Rectangle(lowerX + x, lowerY + y, width, height);
//
//				return;
//			}
//
//			if (id == 0x00)
//			{
//				drawSpriteTile(x, y, 4, 28, 10);
//			}
//			else if (id == 0x01)
//			{
//				drawSpriteTile(x - 8, y, 6, 24, 12, false, false, 2, 2);
//				drawSpriteTile(x + 8, y, 6, 24, 12, true, false, 2, 2);
//			}
//			else if (id == 0x02)
//			{
//				drawSpriteTile(x, y, 0, 16, 10);
//			}
//			else if (id == 0x04)
//			{
//				byte p = (byte) ((room != null && (room.blocks[13] == 83)) ? 15 : 3);
//
//				drawSpriteTile(x, y, 14, 28, p);
//				drawSpriteTile(x, y, 14, 30, p);
//			}
//			else if (id == 0x05)
//			{
//				byte p = (byte) ((room != null && (room.blocks[13] == 83)) ? 15 : 3);
//
//				drawSpriteTile(x, y, 14, 28, p);
//				drawSpriteTile(x, y, 14, 30, p);
//			}
//			else if (id == 0x06)
//			{
//				byte p = (byte) ((room != null && (room.blocks[13] == 83)) ? 15 : 3);
//
//				drawSpriteTile(x, y, 14, 28, p);
//				drawSpriteTile(x, y, 14, 30, p);
//			}
//			else if (id == 0x07)
//			{
//				byte p = (byte) ((room != null && (room.blocks[13] == 83)) ? 15 : 3);
//
//				drawSpriteTile(x, y, 14, 28, p);
//				drawSpriteTile(x, y, 14, 30, p);
//			}
//			else if (id == 0x08)
//			{
//				drawSpriteTile(x, y, 0, 24, 6);
//				drawSpriteTile(x + 4, y + 6, 0, 24, 6, false, false, 1, 1);
//			}
//			else if (id == 0x09)
//			{
//				drawSpriteTile(x - 22, y - 24, 12, 24, 12, false, false, 2, 2); // Moldorm tail
//				drawSpriteTile(x - 16, y - 20, 8, 24, 12, false, false, 2, 2); // Moldorm b2
//				drawSpriteTile(x - 12, y - 16, 4, 24, 12, false, false, 4, 4); // Moldorm b
//				drawSpriteTile(x, y, 0, 24, 12, false, false, 4, 4); // Moldorm head
//
//				drawSpriteTile(x + 20, y + 12, 8, 26, 14, false, false, 2, 2); // Moldorm eye
//				drawSpriteTile(x + 12, y + 20, 8, 26, 14, false, false, 2, 2); // Moldorm eye
//			}
//			else if (id == 0x0A)
//			{
//				drawSpriteTile(x, y, 0, 24, 8);
//				drawSpriteTile(x + 4, y + 6, 0, 24, 8, false, false, 1, 1);
//			}
//			else if (id == 0x0B)
//			{
//				drawSpriteTile(x, y, 10, 30, 10);
//			}
//			else if (id == 0x0C)
//			{
//				drawSpriteTile(x, y, 0, 24, 8);
//				drawSpriteTile(x + 4, y + 6, 0, 24, 8, false, false, 1, 1);
//			}
//			else if (id == 0x0D)
//			{
//				drawSpriteTile(x, y, 14, 28, 12);
//			}
//			else if (id == 0x0E)
//			{
//				drawSpriteTile(x, y, 8, 18, 10, false, false, 3, 2);
//			}
//			else if (id == 0x0F)
//			{
//				drawSpriteTile(x, y, 14, 24, 8, false, false, 2, 3);
//				drawSpriteTile(x + 16, y, 30, 8, 8, true, false, 1, 3);
//			}
//			else if (id == 0x10)
//			{
//				drawSpriteTile(x, y, 12, 31, 8, false, false, 1, 1);
//			}
//			else if (id == 0x11)
//			{
//				drawSpriteTile(x, y + 16, 6, 16, 8, false, false, 2, 2); // Feet
//				drawSpriteTile(x - 8, y + 8, 4, 18, 8, false, false, 2, 2); // Body1
//				drawSpriteTile(x + 8, y + 8, 4, 18, 8, true, false, 2, 2); // Body2
//				drawSpriteTile(x, y, 0, 16, 8, false, false, 2, 2); // Head
//			}
//			else if (id == 0x12)
//			{
//				drawSpriteTile(x, y + 8, 8, 26, 8);
//				drawSpriteTile(x, y, 6, 24, 8);
//			}
//			else if (id == 0x13)
//			{
//				drawSpriteTile(x, y, 4, 22, 2);
//			}
//			else if (id == 0x15)
//			{
//				// Antifairy
//				drawSpriteTile(x + 2, y + 8, 3, 30, 5, false, false, 1, 1);
//				drawSpriteTile(x + 8, y + 2, 3, 30, 5, false, false, 1, 1);
//				drawSpriteTile(x + 14, y + 8, 3, 30, 5, false, false, 1, 1);
//				drawSpriteTile(x + 8, y + 14, 3, 30, 5, false, false, 1, 1);
//				drawSpriteTile(x + 8, y + 8, 1, 30, 5, false, false, 1, 1); // Middle
//			}
//			else if (id == 0x16)
//			{
//				drawSpriteTile(x, y + 8, 2, 26, 2);
//				drawSpriteTile(x, y, 0, 26, 2);
//			}
//			else if (id == 0x17) // Bush hoarder
//			{
//				drawSpriteTile(x, y, 8, 30, 10);
//			}
//			else if (id == 0x18) // Mini moldorm
//			{
//				drawSpriteTile(x + 13, y + 17, 13, 21, 8, false, false, 1, 1); // Tail
//				drawSpriteTile(x + 5, y + 8, 2, 22, 8); // Body
//				drawSpriteTile(x, y, 0, 22, 8); // Head
//				drawSpriteTile(x, y - 4, 13, 20, 8, false, false, 1, 1); // Eyes
//				drawSpriteTile(x - 4, y, 13, 20, 8, false, false, 1, 1); // Eyes
//			}
//			else if (id == 0x19) // Poe - ghost
//			{
//				drawSpriteTile(x, y, 6, 31, 2); //
//			}
//			else if (id == 0x1A) // Smith
//			{
//				//drawSpriteTile((x*16), (y*16), 2, 4, 10,true); // Smitty
//				//drawSpriteTile((x*16)+12, (y*16) - 7, 0, 6, 10); // Hammer
//				drawSpriteTile(x, y, 4, 22, 10);
//			}
//			else if (id == 0x1C) // Statue
//			{
//				drawSpriteTile(x, y + 8, 0, 28, 15);
//				drawSpriteTile(x, y, 2, 28, 15, false, false, 1, 1);
//				drawSpriteTile(x + 8, y, 2, 28, 15, true, false, 1, 1);
//			}
//			else if (id == 0x1E) // Crystal switch
//			{
//				drawSpriteTile(x, y, 4, 30, 5);
//			}
//			else if (id == 0x1F) // Sick kid
//			{
//				drawSpriteTile(x - 8, y + 8, 10, 16, 14);
//				drawSpriteTile(x + 16 - 8, y + 8, 10, 16, 14, true);
//				drawSpriteTile(x - 8, y + 16, 10, 16, 14, false, true, 2, 2);
//				drawSpriteTile(x + 16 - 8, y + 16, 10, 16, 14, true, true, 2, 2);
//				drawSpriteTile(x, y - 4, 14, 16, 10);
//			}
//			else if (id == 0x20)
//			{
//				drawSpriteTile(x, y, 2, 24, 7);
//			}
//			else if (id == 0x21) // Push switch
//			{
//				drawSpriteTile(x + 4, y + 20, 13, 29, 3, false, false, 1, 1);
//				drawSpriteTile(x + 4, y + 28, 12, 29, 3, false, false, 1, 1);
//				drawSpriteTile(x, y + 8, 10, 28, 3);
//			}
//			else if (id == 0x22) // Rope
//			{
//
//				drawSpriteTile(x, y, 8, 26, 5);
//			}
//			else if (id == 0x23) // Red bari
//			{
//				drawSpriteTile(x, y, 2, 18, 4, false, false, 1, 2);
//				drawSpriteTile(x + 8, y, 2, 18, 4, true, false, 1, 2);
//			}
//			else if (id == 0x24) // Blue bari
//			{
//				drawSpriteTile(x, y, 2, 18, 6, false, false, 1, 2);
//				drawSpriteTile(x + 8, y, 2, 18, 6, true, false, 1, 2);
//			}
//			else if (id == 0x25) // Talking tree?
//			{
//				// TODO: Add something here?
//			}
//			else if (id == 0x26) // Hardhat beetle
//			{
//				if ((x & 0x01) == 0x00)
//				{
//					drawSpriteTile(x, y, 4, 20, 8);
//					drawSpriteTile(x, y - 6, 0, 20, 8);
//				}
//				else
//				{
//					drawSpriteTile(x, y, 4, 20, 10);
//					drawSpriteTile(x, y - 6, 0, 20, 10);
//				}
//			}
//			else if (id == 0x27) // Deadrock
//			{
//				drawSpriteTile(x, y, 2, 30, 10);
//			}
//			else if (id == 0x28) // Npcs
//			{
//				drawSpriteTile(x, y, 14, 22, 10);
//			}
//			else if (id == 0x29) // Npcs
//			{
//				drawSpriteTile(x, y, 14, 22, 10);
//			}
//			else if (id == 0x2A) // Npcs
//			{
//				drawSpriteTile(x, y, 14, 22, 10);
//			}
//			else if (id == 0x2B) // ???
//			{
//				drawSpriteTile(x, y, 14, 22, 10);
//			}
//			else if (id == 0x2C) // Lumberjack
//			{
//				drawSpriteTile(x - 24, y + 12, 6, 26, 12, true); // Body
//				drawSpriteTile(x - 24, y, 8, 26, 12, true); // Head
//
//				drawSpriteTile(x - 14, y + 12, 14, 27, 10, false, false, 1, 1); // Saw left edge
//				drawSpriteTile(x - 6, y + 12, 15, 27, 10, false, false, 1, 1); // Saw left edge
//				drawSpriteTile(x + 2, y + 12, 15, 27, 10, false, false, 1, 1); // Saw left edge
//				drawSpriteTile(x + 10, y + 12, 15, 27, 10, false, false, 1, 1); // Saw left edge
//				drawSpriteTile(x + 18, y + 12, 15, 27, 10, false, false, 1, 1); // Saw left edge
//				drawSpriteTile(x + 26, y + 12, 15, 27, 10, false, false, 1, 1); // Saw left edge
//				drawSpriteTile(x + 34, y + 12, 14, 27, 10, true, false, 1, 1); // Saw left edge
//
//				drawSpriteTile(x + 40, y + 12, 4, 26, 12); // Body
//				drawSpriteTile(x + 40, y, 8, 26, 12); // Head
//			}
//			else if (id == 0x2D) // Npcs
//			{
//				drawSpriteTile(x, y, 14, 22, 10);
//			}
//			else if (id == 0x2E) // Npcs
//			{
//				drawSpriteTile(x, y, 14, 22, 10);
//			}
//			else if (id == 0x2F) // Npcs
//			{
//				drawSpriteTile(x, y, 14, 22, 10);
//			}
//			else if (id == 0x30) // Npcs
//			{
//				drawSpriteTile(x, y, 14, 22, 10);
//			}
//			else if (id == 0x31) // Npcs
//			{
//				drawSpriteTile(x, y, 14, 22, 10);
//			}
//			else if (id == 0x32) // Npcs
//			{
//				drawSpriteTile(x, y, 14, 22, 10);
//			}
//			/*
//            else if (id == 0x33) // Pull for rupees
//            {
//
//            }
//            */
//			else if (id == 0x34) // Npcs
//			{
//				drawSpriteTile(x, y, 14, 22, 10);
//			}
//			else if (id == 0x35) // Npcs
//			{
//				drawSpriteTile(x, y, 14, 22, 10);
//			}
//			else if (id == 0x36) // Npcs
//			{
//				drawSpriteTile(x, y, 14, 22, 10);
//			}
//			/*
//            else if (id == 0x37) // Waterfall
//            {
//                drawSpriteTile((x*16), (y*16), 14, 6, 10);
//            }
//            */
//			else if (id == 0x38) // Arrowtarget
//			{
//				drawSpriteTile(x, y, 14, 22, 10);
//			}
//			else if (id == 0x39) // Npcs
//			{
//				drawSpriteTile(x, y, 14, 22, 10);
//			}
//			else if (id == 0x3A) // Npcs
//			{
//				drawSpriteTile(x, y, 14, 22, 10);
//			}
//			else if (id == 0x3B) // Dash item
//			{
//				if (room != null)
//				{
//					if (room.index == 263) // Library
//					{
//						drawSpriteTile(x, y, 12, 18, 11); // BONK ITEM MUST BE MODIFIED TO USE ISKEY VALUE
//					}
//					else
//					{
//						drawSpriteTile(x, y, 14, 18, 11, false, false, 1, 2); // Key
//					}
//				}
//			}
//			else if (id == 0x3C) // Npcs
//			{
//				drawSpriteTile(x, y, 14, 22, 10);
//			}
//			else if (id == 0x3D) // Npcs
//			{
//				drawSpriteTile(x, y, 14, 22, 10);
//			}
//			else if (id == 0x3E) // Npcs
//			{
//				drawSpriteTile(x, y, 14, 22, 10);
//			}
//			else if (id == 0x3F) // Npcs
//			{
//				drawSpriteTile(x, y, 14, 22, 10);
//			}
//			else if (id == 0x40) // Lightning lock (agah tower)
//			{
//				drawSpriteTile(x - 24, y, 10, 28, 2, false, false, 1, 2);
//				drawSpriteTile(x - 16, y, 6, 30, 2);
//				drawSpriteTile(x, y, 8, 30, 2);
//				drawSpriteTile(x + 16, y, 6, 30, 2);
//				drawSpriteTile(x + 24, y, 10, 28, 2, false, false, 1, 2);
//			}
//			else if (id == 0x41) // Blue soldier
//			{
//				drawSpriteTile(x - 4, y + 8, 6, 20, 10);
//				drawSpriteTile(x + 12, y + 8, 6, 20, 10, true, false, 1, 2);
//				drawSpriteTile(x, y, 0, 20, 10);
//				drawSpriteTile(x + 12, y + 8, 13, 22, 10, false, false, 1, 2); // Shield
//				drawSpriteTile(x - 4, y + 16, 14, 22, 10, false, true, 1, 2); // Sword
//			}
//			else if (id == 0x42) // Green soldier
//			{
//				drawSpriteTile(x - 4, y + 8, 6, 20, 12);
//				drawSpriteTile(x + 12, y + 8, 6, 20, 12, true, false, 1, 2);
//				drawSpriteTile(x, y, 0, 20, 12);
//				drawSpriteTile(x + 12, y + 8, 13, 22, 12, false, false, 1, 2); // Shield
//				drawSpriteTile(x - 4, y + 16, 14, 22, 12, false, true, 1, 2); // Sword
//			}
//			else if (id == 0x43) // Red spear soldier
//			{
//				drawSpriteTile(x - 4, y + 8, 6, 20, 8);
//				drawSpriteTile(x + 12, y + 8, 6, 20, 8, true, false, 1, 2);
//				drawSpriteTile(x, y, 0, 20, 8);
//				drawSpriteTile(x + 12, y + 8, 13, 22, 8, false, false, 1, 2); // Shield
//				drawSpriteTile(x - 4, y + 16, 11, 22, 8, false, true, 1, 2); // Spear
//			}
//			else if (id == 0x44) // Sword blue holding up
//			{
//				drawSpriteTile(x + 4, y + 8, 6, 16, 10);
//				drawSpriteTile(x - 4, y + 8, 6, 20, 10, false, false, 1, 2);
//				drawSpriteTile(x, y, 0, 16, 10); // Head
//				drawSpriteTile(x + 12, y + 8, 14, 22, 10, false, true, 1, 2); // Sword
//			}
//			else if (id == 0x45) // Green spear soldier
//			{
//				drawSpriteTile(x - 4, y + 8, 6, 20, 12);
//				drawSpriteTile(x + 12, y + 8, 6, 20, 12, true, false, 1, 2);
//				drawSpriteTile(x, y, 0, 20, 12);
//				drawSpriteTile(x + 12, y + 8, 13, 22, 12, false, false, 1, 2); // Shield
//				drawSpriteTile(x - 4, y + 16, 11, 22, 12, false, true, 1, 2); // Spear
//			}
//			else if (id == 0x46) // Blue archer
//			{
//				drawSpriteTile(x - 4, y + 8, 6, 20, 10);
//				drawSpriteTile(x + 12, y + 8, 6, 20, 10, true, false, 1, 2);
//				drawSpriteTile(x, y, 0, 20, 10); // Head
//				drawSpriteTile(x, y + 16, 10, 16, 10, false, false, 1, 1); // Bow1
//				drawSpriteTile(x + 8, y + 16, 10, 16, 10, true, false, 1, 1); // Bow2
//			}
//			else if (id == 0x47) // Green archer
//			{
//				drawSpriteTile(x, y + 8, 14, 16, 12);
//				drawSpriteTile(x, y, 0, 20, 12);
//				drawSpriteTile(x, y + 16, 10, 16, 12, false, false, 1, 1); // Bow1
//				drawSpriteTile(x + 8, y + 16, 10, 16, 12, true, false, 1, 1); // Bow2
//			}
//			else if (id == 0x48) // Javelin soldier red
//			{
//				drawSpriteTile(x + 4, y + 8, 6, 16, 8);
//				drawSpriteTile(x - 4, y + 8, 6, 20, 8, false, false, 1, 2);
//				drawSpriteTile(x, y, 0, 16, 8); // Head
//				drawSpriteTile(x + 12, y + 8, 11, 22, 8, false, true, 1, 2); // Sword
//			}
//			else if (id == 0x49) // Javelin soldier red from bush
//			{
//				drawSpriteTile(x + 4, y + 8, 6, 16, 8);
//				drawSpriteTile(x - 4, y + 8, 6, 20, 8, false, false, 1, 2);
//				drawSpriteTile(x, y, 0, 18, 8); // Head
//				drawSpriteTile(x, y + 24, 0, 20, 2);
//				drawSpriteTile(x + 12, y + 8, 11, 22, 8, false, true, 1, 2); // Sword
//			}
//			else if (id == 0x4A) // Red bomb soldier
//			{
//				drawSpriteTile(x + 4, y + 8, 6, 16, 8);
//				drawSpriteTile(x - 4, y + 8, 6, 20, 8, false, false, 1, 2);
//				drawSpriteTile(x, y, 0, 16, 8); // Head
//				drawSpriteTile(x + 8, y - 8, 14, 22, 11); // Bomb
//			}
//			else if (id == 0x4B) // Green soldier recruit
//			{
//				// 0,4
//				drawSpriteTile(x, y, 6, 24, 12);
//				drawSpriteTile(x, y - 10, 0, 20, 12);
//			}
//			else if (id == 0x4C) // Jazzhand
//			{
//				drawSpriteTile(x, y, 0, 26, 14, false, false, 6, 2);
//			}
//			else if (id == 0x4D) // Rabit??
//			{
//				drawSpriteTile(x, y, 0, 26, 12, false, false, 6, 2);
//			}
//			else if (id == 0x4E) // Popo1
//			{
//				drawSpriteTile(x, y, 0, 20, 10);
//			}
//			else if (id == 0x4F) // Popo2
//			{
//				drawSpriteTile(x, y, 2, 20, 10);
//			}
//			else if (id == 0x50) // Canon ball
//			{
//				drawSpriteTile(x, y, 0, 24, 10);
//			}
//			else if (id == 0x51) // Armos
//			{
//				drawSpriteTile(x, y, 0, 28, 11, false, false, 2, 4);
//			}
//			else if (id == 0x53) //Armos Knight
//			{
//				drawSpriteTile(x, y, 0, 28, 10, false, false, 4, 4);
//			}
//			else if (id == 0x54)
//			{
//				drawSpriteTile(x, y, 2, 28, 12);
//				drawSpriteTile(x + 8, y + 10, 6, 28, 12);
//				drawSpriteTile(x + 16, y + 18, 10, 28, 12);
//			}
//			else if (id == 0x55) // Fireball Zora
//			{
//				drawSpriteTile(x, y, 4, 26, 11);
//			}
//			else if (id == 0x56) // Zora
//			{
//				drawSpriteTile(x, y, 10, 20, 2);
//				drawSpriteTile(x, y + 8, 8, 30, 2);
//			}
//			else if (id == 0x57) // Desert Rocks
//			{
//				drawSpriteTile(x, y, 14, 24, 2, false, false, 2, 4);
//				drawSpriteTile(x + 16, y, 14, 24, 2, true, false, 2, 4);
//			}
//			else if (id == 0x58) // Crab
//			{
//				drawSpriteTile(x, y, 14, 24, 12);
//				drawSpriteTile(x + 16, y, 14, 24, 12, true);
//			}
//			else if (id == 0x5B) // Spark
//			{
//				drawSpriteTile(x, y, 8, 18, 4);
//			}
//			else if (id == 0x5C) // Spark
//			{
//				drawSpriteTile(x, y, 8, 18, 4, true);
//			}
//			else if (id == 0x5D) // Roller vertical1
//			{
//				// Subset3
//				if (y.BitIsOn(0x10))
//				{
//					drawSpriteTile(x, y, 8, 24, 11);
//
//					for (int i = 8; i < ((7 * 16) + 8); i += 16)
//					{
//						drawSpriteTile(x + i, y, 9, 24, 11);
//					}
//
//					drawSpriteTile(x + (16 * 7), y, 8, 24, 11, true);
//				}
//				else
//				{
//					drawSpriteTile(x, y, 8, 24, 11);
//					drawSpriteTile(x + 16, y, 9, 24, 11);
//					drawSpriteTile(x + 32, y, 9, 24, 11);
//					drawSpriteTile(x + 48, y, 8, 24, 11, true);
//				}
//
//			}
//			else if (id == 0x5E) // Roller vertical2
//			{
//				// Subset3
//				if (y.BitIsOn(0x10))
//				{
//					drawSpriteTile(x, y, 8, 24, 11);
//
//					for (int i = 8; i < ((7 * 16) + 8); i += 16)
//					{
//						drawSpriteTile(x + i, y, 9, 24, 11);
//					}
//
//					drawSpriteTile(x + (16 * 7), y, 8, 24, 11, true);
//				}
//				else
//				{
//					drawSpriteTile(x, y, 8, 24, 11);
//					drawSpriteTile(x + 16, y, 9, 24, 11);
//					drawSpriteTile(x + 32, y, 9, 24, 11);
//					drawSpriteTile(x + 48, y, 8, 24, 11, true);
//				}
//			}
//			else if (id == 0x5F) // Roller horizontal
//			{
//				if (x.BitIsOn(0x10))
//				{
//					drawSpriteTile(x, y, 14, 24, 11);
//					drawSpriteTile(x, y + 16, 14, 25, 11);
//					drawSpriteTile(x, y + 32, 14, 25, 11);
//					drawSpriteTile(x, y + 48, 14, 24, 11, false, true);
//				}
//				else
//				{
//					for (int i = 0; i < 7 * 16; i += 16)
//					{
//						drawSpriteTile(x, y + i, 14, 25, 11);
//					}
//
//					drawSpriteTile(x, y, 14, 24, 11);
//					drawSpriteTile(x, y + (7 * 16), 14, 24, 11, false, true);
//				}
//			}
//			else if (id == 0x60) // Roller horizontal2 (right to left)
//			{
//				// Subset3
//				if (x.BitIsOn(0x10))
//				{
//					drawSpriteTile(x, y, 14, 24, 11);
//					drawSpriteTile(x, y + 16, 14, 25, 11);
//					drawSpriteTile(x, y + 32, 14, 25, 11);
//					drawSpriteTile(x, y + 48, 14, 24, 11, false, true);
//				}
//				else
//				{
//					for (int i = 0; i < 7 * 16; i += 16)
//					{
//						drawSpriteTile(x, y + i, 14, 25, 11);
//					}
//
//					drawSpriteTile(x, y, 14, 24, 11);
//					drawSpriteTile(x, y + (7 * 16), 14, 24, 11, false, true);
//				}
//
//			}
//			else if (id == 0x61) // Beamos
//			{
//				drawSpriteTile(x, y - 16, 8, 20, 14, false, false, 2, 4);
//				drawSpriteTile(x + 4, y - 8, 10, 20, 14, false, false, 1, 1);
//			}
//			else if (id == 0x63) // Devalant non-shooter
//			{
//				drawSpriteTile(x - 8, y - 8, 2, 16, 2);
//				drawSpriteTile(x + 8, y - 8, 2, 16, 2, true);
//				drawSpriteTile(x - 8, y + 8, 2, 16, 2, false, true);
//				drawSpriteTile(x + 8, y + 8, 2, 16, 2, true, true);
//				drawSpriteTile(x, y, 0, 16, 10);
//			}
//			else if (id == 0x64) // Devalant non-shooter
//			{
//				drawSpriteTile(x - 8, y - 8, 2, 16, 2);
//				drawSpriteTile(x + 8, y - 8, 2, 16, 2, true);
//				drawSpriteTile(x - 8, y + 8, 2, 16, 2, false, true);
//				drawSpriteTile(x + 8, y + 8, 2, 16, 2, true, true);
//				drawSpriteTile(x, y, 0, 16, 8);
//			}
//			else if (id == 0x66) // Moving wall canon right
//			{
//				drawSpriteTile(x, y, 14, 16, 14, true);
//			}
//			else if (id == 0x67) // Moving wall canon right
//			{
//				drawSpriteTile(x, y, 14, 16, 14);
//			}
//			else if (id == 0x68) // Moving wall canon right
//			{
//				drawSpriteTile(x, y, 12, 16, 14);
//			}
//			else if (id == 0x69) // Moving wall canon right
//			{
//				drawSpriteTile(x, y, 12, 16, 14, false, true);
//			}
//			else if (id == 0x6A) // Chainball soldier
//			{
//				drawSpriteTile(x + 4, y + 8, 6, 16, 14);
//				drawSpriteTile(x - 4, y + 8, 6, 20, 14, false, false, 1, 2);
//				drawSpriteTile(x, y, 0, 16, 14); // Head
//				drawSpriteTile(x + 12, y - 16, 10, 18, 14); //Ball
//			}
//			else if (id == 0x6B) // Cannon soldier
//			{
//				drawSpriteTile(x + 4, y + 8, 6, 16, 14);
//				drawSpriteTile(x - 4, y + 8, 6, 20, 14, false, false, 1, 2);
//				drawSpriteTile(x, y, 0, 16, 14); // Head
//				drawSpriteTile(x + 12, y + 8, 4, 18, 14); // Cannon
//			}
//			else if (id == 0x6C) // Mirror portal
//			{
//				// Useless
//			}
//			else if (id == 0x6D) // Rat
//			{
//				drawSpriteTile(x, y, 14, 24, 5);
//			}
//			else if (id == 0x6E) // Rope
//			{
//				drawSpriteTile(x, y, 10, 26, 5);
//			}
//			else if (id == 0x6F)
//			{
//				drawSpriteTile(x, y, 4, 24, 10);
//			}
//			else if (id == 0x70) // Helma fireball
//			{
//				drawSpriteTile(x, y, 10, 28, 4);
//			}
//			else if (id == 0x71) // Leever
//			{
//				drawSpriteTile(x, y, 6, 16, 4);
//			}
//			else if (id == 0x73) // Uncle priest
//			{
//				if (room != null)
//				{
//					if (room.index == 260) // Link's house draw uncle sit
//					{
//						drawSpriteTile(x + 8, y, 6, 16, 12);
//						drawSpriteTile(x + 8, y - 10, 0, 16, 10);
//					}
//					else if (room.index == 18)
//					{
//						drawSpriteTile(x, y + 12, 14, 16, 12);
//						drawSpriteTile(x, y, 4, 18, 12);
//					}
//					else
//					{
//						drawSpriteTile(x - 8, y - 16, 0, 18, 10);
//						drawSpriteTile(x + 8, y - 16, 0, 18, 10, true);
//						drawSpriteTile(x, y - 26, 8, 16, 10);
//					}
//				}
//			}
//			else if (id == 0x79) // Bee
//			{
//				drawSpriteTile(x, y, 4, 14, 11, false, false, 1, 1);
//			}
//			else if (id == 0x7A)
//			{
//				drawSpriteTile(x, y - 16, 2, 24, 12, false, false, 2, 4);
//				drawSpriteTile(x + 16, y - 16, 2, 24, 12, true, false, 2, 4);
//			}
//			else if (id == 0x7C) // Skull head
//			{
//				drawSpriteTile(x, y, 0, 16, 10);
//			}
//			else if (id == 0x7D) // Big spike
//			{
//				drawSpriteTile(x, y, 4, 28, 11);
//				drawSpriteTile(x + 16, y, 4, 28, 11, true);
//				drawSpriteTile(x, y + 16, 4, 28, 11, false, true);
//				drawSpriteTile(x + 16, y + 16, 4, 28, 11, true, true);
//			}
//			else if (id == 0x7E) // Guruguru clockwise
//			{
//				drawSpriteTile(x, y - 14, 8, 18, 4);
//				drawSpriteTile(x, y - 28, 8, 18, 4);
//				drawSpriteTile(x, y - 42, 8, 18, 4);
//				drawSpriteTile(x, y - 56, 8, 18, 4);
//			}
//			else if (id == 0x7F) // Guruguru Counterclockwise
//			{
//				drawSpriteTile(x, y - 14, 8, 18, 4);
//				drawSpriteTile(x, y - 28, 8, 18, 4);
//				drawSpriteTile(x, y - 42, 8, 18, 4);
//				drawSpriteTile(x, y - 56, 8, 18, 4);
//			}
//			else if (id == 0x80) // Winder (moving firebar)
//			{
//				drawSpriteTile(x, y, 8, 18, 4);
//				drawSpriteTile(x - 14, y, 8, 18, 4);
//				drawSpriteTile(x - 28, y, 8, 18, 4);
//				drawSpriteTile(x - 42, y, 8, 18, 4);
//				drawSpriteTile(x - 56, y, 8, 18, 4);
//			}
//			else if (id == 0x81) // Water tektite
//			{
//				drawSpriteTile(x, y, 0, 24, 11);
//			}
//			else if (id == 0x82)//circle antifairy
//			{
//				// Antifairy top
//				drawSpriteTile(x + 2 - 4, y + 8 - 16, 3, 30, 5, false, false, 1, 1);
//				drawSpriteTile(x + 8 - 4, y + 2 - 16, 3, 30, 5, false, false, 1, 1);
//				drawSpriteTile(x + 14 - 4, y + 8 - 16, 3, 30, 5, false, false, 1, 1);
//				drawSpriteTile(x + 8 - 4, y + 14 - 16, 3, 30, 5, false, false, 1, 1);
//				drawSpriteTile(x + 8 - 4, y + 8 - 16, 1, 30, 5, false, false, 1, 1); // Middle
//																						   // Left
//				drawSpriteTile(x + 2 - 16, y + 8 - 4, 3, 30, 5, false, false, 1, 1);
//				drawSpriteTile(x + 8 - 16, y + 2 - 4, 3, 30, 5, false, false, 1, 1);
//				drawSpriteTile(x + 14 - 16, y + 8 - 4, 3, 30, 5, false, false, 1, 1);
//				drawSpriteTile(x + 8 - 16, y + 14 - 4, 3, 30, 5, false, false, 1, 1);
//				drawSpriteTile(x + 8 - 16, y + 8 - 4, 1, 30, 5, false, false, 1, 1); // Middle
//
//				drawSpriteTile(x + 2 - 4, y + 8 + 8, 3, 30, 5, false, false, 1, 1);
//				drawSpriteTile(x + 8 - 4, y + 2 + 8, 3, 30, 5, false, false, 1, 1);
//				drawSpriteTile(x + 14 - 4, y + 8 + 8, 3, 30, 5, false, false, 1, 1);
//				drawSpriteTile(x + 8 - 4, y + 14 + 8, 3, 30, 5, false, false, 1, 1);
//				drawSpriteTile(x + 8 - 4, y + 8 + 8, 1, 30, 5, false, false, 1, 1); // Middle
//																						  // Left
//				drawSpriteTile(x + 2 + 8, y + 8 - 4, 3, 30, 5, false, false, 1, 1);
//				drawSpriteTile(x + 8 + 8, y + 2 - 4, 3, 30, 5, false, false, 1, 1);
//				drawSpriteTile(x + 14 + 8, y + 8 - 4, 3, 30, 5, false, false, 1, 1);
//				drawSpriteTile(x + 8 + 8, y + 14 - 4, 3, 30, 5, false, false, 1, 1);
//				drawSpriteTile(x + 8 + 8, y + 8 - 4, 1, 30, 5, false, false, 1, 1); // Middle
//			}
//			else if (id == 0x83) // Green eyegore
//			{
//				drawSpriteTile(x, y, 12, 24, 14, false, false, 2, 3);
//				drawSpriteTile(x + 16, y, 12, 24, 14, true, false, 1, 3);
//			}
//			else if (id == 0x84) // Red eyegore
//			{
//				drawSpriteTile(x, y, 12, 24, 8, false, false, 2, 3);
//				drawSpriteTile(x + 16, y, 12, 24, 8, true, false, 1, 3);
//			}
//			else if (id == 0x85) // Yellow stalfos
//			{
//				drawSpriteTile(x, y, 10, 16, 11);
//				drawSpriteTile(x, y - 12, 0, 16, 11); // Head
//			}
//			else if (id == 0x86) // Kodongo
//			{
//				drawSpriteTile(x, y, 4, 26, 14);
//			}
//			else if (id == 0x88) // Mothula
//			{
//				drawSpriteTile(x, y, 8, 24, 14, false, false, 2, 4);
//				drawSpriteTile(x + 16, y, 8, 24, 14, true, false, 2, 4);
//			}
//			else if (id == 0x8A) // Spike
//			{
//				drawSpriteTile(x, y, 6, 30, 15);
//			}
//			else if (id == 0x8B) // Gibdo
//			{
//				drawSpriteTile(x, y, 10, 24, 14);
//				drawSpriteTile(x, y - 8, 0, 24, 14);
//			}
//			else if (id == 0x8C) // Arrghus
//			{
//				drawSpriteTile(x, y, 0, 24, 14, false, false, 2, 4);
//				drawSpriteTile(x + 16, y, 0, 24, 14, true, false, 2, 4);
//			}
//			else if (id == 0x8D) // Arrghus spawn
//			{
//				drawSpriteTile(x, y, 6, 24, 14);
//			}
//			else if (id == 0x8E) // Terrorpin
//			{
//				drawSpriteTile(x, y, 14, 24, 12);
//			}
//			else if (id == 0x8F) // Slime
//			{
//				drawSpriteTile(x, y, 0, 20, 12);
//			}
//			else if (id == 0x90) // Wall master
//			{
//				drawSpriteTile(x, y, 6, 26, 12);
//				drawSpriteTile(x + 16, y, 15, 26, 12, false, false, 1, 1);
//				drawSpriteTile(x + 16, y + 8, 9, 26, 12, false, false, 1, 2);
//				drawSpriteTile(x, y + 16, 10, 27, 12, false, false, 1, 1);
//				drawSpriteTile(x + 8, y + 16, 8, 27, 12, false, false, 1, 1);
//			}
//			else if (id == 0x91) // Stalfos knight
//			{
//				drawSpriteTile(x - 2, y + 12, 4, 22, 12, false, false, 1, 2);
//				drawSpriteTile(x + 10, y + 12, 4, 22, 12, true, false, 1, 2);
//				drawSpriteTile(x - 4, y + 4, 1, 22, 12);
//				drawSpriteTile(x + 12, y + 4, 3, 22, 12, false, false, 1, 2);
//				drawSpriteTile(x, y - 8, 6, 20, 12);
//			}
//			else if (id == 0x92) // Helmaking
//			{
//				drawSpriteTile(x, y + 32, 14, 26, 14);
//				drawSpriteTile(x + 16, y + 32, 0, 28, 14);
//				drawSpriteTile(x + 32, y + 32, 14, 26, 14, true);
//
//				drawSpriteTile(x, y + 16 + 32, 2, 28, 14);
//				drawSpriteTile(x + 16, y + 16 + 32, 4, 28, 14);
//				drawSpriteTile(x + 32, y + 16 + 32, 2, 28, 14, true);
//
//				drawSpriteTile(x + 8, y + 32 + 32, 6, 28, 14);
//				drawSpriteTile(x + 24, y + 32 + 32, 6, 28, 14, true);
//			}
//			else if (id == 0x93) // Bumper
//			{
//				drawSpriteTile(x, y, 12, 30, 7);
//				drawSpriteTile(x + 16, y, 12, 30, 7, true);
//				drawSpriteTile(x + 16, y + 16, 12, 30, 7, true, true);
//				drawSpriteTile(x, y + 16, 12, 30, 7, false, true);
//			}
//			else if (id == 0x95) // Right laser eye
//			{
//				drawSpriteTile(x, y, 9, 28, 3, true, false, 1, 2);
//				drawSpriteTile(x, y + 16, 9, 28, 3, true, true, 1, 1);
//			}
//			else if (id == 0x96) // Left laser eye
//			{
//				drawSpriteTile(x + 8, y - 4, 9, 28, 3, false, false, 1, 2);
//				drawSpriteTile(x + 8, y + 12, 9, 28, 3, false, true, 1, 1);
//			}
//			else if (id == 0x97) // Right laser eye
//			{
//				drawSpriteTile(x, y, 6, 28, 3, false, false, 2, 1);
//				drawSpriteTile(x + 16, y, 6, 28, 3, true, false, 1, 1);
//			}
//			else if (id == 0x98) // Right laser eye
//			{
//				drawSpriteTile(x, y, 6, 28, 3, false, true, 2, 1);
//				drawSpriteTile(x + 16, y, 6, 28, 3, true, true, 1, 1);
//			}
//			else if (id == 0x99)
//			{
//				drawSpriteTile(x, y, 6, 24, 12);
//				drawSpriteTile(x, y - 8, 0, 24, 12);
//			}
//			else if (id == 0x9A) // Water bubble kyameron
//			{
//				drawSpriteTile(x, y, 10, 24, 6);
//			}
//			else if (id == 0x9B) // Water bubble kyameron
//			{
//				drawSpriteTile(x, y, 6, 24, 11);
//				drawSpriteTile(x, y - 8, 2, 27, 11, false, false, 2, 1);
//			}
//			else if (id == 0x9C) // Water bubble kyameron
//			{
//				drawSpriteTile(x, y, 12, 22, 11);
//				drawSpriteTile(x + 16, y, 13, 22, 11, false, false, 1, 2);
//			}
//			else if (id == 0x9D) // Water bubble kyameron
//			{
//				drawSpriteTile(x, y, 14, 21, 11);
//				drawSpriteTile(x, y - 16, 14, 20, 11, false, false, 2, 1);
//			}
//			else if (id == 0xA1)
//			{
//				drawSpriteTile(x - 8, y + 8, 6, 26, 14);
//				drawSpriteTile(x + 8, y + 8, 6, 26, 14, true);
//			}
//			else if (id == 0xA2)
//			{
//				drawSpriteTile(x, y + 8, 0, 24, 14, false, false, 4, 4);
//			}
//			else if (id == 0xA5)
//			{
//				drawSpriteTile(x, y, 0, 26, 10, false, false, 3, 2);
//				drawSpriteTile(x + 4, y - 8, 0, 24, 10);
//			}
//			else if (id == 0xA6)
//			{
//				drawSpriteTile(x, y, 0, 26, 8, false, false, 3, 2);
//				drawSpriteTile(x + 4, y - 8, 0, 24, 8);
//			}
//			else if (id == 0xA7)
//			{
//				drawSpriteTile(x, y + 12, 12, 16, 10);
//				drawSpriteTile(x, y, 0, 16, 10);
//			}
//			else if (id == 0xAC)
//			{
//				drawSpriteTile(x, y, 5, 14, 4);
//			}
//			else if (id == 0xAD)
//			{
//				drawSpriteTile(x, y + 8, 14, 10, 10);
//				drawSpriteTile(x, y, 12, 10, 10);
//			}
//			else if (id == 0xBA)
//			{
//				drawSpriteTile(x, y, 14, 14, 6);
//			}
//			else if (id == 0xC1)
//			{
//				drawSpriteTile(x, y - 16, 2, 24, 12, false, false, 2, 4);
//				drawSpriteTile(x + 16, y - 16, 2, 24, 12, true, false, 2, 4);
//			}
//			else if (id == 0xC3)
//			{
//				drawSpriteTile(x, y, 10, 14, 12);
//			}
//			else if (id == 0xC4)
//			{
//				drawSpriteTile(x, y, 0, 18, 14);
//				drawSpriteTile(x, y - 8, 0, 16, 14);
//			}
//			else if (id == 0xC5)
//			{
//				if (room == null)
//				{
//					drawSpriteTile(x, y, 6, 30, 7);
//				}
//				else
//				{
//					drawSpriteTile(x + 10, y + 10, 13, 9, 8, false, false, 1, 1);
//					drawSpriteTile(x + 6, y + 6, 13, 8, 8, false, false, 1, 1);
//				}
//			}
//			else if (id == 0xC6)
//			{
//				drawSpriteTile(x + 4, y + 14, 3, 30, 14, false, false, 1, 1);
//				drawSpriteTile(x + 14, y + 4, 3, 30, 14, false, false, 1, 1);
//				drawSpriteTile(x + 4, y + 2, 1, 31, 14, false, false, 1, 1);
//				drawSpriteTile(x - 6, y + 4, 3, 30, 14, false, false, 1, 1);
//				drawSpriteTile(x + 4, y - 6, 3, 30, 14, false, false, 1, 1);
//			}
//			else if (id == 0xC7)
//			{
//				drawSpriteTile(x, y, 0, 26, 4);
//				drawSpriteTile(x, y - 10, 0, 26, 4);
//				drawSpriteTile(x, y - 20, 0, 26, 4);
//				drawSpriteTile(x, y - 30, 2, 26, 4);
//			}
//			else if (id == 0xC8)
//			{
//				drawSpriteTile(x, y, 12, 24, 12, false, false, 2, 3);
//				drawSpriteTile(x + 16, y, 12, 24, 12, true, false, 1, 3);
//			}
//			else if (id == 0xC9)
//			{
//				drawSpriteTile(x, y, 8, 28, 8, false);
//				drawSpriteTile(x + 16, y, 8, 28, 8, true);
//			}
//			else if (id == 0xCA)
//			{
//				drawSpriteTile(x, y, 8, 10, 10);
//			}
//			else if (id == 0xD0)
//			{
//				drawSpriteTile(x, y, 7, 14, 11, false, false, 3, 2);
//				drawSpriteTile(x, y - 10, 8, 12, 11);
//			}
//			else if (id == 0xD1)
//			{
//				drawSpriteTile(x + 2, y + 8, 7, 13, 11, true, true, 1, 1);
//				drawSpriteTile(x + 8, y + 2, 7, 13, 11, true, false, 1, 1);
//				drawSpriteTile(x + 14, y + 8, 7, 13, 11, true, true, 1, 1);
//				drawSpriteTile(x + 8, y + 14, 7, 13, 11, false, true, 1, 1);
//				drawSpriteTile(x + 8, y + 8, 7, 13, 11, false, false, 1, 1); // Middle
//			}
//			else if (id == 0xD4)
//			{
//				drawSpriteTile(x - 4, y, 0, 7, 7, false, false, 1, 1);
//				drawSpriteTile(x + 4, y, 0, 7, 7, true, false, 1, 1);
//			}
//			else if (id == 0xE3) // Fairy
//			{
//				drawSpriteTile(x, y, 10, 14, 10);
//			}
//			else if (id == 0xE4) // Key
//			{
//				drawSpriteTile(x, y, 11, 22, 11, false, false, 1, 2);
//			}
//			else if (id == 0xE7) // Mushroom
//			{
//				drawSpriteTile(x, y, 14, 30, 16);
//			}
//			else if (id == 0xE8) // Fake ms
//			{
//				drawSpriteTile(x + 4, y, 4, 31, 10, false, false, 1, 1);
//				drawSpriteTile(x + 4, y + 8, 5, 31, 10, false, false, 1, 1);
//			}
//			else if (id == 0xEB)
//			{
//				drawSpriteTile(x, y, 0, 14, 5);
//			}
//			else if (id == 0xF2)
//			{
//				drawSpriteTile(x, y - 16, 12, 24, 2, false, false, 2, 4);
//				drawSpriteTile(x + 16, y - 16, 12, 24, 2, true, false, 2, 4);
//			}
//			else if (id == 0xF4)
//			{
//				drawSpriteTile(x, y, 12, 28, 5, false, false, 4, 4);
//			}
//			else
//			{
//				//stringtodraw.Add(new SpriteName(x, (y*16), sprites_name.name[id]));
//				drawSpriteTile(x, y, 4, 4, 5);
//			}
//
//			boundingbox = new Rectangle(lowerX + x, lowerY + y, width, height);
//		}
//
//		private unsafe void drawSpriteTile(int x, int y, int srcx, int srcy, int pal, bool mirror_x = false, bool mirror_y = false, int sizex = 2, int sizey = 2)
//		{
//			var alltilesData = overworld
//				? (byte*) ZS.GFXManager.currentOWgfx16Ptr.ToPointer()
//				: (byte*) ZS.GFXManager.currentgfx16Ptr.ToPointer();
//
//			int mult;
//			int drawid = srcx + (srcy * 16) + 512;
//
//			byte* ptr;
//			pal *= 8;
//			sizex *= 4;
//			sizey *= 8;
//			int tx = (drawid / 16 * 512) + ((drawid & 0xF) << 2);
//
//			int maxIndex;
//			if (preview)
//			{
//				if (ZS.GFXManager.useOverworldGFX)
//				{
//					alltilesData = (byte*) ZS.GFXManager.currentOWgfx16Ptr.ToPointer();
//				}
//
//				x += 16;
//				y += 16;
//
//				mult = 64;
//				ptr = (byte*) ZS.GFXManager.previewSpritesPtr[id].ToPointer();
//				maxIndex = 4096;
//			}
//			else
//			{
//				mult = 512;
//				ptr = (byte*) ZS.GFXManager.roomBg1Ptr.ToPointer();
//				maxIndex = 262144;
//			}
//
//
//			for (int yl = 0, yl2 = 0; yl < sizey; yl++, yl2 += 64)
//			{
//				for (int xl = 0; xl < sizex; xl++)
//				{
//					int mx;
//					int my = mirror_y
//						? sizey - 1 - yl
//						: yl;
//					byte r;
//
//					if (mirror_x)
//					{
//						mx = sizex - 1 - xl;
//						r = 1;
//					}
//					else
//					{
//						mx = xl;
//						r = 0;
//					}
//
//					// Formula information to get tile index position in the array
//					//((ID / nbrofXtiles) * (imgwidth/2) + (ID - ((ID/16)*16) ))
//					var pixel = alltilesData[tx + yl2 + xl];
//					//nx,ny = object position, xx,yy = tile position, xl,yl = pixel position
//					int index = x + (y * mult) + (mx * 2) + (my * mult);
//
//					if (index >= 0 && index <= maxIndex)
//					{
//						if (pixel.BitIsOn(0x0F))
//						{
//							ptr[index + r ^ 1] = (byte) ((pixel & 0x0F) + 112 + pal);
//						}
//						if (pixel.BitIsOn(0xF0))
//						{
//							ptr[index + r] = (byte) ((pixel >> 4) + 112 + pal);
//						}
//					}
//				}
//			}
//		}
//
//		// TODO merge this shit into the above
//		public unsafe void draw_item_tile(int x, int y, int srcx, int srcy, int pal, bool mirror_x = false, bool mirror_y = false, int sizex = 2, int sizey = 2)
//		{
//			var alltilesData = (byte*) ZS.GFXManager.allgfx16Ptr.ToPointer();
//			byte* ptr = (byte*) ZS.GFXManager.roomBg1Ptr.ToPointer();
//
//			sizex *= 8;
//			sizey *= 8;
//			int tx = (srcy * 512) + ((srcx & 0xF) << 2);
//
//			for (int yl = 0, yl2 = 0; yl < sizey; yl++, yl2 += 64)
//			{
//				for (int xl = 0; xl < sizex; xl++)
//				{
//					int mx;
//					int my = mirror_y
//						? sizey - 1 - yl
//						: yl;
//					byte r;
//
//					if (mirror_x)
//					{
//						mx = sizex - 1 - xl;
//						r = 1;
//					}
//					else
//					{
//						mx = xl;
//						r = 0;
//					}
//
//					// Formula information to get tile index position in the array
//					//((ID / nbrofXtiles) * (imgwidth/2) + (ID - ((ID/16)*16) ))
//					var pixel = alltilesData[tx + yl2 + xl];
//					//nx,ny = object position, xx,yy = tile position, xl,yl = pixel position
//					int index = x + (y * 512) + (mx * 2) + (my * 512);
//
//					if (pixel.BitIsOn(0x0F))
//					{
//						ptr[index + r ^ 1] = (byte) ((pixel & 0x0F) + 112 + pal);
//					}
//					if (pixel.BitIsOn(0xF0))
//					{
//						ptr[index + r] = (byte) ((pixel >> 4) + 112 + pal);
//					}
//				}
//			}
//		}
//
//		public void updateMapStuff(ushort mapId)
//		{
//			mapid = (byte) mapId;
//
//			if (mapId >= 64)
//			{
//				mapId -= 64;
//			}
//
//			x = (byte) ((map_x - ((mapId & 0x7) * 512)) / 16);
//			y = (byte) ((map_y - ((mapId / 8) * 512)) / 16);
//
//		}
//	}
}
