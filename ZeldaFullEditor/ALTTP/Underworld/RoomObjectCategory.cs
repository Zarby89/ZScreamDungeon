namespace ZeldaFullEditor.ALTTP.Underworld
{
	public sealed class RoomObjectCategory : SearchCategory
	{
		public override string Name { get; protected init; } = "Name";
		public override string Description { get; protected init; } = "Description";

		private RoomObjectCategory() : base()
		{
		}

		public override string ToString() => Name;

		public static ImmutableArray<RoomObjectCategory> ListOf { get; }

		// Need to use static constructor for reflection to work properly
		static RoomObjectCategory()
		{
			ListOf = Utils.GetSortedListOfPredefinedFields<RoomObjectCategory>((t1, t2) => t1.ID - t2.ID);
		}


		// ================================================================================
		// Collision categories
		// ================================================================================

		[PredefinedInstance]
		public static readonly RoomObjectCategory NoCollision = new()
		{
			Name = "Has no collision",
			Description = "Objects that have no solid collision.",
		};

		[PredefinedInstance]
		public static readonly RoomObjectCategory Collision = new()
		{
			Name = "Has collision",
			Description = "Objects that have some solid collision.",
		};

		[PredefinedInstance]
		public static readonly RoomObjectCategory DiagonalCollision = new()
		{
			Name = "Has diagonal collision",
			Description = "Objects that have some diagonal collision.",
		};

		// ================================================================================
		// Design categories
		// ================================================================================

		[PredefinedInstance]
		public static readonly RoomObjectCategory Wall = new()
		{
			Name = "Wall",
			Description = "Objects that are designed to represent a wall enclosing a room.",
		};

		[PredefinedInstance]
		public static readonly RoomObjectCategory Ceiling = new()
		{
			Name = "Ceiling",
			Description = "Objects that are designed to represent a ceiling on the exterior of an area.",
		};

		[PredefinedInstance]
		public static readonly RoomObjectCategory Floor = new()
		{
			Name = "Floor",
			Description = "Objects that are designed to represent a floor or carpet.",
		};

		[PredefinedInstance]
		public static readonly RoomObjectCategory RoomDecoration = new()
		{
			Name = "Room decoration",
			Description = "Objects that are designed to adorn a room by being placed in its interior.",
		};

		[PredefinedInstance]
		public static readonly RoomObjectCategory WallDecoration = new()
		{
			Name = "Wall decoration",
			Description = "Objects that are designed to adorn a room by being placed along its walls.",
		};

		[PredefinedInstance]
		public static readonly RoomObjectCategory LayerMask = new()
		{
			Name = "Layer mask",
			Description = "Objects whose function is to erase portions of the layer it is placed on to reveal the area below.",
		};

		// ================================================================================
		// Behavior categories
		// ================================================================================

		[PredefinedInstance]
		public static readonly RoomObjectCategory TilesetDependent = new()
		{
			Name = "Tileset dependent",
			Description = "Objects whose behavior changes based on the tileset.",
		};

		[PredefinedInstance]
		public static readonly RoomObjectCategory RoomTransition = new()
		{
			Name = "Room transition",
			Description = "Objects whose function is to effect a change of room.",
		};

		[PredefinedInstance]
		public static readonly RoomObjectCategory Stairs = new()
		{
			Name = "Stairs",
			Description = "Objects that behave as stairs of any variety.",
		};

		[PredefinedInstance]
		public static readonly RoomObjectCategory Pit = new()
		{
			Name = "Pit",
			Description = "Objects that behave as pits.",
		};

		[PredefinedInstance]
		public static readonly RoomObjectCategory Ledge = new()
		{
			Name = "Ledge",
			Description = "Objects that behave as ledges.",
		};

		[PredefinedInstance]
		public static readonly RoomObjectCategory Spikes = new()
		{
			Name = "Spike",
			Description = "Objects that deal damage when touched.",
		};

		[PredefinedInstance]
		public static readonly RoomObjectCategory ShallowWater = new()
		{
			Name = "Shallow water",
			Description = "Objects that behave as shallow water.",
		};

		[PredefinedInstance]
		public static readonly RoomObjectCategory DeepWater = new()
		{
			Name = "Deep water",
			Description = "Objects that behave as deep water.",
		};

		[PredefinedInstance]
		public static readonly RoomObjectCategory IcyFloor = new()
		{
			Name = "Icy floor",
			Description = "Objects that behave as an icy floor of either variety.",
		};

		[PredefinedInstance]
		public static readonly RoomObjectCategory PuzzlePegs = new()
		{
			Name = "Puzzle peg",
			Description = "Any of the hammer peg, or orange and blue crystal switch peg objects.",
		};

		[PredefinedInstance]
		public static readonly RoomObjectCategory Conveyor = new()
		{
			Name = "Conveyor",
			Description = "Objects that, in the correct tileset, behave as a moving floor.",
		};

		[PredefinedInstance]
		public static readonly RoomObjectCategory Secrets = new()
		{
			Name = "Reveals secrets",
			Description = "Objects that can expose a secret when destroyed.",
		};

		[PredefinedInstance]
		public static readonly RoomObjectCategory Mutable = new()
		{
			Name = "Is mutable",
			Description = "Objects that can changed by player interaction in some form.",
		};

		[PredefinedInstance]
		public static readonly RoomObjectCategory Hookshottable = new()
		{
			Name = "Hookshottable",
			Description = "Objects that can grappled with the hookshot.",
		};

		[PredefinedInstance]
		public static readonly RoomObjectCategory Transport = new()
		{
			Name = "Transport",
			Description = "Objects that are designed to transport a player within a room.",
		};

		// ================================================================================
		// Direction categories
		// ================================================================================

		[PredefinedInstance]
		public static readonly RoomObjectCategory NorthSide = new()
		{
			Name = "North side",
			Description = "Objects with a directionality that works best when placed north relative similar objects.",
		};

		[PredefinedInstance]
		public static readonly RoomObjectCategory SouthSide = new()
		{
			Name = "South side",
			Description = "Objects with a directionality that works best when placed south relative similar objects.",
		};

		[PredefinedInstance]
		public static readonly RoomObjectCategory WestSide = new()
		{
			Name = "West side",
			Description = "Objects with a directionality that works best when placed west relative similar objects.",
		};

		[PredefinedInstance]
		public static readonly RoomObjectCategory EastSide = new()
		{
			Name = "East side",
			Description = "Objects with a directionality that works best when placed east relative similar objects.",
		};

		// ================================================================================
		// Layer categories
		// ================================================================================

		[PredefinedInstance]
		public static readonly RoomObjectCategory UpperLayer = new()
		{
			Name = "Upper layer",
			Description = "Objects that are used most practically on the upper layer (Layer 1).",
		};

		[PredefinedInstance]
		public static readonly RoomObjectCategory LowerLayer = new()
		{
			Name = "Lower layer",
			Description = "Objects that are used most practically on the lower layer (Layer 2).",
		};

		[PredefinedInstance]
		public static readonly RoomObjectCategory MetaLayer = new()
		{
			Name = "Meta layer",
			Description = "Objects that are used most practically on the meta layer (Layer 3).",
		};
	}
}
