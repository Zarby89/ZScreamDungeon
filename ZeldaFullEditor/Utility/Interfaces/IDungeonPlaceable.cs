namespace ZeldaFullEditor
{
	/// <summary>
	/// Represents any object which can be placed inside a dungeon.
	/// </summary>
	public interface IDungeonPlaceable : IMouseCollidable
	{
		public string Name { get; }

		public void Draw(Artist art);
	}
}
