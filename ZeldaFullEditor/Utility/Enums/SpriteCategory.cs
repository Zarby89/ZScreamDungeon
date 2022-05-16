namespace ZeldaFullEditor
{
	public enum SpriteCategory
	{
		/// <summary>
		/// Sprites that are mean and try to hurt you
		/// </summary>
		Enemy,

		/// <summary>
		/// Enemy sprites that cannot be damaged normally
		/// </summary>
		UnkillableEnemy,

		/// <summary>
		/// Sprites that are reasonably considered alive, but aren't mean
		/// </summary>
		NPC,

		/// <summary>
		/// NPC sprites that hand out items
		/// </summary>
		GenerousNPC,

		/// <summary>
		/// Sprites that aren't really alive, leaving their meanness ambiguous
		/// </summary>
		Inanimate,

		/// <summary>
		/// Mean sprites that are super strong
		/// </summary>
		Boss,

		/// <summary>
		/// Sprites that are common for puzzles
		/// </summary>
		Puzzle,

		/// <summary>
		/// Overlords which repeatedly spawn new sprites
		/// </summary>
		EnemyFactory,

		/// <summary>
		/// Sprites that are dependent on the existent of another sprite or overlord to behave properly
		/// </summary>
		EntityDependent,

		/// <summary>
		/// Sprites whose behavior changes based on the current room or screen ID, world state, or indoorsness
		/// </summary>
		LocationDependent,

		/// <summary>
		/// Sprites that are 
		/// </summary>
		Collectible,

		/// <summary>
		/// Sprites that are designed to only exist in the overworld
		/// </summary>
		OverworldOnly,

		/// <summary>
		/// Sprites that are designed to only exist in the underworld
		/// </summary>
		UnderworldOnly,

		/// <summary>
		/// Sprites that are expected to obey a specific quote or exist in specific slots
		/// </summary>
		PlacementLimited,

		/// <summary>
		/// Sprites that are only intended to be spawned by other sprites
		/// </summary>
		NotIntendedToBePlacedDirectly,
	}
}
