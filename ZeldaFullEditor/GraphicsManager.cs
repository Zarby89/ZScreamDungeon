using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeldaFullEditor.Properties;

// TODO clean up all the magic numbers
namespace ZeldaFullEditor
{
	public class GraphicsManager
	{
		public IntPtr allgfx16Ptr = Marshal.AllocHGlobal((128 * 7136) / 2);
		public Bitmap allgfxBitmap;

		/*
        public IntPtr allgfx16EDITPtr = Marshal.AllocHGlobal((128 * 7136));
        public Bitmap allgfxEDITBitmap;
        */

		public IntPtr currentgfx16Ptr = Marshal.AllocHGlobal((128 * 512) / 2);
		public Bitmap currentgfx16Bitmap;

		public IntPtr currentEditinggfx16Ptr = Marshal.AllocHGlobal((128 * 512) / 2);
		public Bitmap currentEditingfx16Bitmap;

		public IntPtr currentTileScreengfx16Ptr = Marshal.AllocHGlobal((128 * 512) / 2);
		public Bitmap currentTileScreengfx16Bitmap;

		public IntPtr currentOWgfx16Ptr = Marshal.AllocHGlobal((128 * 512) / 2);
		public Bitmap currentOWgfx16Bitmap;

		public IntPtr previewgfx16Ptr = Marshal.AllocHGlobal((128 * 512) / 2);
		public Bitmap previewgfx16Bitmap;

		public IntPtr editort16Ptr = Marshal.AllocHGlobal((128 * 512));
		public Bitmap editort16Bitmap;

		public IntPtr editortilePtr = Marshal.AllocHGlobal((256));
		public Bitmap editortileBitmap;

		public IntPtr mapgfx16Ptr = Marshal.AllocHGlobal(1048576);
		public Bitmap mapgfx16Bitmap;

		public IntPtr fontgfx16Ptr; // = Marshal.AllocHGlobal((256 * 256));
		public Bitmap fontgfxBitmap;

		public IntPtr currentfontgfx16Ptr; // = Marshal.AllocHGlobal(172 * 20000);
		public Bitmap currentfontgfx16Bitmap;

		public IntPtr mapblockset16; // = Marshal.AllocHGlobal(1048576);
		public Bitmap mapblockset16Bitmap;

		public IntPtr scratchblockset16; // = Marshal.AllocHGlobal(1048576);
		public Bitmap scratchblockset16Bitmap;

		public IntPtr overworldMapPointer; // = Marshal.AllocHGlobal(0x4000);
		public Bitmap overworldMapBitmap;

		public IntPtr owactualMapPointer; // = Marshal.AllocHGlobal(0x40000);
		public Bitmap owactualMapBitmap;

		public bool[] isbpp3 = new bool[Constants.NumberOfSheets];

		public byte[] gfxdata;

		public IntPtr roomBgLayoutPtr = Marshal.AllocHGlobal(512 * 512);
		public Bitmap roomBgLayoutBitmap;

		public IntPtr[] previewObjectsPtr;
		public Bitmap[] previewObjectsBitmap;

		public IntPtr[] previewSpritesPtr;
		public Bitmap[] previewSpritesBitmap;

		public IntPtr[] previewChestsPtr;
		public Bitmap[] previewChestsBitmap;

		public ushort[] tilesBg1Buffer = new ushort[Constants.TilesPerUnderworldRoom];
		public IntPtr roomBg1Ptr = Marshal.AllocHGlobal(512 * 512);
		public Bitmap roomBg1Bitmap;

		public ushort[] tilesBg2Buffer = new ushort[Constants.TilesPerUnderworldRoom];
		public IntPtr roomBg2Ptr = Marshal.AllocHGlobal(512 * 512);
		public Bitmap roomBg2Bitmap;

		public ushort[] tilesObjectsBuffer = new ushort[Constants.TilesPerUnderworldRoom];
		public IntPtr roomObjectsPtr = Marshal.AllocHGlobal(512 * 512);
		public Bitmap roomObjectsBitmap;

		public IntPtr editingtile16 = Marshal.AllocHGlobal(16 * 16);
		public Bitmap editingtile16Bitmap;

		public int animated_frame = 0;
		public int animation_timer = 0;

		public bool useOverworldGFX = false;

