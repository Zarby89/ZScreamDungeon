using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaFullEditor.Data.DungeonObjects;

namespace ZeldaFullEditor
{
	public static class DungeonsData
	{
		public static DungeonRoom[] all_rooms = new DungeonRoom[Constants.NumberOfRooms];
		public static DungeonRoom[] all_rooms_moved = new DungeonRoom[Constants.NumberOfRooms];
		public static Entrance[] entrances = new Entrance[Constants.NumberOfEntrances];
		public static Entrance[] starting_entrances = new Entrance[0x07];
		public static List<DungeonRoom>[] undoRoom = new List<DungeonRoom>[Constants.NumberOfRooms];
		public static List<DungeonRoom>[] redoRoom = new List<DungeonRoom>[Constants.NumberOfRooms];
	}
}
