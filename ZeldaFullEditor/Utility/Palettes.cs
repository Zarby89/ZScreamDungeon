namespace ZeldaFullEditor
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
