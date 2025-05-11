using System;
using static ZeldaFullEditor.OverworldMap;

namespace ZeldaFullEditor
{
    /// <summary>
    ///     A data class containing all the info for oveworld entrances.
    /// </summary>
    [Serializable]
    public class EntranceOW
    {
        /// <summary>
        ///     Gets or sets the x position of the entrance.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        ///     Gets or sets the y position of the entrance.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        ///     Gets or sets the map position of the entrance.
        /// </summary>
        public ushort MapPos { get; set; }

        /// <summary>
        ///     Gets or sets the entrance ID.
        /// </summary>
        public byte EntranceID { get; set; }

        /// <summary>
        ///     Gets or sets the area x position of the entrance.
        /// </summary>
        public byte AreaX { get; set; }

        /// <summary>
        ///     Gets or sets the area y position of the entrance.
        /// </summary>
        public byte AreaY { get; set; }

        /// <summary>
        ///     Gets or sets the map ID the entrance is in.
        /// </summary>
        public short MapID { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether gets or sets whether the entrance is a hole or not.
        /// </summary>
        public bool IsHole { get; set; } = false;

        /// <summary>
        ///     Gets or sets a value indicating whether gets or sets whether the entrance is deleted or not.
        /// </summary>
        public bool Deleted { get; set; } = false;

        /// <summary>
        ///     Gets or sets the unique ID of the entrance.
        /// </summary>
        public int UniqueID { get; set; } = 0;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EntranceOW"/> class.
        ///     mapId might be useless but we will need it to check if the entrance is in the darkworld or lightworld.
        /// </summary>
        /// <param name="x"> The x position. </param>
        /// <param name="y"> The y position. </param>
        /// <param name="entranceId"> The entrance ID. </param>
        /// <param name="mapId"> The map ID. </param>
        /// <param name="mapPos"> The map position. </param>
        /// <param name="hole"> Whether the entrance is a hole or not. </param>
        public EntranceOW(int x, int y, byte entranceId, short mapId, ushort mapPos, bool hole)
        {
            this.X = x;
            this.Y = y;
            this.EntranceID = entranceId;
            this.MapID = mapId;
            this.MapPos = mapPos;

            int mapX = mapId - ((mapId / 8) * 8);
            int mapY = mapId / 8;

            this.AreaX = (byte)(Math.Abs(x - (mapX * 512)) / 16);
            this.AreaY = (byte)(Math.Abs(y - (mapY * 512)) / 16);

            this.IsHole = hole;

            this.UniqueID = ROM.uniqueEntranceID;
            ROM.uniqueEntranceID += 1;
        }

        /// <summary>
        ///     Creats a new copy of this entrance and returns it.
        /// </summary>
        /// <returns> A copy of this entrance. </returns>
        public EntranceOW Copy()
        {
            return new EntranceOW(this.X, this.Y, this.EntranceID, this.MapID, this.MapPos, this.IsHole);
        }

        /// <summary>
        ///     Updates certain entrance properties based on the given area map ID.
        /// </summary>
        /// <param name="mapID"> The ID of the area map. </param>
        public void UpdateMapStuff(short mapID, AreaSizeEnum areaSize)
        {
            this.MapID = mapID;

            if (mapID >= 64)
            {
                mapID -= 64;
            }

            int mapX = mapID - ((mapID / 8) * 8);
            int mapY = mapID / 8;

            this.AreaX = (byte)(Math.Abs(this.X - (mapX * 512)) / 16);
            this.AreaY = (byte)(Math.Abs(this.Y - (mapY * 512)) / 16);

            this.AreaX = this.AreaX.Clamp(0, 63);
            this.AreaY = this.AreaY.Clamp(0, 63);

            // If we are on a large map:
            switch (areaSize)
            {
                case AreaSizeEnum.LargeArea:
                    this.AreaX = this.AreaX.Clamp(0, 31);
                    this.AreaY = this.AreaY.Clamp(0, 31);
                    break;

                case AreaSizeEnum.WideArea:
                    this.AreaY = this.AreaY.Clamp(0, 31);
                    break;

                case AreaSizeEnum.TallArea:
                    this.AreaX = this.AreaX.Clamp(0, 31);
                    break;
            }

            this.MapPos = (ushort)(((this.AreaY << 6) | (this.AreaX & 0x3F)) << 1);
            /*
                int mx = mapId - ((mapId / 8) * 8);
                int my = mapId / 8;
                byte xx = (byte)((this.X - (mx * 512)) / 16);
                byte yy = (byte)((this.Y - (my * 512)) / 16);
                Console.WriteLine(xx + ", " + yy + ", " + mapPos);
            */

            if (this.IsHole)
            {
                Console.WriteLine("Hole:      0x" + this.EntranceID.ToString("X2") + " MapId: 0x" + mapID.ToString("X2") + " X: " + this.AreaX + " Y: " + this.AreaY);
            }
            else
            {
                Console.WriteLine("Entrance:  0x" + this.EntranceID.ToString("X2") + " MapId: 0x" + mapID.ToString("X2") + " X: " + this.AreaX + " Y: " + this.AreaY);
            }
        }
    }
}
