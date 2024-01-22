namespace ZeldaFullEditor.ALTTP.Overworld;

[Serializable]
public class OverworldEntrance : OverworldEntity, IFreelyPlaceable, IMouseCollidable, IHaveInfo, IOverworldUWLink
{
	public ushort Map16Index { get; set; }
	public byte TargetEntranceID { get; set; }
	public bool IsPitEntrance { get; set; }

	public ushort TargetID
	{
		get => TargetEntranceID;
		set => TargetEntranceID = (byte) value;
	}

	public override string Name => "Entrance";

	// TODO make this based on map position and make deleted map position consistent
	public bool Deleted => (GlobalX & GlobalY) == Constants.NullEntrance;

	public OverworldEntrance(ushort x, ushort y, byte entranceId, byte mapId, ushort mapPos)
	{
		MapID = mapId;
		GlobalX = x;
		GlobalY = y;
		TargetEntranceID = entranceId;
		Map16Index = mapPos;
	}

	public override bool PointIsInHitbox(int x, int y)
	{
		return base.PointIsInHitbox(x, y);
	}
}
