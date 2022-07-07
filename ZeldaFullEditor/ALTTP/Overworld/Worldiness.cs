namespace ZeldaFullEditor.ALTTP.Overworld;

/// <summary>
/// Specifies which "world" of the overworld is being operated on.
/// </summary>
public enum Worldiness
{
	/// <summary>
	/// Light World screens, from ID 0x00 to 0x3F.
	/// </summary>
	LightWorld = 0,

	/// <summary>
	/// Dark World screens, from ID 0x40 to 0x7F.
	/// </summary>
	DarkWorld = 64,

	/// <summary>
	/// Special overworld, overlays, and special rooms, from ID 0x80 to 0xFF.
	/// </summary>
	SpecialWorld = 128,
}
