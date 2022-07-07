namespace ZeldaFullEditor.Handler;

public class Underworld
{
	public Room[] RoomList { get; } = new Room[Constants.NumberOfRooms];
	public UnderworldEntrance[] EntranceList { get; } = new UnderworldEntrance[Constants.NumberOfEntrances];
	public UnderworldEntrance[] SpawnPointList { get; } = new UnderworldEntrance[Constants.NumberOfSpawnPoints];

	private readonly ZScreamer ZS;

	public Underworld(ZScreamer zs)
	{
		ZS = zs;
		throw new NotImplementedException();
	}

	public void OnProjectLoad()
	{
		for (ushort i = 0; i < Constants.NumberOfRooms; i++)
		{
			RoomList[i] = Room.BuildRoomFromROM(ZS, i);
			//DungeonsData.undoRoom[i] = new List<Room>();
			//DungeonsData.redoRoom[i] = new List<Room>();
		}

		for (int i = 0; i < Constants.NumberOfEntrances; i++)
		{
			EntranceList[i] = new(ZS, (byte) i, false);
		}


		for (int i = 0; i < Constants.NumberOfSpawnPoints; i++)
		{
			SpawnPointList[i] = new(ZS, (byte) i, true);
		}
	}

	public void ForAllRooms(Action<Room> action)
	{
		foreach (var room in RoomList)
		{
			action(room);
		}
	}

	
}
