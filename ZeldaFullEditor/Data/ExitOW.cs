using System;

namespace ZeldaFullEditor
{
    /// <summary>
    ///     A class containing all the info for each Oveworld Exit.
    /// </summary>
    [Serializable]
    public class ExitOW
    {
        /// <summary>
        ///     Gets or sets the map ID for the exit.
        /// </summary>
        public byte MapID { get; set; }

        /// <summary>
        ///     Gets or sets the Y scroll mod for the exit.
        /// </summary>
        public byte ScrollModY { get; set; }

        /// <summary>
        ///     Gets or sets the X scroll mod for the exit.
        /// </summary>
        public byte ScrollModX { get; set; }

        /// <summary>
        ///     Gets or sets the editor X door position for the exit.
        /// </summary>
        public byte DoorXEditor { get; set; }

        /// <summary>
        ///     Gets or sets the editor Y door position for the exit.
        /// </summary>
        public byte DoorYEditor { get; set; }

        /// <summary>
        ///     Gets or sets the X area for the exit.
        /// </summary>
        public byte AreaX { get; set; }

        /// <summary>
        ///     Gets or sets the Y area for the exit.
        /// </summary>
        public byte AreaY { get; set; }

        /// <summary>
        ///     Gets or sets the VRAM location for the exit.
        /// </summary>
        public short VRAMLocation { get; set; }

        /// <summary>
        ///     Gets or sets the X scroll for the exit.
        /// </summary>
        public short XScroll { get; set; }

        /// <summary>
        ///     Gets or sets the Y scroll for the exit.
        /// </summary>
        public short YScroll { get; set; }

        /// <summary>
        ///     Gets or sets the camera X position for the exit.
        /// </summary>
        public short CameraX { get; set; }

        /// <summary>
        ///     Gets or sets the camera Y position for the exit.
        /// </summary>
        public short CameraY { get; set; }

        /// <summary>
        ///     Gets or sets the 1st door type for the exit.
        /// </summary>
        public short DoorType1 { get; set; }

        /// <summary>
        ///     Gets or sets the 2nd door type for the exit.
        /// </summary>
        public short DoorType2 { get; set; }

        /// <summary>
        ///     Gets or sets the room ID for the exit.
        /// </summary>
        public ushort RoomID { get; set; }

        /// <summary>
        ///     Gets or sets the player X position for the exit.
        /// </summary>
        public ushort PlayerX { get; set; }

