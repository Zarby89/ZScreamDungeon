namespace ZeldaFullEditor.UserInterface;

/// <summary>
/// Parent class for categories related to entities with some dumb built in int sorting.
/// This is an abstract class to force new category types to create their own class to
/// facilitate reflection listings.
/// </summary>
public abstract class SearchCategory
{
	public string Name { get; protected init; } = "Name";
	public string Description { get; protected init; } = "Description";

	public sealed override string ToString() => Name;

	protected int ID { get; }
	private static int id = 0;

	protected SearchCategory()
	{
		ID = id++;
	}

}
