namespace ZeldaFullEditor.Modeling.GameData.GraphicsData.GraphicsTiles
{
	/// <summary>
	/// Contains a <see cref="GraphicsSheet"/> object and which side of the 3BPPP palette should be used should be used.
	/// </summary>
	public record SlottedSheet(GraphicsSheet Sheet, bool RightSide);
}
