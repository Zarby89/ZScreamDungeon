using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data.Underworld
{
    // TODO POST MIGRATION - we don't @author files
    // @author: scawful
    public class CollisionRectangle
	{
		public byte Width { get; set; }
		public byte Height { get; set; }

		public ushort Position { get; set; }
		public byte[] TileData { get; set; }

		public CollisionRectangle(byte w, byte h, ushort p, params byte[] tiles)
		{
			Width = w;
			Height = h;
			Position = p;
			TileData = tiles;
		}
	}
}
