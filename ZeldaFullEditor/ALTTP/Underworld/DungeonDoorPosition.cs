using static ZeldaFullEditor.ALTTP.Underworld.DoorDirection;

namespace ZeldaFullEditor.ALTTP.Underworld;
public class DungeonDoorPosition : IEntityType<DungeonDoorPosition>
{
	public string Name { get; init; }

	public int ListID => ID;

	public byte ID { get; }
	public byte Token { get; }
	public bool IsHorizontal { get; }
	public DoorDirection Direction { get; }

	public ushort TilemapPosition { get; }

	public bool LowerLayer { get; }
	public int RealX { get; }
	public int RealY { get; }

	private readonly Rectangle bounds;
	public Rectangle BoundingBox => bounds;

	public DungeonDoorPosition Partner { get; private set; } = null;

	private DungeonDoorPosition(byte id, DoorDirection direction, int x, int y, bool lowerlayer)
	{
		Name = $"{direction}{id:X2}";
		ID = id;
		Direction = direction;
		RealX = x;
		RealY = y;

		Token = (byte) ((id << 3) | (byte) direction);

		var (ll, hh) = UWTilemapPosition.CreateLowAndHighBytesFromXYZ((byte) (x / 8), (byte) (y / 8), 0);
		TilemapPosition = (ushort) (((hh << 8) | ll) >> 1);

		LowerLayer = lowerlayer;

		IsHorizontal = direction is West or East;

		// this ternary is just to upset foxlisk
		var (w, h) = IsHorizontal ? (24, 32) : (32, 24);

		bounds = new(x, y, w, h);
	}
	public override string ToString() => Name;

	public static ImmutableArray<DungeonDoorPosition> ListOf { get; }

	// Need to use static constructor for reflection to work properly
	static DungeonDoorPosition()
	{
		ListOf = Utils.GetSortedListOfPredefinedFields<DungeonDoorPosition>();

		var pairs = new (DungeonDoorPosition, DungeonDoorPosition)[]
		{
			(North0C, South00),
			(North0E, South02),
			(North10, South04),

			(North12, South06),
			(North14, South08),
			(North16, South0A),

			(West0C, East00),
			(West0E, East02),
			(West10, East04),

			(West12, East06),
			(West14, East08),
			(West16, East0A),
		};

		foreach (var (a, b) in pairs)
		{
			a.Partner = b;
		}
	}

	public static DungeonDoorPosition GetLocationFromToken(byte b)
	{
		return ListOf.FirstOrDefault(o => o.Token == b, null);
	}


	[PredefinedInstance] public static readonly DungeonDoorPosition North00 = new(0x00, North, 112, 32, false);
	[PredefinedInstance] public static readonly DungeonDoorPosition North02 = new(0x02, North, 240, 32, false);
	[PredefinedInstance] public static readonly DungeonDoorPosition North04 = new(0x04, North, 368, 32, false);
	[PredefinedInstance] public static readonly DungeonDoorPosition North06 = new(0x06, North, 112, 56, true);
	[PredefinedInstance] public static readonly DungeonDoorPosition North08 = new(0x08, North, 240, 56, true);
	[PredefinedInstance] public static readonly DungeonDoorPosition North0A = new(0x0A, North, 368, 56, true);
	[PredefinedInstance] public static readonly DungeonDoorPosition North0C = new(0x0C, North, 112, 288, false);
	[PredefinedInstance] public static readonly DungeonDoorPosition North0E = new(0x0E, North, 240, 288, false);
	[PredefinedInstance] public static readonly DungeonDoorPosition North10 = new(0x10, North, 368, 288, false);
	[PredefinedInstance] public static readonly DungeonDoorPosition North12 = new(0x12, North, 112, 312, true);
	[PredefinedInstance] public static readonly DungeonDoorPosition North14 = new(0x14, North, 240, 312, true);
	[PredefinedInstance] public static readonly DungeonDoorPosition North16 = new(0x16, North, 368, 312, true);

