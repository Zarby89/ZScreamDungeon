using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data
{
    public class PaletteGroupInfo
    {
        public string name;
        public PaletteInfo[] palettes;

        public PaletteGroupInfo(string name, PaletteInfo[] palettes) 
        {
            this.name = name;
            this.palettes = palettes;
        }

    }
}
