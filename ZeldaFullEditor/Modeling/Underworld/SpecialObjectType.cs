namespace ZeldaFullEditor.Modeling.Underworld
{
	/// <summary>
	/// Specifies extra-important properties of a <see cref="RoomObjectType"/>
	/// </summary>
	public enum SpecialObjectType
	{
		/// <summary>
		/// Object is not noteworthy whatsoever
		/// </summary>
		None,

		/// <summary>
		/// Staircase objects that trigger transitions from one room to another
		/// </summary>
		InterroomStairs,

		/// <summary>
		/// Normal small chests
		/// </summary>
		Chest,

		/// <summary>
		/// Normal big chests
		/// </summary>
		BigChest,

		/// <summary>
		/// Blocks which may be pushed
		/// </summary>
		PushBlock,

		/// <summary>
		/// Torches which may be lit
		/// </summary>
		Torch,

		/// <summary>
		/// Objects delegated to the meta layer as a means of revealing the lower layer through the upper layer
		/// </summary>
		LayerMask,
	}
}
