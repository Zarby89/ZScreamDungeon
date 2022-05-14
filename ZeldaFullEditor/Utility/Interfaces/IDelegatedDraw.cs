namespace ZeldaFullEditor
{
	/// <summary>
	/// Defines a method for items that require an artist to be passed to refer their drawing to.
	/// </summary>
	public interface IDelegatedDraw
	{
		public void Draw(Artist ZS);
	}
}