		public Bitmap spriteFont;
		public Bitmap moveableBlock;
		public Bitmap favStar1;
		public Bitmap favStar2;

		public Color[] palettes = new Color[Constants.TotalPaletteSize];

		public Color[,] editingPalettes; // Dynamic
		public Color[,] loadedPalettes = new Color[1, 1];
		public ushort paletteid;

		public Color[,] loadedSprPalettes = new Color[1, 1];

		private readonly ZScreamer ZS;
		public GraphicsManager(ZScreamer zs)
		{
			ZS = zs;
		}

		public void DrawBG1()
		{
			DrawBackground(1);
		}

		public void DrawBG2()
		{
			DrawBackground(2);
		}

		internal void OnROMLoad()
		{
			CreateAllGfxData();
		}

		public static unsafe void DrawTileToBuffer(in Tile tile, int x, int y, byte* canvas, byte* tiledata)
		{
			DrawTileToBuffer(in tile, x * 8 + y * 64, canvas, tiledata);
		}

		public static unsafe void DrawTileToBuffer(in Tile tile, int offset, byte* canvas, byte* tiledata)
		{
			int tx = (tile.ID / 16 * 512) + ((tile.ID & 0xF) * 4);
			byte palnibble = (byte) (tile.Palette << 4);
			byte r = tile.HFlipByte;

			for (int yl = 0; yl < 8 * 64; yl += 64)
			{
				// 448 = 64 * 7
				// slightly faster than 64 * (7 - yl) where yl is +1 instead of +64 each iteration
				// everything with index is additive, so we can add it in here
				int my = offset + 8 * (tile.VFlip ? 448 - yl : yl);

				for (int xl = 0; xl < 4; xl++)
				{
					int mx = 2 * (tile.HFlip ? 3 - xl : xl);

					byte pixel = tiledata[tx + yl + xl];

					int index = mx + my;
					canvas[index + r ^ 1] = (byte) ((pixel & 0x0F) | palnibble);
					canvas[index + r] = (byte) ((pixel >> 4) | palnibble);
				}
			}
		}

		private unsafe void DrawBackground(int bg)
		{
			byte* ptr;
			ushort[] buffer;
			switch (bg)
			{
				case 1:
					ptr = (byte*) roomBg1Ptr.ToPointer();
					buffer = tilesBg1Buffer;
					break;

				case 2:
					ptr = (byte*) roomBg2Ptr.ToPointer();
					buffer = tilesBg2Buffer;
					break;

				default:
					return;

			}

			var alltilesData = (byte*) currentgfx16Ptr.ToPointer();
			for (int yy = 0; yy < 64 * 64; yy += 64) // For each tile on the tile buffer
			{
				for (int xx = 0; xx < 64; xx++)
				{
					if (buffer[xx + yy] != 0xFFFF) // Prevent draw if tile == 0xFFFF since it 0 indexed
					{
						DrawTileToBuffer(new Tile(buffer[xx + yy]), xx, yy, ptr, alltilesData);
					}
				}
			}
		}

