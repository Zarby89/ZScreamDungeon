using System;
using static ZeldaFullEditor.OverworldMap;

namespace ZeldaFullEditor
{
    /// <summary>
    ///     A data class containing data for individual dungeon pot or overworld items.
    /// </summary>
    [Serializable]
    public class RoomPotSaveEditor
    {
        /// <summary>
        ///     Gets or sets the in game X position for the item.
        /// </summary>
        public byte GameX { get; set; }

        /// <summary>
        ///     Gets or sets the in game Y position for the item.
        /// </summary>
        public byte GameY { get; set; }

        /// <summary>
        ///     Gets or sets the in game ID for the item.
        /// </summary>
        public byte ID { get; set; }

        /// <summary>
        ///     Gets or sets the in editor X position for the item.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        ///     Gets or sets the in editor Y position for the item.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the item is placed on BG2 or not.
        /// </summary>
        public bool BG2 { get; set; } = false;

        /// <summary>
        ///     Gets or sets dungeon room ID or overworld area ID where the item is placed.
        /// </summary>
        public ushort RoomMapID { get; set; }

        /// <summary>
        ///     Gets or sets the in editor unique ID for the item.
        /// </summary>
        public int UniqueID { get; set; } = 0;

        /// <summary>
        ///     Gets or sets a value indicating whether the item is deleted or not.
        /// </summary>
        public bool Deleted { get; set; } = false;

        /// <summary>
        ///     Initializes a new instance of the <see cref="RoomPotSaveEditor"/> class.
        /// </summary>
        /// <param name="id"> The ID. </param>
        /// <param name="roomMapId"> The dungeon room ID or overworld area ID. </param>
        /// <param name="x"> The in editor X position. </param>
        /// <param name="y"> The in editor Y position. </param>
        /// <param name="bg2"> Whether the Item is on BG2 or not. </param>
        public RoomPotSaveEditor(byte id, ushort roomMapId, int x, int y, bool bg2)
        {
            ID = id;
            X = x.Clamp(0, 4080);
            Y = y.Clamp(0, 4080);
            BG2 = bg2;
            RoomMapID = roomMapId;

            int fakeID = roomMapId % 0x40;

            int mapX = fakeID - ((fakeID / 8) * 8);
            int mapY = fakeID / 8;

            GameX = (byte)(Math.Abs(x - (mapX * 512)) / 16);
            GameY = (byte)(Math.Abs(y - (mapY * 512)) / 16);
            UniqueID = ROM.uniqueItemID++;
        }

        /// <summary>
        ///     Updates the item info when needed. Generally when moving items around in editor.
        /// </summary>
        /// <param name="roomMapId"> The dungeon room ID or overworld area ID where the item was moved to. </param>
        public void UpdateMapStuff(short roomMapId, AreaSizeEnum areaSize)
        {
            RoomMapID = (ushort)roomMapId;

            roomMapId %= 0x40;

            int mapX = roomMapId - ((roomMapId / 8) * 8);
            int mapY = roomMapId / 8;

            GameX = (byte)(Math.Abs(X - (mapX * 512)) / 16);
            GameY = (byte)(Math.Abs(Y - (mapY * 512)) / 16);

            GameX = GameX.Clamp(0, 63);
            GameY = GameY.Clamp(0, 63);

            // If we are on a large map:
            switch (areaSize)
            {
                case AreaSizeEnum.SmallArea:
                    GameX = GameX.Clamp(0, 31);
                    GameY = GameY.Clamp(0, 31);
                    break;

                case AreaSizeEnum.WideArea:
                    GameY = GameY.Clamp(0, 31);
                    break;

                case AreaSizeEnum.TallArea:
                    GameX = GameX.Clamp(0, 31);
                    break;
            }

            Console.WriteLine("Item:      0x" + ID.ToString("X2") + " MapId: 0x" + RoomMapID.ToString("X2") + " X: " + GameX + " Y: " + GameY);
        }

        /// <summary>
        ///     A function that creates and returns a copy of this item.
        /// </summary>
        /// <returns> A new copy of this item. </returns>
        public RoomPotSaveEditor Copy()
        {
            return new RoomPotSaveEditor(ID, RoomMapID, X, Y, BG2);
        }
    }
}
