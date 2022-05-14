using static ZeldaFullEditor.DoorDirection;

namespace ZeldaFullEditor.Data
{
	public class DungeonDoorDraw
	{
		private delegate void DoorDrawFunction(Artist art, DungeonDoor door);

		public byte Position { get; }
		public DoorDirection Direction { get; }

		public bool IsHorizontal { get; }

		public byte Token { get; }

		private readonly DoorDrawFunction draw;
		private readonly DoorDrawFunction drawopp;
		private DungeonDoorDraw(DoorDirection dir, byte pos,
			DoorDrawFunction drawMain, DoorDrawFunction drawOpposing)
		{
			Position = pos;
			Direction = dir;
			draw = drawMain;
			drawopp = drawOpposing;
			Token = (byte) ((pos << 3) | (byte) dir);
			IsHorizontal = dir == West || dir == East;
		}

		public void Draw(Artist art, DungeonDoor door)
		{
			draw(art, door);
			drawopp(art, door);
		}

		public static DungeonDoorDraw GetDirectionFromToken(byte b) => b switch
		{
			(0x00 << 3) | 0x00 => North00,
			(0x02 << 3) | 0x00 => North02,
			(0x04 << 3) | 0x00 => North04,
			(0x06 << 3) | 0x00 => North06,
			(0x08 << 3) | 0x00 => North08,
			(0x0A << 3) | 0x00 => North0A,
			(0x0C << 3) | 0x00 => North0C,
			(0x0E << 3) | 0x00 => North0E,
			(0x10 << 3) | 0x00 => North10,
			(0x12 << 3) | 0x00 => North12,
			(0x14 << 3) | 0x00 => North14,
			(0x16 << 3) | 0x00 => North16,
			(0x00 << 3) | 0x01 => South00,
			(0x02 << 3) | 0x01 => South02,
			(0x04 << 3) | 0x01 => South04,
			(0x06 << 3) | 0x01 => South06,
			(0x08 << 3) | 0x01 => South08,
			(0x0A << 3) | 0x01 => South0A,
			(0x0C << 3) | 0x01 => South0C,
			(0x0E << 3) | 0x01 => South0E,
			(0x10 << 3) | 0x01 => South10,
			(0x12 << 3) | 0x01 => South12,
			(0x14 << 3) | 0x01 => South14,
			(0x16 << 3) | 0x01 => South16,
			(0x00 << 3) | 0x02 => West00,
			(0x02 << 3) | 0x02 => West02,
			(0x04 << 3) | 0x02 => West04,
			(0x06 << 3) | 0x02 => West06,
			(0x08 << 3) | 0x02 => West08,
			(0x0A << 3) | 0x02 => West0A,
			(0x0C << 3) | 0x02 => West0C,
			(0x0E << 3) | 0x02 => West0E,
			(0x10 << 3) | 0x02 => West10,
			(0x12 << 3) | 0x02 => West12,
			(0x14 << 3) | 0x02 => West14,
			(0x16 << 3) | 0x02 => West16,
			(0x00 << 3) | 0x03 => East00,
			(0x02 << 3) | 0x03 => East02,
			(0x04 << 3) | 0x03 => East04,
			(0x06 << 3) | 0x03 => East06,
			(0x08 << 3) | 0x03 => East08,
			(0x0A << 3) | 0x03 => East0A,
			(0x0C << 3) | 0x03 => East0C,
			(0x0E << 3) | 0x03 => East0E,
			(0x10 << 3) | 0x03 => East10,
			(0x12 << 3) | 0x03 => East12,
			(0x14 << 3) | 0x03 => East14,
			(0x16 << 3) | 0x03 => East16,
			_ => null,
		};


