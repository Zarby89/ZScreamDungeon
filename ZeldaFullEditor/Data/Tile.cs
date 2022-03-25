using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ZeldaFullEditor
{
	// Tiles Information
	// iiiiiiii vhoopppc
	// i = tile index
	// v - vertical flip
	// h - horizontal flip
	// p - palette
	// o - on top?
	// c - the 9th(and most significant) bit of the character number for this sprite.

	[Serializable]
	public class Tile
	{

		private bool priority, hflip, vflip;
		private ushort ps, hs, vs;

		/// <summary>
		/// True if high priority
		/// </summary>
		public bool Priority
		{
			get => priority;
			set
			{
				priority = value;
				ps = (ushort) (priority ? 1 : 0);
			}
		}

		/// <summary>
		/// True if h flip
		/// </summary>
		public bool HFlip
		{
			get => hflip;
			set
			{
				hflip = value;
				hs = (ushort) (hflip ? 1 : 0);
			}
		}

		/// <summary>
		/// True if v flip
		/// </summary>
		public bool VFlip
		{
			get => vflip;
			set
			{
				vflip = value;
				vs = (ushort) (vflip ? 1 : 0);
			}
		}

		/// <summary>
		/// 0x0001 if high priority
		/// </summary>
		public ushort PriorityShort => ps;
		/// <summary>
		/// 0x0001 if h flip
		/// </summary>
		public ushort HFlipShort => hs;

		/// <summary>
		/// 0x0001 if v flip
		/// </summary>
		public ushort VFlipShort => vs;



		public ushort id = 0;
		public byte palette = 4;

		public Tile(ushort id, byte palette = 4, bool priority = false, bool hflip = false, bool vflip = false) // Custom tile
		{
			this.id = id;
			HFlip = hflip;
			VFlip = vflip;
			Priority = priority;
			this.palette = palette;
		}

		public TileInfo GetTileInfo()
		{
			return new TileInfo(id, palette, priority, hflip, vflip);
		}

		public Tile(byte b1, byte b2) // Tile from game data
		{
			this.id = (ushort) (((b2 & 0x01) << 8) | b1);
			VFlip = (b2 & 0x80) == 0x80;
			HFlip = (b2 & 0x40) == 0x40;
			Priority = (b2 & 0x20) == 0x20;
			this.palette = (byte) ((b2 >> 2) & 0x07);
		}

		public unsafe void SetTile(int xx, int yy, byte layer, ZScreamer ZS)
		{
			if (xx + (yy * 64) < 4096)
			{
				ushort t = GetGFXTileInfo(GetTileInfo());
				if (layer == 0)
				{

					ZS.GFXManager.tilesBg1Buffer[xx + (yy * 64)] = t;
				}
				else
				{
					ZS.GFXManager.tilesBg2Buffer[xx + (yy * 64)] = t;
				}
			}
		}

		public ushort getshortileinfo()
		{
			ushort value = 0;
			// vhopppcc cccccccc
			if (priority) { value |= Constants.TilePriorityBit; };
			if (hflip) { value |= Constants.TileHFlipBit; };
			if (vflip) { value |= Constants.TileVFlipBit; };
			value |= (ushort) ((this.palette << 10) & 0x1C00);
			value |= (ushort) (this.id & Constants.TileNameMask);
			return value;
		}

		public static TileInfo GetTheGFXInfo(ushort tile)
		{
			// vhopppcc cccccccc
			ushort tid = (ushort) (tile & Constants.TileNameMask);
			byte p = (byte) ((tile >> 10) & 0x07);

			bool o = (tile & Constants.TilePriorityBit) == Constants.TilePriorityBit;
			bool h = (tile & Constants.TileHFlipBit) == Constants.TileHFlipBit;
			bool v = (tile & Constants.TileVFlipBit) == Constants.TileVFlipBit;

			return new TileInfo(tid, p, o, h, v);
		}

		public unsafe void Draw(IntPtr bitmapPointer)
		{
			// TODO: Add something here?
		}

		public unsafe void CopyTile(int x, int y, int xx, int yy)
		{
			// TODO: Add something here?
		}

		public static ushort GetGFXTileInfo(TileInfo t)
		{
			ushort tinfo = (ushort) (t.id | (t.palette << 10));

			if (t.O)
			{
				tinfo |= Constants.TilePriorityBit;
			}
			if (t.H)
			{
				tinfo |= Constants.TileHFlipBit;
			}
			if (t.V)
			{
				tinfo |= Constants.TileVFlipBit;
			}

			return tinfo;
		}
	}
}