		public void initGfx()
		{
			roomBgLayoutBitmap = new Bitmap(512, 512, 512, PixelFormat.Format8bppIndexed, roomBgLayoutPtr);
			roomBg1Bitmap = new Bitmap(512, 512, 512, PixelFormat.Format8bppIndexed, roomBg1Ptr);
			roomBg2Bitmap = new Bitmap(512, 512, 512, PixelFormat.Format8bppIndexed, roomBg2Ptr);
			allgfxBitmap = new Bitmap(128, 7104, 64, PixelFormat.Format4bppIndexed, allgfx16Ptr);
			//allgfxEDITBitmap = new Bitmap(128, 7104, 128, PixelFormat.Format8bppIndexed, allgfx16EDITPtr);
			currentgfx16Bitmap = new Bitmap(128, 512, 64, PixelFormat.Format4bppIndexed, currentgfx16Ptr);
			currentEditingfx16Bitmap = new Bitmap(128, 512, 64, PixelFormat.Format4bppIndexed, currentEditinggfx16Ptr);
			currentTileScreengfx16Bitmap = new Bitmap(128, 512, 64, PixelFormat.Format4bppIndexed, currentEditinggfx16Ptr);
			roomObjectsBitmap = new Bitmap(512, 512, 512, PixelFormat.Format8bppIndexed, roomObjectsPtr);
			editingtile16Bitmap = new Bitmap(16, 16, 16, PixelFormat.Format8bppIndexed, roomObjectsPtr);
			currentOWgfx16Bitmap = new Bitmap(128, 512, 64, PixelFormat.Format4bppIndexed, currentOWgfx16Ptr);
			previewgfx16Bitmap = new Bitmap(128, 512, 64, PixelFormat.Format4bppIndexed, previewgfx16Ptr);
			mapgfx16Bitmap = new Bitmap(128, 7520, 128, PixelFormat.Format8bppIndexed, mapgfx16Ptr);
			editort16Bitmap = new Bitmap(128, 512, 128, PixelFormat.Format8bppIndexed, editort16Ptr);
			editortileBitmap = new Bitmap(16, 16, 16, PixelFormat.Format8bppIndexed, editortilePtr);
			mapblockset16Bitmap = new Bitmap(128, 8192, 128, PixelFormat.Format8bppIndexed, mapblockset16);
			scratchblockset16Bitmap = new Bitmap(256, 4096, 256, PixelFormat.Format8bppIndexed, scratchblockset16);

			moveableBlock = new Bitmap(Resources.Mblock);
			spriteFont = new Bitmap(Resources.spriteFont);
			favStar1 = new Bitmap(Resources.starn);
			favStar2 = new Bitmap(Resources.starl);

			favStar1.MakeTransparent(Color.Fuchsia);
			favStar2.MakeTransparent(Color.Fuchsia);

			previewObjectsPtr = new IntPtr[0x300];
			previewObjectsBitmap = new Bitmap[0x300];
			previewSpritesPtr = new IntPtr[256];
			previewSpritesBitmap = new Bitmap[256];
			previewChestsPtr = new IntPtr[76];
			previewChestsBitmap = new Bitmap[76];

			for (int i = 0; i < 0x300; i++)
			{
				previewObjectsPtr[i] = Marshal.AllocHGlobal(64 * 64);
				previewObjectsBitmap[i] = new Bitmap(64, 64, 64, PixelFormat.Format8bppIndexed, previewObjectsPtr[i]);
			}
			for (int i = 0; i < 256; i++)
			{
				previewSpritesPtr[i] = Marshal.AllocHGlobal(64 * 64);
				previewSpritesBitmap[i] = new Bitmap(64, 64, 64, PixelFormat.Format8bppIndexed, previewSpritesPtr[i]);
			}
			for (int i = 0; i < 76; i++)
			{
				previewChestsPtr[i] = Marshal.AllocHGlobal(64 * 64);
				previewChestsBitmap[i] = new Bitmap(64, 64, 64, PixelFormat.Format8bppIndexed, previewChestsPtr[i]);
			}
			for (int i = 0; i < 4096; i++)
			{
				tilesBg1Buffer[i] = 0xFFFF;
				tilesBg2Buffer[i] = 0xFFFF;
			}
		}

		public void CreateFontGfxData()
		{
			byte[] data = new byte[0x2000];
			for (int i = 0; i < 0x2000; i++)
			{
				data[i] = ZS.ROM[ZS.Offsets.gfx_font + i];
			}

			byte[] newData = new byte[0x4000]; // NEED TO GET THE APPROPRIATE SIZE FOR THAT
			byte[] mask = new byte[] { 0x80, 0x40, 0x20, 0x10, 0x08, 0x04, 0x02, 0x01 };
			int sheetPosition = 0;

			// 8x8 tile
			for (int s = 0; s < 4; s++) // Per Sheet
			{
				for (int j = 0; j < 4; j++) // Per Tile Line Y
				{
					for (int i = 0; i < 16; i++) // Per Tile Line X
					{
						for (int y = 0; y < 8; y++) // Per Pixel Line
						{
							byte lineBits0 = data[(y * 2) + (i * 16) + (j * 256) + sheetPosition];
							byte lineBits1 = data[(y * 2) + (i * 16) + (j * 256) + 1 + sheetPosition];

							for (int x = 0; x < 4; x++) // Per Pixel X
							{
								byte pixdata = 0;
								byte pixdata2 = 0;

								if ((lineBits0 & mask[(x * 2)]) == mask[(x * 2)]) { pixdata += 1; }
								if ((lineBits1 & mask[(x * 2)]) == mask[(x * 2)]) { pixdata += 2; }

								if ((lineBits0 & mask[(x * 2) + 1]) == mask[(x * 2) + 1]) { pixdata2 += 1; }
								if ((lineBits1 & mask[(x * 2) + 1]) == mask[(x * 2) + 1]) { pixdata2 += 2; }

								newData[(y * 64) + (x) + (i * 4) + (j * 512) + (s * 2048)] = (byte) ((pixdata << 4) | pixdata2);
							}
						}
					}
				}

				sheetPosition += 0x400;
			}

			unsafe
			{
				byte* fontgfx16Data = (byte*) fontgfx16Ptr.ToPointer();
				for (int i = 0; i < 0x4000; i++)
				{
					fontgfx16Data[i] = newData[i];
				}
			}
		}

