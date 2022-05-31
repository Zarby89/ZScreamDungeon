namespace ZeldaFullEditor.UserInterface.Drawing
{
	/// <summary>
	/// Specifies in what way a drawable scene needs to be updated.
	/// </summary>
	[Flags]
	public enum NeedsNewArt
	{
		Nothing = 0,

		UpdatedBackgroundTileset = 1 << 0,
		UpdatedSpriteTileset = 1 << 1,
		UpdatedAllTilesets = UpdatedBackgroundTileset | UpdatedSpriteTileset,

		UpdatedBackgroundPalette = 1 << 4,
		UpdatedSpritePalette = 1 << 5,
		UpdatedAllPalettes = UpdatedBackgroundPalette | UpdatedSpritePalette,

		UpdatedLayer1Tilemap = 1 << 8,
		UpdatedLayer2Tilemap = 1 << 9,
		UpdatedSpritesLayer = 1 << 10,
		UpdatedAllTilemaps = UpdatedLayer1Tilemap | UpdatedLayer2Tilemap,

		UpdatedLayering = 1 << 12,

		BitmapRepaint = 1 << 15,

		LiterallyEverything = 0xFFFF
	}
}
