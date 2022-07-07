namespace ZeldaFullEditor.ALTTP.GameData;

class DungeonMap
{
	public ushort bossRoom = 0xFFFF;
	public byte nbrOfFloor = 0;
	public byte nbrOfBasement = 0;
	public List<byte[]> FloorRooms = new();
	public List<byte[]> FloorGfx = new();

	public DungeonMap(ushort bossRoom, byte nbrOfFloor, byte nbrOfBasement, List<byte[]> FloorRooms, List<byte[]> FloorGfx)
	{
		this.bossRoom = bossRoom;
		this.nbrOfFloor = nbrOfFloor;
		this.nbrOfBasement = nbrOfBasement;
		this.FloorRooms = new List<byte[]>(FloorRooms);
		this.FloorGfx = new List<byte[]>(FloorGfx);
	}
}