		// TODO magic numbers
		public byte[] CreateAllGfxDataRaw()
		{
			// 0-112 -> compressed 3bpp bgr -> (decompressed each) 0x600 bytes
			// 113-114 -> compressed 2bpp -> (decompressed each) 0x800 bytes
			// 115-126 -> uncompressed 3bpp sprites -> (each) 0x600 bytes
			// 127-217 -> compressed 3bpp sprites -> (decompressed each) 0x600 bytes
			// 218-222 -> compressed 2bpp -> (decompressed each) 0x800 bytes

			byte[] buffer = new byte[0x54A00];
			int bufferPos = 0;
			byte[] data;
			int compressedSize = 0;

			for (int i = 0; i < Constants.NumberOfSheets; i++)
			{
				isbpp3[i] = (
					(i >= 0 && i <= 112) || // Compressed 3bpp bg
					(i >= 115 && i <= 126) || // Uncompressed 3bpp sprites
					(i >= 127 && i <= 217)    // Compressed 3bpp sprites
					);

				// uncompressed sheets
				if (i >= 115 && i <= 126)
				{
					data = new byte[Constants.Uncompressed3BPPSize];
					int startAddress = GetPCGfxAddress((byte) i);
					for (int j = 0; j < Constants.Uncompressed3BPPSize; j++)
					{
						data[j] = ZS.ROM[j + startAddress];
					}
				}
				else
				{
					data = ZCompressLibrary.Decompress.ALTTPDecompressGraphics(ZS.ROM.DataStream,
						GetPCGfxAddress((byte) i),
						Constants.UncompressedSheetSize,
						ref compressedSize);
				}

				for (int j = 0; j < data.Length; j++)
				{
					buffer[j + bufferPos] = data[j];
				}

				bufferPos += data.Length;
			}

			return buffer;
		}

