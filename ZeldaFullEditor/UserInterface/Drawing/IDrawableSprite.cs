namespace ZeldaFullEditor.UserInterface.Drawing;

/// <summary>
/// Represents a drawable sprite, including secrets.
/// Properties defined by the interface should be calculated by other properties specific to the class.
/// </summary>
public interface IDrawableSprite
{
	public byte ID { get; }
	public int RealX { get; }
	public int RealY { get; }
}
