namespace ZeldaFullEditor.ALTTP.GameData.GraphicsData.GraphicsTiles;

public record BackgroundSet : IByteable
{
	public GraphicsSheet Sheet0 { get; set; }
	public GraphicsSheet Sheet1 { get; set; }
	public GraphicsSheet Sheet2 { get; set; }
	public GraphicsSheet Sheet3 { get; set; }
	public GraphicsSheet Sheet4 { get; set; }
	public GraphicsSheet Sheet5 { get; set; }
	public GraphicsSheet Sheet6 { get; set; }
	public GraphicsSheet Sheet7 { get; set; }

	public byte[] GetByteData()
	{
		return new byte[]
		{
			Sheet0.ID ?? 0xFF,
			Sheet1.ID ?? 0xFF,
			Sheet2.ID ?? 0xFF,
			Sheet3.ID ?? 0xFF,
			Sheet4.ID ?? 0xFF,
			Sheet5.ID ?? 0xFF,
			Sheet6.ID ?? 0xFF,
			Sheet7.ID ?? 0xFF,
		};
	}
}
