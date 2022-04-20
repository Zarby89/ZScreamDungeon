using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data
{
	/// <summary>
	/// Represents a set of instructions for how to draw a new tile to the background.
	/// </summary>
	public readonly struct DrawInfo
	{
		public int TileIndex { get; }
		public int XOff { get; }
		public int YOff { get; }

		public ushort? TileUnder { get; }

		public bool? HFlip { get; }
		public bool? VFlip { get; }

		/// <summary>
		/// Represents a set of instructions for how to draw a new tile to the background.
		/// </summary>
		/// <param name="i">The index into the object's tile listing to use</param>
		/// <param name="x">The X-axis offset of the tile relative to the object's coordinates</param>
		/// <param name="y">The Y-axis offset of the tile relative to the object's coordinates</param>
		/// <param name="hflip">Forces the horizontal flip of the tile; set to <see langword="null"/> to leave it unchanged.</param>
		/// <param name="vflip">Forces the vertical flip of the tile; set to <see langword="null"/> to leave it unchanged.</param>
		/// <param name="under">The data this tile is forbidden to overwrite.</param>
		public DrawInfo(int i, int x, int y, bool? hflip = null, bool? vflip = null, ushort? under = null)
		{
			TileIndex = i;
			XOff = x;
			YOff = y;
			TileUnder = under;
			HFlip = hflip;
			VFlip = vflip;
		}
	}
	/// <summary>
	/// Represents a set of instructions for how to draw a new sprite object.
	/// </summary>
	public readonly struct OAMDrawInfo
	{
		public ushort TileIndex { get; }
		public int XOff { get; }
		public int YOff { get; }
		public bool HFlip { get; }
		public bool VFlip { get; }
		public bool IsBig { get; }
		public byte Palette { get; }

		public int RectSideSize => IsBig ? 16 : 8;


		public OAMDrawInfo(ushort i, int x, int y, byte pal, bool hflip, bool vflip, bool big)
		{
			TileIndex = i;
			XOff = x;
			YOff = y;
			HFlip = hflip;
			VFlip = vflip;
			IsBig = big;
			Palette = pal;
		}
	}
}
