namespace ZeldaFullEditor.Modeling.GameData
{
	/// <summary>
	/// Represents my desire for C# to allow interfaces to declare static methods which their classes must implement.
	/// </summary>
	internal interface IEntityType<T>
	{
		public string Name { get; init; }
		//public static virtual T GetTypeFromID(int id);
		//public static T[] ListOf { get; }

		public string ToString() => Name;
	}
}
