namespace ZeldaFullEditor.Modeling.GameData.GraphicsData.GraphicsTiles
{
	public record SheetSet : IByteable
	{
		public GraphicsSheet Sheet0 { get; set; }
		public GraphicsSheet Sheet1 { get; set; }
		public GraphicsSheet Sheet2 { get; set; }
		public GraphicsSheet Sheet3 { get; set; }

		public byte[] GetByteData()
		{
			return new byte[]
			{
				Sheet0.ID ?? 0xFF,
				Sheet1.ID ?? 0xFF,
				Sheet2.ID ?? 0xFF,
				Sheet3.ID ?? 0xFF,
			};
		}
	}
}
