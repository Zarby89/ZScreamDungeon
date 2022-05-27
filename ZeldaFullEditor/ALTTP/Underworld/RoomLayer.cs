namespace ZeldaFullEditor.ALTTP.Underworld
{
	/// <summary>
	/// Specifies which layer an entity is on in the underworld.
	/// </summary>
	public enum RoomLayer
	{
		Layer1 = 0,
		Layer2 = 1,

		/// <summary>
		/// Specifies the meta layer, which is really just Layer1 again.
		/// </summary>
		Layer3 = 2,

		None = -1
	}
}
