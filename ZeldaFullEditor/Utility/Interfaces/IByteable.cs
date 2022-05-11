namespace ZeldaFullEditor
{
	/// <summary>
	/// Represents data which can be delivered as a continuous stream of bytes.
	/// </summary>
	public interface IByteable
	{
		/// <summary>
		/// Returns a stream of bytes representing the object in its current state.
		/// </summary>
		public byte[] GetByteData();
	}
}
