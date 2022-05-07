using System.Drawing;
using ZeldaFullEditor.Data.Underworld;

namespace ZeldaFullEditor.Data
{
	public delegate void DrawObject(Artist art, RoomObject obj);

	public partial class RoomObjectType
	{
		/// <summary>
		/// Draws a specified tile or set of tiles of an object
		/// </summary>
		/// <param name="ZS">Handler for graphics where object is being drawn.</param>
		/// <param name="obj">Object being drawn</param>
		/// <param name="allbg">Whether this routines draws to all backgrounds or just the object's background</param>
		/// <param name="instructions">A list of <see cref="DrawInfo">DrawInfo</see> instructions for which tiles to draw.</param>
		public static void DrawTiles(Artist art, RoomObject obj, bool allbg, params DrawInfo[] instructions)
		{
			if (obj is RoomObjectPreview pre)
			{

				foreach (DrawInfo d in instructions)
				{
					if (d.XOff > 56 || d.YOff > 56 || d.XOff < 0 || d.YOff < 0) continue;

					Tile t = obj.Tiles[d.TileIndex].CloneModified(hflip: d.HFlip, vflip: d.VFlip, hox: d.HXOR, vox: d.VXOR);

					int indexoff = (d.XOff & ~0x7) + ((d.YOff & ~0x7) << 6);
					art.DrawTileForPreview(t, indexoff);
				}

			} // end of if preview
			else
			{
				foreach (DrawInfo d in instructions)
				{
					if (obj.Width < d.XOff + 8)
					{
						obj.Width = d.XOff + 8;
					}
					if (obj.Height < d.YOff + 8)
					{
						obj.Height = d.YOff + 8;
					}

					int tm = (d.XOff / 8) + obj.GridX + ((obj.GridY + (d.YOff / 8)) * 64);

					if (tm < Constants.TilesPerUnderworldRoom && tm >= 0)
					{
						ushort td = obj.Tiles[d.TileIndex].GetModifiedUnsignedShort(hflip: d.HFlip, vflip: d.VFlip, hox: d.HXOR, vox: d.VXOR);

						obj.CollisionPoints.Add(new Point(d.XOff + obj.RealX, d.YOff + obj.RealY));

						if (obj.Layer == RoomLayer.Layer1 || obj.Layer == RoomLayer.Layer3 || allbg)
						{
							if (d.TileUnder == art.Layer1TileMap[tm])
							{
								return;
							}

							art.Layer1TileMap[tm] = td;
						}

						if (obj.Layer == RoomLayer.Layer2 || allbg)
						{
							if (d.TileUnder == art.Layer2TileMap[tm])
							{
								return;
							}

							art.Layer2TileMap[tm] = td;
						}
					}
				}
			}
		}

		//=======================================================================================================
		// Shared routines
		//=======================================================================================================
		private static void RoomDraw_Arbtrary4x4in4x4SuperSquares(Artist art, RoomObject obj,
			bool bothbg = false, int sizebonus = 1)
		{
			int sizex = 32 * (sizebonus + ((obj.Size >> 2) & 0x03));
			int sizey = 32 * (sizebonus + ((obj.Size) & 0x03));

			for (int x = 0; x < sizex; x += 32)
			{
				for (int y = 0; y < sizey; y += 32)
				{
					DrawTiles(art, obj, bothbg,
						new DrawInfo(0, x, y),
						new DrawInfo(1, x + 8, y),
						new DrawInfo(2, x + 16, y),
						new DrawInfo(3, x + 24, y),

						new DrawInfo(4, x, y + 8),
						new DrawInfo(5, x + 8, y + 8),
						new DrawInfo(6, x + 16, y + 8),
						new DrawInfo(7, x + 24, y + 8),

						new DrawInfo(0, x, y + 16),
						new DrawInfo(1, x + 8, y + 16),
						new DrawInfo(2, x + 16, y + 16),
						new DrawInfo(3, x + 24, y + 16),

						new DrawInfo(4, x, y + 24),
						new DrawInfo(5, x + 8, y + 24),
						new DrawInfo(6, x + 16, y + 24),
						new DrawInfo(7, x + 24, y + 24)
					);
				}
			}
		}

		private static void RoomDraw_ArbitraryDiagonalAcute_1to16(Artist art, RoomObject obj, bool bothbg = false)
		{
			obj.Height = (obj.Size + 10) * 8;
			obj.Width = (obj.Size + 6) * 8;
			obj.DiagonalFix = true;

			for (int s = 0; s < obj.Width; s += 8)
			{
				DrawTiles(art, obj, bothbg,
					new DrawInfo(0, s, 0 - s),
					new DrawInfo(1, s, 8 - s),
					new DrawInfo(2, s, 16 - s),
					new DrawInfo(3, s, 24 - s),
					new DrawInfo(4, s, 32 - s)
				);
			}
		}

		private static void RoomDraw_ArbitraryYByX(Artist art, RoomObject obj,
			int sizex, int sizey, bool bothbg = false,
			int tilestart = 0, int xstart = 0, int ystart = 0)
		{
			DrawInfo[] list = new DrawInfo[sizex * sizey];
			int i = 0;

			sizex = (sizex + xstart) * 8;
			sizey = (sizey + ystart) * 8;

			xstart *= 8;
			ystart *= 8;

			for (int y = ystart; y < sizey; y += 8)
			{
				for (int x = xstart; x < sizex; x += 8)
				{
					list[i++] = new DrawInfo(tilestart++, x, y);
				}
			}

			DrawTiles(art, obj, bothbg, list);
		}

		private static void RoomDraw_ArbitraryXByY(Artist art, RoomObject obj,
			int sizex, int sizey, bool bothbg = false,
			int tilestart = 0, int xstart = 0, int ystart = 0)
		{
			DrawInfo[] list = new DrawInfo[sizex * sizey];
			int i = 0;

			sizex = (sizex + xstart) * 8;
			sizey = (sizey + ystart) * 8;
			xstart *= 8;
			ystart *= 8;

			for (int x = xstart; x < sizex; x += 8)
			{
				for (int y = ystart; y < sizey; y += 8)
				{
					list[i++] = new DrawInfo(tilestart++, x, y);
				}
			}

			DrawTiles(art, obj, bothbg, list);
		}

		private static void RoomDraw_DownwardsXbyY(Artist art, RoomObject obj,
			int size, int sizex, int sizey, int spacing = 0,
			int tilestart = 0, int yoff = 0, int xoff = 0, bool bothbg = false)
		{
			int inc = (sizey + spacing) * 8;
			yoff *= 8;
			xoff *= 8;

			DrawInfo[] list = new DrawInfo[sizex * sizey * size];

			int i = 0;
			for (int s = 0, s2 = 0; s < size; s++, s2 += inc)
			{
				int t = tilestart;
				for (int x = xoff, ix = 0; ix < sizex; ix++, x += 8)
				{
					for (int y = yoff + s2, iy = 0; iy < sizey; iy++, y += 8)
					{
						list[i++] = new DrawInfo(t++, x, y);
					}
				}
			}

			DrawTiles(art, obj, bothbg, list);
		}

		private static void RoomDraw_RightwardsXbyY(Artist art, RoomObject obj,
			int size, int sizex, int sizey, int spacing = 0,
			int tilestart = 0, int yoff = 0, int xoff = 0, bool bothbg = false)
		{
			int inc = (sizex + spacing) * 8;
			yoff *= 8;
			xoff *= 8;

			DrawInfo[] list = new DrawInfo[sizex * sizey * size];

			int i = 0;
			for (int s = 0, s2 = 0; s < size; s++, s2 += inc)
			{
				int t = tilestart;
				for (int x = xoff + s2, ix = 0; ix < sizex; ix++, x += 8)
				{
					for (int y = yoff, iy = 0; iy < sizey; iy++, y += 8)
					{
						list[i++] = new DrawInfo(t++, x, y);
					}
				}
			}

			DrawTiles(art, obj, bothbg, list);
		}

		//=======================================================================================================
		// Main routines
		//=======================================================================================================
		public static void RoomDraw_3x3FloorIn4x4SuperSquare(Artist art, RoomObject obj)
		{
			int sizex = 24 * (1 + ((obj.Size >> 2) & 0x03));
			int sizey = 24 * (1 + ((obj.Size) & 0x03));

			for (int x = 0; x < sizex; x += 24)
			{
				for (int y = 0; y < sizey; y += 24)
				{
					DrawTiles(art, obj, false,
						new DrawInfo(0, x, y),
						new DrawInfo(0, x + 8, y),
						new DrawInfo(0, x + 16, y),

						new DrawInfo(0, x, y + 8),
						new DrawInfo(0, x + 8, y + 8),
						new DrawInfo(0, x + 16, y + 8),

						new DrawInfo(0, x, y + 16),
						new DrawInfo(0, x + 8, y + 16),
						new DrawInfo(0, x + 16, y + 16)
					);
				}
			}
		}

		public static void RoomDraw_4x4BlocksIn4x4SuperSquare(Artist art, RoomObject obj)
		{
			int sizex = 32 * (1 + ((obj.Size >> 2) & 0x03));
			int sizey = 32 * (1 + ((obj.Size) & 0x03));

			for (int x = 0; x < sizex; x += 32)
			{
				for (int y = 0; y < sizey; y += 32)
				{
					DrawTiles(art, obj, false,
						new DrawInfo(0, x, y),
						new DrawInfo(0, x + 8, y),
						new DrawInfo(0, x + 16, y),
						new DrawInfo(0, x + 24, y),

						new DrawInfo(0, x, y + 8),
						new DrawInfo(0, x + 8, y + 8),
						new DrawInfo(0, x + 16, y + 8),
						new DrawInfo(0, x + 24, y + 8),

						new DrawInfo(0, x, y + 16),
						new DrawInfo(0, x + 8, y + 16),
						new DrawInfo(0, x + 16, y + 16),
						new DrawInfo(0, x + 24, y + 16),

						new DrawInfo(0, x, y + 24),
						new DrawInfo(0, x + 8, y + 24),
						new DrawInfo(0, x + 16, y + 24),
						new DrawInfo(0, x + 24, y + 24)
					);
				}
			}
		}

