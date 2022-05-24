namespace ZeldaFullEditor.Modeling.GameData.GraphicsData.Palettes
{
	public record PaletteSet : IByteable
	{
		public byte Palette0 { get; set; }
		public byte Palette1 { get; set; }
		public byte Palette2 { get; set; }
		public byte Palette3 { get; set; }

		public byte[] GetByteData() => new byte[] { Palette0, Palette1, Palette2, Palette3 };
	}
}