		// TODO this can probably be heavily optimized
		private void CreateAllGfxData()
		{
			byte[] data = CreateAllGfxDataRaw();
			byte[] newData = new byte[0x6F800]; // NEED TO GET THE APPROPRIATE SIZE FOR THAT
			byte[] mask = new byte[] { 0x80, 0x40, 0x20, 0x10, 0x08, 0x04, 0x02, 0x01 };
			int sheetPosition = 0;

			// 8x8 tile
			for (int s = 0; s < Constants.NumberOfSheets; s++) // Per Sheet
			{
				for (int j = 0; j < 4; j++) // Per Tile Line Y
				{
					for (int i = 0; i < 16; i++) // Per Tile Line X
					{
						for (int y = 0; y < 8; y++) // Per Pixel Line
						{
							if (isbpp3[s])
							{
								byte lineBits0 = data[(y * 2) + (i * 24) + (j * 384) + sheetPosition];
								byte lineBits1 = data[(y * 2) + (i * 24) + (j * 384) + 1 + sheetPosition];
								byte lineBits2 = data[(y) + (i * 24) + (j * 384) + 16 + sheetPosition];

								for (int x = 0; x < 4; x++) // Per Pixel X
								{
									byte pixdata = 0;
									byte pixdata2 = 0;

									if ((lineBits0 & mask[(x * 2)]) == mask[(x * 2)]) { pixdata += 1; }
									if ((lineBits1 & mask[(x * 2)]) == mask[(x * 2)]) { pixdata += 2; }
									if ((lineBits2 & mask[(x * 2)]) == mask[(x * 2)]) { pixdata += 4; }

									if ((lineBits0 & mask[(x * 2) + 1]) == mask[(x * 2) + 1]) { pixdata2 += 1; }
									if ((lineBits1 & mask[(x * 2) + 1]) == mask[(x * 2) + 1]) { pixdata2 += 2; }
									if ((lineBits2 & mask[(x * 2) + 1]) == mask[(x * 2) + 1]) { pixdata2 += 4; }

									newData[(y * 64) + (x) + (i * 4) + (j * 512) + (s * 2048)] = (byte) ((pixdata << 4) | pixdata2);
								}
							}
							else
							{
								byte lineBits0 = data[(y * 2) + (i * 16) + (j * 256) + sheetPosition];
								byte lineBits1 = data[(y * 2) + (i * 16) + (j * 256) + 1 + sheetPosition];

								for (int x = 0; x < 4; x++) // Per Pixel X
								{
									byte pixdata = 0;
									byte pixdata2 = 0;

									if ((lineBits0 & mask[(x * 2)]) == mask[(x * 2)]) { pixdata += 1; }
									if ((lineBits1 & mask[(x * 2)]) == mask[(x * 2)]) { pixdata += 2; }

									if ((lineBits0 & mask[(x * 2) + 1]) == mask[(x * 2) + 1]) { pixdata2 += 1; }
									if ((lineBits1 & mask[(x * 2) + 1]) == mask[(x * 2) + 1]) { pixdata2 += 2; }

									newData[(y * 64) + (x) + (i * 4) + (j * 512) + (s * 2048)] = (byte) ((pixdata << 4) | pixdata2);
								}
							}
						}
					}
				}

				if (isbpp3[s])
				{
					sheetPosition += Constants.Uncompressed3BPPSize;
				}
				else
				{
					sheetPosition += Constants.UncompressedSheetSize;
				}
			}

			unsafe
			{
				byte* allgfx16Data = (byte*) allgfx16Ptr.ToPointer();
				//byte* allgfx16Data2 = (byte*)allgfx16EDITPtr.ToPointer();

				for (int i = 0; i < 0x6F800; i++)
				{
					allgfx16Data[i] = newData[i];

					//allgfx16Data2[(i*2)+1] = (byte)(newData[i] & 0x0F);
					//allgfx16Data2[(i*2)] = (byte)((newData[i] & 0xF0) >> 4);
				}
			}
		}

		public int GetPCGfxAddress(byte id)
		{
			int gfxPointer1 = SNESFunctions.SNEStoPC(ZS.ROM.Read16(ZS.Offsets.gfx_1_pointer));
			int gfxPointer2 = SNESFunctions.SNEStoPC(ZS.ROM.Read16(ZS.Offsets.gfx_2_pointer));
			int gfxPointer3 = SNESFunctions.SNEStoPC(ZS.ROM.Read16(ZS.Offsets.gfx_3_pointer));

			byte gfxGamePointer1 = ZS.ROM[gfxPointer1 + id];
			byte gfxGamePointer2 = ZS.ROM[gfxPointer2 + id];
			byte gfxGamePointer3 = ZS.ROM[gfxPointer3 + id];

			return Utils.AddressFromBytes(gfxGamePointer1, gfxGamePointer2, gfxGamePointer3).SNEStoPC();
		}

		// Todo: Change palette system entirely
		// TODO magic numbers
		// Palettes must be loaded on rom load then being able to be modified - Done
		// without affecting the rom directly - Done
		// Change the way the room load the palettes, here change the code to load from the Palettes class
		public Color[,] LoadDungeonPalette(byte id)
		{
			Color[,] palettes = new Color[16, 8];

			// id = dungeon palette id
			byte dungeon_palette_ptr = ZS.GFXGroups.paletteGfx[id][0]; //id of the 1st group of 4
			paletteid = ZS.ROM.Read16(0xDEC4B + dungeon_palette_ptr);
			int pId = paletteid / 180;

			int i = 0;
			/*
            for (int y = 0; y < 2; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    palettes[x, y] = Color.Black;
                }
            }
            */

			int j = 0;
			for (int y = 0; y < 2; y++)
			{
				for (int x = 0; x < 16; x++)
				{
					// Hud Palette load from hud array instead of rom
					//getColor((short)((ROM.DATA[0xDD660 + 1 + j] << 8) + (ROM.DATA[0xDD660 + j])));
					palettes[x, y] = ZS.PaletteManager.HUD[0][j++];
				}
			}

			for (int y = 2; y < 8; y++)
			{
				for (int x = 0; x < 16; x++)
				{
					if (x == 0)
					{
						palettes[x, y] = Color.Black;
						continue;
					}

					// Dungeon Palette
					//palettes[x, y] = getColor((short)((ROM.DATA[ZS.Offsets.dungeons_palettes + palette_pos + 1 + i] << 8) + ROM.DATA[ZS.Offsets.dungeons_palettes + palette_pos + i]));
					palettes[x, y] = ZS.PaletteManager.UnderworldMain[pId][i];
					if (x == 8)
					{
						palettes[x, y] = Color.Black;
					}

					i++;
				}
			}

			return palettes;
		}