		public static void RoomDraw_4x4Corner_BothBG(Artist art, RoomObject obj)
		{
			RoomDraw_ArbitraryXByY(art, obj, sizex: 4, sizey: 4, bothbg: true);
		}

		public static void RoomDraw_4x4FloorIn4x4SuperSquare(Artist art, RoomObject obj)
		{
			RoomDraw_Arbtrary4x4in4x4SuperSquares(art, obj);
		}

		public static void RoomDraw_4x4FloorOneIn4x4SuperSquare(Artist art, RoomObject obj)
		{
			RoomDraw_Arbtrary4x4in4x4SuperSquares(art, obj);
		}

		public static void RoomDraw_4x4FloorTwoIn4x4SuperSquare(Artist art, RoomObject obj)
		{
			RoomDraw_Arbtrary4x4in4x4SuperSquares(art, obj);
		}

		public static void RoomDraw_4x4Object(Artist art, RoomObject obj)
		{
			RoomDraw_ArbitraryXByY(art, obj, sizex: 4, sizey: 4);
		}

		public static void RoomDraw_AgahnimsAltar(Artist art, RoomObject obj)
		{
			int tid = 0;
			for (int y = 0; y < 14 * 8; y += 8)
			{
				DrawTiles(art, obj, false,
					new DrawInfo(tid, 0, y),
					new DrawInfo(tid + 14, 8, y),
					new DrawInfo(tid + 14, 16, y),
					new DrawInfo(tid + 28, 24, y),
					new DrawInfo(tid + 42, 32, y),
					new DrawInfo(tid + 56, 40, y),
					new DrawInfo(tid + 70, 48, y),

					new DrawInfo(tid + 70, 56, y, hox: true),
					new DrawInfo(tid + 56, 64, y, hox: true),
					new DrawInfo(tid + 42, 72, y, hox: true),
					new DrawInfo(tid + 28, 80, y, hox: true),
					new DrawInfo(tid + 14, 88, y, hox: true),
					new DrawInfo(tid + 14, 96, y, hox: true),
					new DrawInfo(tid, 104, y, hflip: true)
				);
				tid++;
			}
		}

		public static void RoomDraw_AgahnimsWindows(Artist art, RoomObject obj)
		{
			RoomDraw_ArbitraryYByX(art, obj, sizex: 6, sizey: 4, xstart: 7, ystart: 4, tilestart: 0);
			RoomDraw_ArbitraryYByX(art, obj, sizex: 6, sizey: 4, xstart: 13, ystart: 4, tilestart: 0);
			RoomDraw_ArbitraryYByX(art, obj, sizex: 6, sizey: 4, xstart: 19, ystart: 4, tilestart: 0);

			int tid;
			//for (int i = 7 * 8; i < (3 * 48) + (7 * 8); i += 48)
			//{
			//	tid = 0;
			//	for (int x = 0; x < 6 * 48; x += 48)
			//	{
			//		DrawTiles(art, obj, false,
			//			new DrawInfo(tid++, x + i, 32),
			//			new DrawInfo(tid++, x + i, 40),
			//			new DrawInfo(tid++, x + i, 48),
			//			new DrawInfo(tid++, x + i, 56)
			//		);
			//	}
			//}

			// diagonal walls
			for (int x = 0; x < 7 * 8; x += 8)
			{
				DrawTiles(art, obj, false,
					new DrawInfo(24, 64 - x, 32 + x, hflip: false),
					new DrawInfo(25, 64 - x, 40 + x, hflip: false),
					new DrawInfo(26, 64 - x, 48 + x, hflip: false),
					new DrawInfo(27, 64 - x, 56 + x, hflip: false),
					new DrawInfo(28, 64 - x, 64 + x, hflip: false),

					new DrawInfo(24, 184 + x, 32 + x, hflip: true),
					new DrawInfo(25, 184 + x, 40 + x, hflip: true),
					new DrawInfo(26, 184 + x, 48 + x, hflip: true),
					new DrawInfo(27, 184 + x, 56 + x, hflip: true),
					new DrawInfo(28, 184 + x, 64 + x, hflip: true)
				);
			}

			// side walls
			for (int i = 11 * 8; i < (3 * 48) + (11 * 8); i += 48)
			{
				tid = 29;
				for (int y = 0; y < 6 * 8; y += 8)
				{
					DrawTiles(art, obj, false,
						new DrawInfo(tid, 16, y + i, hflip: false),
						new DrawInfo(tid++, 216, y + i, hflip: true),

						new DrawInfo(tid, 24, y + i, hflip: false),
						new DrawInfo(tid++, 208, y + i, hflip: true),

						new DrawInfo(tid, 32, y + i, hflip: false),
						new DrawInfo(tid++, 200, y + i, hflip: true),

						new DrawInfo(tid, 40, y + i, hflip: false),
						new DrawInfo(tid++, 192, y + i, hflip: true)
					);
				}
			}

			RoomDraw_ArbitraryYByX(art, obj, sizex: 6, sizey: 2, xstart: 12, ystart: 9, tilestart: 53);
			RoomDraw_ArbitraryYByX(art, obj, sizex: 6, sizey: 2, xstart: 18, ystart: 9, tilestart: 53);

			//for (int i = 12 * 8; i < (2 * 48) + (12 * 8); i += 48)
			//{
			//	tid = 53;
			//	for (int y = 9 * 8; y < (11 * 8); y += 8)
			//	{
			//		for (int x = 0; x < 6 * 8; x += 8)
			//		{
			//			DrawTiles(art, obj, false, new DrawInfo(tid++, x + i, y));
			//		}
			//	}
			//}

			RoomDraw_ArbitraryYByX(art, obj, sizex: 2, sizey: 6, xstart: 7, ystart: 14, tilestart: 65);
			RoomDraw_ArbitraryYByX(art, obj, sizex: 2, sizey: 6, xstart: 7, ystart: 20, tilestart: 65);

			//for (int i = 14 * 8; i < (2 * 48) + (14 * 8); i += 48)
			//{
			//	tid = 65;
			//	for (int y = 0; y < (6 * 8); y += 8)
			//	{
			//		DrawTiles(art, obj, false,
			//			new DrawInfo(tid++, 56, y + i),
			//			new DrawInfo(tid++, 64, y + i)
			//		);
			//	}
			//}

			RoomDraw_ArbitraryXByY(art, obj, sizex: 5, sizey: 5, xstart: 7, ystart: 9, tilestart: 77);

			//tid = 77;
			//for (int x = 7 * 8; x < (7 + 5) * 8; x += 8)
			//{
			//	for (int y = 9 * 8; y < (9 + 5) * 8; y += 8)
			//	{
			//		DrawTiles(art, obj, false, new DrawInfo(tid++, x, y));
			//	}
			//}
		}

		public static void RoomDraw_ArcheryGameTargetDoor(Artist art, RoomObject obj)
		{
			int tid = 0;
			for (int x = 0; x < 3 * 8; x += 8)
			{
				DrawTiles(art, obj, false,
					new DrawInfo(tid++, x, 8),
					new DrawInfo(tid++, x, 16),
					new DrawInfo(tid++, x, 24),

					// TODO this is copied correctly but seems very wrong
					new DrawInfo(tid++, x, 16),
					new DrawInfo(tid++, x, 24),
					new DrawInfo(tid++, x, 32)
				);
			}
		}

		public static void RoomDraw_AutoStairsMerged(Artist art, RoomObject obj)
		{
			RoomDraw_ArbitraryXByY(art, obj, sizex: 4, sizey: 4);
		}

		public static void RoomDraw_AutoStairs(Artist art, RoomObject obj)
		{
			RoomDraw_ArbitraryXByY(art, obj, sizex: 4, sizey: 4, bothbg: true);
		}

		public static void RoomDraw_BG2MaskFull(Artist art, RoomObject obj)
		{
			DrawTiles(art, obj, false,
				new DrawInfo(0, 0, 0),
				new DrawInfo(0, 8, 0),
				new DrawInfo(0, 16, 0),
				new DrawInfo(0, 24, 0),

				new DrawInfo(0, 0, 8),
				new DrawInfo(0, 0 + 8, 8),
				new DrawInfo(0, 0 + 16, 8),
				new DrawInfo(0, 0 + 24, 8),

				new DrawInfo(0, 0, 16),
				new DrawInfo(0, 8, 16),
				new DrawInfo(0, 16, 16),
				new DrawInfo(0, 24, 16),

				new DrawInfo(0, 0, 24),
				new DrawInfo(0, 8, 24),
				new DrawInfo(0, 16, 24),
				new DrawInfo(0, 24, 24)
			);
		}

		public static void RoomDraw_Bed4x5(Artist art, RoomObject obj)
		{
			RoomDraw_ArbitraryXByY(art, obj, sizex: 4, sizey: 5);
		}

		public static void RoomDraw_YBed4x5(Artist art, RoomObject obj)
		{
			RoomDraw_ArbitraryYByX(art, obj, sizex: 4, sizey: 5);
		}

		public static void RoomDraw_BigGrayRock(Artist art, RoomObject obj)
		{
			RoomDraw_ArbitraryXByY(art, obj, sizex: 4, sizey: 2);
			RoomDraw_ArbitraryXByY(art, obj, sizex: 4, sizey: 2, ystart: 2, tilestart: 8);
		}

