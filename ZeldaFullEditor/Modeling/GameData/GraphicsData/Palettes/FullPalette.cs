namespace ZeldaFullEditor.Modeling.GameData.GraphicsData.Palettes
{
	public class FullPalette
	{
		private readonly SNESColor[] Palette;

		public SNESColor this[int i] => Palette[i];

		/// <summary>
		/// 
		/// </summary>
		/// <param name="palette"></param>
		/// <param name="color"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		public SNESColor this[int palette, int color]
		{
			get {
				if (palette is > 15 or < 0)
				{
					throw new ArgumentOutOfRangeException(nameof(palette), "Palette id may not exceed 15.");
				}
				else if (color is > 15 or < 0)
				{
					throw new ArgumentOutOfRangeException(nameof(color), "Palette index may not exceed 15.");
				}

				return Palette[palette * 16 + color];
			}
		}

		public FullPalette()
		{
			
		}

		public void AddPartialPalette(PartialPalette p, int index)
		{
			foreach (var c in p.GetNextColor())
			{
				if (c is not null)
				{
					Palette[index] = (SNESColor) c;
				}
				index++;
			}
		}

		public void DuplicateHalfPalette(int source, int destination)
		{
			for (int i = 1; i < 8; i++)
			{
				Palette[destination + i] = Palette[source + i];
			}
		}

		public Color[] ToColorArray()
		{
			var ret = new Color[Constants.TotalPaletteSize];

			for (int i = 1; i < Constants.TotalPaletteSize; i++)
			{
				ret[i] = Palette[i].RealColor;
			}

			ret[0] = Color.Transparent;

			return ret;
		}
	}
}
