using static ZeldaFullEditor.ALTTP.Underworld.ObjectResizability;
using static ZeldaFullEditor.ALTTP.Underworld.RoomObjectCategory;

namespace ZeldaFullEditor.Data;

public partial class RoomObjectType : IEntityType<RoomObjectType>
{
	public string Name { get; init; }
	public ObjectSubtype ObjectSet { get; }
	public ObjectResizability Resizeability { get; }

	private DrawObject Draw { get; }

	public ObjectSpecialType Specialness { get; init; } = ObjectSpecialType.None;

	public DungeonLimits LimitClass { get; init; } = DungeonLimits.None;

	public bool BothBG { get; init; } = false;

	/// <summary>
	/// What tile sets this object doesn't look like garbage in
	/// </summary>
	public RequiredGraphicsSheets RequiredSheets { get; }

	public ImmutableArray<SearchCategory> Categories { get; }

	public bool IsCompletelyInvisible => Draw == RoomDraw_Nothing;

	public ushort FullID { get; init; }
	public int ListID => FullID;

	public ushort TileIndex { get; init; } = 0x0000;


	private readonly TilesBySizeLister lister;


	private RoomObjectType(ushort objectid, ushort tilex, DrawObject drawfunc, ObjectResizability resizing, SearchCategory[] categories, RequiredGraphicsSheets gsets)
	{
		TileIndex = tilex;

		ObjectSet = (ObjectSubtype) (objectid >> 8);
		FullID = objectid;

		Name = ObjectSet switch
		{
			ObjectSubtype.Subtype1 => RoomObjectName.ListOfSubtype1RoomObjects[(byte) objectid].Name,
			ObjectSubtype.Subtype2 => RoomObjectName.ListOfSubtype2RoomObjects[(byte) objectid].Name,
			ObjectSubtype.Subtype3 => RoomObjectName.ListOfSubtype3RoomObjects[(byte) objectid].Name,
			_ => "PROBLEM",
		};

		Resizeability = resizing;
		Categories = categories.ToImmutableArray();
		RequiredSheets = gsets;
		Draw = drawfunc;

		// precalc all the drawing tiles
		int count = Resizeability == None ? 1 : 16;

		List<DrawInfo>[] listfiller = new List<DrawInfo>[count];
		//(int width, int height)[] dimensionfiller = new (int, int)[count];

		for (int i = 0; i < count; i++)
		{
			listfiller[i] = new();
			Draw(listfiller[i], i);
		}

		lister = new(resizing != None, listfiller);
	}

	public override string ToString() => $"{FullID:X3} {Name}";

	public static ImmutableArray<RoomObjectType> ListOf { get; }

	// Need to use static constructor for reflection to work properly
	static RoomObjectType()
	{
		ListOf = Utils.GetSortedListOfPredefinedFields<RoomObjectType>();
	}

	public static RoomObjectType GetTypeFromID(int id) => ListOf.GetTypeFromID(id);


	public ImmutableArray<DrawInfo> GetDrawingForSize(int size)
	{
		return lister.GetDrawingForSize(size);
	}

	private class TilesBySizeLister
	{
		internal bool Resizable { get; }
		private ImmutableArray<DrawInfo>[] Tiles { get; }



		internal int[] Widths { get; }
		internal int[] Heights { get; }

		internal TilesBySizeLister(bool resize, List<DrawInfo>[] listfiller)
		{
			Resizable = resize;
			int count = listfiller.Length;
			Tiles = new ImmutableArray<DrawInfo>[count];

			for (int i = 0; i < count; i++)
			{
				Tiles[i] = listfiller[i].ToImmutableArray();
			}

		}

		public ImmutableArray<DrawInfo> GetDrawingForSize(int size) => Resizable switch
		{
			true => Tiles[size],
			false => Tiles[0],
		};

	}





#pragma warning disable CA1825 // Avoid zero-length array allocations


	/*
	 * All room object defaults
	 */

