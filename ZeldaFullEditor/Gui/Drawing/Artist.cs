using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using ZeldaFullEditor.Data.Underworld;

namespace ZeldaFullEditor
{
	public abstract class Artist
	{
		private const int SheetHeight = 1024;

		public abstract ushort[] Layer1TileMap { get; }
		public abstract IntPtr Layer1Pointer { get; }
		public abstract Bitmap Layer1Bitmap { get; }

		public abstract ushort[] Layer2TileMap { get; }
		public abstract IntPtr Layer2Pointer { get; }
		public abstract Bitmap Layer2Bitmap { get; }

		public IntPtr LoadedGraphicsPointer { get; } = Marshal.AllocHGlobal(128 * SheetHeight);
		public Bitmap LoadedGraphics { get; }

		public abstract IntPtr SpriteCanvasPointer { get; }
		public abstract Bitmap SpriteCanvas { get; }

		public abstract Bitmap FinalOutput { get; }

		public byte BackgroundTileset { get; protected set; }
		public byte SpriteTileset { get; protected set; }
		public byte BackgroundPalette { get; protected set; }
		public byte SpritePalette { get; protected set; }

		protected Artist()
		{
			LoadedGraphics = new Bitmap(128, SheetHeight, 128, PixelFormat.Format8bppIndexed, LoadedGraphicsPointer);
		}




		protected abstract void ReloadPalettes();


		protected static readonly float[][] TranslucencyMatrix = {
			new float[] { 1f, 0, 0, 0, 0 },
			new float[] { 0, 1f, 0, 0, 0 },
			new float[] { 0, 0, 1f, 0, 0 },
			new float[] { 0, 0, 0, 0.5f, 0 },
			new float[] { 0, 0, 0, 0, 1 }
		};

		public abstract void HardRefresh();

		public abstract void RebuildBitMap();

		public abstract void DrawSelfToImage(Graphics g);

		public static unsafe void DrawTileToBuffer(in Tile tile, int x, int y, byte* canvas, byte* tiledata)
		{
			DrawTileToBuffer(in tile, x * 8 + y * 64, canvas, tiledata);
		}

		


		public static unsafe void DrawTileToBuffer(in Tile tile, int offset, byte* canvas, byte* tiledata)
		{
			//int tx = ((tile.ID & ~0xF) << 5) | ((tile.ID & 0xF) << 2);
			int tx = (tile.ID / 16 * 512) | ((tile.ID & 0xF) << 2);
			byte palnibble = (byte) (tile.Palette << 4);
			byte r = tile.HFlipByte;

			for (int yl = 0; yl < 8 * 64; yl += 64)
			{
				// 448 = 64 * 7
				// instead of 64 * (7 - yl)
				// everything with index is additive, so we can add offset in here
				int my = offset + (8 * (tile.VFlip ? 448 - yl : yl));

				for (int xl = 0; xl < 4; xl++)
				{
					int index = my + 2 * (tile.HFlip ? 3 - xl : xl);

					byte pixel = tiledata[tx + yl + xl];

					canvas[index + r ^ 1] = (byte) ((pixel & 0x0F) | palnibble);
					canvas[index + r] = (byte) ((pixel >> 4) | palnibble);
				}
			}
		}


		public abstract void ReloadTileSetGraphics();




		public void DrawBG1()
		{
			DrawBackground(Layer1Pointer, Layer1TileMap);
		}

		public void DrawBG2()
		{
			DrawBackground(Layer2Pointer, Layer2TileMap);
		}


		protected abstract void DrawBackground(IntPtr pointer, ushort[] buffer);
		public abstract void DrawTileForPreview(Tile t, int indexoff);
	}
}
