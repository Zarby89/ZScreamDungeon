namespace ZeldaFullEditor.Utility
{
	public static class Palettes
	{
		public static Color ToColor(this ushort c)
		{
			return Color.FromArgb((c & 0x1F) << 3, (c >> 2) & 0xF8, (c >> 7) & 0xF8);
		}

		public static ushort To555Short(this Color c)
		{
			return (ushort) (((c.B & 0xF8) << 7) | ((c.G & 0xF8) << 2) | (c.R >> 3));
		}

		/// <summary>
		/// Returns a new copy of this color with the alpha channel forced to 255.
		/// </summary>
		/// <returns>
		/// I don't know if this is even necessary, but I don't feel like debugging Zarby's palette code yet.
		/// </returns>
		public static Color NewCopy(this Color col)
		{
			return Color.FromArgb(255, col);
		}

		public static void FillInHalfPaletteZeros(Color[] palette, Color fill)
		{
			for (int i = 0; i < Constants.TotalPaletteSize; i += Constants.ColorsPerHalfPalette)
			{
				palette[i] = fill;
			}
		}
	}
}
