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

		/// <summary>
		/// True if high priority
		/// </summary>
		public bool Priority
		{
			get => priority;
			set
			{
				priority = value;
				PriorityShort = (ushort) (priority ? 1 : 0);
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
				HFlipShort = (ushort) (hflip ? 1 : 0);
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
				VFlipShort = (ushort) (vflip ? 1 : 0);
			}
		}

		/// <summary>
		/// 0x0001 if high priority
		/// </summary>
		public ushort PriorityShort { get; private set; }
		/// <summary>
		/// 0x0001 if h flip
		/// </summary>
		public ushort HFlipShort { get; private set; }

		/// <summary>
		/// 0x0001 if v flip
		/// </summary>
		public ushort VFlipShort { get; private set; }



		public ushort ID { get; set; } = 0;
		public byte Palette { get; set; }

		public Tile(ushort id, byte palette = 4, bool priority = false, bool hflip = false, bool vflip = false) // Custom tile
		{
			ID = id;
			HFlip = hflip;
			VFlip = vflip;
			Priority = priority;
			Palette = palette;
		}

		public ushort GetModifiedUnsignedShort(bool? hflip = null, bool? vflip = null)
		{
			ushort value = (ushort) (((Palette << 10) & 0x1C00) | (ID & Constants.TileNameMask));

			if (hflip ?? HFlip)
			{
				value |= Constants.TileHFlipBit;
			}
			if (vflip ?? HFlip)
			{
				value |= Constants.TileVFlipBit;
			}

			return value;
		}
		
		public Tile Clone()
		{
			return new Tile(ID, Palette, Priority, HFlip, VFlip);
		}
		
		public Tile CloneModified(bool? hflip = null, bool? vflip = null)
		{
			return new Tile(ID, Palette, Priority, hflip ?? HFlip, vflip ?? VFlip);
		}

		public Tile(byte b1, byte b2) // Tile from game data
		{
			ID = (ushort) (((b2 & 0x01) << 8) | b1);
			VFlip = (b2 & 0x80) == 0x80;
			HFlip = (b2 & 0x40) == 0x40;
			Priority = (b2 & 0x20) == 0x20;
			Palette = (byte) ((b2 >> 2) & 0x07);
		}

		public unsafe void SetTile(int x, int y, byte layer, ZScreamer ZS)
		{
			if (x + (y * 64) < 4096)
			{
				ushort t = ToUnsignedShort();
				if (layer == 0)
				{

					ZS.GFXManager.tilesBg1Buffer[x + (y * 64)] = t;
				}
				else
				{
					ZS.GFXManager.tilesBg2Buffer[x + (y * 64)] = t;
				}
			}
		}

		public ushort ToUnsignedShort()
		{
			ushort value = 0;
			// vhopppcc cccccccc
			if (priority) { value |= Constants.TilePriorityBit; };
			if (hflip) { value |= Constants.TileHFlipBit; };
			if (vflip) { value |= Constants.TileVFlipBit; };
			value |= (ushort) ((this.Palette << 10) & 0x1C00);
			value |= (ushort) (this.ID & Constants.TileNameMask);
			return value;
		}

		public unsafe void Draw(IntPtr bitmapPointer)
		{
			// TODO: Add something here?
		}

		public unsafe void CopyTile(int x, int y, int xx, int yy)
		{
			// TODO: Add something here?
		}
	}
}
