namespace ZeldaFullEditor.ALTTP.Underworld;

/// <summary>
/// Represents any object which can be placed inside a dungeon.
/// </summary>
public interface IDungeonPlaceable : IMouseCollidable, IHaveInfo
{
	public void Draw(IDrawArt art);
}
