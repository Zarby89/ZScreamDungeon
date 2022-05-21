namespace ZeldaFullEditor.View.Drawing.SNESGraphics
{
	/// <summary>
	/// Specifies which palette a graphic should use.
	/// When cast to a numeric value, the value may be logically OR'd with a bare index to get a full
	/// 8-bits-per-pixel index.
	/// </summary>
	public enum PaletteID
	{
		BackgroundPalette0Left = 0 << 4,
		BackgroundPalette0Right = BackgroundPalette0Left | 8,
		BackgroundPalette1Left = 1 << 4,
		BackgroundPalette1Right = BackgroundPalette1Left | 8,
		BackgroundPalette2Left = 2 << 4,
		BackgroundPalette2Right = BackgroundPalette2Left | 8,
		BackgroundPalette3Left = 3 << 4,
		BackgroundPalette3Right = BackgroundPalette3Left | 8,
		BackgroundPalette4Left = 4 << 4,
		BackgroundPalette4Right = BackgroundPalette4Left | 8,
		BackgroundPalette5Left = 5 << 4,
		BackgroundPalette5Right = BackgroundPalette5Left | 8,
		BackgroundPalette6Left = 6 << 4,
		BackgroundPalette6Right = BackgroundPalette6Left | 8,
		BackgroundPalette7Left = 7 << 4,
		BackgroundPalette7Right = BackgroundPalette7Left | 8,

		SpritePalette0Left = 0 << 4 | 0x80,
		SpritePalette0Right = SpritePalette0Left | 8,
		SpritePalette1Left = 1 << 4 | 0x80,
		SpritePalette1Right = SpritePalette1Left | 8,
		SpritePalette2Left = 2 << 4 | 0x80,
		SpritePalette2Right = SpritePalette2Left | 8,
		SpritePalette3Left = 3 << 4 | 0x80,
		SpritePalette3Right = SpritePalette3Left | 8,
		SpritePalette4Left = 4 << 4 | 0x80,
		SpritePalette4Right = SpritePalette4Left | 8,
		SpritePalette5Left = 5 << 4 | 0x80,
		SpritePalette5Right = SpritePalette5Left | 8,
		SpritePalette6Left = 6 << 4 | 0x80,
		SpritePalette6Right = SpritePalette6Left | 8,
		SpritePalette7Left = 7 << 4 | 0x80,
		SpritePalette7Right = SpritePalette7Left | 8,
	}
}