		public static readonly DungeonDoorDraw North00 = new(North, 0x00, DrawNorth00, DrawNothing);
		public static readonly DungeonDoorDraw North02 = new(North, 0x02, DrawNorth02, DrawNothing);
		public static readonly DungeonDoorDraw North04 = new(North, 0x04, DrawNorth04, DrawNothing);
		public static readonly DungeonDoorDraw North06 = new(North, 0x06, DrawNorth06, DrawNothing);
		public static readonly DungeonDoorDraw North08 = new(North, 0x08, DrawNorth08, DrawNothing);
		public static readonly DungeonDoorDraw North0A = new(North, 0x0A, DrawNorth0A, DrawNothing);
		public static readonly DungeonDoorDraw North0C = new(North, 0x0C, DrawNorth0C, DrawNothing);
		public static readonly DungeonDoorDraw North0E = new(North, 0x0E, DrawNorth0E, DrawNothing);
		public static readonly DungeonDoorDraw North10 = new(North, 0x10, DrawNorth10, DrawNothing);
		public static readonly DungeonDoorDraw North12 = new(North, 0x12, DrawNorth12, DrawNothing);
		public static readonly DungeonDoorDraw North14 = new(North, 0x14, DrawNorth14, DrawNothing);
		public static readonly DungeonDoorDraw North16 = new(North, 0x16, DrawNorth16, DrawNothing);

		public static readonly DungeonDoorDraw South00 = new(South, 0x00, DrawSouth00, DrawNothing);
		public static readonly DungeonDoorDraw South02 = new(South, 0x02, DrawSouth02, DrawNothing);
		public static readonly DungeonDoorDraw South04 = new(South, 0x04, DrawSouth04, DrawNothing);
		public static readonly DungeonDoorDraw South06 = new(South, 0x06, DrawSouth06, DrawNothing);
		public static readonly DungeonDoorDraw South08 = new(South, 0x08, DrawSouth08, DrawNothing);
		public static readonly DungeonDoorDraw South0A = new(South, 0x0A, DrawSouth0A, DrawNothing);
		public static readonly DungeonDoorDraw South0C = new(South, 0x0C, DrawSouth0C, DrawNothing);
		public static readonly DungeonDoorDraw South0E = new(South, 0x0E, DrawSouth0E, DrawNothing);
		public static readonly DungeonDoorDraw South10 = new(South, 0x10, DrawSouth10, DrawNothing);
		public static readonly DungeonDoorDraw South12 = new(South, 0x12, DrawSouth12, DrawNothing);
		public static readonly DungeonDoorDraw South14 = new(South, 0x14, DrawSouth14, DrawNothing);
		public static readonly DungeonDoorDraw South16 = new(South, 0x16, DrawSouth16, DrawNothing);

		public static readonly DungeonDoorDraw West00 = new(West, 0x00, DrawWest00, DrawNothing);
		public static readonly DungeonDoorDraw West02 = new(West, 0x02, DrawWest02, DrawNothing);
		public static readonly DungeonDoorDraw West04 = new(West, 0x04, DrawWest04, DrawNothing);
		public static readonly DungeonDoorDraw West06 = new(West, 0x06, DrawWest06, DrawNothing);
		public static readonly DungeonDoorDraw West08 = new(West, 0x08, DrawWest08, DrawNothing);
		public static readonly DungeonDoorDraw West0A = new(West, 0x0A, DrawWest0A, DrawNothing);
		public static readonly DungeonDoorDraw West0C = new(West, 0x0C, DrawWest0C, DrawNothing);
		public static readonly DungeonDoorDraw West0E = new(West, 0x0E, DrawWest0E, DrawNothing);
		public static readonly DungeonDoorDraw West10 = new(West, 0x10, DrawWest10, DrawNothing);
		public static readonly DungeonDoorDraw West12 = new(West, 0x12, DrawWest12, DrawNothing);
		public static readonly DungeonDoorDraw West14 = new(West, 0x14, DrawWest14, DrawNothing);
		public static readonly DungeonDoorDraw West16 = new(West, 0x16, DrawWest16, DrawNothing);

