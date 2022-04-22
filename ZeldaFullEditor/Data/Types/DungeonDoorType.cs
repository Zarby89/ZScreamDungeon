using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ZeldaFullEditor.DoorCategory;

namespace ZeldaFullEditor.Data
{
	// TODO
	public class DungeonDoorType
	{
		public byte ID { get; }

		public DoorCategory Category { get; }
		public bool IsExit { get; }
		private DungeonDoorType(byte id, DoorCategory category, bool exit = false)
		{
			ID = id;
			Category = category;
			IsExit = false;
		}

		public static readonly DungeonDoorType DoorType00 = new DungeonDoorType(0x00, Unspecial);
		public static readonly DungeonDoorType DoorType02 = new DungeonDoorType(0x02, Unspecial);
		public static readonly DungeonDoorType DoorType04 = new DungeonDoorType(0x04, Unspecial, exit: true);
		public static readonly DungeonDoorType DoorType06 = new DungeonDoorType(0x06, Unspecial, exit: true);
		public static readonly DungeonDoorType DoorType08 = new DungeonDoorType(0x08, Unspecial);
		public static readonly DungeonDoorType DoorType0A = new DungeonDoorType(0x0A, Unspecial, exit: true);
		public static readonly DungeonDoorType DoorType0C = new DungeonDoorType(0x0C, Unspecial, exit: true);
		public static readonly DungeonDoorType DoorType0E = new DungeonDoorType(0x0E, Unspecial, exit: true);
		public static readonly DungeonDoorType DoorType10 = new DungeonDoorType(0x10, Unspecial, exit: true);
		public static readonly DungeonDoorType DoorType12 = new DungeonDoorType(0x12, Meta, exit: true);
		public static readonly DungeonDoorType DoorType14 = new DungeonDoorType(0x14, Meta);
		public static readonly DungeonDoorType DoorType16 = new DungeonDoorType(0x16, Meta);
		public static readonly DungeonDoorType DoorType18 = new DungeonDoorType(0x18, Shutter);
		public static readonly DungeonDoorType DoorType1A = new DungeonDoorType(0x1A, Shutter);
		public static readonly DungeonDoorType DoorType1C = new DungeonDoorType(0x1C, Openable);
		public static readonly DungeonDoorType DoorType1E = new DungeonDoorType(0x1E, Openable);
		public static readonly DungeonDoorType DoorType20 = new DungeonDoorType(0x20, Openable);
		public static readonly DungeonDoorType DoorType22 = new DungeonDoorType(0x22, Openable);
		public static readonly DungeonDoorType DoorType24 = new DungeonDoorType(0x24, Openable);
		public static readonly DungeonDoorType DoorType26 = new DungeonDoorType(0x26, Openable);
		public static readonly DungeonDoorType DoorType28 = new DungeonDoorType(0x28, Openable);
		public static readonly DungeonDoorType DoorType2A = new DungeonDoorType(0x2A, Openable, exit: true);
		public static readonly DungeonDoorType DoorType2C = new DungeonDoorType(0x2C, Garbage);
		public static readonly DungeonDoorType DoorType2E = new DungeonDoorType(0x2E, Openable);
		public static readonly DungeonDoorType DoorType30 = new DungeonDoorType(0x30, Openable);
		public static readonly DungeonDoorType DoorType32 = new DungeonDoorType(0x32, Openable);
		public static readonly DungeonDoorType DoorType34 = new DungeonDoorType(0x34, Garbage);
		public static readonly DungeonDoorType DoorType36 = new DungeonDoorType(0x36, Shutter);
		public static readonly DungeonDoorType DoorType38 = new DungeonDoorType(0x38, Shutter);
		public static readonly DungeonDoorType DoorType3A = new DungeonDoorType(0x3A, Garbage);
		public static readonly DungeonDoorType DoorType3C = new DungeonDoorType(0x3C, Garbage);
		public static readonly DungeonDoorType DoorType3E = new DungeonDoorType(0x3E, Garbage);
		public static readonly DungeonDoorType DoorType40 = new DungeonDoorType(0x40, Unspecial);
		public static readonly DungeonDoorType DoorType42 = new DungeonDoorType(0x42, Shutter);
		public static readonly DungeonDoorType DoorType44 = new DungeonDoorType(0x44, Shutter);
		public static readonly DungeonDoorType DoorType46 = new DungeonDoorType(0x46, Meta);
		public static readonly DungeonDoorType DoorType48 = new DungeonDoorType(0x48, Shutter);
		public static readonly DungeonDoorType DoorType4A = new DungeonDoorType(0x4A, Shutter);
		public static readonly DungeonDoorType DoorType4C = new DungeonDoorType(0x4C, Garbage);
		public static readonly DungeonDoorType DoorType4E = new DungeonDoorType(0x4E, Garbage);
		public static readonly DungeonDoorType DoorType50 = new DungeonDoorType(0x50, Garbage);
		public static readonly DungeonDoorType DoorType52 = new DungeonDoorType(0x52, Garbage);
		public static readonly DungeonDoorType DoorType54 = new DungeonDoorType(0x54, Garbage);
		public static readonly DungeonDoorType DoorType56 = new DungeonDoorType(0x56, Garbage);
		public static readonly DungeonDoorType DoorType58 = new DungeonDoorType(0x58, Garbage);
		public static readonly DungeonDoorType DoorType5A = new DungeonDoorType(0x5A, Garbage);
		public static readonly DungeonDoorType DoorType5C = new DungeonDoorType(0x5C, Garbage);
		public static readonly DungeonDoorType DoorType5E = new DungeonDoorType(0x5E, Garbage);
		public static readonly DungeonDoorType DoorType60 = new DungeonDoorType(0x60, Garbage);
		public static readonly DungeonDoorType DoorType62 = new DungeonDoorType(0x62, Garbage);
		public static readonly DungeonDoorType DoorType64 = new DungeonDoorType(0x64, Garbage);
		public static readonly DungeonDoorType DoorType66 = new DungeonDoorType(0x66, Garbage);

