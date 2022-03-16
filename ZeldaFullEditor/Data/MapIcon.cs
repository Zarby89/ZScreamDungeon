using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data
{
	class MapIcon
	{
		public short x = 0;
		public short y = 0;
		public ushort gfx = 0;
		public MapIcon(short x, short y, ushort gfx)
		{
			this.x = x;
			this.y = y;
			this.gfx = gfx;
		}
	}
}
