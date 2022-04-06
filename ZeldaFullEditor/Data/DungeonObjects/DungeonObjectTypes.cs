using static ZeldaFullEditor.Data.DungeonObjects.ObjCategory;
using static ZeldaFullEditor.Data.DungeonObjects.DungeonObjectSizeability;

namespace ZeldaFullEditor.Data.DungeonObjects
{
	public partial class DungeonRoomObject
	{
		/*
		 * All room object defaults
		 */
		public static readonly DungeonRoomObject Object000 = new DungeonRoomObject(0x000,
			RoomDraw_Rightwards2x2_1to15or32, Horizontal,
			new ObjCategory[] { Collision, Ceiling },
			new byte[] { });

		public static readonly DungeonRoomObject Object001 = new DungeonRoomObject(0x001,
			RoomDraw_Rightwards2x4_1to15or26, Horizontal,
			new ObjCategory[] { Collision, Wall, NorthSide },
			new byte[] { });

		public static readonly DungeonRoomObject Object002 = new DungeonRoomObject(0x002,
			RoomDraw_Rightwards2x4_1to15or26, Horizontal,
			new ObjCategory[] { Collision, Wall, SouthSide },
			new byte[] { });

		public static readonly DungeonRoomObject Object003 = new DungeonRoomObject(0x003,
			RoomDraw_Rightwards2x4spaced4_1to16, Horizontal,
			new ObjCategory[] { Collision, Wall, NorthSide, Ledge, LowerLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object004 = new DungeonRoomObject(0x004,
			RoomDraw_Rightwards2x4spaced4_1to16, Horizontal,
			new ObjCategory[] { Collision, Wall, SouthSide, Ledge, LowerLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object005 = new DungeonRoomObject(0x005,
			RoomDraw_Rightwards2x4spaced4_1to16_BothBG, Horizontal,
			new ObjCategory[] { Collision, WallDecoration, NorthSide },
			new byte[] { });

		public static readonly DungeonRoomObject Object006 = new DungeonRoomObject(0x006,
			RoomDraw_Rightwards2x4spaced4_1to16_BothBG, Horizontal,
			new ObjCategory[] { Collision, WallDecoration, SouthSide },
			new byte[] { });

		public static readonly DungeonRoomObject Object007 = new DungeonRoomObject(0x007,
			RoomDraw_Rightwards2x2_1to16, Horizontal,
			new ObjCategory[] { Pits, NorthSide },
			new byte[] { });

		public static readonly DungeonRoomObject Object008 = new DungeonRoomObject(0x008,
			RoomDraw_Rightwards2x2_1to16, Horizontal,
			new ObjCategory[] { Pits, SouthSide },
			new byte[] { });

		public static readonly DungeonRoomObject Object009 = new DungeonRoomObject(0x009,
			RoomDraw_DiagonalAcute_1to16, Horizontal,
			new ObjCategory[] { DiagonalCollision, Wall, NorthSide, WestSide, UpperLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object00A = new DungeonRoomObject(0x00A,
			RoomDraw_DiagonalGrave_1to16, Horizontal,
			new ObjCategory[] { DiagonalCollision, Wall, SouthSide, WestSide, UpperLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object00B = new DungeonRoomObject(0x00B,
			RoomDraw_DiagonalGrave_1to16, Horizontal,
			new ObjCategory[] { DiagonalCollision, Wall, NorthSide, EastSide, UpperLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object00C = new DungeonRoomObject(0x00C,
			RoomDraw_DiagonalAcute_1to16, Horizontal,
			new ObjCategory[] { DiagonalCollision, Wall, SouthSide, EastSide, UpperLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object00D = new DungeonRoomObject(0x00D,
			RoomDraw_DiagonalAcute_1to16, Horizontal,
			new ObjCategory[] { DiagonalCollision, Wall, NorthSide, WestSide, UpperLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object00E = new DungeonRoomObject(0x00E,
			RoomDraw_DiagonalGrave_1to16, Horizontal,
			new ObjCategory[] { DiagonalCollision, Wall, SouthSide, WestSide, UpperLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object00F = new DungeonRoomObject(0x00F,
			RoomDraw_DiagonalGrave_1to16, Horizontal,
			new ObjCategory[] { DiagonalCollision, Wall, NorthSide, EastSide, UpperLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object010 = new DungeonRoomObject(0x010,
			RoomDraw_DiagonalAcute_1to16, Horizontal,
			new ObjCategory[] { DiagonalCollision, Wall, SouthSide, EastSide, UpperLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object011 = new DungeonRoomObject(0x011,
			RoomDraw_DiagonalAcute_1to16, Horizontal,
			new ObjCategory[] { DiagonalCollision, Wall, NorthSide, WestSide, UpperLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object012 = new DungeonRoomObject(0x012,
			RoomDraw_DiagonalGrave_1to16, Horizontal,
			new ObjCategory[] { DiagonalCollision, Wall, SouthSide, WestSide, UpperLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object013 = new DungeonRoomObject(0x013,
			RoomDraw_DiagonalGrave_1to16, Horizontal,
			new ObjCategory[] { DiagonalCollision, Wall, NorthSide, EastSide, UpperLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object014 = new DungeonRoomObject(0x014,
			RoomDraw_DiagonalAcute_1to16, Horizontal,
			new ObjCategory[] { DiagonalCollision, Wall, SouthSide, EastSide, UpperLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object015 = new DungeonRoomObject(0x015,
			RoomDraw_DiagonalAcute_1to16_BothBG, Horizontal,
			new ObjCategory[] { DiagonalCollision, Wall, NorthSide, WestSide, LowerLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object016 = new DungeonRoomObject(0x016,
			RoomDraw_DiagonalGrave_1to16_BothBG, Horizontal,
			new ObjCategory[] { DiagonalCollision, Wall, SouthSide, WestSide, LowerLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object017 = new DungeonRoomObject(0x017,
			RoomDraw_DiagonalGrave_1to16_BothBG, Horizontal,
			new ObjCategory[] { DiagonalCollision, Wall, NorthSide, EastSide, LowerLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object018 = new DungeonRoomObject(0x018,
			RoomDraw_DiagonalAcute_1to16_BothBG, Horizontal,
			new ObjCategory[] { DiagonalCollision, Wall, SouthSide, EastSide, LowerLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object019 = new DungeonRoomObject(0x019,
			RoomDraw_DiagonalAcute_1to16_BothBG, Horizontal,
			new ObjCategory[] { DiagonalCollision, Wall, NorthSide, WestSide, LowerLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object01A = new DungeonRoomObject(0x01A,
			RoomDraw_DiagonalGrave_1to16_BothBG, Horizontal,
			new ObjCategory[] { DiagonalCollision, Wall, SouthSide, WestSide, LowerLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object01B = new DungeonRoomObject(0x01B,
			RoomDraw_DiagonalGrave_1to16_BothBG, Horizontal,
			new ObjCategory[] { DiagonalCollision, Wall, NorthSide, EastSide, LowerLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object01C = new DungeonRoomObject(0x01C,
			RoomDraw_DiagonalAcute_1to16_BothBG, Horizontal,
			new ObjCategory[] { DiagonalCollision, Wall, SouthSide, EastSide, LowerLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object01D = new DungeonRoomObject(0x01D,
			RoomDraw_DiagonalAcute_1to16_BothBG, Horizontal,
			new ObjCategory[] { DiagonalCollision, Wall, NorthSide, WestSide, LowerLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object01E = new DungeonRoomObject(0x01E,
			RoomDraw_DiagonalGrave_1to16_BothBG, Horizontal,
			new ObjCategory[] { DiagonalCollision, Wall, SouthSide, WestSide, LowerLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object01F = new DungeonRoomObject(0x01F,
			RoomDraw_DiagonalGrave_1to16_BothBG, Horizontal,
			new ObjCategory[] { DiagonalCollision, Wall, NorthSide, EastSide, LowerLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object020 = new DungeonRoomObject(0x020,
			RoomDraw_DiagonalAcute_1to16_BothBG, Horizontal,
			new ObjCategory[] { DiagonalCollision, Wall, SouthSide, EastSide, LowerLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object021 = new DungeonRoomObject(0x021,
			RoomDraw_Rightwards1x2_1to16_plus2, Horizontal,
			new ObjCategory[] { Stairs },
			new byte[] { });

		public static readonly DungeonRoomObject Object022 = new DungeonRoomObject(0x022,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus3, Horizontal,
			new ObjCategory[] { Collision },
			new byte[] { });

		public static readonly DungeonRoomObject Object023 = new DungeonRoomObject(0x023,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new ObjCategory[] { Pits },
			new byte[] { });

		public static readonly DungeonRoomObject Object024 = new DungeonRoomObject(0x024,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new ObjCategory[] { Pits },
			new byte[] { });

		public static readonly DungeonRoomObject Object025 = new DungeonRoomObject(0x025,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new ObjCategory[] { Pits },
			new byte[] { });

		public static readonly DungeonRoomObject Object026 = new DungeonRoomObject(0x026,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new ObjCategory[] { Pits },
			new byte[] { });

		public static readonly DungeonRoomObject Object027 = new DungeonRoomObject(0x027,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new ObjCategory[] { Pits },
			new byte[] { });

		public static readonly DungeonRoomObject Object028 = new DungeonRoomObject(0x028,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new ObjCategory[] { Pits },
			new byte[] { });

		public static readonly DungeonRoomObject Object029 = new DungeonRoomObject(0x029,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new ObjCategory[] { Pits },
			new byte[] { });

		public static readonly DungeonRoomObject Object02A = new DungeonRoomObject(0x02A,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new ObjCategory[] { Pits },
			new byte[] { });

		public static readonly DungeonRoomObject Object02B = new DungeonRoomObject(0x02B,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new ObjCategory[] { Pits },
			new byte[] { });

		public static readonly DungeonRoomObject Object02C = new DungeonRoomObject(0x02C,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new ObjCategory[] { Pits },
			new byte[] { });

		public static readonly DungeonRoomObject Object02D = new DungeonRoomObject(0x02D,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new ObjCategory[] { Pits },
			new byte[] { });

		public static readonly DungeonRoomObject Object02E = new DungeonRoomObject(0x02E,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new ObjCategory[] { Pits },
			new byte[] { });

		public static readonly DungeonRoomObject Object02F = new DungeonRoomObject(0x02F,
			RoomDraw_RightwardsWithCorners1x2_1to16_plus13, Horizontal,
			new ObjCategory[] { Collision, Ledge, Wall, NorthSide, SouthSide, UpperLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object030 = new DungeonRoomObject(0x030,
			RoomDraw_RightwardsWithCorners1x2_1to16_plus13, Horizontal,
			new ObjCategory[] { Collision, Ledge, Wall, NorthSide, SouthSide, UpperLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object031 = new DungeonRoomObject(0x031,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object032 = new DungeonRoomObject(0x032,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object033 = new DungeonRoomObject(0x033,
			RoomDraw_Rightwards4x4_1to16, Horizontal,
			new ObjCategory[] { NoCollision, Floor, RoomDecoration },
			new byte[] { });

		public static readonly DungeonRoomObject Object034 = new DungeonRoomObject(0x034,
			RoomDraw_Rightwards1x1Solid_1to16_plus3, Horizontal,
			new ObjCategory[] { NoCollision, Floor, RoomDecoration, NorthPerimeter, SouthPerimeter },
			new byte[] { });

		public static readonly DungeonRoomObject Object035 = new DungeonRoomObject(0x035,
			RoomDraw_DoorSwitcherer, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object036 = new DungeonRoomObject(0x036,
			RoomDraw_RightwardsDecor4x4spaced2_1to16, Horizontal,
			new ObjCategory[] { Collision, WallDecoration, NorthSide, UpperLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object037 = new DungeonRoomObject(0x037,
			RoomDraw_RightwardsDecor4x4spaced2_1to16, Horizontal,
			new ObjCategory[] { Collision, WallDecoration, SouthSide, UpperLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object038 = new DungeonRoomObject(0x038,
			RoomDraw_RightwardsStatue2x3spaced2_1to16, Horizontal,
			new ObjCategory[] { Collision, RoomDecoration, Hookshottable },
			new byte[] { });

		public static readonly DungeonRoomObject Object039 = new DungeonRoomObject(0x039,
			RoomDraw_RightwardsPillar2x4spaced4_1to16, Horizontal,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly DungeonRoomObject Object03A = new DungeonRoomObject(0x03A,
			RoomDraw_RightwardsDecor4x3spaced4_1to16, Horizontal,
			new ObjCategory[] { Collision, WallDecoration, NorthSide, UpperLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object03B = new DungeonRoomObject(0x03B,
			RoomDraw_RightwardsDecor4x3spaced4_1to16, Horizontal,
			new ObjCategory[] { Collision, WallDecoration, SouthSide, UpperLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object03C = new DungeonRoomObject(0x03C,
			RoomDraw_RightwardsDoubled2x2spaced2_1to16, Horizontal,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly DungeonRoomObject Object03D = new DungeonRoomObject(0x03D,
			RoomDraw_RightwardsPillar2x4spaced4_1to16, Horizontal,
			new ObjCategory[] { Collision, RoomDecoration, Hookshottable },
			new byte[] { });

		public static readonly DungeonRoomObject Object03E = new DungeonRoomObject(0x03E,
			RoomDraw_RightwardsDecor2x2spaced12_1to16, Horizontal,
			new ObjCategory[] { Collision, WallDecoration, NorthSide, UpperLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object03F = new DungeonRoomObject(0x03F,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new ObjCategory[] { ShallowWater },
			new byte[] { });

		public static readonly DungeonRoomObject Object040 = new DungeonRoomObject(0x040,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new ObjCategory[] { ShallowWater },
			new byte[] { });

		public static readonly DungeonRoomObject Object041 = new DungeonRoomObject(0x041,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new ObjCategory[] { ShallowWater },
			new byte[] { });

		public static readonly DungeonRoomObject Object042 = new DungeonRoomObject(0x042,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new ObjCategory[] { ShallowWater },
			new byte[] { });

		public static readonly DungeonRoomObject Object043 = new DungeonRoomObject(0x043,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new ObjCategory[] { ShallowWater },
			new byte[] { });

		public static readonly DungeonRoomObject Object044 = new DungeonRoomObject(0x044,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new ObjCategory[] { ShallowWater },
			new byte[] { });

		public static readonly DungeonRoomObject Object045 = new DungeonRoomObject(0x045,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new ObjCategory[] { ShallowWater },
			new byte[] { });

		public static readonly DungeonRoomObject Object046 = new DungeonRoomObject(0x046,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new ObjCategory[] { ShallowWater },
			new byte[] { });

		public static readonly DungeonRoomObject Object047 = new DungeonRoomObject(0x047,
			RoomDraw_Waterfall47, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object048 = new DungeonRoomObject(0x048,
			RoomDraw_Waterfall48, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object049 = new DungeonRoomObject(0x049,
			RoomDraw_RightwardsFloorTile4x2_1to16, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object04A = new DungeonRoomObject(0x04A,
			RoomDraw_RightwardsFloorTile4x2_1to16, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object04B = new DungeonRoomObject(0x04B,
			RoomDraw_RightwardsDecor2x2spaced12_1to16, Horizontal,
			new ObjCategory[] { Collision, WallDecoration, SouthSide, UpperLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object04C = new DungeonRoomObject(0x04C,
			RoomDraw_RightwardsBar4x3_1to16, Horizontal,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly DungeonRoomObject Object04D = new DungeonRoomObject(0x04D,
			RoomDraw_RightwardsShelf4x4_1to16, Horizontal,
			new ObjCategory[] { Collision, WallDecoration, NorthSide, UpperLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object04E = new DungeonRoomObject(0x04E,
			RoomDraw_RightwardsShelf4x4_1to16, Horizontal,
			new ObjCategory[] { Collision, WallDecoration, NorthSide, UpperLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object04F = new DungeonRoomObject(0x04F,
			RoomDraw_RightwardsShelf4x4_1to16, Horizontal,
			new ObjCategory[] { Collision, WallDecoration, NorthSide, UpperLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object050 = new DungeonRoomObject(0x050,
			RoomDraw_RightwardsLine1x1_1to16plus1, Horizontal,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object051 = new DungeonRoomObject(0x051,
			RoomDraw_RightwardsCannonHole4x3_1to16, Horizontal,
			new ObjCategory[] { Collision, WallDecoration, NorthSide },
			new byte[] { });

		public static readonly DungeonRoomObject Object052 = new DungeonRoomObject(0x052,
			RoomDraw_RightwardsCannonHole4x3_1to16, Horizontal,
			new ObjCategory[] { Collision, WallDecoration, SouthSide },
			new byte[] { });

		public static readonly DungeonRoomObject Object053 = new DungeonRoomObject(0x053,
			RoomDraw_Rightwards2x2_1to16, Horizontal,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object054 = new DungeonRoomObject(0x054,
			RoomDraw_Nothing, Horizontal,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object055 = new DungeonRoomObject(0x055,
			RoomDraw_RightwardsDecor4x2spaced8_1to16, Horizontal,
			new ObjCategory[] { Collision, WallDecoration, NorthSide, UpperLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object056 = new DungeonRoomObject(0x056,
			RoomDraw_RightwardsDecor4x2spaced8_1to16, Horizontal,
			new ObjCategory[] { Collision, WallDecoration, SouthSide, UpperLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object057 = new DungeonRoomObject(0x057,
			RoomDraw_Nothing, Horizontal,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object058 = new DungeonRoomObject(0x058,
			RoomDraw_Nothing, Horizontal,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object059 = new DungeonRoomObject(0x059,
			RoomDraw_Nothing, Horizontal,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object05A = new DungeonRoomObject(0x05A,
			RoomDraw_Nothing, Horizontal,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object05B = new DungeonRoomObject(0x05B,
			RoomDraw_RightwardsCannonHole4x3_1to16, Horizontal,
			new ObjCategory[] { Collision, WallDecoration, NorthSide },
			new byte[] { });

		public static readonly DungeonRoomObject Object05C = new DungeonRoomObject(0x05C,
			RoomDraw_RightwardsCannonHole4x3_1to16, Horizontal,
			new ObjCategory[] { Collision, WallDecoration, SouthSide },
			new byte[] { });

		public static readonly DungeonRoomObject Object05D = new DungeonRoomObject(0x05D,
			RoomDraw_RightwardsBigRail1x3_1to16plus5, Horizontal,
			new ObjCategory[] { Collision, RoomDecoration, Hookshottable },
			new byte[] { });

		public static readonly DungeonRoomObject Object05E = new DungeonRoomObject(0x05E,
			RoomDraw_RightwardsBlock2x2spaced2_1to16, Horizontal,
			new ObjCategory[] { Collision, RoomDecoration, Hookshottable },
			new byte[] { });

		public static readonly DungeonRoomObject Object05F = new DungeonRoomObject(0x05F,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus23, Horizontal,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly DungeonRoomObject Object060 = new DungeonRoomObject(0x060,
			RoomDraw_Downwards2x2_1to15or32, Horizontal,
			new ObjCategory[] { Ceiling, Collision },
			new byte[] { });

		public static readonly DungeonRoomObject Object061 = new DungeonRoomObject(0x061,
			RoomDraw_Downwards4x2_1to15or26, Horizontal,
			new ObjCategory[] { Collision, Wall, WestSide },
			new byte[] { });

		public static readonly DungeonRoomObject Object062 = new DungeonRoomObject(0x062,
			RoomDraw_Downwards4x2_1to15or26, Horizontal,
			new ObjCategory[] { Collision, Wall, EastSide },
			new byte[] { });

		public static readonly DungeonRoomObject Object063 = new DungeonRoomObject(0x063,
			RoomDraw_Downwards4x2_1to16_BothBG, Horizontal,
			new ObjCategory[] { Collision, Wall, WestSide, LowerLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object064 = new DungeonRoomObject(0x064,
			RoomDraw_Downwards4x2_1to16_BothBG, Horizontal,
			new ObjCategory[] { Collision, Wall, EastSide, LowerLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object065 = new DungeonRoomObject(0x065,
			RoomDraw_DownwardsDecor4x2spaced4_1to16, Horizontal,
			new ObjCategory[] { Collision, WallDecoration, WestSide, UpperLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object066 = new DungeonRoomObject(0x066,
			RoomDraw_DownwardsDecor4x2spaced4_1to16, Horizontal,
			new ObjCategory[] { Collision, WallDecoration, WestSide, UpperLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object067 = new DungeonRoomObject(0x067,
			RoomDraw_Downwards2x2_1to16, Horizontal,
			new ObjCategory[] { Pits, WestSide },
			new byte[] { });

		public static readonly DungeonRoomObject Object068 = new DungeonRoomObject(0x068,
			RoomDraw_Downwards2x2_1to16, Horizontal,
			new ObjCategory[] { Pits, EastSide },
			new byte[] { });

		public static readonly DungeonRoomObject Object069 = new DungeonRoomObject(0x069,
			RoomDraw_DownwardsHasEdge1x1_1to16_plus3, Horizontal,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly DungeonRoomObject Object06A = new DungeonRoomObject(0x06A,
			RoomDraw_DownwardsEdge1x1_1to16, Horizontal,
			new ObjCategory[] { Pits, WestPerimeter},
			new byte[] { });

		public static readonly DungeonRoomObject Object06B = new DungeonRoomObject(0x06B,
			RoomDraw_DownwardsEdge1x1_1to16, Horizontal,
			new ObjCategory[] { Pits, EastPerimeter },
			new byte[] { });

		public static readonly DungeonRoomObject Object06C = new DungeonRoomObject(0x06C,
			RoomDraw_DownwardsWithCorners2x1_1to16_plus12, Horizontal,
			new ObjCategory[] { Collision, WestSide, EastSide, UpperLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object06D = new DungeonRoomObject(0x06D,
			RoomDraw_DownwardsWithCorners2x1_1to16_plus12, Horizontal,
			new ObjCategory[] { Collision, WestSide, EastSide, UpperLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object06E = new DungeonRoomObject(0x06E,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object06F = new DungeonRoomObject(0x06F,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object070 = new DungeonRoomObject(0x070,
			RoomDraw_DownwardsFloor4x4_1to16, Vertical,
			new ObjCategory[] { NoCollision, Floor, RoomDecoration },
			new byte[] { });

		public static readonly DungeonRoomObject Object071 = new DungeonRoomObject(0x071,
			RoomDraw_Downwards1x1Solid_1to16_plus3, Vertical,
			new ObjCategory[] { NoCollision, Floor, RoomDecoration, WestPerimeter, EastPerimeter },
			new byte[] { });

		public static readonly DungeonRoomObject Object072 = new DungeonRoomObject(0x072,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object073 = new DungeonRoomObject(0x073,
			RoomDraw_DownwardsDecor4x4spaced2_1to16, Vertical,
			new ObjCategory[] { Collision, WallDecoration, WestSide, UpperLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object074 = new DungeonRoomObject(0x074,
			RoomDraw_DownwardsDecor4x4spaced2_1to16, Vertical,
			new ObjCategory[] { Collision, WallDecoration, EastSide, UpperLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object075 = new DungeonRoomObject(0x075,
			RoomDraw_DownwardsPillar2x4spaced2_1to16, Vertical,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly DungeonRoomObject Object076 = new DungeonRoomObject(0x076,
			RoomDraw_DownwardsDecor4x4spaced4_1to16, Vertical,
			new ObjCategory[] { Collision, WallDecoration, WestSide, UpperLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object077 = new DungeonRoomObject(0x077,
			RoomDraw_DownwardsDecor4x4spaced4_1to16, Vertical,
			new ObjCategory[] { Collision, WallDecoration, EastSide, UpperLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object078 = new DungeonRoomObject(0x078,
			RoomDraw_DownwardsDecor2x2spaced12_1to16, Vertical,
			new ObjCategory[] { Collision, WallDecoration, WestSide, UpperLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object079 = new DungeonRoomObject(0x079,
			RoomDraw_DownwardsEdge1x1_1to16, Vertical,
			new ObjCategory[] { ShallowWater, Floor },
			new byte[] { });

		public static readonly DungeonRoomObject Object07A = new DungeonRoomObject(0x07A,
			RoomDraw_DownwardsEdge1x1_1to16, Vertical,
			new ObjCategory[] { ShallowWater, Floor },
			new byte[] { });

		public static readonly DungeonRoomObject Object07B = new DungeonRoomObject(0x07B,
			RoomDraw_DownwardsDecor2x2spaced12_1to16, Vertical,
			new ObjCategory[] { Collision, WallDecoration, EastSide, UpperLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object07C = new DungeonRoomObject(0x07C,
			RoomDraw_DownwardsLine1x1_1to16plus1, Vertical,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object07D = new DungeonRoomObject(0x07D,
			RoomDraw_Downwards2x2_1to16, Vertical,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object07E = new DungeonRoomObject(0x07E,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object07F = new DungeonRoomObject(0x07F,
			RoomDraw_DownwardsDecor2x4spaced8_1to16, Vertical,
			new ObjCategory[] { Collision, WallDecoration, WestSide, UpperLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object080 = new DungeonRoomObject(0x080,
			RoomDraw_DownwardsDecor2x4spaced8_1to16, Vertical,
			new ObjCategory[] { Collision, WallDecoration, EastSide, UpperLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object081 = new DungeonRoomObject(0x081,
			RoomDraw_DownwardsDecor3x4spaced2_1to16, Vertical,
			new ObjCategory[] { Collision, WallDecoration, WestSide, UpperLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object082 = new DungeonRoomObject(0x082,
			RoomDraw_DownwardsDecor3x4spaced2_1to16, Vertical,
			new ObjCategory[] { Collision, WallDecoration, EastSide, UpperLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object083 = new DungeonRoomObject(0x083,
			RoomDraw_DownwardsDecor3x4spaced2_1to16, Vertical,
			new ObjCategory[] { Collision, WallDecoration, WestSide, UpperLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object084 = new DungeonRoomObject(0x084,
			RoomDraw_DownwardsDecor3x4spaced2_1to16, Vertical,
			new ObjCategory[] { Collision, WallDecoration, EastSide, UpperLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object085 = new DungeonRoomObject(0x085,
			RoomDraw_DownwardsCannonHole3x4_1to16, Vertical,
			new ObjCategory[] { Collision, WallDecoration, WestSide, UpperLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object086 = new DungeonRoomObject(0x086,
			RoomDraw_DownwardsCannonHole3x4_1to16, Vertical,
			new ObjCategory[] { Collision, WallDecoration, EastSide, UpperLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object087 = new DungeonRoomObject(0x087,
			RoomDraw_DownwardsPillar2x4spaced2_1to16, Vertical,
			new ObjCategory[] { Collision, RoomDecoration, Hookshottable },
			new byte[] { });

		public static readonly DungeonRoomObject Object088 = new DungeonRoomObject(0x088,
			RoomDraw_DownwardsBigRail3x1_1to16plus5, Vertical,
			new ObjCategory[] { Collision, RoomDecoration, Hookshottable },
			new byte[] { });

		public static readonly DungeonRoomObject Object089 = new DungeonRoomObject(0x089,
			RoomDraw_DownwardsBlock2x2spaced2_1to16, Vertical,
			new ObjCategory[] { Collision, RoomDecoration, Hookshottable },
			new byte[] { });

		public static readonly DungeonRoomObject Object08A = new DungeonRoomObject(0x08A,
			RoomDraw_DownwardsHasEdge1x1_1to16_plus23, Vertical,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly DungeonRoomObject Object08B = new DungeonRoomObject(0x08B,
			RoomDraw_DownwardsEdge1x1_1to16plus7, Vertical,
			new ObjCategory[] { Ledge, UpperLayer, WestPerimeter },
			new byte[] { });

		public static readonly DungeonRoomObject Object08C = new DungeonRoomObject(0x08C,
			RoomDraw_DownwardsEdge1x1_1to16plus7, Vertical,
			new ObjCategory[] { Ledge, UpperLayer, EastPerimeter },
			new byte[] { });

		public static readonly DungeonRoomObject Object08D = new DungeonRoomObject(0x08D,
			RoomDraw_DownwardsEdge1x1_1to16, Vertical,
			new ObjCategory[] { NoCollision, Floor, RoomDecoration, WestPerimeter },
			new byte[] { });

		public static readonly DungeonRoomObject Object08E = new DungeonRoomObject(0x08E,
			RoomDraw_DownwardsEdge1x1_1to16, Vertical,
			new ObjCategory[] { NoCollision, Floor, RoomDecoration, EastPerimeter },
			new byte[] { });

		public static readonly DungeonRoomObject Object08F = new DungeonRoomObject(0x08F,
			RoomDraw_DownwardsBar2x5_1to16, Vertical,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly DungeonRoomObject Object090 = new DungeonRoomObject(0x090,
			RoomDraw_Downwards4x2_1to15or26, Vertical,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object091 = new DungeonRoomObject(0x091,
			RoomDraw_Downwards4x2_1to15or26, Vertical,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object092 = new DungeonRoomObject(0x092,
			RoomDraw_Downwards2x2_1to15or32, Vertical,
			new ObjCategory[] { Collision, PuzzlePegs, Hookshottable },
			new byte[] { });

		public static readonly DungeonRoomObject Object093 = new DungeonRoomObject(0x093,
			RoomDraw_Downwards2x2_1to15or32, Vertical,
			new ObjCategory[] { Collision, PuzzlePegs, Hookshottable },
			new byte[] { });

		public static readonly DungeonRoomObject Object094 = new DungeonRoomObject(0x094,
			RoomDraw_DownwardsFloor4x4_1to16, Vertical,
			new ObjCategory[] { NoCollision, Floor },
			new byte[] { });

		public static readonly DungeonRoomObject Object095 = new DungeonRoomObject(0x095,
			RoomDraw_Downwards2x2_1to16, Vertical,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly DungeonRoomObject Object096 = new DungeonRoomObject(0x096,
			RoomDraw_Downwards2x2_1to16, Vertical,
			new ObjCategory[] { Collision, PuzzlePegs, Hookshottable, Manipulable },
			new byte[] { });

		public static readonly DungeonRoomObject Object097 = new DungeonRoomObject(0x097,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object098 = new DungeonRoomObject(0x098,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object099 = new DungeonRoomObject(0x099,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object09A = new DungeonRoomObject(0x09A,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object09B = new DungeonRoomObject(0x09B,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object09C = new DungeonRoomObject(0x09C,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object09D = new DungeonRoomObject(0x09D,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object09E = new DungeonRoomObject(0x09E,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object09F = new DungeonRoomObject(0x09F,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object0A0 = new DungeonRoomObject(0x0A0,
			RoomDraw_DiagonalCeilingTopLeft, Both,
			new ObjCategory[] { Collision, Ceiling },
			new byte[] { });

		public static readonly DungeonRoomObject Object0A1 = new DungeonRoomObject(0x0A1,
			RoomDraw_DiagonalCeilingBottomLeft, Both,
			new ObjCategory[] { Collision, Ceiling },
			new byte[] { });

		public static readonly DungeonRoomObject Object0A2 = new DungeonRoomObject(0x0A2,
			RoomDraw_DiagonalCeilingTopRight, Both,
			new ObjCategory[] { Collision, Ceiling },
			new byte[] { });

		public static readonly DungeonRoomObject Object0A3 = new DungeonRoomObject(0x0A3,
			RoomDraw_DiagonalCeilingBottomRight, Both,
			new ObjCategory[] { Collision, Ceiling },
			new byte[] { });

		public static readonly DungeonRoomObject Object0A4 = new DungeonRoomObject(0x0A4,
			RoomDraw_BigHole4x4_1to16, Both,
			new ObjCategory[] { Pits },
			new byte[] { });

		public static readonly DungeonRoomObject Object0A5 = new DungeonRoomObject(0x0A5,
			RoomDraw_DiagonalCeilingTopLeft, Both,
			new ObjCategory[] { Collision, Ceiling },
			new byte[] { });

		public static readonly DungeonRoomObject Object0A6 = new DungeonRoomObject(0x0A6,
			RoomDraw_DiagonalCeilingBottomLeft, Both,
			new ObjCategory[] { Collision, Ceiling },
			new byte[] { });

		public static readonly DungeonRoomObject Object0A7 = new DungeonRoomObject(0x0A7,
			RoomDraw_DiagonalCeilingTopRight, Both,
			new ObjCategory[] { Collision, Ceiling },
			new byte[] { });

		public static readonly DungeonRoomObject Object0A8 = new DungeonRoomObject(0x0A8,
			RoomDraw_DiagonalCeilingBottomRight, Both,
			new ObjCategory[] { Collision, Ceiling },
			new byte[] { });

		public static readonly DungeonRoomObject Object0A9 = new DungeonRoomObject(0x0A9,
			RoomDraw_DiagonalCeilingTopLeft, Both,
			new ObjCategory[] { Collision, Ceiling },
			new byte[] { });

		public static readonly DungeonRoomObject Object0AA = new DungeonRoomObject(0x0AA,
			RoomDraw_DiagonalCeilingBottomLeft, Both,
			new ObjCategory[] { Collision, Ceiling },
			new byte[] { });

		public static readonly DungeonRoomObject Object0AB = new DungeonRoomObject(0x0AB,
			RoomDraw_DiagonalCeilingTopRight, Both,
			new ObjCategory[] { Collision, Ceiling },
			new byte[] { });

		public static readonly DungeonRoomObject Object0AC = new DungeonRoomObject(0x0AC,
			RoomDraw_DiagonalCeilingBottomRight, Both,
			new ObjCategory[] { Collision, Ceiling },
			new byte[] { });

		public static readonly DungeonRoomObject Object0AD = new DungeonRoomObject(0x0AD,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object0AE = new DungeonRoomObject(0x0AE,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object0AF = new DungeonRoomObject(0x0AF,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object0B0 = new DungeonRoomObject(0x0B0,
			RoomDraw_RightwardsEdge1x1_1to16plus7, Horizontal,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object0B1 = new DungeonRoomObject(0x0B1,
			RoomDraw_RightwardsEdge1x1_1to16plus7, Horizontal,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object0B2 = new DungeonRoomObject(0x0B2,
			RoomDraw_Rightwards4x4_1to16, Horizontal,
			new ObjCategory[] { NoCollision, Floor },
			new byte[] { });

		public static readonly DungeonRoomObject Object0B3 = new DungeonRoomObject(0x0B3,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new ObjCategory[] { NoCollision, Floor, NorthPerimeter },
			new byte[] { });

		public static readonly DungeonRoomObject Object0B4 = new DungeonRoomObject(0x0B4,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new ObjCategory[] { NoCollision, Floor, SouthPerimeter },
			new byte[] { });

		public static readonly DungeonRoomObject Object0B5 = new DungeonRoomObject(0x0B5,
			RoomDraw_Weird2x4_1_to_16, Horizontal,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object0B6 = new DungeonRoomObject(0x0B6,
			RoomDraw_Rightwards2x4_1to15or26, Horizontal,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object0B7 = new DungeonRoomObject(0x0B7,
			RoomDraw_Rightwards2x4_1to15or26, Horizontal,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object0B8 = new DungeonRoomObject(0x0B8,
			RoomDraw_Rightwards2x2_1to15or32, Horizontal,
			new ObjCategory[] { Collision, PuzzlePegs, Hookshottable },
			new byte[] { });

		public static readonly DungeonRoomObject Object0B9 = new DungeonRoomObject(0x0B9,
			RoomDraw_Rightwards2x2_1to15or32, Horizontal,
			new ObjCategory[] { Collision, PuzzlePegs, Hookshottable },
			new byte[] { });

		public static readonly DungeonRoomObject Object0BA = new DungeonRoomObject(0x0BA,
			RoomDraw_Rightwards4x4_1to16, Horizontal,
			new ObjCategory[] { NoCollision, Floor },
			new byte[] { });

		public static readonly DungeonRoomObject Object0BB = new DungeonRoomObject(0x0BB,
			RoomDraw_RightwardsBlock2x2spaced2_1to16, Horizontal,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object0BC = new DungeonRoomObject(0x0BC,
			RoomDraw_RightwardsFakePots2x2_1to16, Horizontal,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly DungeonRoomObject Object0BD = new DungeonRoomObject(0x0BD,
			RoomDraw_RightwardsHammerPegs2x2_1to16, Horizontal,
			new ObjCategory[] { Collision, PuzzlePegs, Hookshottable, Manipulable },
			new byte[] { });

		public static readonly DungeonRoomObject Object0BE = new DungeonRoomObject(0x0BE,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object0BF = new DungeonRoomObject(0x0BF,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object0C0 = new DungeonRoomObject(0x0C0,
			RoomDraw_4x4BlocksIn4x4SuperSquare, Both,
			new ObjCategory[] { Collision, Ceiling },
			new byte[] { });

		public static readonly DungeonRoomObject Object0C1 = new DungeonRoomObject(0x0C1,
			RoomDraw_ClosedChestPlatform, Both,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object0C2 = new DungeonRoomObject(0x0C2,
			RoomDraw_4x4BlocksIn4x4SuperSquare, Both,
			new ObjCategory[] { Pits, MetaLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object0C3 = new DungeonRoomObject(0x0C3,
			RoomDraw_3x3FloorIn4x4SuperSquare, Both,
			new ObjCategory[] { Pits, MetaLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object0C4 = new DungeonRoomObject(0x0C4,
			RoomDraw_4x4FloorOneIn4x4SuperSquare, Both,
			new ObjCategory[] { NoCollision, Floor },
			new byte[] { });

		public static readonly DungeonRoomObject Object0C5 = new DungeonRoomObject(0x0C5,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new ObjCategory[] { NoCollision, Floor },
			new byte[] { });

		public static readonly DungeonRoomObject Object0C6 = new DungeonRoomObject(0x0C6,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new ObjCategory[] { Pits, MetaLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object0C7 = new DungeonRoomObject(0x0C7,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new ObjCategory[] { NoCollision, Floor },
			new byte[] { });

		public static readonly DungeonRoomObject Object0C8 = new DungeonRoomObject(0x0C8,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new ObjCategory[] { NoCollision, Floor },
			new byte[] { });

		public static readonly DungeonRoomObject Object0C9 = new DungeonRoomObject(0x0C9,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new ObjCategory[] { NoCollision, Floor },
			new byte[] { });

		public static readonly DungeonRoomObject Object0CA = new DungeonRoomObject(0x0CA,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new ObjCategory[] { NoCollision, Floor },
			new byte[] { });

		public static readonly DungeonRoomObject Object0CB = new DungeonRoomObject(0x0CB,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object0CC = new DungeonRoomObject(0x0CC,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object0CD = new DungeonRoomObject(0x0CD,
			RoomDraw_MovingWallWest, Both,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object0CE = new DungeonRoomObject(0x0CE,
			RoomDraw_MovingWallEast, Both,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object0CF = new DungeonRoomObject(0x0CF,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object0D0 = new DungeonRoomObject(0x0D0,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object0D1 = new DungeonRoomObject(0x0D1,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object0D2 = new DungeonRoomObject(0x0D2,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object0D3 = new DungeonRoomObject(0x0D3,
			RoomDraw_CheckIfWallIsMoved, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object0D4 = new DungeonRoomObject(0x0D4,
			RoomDraw_CheckIfWallIsMoved, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object0D5 = new DungeonRoomObject(0x0D5,
			RoomDraw_CheckIfWallIsMoved, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object0D6 = new DungeonRoomObject(0x0D6,
			RoomDraw_CheckIfWallIsMoved, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object0D7 = new DungeonRoomObject(0x0D7,
			RoomDraw_3x3FloorIn4x4SuperSquare, Both,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object0D8 = new DungeonRoomObject(0x0D8,
			RoomDraw_WaterOverlay8x8_1to16, Both,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object0D9 = new DungeonRoomObject(0x0D9,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object0DA = new DungeonRoomObject(0x0DA,
			RoomDraw_WaterOverlay8x8_1to16, Both,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object0DB = new DungeonRoomObject(0x0DB,
			RoomDraw_4x4FloorTwoIn4x4SuperSquare, Both,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object0DC = new DungeonRoomObject(0x0DC,
			RoomDraw_OpenChestPlatform, Both,
			new ObjCategory[] { RoomDecoration, Stairs },
			new byte[] { });

		public static readonly DungeonRoomObject Object0DD = new DungeonRoomObject(0x0DD,
			RoomDraw_TableRock4x4_1to16, Both,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly DungeonRoomObject Object0DE = new DungeonRoomObject(0x0DE,
			RoomDraw_Spike2x2In4x4SuperSquare, Both,
			new ObjCategory[] { Spikes },
			new byte[] { });

		public static readonly DungeonRoomObject Object0DF = new DungeonRoomObject(0x0DF,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new ObjCategory[] { Spikes, Floor },
			new byte[] { });

		public static readonly DungeonRoomObject Object0E0 = new DungeonRoomObject(0x0E0,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new ObjCategory[] { NoCollision, Floor },
			new byte[] { });

		public static readonly DungeonRoomObject Object0E1 = new DungeonRoomObject(0x0E1,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new ObjCategory[] { NoCollision, Floor },
			new byte[] { });

		public static readonly DungeonRoomObject Object0E2 = new DungeonRoomObject(0x0E2,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new ObjCategory[] { NoCollision, Floor },
			new byte[] { });

		public static readonly DungeonRoomObject Object0E3 = new DungeonRoomObject(0x0E3,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new ObjCategory[] { NoCollision, Floor, Conveyor },
			new byte[] { });

		public static readonly DungeonRoomObject Object0E4 = new DungeonRoomObject(0x0E4,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new ObjCategory[] { NoCollision, Floor, Conveyor },
			new byte[] { });

		public static readonly DungeonRoomObject Object0E5 = new DungeonRoomObject(0x0E5,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new ObjCategory[] { NoCollision, Floor, Conveyor },
			new byte[] { });

		public static readonly DungeonRoomObject Object0E6 = new DungeonRoomObject(0x0E6,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new ObjCategory[] { NoCollision, Floor, Conveyor },
			new byte[] { });

		public static readonly DungeonRoomObject Object0E7 = new DungeonRoomObject(0x0E7,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new ObjCategory[] { NoCollision, Floor, Conveyor },
			new byte[] { });

		public static readonly DungeonRoomObject Object0E8 = new DungeonRoomObject(0x0E8,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object0E9 = new DungeonRoomObject(0x0E9,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object0EA = new DungeonRoomObject(0x0EA,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object0EB = new DungeonRoomObject(0x0EB,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object0EC = new DungeonRoomObject(0x0EC,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object0ED = new DungeonRoomObject(0x0ED,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object0EE = new DungeonRoomObject(0x0EE,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object0EF = new DungeonRoomObject(0x0EF,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object0F0 = new DungeonRoomObject(0x0F0,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object0F1 = new DungeonRoomObject(0x0F1,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object0F2 = new DungeonRoomObject(0x0F2,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object0F3 = new DungeonRoomObject(0x0F3,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object0F4 = new DungeonRoomObject(0x0F4,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object0F5 = new DungeonRoomObject(0x0F5,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object0F6 = new DungeonRoomObject(0x0F6,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object0F7 = new DungeonRoomObject(0x0F7,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });




		public static readonly DungeonRoomObject Object100 = new DungeonRoomObject(0x100,
			RoomDraw_4x4Object, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object101 = new DungeonRoomObject(0x101,
			RoomDraw_4x4Object, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object102 = new DungeonRoomObject(0x102,
			RoomDraw_4x4Object, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object103 = new DungeonRoomObject(0x103,
			RoomDraw_4x4Object, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object104 = new DungeonRoomObject(0x104,
			RoomDraw_4x4Object, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object105 = new DungeonRoomObject(0x105,
			RoomDraw_4x4Object, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object106 = new DungeonRoomObject(0x106,
			RoomDraw_4x4Object, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object107 = new DungeonRoomObject(0x107,
			RoomDraw_4x4Object, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object108 = new DungeonRoomObject(0x108,
			RoomDraw_4x4Corner_BothBG, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object109 = new DungeonRoomObject(0x109,
			RoomDraw_4x4Corner_BothBG, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object10A = new DungeonRoomObject(0x10A,
			RoomDraw_4x4Corner_BothBG, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object10B = new DungeonRoomObject(0x10B,
			RoomDraw_4x4Corner_BothBG, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object10C = new DungeonRoomObject(0x10C,
			RoomDraw_4x4Corner_BothBG, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object10D = new DungeonRoomObject(0x10D,
			RoomDraw_4x4Corner_BothBG, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object10E = new DungeonRoomObject(0x10E,
			RoomDraw_4x4Corner_BothBG, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object10F = new DungeonRoomObject(0x10F,
			RoomDraw_4x4Corner_BothBG, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object110 = new DungeonRoomObject(0x110,
			RoomDraw_WeirdCornerBottom_BothBG, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object111 = new DungeonRoomObject(0x111,
			RoomDraw_WeirdCornerBottom_BothBG, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object112 = new DungeonRoomObject(0x112,
			RoomDraw_WeirdCornerBottom_BothBG, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object113 = new DungeonRoomObject(0x113,
			RoomDraw_WeirdCornerBottom_BothBG, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object114 = new DungeonRoomObject(0x114,
			RoomDraw_WeirdCornerTop_BothBG, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object115 = new DungeonRoomObject(0x115,
			RoomDraw_WeirdCornerTop_BothBG, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object116 = new DungeonRoomObject(0x116,
			RoomDraw_WeirdCornerTop_BothBG, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object117 = new DungeonRoomObject(0x117,
			RoomDraw_WeirdCornerTop_BothBG, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object118 = new DungeonRoomObject(0x118,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object119 = new DungeonRoomObject(0x119,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object11A = new DungeonRoomObject(0x11A,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object11B = new DungeonRoomObject(0x11B,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object11C = new DungeonRoomObject(0x11C,
			RoomDraw_4x4Object, None,
			new ObjCategory[] { Collision, Pits, RoomDecoration },
			new byte[] { });

		public static readonly DungeonRoomObject Object11D = new DungeonRoomObject(0x11D,
			RoomDraw_Single2x3Pillar, None,
			new ObjCategory[] { Collision, RoomDecoration, Hookshottable },
			new byte[] { });

		public static readonly DungeonRoomObject Object11E = new DungeonRoomObject(0x11E,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { NoCollision, Pits },
			new byte[] { });

		public static readonly DungeonRoomObject Object11F = new DungeonRoomObject(0x11F,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { NoCollision, Pits },
			new byte[] { });

		public static readonly DungeonRoomObject Object120 = new DungeonRoomObject(0x120,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { Collision, RoomDecoration, Hookshottable },
			new byte[] { });

		public static readonly DungeonRoomObject Object121 = new DungeonRoomObject(0x121,
			RoomDraw_Single2x3Pillar, None,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly DungeonRoomObject Object122 = new DungeonRoomObject(0x122,
			RoomDraw_Bed4x5, None,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly DungeonRoomObject Object123 = new DungeonRoomObject(0x123,
			RoomDraw_4x3OneLayer, None,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly DungeonRoomObject Object124 = new DungeonRoomObject(0x124,
			RoomDraw_4x4Object, None,
			new ObjCategory[] { Collision, WallDecoration },
			new byte[] { });

		public static readonly DungeonRoomObject Object125 = new DungeonRoomObject(0x125,
			RoomDraw_4x4Object, None,
			new ObjCategory[] { Collision, WallDecoration },
			new byte[] { });

		public static readonly DungeonRoomObject Object126 = new DungeonRoomObject(0x126,
			RoomDraw_Single2x3Pillar, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object127 = new DungeonRoomObject(0x127,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly DungeonRoomObject Object128 = new DungeonRoomObject(0x128,
			RoomDraw_YBed4x5, None,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly DungeonRoomObject Object129 = new DungeonRoomObject(0x129,
			RoomDraw_4x4Object, None,
			new ObjCategory[] { Collision, WallDecoration },
			new byte[] { });

		public static readonly DungeonRoomObject Object12A = new DungeonRoomObject(0x12A,
			RoomDraw_PortraitOfMario, None,
			new ObjCategory[] { Collision, WallDecoration, UpperLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object12B = new DungeonRoomObject(0x12B,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object12C = new DungeonRoomObject(0x12C,
			RoomDraw_DrawRightwards3x6, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object12D = new DungeonRoomObject(0x12D,
			RoomDraw_InterRoomFatStairs, None,
			new ObjCategory[] { Stairs },
			new byte[] { },
			special: SpecialObjectType.InterroomStairs);

		public static readonly DungeonRoomObject Object12E = new DungeonRoomObject(0x12E,
			RoomDraw_InterRoomFatStairs, None,
			new ObjCategory[] { Stairs, RoomTransition },
			new byte[] { },
			special: SpecialObjectType.InterroomStairs);

		public static readonly DungeonRoomObject Object12F = new DungeonRoomObject(0x12F,
			RoomDraw_InterRoomFatStairs, None,
			new ObjCategory[] { Stairs, RoomTransition },
			new byte[] { });

		public static readonly DungeonRoomObject Object130 = new DungeonRoomObject(0x130,
			RoomDraw_AutoStairs, None,
			new ObjCategory[] { Stairs },
			new byte[] { });

		public static readonly DungeonRoomObject Object131 = new DungeonRoomObject(0x131,
			RoomDraw_AutoStairs, None,
			new ObjCategory[] { Stairs },
			new byte[] { });

		public static readonly DungeonRoomObject Object132 = new DungeonRoomObject(0x132,
			RoomDraw_AutoStairsMerged, None,
			new ObjCategory[] { Stairs },
			new byte[] { });

		public static readonly DungeonRoomObject Object133 = new DungeonRoomObject(0x133,
			RoomDraw_AutoStairsMerged, None,
			new ObjCategory[] { Stairs },
			new byte[] { });

		public static readonly DungeonRoomObject Object134 = new DungeonRoomObject(0x134,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { Collision, RoomDecoration, Hookshottable },
			new byte[] { });

		public static readonly DungeonRoomObject Object135 = new DungeonRoomObject(0x135,
			RoomDraw_WaterHopStairs_A, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object136 = new DungeonRoomObject(0x136,
			RoomDraw_WaterHopStairs_B, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object137 = new DungeonRoomObject(0x137,
			RoomDraw_DamFloodGate, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object138 = new DungeonRoomObject(0x138,
			RoomDraw_SpiralStairs, None,
			new ObjCategory[] { Stairs, RoomTransition },
			new byte[] { },
			special: SpecialObjectType.InterroomStairs);

		public static readonly DungeonRoomObject Object139 = new DungeonRoomObject(0x139,
			RoomDraw_SpiralStairs, None,
			new ObjCategory[] { Stairs, RoomTransition },
			new byte[] { },
			special: SpecialObjectType.InterroomStairs);

		public static readonly DungeonRoomObject Object13A = new DungeonRoomObject(0x13A,
			RoomDraw_SpiralStairs, None,
			new ObjCategory[] { Stairs, RoomTransition },
			new byte[] { });

		public static readonly DungeonRoomObject Object13B = new DungeonRoomObject(0x13B,
			RoomDraw_SpiralStairs, None,
			new ObjCategory[] { Stairs, RoomTransition },
			new byte[] { },
			special: SpecialObjectType.InterroomStairs);

		public static readonly DungeonRoomObject Object13C = new DungeonRoomObject(0x13C,
			RoomDraw_SanctuaryWall, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object13D = new DungeonRoomObject(0x13D,
			RoomDraw_4x3OneLayer, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object13E = new DungeonRoomObject(0x13E,
			RoomDraw_Utility6x3, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object13F = new DungeonRoomObject(0x13F,
			RoomDraw_MagicBatAltar, None,
			new ObjCategory[] { },
			new byte[] { });




		public static readonly DungeonRoomObject Object200 = new DungeonRoomObject(0x200,
			RoomDraw_EmptyWaterFace, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object201 = new DungeonRoomObject(0x201,
			RoomDraw_SpittingWaterFace, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object202 = new DungeonRoomObject(0x202,
			RoomDraw_DrenchingWaterFace, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object203 = new DungeonRoomObject(0x203,
			RoomDraw_SomariaLine, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object204 = new DungeonRoomObject(0x204,
			RoomDraw_SomariaLine, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object205 = new DungeonRoomObject(0x205,
			RoomDraw_SomariaLine, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object206 = new DungeonRoomObject(0x206,
			RoomDraw_SomariaLine, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object207 = new DungeonRoomObject(0x207,
			RoomDraw_SomariaLine, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object208 = new DungeonRoomObject(0x208,
			RoomDraw_SomariaLine, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object209 = new DungeonRoomObject(0x209,
			RoomDraw_SomariaLine, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object20A = new DungeonRoomObject(0x20A,
			RoomDraw_SomariaLine, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object20B = new DungeonRoomObject(0x20B,
			RoomDraw_SomariaLine, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object20C = new DungeonRoomObject(0x20C,
			RoomDraw_SomariaLine, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object20D = new DungeonRoomObject(0x20D,
			RoomDraw_PrisonCell, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object20E = new DungeonRoomObject(0x20E,
			RoomDraw_SomariaLine, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object20F = new DungeonRoomObject(0x20F,
			RoomDraw_SomariaLine, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object210 = new DungeonRoomObject(0x210,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object211 = new DungeonRoomObject(0x211,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object212 = new DungeonRoomObject(0x212,
			RoomDraw_RupeeFloor, None,
			new ObjCategory[] { NoCollision, Floor, Secrets },
			new byte[] { });

		public static readonly DungeonRoomObject Object213 = new DungeonRoomObject(0x213,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { Collision, WallDecoration, Hookshottable },
			new byte[] { });

		public static readonly DungeonRoomObject Object214 = new DungeonRoomObject(0x214,
			RoomDraw_4x3OneLayer, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object215 = new DungeonRoomObject(0x215,
			RoomDraw_KholdstareShell, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object216 = new DungeonRoomObject(0x216,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { Collision, PuzzlePegs, Hookshottable, Manipulable },
			new byte[] { });

		public static readonly DungeonRoomObject Object217 = new DungeonRoomObject(0x217,
			RoomDraw_PrisonCell, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object218 = new DungeonRoomObject(0x218,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object219 = new DungeonRoomObject(0x219,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { Collision, RoomDecoration, Secrets, Hookshottable },
			new byte[] { },
			special: SpecialObjectType.Chest);

		public static readonly DungeonRoomObject Object21A = new DungeonRoomObject(0x21A,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { Collision, RoomDecoration, Hookshottable },
			new byte[] { });

		public static readonly DungeonRoomObject Object21B = new DungeonRoomObject(0x21B,
			RoomDraw_AutoStairs, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object21C = new DungeonRoomObject(0x21C,
			RoomDraw_AutoStairs, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object21D = new DungeonRoomObject(0x21D,
			RoomDraw_AutoStairs, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object21E = new DungeonRoomObject(0x21E,
			RoomDraw_StraightInterroomStairs, None,
			new ObjCategory[] { Stairs, RoomTransition },
			new byte[] { });

		public static readonly DungeonRoomObject Object21F = new DungeonRoomObject(0x21F,
			RoomDraw_StraightInterroomStairs, None,
			new ObjCategory[] { Stairs, RoomTransition },
			new byte[] { });

		public static readonly DungeonRoomObject Object220 = new DungeonRoomObject(0x220,
			RoomDraw_StraightInterroomStairs, None,
			new ObjCategory[] { Stairs, RoomTransition },
			new byte[] { });

		public static readonly DungeonRoomObject Object221 = new DungeonRoomObject(0x221,
			RoomDraw_StraightInterroomStairs, None,
			new ObjCategory[] { Stairs, RoomTransition },
			new byte[] { });

		public static readonly DungeonRoomObject Object222 = new DungeonRoomObject(0x222,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object223 = new DungeonRoomObject(0x223,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object224 = new DungeonRoomObject(0x224,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object225 = new DungeonRoomObject(0x225,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object226 = new DungeonRoomObject(0x226,
			RoomDraw_StraightInterroomStairs, None,
			new ObjCategory[] { Stairs, RoomTransition },
			new byte[] { });

		public static readonly DungeonRoomObject Object227 = new DungeonRoomObject(0x227,
			RoomDraw_StraightInterroomStairs, None,
			new ObjCategory[] { Stairs, RoomTransition },
			new byte[] { });

		public static readonly DungeonRoomObject Object228 = new DungeonRoomObject(0x228,
			RoomDraw_StraightInterroomStairs, None,
			new ObjCategory[] { Stairs, RoomTransition },
			new byte[] { });

		public static readonly DungeonRoomObject Object229 = new DungeonRoomObject(0x229,
			RoomDraw_StraightInterroomStairs, None,
			new ObjCategory[] { Stairs, RoomTransition },
			new byte[] { });

		public static readonly DungeonRoomObject Object22A = new DungeonRoomObject(0x22A,
			RoomDraw_LampCones, None,
			new ObjCategory[] { LowerLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object22B = new DungeonRoomObject(0x22B,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object22C = new DungeonRoomObject(0x22C,
			RoomDraw_BigGrayRock, None,
			new ObjCategory[] { Collision, RoomDecoration, Secrets, Manipulable, Hookshottable },
			new byte[] { });

		public static readonly DungeonRoomObject Object22D = new DungeonRoomObject(0x22D,
			RoomDraw_AgahnimsAltar, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object22E = new DungeonRoomObject(0x22E,
			RoomDraw_AgahnimsWindows, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object22F = new DungeonRoomObject(0x22F,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { Collision, RoomDecoration, Secrets, Manipulable, Hookshottable },
			new byte[] { });

		public static readonly DungeonRoomObject Object230 = new DungeonRoomObject(0x230,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object231 = new DungeonRoomObject(0x231,
			RoomDraw_4x3OneLayer, None,
			new ObjCategory[] { Collision, RoomDecoration, Secrets, Hookshottable },
			new byte[] { },
			special: SpecialObjectType.BigChest);

		public static readonly DungeonRoomObject Object232 = new DungeonRoomObject(0x232,
			RoomDraw_4x3OneLayer, None,
			new ObjCategory[] { Collision, RoomDecoration, Hookshottable },
			new byte[] { });

		public static readonly DungeonRoomObject Object233 = new DungeonRoomObject(0x233,
			RoomDraw_AutoStairs, None,
			new ObjCategory[] { Stairs },
			new byte[] { });

		public static readonly DungeonRoomObject Object234 = new DungeonRoomObject(0x234,
			RoomDraw_ChestPlatformVerticalWall, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object235 = new DungeonRoomObject(0x235,
			RoomDraw_ChestPlatformVerticalWall, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object236 = new DungeonRoomObject(0x236,
			RoomDraw_DrawRightwards3x6, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object237 = new DungeonRoomObject(0x237,
			RoomDraw_DrawRightwards3x6, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object238 = new DungeonRoomObject(0x238,
			RoomDraw_ChestPlatformVerticalWall, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object239 = new DungeonRoomObject(0x239,
			RoomDraw_ChestPlatformVerticalWall, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object23A = new DungeonRoomObject(0x23A,
			RoomDraw_VerticalTurtleRockPipe, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object23B = new DungeonRoomObject(0x23B,
			RoomDraw_VerticalTurtleRockPipe, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object23C = new DungeonRoomObject(0x23C,
			RoomDraw_HorizontalTurtleRockPipe, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object23D = new DungeonRoomObject(0x23D,
			RoomDraw_HorizontalTurtleRockPipe, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object23E = new DungeonRoomObject(0x23E,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object23F = new DungeonRoomObject(0x23F,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object240 = new DungeonRoomObject(0x240,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object241 = new DungeonRoomObject(0x241,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object242 = new DungeonRoomObject(0x242,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object243 = new DungeonRoomObject(0x243,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object244 = new DungeonRoomObject(0x244,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object245 = new DungeonRoomObject(0x245,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object246 = new DungeonRoomObject(0x246,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object247 = new DungeonRoomObject(0x247,
			RoomDraw_BombableFloor, None,
			new ObjCategory[] { NoCollision, Floor, Pits, Manipulable },
			new byte[] { });

		public static readonly DungeonRoomObject Object248 = new DungeonRoomObject(0x248,
			RoomDraw_4x4Object, None,
			new ObjCategory[] { NoCollision, Floor },
			new byte[] { });

		public static readonly DungeonRoomObject Object249 = new DungeonRoomObject(0x249,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object24A = new DungeonRoomObject(0x24A,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { RoomTransition },
			new byte[] { });

		public static readonly DungeonRoomObject Object24B = new DungeonRoomObject(0x24B,
			RoomDraw_BigWallDecor, None,
			new ObjCategory[] { Collision, WallDecoration, NorthSide },
			new byte[] { });

		public static readonly DungeonRoomObject Object24C = new DungeonRoomObject(0x24C,
			RoomDraw_SmithyFurnace, None,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly DungeonRoomObject Object24D = new DungeonRoomObject(0x24D,
			RoomDraw_Utility6x3, None,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly DungeonRoomObject Object24E = new DungeonRoomObject(0x24E,
			RoomDraw_4x3OneLayer, None,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly DungeonRoomObject Object24F = new DungeonRoomObject(0x24F,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { NoCollision, Floor },
			new byte[] { });

		public static readonly DungeonRoomObject Object250 = new DungeonRoomObject(0x250,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object251 = new DungeonRoomObject(0x251,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object252 = new DungeonRoomObject(0x252,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { Collision, PuzzlePegs, Hookshottable },
			new byte[] { });

		public static readonly DungeonRoomObject Object253 = new DungeonRoomObject(0x253,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { Collision, PuzzlePegs, Hookshottable },
			new byte[] { });

		public static readonly DungeonRoomObject Object254 = new DungeonRoomObject(0x254,
			RoomDraw_FortuneTellerRoom, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object255 = new DungeonRoomObject(0x255,
			RoomDraw_Utility3x5, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object256 = new DungeonRoomObject(0x256,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly DungeonRoomObject Object257 = new DungeonRoomObject(0x257,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly DungeonRoomObject Object258 = new DungeonRoomObject(0x258,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly DungeonRoomObject Object259 = new DungeonRoomObject(0x259,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly DungeonRoomObject Object25A = new DungeonRoomObject(0x25A,
			RoomDraw_TableBowl, None,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly DungeonRoomObject Object25B = new DungeonRoomObject(0x25B,
			RoomDraw_Utility3x5, None,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly DungeonRoomObject Object25C = new DungeonRoomObject(0x25C,
			RoomDraw_HorizontalTurtleRockPipe, None,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly DungeonRoomObject Object25D = new DungeonRoomObject(0x25D,
			RoomDraw_Utility6x3, None,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly DungeonRoomObject Object25E = new DungeonRoomObject(0x25E,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly DungeonRoomObject Object25F = new DungeonRoomObject(0x25F,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly DungeonRoomObject Object260 = new DungeonRoomObject(0x260,
			RoomDraw_ArcheryGameTargetDoor, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object261 = new DungeonRoomObject(0x261,
			RoomDraw_ArcheryGameTargetDoor, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object262 = new DungeonRoomObject(0x262,
			RoomDraw_VitreousGooGraphics, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object263 = new DungeonRoomObject(0x263,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object264 = new DungeonRoomObject(0x264,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly DungeonRoomObject Object265 = new DungeonRoomObject(0x265,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly DungeonRoomObject Object266 = new DungeonRoomObject(0x266,
			RoomDraw_4x4Object, None,
			new ObjCategory[] { Pits },
			new byte[] { });

		public static readonly DungeonRoomObject Object267 = new DungeonRoomObject(0x267,
			RoomDraw_4x3OneLayer, None,
			new ObjCategory[] { Collision, WallDecoration, NorthSide, UpperLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object268 = new DungeonRoomObject(0x268,
			RoomDraw_4x3OneLayer, None,
			new ObjCategory[] { Collision, WallDecoration, SouthSide, UpperLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object269 = new DungeonRoomObject(0x269,
			RoomDraw_SolidWallDecor3x4, None,
			new ObjCategory[] { Collision, WallDecoration, WestSide, UpperLayer},
			new byte[] { });

		public static readonly DungeonRoomObject Object26A = new DungeonRoomObject(0x26A,
			RoomDraw_SolidWallDecor3x4, None,
			new ObjCategory[] { Collision, WallDecoration, EastSide, UpperLayer },
			new byte[] { });

		public static readonly DungeonRoomObject Object26B = new DungeonRoomObject(0x26B,
			RoomDraw_4x4Object, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object26C = new DungeonRoomObject(0x26C,
			RoomDraw_4x3OneLayer, None,
			new ObjCategory[] { Collision, WallDecoration, NorthSide },
			new byte[] { });

		public static readonly DungeonRoomObject Object26D = new DungeonRoomObject(0x26D,
			RoomDraw_4x3OneLayer, None,
			new ObjCategory[] { Collision, WallDecoration, SouthSide },
			new byte[] { });

		public static readonly DungeonRoomObject Object26E = new DungeonRoomObject(0x26E,
			RoomDraw_SolidWallDecor3x4, None,
			new ObjCategory[] { Collision, WallDecoration, WestSide },
			new byte[] { });

		public static readonly DungeonRoomObject Object26F = new DungeonRoomObject(0x26F,
			RoomDraw_SolidWallDecor3x4, None,
			new ObjCategory[] { Collision, WallDecoration, EastSide },
			new byte[] { });

		public static readonly DungeonRoomObject Object270 = new DungeonRoomObject(0x270,
			RoomDraw_LightBeamOnFloor, None,
			new ObjCategory[] { NoCollision, Floor },
			new byte[] { });

		public static readonly DungeonRoomObject Object271 = new DungeonRoomObject(0x271,
			RoomDraw_BigLightBeamOnFloor, None,
			new ObjCategory[] { NoCollision, Floor },
			new byte[] { });

		public static readonly DungeonRoomObject Object272 = new DungeonRoomObject(0x272,
			RoomDraw_TrinexxShell, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object273 = new DungeonRoomObject(0x273,
			RoomDraw_BG2MaskFull, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly DungeonRoomObject Object274 = new DungeonRoomObject(0x274,
			RoomDraw_FloorLight, None,
			new ObjCategory[] { Collision, WallDecoration, NorthSide, Hookshottable },
			new byte[] { });

		public static readonly DungeonRoomObject Object275 = new DungeonRoomObject(0x275,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { Collision, RoomDecoration, Secrets, Hookshottable },
			new byte[] { });

		public static readonly DungeonRoomObject Object276 = new DungeonRoomObject(0x276,
			RoomDraw_BigWallDecor, None,
			new ObjCategory[] { Collision, WallDecoration, NorthSide },
			new byte[] { });

		public static readonly DungeonRoomObject Object277 = new DungeonRoomObject(0x277,
			RoomDraw_BigWallDecor, None,
			new ObjCategory[] { Collision, WallDecoration, NorthSide },
			new byte[] { });

		public static readonly DungeonRoomObject Object278 = new DungeonRoomObject(0x278,
			RoomDraw_GanonTriforceFloorDecor, None,
			new ObjCategory[] { NoCollision, Floor },
			new byte[] { });

		public static readonly DungeonRoomObject Object279 = new DungeonRoomObject(0x279,
			RoomDraw_4x3OneLayer, None,
			new ObjCategory[] { Collision, WallDecoration, NorthSide },
			new byte[] { });

		public static readonly DungeonRoomObject Object27A = new DungeonRoomObject(0x27A,
			RoomDraw_4x4Object, None,
			new ObjCategory[] { NoCollision, Floor },
			new byte[] { });

		public static readonly DungeonRoomObject Object27B = new DungeonRoomObject(0x27B,
			RoomDraw_VitreousGooDamage, None,
			new ObjCategory[] { Spikes },
			new byte[] { });

		public static readonly DungeonRoomObject Object27C = new DungeonRoomObject(0x27C,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { NoCollision, Floor },
			new byte[] { });

		public static readonly DungeonRoomObject Object27D = new DungeonRoomObject(0x27D,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { NoCollision, Floor },
			new byte[] { });

		public static readonly DungeonRoomObject Object27E = new DungeonRoomObject(0x27E,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { NoCollision, Floor },
			new byte[] { });

		public static readonly DungeonRoomObject Object27F = new DungeonRoomObject(0x27F,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static DungeonRoomObject GetDungeonObject(ushort id)
		{
			switch (id)
			{
				case 0x000: return Object000;
				case 0x001: return Object001;
				case 0x002: return Object002;
				case 0x003: return Object003;
				case 0x004: return Object004;
				case 0x005: return Object005;
				case 0x006: return Object006;
				case 0x007: return Object007;
				case 0x008: return Object008;
				case 0x009: return Object009;
				case 0x00A: return Object00A;
				case 0x00B: return Object00B;
				case 0x00C: return Object00C;
				case 0x00D: return Object00D;
				case 0x00E: return Object00E;
				case 0x00F: return Object00F;
				case 0x010: return Object010;
				case 0x011: return Object011;
				case 0x012: return Object012;
				case 0x013: return Object013;
				case 0x014: return Object014;
				case 0x015: return Object015;
				case 0x016: return Object016;
				case 0x017: return Object017;
				case 0x018: return Object018;
				case 0x019: return Object019;
				case 0x01A: return Object01A;
				case 0x01B: return Object01B;
				case 0x01C: return Object01C;
				case 0x01D: return Object01D;
				case 0x01E: return Object01E;
				case 0x01F: return Object01F;
				case 0x020: return Object020;
				case 0x021: return Object021;
				case 0x022: return Object022;
				case 0x023: return Object023;
				case 0x024: return Object024;
				case 0x025: return Object025;
				case 0x026: return Object026;
				case 0x027: return Object027;
				case 0x028: return Object028;
				case 0x029: return Object029;
				case 0x02A: return Object02A;
				case 0x02B: return Object02B;
				case 0x02C: return Object02C;
				case 0x02D: return Object02D;
				case 0x02E: return Object02E;
				case 0x02F: return Object02F;
				case 0x030: return Object030;
				case 0x031: return Object031;
				case 0x032: return Object032;
				case 0x033: return Object033;
				case 0x034: return Object034;
				case 0x035: return Object035;
				case 0x036: return Object036;
				case 0x037: return Object037;
				case 0x038: return Object038;
				case 0x039: return Object039;
				case 0x03A: return Object03A;
				case 0x03B: return Object03B;
				case 0x03C: return Object03C;
				case 0x03D: return Object03D;
				case 0x03E: return Object03E;
				case 0x03F: return Object03F;
				case 0x040: return Object040;
				case 0x041: return Object041;
				case 0x042: return Object042;
				case 0x043: return Object043;
				case 0x044: return Object044;
				case 0x045: return Object045;
				case 0x046: return Object046;
				case 0x047: return Object047;
				case 0x048: return Object048;
				case 0x049: return Object049;
				case 0x04A: return Object04A;
				case 0x04B: return Object04B;
				case 0x04C: return Object04C;
				case 0x04D: return Object04D;
				case 0x04E: return Object04E;
				case 0x04F: return Object04F;
				case 0x050: return Object050;
				case 0x051: return Object051;
				case 0x052: return Object052;
				case 0x053: return Object053;
				case 0x054: return Object054;
				case 0x055: return Object055;
				case 0x056: return Object056;
				case 0x057: return Object057;
				case 0x058: return Object058;
				case 0x059: return Object059;
				case 0x05A: return Object05A;
				case 0x05B: return Object05B;
				case 0x05C: return Object05C;
				case 0x05D: return Object05D;
				case 0x05E: return Object05E;
				case 0x05F: return Object05F;
				case 0x060: return Object060;
				case 0x061: return Object061;
				case 0x062: return Object062;
				case 0x063: return Object063;
				case 0x064: return Object064;
				case 0x065: return Object065;
				case 0x066: return Object066;
				case 0x067: return Object067;
				case 0x068: return Object068;
				case 0x069: return Object069;
				case 0x06A: return Object06A;
				case 0x06B: return Object06B;
				case 0x06C: return Object06C;
				case 0x06D: return Object06D;
				case 0x06E: return Object06E;
				case 0x06F: return Object06F;
				case 0x070: return Object070;
				case 0x071: return Object071;
				case 0x072: return Object072;
				case 0x073: return Object073;
				case 0x074: return Object074;
				case 0x075: return Object075;
				case 0x076: return Object076;
				case 0x077: return Object077;
				case 0x078: return Object078;
				case 0x079: return Object079;
				case 0x07A: return Object07A;
				case 0x07B: return Object07B;
				case 0x07C: return Object07C;
				case 0x07D: return Object07D;
				case 0x07E: return Object07E;
				case 0x07F: return Object07F;
				case 0x080: return Object080;
				case 0x081: return Object081;
				case 0x082: return Object082;
				case 0x083: return Object083;
				case 0x084: return Object084;
				case 0x085: return Object085;
				case 0x086: return Object086;
				case 0x087: return Object087;
				case 0x088: return Object088;
				case 0x089: return Object089;
				case 0x08A: return Object08A;
				case 0x08B: return Object08B;
				case 0x08C: return Object08C;
				case 0x08D: return Object08D;
				case 0x08E: return Object08E;
				case 0x08F: return Object08F;
				case 0x090: return Object090;
				case 0x091: return Object091;
				case 0x092: return Object092;
				case 0x093: return Object093;
				case 0x094: return Object094;
				case 0x095: return Object095;
				case 0x096: return Object096;
				case 0x097: return Object097;
				case 0x098: return Object098;
				case 0x099: return Object099;
				case 0x09A: return Object09A;
				case 0x09B: return Object09B;
				case 0x09C: return Object09C;
				case 0x09D: return Object09D;
				case 0x09E: return Object09E;
				case 0x09F: return Object09F;
				case 0x0A0: return Object0A0;
				case 0x0A1: return Object0A1;
				case 0x0A2: return Object0A2;
				case 0x0A3: return Object0A3;
				case 0x0A4: return Object0A4;
				case 0x0A5: return Object0A5;
				case 0x0A6: return Object0A6;
				case 0x0A7: return Object0A7;
				case 0x0A8: return Object0A8;
				case 0x0A9: return Object0A9;
				case 0x0AA: return Object0AA;
				case 0x0AB: return Object0AB;
				case 0x0AC: return Object0AC;
				case 0x0AD: return Object0AD;
				case 0x0AE: return Object0AE;
				case 0x0AF: return Object0AF;
				case 0x0B0: return Object0B0;
				case 0x0B1: return Object0B1;
				case 0x0B2: return Object0B2;
				case 0x0B3: return Object0B3;
				case 0x0B4: return Object0B4;
				case 0x0B5: return Object0B5;
				case 0x0B6: return Object0B6;
				case 0x0B7: return Object0B7;
				case 0x0B8: return Object0B8;
				case 0x0B9: return Object0B9;
				case 0x0BA: return Object0BA;
				case 0x0BB: return Object0BB;
				case 0x0BC: return Object0BC;
				case 0x0BD: return Object0BD;
				case 0x0BE: return Object0BE;
				case 0x0BF: return Object0BF;
				case 0x0C0: return Object0C0;
				case 0x0C1: return Object0C1;
				case 0x0C2: return Object0C2;
				case 0x0C3: return Object0C3;
				case 0x0C4: return Object0C4;
				case 0x0C5: return Object0C5;
				case 0x0C6: return Object0C6;
				case 0x0C7: return Object0C7;
				case 0x0C8: return Object0C8;
				case 0x0C9: return Object0C9;
				case 0x0CA: return Object0CA;
				case 0x0CB: return Object0CB;
				case 0x0CC: return Object0CC;
				case 0x0CD: return Object0CD;
				case 0x0CE: return Object0CE;
				case 0x0CF: return Object0CF;
				case 0x0D0: return Object0D0;
				case 0x0D1: return Object0D1;
				case 0x0D2: return Object0D2;
				case 0x0D3: return Object0D3;
				case 0x0D4: return Object0D4;
				case 0x0D5: return Object0D5;
				case 0x0D6: return Object0D6;
				case 0x0D7: return Object0D7;
				case 0x0D8: return Object0D8;
				case 0x0D9: return Object0D9;
				case 0x0DA: return Object0DA;
				case 0x0DB: return Object0DB;
				case 0x0DC: return Object0DC;
				case 0x0DD: return Object0DD;
				case 0x0DE: return Object0DE;
				case 0x0DF: return Object0DF;
				case 0x0E0: return Object0E0;
				case 0x0E1: return Object0E1;
				case 0x0E2: return Object0E2;
				case 0x0E3: return Object0E3;
				case 0x0E4: return Object0E4;
				case 0x0E5: return Object0E5;
				case 0x0E6: return Object0E6;
				case 0x0E7: return Object0E7;
				case 0x0E8: return Object0E8;
				case 0x0E9: return Object0E9;
				case 0x0EA: return Object0EA;
				case 0x0EB: return Object0EB;
				case 0x0EC: return Object0EC;
				case 0x0ED: return Object0ED;
				case 0x0EE: return Object0EE;
				case 0x0EF: return Object0EF;
				case 0x0F0: return Object0F0;
				case 0x0F1: return Object0F1;
				case 0x0F2: return Object0F2;
				case 0x0F3: return Object0F3;
				case 0x0F4: return Object0F4;
				case 0x0F5: return Object0F5;
				case 0x0F6: return Object0F6;
				case 0x0F7: return Object0F7;
				case 0x100: return Object100;
				case 0x101: return Object101;
				case 0x102: return Object102;
				case 0x103: return Object103;
				case 0x104: return Object104;
				case 0x105: return Object105;
				case 0x106: return Object106;
				case 0x107: return Object107;
				case 0x108: return Object108;
				case 0x109: return Object109;
				case 0x10A: return Object10A;
				case 0x10B: return Object10B;
				case 0x10C: return Object10C;
				case 0x10D: return Object10D;
				case 0x10E: return Object10E;
				case 0x10F: return Object10F;
				case 0x110: return Object110;
				case 0x111: return Object111;
				case 0x112: return Object112;
				case 0x113: return Object113;
				case 0x114: return Object114;
				case 0x115: return Object115;
				case 0x116: return Object116;
				case 0x117: return Object117;
				case 0x118: return Object118;
				case 0x119: return Object119;
				case 0x11A: return Object11A;
				case 0x11B: return Object11B;
				case 0x11C: return Object11C;
				case 0x11D: return Object11D;
				case 0x11E: return Object11E;
				case 0x11F: return Object11F;
				case 0x120: return Object120;
				case 0x121: return Object121;
				case 0x122: return Object122;
				case 0x123: return Object123;
				case 0x124: return Object124;
				case 0x125: return Object125;
				case 0x126: return Object126;
				case 0x127: return Object127;
				case 0x128: return Object128;
				case 0x129: return Object129;
				case 0x12A: return Object12A;
				case 0x12B: return Object12B;
				case 0x12C: return Object12C;
				case 0x12D: return Object12D;
				case 0x12E: return Object12E;
				case 0x12F: return Object12F;
				case 0x130: return Object130;
				case 0x131: return Object131;
				case 0x132: return Object132;
				case 0x133: return Object133;
				case 0x134: return Object134;
				case 0x135: return Object135;
				case 0x136: return Object136;
				case 0x137: return Object137;
				case 0x138: return Object138;
				case 0x139: return Object139;
				case 0x13A: return Object13A;
				case 0x13B: return Object13B;
				case 0x13C: return Object13C;
				case 0x13D: return Object13D;
				case 0x13E: return Object13E;
				case 0x13F: return Object13F;
				case 0x200: return Object200;
				case 0x201: return Object201;
				case 0x202: return Object202;
				case 0x203: return Object203;
				case 0x204: return Object204;
				case 0x205: return Object205;
				case 0x206: return Object206;
				case 0x207: return Object207;
				case 0x208: return Object208;
				case 0x209: return Object209;
				case 0x20A: return Object20A;
				case 0x20B: return Object20B;
				case 0x20C: return Object20C;
				case 0x20D: return Object20D;
				case 0x20E: return Object20E;
				case 0x20F: return Object20F;
				case 0x210: return Object210;
				case 0x211: return Object211;
				case 0x212: return Object212;
				case 0x213: return Object213;
				case 0x214: return Object214;
				case 0x215: return Object215;
				case 0x216: return Object216;
				case 0x217: return Object217;
				case 0x218: return Object218;
				case 0x219: return Object219;
				case 0x21A: return Object21A;
				case 0x21B: return Object21B;
				case 0x21C: return Object21C;
				case 0x21D: return Object21D;
				case 0x21E: return Object21E;
				case 0x21F: return Object21F;
				case 0x220: return Object220;
				case 0x221: return Object221;
				case 0x222: return Object222;
				case 0x223: return Object223;
				case 0x224: return Object224;
				case 0x225: return Object225;
				case 0x226: return Object226;
				case 0x227: return Object227;
				case 0x228: return Object228;
				case 0x229: return Object229;
				case 0x22A: return Object22A;
				case 0x22B: return Object22B;
				case 0x22C: return Object22C;
				case 0x22D: return Object22D;
				case 0x22E: return Object22E;
				case 0x22F: return Object22F;
				case 0x230: return Object230;
				case 0x231: return Object231;
				case 0x232: return Object232;
				case 0x233: return Object233;
				case 0x234: return Object234;
				case 0x235: return Object235;
				case 0x236: return Object236;
				case 0x237: return Object237;
				case 0x238: return Object238;
				case 0x239: return Object239;
				case 0x23A: return Object23A;
				case 0x23B: return Object23B;
				case 0x23C: return Object23C;
				case 0x23D: return Object23D;
				case 0x23E: return Object23E;
				case 0x23F: return Object23F;
				case 0x240: return Object240;
				case 0x241: return Object241;
				case 0x242: return Object242;
				case 0x243: return Object243;
				case 0x244: return Object244;
				case 0x245: return Object245;
				case 0x246: return Object246;
				case 0x247: return Object247;
				case 0x248: return Object248;
				case 0x249: return Object249;
				case 0x24A: return Object24A;
				case 0x24B: return Object24B;
				case 0x24C: return Object24C;
				case 0x24D: return Object24D;
				case 0x24E: return Object24E;
				case 0x24F: return Object24F;
				case 0x250: return Object250;
				case 0x251: return Object251;
				case 0x252: return Object252;
				case 0x253: return Object253;
				case 0x254: return Object254;
				case 0x255: return Object255;
				case 0x256: return Object256;
				case 0x257: return Object257;
				case 0x258: return Object258;
				case 0x259: return Object259;
				case 0x25A: return Object25A;
				case 0x25B: return Object25B;
				case 0x25C: return Object25C;
				case 0x25D: return Object25D;
				case 0x25E: return Object25E;
				case 0x25F: return Object25F;
				case 0x260: return Object260;
				case 0x261: return Object261;
				case 0x262: return Object262;
				case 0x263: return Object263;
				case 0x264: return Object264;
				case 0x265: return Object265;
				case 0x266: return Object266;
				case 0x267: return Object267;
				case 0x268: return Object268;
				case 0x269: return Object269;
				case 0x26A: return Object26A;
				case 0x26B: return Object26B;
				case 0x26C: return Object26C;
				case 0x26D: return Object26D;
				case 0x26E: return Object26E;
				case 0x26F: return Object26F;
				case 0x270: return Object270;
				case 0x271: return Object271;
				case 0x272: return Object272;
				case 0x273: return Object273;
				case 0x274: return Object274;
				case 0x275: return Object275;
				case 0x276: return Object276;
				case 0x277: return Object277;
				case 0x278: return Object278;
				case 0x279: return Object279;
				case 0x27A: return Object27A;
				case 0x27B: return Object27B;
				case 0x27C: return Object27C;
				case 0x27D: return Object27D;
				case 0x27E: return Object27E;
				case 0x27F: return Object27F;
			}

			return null;
		}
	}
}
