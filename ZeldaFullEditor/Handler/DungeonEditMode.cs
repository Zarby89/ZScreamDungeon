namespace ZeldaFullEditor.Handler
{
	/// <summary>
	/// Specifies the current editing mode the <see cref="DungeonEditor"/> should be operating in.
	/// </summary>
	public enum DungeonEditMode
	{
		Layer1 = 0,
		Layer2 = 1,
		Layer3 = 2,
		LayerAll = 3,
		Doors,
		Sprites,
		Secrets,
		Blocks,
		Torches,
		Entrances,
		CollisionMap,
	}
}
