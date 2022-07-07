namespace ZeldaFullEditor.ALTTP.GameData;

/// <summary>
/// Specifies a category of broad usability under which sprites may fall.
/// </summary>
public class SpriteCategory : SearchCategory
{
	private SpriteCategory() : base()
	{
	}

	public static ImmutableArray<SpriteCategory> ListOf { get; }

	// Need to use static constructor for reflection to work properly
	static SpriteCategory()
	{
		ListOf = Utils.GetSortedListOfPredefinedFields<SpriteCategory>((t1, t2) => t1.ID - t2.ID);
	}


	// ================================================================================
	// Categories
	// ================================================================================

	[PredefinedInstance]
	public static readonly SpriteCategory Enemy = new()
	{
		Name = "Enemy",
		Description = "Sprites that are mean and try to hurt you.",
	};

	[PredefinedInstance]
	public static readonly SpriteCategory UnkillableEnemy = new()
	{
		Name = "Unkillable enemy",
		Description = "Enemy sprites that cannot be damaged normally.",
	};

	[PredefinedInstance]
	public static readonly SpriteCategory NPC = new()
	{
		Name = "NPC",
		Description = "Sprites that are reasonably considered alive, but aren't mean.",
	};

	[PredefinedInstance]
	public static readonly SpriteCategory GenerousNPC = new()
	{
		Name = "Generous NPC",
		Description = "NPC sprites that hand out items.",
	};

	[PredefinedInstance]
	public static readonly SpriteCategory Inanimate = new()
	{
		Name = "Inanimate",
		Description = "Sprites that aren't really alive, leaving their meanness ambiguous.",
	};

	[PredefinedInstance]
	public static readonly SpriteCategory Boss = new()
	{
		Name = "Boss",
		Description = "Mean sprites that are super strong.",
	};

	[PredefinedInstance]
	public static readonly SpriteCategory Puzzle = new()
	{
		Name = "Puzzle",
		Description = "Sprites that are commonly used as elements for puzzles.",
	};

	[PredefinedInstance]
	public static readonly SpriteCategory EnemyFactory = new()
	{
		Name = "Enemy factory",
		Description = "Overlords that regularly spawn new sprites.",
	};

	[PredefinedInstance]
	public static readonly SpriteCategory EntityDependent = new()
	{
		Name = "Entity dependent",
		Description = "Sprites that are dependent on the existence of another sprite or overlord to behave properly.",
	};

	[PredefinedInstance]
	public static readonly SpriteCategory LocationDependent = new()
	{
		Name = "Location dependent",
		Description = "Sprites whose behavior changes based on the current room or screen ID, world state, or indoorsiness.",
	};

	[PredefinedInstance]
	public static readonly SpriteCategory Collectible = new()
	{
		Name = "Collectible",
		Description = "Sprites that are abstractly eaten by Link.",
	};

	[PredefinedInstance]
	public static readonly SpriteCategory UnderworldOnly = new()
	{
		Name = "Underworld only",
		Description = "Sprites that are designed to only exist in the underworld.",
	};

	[PredefinedInstance]
	public static readonly SpriteCategory OverworldOnly = new()
	{
		Name = "Overworld only",
		Description = "Sprites that are designed to only exist in the overworld.",
	};

	[PredefinedInstance]
	public static readonly SpriteCategory PlacementLimited = new()
	{
		Name = "Placement limited",
		Description = "Sprites that are expected to obey a specific quota or exist in specific slots.",
	};

	[PredefinedInstance]
	public static readonly SpriteCategory NotIntendedToBePlacedDirectly = new()
	{
		Name = "Don't place",
		Description = "Sprites that are only intended to be spawned by other sprites.",
	};
}
