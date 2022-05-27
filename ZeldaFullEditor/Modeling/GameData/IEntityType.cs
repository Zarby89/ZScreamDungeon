namespace ZeldaFullEditor.Modeling.GameData
{
	/// <summary>
	/// Represents my desire for C# to allow interfaces to declare static methods which their classes must implement.
	/// </summary>
	internal interface IEntityType<T>
	{
		/// <summary>
		/// This entity type's internal ID that should be used for sorting a 
		/// </summary>
		public int ListID { get; }

		public string Name { get; init; }
		//public static virtual T GetTypeFromID(int id);
		//public static T[] ListOf { get; }

		public abstract string ToString();
	}
}
