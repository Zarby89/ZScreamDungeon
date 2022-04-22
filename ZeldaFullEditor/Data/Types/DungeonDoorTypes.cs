using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaFullEditor.Data.Underworld;
using static ZeldaFullEditor.DoorDirection;

namespace ZeldaFullEditor.Data
{
	public class DungeonDoorDraw
	{
		private delegate void DoorDrawFunction(ZScreamer ZS, DungeonDoorObject door);

		public byte Position { get; }
		public DoorDirection Direction { get; }

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
		}

		public void Draw(ZScreamer ZS, DungeonDoorObject door)
		{
			draw(ZS, door);
			drawopp(ZS, door);
		}

		public static DungeonDoorDraw GetDirectionFromToken(byte b)
		{
			switch (b)
			{
				case (0x00 << 3) | 0x00: return North00;
				case (0x02 << 3) | 0x00: return North02;
				case (0x04 << 3) | 0x00: return North04;
				case (0x06 << 3) | 0x00: return North06;
				case (0x08 << 3) | 0x00: return North08;
				case (0x0A << 3) | 0x00: return North0A;
				case (0x0C << 3) | 0x00: return North0C;
				case (0x0E << 3) | 0x00: return North0E;
				case (0x10 << 3) | 0x00: return North10;
				case (0x12 << 3) | 0x00: return North12;
				case (0x14 << 3) | 0x00: return North14;
				case (0x16 << 3) | 0x00: return North16;

				case (0x00 << 3) | 0x01: return South00;
				case (0x02 << 3) | 0x01: return South02;
				case (0x04 << 3) | 0x01: return South04;
				case (0x06 << 3) | 0x01: return South06;
				case (0x08 << 3) | 0x01: return South08;
				case (0x0A << 3) | 0x01: return South0A;
				case (0x0C << 3) | 0x01: return South0C;
				case (0x0E << 3) | 0x01: return South0E;
				case (0x10 << 3) | 0x01: return South10;
				case (0x12 << 3) | 0x01: return South12;
				case (0x14 << 3) | 0x01: return South14;
				case (0x16 << 3) | 0x01: return South16;

				case (0x00 << 3) | 0x02: return West00;
				case (0x02 << 3) | 0x02: return West02;
				case (0x04 << 3) | 0x02: return West04;
				case (0x06 << 3) | 0x02: return West06;
				case (0x08 << 3) | 0x02: return West08;
				case (0x0A << 3) | 0x02: return West0A;
				case (0x0C << 3) | 0x02: return West0C;
				case (0x0E << 3) | 0x02: return West0E;
				case (0x10 << 3) | 0x02: return West10;
				case (0x12 << 3) | 0x02: return West12;
				case (0x14 << 3) | 0x02: return West14;
				case (0x16 << 3) | 0x02: return West16;

				case (0x00 << 3) | 0x03: return East00;
				case (0x02 << 3) | 0x03: return East02;
				case (0x04 << 3) | 0x03: return East04;
				case (0x06 << 3) | 0x03: return East06;
				case (0x08 << 3) | 0x03: return East08;
				case (0x0A << 3) | 0x03: return East0A;
				case (0x0C << 3) | 0x03: return East0C;
				case (0x0E << 3) | 0x03: return East0E;
				case (0x10 << 3) | 0x03: return East10;
				case (0x12 << 3) | 0x03: return East12;
				case (0x14 << 3) | 0x03: return East14;
				case (0x16 << 3) | 0x03: return East16;
			}
			return null;
		}


