namespace ZeldaFullEditor.ALTTP.Underworld;

/// <summary>
/// Defines the <see cref="Layer">Layer</see> property indicating which layer an entity is on.
/// </summary>
public interface IMultilayered
{
	/// <summary>
	/// The layer this entity currently resides on.
	/// </summary>
	public RoomLayer Layer { get; set; }
}