		// TODO clean up magic numbers
		public Color[,] LoadSpritesPalette(byte id)
		{
			Color[,] palettes = new Color[16, 8];
			byte sprite1_palette_ptr = ZS.ROM[ZS.Offsets.dungeons_palettes_groups + (id * 4) + 1];
			byte sprite2_palette_ptr = (byte) (ZS.ROM[ZS.Offsets.dungeons_palettes_groups + (id * 4) + 2] * 2);
			byte sprite3_palette_ptr = (byte) (ZS.ROM[ZS.Offsets.dungeons_palettes_groups + (id * 4) + 3] * 2);

			ushort palette_pos1 = ZS.ROM[0xDEBC6 + sprite1_palette_ptr]; // /14
			ushort palette_pos2 = ZS.ROM.Read16(0xDEBD6 + sprite2_palette_ptr); // /14
			ushort palette_pos3 = ZS.ROM.Read16(0xDEBD6 + sprite3_palette_ptr); // /14
			//ushort palette_pos4 = ROM.DATA[0xDEBC6 + 10]; // 140?

			// ID = dungeon palette id
			palettes[9, 5] = ZS.PaletteManager.PlayerSword[0][0];
			palettes[10, 5] = ZS.PaletteManager.PlayerSword[0][1];
			palettes[11, 5] = ZS.PaletteManager.PlayerSword[0][2];
			palettes[12, 5] = ZS.PaletteManager.PlayerShield[0][0];
			palettes[13, 5] = ZS.PaletteManager.PlayerShield[0][1];
			palettes[14, 5] = ZS.PaletteManager.PlayerShield[0][2];
			palettes[15, 5] = ZS.PaletteManager.PlayerShield[0][3];

			for (int x = 0; x < 15; x++)
			{
				if (x < 7)
				{
					palettes[x + 1, 0] = ZS.PaletteManager.SpriteAux1[palette_pos1 / 14][x];
					palettes[x + 1, 5] = ZS.PaletteManager.SpriteAux3[palette_pos2 / 14][x];
					palettes[x + 1, 6] = ZS.PaletteManager.SpriteAux3[palette_pos3 / 14][x];
				}
				else
				{
					palettes[x + 1, 0] = loadedPalettes[x - 7, 2];
					if (x < 14)
					{
						palettes[x + 2, 6] = ZS.PaletteManager.SpriteAux2[10][x - 7];
					}
				}

				// SP-1
				//getColor((short)((ROM.DATA[0xDD218 + i + 1] << 8) + ROM.DATA[0xDD218 + i]));
				palettes[x + 1, 1] = ZS.PaletteManager.SpriteGlobal[0][x];
				// SP-2
				palettes[x + 1, 2] = ZS.PaletteManager.SpriteGlobal[0][x + 15];
				// SP-3
				palettes[x + 1, 3] = ZS.PaletteManager.SpriteGlobal[0][x + 30];
				// SP-4
				palettes[x + 1, 4] = ZS.PaletteManager.SpriteGlobal[0][x + 45];

				//SP-6
				/*
                palettes[x + 1, 12] = getColor((short)((ROM.DATA[0xDD4E0 AUX3 + palette_pos3 + i + 1] << 8) + ROM.DATA[0xDD4E0 + palette_pos3 + i]));
                palettes[x + 1, 13] = getColor((short)((ROM.DATA[0xDD446 AUX2 + palette_pos4 + i + 1] << 8) + ROM.DATA[0xDD446 + palette_pos4 + i])); //liftable objects
                */

				// IF GHOST PALETTE?
				// SP-7 ???? WTF IT LINK PALETTE
				//palettes[x + 1, 14] = getColor((short)((ROM.DATA[0xDD39E + palette_pos1 + i + 1] << 8) + ROM.DATA[0xDD39E + palette_pos1 + i]));
			}

			return palettes;
		}

