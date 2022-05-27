namespace ZeldaFullEditor.Modeling.Underworld
{
	public class RoomTagType : IEntityType<RoomTagType>
	{
		public byte ID { get; init; }
		public int ListID => ID;
		public string Name { get; init; }

		private RoomTagType(byte id, string name)
		{
			ID = id;
			Name = name;
		}

		public override string ToString() => Name;

		public static ImmutableArray<RoomTagType> ListOf { get; }

		// Need to use static constructor for reflection to work properly
		static RoomTagType()
		{
			ListOf = Utils.GetSortedListOfPredefinedFields<RoomTagType>();
		}

		public static RoomTagType GetTypeFromID(byte id) => ListOf.GetTypeFromID(id);

		[PredefinedInstance] public static readonly RoomTagType RoomTag00 = new (0x00, "Nothing");
		[PredefinedInstance] public static readonly RoomTagType RoomTag01 = new (0x01, "NW Kill Room Door");
		[PredefinedInstance] public static readonly RoomTagType RoomTag02 = new (0x02, "NE Kill Room Door");
		[PredefinedInstance] public static readonly RoomTagType RoomTag03 = new (0x03, "SW Kill Room Door");
		[PredefinedInstance] public static readonly RoomTagType RoomTag04 = new (0x04, "SE Kill Room Door");
		[PredefinedInstance] public static readonly RoomTagType RoomTag05 = new (0x05, "W Kill Room Door");
		[PredefinedInstance] public static readonly RoomTagType RoomTag06 = new (0x06, "E Kill Room Door");
		[PredefinedInstance] public static readonly RoomTagType RoomTag07 = new (0x07, "N Kill Room Door");
		[PredefinedInstance] public static readonly RoomTagType RoomTag08 = new (0x08, "S Kill Room Door");
		[PredefinedInstance] public static readonly RoomTagType RoomTag09 = new (0x09, "Quadrant Kill Room Door");
		[PredefinedInstance] public static readonly RoomTagType RoomTag0A = new (0x0A, "Supertile Kill Room Door");
		[PredefinedInstance] public static readonly RoomTagType RoomTag0B = new (0x0B, "NW Pushblock Door");
		[PredefinedInstance] public static readonly RoomTagType RoomTag0C = new (0x0C, "NE Pushblock Door");
		[PredefinedInstance] public static readonly RoomTagType RoomTag0D = new (0x0D, "SW Pushblock Door");
		[PredefinedInstance] public static readonly RoomTagType RoomTag0E = new (0x0E, "SE Pushblock Door");
		[PredefinedInstance] public static readonly RoomTagType RoomTag0F = new (0x0F, "W Pushblock Door");
		[PredefinedInstance] public static readonly RoomTagType RoomTag10 = new (0x10, "E Pushblock Door");
		[PredefinedInstance] public static readonly RoomTagType RoomTag11 = new (0x11, "N Pushblock Door");
		[PredefinedInstance] public static readonly RoomTagType RoomTag12 = new (0x12, "S Pushblock Door");
		[PredefinedInstance] public static readonly RoomTagType RoomTag13 = new (0x13, "Pushblock Door");
		[PredefinedInstance] public static readonly RoomTagType RoomTag14 = new (0x14, "Pull Switch Door");
		[PredefinedInstance] public static readonly RoomTagType RoomTag15 = new (0x15, "Dungeon Prize Door");
		[PredefinedInstance] public static readonly RoomTagType RoomTag16 = new (0x16, "Held Switch Door");
		[PredefinedInstance] public static readonly RoomTagType RoomTag17 = new (0x17, "Toggled Switch Door");
		[PredefinedInstance] public static readonly RoomTagType RoomTag18 = new (0x18, "Water Drain");
		[PredefinedInstance] public static readonly RoomTagType RoomTag19 = new (0x19, "Water Flood");
		[PredefinedInstance] public static readonly RoomTagType RoomTag1A = new (0x1A, "Water Gate");
		[PredefinedInstance] public static readonly RoomTagType RoomTag1B = new (0x1B, "Water Twin");
		[PredefinedInstance] public static readonly RoomTagType RoomTag1C = new (0x1C, "Moving Wall Right");
		[PredefinedInstance] public static readonly RoomTagType RoomTag1D = new (0x1D, "Moving Wall Left");
		[PredefinedInstance] public static readonly RoomTagType RoomTag1E = new (0x1E, "Crash");
		[PredefinedInstance] public static readonly RoomTagType RoomTag1F = new (0x1F, "Crash");
		[PredefinedInstance] public static readonly RoomTagType RoomTag20 = new (0x20, "Pressure Switch Exploding Wall");
		[PredefinedInstance] public static readonly RoomTagType RoomTag21 = new (0x21, "Holes 0");
		[PredefinedInstance] public static readonly RoomTagType RoomTag22 = new (0x22, "Chest Triggers Holes 0");
		[PredefinedInstance] public static readonly RoomTagType RoomTag23 = new (0x23, "Holes 1");
		[PredefinedInstance] public static readonly RoomTagType RoomTag24 = new (0x24, "Holes 2");
		[PredefinedInstance] public static readonly RoomTagType RoomTag25 = new (0x25, "Defeat Boss for Dungeon Prize");
		[PredefinedInstance] public static readonly RoomTagType RoomTag26 = new (0x26, "SE Kill Block");
		[PredefinedInstance] public static readonly RoomTagType RoomTag27 = new (0x27, "Pressure Switch Chest");
		[PredefinedInstance] public static readonly RoomTagType RoomTag28 = new (0x28, "Pull Switch Exploding Wall");
		[PredefinedInstance] public static readonly RoomTagType RoomTag29 = new (0x29, "NW Kill Chest");
		[PredefinedInstance] public static readonly RoomTagType RoomTag2A = new (0x2A, "NE Kill Chest");
		[PredefinedInstance] public static readonly RoomTagType RoomTag2B = new (0x2B, "SW Kill Chest");
		[PredefinedInstance] public static readonly RoomTagType RoomTag2C = new (0x2C, "SE Kill Chest");
		[PredefinedInstance] public static readonly RoomTagType RoomTag2D = new (0x2D, "W Kill Chest");
		[PredefinedInstance] public static readonly RoomTagType RoomTag2E = new (0x2E, "E Kill Chest");
		[PredefinedInstance] public static readonly RoomTagType RoomTag2F = new (0x2F, "N Kill Chest");
		[PredefinedInstance] public static readonly RoomTagType RoomTag30 = new (0x30, "S Kill Chest");
		[PredefinedInstance] public static readonly RoomTagType RoomTag31 = new (0x31, "Quadrant Kill Chest");
		[PredefinedInstance] public static readonly RoomTagType RoomTag32 = new (0x32, "Supertile Kill Chest");
		[PredefinedInstance] public static readonly RoomTagType RoomTag33 = new (0x33, "Torches Door");
		[PredefinedInstance] public static readonly RoomTagType RoomTag34 = new (0x34, "Holes 3");
		[PredefinedInstance] public static readonly RoomTagType RoomTag35 = new (0x35, "Holes 4");
		[PredefinedInstance] public static readonly RoomTagType RoomTag36 = new (0x36, "Holes 5");
		[PredefinedInstance] public static readonly RoomTagType RoomTag37 = new (0x37, "Holes 6");
		[PredefinedInstance] public static readonly RoomTagType RoomTag38 = new (0x38, "Agahnim Room");
		[PredefinedInstance] public static readonly RoomTagType RoomTag39 = new (0x39, "Holes 7");
		[PredefinedInstance] public static readonly RoomTagType RoomTag3A = new (0x3A, "Holes 8");
		[PredefinedInstance] public static readonly RoomTagType RoomTag3B = new (0x3B, "Chest Triggers Holes 8");
		[PredefinedInstance] public static readonly RoomTagType RoomTag3C = new (0x3C, "Pushblock Chest");
		[PredefinedInstance] public static readonly RoomTagType RoomTag3D = new (0x3D, "Triforce Door");
		[PredefinedInstance] public static readonly RoomTagType RoomTag3E = new (0x3E, "Torches Chest");
		[PredefinedInstance] public static readonly RoomTagType RoomTag3F = new (0x3F, "Rekillable Boss");
	}
}
