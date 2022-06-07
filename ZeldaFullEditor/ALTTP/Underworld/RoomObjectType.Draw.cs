using static ZeldaFullEditor.UserInterface.Drawing.SNESGraphics.FlipBehavior;

namespace ZeldaFullEditor.Data
{
	public delegate void DrawObject(List<DrawInfo> list, int objSize);

	public partial class RoomObjectType
	{
		/// <summary>
		/// Draws a specified tile or set of tiles of an object
		/// </summary>
		/// <param name="art">Handler for graphics where object is being drawn.</param>
		/// <param name="obj">Object being drawn</param>
		/// <param name="allbg">Whether this routines draws to all backgrounds or just the object's background</param>
		/// <param name="instructions">A list of <see cref="DrawInfo"/> instructions for which tiles to draw.</param>
		//private static void DrawTiles(IDrawArt artist, RoomObject obj , bool allbg, params DrawInfo[] instructions)
		//{
		//	if (artist is PreviewArtist prvart)
		//	{
		//		
		//	} // end of if preview
		//	else if (artist is TilemapArtist art)
		//	{
		//		foreach (DrawInfo d in instructions)
		//		{
		//			if (obj.Width < d.XOff + 8)
		//			{
		//				obj.Width = d.XOff + 8;
		//			}
		//			if (obj.Height < d.YOff + 8)
		//			{
		//				obj.Height = d.YOff + 8;
		//			}
		//
		//			int tm = (d.XOff / 8) + obj.GridX + ((obj.GridY + (d.YOff / 8)) * 64);
		//
		//			if (tm < Constants.TilesPerUnderworldRoom && tm >= 0)
		//			{
		//				ushort td = obj.Tiles[d.TileIndex].GetModifiedUnsignedShort(hflip: d.HFlip, vflip: d.VFlip);
		//
		//				obj.CollisionRectangles.Add(new(d.XOff + obj.RealX, d.YOff + obj.RealY, 8, 8));
		//
		//				if (obj.Layer == RoomLayer.Layer1 || obj.Layer == RoomLayer.Layer3 || allbg)
		//				{
		//					if (d.TileUnder == art.Layer1TileMap[tm])
		//					{
		//						return;
		//					}
		//
		//					art.Layer1TileMap[tm] = td;
		//				}
		//
		//				if (obj.Layer == RoomLayer.Layer2 || allbg)
		//				{
		//					if (d.TileUnder == art.Layer2TileMap[tm])
		//					{
		//						return;
		//					}
		//
		//					art.Layer2TileMap[tm] = td;
		//				}
		//			}
		//		}
		//	}
		//}