		public byte[] pc4bppto3bppsnes(byte[] sheetData)
		{
			// [r0, bp1], [r0, bp2], [r1, bp1], [r1, bp2], [r2, bp1], [r2, bp2], [r3, bp1], [r3, bp2]
			// [r4, bp1], [r4, bp2], [r5, bp1], [r5, bp2], [r6, bp1], [r6, bp2], [r7, bp1], [r7, bp2]
			// [r0, bp3], [r1, bp3], [r2, bp3], [r3, bp3], [r4, bp3], [r5, bp3], [r6, bp3], [r7, bp3]

			// 4 bytes = 1 line of a 8x8 tile
			int dpos;

			byte[] blockdata = new byte[24 * 64];
			byte l1d, l2d, l3d;
			int bpos = 0;

			for (int b = 0; b < 64; b++)
			{
				int y = b / 16 * 512;
				int x = (b % 16) * 4;
				// Do that x8 for each blocks

				dpos = 0;
				for (int l = 0; l < 8 * 64; l += 64)
				{
					l1d = 0;
					l2d = 0;
					l3d = 0;

					int lll = l + y + x;

					for (int i = 0; i < 4; i++) // 1 line
					{
						byte d = sheetData[i + lll];
						// 1111 0000 | 3333 2222 | 5555 4444 | 7777 6666  (4 bytes (i))
						l1d += (byte) ((d >> 4) & 0x01); // Load bpp1 of line1 pixel2 + i (pixel 4, 6, 7)
						l1d = (byte) (l1d << 1); // Put it in linebpp1data and shift it by 1
						l1d += (byte) (d & 0x01); // Load bpp1 of line1 pixel1 + i (pixel 3, 5, 7)

						l2d += (byte) ((d >> 5) & 0x01); // Load bpp2 of line1 pixel2 + i (pixel 4, 6, 7)
						l2d = (byte) (l2d << 1); // Put it in linebpp2data and shift it by 1
						l2d += (byte) ((d >> 1) & 0x01); // Load bpp2 of line1 pixel1 + i (pixel 3, 5, 7)

						l3d += (byte) ((d >> 6) & 0x01); // Load bpp3 of line1 pixel2 + i (pixel 4, 6, 7)
						l3d = (byte) (l3d << 1); // Put it in linebpp3data and shift it by 1
						l3d += (byte) ((d >> 2) & 0x01); // Load bpp3 of line1 pixel1 + i (pixel 3, 5, 7)


						if (i != 3) // Shift all the linebpp data for the next bit except for the last one
						{
							l1d = (byte) (l1d << 1);
							l2d = (byte) (l2d << 1);
							l3d = (byte) (l3d << 1);
						}
					}

					blockdata[bpos + (dpos * 2)] = l1d;
					blockdata[bpos + 1 + (dpos * 2)] = l2d;
					blockdata[bpos + 16 + dpos] = l3d;
					dpos++;
				}

				bpos += 24;
			}

			// l1d = byte0
			// l2d = byte1
			// l3d = byte16

			return blockdata;
		}