        /// <summary>
        ///     Gets or sets the player Y position for the exit.
        /// </summary>
        public ushort PlayerY { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the exit values are automatically calculated or not.
        /// </summary>
        public bool IsAutomatic { get; set; } = true;

        /// <summary>
        ///     Gets or sets a value indicating whether the exit is deleted or not.
        /// </summary>
        public bool Deleted { get; set; } = false;

        /// <summary>
        ///     Gets or sets the unique ID for the exit.
        /// </summary>
        public int UniqueID { get; set; } = 0;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ExitOW"/> class.
        /// </summary>
        /// <param name="roomID"> The room ID. </param>
        /// <param name="mapID"> The map ID. </param>
        /// <param name="vramLocation"> The VRAM location. </param>
        /// <param name="yScroll"> The Y scroll. </param>
        /// <param name="xScroll"> The X scroll. </param>
        /// <param name="playerY"> The player Y position. </param>
        /// <param name="playerX"> The player X position. </param>
        /// <param name="cameraY"> The camera Y position. </param>
        /// <param name="cameraX"> The camera X position. </param>
        /// <param name="scrollModY"> The Y scroll mod. </param>
        /// <param name="scrollModX"> The X scroll mod. </param>
        /// <param name="doorType1"> The 1st door type. </param>
        /// <param name="doorType2"> The 2nd door type. </param>
        public ExitOW(ushort roomID, byte mapID, short vramLocation, short yScroll, short xScroll, ushort playerY, ushort playerX, short cameraY, short cameraX, byte scrollModY, byte scrollModX, short doorType1, short doorType2)
        {
            this.RoomID = roomID;
            this.MapID = mapID;
            this.VRAMLocation = vramLocation;
            this.XScroll = xScroll;
            this.YScroll = yScroll;
            this.PlayerX = playerX;
            this.PlayerY = playerY;
            this.CameraX = cameraX;
            this.CameraY = cameraY;
            this.ScrollModY = scrollModY;
            this.ScrollModX = scrollModX;
            this.DoorType1 = doorType1;
            this.DoorType2 = doorType2;

            if (doorType1 != 0)
            {
                int p = (doorType1 & 0x7FFF) >> 1;
                this.DoorXEditor = (byte)(p % 64);
                this.DoorYEditor = (byte)(p >> 6);
            }

            if (doorType2 != 0)
            {
                int p = (doorType2 & 0x7FFF) >> 1;
                this.DoorXEditor = (byte)(p % 64);
                this.DoorYEditor = (byte)(p >> 6);
            }

            int mapX = mapID - ((mapID / 8) * 8);
            int mapY = mapID / 8;

            this.AreaX = (byte)(Math.Abs(playerX - (mapX * 512)) / 16);
            this.AreaY = (byte)(Math.Abs(playerY - (mapY * 512)) / 16);

            this.UniqueID = ROM.uniqueExitID;
            ROM.uniqueExitID += 1;
        }

        /// <summary>
        ///     This function makes a copy of this exit and returns it as a new one.
        /// </summary>
        /// <returns> A new copy of this exit. </returns>
        public ExitOW Copy()
        {
            return new ExitOW(
            this.RoomID,
            this.MapID,
            this.VRAMLocation,
            this.XScroll,
            this.YScroll,
            this.PlayerX,
            this.PlayerY,
            this.CameraX,
            this.CameraY,
            this.ScrollModY,
            this.ScrollModX,
            this.DoorType1,
            this.DoorType2);
        }

        /// <summary>
        ///     Updates certain exit properties based on the given area map ID.
        /// </summary>
        /// <param name="mapID"> The ID of the area map. </param>
        /// <param name="overworld"> The current Overworld. </param>
        public void UpdateMapStuff(byte mapID, Overworld overworld)
        {
            this.MapID = mapID;

            int large = 256;
            int mapid = mapID;

            if (mapID < 128)
            {
                large = overworld.allmaps[mapID].largeMap ? 768 : 256;
                if (overworld.allmaps[mapID].parent != mapID)
                {
                    mapid = overworld.allmaps[mapID].parent;
                }
            }

            int mapX = mapID - ((mapID / 8) * 8);
            int mapY = mapID / 8;

            this.AreaX = (byte)(Math.Abs(this.PlayerX - (mapX * 512)) / 16);
            this.AreaY = (byte)(Math.Abs(this.PlayerY - (mapY * 512)) / 16);

            // If map is large, large = 768, otherwise 256.

            // mapx, mapy = "super map" position on the grid *512.
            if (mapID >= 64)
            {
                mapID -= 64;
            }

            int mapx = (mapID & 7) << 9;
            int mapy = (mapID & 56) << 6;
            if (this.IsAutomatic)
            {
                /*
				Zarby:
				vanilla values of link's house are ->
				ScrollY: 0A9A
				ScrollX: 0832

				PY: 0AE8
				PX: 08B8

				if you subtract these you get -134 and -78.

				Jared_Brain_: further testing by zarby revealed that these values are different for every entrance.
				completly centered is -120 and -80.
				*/

                this.XScroll = (short)(this.PlayerX - 120); // 134.
                this.YScroll = (short)(this.PlayerY - 80); // 78.

                if (this.XScroll < mapx)
                {
                    this.XScroll = (short)mapx;
                }

                if (this.YScroll < mapy)
                {
                    this.YScroll = (short)mapy;
                }

                if (this.XScroll > mapx + large)
                {
                    this.XScroll = (short)(mapx + large);
                }

                if (this.YScroll > mapy + large + 32)
                {
                    this.YScroll = (short)(mapy + large + 32);
                }

                this.CameraX = (short)(this.PlayerX + 0x07);
                this.CameraY = (short)(this.PlayerY + 0x1F);

                if (this.CameraX < mapx + 127)
                {
                    this.CameraX = (short)(mapx + 127);
                }

                if (this.CameraY < mapy + 111)
                {
                    this.CameraY = (short)(mapy + 111);
                }

                if (this.CameraX > mapx + 127 + large)
                {
                    this.CameraX = (short)(mapx + 127 + large);
                }

                if (this.CameraY > mapy + 143 + large)
                {
                    this.CameraY = (short)(mapy + 143 + large);
                }
            }

            short vramXScroll = (short)(this.XScroll - mapx);
            short vramYScroll = (short)(this.YScroll - mapy);

            this.VRAMLocation = (short)(((vramYScroll & 0xFFF0) << 3) | ((vramXScroll & 0xFFF0) >> 3));

            Console.WriteLine("Exit:      " + this.RoomID + " MapId: " + mapid.ToString("X2") + " X: " + this.AreaX + " Y: " + this.AreaY);
        }
    }
}
