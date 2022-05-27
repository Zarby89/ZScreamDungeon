namespace ZeldaFullEditor.ALTTP.Underworld
{
	/// <summary>
	/// Specifies the resizability of dungeon objects in the subtype 1 class.
	/// </summary>
	[Flags]
	public enum ObjectResizability
	{
		/// <summary>
		/// Objects that cannot be resized
		/// </summary>
		None,

		/// <summary>
		/// Objects whose size changes their width on the X-axis
		/// </summary>
		Horizontal,

		/// <summary>
		/// Objects whose size changes their height on the Y-axis
		/// </summary>
		Vertical,

		/// <summary>
		/// Objects whose size change both their width and their height
		/// </summary>
		Both
	}
}
