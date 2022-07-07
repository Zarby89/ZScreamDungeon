namespace ZeldaFullEditor.Handler;

/// <summary>
/// For errors that we should catch, distinguished from other badder errors
/// </summary>
[Serializable]
internal class ZeldaException : Exception
{
	/// <summary>
	/// Initializes a new instance of the <see cref="ZeldaException"/> class with the specified <paramref name="message"/>.
	/// </summary>
	/// <param name="message">A comprehensive warning that will be displayed to the end user.</param>
	public ZeldaException(string message) : base(message) { }
}
