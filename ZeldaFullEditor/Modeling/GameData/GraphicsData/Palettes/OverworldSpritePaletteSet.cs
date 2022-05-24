namespace ZeldaFullEditor.Modeling.GameData.GraphicsData.Palettes
{
	public record OverworldSpritePaletteSet : IByteable
	{
		public byte Palette0 { get; set; }
		public byte Palette1 { get; set; }

		public byte[] GetByteData() => new byte[] { Palette0, Palette1 };
	}
}
