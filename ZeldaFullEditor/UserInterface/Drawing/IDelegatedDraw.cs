namespace ZeldaFullEditor.UserInterface.Drawing
{
	/// <summary>
	/// Defines a method for items that require an artist to be passed to refer their drawing to.
	/// </summary>
	public interface IDelegatedDraw
	{
		/// <summary>
		/// Draw this object using the specified artist.
		/// </summary>
		public void Draw(Artist art);
	}
}
