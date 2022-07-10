namespace ZeldaFullEditor.ALTTP.Overworld;

public readonly struct OverlayTile
{
	public byte MapX { get; }
	public byte MapY { get; }
	public ushort Tile16ID { get; }

	public bool IsGarbage => Tile16ID == 0xFFFF;

	public OverlayTile(ushort tileId, byte x, byte y)
	{
		MapX = x;
		MapY = y;
		Tile16ID = tileId;
	}

	public OverlayTile(int tileId, int x, int y) : this((ushort) tileId, (byte) x, (byte) y)
	{
	}

	public static readonly OverlayTile GarbageTile = new(0xFFFF, 0xFF, 0xFF);
}
