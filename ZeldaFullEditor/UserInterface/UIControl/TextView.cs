namespace ZeldaFullEditor.UserInterface.UIControl
{
	/// <summary>
	/// Specifies how UI elements should display text representations of themselves
	/// </summary>
	public enum TextView
	{
		/// <summary>
		/// Only the ID, and never the name, is shown.
		/// </summary>
		NeverShowName,

		/// <summary>
		/// Only the ID is shown, unless the mouse is hovering over the entity, in which case both ID and name are shown.
		/// </summary>
		ShowNameOnHover,

		/// <summary>
		/// Both ID and name are shown at all times.
		/// </summary>
		AlwaysShowName,
	}
}
