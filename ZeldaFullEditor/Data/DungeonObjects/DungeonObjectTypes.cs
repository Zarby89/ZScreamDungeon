using static ZeldaFullEditor.Data.DungeonObjects.ObjCategory;
using static ZeldaFullEditor.Data.DungeonObjects.DungeonObjectSizeability;

using System.Linq;
using System.Collections.Generic;

namespace ZeldaFullEditor.Data.DungeonObjects
{
	public partial class RoomObjectType
	{
		public string VanillaName { get; }
		public DungeonObjectSet ObjectSet { get; }
		public byte ID { get; }
		public DungeonObjectSizeability Resizeability { get; }

		public DrawObject Draw { get; }
		public SpecialObjectType Specialness { get; }

		/// <summary>
		/// What tile sets this object doesn't look like garbage in
		/// </summary>
		public List<byte> PrettyTileSets { get; }

		public List<ObjCategory> Categories { get; }

		public ushort FullID { get; }

		// every tileset is beautiful
		public static byte[] AllTileSets = { 0 };
		protected RoomObjectType(ushort objectid, DrawObject drawfunc, DungeonObjectSizeability resizing, ObjCategory[] categories, byte[] gsets,
			SpecialObjectType special = SpecialObjectType.None)
		{
			string name = "PROBLEM";

			ObjectSet = (DungeonObjectSet) (objectid >> 8);
			ID = (byte) objectid;
			FullID = objectid;

			switch (ObjectSet)
			{
				case DungeonObjectSet.Subtype1:
					name = DefaultEntities.ListOfSet0RoomObjects[ID].Name;
					break;
				case DungeonObjectSet.Subtype2:
					name = DefaultEntities.ListOfSet1RoomObjects[ID].Name;
					break;
				case DungeonObjectSet.Subtype3:
					name = DefaultEntities.ListOfSet2RoomObjects[ID].Name;
					break;
			}

			VanillaName = name;
			Resizeability = resizing;
			Specialness = special;
			Categories = categories.ToList();
			PrettyTileSets = gsets.ToList();
			Draw = drawfunc;
		}

		public override string ToString()
		{
			return $"{FullID:X3} {VanillaName}";
		}


		/*
		 * All room object defaults
		 */
		public static readonly RoomObjectType Object000 = new RoomObjectType(0x000,
			RoomDraw_Rightwards2x2_1to15or32, Horizontal,
			new ObjCategory[] { Collision, Ceiling },
			new byte[] { });

		public static readonly RoomObjectType Object001 = new RoomObjectType(0x001,
			RoomDraw_Rightwards2x4_1to15or26, Horizontal,
			new ObjCategory[] { Collision, Wall, NorthSide },
			new byte[] { });

		public static readonly RoomObjectType Object002 = new RoomObjectType(0x002,
			RoomDraw_Rightwards2x4_1to15or26, Horizontal,
			new ObjCategory[] { Collision, Wall, SouthSide },
			new byte[] { });

		public static readonly RoomObjectType Object003 = new RoomObjectType(0x003,
			RoomDraw_Rightwards2x4spaced4_1to16, Horizontal,
			new ObjCategory[] { Collision, Wall, NorthSide, Ledge, LowerLayer },
			new byte[] { });

		public static readonly RoomObjectType Object004 = new RoomObjectType(0x004,
			RoomDraw_Rightwards2x4spaced4_1to16, Horizontal,
			new ObjCategory[] { Collision, Wall, SouthSide, Ledge, LowerLayer },
			new byte[] { });

		public static readonly RoomObjectType Object005 = new RoomObjectType(0x005,
			RoomDraw_Rightwards2x4spaced4_1to16_BothBG, Horizontal,
			new ObjCategory[] { Collision, WallDecoration, NorthSide },
			new byte[] { });

		public static readonly RoomObjectType Object006 = new RoomObjectType(0x006,
			RoomDraw_Rightwards2x4spaced4_1to16_BothBG, Horizontal,
			new ObjCategory[] { Collision, WallDecoration, SouthSide },
			new byte[] { });

		public static readonly RoomObjectType Object007 = new RoomObjectType(0x007,
			RoomDraw_Rightwards2x2_1to16, Horizontal,
			new ObjCategory[] { Pits, NorthSide },
			new byte[] { });

		public static readonly RoomObjectType Object008 = new RoomObjectType(0x008,
			RoomDraw_Rightwards2x2_1to16, Horizontal,
			new ObjCategory[] { Pits, SouthSide },
			new byte[] { });

		public static readonly RoomObjectType Object009 = new RoomObjectType(0x009,
			RoomDraw_DiagonalAcute_1to16, Horizontal,
			new ObjCategory[] { DiagonalCollision, Wall, NorthSide, WestSide, UpperLayer },
			new byte[] { });

		public static readonly RoomObjectType Object00A = new RoomObjectType(0x00A,
			RoomDraw_DiagonalGrave_1to16, Horizontal,
			new ObjCategory[] { DiagonalCollision, Wall, SouthSide, WestSide, UpperLayer },
			new byte[] { });

		public static readonly RoomObjectType Object00B = new RoomObjectType(0x00B,
			RoomDraw_DiagonalGrave_1to16, Horizontal,
			new ObjCategory[] { DiagonalCollision, Wall, NorthSide, EastSide, UpperLayer },
			new byte[] { });

		public static readonly RoomObjectType Object00C = new RoomObjectType(0x00C,
			RoomDraw_DiagonalAcute_1to16, Horizontal,
			new ObjCategory[] { DiagonalCollision, Wall, SouthSide, EastSide, UpperLayer },
			new byte[] { });

		public static readonly RoomObjectType Object00D = new RoomObjectType(0x00D,
			RoomDraw_DiagonalAcute_1to16, Horizontal,
			new ObjCategory[] { DiagonalCollision, Wall, NorthSide, WestSide, UpperLayer },
			new byte[] { });

		public static readonly RoomObjectType Object00E = new RoomObjectType(0x00E,
			RoomDraw_DiagonalGrave_1to16, Horizontal,
			new ObjCategory[] { DiagonalCollision, Wall, SouthSide, WestSide, UpperLayer },
			new byte[] { });

		public static readonly RoomObjectType Object00F = new RoomObjectType(0x00F,
			RoomDraw_DiagonalGrave_1to16, Horizontal,
			new ObjCategory[] { DiagonalCollision, Wall, NorthSide, EastSide, UpperLayer },
			new byte[] { });

		public static readonly RoomObjectType Object010 = new RoomObjectType(0x010,
			RoomDraw_DiagonalAcute_1to16, Horizontal,
			new ObjCategory[] { DiagonalCollision, Wall, SouthSide, EastSide, UpperLayer },
			new byte[] { });

		public static readonly RoomObjectType Object011 = new RoomObjectType(0x011,
			RoomDraw_DiagonalAcute_1to16, Horizontal,
			new ObjCategory[] { DiagonalCollision, Wall, NorthSide, WestSide, UpperLayer },
			new byte[] { });

		public static readonly RoomObjectType Object012 = new RoomObjectType(0x012,
			RoomDraw_DiagonalGrave_1to16, Horizontal,
			new ObjCategory[] { DiagonalCollision, Wall, SouthSide, WestSide, UpperLayer },
			new byte[] { });

		public static readonly RoomObjectType Object013 = new RoomObjectType(0x013,
			RoomDraw_DiagonalGrave_1to16, Horizontal,
			new ObjCategory[] { DiagonalCollision, Wall, NorthSide, EastSide, UpperLayer },
			new byte[] { });

		public static readonly RoomObjectType Object014 = new RoomObjectType(0x014,
			RoomDraw_DiagonalAcute_1to16, Horizontal,
			new ObjCategory[] { DiagonalCollision, Wall, SouthSide, EastSide, UpperLayer },
			new byte[] { });

		public static readonly RoomObjectType Object015 = new RoomObjectType(0x015,
			RoomDraw_DiagonalAcute_1to16_BothBG, Horizontal,
			new ObjCategory[] { DiagonalCollision, Wall, NorthSide, WestSide, LowerLayer },
			new byte[] { });

		public static readonly RoomObjectType Object016 = new RoomObjectType(0x016,
			RoomDraw_DiagonalGrave_1to16_BothBG, Horizontal,
			new ObjCategory[] { DiagonalCollision, Wall, SouthSide, WestSide, LowerLayer },
			new byte[] { });

		public static readonly RoomObjectType Object017 = new RoomObjectType(0x017,
			RoomDraw_DiagonalGrave_1to16_BothBG, Horizontal,
			new ObjCategory[] { DiagonalCollision, Wall, NorthSide, EastSide, LowerLayer },
			new byte[] { });

		public static readonly RoomObjectType Object018 = new RoomObjectType(0x018,
			RoomDraw_DiagonalAcute_1to16_BothBG, Horizontal,
			new ObjCategory[] { DiagonalCollision, Wall, SouthSide, EastSide, LowerLayer },
			new byte[] { });

		public static readonly RoomObjectType Object019 = new RoomObjectType(0x019,
			RoomDraw_DiagonalAcute_1to16_BothBG, Horizontal,
			new ObjCategory[] { DiagonalCollision, Wall, NorthSide, WestSide, LowerLayer },
			new byte[] { });

