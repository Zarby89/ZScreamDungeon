namespace ZeldaFullEditor
{
	/// <summary>
	/// Represents a drawable sprite, including secrets.
	/// Properties defined by the interface should be calculated by other properties specific to the class.
	/// </summary>
	public interface IDrawableSprite
	{
		byte ID { get; }
		int RealX { get; }
		int RealY { get; }
	}
}
