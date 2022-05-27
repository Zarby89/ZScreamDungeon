using static ZeldaFullEditor.Modeling.Underworld.ObjectResizability;
using static ZeldaFullEditor.Modeling.Underworld.RoomObjectCategory;

namespace ZeldaFullEditor.Data
{
	public partial class RoomObjectType : IEntityType<RoomObjectType>
	{
		public string Name { get; init; }
		public ObjectSubtype ObjectSet { get; }
		public ObjectResizability Resizeability { get; }

		public DrawObject Draw { get; }

		public ObjectSpecialType Specialness { get; }

		public DungeonLimits LimitClass { get; }

		/// <summary>
		/// What tile sets this object doesn't look like garbage in
		/// </summary>
		public RequiredGraphicsSheets RequiredSheets { get; }

		public ImmutableArray<RoomObjectCategory> Categories { get; }

		public bool IsCompletelyInvisible => Draw == RoomDraw_Nothing;

		public ushort FullID { get; init; }
		public int ListID => FullID;


		private RoomObjectType(ushort objectid, DrawObject drawfunc, ObjectResizability resizing, RoomObjectCategory[] categories, RequiredGraphicsSheets gsets,
			ObjectSpecialType special = ObjectSpecialType.None, DungeonLimits limit = DungeonLimits.None)
		{
			ObjectSet = (ObjectSubtype) (objectid >> 8);
			FullID = objectid;

			string name = ObjectSet switch
			{
				ObjectSubtype.Subtype1 => DefaultEntities.ListOfSubtype1RoomObjects[(byte) objectid].Name,
				ObjectSubtype.Subtype2 => DefaultEntities.ListOfSubtype2RoomObjects[(byte) objectid].Name,
				ObjectSubtype.Subtype3 => DefaultEntities.ListOfSubtype3RoomObjects[(byte) objectid].Name,
				_ => "PROBLEM",
			};

			Name = name;
			Resizeability = resizing;
			Specialness = special;
			Categories = categories.ToImmutableArray();
			RequiredSheets = gsets;
			LimitClass = limit;
			Draw = drawfunc;
		}

		public override string ToString() => $"{FullID:X3} {Name}";

		public static ImmutableArray<RoomObjectType> ListOf { get; }

		// Need to use static constructor for reflection to work properly
		static RoomObjectType()
		{
			ListOf = Utils.GetSortedListOfPredefinedFields<RoomObjectType>();
		}

		public static RoomObjectType GetTypeFromID(int id) => ListOf.GetTypeFromID(id);

#pragma warning disable CA1825 // Avoid zero-length array allocations


