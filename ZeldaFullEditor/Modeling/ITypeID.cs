namespace ZeldaFullEditor.Modeling
{
	/// <summary>
	/// Represents an entity with a distinguishing ID that can be derived directly from another property of the entity.
	/// </summary>
	public interface ITypeID
	{
		public int TypeID { get; }
	}
}
