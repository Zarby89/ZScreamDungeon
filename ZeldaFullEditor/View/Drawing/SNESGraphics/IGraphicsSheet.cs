namespace ZeldaFullEditor.View.Drawing.SNESGraphics
{
	/// <summary>
	/// Represents an object that is some higher level container of <see cref="GraphicsTile"/> objects.
	/// </summary>
	internal interface IGraphicsSheet
	{
		public GraphicsTile this[int i] { get; }
	}
}