		public static void RoomDraw_BigHole4x4_1to16(Artist art, RoomObject obj)
		{
			int size = (obj.Size + 3) * 8;

			DrawTiles(art, obj, false,
				new DrawInfo(8, 0, 0), //top left corner
				new DrawInfo(9, 8, 0),

				new DrawInfo(23, size, size),

				new DrawInfo(17, 0, size), //bottom left corner
				new DrawInfo(14, size, 0)
			);

			for (int x = 8; x < size; x += 8)
			{
				for (int y = 8; y < size; y += 8)
				{
					DrawTiles(art, obj, false, new DrawInfo(0, x, y));
				}
				DrawTiles(art, obj, false,
					new DrawInfo(10, x, 0),
					new DrawInfo(19, x, size)
				);
			}

			for (int y = 8; y < size; y += 8)
			{
				DrawTiles(art, obj, false,
					new DrawInfo(9, 0, y),
					new DrawInfo(15, size, y)
				);
			}
		}

		public static void RoomDraw_BigLightBeamOnFloor(Artist art, RoomObject obj)
		{
			RoomDraw_ArbitraryXByY(art, obj, sizex: 8, sizey: 4);
			RoomDraw_ArbitraryXByY(art, obj, sizex: 8, sizey: 4, ystart: 4, tilestart: 32);


			//int tid = 0;
			//for (int x = 0; x < 8 * 8; x += 8)
			//{
			//	for (int y = 0; y < 4 * 8; y += 8)
			//	{
			//		DrawTiles(art, obj, false,
			//			new DrawInfo(tid, x, y),
			//			new DrawInfo(tid + 32, x, y + 32)
			//		);
			//
			//		tid++;
			//	}
			//}
		}

		public static void RoomDraw_BigWallDecor(Artist art, RoomObject obj)
		{
			RoomDraw_ArbitraryXByY(art, obj, sizex: 8, sizey: 3);
		}

		public static void RoomDraw_BombableFloor(Artist art, RoomObject obj)
		{
			// 00 04 02 06
			// 08 12 10 14
			// 01 05 03 07
			// 09 13 11 15
			DrawTiles(art, obj, false,
				new DrawInfo(00, 0, 0),
				new DrawInfo(01, 0, 16),
				new DrawInfo(02, 16, 0),
				new DrawInfo(03, 16, 16),
				new DrawInfo(04, 8, 0),
				new DrawInfo(05, 8, 16),
				new DrawInfo(06, 24, 0),
				new DrawInfo(07, 24, 16),
				new DrawInfo(08, 0, 8),
				new DrawInfo(09, 0, 24),
				new DrawInfo(10, 16, 8),
				new DrawInfo(11, 16, 24),
				new DrawInfo(12, 8, 8),
				new DrawInfo(13, 8, 24),
				new DrawInfo(14, 24, 8),
				new DrawInfo(15, 24, 24)
			);
		}

		public static void RoomDraw_CheckIfWallIsMoved(Artist art, RoomObject obj)
		{
			// Nothing
		}

		public static void RoomDraw_ChestPlatformVerticalWall(Artist art, RoomObject obj)
		{
			RoomDraw_ArbitraryXByY(art, obj, sizex: 2, sizey: 3);
		}

		public static void RoomDraw_ClosedChestPlatform(Artist art, RoomObject obj)
		{

			int sizex = (obj.Size >> 2) & 0x03;
			int sizey = obj.Size & 0x03;

			int sizex2 = (sizex + 4) * 16;
			int sizey2 = (sizey + 1) * 16;

			int tid = 0;
			for (int x = 0; x < 3 * 8; x += 8)
			{
				int xx2 = sizex2 + 24 + x;
				for (int y = 0; y < 3 * 8; y += 8)
				{
					int yy2 = y + sizey2 + 24;
					DrawTiles(art, obj, false,
						new DrawInfo(tid, x, y),
						new DrawInfo(tid + 15, xx2, y),
						new DrawInfo(tid + 40, x, yy2),
						new DrawInfo(tid + 55, xx2, yy2)
					);
					tid++;
				}
			}

			int xxxxxx = 8 * sizex;
			int yyyyyy = 8 * sizey;

			DrawTiles(art, obj, false,
				new DrawInfo(64, xxxxxx + 48, yyyyyy + 24),
				new DrawInfo(66, xxxxxx + 56, yyyyyy + 24),
				new DrawInfo(65, xxxxxx + 48, yyyyyy + 32),
				new DrawInfo(67, xxxxxx + 56, yyyyyy + 32)
			);

			for (int x = 0; x < sizex2; x += 16)
			{
				DrawTiles(art, obj, false,
					new DrawInfo(09, x + 24, 0),
					new DrawInfo(12, x + 32, 0),
					new DrawInfo(10, x + 24, 8),
					new DrawInfo(13, x + 32, 8),
					new DrawInfo(11, x + 24, 16),
					new DrawInfo(14, x + 32, 16),
					new DrawInfo(49, x + 24, sizey2 + 24),
					new DrawInfo(52, x + 32, sizey2 + 24),
					new DrawInfo(50, x + 24, sizey2 + 32),
					new DrawInfo(53, x + 32, sizey2 + 32),
					new DrawInfo(51, x + 24, sizey2 + 40),
					new DrawInfo(54, x + 32, sizey2 + 40)
				);

				for (int y = 0; y < sizey2; y += 16)
				{
					DrawTiles(art, obj, false,
						new DrawInfo(30, x + 24, y + 24),
						new DrawInfo(31, x + 32, y + 24),
						new DrawInfo(32, x + 24, y + 32),
						new DrawInfo(33, x + 32, y + 32)
					);
				}

			}

			for (int y = 0; y < sizey2; y += 16)
			{
				DrawTiles(art, obj, false,
					new DrawInfo(24, 0, y + 24),
					new DrawInfo(25, 8, y + 24),
					new DrawInfo(26, 16, y + 24),
					new DrawInfo(27, 0, y + 32),
					new DrawInfo(28, 8, y + 32),
					new DrawInfo(29, 16, y + 32),
					new DrawInfo(34, sizex2 + 24, y + 24),
					new DrawInfo(35, sizex2 + 32, y + 24),
					new DrawInfo(36, sizex2 + 40, y + 24),
					new DrawInfo(37, sizex2 + 24, y + 32),
					new DrawInfo(38, sizex2 + 32, y + 32),
					new DrawInfo(39, sizex2 + 40, y + 32)
				);
			}

		}

		public static void RoomDraw_DamFloodGate(Artist art, RoomObject obj)
		{
			RoomDraw_ArbitraryXByY(art, obj, sizex: 10, sizey: 4);
		}

		public static void RoomDraw_DiagonalAcute_1to16(Artist art, RoomObject obj)
		{
			RoomDraw_ArbitraryDiagonalAcute_1to16(art, obj, false);
		}

		public static void RoomDraw_DiagonalAcute_1to16_BothBG(Artist art, RoomObject obj)
		{
			RoomDraw_ArbitraryDiagonalAcute_1to16(art, obj, true);
		}

		public static void RoomDraw_DiagonalCeilingBottomLeft(Artist art, RoomObject obj)
		{
			int length = 8 * (obj.Size + 4);
			int size = length;

			for (int s = 0; s < size; s += 8)
			{
				for (int i = 0; i < length; i += 8)
				{
					DrawTiles(art, obj, false, new DrawInfo(0, i, s));
				}

				length += 8;
			}
		}

		public static void RoomDraw_DiagonalCeilingBottomRight(Artist art, RoomObject obj)
		{
			int size = 8 * (obj.Size + 4);

			for (int s = 0; s < size; s += 8)
			{
				for (int i = s; i < size; i += 8)
				{
					DrawTiles(art, obj, false, new DrawInfo(0, i, -s));
				}
			}
		}

		public static void RoomDraw_DiagonalCeilingTopLeft(Artist art, RoomObject obj)
		{
			int length = 8 * (obj.Size + 4);
			int size = length;

			for (int s = 0; s < size; s += 8)
			{
				for (int i = s; i < length; i += 8)
				{
					DrawTiles(art, obj, false, new DrawInfo(0, i, s));
				}

				length -= 8;
			}
		}

		public static void RoomDraw_DiagonalCeilingTopRight(Artist art, RoomObject obj)
		{
			int size = 8 * (obj.Size + 4);

			for (int s = 0; s < size; s += 8)
			{
				for (int i = s; i < size; i += 8)
				{
					DrawTiles(art, obj, false, new DrawInfo(0, i, s));
				}
			}
		}

		public static void RoomDraw_DiagonalGrave_1to16(Artist art, RoomObject obj)
		{
			obj.Height = (obj.Size + 10) * 8;
			obj.Width = (obj.Size + 6) * 8;
			obj.DiagonalFix = true;

			for (int s = 0; s < obj.Width; s += 8)
			{
				DrawTiles(art, obj, false,
					new DrawInfo(0, s, s),
					new DrawInfo(1, s, 8 + s),
					new DrawInfo(2, s, 16 + s),
					new DrawInfo(3, s, 24 + s),
					new DrawInfo(4, s, 32 + s)
				);
			}
		}
		public static void RoomDraw_DiagonalGrave_1to16_BothBG(Artist art, RoomObject obj)
		{
			obj.Height = (obj.Size + 10) * 8;
			obj.Width = (obj.Size + 6) * 8;
			obj.DiagonalFix = true;

			for (int s = 0; s < obj.Width; s += 8)
			{
				DrawTiles(art, obj, true,
					new DrawInfo(0, s, s),
					new DrawInfo(1, s, 8 + s),
					new DrawInfo(2, s, 16 + s),
					new DrawInfo(3, s, 24 + s),
					new DrawInfo(4, s, 32 + s)
				);
			}
		}

