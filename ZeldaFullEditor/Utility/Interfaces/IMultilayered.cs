namespace ZeldaFullEditor
{
	/// <summary>
	/// Contains the <see cref="Layer">Layer</see> property indicating which layer an entity is on.
	/// </summary>
	public interface IMultilayered
	{
		byte Layer { get; set; }
	}
}
