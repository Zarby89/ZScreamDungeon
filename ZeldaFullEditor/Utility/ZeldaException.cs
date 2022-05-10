namespace ZeldaFullEditor
{
	/// <summary>
	/// For errors that we should catch, distinguished from other badder errors
	/// </summary>
	[Serializable]
	internal class ZeldaException : Exception
	{
		public ZeldaException(string message) : base(message) { }
	}
}
