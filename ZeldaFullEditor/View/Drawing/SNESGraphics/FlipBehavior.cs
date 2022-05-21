namespace ZeldaFullEditor.View.Drawing.SNESGraphics
{
	/// <summary>
	/// Specifies changes in binary properties to apply to a <see cref="Tile"/>.
	/// </summary>
	public enum FlipBehavior : byte
	{
		/// <summary>
		/// Property is left as is.
		/// </summary>
		LeaveAlone,

		/// <summary>
		/// Property is forced to <see langword="false"/>, regardless of the original state.
		/// </summary>
		ForcedToFalse,

		/// <summary>
		/// Property is forced to <see langword="true"/>, regardless of the original state.
		/// </summary>
		ForcedToTrue,

		/// <summary>
		/// Property is flipped with a logical not of its original state.
		/// </summary>
		InvertFlip
	}
}
