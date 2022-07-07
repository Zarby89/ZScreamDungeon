namespace ZeldaFullEditor.ALTTP;

/// <summary>
/// Standardizes the retrieval of data that can be delivered as a continuous stream of bytes.
/// </summary>
public interface IByteable
{
	/// <summary>
	/// Creates and returns a stream of bytes representing the object in its current state.
	/// </summary>
	/// <returns>
	/// An array of <see langword="byte"/> values that can be written continuously to a ROM binary.
	/// </returns>
	public byte[] GetByteData();
}
