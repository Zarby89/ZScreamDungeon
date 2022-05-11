namespace ZeldaFullEditor
{
	/// <summary>
	/// Represents any object which can be placed inside a dungeon.
	/// </summary>
	public interface IDungeonPlaceable : IMouseCollidable
	{
		string Name { get; }

		void Draw(Artist art);
	}
}