		public static DungeonDoorType GetDoorTypeFromID(byte b)
		{
			switch (b)
			{
				case 0x00: return DoorType00;
				case 0x02: return DoorType02;
				case 0x04: return DoorType04;
				case 0x06: return DoorType06;
				case 0x08: return DoorType08;
				case 0x0A: return DoorType0A;
				case 0x0C: return DoorType0C;
				case 0x0E: return DoorType0E;
				case 0x10: return DoorType10;
				case 0x12: return DoorType12;
				case 0x14: return DoorType14;
				case 0x16: return DoorType16;
				case 0x18: return DoorType18;
				case 0x1A: return DoorType1A;
				case 0x1C: return DoorType1C;
				case 0x1E: return DoorType1E;
				case 0x20: return DoorType20;
				case 0x22: return DoorType22;
				case 0x24: return DoorType24;
				case 0x26: return DoorType26;
				case 0x28: return DoorType28;
				case 0x2A: return DoorType2A;
				case 0x2C: return DoorType2C;
				case 0x2E: return DoorType2E;
				case 0x30: return DoorType30;
				case 0x32: return DoorType32;
				case 0x34: return DoorType34;
				case 0x36: return DoorType36;
				case 0x38: return DoorType38;
				case 0x3A: return DoorType3A;
				case 0x3C: return DoorType3C;
				case 0x3E: return DoorType3E;
				case 0x40: return DoorType40;
				case 0x42: return DoorType42;
				case 0x44: return DoorType44;
				case 0x46: return DoorType46;
				case 0x48: return DoorType48;
				case 0x4A: return DoorType4A;
				case 0x4C: return DoorType4C;
				case 0x4E: return DoorType4E;
				case 0x50: return DoorType50;
				case 0x52: return DoorType52;
				case 0x54: return DoorType54;
				case 0x56: return DoorType56;
				case 0x58: return DoorType58;
				case 0x5A: return DoorType5A;
				case 0x5C: return DoorType5C;
				case 0x5E: return DoorType5E;
				case 0x60: return DoorType60;
				case 0x62: return DoorType62;
				case 0x64: return DoorType64;
				case 0x66: return DoorType66;
			}
			return null;
		}
	}
}
