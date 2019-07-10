using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
    [Serializable]
    public class RoomPotSaveEditor
    {
        public byte gameX, gameY, id;
        public int x, y;
        public bool bg2 = false;
        public ushort roomMapId;
        public RoomPotSaveEditor(byte id, ushort roomMapId, int x, int y, bool bg2)
        {
            this.id = id;
            this.x = x;
            this.y = y;
            this.bg2 = bg2;
            this.roomMapId = roomMapId;
        }

        public void updateMapStuff(short mapId)
        {
            this.roomMapId = (ushort)mapId;

            if (mapId >= 64)
            {
                mapId -= 64;
            }
            int mx = (mapId - ((mapId / 8) * 8));
            int my = ((mapId / 8));

            gameX = (byte)((x - (mx * 512)) / 16);
            gameY = (byte)((y - (my * 512)) / 16);
        }

        public RoomPotSaveEditor Copy()
        {
            return new RoomPotSaveEditor(this.id, this.roomMapId, this.x, this.y, this.bg2);
        }
    }


}