		public static readonly DungeonDoorDraw East00 = new(East, 0x00, DrawEast00, DrawNothing);
		public static readonly DungeonDoorDraw East02 = new(East, 0x02, DrawEast02, DrawNothing);
		public static readonly DungeonDoorDraw East04 = new(East, 0x04, DrawEast04, DrawNothing);
		public static readonly DungeonDoorDraw East06 = new(East, 0x06, DrawEast06, DrawNothing);
		public static readonly DungeonDoorDraw East08 = new(East, 0x08, DrawEast08, DrawNothing);
		public static readonly DungeonDoorDraw East0A = new(East, 0x0A, DrawEast0A, DrawNothing);
		public static readonly DungeonDoorDraw East0C = new(East, 0x0C, DrawEast0C, DrawNothing);
		public static readonly DungeonDoorDraw East0E = new(East, 0x0E, DrawEast0E, DrawNothing);
		public static readonly DungeonDoorDraw East10 = new(East, 0x10, DrawEast10, DrawNothing);
		public static readonly DungeonDoorDraw East12 = new(East, 0x12, DrawEast12, DrawNothing);
		public static readonly DungeonDoorDraw East14 = new(East, 0x14, DrawEast14, DrawNothing);
		public static readonly DungeonDoorDraw East16 = new(East, 0x16, DrawEast16, DrawNothing);


		private static void DrawNothing(Artist art, DungeonDoor door) { } // THIS PAGE LEFT INTENTIONALLY BLANK

		private static void DrawNorth00(Artist art, DungeonDoor door) { DrawNorth(art, door, 0x021C, false); }
		private static void DrawNorth02(Artist art, DungeonDoor door) { DrawNorth(art, door, 0x023C, false); }
		private static void DrawNorth04(Artist art, DungeonDoor door) { DrawNorth(art, door, 0x025C, false); }
		private static void DrawNorth06(Artist art, DungeonDoor door) { DrawNorth(art, door, 0x039C, false); }
		private static void DrawNorth08(Artist art, DungeonDoor door) { DrawNorth(art, door, 0x03BC, false); }
		private static void DrawNorth0A(Artist art, DungeonDoor door) { DrawNorth(art, door, 0x03DC, false); }
		private static void DrawNorth0C(Artist art, DungeonDoor door) { DrawNorth(art, door, 0x121C, false); }
		private static void DrawNorth0E(Artist art, DungeonDoor door) { DrawNorth(art, door, 0x123C, false); }
		private static void DrawNorth10(Artist art, DungeonDoor door) { DrawNorth(art, door, 0x125C, false); }
		private static void DrawNorth12(Artist art, DungeonDoor door) { DrawNorth(art, door, 0x139C, false); }
		private static void DrawNorth14(Artist art, DungeonDoor door) { DrawNorth(art, door, 0x13BC, false); }
		private static void DrawNorth16(Artist art, DungeonDoor door) { DrawNorth(art, door, 0x13DC, false); }

		private static void DrawSouth00(Artist art, DungeonDoor door) { DrawSouth(art, door, 0x0D1C, false); }
		private static void DrawSouth02(Artist art, DungeonDoor door) { DrawSouth(art, door, 0x0D3C, false); }
		private static void DrawSouth04(Artist art, DungeonDoor door) { DrawSouth(art, door, 0x0D5C, false); }
		private static void DrawSouth06(Artist art, DungeonDoor door) { DrawSouth(art, door, 0x0B9C, false); }
		private static void DrawSouth08(Artist art, DungeonDoor door) { DrawSouth(art, door, 0x0BBC, false); }
		private static void DrawSouth0A(Artist art, DungeonDoor door) { DrawSouth(art, door, 0x0BDC, false); }
		private static void DrawSouth0C(Artist art, DungeonDoor door) { DrawSouth(art, door, 0x1D1C, false); }
		private static void DrawSouth0E(Artist art, DungeonDoor door) { DrawSouth(art, door, 0x1D3C, false); }
		private static void DrawSouth10(Artist art, DungeonDoor door) { DrawSouth(art, door, 0x1D5C, false); }
		private static void DrawSouth12(Artist art, DungeonDoor door) { DrawSouth(art, door, 0x1B9C, false); }
		private static void DrawSouth14(Artist art, DungeonDoor door) { DrawSouth(art, door, 0x1BBC, false); }
		private static void DrawSouth16(Artist art, DungeonDoor door) { DrawSouth(art, door, 0x1BDC, false); }

