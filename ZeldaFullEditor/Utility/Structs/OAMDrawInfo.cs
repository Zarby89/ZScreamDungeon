using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
	/// <summary>
	/// Represents a set of instructions for how to draw a new sprite object.
	/// </summary>
	public readonly struct OAMDrawInfo
	{
		/// <summary>
		/// Index into the object's tile listing to use
		/// </summary>
		public int TileIndex { get; }

		/// <summary>
		/// X-axis offset of the tile relative to the object's coordinates
		/// </summary>
		public int XOff { get; }

		/// <summary>
		/// Y-axis offset of the tile relative to the object's coordinates
		/// </summary>
		public int YOff { get; }

		/// <summary>
		/// Horizontal flip across the Y axis
		/// </summary>
		public bool HFlip { get; }

		/// <summary>
		/// Vertical flip across the X axis
		/// </summary>
		public bool VFlip { get; }

		/// <summary>
		/// Defines the size of the object as either 16x16 or 8x8
		/// </summary>
		public bool IsBig { get; }

		/// <summary>
		/// Object's palette
		/// </summary>
		public byte Palette { get; }

		/// <summary>
		/// The length of each side of the object, based on the size of the object.
		/// </summary>
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
