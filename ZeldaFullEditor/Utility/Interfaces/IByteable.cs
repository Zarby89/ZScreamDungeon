namespace ZeldaFullEditor
{
	/// <summary>
	/// Represents data which can be delivered as a continuous stream of bytes.
	/// </summary>
	public interface IByteable
	{
		/// <summary>
		/// Creates and returns a stream of bytes representing the object in its current state.
		/// </summary>
		public byte[] GetByteData();
	}
}
