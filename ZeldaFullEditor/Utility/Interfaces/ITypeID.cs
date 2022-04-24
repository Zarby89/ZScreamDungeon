namespace ZeldaFullEditor
{
	/// <summary>
	/// Represents an entity with a distinguishing ID that can be derived directly from another property of the entity.
	/// </summary>
	public interface ITypeID
	{
		int TypeID { get; }
	}
}
