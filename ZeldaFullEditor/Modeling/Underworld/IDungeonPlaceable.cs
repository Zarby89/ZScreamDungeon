namespace ZeldaFullEditor.Modeling.Underworld
{
	/// <summary>
	/// Represents any object which can be placed inside a dungeon.
	/// </summary>
	public interface IDungeonPlaceable : IMouseCollidable, IHaveInfo, IDelegatedDraw
	{
		public void Draw(Artist art);
	}
}