		public static void RoomDraw_DoorSwitcherer(Artist art, RoomObject obj)
		{
			// TODO ROOM DRAW
		}

		public static void RoomDraw_Downwards1x1Solid_1to16_plus3(Artist art, RoomObject obj)
		{
			for (int s = 0; s < (obj.Size + 4) * 8; s += 8)
			{
				DrawTiles(art, obj, false, new DrawInfo(0, 0, s));
			}
		}

		public static void RoomDraw_Downwards2x2_1to15or32(Artist art, RoomObject obj)
		{
			int size = obj.Size == 0 ? 32 : obj.Size;
			RoomDraw_DownwardsXbyY(art, obj, size, sizex: 2, sizey: 2);
		}

		public static void RoomDraw_Downwards2x2_1to16(Artist art, RoomObject obj)
		{
			RoomDraw_DownwardsXbyY(art, obj, obj.Size + 1, sizex: 2, sizey: 2);
		}

		public static void RoomDraw_Downwards4x2_1to15or26(Artist art, RoomObject obj)
		{
			int size = obj.Size == 0 ? 26 : obj.Size;

			for (int s = 0; s < (size * 16); s += 16)
			{
				DrawTiles(art, obj, true,
					new DrawInfo(0, 0, s),
					new DrawInfo(1, 8, s),
					new DrawInfo(2, 16, s),
					new DrawInfo(3, 24, s),

					new DrawInfo(4, 0, s + 8),
					new DrawInfo(5, 8, s + 8),
					new DrawInfo(6, 16, s + 8),
					new DrawInfo(7, 24, s + 8)
				);
			}
		}

		public static void RoomDraw_Downwards4x2_1to16_BothBG(Artist art, RoomObject obj)
		{
			for (int s = 0; s < ((obj.Size + 1) * 16); s += 16)
			{
				DrawTiles(art, obj, true,
					new DrawInfo(0, 0, s),
					new DrawInfo(1, 8, s),
					new DrawInfo(2, 16, s),
					new DrawInfo(3, 24, s),

					new DrawInfo(4, 0, s + 8),
					new DrawInfo(5, 8, s + 8),
					new DrawInfo(6, 16, s + 8),
					new DrawInfo(7, 24, s + 8)
				);
			}
		}

		public static void RoomDraw_DownwardsBar2x5_1to16(Artist art, RoomObject obj)
		{
			int size = (obj.Size + 2) * 16;

			for (int s = 0; s < size; s += 16)
			{
				DrawTiles(art, obj, false,
					new DrawInfo(2, 0, s + 8),
					new DrawInfo(3, 8, s + 8),
					new DrawInfo(2, 0, s + 16),
					new DrawInfo(3, 8, s + 16)
				);
			}
			DrawTiles(art, obj, false,
				new DrawInfo(0, 0, 0),
				new DrawInfo(1, 8, 0)
			);
		}

		public static void RoomDraw_DownwardsBigRail3x1_1to16plus5(Artist art, RoomObject obj)
		{
			int size1 = (obj.Size + 2) * 16;

			for (int s = 0; s < size1; s += 16)
			{
				DrawTiles(art, obj, false,
					new DrawInfo(4, 0, s),
					new DrawInfo(5, 8, s)
				);
			}

			int size2 = (obj.Size + 3) * 8;

			DrawTiles(art, obj, false,
				new DrawInfo(0, 0, 0),
				new DrawInfo(1, 0, 8),
				new DrawInfo(2, 8, 0),
				new DrawInfo(3, 8, 8),

				new DrawInfo(6, 0, size2),
				new DrawInfo(7, 0, size2 + 8),
				new DrawInfo(8, 0, size2 + 16),

				new DrawInfo(9, 8, size2),
				new DrawInfo(10, 8, size2 + 8),
				new DrawInfo(11, 8, size2 + 16)
			);
		}

		public static void RoomDraw_DownwardsBlock2x2spaced2_1to16(Artist art, RoomObject obj)
		{
			RoomDraw_DownwardsXbyY(art, obj, obj.Size + 1, sizex: 2, sizey: 2, spacing: 2);
		}

		public static void RoomDraw_DownwardsCannonHole3x4_1to16(Artist art, RoomObject obj)
		{
			int size = (obj.Size + 1) * 16;

			for (int s = 16; s < size; s += 16)
			{
				DrawTiles(art, obj, false,
					new DrawInfo(6, 0, s),
					new DrawInfo(7, 8, s),
					new DrawInfo(8, 16, s),

					new DrawInfo(9, 0, s + 8),
					new DrawInfo(10, 8, s + 8),
					new DrawInfo(11, 16, s + 8)
				);
			}

			DrawTiles(art, obj, false,
				new DrawInfo(0, 0, 0),
				new DrawInfo(1, 8, 0),
				new DrawInfo(2, 16, 0),

				new DrawInfo(3, 0, 8),
				new DrawInfo(4, 8, 8),
				new DrawInfo(5, 16, 8),

				new DrawInfo(12, 0, size),
				new DrawInfo(13, 8, size),
				new DrawInfo(14, 16, size),

				new DrawInfo(15, 0, size + 8),
				new DrawInfo(16, 8, size + 8),
				new DrawInfo(17, 16, size + 8)
			);
		}

		public static void RoomDraw_DownwardsDecor2x2spaced12_1to16(Artist art, RoomObject obj)
		{
			RoomDraw_DownwardsXbyY(art, obj, obj.Size + 1, sizex: 2, sizey: 2, spacing: 12);
		}

		public static void RoomDraw_DownwardsDecor3x4spaced2_1to16(Artist art, RoomObject obj)
		{
			RoomDraw_DownwardsXbyY(art, obj, obj.Size + 1, sizex: 3, sizey: 4, spacing: 2);
		}

		public static void RoomDraw_DownwardsDecor2x4spaced8_1to16(Artist art, RoomObject obj)
		{
			RoomDraw_DownwardsXbyY(art, obj, obj.Size + 1, sizex: 2, sizey: 4, spacing: 8);
		}

		public static void RoomDraw_DownwardsDecor4x2spaced4_1to16(Artist art, RoomObject obj)
		{
			RoomDraw_DownwardsXbyY(art, obj, obj.Size + 1, sizex: 4, sizey: 2, spacing: 4);
		}

		public static void RoomDraw_DownwardsDecor4x4spaced2_1to16(Artist art, RoomObject obj)
		{
			RoomDraw_DownwardsXbyY(art, obj, obj.Size + 1, sizex: 4, sizey: 4, spacing: 2);
		}

		public static void RoomDraw_DownwardsDecor3x4spaced4_1to16(Artist art, RoomObject obj)
		{
			RoomDraw_DownwardsXbyY(art, obj, obj.Size + 1, sizex: 3, sizey: 4, spacing: 4);
		}

		public static void RoomDraw_DownwardsEdge1x1_1to16(Artist art, RoomObject obj)
		{
			for (int s = 0; s <= obj.Size * 8; s += 8)
			{
				DrawTiles(art, obj, false, new DrawInfo(0, 0, s));
			}
		}

		public static void RoomDraw_DownwardsEdge1x1_1to16plus7(Artist art, RoomObject obj)
		{
			for (int s = 0; s < (obj.Size + 8) * 8; s += 8)
			{
				DrawTiles(art, obj, false, new DrawInfo(0, 0, s));
			}
		}

		public static void RoomDraw_DownwardsFloor4x4_1to16(Artist art, RoomObject obj)
		{
			RoomDraw_DownwardsXbyY(art, obj, obj.Size + 1, sizex: 4, sizey: 4);
		}

		public static void RoomDraw_DownwardsHasEdge1x1_1to16_plus23(Artist art, RoomObject obj)
		{
			for (int s = 8; s < ((obj.Size + 22) * 8); s += 8)
			{
				DrawTiles(art, obj, false, new DrawInfo(1, 0, s));
			}

			DrawTiles(art, obj, false,
				new DrawInfo(0, 0, 0),
				new DrawInfo(2, 0, (obj.Size * 8) + 176)
			);
		}

		public static void RoomDraw_DownwardsHasEdge1x1_1to16_plus3(Artist art, RoomObject obj)
		{
			for (int s = 8; s <= ((obj.Size + 1) * 8); s += 8)
			{
				DrawTiles(art, obj, false, new DrawInfo(1, 0, s));
			}

			DrawTiles(art, obj, false,
				new DrawInfo(0, 0, 0, under: obj.Tiles[1].ToUnsignedShort()),
				new DrawInfo(2, 0, (obj.Size * 8) + 16)
			);
		}

		public static void RoomDraw_DownwardsLine1x1_1to16plus1(Artist art, RoomObject obj)
		{
			for (int s = 0; s < ((obj.Size + 2) * 8); s += 8)
			{
				DrawTiles(art, obj, false, new DrawInfo(0, 0, s));
			}
		}

		public static void RoomDraw_DownwardsPillar2x4spaced2_1to16(Artist art, RoomObject obj)
		{
			RoomDraw_DownwardsXbyY(art, obj, obj.Size + 1, sizex: 2, sizey: 4, spacing: 2);
		}

		public static void RoomDraw_DownwardsWithCorners2x1_1to16_plus12(Artist art, RoomObject obj)
		{
			int size = (obj.Size + 12) * 8;

			for (int s = 8; s < size; s += 8)
			{
				DrawTiles(art, obj, false,
					new DrawInfo(0, 0, s),
					new DrawInfo(3, 8, s)
				);
			}

			DrawTiles(art, obj, false,
				new DrawInfo(1, 8, 0),
				new DrawInfo(2, 8, 8),
				new DrawInfo(4, 8, size),
				new DrawInfo(5, 8, size + 8)
			);
		}

