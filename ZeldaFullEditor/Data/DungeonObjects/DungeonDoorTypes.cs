using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static ZeldaFullEditor.Data.DungeonObjects.DoorDirection;

namespace ZeldaFullEditor.Data.DungeonObjects
{
	public enum DoorDirection
	{
		North = 0x00,
		South = 0x01,
		West = 0x02,
		East = 0x03
	}

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

		private static void DrawDoor(ZScreamer ZS, DungeonDoorObject obj)
		{
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

		private static void DrawNorth00(ZScreamer ZS, DungeonDoorObject door) { DrawNorth(ZS, door, 0x021C); }
		private static void DrawNorth02(ZScreamer ZS, DungeonDoorObject door) { DrawNorth(ZS, door, 0x023C); }
		private static void DrawNorth04(ZScreamer ZS, DungeonDoorObject door) { DrawNorth(ZS, door, 0x025C); }
		private static void DrawNorth06(ZScreamer ZS, DungeonDoorObject door) { DrawNorth(ZS, door, 0x039C); }
		private static void DrawNorth08(ZScreamer ZS, DungeonDoorObject door) { DrawNorth(ZS, door, 0x03BC); }
		private static void DrawNorth0A(ZScreamer ZS, DungeonDoorObject door) { DrawNorth(ZS, door, 0x03DC); }
		private static void DrawNorth0C(ZScreamer ZS, DungeonDoorObject door) { DrawNorth(ZS, door, 0x121C); }
		private static void DrawNorth0E(ZScreamer ZS, DungeonDoorObject door) { DrawNorth(ZS, door, 0x123C); }
		private static void DrawNorth10(ZScreamer ZS, DungeonDoorObject door) { DrawNorth(ZS, door, 0x125C); }
		private static void DrawNorth12(ZScreamer ZS, DungeonDoorObject door) { DrawNorth(ZS, door, 0x139C); }
		private static void DrawNorth14(ZScreamer ZS, DungeonDoorObject door) { DrawNorth(ZS, door, 0x13BC); }
		private static void DrawNorth16(ZScreamer ZS, DungeonDoorObject door) { DrawNorth(ZS, door, 0x13DC); }

		private static void DrawSouth00(ZScreamer ZS, DungeonDoorObject door) { DrawSouth(ZS, door, 0x0D1C); }
		private static void DrawSouth02(ZScreamer ZS, DungeonDoorObject door) { DrawSouth(ZS, door, 0x0D3C); }
		private static void DrawSouth04(ZScreamer ZS, DungeonDoorObject door) { DrawSouth(ZS, door, 0x0D5C); }
		private static void DrawSouth06(ZScreamer ZS, DungeonDoorObject door) { DrawSouth(ZS, door, 0x0B9C); }
		private static void DrawSouth08(ZScreamer ZS, DungeonDoorObject door) { DrawSouth(ZS, door, 0x0BBC); }
		private static void DrawSouth0A(ZScreamer ZS, DungeonDoorObject door) { DrawSouth(ZS, door, 0x0BDC); }
		private static void DrawSouth0C(ZScreamer ZS, DungeonDoorObject door) { DrawSouth(ZS, door, 0x1D1C); }
		private static void DrawSouth0E(ZScreamer ZS, DungeonDoorObject door) { DrawSouth(ZS, door, 0x1D3C); }
		private static void DrawSouth10(ZScreamer ZS, DungeonDoorObject door) { DrawSouth(ZS, door, 0x1D5C); }
		private static void DrawSouth12(ZScreamer ZS, DungeonDoorObject door) { DrawSouth(ZS, door, 0x1B9C); }
		private static void DrawSouth14(ZScreamer ZS, DungeonDoorObject door) { DrawSouth(ZS, door, 0x1BBC); }
		private static void DrawSouth16(ZScreamer ZS, DungeonDoorObject door) { DrawSouth(ZS, door, 0x1BDC); }

		private static void DrawWest00(ZScreamer ZS, DungeonDoorObject door) { DrawWest(ZS, door, 0x0784); }
		private static void DrawWest02(ZScreamer ZS, DungeonDoorObject door) { DrawWest(ZS, door, 0x0F84); }
		private static void DrawWest04(ZScreamer ZS, DungeonDoorObject door) { DrawWest(ZS, door, 0x1784); }
		private static void DrawWest06(ZScreamer ZS, DungeonDoorObject door) { DrawWest(ZS, door, 0x078A); }
		private static void DrawWest08(ZScreamer ZS, DungeonDoorObject door) { DrawWest(ZS, door, 0x0F8A); }
		private static void DrawWest0A(ZScreamer ZS, DungeonDoorObject door) { DrawWest(ZS, door, 0x178A); }
		private static void DrawWest0C(ZScreamer ZS, DungeonDoorObject door) { DrawWest(ZS, door, 0x07C4); }
		private static void DrawWest0E(ZScreamer ZS, DungeonDoorObject door) { DrawWest(ZS, door, 0x0FC4); }
		private static void DrawWest10(ZScreamer ZS, DungeonDoorObject door) { DrawWest(ZS, door, 0x17C4); }
		private static void DrawWest12(ZScreamer ZS, DungeonDoorObject door) { DrawWest(ZS, door, 0x07CA); }
		private static void DrawWest14(ZScreamer ZS, DungeonDoorObject door) { DrawWest(ZS, door, 0x0FCA); }
		private static void DrawWest16(ZScreamer ZS, DungeonDoorObject door) { DrawWest(ZS, door, 0x17CA); }

		private static void DrawEast00(ZScreamer ZS, DungeonDoorObject door) { DrawEast(ZS, door, 0x07B4); }
		private static void DrawEast02(ZScreamer ZS, DungeonDoorObject door) { DrawEast(ZS, door, 0x0FB4); }
		private static void DrawEast04(ZScreamer ZS, DungeonDoorObject door) { DrawEast(ZS, door, 0x17B4); }
		private static void DrawEast06(ZScreamer ZS, DungeonDoorObject door) { DrawEast(ZS, door, 0x07AE); }
		private static void DrawEast08(ZScreamer ZS, DungeonDoorObject door) { DrawEast(ZS, door, 0x0FAE); }
		private static void DrawEast0A(ZScreamer ZS, DungeonDoorObject door) { DrawEast(ZS, door, 0x17AE); }
		private static void DrawEast0C(ZScreamer ZS, DungeonDoorObject door) { DrawEast(ZS, door, 0x07F4); }
		private static void DrawEast0E(ZScreamer ZS, DungeonDoorObject door) { DrawEast(ZS, door, 0x0FF4); }
		private static void DrawEast10(ZScreamer ZS, DungeonDoorObject door) { DrawEast(ZS, door, 0x17F4); }
		private static void DrawEast12(ZScreamer ZS, DungeonDoorObject door) { DrawEast(ZS, door, 0x07EE); }
		private static void DrawEast14(ZScreamer ZS, DungeonDoorObject door) { DrawEast(ZS, door, 0x0FEE); }
		private static void DrawEast16(ZScreamer ZS, DungeonDoorObject door) { DrawEast(ZS, door, 0x17EE); }


		private static void DrawNorth(ZScreamer ZS, DungeonDoorObject door, ushort tilemap)
		{

		}
		private static void DrawSouth(ZScreamer ZS, DungeonDoorObject door, ushort tilemap)
		{

		}
		private static void DrawWest(ZScreamer ZS, DungeonDoorObject door, ushort tilemap)
		{

		}
		private static void DrawEast(ZScreamer ZS, DungeonDoorObject door, ushort tilemap)
		{

		}

	}
}
