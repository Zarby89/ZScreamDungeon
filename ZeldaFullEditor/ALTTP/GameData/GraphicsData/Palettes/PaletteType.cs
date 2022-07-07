using static ZeldaFullEditor.ALTTP.GameData.GraphicsData.Palettes.PaletteType;

namespace ZeldaFullEditor.ALTTP.GameData.GraphicsData.Palettes;

public enum PaletteType
{
	DungeonPalette,
	SpritePal0,
	SpriteEnvironment,
	SpriteAux,
	FullSpritePalette,
	MailPalette,
	SwordPalette,
	ShieldPalette,
	HUDPalette,
	OWAnim,
	OWAux,
	OWMain,
	OWMapPalette,
	UWMapPalette,
	UWMapSpritePalette,
	PolyhedralPalette
}

public static class PaletteTypeHelper
{
	public static int GetRealSize(this PaletteType type) => type switch
	{
		DungeonPalette => 6 * 15,
		SpritePal0 => 7,
		SpriteEnvironment => 7,
		SpriteAux => 7,
		MailPalette => 15,
		FullSpritePalette => 4 * 15,
		SwordPalette => 3,
		ShieldPalette => 4,
		HUDPalette => 4,
		OWAnim => 7,
		OWMain => 5 * 7,
		OWAux => 3 * 7,
		OWMapPalette => 8 * 16,
		UWMapPalette => 6 * 16,
		PolyhedralPalette => 8,
		UWMapSpritePalette => 3 * 7,
		_ => 0,
	};
	
	public static int GetVirtualSize(this PaletteType type) => type switch
	{
		DungeonPalette => 6 * 16,
		SpritePal0 => 7,
		SpriteEnvironment => 7,
		SpriteAux => 7,
		MailPalette => 15,
		FullSpritePalette => 4 * 16,
		SwordPalette => 3,
		ShieldPalette => 4,
		HUDPalette => 4,
		OWAnim => 7,
		OWMain => 5 * 16,
		OWAux => 3 * 16,
		OWMapPalette => 8 * 16,
		UWMapPalette => 6 * 16,
		PolyhedralPalette => 8,
		UWMapSpritePalette => 3 * 16,

		_ => 0,
	};
	
	public static int GetRealWidth(this PaletteType type) => type switch
	{
		DungeonPalette => 15,
		SpritePal0 => 7,
		SpriteEnvironment => 7,
		SpriteAux => 7,
		MailPalette => 15,
		FullSpritePalette => 15,
		SwordPalette => 3,
		ShieldPalette => 4,
		HUDPalette => 4,
		OWAnim => 7,
		OWMain => 5,
		OWAux => 3,
		OWMapPalette => 16,
		UWMapPalette => 16,
		PolyhedralPalette => 8,
		UWMapSpritePalette => 7,
		_ => 0,
	};
}