		public static void RoomDraw_DrawRightwards3x6(Artist art, RoomObject obj)
		{
			RoomDraw_ArbitraryXByY(art, obj, sizex: 6, sizey: 3);
		}

		public static void RoomDraw_DrenchingWaterFace(Artist art, RoomObject obj)
		{
			RoomDraw_ArbitraryYByX(art, obj, sizex: 4, sizey: 7);
		}

		public static void RoomDraw_EmptyWaterFace(Artist art, RoomObject obj)
		{
			RoomDraw_ArbitraryYByX(art, obj, sizex: 4, sizey: 3);
		}

		public static void RoomDraw_FloorLight(Artist art, RoomObject obj)
		{
			RoomDraw_ArbitraryXByY(art, obj, sizex: 8, sizey: 4);
			RoomDraw_ArbitraryXByY(art, obj, sizex: 8, sizey: 4, ystart: 4, tilestart: 32);
			//int tid = 0;
			//for (int x = 0; x < 8 * 8; x += 8)
			//{
			//	for (int y = 0; y < 4 * 8; y += 8)
			//	{
			//		DrawTiles(art, obj, false,
			//			new DrawInfo(tid, x, y),
			//			new DrawInfo(tid + 32, x, y + 32)
			//		);
			//		tid++;
			//	}
			//}
		}

		// TODO wrong
		public static void RoomDraw_FortuneTellerRoom(Artist art, RoomObject obj)
		{
			for (int x = 8; x < (13 * 8); x += 8)
			{
				DrawTiles(art, obj, false,
					new DrawInfo(0, x, 0),
					new DrawInfo(0, x, 8),
					new DrawInfo(1, x, 16)
				);
			}


			for (int x = 0; x < (16 * 7); x += 16)
			{
				DrawTiles(art, obj, false,
					new DrawInfo(2, x, 24),
					new DrawInfo(2, x + 8, 24, hox: true),

					new DrawInfo(3, x, 32),
					new DrawInfo(3, x + 8, 32, hox: true),

					new DrawInfo(4, x, 40),
					new DrawInfo(4, x + 8, 40, hox: true)
				);
			}

			for (int x = 4 * 8; x < 10 * 8; x += 8)
			{

				DrawTiles(art, obj, false,
					new DrawInfo(6, x, 32),
					new DrawInfo(7, x, 40),

					new DrawInfo(6, x, 32),
					new DrawInfo(7, x, 40)
				);
			}

			DrawTiles(art, obj, false,
				new DrawInfo(8, 0, 0),
				new DrawInfo(8, 0, 8),
				new DrawInfo(9, 0, 16),

				new DrawInfo(8, 104, 0),
				new DrawInfo(8, 104, 8),
				new DrawInfo(9, 104, 16)
			);



			RoomDraw_ArbitraryXByY(art, obj, sizex: 4, sizey: 4, xstart: 3, ystart: 10, tilestart: 10);
			RoomDraw_ArbitraryXByY(art, obj, sizex: 4, sizey: 4, xstart: 6, ystart: 10, tilestart: 10);

		}

		public static void RoomDraw_GanonTriforceFloorDecor(Artist art, RoomObject obj)
		{
			RoomDraw_ArbitraryXByY(art, obj, sizex: 4, sizey: 4);
			RoomDraw_ArbitraryXByY(art, obj, sizex: 4, sizey: 4, xstart: -2, ystart: 4, tilestart: 16);
			RoomDraw_ArbitraryXByY(art, obj, sizex: 4, sizey: 4, xstart: +2, ystart: 4, tilestart: 16);
		}

		public static void RoomDraw_HorizontalTurtleRockPipe(Artist art, RoomObject obj)
		{
			RoomDraw_ArbitraryXByY(art, obj, sizex: 6, sizey: 4);
		}

		public static void RoomDraw_InterRoomFatStairs(Artist art, RoomObject obj)
		{
			RoomDraw_ArbitraryXByY(art, obj, sizex: 4, sizey: 4);
		}

		public static void RoomDraw_KholdstareShell(Artist art, RoomObject obj)
		{
			RoomDraw_ArbitraryYByX(art, obj, sizex: 10, sizey: 8);
		}

		public static void RoomDraw_LampCones(Artist art, RoomObject obj)
		{
			RoomDraw_ArbitraryXByY(art, obj, sizex: 4, sizey: 4);
		}

		public static void RoomDraw_LightBeamOnFloor(Artist art, RoomObject obj)
		{
			RoomDraw_ArbitraryXByY(art, obj, sizex: 4, sizey: 4);

			DrawTiles(art, obj, false,
				new DrawInfo(0, 0, 32),
				new DrawInfo(1, 8, 32),
				new DrawInfo(2, 16, 32),
				new DrawInfo(3, 24, 32),

				new DrawInfo(0, 0, 40),
				new DrawInfo(1, 8, 40),
				new DrawInfo(2, 16, 40),
				new DrawInfo(3, 24, 40)
			);

			RoomDraw_ArbitraryXByY(art, obj, sizex: 4, sizey: 4, ystart: 6, tilestart: 16);

			//int tid = 16;
			//for (int x = 0; x < 4 * 8; x += 8)
			//{
			//	DrawTiles(art, obj, false,
			//		new DrawInfo(tid++, x, 48),
			//		new DrawInfo(tid++, x, 56),
			//		new DrawInfo(tid++, x, 64),
			//		new DrawInfo(tid++, x, 72)
			//	);
			//}

		}

		public static void RoomDraw_MagicBatAltar(Artist art, RoomObject obj)
		{
			RoomDraw_ArbitraryXByY(art, obj, sizex: 8, sizey: 7);
		}

		public static void RoomDraw_MovingWallEast(Artist art, RoomObject obj)
		{
			int sizey = (obj.Size >> 2) & 0x03;
			int sizex = 64 * (1 + (obj.Size & 0x03));


			int sizey2 = sizey * 32;
			DrawTiles(art, obj, false,
				new DrawInfo(0, 0, 0),
				new DrawInfo(3, 8, 0),
				new DrawInfo(6, 16, 0),
				new DrawInfo(1, 0, 8),
				new DrawInfo(4, 8, 8),
				new DrawInfo(7, 16, 8),
				new DrawInfo(2, 0, 16),
				new DrawInfo(5, 8, 16),
				new DrawInfo(8, 16, 16),
				new DrawInfo(15, 0, 104 + sizey2),
				new DrawInfo(18, 8, 104 + sizey2),
				new DrawInfo(21, 16, 104 + sizey2),
				new DrawInfo(16, 0, 112 + sizey2),
				new DrawInfo(19, 8, 112 + sizey2),
				new DrawInfo(22, 16, 112 + sizey2),
				new DrawInfo(17, 0, 120 + sizey2),
				new DrawInfo(20, 8, 120 + sizey2),
				new DrawInfo(23, 16, 120 + sizey2)
			);

			sizey *= 32;

			for (int x = 0; x < sizex; x += 16)
			{
				for (int y = 0; y < 256 + sizey; y += 16)
				{
					DrawTiles(art, obj, false,
						new DrawInfo(24, x + 24, y),
						new DrawInfo(25, x + 32, y),
						new DrawInfo(26, x + 24, y + 8),
						new DrawInfo(27, x + 32, y + 8)
					);
				}
			}

			for (int y = 0; y < 160 + sizey; y++)
			{
				DrawTiles(art, obj, false,
					new DrawInfo(9, 0, y + 24),
					new DrawInfo(10, 8, y + 24),
					new DrawInfo(11, 16, y + 24),
					new DrawInfo(12, 0, y + 32),
					new DrawInfo(13, 8, y + 32),
					new DrawInfo(14, 16, y + 32)
				);
			}
		}

		public static void RoomDraw_MovingWallWest(Artist art, RoomObject obj)
		{
			const int offsetx = 64;
			int sizey = (obj.Size >> 2) & 0x03;
			int sizex = (obj.Size) & 0x03;

			int sizex2 = 64 * sizex + offsetx;
			int sizey2 = 32 * sizey;

			DrawTiles(art, obj, false,
				new DrawInfo(00, sizex2 + 64, sizey2),
				new DrawInfo(03, sizex2 + 72, sizey2),
				new DrawInfo(06, sizex2 + 80, sizey2),
				new DrawInfo(01, sizex2 + 64, sizey2 + 8), 
				new DrawInfo(04, sizex2 + 72, sizey2 + 8), 
				new DrawInfo(07, sizex2 + 80, sizey2 + 8), 
				new DrawInfo(02, sizex2 + 64, sizey2 + 16),
				new DrawInfo(05, sizex2 + 72, sizey2 + 16),
				new DrawInfo(08, sizex2 + 80, sizey2 + 16),
				new DrawInfo(15, sizex2 + 64, sizey2 + 104),
				new DrawInfo(18, sizex2 + 72, sizey2 + 104),
				new DrawInfo(21, sizex2 + 80, sizey2 + 104),
				new DrawInfo(16, sizex2 + 64, sizey2 + 112),
				new DrawInfo(19, sizex2 + 72, sizey2 + 112),
				new DrawInfo(22, sizex2 + 80, sizey2 + 112),
				new DrawInfo(17, sizex2 + 64, sizey2 + 120),
				new DrawInfo(20, sizex2 + 72, sizey2 + 120),
				new DrawInfo(23, sizex2 + 80, sizey2 + 120)
			);

			for (int x = 0; x < (sizex + 1) * 64; x += 64)
			{
				for (int y = 0; y < (sizey + 4) * 32; y += 32)
				{
					DrawTiles(art, obj, false,
						new DrawInfo(24, sizex2 + offsetx, y),
						new DrawInfo(25, sizex2 + offsetx + 8, y),
						new DrawInfo(26, sizex2 + offsetx, y + 8),
						new DrawInfo(27, sizex2 + offsetx + 8, y + 8)
					);
				}
			}

			for (int y = 0; y < sizey2 + 80; y += 16)
			{
				DrawTiles(art, obj, false,
					new DrawInfo(09, sizex2 + 64, y + 24),
					new DrawInfo(10, sizex2 + 72, y + 24),
					new DrawInfo(11, sizex2 + 80, y + 24),
					new DrawInfo(12, sizex2 + 64, y + 32),
					new DrawInfo(13, sizex2 + 72, y + 32),
					new DrawInfo(14, sizex2 + 80, y + 32)
				);
			}
		}

