using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
	public class TileInfo
	{
		private bool o, h, v;

		/// <summary>
		/// True if high priority
		/// </summary>
		public bool O
		{
			get => o;
			set
			{
				o = value;
				OS = (ushort) (o ? 1 : 0);
			}
		}

		/// <summary>
		/// True if h flip
		/// </summary>
		public bool H
		{
			get => h;
			set
			{
				h = value;
				HS = (ushort) (h ? 1 : 0);
			}
		}

		/// <summary>
		/// True if v flip
		/// </summary>

		public bool V
		{
			get => v;
			set
			{
				v = value;
				VS = (ushort) (v ? 1 : 0);
			}
		}

		/// <summary>
		/// 0x0001 if high priority
		/// </summary>
		public ushort OS { get; private set; }
		/// <summary>
		/// 0x0001 if h flip
		/// </summary>
		public ushort HS { get; private set; }

		/// <summary>
		/// 0x0001 if v flip
		/// </summary>
		public ushort VS { get; private set; }

		public byte palette;
		public ushort id;
		// vhopppcc cccccccc
		public TileInfo(ushort id, byte palette, bool o, bool h, bool v)
		{
			this.id = id;
			this.palette = palette;
			V = v;
			H = h;
			O = o;
		}
		public ushort ToUnsignedShort()
		{
			ushort value = 0;
			// vhopppcc cccccccc
			if (o) { value |= Constants.TilePriorityBit; };
			if (h) { value |= Constants.TileHFlipBit; };
			if (v) { value |= Constants.TileVFlipBit; };
			value |= (ushort) ((palette << 10) & 0x1C00);
			value |= (ushort) (id & Constants.TileNameMask);
			return value;
		}

		public void FlipHFlip()
		{
			H = !H;
		}
	}
}
