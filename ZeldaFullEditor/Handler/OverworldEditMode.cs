namespace ZeldaFullEditor.Handler;

/// <summary>
/// Specifies the current editing mode the <see cref="OverworldEditor"/> should be operating in.
/// </summary>
public enum OverworldEditMode
{
	Tile16,
	Tile16Fill,
	Overlay,
	Sprites,
	Secrets,
	Entrances,
	Exits,
	Transports,
	Gravestones,
	Doors,
}