	[PredefinedInstance]
	public static readonly RoomObjectType Object000 = new(0x000, 0x03D8,
		RoomDraw_Rightwards2x2_1to15or32, Horizontal,
		new[] { Collision, Ceiling },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object001 = new(0x001, 0x02E8,
		RoomDraw_Rightwards2x4_1to15or26, Horizontal,
		new[] { Collision, Wall, NorthSide },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object002 = new(0x002, 0x02F8,
		RoomDraw_Rightwards2x4_1to15or26, Horizontal,
		new[] { Collision, Wall, SouthSide },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object003 = new(0x003, 0x0328,
		RoomDraw_Rightwards2x4spaced4_1to16, Horizontal,
		new[] { Collision, Wall, NorthSide, Ledge, LowerLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object004 = new(0x004, 0x0338,
		RoomDraw_Rightwards2x4spaced4_1to16, Horizontal,
		new[] { Collision, Wall, SouthSide, Ledge, LowerLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object005 = new(0x005, 0x0400,
		RoomDraw_Rightwards2x4spaced4_1to16_BothBG, Horizontal,
		new[] { Collision, WallDecoration, NorthSide },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object006 = new(0x006, 0x0410,
		RoomDraw_Rightwards2x4spaced4_1to16_BothBG, Horizontal,
		new[] { Collision, WallDecoration, SouthSide },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object007 = new(0x007, 0x0388,
		RoomDraw_Rightwards2x2_1to16, Horizontal,
		new[] { Pit, NorthSide },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object008 = new(0x008, 0x0390,
		RoomDraw_Rightwards2x2_1to16, Horizontal,
		new[] { Pit, SouthSide },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object009 = new(0x009, 0x0420,
		RoomDraw_DiagonalAcute_1to16, Horizontal,
		new[] { DiagonalCollision, Wall, NorthSide, WestSide, UpperLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object00A = new(0x00A, 0x042A,
		RoomDraw_DiagonalGrave_1to16, Horizontal,
		new[] { DiagonalCollision, Wall, SouthSide, WestSide, UpperLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object00B = new(0x00B, 0x0434,
		RoomDraw_DiagonalGrave_1to16, Horizontal,
		new[] { DiagonalCollision, Wall, NorthSide, EastSide, UpperLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object00C = new(0x00C, 0x043E,
		RoomDraw_DiagonalAcute_1to16, Horizontal,
		new[] { DiagonalCollision, Wall, SouthSide, EastSide, UpperLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object00D = new(0x00D, 0x0448,
		RoomDraw_DiagonalAcute_1to16, Horizontal,
		new[] { DiagonalCollision, Wall, NorthSide, WestSide, UpperLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object00E = new(0x00E, 0x0452,
		RoomDraw_DiagonalGrave_1to16, Horizontal,
		new[] { DiagonalCollision, Wall, SouthSide, WestSide, UpperLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object00F = new(0x00F, 0x045C,
		RoomDraw_DiagonalGrave_1to16, Horizontal,
		new[] { DiagonalCollision, Wall, NorthSide, EastSide, UpperLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object010 = new(0x010, 0x0466,
		RoomDraw_DiagonalAcute_1to16, Horizontal,
		new[] { DiagonalCollision, Wall, SouthSide, EastSide, UpperLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object011 = new(0x011, 0x0470,
		RoomDraw_DiagonalAcute_1to16, Horizontal,
		new[] { DiagonalCollision, Wall, NorthSide, WestSide, UpperLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object012 = new(0x012, 0x047A,
		RoomDraw_DiagonalGrave_1to16, Horizontal,
		new[] { DiagonalCollision, Wall, SouthSide, WestSide, UpperLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object013 = new(0x013, 0x0484,
		RoomDraw_DiagonalGrave_1to16, Horizontal,
		new[] { DiagonalCollision, Wall, NorthSide, EastSide, UpperLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object014 = new(0x014, 0x048E,
		RoomDraw_DiagonalAcute_1to16, Horizontal,
		new[] { DiagonalCollision, Wall, SouthSide, EastSide, UpperLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object015 = new(0x015, 0x0498,
		RoomDraw_DiagonalAcute_1to16_BothBG, Horizontal,
		new[] { DiagonalCollision, Wall, NorthSide, WestSide, LowerLayer },
		new())
	{
		BothBG = true,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object016 = new(0x016, 0x04A2,
		RoomDraw_DiagonalGrave_1to16_BothBG, Horizontal,
		new[] { DiagonalCollision, Wall, SouthSide, WestSide, LowerLayer },
		new())
	{
		BothBG = true,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object017 = new(0x017, 0x04AC,
		RoomDraw_DiagonalGrave_1to16_BothBG, Horizontal,
		new[] { DiagonalCollision, Wall, NorthSide, EastSide, LowerLayer },
		new())
	{
		BothBG = true,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object018 = new(0x018, 0x04B6,
		RoomDraw_DiagonalAcute_1to16_BothBG, Horizontal,
		new[] { DiagonalCollision, Wall, SouthSide, EastSide, LowerLayer },
		new())
	{
		BothBG = true,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object019 = new(0x019, 0x04C0,
		RoomDraw_DiagonalAcute_1to16_BothBG, Horizontal,
		new[] { DiagonalCollision, Wall, NorthSide, WestSide, LowerLayer },
		new())
	{
		BothBG = true,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object01A = new(0x01A, 0x04CA,
		RoomDraw_DiagonalGrave_1to16_BothBG, Horizontal,
		new[] { DiagonalCollision, Wall, SouthSide, WestSide, LowerLayer },
		new())
	{
		BothBG = true,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object01B = new(0x01B, 0x04D4,
		RoomDraw_DiagonalGrave_1to16_BothBG, Horizontal,
		new[] { DiagonalCollision, Wall, NorthSide, EastSide, LowerLayer },
		new())
	{
		BothBG = true,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object01C = new(0x01C, 0x04DE,
		RoomDraw_DiagonalAcute_1to16_BothBG, Horizontal,
		new[] { DiagonalCollision, Wall, SouthSide, EastSide, LowerLayer },
		new())
	{
		BothBG = true,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object01D = new(0x01D, 0x04E8,
		RoomDraw_DiagonalAcute_1to16_BothBG, Horizontal,
		new[] { DiagonalCollision, Wall, NorthSide, WestSide, LowerLayer },
		new())
	{
		BothBG = true,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object01E = new(0x01E, 0x04F2,
		RoomDraw_DiagonalGrave_1to16_BothBG, Horizontal,
		new[] { DiagonalCollision, Wall, SouthSide, WestSide, LowerLayer },
		new())
	{
		BothBG = true,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object01F = new(0x01F, 0x04FC,
		RoomDraw_DiagonalGrave_1to16_BothBG, Horizontal,
		new[] { DiagonalCollision, Wall, NorthSide, EastSide, LowerLayer },
		new())
	{
		BothBG = true,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object020 = new(0x020, 0x0506,
		RoomDraw_DiagonalAcute_1to16_BothBG, Horizontal,
		new[] { DiagonalCollision, Wall, SouthSide, EastSide, LowerLayer },
		new())
	{
		BothBG = true,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object021 = new(0x021, 0x0598,
		RoomDraw_Rightwards1x2_1to16_plus2, Horizontal,
		new[] { Stairs },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object022 = new(0x022, 0x0600,
		RoomDraw_RightwardsHasEdge1x1_1to16_plus3, Horizontal,
		new[] { Collision },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object023 = new(0x023, 0x063C,
		RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
		new[] { Pit },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object024 = new(0x024, 0x063C,
		RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
		new[] { Pit },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object025 = new(0x025, 0x063C,
		RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
		new[] { Pit },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object026 = new(0x026, 0x063C,
		RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
		new[] { Pit },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object027 = new(0x027, 0x063C,
		RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
		new[] { Pit },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object028 = new(0x028, 0x0642,
		RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
		new[] { Pit },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object029 = new(0x029, 0x064C,
		RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
		new[] { Pit },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object02A = new(0x02A, 0x0652,
		RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
		new[] { Pit },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object02B = new(0x02B, 0x0658,
		RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
		new[] { Pit },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object02C = new(0x02C, 0x065E,
		RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
		new[] { Pit },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object02D = new(0x02D, 0x0664,
		RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
		new[] { Pit },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object02E = new(0x02E, 0x066A,
		RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
		new[] { Pit },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object02F = new(0x02F, 0x0688,
		RoomDraw_RightwardsWithCorners1x2_1to16_plus13, Horizontal,
		new[] { Collision, Ledge, Wall, NorthSide, SouthSide, UpperLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object030 = new(0x030, 0x0694,
		RoomDraw_RightwardsWithCorners1x2_1to16_plus13, Horizontal,
		new[] { Collision, Ledge, Wall, NorthSide, SouthSide, UpperLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object031 = new(0x031, 0x06A8,
		RoomDraw_Nothing, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object032 = new(0x032, 0x06A8,
		RoomDraw_Nothing, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object033 = new(0x033, 0x06A8,
		RoomDraw_Rightwards4x4_1to16, Horizontal,
		new[] { NoCollision, Floor, RoomDecoration },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object034 = new(0x034, 0x06C8,
		RoomDraw_Rightwards1x1Solid_1to16_plus3, Horizontal,
		new[] { NoCollision, Floor, RoomDecoration, NorthSide, SouthSide },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object035 = new(0x035, 0x0000,
		RoomDraw_DoorSwitcherer, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object036 = new(0x036, 0x078A,
		RoomDraw_RightwardsDecor4x4spaced2_1to16, Horizontal,
		new[] { Collision, WallDecoration, NorthSide, UpperLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object037 = new(0x037, 0x07AA,
		RoomDraw_RightwardsDecor4x4spaced2_1to16, Horizontal,
		new[] { Collision, WallDecoration, SouthSide, UpperLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object038 = new(0x038, 0x0E26,
		RoomDraw_RightwardsStatue2x3spaced2_1to16, Horizontal,
		new[] { Collision, RoomDecoration, Hookshottable },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object039 = new(0x039, 0x084A,
		RoomDraw_RightwardsPillar2x4spaced4_1to16, Horizontal,
		new[] { Collision, RoomDecoration },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object03A = new(0x03A, 0x086A,
		RoomDraw_RightwardsDecor4x3spaced4_1to16, Horizontal,
		new[] { Collision, WallDecoration, NorthSide, UpperLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object03B = new(0x03B, 0x0882,
		RoomDraw_RightwardsDecor4x3spaced4_1to16, Horizontal,
		new[] { Collision, WallDecoration, SouthSide, UpperLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object03C = new(0x03C, 0x08CA,
		RoomDraw_RightwardsDoubled2x2spaced2_1to16, Horizontal,
		new[] { Collision, RoomDecoration },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object03D = new(0x03D, 0x085A,
		RoomDraw_RightwardsPillar2x4spaced4_1to16, Horizontal,
		new[] { Collision, RoomDecoration, Hookshottable },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object03E = new(0x03E, 0x08FA,
		RoomDraw_RightwardsDecor2x2spaced12_1to16, Horizontal,
		new[] { Collision, WallDecoration, NorthSide, UpperLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object03F = new(0x03F, 0x091A,
		RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
		new[] { ShallowWater },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object040 = new(0x040, 0x0920,
		RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
		new[] { ShallowWater },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object041 = new(0x041, 0x092A,
		RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
		new[] { ShallowWater },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object042 = new(0x042, 0x0930,
		RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
		new[] { ShallowWater },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object043 = new(0x043, 0x0936,
		RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
		new[] { ShallowWater },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object044 = new(0x044, 0x093C,
		RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
		new[] { ShallowWater },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object045 = new(0x045, 0x0942,
		RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
		new[] { ShallowWater },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object046 = new(0x046, 0x0948,
		RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
		new[] { ShallowWater },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object047 = new(0x047, 0x094E,
		RoomDraw_Waterfall47, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object048 = new(0x048, 0x096C,
		RoomDraw_Waterfall48, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object049 = new(0x049, 0x097E,
		RoomDraw_RightwardsFloorTile4x2_1to16, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object04A = new(0x04A, 0x098E,
		RoomDraw_RightwardsFloorTile4x2_1to16, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object04B = new(0x04B, 0x0902,
		RoomDraw_RightwardsDecor2x2spaced12_1to16, Horizontal,
		new[] { Collision, WallDecoration, SouthSide, UpperLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object04C = new(0x04C, 0x099E,
		RoomDraw_RightwardsBar4x3_1to16, Horizontal,
		new[] { Collision, RoomDecoration },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object04D = new(0x04D, 0x09D8,
		RoomDraw_RightwardsShelf4x4_1to16, Horizontal,
		new[] { Collision, WallDecoration, NorthSide, UpperLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object04E = new(0x04E, 0x09D8,
		RoomDraw_RightwardsShelf4x4_1to16, Horizontal,
		new[] { Collision, WallDecoration, NorthSide, UpperLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object04F = new(0x04F, 0x09D8,
		RoomDraw_RightwardsShelf4x4_1to16, Horizontal,
		new[] { Collision, WallDecoration, NorthSide, UpperLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object050 = new(0x050, 0x09FA,
		RoomDraw_RightwardsLine1x1_1to16plus1, Horizontal,
		new[] { Transport, Pit },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object051 = new(0x051, 0x156C,
		RoomDraw_RightwardsCannonHole4x3_1to16, Horizontal,
		new[] { Collision, WallDecoration, NorthSide },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object052 = new(0x052, 0x1590,
		RoomDraw_RightwardsCannonHole4x3_1to16, Horizontal,
		new[] { Collision, WallDecoration, SouthSide },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object053 = new(0x053, 0x1D86,
		RoomDraw_Rightwards2x2_1to16, Horizontal,
		new[] { Transport, Pit },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object054 = new(0x054, 0x0000,
		RoomDraw_Nothing, Horizontal,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object055 = new(0x055, 0x0A14,
		RoomDraw_RightwardsDecor4x2spaced8_1to16, Horizontal,
		new[] { Collision, WallDecoration, NorthSide, UpperLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object056 = new(0x056, 0x0A24,
		RoomDraw_RightwardsDecor4x2spaced8_1to16, Horizontal,
		new[] { Collision, WallDecoration, SouthSide, UpperLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object057 = new(0x057, 0x0A54,
		RoomDraw_Nothing, Horizontal,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object058 = new(0x058, 0x0A54,
		RoomDraw_Nothing, Horizontal,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object059 = new(0x059, 0x0A84,
		RoomDraw_Nothing, Horizontal,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object05A = new(0x05A, 0x0A84,
		RoomDraw_Nothing, Horizontal,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object05B = new(0x05B, 0x14DC,
		RoomDraw_RightwardsCannonHole4x3_1to16, Horizontal,
		new[] { Collision, WallDecoration, NorthSide },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object05C = new(0x05C, 0x1500,
		RoomDraw_RightwardsCannonHole4x3_1to16, Horizontal,
		new[] { Collision, WallDecoration, SouthSide },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object05D = new(0x05D, 0x061E,
		RoomDraw_RightwardsBigRail1x3_1to16plus5, Horizontal,
		new[] { Collision, RoomDecoration, Hookshottable },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object05E = new(0x05E, 0x0E52,
		RoomDraw_RightwardsBlock2x2spaced2_1to16, Horizontal,
		new[] { Collision, RoomDecoration, Hookshottable },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object05F = new(0x05F, 0x0600,
		RoomDraw_RightwardsHasEdge1x1_1to16_plus23, Horizontal,
		new[] { Collision, RoomDecoration },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object060 = new(0x060, 0x03D8,
		RoomDraw_Downwards2x2_1to15or32, Horizontal,
		new[] { Ceiling, Collision },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object061 = new(0x061, 0x02C8,
		RoomDraw_Downwards4x2_1to15or26, Horizontal,
		new[] { Collision, Wall, WestSide },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object062 = new(0x062, 0x02D8,
		RoomDraw_Downwards4x2_1to15or26, Horizontal,
		new[] { Collision, Wall, EastSide },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object063 = new(0x063, 0x0308,
		RoomDraw_Downwards4x2_1to16_BothBG, Horizontal,
		new[] { Collision, Wall, WestSide, LowerLayer },
		new())
	{
		BothBG = true,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object064 = new(0x064, 0x0318,
		RoomDraw_Downwards4x2_1to16_BothBG, Horizontal,
		new[] { Collision, Wall, EastSide, LowerLayer },
		new())
	{
		BothBG = true,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object065 = new(0x065, 0x03E0,
		RoomDraw_DownwardsDecor4x2spaced4_1to16, Horizontal,
		new[] { Collision, WallDecoration, WestSide, UpperLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object066 = new(0x066, 0x03F0,
		RoomDraw_DownwardsDecor4x2spaced4_1to16, Horizontal,
		new[] { Collision, WallDecoration, WestSide, UpperLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object067 = new(0x067, 0x0378,
		RoomDraw_Downwards2x2_1to16, Horizontal,
		new[] { Pit, WestSide },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object068 = new(0x068, 0x0380,
		RoomDraw_Downwards2x2_1to16, Horizontal,
		new[] { Pit, EastSide },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object069 = new(0x069, 0x05FA,
		RoomDraw_DownwardsHasEdge1x1_1to16_plus3, Horizontal,
		new[] { Collision, RoomDecoration },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object06A = new(0x06A, 0x0648,
		RoomDraw_DownwardsEdge1x1_1to16, Horizontal,
		new[] { Pit, WestSide },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object06B = new(0x06B, 0x064A,
		RoomDraw_DownwardsEdge1x1_1to16, Horizontal,
		new[] { Pit, EastSide },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object06C = new(0x06C, 0x0670,
		RoomDraw_DownwardsWithCorners2x1_1to16_plus12, Horizontal,
		new[] { Collision, WestSide, EastSide, UpperLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object06D = new(0x06D, 0x067C,
		RoomDraw_DownwardsWithCorners2x1_1to16_plus12, Horizontal,
		new[] { Collision, WestSide, EastSide, UpperLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object06E = new(0x06E, 0x06A8,
		RoomDraw_Nothing, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object06F = new(0x06F, 0x06A8,
		RoomDraw_Nothing, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object070 = new(0x070, 0x06A8,
		RoomDraw_DownwardsFloor4x4_1to16, Vertical,
		new[] { NoCollision, Floor, RoomDecoration },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object071 = new(0x071, 0x06C8,
		RoomDraw_Downwards1x1Solid_1to16_plus3, Vertical,
		new[] { NoCollision, Floor, RoomDecoration, WestSide, EastSide },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object072 = new(0x072, 0x0000,
		RoomDraw_Nothing, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object073 = new(0x073, 0x07AA,
		RoomDraw_DownwardsDecor4x4spaced2_1to16, Vertical,
		new[] { Collision, WallDecoration, WestSide, UpperLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object074 = new(0x074, 0x07CA,
		RoomDraw_DownwardsDecor4x4spaced2_1to16, Vertical,
		new[] { Collision, WallDecoration, EastSide, UpperLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object075 = new(0x075, 0x084A,
		RoomDraw_DownwardsPillar2x4spaced2_1to16, Vertical,
		new[] { Collision, RoomDecoration },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object076 = new(0x076, 0x089A,
		RoomDraw_DownwardsDecor3x4spaced4_1to16, Vertical,
		new[] { Collision, WallDecoration, WestSide, UpperLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object077 = new(0x077, 0x08B2,
		RoomDraw_DownwardsDecor3x4spaced4_1to16, Vertical,
		new[] { Collision, WallDecoration, EastSide, UpperLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object078 = new(0x078, 0x090A,
		RoomDraw_DownwardsDecor2x2spaced12_1to16, Vertical,
		new[] { Collision, WallDecoration, WestSide, UpperLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object079 = new(0x079, 0x0926,
		RoomDraw_DownwardsEdge1x1_1to16, Vertical,
		new[] { ShallowWater, Floor },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object07A = new(0x07A, 0x0928,
		RoomDraw_DownwardsEdge1x1_1to16, Vertical,
		new[] { ShallowWater, Floor },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object07B = new(0x07B, 0x0912,
		RoomDraw_DownwardsDecor2x2spaced12_1to16, Vertical,
		new[] { Collision, WallDecoration, EastSide, UpperLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object07C = new(0x07C, 0x09F8,
		RoomDraw_DownwardsLine1x1_1to16plus1, Vertical,
		new[] { Transport, Pit },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object07D = new(0x07D, 0x1D7E,
		RoomDraw_Downwards2x2_1to16, Vertical,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object07E = new(0x07E, 0x0000,
		RoomDraw_Nothing, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object07F = new(0x07F, 0x0A34,
		RoomDraw_DownwardsDecor2x4spaced8_1to16, Vertical,
		new[] { Collision, WallDecoration, WestSide, UpperLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object080 = new(0x080, 0x0A44,
		RoomDraw_DownwardsDecor2x4spaced8_1to16, Vertical,
		new[] { Collision, WallDecoration, EastSide, UpperLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object081 = new(0x081, 0x0A54,
		RoomDraw_DownwardsDecor3x4spaced2_1to16, Vertical,
		new[] { Collision, WallDecoration, WestSide, UpperLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object082 = new(0x082, 0x0A6C,
		RoomDraw_DownwardsDecor3x4spaced2_1to16, Vertical,
		new[] { Collision, WallDecoration, EastSide, UpperLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object083 = new(0x083, 0x0A84,
		RoomDraw_DownwardsDecor3x4spaced2_1to16, Vertical,
		new[] { Collision, WallDecoration, WestSide, UpperLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object084 = new(0x084, 0x0A9C,
		RoomDraw_DownwardsDecor3x4spaced2_1to16, Vertical,
		new[] { Collision, WallDecoration, EastSide, UpperLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object085 = new(0x085, 0x1524,
		RoomDraw_DownwardsCannonHole3x4_1to16, Vertical,
		new[] { Collision, WallDecoration, WestSide, UpperLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object086 = new(0x086, 0x1548,
		RoomDraw_DownwardsCannonHole3x4_1to16, Vertical,
		new[] { Collision, WallDecoration, EastSide, UpperLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object087 = new(0x087, 0x085A,
		RoomDraw_DownwardsPillar2x4spaced2_1to16, Vertical,
		new[] { Collision, RoomDecoration, Hookshottable },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object088 = new(0x088, 0x0606,
		RoomDraw_DownwardsBigRail3x1_1to16plus5, Vertical,
		new[] { Collision, RoomDecoration, Hookshottable },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object089 = new(0x089, 0x0E52,
		RoomDraw_DownwardsBlock2x2spaced2_1to16, Vertical,
		new[] { Collision, RoomDecoration, Hookshottable },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object08A = new(0x08A, 0x05FA,
		RoomDraw_DownwardsHasEdge1x1_1to16_plus23, Vertical,
		new[] { Collision, RoomDecoration },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object08B = new(0x08B, 0x06A0,
		RoomDraw_DownwardsEdge1x1_1to16plus7, Vertical,
		new[] { Ledge, UpperLayer, WestSide },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object08C = new(0x08C, 0x06A2,
		RoomDraw_DownwardsEdge1x1_1to16plus7, Vertical,
		new[] { Ledge, UpperLayer, EastSide },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object08D = new(0x08D, 0x0B12,
		RoomDraw_DownwardsEdge1x1_1to16, Vertical,
		new[] { NoCollision, Floor, RoomDecoration, WestSide },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object08E = new(0x08E, 0x0B14,
		RoomDraw_DownwardsEdge1x1_1to16, Vertical,
		new[] { NoCollision, Floor, RoomDecoration, EastSide },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object08F = new(0x08F, 0x09B0,
		RoomDraw_DownwardsBar2x5_1to16, Vertical,
		new[] { Collision, RoomDecoration },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object090 = new(0x090, 0x0B46,
		RoomDraw_Downwards4x2_1to15or26, Vertical,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object091 = new(0x091, 0x0B56,
		RoomDraw_Downwards4x2_1to15or26, Vertical,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object092 = new(0x092, 0x1F52,
		RoomDraw_Downwards2x2_1to15or32, Vertical,
		new[] { Collision, PuzzlePegs, Hookshottable },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object093 = new(0x093, 0x1F5A,
		RoomDraw_Downwards2x2_1to15or32, Vertical,
		new[] { Collision, PuzzlePegs, Hookshottable },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object094 = new(0x094, 0x0288,
		RoomDraw_DownwardsFloor4x4_1to16, Vertical,
		new[] { NoCollision, Floor },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object095 = new(0x095, 0x0E82,
		RoomDraw_Downwards2x2_1to16, Vertical,
		new[] { Collision, Hookshottable, Mutable },
		new())
	{
		LimitClass = DungeonLimits.GeneralManipulable,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object096 = new(0x096, 0x1DF2,
		RoomDraw_Downwards2x2_1to16, Vertical,
		new[] { Collision, PuzzlePegs, Hookshottable, Mutable },
		new())
	{
		LimitClass = DungeonLimits.GeneralManipulable,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object097 = new(0x097, 0x0000,
		RoomDraw_Nothing, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object098 = new(0x098, 0x0000,
		RoomDraw_Nothing, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object099 = new(0x099, 0x0000,
		RoomDraw_Nothing, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object09A = new(0x09A, 0x0000,
		RoomDraw_Nothing, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object09B = new(0x09B, 0x0000,
		RoomDraw_Nothing, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object09C = new(0x09C, 0x0000,
		RoomDraw_Nothing, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object09D = new(0x09D, 0x0000,
		RoomDraw_Nothing, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object09E = new(0x09E, 0x0000,
		RoomDraw_Nothing, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object09F = new(0x09F, 0x0000,
		RoomDraw_Nothing, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0A0 = new(0x0A0, 0x03D8,
		RoomDraw_DiagonalCeilingTopLeft, Both,
		new[] { Collision, Ceiling },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0A1 = new(0x0A1, 0x03D8,
		RoomDraw_DiagonalCeilingBottomLeft, Both,
		new[] { Collision, Ceiling },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0A2 = new(0x0A2, 0x03D8,
		RoomDraw_DiagonalCeilingTopRight, Both,
		new[] { Collision, Ceiling },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0A3 = new(0x0A3, 0x03D8,
		RoomDraw_DiagonalCeilingBottomRight, Both,
		new[] { Collision, Ceiling },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0A4 = new(0x0A4, 0x05AA,
		RoomDraw_BigHole4x4_1to16, Both,
		new[] { Pit },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0A5 = new(0x0A5, 0x05B2,
		RoomDraw_DiagonalCeilingTopLeft, Both,
		new[] { Collision, Ceiling },
		new())
	{
		Specialness = ObjectSpecialType.LayerMask,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object0A6 = new(0x0A6, 0x05B2,
		RoomDraw_DiagonalCeilingBottomLeft, Both,
		new[] { Collision, Ceiling },
		new())
	{
		Specialness = ObjectSpecialType.LayerMask,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object0A7 = new(0x0A7, 0x05B2,
		RoomDraw_DiagonalCeilingTopRight, Both,
		new[] { Collision, Ceiling },
		new())
	{
		Specialness = ObjectSpecialType.LayerMask,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object0A8 = new(0x0A8, 0x05B2,
		RoomDraw_DiagonalCeilingBottomRight, Both,
		new[] { Collision, Ceiling },
		new())
	{
		Specialness = ObjectSpecialType.LayerMask,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object0A9 = new(0x0A9, 0x00E0,
		RoomDraw_DiagonalCeilingTopLeft, Both,
		new[] { Collision, Ceiling },
		new())
	{
		Specialness = ObjectSpecialType.LayerMask,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object0AA = new(0x0AA, 0x00E0,
		RoomDraw_DiagonalCeilingBottomLeft, Both,
		new[] { Collision, Ceiling },
		new())
	{
		Specialness = ObjectSpecialType.LayerMask,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object0AB = new(0x0AB, 0x00E0,
		RoomDraw_DiagonalCeilingTopRight, Both,
		new[] { Collision, Ceiling },
		new())
	{
		Specialness = ObjectSpecialType.LayerMask,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object0AC = new(0x0AC, 0x00E0,
		RoomDraw_DiagonalCeilingBottomRight, Both,
		new[] { Collision, Ceiling },
		new())
	{
		Specialness = ObjectSpecialType.LayerMask,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object0AD = new(0x0AD, 0x0110,
		RoomDraw_Nothing, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0AE = new(0x0AE, 0x0000,
		RoomDraw_Nothing, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0AF = new(0x0AF, 0x0000,
		RoomDraw_Nothing, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0B0 = new(0x0B0, 0x06A4,
		RoomDraw_RightwardsEdge1x1_1to16plus7, Horizontal,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0B1 = new(0x0B1, 0x06A6,
		RoomDraw_RightwardsEdge1x1_1to16plus7, Horizontal,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0B2 = new(0x0B2, 0x0AE6,
		RoomDraw_Rightwards4x4_1to16, Horizontal,
		new[] { NoCollision, Floor },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0B3 = new(0x0B3, 0x0B06,
		RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
		new[] { NoCollision, Floor, NorthSide },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0B4 = new(0x0B4, 0x0B0C,
		RoomDraw_RightwardsHasEdge1x1_1to16_plus2, Horizontal,
		new[] { NoCollision, Floor, SouthSide },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0B5 = new(0x0B5, 0x0B16,
		RoomDraw_Weird2x4_1_to_16, Horizontal,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0B6 = new(0x0B6, 0x0B26,
		RoomDraw_Rightwards2x4_1to15or26, Horizontal,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0B7 = new(0x0B7, 0x0B36,
		RoomDraw_Rightwards2x4_1to15or26, Horizontal,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0B8 = new(0x0B8, 0x1F52,
		RoomDraw_Rightwards2x2_1to15or32, Horizontal,
		new[] { Collision, PuzzlePegs, Hookshottable },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0B9 = new(0x0B9, 0x1F5A,
		RoomDraw_Rightwards2x2_1to15or32, Horizontal,
		new[] { Collision, PuzzlePegs, Hookshottable },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0BA = new(0x0BA, 0x0288,
		RoomDraw_Rightwards4x4_1to16, Horizontal,
		new[] { NoCollision, Floor },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0BB = new(0x0BB, 0x0EBA,
		RoomDraw_RightwardsBlock2x2spaced2_1to16, Horizontal,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0BC = new(0x0BC, 0x0E82,
		RoomDraw_Rightwards2x2_1to16, Horizontal,
		new[] { Collision, Hookshottable, Mutable },
		new())
	{
		LimitClass = DungeonLimits.GeneralManipulable,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object0BD = new(0x0BD, 0x1DF2,
		RoomDraw_Rightwards2x2_1to16, Horizontal,
		new[] { Collision, PuzzlePegs, Hookshottable, Mutable },
		new())
	{
		LimitClass = DungeonLimits.GeneralManipulable,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object0BE = new(0x0BE, 0x0000,
		RoomDraw_Nothing, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0BF = new(0x0BF, 0x0000,
		RoomDraw_Nothing, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0C0 = new(0x0C0, 0x03D8,
		RoomDraw_4x4BlocksIn4x4SuperSquare, Both,
		new[] { Collision, Ceiling },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0C1 = new(0x0C1, 0x0510,
		RoomDraw_ClosedChestPlatform, Both,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0C2 = new(0x0C2, 0x05AA,
		RoomDraw_4x4BlocksIn4x4SuperSquare, Both,
		new[] { Pit, MetaLayer },
		new())
	{
		Specialness = ObjectSpecialType.LayerMask,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object0C3 = new(0x0C3, 0x05AA,
		RoomDraw_3x3FloorIn4x4SuperSquare, Both,
		new[] { Pit, MetaLayer },
		new())
	{
		Specialness = ObjectSpecialType.LayerMask,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object0C4 = new(0x0C4, 0x0000,
		RoomDraw_4x4FloorOneIn4x4SuperSquare, Both,
		new[] { NoCollision, Floor },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0C5 = new(0x0C5, 0x0168,
		RoomDraw_4x4FloorIn4x4SuperSquare, Both,
		new[] { NoCollision, Floor },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0C6 = new(0x0C6, 0x00E0,
		RoomDraw_4x4FloorIn4x4SuperSquare, Both,
		new[] { Pit, MetaLayer },
		new())
	{
		Specialness = ObjectSpecialType.LayerMask,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object0C7 = new(0x0C7, 0x0158,
		RoomDraw_4x4FloorIn4x4SuperSquare, Both,
		new[] { NoCollision, Floor },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0C8 = new(0x0C8, 0x0100,
		RoomDraw_4x4FloorIn4x4SuperSquare, Both,
		new[] { NoCollision, Floor },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0C9 = new(0x0C9, 0x0110,
		RoomDraw_4x4FloorIn4x4SuperSquare, Both,
		new[] { NoCollision, Floor },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0CA = new(0x0CA, 0x0178,
		RoomDraw_4x4FloorIn4x4SuperSquare, Both,
		new[] { NoCollision, Floor },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0CB = new(0x0CB, 0x072A,
		RoomDraw_Nothing, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0CC = new(0x0CC, 0x072A,
		RoomDraw_Nothing, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0CD = new(0x0CD, 0x072A,
		RoomDraw_MovingWallWest, Both,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0CE = new(0x0CE, 0x075A,
		RoomDraw_MovingWallEast, Both,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0CF = new(0x0CF, 0x0670,
		RoomDraw_Nothing, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0D0 = new(0x0D0, 0x0670,
		RoomDraw_Nothing, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0D1 = new(0x0D1, 0x0130,
		RoomDraw_4x4FloorIn4x4SuperSquare, Both,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0D2 = new(0x0D2, 0x0148,
		RoomDraw_4x4FloorIn4x4SuperSquare, Both,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0D3 = new(0x0D3, 0x072A,
		RoomDraw_CheckIfWallIsMoved, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0D4 = new(0x0D4, 0x072A,
		RoomDraw_CheckIfWallIsMoved, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0D5 = new(0x0D5, 0x072A,
		RoomDraw_CheckIfWallIsMoved, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0D6 = new(0x0D6, 0x075A,
		RoomDraw_CheckIfWallIsMoved, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0D7 = new(0x0D7, 0x00E0,
		RoomDraw_3x3FloorIn4x4SuperSquare, Both,
		new[] { MetaLayer },
		new())
	{
		Specialness = ObjectSpecialType.LayerMask,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object0D8 = new(0x0D8, 0x0110,
		RoomDraw_WaterOverlay8x8_1to16, Both,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0D9 = new(0x0D9, 0x00F0,
		RoomDraw_4x4FloorIn4x4SuperSquare, Both,
		new[] { MetaLayer },
		new())
	{
		Specialness = ObjectSpecialType.LayerMask,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object0DA = new(0x0DA, 0x0110,
		RoomDraw_WaterOverlay8x8_1to16, Both,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0DB = new(0x0DB, 0x0000,
		RoomDraw_4x4FloorTwoIn4x4SuperSquare, Both,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0DC = new(0x0DC, 0x0AB4,
		RoomDraw_OpenChestPlatform, Both,
		new[] { RoomDecoration, Stairs },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0DD = new(0x0DD, 0x08DA,
		RoomDraw_TableRock4x4_1to16, Both,
		new[] { Collision, RoomDecoration },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0DE = new(0x0DE, 0x0ADE,
		RoomDraw_Spike2x2In4x4SuperSquare, Both,
		new[] { Spikes },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0DF = new(0x0DF, 0x0188,
		RoomDraw_4x4FloorIn4x4SuperSquare, Both,
		new[] { Spikes, Floor },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0E0 = new(0x0E0, 0x01A0,
		RoomDraw_4x4FloorIn4x4SuperSquare, Both,
		new[] { NoCollision, Floor },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0E1 = new(0x0E1, 0x01B0,
		RoomDraw_4x4FloorIn4x4SuperSquare, Both,
		new[] { NoCollision, Floor },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0E2 = new(0x0E2, 0x01C0,
		RoomDraw_4x4FloorIn4x4SuperSquare, Both,
		new[] { NoCollision, Floor },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0E3 = new(0x0E3, 0x01D0,
		RoomDraw_4x4FloorIn4x4SuperSquare, Both,
		new[] { NoCollision, Floor, Conveyor },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0E4 = new(0x0E4, 0x01E0,
		RoomDraw_4x4FloorIn4x4SuperSquare, Both,
		new[] { NoCollision, Floor, Conveyor },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0E5 = new(0x0E5, 0x01F0,
		RoomDraw_4x4FloorIn4x4SuperSquare, Both,
		new[] { NoCollision, Floor, Conveyor },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0E6 = new(0x0E6, 0x0200,
		RoomDraw_4x4FloorIn4x4SuperSquare, Both,
		new[] { NoCollision, Floor, Conveyor },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0E7 = new(0x0E7, 0x0120,
		RoomDraw_4x4FloorIn4x4SuperSquare, Both,
		new[] { NoCollision, Floor, Conveyor },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0E8 = new(0x0E8, 0x02A8,
		RoomDraw_4x4FloorIn4x4SuperSquare, Both,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0E9 = new(0x0E9, 0x0000,
		RoomDraw_Nothing, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0EA = new(0x0EA, 0x0000,
		RoomDraw_Nothing, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0EB = new(0x0EB, 0x0000,
		RoomDraw_Nothing, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0EC = new(0x0EC, 0x0000,
		RoomDraw_Nothing, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0ED = new(0x0ED, 0x0000,
		RoomDraw_Nothing, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0EE = new(0x0EE, 0x0000,
		RoomDraw_Nothing, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0EF = new(0x0EF, 0x0000,
		RoomDraw_Nothing, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0F0 = new(0x0F0, 0x0000,
		RoomDraw_Nothing, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0F1 = new(0x0F1, 0x0000,
		RoomDraw_Nothing, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0F2 = new(0x0F2, 0x0000,
		RoomDraw_Nothing, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0F3 = new(0x0F3, 0x0000,
		RoomDraw_Nothing, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0F4 = new(0x0F4, 0x0000,
		RoomDraw_Nothing, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0F5 = new(0x0F5, 0x0000,
		RoomDraw_Nothing, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0F6 = new(0x0F6, 0x0000,
		RoomDraw_Nothing, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object0F7 = new(0x0F7, 0x0000,
		RoomDraw_Nothing, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object100 = new(0x100, 0x0B66,
		RoomDraw_4x4Object, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object101 = new(0x101, 0x0B86,
		RoomDraw_4x4Object, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object102 = new(0x102, 0x0BA6,
		RoomDraw_4x4Object, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object103 = new(0x103, 0x0BC6,
		RoomDraw_4x4Object, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object104 = new(0x104, 0x0C66,
		RoomDraw_4x4Object, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object105 = new(0x105, 0x0C86,
		RoomDraw_4x4Object, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object106 = new(0x106, 0x0CA6,
		RoomDraw_4x4Object, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object107 = new(0x107, 0x0CC6,
		RoomDraw_4x4Object, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object108 = new(0x108, 0x0BE6,
		RoomDraw_4x4Corner_BothBG, None,
		new SearchCategory[] { },
		new())
	{
		BothBG = true,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object109 = new(0x109, 0x0C06,
		RoomDraw_4x4Corner_BothBG, None,
		new SearchCategory[] { },
		new())
	{
		BothBG = true,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object10A = new(0x10A, 0x0C26,
		RoomDraw_4x4Corner_BothBG, None,
		new SearchCategory[] { },
		new())
	{
		BothBG = true,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object10B = new(0x10B, 0x0C46,
		RoomDraw_4x4Corner_BothBG, None,
		new SearchCategory[] { },
		new())
	{
		BothBG = true,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object10C = new(0x10C, 0x0CE6,
		RoomDraw_4x4Corner_BothBG, None,
		new SearchCategory[] { },
		new())
	{
		BothBG = true,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object10D = new(0x10D, 0x0D06,
		RoomDraw_4x4Corner_BothBG, None,
		new SearchCategory[] { },
		new())
	{
		BothBG = true,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object10E = new(0x10E, 0x0D26,
		RoomDraw_4x4Corner_BothBG, None,
		new SearchCategory[] { },
		new())
	{
		BothBG = true,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object10F = new(0x10F, 0x0D46,
		RoomDraw_4x4Corner_BothBG, None,
		new SearchCategory[] { },
		new())
	{
		BothBG = true,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object110 = new(0x110, 0x0D66,
		RoomDraw_WeirdCornerBottom_BothBG, None,
		new SearchCategory[] { },
		new())
	{
		BothBG = true,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object111 = new(0x111, 0x0D7E,
		RoomDraw_WeirdCornerBottom_BothBG, None,
		new SearchCategory[] { },
		new())
	{
		BothBG = true,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object112 = new(0x112, 0x0D96,
		RoomDraw_WeirdCornerBottom_BothBG, None,
		new SearchCategory[] { },
		new())
	{
		BothBG = true,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object113 = new(0x113, 0x0DAE,
		RoomDraw_WeirdCornerBottom_BothBG, None,
		new SearchCategory[] { },
		new())
	{
		BothBG = true,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object114 = new(0x114, 0x0DC6,
		RoomDraw_WeirdCornerTop_BothBG, None,
		new SearchCategory[] { },
		new())
	{
		BothBG = true,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object115 = new(0x115, 0x0DDE,
		RoomDraw_WeirdCornerTop_BothBG, None,
		new SearchCategory[] { },
		new())
	{
		BothBG = true,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object116 = new(0x116, 0x0DF6,
		RoomDraw_WeirdCornerTop_BothBG, None,
		new SearchCategory[] { },
		new())
	{
		BothBG = true,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object117 = new(0x117, 0x0E0E,
		RoomDraw_WeirdCornerTop_BothBG, None,
		new SearchCategory[] { },
		new())
	{
		BothBG = true,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object118 = new(0x118, 0x0398,
		RoomDraw_Single2x2, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object119 = new(0x119, 0x03A0,
		RoomDraw_Single2x2, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object11A = new(0x11A, 0x03A8,
		RoomDraw_Single2x2, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object11B = new(0x11B, 0x03B0,
		RoomDraw_Single2x2, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object11C = new(0x11C, 0x0E32,
		RoomDraw_4x4Object, None,
		new[] { Collision, Pit, RoomDecoration },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object11D = new(0x11D, 0x0E26,
		RoomDraw_Single2x3Pillar, None,
		new[] { Collision, RoomDecoration, Hookshottable },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object11E = new(0x11E, 0x0EA2,
		RoomDraw_Single2x2, None,
		new[] { NoCollision, Pit },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object11F = new(0x11F, 0x0E9A,
		RoomDraw_Single2x2, None,
		new[] { NoCollision, Pit },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object120 = new(0x120, 0x0ECA,
		RoomDraw_Single2x2, None,
		new[] { Collision, RoomDecoration, Hookshottable },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object121 = new(0x121, 0x0ED2,
		RoomDraw_Single2x3Pillar, None,
		new[] { Collision, RoomDecoration },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object122 = new(0x122, 0x0EDE,
		RoomDraw_Bed4x5, None,
		new[] { Collision, RoomDecoration },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object123 = new(0x123, 0x0EDE,
		RoomDraw_4x3OneLayer, None,
		new[] { Collision, RoomDecoration },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object124 = new(0x124, 0x0F1E,
		RoomDraw_4x4Object, None,
		new[] { Collision, WallDecoration },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object125 = new(0x125, 0x0F3E,
		RoomDraw_4x4Object, None,
		new[] { Collision, WallDecoration },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object126 = new(0x126, 0x0F5E,
		RoomDraw_Single2x3Pillar, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object127 = new(0x127, 0x0F6A,
		RoomDraw_Single2x2, None,
		new[] { Collision, RoomDecoration },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object128 = new(0x128, 0x0EF6,
		RoomDraw_YBed4x5, None,
		new[] { Collision, RoomDecoration },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object129 = new(0x129, 0x0F72,
		RoomDraw_4x4Object, None,
		new[] { Collision, WallDecoration },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object12A = new(0x12A, 0x0F92,
		RoomDraw_PortraitOfMario, None,
		new[] { Collision, WallDecoration, UpperLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object12B = new(0x12B, 0x0FA2,
		RoomDraw_Single2x2, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object12C = new(0x12C, 0x0FA2,
		RoomDraw_DrawRightwards3x6, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object12D = new(0x12D, 0x1088,
		RoomDraw_InterRoomFatStairs, None,
		new[] { Stairs },
		new())
	{
		Specialness = ObjectSpecialType.InterroomStairs,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object12E = new(0x12E, 0x10A8,
		RoomDraw_InterRoomFatStairs, None,
		new[] { Stairs, RoomTransition },
		new())
	{
		Specialness = ObjectSpecialType.InterroomStairs,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object12F = new(0x12F, 0x10A8,
		RoomDraw_InterRoomFatStairs, None,
		new[] { Stairs, RoomTransition },
		new())
	{
		Specialness = ObjectSpecialType.InterroomStairs,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object130 = new(0x130, 0x10C8,
		RoomDraw_AutoStairs, None,
		new[] { Stairs },
		new())
	{
		BothBG = true,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object131 = new(0x131, 0x10C8,
		RoomDraw_AutoStairs, None,
		new[] { Stairs },
		new())
	{
		BothBG = true,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object132 = new(0x132, 0x10C8,
		RoomDraw_AutoStairsMerged, None,
		new[] { Stairs },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object133 = new(0x133, 0x10C8,
		RoomDraw_AutoStairsMerged, None,
		new[] { Stairs },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object134 = new(0x134, 0x0E52,
		RoomDraw_Single2x2, None,
		new[] { Collision, RoomDecoration, Hookshottable },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object135 = new(0x135, 0x1108,
		RoomDraw_WaterHopStairs_A, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object136 = new(0x136, 0x1108,
		RoomDraw_WaterHopStairs_B, None,
		new SearchCategory[] { },
		new())
	{
		BothBG = true,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object137 = new(0x137, 0x12A8,
		RoomDraw_DamFloodGate, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object138 = new(0x138, 0x1148,
		RoomDraw_SpiralStairs, None,
		new[] { Stairs, RoomTransition },
		new())
	{
		Specialness = ObjectSpecialType.InterroomStairs,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object139 = new(0x139, 0x1160,
		RoomDraw_SpiralStairs, None,
		new[] { Stairs, RoomTransition },
		new())
	{
		Specialness = ObjectSpecialType.InterroomStairs,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object13A = new(0x13A, 0x1178,
		RoomDraw_SpiralStairs, None,
		new[] { Stairs, RoomTransition },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object13B = new(0x13B, 0x1190,
		RoomDraw_SpiralStairs, None,
		new[] { Stairs, RoomTransition },
		new())
	{
		Specialness = ObjectSpecialType.InterroomStairs,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object13C = new(0x13C, 0x1458,
		RoomDraw_SanctuaryWall, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object13D = new(0x13D, 0x1488,
		RoomDraw_4x3OneLayer, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object13E = new(0x13E, 0x2062,
		RoomDraw_Utility6x3, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object13F = new(0x13F, 0x2086,
		RoomDraw_MagicBatAltar, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object200 = new(0x200, 0x1614,
		RoomDraw_EmptyWaterFace, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object201 = new(0x201, 0x162C,
		RoomDraw_SpittingWaterFace, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object202 = new(0x202, 0x1654,
		RoomDraw_DrenchingWaterFace, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object203 = new(0x203, 0x0A0E,
		RoomDraw_SomariaLine, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object204 = new(0x204, 0x0A0C,
		RoomDraw_SomariaLine, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object205 = new(0x205, 0x09FC,
		RoomDraw_SomariaLine, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object206 = new(0x206, 0x09FE,
		RoomDraw_SomariaLine, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object207 = new(0x207, 0x0A00,
		RoomDraw_SomariaLine, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object208 = new(0x208, 0x0A02,
		RoomDraw_SomariaLine, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object209 = new(0x209, 0x0A04,
		RoomDraw_SomariaLine, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object20A = new(0x20A, 0x0A06,
		RoomDraw_SomariaLine, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object20B = new(0x20B, 0x0A08,
		RoomDraw_SomariaLine, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object20C = new(0x20C, 0x0A0A,
		RoomDraw_SomariaLine, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object20D = new(0x20D, 0x0000,
		RoomDraw_PrisonCell, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object20E = new(0x20E, 0x0A10,
		RoomDraw_SomariaLine, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object20F = new(0x20F, 0x0A12,
		RoomDraw_SomariaLine, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object210 = new(0x210, 0x1DDA,
		RoomDraw_Single2x2, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object211 = new(0x211, 0x1DE2,
		RoomDraw_Single2x2, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object212 = new(0x212, 0x1DD6,
		RoomDraw_RupeeFloor, None,
		new[] { NoCollision, Floor, Secrets },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object213 = new(0x213, 0x1DEA,
		RoomDraw_Single2x2, None,
		new[] { Collision, WallDecoration, Hookshottable },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object214 = new(0x214, 0x15FC,
		RoomDraw_4x3OneLayer, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object215 = new(0x215, 0x1DFA,
		RoomDraw_KholdstareShell, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object216 = new(0x216, 0x1DF2,
		RoomDraw_Single2x2, None,
		new[] { Collision, PuzzlePegs, Hookshottable, Mutable },
		new())
	{
		LimitClass = DungeonLimits.GeneralManipulable,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object217 = new(0x217, 0x1488,
		RoomDraw_PrisonCell, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object218 = new(0x218, 0x1494,
		RoomDraw_Single2x2, None,
		new SearchCategory[] { },
		new())
	{
		Specialness = ObjectSpecialType.BigChest,
		LimitClass = DungeonLimits.Chest,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object219 = new(0x219, 0x149C,
		RoomDraw_Single2x2, None,
		new[] { Collision, RoomDecoration, Secrets, Hookshottable },
		new())
	{
		Specialness = ObjectSpecialType.Chest,
		LimitClass = DungeonLimits.Chest,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object21A = new(0x21A, 0x14A4,
		RoomDraw_Single2x2, None,
		new[] { Collision, RoomDecoration, Hookshottable },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object21B = new(0x21B, 0x10E8,
		RoomDraw_AutoStairs, None,
		new SearchCategory[] { },
		new())
	{
		BothBG = true,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object21C = new(0x21C, 0x10E8,
		RoomDraw_AutoStairs, None,
		new SearchCategory[] { },
		new())
	{
		BothBG = true,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object21D = new(0x21D, 0x10E8,
		RoomDraw_AutoStairs, None,
		new SearchCategory[] { },
		new())
	{
		BothBG = true,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object21E = new(0x21E, 0x11A8,
		RoomDraw_StraightInterroomStairs, None,
		new[] { Stairs, RoomTransition },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object21F = new(0x21F, 0x11C8,
		RoomDraw_StraightInterroomStairs, None,
		new[] { Stairs, RoomTransition },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object220 = new(0x220, 0x11E8,
		RoomDraw_StraightInterroomStairs, None,
		new[] { Stairs, RoomTransition },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object221 = new(0x221, 0x1208,
		RoomDraw_StraightInterroomStairs, None,
		new[] { Stairs, RoomTransition },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object222 = new(0x222, 0x03B8,
		RoomDraw_Single2x2, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object223 = new(0x223, 0x03C0,
		RoomDraw_Single2x2, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object224 = new(0x224, 0x03C8,
		RoomDraw_Single2x2, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object225 = new(0x225, 0x03D0,
		RoomDraw_Single2x2, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object226 = new(0x226, 0x1228,
		RoomDraw_StraightInterroomStairs, None,
		new[] { Stairs, RoomTransition },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object227 = new(0x227, 0x1248,
		RoomDraw_StraightInterroomStairs, None,
		new[] { Stairs, RoomTransition },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object228 = new(0x228, 0x1268,
		RoomDraw_StraightInterroomStairs, None,
		new[] { Stairs, RoomTransition },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object229 = new(0x229, 0x1288,
		RoomDraw_StraightInterroomStairs, None,
		new[] { Stairs, RoomTransition },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object22A = new(0x22A, 0x0000,
		RoomDraw_LampCones, None,
		new[] { LowerLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object22B = new(0x22B, 0x0E5A,
		RoomDraw_Single2x2, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object22C = new(0x22C, 0x0E62,
		RoomDraw_BigGrayRock, None,
		new[] { Collision, RoomDecoration, Secrets, Mutable, Hookshottable },
		new())
	{
		LimitClass = DungeonLimits.GeneralManipulable4x,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object22D = new(0x22D, 0x0000,
		RoomDraw_AgahnimsAltar, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object22E = new(0x22E, 0x0000,
		RoomDraw_AgahnimsWindows, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object22F = new(0x22F, 0x0E82,
		RoomDraw_Single2x2, None,
		new[] { Collision, RoomDecoration, Secrets, Mutable, Hookshottable },
		new())
	{
		LimitClass = DungeonLimits.GeneralManipulable,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object230 = new(0x230, 0x0E8A,
		RoomDraw_Single2x2, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object231 = new(0x231, 0x14AC,
		RoomDraw_4x3OneLayer, None,
		new[] { Collision, RoomDecoration, Secrets, Hookshottable },
		new())
	{
		Specialness = ObjectSpecialType.BigChest,
		LimitClass = DungeonLimits.Chest,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object232 = new(0x232, 0x14C4,
		RoomDraw_4x3OneLayer, None,
		new[] { Collision, RoomDecoration, Hookshottable },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object233 = new(0x233, 0x10E8,
		RoomDraw_AutoStairs, None,
		new[] { Stairs },
		new())
	{
		BothBG = true,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object234 = new(0x234, 0x1614,
		RoomDraw_ChestPlatformVerticalWall, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object235 = new(0x235, 0x1614,
		RoomDraw_ChestPlatformVerticalWall, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object236 = new(0x236, 0x1614,
		RoomDraw_DrawRightwards3x6, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object237 = new(0x237, 0x1614,
		RoomDraw_DrawRightwards3x6, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object238 = new(0x238, 0x1614,
		RoomDraw_ChestPlatformVerticalWall, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object239 = new(0x239, 0x1614,
		RoomDraw_ChestPlatformVerticalWall, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object23A = new(0x23A, 0x1CBE,
		RoomDraw_VerticalTurtleRockPipe, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object23B = new(0x23B, 0x1CEE,
		RoomDraw_VerticalTurtleRockPipe, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object23C = new(0x23C, 0x1D1E,
		RoomDraw_HorizontalTurtleRockPipe, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object23D = new(0x23D, 0x1D4E,
		RoomDraw_HorizontalTurtleRockPipe, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object23E = new(0x23E, 0x1D8E,
		RoomDraw_Single2x2, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object23F = new(0x23F, 0x1D96,
		RoomDraw_Single2x2, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object240 = new(0x240, 0x1D9E,
		RoomDraw_Single2x2, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object241 = new(0x241, 0x1DA6,
		RoomDraw_Single2x2, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object242 = new(0x242, 0x1DAE,
		RoomDraw_Single2x2, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object243 = new(0x243, 0x1DB6,
		RoomDraw_Single2x2, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object244 = new(0x244, 0x1DBE,
		RoomDraw_Single2x2, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object245 = new(0x245, 0x1DC6,
		RoomDraw_Single2x2, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object246 = new(0x246, 0x1DCE,
		RoomDraw_Single2x2, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object247 = new(0x247, 0x0220,
		RoomDraw_BombableFloor, None,
		new[] { NoCollision, Floor, Pit, Mutable },
		new())
	{
		LimitClass = DungeonLimits.GeneralManipulable4x,
	};

	[PredefinedInstance]
	public static readonly RoomObjectType Object248 = new(0x248, 0x0260,
		RoomDraw_4x4Object, None,
		new[] { NoCollision, Floor },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object249 = new(0x249, 0x0280,
		RoomDraw_Single2x2, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object24A = new(0x24A, 0x1F3A,
		RoomDraw_Single2x2, None,
		new[] { RoomTransition },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object24B = new(0x24B, 0x1F62,
		RoomDraw_BigWallDecor, None,
		new[] { Collision, WallDecoration, NorthSide },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object24C = new(0x24C, 0x1F92,
		RoomDraw_SmithyFurnace, None,
		new[] { Collision, RoomDecoration },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object24D = new(0x24D, 0x1FF2,
		RoomDraw_Utility6x3, None,
		new[] { Collision, RoomDecoration },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object24E = new(0x24E, 0x2016,
		RoomDraw_4x3OneLayer, None,
		new[] { Collision, RoomDecoration },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object24F = new(0x24F, 0x1F42,
		RoomDraw_Single2x2, None,
		new[] { NoCollision, Floor },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object250 = new(0x250, 0x0EAA,
		RoomDraw_Single2x2, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object251 = new(0x251, 0x1F4A,
		RoomDraw_Single2x2, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object252 = new(0x252, 0x1F52,
		RoomDraw_Single2x2, None,
		new[] { Collision, PuzzlePegs, Hookshottable },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object253 = new(0x253, 0x1F5A,
		RoomDraw_Single2x2, None,
		new[] { Collision, PuzzlePegs, Hookshottable },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object254 = new(0x254, 0x202E,
		RoomDraw_FortuneTellerRoom, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object255 = new(0x255, 0x2062,
		RoomDraw_Utility3x5, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object256 = new(0x256, 0x09B8,
		RoomDraw_Single2x2, None,
		new[] { Collision, RoomDecoration },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object257 = new(0x257, 0x09C0,
		RoomDraw_Single2x2, None,
		new[] { Collision, RoomDecoration },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object258 = new(0x258, 0x09C8,
		RoomDraw_Single2x2, None,
		new[] { Collision, RoomDecoration },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object259 = new(0x259, 0x09D0,
		RoomDraw_Single2x2, None,
		new[] { Collision, RoomDecoration },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object25A = new(0x25A, 0x0FA2,
		RoomDraw_TableBowl, None,
		new[] { Collision, RoomDecoration },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object25B = new(0x25B, 0x0FB2,
		RoomDraw_Utility3x5, None,
		new[] { Collision, RoomDecoration },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object25C = new(0x25C, 0x0FC4,
		RoomDraw_HorizontalTurtleRockPipe, None,
		new[] { Collision, RoomDecoration },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object25D = new(0x25D, 0x0FF4,
		RoomDraw_Utility6x3, None,
		new[] { Collision, RoomDecoration },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object25E = new(0x25E, 0x1018,
		RoomDraw_Single2x2, None,
		new[] { Collision, RoomDecoration },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object25F = new(0x25F, 0x1020,
		RoomDraw_Single2x2, None,
		new[] { Collision, RoomDecoration },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object260 = new(0x260, 0x15B4,
		RoomDraw_ArcheryGameTargetDoor, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object261 = new(0x261, 0x15D8,
		RoomDraw_ArcheryGameTargetDoor, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object262 = new(0x262, 0x20F6,
		RoomDraw_VitreousGooGraphics, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object263 = new(0x263, 0x0EBA,
		RoomDraw_Single2x2, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object264 = new(0x264, 0x22E6,
		RoomDraw_Single2x2, None,
		new[] { Collision, RoomDecoration },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object265 = new(0x265, 0x22EE,
		RoomDraw_Single2x2, None,
		new[] { Collision, RoomDecoration },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object266 = new(0x266, 0x05DA,
		RoomDraw_4x4Object, None,
		new[] { Pit },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object267 = new(0x267, 0x281E,
		RoomDraw_4x3OneLayer, None,
		new[] { Collision, WallDecoration, NorthSide, UpperLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object268 = new(0x268, 0x2AE0,
		RoomDraw_4x3OneLayer, None,
		new[] { Collision, WallDecoration, SouthSide, UpperLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object269 = new(0x269, 0x2D2A,
		RoomDraw_SolidWallDecor3x4, None,
		new[] { Collision, WallDecoration, WestSide, UpperLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object26A = new(0x26A, 0x2F2A,
		RoomDraw_SolidWallDecor3x4, None,
		new[] { Collision, WallDecoration, EastSide, UpperLayer },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object26B = new(0x26B, 0x22F6,
		RoomDraw_4x4Object, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object26C = new(0x26C, 0x2316,
		RoomDraw_4x3OneLayer, None,
		new[] { Collision, WallDecoration, NorthSide },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object26D = new(0x26D, 0x232E,
		RoomDraw_4x3OneLayer, None,
		new[] { Collision, WallDecoration, SouthSide },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object26E = new(0x26E, 0x2346,
		RoomDraw_SolidWallDecor3x4, None,
		new[] { Collision, WallDecoration, WestSide },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object26F = new(0x26F, 0x235E,
		RoomDraw_SolidWallDecor3x4, None,
		new[] { Collision, WallDecoration, EastSide },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object270 = new(0x270, 0x2376,
		RoomDraw_LightBeamOnFloor, None,
		new[] { NoCollision, Floor },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object271 = new(0x271, 0x23B6,
		RoomDraw_BigLightBeamOnFloor, None,
		new[] { NoCollision, Floor },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object272 = new(0x272, 0x1E9A,
		RoomDraw_TrinexxShell, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object273 = new(0x273, 0x0000,
		RoomDraw_BG2MaskFull, None,
		new SearchCategory[] { },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object274 = new(0x274, 0x2436,
		RoomDraw_FloorLight, None,
		new[] { Collision, WallDecoration, NorthSide, Hookshottable },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object275 = new(0x275, 0x149C,
		RoomDraw_Single2x2, None,
		new[] { Collision, RoomDecoration, Secrets, Hookshottable },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object276 = new(0x276, 0x24B6,
		RoomDraw_BigWallDecor, None,
		new[] { Collision, WallDecoration, NorthSide },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object277 = new(0x277, 0x24E6,
		RoomDraw_BigWallDecor, None,
		new[] { Collision, WallDecoration, NorthSide },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object278 = new(0x278, 0x2516,
		RoomDraw_GanonTriforceFloorDecor, None,
		new[] { NoCollision, Floor },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object279 = new(0x279, 0x1028,
		RoomDraw_4x3OneLayer, None,
		new[] { Collision, WallDecoration, NorthSide },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object27A = new(0x27A, 0x1040,
		RoomDraw_4x4Object, None,
		new[] { NoCollision, Floor },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object27B = new(0x27B, 0x1060,
		RoomDraw_VitreousGooDamage, None,
		new[] { Spikes },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object27C = new(0x27C, 0x1070,
		RoomDraw_Single2x2, None,
		new[] { NoCollision, Floor },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object27D = new(0x27D, 0x1078,
		RoomDraw_Single2x2, None,
		new[] { NoCollision, Floor },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object27E = new(0x27E, 0x1080,
		RoomDraw_Single2x2, None,
		new[] { NoCollision, Floor },
		new());

	[PredefinedInstance]
	public static readonly RoomObjectType Object27F = new(0x27F, 0x0000,
		RoomDraw_Nothing, None,
		new SearchCategory[] { },
		new());
}