		public byte[] pc4bppto2bppsnes(byte[] sheetData)
		{
			// [r0, bp1], [r0, bp2], [r1, bp1], [r1, bp2], [r2, bp1], [r2, bp2], [r3, bp1], [r3, bp2]
			// [r4, bp1], [r4, bp2], [r5, bp1], [r5, bp2], [r6, bp1], [r6, bp2], [r7, bp1], [r7, bp2]

			// 4 bytes = 1 line of a 8x8 tile
			int dpos; // Destination pos

			byte[] blockdata = new byte[16 * 128];
			byte l1d, l2d;
			int bpos = 0;

			for (int b = 0; b < 128; b++)
			{
				int y = b / 16 * 512;
				int x = (b % 16) * 4;
				// Do that x8 for each blocks

				dpos = 0;
				for (int l = 0; l < 8 * 64; l += 64)
				{
					l1d = 0;
					l2d = 0;

					int lll = l + y + x;

					for (int i = 0; i < 4; i++) // 1 line
					{
						byte d = sheetData[i + lll];
						// 1111 0000 | 3333 2222 | 5555 4444 | 7777 6666  (4 bytes (i))
						l1d += (byte) ((d >> 4) & 0x01); // Load bpp1 of line1 pixel2 + i (pixel 4, 6, 7)
						l1d = (byte) (l1d << 1); // Put it in linebpp1data and shift it by 1
						l1d += (byte) (d & 0x01); // Load bpp1 of line1 pixel1 + i (pixel 3, 5, 7)

						l2d += (byte) ((d >> 5) & 0x01);// Load bpp2 of line1 pixel2 + i (pixel 4, 6, 7)
						l2d = (byte) (l2d << 1); // Put it in linebpp2data and shift it by 1
						l2d += (byte) ((d >> 1) & 0x01);// Load bpp2 of line1 pixel1 + i (pixel 3, 5, 7)

						if (i != 3) // Shift all the linebpp data for the next bit except for the last one
						{
							l1d = (byte) (l1d << 1);
							l2d = (byte) (l2d << 1);
						}
					}

					blockdata[bpos + dpos] = l1d;
					blockdata[bpos + dpos + 1] = l2d;
					dpos += 2;
				}

				bpos += 16;
			}

			return blockdata;
		}

		// TODO magic numbers
		public void loadOverworldMap()
		{
			overworldMapBitmap = new Bitmap(128, 128, 128, PixelFormat.Format8bppIndexed, overworldMapPointer);
			owactualMapBitmap = new Bitmap(512, 512, 512, PixelFormat.Format8bppIndexed, owactualMapPointer);

			// Mode 7
			unsafe
			{
				byte* ptr = (byte*) overworldMapPointer.ToPointer();

				int pos = 0;
				for (int sy = 0; sy < 16 * 1024; sy += 1024)
				{
					for (int sx = 0; sx < 16 * 8; sx += 8)
					{
						for (int y = 0; y < 8 * 128; y += 128)
						{
							for (int x = 0; x < 8; x++)
							{
								ptr[x + sx + y + sy] = ZS.ROM[0x0C4000 + pos];
								pos++;
							}
						}
					}
				}
			}

			ColorPalette cp = overworldMapBitmap.Palette;
			for (int i = 0; i < 256; i += 2)
			{
				// 55B27 = US LW
				// 55C27 = US DW
				cp.Entries[i / 2] = ZS.ROM.Read16(0x55B27 + i).ToColor();

				int k = 0;
				int j = 0;
				for (int y = 10; y < 14; y++)
				{
					for (int x = 0; x < 15; x++)
					{
						cp.Entries[145 + k] = ZS.PaletteManager.SpriteGlobal[0][j++];
						k++;
					}
					k++;
				}
			}

			overworldMapBitmap.Palette = cp;
			owactualMapBitmap.Palette = cp;
		}

		public void drawText(Graphics g, int x, int y, string text, ImageAttributes ai = null, bool x2 = false)
		{
			text = text.ToUpper();
			int cpos = 0;
			for (int i = 0; i < text.Length; i++)
			{
				byte arrayPos = (byte) (text[i] - 32);
				if ((byte) text[i] == 10)
				{
					y += 10;
					cpos = 0;
					continue;
				}

				if (ai == null)
				{
					if (x2)
					{
						g.DrawImage(spriteFont, new Rectangle(x + cpos, y, 16, 16), arrayPos * 8, 0, 8, 8, GraphicsUnit.Pixel);
					}
					else
					{
						g.DrawImage(spriteFont, new Rectangle(x + cpos, y, 8, 8), arrayPos * 8, 0, 8, 8, GraphicsUnit.Pixel);
					}
				}
				else
				{
					g.DrawImage(spriteFont, new Rectangle(x + cpos, y, 8, 8), arrayPos * 8, 0, 8, 8, GraphicsUnit.Pixel, ai);
				}

				if (arrayPos > Constants.FontSpacings.Length - 1)
				{
					cpos += 8;
					continue;
				}

				if (x2)
				{
					cpos += Constants.FontSpacings[arrayPos] * 2;
				}
				else
				{
					cpos += Constants.FontSpacings[arrayPos];
				}
			}
		}
	}
}