		private static void DrawWest00(Artist art, DungeonDoor door) { DrawWest(art, door, 0x0784, false); }
		private static void DrawWest02(Artist art, DungeonDoor door) { DrawWest(art, door, 0x0F84, false); }
		private static void DrawWest04(Artist art, DungeonDoor door) { DrawWest(art, door, 0x1784, false); }
		private static void DrawWest06(Artist art, DungeonDoor door) { DrawWest(art, door, 0x078A, false); }
		private static void DrawWest08(Artist art, DungeonDoor door) { DrawWest(art, door, 0x0F8A, false); }
		private static void DrawWest0A(Artist art, DungeonDoor door) { DrawWest(art, door, 0x178A, false); }
		private static void DrawWest0C(Artist art, DungeonDoor door) { DrawWest(art, door, 0x07C4, false); }
		private static void DrawWest0E(Artist art, DungeonDoor door) { DrawWest(art, door, 0x0FC4, false); }
		private static void DrawWest10(Artist art, DungeonDoor door) { DrawWest(art, door, 0x17C4, false); }
		private static void DrawWest12(Artist art, DungeonDoor door) { DrawWest(art, door, 0x07CA, false); }
		private static void DrawWest14(Artist art, DungeonDoor door) { DrawWest(art, door, 0x0FCA, false); }
		private static void DrawWest16(Artist art, DungeonDoor door) { DrawWest(art, door, 0x17CA, false); }

		private static void DrawEast00(Artist art, DungeonDoor door) { DrawEast(art, door, 0x07B4, false); }
		private static void DrawEast02(Artist art, DungeonDoor door) { DrawEast(art, door, 0x0FB4, false); }
		private static void DrawEast04(Artist art, DungeonDoor door) { DrawEast(art, door, 0x17B4, false); }
		private static void DrawEast06(Artist art, DungeonDoor door) { DrawEast(art, door, 0x07AE, false); }
		private static void DrawEast08(Artist art, DungeonDoor door) { DrawEast(art, door, 0x0FAE, false); }
		private static void DrawEast0A(Artist art, DungeonDoor door) { DrawEast(art, door, 0x17AE, false); }
		private static void DrawEast0C(Artist art, DungeonDoor door) { DrawEast(art, door, 0x07F4, false); }
		private static void DrawEast0E(Artist art, DungeonDoor door) { DrawEast(art, door, 0x0FF4, false); }
		private static void DrawEast10(Artist art, DungeonDoor door) { DrawEast(art, door, 0x17F4, false); }
		private static void DrawEast12(Artist art, DungeonDoor door) { DrawEast(art, door, 0x07EE, false); }
		private static void DrawEast14(Artist art, DungeonDoor door) { DrawEast(art, door, 0x0FEE, false); }
		private static void DrawEast16(Artist art, DungeonDoor door) { DrawEast(art, door, 0x17EE, false); }


		// ???
		// ushort posxy = (ushort) (ZS.ROM[addresspos + door_pos, 2] / 2);
		// float n = (((float) posxy / 64) - (byte) (posxy / 64)) * 64;
		// x = (byte) n;
		// y = (byte) (posxy / 64);

