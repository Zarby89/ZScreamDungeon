using System.Collections.Generic;
using ZeldaFullEditor.Data;

namespace ZeldaFullEditor
{
    /// <summary>
    ///     A static class used to hold all the dungeon rooms and other related data.
    /// </summary>
    public static class DungeonsData
    {
        /// <summary>
        ///     All of the dungeon rooms.
        /// </summary>
        public static Room[] AllRooms = new Room[Constants.NumberOfRooms];

        /// <summary>
        ///     A temporary list of all rooms used when moving rooms from one ROM to another.
        /// </summary>
        public static Room[] AllRoomsMoved = new Room[Constants.NumberOfRooms];

        /// <summary>
        ///     All of the entrances.
        /// </summary>
        public static Entrance[] Entrances = new Entrance[0x85];

        /// <summary>
        ///     All of the starting entrances (entrances that the player can spawn at).
        /// </summary>
        public static Entrance[] StartingEntrances = new Entrance[0x07];

        /// <summary>
        ///     A duplicate storage of all rooms to revert to when using the undo feature.
        /// </summary>
        public static List<Room>[] UndoRoom = new List<Room>[Constants.NumberOfRooms];

        /// <summary>
        ///     A duplicate storage of all rooms to revert to when using the redo feature.
        /// </summary>
        public static List<Room>[] RedoRoom = new List<Room>[Constants.NumberOfRooms];

        public static List<SpriteProperty> SpriteProperties = new List<SpriteProperty>();

        public static byte[] SpriteDamageTaken = new byte[0x1000];

        public static byte[] GlobalDamages = new byte[0x80];
    }
}
