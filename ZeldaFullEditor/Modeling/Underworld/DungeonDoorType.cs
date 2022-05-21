using static ZeldaFullEditor.Modeling.Underworld.DoorCategory;

namespace ZeldaFullEditor.Modeling.Underworld
{
	public class DungeonDoorType : IEntityType<DungeonDoorType>
	{
		public byte ID { get; }

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

		public static readonly DungeonDoorType DoorType00 = new(0x00, "Normal door", Unspecial);
		public static readonly DungeonDoorType DoorType02 = new(0x02, "Normal door (lower layer)", Unspecial);
		public static readonly DungeonDoorType DoorType04 = new(0x04, "Exit (lower layer)", Unspecial, exit: true);
		public static readonly DungeonDoorType DoorType06 = new(0x06, "Unused cave exit (lower layer)", Unspecial, exit: true);
		public static readonly DungeonDoorType DoorType08 = new(0x08, "Waterfall door", Unspecial);
		public static readonly DungeonDoorType DoorType0A = new(0x0A, "Fancy dungeon exit", Fancy, exit: true, spdraw: DungeonDoorDraw.DrawFancyEntrance);
		public static readonly DungeonDoorType DoorType0C = new(0x0C, "Fancy dungeon exit (lower layer)", Fancy, exit: true, spdraw: DungeonDoorDraw.DrawFancyEntrance);
		public static readonly DungeonDoorType DoorType0E = new(0x0E, "Cave exit", Unspecial, exit: true);
		public static readonly DungeonDoorType DoorType10 = new(0x10, "Lit cave exit (lower layer)", Unspecial, exit: true);
		public static readonly DungeonDoorType DoorType12 = new(0x12, "Exit marker", Meta, exit: true, spdraw: DungeonDoorDraw.DrawNothing);
		public static readonly DungeonDoorType DoorType14 = new(0x14, "Dungeon swap marker", DungeonSwap, spdraw: DungeonDoorDraw.DrawNothing);
		public static readonly DungeonDoorType DoorType16 = new(0x16, "Layer swap marker", LayerSwap, spdraw: DungeonDoorDraw.DrawNothing);
		public static readonly DungeonDoorType DoorType18 = new(0x18, "Double sided shutter door", Shutter);
		public static readonly DungeonDoorType DoorType1A = new(0x1A, "Eye watch door", Shutter);
		public static readonly DungeonDoorType DoorType1C = new(0x1C, "Small key door", Openable);
		public static readonly DungeonDoorType DoorType1E = new(0x1E, "Big key door", Openable, opp: DoorType00);
		public static readonly DungeonDoorType DoorType20 = new(0x20, "Small key stairs (upwards)", Openable, spdraw: DungeonDoorDraw.DrawKeyStairsUp);
		public static readonly DungeonDoorType DoorType22 = new(0x22, "Small key stairs (downwards)", Openable, spdraw: DungeonDoorDraw.DrawKeyStairsDown);
		public static readonly DungeonDoorType DoorType24 = new(0x24, "Small key stairs (lower layer; upwards)", Openable, spdraw: DungeonDoorDraw.DrawKeyStairsUp);
		public static readonly DungeonDoorType DoorType26 = new(0x26, "Small key stairs (lower layer; downwards)", Openable, spdraw: DungeonDoorDraw.DrawKeyStairsDown);
		public static readonly DungeonDoorType DoorType28 = new(0x28, "Dash wall", Openable);
		public static readonly DungeonDoorType DoorType2A = new(0x2A, "Bombable cave exit", Openable, exit: true);
		public static readonly DungeonDoorType DoorType2C = new(0x2C, "Unopenable, double-sided big key door", Garbage);
		public static readonly DungeonDoorType DoorType2E = new(0x2E, "Bombable door", Openable);
		public static readonly DungeonDoorType DoorType30 = new(0x30, "Exploding wall", Openable, spdraw: DungeonDoorDraw.DrawExplodingWall);
		public static readonly DungeonDoorType DoorType32 = new(0x32, "Curtain door", Openable);
		public static readonly DungeonDoorType DoorType34 = new(0x34, "Unusable bottom-sided shutter door", Garbage);
		public static readonly DungeonDoorType DoorType36 = new(0x36, "Bottom-sided shutter door", Shutter);
		public static readonly DungeonDoorType DoorType38 = new(0x38, "Top-sided shutter door", Shutter);
		public static readonly DungeonDoorType DoorType3A = new(0x3A, "Unusable normal door (lower layer)", Garbage);
		public static readonly DungeonDoorType DoorType3C = new(0x3C, "Unusable normal door (lower layer)", Garbage);
		public static readonly DungeonDoorType DoorType3E = new(0x3E, "Unusable normal door (lower layer)", Garbage);
		public static readonly DungeonDoorType DoorType40 = new(0x40, "Normal door (lower layer; used with one-sided shutters)", Unspecial);
		public static readonly DungeonDoorType DoorType42 = new(0x42, "Unused double-sided shutter", Shutter);
		public static readonly DungeonDoorType DoorType44 = new(0x44, "Double-sided shutter (lower layer)", Shutter);
		public static readonly DungeonDoorType DoorType46 = new(0x46, "Explicit room door", Meta);
		public static readonly DungeonDoorType DoorType48 = new(0x48, "Bottom-sided shutter door (lower layer)", Shutter);
		public static readonly DungeonDoorType DoorType4A = new(0x4A, "Top-sided shutter door (lower layer)", Shutter);
		public static readonly DungeonDoorType DoorType4C = new(0x4C, "Unusable normal door (lower layer)", Garbage);
		public static readonly DungeonDoorType DoorType4E = new(0x4E, "Unusable normal door (lower layer)", Garbage);
		public static readonly DungeonDoorType DoorType50 = new(0x50, "Unusable normal door (lower layer)", Garbage);
		public static readonly DungeonDoorType DoorType52 = new(0x52, "Unusable bombed-open door (lower layer)", Garbage);
		public static readonly DungeonDoorType DoorType54 = new(0x54, "Unusable glitchy door (lower layer)", Garbage);
		public static readonly DungeonDoorType DoorType56 = new(0x56, "Unusable glitchy door (lower layer)", Garbage);
		public static readonly DungeonDoorType DoorType58 = new(0x58, "Unusable normal door (lower layer)", Garbage);
		public static readonly DungeonDoorType DoorType5A = new(0x5A, "Unusable glitchy/stairs up (lower layer)", Garbage);
		public static readonly DungeonDoorType DoorType5C = new(0x5C, "Unusable glitchy/stairs up (lower layer)", Garbage);
		public static readonly DungeonDoorType DoorType5E = new(0x5E, "Unusable glitchy/stairs up (lower layer)", Garbage);
		public static readonly DungeonDoorType DoorType60 = new(0x60, "Unusable glitchy/stairs up (lower layer)", Garbage);
		public static readonly DungeonDoorType DoorType62 = new(0x62, "Unusable glitchy/stairs down (lower layer)", Garbage);
		public static readonly DungeonDoorType DoorType64 = new(0x64, "Unusable glitchy/stairs up (lower layer)", Garbage);
		public static readonly DungeonDoorType DoorType66 = new(0x66, "Unusable glitchy/stairs down (lower layer)", Garbage);

