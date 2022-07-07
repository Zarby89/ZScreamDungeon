using static ZeldaFullEditor.ALTTP.Underworld.DoorCategory;

namespace ZeldaFullEditor.ALTTP.Underworld;

public class DungeonDoorType : IEntityType<DungeonDoorType>
{
	public byte ID { get; }
	public int ListID => ID;

	public DoorCategory Category { get; }
	public bool IsExit { get; }

	public string Name { get; init; }

	internal DoorDrawFunction SpecialDraw { get; }

	internal DungeonDoorType OppositeDoor { get; }

	// TODO not sure how to handle doors anymore
	private DungeonDoorType(byte id, string name, DoorCategory category, bool exit = false, DoorDrawFunction spdraw = null, DungeonDoorType opp = null)
	{
		ID = id;
		Name = name;
		Category = category;
		IsExit = exit;
		SpecialDraw = spdraw;
		OppositeDoor = opp ?? this;
	}

	public override string ToString() => $"{ID:X2} - {Name}";

	public static ImmutableArray<DungeonDoorType> ListOf { get; }

	// Need to use static constructor for reflection to work properly
	static DungeonDoorType()
	{
		ListOf = Utils.GetSortedListOfPredefinedFields<DungeonDoorType>();
	}

	public static DungeonDoorType GetTypeFromID(byte id) => ListOf.GetTypeFromID(id);


	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType00 = new(0x00, "Normal door", Unspecial);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType02 = new(0x02, "Normal door (lower layer)", Unspecial);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType04 = new(0x04, "Exit (lower layer)", Unspecial, exit: true);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType06 = new(0x06, "Unused cave exit (lower layer)", Unspecial, exit: true);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType08 = new(0x08, "Waterfall door", Unspecial);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType0A = new(0x0A, "Fancy dungeon exit", Fancy, exit: true, spdraw: DungeonDoorDraw.DrawFancyEntrance);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType0C = new(0x0C, "Fancy dungeon exit (lower layer)", Fancy, exit: true, spdraw: DungeonDoorDraw.DrawFancyEntrance);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType0E = new(0x0E, "Cave exit", Unspecial, exit: true);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType10 = new(0x10, "Lit cave exit (lower layer)", Unspecial, exit: true);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType12 = new(0x12, "Exit marker", Meta, exit: true, spdraw: DungeonDoorDraw.DrawNothing);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType14 = new(0x14, "Dungeon swap marker", DungeonSwap, spdraw: DungeonDoorDraw.DrawNothing);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType16 = new(0x16, "Layer swap marker", LayerSwap, spdraw: DungeonDoorDraw.DrawNothing);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType18 = new(0x18, "Double sided shutter door", Shutter);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType1A = new(0x1A, "Eye watch door", Shutter);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType1C = new(0x1C, "Small key door", Openable);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType1E = new(0x1E, "Big key door", Openable, opp: DoorType00);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType20 = new(0x20, "Small key stairs (upwards)", Openable, spdraw: DungeonDoorDraw.DrawKeyStairsUp);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType22 = new(0x22, "Small key stairs (downwards)", Openable, spdraw: DungeonDoorDraw.DrawKeyStairsDown);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType24 = new(0x24, "Small key stairs (lower layer; upwards)", Openable, spdraw: DungeonDoorDraw.DrawKeyStairsUp);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType26 = new(0x26, "Small key stairs (lower layer; downwards)", Openable, spdraw: DungeonDoorDraw.DrawKeyStairsDown);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType28 = new(0x28, "Dash wall", Openable);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType2A = new(0x2A, "Bombable cave exit", Openable, exit: true);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType2C = new(0x2C, "Unopenable, double-sided big key door", Garbage);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType2E = new(0x2E, "Bombable door", Openable);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType30 = new(0x30, "Exploding wall", Openable, spdraw: DungeonDoorDraw.DrawExplodingWall);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType32 = new(0x32, "Curtain door", Openable);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType34 = new(0x34, "Unusable bottom-sided shutter door", Garbage);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType36 = new(0x36, "Bottom-sided shutter door", Shutter);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType38 = new(0x38, "Top-sided shutter door", Shutter);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType3A = new(0x3A, "Unusable normal door (lower layer)", Garbage);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType3C = new(0x3C, "Unusable normal door (lower layer)", Garbage);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType3E = new(0x3E, "Unusable normal door (lower layer)", Garbage);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType40 = new(0x40, "Normal door (lower layer; used with one-sided shutters)", Unspecial);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType42 = new(0x42, "Unused double-sided shutter", Shutter);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType44 = new(0x44, "Double-sided shutter (lower layer)", Shutter);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType46 = new(0x46, "Explicit room door", Meta);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType48 = new(0x48, "Bottom-sided shutter door (lower layer)", Shutter);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType4A = new(0x4A, "Top-sided shutter door (lower layer)", Shutter);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType4C = new(0x4C, "Unusable normal door (lower layer)", Garbage);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType4E = new(0x4E, "Unusable normal door (lower layer)", Garbage);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType50 = new(0x50, "Unusable normal door (lower layer)", Garbage);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType52 = new(0x52, "Unusable bombed-open door (lower layer)", Garbage);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType54 = new(0x54, "Unusable glitchy door (lower layer)", Garbage);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType56 = new(0x56, "Unusable glitchy door (lower layer)", Garbage);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType58 = new(0x58, "Unusable normal door (lower layer)", Garbage);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType5A = new(0x5A, "Unusable glitchy/stairs up (lower layer)", Garbage);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType5C = new(0x5C, "Unusable glitchy/stairs up (lower layer)", Garbage);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType5E = new(0x5E, "Unusable glitchy/stairs up (lower layer)", Garbage);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType60 = new(0x60, "Unusable glitchy/stairs up (lower layer)", Garbage);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType62 = new(0x62, "Unusable glitchy/stairs down (lower layer)", Garbage);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType64 = new(0x64, "Unusable glitchy/stairs up (lower layer)", Garbage);

	[PredefinedInstance]
	public static readonly DungeonDoorType DoorType66 = new(0x66, "Unusable glitchy/stairs down (lower layer)", Garbage);
}
