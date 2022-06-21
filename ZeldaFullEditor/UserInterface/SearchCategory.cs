namespace ZeldaFullEditor.UserInterface
{
	/// <summary>
	/// Parent class for categories related to entities with some dumb built in int sorting.
	/// </summary>
	public abstract class SearchCategory
	{
		public abstract string Name { get; protected init; }
		public abstract string Description { get; protected init; }

		public override string ToString() => Name;

		protected int ID { get; }
		private static int id = 0;

		protected SearchCategory()
		{
			ID = id++;
		}

	}
}
