namespace ZeldaFullEditor.ALTTP.GameData.Defaults
{
	/// <summary>
	/// Base class for defining names and IDs of reusable entities and concepts.
	/// </summary>
	public abstract record EntityName(int ID, string Name)
	{
		public override string ToString() => $"{ID:X2} {Name}";
	}

	/// <summary>
	/// Provides static lists of names based on the vanilla usage and properties of the contained entities,
	/// and methods for searching those lists.
	/// </summary>
	internal static class DefaultEntities
	{

		/// <summary>
		/// Finds an entity with the specified <paramref name="id"/> in the given list and returns its name.
		/// </summary>
		/// <returns>
		/// A <see langword="string"/> containing the entity's name.
		/// </returns>
		/// <exception cref="KeyNotFoundException"></exception>
		public static string GetNameFromEntityList(this EntityName[] list, int id)
		{
			return list.GetObjectFromEntityList(id)?.Name ??
				throw new KeyNotFoundException($"No entity with the ID {id:X} was found in the list.");
		}

		/// <summary>
		/// Finds an entity with the specified <paramref name="id"/> in the given list.
		/// </summary>
		/// <returns>
		/// An object of type <typeparamref name="T"/> with the given <paramref name="id"/>
		/// or <see langword="null"/> if no entity in the list has the ID requested.
		/// </returns>
		public static T GetObjectFromEntityList<T>(this T[] list, int id) where T : EntityName
		{
			return Array.Find(list, s => s.ID == id);
		}

		/// <summary>
		/// Retrieves all entities in the specified <paramref name="list"/> whose name contains the string specified
		/// in <paramref name="match"/>, with casing ignored.
		/// </summary>
		/// <returns>An array of type <typeparamref name="T"/> containing what I said above.</returns>
		public static T[] GetAllObjectsFromEntityListByName<T>(this T[] list, string match) where T : EntityName
		{
			return Array.FindAll(list, s => s.Name.Contains(match, StringComparison.CurrentCultureIgnoreCase));
		}
	}
}
