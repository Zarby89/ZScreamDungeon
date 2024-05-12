using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data
{
    public class AnimationFrame
    {
        public byte sfx1 = 0;
        public byte sfx2 = 0;
        public byte sfx3 = 0;
        public byte wait = 0;
        public bool shake = false;

        public AnimationFrame(byte sfx1, byte sfx2, byte sfx3, byte wait, bool shake)
        {
            this.sfx1 = sfx1;
            this.sfx2 = sfx2;
            this.sfx3 = sfx3;
            this.wait = wait;
            this.shake = shake;
        }
    }
}
