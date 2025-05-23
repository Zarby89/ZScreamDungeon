﻿using System;

namespace ZeldaFullEditor
{
    public class TransportOW
    {
        public ushort
            vramLocation,
            xScroll,
            yScroll,
            playerX,
            playerY,
            cameraX,
            cameraY,
            MapID,
            whirlpoolPos;

        public byte
            unk1,
            unk2,
            AreaX,
            AreaY;

        public bool isAutomatic = true;

        public int ID = 0;

        public TransportOW(byte mapID, ushort vramLocation, ushort yScroll, ushort xScroll, ushort playerY, ushort playerX, ushort cameraY, ushort cameraX, byte unk1, byte unk2, ushort whirlpoolPos)
        {
            this.MapID = mapID;
            this.vramLocation = vramLocation;
            this.xScroll = xScroll;
            this.yScroll = yScroll;
            this.playerX = playerX.Clamp(0, 4088);
            this.playerY = playerY.Clamp(0, 4088);
            this.cameraX = cameraX;
            this.cameraY = cameraY;
            this.unk1 = unk1;
            this.unk2 = unk2;
            this.whirlpoolPos = whirlpoolPos;

            int mapX = mapID - ((mapID / 8) * 8);
            int mapY = mapID / 8;

            this.AreaX = (byte)(Math.Abs(playerX - (mapX * 512)) / 16);
            this.AreaY = (byte)(Math.Abs(playerY - (mapY * 512)) / 16);

            this.ID = ROM.uniqueTransportID++;
        }

        public void updateMapStuff(byte mapID, Overworld ow)
        {
            var large = 256;

            if (mapID < 128)
            {
                large = ow.AllMaps[mapID].LargeMap ? 768 : 256;
            }

            this.MapID = mapID;
            var mapx = (mapID & 7) << 9;
            var mapy = (mapID & 0x38) << 6;
            this.xScroll = (ushort)(this.playerX - 134);
            this.yScroll = (ushort)(this.playerY - 78);

            if (this.xScroll < mapx)
            {
                this.xScroll = (ushort)mapx;
            }

            if (this.yScroll < mapy)
            {
                this.yScroll = (ushort)mapy;
            }

            if (this.xScroll > mapx + large)
            {
                this.xScroll = (ushort)(mapx + large);
            }

            if (this.yScroll > mapy + large + 30)
            {
                this.yScroll = (ushort)(mapy + large + 30);
            }

            this.cameraX = this.playerX;
            this.cameraY = (ushort)(this.playerY + 19);

            if (this.cameraX < mapx + 127)
            {
                this.cameraX = (ushort)(mapx + 127);
            }
            else if (this.cameraX > mapx + 127 + large)
            {
                this.cameraX = (ushort)(mapx + 127 + large);
            }

            if (this.cameraY < mapy + 111)
            {
                this.cameraY = (ushort)(mapy + 111);
            }
            else if (this.cameraY > mapy + 143 + large)
            {
                this.cameraY = (ushort)(mapy + 143 + large);
            }

            var vramXScroll = (ushort)(this.xScroll - mapx);
            var vramYScroll = (ushort)(this.yScroll - mapy);

            this.vramLocation = (ushort)((vramYScroll & 0xFFF0) << 3 | (vramXScroll & 0xFFF0) >> 3);

            Console.WriteLine("Transport: " + this.ID.ToString("X2") + " MapID: " + mapID.ToString("X2") + " X: " + this.playerX + " Y: " + this.playerY);
        }
    }
}
