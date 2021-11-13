using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
    public static class DungeonsData
    {
        public static Room[] all_rooms = new Room[296];
        public static Room[] all_rooms_moved = new Room[296];
        public static Entrance[] entrances = new Entrance[0x85];
        public static Entrance[] starting_entrances = new Entrance[0x07];
        public static List<Room>[] undoRoom = new List<Room>[296];
        public static List<Room>[] redoRoom = new List<Room>[296];


    }
}
