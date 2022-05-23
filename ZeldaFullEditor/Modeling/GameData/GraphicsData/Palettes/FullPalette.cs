namespace ZeldaFullEditor.Modeling.GameData.GraphicsData.Palettes
{
	public class FullPalette
	{
		private readonly SNESColor[] Palette;

		public SNESColor this[int i] => Palette[i];

		public SNESColor this[int palette, int index]
		{
			get {
				if (palette is > 15 or < 0)
				{
					throw new ArgumentOutOfRangeException(nameof(palette), "Palette id may not exceed 15.");
				}
				else if (index is > 15 or < 0)
				{
					throw new ArgumentOutOfRangeException(nameof(index), "Palette index may not exceed 15.");
				}

				return Palette[palette * 16 + index];
			}
		}

		public FullPalette()
		{
			
		}

		public void AddPartialPalette(PartialPalette p, int index)
		{
			int i = 0;
			foreach (var c in p.GetNextColor())
			{
				if (c is not null)
				{
					Palette[i] = (SNESColor) c;
				}
				i++;
			}
		}



		public Color[] GetFullPalette()
		{
			var ret = new Color[Constants.TotalPaletteSize];

			for (int i = 1; i < Constants.TotalPaletteSize; i++)
			{
				ret[i] = Palette[i].RealColor;
			}

			return ret;
		}
	}
}
