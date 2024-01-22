namespace ZeldaFullEditor.ALTTP.Overworld;

/// <summary>
/// Groups <see cref="OverworldEntrance"/> and <see cref="OverworldExit"/> together to use them within the same Overworld mode.
/// </summary>
public interface IOverworldUWLink : IMouseCollidable
{
	public ushort TargetID { get; set; }
	public ushort GlobalX { get; set; }
	public ushort GlobalY { get; set; }
	public byte MapID { get; set; }

	public bool IsInThisWorld(Worldiness world);

	public void SnapToGrid();
}
