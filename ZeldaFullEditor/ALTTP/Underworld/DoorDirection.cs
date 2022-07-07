namespace ZeldaFullEditor.ALTTP.Underworld;

/// <summary>
/// Specifies which direction a door faces.
/// This should be the same cardinal direction as the wall this door is placed on.
/// </summary>
public enum DoorDirection
{
	North = 0x00,
	South = 0x01,

	/// <summary>
	/// Weast
	/// </summary>
	West = 0x02,
	East = 0x03
}
