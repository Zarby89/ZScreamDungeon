using static ZeldaFullEditor.DungeonObjectSizeability;
using static ZeldaFullEditor.RoomObjectCategory;

namespace ZeldaFullEditor.Data
{
	public partial class RoomObjectType : IEntityType<RoomObjectType>
	{
		public string VanillaName { get; }
		public DungeonObjectSet ObjectSet { get; }
		public DungeonObjectSizeability Resizeability { get; }

		public DrawObject Draw { get; }

		public SpecialObjectType Specialness { get; }

		public DungeonLimits LimitClass { get; }

		/// <summary>
		/// What tile sets this object doesn't look like garbage in
		/// </summary>
		public RequiredGraphicsSheets RequiredSheets { get; }

		public ImmutableArray<RoomObjectCategory> Categories { get; }

		public bool IsCompletelyInvisible => Draw == RoomDraw_Nothing;

		public ushort FullID { get; }

		// every tileset is beautiful
		public static readonly byte[] AllTileSets = { 0 };

		private RoomObjectType(ushort objectid, DrawObject drawfunc, DungeonObjectSizeability resizing, RoomObjectCategory[] categories, RequiredGraphicsSheets gsets,
			SpecialObjectType special = SpecialObjectType.None, DungeonLimits limit = DungeonLimits.None)
		{
			ObjectSet = (DungeonObjectSet) (objectid >> 8);
			FullID = objectid;

			string name = ObjectSet switch
			{
				DungeonObjectSet.Subtype1 => DefaultEntities.ListOfSubtype1RoomObjects[(byte) objectid].Name,
				DungeonObjectSet.Subtype2 => DefaultEntities.ListOfSubtype2RoomObjects[(byte) objectid].Name,
				DungeonObjectSet.Subtype3 => DefaultEntities.ListOfSubtype3RoomObjects[(byte) objectid].Name,
				_ => "PROBLEM",
			};

			VanillaName = name;
			Resizeability = resizing;
			Specialness = special;
			Categories = categories.ToImmutableArray();
			RequiredSheets = gsets;
			LimitClass = limit;
			Draw = drawfunc;
		}

		public override string ToString()
		{
			return $"{FullID:X3} {VanillaName}";
		}


#pragma warning disable CA1825 // Avoid zero-length array allocations


		/*
		 * All room object defaults
		 */
		public static readonly RoomObjectType Object000 = new(0x000,
			RoomDraw_Rightwards2x2_1to15or32, Horizontal,
			new RoomObjectCategory[] { Collision, Ceiling },
			new());

		public static readonly RoomObjectType Object001 = new(0x001,
			RoomDraw_Rightwards2x4_1to15or26, Horizontal,
			new RoomObjectCategory[] { Collision, Wall, NorthSide },
			new());

		public static readonly RoomObjectType Object002 = new(0x002,
			RoomDraw_Rightwards2x4_1to15or26, Horizontal,
			new RoomObjectCategory[] { Collision, Wall, SouthSide },
			new());

		public static readonly RoomObjectType Object003 = new(0x003,
			RoomDraw_Rightwards2x4spaced4_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, Wall, NorthSide, Ledge, LowerLayer },
			new());