		public static readonly RoomObjectType Object01A = new RoomObjectType(0x01A,
			RoomDraw_DiagonalGrave_1to16_BothBG, Horizontal,
			new ObjCategory[] { DiagonalCollision, Wall, SouthSide, WestSide, LowerLayer },
			new byte[] { });

		public static readonly RoomObjectType Object01B = new RoomObjectType(0x01B,
			RoomDraw_DiagonalGrave_1to16_BothBG, Horizontal,
			new ObjCategory[] { DiagonalCollision, Wall, NorthSide, EastSide, LowerLayer },
			new byte[] { });

		public static readonly RoomObjectType Object01C = new RoomObjectType(0x01C,
			RoomDraw_DiagonalAcute_1to16_BothBG, Horizontal,
			new ObjCategory[] { DiagonalCollision, Wall, SouthSide, EastSide, LowerLayer },
			new byte[] { });

		public static readonly RoomObjectType Object01D = new RoomObjectType(0x01D,
			RoomDraw_DiagonalAcute_1to16_BothBG, Horizontal,
			new ObjCategory[] { DiagonalCollision, Wall, NorthSide, WestSide, LowerLayer },
			new byte[] { });

		public static readonly RoomObjectType Object01E = new RoomObjectType(0x01E,
			RoomDraw_DiagonalGrave_1to16_BothBG, Horizontal,
			new ObjCategory[] { DiagonalCollision, Wall, SouthSide, WestSide, LowerLayer },
			new byte[] { });

		public static readonly RoomObjectType Object01F = new RoomObjectType(0x01F,
			RoomDraw_DiagonalGrave_1to16_BothBG, Horizontal,
			new ObjCategory[] { DiagonalCollision, Wall, NorthSide, EastSide, LowerLayer },
			new byte[] { });

		public static readonly RoomObjectType Object020 = new RoomObjectType(0x020,
			RoomDraw_DiagonalAcute_1to16_BothBG, Horizontal,
			new ObjCategory[] { DiagonalCollision, Wall, SouthSide, EastSide, LowerLayer },
			new byte[] { });

		public static readonly RoomObjectType Object021 = new RoomObjectType(0x021,
			RoomDraw_Rightwards1x2_1to16_plus2, Horizontal,
			new ObjCategory[] { Stairs },
			new byte[] { });

		public static readonly RoomObjectType Object022 = new RoomObjectType(0x022,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus3, Horizontal,
			new ObjCategory[] { Collision },
			new byte[] { });

		public static readonly RoomObjectType Object023 = new RoomObjectType(0x023,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new ObjCategory[] { Pits },
			new byte[] { });

		public static readonly RoomObjectType Object024 = new RoomObjectType(0x024,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new ObjCategory[] { Pits },
			new byte[] { });

		public static readonly RoomObjectType Object025 = new RoomObjectType(0x025,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new ObjCategory[] { Pits },
			new byte[] { });

		public static readonly RoomObjectType Object026 = new RoomObjectType(0x026,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new ObjCategory[] { Pits },
			new byte[] { });

		public static readonly RoomObjectType Object027 = new RoomObjectType(0x027,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new ObjCategory[] { Pits },
			new byte[] { });

		public static readonly RoomObjectType Object028 = new RoomObjectType(0x028,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new ObjCategory[] { Pits },
			new byte[] { });

		public static readonly RoomObjectType Object029 = new RoomObjectType(0x029,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new ObjCategory[] { Pits },
			new byte[] { });

		public static readonly RoomObjectType Object02A = new RoomObjectType(0x02A,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new ObjCategory[] { Pits },
			new byte[] { });

		public static readonly RoomObjectType Object02B = new RoomObjectType(0x02B,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new ObjCategory[] { Pits },
			new byte[] { });

		public static readonly RoomObjectType Object02C = new RoomObjectType(0x02C,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new ObjCategory[] { Pits },
			new byte[] { });

		public static readonly RoomObjectType Object02D = new RoomObjectType(0x02D,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new ObjCategory[] { Pits },
			new byte[] { });

		public static readonly RoomObjectType Object02E = new RoomObjectType(0x02E,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new ObjCategory[] { Pits },
			new byte[] { });

		public static readonly RoomObjectType Object02F = new RoomObjectType(0x02F,
			RoomDraw_RightwardsWithCorners1x2_1to16_plus13, Horizontal,
			new ObjCategory[] { Collision, Ledge, Wall, NorthSide, SouthSide, UpperLayer },
			new byte[] { });

		public static readonly RoomObjectType Object030 = new RoomObjectType(0x030,
			RoomDraw_RightwardsWithCorners1x2_1to16_plus13, Horizontal,
			new ObjCategory[] { Collision, Ledge, Wall, NorthSide, SouthSide, UpperLayer },
			new byte[] { });

