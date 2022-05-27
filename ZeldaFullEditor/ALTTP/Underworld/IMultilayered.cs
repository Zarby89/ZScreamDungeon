namespace ZeldaFullEditor.ALTTP.Underworld
{
	/// <summary>
	/// Defines the <see cref="Layer">Layer</see> property indicating which layer an entity is on.
	/// </summary>
	public interface IMultilayered
	{
		public RoomLayer Layer { get; set; }
	}
}
