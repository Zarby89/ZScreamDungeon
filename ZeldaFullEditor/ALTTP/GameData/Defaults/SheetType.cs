namespace ZeldaFullEditor.ALTTP.GameData.Defaults
{
	public enum SheetType
	{
		/// <summary>
		/// Sheets with no specific purpose
		/// </summary>
		None,

		/// <summary>
		/// Sheets that are empty in vanilla
		/// </summary>
		Empty,

		/// <summary>
		/// Sheets that are nonempty, but unused
		/// </summary>
		Garbage,

		/// <summary>
		/// Sheets meant for background graphics in the underworld
		/// </summary>
		UnderworldTile,

		/// <summary>
		/// Sheets meant for background graphics in the overworld
		/// </summary>
		OverworldTile,

		/// <summary>
		/// Sheets meant for normal sprites
		/// </summary>
		Sprite,

		/// <summary>
		/// Sheets meant for copying into a temporary WRAM buffer and pulling from there
		/// </summary>
		DynamicBackground,

		/// <summary>
		/// Sheets meant for copying into a temporary WRAM buffer and pulling from there
		/// </summary>
		DynamicSprite,

		/// <summary>
		/// Sheets meant for the dungeon map
		/// </summary>
		DungeonMapTile,

		/// <summary>
		/// Sheets meant for the HUD background
		/// </summary>
		HUDTile,
	}
}