		public static readonly DungeonDoorDraw North00 = new DungeonDoorDraw(North, 0x00, DrawNorth00, DrawNothing);
		public static readonly DungeonDoorDraw North02 = new DungeonDoorDraw(North, 0x02, DrawNorth02, DrawNothing);
		public static readonly DungeonDoorDraw North04 = new DungeonDoorDraw(North, 0x04, DrawNorth04, DrawNothing);
		public static readonly DungeonDoorDraw North06 = new DungeonDoorDraw(North, 0x06, DrawNorth06, DrawNothing);
		public static readonly DungeonDoorDraw North08 = new DungeonDoorDraw(North, 0x08, DrawNorth08, DrawNothing);
		public static readonly DungeonDoorDraw North0A = new DungeonDoorDraw(North, 0x0A, DrawNorth0A, DrawNothing);
		public static readonly DungeonDoorDraw North0C = new DungeonDoorDraw(North, 0x0C, DrawNorth0C, DrawNothing);
		public static readonly DungeonDoorDraw North0E = new DungeonDoorDraw(North, 0x0E, DrawNorth0E, DrawNothing);
		public static readonly DungeonDoorDraw North10 = new DungeonDoorDraw(North, 0x10, DrawNorth10, DrawNothing);
		public static readonly DungeonDoorDraw North12 = new DungeonDoorDraw(North, 0x12, DrawNorth12, DrawNothing);
		public static readonly DungeonDoorDraw North14 = new DungeonDoorDraw(North, 0x14, DrawNorth14, DrawNothing);
		public static readonly DungeonDoorDraw North16 = new DungeonDoorDraw(North, 0x16, DrawNorth16, DrawNothing);

		public static readonly DungeonDoorDraw South00 = new DungeonDoorDraw(South, 0x00, DrawSouth00, DrawNothing);
		public static readonly DungeonDoorDraw South02 = new DungeonDoorDraw(South, 0x02, DrawSouth02, DrawNothing);
		public static readonly DungeonDoorDraw South04 = new DungeonDoorDraw(South, 0x04, DrawSouth04, DrawNothing);
		public static readonly DungeonDoorDraw South06 = new DungeonDoorDraw(South, 0x06, DrawSouth06, DrawNothing);
		public static readonly DungeonDoorDraw South08 = new DungeonDoorDraw(South, 0x08, DrawSouth08, DrawNothing);
		public static readonly DungeonDoorDraw South0A = new DungeonDoorDraw(South, 0x0A, DrawSouth0A, DrawNothing);
		public static readonly DungeonDoorDraw South0C = new DungeonDoorDraw(South, 0x0C, DrawSouth0C, DrawNothing);
		public static readonly DungeonDoorDraw South0E = new DungeonDoorDraw(South, 0x0E, DrawSouth0E, DrawNothing);
		public static readonly DungeonDoorDraw South10 = new DungeonDoorDraw(South, 0x10, DrawSouth10, DrawNothing);
		public static readonly DungeonDoorDraw South12 = new DungeonDoorDraw(South, 0x12, DrawSouth12, DrawNothing);
		public static readonly DungeonDoorDraw South14 = new DungeonDoorDraw(South, 0x14, DrawSouth14, DrawNothing);
		public static readonly DungeonDoorDraw South16 = new DungeonDoorDraw(South, 0x16, DrawSouth16, DrawNothing);

		public static readonly DungeonDoorDraw West00 = new DungeonDoorDraw(West, 0x00, DrawWest00, DrawNothing);
		public static readonly DungeonDoorDraw West02 = new DungeonDoorDraw(West, 0x02, DrawWest02, DrawNothing);
		public static readonly DungeonDoorDraw West04 = new DungeonDoorDraw(West, 0x04, DrawWest04, DrawNothing);
		public static readonly DungeonDoorDraw West06 = new DungeonDoorDraw(West, 0x06, DrawWest06, DrawNothing);
		public static readonly DungeonDoorDraw West08 = new DungeonDoorDraw(West, 0x08, DrawWest08, DrawNothing);
		public static readonly DungeonDoorDraw West0A = new DungeonDoorDraw(West, 0x0A, DrawWest0A, DrawNothing);
		public static readonly DungeonDoorDraw West0C = new DungeonDoorDraw(West, 0x0C, DrawWest0C, DrawNothing);
		public static readonly DungeonDoorDraw West0E = new DungeonDoorDraw(West, 0x0E, DrawWest0E, DrawNothing);
		public static readonly DungeonDoorDraw West10 = new DungeonDoorDraw(West, 0x10, DrawWest10, DrawNothing);
		public static readonly DungeonDoorDraw West12 = new DungeonDoorDraw(West, 0x12, DrawWest12, DrawNothing);
		public static readonly DungeonDoorDraw West14 = new DungeonDoorDraw(West, 0x14, DrawWest14, DrawNothing);
		public static readonly DungeonDoorDraw West16 = new DungeonDoorDraw(West, 0x16, DrawWest16, DrawNothing);