		/*
		 * All room object defaults
		 */
		[PredefinedInstance]
		public static readonly RoomObjectType Object000 = new(0x000,
			RoomDraw_Rightwards2x2_1to15or32, Horizontal,
			new RoomObjectCategory[] { Collision, Ceiling },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object001 = new(0x001,
			RoomDraw_Rightwards2x4_1to15or26, Horizontal,
			new RoomObjectCategory[] { Collision, Wall, NorthSide },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object002 = new(0x002,
			RoomDraw_Rightwards2x4_1to15or26, Horizontal,
			new RoomObjectCategory[] { Collision, Wall, SouthSide },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object003 = new(0x003,
			RoomDraw_Rightwards2x4spaced4_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, Wall, NorthSide, Ledge, LowerLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object004 = new(0x004,
			RoomDraw_Rightwards2x4spaced4_1to16, Horizontal,
			new[] { Collision, Wall, SouthSide, Ledge, LowerLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object005 = new(0x005,
			RoomDraw_Rightwards2x4spaced4_1to16_BothBG, Horizontal,
			new RoomObjectCategory[] { Collision, WallDecoration, NorthSide },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object006 = new(0x006,
			RoomDraw_Rightwards2x4spaced4_1to16_BothBG, Horizontal,
			new RoomObjectCategory[] { Collision, WallDecoration, SouthSide },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object007 = new(0x007,
			RoomDraw_Rightwards2x2_1to16, Horizontal,
			new RoomObjectCategory[] { Pit, NorthSide },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object008 = new(0x008,
			RoomDraw_Rightwards2x2_1to16, Horizontal,
			new RoomObjectCategory[] { Pit, SouthSide },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object009 = new(0x009,
			RoomDraw_DiagonalAcute_1to16, Horizontal,
			new RoomObjectCategory[] { DiagonalCollision, Wall, NorthSide, WestSide, UpperLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object00A = new(0x00A,
			RoomDraw_DiagonalGrave_1to16, Horizontal,
			new RoomObjectCategory[] { DiagonalCollision, Wall, SouthSide, WestSide, UpperLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object00B = new(0x00B,
			RoomDraw_DiagonalGrave_1to16, Horizontal,
			new RoomObjectCategory[] { DiagonalCollision, Wall, NorthSide, EastSide, UpperLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object00C = new(0x00C,
			RoomDraw_DiagonalAcute_1to16, Horizontal,
			new RoomObjectCategory[] { DiagonalCollision, Wall, SouthSide, EastSide, UpperLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object00D = new(0x00D,
			RoomDraw_DiagonalAcute_1to16, Horizontal,
			new RoomObjectCategory[] { DiagonalCollision, Wall, NorthSide, WestSide, UpperLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object00E = new(0x00E,
			RoomDraw_DiagonalGrave_1to16, Horizontal,
			new RoomObjectCategory[] { DiagonalCollision, Wall, SouthSide, WestSide, UpperLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object00F = new(0x00F,
			RoomDraw_DiagonalGrave_1to16, Horizontal,
			new RoomObjectCategory[] { DiagonalCollision, Wall, NorthSide, EastSide, UpperLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object010 = new(0x010,
			RoomDraw_DiagonalAcute_1to16, Horizontal,
			new RoomObjectCategory[] { DiagonalCollision, Wall, SouthSide, EastSide, UpperLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object011 = new(0x011,
			RoomDraw_DiagonalAcute_1to16, Horizontal,
			new RoomObjectCategory[] { DiagonalCollision, Wall, NorthSide, WestSide, UpperLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object012 = new(0x012,
			RoomDraw_DiagonalGrave_1to16, Horizontal,
			new RoomObjectCategory[] { DiagonalCollision, Wall, SouthSide, WestSide, UpperLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object013 = new(0x013,
			RoomDraw_DiagonalGrave_1to16, Horizontal,
			new RoomObjectCategory[] { DiagonalCollision, Wall, NorthSide, EastSide, UpperLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object014 = new(0x014,
			RoomDraw_DiagonalAcute_1to16, Horizontal,
			new RoomObjectCategory[] { DiagonalCollision, Wall, SouthSide, EastSide, UpperLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object015 = new(0x015,
			RoomDraw_DiagonalAcute_1to16_BothBG, Horizontal,
			new RoomObjectCategory[] { DiagonalCollision, Wall, NorthSide, WestSide, LowerLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object016 = new(0x016,
			RoomDraw_DiagonalGrave_1to16_BothBG, Horizontal,
			new RoomObjectCategory[] { DiagonalCollision, Wall, SouthSide, WestSide, LowerLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object017 = new(0x017,
			RoomDraw_DiagonalGrave_1to16_BothBG, Horizontal,
			new RoomObjectCategory[] { DiagonalCollision, Wall, NorthSide, EastSide, LowerLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object018 = new(0x018,
			RoomDraw_DiagonalAcute_1to16_BothBG, Horizontal,
			new RoomObjectCategory[] { DiagonalCollision, Wall, SouthSide, EastSide, LowerLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object019 = new(0x019,
			RoomDraw_DiagonalAcute_1to16_BothBG, Horizontal,
			new RoomObjectCategory[] { DiagonalCollision, Wall, NorthSide, WestSide, LowerLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object01A = new(0x01A,
			RoomDraw_DiagonalGrave_1to16_BothBG, Horizontal,
			new RoomObjectCategory[] { DiagonalCollision, Wall, SouthSide, WestSide, LowerLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object01B = new(0x01B,
			RoomDraw_DiagonalGrave_1to16_BothBG, Horizontal,
			new RoomObjectCategory[] { DiagonalCollision, Wall, NorthSide, EastSide, LowerLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object01C = new(0x01C,
			RoomDraw_DiagonalAcute_1to16_BothBG, Horizontal,
			new RoomObjectCategory[] { DiagonalCollision, Wall, SouthSide, EastSide, LowerLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object01D = new(0x01D,
			RoomDraw_DiagonalAcute_1to16_BothBG, Horizontal,
			new RoomObjectCategory[] { DiagonalCollision, Wall, NorthSide, WestSide, LowerLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object01E = new(0x01E,
			RoomDraw_DiagonalGrave_1to16_BothBG, Horizontal,
			new RoomObjectCategory[] { DiagonalCollision, Wall, SouthSide, WestSide, LowerLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object01F = new(0x01F,
			RoomDraw_DiagonalGrave_1to16_BothBG, Horizontal,
			new RoomObjectCategory[] { DiagonalCollision, Wall, NorthSide, EastSide, LowerLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object020 = new(0x020,
			RoomDraw_DiagonalAcute_1to16_BothBG, Horizontal,
			new RoomObjectCategory[] { DiagonalCollision, Wall, SouthSide, EastSide, LowerLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object021 = new(0x021,
			RoomDraw_Rightwards1x2_1to16_plus2, Horizontal,
			new RoomObjectCategory[] { Stairs },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object022 = new(0x022,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus3, Horizontal,
			new RoomObjectCategory[] { Collision },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object023 = new(0x023,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new RoomObjectCategory[] { Pit },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object024 = new(0x024,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new RoomObjectCategory[] { Pit },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object025 = new(0x025,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new RoomObjectCategory[] { Pit },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object026 = new(0x026,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new RoomObjectCategory[] { Pit },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object027 = new(0x027,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new RoomObjectCategory[] { Pit },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object028 = new(0x028,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new RoomObjectCategory[] { Pit },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object029 = new(0x029,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new RoomObjectCategory[] { Pit },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object02A = new(0x02A,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new RoomObjectCategory[] { Pit },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object02B = new(0x02B,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new RoomObjectCategory[] { Pit },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object02C = new(0x02C,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new RoomObjectCategory[] { Pit },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object02D = new(0x02D,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new RoomObjectCategory[] { Pit },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object02E = new(0x02E,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new RoomObjectCategory[] { Pit },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object02F = new(0x02F,
			RoomDraw_RightwardsWithCorners1x2_1to16_plus13, Horizontal,
			new RoomObjectCategory[] { Collision, Ledge, Wall, NorthSide, SouthSide, UpperLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object030 = new(0x030,
			RoomDraw_RightwardsWithCorners1x2_1to16_plus13, Horizontal,
			new RoomObjectCategory[] { Collision, Ledge, Wall, NorthSide, SouthSide, UpperLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object031 = new(0x031,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object032 = new(0x032,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object033 = new(0x033,
			RoomDraw_Rightwards4x4_1to16, Horizontal,
			new RoomObjectCategory[] { NoCollision, Floor, RoomDecoration },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object034 = new(0x034,
			RoomDraw_Rightwards1x1Solid_1to16_plus3, Horizontal,
			new RoomObjectCategory[] { NoCollision, Floor, RoomDecoration, NorthSide, SouthSide },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object035 = new(0x035,
			RoomDraw_DoorSwitcherer, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object036 = new(0x036,
			RoomDraw_RightwardsDecor4x4spaced2_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, WallDecoration, NorthSide, UpperLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object037 = new(0x037,
			RoomDraw_RightwardsDecor4x4spaced2_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, WallDecoration, SouthSide, UpperLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object038 = new(0x038,
			RoomDraw_RightwardsStatue2x3spaced2_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, RoomDecoration, Hookshottable },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object039 = new(0x039,
			RoomDraw_RightwardsPillar2x4spaced4_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object03A = new(0x03A,
			RoomDraw_RightwardsDecor4x3spaced4_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, WallDecoration, NorthSide, UpperLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object03B = new(0x03B,
			RoomDraw_RightwardsDecor4x3spaced4_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, WallDecoration, SouthSide, UpperLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object03C = new(0x03C,
			RoomDraw_RightwardsDoubled2x2spaced2_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object03D = new(0x03D,
			RoomDraw_RightwardsPillar2x4spaced4_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, RoomDecoration, Hookshottable },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object03E = new(0x03E,
			RoomDraw_RightwardsDecor2x2spaced12_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, WallDecoration, NorthSide, UpperLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object03F = new(0x03F,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new RoomObjectCategory[] { ShallowWater },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object040 = new(0x040,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new RoomObjectCategory[] { ShallowWater },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object041 = new(0x041,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new RoomObjectCategory[] { ShallowWater },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object042 = new(0x042,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new RoomObjectCategory[] { ShallowWater },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object043 = new(0x043,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new RoomObjectCategory[] { ShallowWater },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object044 = new(0x044,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new RoomObjectCategory[] { ShallowWater },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object045 = new(0x045,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new RoomObjectCategory[] { ShallowWater },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object046 = new(0x046,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new RoomObjectCategory[] { ShallowWater },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object047 = new(0x047,
			RoomDraw_Waterfall47, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object048 = new(0x048,
			RoomDraw_Waterfall48, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object049 = new(0x049,
			RoomDraw_RightwardsFloorTile4x2_1to16, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object04A = new(0x04A,
			RoomDraw_RightwardsFloorTile4x2_1to16, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object04B = new(0x04B,
			RoomDraw_RightwardsDecor2x2spaced12_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, WallDecoration, SouthSide, UpperLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object04C = new(0x04C,
			RoomDraw_RightwardsBar4x3_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object04D = new(0x04D,
			RoomDraw_RightwardsShelf4x4_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, WallDecoration, NorthSide, UpperLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object04E = new(0x04E,
			RoomDraw_RightwardsShelf4x4_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, WallDecoration, NorthSide, UpperLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object04F = new(0x04F,
			RoomDraw_RightwardsShelf4x4_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, WallDecoration, NorthSide, UpperLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object050 = new(0x050,
			RoomDraw_RightwardsLine1x1_1to16plus1, Horizontal,
			new RoomObjectCategory[] { Transport, Pit },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object051 = new(0x051,
			RoomDraw_RightwardsCannonHole4x3_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, WallDecoration, NorthSide },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object052 = new(0x052,
			RoomDraw_RightwardsCannonHole4x3_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, WallDecoration, SouthSide },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object053 = new(0x053,
			RoomDraw_Rightwards2x2_1to16, Horizontal,
			new RoomObjectCategory[] { Transport, Pit },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object054 = new(0x054,
			RoomDraw_Nothing, Horizontal,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object055 = new(0x055,
			RoomDraw_RightwardsDecor4x2spaced8_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, WallDecoration, NorthSide, UpperLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object056 = new(0x056,
			RoomDraw_RightwardsDecor4x2spaced8_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, WallDecoration, SouthSide, UpperLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object057 = new(0x057,
			RoomDraw_Nothing, Horizontal,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object058 = new(0x058,
			RoomDraw_Nothing, Horizontal,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object059 = new(0x059,
			RoomDraw_Nothing, Horizontal,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object05A = new(0x05A,
			RoomDraw_Nothing, Horizontal,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object05B = new(0x05B,
			RoomDraw_RightwardsCannonHole4x3_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, WallDecoration, NorthSide },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object05C = new(0x05C,
			RoomDraw_RightwardsCannonHole4x3_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, WallDecoration, SouthSide },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object05D = new(0x05D,
			RoomDraw_RightwardsBigRail1x3_1to16plus5, Horizontal,
			new RoomObjectCategory[] { Collision, RoomDecoration, Hookshottable },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object05E = new(0x05E,
			RoomDraw_RightwardsBlock2x2spaced2_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, RoomDecoration, Hookshottable },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object05F = new(0x05F,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus23, Horizontal,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object060 = new(0x060,
			RoomDraw_Downwards2x2_1to15or32, Horizontal,
			new RoomObjectCategory[] { Ceiling, Collision },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object061 = new(0x061,
			RoomDraw_Downwards4x2_1to15or26, Horizontal,
			new RoomObjectCategory[] { Collision, Wall, WestSide },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object062 = new(0x062,
			RoomDraw_Downwards4x2_1to15or26, Horizontal,
			new RoomObjectCategory[] { Collision, Wall, EastSide },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object063 = new(0x063,
			RoomDraw_Downwards4x2_1to16_BothBG, Horizontal,
			new RoomObjectCategory[] { Collision, Wall, WestSide, LowerLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object064 = new(0x064,
			RoomDraw_Downwards4x2_1to16_BothBG, Horizontal,
			new RoomObjectCategory[] { Collision, Wall, EastSide, LowerLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object065 = new(0x065,
			RoomDraw_DownwardsDecor4x2spaced4_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, WallDecoration, WestSide, UpperLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object066 = new(0x066,
			RoomDraw_DownwardsDecor4x2spaced4_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, WallDecoration, WestSide, UpperLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object067 = new(0x067,
			RoomDraw_Downwards2x2_1to16, Horizontal,
			new RoomObjectCategory[] { Pit, WestSide },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object068 = new(0x068,
			RoomDraw_Downwards2x2_1to16, Horizontal,
			new RoomObjectCategory[] { Pit, EastSide },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object069 = new(0x069,
			RoomDraw_DownwardsHasEdge1x1_1to16_plus3, Horizontal,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object06A = new(0x06A,
			RoomDraw_DownwardsEdge1x1_1to16, Horizontal,
			new RoomObjectCategory[] { Pit, WestSide },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object06B = new(0x06B,
			RoomDraw_DownwardsEdge1x1_1to16, Horizontal,
			new RoomObjectCategory[] { Pit, EastSide },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object06C = new(0x06C,
			RoomDraw_DownwardsWithCorners2x1_1to16_plus12, Horizontal,
			new RoomObjectCategory[] { Collision, WestSide, EastSide, UpperLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object06D = new(0x06D,
			RoomDraw_DownwardsWithCorners2x1_1to16_plus12, Horizontal,
			new RoomObjectCategory[] { Collision, WestSide, EastSide, UpperLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object06E = new(0x06E,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object06F = new(0x06F,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object070 = new(0x070,
			RoomDraw_DownwardsFloor4x4_1to16, Vertical,
			new RoomObjectCategory[] { NoCollision, Floor, RoomDecoration },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object071 = new(0x071,
			RoomDraw_Downwards1x1Solid_1to16_plus3, Vertical,
			new RoomObjectCategory[] { NoCollision, Floor, RoomDecoration, WestSide, EastSide },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object072 = new(0x072,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object073 = new(0x073,
			RoomDraw_DownwardsDecor4x4spaced2_1to16, Vertical,
			new RoomObjectCategory[] { Collision, WallDecoration, WestSide, UpperLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object074 = new(0x074,
			RoomDraw_DownwardsDecor4x4spaced2_1to16, Vertical,
			new RoomObjectCategory[] { Collision, WallDecoration, EastSide, UpperLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object075 = new(0x075,
			RoomDraw_DownwardsPillar2x4spaced2_1to16, Vertical,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object076 = new(0x076,
			RoomDraw_DownwardsDecor3x4spaced4_1to16, Vertical,
			new RoomObjectCategory[] { Collision, WallDecoration, WestSide, UpperLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object077 = new(0x077,
			RoomDraw_DownwardsDecor3x4spaced4_1to16, Vertical,
			new RoomObjectCategory[] { Collision, WallDecoration, EastSide, UpperLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object078 = new(0x078,
			RoomDraw_DownwardsDecor2x2spaced12_1to16, Vertical,
			new RoomObjectCategory[] { Collision, WallDecoration, WestSide, UpperLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object079 = new(0x079,
			RoomDraw_DownwardsEdge1x1_1to16, Vertical,
			new RoomObjectCategory[] { ShallowWater, Floor },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object07A = new(0x07A,
			RoomDraw_DownwardsEdge1x1_1to16, Vertical,
			new RoomObjectCategory[] { ShallowWater, Floor },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object07B = new(0x07B,
			RoomDraw_DownwardsDecor2x2spaced12_1to16, Vertical,
			new RoomObjectCategory[] { Collision, WallDecoration, EastSide, UpperLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object07C = new(0x07C,
			RoomDraw_DownwardsLine1x1_1to16plus1, Vertical,
			new RoomObjectCategory[] { Transport, Pit },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object07D = new(0x07D,
			RoomDraw_Downwards2x2_1to16, Vertical,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object07E = new(0x07E,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object07F = new(0x07F,
			RoomDraw_DownwardsDecor2x4spaced8_1to16, Vertical,
			new RoomObjectCategory[] { Collision, WallDecoration, WestSide, UpperLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object080 = new(0x080,
			RoomDraw_DownwardsDecor2x4spaced8_1to16, Vertical,
			new RoomObjectCategory[] { Collision, WallDecoration, EastSide, UpperLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object081 = new(0x081,
			RoomDraw_DownwardsDecor3x4spaced2_1to16, Vertical,
			new RoomObjectCategory[] { Collision, WallDecoration, WestSide, UpperLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object082 = new(0x082,
			RoomDraw_DownwardsDecor3x4spaced2_1to16, Vertical,
			new RoomObjectCategory[] { Collision, WallDecoration, EastSide, UpperLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object083 = new(0x083,
			RoomDraw_DownwardsDecor3x4spaced2_1to16, Vertical,
			new RoomObjectCategory[] { Collision, WallDecoration, WestSide, UpperLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object084 = new(0x084,
			RoomDraw_DownwardsDecor3x4spaced2_1to16, Vertical,
			new RoomObjectCategory[] { Collision, WallDecoration, EastSide, UpperLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object085 = new(0x085,
			RoomDraw_DownwardsCannonHole3x4_1to16, Vertical,
			new RoomObjectCategory[] { Collision, WallDecoration, WestSide, UpperLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object086 = new(0x086,
			RoomDraw_DownwardsCannonHole3x4_1to16, Vertical,
			new RoomObjectCategory[] { Collision, WallDecoration, EastSide, UpperLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object087 = new(0x087,
			RoomDraw_DownwardsPillar2x4spaced2_1to16, Vertical,
			new RoomObjectCategory[] { Collision, RoomDecoration, Hookshottable },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object088 = new(0x088,
			RoomDraw_DownwardsBigRail3x1_1to16plus5, Vertical,
			new RoomObjectCategory[] { Collision, RoomDecoration, Hookshottable },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object089 = new(0x089,
			RoomDraw_DownwardsBlock2x2spaced2_1to16, Vertical,
			new RoomObjectCategory[] { Collision, RoomDecoration, Hookshottable },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object08A = new(0x08A,
			RoomDraw_DownwardsHasEdge1x1_1to16_plus23, Vertical,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object08B = new(0x08B,
			RoomDraw_DownwardsEdge1x1_1to16plus7, Vertical,
			new RoomObjectCategory[] { Ledge, UpperLayer, WestSide },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object08C = new(0x08C,
			RoomDraw_DownwardsEdge1x1_1to16plus7, Vertical,
			new RoomObjectCategory[] { Ledge, UpperLayer, EastSide },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object08D = new(0x08D,
			RoomDraw_DownwardsEdge1x1_1to16, Vertical,
			new RoomObjectCategory[] { NoCollision, Floor, RoomDecoration, WestSide },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object08E = new(0x08E,
			RoomDraw_DownwardsEdge1x1_1to16, Vertical,
			new RoomObjectCategory[] { NoCollision, Floor, RoomDecoration, EastSide },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object08F = new(0x08F,
			RoomDraw_DownwardsBar2x5_1to16, Vertical,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object090 = new(0x090,
			RoomDraw_Downwards4x2_1to15or26, Vertical,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object091 = new(0x091,
			RoomDraw_Downwards4x2_1to15or26, Vertical,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object092 = new(0x092,
			RoomDraw_Downwards2x2_1to15or32, Vertical,
			new RoomObjectCategory[] { Collision, PuzzlePegs, Hookshottable },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object093 = new(0x093,
			RoomDraw_Downwards2x2_1to15or32, Vertical,
			new RoomObjectCategory[] { Collision, PuzzlePegs, Hookshottable },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object094 = new(0x094,
			RoomDraw_DownwardsFloor4x4_1to16, Vertical,
			new RoomObjectCategory[] { NoCollision, Floor },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object095 = new(0x095,
			RoomDraw_Downwards2x2_1to16, Vertical,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object096 = new(0x096,
			RoomDraw_Downwards2x2_1to16, Vertical,
			new RoomObjectCategory[] { Collision, PuzzlePegs, Hookshottable, Mutable },
			new(),
			limit: DungeonLimits.GeneralManipulable);

		[PredefinedInstance]
		public static readonly RoomObjectType Object097 = new(0x097,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object098 = new(0x098,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object099 = new(0x099,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object09A = new(0x09A,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object09B = new(0x09B,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object09C = new(0x09C,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object09D = new(0x09D,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object09E = new(0x09E,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object09F = new(0x09F,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0A0 = new(0x0A0,
			RoomDraw_DiagonalCeilingTopLeft, Both,
			new RoomObjectCategory[] { Collision, Ceiling },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0A1 = new(0x0A1,
			RoomDraw_DiagonalCeilingBottomLeft, Both,
			new RoomObjectCategory[] { Collision, Ceiling },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0A2 = new(0x0A2,
			RoomDraw_DiagonalCeilingTopRight, Both,
			new RoomObjectCategory[] { Collision, Ceiling },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0A3 = new(0x0A3,
			RoomDraw_DiagonalCeilingBottomRight, Both,
			new RoomObjectCategory[] { Collision, Ceiling },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0A4 = new(0x0A4,
			RoomDraw_BigHole4x4_1to16, Both,
			new RoomObjectCategory[] { Pit },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0A5 = new(0x0A5,
			RoomDraw_DiagonalCeilingTopLeft, Both,
			new RoomObjectCategory[] { Collision, Ceiling },
			new(),
			special: ObjectSpecialType.LayerMask);

		[PredefinedInstance]
		public static readonly RoomObjectType Object0A6 = new(0x0A6,
			RoomDraw_DiagonalCeilingBottomLeft, Both,
			new RoomObjectCategory[] { Collision, Ceiling },
			new(),
			special: ObjectSpecialType.LayerMask);

		[PredefinedInstance]
		public static readonly RoomObjectType Object0A7 = new(0x0A7,
			RoomDraw_DiagonalCeilingTopRight, Both,
			new RoomObjectCategory[] { Collision, Ceiling },
			new(),
			special: ObjectSpecialType.LayerMask);

		[PredefinedInstance]
		public static readonly RoomObjectType Object0A8 = new(0x0A8,
			RoomDraw_DiagonalCeilingBottomRight, Both,
			new RoomObjectCategory[] { Collision, Ceiling },
			new(),
			special: ObjectSpecialType.LayerMask);

		[PredefinedInstance]
		public static readonly RoomObjectType Object0A9 = new(0x0A9,
			RoomDraw_DiagonalCeilingTopLeft, Both,
			new RoomObjectCategory[] { Collision, Ceiling },
			new(),
			special: ObjectSpecialType.LayerMask);

		[PredefinedInstance]
		public static readonly RoomObjectType Object0AA = new(0x0AA,
			RoomDraw_DiagonalCeilingBottomLeft, Both,
			new RoomObjectCategory[] { Collision, Ceiling },
			new(),
			special: ObjectSpecialType.LayerMask);

		[PredefinedInstance]
		public static readonly RoomObjectType Object0AB = new(0x0AB,
			RoomDraw_DiagonalCeilingTopRight, Both,
			new RoomObjectCategory[] { Collision, Ceiling },
			new(),
			special: ObjectSpecialType.LayerMask);

		[PredefinedInstance]
		public static readonly RoomObjectType Object0AC = new(0x0AC,
			RoomDraw_DiagonalCeilingBottomRight, Both,
			new RoomObjectCategory[] { Collision, Ceiling },
			new(),
			special: ObjectSpecialType.LayerMask);

		[PredefinedInstance]
		public static readonly RoomObjectType Object0AD = new(0x0AD,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0AE = new(0x0AE,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0AF = new(0x0AF,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0B0 = new(0x0B0,
			RoomDraw_RightwardsEdge1x1_1to16plus7, Horizontal,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0B1 = new(0x0B1,
			RoomDraw_RightwardsEdge1x1_1to16plus7, Horizontal,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0B2 = new(0x0B2,
			RoomDraw_Rightwards4x4_1to16, Horizontal,
			new RoomObjectCategory[] { NoCollision, Floor },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0B3 = new(0x0B3,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new RoomObjectCategory[] { NoCollision, Floor, NorthSide },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0B4 = new(0x0B4,
			RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
			new RoomObjectCategory[] { NoCollision, Floor, SouthSide },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0B5 = new(0x0B5,
			RoomDraw_Weird2x4_1_to_16, Horizontal,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0B6 = new(0x0B6,
			RoomDraw_Rightwards2x4_1to15or26, Horizontal,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0B7 = new(0x0B7,
			RoomDraw_Rightwards2x4_1to15or26, Horizontal,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0B8 = new(0x0B8,
			RoomDraw_Rightwards2x2_1to15or32, Horizontal,
			new RoomObjectCategory[] { Collision, PuzzlePegs, Hookshottable },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0B9 = new(0x0B9,
			RoomDraw_Rightwards2x2_1to15or32, Horizontal,
			new RoomObjectCategory[] { Collision, PuzzlePegs, Hookshottable },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0BA = new(0x0BA,
			RoomDraw_Rightwards4x4_1to16, Horizontal,
			new RoomObjectCategory[] { NoCollision, Floor },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0BB = new(0x0BB,
			RoomDraw_RightwardsBlock2x2spaced2_1to16, Horizontal,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0BC = new(0x0BC,
			RoomDraw_RightwardsFakePots2x2_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0BD = new(0x0BD,
			RoomDraw_RightwardsHammerPegs2x2_1to16, Horizontal,
			new RoomObjectCategory[] { Collision, PuzzlePegs, Hookshottable, Mutable },
			new(),
			limit: DungeonLimits.GeneralManipulable);

		[PredefinedInstance]
		public static readonly RoomObjectType Object0BE = new(0x0BE,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0BF = new(0x0BF,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0C0 = new(0x0C0,
			RoomDraw_4x4BlocksIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { Collision, Ceiling },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0C1 = new(0x0C1,
			RoomDraw_ClosedChestPlatform, Both,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0C2 = new(0x0C2,
			RoomDraw_4x4BlocksIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { Pit, MetaLayer },
			new(),
			special: ObjectSpecialType.LayerMask);

		[PredefinedInstance]
		public static readonly RoomObjectType Object0C3 = new(0x0C3,
			RoomDraw_3x3FloorIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { Pit, MetaLayer },
			new(),
			special: ObjectSpecialType.LayerMask);

		[PredefinedInstance]
		public static readonly RoomObjectType Object0C4 = new(0x0C4,
			RoomDraw_4x4FloorOneIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { NoCollision, Floor },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0C5 = new(0x0C5,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { NoCollision, Floor },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0C6 = new(0x0C6,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { Pit, MetaLayer },
			new(),
			special: ObjectSpecialType.LayerMask);

		[PredefinedInstance]
		public static readonly RoomObjectType Object0C7 = new(0x0C7,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { NoCollision, Floor },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0C8 = new(0x0C8,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { NoCollision, Floor },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0C9 = new(0x0C9,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { NoCollision, Floor },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0CA = new(0x0CA,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { NoCollision, Floor },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0CB = new(0x0CB,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0CC = new(0x0CC,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0CD = new(0x0CD,
			RoomDraw_MovingWallWest, Both,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0CE = new(0x0CE,
			RoomDraw_MovingWallEast, Both,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0CF = new(0x0CF,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0D0 = new(0x0D0,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0D1 = new(0x0D1,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0D2 = new(0x0D2,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0D3 = new(0x0D3,
			RoomDraw_CheckIfWallIsMoved, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0D4 = new(0x0D4,
			RoomDraw_CheckIfWallIsMoved, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0D5 = new(0x0D5,
			RoomDraw_CheckIfWallIsMoved, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0D6 = new(0x0D6,
			RoomDraw_CheckIfWallIsMoved, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0D7 = new(0x0D7,
			RoomDraw_3x3FloorIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { MetaLayer },
			new(),
			special: ObjectSpecialType.LayerMask);

		[PredefinedInstance]
		public static readonly RoomObjectType Object0D8 = new(0x0D8,
			RoomDraw_WaterOverlay8x8_1to16, Both,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0D9 = new(0x0D9,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { MetaLayer },
			new(),
			special: ObjectSpecialType.LayerMask);

		[PredefinedInstance]
		public static readonly RoomObjectType Object0DA = new(0x0DA,
			RoomDraw_WaterOverlay8x8_1to16, Both,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0DB = new(0x0DB,
			RoomDraw_4x4FloorTwoIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0DC = new(0x0DC,
			RoomDraw_OpenChestPlatform, Both,
			new RoomObjectCategory[] { RoomDecoration, Stairs },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0DD = new(0x0DD,
			RoomDraw_TableRock4x4_1to16, Both,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0DE = new(0x0DE,
			RoomDraw_Spike2x2In4x4SuperSquare, Both,
			new RoomObjectCategory[] { Spikes },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0DF = new(0x0DF,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { Spikes, Floor },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0E0 = new(0x0E0,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { NoCollision, Floor },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0E1 = new(0x0E1,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { NoCollision, Floor },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0E2 = new(0x0E2,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { NoCollision, Floor },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0E3 = new(0x0E3,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { NoCollision, Floor, Conveyor },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0E4 = new(0x0E4,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { NoCollision, Floor, Conveyor },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0E5 = new(0x0E5,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { NoCollision, Floor, Conveyor },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0E6 = new(0x0E6,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { NoCollision, Floor, Conveyor },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0E7 = new(0x0E7,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { NoCollision, Floor, Conveyor },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0E8 = new(0x0E8,
			RoomDraw_4x4FloorIn4x4SuperSquare, Both,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0E9 = new(0x0E9,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0EA = new(0x0EA,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0EB = new(0x0EB,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0EC = new(0x0EC,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0ED = new(0x0ED,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0EE = new(0x0EE,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0EF = new(0x0EF,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0F0 = new(0x0F0,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0F1 = new(0x0F1,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0F2 = new(0x0F2,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0F3 = new(0x0F3,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0F4 = new(0x0F4,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0F5 = new(0x0F5,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0F6 = new(0x0F6,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object0F7 = new(0x0F7,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());




		[PredefinedInstance]
		public static readonly RoomObjectType Object100 = new(0x100,
			RoomDraw_4x4Object, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object101 = new(0x101,
			RoomDraw_4x4Object, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object102 = new(0x102,
			RoomDraw_4x4Object, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object103 = new(0x103,
			RoomDraw_4x4Object, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object104 = new(0x104,
			RoomDraw_4x4Object, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object105 = new(0x105,
			RoomDraw_4x4Object, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object106 = new(0x106,
			RoomDraw_4x4Object, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object107 = new(0x107,
			RoomDraw_4x4Object, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object108 = new(0x108,
			RoomDraw_4x4Corner_BothBG, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object109 = new(0x109,
			RoomDraw_4x4Corner_BothBG, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object10A = new(0x10A,
			RoomDraw_4x4Corner_BothBG, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object10B = new(0x10B,
			RoomDraw_4x4Corner_BothBG, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object10C = new(0x10C,
			RoomDraw_4x4Corner_BothBG, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object10D = new(0x10D,
			RoomDraw_4x4Corner_BothBG, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object10E = new(0x10E,
			RoomDraw_4x4Corner_BothBG, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object10F = new(0x10F,
			RoomDraw_4x4Corner_BothBG, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object110 = new(0x110,
			RoomDraw_WeirdCornerBottom_BothBG, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object111 = new(0x111,
			RoomDraw_WeirdCornerBottom_BothBG, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object112 = new(0x112,
			RoomDraw_WeirdCornerBottom_BothBG, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object113 = new(0x113,
			RoomDraw_WeirdCornerBottom_BothBG, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object114 = new(0x114,
			RoomDraw_WeirdCornerTop_BothBG, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object115 = new(0x115,
			RoomDraw_WeirdCornerTop_BothBG, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object116 = new(0x116,
			RoomDraw_WeirdCornerTop_BothBG, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object117 = new(0x117,
			RoomDraw_WeirdCornerTop_BothBG, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object118 = new(0x118,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object119 = new(0x119,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object11A = new(0x11A,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object11B = new(0x11B,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object11C = new(0x11C,
			RoomDraw_4x4Object, None,
			new RoomObjectCategory[] { Collision, Pit, RoomDecoration },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object11D = new(0x11D,
			RoomDraw_Single2x3Pillar, None,
			new RoomObjectCategory[] { Collision, RoomDecoration, Hookshottable },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object11E = new(0x11E,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { NoCollision, Pit },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object11F = new(0x11F,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { NoCollision, Pit },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object120 = new(0x120,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { Collision, RoomDecoration, Hookshottable },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object121 = new(0x121,
			RoomDraw_Single2x3Pillar, None,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object122 = new(0x122,
			RoomDraw_Bed4x5, None,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object123 = new(0x123,
			RoomDraw_4x3OneLayer, None,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object124 = new(0x124,
			RoomDraw_4x4Object, None,
			new RoomObjectCategory[] { Collision, WallDecoration },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object125 = new(0x125,
			RoomDraw_4x4Object, None,
			new RoomObjectCategory[] { Collision, WallDecoration },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object126 = new(0x126,
			RoomDraw_Single2x3Pillar, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object127 = new(0x127,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object128 = new(0x128,
			RoomDraw_YBed4x5, None,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object129 = new(0x129,
			RoomDraw_4x4Object, None,
			new RoomObjectCategory[] { Collision, WallDecoration },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object12A = new(0x12A,
			RoomDraw_PortraitOfMario, None,
			new RoomObjectCategory[] { Collision, WallDecoration, UpperLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object12B = new(0x12B,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object12C = new(0x12C,
			RoomDraw_DrawRightwards3x6, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object12D = new(0x12D,
			RoomDraw_InterRoomFatStairs, None,
			new RoomObjectCategory[] { Stairs },
			new(),
			special: ObjectSpecialType.InterroomStairs);

		[PredefinedInstance]
		public static readonly RoomObjectType Object12E = new(0x12E,
			RoomDraw_InterRoomFatStairs, None,
			new RoomObjectCategory[] { Stairs, RoomTransition },
			new(),
			special: ObjectSpecialType.InterroomStairs);

		[PredefinedInstance]
		public static readonly RoomObjectType Object12F = new(0x12F,
			RoomDraw_InterRoomFatStairs, None,
			new RoomObjectCategory[] { Stairs, RoomTransition },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object130 = new(0x130,
			RoomDraw_AutoStairs, None,
			new RoomObjectCategory[] { Stairs },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object131 = new(0x131,
			RoomDraw_AutoStairs, None,
			new RoomObjectCategory[] { Stairs },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object132 = new(0x132,
			RoomDraw_AutoStairsMerged, None,
			new RoomObjectCategory[] { Stairs },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object133 = new(0x133,
			RoomDraw_AutoStairsMerged, None,
			new RoomObjectCategory[] { Stairs },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object134 = new(0x134,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { Collision, RoomDecoration, Hookshottable },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object135 = new(0x135,
			RoomDraw_WaterHopStairs_A, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object136 = new(0x136,
			RoomDraw_WaterHopStairs_B, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object137 = new(0x137,
			RoomDraw_DamFloodGate, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object138 = new(0x138,
			RoomDraw_SpiralStairs, None,
			new RoomObjectCategory[] { Stairs, RoomTransition },
			new(),
			special: ObjectSpecialType.InterroomStairs);

		[PredefinedInstance]
		public static readonly RoomObjectType Object139 = new(0x139,
			RoomDraw_SpiralStairs, None,
			new RoomObjectCategory[] { Stairs, RoomTransition },
			new(),
			special: ObjectSpecialType.InterroomStairs);

		[PredefinedInstance]
		public static readonly RoomObjectType Object13A = new(0x13A,
			RoomDraw_SpiralStairs, None,
			new RoomObjectCategory[] { Stairs, RoomTransition },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object13B = new(0x13B,
			RoomDraw_SpiralStairs, None,
			new RoomObjectCategory[] { Stairs, RoomTransition },
			new(),
			special: ObjectSpecialType.InterroomStairs);

		[PredefinedInstance]
		public static readonly RoomObjectType Object13C = new(0x13C,
			RoomDraw_SanctuaryWall, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object13D = new(0x13D,
			RoomDraw_4x3OneLayer, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object13E = new(0x13E,
			RoomDraw_Utility6x3, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object13F = new(0x13F,
			RoomDraw_MagicBatAltar, None,
			new RoomObjectCategory[] { },
			new());




		[PredefinedInstance]
		public static readonly RoomObjectType Object200 = new(0x200,
			RoomDraw_EmptyWaterFace, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object201 = new(0x201,
			RoomDraw_SpittingWaterFace, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object202 = new(0x202,
			RoomDraw_DrenchingWaterFace, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object203 = new(0x203,
			RoomDraw_SomariaLine, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object204 = new(0x204,
			RoomDraw_SomariaLine, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object205 = new(0x205,
			RoomDraw_SomariaLine, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object206 = new(0x206,
			RoomDraw_SomariaLine, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object207 = new(0x207,
			RoomDraw_SomariaLine, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object208 = new(0x208,
			RoomDraw_SomariaLine, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object209 = new(0x209,
			RoomDraw_SomariaLine, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object20A = new(0x20A,
			RoomDraw_SomariaLine, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object20B = new(0x20B,
			RoomDraw_SomariaLine, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object20C = new(0x20C,
			RoomDraw_SomariaLine, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object20D = new(0x20D,
			RoomDraw_PrisonCell, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object20E = new(0x20E,
			RoomDraw_SomariaLine, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object20F = new(0x20F,
			RoomDraw_SomariaLine, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object210 = new(0x210,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object211 = new(0x211,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object212 = new(0x212,
			RoomDraw_RupeeFloor, None,
			new RoomObjectCategory[] { NoCollision, Floor, Secrets },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object213 = new(0x213,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { Collision, WallDecoration, Hookshottable },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object214 = new(0x214,
			RoomDraw_4x3OneLayer, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object215 = new(0x215,
			RoomDraw_KholdstareShell, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object216 = new(0x216,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { Collision, PuzzlePegs, Hookshottable, Mutable },
			new(),
			limit: DungeonLimits.GeneralManipulable);

		[PredefinedInstance]
		public static readonly RoomObjectType Object217 = new(0x217,
			RoomDraw_PrisonCell, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object218 = new(0x218,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new(),
			special: ObjectSpecialType.BigChest);

		[PredefinedInstance]
		public static readonly RoomObjectType Object219 = new(0x219,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { Collision, RoomDecoration, Secrets, Hookshottable },
			new(),
			special: ObjectSpecialType.Chest);

		[PredefinedInstance]
		public static readonly RoomObjectType Object21A = new(0x21A,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { Collision, RoomDecoration, Hookshottable },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object21B = new(0x21B,
			RoomDraw_AutoStairs, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object21C = new(0x21C,
			RoomDraw_AutoStairs, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object21D = new(0x21D,
			RoomDraw_AutoStairs, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object21E = new(0x21E,
			RoomDraw_StraightInterroomStairs, None,
			new RoomObjectCategory[] { Stairs, RoomTransition },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object21F = new(0x21F,
			RoomDraw_StraightInterroomStairs, None,
			new RoomObjectCategory[] { Stairs, RoomTransition },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object220 = new(0x220,
			RoomDraw_StraightInterroomStairs, None,
			new RoomObjectCategory[] { Stairs, RoomTransition },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object221 = new(0x221,
			RoomDraw_StraightInterroomStairs, None,
			new RoomObjectCategory[] { Stairs, RoomTransition },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object222 = new(0x222,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object223 = new(0x223,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object224 = new(0x224,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object225 = new(0x225,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object226 = new(0x226,
			RoomDraw_StraightInterroomStairs, None,
			new RoomObjectCategory[] { Stairs, RoomTransition },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object227 = new(0x227,
			RoomDraw_StraightInterroomStairs, None,
			new RoomObjectCategory[] { Stairs, RoomTransition },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object228 = new(0x228,
			RoomDraw_StraightInterroomStairs, None,
			new RoomObjectCategory[] { Stairs, RoomTransition },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object229 = new(0x229,
			RoomDraw_StraightInterroomStairs, None,
			new RoomObjectCategory[] { Stairs, RoomTransition },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object22A = new(0x22A,
			RoomDraw_LampCones, None,
			new RoomObjectCategory[] { LowerLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object22B = new(0x22B,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object22C = new(0x22C,
			RoomDraw_BigGrayRock, None,
			new RoomObjectCategory[] { Collision, RoomDecoration, Secrets, Mutable, Hookshottable },
			new(),
			limit: DungeonLimits.GeneralManipulable4x);

		[PredefinedInstance]
		public static readonly RoomObjectType Object22D = new(0x22D,
			RoomDraw_AgahnimsAltar, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object22E = new(0x22E,
			RoomDraw_AgahnimsWindows, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object22F = new(0x22F,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { Collision, RoomDecoration, Secrets, Mutable, Hookshottable },
			new(),
			limit: DungeonLimits.GeneralManipulable);

		[PredefinedInstance]
		public static readonly RoomObjectType Object230 = new(0x230,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object231 = new(0x231,
			RoomDraw_4x3OneLayer, None,
			new RoomObjectCategory[] { Collision, RoomDecoration, Secrets, Hookshottable },
			new(),
			special: ObjectSpecialType.BigChest);

		[PredefinedInstance]
		public static readonly RoomObjectType Object232 = new(0x232,
			RoomDraw_4x3OneLayer, None,
			new RoomObjectCategory[] { Collision, RoomDecoration, Hookshottable },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object233 = new(0x233,
			RoomDraw_AutoStairs, None,
			new RoomObjectCategory[] { Stairs },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object234 = new(0x234,
			RoomDraw_ChestPlatformVerticalWall, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object235 = new(0x235,
			RoomDraw_ChestPlatformVerticalWall, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object236 = new(0x236,
			RoomDraw_DrawRightwards3x6, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object237 = new(0x237,
			RoomDraw_DrawRightwards3x6, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object238 = new(0x238,
			RoomDraw_ChestPlatformVerticalWall, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object239 = new(0x239,
			RoomDraw_ChestPlatformVerticalWall, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object23A = new(0x23A,
			RoomDraw_VerticalTurtleRockPipe, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object23B = new(0x23B,
			RoomDraw_VerticalTurtleRockPipe, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object23C = new(0x23C,
			RoomDraw_HorizontalTurtleRockPipe, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object23D = new(0x23D,
			RoomDraw_HorizontalTurtleRockPipe, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object23E = new(0x23E,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object23F = new(0x23F,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object240 = new(0x240,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object241 = new(0x241,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object242 = new(0x242,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object243 = new(0x243,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object244 = new(0x244,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object245 = new(0x245,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object246 = new(0x246,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object247 = new(0x247,
			RoomDraw_BombableFloor, None,
			new RoomObjectCategory[] { NoCollision, Floor, Pit, Mutable },
			new(),
			limit: DungeonLimits.GeneralManipulable4x);

		[PredefinedInstance]
		public static readonly RoomObjectType Object248 = new(0x248,
			RoomDraw_4x4Object, None,
			new RoomObjectCategory[] { NoCollision, Floor },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object249 = new(0x249,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object24A = new(0x24A,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { RoomTransition },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object24B = new(0x24B,
			RoomDraw_BigWallDecor, None,
			new RoomObjectCategory[] { Collision, WallDecoration, NorthSide },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object24C = new(0x24C,
			RoomDraw_SmithyFurnace, None,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object24D = new(0x24D,
			RoomDraw_Utility6x3, None,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object24E = new(0x24E,
			RoomDraw_4x3OneLayer, None,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object24F = new(0x24F,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { NoCollision, Floor },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object250 = new(0x250,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object251 = new(0x251,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object252 = new(0x252,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { Collision, PuzzlePegs, Hookshottable },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object253 = new(0x253,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { Collision, PuzzlePegs, Hookshottable },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object254 = new(0x254,
			RoomDraw_FortuneTellerRoom, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object255 = new(0x255,
			RoomDraw_Utility3x5, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object256 = new(0x256,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object257 = new(0x257,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object258 = new(0x258,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object259 = new(0x259,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object25A = new(0x25A,
			RoomDraw_TableBowl, None,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object25B = new(0x25B,
			RoomDraw_Utility3x5, None,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object25C = new(0x25C,
			RoomDraw_HorizontalTurtleRockPipe, None,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object25D = new(0x25D,
			RoomDraw_Utility6x3, None,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object25E = new(0x25E,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object25F = new(0x25F,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object260 = new(0x260,
			RoomDraw_ArcheryGameTargetDoor, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object261 = new(0x261,
			RoomDraw_ArcheryGameTargetDoor, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object262 = new(0x262,
			RoomDraw_VitreousGooGraphics, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object263 = new(0x263,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object264 = new(0x264,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object265 = new(0x265,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { Collision, RoomDecoration },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object266 = new(0x266,
			RoomDraw_4x4Object, None,
			new RoomObjectCategory[] { Pit },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object267 = new(0x267,
			RoomDraw_4x3OneLayer, None,
			new RoomObjectCategory[] { Collision, WallDecoration, NorthSide, UpperLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object268 = new(0x268,
			RoomDraw_4x3OneLayer, None,
			new RoomObjectCategory[] { Collision, WallDecoration, SouthSide, UpperLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object269 = new(0x269,
			RoomDraw_SolidWallDecor3x4, None,
			new RoomObjectCategory[] { Collision, WallDecoration, WestSide, UpperLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object26A = new(0x26A,
			RoomDraw_SolidWallDecor3x4, None,
			new RoomObjectCategory[] { Collision, WallDecoration, EastSide, UpperLayer },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object26B = new(0x26B,
			RoomDraw_4x4Object, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object26C = new(0x26C,
			RoomDraw_4x3OneLayer, None,
			new RoomObjectCategory[] { Collision, WallDecoration, NorthSide },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object26D = new(0x26D,
			RoomDraw_4x3OneLayer, None,
			new RoomObjectCategory[] { Collision, WallDecoration, SouthSide },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object26E = new(0x26E,
			RoomDraw_SolidWallDecor3x4, None,
			new RoomObjectCategory[] { Collision, WallDecoration, WestSide },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object26F = new(0x26F,
			RoomDraw_SolidWallDecor3x4, None,
			new RoomObjectCategory[] { Collision, WallDecoration, EastSide },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object270 = new(0x270,
			RoomDraw_LightBeamOnFloor, None,
			new RoomObjectCategory[] { NoCollision, Floor },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object271 = new(0x271,
			RoomDraw_BigLightBeamOnFloor, None,
			new RoomObjectCategory[] { NoCollision, Floor },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object272 = new(0x272,
			RoomDraw_TrinexxShell, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object273 = new(0x273,
			RoomDraw_BG2MaskFull, None,
			new RoomObjectCategory[] { },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object274 = new(0x274,
			RoomDraw_FloorLight, None,
			new RoomObjectCategory[] { Collision, WallDecoration, NorthSide, Hookshottable },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object275 = new(0x275,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { Collision, RoomDecoration, Secrets, Hookshottable },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object276 = new(0x276,
			RoomDraw_BigWallDecor, None,
			new RoomObjectCategory[] { Collision, WallDecoration, NorthSide },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object277 = new(0x277,
			RoomDraw_BigWallDecor, None,
			new RoomObjectCategory[] { Collision, WallDecoration, NorthSide },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object278 = new(0x278,
			RoomDraw_GanonTriforceFloorDecor, None,
			new RoomObjectCategory[] { NoCollision, Floor },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object279 = new(0x279,
			RoomDraw_4x3OneLayer, None,
			new RoomObjectCategory[] { Collision, WallDecoration, NorthSide },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object27A = new(0x27A,
			RoomDraw_4x4Object, None,
			new RoomObjectCategory[] { NoCollision, Floor },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object27B = new(0x27B,
			RoomDraw_VitreousGooDamage, None,
			new RoomObjectCategory[] { Spikes },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object27C = new(0x27C,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { NoCollision, Floor },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object27D = new(0x27D,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { NoCollision, Floor },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object27E = new(0x27E,
			RoomDraw_Single2x2, None,
			new RoomObjectCategory[] { NoCollision, Floor },
			new());

		[PredefinedInstance]
		public static readonly RoomObjectType Object27F = new(0x27F,
			RoomDraw_Nothing, None,
			new RoomObjectCategory[] { },
			new());
	}
}