		public static void DrawTiles(Artist art, DungeonDoor obj, bool bg2, ushort tmap, params DrawInfo[] instructions)
		{
			foreach (DrawInfo d in instructions)
			{
				int tm = tmap + (d.XOff / 8) + (d.YOff / 8 * 64);

				if (tm < Constants.TilesPerUnderworldRoom && tm >= 0)
				{
					ushort td = obj.Tiles[d.TileIndex].GetModifiedUnsignedShort(hflip: d.HFlip, vflip: d.VFlip);

					if (bg2)
					{
						art.Layer2TileMap[tm] = td;
					}
					else
					{
						art.Layer1TileMap[tm] = td;
					}
				}
			}
		}


		private static void DrawNorth(Artist art, DungeonDoor door, ushort tmap, bool bg2)
		{
			tmap /= 2;
			// trim always goes on top
			DrawTiles(art, door, false, tmap,
				new DrawInfo(0, 0, 0),
				new DrawInfo(3, 8, 0),
				new DrawInfo(6, 16, 0),
				new DrawInfo(9, 24, 0)
			);

			DrawTiles(art, door, bg2, tmap,
				new DrawInfo(1, 0, 8),
				new DrawInfo(4, 8, 8),
				new DrawInfo(7, 16, 8),
				new DrawInfo(10, 24, 8),

				new DrawInfo(2, 0, 16),
				new DrawInfo(5, 8, 16),
				new DrawInfo(8, 16, 16),
				new DrawInfo(11, 24, 16)
			);
		}

		private static void DrawSouth(Artist art, DungeonDoor door, ushort tmap, bool bg2)
		{
			tmap /= 2;
			// trim always goes on top
			DrawTiles(art, door, false, tmap,
				new DrawInfo(2, 0, 16),
				new DrawInfo(5, 8, 16),
				new DrawInfo(8, 16, 16),
				new DrawInfo(11, 24, 16)
			);

			DrawTiles(art, door, bg2, tmap,

				new DrawInfo(0, 0, 0),
				new DrawInfo(3, 8, 0),
				new DrawInfo(6, 16, 0),
				new DrawInfo(9, 24, 0),

				new DrawInfo(1, 0, 8),
				new DrawInfo(4, 8, 8),
				new DrawInfo(7, 16, 8),
				new DrawInfo(10, 24, 8)
			);
		}

		private static void DrawWest(Artist art, DungeonDoor door, ushort tmap, bool bg2)
		{
			tmap /= 2;
			// trim always goes on top
			DrawTiles(art, door, false, tmap,
				new DrawInfo(0, 0, 0),
				new DrawInfo(1, 0, 8),
				new DrawInfo(2, 0, 16),
				new DrawInfo(3, 0, 24)
			);

			DrawTiles(art, door, bg2, tmap,
				new DrawInfo(4, 8, 0),
				new DrawInfo(5, 8, 8),
				new DrawInfo(6, 8, 16),
				new DrawInfo(7, 8, 24),

				new DrawInfo(8, 16, 0),
				new DrawInfo(9, 16, 8),
				new DrawInfo(10, 16, 16),
				new DrawInfo(11, 16, 24)
			);
		}

		private static void DrawEast(Artist art, DungeonDoor door, ushort tmap, bool bg2)
		{
			tmap /= 2;
			// trim always goes on top
			DrawTiles(art, door, false, tmap,
				new DrawInfo(8, 16, 0),
				new DrawInfo(9, 16, 8),
				new DrawInfo(10, 16, 16),
				new DrawInfo(11, 16, 24)
			);

			DrawTiles(art, door, bg2, tmap,
				new DrawInfo(0, 0, 0),
				new DrawInfo(1, 0, 8),
				new DrawInfo(2, 0, 16),
				new DrawInfo(3, 0, 24),

				new DrawInfo(4, 8, 0),
				new DrawInfo(5, 8, 8),
				new DrawInfo(6, 8, 16),
				new DrawInfo(7, 8, 24)
			);
		}

	}
}
