using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
    public class EntranceOW
    {
        public short mapPos = 0;
        public short mapId = 0;
        public short entranceId = 0;
        public bool selected = false;
        public EntranceOW(short mapId, short mapPos, byte entranceId)
        {
            this.mapPos = mapPos;
            this.mapId = mapId;
            this.entranceId = entranceId;
           
        }

    }
}