		public static void RoomDraw_Nothing(Artist art, RoomObject obj)
		{
			// Nothing
		}

		public static void RoomDraw_Rightwards2x4spaced4_1to16(Artist art, RoomObject obj)
		{
			RoomDraw_RightwardsXbyY(art, obj, obj.Size + 1, sizex: 2, sizey: 4, spacing: 4);
		}

		public static void RoomDraw_OpenChestPlatform(Artist art, RoomObject obj)
		{
			int sizex = (obj.Size >> 2) & 0x03;
			int sizey = obj.Size & 0x03;

			int sizex2 = sizex * 16;
			int sizey2 = sizey * 16;

			int sizex3 = sizex * 8;

			DrawTiles(art, obj, false,
				new DrawInfo(18, sizex2 + 72, 0),
				new DrawInfo(0, 0, 0),
				new DrawInfo(1, 0, sizey2 + 40),
				new DrawInfo(2, 0, sizey2 + 48),
				new DrawInfo(19, sizex2 + 72, sizey2 + 40),
				new DrawInfo(20, sizex2 + 72, sizey2 + 48),
				new DrawInfo(9, sizex3 + 24, 0),
				new DrawInfo(9, sizex3 + 32, 0),
				new DrawInfo(9, sizex3 + 40, 0),
				new DrawInfo(9, sizex3 + 48, 0),
				new DrawInfo(10, sizex3 + 24, sizey2 + 40),
				new DrawInfo(10, sizex3 + 32, sizey2 + 40),
				new DrawInfo(10, sizex3 + 40, sizey2 + 40),
				new DrawInfo(10, sizex3 + 48, sizey2 + 40),
				new DrawInfo(11, sizex3 + 24, sizey2 + 48),
				new DrawInfo(11, sizex3 + 32, sizey2 + 48),
				new DrawInfo(11, sizex3 + 40, sizey2 + 48),
				new DrawInfo(11, sizex3 + 48, sizey2 + 48),
				new DrawInfo(7, sizex3 + 16, sizey2 + 40),
				new DrawInfo(6, sizex3 + 16, sizey2 + 32),
				new DrawInfo(12, sizex3 + 56, sizey2 + 32),
				new DrawInfo(13, sizex3 + 56, sizey2 + 40),
				new DrawInfo(14, sizex3 + 56, sizey2 + 48),
				new DrawInfo(8, sizex3 + 16, sizey2 + 48)
			);

			for (int y = 0; y < sizey2 + 32; y += 16)
			{
				DrawTiles(art, obj, false,
					new DrawInfo(0, 0, 8 + y),
					new DrawInfo(0, 0, 16 + y),
					new DrawInfo(9, sizex3 + 24, 8 + y),
					new DrawInfo(9, sizex3 + 32, 8 + y),
					new DrawInfo(9, sizex3 + 40, 8 + y),
					new DrawInfo(9, sizex3 + 48, 8 + y),
					new DrawInfo(9, sizex3 + 24, 16 + 6),
					new DrawInfo(9, sizex3 + 32, 16 + 6),
					new DrawInfo(9, sizex3 + 40, 16 + 6),
					new DrawInfo(9, sizex3 + 48, 16 + 6),
					new DrawInfo(6, sizex3 + 16, y),
					new DrawInfo(6, sizex3 + 16, 8 + y),
					new DrawInfo(12, 56 + sizex3, y),
					new DrawInfo(12, 56 + sizex3, 8 + y),
					new DrawInfo(18, 72 + sizex2, 8 + y),
					new DrawInfo(18, 72 + sizex2, 16 + y)
				);

				for (int x = 8; x < sizex3 + 16; x += 8)
				{
					DrawTiles(art, obj, false,
						new DrawInfo(3, x, y),
						new DrawInfo(3, x, y + 8),
						new DrawInfo(15, x + sizex3 + 56, y),
						new DrawInfo(15, x + sizex3 + 56, y + 8)
					);
				}
			}

			for (int x = 8; x < sizex3 + 16; x += 8)
			{
				DrawTiles(art, obj, false,
					new DrawInfo(3, x, sizey2 + 32),
					new DrawInfo(4, x, sizey2 + 40),
					new DrawInfo(5, x, sizey2 + 48),
					new DrawInfo(15, x + sizex3 + 56, sizey2 + 32),
					new DrawInfo(16, x + sizex3 + 56, sizey2 + 40),
					new DrawInfo(17, x + sizex3 + 56, sizey2 + 48)
				);
			}

		}

		public static void RoomDraw_PortraitOfMario(Artist art, RoomObject obj)
		{
			RoomDraw_ArbitraryYByX(art, obj, sizex: 4, sizey: 2);
		}

		public static void RoomDraw_PrisonCell(Artist art, RoomObject obj)
		{
			DrawTiles(art, obj, false,
				new DrawInfo(0, 0, 0),
				new DrawInfo(0, 120, 0, hflip: true),
				new DrawInfo(1, 8, 0),
				new DrawInfo(1, 112, 0, hflip: true),
				new DrawInfo(3, 8, 16),
				new DrawInfo(3, 112, 16, hflip: true)
			);

			for (int x = 16; x < 56; x += 8)
			{
				DrawTiles(art, obj, false,
					new DrawInfo(1, x, 0),
					new DrawInfo(1, x + 56, 0, hflip: true),
					new DrawInfo(2, x, 8),
					new DrawInfo(2, x + 56, 8, hflip: true),
					new DrawInfo(4, x, 16),
					new DrawInfo(4, x, 16, hflip: true),
					new DrawInfo(5, x + 56, 24),
					new DrawInfo(5, x, 24, hflip: true)
				);
			}
		}

		public static void RoomDraw_Rightwards1x1Solid_1to16_plus3(Artist art, RoomObject obj)
		{
			RoomDraw_RightwardsXbyY(art, obj, obj.Size + 4, sizex: 1, sizey: 1);
		}

		public static void RoomDraw_Rightwards1x2_1to16_plus2(Artist art, RoomObject obj)
		{
			for (int s = 0; s <= (obj.Size  * 16); s += 16)
			{
				DrawTiles(art, obj, false,
					new DrawInfo(3, s + 8, 0),
					new DrawInfo(4, s + 8, 8),
					new DrawInfo(5, s + 8, 16),
					new DrawInfo(3, s + 16, 0),
					new DrawInfo(4, s + 16, 8),
					new DrawInfo(5, s + 16, 16)
				);
			}

			DrawTiles(art, obj, false,
				new DrawInfo(0, 0, 0),
				new DrawInfo(1, 0, 8),
				new DrawInfo(2, 0, 16),
				new DrawInfo(6, (obj.Size * 16) + 24, 0),
				new DrawInfo(7, (obj.Size * 16) + 24, 8),
				new DrawInfo(8, (obj.Size * 16) + 24, 16)
			);
		}

		public static void RoomDraw_Rightwards2x2_1to15or32(Artist art, RoomObject obj)
		{
			int size = obj.Size == 0 ? 32 : obj.Size;

			RoomDraw_RightwardsXbyY(art, obj, size, sizex: 2, sizey: 2);
		}

		public static void RoomDraw_Rightwards2x2_1to16(Artist art, RoomObject obj)
		{
			RoomDraw_RightwardsXbyY(art, obj, obj.Size + 1, sizex: 2, sizey: 2);
		}

		public static void RoomDraw_Rightwards2x4spaced4_1to16_BothBG(Artist art, RoomObject obj)
		{
			RoomDraw_RightwardsXbyY(art, obj, obj.Size + 1, sizex: 2, sizey: 4, bothbg: true);
		}

		public static void RoomDraw_Rightwards2x4_1to15or26(Artist art, RoomObject obj)
		{
			int size = obj.Size == 0 ? 26 : obj.Size;

			RoomDraw_RightwardsXbyY(art, obj, size, sizex: 2, sizey: 4);
		}

		public static void RoomDraw_Rightwards4x4_1to16(Artist art, RoomObject obj)
		{
			RoomDraw_RightwardsXbyY(art, obj, obj.Size + 1, sizex: 4, sizey: 4);
		}

		public static void RoomDraw_RightwardsBar4x3_1to16(Artist art, RoomObject obj)
		{
			int size = (obj.Size + 1) * 16;

			for (int s = 8; s < size + 16; s += 16)
			{
				DrawTiles(art, obj, false,
					new DrawInfo(3, s, 0),
					new DrawInfo(3, s + 8, 0),
					new DrawInfo(4, s, 8),
					new DrawInfo(4, s + 8, 8),
					new DrawInfo(5, s, 16),
					new DrawInfo(5, s + 8, 16)
				);
			}

			DrawTiles(art, obj, false,
				new DrawInfo(0, 0, 0),
				new DrawInfo(1, 0, 8),
				new DrawInfo(2, 0, 16),
				new DrawInfo(6, size + 16, 0),
				new DrawInfo(7, size + 16, 8),
				new DrawInfo(8, size + 16, 16)
			);
		}

