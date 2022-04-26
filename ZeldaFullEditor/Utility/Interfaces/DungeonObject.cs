using System.Drawing;

namespace ZeldaFullEditor
{
	/// <summary>
	/// Represents any object which can be placed inside a dungeon.
	/// </summary>
	public interface DungeonPlaceable : IMouseCollidable
	{
		void Draw(ZScreamer ZS);

		Rectangle OutlineBox { get; }
	}
}