		public static readonly DungeonDoorType[] ListOf =
		{
			DoorType00,
			DoorType02,
			DoorType04,
			DoorType06,
			DoorType08,
			DoorType0A,
			DoorType0C,
			DoorType0E,
			DoorType10,
			DoorType12,
			DoorType14,
			DoorType16,
			DoorType18,
			DoorType1A,
			DoorType1C,
			DoorType1E,
			DoorType20,
			DoorType22,
			DoorType24,
			DoorType26,
			DoorType28,
			DoorType2A,
			DoorType2C,
			DoorType2E,
			DoorType30,
			DoorType32,
			DoorType34,
			DoorType36,
			DoorType38,
			DoorType3A,
			DoorType3C,
			DoorType3E,
			DoorType40,
			DoorType42,
			DoorType44,
			DoorType46,
			DoorType48,
			DoorType4A,
			DoorType4C,
			DoorType4E,
			DoorType50,
			DoorType52,
			DoorType54,
			DoorType56,
			DoorType58,
			DoorType5A,
			DoorType5C,
			DoorType5E,
			DoorType60,
			DoorType62,
			DoorType64,
			DoorType66,
		};


		public static DungeonDoorType GetTypeFromID(int b) => b switch
		{
			0x00 => DoorType00,
			0x02 => DoorType02,
			0x04 => DoorType04,
			0x06 => DoorType06,
			0x08 => DoorType08,
			0x0A => DoorType0A,
			0x0C => DoorType0C,
			0x0E => DoorType0E,
			0x10 => DoorType10,
			0x12 => DoorType12,
			0x14 => DoorType14,
			0x16 => DoorType16,
			0x18 => DoorType18,
			0x1A => DoorType1A,
			0x1C => DoorType1C,
			0x1E => DoorType1E,
			0x20 => DoorType20,
			0x22 => DoorType22,
			0x24 => DoorType24,
			0x26 => DoorType26,
			0x28 => DoorType28,
			0x2A => DoorType2A,
			0x2C => DoorType2C,
			0x2E => DoorType2E,
			0x30 => DoorType30,
			0x32 => DoorType32,
			0x34 => DoorType34,
			0x36 => DoorType36,
			0x38 => DoorType38,
			0x3A => DoorType3A,
			0x3C => DoorType3C,
			0x3E => DoorType3E,
			0x40 => DoorType40,
			0x42 => DoorType42,
			0x44 => DoorType44,
			0x46 => DoorType46,
			0x48 => DoorType48,
			0x4A => DoorType4A,
			0x4C => DoorType4C,
			0x4E => DoorType4E,
			0x50 => DoorType50,
			0x52 => DoorType52,
			0x54 => DoorType54,
			0x56 => DoorType56,
			0x58 => DoorType58,
			0x5A => DoorType5A,
			0x5C => DoorType5C,
			0x5E => DoorType5E,
			0x60 => DoorType60,
			0x62 => DoorType62,
			0x64 => DoorType64,
			0x66 => DoorType66,
			_ => null,
		};
	}
}