		public static void RoomDraw_RightwardsBigRail1x3_1to16plus5(Artist art, RoomObject obj)
		{
			int size = obj.Size * 8;

			for (int s = 16; s < size + 32; s += 8)
			{
				DrawTiles(art, obj, false,
					new DrawInfo(6, s, 0),
					new DrawInfo(7, s, 8),
					new DrawInfo(8, s, 16)
				);
			}
			DrawTiles(art, obj, false,
				new DrawInfo(0, 0, 0),
				new DrawInfo(3, 8, 0),
				new DrawInfo(1, 0, 8),
				new DrawInfo(4, 8, 8),
				new DrawInfo(2, 0, 16),
				new DrawInfo(5, 8, 16),
				new DrawInfo(9, size + 32, 0),
				new DrawInfo(12, size + 40, 0),
				new DrawInfo(10, size + 32, 8),
				new DrawInfo(13, size + 40, 8),
				new DrawInfo(11, size + 32, 16),
				new DrawInfo(14, size + 40, 16)
			);
		}

		public static void RoomDraw_RightwardsBlock2x2spaced2_1to16(Artist art, RoomObject obj)
		{
			RoomDraw_RightwardsXbyY(art, obj, obj.Size + 1, sizex: 2, sizey: 2, spacing: 2);
		}

		public static void RoomDraw_RightwardsCannonHole4x3_1to16(Artist art, RoomObject obj)
		{
			int size = (obj.Size + 1) * 16;

			for (int s = 16; s < size; s += 16)
			{
				DrawTiles(art, obj, false,
					new DrawInfo(6, s, 0),
					new DrawInfo(7, s, 8),
					new DrawInfo(8, s, 16),

					new DrawInfo(9, s+ 8, 0),
					new DrawInfo(10, s+ 8, 8),
					new DrawInfo(11, s+ 8, 16)
				);
			}

			DrawTiles(art, obj, false,
				new DrawInfo(0, 0, 0),
				new DrawInfo(1, 0, 8),
				new DrawInfo(2, 0, 16),

				new DrawInfo(3, 8, 0),
				new DrawInfo(4, 8, 8),
				new DrawInfo(5, 8, 16),

				new DrawInfo(12, size, 0),
				new DrawInfo(13, size, 8),
				new DrawInfo(14, size, 16),

				new DrawInfo(15, size + 8, 0),
				new DrawInfo(16, size + 8, 8),
				new DrawInfo(17, size + 8, 16)
			);
		}

		public static void RoomDraw_RightwardsDecor2x2spaced12_1to16(Artist art, RoomObject obj)
		{
			RoomDraw_RightwardsXbyY(art, obj, obj.Size + 1, sizex: 2, sizey: 2, spacing: 12);
		}

		public static void RoomDraw_RightwardsDecor4x2spaced8_1to16(Artist art, RoomObject obj)
		{
			RoomDraw_RightwardsXbyY(art, obj, obj.Size + 1, sizex: 4, sizey: 2, spacing: 8);
		}

		public static void RoomDraw_RightwardsDecor4x3spaced4_1to16(Artist art, RoomObject obj)
		{
			RoomDraw_RightwardsXbyY(art, obj, obj.Size + 1, sizex: 4, sizey: 3, spacing: 4);
		}

		public static void RoomDraw_RightwardsDecor4x4spaced2_1to16(Artist art, RoomObject obj)
		{
			RoomDraw_RightwardsXbyY(art, obj, obj.Size + 1, sizex: 4, sizey: 4, spacing: 2);
		}

		public static void RoomDraw_RightwardsDoubled2x2spaced2_1to16(Artist art, RoomObject obj)
		{
			int size = obj.Size * 32;

			for (int s = 0; s < size; s += 32)
			{
				DrawTiles(art, obj, false,
					new DrawInfo(0, s, 0),
					new DrawInfo(1, s, 8),
					new DrawInfo(2, s + 8, 0),
					new DrawInfo(3, s + 8, 8),

					new DrawInfo(0, s, 48),
					new DrawInfo(1, s, 48),
					new DrawInfo(2, s + 8, 56),
					new DrawInfo(3, s + 8, 56)
				);
			}
		}

		public static void RoomDraw_RightwardsEdge1x1_1to16plus7(Artist art, RoomObject obj)
		{
			RoomDraw_RightwardsXbyY(art, obj, obj.Size + 8, sizex: 1, sizey: 1);
		}

		public static void RoomDraw_RightwardsFakePots2x2_1to16(Artist art, RoomObject obj)
		{
			RoomDraw_RightwardsXbyY(art, obj, obj.Size + 1, sizex: 2, sizey: 2);
		}

		public static void RoomDraw_RightwardsFloorTile4x2_1to16(Artist art, RoomObject obj)
		{
			RoomDraw_RightwardsXbyY(art, obj, obj.Size + 1, sizex: 4, sizey: 2);
		}

		public static void RoomDraw_RightwardsHammerPegs2x2_1to16(Artist art, RoomObject obj)
		{
			RoomDraw_RightwardsXbyY(art, obj, obj.Size + 1, sizex: 2, sizey: 2);
		}

		public static void RoomDraw_RightwardsHasEdge1x1_1to16_plus2(Artist art, RoomObject obj)
		{
			for (int s = 8; s <= ((obj.Size + 1) * 8); s += 8)
			{
				DrawTiles(art, obj, false, new DrawInfo(1, s, 0));
			}

			DrawTiles(art, obj, false,
				new DrawInfo(0, 0, 0, under: obj.Tiles[1].ToUnsignedShort()),
				new DrawInfo(2, (obj.Size * 8) + 16, 0)
			);
		}

		public static void RoomDraw_RightwardsHasEdge1x1_1to16_plus23(Artist art, RoomObject obj)
		{
			for (int s = 8; s < ((obj.Size + 22) * 8); s += 8)
			{
				DrawTiles(art, obj, false, new DrawInfo(1, s, 0));
			}

			DrawTiles(art, obj, false,
				new DrawInfo(0, 0, 0),
				new DrawInfo(2, (obj.Size * 8) + 176, 0)
			);
		}

		public static void RoomDraw_RightwardsHasEdge1x1_1to16_plus3(Artist art, RoomObject obj)
		{
			for (int s = 8; s <= ((obj.Size + 2) * 8); s += 8)
			{
				DrawTiles(art, obj, false, new DrawInfo(1, s, 0));
			}

			DrawTiles(art, obj, false,
				new DrawInfo(0, 0, 0, under: obj.Tiles[1].ToUnsignedShort()),
				new DrawInfo(2, (obj.Size * 8) + 24, 0)
			);
		}

		public static void RoomDraw_RightwardsLine1x1_1to16plus1(Artist art, RoomObject obj)
		{
			RoomDraw_RightwardsXbyY(art, obj, obj.Size + 1, sizex: 1, sizey: 1);
		}

		public static void RoomDraw_RightwardsPillar2x4spaced4_1to16(Artist art, RoomObject obj)
		{
			RoomDraw_RightwardsXbyY(art, obj, obj.Size + 1, sizex: 2, sizey: 4, spacing: 4);
		}

		public static void RoomDraw_RightwardsShelf4x4_1to16(Artist art, RoomObject obj)
		{
			int size = (obj.Size + 1) * 16;

			for (int s = 8; s < size; s += 16)
			{
				DrawTiles(art, obj, false,
					new DrawInfo(4, s, 0),
					new DrawInfo(5, s, 8),
					new DrawInfo(6, s, 16),
					new DrawInfo(7, s, 24),

					new DrawInfo(8, s + 8, 0),
					new DrawInfo(9, s + 8, 8),
					new DrawInfo(10, s + 8, 16),
					new DrawInfo(11, s + 8, 24)
				);
			}

			DrawTiles(art, obj, false,
				new DrawInfo(0, 0, 0),
				new DrawInfo(1, 0, 8),
				new DrawInfo(2, 0, 16),
				new DrawInfo(3, 0, 24),

				new DrawInfo(12, size + 8, 0),
				new DrawInfo(13, size + 8, 8),
				new DrawInfo(14, size + 8, 16),
				new DrawInfo(15, size + 8, 24)
			);
		}

		public static void RoomDraw_RightwardsStatue2x3spaced2_1to16(Artist art, RoomObject obj)
		{
			RoomDraw_RightwardsXbyY(art, obj, obj.Size + 1, sizex: 2, sizey: 3, spacing: 2);
		}

		public static void RoomDraw_RightwardsWithCorners1x2_1to16_plus13(Artist art, RoomObject obj)
		{
			int size = (obj.Size + 12) * 8;
			for (int s = 8; s < size; s += 8)
			{
				DrawTiles(art, obj, false,
					new DrawInfo(0, s, 0),
					new DrawInfo(3, s, 8)
				);
			}

			DrawTiles(art, obj, false,
				new DrawInfo(1, 0, 8),
				new DrawInfo(2, 8, 8),
				new DrawInfo(4, size, 8),
				new DrawInfo(5, size + 8, 8)
			);
		}

		public static void RoomDraw_RupeeFloor(Artist art, RoomObject obj)
		{
			for (int y = 0; y < 3 * 24; y += 24)
			{
				for (int x = 0; x < 3 * 16; x += 16)
				{
					DrawTiles(art, obj, false,
						new DrawInfo(0, x, y),
						new DrawInfo(1, x, y)
					);
				}
			}
		}

