using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
    public class ExitOW
    {

        public short roomId = 0;
        public byte mapId = 0;
        public short vramLocation = 0;
        public short xScroll;
        public short yScroll;
        public short playerX;
        public short playerY;
        public short cameraX;
        public short cameraY;
        public byte unk1;
        public byte unk2;
        public byte doorType1;
        public byte doorType2;
        public bool selected = false;
        public ExitOW(short roomId,byte mapId,short vramLocation, short yScroll,short xScroll,short playerY, short playerX,short cameraY, short cameraX, byte unk1,byte unk2,byte doorType1,byte doorType2)
        {
            this.roomId = roomId;
            this.mapId = mapId;
            this.vramLocation = vramLocation;
            this.xScroll = xScroll;
            this.yScroll = yScroll;
            this.playerX = playerX;
            this.playerY = playerY;
            this.cameraX = cameraX;
            this.cameraY = cameraY;
            this.unk1 = unk1;
            this.unk2 = unk2;
            this.doorType1 = doorType1;
            this.doorType2 = doorType2;
        }


    }
}
