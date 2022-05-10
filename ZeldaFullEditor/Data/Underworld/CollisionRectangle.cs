namespace ZeldaFullEditor.Data.Underworld
{
	// @author: scawful
	public class CollisionRectangle
	{
		public byte Width { get; set; }
		public byte Height { get; set; }

		public ushort Position { get; set; }
		public byte[] TileData { get; set; }

		public CollisionRectangle(byte w, byte h, ushort p, params byte[] tiles)
		{
			Width = w;
			Height = h;
			Position = p;
			TileData = tiles;
		}
	}
}
