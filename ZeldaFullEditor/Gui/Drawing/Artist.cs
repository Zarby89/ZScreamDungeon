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
		public abstract PointeredImage Layer1Canvas { get; }

		public abstract ushort[] Layer2TileMap { get; }
		public abstract PointeredImage Layer2Canvas { get; }

		public abstract PointeredImage SpriteCanvas { get; }

		public abstract Bitmap FinalOutput { get; }

		public byte BackgroundTileset { get; protected set; }
		public byte SpriteTileset { get; protected set; }
		public byte BackgroundPalette { get; protected set; }
		public byte SpritePalette { get; protected set; }

		public GraphicsSet LoadedGraphics {get;set;}

		protected Artist() { }




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

		public unsafe void ClearBgGfx()
		{
			for (int i = 0; i < 512 * 512; i++)
			{
				Layer1Canvas[i] = 0;
				Layer2Canvas[i] = 0;
			}
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

		public abstract void DrawTileForPreview(Tile t, int indexoff);

		public virtual unsafe void DrawSprite(IDrawableSprite spr, OAMDrawInfo[] instructions,
			int xoff = 0, int yoff = 0, int mult = 512, int maxindex = 262144, bool useGlobal = false)
		{
			var graphics = LoadedGraphics;

			// TODO poorly copied and shit
			foreach (OAMDrawInfo ti in instructions)
			{
				int size = ti.RectSideSize;
				byte r = (byte) (ti.HFlip ? 1 : 0);
				int tx = (ti.TileIndex / 16 * 512) + ((ti.TileIndex & 0xF) << 2); // TODO verify
				int indexoff = spr.RealX + ti.XOff + xoff + (mult * (spr.RealY + ti.YOff + yoff));
				byte pal = (byte) (ti.Palette << 3);


				for (int yl = 0, yl2 = tx; yl < size; yl++, yl2 += 64)
				{
					int my = (mult * (ti.VFlip ? size - 1 - yl : yl)) + indexoff; // this is alltilesData additive, so it can go here

					for (int xl = 0, xl2 = yl2; xl < size; xl++, xl2++)
					{
						int mx = ti.HFlip ? size - 1 - xl : xl;
						var pixel = graphics[xl2];
						int index = (mx * 2) + my;

						if (index >= 0 && index <= maxindex)
						{
							if (pixel.BitIsOn(0x0F))
							{
								SpriteCanvas[index + r ^ 1] = (byte) ((pixel & 0x0F) + 112 + pal);
							}
							if (pixel.BitIsOn(0xF0))
							{
								SpriteCanvas[index + r] = (byte) ((pixel >> 4) + 112 + pal);
							}
						}
					}
				}
			}
		}
	}
}
