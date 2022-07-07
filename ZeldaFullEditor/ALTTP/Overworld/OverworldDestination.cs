namespace ZeldaFullEditor.ALTTP.Overworld;

/// <summary>
/// Provides a base class for 
/// </summary>
public abstract class OverworldDestination : OverworldEntity, IMouseCollidable, IFreelyPlaceable, IHaveInfo
{
	public ushort ScrollX { get; set; }
	public ushort ScrollY { get; set; }
	public ushort CameraX { get; set; }
	public ushort CameraY { get; set; }
	public ushort VRAMBase { get; set; }

	public bool Deleted => (GlobalX & GlobalY) == Constants.NullEntrance;
	public override void SnapToGrid()
	{
		GlobalX &= 0xFFF8;
		GlobalY &= 0xFFF8;
	}

	public void UpdateMapProperties(bool isLarge)
	{
		var large = 256;

		if (MapID < 128)
		{
			large = isLarge ? 768 : 256;
		}

		var mapx = (MapID & 7) << 9;
		var mapy = (MapID & 0x38) << 6;
		ScrollX = (ushort) (GlobalX - 134);
		ScrollY = (ushort) (GlobalY - 78);

		if (ScrollX < mapx)
		{
			ScrollX = (ushort) mapx;
		}

		if (ScrollY < mapy)
		{
			ScrollY = (ushort) mapy;
		}

		if (ScrollX > mapx + large)
		{
			ScrollX = (ushort) (mapx + large);
		}
		if (ScrollY > mapy + large + 30)
		{
			ScrollY = (ushort) (mapy + large + 30);
		}

		CameraX = GlobalX;
		CameraY = (ushort) (GlobalY + 19);

		if (CameraX < mapx + 127)
		{
			CameraX = (ushort) (mapx + 127);
		}
		else if (CameraX > mapx + 127 + large)
		{
			CameraX = (ushort) (mapx + 127 + large);
		}

		if (CameraY < mapy + 111)
		{
			CameraY = (ushort) (mapy + 111);
		}
		else if (CameraY > mapy + 143 + large)
		{
			CameraY = (ushort) (mapy + 143 + large);
		}

		var vramXScroll = (ushort) (ScrollX - mapx);
		var vramYScroll = (ushort) (ScrollY - mapy);

		VRAMBase = (ushort) ((vramYScroll & 0xFFF0) << 3 | (vramXScroll & 0xFFF0) >> 3);
	}
}
