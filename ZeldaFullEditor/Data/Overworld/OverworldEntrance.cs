namespace ZeldaFullEditor
{
	[Serializable]
	public class OverworldEntrance : OverworldEntity, IFreelyPlaceable, IMouseCollidable, IHaveInfo
	{
		public ushort mapPos { get; set; }
		public byte TargetEntranceID { get; set; }
		public bool IsPitEntrance { get; set; }

		public override string Name => "Entrance";

		// TODO make this based on map position and make deleted map position consistent
		public bool Deleted => (GlobalX & GlobalY) == Constants.NullEntrance;

		public OverworldEntrance(ushort x, ushort y, byte entranceId, byte mapId, ushort mapPos)
		{
			MapID = mapId;
			GlobalX = x;
			GlobalY = y;
			TargetEntranceID = entranceId;
			this.mapPos = mapPos;
		}

		public override bool PointIsInHitbox(int x, int y)
		{
			return base.PointIsInHitbox(x, y);
		}
	}
}
