using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data
{
    public class PaletteInfo
    {
        public string name;
        public Color[] colors;
        public int width;

        public PaletteInfo(string name, Color[] colors, int width) 
        {
            this.name = name;
            this.colors = colors;
            this.width = width;
        }

    }
}
