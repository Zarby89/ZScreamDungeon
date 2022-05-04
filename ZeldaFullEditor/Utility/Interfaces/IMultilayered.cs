namespace ZeldaFullEditor
{
	/// <summary>
	/// Contains the <see cref="Layer">Layer</see> property indicating which layer an entity is on.
	/// </summary>
	public interface IMultilayered
	{
		RoomLayer Layer { get; set; }
	}

	public enum RoomLayer
	{
		Layer1 = 0,
		Layer2 = 1,
		Layer3 = 2,

		None = -1
	}
}
