namespace ZeldaFullEditor.UserInterface.Drawing.Artists
{
	public interface IDrawArt
	{
		public GraphicsSet LoadedGraphics { get; }
		public NeedsNewArt Redrawing { get; }
	}
}
