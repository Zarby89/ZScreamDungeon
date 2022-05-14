namespace ZeldaFullEditor
{
	internal interface IGraphicsSheet
	{
		public GraphicsTile this[int i] { get; }

		public sealed GraphicsTile this[Tile t] => this[t.ID];

		//public void DrawBitmap(Graphics g);
	}
}