		public static readonly DungeonDoorDraw East00 = new DungeonDoorDraw(East, 0x00, DrawEast00, DrawNothing);
		public static readonly DungeonDoorDraw East02 = new DungeonDoorDraw(East, 0x02, DrawEast02, DrawNothing);
		public static readonly DungeonDoorDraw East04 = new DungeonDoorDraw(East, 0x04, DrawEast04, DrawNothing);
		public static readonly DungeonDoorDraw East06 = new DungeonDoorDraw(East, 0x06, DrawEast06, DrawNothing);
		public static readonly DungeonDoorDraw East08 = new DungeonDoorDraw(East, 0x08, DrawEast08, DrawNothing);
		public static readonly DungeonDoorDraw East0A = new DungeonDoorDraw(East, 0x0A, DrawEast0A, DrawNothing);
		public static readonly DungeonDoorDraw East0C = new DungeonDoorDraw(East, 0x0C, DrawEast0C, DrawNothing);
		public static readonly DungeonDoorDraw East0E = new DungeonDoorDraw(East, 0x0E, DrawEast0E, DrawNothing);
		public static readonly DungeonDoorDraw East10 = new DungeonDoorDraw(East, 0x10, DrawEast10, DrawNothing);
		public static readonly DungeonDoorDraw East12 = new DungeonDoorDraw(East, 0x12, DrawEast12, DrawNothing);
		public static readonly DungeonDoorDraw East14 = new DungeonDoorDraw(East, 0x14, DrawEast14, DrawNothing);
		public static readonly DungeonDoorDraw East16 = new DungeonDoorDraw(East, 0x16, DrawEast16, DrawNothing);


		private static void DrawNothing(ZScreamer ZS, DungeonDoorObject door) { } // THIS PAGE LEFT INTENTIONALLY BLANK

		private static void DrawNorth00(ZScreamer ZS, DungeonDoorObject door) { DrawNorth(ZS, door, 0x021C, false); }
		private static void DrawNorth02(ZScreamer ZS, DungeonDoorObject door) { DrawNorth(ZS, door, 0x023C, false); }
		private static void DrawNorth04(ZScreamer ZS, DungeonDoorObject door) { DrawNorth(ZS, door, 0x025C, false); }
		private static void DrawNorth06(ZScreamer ZS, DungeonDoorObject door) { DrawNorth(ZS, door, 0x039C, false); }
		private static void DrawNorth08(ZScreamer ZS, DungeonDoorObject door) { DrawNorth(ZS, door, 0x03BC, false); }
		private static void DrawNorth0A(ZScreamer ZS, DungeonDoorObject door) { DrawNorth(ZS, door, 0x03DC, false); }
		private static void DrawNorth0C(ZScreamer ZS, DungeonDoorObject door) { DrawNorth(ZS, door, 0x121C, false); }
		private static void DrawNorth0E(ZScreamer ZS, DungeonDoorObject door) { DrawNorth(ZS, door, 0x123C, false); }
		private static void DrawNorth10(ZScreamer ZS, DungeonDoorObject door) { DrawNorth(ZS, door, 0x125C, false); }
		private static void DrawNorth12(ZScreamer ZS, DungeonDoorObject door) { DrawNorth(ZS, door, 0x139C, false); }
		private static void DrawNorth14(ZScreamer ZS, DungeonDoorObject door) { DrawNorth(ZS, door, 0x13BC, false); }
		private static void DrawNorth16(ZScreamer ZS, DungeonDoorObject door) { DrawNorth(ZS, door, 0x13DC, false); }