		public static readonly RoomObjectType Object004 = new(0x004,
			RoomDraw_Rightwards2x4spaced4_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, Wall, SouthSide, Ledge, LowerLayer },
			new());

		public static readonly RoomObjectType Object005 = new(0x005,
			RoomDraw_Rightwards2x4spaced4_1to16_BothBG, Horizontal,
			new RoomObjectCategory[] { Collision, WallDecoration, NorthSide },
			new());

		public static readonly RoomObjectType Object006 = new(0x006,
			RoomDraw_Rightwards2x4spaced4_1to16_BothBG, Horizontal,
			new RoomObjectCategory[] { Collision, WallDecoration, SouthSide },
			new());

		public static readonly RoomObjectType Object007 = new(0x007,
			RoomDraw_Rightwards2x2_1to16, Horizontal,
			new RoomObjectCategory[] { Pits, NorthSide },
			new());

		public static readonly RoomObjectType Object008 = new(0x008,
			RoomDraw_Rightwards2x2_1to16, Horizontal,
			new RoomObjectCategory[] { Pits, SouthSide },
			new());

		public static readonly RoomObjectType Object009 = new(0x009,
			RoomDraw_DiagonalAcute_1to16, Horizontal,
			new RoomObjectCategory[] { DiagonalCollision, Wall, NorthSide, WestSide, UpperLayer },
			new());

		public static readonly RoomObjectType Object00A = new(0x00A,
			RoomDraw_DiagonalGrave_1to16, Horizontal,
			new RoomObjectCategory[] { DiagonalCollision, Wall, SouthSide, WestSide, UpperLayer },
			new());

		public static readonly RoomObjectType Object00B = new(0x00B,
			RoomDraw_DiagonalGrave_1to16, Horizontal,
			new RoomObjectCategory[] { DiagonalCollision, Wall, NorthSide, EastSide, UpperLayer },
			new());

		public static readonly RoomObjectType Object00C = new(0x00C,
			RoomDraw_DiagonalAcute_1to16, Horizontal,
			new RoomObjectCategory[] { DiagonalCollision, Wall, SouthSide, EastSide, UpperLayer },
			new());

		public static readonly RoomObjectType Object00D = new(0x00D,
			RoomDraw_DiagonalAcute_1to16, Horizontal,
			new RoomObjectCategory[] { DiagonalCollision, Wall, NorthSide, WestSide, UpperLayer },
			new());

		public static readonly RoomObjectType Object00E = new(0x00E,
			RoomDraw_DiagonalGrave_1to16, Horizontal,
			new RoomObjectCategory[] { DiagonalCollision, Wall, SouthSide, WestSide, UpperLayer },
			new());

		public static readonly RoomObjectType Object00F = new(0x00F,
			RoomDraw_DiagonalGrave_1to16, Horizontal,
			new RoomObjectCategory[] { DiagonalCollision, Wall, NorthSide, EastSide, UpperLayer },
			new());

		public static readonly RoomObjectType Object010 = new(0x010,
			RoomDraw_DiagonalAcute_1to16, Horizontal,
			new RoomObjectCategory[] { DiagonalCollision, Wall, SouthSide, EastSide, UpperLayer },
			new());

		public static readonly RoomObjectType Object011 = new(0x011,
			RoomDraw_DiagonalAcute_1to16, Horizontal,
			new RoomObjectCategory[] { DiagonalCollision, Wall, NorthSide, WestSide, UpperLayer },
			new());

		public static readonly RoomObjectType Object012 = new(0x012,
			RoomDraw_DiagonalGrave_1to16, Horizontal,
			new RoomObjectCategory[] { DiagonalCollision, Wall, SouthSide, WestSide, UpperLayer },
			new());

		public static readonly RoomObjectType Object013 = new(0x013,
			RoomDraw_DiagonalGrave_1to16, Horizontal,
			new RoomObjectCategory[] { DiagonalCollision, Wall, NorthSide, EastSide, UpperLayer },
			new());

		public static readonly RoomObjectType Object014 = new(0x014,
			RoomDraw_DiagonalAcute_1to16, Horizontal,
			new RoomObjectCategory[] { DiagonalCollision, Wall, SouthSide, EastSide, UpperLayer },
			new());

		public static readonly RoomObjectType Object015 = new(0x015,
			RoomDraw_DiagonalAcute_1to16_BothBG, Horizontal,
			new RoomObjectCategory[] { DiagonalCollision, Wall, NorthSide, WestSide, LowerLayer },
			new());

		public static readonly RoomObjectType Object016 = new(0x016,
			RoomDraw_DiagonalGrave_1to16_BothBG, Horizontal,
			new RoomObjectCategory[] { DiagonalCollision, Wall, SouthSide, WestSide, LowerLayer },
			new());

		public static readonly RoomObjectType Object017 = new(0x017,
			RoomDraw_DiagonalGrave_1to16_BothBG, Horizontal,
			new RoomObjectCategory[] { DiagonalCollision, Wall, NorthSide, EastSide, LowerLayer },
			new());

		public static readonly RoomObjectType Object018 = new(0x018,
			RoomDraw_DiagonalAcute_1to16_BothBG, Horizontal,
			new RoomObjectCategory[] { DiagonalCollision, Wall, SouthSide, EastSide, LowerLayer },
			new());

		public static readonly RoomObjectType Object019 = new(0x019,
			RoomDraw_DiagonalAcute_1to16_BothBG, Horizontal,
			new RoomObjectCategory[] { DiagonalCollision, Wall, NorthSide, WestSide, LowerLayer },
			new());

		public static readonly RoomObjectType Object01A = new(0x01A,
			RoomDraw_DiagonalGrave_1to16_BothBG, Horizontal,
			new RoomObjectCategory[] { DiagonalCollision, Wall, SouthSide, WestSide, LowerLayer },
			new());

		public static readonly RoomObjectType Object01B = new(0x01B,
			RoomDraw_DiagonalGrave_1to16_BothBG, Horizontal,
			new RoomObjectCategory[] { DiagonalCollision, Wall, NorthSide, EastSide, LowerLayer },
			new());

		public static readonly RoomObjectType Object01C = new(0x01C,
			RoomDraw_DiagonalAcute_1to16_BothBG, Horizontal,
			new RoomObjectCategory[] { DiagonalCollision, Wall, SouthSide, EastSide, LowerLayer },
			new());

		public static readonly RoomObjectType Object01D = new(0x01D,
			RoomDraw_DiagonalAcute_1to16_BothBG, Horizontal,
			new RoomObjectCategory[] { DiagonalCollision, Wall, NorthSide, WestSide, LowerLayer },
			new());

		public static readonly RoomObjectType Object01E = new(0x01E,
			RoomDraw_DiagonalGrave_1to16_BothBG, Horizontal,
			new RoomObjectCategory[] { DiagonalCollision, Wall, SouthSide, WestSide, LowerLayer },
			new());

		public static readonly RoomObjectType Object01F = new(0x01F,
			RoomDraw_DiagonalGrave_1to16_BothBG, Horizontal,
			new RoomObjectCategory[] { DiagonalCollision, Wall, NorthSide, EastSide, LowerLayer },
			new());

		public static readonly RoomObjectType Object020 = new(0x020,
			RoomDraw_DiagonalAcute_1to16_BothBG, Horizontal,
			new RoomObjectCategory[] { DiagonalCollision, Wall, SouthSide, EastSide, LowerLayer },
			new());

		public static readonly RoomObjectType Object021 = new(0x021,
			RoomDraw_Rightwards1x2_1to16_plus2, Horizontal,
			new RoomObjectCategory[] { Stairs },
			new());

		public static readonly RoomObjectType Object022 = new(0x022,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus3, Horizontal,
			new RoomObjectCategory[] { Collision },
			new());

		public static readonly RoomObjectType Object023 = new(0x023,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new RoomObjectCategory[] { Pits },
			new());

		public static readonly RoomObjectType Object024 = new(0x024,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new RoomObjectCategory[] { Pits },
			new());

		public static readonly RoomObjectType Object025 = new(0x025,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new RoomObjectCategory[] { Pits },
			new());

		public static readonly RoomObjectType Object026 = new(0x026,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new RoomObjectCategory[] { Pits },
			new());

		public static readonly RoomObjectType Object027 = new(0x027,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new RoomObjectCategory[] { Pits },
			new());

		public static readonly RoomObjectType Object028 = new(0x028,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new RoomObjectCategory[] { Pits },
			new());

		public static readonly RoomObjectType Object029 = new(0x029,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new RoomObjectCategory[] { Pits },
			new());

		public static readonly RoomObjectType Object02A = new(0x02A,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new RoomObjectCategory[] { Pits },
			new());

		public static readonly RoomObjectType Object02B = new(0x02B,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new RoomObjectCategory[] { Pits },
			new());

		public static readonly RoomObjectType Object02C = new(0x02C,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new RoomObjectCategory[] { Pits },
			new());

		public static readonly RoomObjectType Object02D = new(0x02D,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new RoomObjectCategory[] { Pits },
			new());

		public static readonly RoomObjectType Object02E = new(0x02E,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new RoomObjectCategory[] { Pits },
			new());

		public static readonly RoomObjectType Object02F = new(0x02F,
			RoomDraw_RightwardsWithCorners1x2_1to16_plus13, Horizontal,
			new RoomObjectCategory[] { Collision, Ledge, Wall, NorthSide, SouthSide, UpperLayer },
			new());

		public static readonly RoomObjectType Object030 = new(0x030,
			RoomDraw_RightwardsWithCorners1x2_1to16_plus13, Horizontal,
			new RoomObjectCategory[] { Collision, Ledge, Wall, NorthSide, SouthSide, UpperLayer },
			new());

		public static readonly RoomObjectType Object031 = new(0x031,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object032 = new(0x032,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object033 = new(0x033,
			RoomDraw_Rightwards4x4_1to16, Horizontal,
			new RoomObjectCategory[] { NoCollision, Floor, RoomDecoration },
			new());

		public static readonly RoomObjectType Object034 = new(0x034,
			RoomDraw_Rightwards1x1Solid_1to16_plus3, Horizontal,
			new RoomObjectCategory[] { NoCollision, Floor, RoomDecoration, NorthPerimeter, SouthPerimeter },
			new());

		public static readonly RoomObjectType Object035 = new(0x035,
			RoomDraw_DoorSwitcherer, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object036 = new(0x036,
			RoomDraw_RightwardsDecor4x4spaced2_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, WallDecoration, NorthSide, UpperLayer },
			new());

		public static readonly RoomObjectType Object037 = new(0x037,
			RoomDraw_RightwardsDecor4x4spaced2_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, WallDecoration, SouthSide, UpperLayer },
			new());

		public static readonly RoomObjectType Object038 = new(0x038,
			RoomDraw_RightwardsStatue2x3spaced2_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, RoomDecoration, Hookshottable },
			new());

		public static readonly RoomObjectType Object039 = new(0x039,
			RoomDraw_RightwardsPillar2x4spaced4_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		public static readonly RoomObjectType Object03A = new(0x03A,
			RoomDraw_RightwardsDecor4x3spaced4_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, WallDecoration, NorthSide, UpperLayer },
			new());

		public static readonly RoomObjectType Object03B = new(0x03B,
			RoomDraw_RightwardsDecor4x3spaced4_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, WallDecoration, SouthSide, UpperLayer },
			new());

		public static readonly RoomObjectType Object03C = new(0x03C,
			RoomDraw_RightwardsDoubled2x2spaced2_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		public static readonly RoomObjectType Object03D = new(0x03D,
			RoomDraw_RightwardsPillar2x4spaced4_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, RoomDecoration, Hookshottable },
			new());

		public static readonly RoomObjectType Object03E = new(0x03E,
			RoomDraw_RightwardsDecor2x2spaced12_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, WallDecoration, NorthSide, UpperLayer },
			new());

		public static readonly RoomObjectType Object03F = new(0x03F,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new RoomObjectCategory[] { ShallowWater },
			new());

		public static readonly RoomObjectType Object040 = new(0x040,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new RoomObjectCategory[] { ShallowWater },
			new());

		public static readonly RoomObjectType Object041 = new(0x041,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new RoomObjectCategory[] { ShallowWater },
			new());

		public static readonly RoomObjectType Object042 = new(0x042,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new RoomObjectCategory[] { ShallowWater },
			new());

		public static readonly RoomObjectType Object043 = new(0x043,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new RoomObjectCategory[] { ShallowWater },
			new());

		public static readonly RoomObjectType Object044 = new(0x044,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new RoomObjectCategory[] { ShallowWater },
			new());

		public static readonly RoomObjectType Object045 = new(0x045,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new RoomObjectCategory[] { ShallowWater },
			new());

		public static readonly RoomObjectType Object046 = new(0x046,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new RoomObjectCategory[] { ShallowWater },
			new());

		public static readonly RoomObjectType Object047 = new(0x047,
			RoomDraw_Waterfall47, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object048 = new(0x048,
			RoomDraw_Waterfall48, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object049 = new(0x049,
			RoomDraw_RightwardsFloorTile4x2_1to16, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object04A = new(0x04A,
			RoomDraw_RightwardsFloorTile4x2_1to16, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object04B = new(0x04B,
			RoomDraw_RightwardsDecor2x2spaced12_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, WallDecoration, SouthSide, UpperLayer },
			new());

		public static readonly RoomObjectType Object04C = new(0x04C,
			RoomDraw_RightwardsBar4x3_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		public static readonly RoomObjectType Object04D = new(0x04D,
			RoomDraw_RightwardsShelf4x4_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, WallDecoration, NorthSide, UpperLayer },
			new());

		public static readonly RoomObjectType Object04E = new(0x04E,
			RoomDraw_RightwardsShelf4x4_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, WallDecoration, NorthSide, UpperLayer },
			new());

		public static readonly RoomObjectType Object04F = new(0x04F,
			RoomDraw_RightwardsShelf4x4_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, WallDecoration, NorthSide, UpperLayer },
			new());

		public static readonly RoomObjectType Object050 = new(0x050,
			RoomDraw_RightwardsLine1x1_1to16plus1, Horizontal,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object051 = new(0x051,
			RoomDraw_RightwardsCannonHole4x3_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, WallDecoration, NorthSide },
			new());

		public static readonly RoomObjectType Object052 = new(0x052,
			RoomDraw_RightwardsCannonHole4x3_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, WallDecoration, SouthSide },
			new());

		public static readonly RoomObjectType Object053 = new(0x053,
			RoomDraw_Rightwards2x2_1to16, Horizontal,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object054 = new(0x054,
			RoomDraw_Nothing, Horizontal,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object055 = new(0x055,
			RoomDraw_RightwardsDecor4x2spaced8_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, WallDecoration, NorthSide, UpperLayer },
			new());

		public static readonly RoomObjectType Object056 = new(0x056,
			RoomDraw_RightwardsDecor4x2spaced8_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, WallDecoration, SouthSide, UpperLayer },
			new());

		public static readonly RoomObjectType Object057 = new(0x057,
			RoomDraw_Nothing, Horizontal,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object058 = new(0x058,
			RoomDraw_Nothing, Horizontal,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object059 = new(0x059,
			RoomDraw_Nothing, Horizontal,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object05A = new(0x05A,
			RoomDraw_Nothing, Horizontal,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object05B = new(0x05B,
			RoomDraw_RightwardsCannonHole4x3_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, WallDecoration, NorthSide },
			new());

		public static readonly RoomObjectType Object05C = new(0x05C,
			RoomDraw_RightwardsCannonHole4x3_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, WallDecoration, SouthSide },
			new());

		public static readonly RoomObjectType Object05D = new(0x05D,
			RoomDraw_RightwardsBigRail1x3_1to16plus5, Horizontal,
			new RoomObjectCategory[] { Collision, RoomDecoration, Hookshottable },
			new());

		public static readonly RoomObjectType Object05E = new(0x05E,
			RoomDraw_RightwardsBlock2x2spaced2_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, RoomDecoration, Hookshottable },
			new());

		public static readonly RoomObjectType Object05F = new(0x05F,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus23, Horizontal,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		public static readonly RoomObjectType Object060 = new(0x060,
			RoomDraw_Downwards2x2_1to15or32, Horizontal,
			new RoomObjectCategory[] { Ceiling, Collision },
			new());

		public static readonly RoomObjectType Object061 = new(0x061,
			RoomDraw_Downwards4x2_1to15or26, Horizontal,
			new RoomObjectCategory[] { Collision, Wall, WestSide },
			new());

		public static readonly RoomObjectType Object062 = new(0x062,
			RoomDraw_Downwards4x2_1to15or26, Horizontal,
			new RoomObjectCategory[] { Collision, Wall, EastSide },
			new());

		public static readonly RoomObjectType Object063 = new(0x063,
			RoomDraw_Downwards4x2_1to16_BothBG, Horizontal,
			new RoomObjectCategory[] { Collision, Wall, WestSide, LowerLayer },
			new());

		public static readonly RoomObjectType Object064 = new(0x064,
			RoomDraw_Downwards4x2_1to16_BothBG, Horizontal,
			new RoomObjectCategory[] { Collision, Wall, EastSide, LowerLayer },
			new());

		public static readonly RoomObjectType Object065 = new(0x065,
			RoomDraw_DownwardsDecor4x2spaced4_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, WallDecoration, WestSide, UpperLayer },
			new());

		public static readonly RoomObjectType Object066 = new(0x066,
			RoomDraw_DownwardsDecor4x2spaced4_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, WallDecoration, WestSide, UpperLayer },
			new());

		public static readonly RoomObjectType Object067 = new(0x067,
			RoomDraw_Downwards2x2_1to16, Horizontal,
			new RoomObjectCategory[] { Pits, WestSide },
			new());

		public static readonly RoomObjectType Object068 = new(0x068,
			RoomDraw_Downwards2x2_1to16, Horizontal,
			new RoomObjectCategory[] { Pits, EastSide },
			new());

		public static readonly RoomObjectType Object069 = new(0x069,
			RoomDraw_DownwardsHasEdge1x1_1to16_plus3, Horizontal,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		public static readonly RoomObjectType Object06A = new(0x06A,
			RoomDraw_DownwardsEdge1x1_1to16, Horizontal,
			new RoomObjectCategory[] { Pits, WestPerimeter },
			new());

		public static readonly RoomObjectType Object06B = new(0x06B,
			RoomDraw_DownwardsEdge1x1_1to16, Horizontal,
			new RoomObjectCategory[] { Pits, EastPerimeter },
			new());

		public static readonly RoomObjectType Object06C = new(0x06C,
			RoomDraw_DownwardsWithCorners2x1_1to16_plus12, Horizontal,
			new RoomObjectCategory[] { Collision, WestSide, EastSide, UpperLayer },
			new());

		public static readonly RoomObjectType Object06D = new(0x06D,
			RoomDraw_DownwardsWithCorners2x1_1to16_plus12, Horizontal,
			new RoomObjectCategory[] { Collision, WestSide, EastSide, UpperLayer },
			new());

		public static readonly RoomObjectType Object06E = new(0x06E,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object06F = new(0x06F,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object070 = new(0x070,
			RoomDraw_DownwardsFloor4x4_1to16, Vertical,
			new RoomObjectCategory[] { NoCollision, Floor, RoomDecoration },
			new());

		public static readonly RoomObjectType Object071 = new(0x071,
			RoomDraw_Downwards1x1Solid_1to16_plus3, Vertical,
			new RoomObjectCategory[] { NoCollision, Floor, RoomDecoration, WestPerimeter, EastPerimeter },
			new());

		public static readonly RoomObjectType Object072 = new(0x072,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object073 = new(0x073,
			RoomDraw_DownwardsDecor4x4spaced2_1to16, Vertical,
			new RoomObjectCategory[] { Collision, WallDecoration, WestSide, UpperLayer },
			new());

		public static readonly RoomObjectType Object074 = new(0x074,
			RoomDraw_DownwardsDecor4x4spaced2_1to16, Vertical,
			new RoomObjectCategory[] { Collision, WallDecoration, EastSide, UpperLayer },
			new());

		public static readonly RoomObjectType Object075 = new(0x075,
			RoomDraw_DownwardsPillar2x4spaced2_1to16, Vertical,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		public static readonly RoomObjectType Object076 = new(0x076,
			RoomDraw_DownwardsDecor3x4spaced4_1to16, Vertical,
			new RoomObjectCategory[] { Collision, WallDecoration, WestSide, UpperLayer },
			new());

		public static readonly RoomObjectType Object077 = new(0x077,
			RoomDraw_DownwardsDecor3x4spaced4_1to16, Vertical,
			new RoomObjectCategory[] { Collision, WallDecoration, EastSide, UpperLayer },
			new());

		public static readonly RoomObjectType Object078 = new(0x078,
			RoomDraw_DownwardsDecor2x2spaced12_1to16, Vertical,
			new RoomObjectCategory[] { Collision, WallDecoration, WestSide, UpperLayer },
			new());

		public static readonly RoomObjectType Object079 = new(0x079,
			RoomDraw_DownwardsEdge1x1_1to16, Vertical,
			new RoomObjectCategory[] { ShallowWater, Floor },
			new());

		public static readonly RoomObjectType Object07A = new(0x07A,
			RoomDraw_DownwardsEdge1x1_1to16, Vertical,
			new RoomObjectCategory[] { ShallowWater, Floor },
			new());

		public static readonly RoomObjectType Object07B = new(0x07B,
			RoomDraw_DownwardsDecor2x2spaced12_1to16, Vertical,
			new RoomObjectCategory[] { Collision, WallDecoration, EastSide, UpperLayer },
			new());

		public static readonly RoomObjectType Object07C = new(0x07C,
			RoomDraw_DownwardsLine1x1_1to16plus1, Vertical,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object07D = new(0x07D,
			RoomDraw_Downwards2x2_1to16, Vertical,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object07E = new(0x07E,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object07F = new(0x07F,
			RoomDraw_DownwardsDecor2x4spaced8_1to16, Vertical,
			new RoomObjectCategory[] { Collision, WallDecoration, WestSide, UpperLayer },
			new());

		public static readonly RoomObjectType Object080 = new(0x080,
			RoomDraw_DownwardsDecor2x4spaced8_1to16, Vertical,
			new RoomObjectCategory[] { Collision, WallDecoration, EastSide, UpperLayer },
			new());

		public static readonly RoomObjectType Object081 = new(0x081,
			RoomDraw_DownwardsDecor3x4spaced2_1to16, Vertical,
			new RoomObjectCategory[] { Collision, WallDecoration, WestSide, UpperLayer },
			new());

		public static readonly RoomObjectType Object082 = new(0x082,
			RoomDraw_DownwardsDecor3x4spaced2_1to16, Vertical,
			new RoomObjectCategory[] { Collision, WallDecoration, EastSide, UpperLayer },
			new());

		public static readonly RoomObjectType Object083 = new(0x083,
			RoomDraw_DownwardsDecor3x4spaced2_1to16, Vertical,
			new RoomObjectCategory[] { Collision, WallDecoration, WestSide, UpperLayer },
			new());

		public static readonly RoomObjectType Object084 = new(0x084,
			RoomDraw_DownwardsDecor3x4spaced2_1to16, Vertical,
			new RoomObjectCategory[] { Collision, WallDecoration, EastSide, UpperLayer },
			new());

		public static readonly RoomObjectType Object085 = new(0x085,
			RoomDraw_DownwardsCannonHole3x4_1to16, Vertical,
			new RoomObjectCategory[] { Collision, WallDecoration, WestSide, UpperLayer },
			new());

		public static readonly RoomObjectType Object086 = new(0x086,
			RoomDraw_DownwardsCannonHole3x4_1to16, Vertical,
			new RoomObjectCategory[] { Collision, WallDecoration, EastSide, UpperLayer },
			new());

		public static readonly RoomObjectType Object087 = new(0x087,
			RoomDraw_DownwardsPillar2x4spaced2_1to16, Vertical,
			new RoomObjectCategory[] { Collision, RoomDecoration, Hookshottable },
			new());

		public static readonly RoomObjectType Object088 = new(0x088,
			RoomDraw_DownwardsBigRail3x1_1to16plus5, Vertical,
			new RoomObjectCategory[] { Collision, RoomDecoration, Hookshottable },
			new());

		public static readonly RoomObjectType Object089 = new(0x089,
			RoomDraw_DownwardsBlock2x2spaced2_1to16, Vertical,
			new RoomObjectCategory[] { Collision, RoomDecoration, Hookshottable },
			new());

		public static readonly RoomObjectType Object08A = new(0x08A,
			RoomDraw_DownwardsHasEdge1x1_1to16_plus23, Vertical,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		public static readonly RoomObjectType Object08B = new(0x08B,
			RoomDraw_DownwardsEdge1x1_1to16plus7, Vertical,
			new RoomObjectCategory[] { Ledge, UpperLayer, WestPerimeter },
			new());

		public static readonly RoomObjectType Object08C = new(0x08C,
			RoomDraw_DownwardsEdge1x1_1to16plus7, Vertical,
			new RoomObjectCategory[] { Ledge, UpperLayer, EastPerimeter },
			new());

		public static readonly RoomObjectType Object08D = new(0x08D,
			RoomDraw_DownwardsEdge1x1_1to16, Vertical,
			new RoomObjectCategory[] { NoCollision, Floor, RoomDecoration, WestPerimeter },
			new());

		public static readonly RoomObjectType Object08E = new(0x08E,
			RoomDraw_DownwardsEdge1x1_1to16, Vertical,
			new RoomObjectCategory[] { NoCollision, Floor, RoomDecoration, EastPerimeter },
			new());

		public static readonly RoomObjectType Object08F = new(0x08F,
			RoomDraw_DownwardsBar2x5_1to16, Vertical,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		public static readonly RoomObjectType Object090 = new(0x090,
			RoomDraw_Downwards4x2_1to15or26, Vertical,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object091 = new(0x091,
			RoomDraw_Downwards4x2_1to15or26, Vertical,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object092 = new(0x092,
			RoomDraw_Downwards2x2_1to15or32, Vertical,
			new RoomObjectCategory[] { Collision, PuzzlePegs, Hookshottable },
			new());

		public static readonly RoomObjectType Object093 = new(0x093,
			RoomDraw_Downwards2x2_1to15or32, Vertical,
			new RoomObjectCategory[] { Collision, PuzzlePegs, Hookshottable },
			new());

		public static readonly RoomObjectType Object094 = new(0x094,
			RoomDraw_DownwardsFloor4x4_1to16, Vertical,
			new RoomObjectCategory[] { NoCollision, Floor },
			new());

		public static readonly RoomObjectType Object095 = new(0x095,
			RoomDraw_Downwards2x2_1to16, Vertical,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		public static readonly RoomObjectType Object096 = new(0x096,
			RoomDraw_Downwards2x2_1to16, Vertical,
			new RoomObjectCategory[] { Collision, PuzzlePegs, Hookshottable, Manipulable },
			new(),
			limit: DungeonLimits.GeneralManipulable);

		public static readonly RoomObjectType Object097 = new(0x097,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object098 = new(0x098,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object099 = new(0x099,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object09A = new(0x09A,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object09B = new(0x09B,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object09C = new(0x09C,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object09D = new(0x09D,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object09E = new(0x09E,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object09F = new(0x09F,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object0A0 = new(0x0A0,
			RoomDraw_DiagonalCeilingTopLeft, Both,
			new RoomObjectCategory[] { Collision, Ceiling },
			new());

		public static readonly RoomObjectType Object0A1 = new(0x0A1,
			RoomDraw_DiagonalCeilingBottomLeft, Both,
			new RoomObjectCategory[] { Collision, Ceiling },
			new());

		public static readonly RoomObjectType Object0A2 = new(0x0A2,
			RoomDraw_DiagonalCeilingTopRight, Both,
			new RoomObjectCategory[] { Collision, Ceiling },
			new());

		public static readonly RoomObjectType Object0A3 = new(0x0A3,
			RoomDraw_DiagonalCeilingBottomRight, Both,
			new RoomObjectCategory[] { Collision, Ceiling },
			new());

		public static readonly RoomObjectType Object0A4 = new(0x0A4,
			RoomDraw_BigHole4x4_1to16, Both,
			new RoomObjectCategory[] { Pits },
			new());

		public static readonly RoomObjectType Object0A5 = new(0x0A5,
			RoomDraw_DiagonalCeilingTopLeft, Both,
			new RoomObjectCategory[] { Collision, Ceiling },
			new(),
			special: SpecialObjectType.LayerMask);

		public static readonly RoomObjectType Object0A6 = new(0x0A6,
			RoomDraw_DiagonalCeilingBottomLeft, Both,
			new RoomObjectCategory[] { Collision, Ceiling },
			new(),
			special: SpecialObjectType.LayerMask);

		public static readonly RoomObjectType Object0A7 = new(0x0A7,
			RoomDraw_DiagonalCeilingTopRight, Both,
			new RoomObjectCategory[] { Collision, Ceiling },
			new(),
			special: SpecialObjectType.LayerMask);

		public static readonly RoomObjectType Object0A8 = new(0x0A8,
			RoomDraw_DiagonalCeilingBottomRight, Both,
			new RoomObjectCategory[] { Collision, Ceiling },
			new(),
			special: SpecialObjectType.LayerMask);

		public static readonly RoomObjectType Object0A9 = new(0x0A9,
			RoomDraw_DiagonalCeilingTopLeft, Both,
			new RoomObjectCategory[] { Collision, Ceiling },
			new(),
			special: SpecialObjectType.LayerMask);

		public static readonly RoomObjectType Object0AA = new(0x0AA,
			RoomDraw_DiagonalCeilingBottomLeft, Both,
			new RoomObjectCategory[] { Collision, Ceiling },
			new(),
			special: SpecialObjectType.LayerMask);

		public static readonly RoomObjectType Object0AB = new(0x0AB,
			RoomDraw_DiagonalCeilingTopRight, Both,
			new RoomObjectCategory[] { Collision, Ceiling },
			new(),
			special: SpecialObjectType.LayerMask);

		public static readonly RoomObjectType Object0AC = new(0x0AC,
			RoomDraw_DiagonalCeilingBottomRight, Both,
			new RoomObjectCategory[] { Collision, Ceiling },
			new(),
			special: SpecialObjectType.LayerMask);

		public static readonly RoomObjectType Object0AD = new(0x0AD,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object0AE = new(0x0AE,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object0AF = new(0x0AF,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object0B0 = new(0x0B0,
			RoomDraw_RightwardsEdge1x1_1to16plus7, Horizontal,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object0B1 = new(0x0B1,
			RoomDraw_RightwardsEdge1x1_1to16plus7, Horizontal,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object0B2 = new(0x0B2,
			RoomDraw_Rightwards4x4_1to16, Horizontal,
			new RoomObjectCategory[] { NoCollision, Floor },
			new());

		public static readonly RoomObjectType Object0B3 = new(0x0B3,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new RoomObjectCategory[] { NoCollision, Floor, NorthPerimeter },
			new());

		public static readonly RoomObjectType Object0B4 = new(0x0B4,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new RoomObjectCategory[] { NoCollision, Floor, SouthPerimeter },
			new());

		public static readonly RoomObjectType Object0B5 = new(0x0B5,
			RoomDraw_Weird2x4_1_to_16, Horizontal,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object0B6 = new(0x0B6,
			RoomDraw_Rightwards2x4_1to15or26, Horizontal,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object0B7 = new(0x0B7,
			RoomDraw_Rightwards2x4_1to15or26, Horizontal,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object0B8 = new(0x0B8,
			RoomDraw_Rightwards2x2_1to15or32, Horizontal,
			new RoomObjectCategory[] { Collision, PuzzlePegs, Hookshottable },
			new());

		public static readonly RoomObjectType Object0B9 = new(0x0B9,
			RoomDraw_Rightwards2x2_1to15or32, Horizontal,
			new RoomObjectCategory[] { Collision, PuzzlePegs, Hookshottable },
			new());

		public static readonly RoomObjectType Object0BA = new(0x0BA,
			RoomDraw_Rightwards4x4_1to16, Horizontal,
			new RoomObjectCategory[] { NoCollision, Floor },
			new());

		public static readonly RoomObjectType Object0BB = new(0x0BB,
			RoomDraw_RightwardsBlock2x2spaced2_1to16, Horizontal,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object0BC = new(0x0BC,
			RoomDraw_RightwardsFakePots2x2_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		public static readonly RoomObjectType Object0BD = new(0x0BD,
			RoomDraw_RightwardsHammerPegs2x2_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, PuzzlePegs, Hookshottable, Manipulable },
			new(),
			limit: DungeonLimits.GeneralManipulable);

		public static readonly RoomObjectType Object0BE = new(0x0BE,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object0BF = new(0x0BF,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object0C0 = new(0x0C0,
			RoomDraw_4x4BlocksIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { Collision, Ceiling },
			new());

		public static readonly RoomObjectType Object0C1 = new(0x0C1,
			RoomDraw_ClosedChestPlatform, Both,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object0C2 = new(0x0C2,
			RoomDraw_4x4BlocksIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { Pits, MetaLayer },
			new(),
			special: SpecialObjectType.LayerMask);

		public static readonly RoomObjectType Object0C3 = new(0x0C3,
			RoomDraw_3x3FloorIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { Pits, MetaLayer },
			new(),
			special: SpecialObjectType.LayerMask);

		public static readonly RoomObjectType Object0C4 = new(0x0C4,
			RoomDraw_4x4FloorOneIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { NoCollision, Floor },
			new());

		public static readonly RoomObjectType Object0C5 = new(0x0C5,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { NoCollision, Floor },
			new());

		public static readonly RoomObjectType Object0C6 = new(0x0C6,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { Pits, MetaLayer },
			new(),
			special: SpecialObjectType.LayerMask);

		public static readonly RoomObjectType Object0C7 = new(0x0C7,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { NoCollision, Floor },
			new());

		public static readonly RoomObjectType Object0C8 = new(0x0C8,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { NoCollision, Floor },
			new());

		public static readonly RoomObjectType Object0C9 = new(0x0C9,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { NoCollision, Floor },
			new());

		public static readonly RoomObjectType Object0CA = new(0x0CA,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { NoCollision, Floor },
			new());

		public static readonly RoomObjectType Object0CB = new(0x0CB,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object0CC = new(0x0CC,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object0CD = new(0x0CD,
			RoomDraw_MovingWallWest, Both,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object0CE = new(0x0CE,
			RoomDraw_MovingWallEast, Both,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object0CF = new(0x0CF,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object0D0 = new(0x0D0,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object0D1 = new(0x0D1,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object0D2 = new(0x0D2,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object0D3 = new(0x0D3,
			RoomDraw_CheckIfWallIsMoved, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object0D4 = new(0x0D4,
			RoomDraw_CheckIfWallIsMoved, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object0D5 = new(0x0D5,
			RoomDraw_CheckIfWallIsMoved, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object0D6 = new(0x0D6,
			RoomDraw_CheckIfWallIsMoved, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object0D7 = new(0x0D7,
			RoomDraw_3x3FloorIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { MetaLayer },
			new(),
			special: SpecialObjectType.LayerMask);

		public static readonly RoomObjectType Object0D8 = new(0x0D8,
			RoomDraw_WaterOverlay8x8_1to16, Both,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object0D9 = new(0x0D9,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { MetaLayer },
			new(),
			special: SpecialObjectType.LayerMask);

		public static readonly RoomObjectType Object0DA = new(0x0DA,
			RoomDraw_WaterOverlay8x8_1to16, Both,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object0DB = new(0x0DB,
			RoomDraw_4x4FloorTwoIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object0DC = new(0x0DC,
			RoomDraw_OpenChestPlatform, Both,
			new RoomObjectCategory[] { RoomDecoration, Stairs },
			new());

		public static readonly RoomObjectType Object0DD = new(0x0DD,
			RoomDraw_TableRock4x4_1to16, Both,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		public static readonly RoomObjectType Object0DE = new(0x0DE,
			RoomDraw_Spike2x2In4x4SuperSquare, Both,
			new RoomObjectCategory[] { Spikes },
			new());

		public static readonly RoomObjectType Object0DF = new(0x0DF,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { Spikes, Floor },
			new());

		public static readonly RoomObjectType Object0E0 = new(0x0E0,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { NoCollision, Floor },
			new());

		public static readonly RoomObjectType Object0E1 = new(0x0E1,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { NoCollision, Floor },
			new());

		public static readonly RoomObjectType Object0E2 = new(0x0E2,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { NoCollision, Floor },
			new());

		public static readonly RoomObjectType Object0E3 = new(0x0E3,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { NoCollision, Floor, Conveyor },
			new());

		public static readonly RoomObjectType Object0E4 = new(0x0E4,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { NoCollision, Floor, Conveyor },
			new());

		public static readonly RoomObjectType Object0E5 = new(0x0E5,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { NoCollision, Floor, Conveyor },
			new());

		public static readonly RoomObjectType Object0E6 = new(0x0E6,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { NoCollision, Floor, Conveyor },
			new());

		public static readonly RoomObjectType Object0E7 = new(0x0E7,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { NoCollision, Floor, Conveyor },
			new());

		public static readonly RoomObjectType Object0E8 = new(0x0E8,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object0E9 = new(0x0E9,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object0EA = new(0x0EA,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object0EB = new(0x0EB,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object0EC = new(0x0EC,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object0ED = new(0x0ED,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object0EE = new(0x0EE,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object0EF = new(0x0EF,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object0F0 = new(0x0F0,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object0F1 = new(0x0F1,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object0F2 = new(0x0F2,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object0F3 = new(0x0F3,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object0F4 = new(0x0F4,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object0F5 = new(0x0F5,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object0F6 = new(0x0F6,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object0F7 = new(0x0F7,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());




		public static readonly RoomObjectType Object100 = new(0x100,
			RoomDraw_4x4Object, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object101 = new(0x101,
			RoomDraw_4x4Object, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object102 = new(0x102,
			RoomDraw_4x4Object, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object103 = new(0x103,
			RoomDraw_4x4Object, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object104 = new(0x104,
			RoomDraw_4x4Object, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object105 = new(0x105,
			RoomDraw_4x4Object, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object106 = new(0x106,
			RoomDraw_4x4Object, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object107 = new(0x107,
			RoomDraw_4x4Object, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object108 = new(0x108,
			RoomDraw_4x4Corner_BothBG, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object109 = new(0x109,
			RoomDraw_4x4Corner_BothBG, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object10A = new(0x10A,
			RoomDraw_4x4Corner_BothBG, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object10B = new(0x10B,
			RoomDraw_4x4Corner_BothBG, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object10C = new(0x10C,
			RoomDraw_4x4Corner_BothBG, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object10D = new(0x10D,
			RoomDraw_4x4Corner_BothBG, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object10E = new(0x10E,
			RoomDraw_4x4Corner_BothBG, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object10F = new(0x10F,
			RoomDraw_4x4Corner_BothBG, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object110 = new(0x110,
			RoomDraw_WeirdCornerBottom_BothBG, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object111 = new(0x111,
			RoomDraw_WeirdCornerBottom_BothBG, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object112 = new(0x112,
			RoomDraw_WeirdCornerBottom_BothBG, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object113 = new(0x113,
			RoomDraw_WeirdCornerBottom_BothBG, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object114 = new(0x114,
			RoomDraw_WeirdCornerTop_BothBG, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object115 = new(0x115,
			RoomDraw_WeirdCornerTop_BothBG, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object116 = new(0x116,
			RoomDraw_WeirdCornerTop_BothBG, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object117 = new(0x117,
			RoomDraw_WeirdCornerTop_BothBG, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object118 = new(0x118,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object119 = new(0x119,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object11A = new(0x11A,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object11B = new(0x11B,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object11C = new(0x11C,
			RoomDraw_4x4Object, None,
			new RoomObjectCategory[] { Collision, Pits, RoomDecoration },
			new());

		public static readonly RoomObjectType Object11D = new(0x11D,
			RoomDraw_Single2x3Pillar, None,
			new RoomObjectCategory[] { Collision, RoomDecoration, Hookshottable },
			new());

		public static readonly RoomObjectType Object11E = new(0x11E,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { NoCollision, Pits },
			new());

		public static readonly RoomObjectType Object11F = new(0x11F,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { NoCollision, Pits },
			new());

		public static readonly RoomObjectType Object120 = new(0x120,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { Collision, RoomDecoration, Hookshottable },
			new());

		public static readonly RoomObjectType Object121 = new(0x121,
			RoomDraw_Single2x3Pillar, None,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		public static readonly RoomObjectType Object122 = new(0x122,
			RoomDraw_Bed4x5, None,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		public static readonly RoomObjectType Object123 = new(0x123,
			RoomDraw_4x3OneLayer, None,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		public static readonly RoomObjectType Object124 = new(0x124,
			RoomDraw_4x4Object, None,
			new RoomObjectCategory[] { Collision, WallDecoration },
			new());

		public static readonly RoomObjectType Object125 = new(0x125,
			RoomDraw_4x4Object, None,
			new RoomObjectCategory[] { Collision, WallDecoration },
			new());

		public static readonly RoomObjectType Object126 = new(0x126,
			RoomDraw_Single2x3Pillar, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object127 = new(0x127,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		public static readonly RoomObjectType Object128 = new(0x128,
			RoomDraw_YBed4x5, None,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		public static readonly RoomObjectType Object129 = new(0x129,
			RoomDraw_4x4Object, None,
			new RoomObjectCategory[] { Collision, WallDecoration },
			new());

		public static readonly RoomObjectType Object12A = new(0x12A,
			RoomDraw_PortraitOfMario, None,
			new RoomObjectCategory[] { Collision, WallDecoration, UpperLayer },
			new());

		public static readonly RoomObjectType Object12B = new(0x12B,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object12C = new(0x12C,
			RoomDraw_DrawRightwards3x6, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object12D = new(0x12D,
			RoomDraw_InterRoomFatStairs, None,
			new RoomObjectCategory[] { Stairs },
			new(),
			special: SpecialObjectType.InterroomStairs);

		public static readonly RoomObjectType Object12E = new(0x12E,
			RoomDraw_InterRoomFatStairs, None,
			new RoomObjectCategory[] { Stairs, RoomTransition },
			new(),
			special: SpecialObjectType.InterroomStairs);

		public static readonly RoomObjectType Object12F = new(0x12F,
			RoomDraw_InterRoomFatStairs, None,
			new RoomObjectCategory[] { Stairs, RoomTransition },
			new());

		public static readonly RoomObjectType Object130 = new(0x130,
			RoomDraw_AutoStairs, None,
			new RoomObjectCategory[] { Stairs },
			new());

		public static readonly RoomObjectType Object131 = new(0x131,
			RoomDraw_AutoStairs, None,
			new RoomObjectCategory[] { Stairs },
			new());

		public static readonly RoomObjectType Object132 = new(0x132,
			RoomDraw_AutoStairsMerged, None,
			new RoomObjectCategory[] { Stairs },
			new());

		public static readonly RoomObjectType Object133 = new(0x133,
			RoomDraw_AutoStairsMerged, None,
			new RoomObjectCategory[] { Stairs },
			new());

		public static readonly RoomObjectType Object134 = new(0x134,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { Collision, RoomDecoration, Hookshottable },
			new());

		public static readonly RoomObjectType Object135 = new(0x135,
			RoomDraw_WaterHopStairs_A, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object136 = new(0x136,
			RoomDraw_WaterHopStairs_B, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object137 = new(0x137,
			RoomDraw_DamFloodGate, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object138 = new(0x138,
			RoomDraw_SpiralStairs, None,
			new RoomObjectCategory[] { Stairs, RoomTransition },
			new(),
			special: SpecialObjectType.InterroomStairs);

		public static readonly RoomObjectType Object139 = new(0x139,
			RoomDraw_SpiralStairs, None,
			new RoomObjectCategory[] { Stairs, RoomTransition },
			new(),
			special: SpecialObjectType.InterroomStairs);

		public static readonly RoomObjectType Object13A = new(0x13A,
			RoomDraw_SpiralStairs, None,
			new RoomObjectCategory[] { Stairs, RoomTransition },
			new());

		public static readonly RoomObjectType Object13B = new(0x13B,
			RoomDraw_SpiralStairs, None,
			new RoomObjectCategory[] { Stairs, RoomTransition },
			new(),
			special: SpecialObjectType.InterroomStairs);

		public static readonly RoomObjectType Object13C = new(0x13C,
			RoomDraw_SanctuaryWall, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object13D = new(0x13D,
			RoomDraw_4x3OneLayer, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object13E = new(0x13E,
			RoomDraw_Utility6x3, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object13F = new(0x13F,
			RoomDraw_MagicBatAltar, None,
			new RoomObjectCategory[] { },
			new());




		public static readonly RoomObjectType Object200 = new(0x200,
			RoomDraw_EmptyWaterFace, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object201 = new(0x201,
			RoomDraw_SpittingWaterFace, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object202 = new(0x202,
			RoomDraw_DrenchingWaterFace, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object203 = new(0x203,
			RoomDraw_SomariaLine, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object204 = new(0x204,
			RoomDraw_SomariaLine, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object205 = new(0x205,
			RoomDraw_SomariaLine, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object206 = new(0x206,
			RoomDraw_SomariaLine, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object207 = new(0x207,
			RoomDraw_SomariaLine, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object208 = new(0x208,
			RoomDraw_SomariaLine, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object209 = new(0x209,
			RoomDraw_SomariaLine, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object20A = new(0x20A,
			RoomDraw_SomariaLine, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object20B = new(0x20B,
			RoomDraw_SomariaLine, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object20C = new(0x20C,
			RoomDraw_SomariaLine, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object20D = new(0x20D,
			RoomDraw_PrisonCell, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object20E = new(0x20E,
			RoomDraw_SomariaLine, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object20F = new(0x20F,
			RoomDraw_SomariaLine, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object210 = new(0x210,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object211 = new(0x211,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object212 = new(0x212,
			RoomDraw_RupeeFloor, None,
			new RoomObjectCategory[] { NoCollision, Floor, Secrets },
			new());

		public static readonly RoomObjectType Object213 = new(0x213,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { Collision, WallDecoration, Hookshottable },
			new());

		public static readonly RoomObjectType Object214 = new(0x214,
			RoomDraw_4x3OneLayer, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object215 = new(0x215,
			RoomDraw_KholdstareShell, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object216 = new(0x216,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { Collision, PuzzlePegs, Hookshottable, Manipulable },
			new(),
			limit: DungeonLimits.GeneralManipulable);

		public static readonly RoomObjectType Object217 = new(0x217,
			RoomDraw_PrisonCell, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object218 = new(0x218,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new(),
			special: SpecialObjectType.BigChest);

		public static readonly RoomObjectType Object219 = new(0x219,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { Collision, RoomDecoration, Secrets, Hookshottable },
			new(),
			special: SpecialObjectType.Chest);

		public static readonly RoomObjectType Object21A = new(0x21A,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { Collision, RoomDecoration, Hookshottable },
			new());

		public static readonly RoomObjectType Object21B = new(0x21B,
			RoomDraw_AutoStairs, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object21C = new(0x21C,
			RoomDraw_AutoStairs, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object21D = new(0x21D,
			RoomDraw_AutoStairs, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object21E = new(0x21E,
			RoomDraw_StraightInterroomStairs, None,
			new RoomObjectCategory[] { Stairs, RoomTransition },
			new());

		public static readonly RoomObjectType Object21F = new(0x21F,
			RoomDraw_StraightInterroomStairs, None,
			new RoomObjectCategory[] { Stairs, RoomTransition },
			new());

		public static readonly RoomObjectType Object220 = new(0x220,
			RoomDraw_StraightInterroomStairs, None,
			new RoomObjectCategory[] { Stairs, RoomTransition },
			new());

		public static readonly RoomObjectType Object221 = new(0x221,
			RoomDraw_StraightInterroomStairs, None,
			new RoomObjectCategory[] { Stairs, RoomTransition },
			new());

		public static readonly RoomObjectType Object222 = new(0x222,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object223 = new(0x223,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object224 = new(0x224,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object225 = new(0x225,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object226 = new(0x226,
			RoomDraw_StraightInterroomStairs, None,
			new RoomObjectCategory[] { Stairs, RoomTransition },
			new());

		public static readonly RoomObjectType Object227 = new(0x227,
			RoomDraw_StraightInterroomStairs, None,
			new RoomObjectCategory[] { Stairs, RoomTransition },
			new());

		public static readonly RoomObjectType Object228 = new(0x228,
			RoomDraw_StraightInterroomStairs, None,
			new RoomObjectCategory[] { Stairs, RoomTransition },
			new());

		public static readonly RoomObjectType Object229 = new(0x229,
			RoomDraw_StraightInterroomStairs, None,
			new RoomObjectCategory[] { Stairs, RoomTransition },
			new());

		public static readonly RoomObjectType Object22A = new(0x22A,
			RoomDraw_LampCones, None,
			new RoomObjectCategory[] { LowerLayer },
			new());

		public static readonly RoomObjectType Object22B = new(0x22B,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object22C = new(0x22C,
			RoomDraw_BigGrayRock, None,
			new RoomObjectCategory[] { Collision, RoomDecoration, Secrets, Manipulable, Hookshottable },
			new(),
			limit: DungeonLimits.GeneralManipulable4x);

		public static readonly RoomObjectType Object22D = new(0x22D,
			RoomDraw_AgahnimsAltar, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object22E = new(0x22E,
			RoomDraw_AgahnimsWindows, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object22F = new(0x22F,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { Collision, RoomDecoration, Secrets, Manipulable, Hookshottable },
			new(),
			limit: DungeonLimits.GeneralManipulable);

		public static readonly RoomObjectType Object230 = new(0x230,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object231 = new(0x231,
			RoomDraw_4x3OneLayer, None,
			new RoomObjectCategory[] { Collision, RoomDecoration, Secrets, Hookshottable },
			new(),
			special: SpecialObjectType.BigChest);

		public static readonly RoomObjectType Object232 = new(0x232,
			RoomDraw_4x3OneLayer, None,
			new RoomObjectCategory[] { Collision, RoomDecoration, Hookshottable },
			new());

		public static readonly RoomObjectType Object233 = new(0x233,
			RoomDraw_AutoStairs, None,
			new RoomObjectCategory[] { Stairs },
			new());

		public static readonly RoomObjectType Object234 = new(0x234,
			RoomDraw_ChestPlatformVerticalWall, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object235 = new(0x235,
			RoomDraw_ChestPlatformVerticalWall, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object236 = new(0x236,
			RoomDraw_DrawRightwards3x6, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object237 = new(0x237,
			RoomDraw_DrawRightwards3x6, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object238 = new(0x238,
			RoomDraw_ChestPlatformVerticalWall, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object239 = new(0x239,
			RoomDraw_ChestPlatformVerticalWall, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object23A = new(0x23A,
			RoomDraw_VerticalTurtleRockPipe, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object23B = new(0x23B,
			RoomDraw_VerticalTurtleRockPipe, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object23C = new(0x23C,
			RoomDraw_HorizontalTurtleRockPipe, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object23D = new(0x23D,
			RoomDraw_HorizontalTurtleRockPipe, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object23E = new(0x23E,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object23F = new(0x23F,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object240 = new(0x240,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object241 = new(0x241,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object242 = new(0x242,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object243 = new(0x243,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object244 = new(0x244,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object245 = new(0x245,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object246 = new(0x246,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object247 = new(0x247,
			RoomDraw_BombableFloor, None,
			new RoomObjectCategory[] { NoCollision, Floor, Pits, Manipulable },
			new(),
			limit: DungeonLimits.GeneralManipulable4x);

		public static readonly RoomObjectType Object248 = new(0x248,
			RoomDraw_4x4Object, None,
			new RoomObjectCategory[] { NoCollision, Floor },
			new());

		public static readonly RoomObjectType Object249 = new(0x249,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object24A = new(0x24A,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { RoomTransition },
			new());

		public static readonly RoomObjectType Object24B = new(0x24B,
			RoomDraw_BigWallDecor, None,
			new RoomObjectCategory[] { Collision, WallDecoration, NorthSide },
			new());

		public static readonly RoomObjectType Object24C = new(0x24C,
			RoomDraw_SmithyFurnace, None,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		public static readonly RoomObjectType Object24D = new(0x24D,
			RoomDraw_Utility6x3, None,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		public static readonly RoomObjectType Object24E = new(0x24E,
			RoomDraw_4x3OneLayer, None,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		public static readonly RoomObjectType Object24F = new(0x24F,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { NoCollision, Floor },
			new());

		public static readonly RoomObjectType Object250 = new(0x250,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object251 = new(0x251,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object252 = new(0x252,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { Collision, PuzzlePegs, Hookshottable },
			new());

		public static readonly RoomObjectType Object253 = new(0x253,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { Collision, PuzzlePegs, Hookshottable },
			new());

		public static readonly RoomObjectType Object254 = new(0x254,
			RoomDraw_FortuneTellerRoom, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object255 = new(0x255,
			RoomDraw_Utility3x5, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object256 = new(0x256,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		public static readonly RoomObjectType Object257 = new(0x257,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		public static readonly RoomObjectType Object258 = new(0x258,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		public static readonly RoomObjectType Object259 = new(0x259,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		public static readonly RoomObjectType Object25A = new(0x25A,
			RoomDraw_TableBowl, None,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		public static readonly RoomObjectType Object25B = new(0x25B,
			RoomDraw_Utility3x5, None,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		public static readonly RoomObjectType Object25C = new(0x25C,
			RoomDraw_HorizontalTurtleRockPipe, None,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		public static readonly RoomObjectType Object25D = new(0x25D,
			RoomDraw_Utility6x3, None,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		public static readonly RoomObjectType Object25E = new(0x25E,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		public static readonly RoomObjectType Object25F = new(0x25F,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		public static readonly RoomObjectType Object260 = new(0x260,
			RoomDraw_ArcheryGameTargetDoor, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object261 = new(0x261,
			RoomDraw_ArcheryGameTargetDoor, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object262 = new(0x262,
			RoomDraw_VitreousGooGraphics, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object263 = new(0x263,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object264 = new(0x264,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		public static readonly RoomObjectType Object265 = new(0x265,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		public static readonly RoomObjectType Object266 = new(0x266,
			RoomDraw_4x4Object, None,
			new RoomObjectCategory[] { Pits },
			new());

		public static readonly RoomObjectType Object267 = new(0x267,
			RoomDraw_4x3OneLayer, None,
			new RoomObjectCategory[] { Collision, WallDecoration, NorthSide, UpperLayer },
			new());

		public static readonly RoomObjectType Object268 = new(0x268,
			RoomDraw_4x3OneLayer, None,
			new RoomObjectCategory[] { Collision, WallDecoration, SouthSide, UpperLayer },
			new());

		public static readonly RoomObjectType Object269 = new(0x269,
			RoomDraw_SolidWallDecor3x4, None,
			new RoomObjectCategory[] { Collision, WallDecoration, WestSide, UpperLayer },
			new());

		public static readonly RoomObjectType Object26A = new(0x26A,
			RoomDraw_SolidWallDecor3x4, None,
			new RoomObjectCategory[] { Collision, WallDecoration, EastSide, UpperLayer },
			new());

		public static readonly RoomObjectType Object26B = new(0x26B,
			RoomDraw_4x4Object, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object26C = new(0x26C,
			RoomDraw_4x3OneLayer, None,
			new RoomObjectCategory[] { Collision, WallDecoration, NorthSide },
			new());

		public static readonly RoomObjectType Object26D = new(0x26D,
			RoomDraw_4x3OneLayer, None,
			new RoomObjectCategory[] { Collision, WallDecoration, SouthSide },
			new());

		public static readonly RoomObjectType Object26E = new(0x26E,
			RoomDraw_SolidWallDecor3x4, None,
			new RoomObjectCategory[] { Collision, WallDecoration, WestSide },
			new());

		public static readonly RoomObjectType Object26F = new(0x26F,
			RoomDraw_SolidWallDecor3x4, None,
			new RoomObjectCategory[] { Collision, WallDecoration, EastSide },
			new());

		public static readonly RoomObjectType Object270 = new(0x270,
			RoomDraw_LightBeamOnFloor, None,
			new RoomObjectCategory[] { NoCollision, Floor },
			new());

		public static readonly RoomObjectType Object271 = new(0x271,
			RoomDraw_BigLightBeamOnFloor, None,
			new RoomObjectCategory[] { NoCollision, Floor },
			new());

		public static readonly RoomObjectType Object272 = new(0x272,
			RoomDraw_TrinexxShell, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object273 = new(0x273,
			RoomDraw_BG2MaskFull, None,
			new RoomObjectCategory[] { },
			new());

		public static readonly RoomObjectType Object274 = new(0x274,
			RoomDraw_FloorLight, None,
			new RoomObjectCategory[] { Collision, WallDecoration, NorthSide, Hookshottable },
			new());

		public static readonly RoomObjectType Object275 = new(0x275,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { Collision, RoomDecoration, Secrets, Hookshottable },
			new());

		public static readonly RoomObjectType Object276 = new(0x276,
			RoomDraw_BigWallDecor, None,
			new RoomObjectCategory[] { Collision, WallDecoration, NorthSide },
			new());

		public static readonly RoomObjectType Object277 = new(0x277,
			RoomDraw_BigWallDecor, None,
			new RoomObjectCategory[] { Collision, WallDecoration, NorthSide },
			new());

		public static readonly RoomObjectType Object278 = new(0x278,
			RoomDraw_GanonTriforceFloorDecor, None,
			new RoomObjectCategory[] { NoCollision, Floor },
			new());

		public static readonly RoomObjectType Object279 = new(0x279,
			RoomDraw_4x3OneLayer, None,
			new RoomObjectCategory[] { Collision, WallDecoration, NorthSide },
			new());

		public static readonly RoomObjectType Object27A = new(0x27A,
			RoomDraw_4x4Object, None,
			new RoomObjectCategory[] { NoCollision, Floor },
			new());

		public static readonly RoomObjectType Object27B = new(0x27B,
			RoomDraw_VitreousGooDamage, None,
			new RoomObjectCategory[] { Spikes },
			new());

		public static readonly RoomObjectType Object27C = new(0x27C,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { NoCollision, Floor },
			new());

		public static readonly RoomObjectType Object27D = new(0x27D,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { NoCollision, Floor },
			new());

		public static readonly RoomObjectType Object27E = new(0x27E,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { NoCollision, Floor },
			new());

		public static readonly RoomObjectType Object27F = new(0x27F,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		public static RoomObjectType GetTypeFromID(int id)
		{
			return id switch
			{
				0x000 => Object000,
				0x001 => Object001,
				0x002 => Object002,
				0x003 => Object003,
				0x004 => Object004,
				0x005 => Object005,
				0x006 => Object006,
				0x007 => Object007,
				0x008 => Object008,
				0x009 => Object009,
				0x00A => Object00A,
				0x00B => Object00B,
				0x00C => Object00C,
				0x00D => Object00D,
				0x00E => Object00E,
				0x00F => Object00F,
				0x010 => Object010,
				0x011 => Object011,
				0x012 => Object012,
				0x013 => Object013,
				0x014 => Object014,
				0x015 => Object015,
				0x016 => Object016,
				0x017 => Object017,
				0x018 => Object018,
				0x019 => Object019,
				0x01A => Object01A,
				0x01B => Object01B,
				0x01C => Object01C,
				0x01D => Object01D,
				0x01E => Object01E,
				0x01F => Object01F,
				0x020 => Object020,
				0x021 => Object021,
				0x022 => Object022,
				0x023 => Object023,
				0x024 => Object024,
				0x025 => Object025,
				0x026 => Object026,
				0x027 => Object027,
				0x028 => Object028,
				0x029 => Object029,
				0x02A => Object02A,
				0x02B => Object02B,
				0x02C => Object02C,
				0x02D => Object02D,
				0x02E => Object02E,
				0x02F => Object02F,
				0x030 => Object030,
				0x031 => Object031,
				0x032 => Object032,
				0x033 => Object033,
				0x034 => Object034,
				0x035 => Object035,
				0x036 => Object036,
				0x037 => Object037,
				0x038 => Object038,
				0x039 => Object039,
				0x03A => Object03A,
				0x03B => Object03B,
				0x03C => Object03C,
				0x03D => Object03D,
				0x03E => Object03E,
				0x03F => Object03F,
				0x040 => Object040,
				0x041 => Object041,
				0x042 => Object042,
				0x043 => Object043,
				0x044 => Object044,
				0x045 => Object045,
				0x046 => Object046,
				0x047 => Object047,
				0x048 => Object048,
				0x049 => Object049,
				0x04A => Object04A,
				0x04B => Object04B,
				0x04C => Object04C,
				0x04D => Object04D,
				0x04E => Object04E,
				0x04F => Object04F,
				0x050 => Object050,
				0x051 => Object051,
				0x052 => Object052,
				0x053 => Object053,
				0x054 => Object054,
				0x055 => Object055,
				0x056 => Object056,
				0x057 => Object057,
				0x058 => Object058,
				0x059 => Object059,
				0x05A => Object05A,
				0x05B => Object05B,
				0x05C => Object05C,
				0x05D => Object05D,
				0x05E => Object05E,
				0x05F => Object05F,
				0x060 => Object060,
				0x061 => Object061,
				0x062 => Object062,
				0x063 => Object063,
				0x064 => Object064,
				0x065 => Object065,
				0x066 => Object066,
				0x067 => Object067,
				0x068 => Object068,
				0x069 => Object069,
				0x06A => Object06A,
				0x06B => Object06B,
				0x06C => Object06C,
				0x06D => Object06D,
				0x06E => Object06E,
				0x06F => Object06F,
				0x070 => Object070,
				0x071 => Object071,
				0x072 => Object072,
				0x073 => Object073,
				0x074 => Object074,
				0x075 => Object075,
				0x076 => Object076,
				0x077 => Object077,
				0x078 => Object078,
				0x079 => Object079,
				0x07A => Object07A,
				0x07B => Object07B,
				0x07C => Object07C,
				0x07D => Object07D,
				0x07E => Object07E,
				0x07F => Object07F,
				0x080 => Object080,
				0x081 => Object081,
				0x082 => Object082,
				0x083 => Object083,
				0x084 => Object084,
				0x085 => Object085,
				0x086 => Object086,
				0x087 => Object087,
				0x088 => Object088,
				0x089 => Object089,
				0x08A => Object08A,
				0x08B => Object08B,
				0x08C => Object08C,
				0x08D => Object08D,
				0x08E => Object08E,
				0x08F => Object08F,
				0x090 => Object090,
				0x091 => Object091,
				0x092 => Object092,
				0x093 => Object093,
				0x094 => Object094,
				0x095 => Object095,
				0x096 => Object096,
				0x097 => Object097,
				0x098 => Object098,
				0x099 => Object099,
				0x09A => Object09A,
				0x09B => Object09B,
				0x09C => Object09C,
				0x09D => Object09D,
				0x09E => Object09E,
				0x09F => Object09F,
				0x0A0 => Object0A0,
				0x0A1 => Object0A1,
				0x0A2 => Object0A2,
				0x0A3 => Object0A3,
				0x0A4 => Object0A4,
				0x0A5 => Object0A5,
				0x0A6 => Object0A6,
				0x0A7 => Object0A7,
				0x0A8 => Object0A8,
				0x0A9 => Object0A9,
				0x0AA => Object0AA,
				0x0AB => Object0AB,
				0x0AC => Object0AC,
				0x0AD => Object0AD,
				0x0AE => Object0AE,
				0x0AF => Object0AF,
				0x0B0 => Object0B0,
				0x0B1 => Object0B1,
				0x0B2 => Object0B2,
				0x0B3 => Object0B3,
				0x0B4 => Object0B4,
				0x0B5 => Object0B5,
				0x0B6 => Object0B6,
				0x0B7 => Object0B7,
				0x0B8 => Object0B8,
				0x0B9 => Object0B9,
				0x0BA => Object0BA,
				0x0BB => Object0BB,
				0x0BC => Object0BC,
				0x0BD => Object0BD,
				0x0BE => Object0BE,
				0x0BF => Object0BF,
				0x0C0 => Object0C0,
				0x0C1 => Object0C1,
				0x0C2 => Object0C2,
				0x0C3 => Object0C3,
				0x0C4 => Object0C4,
				0x0C5 => Object0C5,
				0x0C6 => Object0C6,
				0x0C7 => Object0C7,
				0x0C8 => Object0C8,
				0x0C9 => Object0C9,
				0x0CA => Object0CA,
				0x0CB => Object0CB,
				0x0CC => Object0CC,
				0x0CD => Object0CD,
				0x0CE => Object0CE,
				0x0CF => Object0CF,
				0x0D0 => Object0D0,
				0x0D1 => Object0D1,
				0x0D2 => Object0D2,
				0x0D3 => Object0D3,
				0x0D4 => Object0D4,
				0x0D5 => Object0D5,
				0x0D6 => Object0D6,
				0x0D7 => Object0D7,
				0x0D8 => Object0D8,
				0x0D9 => Object0D9,
				0x0DA => Object0DA,
				0x0DB => Object0DB,
				0x0DC => Object0DC,
				0x0DD => Object0DD,
				0x0DE => Object0DE,
				0x0DF => Object0DF,
				0x0E0 => Object0E0,
				0x0E1 => Object0E1,
				0x0E2 => Object0E2,
				0x0E3 => Object0E3,
				0x0E4 => Object0E4,
				0x0E5 => Object0E5,
				0x0E6 => Object0E6,
				0x0E7 => Object0E7,
				0x0E8 => Object0E8,
				0x0E9 => Object0E9,
				0x0EA => Object0EA,
				0x0EB => Object0EB,
				0x0EC => Object0EC,
				0x0ED => Object0ED,
				0x0EE => Object0EE,
				0x0EF => Object0EF,
				0x0F0 => Object0F0,
				0x0F1 => Object0F1,
				0x0F2 => Object0F2,
				0x0F3 => Object0F3,
				0x0F4 => Object0F4,
				0x0F5 => Object0F5,
				0x0F6 => Object0F6,
				0x0F7 => Object0F7,
				0x100 => Object100,
				0x101 => Object101,
				0x102 => Object102,
				0x103 => Object103,
				0x104 => Object104,
				0x105 => Object105,
				0x106 => Object106,
				0x107 => Object107,
				0x108 => Object108,
				0x109 => Object109,
				0x10A => Object10A,
				0x10B => Object10B,
				0x10C => Object10C,
				0x10D => Object10D,
				0x10E => Object10E,
				0x10F => Object10F,
				0x110 => Object110,
				0x111 => Object111,
				0x112 => Object112,
				0x113 => Object113,
				0x114 => Object114,
				0x115 => Object115,
				0x116 => Object116,
				0x117 => Object117,
				0x118 => Object118,
				0x119 => Object119,
				0x11A => Object11A,
				0x11B => Object11B,
				0x11C => Object11C,
				0x11D => Object11D,
				0x11E => Object11E,
				0x11F => Object11F,
				0x120 => Object120,
				0x121 => Object121,
				0x122 => Object122,
				0x123 => Object123,
				0x124 => Object124,
				0x125 => Object125,
				0x126 => Object126,
				0x127 => Object127,
				0x128 => Object128,
				0x129 => Object129,
				0x12A => Object12A,
				0x12B => Object12B,
				0x12C => Object12C,
				0x12D => Object12D,
				0x12E => Object12E,
				0x12F => Object12F,
				0x130 => Object130,
				0x131 => Object131,
				0x132 => Object132,
				0x133 => Object133,
				0x134 => Object134,
				0x135 => Object135,
				0x136 => Object136,
				0x137 => Object137,
				0x138 => Object138,
				0x139 => Object139,
				0x13A => Object13A,
				0x13B => Object13B,
				0x13C => Object13C,
				0x13D => Object13D,
				0x13E => Object13E,
				0x13F => Object13F,
				0x200 => Object200,
				0x201 => Object201,
				0x202 => Object202,
				0x203 => Object203,
				0x204 => Object204,
				0x205 => Object205,
				0x206 => Object206,
				0x207 => Object207,
				0x208 => Object208,
				0x209 => Object209,
				0x20A => Object20A,
				0x20B => Object20B,
				0x20C => Object20C,
				0x20D => Object20D,
				0x20E => Object20E,
				0x20F => Object20F,
				0x210 => Object210,
				0x211 => Object211,
				0x212 => Object212,
				0x213 => Object213,
				0x214 => Object214,
				0x215 => Object215,
				0x216 => Object216,
				0x217 => Object217,
				0x218 => Object218,
				0x219 => Object219,
				0x21A => Object21A,
				0x21B => Object21B,
				0x21C => Object21C,
				0x21D => Object21D,
				0x21E => Object21E,
				0x21F => Object21F,
				0x220 => Object220,
				0x221 => Object221,
				0x222 => Object222,
				0x223 => Object223,
				0x224 => Object224,
				0x225 => Object225,
				0x226 => Object226,
				0x227 => Object227,
				0x228 => Object228,
				0x229 => Object229,
				0x22A => Object22A,
				0x22B => Object22B,
				0x22C => Object22C,
				0x22D => Object22D,
				0x22E => Object22E,
				0x22F => Object22F,
				0x230 => Object230,
				0x231 => Object231,
				0x232 => Object232,
				0x233 => Object233,
				0x234 => Object234,
				0x235 => Object235,
				0x236 => Object236,
				0x237 => Object237,
				0x238 => Object238,
				0x239 => Object239,
				0x23A => Object23A,
				0x23B => Object23B,
				0x23C => Object23C,
				0x23D => Object23D,
				0x23E => Object23E,
				0x23F => Object23F,
				0x240 => Object240,
				0x241 => Object241,
				0x242 => Object242,
				0x243 => Object243,
				0x244 => Object244,
				0x245 => Object245,
				0x246 => Object246,
				0x247 => Object247,
				0x248 => Object248,
				0x249 => Object249,
				0x24A => Object24A,
				0x24B => Object24B,
				0x24C => Object24C,
				0x24D => Object24D,
				0x24E => Object24E,
				0x24F => Object24F,
				0x250 => Object250,
				0x251 => Object251,
				0x252 => Object252,
				0x253 => Object253,
				0x254 => Object254,
				0x255 => Object255,
				0x256 => Object256,
				0x257 => Object257,
				0x258 => Object258,
				0x259 => Object259,
				0x25A => Object25A,
				0x25B => Object25B,
				0x25C => Object25C,
				0x25D => Object25D,
				0x25E => Object25E,
				0x25F => Object25F,
				0x260 => Object260,
				0x261 => Object261,
				0x262 => Object262,
				0x263 => Object263,
				0x264 => Object264,
				0x265 => Object265,
				0x266 => Object266,
				0x267 => Object267,
				0x268 => Object268,
				0x269 => Object269,
				0x26A => Object26A,
				0x26B => Object26B,
				0x26C => Object26C,
				0x26D => Object26D,
				0x26E => Object26E,
				0x26F => Object26F,
				0x270 => Object270,
				0x271 => Object271,
				0x272 => Object272,
				0x273 => Object273,
				0x274 => Object274,
				0x275 => Object275,
				0x276 => Object276,
				0x277 => Object277,
				0x278 => Object278,
				0x279 => Object279,
				0x27A => Object27A,
				0x27B => Object27B,
				0x27C => Object27C,
				0x27D => Object27D,
				0x27E => Object27E,
				0x27F => Object27F,
				_ => null,
			};
		}
	}
}
