namespace ZeldaFullEditor.ALTTP.GameData.GraphicsData.GraphicsTiles;

/// <summary>
/// Contains a <see cref="GraphicsSheet"/> object and which side of the 3BPP palette should be used.
/// </summary>
public record SlottedSheet(GraphicsSheet Sheet, bool RightSide);