		private static void DrawSouth00(ZScreamer ZS, DungeonDoorObject door) { DrawSouth(ZS, door, 0x0D1C, false); }
		private static void DrawSouth02(ZScreamer ZS, DungeonDoorObject door) { DrawSouth(ZS, door, 0x0D3C, false); }
		private static void DrawSouth04(ZScreamer ZS, DungeonDoorObject door) { DrawSouth(ZS, door, 0x0D5C, false); }
		private static void DrawSouth06(ZScreamer ZS, DungeonDoorObject door) { DrawSouth(ZS, door, 0x0B9C, false); }
		private static void DrawSouth08(ZScreamer ZS, DungeonDoorObject door) { DrawSouth(ZS, door, 0x0BBC, false); }
		private static void DrawSouth0A(ZScreamer ZS, DungeonDoorObject door) { DrawSouth(ZS, door, 0x0BDC, false); }
		private static void DrawSouth0C(ZScreamer ZS, DungeonDoorObject door) { DrawSouth(ZS, door, 0x1D1C, false); }
		private static void DrawSouth0E(ZScreamer ZS, DungeonDoorObject door) { DrawSouth(ZS, door, 0x1D3C, false); }
		private static void DrawSouth10(ZScreamer ZS, DungeonDoorObject door) { DrawSouth(ZS, door, 0x1D5C, false); }
		private static void DrawSouth12(ZScreamer ZS, DungeonDoorObject door) { DrawSouth(ZS, door, 0x1B9C, false); }
		private static void DrawSouth14(ZScreamer ZS, DungeonDoorObject door) { DrawSouth(ZS, door, 0x1BBC, false); }
		private static void DrawSouth16(ZScreamer ZS, DungeonDoorObject door) { DrawSouth(ZS, door, 0x1BDC, false); }

		private static void DrawWest00(ZScreamer ZS, DungeonDoorObject door) { DrawWest(ZS, door, 0x0784, false); }
		private static void DrawWest02(ZScreamer ZS, DungeonDoorObject door) { DrawWest(ZS, door, 0x0F84, false); }
		private static void DrawWest04(ZScreamer ZS, DungeonDoorObject door) { DrawWest(ZS, door, 0x1784, false); }
		private static void DrawWest06(ZScreamer ZS, DungeonDoorObject door) { DrawWest(ZS, door, 0x078A, false); }
		private static void DrawWest08(ZScreamer ZS, DungeonDoorObject door) { DrawWest(ZS, door, 0x0F8A, false); }
		private static void DrawWest0A(ZScreamer ZS, DungeonDoorObject door) { DrawWest(ZS, door, 0x178A, false); }
		private static void DrawWest0C(ZScreamer ZS, DungeonDoorObject door) { DrawWest(ZS, door, 0x07C4, false); }
		private static void DrawWest0E(ZScreamer ZS, DungeonDoorObject door) { DrawWest(ZS, door, 0x0FC4, false); }
		private static void DrawWest10(ZScreamer ZS, DungeonDoorObject door) { DrawWest(ZS, door, 0x17C4, false); }
		private static void DrawWest12(ZScreamer ZS, DungeonDoorObject door) { DrawWest(ZS, door, 0x07CA, false); }
		private static void DrawWest14(ZScreamer ZS, DungeonDoorObject door) { DrawWest(ZS, door, 0x0FCA, false); }
		private static void DrawWest16(ZScreamer ZS, DungeonDoorObject door) { DrawWest(ZS, door, 0x17CA, false); }