		public static readonly RoomObjectType Object031 = new RoomObjectType(0x031,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object032 = new RoomObjectType(0x032,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object033 = new RoomObjectType(0x033,
			RoomDraw_Rightwards4x4_1to16, Horizontal,
			new ObjCategory[] { NoCollision, Floor, RoomDecoration },
			new byte[] { });

		public static readonly RoomObjectType Object034 = new RoomObjectType(0x034,
			RoomDraw_Rightwards1x1Solid_1to16_plus3, Horizontal,
			new ObjCategory[] { NoCollision, Floor, RoomDecoration, NorthPerimeter, SouthPerimeter },
			new byte[] { });

		public static readonly RoomObjectType Object035 = new RoomObjectType(0x035,
			RoomDraw_DoorSwitcherer, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object036 = new RoomObjectType(0x036,
			RoomDraw_RightwardsDecor4x4spaced2_1to16, Horizontal,
			new ObjCategory[] { Collision, WallDecoration, NorthSide, UpperLayer },
			new byte[] { });

		public static readonly RoomObjectType Object037 = new RoomObjectType(0x037,
			RoomDraw_RightwardsDecor4x4spaced2_1to16, Horizontal,
			new ObjCategory[] { Collision, WallDecoration, SouthSide, UpperLayer },
			new byte[] { });

		public static readonly RoomObjectType Object038 = new RoomObjectType(0x038,
			RoomDraw_RightwardsStatue2x3spaced2_1to16, Horizontal,
			new ObjCategory[] { Collision, RoomDecoration, Hookshottable },
			new byte[] { });

		public static readonly RoomObjectType Object039 = new RoomObjectType(0x039,
			RoomDraw_RightwardsPillar2x4spaced4_1to16, Horizontal,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly RoomObjectType Object03A = new RoomObjectType(0x03A,
			RoomDraw_RightwardsDecor4x3spaced4_1to16, Horizontal,
			new ObjCategory[] { Collision, WallDecoration, NorthSide, UpperLayer },
			new byte[] { });

		public static readonly RoomObjectType Object03B = new RoomObjectType(0x03B,
			RoomDraw_RightwardsDecor4x3spaced4_1to16, Horizontal,
			new ObjCategory[] { Collision, WallDecoration, SouthSide, UpperLayer },
			new byte[] { });

		public static readonly RoomObjectType Object03C = new RoomObjectType(0x03C,
			RoomDraw_RightwardsDoubled2x2spaced2_1to16, Horizontal,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly RoomObjectType Object03D = new RoomObjectType(0x03D,
			RoomDraw_RightwardsPillar2x4spaced4_1to16, Horizontal,
			new ObjCategory[] { Collision, RoomDecoration, Hookshottable },
			new byte[] { });

		public static readonly RoomObjectType Object03E = new RoomObjectType(0x03E,
			RoomDraw_RightwardsDecor2x2spaced12_1to16, Horizontal,
			new ObjCategory[] { Collision, WallDecoration, NorthSide, UpperLayer },
			new byte[] { });

		public static readonly RoomObjectType Object03F = new RoomObjectType(0x03F,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new ObjCategory[] { ShallowWater },
			new byte[] { });

		public static readonly RoomObjectType Object040 = new RoomObjectType(0x040,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new ObjCategory[] { ShallowWater },
			new byte[] { });

		public static readonly RoomObjectType Object041 = new RoomObjectType(0x041,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new ObjCategory[] { ShallowWater },
			new byte[] { });

		public static readonly RoomObjectType Object042 = new RoomObjectType(0x042,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new ObjCategory[] { ShallowWater },
			new byte[] { });

		public static readonly RoomObjectType Object043 = new RoomObjectType(0x043,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new ObjCategory[] { ShallowWater },
			new byte[] { });

		public static readonly RoomObjectType Object044 = new RoomObjectType(0x044,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new ObjCategory[] { ShallowWater },
			new byte[] { });

		public static readonly RoomObjectType Object045 = new RoomObjectType(0x045,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new ObjCategory[] { ShallowWater },
			new byte[] { });

		public static readonly RoomObjectType Object046 = new RoomObjectType(0x046,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new ObjCategory[] { ShallowWater },
			new byte[] { });

		public static readonly RoomObjectType Object047 = new RoomObjectType(0x047,
			RoomDraw_Waterfall47, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object048 = new RoomObjectType(0x048,
			RoomDraw_Waterfall48, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object049 = new RoomObjectType(0x049,
			RoomDraw_RightwardsFloorTile4x2_1to16, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object04A = new RoomObjectType(0x04A,
			RoomDraw_RightwardsFloorTile4x2_1to16, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object04B = new RoomObjectType(0x04B,
			RoomDraw_RightwardsDecor2x2spaced12_1to16, Horizontal,
			new ObjCategory[] { Collision, WallDecoration, SouthSide, UpperLayer },
			new byte[] { });

		public static readonly RoomObjectType Object04C = new RoomObjectType(0x04C,
			RoomDraw_RightwardsBar4x3_1to16, Horizontal,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly RoomObjectType Object04D = new RoomObjectType(0x04D,
			RoomDraw_RightwardsShelf4x4_1to16, Horizontal,
			new ObjCategory[] { Collision, WallDecoration, NorthSide, UpperLayer },
			new byte[] { });

		public static readonly RoomObjectType Object04E = new RoomObjectType(0x04E,
			RoomDraw_RightwardsShelf4x4_1to16, Horizontal,
			new ObjCategory[] { Collision, WallDecoration, NorthSide, UpperLayer },
			new byte[] { });

		public static readonly RoomObjectType Object04F = new RoomObjectType(0x04F,
			RoomDraw_RightwardsShelf4x4_1to16, Horizontal,
			new ObjCategory[] { Collision, WallDecoration, NorthSide, UpperLayer },
			new byte[] { });

		public static readonly RoomObjectType Object050 = new RoomObjectType(0x050,
			RoomDraw_RightwardsLine1x1_1to16plus1, Horizontal,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object051 = new RoomObjectType(0x051,
			RoomDraw_RightwardsCannonHole4x3_1to16, Horizontal,
			new ObjCategory[] { Collision, WallDecoration, NorthSide },
			new byte[] { });

		public static readonly RoomObjectType Object052 = new RoomObjectType(0x052,
			RoomDraw_RightwardsCannonHole4x3_1to16, Horizontal,
			new ObjCategory[] { Collision, WallDecoration, SouthSide },
			new byte[] { });

		public static readonly RoomObjectType Object053 = new RoomObjectType(0x053,
			RoomDraw_Rightwards2x2_1to16, Horizontal,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object054 = new RoomObjectType(0x054,
			RoomDraw_Nothing, Horizontal,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object055 = new RoomObjectType(0x055,
			RoomDraw_RightwardsDecor4x2spaced8_1to16, Horizontal,
			new ObjCategory[] { Collision, WallDecoration, NorthSide, UpperLayer },
			new byte[] { });

		public static readonly RoomObjectType Object056 = new RoomObjectType(0x056,
			RoomDraw_RightwardsDecor4x2spaced8_1to16, Horizontal,
			new ObjCategory[] { Collision, WallDecoration, SouthSide, UpperLayer },
			new byte[] { });

		public static readonly RoomObjectType Object057 = new RoomObjectType(0x057,
			RoomDraw_Nothing, Horizontal,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object058 = new RoomObjectType(0x058,
			RoomDraw_Nothing, Horizontal,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object059 = new RoomObjectType(0x059,
			RoomDraw_Nothing, Horizontal,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object05A = new RoomObjectType(0x05A,
			RoomDraw_Nothing, Horizontal,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object05B = new RoomObjectType(0x05B,
			RoomDraw_RightwardsCannonHole4x3_1to16, Horizontal,
			new ObjCategory[] { Collision, WallDecoration, NorthSide },
			new byte[] { });

		public static readonly RoomObjectType Object05C = new RoomObjectType(0x05C,
			RoomDraw_RightwardsCannonHole4x3_1to16, Horizontal,
			new ObjCategory[] { Collision, WallDecoration, SouthSide },
			new byte[] { });

		public static readonly RoomObjectType Object05D = new RoomObjectType(0x05D,
			RoomDraw_RightwardsBigRail1x3_1to16plus5, Horizontal,
			new ObjCategory[] { Collision, RoomDecoration, Hookshottable },
			new byte[] { });

		public static readonly RoomObjectType Object05E = new RoomObjectType(0x05E,
			RoomDraw_RightwardsBlock2x2spaced2_1to16, Horizontal,
			new ObjCategory[] { Collision, RoomDecoration, Hookshottable },
			new byte[] { });

		public static readonly RoomObjectType Object05F = new RoomObjectType(0x05F,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus23, Horizontal,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly RoomObjectType Object060 = new RoomObjectType(0x060,
			RoomDraw_Downwards2x2_1to15or32, Horizontal,
			new ObjCategory[] { Ceiling, Collision },
			new byte[] { });

		public static readonly RoomObjectType Object061 = new RoomObjectType(0x061,
			RoomDraw_Downwards4x2_1to15or26, Horizontal,
			new ObjCategory[] { Collision, Wall, WestSide },
			new byte[] { });

		public static readonly RoomObjectType Object062 = new RoomObjectType(0x062,
			RoomDraw_Downwards4x2_1to15or26, Horizontal,
			new ObjCategory[] { Collision, Wall, EastSide },
			new byte[] { });

		public static readonly RoomObjectType Object063 = new RoomObjectType(0x063,
			RoomDraw_Downwards4x2_1to16_BothBG, Horizontal,
			new ObjCategory[] { Collision, Wall, WestSide, LowerLayer },
			new byte[] { });

		public static readonly RoomObjectType Object064 = new RoomObjectType(0x064,
			RoomDraw_Downwards4x2_1to16_BothBG, Horizontal,
			new ObjCategory[] { Collision, Wall, EastSide, LowerLayer },
			new byte[] { });

		public static readonly RoomObjectType Object065 = new RoomObjectType(0x065,
			RoomDraw_DownwardsDecor4x2spaced4_1to16, Horizontal,
			new ObjCategory[] { Collision, WallDecoration, WestSide, UpperLayer },
			new byte[] { });

		public static readonly RoomObjectType Object066 = new RoomObjectType(0x066,
			RoomDraw_DownwardsDecor4x2spaced4_1to16, Horizontal,
			new ObjCategory[] { Collision, WallDecoration, WestSide, UpperLayer },
			new byte[] { });

		public static readonly RoomObjectType Object067 = new RoomObjectType(0x067,
			RoomDraw_Downwards2x2_1to16, Horizontal,
			new ObjCategory[] { Pits, WestSide },
			new byte[] { });

		public static readonly RoomObjectType Object068 = new RoomObjectType(0x068,
			RoomDraw_Downwards2x2_1to16, Horizontal,
			new ObjCategory[] { Pits, EastSide },
			new byte[] { });

		public static readonly RoomObjectType Object069 = new RoomObjectType(0x069,
			RoomDraw_DownwardsHasEdge1x1_1to16_plus3, Horizontal,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly RoomObjectType Object06A = new RoomObjectType(0x06A,
			RoomDraw_DownwardsEdge1x1_1to16, Horizontal,
			new ObjCategory[] { Pits, WestPerimeter},
			new byte[] { });

		public static readonly RoomObjectType Object06B = new RoomObjectType(0x06B,
			RoomDraw_DownwardsEdge1x1_1to16, Horizontal,
			new ObjCategory[] { Pits, EastPerimeter },
			new byte[] { });

		public static readonly RoomObjectType Object06C = new RoomObjectType(0x06C,
			RoomDraw_DownwardsWithCorners2x1_1to16_plus12, Horizontal,
			new ObjCategory[] { Collision, WestSide, EastSide, UpperLayer },
			new byte[] { });

		public static readonly RoomObjectType Object06D = new RoomObjectType(0x06D,
			RoomDraw_DownwardsWithCorners2x1_1to16_plus12, Horizontal,
			new ObjCategory[] { Collision, WestSide, EastSide, UpperLayer },
			new byte[] { });

		public static readonly RoomObjectType Object06E = new RoomObjectType(0x06E,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object06F = new RoomObjectType(0x06F,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object070 = new RoomObjectType(0x070,
			RoomDraw_DownwardsFloor4x4_1to16, Vertical,
			new ObjCategory[] { NoCollision, Floor, RoomDecoration },
			new byte[] { });

		public static readonly RoomObjectType Object071 = new RoomObjectType(0x071,
			RoomDraw_Downwards1x1Solid_1to16_plus3, Vertical,
			new ObjCategory[] { NoCollision, Floor, RoomDecoration, WestPerimeter, EastPerimeter },
			new byte[] { });

		public static readonly RoomObjectType Object072 = new RoomObjectType(0x072,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object073 = new RoomObjectType(0x073,
			RoomDraw_DownwardsDecor4x4spaced2_1to16, Vertical,
			new ObjCategory[] { Collision, WallDecoration, WestSide, UpperLayer },
			new byte[] { });

		public static readonly RoomObjectType Object074 = new RoomObjectType(0x074,
			RoomDraw_DownwardsDecor4x4spaced2_1to16, Vertical,
			new ObjCategory[] { Collision, WallDecoration, EastSide, UpperLayer },
			new byte[] { });

		public static readonly RoomObjectType Object075 = new RoomObjectType(0x075,
			RoomDraw_DownwardsPillar2x4spaced2_1to16, Vertical,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly RoomObjectType Object076 = new RoomObjectType(0x076,
			RoomDraw_DownwardsDecor4x4spaced4_1to16, Vertical,
			new ObjCategory[] { Collision, WallDecoration, WestSide, UpperLayer },
			new byte[] { });

		public static readonly RoomObjectType Object077 = new RoomObjectType(0x077,
			RoomDraw_DownwardsDecor4x4spaced4_1to16, Vertical,
			new ObjCategory[] { Collision, WallDecoration, EastSide, UpperLayer },
			new byte[] { });

		public static readonly RoomObjectType Object078 = new RoomObjectType(0x078,
			RoomDraw_DownwardsDecor2x2spaced12_1to16, Vertical,
			new ObjCategory[] { Collision, WallDecoration, WestSide, UpperLayer },
			new byte[] { });

		public static readonly RoomObjectType Object079 = new RoomObjectType(0x079,
			RoomDraw_DownwardsEdge1x1_1to16, Vertical,
			new ObjCategory[] { ShallowWater, Floor },
			new byte[] { });

		public static readonly RoomObjectType Object07A = new RoomObjectType(0x07A,
			RoomDraw_DownwardsEdge1x1_1to16, Vertical,
			new ObjCategory[] { ShallowWater, Floor },
			new byte[] { });

		public static readonly RoomObjectType Object07B = new RoomObjectType(0x07B,
			RoomDraw_DownwardsDecor2x2spaced12_1to16, Vertical,
			new ObjCategory[] { Collision, WallDecoration, EastSide, UpperLayer },
			new byte[] { });

		public static readonly RoomObjectType Object07C = new RoomObjectType(0x07C,
			RoomDraw_DownwardsLine1x1_1to16plus1, Vertical,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object07D = new RoomObjectType(0x07D,
			RoomDraw_Downwards2x2_1to16, Vertical,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object07E = new RoomObjectType(0x07E,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object07F = new RoomObjectType(0x07F,
			RoomDraw_DownwardsDecor2x4spaced8_1to16, Vertical,
			new ObjCategory[] { Collision, WallDecoration, WestSide, UpperLayer },
			new byte[] { });

		public static readonly RoomObjectType Object080 = new RoomObjectType(0x080,
			RoomDraw_DownwardsDecor2x4spaced8_1to16, Vertical,
			new ObjCategory[] { Collision, WallDecoration, EastSide, UpperLayer },
			new byte[] { });

		public static readonly RoomObjectType Object081 = new RoomObjectType(0x081,
			RoomDraw_DownwardsDecor3x4spaced2_1to16, Vertical,
			new ObjCategory[] { Collision, WallDecoration, WestSide, UpperLayer },
			new byte[] { });

		public static readonly RoomObjectType Object082 = new RoomObjectType(0x082,
			RoomDraw_DownwardsDecor3x4spaced2_1to16, Vertical,
			new ObjCategory[] { Collision, WallDecoration, EastSide, UpperLayer },
			new byte[] { });

		public static readonly RoomObjectType Object083 = new RoomObjectType(0x083,
			RoomDraw_DownwardsDecor3x4spaced2_1to16, Vertical,
			new ObjCategory[] { Collision, WallDecoration, WestSide, UpperLayer },
			new byte[] { });

		public static readonly RoomObjectType Object084 = new RoomObjectType(0x084,
			RoomDraw_DownwardsDecor3x4spaced2_1to16, Vertical,
			new ObjCategory[] { Collision, WallDecoration, EastSide, UpperLayer },
			new byte[] { });

		public static readonly RoomObjectType Object085 = new RoomObjectType(0x085,
			RoomDraw_DownwardsCannonHole3x4_1to16, Vertical,
			new ObjCategory[] { Collision, WallDecoration, WestSide, UpperLayer },
			new byte[] { });

		public static readonly RoomObjectType Object086 = new RoomObjectType(0x086,
			RoomDraw_DownwardsCannonHole3x4_1to16, Vertical,
			new ObjCategory[] { Collision, WallDecoration, EastSide, UpperLayer },
			new byte[] { });

		public static readonly RoomObjectType Object087 = new RoomObjectType(0x087,
			RoomDraw_DownwardsPillar2x4spaced2_1to16, Vertical,
			new ObjCategory[] { Collision, RoomDecoration, Hookshottable },
			new byte[] { });

		public static readonly RoomObjectType Object088 = new RoomObjectType(0x088,
			RoomDraw_DownwardsBigRail3x1_1to16plus5, Vertical,
			new ObjCategory[] { Collision, RoomDecoration, Hookshottable },
			new byte[] { });

		public static readonly RoomObjectType Object089 = new RoomObjectType(0x089,
			RoomDraw_DownwardsBlock2x2spaced2_1to16, Vertical,
			new ObjCategory[] { Collision, RoomDecoration, Hookshottable },
			new byte[] { });

		public static readonly RoomObjectType Object08A = new RoomObjectType(0x08A,
			RoomDraw_DownwardsHasEdge1x1_1to16_plus23, Vertical,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly RoomObjectType Object08B = new RoomObjectType(0x08B,
			RoomDraw_DownwardsEdge1x1_1to16plus7, Vertical,
			new ObjCategory[] { Ledge, UpperLayer, WestPerimeter },
			new byte[] { });

		public static readonly RoomObjectType Object08C = new RoomObjectType(0x08C,
			RoomDraw_DownwardsEdge1x1_1to16plus7, Vertical,
			new ObjCategory[] { Ledge, UpperLayer, EastPerimeter },
			new byte[] { });

		public static readonly RoomObjectType Object08D = new RoomObjectType(0x08D,
			RoomDraw_DownwardsEdge1x1_1to16, Vertical,
			new ObjCategory[] { NoCollision, Floor, RoomDecoration, WestPerimeter },
			new byte[] { });

		public static readonly RoomObjectType Object08E = new RoomObjectType(0x08E,
			RoomDraw_DownwardsEdge1x1_1to16, Vertical,
			new ObjCategory[] { NoCollision, Floor, RoomDecoration, EastPerimeter },
			new byte[] { });

		public static readonly RoomObjectType Object08F = new RoomObjectType(0x08F,
			RoomDraw_DownwardsBar2x5_1to16, Vertical,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly RoomObjectType Object090 = new RoomObjectType(0x090,
			RoomDraw_Downwards4x2_1to15or26, Vertical,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object091 = new RoomObjectType(0x091,
			RoomDraw_Downwards4x2_1to15or26, Vertical,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object092 = new RoomObjectType(0x092,
			RoomDraw_Downwards2x2_1to15or32, Vertical,
			new ObjCategory[] { Collision, PuzzlePegs, Hookshottable },
			new byte[] { });

		public static readonly RoomObjectType Object093 = new RoomObjectType(0x093,
			RoomDraw_Downwards2x2_1to15or32, Vertical,
			new ObjCategory[] { Collision, PuzzlePegs, Hookshottable },
			new byte[] { });

		public static readonly RoomObjectType Object094 = new RoomObjectType(0x094,
			RoomDraw_DownwardsFloor4x4_1to16, Vertical,
			new ObjCategory[] { NoCollision, Floor },
			new byte[] { });

		public static readonly RoomObjectType Object095 = new RoomObjectType(0x095,
			RoomDraw_Downwards2x2_1to16, Vertical,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly RoomObjectType Object096 = new RoomObjectType(0x096,
			RoomDraw_Downwards2x2_1to16, Vertical,
			new ObjCategory[] { Collision, PuzzlePegs, Hookshottable, Manipulable },
			new byte[] { });

		public static readonly RoomObjectType Object097 = new RoomObjectType(0x097,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object098 = new RoomObjectType(0x098,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object099 = new RoomObjectType(0x099,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object09A = new RoomObjectType(0x09A,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object09B = new RoomObjectType(0x09B,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object09C = new RoomObjectType(0x09C,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object09D = new RoomObjectType(0x09D,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object09E = new RoomObjectType(0x09E,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object09F = new RoomObjectType(0x09F,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object0A0 = new RoomObjectType(0x0A0,
			RoomDraw_DiagonalCeilingTopLeft, Both,
			new ObjCategory[] { Collision, Ceiling },
			new byte[] { });

		public static readonly RoomObjectType Object0A1 = new RoomObjectType(0x0A1,
			RoomDraw_DiagonalCeilingBottomLeft, Both,
			new ObjCategory[] { Collision, Ceiling },
			new byte[] { });

		public static readonly RoomObjectType Object0A2 = new RoomObjectType(0x0A2,
			RoomDraw_DiagonalCeilingTopRight, Both,
			new ObjCategory[] { Collision, Ceiling },
			new byte[] { });

		public static readonly RoomObjectType Object0A3 = new RoomObjectType(0x0A3,
			RoomDraw_DiagonalCeilingBottomRight, Both,
			new ObjCategory[] { Collision, Ceiling },
			new byte[] { });

		public static readonly RoomObjectType Object0A4 = new RoomObjectType(0x0A4,
			RoomDraw_BigHole4x4_1to16, Both,
			new ObjCategory[] { Pits },
			new byte[] { });

		public static readonly RoomObjectType Object0A5 = new RoomObjectType(0x0A5,
			RoomDraw_DiagonalCeilingTopLeft, Both,
			new ObjCategory[] { Collision, Ceiling },
			new byte[] { });

		public static readonly RoomObjectType Object0A6 = new RoomObjectType(0x0A6,
			RoomDraw_DiagonalCeilingBottomLeft, Both,
			new ObjCategory[] { Collision, Ceiling },
			new byte[] { });

		public static readonly RoomObjectType Object0A7 = new RoomObjectType(0x0A7,
			RoomDraw_DiagonalCeilingTopRight, Both,
			new ObjCategory[] { Collision, Ceiling },
			new byte[] { });

		public static readonly RoomObjectType Object0A8 = new RoomObjectType(0x0A8,
			RoomDraw_DiagonalCeilingBottomRight, Both,
			new ObjCategory[] { Collision, Ceiling },
			new byte[] { });

		public static readonly RoomObjectType Object0A9 = new RoomObjectType(0x0A9,
			RoomDraw_DiagonalCeilingTopLeft, Both,
			new ObjCategory[] { Collision, Ceiling },
			new byte[] { });

		public static readonly RoomObjectType Object0AA = new RoomObjectType(0x0AA,
			RoomDraw_DiagonalCeilingBottomLeft, Both,
			new ObjCategory[] { Collision, Ceiling },
			new byte[] { });

		public static readonly RoomObjectType Object0AB = new RoomObjectType(0x0AB,
			RoomDraw_DiagonalCeilingTopRight, Both,
			new ObjCategory[] { Collision, Ceiling },
			new byte[] { });

		public static readonly RoomObjectType Object0AC = new RoomObjectType(0x0AC,
			RoomDraw_DiagonalCeilingBottomRight, Both,
			new ObjCategory[] { Collision, Ceiling },
			new byte[] { });

		public static readonly RoomObjectType Object0AD = new RoomObjectType(0x0AD,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object0AE = new RoomObjectType(0x0AE,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object0AF = new RoomObjectType(0x0AF,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object0B0 = new RoomObjectType(0x0B0,
			RoomDraw_RightwardsEdge1x1_1to16plus7, Horizontal,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object0B1 = new RoomObjectType(0x0B1,
			RoomDraw_RightwardsEdge1x1_1to16plus7, Horizontal,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object0B2 = new RoomObjectType(0x0B2,
			RoomDraw_Rightwards4x4_1to16, Horizontal,
			new ObjCategory[] { NoCollision, Floor },
			new byte[] { });

		public static readonly RoomObjectType Object0B3 = new RoomObjectType(0x0B3,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new ObjCategory[] { NoCollision, Floor, NorthPerimeter },
			new byte[] { });

		public static readonly RoomObjectType Object0B4 = new RoomObjectType(0x0B4,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new ObjCategory[] { NoCollision, Floor, SouthPerimeter },
			new byte[] { });

		public static readonly RoomObjectType Object0B5 = new RoomObjectType(0x0B5,
			RoomDraw_Weird2x4_1_to_16, Horizontal,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object0B6 = new RoomObjectType(0x0B6,
			RoomDraw_Rightwards2x4_1to15or26, Horizontal,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object0B7 = new RoomObjectType(0x0B7,
			RoomDraw_Rightwards2x4_1to15or26, Horizontal,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object0B8 = new RoomObjectType(0x0B8,
			RoomDraw_Rightwards2x2_1to15or32, Horizontal,
			new ObjCategory[] { Collision, PuzzlePegs, Hookshottable },
			new byte[] { });

		public static readonly RoomObjectType Object0B9 = new RoomObjectType(0x0B9,
			RoomDraw_Rightwards2x2_1to15or32, Horizontal,
			new ObjCategory[] { Collision, PuzzlePegs, Hookshottable },
			new byte[] { });

		public static readonly RoomObjectType Object0BA = new RoomObjectType(0x0BA,
			RoomDraw_Rightwards4x4_1to16, Horizontal,
			new ObjCategory[] { NoCollision, Floor },
			new byte[] { });

		public static readonly RoomObjectType Object0BB = new RoomObjectType(0x0BB,
			RoomDraw_RightwardsBlock2x2spaced2_1to16, Horizontal,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object0BC = new RoomObjectType(0x0BC,
			RoomDraw_RightwardsFakePots2x2_1to16, Horizontal,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly RoomObjectType Object0BD = new RoomObjectType(0x0BD,
			RoomDraw_RightwardsHammerPegs2x2_1to16, Horizontal,
			new ObjCategory[] { Collision, PuzzlePegs, Hookshottable, Manipulable },
			new byte[] { });

		public static readonly RoomObjectType Object0BE = new RoomObjectType(0x0BE,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object0BF = new RoomObjectType(0x0BF,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object0C0 = new RoomObjectType(0x0C0,
			RoomDraw_4x4BlocksIn4x4SuperSquare, Both,
			new ObjCategory[] { Collision, Ceiling },
			new byte[] { });

		public static readonly RoomObjectType Object0C1 = new RoomObjectType(0x0C1,
			RoomDraw_ClosedChestPlatform, Both,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object0C2 = new RoomObjectType(0x0C2,
			RoomDraw_4x4BlocksIn4x4SuperSquare, Both,
			new ObjCategory[] { Pits, MetaLayer },
			new byte[] { });

		public static readonly RoomObjectType Object0C3 = new RoomObjectType(0x0C3,
			RoomDraw_3x3FloorIn4x4SuperSquare, Both,
			new ObjCategory[] { Pits, MetaLayer },
			new byte[] { });

		public static readonly RoomObjectType Object0C4 = new RoomObjectType(0x0C4,
			RoomDraw_4x4FloorOneIn4x4SuperSquare, Both,
			new ObjCategory[] { NoCollision, Floor },
			new byte[] { });

		public static readonly RoomObjectType Object0C5 = new RoomObjectType(0x0C5,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new ObjCategory[] { NoCollision, Floor },
			new byte[] { });

		public static readonly RoomObjectType Object0C6 = new RoomObjectType(0x0C6,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new ObjCategory[] { Pits, MetaLayer },
			new byte[] { });

		public static readonly RoomObjectType Object0C7 = new RoomObjectType(0x0C7,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new ObjCategory[] { NoCollision, Floor },
			new byte[] { });

		public static readonly RoomObjectType Object0C8 = new RoomObjectType(0x0C8,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new ObjCategory[] { NoCollision, Floor },
			new byte[] { });

		public static readonly RoomObjectType Object0C9 = new RoomObjectType(0x0C9,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new ObjCategory[] { NoCollision, Floor },
			new byte[] { });

		public static readonly RoomObjectType Object0CA = new RoomObjectType(0x0CA,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new ObjCategory[] { NoCollision, Floor },
			new byte[] { });

		public static readonly RoomObjectType Object0CB = new RoomObjectType(0x0CB,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object0CC = new RoomObjectType(0x0CC,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object0CD = new RoomObjectType(0x0CD,
			RoomDraw_MovingWallWest, Both,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object0CE = new RoomObjectType(0x0CE,
			RoomDraw_MovingWallEast, Both,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object0CF = new RoomObjectType(0x0CF,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object0D0 = new RoomObjectType(0x0D0,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object0D1 = new RoomObjectType(0x0D1,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object0D2 = new RoomObjectType(0x0D2,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object0D3 = new RoomObjectType(0x0D3,
			RoomDraw_CheckIfWallIsMoved, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object0D4 = new RoomObjectType(0x0D4,
			RoomDraw_CheckIfWallIsMoved, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object0D5 = new RoomObjectType(0x0D5,
			RoomDraw_CheckIfWallIsMoved, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object0D6 = new RoomObjectType(0x0D6,
			RoomDraw_CheckIfWallIsMoved, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object0D7 = new RoomObjectType(0x0D7,
			RoomDraw_3x3FloorIn4x4SuperSquare, Both,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object0D8 = new RoomObjectType(0x0D8,
			RoomDraw_WaterOverlay8x8_1to16, Both,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object0D9 = new RoomObjectType(0x0D9,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object0DA = new RoomObjectType(0x0DA,
			RoomDraw_WaterOverlay8x8_1to16, Both,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object0DB = new RoomObjectType(0x0DB,
			RoomDraw_4x4FloorTwoIn4x4SuperSquare, Both,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object0DC = new RoomObjectType(0x0DC,
			RoomDraw_OpenChestPlatform, Both,
			new ObjCategory[] { RoomDecoration, Stairs },
			new byte[] { });

		public static readonly RoomObjectType Object0DD = new RoomObjectType(0x0DD,
			RoomDraw_TableRock4x4_1to16, Both,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly RoomObjectType Object0DE = new RoomObjectType(0x0DE,
			RoomDraw_Spike2x2In4x4SuperSquare, Both,
			new ObjCategory[] { Spikes },
			new byte[] { });

		public static readonly RoomObjectType Object0DF = new RoomObjectType(0x0DF,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new ObjCategory[] { Spikes, Floor },
			new byte[] { });

		public static readonly RoomObjectType Object0E0 = new RoomObjectType(0x0E0,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new ObjCategory[] { NoCollision, Floor },
			new byte[] { });

		public static readonly RoomObjectType Object0E1 = new RoomObjectType(0x0E1,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new ObjCategory[] { NoCollision, Floor },
			new byte[] { });

		public static readonly RoomObjectType Object0E2 = new RoomObjectType(0x0E2,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new ObjCategory[] { NoCollision, Floor },
			new byte[] { });

		public static readonly RoomObjectType Object0E3 = new RoomObjectType(0x0E3,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new ObjCategory[] { NoCollision, Floor, Conveyor },
			new byte[] { });

		public static readonly RoomObjectType Object0E4 = new RoomObjectType(0x0E4,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new ObjCategory[] { NoCollision, Floor, Conveyor },
			new byte[] { });

		public static readonly RoomObjectType Object0E5 = new RoomObjectType(0x0E5,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new ObjCategory[] { NoCollision, Floor, Conveyor },
			new byte[] { });

		public static readonly RoomObjectType Object0E6 = new RoomObjectType(0x0E6,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new ObjCategory[] { NoCollision, Floor, Conveyor },
			new byte[] { });

		public static readonly RoomObjectType Object0E7 = new RoomObjectType(0x0E7,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new ObjCategory[] { NoCollision, Floor, Conveyor },
			new byte[] { });

		public static readonly RoomObjectType Object0E8 = new RoomObjectType(0x0E8,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object0E9 = new RoomObjectType(0x0E9,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object0EA = new RoomObjectType(0x0EA,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object0EB = new RoomObjectType(0x0EB,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object0EC = new RoomObjectType(0x0EC,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object0ED = new RoomObjectType(0x0ED,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object0EE = new RoomObjectType(0x0EE,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object0EF = new RoomObjectType(0x0EF,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object0F0 = new RoomObjectType(0x0F0,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object0F1 = new RoomObjectType(0x0F1,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object0F2 = new RoomObjectType(0x0F2,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object0F3 = new RoomObjectType(0x0F3,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object0F4 = new RoomObjectType(0x0F4,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object0F5 = new RoomObjectType(0x0F5,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object0F6 = new RoomObjectType(0x0F6,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object0F7 = new RoomObjectType(0x0F7,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });




		public static readonly RoomObjectType Object100 = new RoomObjectType(0x100,
			RoomDraw_4x4Object, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object101 = new RoomObjectType(0x101,
			RoomDraw_4x4Object, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object102 = new RoomObjectType(0x102,
			RoomDraw_4x4Object, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object103 = new RoomObjectType(0x103,
			RoomDraw_4x4Object, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object104 = new RoomObjectType(0x104,
			RoomDraw_4x4Object, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object105 = new RoomObjectType(0x105,
			RoomDraw_4x4Object, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object106 = new RoomObjectType(0x106,
			RoomDraw_4x4Object, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object107 = new RoomObjectType(0x107,
			RoomDraw_4x4Object, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object108 = new RoomObjectType(0x108,
			RoomDraw_4x4Corner_BothBG, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object109 = new RoomObjectType(0x109,
			RoomDraw_4x4Corner_BothBG, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object10A = new RoomObjectType(0x10A,
			RoomDraw_4x4Corner_BothBG, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object10B = new RoomObjectType(0x10B,
			RoomDraw_4x4Corner_BothBG, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object10C = new RoomObjectType(0x10C,
			RoomDraw_4x4Corner_BothBG, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object10D = new RoomObjectType(0x10D,
			RoomDraw_4x4Corner_BothBG, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object10E = new RoomObjectType(0x10E,
			RoomDraw_4x4Corner_BothBG, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object10F = new RoomObjectType(0x10F,
			RoomDraw_4x4Corner_BothBG, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object110 = new RoomObjectType(0x110,
			RoomDraw_WeirdCornerBottom_BothBG, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object111 = new RoomObjectType(0x111,
			RoomDraw_WeirdCornerBottom_BothBG, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object112 = new RoomObjectType(0x112,
			RoomDraw_WeirdCornerBottom_BothBG, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object113 = new RoomObjectType(0x113,
			RoomDraw_WeirdCornerBottom_BothBG, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object114 = new RoomObjectType(0x114,
			RoomDraw_WeirdCornerTop_BothBG, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object115 = new RoomObjectType(0x115,
			RoomDraw_WeirdCornerTop_BothBG, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object116 = new RoomObjectType(0x116,
			RoomDraw_WeirdCornerTop_BothBG, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object117 = new RoomObjectType(0x117,
			RoomDraw_WeirdCornerTop_BothBG, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object118 = new RoomObjectType(0x118,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object119 = new RoomObjectType(0x119,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object11A = new RoomObjectType(0x11A,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object11B = new RoomObjectType(0x11B,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object11C = new RoomObjectType(0x11C,
			RoomDraw_4x4Object, None,
			new ObjCategory[] { Collision, Pits, RoomDecoration },
			new byte[] { });

		public static readonly RoomObjectType Object11D = new RoomObjectType(0x11D,
			RoomDraw_Single2x3Pillar, None,
			new ObjCategory[] { Collision, RoomDecoration, Hookshottable },
			new byte[] { });

		public static readonly RoomObjectType Object11E = new RoomObjectType(0x11E,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { NoCollision, Pits },
			new byte[] { });

		public static readonly RoomObjectType Object11F = new RoomObjectType(0x11F,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { NoCollision, Pits },
			new byte[] { });

		public static readonly RoomObjectType Object120 = new RoomObjectType(0x120,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { Collision, RoomDecoration, Hookshottable },
			new byte[] { });

		public static readonly RoomObjectType Object121 = new RoomObjectType(0x121,
			RoomDraw_Single2x3Pillar, None,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly RoomObjectType Object122 = new RoomObjectType(0x122,
			RoomDraw_Bed4x5, None,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly RoomObjectType Object123 = new RoomObjectType(0x123,
			RoomDraw_4x3OneLayer, None,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly RoomObjectType Object124 = new RoomObjectType(0x124,
			RoomDraw_4x4Object, None,
			new ObjCategory[] { Collision, WallDecoration },
			new byte[] { });

		public static readonly RoomObjectType Object125 = new RoomObjectType(0x125,
			RoomDraw_4x4Object, None,
			new ObjCategory[] { Collision, WallDecoration },
			new byte[] { });

		public static readonly RoomObjectType Object126 = new RoomObjectType(0x126,
			RoomDraw_Single2x3Pillar, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object127 = new RoomObjectType(0x127,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly RoomObjectType Object128 = new RoomObjectType(0x128,
			RoomDraw_YBed4x5, None,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly RoomObjectType Object129 = new RoomObjectType(0x129,
			RoomDraw_4x4Object, None,
			new ObjCategory[] { Collision, WallDecoration },
			new byte[] { });

		public static readonly RoomObjectType Object12A = new RoomObjectType(0x12A,
			RoomDraw_PortraitOfMario, None,
			new ObjCategory[] { Collision, WallDecoration, UpperLayer },
			new byte[] { });

		public static readonly RoomObjectType Object12B = new RoomObjectType(0x12B,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object12C = new RoomObjectType(0x12C,
			RoomDraw_DrawRightwards3x6, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object12D = new RoomObjectType(0x12D,
			RoomDraw_InterRoomFatStairs, None,
			new ObjCategory[] { Stairs },
			new byte[] { },
			special: SpecialObjectType.InterroomStairs);

		public static readonly RoomObjectType Object12E = new RoomObjectType(0x12E,
			RoomDraw_InterRoomFatStairs, None,
			new ObjCategory[] { Stairs, RoomTransition },
			new byte[] { },
			special: SpecialObjectType.InterroomStairs);

		public static readonly RoomObjectType Object12F = new RoomObjectType(0x12F,
			RoomDraw_InterRoomFatStairs, None,
			new ObjCategory[] { Stairs, RoomTransition },
			new byte[] { });

		public static readonly RoomObjectType Object130 = new RoomObjectType(0x130,
			RoomDraw_AutoStairs, None,
			new ObjCategory[] { Stairs },
			new byte[] { });

		public static readonly RoomObjectType Object131 = new RoomObjectType(0x131,
			RoomDraw_AutoStairs, None,
			new ObjCategory[] { Stairs },
			new byte[] { });

		public static readonly RoomObjectType Object132 = new RoomObjectType(0x132,
			RoomDraw_AutoStairsMerged, None,
			new ObjCategory[] { Stairs },
			new byte[] { });

		public static readonly RoomObjectType Object133 = new RoomObjectType(0x133,
			RoomDraw_AutoStairsMerged, None,
			new ObjCategory[] { Stairs },
			new byte[] { });

		public static readonly RoomObjectType Object134 = new RoomObjectType(0x134,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { Collision, RoomDecoration, Hookshottable },
			new byte[] { });

		public static readonly RoomObjectType Object135 = new RoomObjectType(0x135,
			RoomDraw_WaterHopStairs_A, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object136 = new RoomObjectType(0x136,
			RoomDraw_WaterHopStairs_B, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object137 = new RoomObjectType(0x137,
			RoomDraw_DamFloodGate, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object138 = new RoomObjectType(0x138,
			RoomDraw_SpiralStairs, None,
			new ObjCategory[] { Stairs, RoomTransition },
			new byte[] { },
			special: SpecialObjectType.InterroomStairs);

		public static readonly RoomObjectType Object139 = new RoomObjectType(0x139,
			RoomDraw_SpiralStairs, None,
			new ObjCategory[] { Stairs, RoomTransition },
			new byte[] { },
			special: SpecialObjectType.InterroomStairs);

		public static readonly RoomObjectType Object13A = new RoomObjectType(0x13A,
			RoomDraw_SpiralStairs, None,
			new ObjCategory[] { Stairs, RoomTransition },
			new byte[] { });

		public static readonly RoomObjectType Object13B = new RoomObjectType(0x13B,
			RoomDraw_SpiralStairs, None,
			new ObjCategory[] { Stairs, RoomTransition },
			new byte[] { },
			special: SpecialObjectType.InterroomStairs);

		public static readonly RoomObjectType Object13C = new RoomObjectType(0x13C,
			RoomDraw_SanctuaryWall, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object13D = new RoomObjectType(0x13D,
			RoomDraw_4x3OneLayer, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object13E = new RoomObjectType(0x13E,
			RoomDraw_Utility6x3, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object13F = new RoomObjectType(0x13F,
			RoomDraw_MagicBatAltar, None,
			new ObjCategory[] { },
			new byte[] { });




		public static readonly RoomObjectType Object200 = new RoomObjectType(0x200,
			RoomDraw_EmptyWaterFace, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object201 = new RoomObjectType(0x201,
			RoomDraw_SpittingWaterFace, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object202 = new RoomObjectType(0x202,
			RoomDraw_DrenchingWaterFace, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object203 = new RoomObjectType(0x203,
			RoomDraw_SomariaLine, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object204 = new RoomObjectType(0x204,
			RoomDraw_SomariaLine, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object205 = new RoomObjectType(0x205,
			RoomDraw_SomariaLine, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object206 = new RoomObjectType(0x206,
			RoomDraw_SomariaLine, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object207 = new RoomObjectType(0x207,
			RoomDraw_SomariaLine, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object208 = new RoomObjectType(0x208,
			RoomDraw_SomariaLine, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object209 = new RoomObjectType(0x209,
			RoomDraw_SomariaLine, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object20A = new RoomObjectType(0x20A,
			RoomDraw_SomariaLine, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object20B = new RoomObjectType(0x20B,
			RoomDraw_SomariaLine, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object20C = new RoomObjectType(0x20C,
			RoomDraw_SomariaLine, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object20D = new RoomObjectType(0x20D,
			RoomDraw_PrisonCell, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object20E = new RoomObjectType(0x20E,
			RoomDraw_SomariaLine, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object20F = new RoomObjectType(0x20F,
			RoomDraw_SomariaLine, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object210 = new RoomObjectType(0x210,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object211 = new RoomObjectType(0x211,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object212 = new RoomObjectType(0x212,
			RoomDraw_RupeeFloor, None,
			new ObjCategory[] { NoCollision, Floor, Secrets },
			new byte[] { });

		public static readonly RoomObjectType Object213 = new RoomObjectType(0x213,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { Collision, WallDecoration, Hookshottable },
			new byte[] { });

		public static readonly RoomObjectType Object214 = new RoomObjectType(0x214,
			RoomDraw_4x3OneLayer, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object215 = new RoomObjectType(0x215,
			RoomDraw_KholdstareShell, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object216 = new RoomObjectType(0x216,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { Collision, PuzzlePegs, Hookshottable, Manipulable },
			new byte[] { });

		public static readonly RoomObjectType Object217 = new RoomObjectType(0x217,
			RoomDraw_PrisonCell, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object218 = new RoomObjectType(0x218,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { },
			special: SpecialObjectType.BigChest);

		public static readonly RoomObjectType Object219 = new RoomObjectType(0x219,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { Collision, RoomDecoration, Secrets, Hookshottable },
			new byte[] { },
			special: SpecialObjectType.Chest);

		public static readonly RoomObjectType Object21A = new RoomObjectType(0x21A,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { Collision, RoomDecoration, Hookshottable },
			new byte[] { });

		public static readonly RoomObjectType Object21B = new RoomObjectType(0x21B,
			RoomDraw_AutoStairs, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object21C = new RoomObjectType(0x21C,
			RoomDraw_AutoStairs, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object21D = new RoomObjectType(0x21D,
			RoomDraw_AutoStairs, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object21E = new RoomObjectType(0x21E,
			RoomDraw_StraightInterroomStairs, None,
			new ObjCategory[] { Stairs, RoomTransition },
			new byte[] { });

		public static readonly RoomObjectType Object21F = new RoomObjectType(0x21F,
			RoomDraw_StraightInterroomStairs, None,
			new ObjCategory[] { Stairs, RoomTransition },
			new byte[] { });

		public static readonly RoomObjectType Object220 = new RoomObjectType(0x220,
			RoomDraw_StraightInterroomStairs, None,
			new ObjCategory[] { Stairs, RoomTransition },
			new byte[] { });

		public static readonly RoomObjectType Object221 = new RoomObjectType(0x221,
			RoomDraw_StraightInterroomStairs, None,
			new ObjCategory[] { Stairs, RoomTransition },
			new byte[] { });

		public static readonly RoomObjectType Object222 = new RoomObjectType(0x222,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object223 = new RoomObjectType(0x223,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object224 = new RoomObjectType(0x224,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object225 = new RoomObjectType(0x225,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object226 = new RoomObjectType(0x226,
			RoomDraw_StraightInterroomStairs, None,
			new ObjCategory[] { Stairs, RoomTransition },
			new byte[] { });

		public static readonly RoomObjectType Object227 = new RoomObjectType(0x227,
			RoomDraw_StraightInterroomStairs, None,
			new ObjCategory[] { Stairs, RoomTransition },
			new byte[] { });

		public static readonly RoomObjectType Object228 = new RoomObjectType(0x228,
			RoomDraw_StraightInterroomStairs, None,
			new ObjCategory[] { Stairs, RoomTransition },
			new byte[] { });

		public static readonly RoomObjectType Object229 = new RoomObjectType(0x229,
			RoomDraw_StraightInterroomStairs, None,
			new ObjCategory[] { Stairs, RoomTransition },
			new byte[] { });

		public static readonly RoomObjectType Object22A = new RoomObjectType(0x22A,
			RoomDraw_LampCones, None,
			new ObjCategory[] { LowerLayer },
			new byte[] { });

		public static readonly RoomObjectType Object22B = new RoomObjectType(0x22B,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object22C = new RoomObjectType(0x22C,
			RoomDraw_BigGrayRock, None,
			new ObjCategory[] { Collision, RoomDecoration, Secrets, Manipulable, Hookshottable },
			new byte[] { });

		public static readonly RoomObjectType Object22D = new RoomObjectType(0x22D,
			RoomDraw_AgahnimsAltar, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object22E = new RoomObjectType(0x22E,
			RoomDraw_AgahnimsWindows, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object22F = new RoomObjectType(0x22F,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { Collision, RoomDecoration, Secrets, Manipulable, Hookshottable },
			new byte[] { });

		public static readonly RoomObjectType Object230 = new RoomObjectType(0x230,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object231 = new RoomObjectType(0x231,
			RoomDraw_4x3OneLayer, None,
			new ObjCategory[] { Collision, RoomDecoration, Secrets, Hookshottable },
			new byte[] { },
			special: SpecialObjectType.BigChest);

		public static readonly RoomObjectType Object232 = new RoomObjectType(0x232,
			RoomDraw_4x3OneLayer, None,
			new ObjCategory[] { Collision, RoomDecoration, Hookshottable },
			new byte[] { });

		public static readonly RoomObjectType Object233 = new RoomObjectType(0x233,
			RoomDraw_AutoStairs, None,
			new ObjCategory[] { Stairs },
			new byte[] { });

		public static readonly RoomObjectType Object234 = new RoomObjectType(0x234,
			RoomDraw_ChestPlatformVerticalWall, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object235 = new RoomObjectType(0x235,
			RoomDraw_ChestPlatformVerticalWall, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object236 = new RoomObjectType(0x236,
			RoomDraw_DrawRightwards3x6, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object237 = new RoomObjectType(0x237,
			RoomDraw_DrawRightwards3x6, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object238 = new RoomObjectType(0x238,
			RoomDraw_ChestPlatformVerticalWall, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object239 = new RoomObjectType(0x239,
			RoomDraw_ChestPlatformVerticalWall, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object23A = new RoomObjectType(0x23A,
			RoomDraw_VerticalTurtleRockPipe, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object23B = new RoomObjectType(0x23B,
			RoomDraw_VerticalTurtleRockPipe, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object23C = new RoomObjectType(0x23C,
			RoomDraw_HorizontalTurtleRockPipe, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object23D = new RoomObjectType(0x23D,
			RoomDraw_HorizontalTurtleRockPipe, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object23E = new RoomObjectType(0x23E,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object23F = new RoomObjectType(0x23F,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object240 = new RoomObjectType(0x240,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object241 = new RoomObjectType(0x241,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object242 = new RoomObjectType(0x242,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object243 = new RoomObjectType(0x243,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object244 = new RoomObjectType(0x244,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object245 = new RoomObjectType(0x245,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object246 = new RoomObjectType(0x246,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object247 = new RoomObjectType(0x247,
			RoomDraw_BombableFloor, None,
			new ObjCategory[] { NoCollision, Floor, Pits, Manipulable },
			new byte[] { });

		public static readonly RoomObjectType Object248 = new RoomObjectType(0x248,
			RoomDraw_4x4Object, None,
			new ObjCategory[] { NoCollision, Floor },
			new byte[] { });

		public static readonly RoomObjectType Object249 = new RoomObjectType(0x249,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object24A = new RoomObjectType(0x24A,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { RoomTransition },
			new byte[] { });

		public static readonly RoomObjectType Object24B = new RoomObjectType(0x24B,
			RoomDraw_BigWallDecor, None,
			new ObjCategory[] { Collision, WallDecoration, NorthSide },
			new byte[] { });

		public static readonly RoomObjectType Object24C = new RoomObjectType(0x24C,
			RoomDraw_SmithyFurnace, None,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly RoomObjectType Object24D = new RoomObjectType(0x24D,
			RoomDraw_Utility6x3, None,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly RoomObjectType Object24E = new RoomObjectType(0x24E,
			RoomDraw_4x3OneLayer, None,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly RoomObjectType Object24F = new RoomObjectType(0x24F,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { NoCollision, Floor },
			new byte[] { });

		public static readonly RoomObjectType Object250 = new RoomObjectType(0x250,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object251 = new RoomObjectType(0x251,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object252 = new RoomObjectType(0x252,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { Collision, PuzzlePegs, Hookshottable },
			new byte[] { });

		public static readonly RoomObjectType Object253 = new RoomObjectType(0x253,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { Collision, PuzzlePegs, Hookshottable },
			new byte[] { });

		public static readonly RoomObjectType Object254 = new RoomObjectType(0x254,
			RoomDraw_FortuneTellerRoom, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object255 = new RoomObjectType(0x255,
			RoomDraw_Utility3x5, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object256 = new RoomObjectType(0x256,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly RoomObjectType Object257 = new RoomObjectType(0x257,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly RoomObjectType Object258 = new RoomObjectType(0x258,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly RoomObjectType Object259 = new RoomObjectType(0x259,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly RoomObjectType Object25A = new RoomObjectType(0x25A,
			RoomDraw_TableBowl, None,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly RoomObjectType Object25B = new RoomObjectType(0x25B,
			RoomDraw_Utility3x5, None,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly RoomObjectType Object25C = new RoomObjectType(0x25C,
			RoomDraw_HorizontalTurtleRockPipe, None,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly RoomObjectType Object25D = new RoomObjectType(0x25D,
			RoomDraw_Utility6x3, None,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly RoomObjectType Object25E = new RoomObjectType(0x25E,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly RoomObjectType Object25F = new RoomObjectType(0x25F,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly RoomObjectType Object260 = new RoomObjectType(0x260,
			RoomDraw_ArcheryGameTargetDoor, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object261 = new RoomObjectType(0x261,
			RoomDraw_ArcheryGameTargetDoor, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object262 = new RoomObjectType(0x262,
			RoomDraw_VitreousGooGraphics, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object263 = new RoomObjectType(0x263,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object264 = new RoomObjectType(0x264,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly RoomObjectType Object265 = new RoomObjectType(0x265,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { Collision, RoomDecoration },
			new byte[] { });

		public static readonly RoomObjectType Object266 = new RoomObjectType(0x266,
			RoomDraw_4x4Object, None,
			new ObjCategory[] { Pits },
			new byte[] { });

		public static readonly RoomObjectType Object267 = new RoomObjectType(0x267,
			RoomDraw_4x3OneLayer, None,
			new ObjCategory[] { Collision, WallDecoration, NorthSide, UpperLayer },
			new byte[] { });

		public static readonly RoomObjectType Object268 = new RoomObjectType(0x268,
			RoomDraw_4x3OneLayer, None,
			new ObjCategory[] { Collision, WallDecoration, SouthSide, UpperLayer },
			new byte[] { });

		public static readonly RoomObjectType Object269 = new RoomObjectType(0x269,
			RoomDraw_SolidWallDecor3x4, None,
			new ObjCategory[] { Collision, WallDecoration, WestSide, UpperLayer},
			new byte[] { });

		public static readonly RoomObjectType Object26A = new RoomObjectType(0x26A,
			RoomDraw_SolidWallDecor3x4, None,
			new ObjCategory[] { Collision, WallDecoration, EastSide, UpperLayer },
			new byte[] { });

		public static readonly RoomObjectType Object26B = new RoomObjectType(0x26B,
			RoomDraw_4x4Object, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object26C = new RoomObjectType(0x26C,
			RoomDraw_4x3OneLayer, None,
			new ObjCategory[] { Collision, WallDecoration, NorthSide },
			new byte[] { });

		public static readonly RoomObjectType Object26D = new RoomObjectType(0x26D,
			RoomDraw_4x3OneLayer, None,
			new ObjCategory[] { Collision, WallDecoration, SouthSide },
			new byte[] { });

		public static readonly RoomObjectType Object26E = new RoomObjectType(0x26E,
			RoomDraw_SolidWallDecor3x4, None,
			new ObjCategory[] { Collision, WallDecoration, WestSide },
			new byte[] { });

		public static readonly RoomObjectType Object26F = new RoomObjectType(0x26F,
			RoomDraw_SolidWallDecor3x4, None,
			new ObjCategory[] { Collision, WallDecoration, EastSide },
			new byte[] { });

		public static readonly RoomObjectType Object270 = new RoomObjectType(0x270,
			RoomDraw_LightBeamOnFloor, None,
			new ObjCategory[] { NoCollision, Floor },
			new byte[] { });

		public static readonly RoomObjectType Object271 = new RoomObjectType(0x271,
			RoomDraw_BigLightBeamOnFloor, None,
			new ObjCategory[] { NoCollision, Floor },
			new byte[] { });

		public static readonly RoomObjectType Object272 = new RoomObjectType(0x272,
			RoomDraw_TrinexxShell, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object273 = new RoomObjectType(0x273,
			RoomDraw_BG2MaskFull, None,
			new ObjCategory[] { },
			new byte[] { });

		public static readonly RoomObjectType Object274 = new RoomObjectType(0x274,
			RoomDraw_FloorLight, None,
			new ObjCategory[] { Collision, WallDecoration, NorthSide, Hookshottable },
			new byte[] { });

		public static readonly RoomObjectType Object275 = new RoomObjectType(0x275,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { Collision, RoomDecoration, Secrets, Hookshottable },
			new byte[] { });

		public static readonly RoomObjectType Object276 = new RoomObjectType(0x276,
			RoomDraw_BigWallDecor, None,
			new ObjCategory[] { Collision, WallDecoration, NorthSide },
			new byte[] { });

		public static readonly RoomObjectType Object277 = new RoomObjectType(0x277,
			RoomDraw_BigWallDecor, None,
			new ObjCategory[] { Collision, WallDecoration, NorthSide },
			new byte[] { });

		public static readonly RoomObjectType Object278 = new RoomObjectType(0x278,
			RoomDraw_GanonTriforceFloorDecor, None,
			new ObjCategory[] { NoCollision, Floor },
			new byte[] { });

		public static readonly RoomObjectType Object279 = new RoomObjectType(0x279,
			RoomDraw_4x3OneLayer, None,
			new ObjCategory[] { Collision, WallDecoration, NorthSide },
			new byte[] { });

		public static readonly RoomObjectType Object27A = new RoomObjectType(0x27A,
			RoomDraw_4x4Object, None,
			new ObjCategory[] { NoCollision, Floor },
			new byte[] { });

		public static readonly RoomObjectType Object27B = new RoomObjectType(0x27B,
			RoomDraw_VitreousGooDamage, None,
			new ObjCategory[] { Spikes },
			new byte[] { });

		public static readonly RoomObjectType Object27C = new RoomObjectType(0x27C,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { NoCollision, Floor },
			new byte[] { });

		public static readonly RoomObjectType Object27D = new RoomObjectType(0x27D,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { NoCollision, Floor },
			new byte[] { });

		public static readonly RoomObjectType Object27E = new RoomObjectType(0x27E,
			RoomDraw_Single2x2, None,
			new ObjCategory[] { NoCollision, Floor },
			new byte[] { });

		public static readonly RoomObjectType Object27F = new RoomObjectType(0x27F,
			RoomDraw_Nothing, None,
			new ObjCategory[] { },
			new byte[] { });

		public static RoomObjectType GetDungeonObject(ushort id)
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
