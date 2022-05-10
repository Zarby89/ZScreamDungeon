using static ZeldaFullEditor.DoorCategory;

namespace ZeldaFullEditor.Data
{
	public class DungeonDoorType : IEntityType<DungeonDoorType>
	{
		public byte ID { get; }

		public DoorCategory Category { get; }
		public bool IsExit { get; }
		private DungeonDoorType(byte id, DoorCategory category, bool exit = false)
		{
			ID = id;
			Category = category;
			IsExit = exit;
		}

		public static readonly DungeonDoorType DoorType00 = new(0x00, Unspecial);
		public static readonly DungeonDoorType DoorType02 = new(0x02, Unspecial);
		public static readonly DungeonDoorType DoorType04 = new(0x04, Unspecial, exit: true);
		public static readonly DungeonDoorType DoorType06 = new(0x06, Unspecial, exit: true);
		public static readonly DungeonDoorType DoorType08 = new(0x08, Unspecial);
		public static readonly DungeonDoorType DoorType0A = new(0x0A, Unspecial, exit: true);
		public static readonly DungeonDoorType DoorType0C = new(0x0C, Unspecial, exit: true);
		public static readonly DungeonDoorType DoorType0E = new(0x0E, Unspecial, exit: true);
		public static readonly DungeonDoorType DoorType10 = new(0x10, Unspecial, exit: true);
		public static readonly DungeonDoorType DoorType12 = new(0x12, Meta, exit: true);
		public static readonly DungeonDoorType DoorType14 = new(0x14, DungeonSwap);
		public static readonly DungeonDoorType DoorType16 = new(0x16, LayerSwap);
		public static readonly DungeonDoorType DoorType18 = new(0x18, Shutter);
		public static readonly DungeonDoorType DoorType1A = new(0x1A, Shutter);
		public static readonly DungeonDoorType DoorType1C = new(0x1C, Openable);
		public static readonly DungeonDoorType DoorType1E = new(0x1E, Openable);
		public static readonly DungeonDoorType DoorType20 = new(0x20, Openable);
		public static readonly DungeonDoorType DoorType22 = new(0x22, Openable);
		public static readonly DungeonDoorType DoorType24 = new(0x24, Openable);
		public static readonly DungeonDoorType DoorType26 = new(0x26, Openable);
		public static readonly DungeonDoorType DoorType28 = new(0x28, Openable);
		public static readonly DungeonDoorType DoorType2A = new(0x2A, Openable, exit: true);
		public static readonly DungeonDoorType DoorType2C = new(0x2C, Garbage);
		public static readonly DungeonDoorType DoorType2E = new(0x2E, Openable);
		public static readonly DungeonDoorType DoorType30 = new(0x30, Openable);
		public static readonly DungeonDoorType DoorType32 = new(0x32, Openable);
		public static readonly DungeonDoorType DoorType34 = new(0x34, Garbage);
		public static readonly DungeonDoorType DoorType36 = new(0x36, Shutter);
		public static readonly DungeonDoorType DoorType38 = new(0x38, Shutter);
		public static readonly DungeonDoorType DoorType3A = new(0x3A, Garbage);
		public static readonly DungeonDoorType DoorType3C = new(0x3C, Garbage);
		public static readonly DungeonDoorType DoorType3E = new(0x3E, Garbage);
		public static readonly DungeonDoorType DoorType40 = new(0x40, Unspecial);
		public static readonly DungeonDoorType DoorType42 = new(0x42, Shutter);
		public static readonly DungeonDoorType DoorType44 = new(0x44, Shutter);
		public static readonly DungeonDoorType DoorType46 = new(0x46, Meta);
		public static readonly DungeonDoorType DoorType48 = new(0x48, Shutter);
		public static readonly DungeonDoorType DoorType4A = new(0x4A, Shutter);
		public static readonly DungeonDoorType DoorType4C = new(0x4C, Garbage);
		public static readonly DungeonDoorType DoorType4E = new(0x4E, Garbage);
		public static readonly DungeonDoorType DoorType50 = new(0x50, Garbage);
		public static readonly DungeonDoorType DoorType52 = new(0x52, Garbage);
		public static readonly DungeonDoorType DoorType54 = new(0x54, Garbage);
		public static readonly DungeonDoorType DoorType56 = new(0x56, Garbage);
		public static readonly DungeonDoorType DoorType58 = new(0x58, Garbage);
		public static readonly DungeonDoorType DoorType5A = new(0x5A, Garbage);
		public static readonly DungeonDoorType DoorType5C = new(0x5C, Garbage);
		public static readonly DungeonDoorType DoorType5E = new(0x5E, Garbage);
		public static readonly DungeonDoorType DoorType60 = new(0x60, Garbage);
		public static readonly DungeonDoorType DoorType62 = new(0x62, Garbage);
		public static readonly DungeonDoorType DoorType64 = new(0x64, Garbage);
		public static readonly DungeonDoorType DoorType66 = new(0x66, Garbage);

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