		private static void DrawEast00(ZScreamer ZS, DungeonDoorObject door) { DrawEast(ZS, door, 0x07B4, false); }
		private static void DrawEast02(ZScreamer ZS, DungeonDoorObject door) { DrawEast(ZS, door, 0x0FB4, false); }
		private static void DrawEast04(ZScreamer ZS, DungeonDoorObject door) { DrawEast(ZS, door, 0x17B4, false); }
		private static void DrawEast06(ZScreamer ZS, DungeonDoorObject door) { DrawEast(ZS, door, 0x07AE, false); }
		private static void DrawEast08(ZScreamer ZS, DungeonDoorObject door) { DrawEast(ZS, door, 0x0FAE, false); }
		private static void DrawEast0A(ZScreamer ZS, DungeonDoorObject door) { DrawEast(ZS, door, 0x17AE, false); }
		private static void DrawEast0C(ZScreamer ZS, DungeonDoorObject door) { DrawEast(ZS, door, 0x07F4, false); }
		private static void DrawEast0E(ZScreamer ZS, DungeonDoorObject door) { DrawEast(ZS, door, 0x0FF4, false); }
		private static void DrawEast10(ZScreamer ZS, DungeonDoorObject door) { DrawEast(ZS, door, 0x17F4, false); }
		private static void DrawEast12(ZScreamer ZS, DungeonDoorObject door) { DrawEast(ZS, door, 0x07EE, false); }
		private static void DrawEast14(ZScreamer ZS, DungeonDoorObject door) { DrawEast(ZS, door, 0x0FEE, false); }
		private static void DrawEast16(ZScreamer ZS, DungeonDoorObject door) { DrawEast(ZS, door, 0x17EE, false); }


		// ???
		// ushort posxy = (ushort) (ZS.ROM[addresspos + door_pos, 2] / 2);
		// float n = (((float) posxy / 64) - (byte) (posxy / 64)) * 64;
		// x = (byte) n;
		// y = (byte) (posxy / 64);

		public static unsafe void DrawTiles(ZScreamer ZS, DungeonDoorObject obj, bool bg2, ushort tmap, params DrawInfo[] instructions)
		{
			foreach (DrawInfo d in instructions)
			{
				int tm = tmap + (d.XOff / 8) + (d.YOff / 8 * 64);

				if (tm < Constants.TilesPerUnderworldRoom && tm >= 0)
				{
					ushort td = obj.Tiles[d.TileIndex].GetModifiedUnsignedShort(hflip: d.HFlip, vflip: d.VFlip);

					if (bg2)
					{
						ZS.GFXManager.tilesBg1Buffer[tm] = td;
					}
					else
					{
						ZS.GFXManager.tilesBg2Buffer[tm] = td;
					}
				}
			}
		}


		private static void DrawNorth(ZScreamer ZS, DungeonDoorObject door, ushort tmap, bool bg2)
		{
			// trim always goes on top
			DrawTiles(ZS, door, false, tmap,
				new DrawInfo(0, 0, 0),
				new DrawInfo(3, 8, 0),
				new DrawInfo(6, 16, 0),
				new DrawInfo(9, 24, 0)
			);

			DrawTiles(ZS, door, bg2, tmap,
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

		private static void DrawSouth(ZScreamer ZS, DungeonDoorObject door, ushort tmap, bool bg2)
		{
			// trim always goes on top
			DrawTiles(ZS, door, false, tmap,
				new DrawInfo(2, 0, 16),
				new DrawInfo(5, 8, 16),
				new DrawInfo(8, 16, 16),
				new DrawInfo(11, 24, 16)
			);

			DrawTiles(ZS, door, bg2, tmap,

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

		private static void DrawWest(ZScreamer ZS, DungeonDoorObject door, ushort tmap, bool bg2)
		{
			// trim always goes on top
			DrawTiles(ZS, door, false, tmap,
				new DrawInfo(0, 0, 0),
				new DrawInfo(1, 0, 8),
				new DrawInfo(2, 0, 16),
				new DrawInfo(3, 0, 24)
			);

			DrawTiles(ZS, door, bg2, tmap,
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

		private static void DrawEast(ZScreamer ZS, DungeonDoorObject door, ushort tmap, bool bg2)
		{
			// trim always goes on top
			DrawTiles(ZS, door, false, tmap,
				new DrawInfo(8, 16, 0),
				new DrawInfo(9, 16, 8),
				new DrawInfo(10, 16, 16),
				new DrawInfo(11, 16, 24)
			);

			DrawTiles(ZS, door, bg2, tmap,
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