		public static void RoomDraw_SanctuaryWall(Artist art, RoomObject obj)
		{
			for (int i = 0; i < (2 * 14 * 8); i += (14 * 8))
			{
				int tid = 0;
				for (int x = i; x < (i + 16); x += 8)
				{
					for (int y = 0; y < 6 * 8; y += 8)
					{
						DrawTiles(art, obj, false,
							new DrawInfo(tid, x, y),
							new DrawInfo(tid + 6, x + 16, y),

							new DrawInfo(tid, x + 32, y),
							new DrawInfo(tid + 6, x + 48, y),

							new DrawInfo(tid, x + 64, y)
						);
					}
					tid++;
				}
			}

			RoomDraw_ArbitraryXByY(art, obj, sizex: 4, sizey: 3, xstart: 10, tilestart: 12);
		}

		public static void RoomDraw_Single2x2(Artist art, RoomObject obj)
		{
			DrawTiles(art, obj, false,
				new DrawInfo(0, 0, 0),
				new DrawInfo(1, 0, 8),
				new DrawInfo(2, 8, 0),
				new DrawInfo(3, 8, 8)
			);
		}

		public static void RoomDraw_Single2x3Pillar(Artist art, RoomObject obj)
		{
			RoomDraw_ArbitraryXByY(art, obj, sizex: 2, sizey: 3);
		}

		public static void RoomDraw_SmithyFurnace(Artist art, RoomObject obj)
		{
			RoomDraw_ArbitraryYByX(art, obj, sizex: 6, sizey: 8);
		}

		public static void RoomDraw_SolidWallDecor3x4(Artist art, RoomObject obj)
		{
			RoomDraw_ArbitraryXByY(art, obj, sizex: 3, sizey: 4);
		}

		public static void RoomDraw_SomariaLine(Artist art, RoomObject obj)
		{
			DrawTiles(art, obj, false, new DrawInfo(0, 0, 0));
		}

		public static void RoomDraw_Spike2x2In4x4SuperSquare(Artist art, RoomObject obj)
		{
			int sizex = 16 * (1 + ((obj.Size >> 2) & 0x03));
			int sizey = 16 * (1 + ((obj.Size) & 0x03));

			for (int x = 0; x < sizex; x += 16)
			{
				for (int y = 0; y < sizey; y += 16)
				{
					DrawTiles(art, obj, false,
						new DrawInfo(0, x, y),
						new DrawInfo(1, x, y + 8),
						new DrawInfo(2, x + 8, y),
						new DrawInfo(3, x + 8, y + 8)
					);
				}
			}
		}

		public static void RoomDraw_SpiralStairs(Artist art, RoomObject obj)
		{
			RoomDraw_ArbitraryXByY(art, obj, sizex: 4, sizey: 3);
		}

		public static void RoomDraw_SpittingWaterFace(Artist art, RoomObject obj)
		{
			RoomDraw_ArbitraryYByX(art, obj, sizex: 4, sizey: 5);
		}

		public static void RoomDraw_StraightInterroomStairs(Artist art, RoomObject obj)
		{
			RoomDraw_ArbitraryXByY(art, obj, sizex: 4, sizey: 4);
		}

		public static void RoomDraw_TableBowl(Artist art, RoomObject obj)
		{
			RoomDraw_ArbitraryYByX(art, obj, sizex: 4, sizey: 2);
		}

		public static void RoomDraw_4x3OneLayer(Artist art, RoomObject obj)
		{
			RoomDraw_ArbitraryXByY(art, obj, sizex: 4, sizey: 3);
		}

		public static void RoomDraw_TableRock4x4_1to16(Artist art, RoomObject obj)
		{
			int sizex = (obj.Size >> 2) & 0x03;
			int sizey = obj.Size & 0x03;

			sizex = sizex * 16 + 24;
			sizey = sizey * 16 + 24;

			for (int x = 8; x < sizex; x += 16)
			{
				for (int y = 8; y < sizey; y += 16)
				{
					DrawTiles(art, obj, false,
						new DrawInfo(5, x, y),
						new DrawInfo(6, x + 8, y),
						new DrawInfo(9, x, y + 8),
						new DrawInfo(10, x + 8, y + 8)
					);
				}

				DrawTiles(art, obj, false,
					new DrawInfo(1, x, 0),
					new DrawInfo(2, x + 8, 0),
					new DrawInfo(13, x, sizey),
					new DrawInfo(14, x + 8, sizey)
				);
			}
			
			for (int y = 8; y < sizey; y += 16)
			{
				DrawTiles(art, obj, false,
					new DrawInfo(4, 0, y),
					new DrawInfo(8, 0, y + 8),
					new DrawInfo(7, sizex, y),
					new DrawInfo(11, sizex, y + 8)
				);
			}

			DrawTiles(art, obj, false,
				new DrawInfo(0, 0, 0),
				new DrawInfo(12, 0, sizey),
				new DrawInfo(3, sizex, 0),
				new DrawInfo(15, sizex, sizey)
			);
		}

		public static void RoomDraw_TrinexxShell(Artist art, RoomObject obj)
		{
			RoomDraw_ArbitraryYByX(art, obj, sizex: 10, sizey: 8);
		}

		public static void RoomDraw_Utility3x5(Artist art, RoomObject obj)
		{
			// TODO Zarby's routines seem wrong
		}

		public static void RoomDraw_Utility6x3(Artist art, RoomObject obj)
		{
			RoomDraw_ArbitraryXByY(art, obj, sizex: 6, sizey: 3);
		}

		public static void RoomDraw_VerticalTurtleRockPipe(Artist art, RoomObject obj)
		{
			DrawTiles(art, obj, false,
				new DrawInfo(0, 0, 0),
				new DrawInfo(6, 16, 0),

				new DrawInfo(1, 0, 8),
				new DrawInfo(7, 16, 8),

				new DrawInfo(2, 0, 16),
				new DrawInfo(8, 16, 16),

				new DrawInfo(3, 1, 0),
				new DrawInfo(9, 24, 0),

				new DrawInfo(4, 1, 8),
				new DrawInfo(10, 24, 8),

				new DrawInfo(5, 1, 16),
				new DrawInfo(11, 24, 16),

				new DrawInfo(12, 0, 24),
				new DrawInfo(15, 8, 24),
				new DrawInfo(18, 16, 24),
				new DrawInfo(21, 24, 24),

				new DrawInfo(13, 0, 32),
				new DrawInfo(16, 8, 32),
				new DrawInfo(19, 16, 32),
				new DrawInfo(22, 24, 32),

				new DrawInfo(14, 0, 40),
				new DrawInfo(17, 8, 40),
				new DrawInfo(20, 16, 40),
				new DrawInfo(23, 24, 40)
			);
		}

		public static void RoomDraw_VitreousGooDamage(Artist art, RoomObject obj)
		{
			for (int x = 0; x < 5 * 64; x += 32)
			{
				for (int y = 0; y < 64; y += 32)
				{
					DrawTiles(art, obj, false,
						new DrawInfo(0, x, y),
						new DrawInfo(1, x + 8, y),
						new DrawInfo(2, x + 16, y),
						new DrawInfo(3, x + 24, y),
						new DrawInfo(4, x, y + 8),
						new DrawInfo(5, x + 8, y + 8),
						new DrawInfo(6, x + 16, y + 8),
						new DrawInfo(7, x + 24, y + 8),
						new DrawInfo(0, x, y + 16),
						new DrawInfo(1, x + 8, y + 16),
						new DrawInfo(2, x + 16, y + 16),
						new DrawInfo(3, x + 24, y + 16),
						new DrawInfo(4, x, y + 24),
						new DrawInfo(5, x + 8, y + 24),
						new DrawInfo(6, x + 16, y + 24),
						new DrawInfo(7, x + 24, y + 24)
					);
				}
			}
		}

		public static void RoomDraw_VitreousGooGraphics(Artist art, RoomObject obj)
		{
			RoomDraw_ArbitraryXByY(art, obj, sizex: 22, sizey: 11);
		}

		public static void RoomDraw_WaterHopStairs_A(Artist art, RoomObject obj)
		{
			RoomDraw_ArbitraryYByX(art, obj, sizex: 4, sizey: 2);
		}

		public static void RoomDraw_WaterHopStairs_B(Artist art, RoomObject obj)
		{
			RoomDraw_ArbitraryYByX(art, obj, sizex: 4, sizey: 2, bothbg: true);
		}

		public static void RoomDraw_WaterOverlay8x8_1to16(Artist art, RoomObject obj)
		{
			RoomDraw_Arbtrary4x4in4x4SuperSquares(art, obj, sizebonus: 2);
		}

		public static void RoomDraw_Waterfall47(Artist art, RoomObject obj)
		{
			// TODO ROOM DRAW
		}

		public static void RoomDraw_Waterfall48(Artist art, RoomObject obj)
		{
			// TODO ROOM DRAW
		}

		public static void RoomDraw_Weird2x4_1_to_16(Artist art, RoomObject obj)
		{
			RoomDraw_RightwardsXbyY(art, obj, obj.Size + 1, sizex: 2, sizey: 4);
		}

		public static void RoomDraw_WeirdCornerBottom_BothBG(Artist art, RoomObject obj)
		{
			RoomDraw_ArbitraryXByY(art, obj, sizex: 3, sizey: 4, bothbg: true);
		}

		public static void RoomDraw_WeirdCornerTop_BothBG(Artist art, RoomObject obj)
		{
			RoomDraw_ArbitraryXByY(art, obj, sizex: 4, sizey: 3, bothbg: true);
		}

		//===================================================================================
		//===================================================================================
		// Doors
		//===================================================================================
		//===================================================================================

	}
}
