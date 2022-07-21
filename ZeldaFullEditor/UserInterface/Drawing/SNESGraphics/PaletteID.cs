namespace ZeldaFullEditor.UserInterface.Drawing.SNESGraphics;

/// <summary>
/// Specifies which palette a graphic should use.
/// When cast to a numeric value, the value may be logically OR'd with a bare index to get a full
/// 8-bits-per-pixel index.
/// </summary>
public enum PaletteID
{
	LeftPalette = 0x00,
	RightPalette = 0x08,
	SpritePalette = 0x80,


	BackgroundPalette0Left = LeftPalette,
	BackgroundPalette0Right = RightPalette,
	BackgroundPalette1Left = 1 << 4,
	BackgroundPalette1Right = BackgroundPalette1Left | RightPalette,
	BackgroundPalette2Left = 2 << 4,
	BackgroundPalette2Right = BackgroundPalette2Left | RightPalette,
	BackgroundPalette3Left = 3 << 4,
	BackgroundPalette3Right = BackgroundPalette3Left | RightPalette,
	BackgroundPalette4Left = 4 << 4,
	BackgroundPalette4Right = BackgroundPalette4Left | RightPalette,
	BackgroundPalette5Left = 5 << 4,
	BackgroundPalette5Right = BackgroundPalette5Left | RightPalette,
	BackgroundPalette6Left = 6 << 4,
	BackgroundPalette6Right = BackgroundPalette6Left | RightPalette,
	BackgroundPalette7Left = 7 << 4,
	BackgroundPalette7Right = BackgroundPalette7Left | RightPalette,


	SpritePalette0Left = SpritePalette,
	SpritePalette0Right = SpritePalette0Left | RightPalette,
	SpritePalette1Left = 1 << 4 | SpritePalette,
	SpritePalette1Right = SpritePalette1Left | RightPalette,
	SpritePalette2Left = 2 << 4 | SpritePalette,
	SpritePalette2Right = SpritePalette2Left | RightPalette,
	SpritePalette3Left = 3 << 4 | SpritePalette,
	SpritePalette3Right = SpritePalette3Left | RightPalette,
	SpritePalette4Left = 4 << 4 | SpritePalette,
	SpritePalette4Right = SpritePalette4Left | RightPalette,
	SpritePalette5Left = 5 << 4 | SpritePalette,
	SpritePalette5Right = SpritePalette5Left | RightPalette,
	SpritePalette6Left = 6 << 4 | SpritePalette,
	SpritePalette6Right = SpritePalette6Left | RightPalette,
	SpritePalette7Left = 7 << 4 | SpritePalette,
	SpritePalette7Right = SpritePalette7Left | RightPalette,
}