		//=======================================================================================================
		// Shared routines
		//=======================================================================================================
		private static void RoomDraw_Arbtrary4x4in4x4SuperSquares(List<DrawInfo> list, int objSize, int sizebonus = 1)
		{
			int sizex = 32 * (sizebonus + ((objSize >> 2) & 0x03));
			int sizey = 32 * (sizebonus + ((objSize) & 0x03));

			for (int x = 0; x < sizex; x += 32)
			{
				for (int y = 0; y < sizey; y += 32)
				{
					list.AddMany(
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

		private static void RoomDraw_ArbitraryDiagonalAcute_1to16(List<DrawInfo> list, int objSize)
		{
			//obj.Height = (objSize + 10) * 8;
			//obj.Width = (objSize + 6) * 8;
			//obj.DiagonalFix = true;

			int objWidth = (objSize + 6) * 8;

			for (int s = 0; s < objWidth; s += 8)
			{
				list.AddMany(
					new DrawInfo(0, s, 0 - s),
					new DrawInfo(1, s, 8 - s),
					new DrawInfo(2, s, 16 - s),
					new DrawInfo(3, s, 24 - s),
					new DrawInfo(4, s, 32 - s)
				);
			}
		}

		private static void RoomDraw_ArbitraryYByX(List<DrawInfo> list, int objSize,
			int sizex, int sizey,
			int tilestart = 0, int xstart = 0, int ystart = 0)
		{

			sizex = (sizex + xstart) * 8;
			sizey = (sizey + ystart) * 8;

			xstart *= 8;
			ystart *= 8;

			for (int y = ystart; y < sizey; y += 8)
			{
				for (int x = xstart; x < sizex; x += 8)
				{
					list.Add(new DrawInfo(tilestart++, x, y));
				}
			}
		}

		private static void RoomDraw_ArbitraryXByY(List<DrawInfo> list, int objSize,
			int sizex, int sizey,
			int tilestart = 0, int xstart = 0, int ystart = 0)
		{

			sizex = (sizex + xstart) * 8;
			sizey = (sizey + ystart) * 8;
			xstart *= 8;
			ystart *= 8;

			for (int x = xstart; x < sizex; x += 8)
			{
				for (int y = ystart; y < sizey; y += 8)
				{
					list.Add(new DrawInfo(tilestart++, x, y));
				}
			}
		}

		private static void RoomDraw_DownwardsXbyY(List<DrawInfo> list, int objSize,
			int size, int sizex, int sizey, int spacing = 0,
			int tilestart = 0, int yoff = 0, int xoff = 0)
		{
			int inc = (sizey + spacing) * 8;
			yoff *= 8;
			xoff *= 8;

			for (int s = 0, s2 = 0; s < size; s++, s2 += inc)
			{
				int t = tilestart;
				for (int x = xoff, ix = 0; ix < sizex; ix++, x += 8)
				{
					for (int y = yoff + s2, iy = 0; iy < sizey; iy++, y += 8)
					{
						list.Add(new DrawInfo(t++, x, y));
					}
				}
			}
		}

		private static void RoomDraw_RightwardsXbyY(List<DrawInfo> list, int objSize,
			int size, int sizex, int sizey, int spacing = 0,
			int tilestart = 0, int yoff = 0, int xoff = 0)
		{
			int inc = (sizex + spacing) * 8;
			yoff *= 8;
			xoff *= 8;

			for (int s = 0, s2 = 0; s < size; s++, s2 += inc)
			{
				int t = tilestart;
				for (int x = xoff + s2, ix = 0; ix < sizex; ix++, x += 8)
				{
					for (int y = yoff, iy = 0; iy < sizey; iy++, y += 8)
					{
						list.Add(new DrawInfo(t++, x, y));
					}
				}
			}
		}

		//=======================================================================================================
		// Main routines
		//=======================================================================================================
		private static void RoomDraw_3x3FloorIn4x4SuperSquare(List<DrawInfo> list, int objSize)
		{
			int sizex = 24 * (1 + ((objSize >> 2) & 0x03));
			int sizey = 24 * (1 + ((objSize) & 0x03));

			for (int x = 0; x < sizex; x += 24)
			{
				for (int y = 0; y < sizey; y += 24)
				{
					list.AddMany(
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

		private static void RoomDraw_4x4BlocksIn4x4SuperSquare(List<DrawInfo> list, int objSize)
		{
			int sizex = 32 * (1 + ((objSize >> 2) & 0x03));
			int sizey = 32 * (1 + ((objSize) & 0x03));

			for (int x = 0; x < sizex; x += 32)
			{
				for (int y = 0; y < sizey; y += 32)
				{
					list.AddMany(
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

		private static void RoomDraw_4x4Corner_BothBG(List<DrawInfo> list, int objSize)
		{
			RoomDraw_ArbitraryXByY(list, objSize, sizex: 4, sizey: 4);
		}

		private static void RoomDraw_4x4FloorIn4x4SuperSquare(List<DrawInfo> list, int objSize)
		{
			RoomDraw_Arbtrary4x4in4x4SuperSquares(list, objSize);
		}

		private static void RoomDraw_4x4FloorOneIn4x4SuperSquare(List<DrawInfo> list, int objSize)
		{
			RoomDraw_Arbtrary4x4in4x4SuperSquares(list, objSize);
		}

		private static void RoomDraw_4x4FloorTwoIn4x4SuperSquare(List<DrawInfo> list, int objSize)
		{
			RoomDraw_Arbtrary4x4in4x4SuperSquares(list, objSize);
		}

		private static void RoomDraw_4x4Object(List<DrawInfo> list, int objSize)
		{
			RoomDraw_ArbitraryXByY(list, objSize, sizex: 4, sizey: 4);
		}

		private static void RoomDraw_AgahnimsAltar(List<DrawInfo> list, int objSize)
		{
			int tid = 0;
			for (int y = 0; y < 14 * 8; y += 8)
			{
				list.AddMany(
					new DrawInfo(tid, 0, y),
					new DrawInfo(tid + 14, 8, y),
					new DrawInfo(tid + 14, 16, y),
					new DrawInfo(tid + 28, 24, y),
					new DrawInfo(tid + 42, 32, y),
					new DrawInfo(tid + 56, 40, y),
					new DrawInfo(tid + 70, 48, y),

					new DrawInfo(tid + 70, 56, y) { HFlip = InvertFlip },
					new DrawInfo(tid + 56, 64, y) { HFlip = InvertFlip },
					new DrawInfo(tid + 42, 72, y) { HFlip = InvertFlip },
					new DrawInfo(tid + 28, 80, y) { HFlip = InvertFlip },
					new DrawInfo(tid + 14, 88, y) { HFlip = InvertFlip },
					new DrawInfo(tid + 14, 96, y) { HFlip = InvertFlip },
					new DrawInfo(tid, 104, y) { HFlip = InvertFlip }
				);
				tid++;
			}
		}

		private static void RoomDraw_AgahnimsWindows(List<DrawInfo> list, int objSize)
		{
			RoomDraw_ArbitraryYByX(list, objSize, sizex: 6, sizey: 4, xstart: 7, ystart: 4, tilestart: 0);
			RoomDraw_ArbitraryYByX(list, objSize, sizex: 6, sizey: 4, xstart: 13, ystart: 4, tilestart: 0);
			RoomDraw_ArbitraryYByX(list, objSize, sizex: 6, sizey: 4, xstart: 19, ystart: 4, tilestart: 0);

			int tid;
			//for (int i = 7 * 8; i < (3 * 48) + (7 * 8); i += 48)
			//{
			//	tid = 0;
			//	for (int x = 0; x < 6 * 48; x += 48)
			//	{
			//		list.AddMany(
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
				list.AddMany(
					new DrawInfo(24, 64 - x, 32 + x) { HFlip = ForcedToFalse },
					new DrawInfo(25, 64 - x, 40 + x) { HFlip = ForcedToFalse },
					new DrawInfo(26, 64 - x, 48 + x) { HFlip = ForcedToFalse },
					new DrawInfo(27, 64 - x, 56 + x) { HFlip = ForcedToFalse },
					new DrawInfo(28, 64 - x, 64 + x) { HFlip = ForcedToFalse },

					new DrawInfo(24, 184 + x, 32 + x) { HFlip = ForcedToTrue },
					new DrawInfo(25, 184 + x, 40 + x) { HFlip = ForcedToTrue },
					new DrawInfo(26, 184 + x, 48 + x) { HFlip = ForcedToTrue },
					new DrawInfo(27, 184 + x, 56 + x) { HFlip = ForcedToTrue },
					new DrawInfo(28, 184 + x, 64 + x) { HFlip = ForcedToTrue }
				);
			}

			// side walls
			for (int i = 11 * 8; i < (3 * 48) + (11 * 8); i += 48)
			{
				tid = 29;
				for (int y = 0; y < 6 * 8; y += 8)
				{
					list.AddMany(
						new DrawInfo(tid, 16, y + i) { HFlip = ForcedToFalse },
						new DrawInfo(tid++, 216, y + i) { HFlip = ForcedToTrue },

						new DrawInfo(tid, 24, y + i) { HFlip = ForcedToFalse },
						new DrawInfo(tid++, 208, y + i) { HFlip = ForcedToTrue },

						new DrawInfo(tid, 32, y + i) { HFlip = ForcedToFalse },
						new DrawInfo(tid++, 200, y + i) { HFlip = ForcedToTrue },

						new DrawInfo(tid, 40, y + i) { HFlip = ForcedToFalse },
						new DrawInfo(tid++, 192, y + i) { HFlip = ForcedToTrue }
					);
				}
			}

			RoomDraw_ArbitraryYByX(list, objSize, sizex: 6, sizey: 2, xstart: 12, ystart: 9, tilestart: 53);
			RoomDraw_ArbitraryYByX(list, objSize, sizex: 6, sizey: 2, xstart: 18, ystart: 9, tilestart: 53);

			//for (int i = 12 * 8; i < (2 * 48) + (12 * 8); i += 48)
			//{
			//	tid = 53;
			//	for (int y = 9 * 8; y < (11 * 8); y += 8)
			//	{
			//		for (int x = 0; x < 6 * 8; x += 8)
			//		{
			//			list.Add(new DrawInfo(tid++, x + i, y));
			//		}
			//	}
			//}

			RoomDraw_ArbitraryYByX(list, objSize, sizex: 2, sizey: 6, xstart: 7, ystart: 14, tilestart: 65);
			RoomDraw_ArbitraryYByX(list, objSize, sizex: 2, sizey: 6, xstart: 7, ystart: 20, tilestart: 65);

			//for (int i = 14 * 8; i < (2 * 48) + (14 * 8); i += 48)
			//{
			//	tid = 65;
			//	for (int y = 0; y < (6 * 8); y += 8)
			//	{
			//		list.AddMany(
			//			new DrawInfo(tid++, 56, y + i),
			//			new DrawInfo(tid++, 64, y + i)
			//		);
			//	}
			//}

			RoomDraw_ArbitraryXByY(list, objSize, sizex: 5, sizey: 5, xstart: 7, ystart: 9, tilestart: 77);

			//tid = 77;
			//for (int x = 7 * 8; x < (7 + 5) * 8; x += 8)
			//{
			//	for (int y = 9 * 8; y < (9 + 5) * 8; y += 8)
			//	{
			//		list.Add(new DrawInfo(tid++, x, y));
			//	}
			//}
		}

		private static void RoomDraw_ArcheryGameTargetDoor(List<DrawInfo> list, int objSize)
		{
			int tid = 0;
			for (int x = 0; x < 3 * 8; x += 8)
			{
				list.AddMany(
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

		private static void RoomDraw_AutoStairsMerged(List<DrawInfo> list, int objSize)
		{
			RoomDraw_ArbitraryXByY(list, objSize, sizex: 4, sizey: 4);
		}

		private static void RoomDraw_AutoStairs(List<DrawInfo> list, int objSize)
		{
			RoomDraw_ArbitraryXByY(list, objSize, sizex: 4, sizey: 4);
		}

		private static void RoomDraw_BG2MaskFull(List<DrawInfo> list, int objSize)
		{
			list.AddMany(
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

		private static void RoomDraw_Bed4x5(List<DrawInfo> list, int objSize)
		{
			RoomDraw_ArbitraryXByY(list, objSize, sizex: 4, sizey: 5);
		}

		private static void RoomDraw_YBed4x5(List<DrawInfo> list, int objSize)
		{
			RoomDraw_ArbitraryYByX(list, objSize, sizex: 4, sizey: 5);
		}

		private static void RoomDraw_BigGrayRock(List<DrawInfo> list, int objSize)
		{
			RoomDraw_ArbitraryXByY(list, objSize, sizex: 4, sizey: 2);
			RoomDraw_ArbitraryXByY(list, objSize, sizex: 4, sizey: 2, ystart: 2, tilestart: 8);
		}

		private static void RoomDraw_BigHole4x4_1to16(List<DrawInfo> list, int objSize)
		{
			int size = (objSize + 3) * 8;

			list.AddMany(
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
					list.Add(new DrawInfo(0, x, y));
				}
				list.AddMany(
					new DrawInfo(10, x, 0),
					new DrawInfo(19, x, size)
				);
			}

			for (int y = 8; y < size; y += 8)
			{
				list.AddMany(
					new DrawInfo(9, 0, y),
					new DrawInfo(15, size, y)
				);
			}
		}

		private static void RoomDraw_BigLightBeamOnFloor(List<DrawInfo> list, int objSize)
		{
			RoomDraw_ArbitraryXByY(list, objSize, sizex: 8, sizey: 4);
			RoomDraw_ArbitraryXByY(list, objSize, sizex: 8, sizey: 4, ystart: 4, tilestart: 32);


			//int tid = 0;
			//for (int x = 0; x < 8 * 8; x += 8)
			//{
			//	for (int y = 0; y < 4 * 8; y += 8)
			//	{
			//		list.AddMany(
			//			new DrawInfo(tid, x, y),
			//			new DrawInfo(tid + 32, x, y + 32)
			//		);
			//
			//		tid++;
			//	}
			//}
		}

		private static void RoomDraw_BigWallDecor(List<DrawInfo> list, int objSize)
		{
			RoomDraw_ArbitraryXByY(list, objSize, sizex: 8, sizey: 3);
		}

		private static void RoomDraw_BombableFloor(List<DrawInfo> list, int objSize)
		{
			// 00 04 02 06
			// 08 12 10 14
			// 01 05 03 07
			// 09 13 11 15
			list.AddMany(
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

		private static void RoomDraw_CheckIfWallIsMoved(List<DrawInfo> list, int objSize)
		{
			// Nothing
		}

		private static void RoomDraw_ChestPlatformVerticalWall(List<DrawInfo> list, int objSize)
		{
			RoomDraw_ArbitraryXByY(list, objSize, sizex: 2, sizey: 3);
		}

		private static void RoomDraw_ClosedChestPlatform(List<DrawInfo> list, int objSize)
		{

			int sizex = (objSize >> 2) & 0x03;
			int sizey = objSize & 0x03;

			int sizex2 = (sizex + 4) * 16;
			int sizey2 = (sizey + 1) * 16;

			int tid = 0;
			for (int x = 0; x < 3 * 8; x += 8)
			{
				int xx2 = sizex2 + 24 + x;
				for (int y = 0; y < 3 * 8; y += 8)
				{
					int yy2 = y + sizey2 + 24;
					list.AddMany(
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

			list.AddMany(
				new DrawInfo(64, xxxxxx + 48, yyyyyy + 24),
				new DrawInfo(66, xxxxxx + 56, yyyyyy + 24),
				new DrawInfo(65, xxxxxx + 48, yyyyyy + 32),
				new DrawInfo(67, xxxxxx + 56, yyyyyy + 32)
			);

			for (int x = 0; x < sizex2; x += 16)
			{
				list.AddMany(
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
					list.AddMany(
						new DrawInfo(30, x + 24, y + 24),
						new DrawInfo(31, x + 32, y + 24),
						new DrawInfo(32, x + 24, y + 32),
						new DrawInfo(33, x + 32, y + 32)
					);
				}

			}

			for (int y = 0; y < sizey2; y += 16)
			{
				list.AddMany(
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

		private static void RoomDraw_DamFloodGate(List<DrawInfo> list, int objSize)
		{
			RoomDraw_ArbitraryXByY(list, objSize, sizex: 10, sizey: 4);
		}

		private static void RoomDraw_DiagonalAcute_1to16(List<DrawInfo> list, int objSize)
		{
			RoomDraw_ArbitraryDiagonalAcute_1to16(list, objSize);
		}

		private static void RoomDraw_DiagonalAcute_1to16_BothBG(List<DrawInfo> list, int objSize)
		{
			RoomDraw_ArbitraryDiagonalAcute_1to16(list, objSize);
		}

		private static void RoomDraw_DiagonalCeilingBottomLeft(List<DrawInfo> list, int objSize)
		{
			int length = 8 * (objSize + 4);
			int size = length;

			for (int s = 0; s < size; s += 8)
			{
				for (int i = 0; i < length; i += 8)
				{
					list.Add(new DrawInfo(0, i, s));
				}

				length += 8;
			}
		}

		private static void RoomDraw_DiagonalCeilingBottomRight(List<DrawInfo> list, int objSize)
		{
			int size = 8 * (objSize + 4);

			for (int s = 0; s < size; s += 8)
			{
				for (int i = s; i < size; i += 8)
				{
					list.Add(new DrawInfo(0, i, -s));
				}
			}
		}

		private static void RoomDraw_DiagonalCeilingTopLeft(List<DrawInfo> list, int objSize)
		{
			int length = 8 * (objSize + 4);
			int size = length;

			for (int s = 0; s < size; s += 8)
			{
				for (int i = s; i < length; i += 8)
				{
					list.Add(new DrawInfo(0, i, s));
				}

				length -= 8;
			}
		}

		private static void RoomDraw_DiagonalCeilingTopRight(List<DrawInfo> list, int objSize)
		{
			int size = 8 * (objSize + 4);

			for (int s = 0; s < size; s += 8)
			{
				for (int i = s; i < size; i += 8)
				{
					list.Add(new DrawInfo(0, i, s));
				}
			}
		}

		private static void RoomDraw_DiagonalGrave_1to16(List<DrawInfo> list, int objSize)
		{
			//obj.Height = (objSize + 10) * 8;
			//obj.Width = (objSize + 6) * 8;
			//obj.DiagonalFix = true;

			int objWidth = (objSize + 6) * 8;

			for (int s = 0; s < objWidth; s += 8)
			{
				list.AddMany(
					new DrawInfo(0, s, s),
					new DrawInfo(1, s, 8 + s),
					new DrawInfo(2, s, 16 + s),
					new DrawInfo(3, s, 24 + s),
					new DrawInfo(4, s, 32 + s)
				);
			}
		}
		private static void RoomDraw_DiagonalGrave_1to16_BothBG(List<DrawInfo> list, int objSize)
		{
			//obj.Height = (objSize + 10) * 8;
			//obj.Width = (objSize + 6) * 8;
			//obj.DiagonalFix = true;

			int objWidth = (objSize + 6) * 8;

			for (int s = 0; s < objWidth; s += 8)
			{
				list.AddMany(
					new DrawInfo(0, s, s),
					new DrawInfo(1, s, 8 + s),
					new DrawInfo(2, s, 16 + s),
					new DrawInfo(3, s, 24 + s),
					new DrawInfo(4, s, 32 + s)
				);
			}
		}

		private static void RoomDraw_DoorSwitcherer(List<DrawInfo> list, int objSize)
		{
			// TODO ROOM DRAW
		}

		private static void RoomDraw_Downwards1x1Solid_1to16_plus3(List<DrawInfo> list, int objSize)
		{
			for (int s = 0; s < (objSize + 4) * 8; s += 8)
			{
				list.Add(new DrawInfo(0, 0, s));
			}
		}

		private static void RoomDraw_Downwards2x2_1to15or32(List<DrawInfo> list, int objSize)
		{
			int size = objSize == 0 ? 32 : objSize;
			RoomDraw_DownwardsXbyY(list, objSize, size, sizex: 2, sizey: 2);
		}

		private static void RoomDraw_Downwards2x2_1to16(List<DrawInfo> list, int objSize)
		{
			RoomDraw_DownwardsXbyY(list, objSize, objSize + 1, sizex: 2, sizey: 2);
		}

		private static void RoomDraw_Downwards4x2_1to15or26(List<DrawInfo> list, int objSize)
		{
			int size = objSize == 0 ? 26 : objSize;

			for (int s = 0; s < (size * 16); s += 16)
			{
				list.AddMany(
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

		private static void RoomDraw_Downwards4x2_1to16_BothBG(List<DrawInfo> list, int objSize)
		{
			for (int s = 0; s < ((objSize + 1) * 16); s += 16)
			{
				list.AddMany(
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

		private static void RoomDraw_DownwardsBar2x5_1to16(List<DrawInfo> list, int objSize)
		{
			int size = (objSize + 2) * 16;

			for (int s = 0; s < size; s += 16)
			{
				list.AddMany(
					new DrawInfo(2, 0, s + 8),
					new DrawInfo(3, 8, s + 8),
					new DrawInfo(2, 0, s + 16),
					new DrawInfo(3, 8, s + 16)
				);
			}
			list.AddMany(
				new DrawInfo(0, 0, 0),
				new DrawInfo(1, 8, 0)
			);
		}

		private static void RoomDraw_DownwardsBigRail3x1_1to16plus5(List<DrawInfo> list, int objSize)
		{
			int size1 = (objSize + 2) * 16;

			for (int s = 0; s < size1; s += 16)
			{
				list.AddMany(
					new DrawInfo(4, 0, s),
					new DrawInfo(5, 8, s)
				);
			}

			int size2 = (objSize + 3) * 8;

			list.AddMany(
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

		private static void RoomDraw_DownwardsBlock2x2spaced2_1to16(List<DrawInfo> list, int objSize)
		{
			RoomDraw_DownwardsXbyY(list, objSize, objSize + 1, sizex: 2, sizey: 2, spacing: 2);
		}

		private static void RoomDraw_DownwardsCannonHole3x4_1to16(List<DrawInfo> list, int objSize)
		{
			int size = (objSize + 1) * 16;

			for (int s = 16; s < size; s += 16)
			{
				list.AddMany(
					new DrawInfo(6, 0, s),
					new DrawInfo(7, 8, s),
					new DrawInfo(8, 16, s),

					new DrawInfo(9, 0, s + 8),
					new DrawInfo(10, 8, s + 8),
					new DrawInfo(11, 16, s + 8)
				);
			}

			list.AddMany(
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

		private static void RoomDraw_DownwardsDecor2x2spaced12_1to16(List<DrawInfo> list, int objSize)
		{
			RoomDraw_DownwardsXbyY(list, objSize, objSize + 1, sizex: 2, sizey: 2, spacing: 12);
		}

		private static void RoomDraw_DownwardsDecor3x4spaced2_1to16(List<DrawInfo> list, int objSize)
		{
			RoomDraw_DownwardsXbyY(list, objSize, objSize + 1, sizex: 3, sizey: 4, spacing: 2);
		}

		private static void RoomDraw_DownwardsDecor2x4spaced8_1to16(List<DrawInfo> list, int objSize)
		{
			RoomDraw_DownwardsXbyY(list, objSize, objSize + 1, sizex: 2, sizey: 4, spacing: 8);
		}

		private static void RoomDraw_DownwardsDecor4x2spaced4_1to16(List<DrawInfo> list, int objSize)
		{
			RoomDraw_DownwardsXbyY(list, objSize, objSize + 1, sizex: 4, sizey: 2, spacing: 4);
		}

		private static void RoomDraw_DownwardsDecor4x4spaced2_1to16(List<DrawInfo> list, int objSize)
		{
			RoomDraw_DownwardsXbyY(list, objSize, objSize + 1, sizex: 4, sizey: 4, spacing: 2);
		}

		private static void RoomDraw_DownwardsDecor3x4spaced4_1to16(List<DrawInfo> list, int objSize)
		{
			RoomDraw_DownwardsXbyY(list, objSize, objSize + 1, sizex: 3, sizey: 4, spacing: 4);
		}

		private static void RoomDraw_DownwardsEdge1x1_1to16(List<DrawInfo> list, int objSize)
		{
			for (int s = 0; s <= objSize * 8; s += 8)
			{
				list.Add(new DrawInfo(0, 0, s));
			}
		}

		private static void RoomDraw_DownwardsEdge1x1_1to16plus7(List<DrawInfo> list, int objSize)
		{
			for (int s = 0; s < (objSize + 8) * 8; s += 8)
			{
				list.Add(new DrawInfo(0, 0, s));
			}
		}

		private static void RoomDraw_DownwardsFloor4x4_1to16(List<DrawInfo> list, int objSize)
		{
			RoomDraw_DownwardsXbyY(list, objSize, objSize + 1, sizex: 4, sizey: 4);
		}

		private static void RoomDraw_DownwardsHasEdge1x1_1to16_plus23(List<DrawInfo> list, int objSize)
		{
			for (int s = 8; s < ((objSize + 22) * 8); s += 8)
			{
				list.Add(new DrawInfo(1, 0, s));
			}

			list.AddMany(
				new DrawInfo(0, 0, 0),
				new DrawInfo(2, 0, (objSize * 8) + 176)
			);
		}

		private static void RoomDraw_DownwardsHasEdge1x1_1to16_plus3(List<DrawInfo> list, int objSize)
		{
			for (int s = 8; s <= ((objSize + 1) * 8); s += 8)
			{
				list.Add(new DrawInfo(1, 0, s));
			}

			list.AddMany(
				new DrawInfo(0, 0, 0) { TileUnder = 1 },
				new DrawInfo(2, 0, (objSize * 8) + 16)
			);
		}

		private static void RoomDraw_DownwardsLine1x1_1to16plus1(List<DrawInfo> list, int objSize)
		{
			for (int s = 0; s < ((objSize + 2) * 8); s += 8)
			{
				list.Add(new DrawInfo(0, 0, s));
			}
		}

		private static void RoomDraw_DownwardsPillar2x4spaced2_1to16(List<DrawInfo> list, int objSize)
		{
			RoomDraw_DownwardsXbyY(list, objSize, objSize + 1, sizex: 2, sizey: 4, spacing: 2);
		}

		private static void RoomDraw_DownwardsWithCorners2x1_1to16_plus12(List<DrawInfo> list, int objSize)
		{
			int size = (objSize + 12) * 8;

			for (int s = 8; s < size; s += 8)
			{
				list.AddMany(
					new DrawInfo(0, 0, s),
					new DrawInfo(3, 8, s)
				);
			}

			list.AddMany(
				new DrawInfo(1, 8, 0),
				new DrawInfo(2, 8, 8),
				new DrawInfo(4, 8, size),
				new DrawInfo(5, 8, size + 8)
			);
		}

		private static void RoomDraw_DrawRightwards3x6(List<DrawInfo> list, int objSize)
		{
			RoomDraw_ArbitraryXByY(list, objSize, sizex: 6, sizey: 3);
		}

		private static void RoomDraw_DrenchingWaterFace(List<DrawInfo> list, int objSize)
		{
			RoomDraw_ArbitraryYByX(list, objSize, sizex: 4, sizey: 7);
		}

		private static void RoomDraw_EmptyWaterFace(List<DrawInfo> list, int objSize)
		{
			RoomDraw_ArbitraryYByX(list, objSize, sizex: 4, sizey: 3);
		}

		private static void RoomDraw_FloorLight(List<DrawInfo> list, int objSize)
		{
			RoomDraw_ArbitraryXByY(list, objSize, sizex: 8, sizey: 4);
			RoomDraw_ArbitraryXByY(list, objSize, sizex: 8, sizey: 4, ystart: 4, tilestart: 32);
			//int tid = 0;
			//for (int x = 0; x < 8 * 8; x += 8)
			//{
			//	for (int y = 0; y < 4 * 8; y += 8)
			//	{
			//		list.AddMany(
			//			new DrawInfo(tid, x, y),
			//			new DrawInfo(tid + 32, x, y + 32)
			//		);
			//		tid++;
			//	}
			//}
		}

		// TODO wrong
		private static void RoomDraw_FortuneTellerRoom(List<DrawInfo> list, int objSize)
		{
			for (int x = 8; x < (13 * 8); x += 8)
			{
				list.AddMany(
					new DrawInfo(0, x, 0),
					new DrawInfo(0, x, 8),
					new DrawInfo(1, x, 16)
				);
			}


			for (int x = 0; x < (16 * 7); x += 16)
			{
				list.AddMany(
					new DrawInfo(2, x, 24),
					new DrawInfo(2, x + 8, 24) { HFlip = InvertFlip },

					new DrawInfo(3, x, 32),
					new DrawInfo(3, x + 8, 32) { HFlip = InvertFlip },

					new DrawInfo(4, x, 40),
					new DrawInfo(4, x + 8, 40) { HFlip = InvertFlip }
				);
			}

			for (int x = 4 * 8; x < 10 * 8; x += 8)
			{

				list.AddMany(
					new DrawInfo(6, x, 32),
					new DrawInfo(7, x, 40),

					new DrawInfo(6, x, 32),
					new DrawInfo(7, x, 40)
				);
			}

			list.AddMany(
				new DrawInfo(8, 0, 0),
				new DrawInfo(8, 0, 8),
				new DrawInfo(9, 0, 16),

				new DrawInfo(8, 104, 0),
				new DrawInfo(8, 104, 8),
				new DrawInfo(9, 104, 16)
			);



			RoomDraw_ArbitraryXByY(list, objSize, sizex: 4, sizey: 4, xstart: 3, ystart: 10, tilestart: 10);
			RoomDraw_ArbitraryXByY(list, objSize, sizex: 4, sizey: 4, xstart: 6, ystart: 10, tilestart: 10);

		}

		private static void RoomDraw_GanonTriforceFloorDecor(List<DrawInfo> list, int objSize)
		{
			RoomDraw_ArbitraryXByY(list, objSize, sizex: 4, sizey: 4);
			RoomDraw_ArbitraryXByY(list, objSize, sizex: 4, sizey: 4, xstart: -2, ystart: 4, tilestart: 16);
			RoomDraw_ArbitraryXByY(list, objSize, sizex: 4, sizey: 4, xstart: +2, ystart: 4, tilestart: 16);
		}

		private static void RoomDraw_HorizontalTurtleRockPipe(List<DrawInfo> list, int objSize)
		{
			RoomDraw_ArbitraryXByY(list, objSize, sizex: 6, sizey: 4);
		}

		private static void RoomDraw_InterRoomFatStairs(List<DrawInfo> list, int objSize)
		{
			RoomDraw_ArbitraryXByY(list, objSize, sizex: 4, sizey: 4);
		}

		private static void RoomDraw_KholdstareShell(List<DrawInfo> list, int objSize)
		{
			RoomDraw_ArbitraryYByX(list, objSize, sizex: 10, sizey: 8);
		}

		private static void RoomDraw_LampCones(List<DrawInfo> list, int objSize)
		{
			RoomDraw_ArbitraryXByY(list, objSize, sizex: 4, sizey: 4);
		}

		private static void RoomDraw_LightBeamOnFloor(List<DrawInfo> list, int objSize)
		{
			RoomDraw_ArbitraryXByY(list, objSize, sizex: 4, sizey: 4);

			list.AddMany(
				new DrawInfo(0, 0, 32),
				new DrawInfo(1, 8, 32),
				new DrawInfo(2, 16, 32),
				new DrawInfo(3, 24, 32),

				new DrawInfo(0, 0, 40),
				new DrawInfo(1, 8, 40),
				new DrawInfo(2, 16, 40),
				new DrawInfo(3, 24, 40)
			);

			RoomDraw_ArbitraryXByY(list, objSize, sizex: 4, sizey: 4, ystart: 6, tilestart: 16);

			//int tid = 16;
			//for (int x = 0; x < 4 * 8; x += 8)
			//{
			//	list.AddMany(
			//		new DrawInfo(tid++, x, 48),
			//		new DrawInfo(tid++, x, 56),
			//		new DrawInfo(tid++, x, 64),
			//		new DrawInfo(tid++, x, 72)
			//	);
			//}

		}

		private static void RoomDraw_MagicBatAltar(List<DrawInfo> list, int objSize)
		{
			RoomDraw_ArbitraryXByY(list, objSize, sizex: 8, sizey: 7);
		}

		private static void RoomDraw_MovingWallEast(List<DrawInfo> list, int objSize)
		{
			int sizey = (objSize >> 2) & 0x03;
			int sizex = 64 * (1 + (objSize & 0x03));


			int sizey2 = sizey * 32;
			list.AddMany(
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
					list.AddMany(
						new DrawInfo(24, x + 24, y),
						new DrawInfo(25, x + 32, y),
						new DrawInfo(26, x + 24, y + 8),
						new DrawInfo(27, x + 32, y + 8)
					);
				}
			}

			for (int y = 0; y < 160 + sizey; y++)
			{
				list.AddMany(
					new DrawInfo(9, 0, y + 24),
					new DrawInfo(10, 8, y + 24),
					new DrawInfo(11, 16, y + 24),
					new DrawInfo(12, 0, y + 32),
					new DrawInfo(13, 8, y + 32),
					new DrawInfo(14, 16, y + 32)
				);
			}
		}

		private static void RoomDraw_MovingWallWest(List<DrawInfo> list, int objSize)
		{
			const int offsetx = 64;
			int sizey = (objSize >> 2) & 0x03;
			int sizex = (objSize) & 0x03;

			int sizex2 = 64 * sizex + offsetx;
			int sizey2 = 32 * sizey;

			list.AddMany(
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
					list.AddMany(
						new DrawInfo(24, sizex2 + offsetx, y),
						new DrawInfo(25, sizex2 + offsetx + 8, y),
						new DrawInfo(26, sizex2 + offsetx, y + 8),
						new DrawInfo(27, sizex2 + offsetx + 8, y + 8)
					);
				}
			}

			for (int y = 0; y < sizey2 + 80; y += 16)
			{
				list.AddMany(
					new DrawInfo(09, sizex2 + 64, y + 24),
					new DrawInfo(10, sizex2 + 72, y + 24),
					new DrawInfo(11, sizex2 + 80, y + 24),
					new DrawInfo(12, sizex2 + 64, y + 32),
					new DrawInfo(13, sizex2 + 72, y + 32),
					new DrawInfo(14, sizex2 + 80, y + 32)
				);
			}
		}

		private static void RoomDraw_Nothing(List<DrawInfo> list, int objSize)
		{
			// Nothing
		}

		private static void RoomDraw_Rightwards2x4spaced4_1to16(List<DrawInfo> list, int objSize)
		{
			RoomDraw_RightwardsXbyY(list, objSize, objSize + 1, sizex: 2, sizey: 4, spacing: 4);
		}

		private static void RoomDraw_OpenChestPlatform(List<DrawInfo> list, int objSize)
		{
			int sizex = (objSize >> 2) & 0x03;
			int sizey = objSize & 0x03;

			int sizex2 = sizex * 16;
			int sizey2 = sizey * 16;

			int sizex3 = sizex * 8;

			list.AddMany(
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
				list.AddMany(
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
					list.AddMany(
						new DrawInfo(3, x, y),
						new DrawInfo(3, x, y + 8),
						new DrawInfo(15, x + sizex3 + 56, y),
						new DrawInfo(15, x + sizex3 + 56, y + 8)
					);
				}
			}

			for (int x = 8; x < sizex3 + 16; x += 8)
			{
				list.AddMany(
					new DrawInfo(3, x, sizey2 + 32),
					new DrawInfo(4, x, sizey2 + 40),
					new DrawInfo(5, x, sizey2 + 48),
					new DrawInfo(15, x + sizex3 + 56, sizey2 + 32),
					new DrawInfo(16, x + sizex3 + 56, sizey2 + 40),
					new DrawInfo(17, x + sizex3 + 56, sizey2 + 48)
				);
			}

		}

		private static void RoomDraw_PortraitOfMario(List<DrawInfo> list, int objSize)
		{
			RoomDraw_ArbitraryYByX(list, objSize, sizex: 4, sizey: 2);
		}

		private static void RoomDraw_PrisonCell(List<DrawInfo> list, int objSize)
		{
			list.AddMany(
				new DrawInfo(0, 0, 0),
				new DrawInfo(0, 120, 0) { HFlip = ForcedToTrue },
				new DrawInfo(1, 8, 0),
				new DrawInfo(1, 112, 0) { HFlip = ForcedToTrue },
				new DrawInfo(3, 8, 16),
				new DrawInfo(3, 112, 16) { HFlip = ForcedToTrue }
			);

			for (int x = 16; x < 56; x += 8)
			{
				
				list.AddMany(
					new DrawInfo(1, x, 0),
					new DrawInfo(1, x + 56, 0) { HFlip = ForcedToTrue },
					new DrawInfo(2, x, 8),
					new DrawInfo(2, x + 56, 8) { HFlip = ForcedToTrue },
					new DrawInfo(4, x, 16),
					new DrawInfo(4, x, 16) { HFlip = ForcedToTrue },
					new DrawInfo(5, x + 56, 24),
					new DrawInfo(5, x, 24) { HFlip = ForcedToTrue }
				);
			}
		}

		private static void RoomDraw_Rightwards1x1Solid_1to16_plus3(List<DrawInfo> list, int objSize)
		{
			RoomDraw_RightwardsXbyY(list, objSize, objSize + 4, sizex: 1, sizey: 1);
		}

		private static void RoomDraw_Rightwards1x2_1to16_plus2(List<DrawInfo> list, int objSize)
		{
			for (int s = 0; s <= (objSize * 16); s += 16)
			{
				list.AddMany(
					new DrawInfo(3, s + 8, 0),
					new DrawInfo(4, s + 8, 8),
					new DrawInfo(5, s + 8, 16),
					new DrawInfo(3, s + 16, 0),
					new DrawInfo(4, s + 16, 8),
					new DrawInfo(5, s + 16, 16)
				);
			}

			list.AddMany(
				new DrawInfo(0, 0, 0),
				new DrawInfo(1, 0, 8),
				new DrawInfo(2, 0, 16),
				new DrawInfo(6, (objSize * 16) + 24, 0),
				new DrawInfo(7, (objSize * 16) + 24, 8),
				new DrawInfo(8, (objSize * 16) + 24, 16)
			);
		}

		private static void RoomDraw_Rightwards2x2_1to15or32(List<DrawInfo> list, int objSize)
		{
			int size = objSize == 0 ? 32 : objSize;

			RoomDraw_RightwardsXbyY(list, objSize, size, sizex: 2, sizey: 2);
		}

		private static void RoomDraw_Rightwards2x2_1to16(List<DrawInfo> list, int objSize)
		{
			RoomDraw_RightwardsXbyY(list, objSize, objSize + 1, sizex: 2, sizey: 2);
		}

		private static void RoomDraw_Rightwards2x4spaced4_1to16_BothBG(List<DrawInfo> list, int objSize)
		{
			RoomDraw_RightwardsXbyY(list, objSize, objSize + 1, sizex: 2, sizey: 4);
		}

		private static void RoomDraw_Rightwards2x4_1to15or26(List<DrawInfo> list, int objSize)
		{
			int size = objSize == 0 ? 26 : objSize;

			RoomDraw_RightwardsXbyY(list, objSize, size, sizex: 2, sizey: 4);
		}

		private static void RoomDraw_Rightwards4x4_1to16(List<DrawInfo> list, int objSize)
		{
			RoomDraw_RightwardsXbyY(list, objSize, objSize + 1, sizex: 4, sizey: 4);
		}

		private static void RoomDraw_RightwardsBar4x3_1to16(List<DrawInfo> list, int objSize)
		{
			int size = (objSize + 1) * 16;

			for (int s = 8; s < size + 16; s += 16)
			{
				list.AddMany(
					new DrawInfo(3, s, 0),
					new DrawInfo(3, s + 8, 0),
					new DrawInfo(4, s, 8),
					new DrawInfo(4, s + 8, 8),
					new DrawInfo(5, s, 16),
					new DrawInfo(5, s + 8, 16)
				);
			}

			list.AddMany(
				new DrawInfo(0, 0, 0),
				new DrawInfo(1, 0, 8),
				new DrawInfo(2, 0, 16),
				new DrawInfo(6, size + 16, 0),
				new DrawInfo(7, size + 16, 8),
				new DrawInfo(8, size + 16, 16)
			);
		}

		private static void RoomDraw_RightwardsBigRail1x3_1to16plus5(List<DrawInfo> list, int objSize)
		{
			int size = objSize * 8;

			for (int s = 16; s < size + 32; s += 8)
			{
				list.AddMany(
					new DrawInfo(6, s, 0),
					new DrawInfo(7, s, 8),
					new DrawInfo(8, s, 16)
				);
			}
			list.AddMany(
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

		private static void RoomDraw_RightwardsBlock2x2spaced2_1to16(List<DrawInfo> list, int objSize)
		{
			RoomDraw_RightwardsXbyY(list, objSize, objSize + 1, sizex: 2, sizey: 2, spacing: 2);
		}

		private static void RoomDraw_RightwardsCannonHole4x3_1to16(List<DrawInfo> list, int objSize)
		{
			int size = (objSize + 1) * 16;

			for (int s = 16; s < size; s += 16)
			{
				list.AddMany(
					new DrawInfo(6, s, 0),
					new DrawInfo(7, s, 8),
					new DrawInfo(8, s, 16),

					new DrawInfo(9, s + 8, 0),
					new DrawInfo(10, s + 8, 8),
					new DrawInfo(11, s + 8, 16)
				);
			}

			list.AddMany(
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

		private static void RoomDraw_RightwardsDecor2x2spaced12_1to16(List<DrawInfo> list, int objSize)
		{
			RoomDraw_RightwardsXbyY(list, objSize, objSize + 1, sizex: 2, sizey: 2, spacing: 12);
		}

		private static void RoomDraw_RightwardsDecor4x2spaced8_1to16(List<DrawInfo> list, int objSize)
		{
			RoomDraw_RightwardsXbyY(list, objSize, objSize + 1, sizex: 4, sizey: 2, spacing: 8);
		}

		private static void RoomDraw_RightwardsDecor4x3spaced4_1to16(List<DrawInfo> list, int objSize)
		{
			RoomDraw_RightwardsXbyY(list, objSize, objSize + 1, sizex: 4, sizey: 3, spacing: 4);
		}

		private static void RoomDraw_RightwardsDecor4x4spaced2_1to16(List<DrawInfo> list, int objSize)
		{
			RoomDraw_RightwardsXbyY(list, objSize, objSize + 1, sizex: 4, sizey: 4, spacing: 2);
		}

		private static void RoomDraw_RightwardsDoubled2x2spaced2_1to16(List<DrawInfo> list, int objSize)
		{
			int size = objSize * 32;

			for (int s = 0; s < size; s += 32)
			{
				list.AddMany(
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

		private static void RoomDraw_RightwardsEdge1x1_1to16plus7(List<DrawInfo> list, int objSize)
		{
			RoomDraw_RightwardsXbyY(list, objSize, objSize + 8, sizex: 1, sizey: 1);
		}

		private static void RoomDraw_RightwardsFakePots2x2_1to16(List<DrawInfo> list, int objSize)
		{
			RoomDraw_RightwardsXbyY(list, objSize, objSize + 1, sizex: 2, sizey: 2);
		}

		private static void RoomDraw_RightwardsFloorTile4x2_1to16(List<DrawInfo> list, int objSize)
		{
			RoomDraw_RightwardsXbyY(list, objSize, objSize + 1, sizex: 4, sizey: 2);
		}

		private static void RoomDraw_RightwardsHammerPegs2x2_1to16(List<DrawInfo> list, int objSize)
		{
			RoomDraw_RightwardsXbyY(list, objSize, objSize + 1, sizex: 2, sizey: 2);
		}

		private static void RoomDraw_RightwardsHasEdge1x1_1to16_plus2(List<DrawInfo> list, int objSize)
		{
			for (int s = 8; s <= ((objSize + 1) * 8); s += 8)
			{
				list.Add(new DrawInfo(1, s, 0));
			}

			list.AddMany(
				new DrawInfo(0, 0, 0) { TileUnder = 1 },
				new DrawInfo(2, (objSize * 8) + 16, 0)
			);
		}

		private static void RoomDraw_RightwardsHasEdge1x1_1to16_plus23(List<DrawInfo> list, int objSize)
		{
			for (int s = 8; s < ((objSize + 22) * 8); s += 8)
			{
				list.Add(new DrawInfo(1, s, 0));
			}

			list.AddMany(
				new DrawInfo(0, 0, 0),
				new DrawInfo(2, (objSize * 8) + 176, 0)
			);
		}

		private static void RoomDraw_RightwardsHasEdge1x1_1to16_plus3(List<DrawInfo> list, int objSize)
		{
			for (int s = 8; s <= ((objSize + 2) * 8); s += 8)
			{
				list.Add(new DrawInfo(1, s, 0));
			}

			list.AddMany(
				new DrawInfo(0, 0, 0) { TileUnder = 1 },
				new DrawInfo(2, (objSize * 8) + 24, 0)
			);
		}

		private static void RoomDraw_RightwardsLine1x1_1to16plus1(List<DrawInfo> list, int objSize)
		{
			RoomDraw_RightwardsXbyY(list, objSize, objSize + 1, sizex: 1, sizey: 1);
		}

		private static void RoomDraw_RightwardsPillar2x4spaced4_1to16(List<DrawInfo> list, int objSize)
		{
			RoomDraw_RightwardsXbyY(list, objSize, objSize + 1, sizex: 2, sizey: 4, spacing: 4);
		}

		private static void RoomDraw_RightwardsShelf4x4_1to16(List<DrawInfo> list, int objSize)
		{
			int size = (objSize + 1) * 16;

			for (int s = 8; s < size; s += 16)
			{
				list.AddMany(
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

			list.AddMany(
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

		private static void RoomDraw_RightwardsStatue2x3spaced2_1to16(List<DrawInfo> list, int objSize)
		{
			RoomDraw_RightwardsXbyY(list, objSize, objSize + 1, sizex: 2, sizey: 3, spacing: 2);
		}

		private static void RoomDraw_RightwardsWithCorners1x2_1to16_plus13(List<DrawInfo> list, int objSize)
		{
			int size = (objSize + 12) * 8;
			for (int s = 8; s < size; s += 8)
			{
				list.AddMany(
					new DrawInfo(0, s, 0),
					new DrawInfo(3, s, 8)
				);
			}

			list.AddMany(
				new DrawInfo(1, 0, 8),
				new DrawInfo(2, 8, 8),
				new DrawInfo(4, size, 8),
				new DrawInfo(5, size + 8, 8)
			);
		}

		private static void RoomDraw_RupeeFloor(List<DrawInfo> list, int objSize)
		{
			for (int y = 0; y < 3 * 24; y += 24)
			{
				for (int x = 0; x < 3 * 16; x += 16)
				{
					list.AddMany(
						new DrawInfo(0, x, y),
						new DrawInfo(1, x, y)
					);
				}
			}
		}

		private static void RoomDraw_SanctuaryWall(List<DrawInfo> list, int objSize)
		{
			for (int i = 0; i < (2 * 14 * 8); i += (14 * 8))
			{
				int tid = 0;
				for (int x = i; x < (i + 16); x += 8)
				{
					for (int y = 0; y < 6 * 8; y += 8)
					{
						list.AddMany(
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

			RoomDraw_ArbitraryXByY(list, objSize, sizex: 4, sizey: 3, xstart: 10, tilestart: 12);
		}

		private static void RoomDraw_Single2x2(List<DrawInfo> list, int objSize)
		{
			list.AddMany(
				new DrawInfo(0, 0, 0),
				new DrawInfo(1, 0, 8),
				new DrawInfo(2, 8, 0),
				new DrawInfo(3, 8, 8)
			);
		}

		private static void RoomDraw_Single2x3Pillar(List<DrawInfo> list, int objSize)
		{
			RoomDraw_ArbitraryXByY(list, objSize, sizex: 2, sizey: 3);
		}

		private static void RoomDraw_SmithyFurnace(List<DrawInfo> list, int objSize)
		{
			RoomDraw_ArbitraryYByX(list, objSize, sizex: 6, sizey: 8);
		}

		private static void RoomDraw_SolidWallDecor3x4(List<DrawInfo> list, int objSize)
		{
			RoomDraw_ArbitraryXByY(list, objSize, sizex: 3, sizey: 4);
		}

		private static void RoomDraw_SomariaLine(List<DrawInfo> list, int objSize)
		{
			list.Add(new DrawInfo(0, 0, 0));
		}

		private static void RoomDraw_Spike2x2In4x4SuperSquare(List<DrawInfo> list, int objSize)
		{
			int sizex = 16 * (1 + ((objSize >> 2) & 0x03));
			int sizey = 16 * (1 + ((objSize) & 0x03));

			for (int x = 0; x < sizex; x += 16)
			{
				for (int y = 0; y < sizey; y += 16)
				{
					list.AddMany(
						new DrawInfo(0, x, y),
						new DrawInfo(1, x, y + 8),
						new DrawInfo(2, x + 8, y),
						new DrawInfo(3, x + 8, y + 8)
					);
				}
			}
		}

		private static void RoomDraw_SpiralStairs(List<DrawInfo> list, int objSize)
		{
			RoomDraw_ArbitraryXByY(list, objSize, sizex: 4, sizey: 3);
		}

		private static void RoomDraw_SpittingWaterFace(List<DrawInfo> list, int objSize)
		{
			RoomDraw_ArbitraryYByX(list, objSize, sizex: 4, sizey: 5);
		}

		private static void RoomDraw_StraightInterroomStairs(List<DrawInfo> list, int objSize)
		{
			RoomDraw_ArbitraryXByY(list, objSize, sizex: 4, sizey: 4);
		}

		private static void RoomDraw_TableBowl(List<DrawInfo> list, int objSize)
		{
			RoomDraw_ArbitraryYByX(list, objSize, sizex: 4, sizey: 2);
		}

		private static void RoomDraw_4x3OneLayer(List<DrawInfo> list, int objSize)
		{
			RoomDraw_ArbitraryXByY(list, objSize, sizex: 4, sizey: 3);
		}

		private static void RoomDraw_TableRock4x4_1to16(List<DrawInfo> list, int objSize)
		{
			int sizex = (objSize >> 2) & 0x03;
			int sizey = objSize & 0x03;

			sizex = sizex * 16 + 24;
			sizey = sizey * 16 + 24;

			for (int x = 8; x < sizex; x += 16)
			{
				for (int y = 8; y < sizey; y += 16)
				{
					list.AddMany(
						new DrawInfo(5, x, y),
						new DrawInfo(6, x + 8, y),
						new DrawInfo(9, x, y + 8),
						new DrawInfo(10, x + 8, y + 8)
					);
				}

				list.AddMany(
					new DrawInfo(1, x, 0),
					new DrawInfo(2, x + 8, 0),
					new DrawInfo(13, x, sizey),
					new DrawInfo(14, x + 8, sizey)
				);
			}

			for (int y = 8; y < sizey; y += 16)
			{
				list.AddMany(
					new DrawInfo(4, 0, y),
					new DrawInfo(8, 0, y + 8),
					new DrawInfo(7, sizex, y),
					new DrawInfo(11, sizex, y + 8)
				);
			}

			list.AddMany(
				new DrawInfo(0, 0, 0),
				new DrawInfo(12, 0, sizey),
				new DrawInfo(3, sizex, 0),
				new DrawInfo(15, sizex, sizey)
			);
		}

		private static void RoomDraw_TrinexxShell(List<DrawInfo> list, int objSize)
		{
			RoomDraw_ArbitraryYByX(list, objSize, sizex: 10, sizey: 8);
		}

		private static void RoomDraw_Utility3x5(List<DrawInfo> list, int objSize)
		{
			// TODO Zarby's routines seem wrong
		}

		private static void RoomDraw_Utility6x3(List<DrawInfo> list, int objSize)
		{
			RoomDraw_ArbitraryXByY(list, objSize, sizex: 6, sizey: 3);
		}

		private static void RoomDraw_VerticalTurtleRockPipe(List<DrawInfo> list, int objSize)
		{
			list.AddMany(
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

		private static void RoomDraw_VitreousGooDamage(List<DrawInfo> list, int objSize)
		{
			for (int x = 0; x < 5 * 64; x += 32)
			{
				for (int y = 0; y < 64; y += 32)
				{
					list.AddMany(
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

		private static void RoomDraw_VitreousGooGraphics(List<DrawInfo> list, int objSize)
		{
			RoomDraw_ArbitraryXByY(list, objSize, sizex: 22, sizey: 11);
		}

		private static void RoomDraw_WaterHopStairs_A(List<DrawInfo> list, int objSize)
		{
			RoomDraw_ArbitraryYByX(list, objSize, sizex: 4, sizey: 2);
		}

		private static void RoomDraw_WaterHopStairs_B(List<DrawInfo> list, int objSize)
		{
			RoomDraw_ArbitraryYByX(list, objSize, sizex: 4, sizey: 2);
		}

		private static void RoomDraw_WaterOverlay8x8_1to16(List<DrawInfo> list, int objSize)
		{
			RoomDraw_Arbtrary4x4in4x4SuperSquares(list, objSize, sizebonus: 2);
		}

		private static void RoomDraw_Waterfall47(List<DrawInfo> list, int objSize)
		{
			// TODO ROOM DRAW
		}

		private static void RoomDraw_Waterfall48(List<DrawInfo> list, int objSize)
		{
			// TODO ROOM DRAW
		}

		private static void RoomDraw_Weird2x4_1_to_16(List<DrawInfo> list, int objSize)
		{
			RoomDraw_RightwardsXbyY(list, objSize, objSize + 1, sizex: 2, sizey: 4);
		}

		private static void RoomDraw_WeirdCornerBottom_BothBG(List<DrawInfo> list, int objSize)
		{
			RoomDraw_ArbitraryXByY(list, objSize, sizex: 3, sizey: 4);
		}

		private static void RoomDraw_WeirdCornerTop_BothBG(List<DrawInfo> list, int objSize)
		{
			RoomDraw_ArbitraryXByY(list, objSize, sizex: 4, sizey: 3);
		}

		//===================================================================================
		//===================================================================================
		// Doors
		//===================================================================================
		//===================================================================================

	}
}
