namespace ZeldaFullEditor
{
	/// <summary>
	/// Defines a method for items that require a ZScreamer to be passed to refer their drawing to.
	/// </summary>
	public interface IDelegatedDraw
	{
		void Draw(ZScreamer ZS);
	}
}
