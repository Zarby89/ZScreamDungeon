namespace ZeldaFullEditor.ALTTP.Underworld
{
	/// <summary>
	/// Specifies the unique classification of behavior a <see cref="DungeonDoorType"/> falls under
	/// </summary>
	public enum DoorCategory
	{
		/// <summary>
		/// Doors which have no special or discerning behavior
		/// </summary>
		Unspecial,

		/// <summary>
		/// Doors which are permanently openable, such as key doors and bombable walls
		/// </summary>
		Openable,

		/// <summary>
		/// Doors which are temporarily openable
		/// </summary>
		Shutter,

		/// <summary>
		/// Doors which mark doors with a property they don't normally have
		/// </summary>
		Meta,

		/// <summary>
		/// Doors which swap the player's layer on transition
		/// </summary>
		LayerSwap,

		/// <summary>
		/// Doors which swap the player's dungeon on transition
		/// </summary>
		DungeonSwap,

		/// <summary>
		/// Doors with an irregular, larger draw function
		/// </summary>
		Fancy,

		/// <summary>
		/// Doors that are completely unusable or otherwise broken
		/// </summary>
		Garbage,
	}
}