	[PredefinedInstance] public static readonly DungeonDoorPosition South00 = new(0x00, South, 112, 216, false);
	[PredefinedInstance] public static readonly DungeonDoorPosition South02 = new(0x02, South, 240, 216, false);
	[PredefinedInstance] public static readonly DungeonDoorPosition South04 = new(0x04, South, 368, 216, false);
	[PredefinedInstance] public static readonly DungeonDoorPosition South06 = new(0x06, South, 112, 192, true);
	[PredefinedInstance] public static readonly DungeonDoorPosition South08 = new(0x08, South, 240, 192, true);
	[PredefinedInstance] public static readonly DungeonDoorPosition South0A = new(0x0A, South, 368, 192, true);
	[PredefinedInstance] public static readonly DungeonDoorPosition South0C = new(0x0C, South, 112, 472, false);
	[PredefinedInstance] public static readonly DungeonDoorPosition South0E = new(0x0E, South, 240, 472, false);
	[PredefinedInstance] public static readonly DungeonDoorPosition South10 = new(0x10, South, 368, 472, false);
	[PredefinedInstance] public static readonly DungeonDoorPosition South12 = new(0x12, South, 112, 448, true);
	[PredefinedInstance] public static readonly DungeonDoorPosition South14 = new(0x14, South, 240, 448, true);
	[PredefinedInstance] public static readonly DungeonDoorPosition South16 = new(0x16, South, 368, 448, true);

	[PredefinedInstance] public static readonly DungeonDoorPosition West00 = new(0x00, West, 16, 120, false);
	[PredefinedInstance] public static readonly DungeonDoorPosition West02 = new(0x02, West, 16, 248, false);
	[PredefinedInstance] public static readonly DungeonDoorPosition West04 = new(0x04, West, 16, 376, false);
	[PredefinedInstance] public static readonly DungeonDoorPosition West06 = new(0x06, West, 40, 120, true);
	[PredefinedInstance] public static readonly DungeonDoorPosition West08 = new(0x08, West, 40, 248, true);
	[PredefinedInstance] public static readonly DungeonDoorPosition West0A = new(0x0A, West, 40, 376, true);
	[PredefinedInstance] public static readonly DungeonDoorPosition West0C = new(0x0C, West, 272, 120, false);
	[PredefinedInstance] public static readonly DungeonDoorPosition West0E = new(0x0E, West, 272, 248, false);
	[PredefinedInstance] public static readonly DungeonDoorPosition West10 = new(0x10, West, 272, 376, false);
	[PredefinedInstance] public static readonly DungeonDoorPosition West12 = new(0x12, West, 296, 120, true);
	[PredefinedInstance] public static readonly DungeonDoorPosition West14 = new(0x14, West, 296, 248, true);
	[PredefinedInstance] public static readonly DungeonDoorPosition West16 = new(0x16, West, 296, 376, true);

	[PredefinedInstance] public static readonly DungeonDoorPosition East00 = new(0x00, East, 216, 120, false);
	[PredefinedInstance] public static readonly DungeonDoorPosition East02 = new(0x02, East, 216, 248, false);
	[PredefinedInstance] public static readonly DungeonDoorPosition East04 = new(0x04, East, 216, 376, false);
	[PredefinedInstance] public static readonly DungeonDoorPosition East06 = new(0x06, East, 192, 120, true);
	[PredefinedInstance] public static readonly DungeonDoorPosition East08 = new(0x08, East, 192, 248, true);
	[PredefinedInstance] public static readonly DungeonDoorPosition East0A = new(0x0A, East, 192, 376, true);
	[PredefinedInstance] public static readonly DungeonDoorPosition East0C = new(0x0C, East, 472, 120, false);
	[PredefinedInstance] public static readonly DungeonDoorPosition East0E = new(0x0E, East, 472, 248, false);
	[PredefinedInstance] public static readonly DungeonDoorPosition East10 = new(0x10, East, 472, 376, false);
	[PredefinedInstance] public static readonly DungeonDoorPosition East12 = new(0x12, East, 448, 120, true);
	[PredefinedInstance] public static readonly DungeonDoorPosition East14 = new(0x14, East, 448, 248, true);
	[PredefinedInstance] public static readonly DungeonDoorPosition East16 = new(0x16, East, 448, 376, true);

}
