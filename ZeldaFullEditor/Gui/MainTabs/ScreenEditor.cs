using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.IO;
using ZeldaFullEditor.Properties;
using System.Globalization;
using System.Diagnostics;
using ZeldaFullEditor.Data;

namespace ZeldaFullEditor.Gui.MainTabs
{
	public partial class ScreenEditor : UserControl
	{

		public const ushort BossRoomNull = 0x000F;
		private const int SomeThingZarbyNeedsToName = 492;
		Point3D[] triforceVertices = new Point3D[6];
		Point3D[] crystalVertices = new Point3D[6];
		Point3D selectedVertex = null;
		OAMTile[] oamData = new OAMTile[10];
		OAMTile selectedOamTile = null;
		OAMTile lastSelectedOamTile = null;
		byte[] mapdata = new byte[64 * 64];
		byte[] dwmapdata = new byte[64 * 64];
		int swordX = 0;

		public IntPtr dungmaptiles8Ptr = Marshal.AllocHGlobal(0x8000);
		public Bitmap dungmaptiles8Bitmap;

		public IntPtr dungmaptiles16Ptr = Marshal.AllocHGlobal(0x20000);
		public Bitmap dungmaptiles16Bitmap;

		public IntPtr tiles8Ptr = Marshal.AllocHGlobal(0x20000);
		public Bitmap tiles8Bitmap;

		public ushort[] tilesBG1Buffer = new ushort[Constants.TilesPerTilemap];
		public IntPtr tilesBG1Ptr = Marshal.AllocHGlobal(0x80000);
		public Bitmap tilesBG1Bitmap;

		public ushort[] tilesBG2Buffer = new ushort[Constants.TilesPerTilemap];
		public IntPtr tilesBG2Ptr = Marshal.AllocHGlobal(0x80000);
		public Bitmap tilesBG2Bitmap;

		public IntPtr oamBGPtr = Marshal.AllocHGlobal(0x80000);
		public Bitmap oamBGBitmap;

		byte palSelected = 0;
		ushort selectedTile = 0;

		bool mDown = false;
		byte lastX = 0;
		byte lastY = 0;
		int xIn = 0;
		bool swordSelected = false;
		private bool darkWorld = false;

		List<MapIcon>[] allMapIcons = new List<MapIcon>[10];

		int[] addresses = new int[] { 0x53de4, 0x53e2c, 0x53e08, 0x53e50, 0x53e74, 0x53e98, 0x53ebc };
		int[] addressesgfx = new int[] { 0x53ee0, 0x53f04, 0x53ef2, 0x53f16, 0x53f28, 0x53f3a, 0x53f4c };

		byte selectedMapTile = 0;

		byte[][] currentFloorRooms = new byte[1][];
		byte[][] currentFloorGfx = new byte[1][];
		int totalFloors = 0;
		byte currentFloor = 0;
		byte nbrBasement = 0;
		byte nbrFloor = 0;
		ushort bossRoom = BossRoomNull;

		DungeonMap[] dungmaps = new DungeonMap[14];

		Bitmap floorSelector;

		int dungmapSelectedTile = 0;
		int dungmapSelected = 0;
		bool currentDungeonChanged = false;
		bool editedFromEditor = false;

		private readonly byte[] copiedDataRooms = new byte[Constants.RoomsPerFloorOnMap];
		private readonly byte[] copiedDataGfx = new byte[Constants.RoomsPerFloorOnMap];

		MapIcon selectedMapIcon = null;
		bool mouseDown = false;
		int mxClick = 0;
		int myClick = 0;
		int mxDist = 0;
		int myDist = 0;

		bool mdown = false;

		private readonly Color[] currentPalette = new Color[Constants.TotalPaletteSize];

		public ScreenEditor()
		{
			InitializeComponent();
			overworldCombobox.SelectedIndex = 0;
		}

		public void Init()
		{
			// Triforce
			for (int i = 0; i < 6; i++)
			{
				triforceVertices[i] = new Point3D(
					(sbyte) ZScreamer.ActiveROM[ZScreamer.ActiveOffsets.triforceVertices + 0 + (i * 3)],
					(sbyte) ZScreamer.ActiveROM[ZScreamer.ActiveOffsets.triforceVertices + 1 + (i * 3)],
					(sbyte) ZScreamer.ActiveROM[ZScreamer.ActiveOffsets.triforceVertices + 2 + (i * 3)]
				);

				crystalVertices[i] = new Point3D(
					(sbyte) ZScreamer.ActiveROM[ZScreamer.ActiveOffsets.crystalVertices + 0 + (i * 3)],
					(sbyte) ZScreamer.ActiveROM[ZScreamer.ActiveOffsets.crystalVertices + 1 + (i * 3)],
					(sbyte) ZScreamer.ActiveROM[ZScreamer.ActiveOffsets.crystalVertices + 2 + (i * 3)]
				);
			}

			tiles8Bitmap = new Bitmap(128, 512, 128, PixelFormat.Format8bppIndexed, tiles8Ptr);
			dungmaptiles8Bitmap = new Bitmap(128, 128, 128, PixelFormat.Format8bppIndexed, dungmaptiles8Ptr);
			dungmaptiles16Bitmap = new Bitmap(256, 192, 256, PixelFormat.Format8bppIndexed, dungmaptiles16Ptr);
			tilesBG1Bitmap = new Bitmap(256, 256, 256, PixelFormat.Format8bppIndexed, tilesBG1Ptr);
			tilesBG2Bitmap = new Bitmap(256, 256, 256, PixelFormat.Format8bppIndexed, tilesBG2Ptr);
			oamBGBitmap = new Bitmap(256, 256, 256, PixelFormat.Format8bppIndexed, oamBGPtr);
			floorSelector = new Bitmap(Resources.floorselector); ;
			Buildtileset();
			AssembleMapTiles();

			for (int i = 0; i < 1024; i++)
			{
				tilesBG1Buffer[i] = SomeThingZarbyNeedsToName;
				tilesBG2Buffer[i] = SomeThingZarbyNeedsToName;
			}

			SetColorsPalette
			(
				ZScreamer.ActivePaletteManager.OverworldMain[5], ZScreamer.ActivePaletteManager.OverworldAnimated[0],
				ZScreamer.ActivePaletteManager.OverworldAux[3], ZScreamer.ActivePaletteManager.OverworldAux[3],
				ZScreamer.ActivePaletteManager.HUD[0],
				Color.FromArgb(0, 0, 0, 0),
				ZScreamer.ActivePaletteManager.SpriteAux1[1],
				ZScreamer.ActivePaletteManager.SpriteAux1[1]
			);

			int p = Constants.IDKZarby;
			int p2 = Constants.IDKZarby + 0x0400;
			int p3 = Constants.IDKZarby + 0x0800;
			int p4 = Constants.IDKZarby + 0x0C00;
			int p5 = Constants.IDKZarby + 0x1000;
			bool rSide = false;
			int cSide = 0;
			int count = 0;

			while (count < 64 * 64)
			{
				if (count < 0x800)
				{
					if (!rSide)
					{
						mapdata[count] = ZScreamer.ActiveROM[p];
						dwmapdata[count] = ZScreamer.ActiveROM[p];
						p++;

						if (cSide >= 31)
						{
							cSide = 0;
							rSide = true;
							count++;
							continue;
						}
					}
					else
					{
						mapdata[count] = ZScreamer.ActiveROM[p2];
						dwmapdata[count] = ZScreamer.ActiveROM[p2];
						p2++;
						if (cSide >= 31)
						{
							cSide = 0;
							rSide = false;
							count++;
							continue;
						}
					}
				}
				else
				{
					if (!rSide)
					{
						mapdata[count] = ZScreamer.ActiveROM[p3];
						dwmapdata[count] = ZScreamer.ActiveROM[p3];
						p3++;
						if (cSide >= 31)
						{
							cSide = 0;
							rSide = true;
							count++;
							continue;
						}
					}
					else
					{
						mapdata[count] = ZScreamer.ActiveROM[p4];
						dwmapdata[count] = ZScreamer.ActiveROM[p4];
						p4++;
						if (cSide >= 31)
						{
							cSide = 0;
							rSide = false;
							count++;
							continue;
						}
					}
				}

				cSide++;
				count++;
			}

			count = 0;
			int line = 0;
			while (true)
			{
				dwmapdata[1040 + count + (line * 64)] = ZScreamer.ActiveROM[p5++];
				count++;
				if (count >= 32)
				{
					count = 0;
					line++;
					if (line >= 32)
					{
						break;
					}
				}
			}

			// Palettes : 
			// Main5, Aux

			// Load Title Screen Data
			// Format : 
			// 4 Bytes Header followed by "short tiles values"
			// byte 0 and 1 = Dest Address? Big Endian
			// byte 2 and 3 = Tile Count in Big Endian if 8XXX this is the last index
			// 11 0B    00 19

			// TODO magic numbers
			uppersprCheckbox.Checked = (ZScreamer.ActiveROM[0x67E92] & 0x01) == 0;

			int xLowest = 256;
			for (int i = 0; i < 10; i++)
			{
				oamData[i] = new OAMTile(ZScreamer.ActiveROM[0x67E26 + i], (byte) (ZScreamer.ActiveROM[0x67E30 + (i * 2)] + 22),
					ZScreamer.ActiveROM[0x67E1C + i], (byte) ((ZScreamer.ActiveROM[0x67E92] >> 1) & 0x07), uppersprCheckbox.Checked);
				if (ZScreamer.ActiveROM[0x67E26 + i] < xLowest)
				{
					xLowest = ZScreamer.ActiveROM[0x67E26 + i];
				}
			}

			swordX = xLowest;
			//swordXPos = ZScreamer.ActiveROM.DATA[0x67E26];

			/*
            oamData[1] = new OAMTile(64, 54, 02, 00);
            oamData[2] = new OAMTile(48  ,62  ,32, 00);
            oamData[3] = new OAMTile(80  ,62  ,34, 00);
            oamData[4] = new OAMTile(64  ,70  ,04, 00);
            oamData[5] = new OAMTile(64  ,86  ,06, 00);
            oamData[6] = new OAMTile(64  ,102 ,08, 00);
            oamData[7] = new OAMTile(64  ,118 ,10, 00);
            oamData[8] = new OAMTile(64  ,134 ,12, 00);
            oamData[9] = new OAMTile(64  ,150 ,14, 00);
            */

			LoadTitleScreen();
			LoadOverworldMap();
			LoadDungeonMaps();
			LoadAllMapIcons();
			dungmapListbox.SelectedIndex = 0;
		}


		public void LoadOverworldMap()
		{
			// TODO: Add something here?
		}

		// TODO so many magic numbers
		public void LoadTitleScreen(bool JP = false)
		{
			int pos = (ZScreamer.ActiveROM[0x138C + 3] << 16) + (ZScreamer.ActiveROM[0x1383 + 3] << 8) + ZScreamer.ActiveROM[0x137A + 3];

			for (int i = 0; i < 1024; i++)
			{
				tilesBG1Buffer[i] = SomeThingZarbyNeedsToName;
				tilesBG2Buffer[i] = SomeThingZarbyNeedsToName;
			}

			pos = (JP) ? 0x065CC7 : pos.SNEStoPC(); // TODO dammit move this to a constant in ZScream

			while (!ZScreamer.ActiveROM[pos].BitIsOn(0x80))
			{
				//Console.WriteLine(ZScreamer.ActiveROM.DATA[pos].ToString("X2") + " "+ ZScreamer.ActiveROM.DATA[pos+1].ToString("X2") + " "+ ZScreamer.ActiveROM.DATA[pos+2].ToString("X2") + " "+ ZScreamer.ActiveROM.DATA[pos+3].ToString("X2") + " ");
				ushort destAddr = ZScreamer.ActiveROM.Read16BE(pos); // $03 and $04
				pos += 2;
				ushort length = ZScreamer.ActiveROM.Read16BE(pos);
				bool increment64 = length.BitIsOn(0x8000);
				bool fixsource = length.BitIsOn(0x4000);
				pos += 2;

				length &= 0x07FF;

				int j = 0;
				int jj = 0;
				int posB = pos;
				while (j < (length / 2) + 1)
				{
					ushort tiledata = ZScreamer.ActiveROM.Read16(pos);
					if (destAddr >= 0x1000)
					{
						//destAddr -= 0x1000;
						if (destAddr < 0x2000)
						{
							tilesBG1Buffer[destAddr - 0x1000] = tiledata;
						}
					}
					else
					{
						if (destAddr < 0x1000)
						{
							tilesBG2Buffer[destAddr] = tiledata;
						}
					}

					if (increment64)
					{
						destAddr += 32;
					}
					else
					{
						destAddr++;
					}

					if (!fixsource)
					{
						pos += 2;
					}

					jj += 2;
					j++;
				}

				if (fixsource)
				{
					pos += 2;
				}
				else
				{
					pos = posB + jj;
				}
			}

			//label4.Text = count.ToString("X6");
			//label4.Text = "Break at position " + pos.ToString("X6");
			palSelected = 2;
			updateTiles();
		}

		public unsafe void Buildtileset()
		{
			byte[] staticgfx = new byte[16];

			// Main Blocksets

			for (int i = 0; i < 8; i++)
			{
				staticgfx[i] = ZScreamer.ActiveROM[ZScreamer.ActiveOffsets.overworldgfxGroups2 + (35 * 8) + i];
			}

			staticgfx[8] = 115 + 0;
			staticgfx[9] = (byte) (ZScreamer.ActiveROM[ZScreamer.ActiveOffsets.sprite_blockset_pointer + (125 * 4) + 3] + 115);
			staticgfx[10] = 115 + 6;
			staticgfx[11] = 115 + 7;
			staticgfx[12] = (byte) (ZScreamer.ActiveROM[ZScreamer.ActiveOffsets.sprite_blockset_pointer + (125 * 4)] + 115);
			staticgfx[13] = 112;
			staticgfx[14] = 112;
			staticgfx[15] = 112;

			/*
            for (int i = 0; i < 4; i++)
            {
                
            }
            */
			// NEED TO BE EXECUTED AFTER THE TILESET ARE LOADED NOT BEFORE -_-
			byte* currentmapgfx8Data = (byte*) ZScreamer.ActiveGraphicsManager.currentTileScreengfx16Ptr.ToPointer(); // Loaded gfx for the current map (empty at this point)
			byte* allgfxData = (byte*) ZScreamer.ActiveGraphicsManager.allgfx16Ptr.ToPointer(); // All gfx of the game pack of 2048 bytes (4bpp)
			for (int i = 0; i < 16; i++)
			{
				for (int j = 0; j < 2048; j++)
				{
					byte mapByte = allgfxData[j + (staticgfx[i] * 2048)];
					switch (i)
					{
						case 0:
						case 3:
						case 4:
						case 5:
							mapByte += 0x88;
							break;
					}

					currentmapgfx8Data[(i * 2048) + j] = mapByte; // Upload used gfx data
				}
			}
		}


		public unsafe void Buildtilesetmap()
		{
			byte[] staticgfx = new byte[16];

			// Main Blocksets

			for (int i = 0; i < 8; i++)
			{
				staticgfx[i] = 0;
			}

			staticgfx[8] = 115 + 0;
			staticgfx[9] = 115 + 5;
			staticgfx[10] = 115 + 6;
			staticgfx[11] = 115 + 7;
			staticgfx[12] = 112;
			staticgfx[13] = 112;
			staticgfx[14] = 112;
			staticgfx[15] = 112;

			/*
            for (int i = 0; i < 4; i++)
            {
                
            }
            */

			// NEED TO BE EXECUTED AFTER THE TILESET ARE LOADED NOT BEFORE -_-
			byte* currentmapgfx8Data = (byte*) ZScreamer.ActiveGraphicsManager.currentTileScreengfx16Ptr.ToPointer(); // Loaded gfx for the current map (empty at this point)
			byte* allgfxData = (byte*) ZScreamer.ActiveGraphicsManager.allgfx16Ptr.ToPointer(); // All gfx of the game pack of 2048 bytes (4bpp)
			for (int i = 0; i < 16; i++)
			{
				for (int j = 0; j < 2048; j++)
				{
					byte mapByte = allgfxData[j + (staticgfx[i] * 2048)];
					switch (i)
					{
						case 0:
						case 3:
						case 4:
						case 5:
							mapByte += 0x88;
							break;
					}

					currentmapgfx8Data[(i * 2048) + j] = mapByte; // Upload used gfx data
				}
			}
			

			ColorPalette cp = ZScreamer.ActiveGraphicsManager.overworldMapBitmap.Palette;
			for (int i = 128; i < 256; i++)
			{
				cp.Entries[i] = currentPalette[i];
			}

			for (int i = 0; i < 80; i++)
			{
				cp.Entries[i + 32] = Palettes.ToColor(ZScreamer.ActiveROM.Read16(0xDE544 + (i * 2)));
				if ((i % 16) == 0)
				{
					cp.Entries[i + 32] = Color.Transparent;
				}
			}
		}

		public unsafe void updateTiles()
		{
			byte p = palSelected; ;
			//ushort tempTile = selectedTile;
			byte* destPtr = (byte*) tiles8Ptr.ToPointer();
			byte* srcPtr = (byte*) ZScreamer.ActiveGraphicsManager.currentTileScreengfx16Ptr.ToPointer();
			int xx = 0;
			int yy = 0;

			for (int i = 0; i < 1024; i++)
			{
				for (int y = 0; y < 8; y++)
				{
					for (int x = 0; x < 4; x++)
					{
						CopyTile(x, y, xx, yy, i, p, destPtr, srcPtr);
					}
				}

				xx += 8;
				if (xx >= 128)
				{
					yy += 1024;
					xx = 0;
				}
			}

			// Updated bitmap palette here
			tiles8Bitmap.Palette = tilesBG1Bitmap.Palette;
			tilesBox.Refresh();
		}

		private unsafe void CopyTile(int x, int y, int xx, int yy, int id, byte p, byte* gfx16Pointer, byte* gfx8Pointer)
		{
			int mx = x;
			int my = 128 * (mirrorYCheckbox.Checked ? 7 - y : y);
			byte r = 0;

			if (mirrorXCheckbox.Checked)
			{
				mx = 3 - x;
				r = 1;
			}

			int tx = ((id / 16) * 512) + ((id & 0xF) * 4);
			var index = xx + yy + (mx * 2) + my;
			var pixel = gfx8Pointer[tx + (y * 64) + x];

			gfx16Pointer[index + r ^ 1] = (byte) ((pixel & 0x0F) | (p << 4));
			gfx16Pointer[index + r] = (byte) ((pixel >> 4) | (p << 4));
		}


		private unsafe void CopyTile(int x, int y, int xx, int yy, int id, byte p, bool v, bool h, byte* gfx16Pointer, byte* gfx8Pointer)
		{
			int mx = x;
			int my = y;
			byte r = 0;

			if (h)
			{
				mx = 3 - x;
				r = 1;
			}
			if (v)
			{
				my = 7 - y;
			}

			int tx = ((id / 16) * 512) + ((id & 0xF) * 4);
			var index = xx + yy + (mx * 2) + (my * 256);
			var pixel = gfx8Pointer[tx + (y * 64) + x];

			gfx16Pointer[index + r ^ 1] = (byte) ((pixel & 0x0F) + p * 16);
			gfx16Pointer[index + r] = (byte) (((pixel >> 4) & 0x0F) + p * 16);
		}

		private void pictureBox2_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			e.Graphics.DrawImage(tiles8Bitmap, Constants.Rect_0_0_256_1024, Constants.Rect_0_0_128_512, GraphicsUnit.Pixel);
			int sx = selectedTile % 16;
			int sy = selectedTile / 16;

			if (editsprRadio.Checked)
			{
				e.Graphics.DrawRectangle(Pens.LimeGreen, new Rectangle(sx * 16, sy * 16, 32, 32));
			}
			else
			{
				e.Graphics.DrawRectangle(Pens.LimeGreen, new Rectangle(sx * 16, sy * 16, 16, 16));
			}
		}

		private void mirrorXCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			updateTiles();
		}

		// TODO :cry:
		public unsafe void DrawBGs(IntPtr destPtr, ushort[] tilesBgBuffer, bool onlyPrior = false)
		{
			var alltilesData = (byte*) ZScreamer.ActiveGraphicsManager.currentTileScreengfx16Ptr.ToPointer();
			byte* ptr = (byte*) destPtr.ToPointer();

			for (int yy = 0; yy < 32; yy++) // for each tile on the tile buffer
			{
				for (int xx = 0; xx < 32; xx++)
				{
					if (tilesBgBuffer[xx + (yy * 32)] != 0xFFFF) // Prevent draw if tile == 0xFFFF since it 0 indexed
					{
						Tile t = new Tile(tilesBgBuffer[xx + (yy * 32)]);
						if (onlyPrior && !t.Priority)
						{
							continue;
						}

						for (var yl = 0; yl < 8; yl++)
						{
							for (var xl = 0; xl < 4; xl++)
							{
								int mx = xl * (1 - t.HFlipByte) + (3 - xl) * (t.HFlipByte);
								int my = yl * (1 - t.VFlipByte) + (7 - yl) * (t.VFlipByte);

								int ty = (t.ID / 16) * 512;
								int tx = (t.ID % 16) * 4;
								var pixel = alltilesData[(tx + ty) + (yl * 64) + xl];

								int index = (xx * 8) + (yy * 2048) + ((mx * 2) + (my * 256));
								ptr[index + t.HFlipByte ^ 1] = (byte) ((pixel & 0x0F) + t.Palette * 16);
								ptr[index + t.HFlipByte] = (byte) (((pixel >> 4) & 0x0F) + t.Palette * 16);
							}
						}
					}
				}
			}
		}

		// TODO :cry:
		public unsafe void DrawSpr(IntPtr destPtr)
		{
			var alltilesData = (byte*) ZScreamer.ActiveGraphicsManager.currentTileScreengfx16Ptr.ToPointer();
			byte* ptr = (byte*) destPtr.ToPointer();

			foreach (OAMTile t in oamData) // Prevent draw if tile == 0xFFFF since it 0 indexed
			{
				for (var yl = 0; yl < 16; yl++)
				{
					for (var xl = 0; xl < 8; xl++)
					{
						int ty = (t.tile / 16) * 512;
						int tx = (t.tile % 16) * 4;
						var pixel = alltilesData[(tx + ty) + (yl * 64) + xl];

						int index = (t.x + (xl * 2)) + (t.y * 256) + (yl * 256); // + ((mx * 2) + (my * 256));

						ptr[index + 1] = (byte) ((pixel & 0x0F) + (t.pal + 8) * 16);
						ptr[index] = (byte) (((pixel >> 4) & 0x0F) + (t.pal + 8) * 16);
					}
				}
			}
		}

		public unsafe void ClearBG(IntPtr destPtr)
		{
			byte* ptr = (byte*) destPtr.ToPointer();
			for (int i = 0; i < (512 * 512); i++)
			{
				ptr[i] = 0;
			}
		}

		private void screenBox_Paint(object sender, PaintEventArgs e)
		{
			//e.Graphics.Clear(Color.Black);
			DrawBGs(tilesBG1Ptr, tilesBG1Buffer);
			DrawBGs(tilesBG2Ptr, tilesBG2Buffer);
			ClearBG(oamBGPtr);
			DrawSpr(oamBGPtr);

			e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

			if (bg2Checkbox.Checked)
			{
				e.Graphics.DrawImage(tilesBG2Bitmap, Constants.Rect_0_0_512_512, Constants.Rect_0_0_256_256, GraphicsUnit.Pixel);
			}

			if (bg1checkbox.Checked)
			{
				e.Graphics.DrawImage(tilesBG1Bitmap, Constants.Rect_0_0_512_512, Constants.Rect_0_0_256_256, GraphicsUnit.Pixel);
			}

			if (oambgCheckbox.Checked)
			{
				e.Graphics.DrawImage(oamBGBitmap, Constants.Rect_0_0_512_512, Constants.Rect_0_0_256_256, GraphicsUnit.Pixel);
			}

			ClearBG(tilesBG1Ptr);
			DrawBGs(tilesBG1Ptr, tilesBG1Buffer, true);

			if (bg1checkbox.Checked)
			{
				e.Graphics.DrawImage(tilesBG1Bitmap, Constants.Rect_0_0_512_512, Constants.Rect_0_0_256_256, GraphicsUnit.Pixel);
			}

			if (editsprRadio.Checked)
			{
				if (lastSelectedOamTile != null)
				{
					e.Graphics.DrawRectangle(Pens.LightGreen, new Rectangle((lastSelectedOamTile.x * 2), (lastSelectedOamTile.y * 2), 32, 32));
				}
			}
		}

		private void bg1checkbox_CheckedChanged(object sender, EventArgs e)
		{
			screenBox.Refresh();
		}

		private void tilesBox_MouseDown(object sender, MouseEventArgs e)
		{
			selectedTile = (ushort) ((e.X / 16) + (e.Y & ~0xF));
			tilesBox.Refresh();

			if (editsprRadio.Checked && lastSelectedOamTile != null)
			{
				lastSelectedOamTile.tile = selectedTile;
				screenBox.Refresh();
			}
		}

		private void screenBox_MouseDown(object sender, MouseEventArgs e)
		{
			lastX = (byte) (e.X / 16);
			lastY = (byte) (e.Y / 16);

			if (e.Button == MouseButtons.Left)
			{
				mDown = true;

				//Set Tile
				Tile t = new Tile(
					selectedTile,
					palSelected, onTopCheckbox.Checked,
					mirrorXCheckbox.Checked,
					mirrorYCheckbox.Checked);

				if (bg1Radio.Checked)
				{
					tilesBG1Buffer[lastX + (lastY * 32)] = t.ToUnsignedShort();
				}
				else if (bg2Radio.Checked)
				{
					tilesBG2Buffer[lastX + (lastY * 32)] = t.ToUnsignedShort();
				}
				if (movesprRadio.Checked)
				{
					xIn = e.X - (swordX * 2);
					swordSelected = true;
				}

				screenBox.Refresh();
			}
			else if (e.Button == MouseButtons.Right)
			{
				Tile t = new Tile(0, 0);
				if (bg1Radio.Checked)
				{
					t = new Tile(tilesBG1Buffer[lastX + (lastY * 32)]);
				}
				else if (bg2Radio.Checked)
				{
					t = new Tile(tilesBG2Buffer[lastX + (lastY * 32)]);
				}

				selectedTile = t.ID;
				palSelected = t.Palette;
				mirrorXCheckbox.Checked = t.HFlip;
				mirrorYCheckbox.Checked = t.VFlip;
				onTopCheckbox.Checked = t.Priority;
				updateTiles();
				paletteBox.Refresh();
				tilesBox.Refresh();
				// Copy Tile
			}

			if (editsprRadio.Checked)
			{
				int xP = e.X / 2;
				int yP = e.Y / 2;
				for (int i = 0; i < 10; i++)
				{
					if (xP >= oamData[i].x && xP <= (oamData[i].x + 16) &&
						yP >= oamData[i].y && yP <= (oamData[i].y + 16))
					{
						selectedOamTile = oamData[i];
						break;
					}
				}
			}
		}

		private void screenBox_MouseMove(object sender, MouseEventArgs e)
		{
			byte mX = (byte) (e.X / 16);
			byte mY = (byte) (e.Y / 16);

			if (mDown)
			{
				if (mX != lastX || mY != lastY)
				{
					// Set Tile
					Tile t = new Tile(
						selectedTile,
						palSelected,
						onTopCheckbox.Checked,
						mirrorXCheckbox.Checked,
						mirrorYCheckbox.Checked);
					if (bg1Radio.Checked)
					{
						tilesBG1Buffer[mX + (mY * 32)] = t.ToUnsignedShort();
					}
					else if (bg2Radio.Checked)
					{
						tilesBG2Buffer[mX + (mY * 32)] = t.ToUnsignedShort();
					}

					screenBox.Refresh();

					lastX = mX;
					lastY = mY;
				}

				if (movesprRadio.Checked)
				{
					for (int i = 0; i < 10; i++)
					{
						// TODO magic number
						oamData[i].x = (byte) (ZScreamer.ActiveROM[0x67E26 + i] + (e.X / 2) - swordX);

						screenBox.Refresh();
					}

					//swordX = (e.X / 2);
					if (swordSelected)
					{
						// TODO: remove this?
					}
				}

				if (editsprRadio.Checked)
				{
					int xP = e.X / 2;
					int yP = e.Y / 2;

					for (int i = 0; i < 10; i++)
					{
						if (xP >= oamData[i].x && xP <= (oamData[i].x + 16) &&
							yP >= oamData[i].y && yP <= (oamData[i].y + 16))
						{
							selectedOamTile = oamData[i];
							break;
						}
					}

					if (selectedOamTile != null)
					{
						if (lockCheckbox.Checked)
						{
							selectedOamTile.x = (byte) ((xP / 8) * 8);
							selectedOamTile.y = (byte) ((yP / 8) * 8);
						}
						else
						{
							selectedOamTile.x = (byte) xP;
							selectedOamTile.y = (byte) yP;
						}
					}

					screenBox.Refresh();
				}
			}

			// SelectedOamTile
		}

		private void screenBox_MouseUp(object sender, MouseEventArgs e)
		{
			mDown = false;
			if (selectedOamTile != null)
			{
				lastSelectedOamTile = selectedOamTile;
				selectedTile = lastSelectedOamTile.tile;
				palSelected = (byte) (lastSelectedOamTile.pal + 8);
				mirrorXCheckbox.Checked = lastSelectedOamTile.mx == 1;
				mirrorYCheckbox.Checked = lastSelectedOamTile.my == 1;
				updateTiles();
				paletteBox.Refresh();
				tilesBox.Refresh();
			}

			screenBox.Refresh();
			selectedOamTile = null;
		}


		private void SetColorsPalette(Color[] main, Color[] animated, Color[] aux1, Color[] aux2, Color[] hud, Color bgrcolor, Color[] spr, Color[] spr2)
		{
			// Palettes infos, color 0 of a palette is always transparent (the arrays contains 7 colors width wide)
			// There is 16 color per line so 16*Y

			// Left side of the palette - Main, Animated

			// Main Palette, Location 0,2 : 35 colors [7x5]
			int k = 0;
			for (int y = 2; y < 7; y++)
			{
				for (int x = 1; x < 8; x++)
				{
					currentPalette[x + (16 * y)] = main[k++];
				}
			}

			// Animated Palette, Location 0,7 : 7colors
			for (int x = 1; x < 8; x++)
			{
				currentPalette[(16 * 7) + x] = animated[x - 1];
			}

			// Right side of the palette - Aux1, Aux2 

			// Aux1 Palette, Location 8,2 : 21 colors [7x3]
			k = 0;
			for (int y = 2; y < 5; y++)
			{
				for (int x = 9; x < 16; x++)
				{
					currentPalette[x + (16 * y)] = aux1[k++];
				}
			}

			// Aux2 Palette, Location 8,5 : 21 colors [7x3]
			k = 0;
			for (int y = 5; y < 8; y++)
			{
				for (int x = 9; x < 16; x++)
				{
					currentPalette[x + (16 * y)] = aux2[k++];
				}
			}

			// Hud Palette, Location 0,0 : 32 colors [16x2]
			for (int i = 0; i < 32; i++)
			{
				currentPalette[i] = hud[i];
			}

			// Hardcoded grass color (that might change to become invisible instead)
			for (int i = 0; i < 8; i++)
			{
				currentPalette[i * 16] = bgrcolor;
				currentPalette[(i * 16) + 8] = bgrcolor;
			}

			// Sprite Palettes
			k = 0;
			for (int y = 8; y < 9; y++)
			{
				for (int x = 1; x < 8; x++)
				{
					currentPalette[x + (16 * y)] = ZScreamer.ActivePaletteManager.SpriteAux1[1][k++];
				}
			}

			// Sprite Palettes
			k = 0;
			for (int y = 8; y < 9; y++)
			{
				for (int x = 9; x < 16; x++)
				{
					currentPalette[x + (16 * y)] = ZScreamer.ActivePaletteManager.SpriteAux3[0][k++];
				}
			}

			// Sprite Palettes
			k = 0;
			for (int y = 9; y < 13; y++)
			{
				for (int x = 1; x < 16; x++)
				{
					currentPalette[x + (16 * y)] = ZScreamer.ActivePaletteManager.SpriteGlobal[0][k++];
				}
			}

			// Sprite Palettes
			k = 0;
			for (int y = 13; y < 14; y++)
			{
				for (int x = 1; x < 8; x++)
				{
					currentPalette[x + (16 * y)] = spr[k++];
				}
			}

			// Sprite Palettes
			k = 0;
			for (int y = 14; y < 15; y++)
			{
				for (int x = 1; x < 8; x++)
				{
					currentPalette[x + (16 * y)] = spr2[k++];
				}
			}

			// Sprite Palettes
			k = 0;
			for (int y = 15; y < 16; y++)
			{
				for (int x = 1; x < 16; x++)
				{
					currentPalette[x + (16 * y)] = ZScreamer.ActivePaletteManager.PlayerMail[0][k++];
				}
			}

			k = 0;
			for (int x = 1; x < 8; x++)
			{
				currentPalette[x + (16 * 8)] = ZScreamer.ActivePaletteManager.SpriteAux1[11][k++];
			}

			try
			{
				ColorPalette pal = tilesBG1Bitmap.Palette;
				for (int i = 0; i < 256; i++)
				{
					pal.Entries[i] = currentPalette[i];
					if ((i % 16) == 0)
					{
						pal.Entries[i] = Color.Transparent;
					}
				}
				ZScreamer.ActiveGraphicsManager.currentTileScreengfx16Bitmap.Palette = pal;

				tilesBG1Bitmap.Palette = pal;
				tilesBG2Bitmap.Palette = pal;
				oamBGBitmap.Palette = pal;
			}
			catch (Exception)
			{
				// TODO: Add error message here.
			}
		}

		private void paletteBox_Paint(object sender, PaintEventArgs e)
		{
			for (int i = 0; i < 256; i++)
			{
				e.Graphics.FillRectangle(new SolidBrush(currentPalette[i]), new Rectangle((i % 16) * 16, (i / 16) * 16, 16, 16));
			}

			e.Graphics.DrawRectangle(Pens.LimeGreen, new Rectangle(0, 16 * palSelected, 256, 16));
		}

		private void paletteBox_MouseDown(object sender, MouseEventArgs e)
		{
			palSelected = (byte) (e.Y / 16);
			paletteBox.Refresh();
			updateTiles();

			if (editsprRadio.Checked)
			{
				for (int i = 0; i < 10; i++)
				{
					oamData[i].pal = (byte) (palSelected - 8);
				}
			}

			screenBox.Refresh();
		}

		private void owMapTilesBox_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

			e.Graphics.DrawImage(ZScreamer.ActiveGraphicsManager.overworldMapBitmap, Constants.Rect_0_0_256_256);
			e.Graphics.DrawRectangle(Pens.LimeGreen, new Rectangle((selectedMapTile % 16) * 16, (selectedMapTile / 16) * 16, 16, 16));
		}

		public unsafe void DrawMapBG(IntPtr destPtr)
		{
			var alltilesData = (byte*) ZScreamer.ActiveGraphicsManager.overworldMapPointer.ToPointer();
			byte* ptr = (byte*) destPtr.ToPointer();

			for (int yy = 0; yy < 64; yy++) // for each tile on the tile buffer
			{
				for (int xx = 0; xx < 64; xx++)
				{
					for (int yl = 0; yl < 8; yl++)
					{
						for (int xl = 0; xl < 8; xl++)
						{
							byte tid = (darkWorld ? dwmapdata : mapdata)[xx + (yy * 64)];

							int ty = (tid / 16) * 1024;
							int tx = (tid % 16) * 8;

							int index = (xx * 8) + (yy * 4096) + xl + (yl * 512);
							ptr[index] = alltilesData[(tx + ty) + (yl * 128) + xl];
						}
					}
				}
			}
		}

		public void LoadAllMapIcons()
		{
			for (int e = 0; e < 10; e++)
			{
				allMapIcons[e] = new List<MapIcon>();

				for (int i = 0; i < 8; i++)
				{
					ushort yPos, xPos;
					if (e == 9)
					{
						// TODO magic numbers
						xPos = (ushort) ((ZScreamer.ActiveROM[0x53763 + i] + (ZScreamer.ActiveROM[0x5376B + i] << 8)) >> 4);
						yPos = (ushort) ((ZScreamer.ActiveROM[0x53773 + i] + (ZScreamer.ActiveROM[0x5377B + i] << 8)) >> 4);
					}
					else
					{
						if (i == 7)
						{
							break;
						}

						ushort xData = ZScreamer.ActiveROM.Read16(addresses[i] + e * 2);

						if (xData < 0)
						{
							break;
						}

						xPos = (ushort) (xData >> 4);
						ushort yData = ZScreamer.ActiveROM.Read16(addresses[i] + 18 + e * 2);
						yPos = (ushort) (yData >> 4);
						//rc->top = ((short*)(rom + wmmark_ofs[i] + 18))[b] >> 4
					}

					ushort gfx = 0;
					if (e != 9)
					{
						gfx = ZScreamer.ActiveROM.Read16(addressesgfx[i] + e * 2);
					}

					allMapIcons[e].Add(new MapIcon(xPos, yPos, gfx));
				}
			}
		}

		private void mapPicturebox_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
			e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

			DrawMapBG(ZScreamer.ActiveGraphicsManager.owactualMapPointer);
			/*
            DrawMapBGDW(ZScreamer.ActiveGraphicsManager.owactualMapPointer);
            byte yData1 = (byte)((ZScreamer.ActiveROM.DATA[0x053DF6+ (comboBox1.SelectedIndex*2)]&0xF0) >> 4);
            byte yData2 = (byte)((ZScreamer.ActiveROM.DATA[0x053DF7+ (comboBox1.SelectedIndex * 2)] &0x0F) << 4);
            byte yData = (byte)(yData1 + yData2);

            byte xData1 = (byte)((ZScreamer.ActiveROM.DATA[0x053DE4+ (comboBox1.SelectedIndex * 2)] & 0xF0) >> 4);
            byte xData2 = (byte)((ZScreamer.ActiveROM.DATA[0x053DE5+ (comboBox1.SelectedIndex * 2)] & 0x0F) << 4);
            byte xData = (byte)(xData1 + xData2);
            */

			e.Graphics.DrawImage(ZScreamer.ActiveGraphicsManager.owactualMapBitmap, Constants.Rect_0_0_1024_1024, Constants.Rect_0_0_512_512, GraphicsUnit.Pixel);

			//for (int i = 0; i < 8; i++)
			//{

			for (int i = 0; i < allMapIcons[overworldCombobox.SelectedIndex].Count; i++)
			{
				int xpos = 256 + (allMapIcons[overworldCombobox.SelectedIndex][i].x * 2);
				int ypos = 256 + (allMapIcons[overworldCombobox.SelectedIndex][i].y * 2);

				Brush brush;
				if (allMapIcons[overworldCombobox.SelectedIndex][i] == selectedMapIcon)
				{
					brush = Brushes.Teal;
				}
				else
				{
					brush = Brushes.Yellow;
				}

				e.Graphics.DrawFilledRectangleWithOutline(xpos, ypos, 24, 24, Constants.BlackPen2, brush);

				ZScreamer.ActiveGraphicsManager.drawText(e.Graphics, xpos + 6, ypos + 4, (i + 1).ToString(), null, true);
			}

			//}
		}

		private void mapPalettePicturebox_Paint(object sender, PaintEventArgs e)
		{
			for (int i = 0; i < 256; i++)
			{
				e.Graphics.FillRectangle(new SolidBrush(ZScreamer.ActiveGraphicsManager.overworldMapBitmap.Palette.Entries[i]), new Rectangle((i % 16) * 16, (i / 16) * 16, 16, 16));
			}
		}

		private void owMapTilesBox_MouseDown(object sender, MouseEventArgs e)
		{
			selectedMapTile = (byte) ((e.X / 16) + ((e.Y / 16) * 16));
			owMapTilesBox.Refresh();
		}

		// TODO magic numbers
		public void Save()
		{
			for (int i = 0; i < 10; i++)
			{
				ZScreamer.ActiveROM[0x67E26 + i] = oamData[i].x;
				ZScreamer.ActiveROM[0x67E30 + (i * 2)] = (byte) (oamData[i].y - 22);

				if (uppersprCheckbox.Checked)
				{
					ZScreamer.ActiveROM[0x67E1C + i] = (byte)(oamData[i].tile - 512);
				}
				else
				{
					ZScreamer.ActiveROM[0x67E1C + i] = (byte)(oamData[i].tile - 768);
				}
			}

			// New position //PC:108000 / S:218000
			int titleScreenPosition = 0x108000; // In PC
			int snestitleScreenPosition = titleScreenPosition.PCtoSNES();
			ZScreamer.ActiveROM[0x138C + 3] =  (byte) (snestitleScreenPosition >> 16);
			ZScreamer.ActiveROM[0x1383 + 3] =  (byte) (snestitleScreenPosition >> 8);
			ZScreamer.ActiveROM[0x137A + 3] =  (byte) snestitleScreenPosition;

			// Just do a full DMA of all tiles why not...
			// Header bytes
			List<byte> allData = new List<byte>();
			allData.Add(0x10);
			allData.Add(0x00); // pos

			allData.Add(0x07); // length
			allData.Add(0xFF);

			for (int i = 0; i < 1024; i++)
			{
				allData.Add(tilesBG1Buffer[i]);
			}

			allData.Add(0x00);
			allData.Add(0x00); // pos

			allData.Add(0x07); // length
			allData.Add(0xFF);

			for (int i = 0; i < 1024; i++)
			{
				allData.Add(tilesBG2Buffer[i]);
			}

			allData.Add(0xFF);

			//label4.Text = allData.Count.ToString("X6");

			// TODO: Move the upper sprite to a array as well there's space remaining at position 0x67FB1 - 0x67FFF

			if (uppersprCheckbox.Checked)
			{
				ZScreamer.ActiveROM[0x67E92] = (byte) (0x20 + (oamData[0].pal << 1));
			}
			else
			{
				ZScreamer.ActiveROM[0x67E92] = (byte) (0x21 + (oamData[0].pal << 1));
			}

			ZScreamer.ActiveROM.Write(titleScreenPosition, allData.ToArray());
		}

		private void button2_Click(object sender, EventArgs e)
		{
			/*
            int pos = 0;
            while(pos < (64*64))
            {
                mapdata[pos] = ZScreamer.ActiveROM.DATA[p + pos];
                pos++;
            }
            */

			SaveFileDialog sfd = new SaveFileDialog
			{
				// TODO standardize
				Filter = "all *.bin |*.bin"
			};
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				FileStream fs = new FileStream(sfd.FileName, FileMode.OpenOrCreate, FileAccess.Write);
				fs.Write(darkWorld ? dwmapdata : mapdata, 0, 64 * 64);
	

				fs.Close();
				//label4.Text = ;

				ZScreamer.ActiveGraphicsManager.overworldMapBitmap.Save(sfd.FileName + "_Tileset.png");
			}
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			mapPicturebox.Refresh();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			darkWorld = !darkWorld;
			int offset = darkWorld ? 256 : 0;

			ColorPalette cp = ZScreamer.ActiveGraphicsManager.overworldMapBitmap.Palette;
			for (int i = 0; i < 256; i += 2)
			{
				// 55B27 = US LW
				// 55C27 = US DW
				cp.Entries[i / 2] = ZScreamer.ActiveROM.Read16(0x55B27 + i + offset + 1).ToColor();
				int k = 0;
				int j = 0;

				for (int y = 10; y < 14; y++)
				{
					for (int x = 0; x < 15; x++)
					{
						cp.Entries[145 + k] = ZScreamer.ActivePaletteManager.SpriteGlobal[0][j++];
						k++;
					}

					k++;
				}
			}

			ZScreamer.ActiveGraphicsManager.overworldMapBitmap.Palette = cp;
			ZScreamer.ActiveGraphicsManager.owactualMapBitmap.Palette = cp;
			Buildtilesetmap();
			mapPalettePicturebox.Refresh();
			mapPicturebox.Refresh();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog
			{
				// TODO standardize
				Filter = "all *.bin |*.bin"
			};

			if (ofd.ShowDialog() == DialogResult.OK)
			{
				FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);

				fs.Read(darkWorld ? dwmapdata : mapdata, 0, 64 * 64);

				fs.Close();
			}
		}

		public void saveOverworldMap()
		{
			int p = Constants.IDKZarby;
			int p2 = Constants.IDKZarby + 0x0400;
			int p3 = Constants.IDKZarby + 0x0800;
			int p4 = Constants.IDKZarby + 0x0C00;
			int p5 = Constants.IDKZarby + 0x1000;
			bool rSide = false;
			int cSide = 0;
			int count = 0;

			while (count < 64 * 64)
			{
				if (count < 0x800)
				{
					if (!rSide)
					{
						ZScreamer.ActiveROM[p++] = mapdata[count];

						if (cSide >= 31)
						{
							cSide = 0;
							rSide = true;
							count++;
							continue;
						}
					}
					else
					{
						ZScreamer.ActiveROM[p2++] = mapdata[count] ;

						if (cSide >= 31)
						{
							cSide = 0;
							rSide = false;
							count++;
							continue;
						}
					}
				}
				else
				{
					if (!rSide)
					{
						ZScreamer.ActiveROM[p3] = mapdata[count];

						p3++;
						if (cSide >= 31)
						{
							cSide = 0;
							rSide = true;
							count++;
							continue;
						}
					}
					else
					{
						ZScreamer.ActiveROM[p4++] =  mapdata[count];
						if (cSide >= 31)
						{
							cSide = 0;
							rSide = false;
							count++;
							continue;
						}
					}
				}

				cSide++;
				count++;
			}

			count = 0;
			int line = 0;
			while (true)
			{
				ZScreamer.ActiveROM[p5] = dwmapdata[1040 + count + (line * 64)];

				p5++;
				count++;
				if (count >= 32)
				{
					count = 0;
					line++;
					if (line >= 32)
					{
						break;
					}
				}
			}

			for (int e = 0; e < 10; e++)
			{
				for (int i = 0; i < 8; i++)
				{
					if (allMapIcons[e].Count <= i)
					{
						break;
					}

					if (e < 9)
					{
						ZScreamer.ActiveROM.Write16(addresses[i] + (e * 2), allMapIcons[e][i].x << 4);
						ZScreamer.ActiveROM.Write16(addresses[i] + 18 + (e * 2), allMapIcons[e][i].y << 4);
						ZScreamer.ActiveROM.Write16(addressesgfx[i] + (e * 2), allMapIcons[e][i].gfx);
					}
					else
					{
						ushort px = (ushort) (allMapIcons[e][i].x << 4);
						ushort py = (ushort) (allMapIcons[e][i].y << 4);
						ZScreamer.ActiveROM[0x53763 + i] = (byte) px;
						ZScreamer.ActiveROM[0x5376B + i] = (byte) (px>>8);

						ZScreamer.ActiveROM[0x53773 + i] = (byte) py;
						ZScreamer.ActiveROM[0x5377B + i] = (byte) (py >> 8);
					}
				}
			}
		}

		// DUNGEON MAP START
		private void dungmapPicturebox_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
			e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

			// TODO magic numbers
			Color r1 = ZScreamer.ActiveROM.Read16(0x0DE56E).ToColor();
			Color r2 = ZScreamer.ActiveROM.Read16(0x0DE570).ToColor();
			Color gridcolor = ZScreamer.ActiveROM.Read16(0x0DE572).ToColor();
			Pen ppp = new Pen(gridcolor, 2);


			e.Graphics.DrawRectangle(new Pen(r2, 2), Constants.Rect_1_1_182_182);
			e.Graphics.DrawRectangle(new Pen(r1, 2), Constants.Rect_3_3_178_178);

			for (int i = 0; i < 6 * 32; i += 32)
			{
				e.Graphics.DrawLine(ppp, 10, 12 + i, 170, 12 + i);
				e.Graphics.DrawLine(ppp, 10 + i, 12, 10 + i, 172);
			}

			if (dungmapListbox.SelectedIndex != -1)
			{
				for (int i = 0; i < 25; i++)
				{
					var box = new Rectangle(10 + ((i % 5) * 32), 12 + ((i / 5) * 32), 32, 32);

					if (currentFloorRooms[currentFloor][i] != 0x0F)
					{
						int gId = currentFloorGfx[currentFloor][i];
						e.Graphics.DrawImage(dungmaptiles16Bitmap, box, new Rectangle((gId % 16) * 16, gId & ~0xF, 16, 16), GraphicsUnit.Pixel);
						if (currentFloorRooms[currentFloor][i] == bossRoom)
						{
							e.Graphics.DrawRectangle(Constants.RedPen4, box);
						}

						if (roomidshowCheckbox.Checked)
						{
							ZScreamer.ActiveGraphicsManager.drawText(e.Graphics, 16 + ((i % 5) * 32), 20 + ((i / 5) * 32), currentFloorRooms[currentFloor][i].ToString("X2"), null, true);
						}
					}

					if (dungmapSelectedTile == i)
					{
						e.Graphics.DrawRectangle(Constants.AzurePen2, box);
					}
				}
			}
		}

		public void LoadDungeonMaps()
		{
			List<byte[]> currentFloorRoomsD = new List<byte[]>();
			List<byte[]> currentFloorGfxD = new List<byte[]>();
			int totalFloorsD;
			byte nbrFloorD, nbrBasementD;

			for (int d = 0; d < 14; d++)
			{
				currentFloorRoomsD.Clear();
				currentFloorGfxD.Clear();
				int ptr = 0x0A0000 | ZScreamer.ActiveROM.Read16(ZScreamer.ActiveOffsets.dungeonMap_rooms_ptr + (d * 2));
				int ptrGFX = 0x0A0000 | ZScreamer.ActiveROM.Read16(ZScreamer.ActiveOffsets.dungeonMap_gfx_ptr + (d * 2));
				int pcPtr = ptr.SNEStoPC(); // Contains data for the next 25 rooms
				int pcPtrGFX = ptrGFX.SNEStoPC(); // Contains data for the next 25 rooms

				ushort bossRoomD = ZScreamer.ActiveROM.Read16(ZScreamer.ActiveOffsets.dungeonMap_bossrooms + (d * 2));
				nbrBasementD = ZScreamer.ActiveROM[ZScreamer.ActiveOffsets.dungeonMap_floors + (d * 2)];
				nbrFloorD = (byte) (nbrBasementD >> 4);
				nbrBasementD &= 0x0F;
				totalFloorsD = nbrBasementD + nbrFloorD;

				for (int i = 0; i < totalFloorsD * Constants.RoomsPerFloorOnMap; i += Constants.RoomsPerFloorOnMap)
				{
					byte[] rdata = new byte[Constants.RoomsPerFloorOnMap];
					byte[] gdata = new byte[Constants.RoomsPerFloorOnMap];

					for (int j = 0; j < Constants.RoomsPerFloorOnMap; j++) // for each room on the floor
					{
						//rdata[j] = 0x0F;
						rdata[j] = ZScreamer.ActiveROM[pcPtr + j + i]; // Set the rooms

						if (rdata[j] == 0x0F)
						{
							gdata[j] = 0xFF;
						}
						else
						{
							gdata[j] = ZScreamer.ActiveROM[pcPtrGFX++];
						}
					}

					currentFloorGfxD.Add(gdata); // Add new floor gfx data
					currentFloorRoomsD.Add(rdata); // Add new floor data
				}

				dungmaps[d] = new DungeonMap(bossRoomD, nbrFloorD, nbrBasementD, currentFloorRoomsD, currentFloorGfxD);
			}
		}

		private void dungmapListbox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (currentDungeonChanged)
			{
				if (UIText.WarnAboutSaving("The previous selected dungeon had changes that will be lost.") == DialogResult.Yes)
				{
					// TODO: Add save
					// do save
				}

				currentDungeonChanged = false;
			}

			updateDungMap();
		}

		public void updateDungMap()
		{
			currentFloorRooms = dungmaps[dungmapListbox.SelectedIndex].FloorRooms.ToArray();
			currentFloorGfx = dungmaps[dungmapListbox.SelectedIndex].FloorGfx.ToArray();
			nbrBasement = dungmaps[dungmapListbox.SelectedIndex].nbrOfBasement;
			nbrFloor = dungmaps[dungmapListbox.SelectedIndex].nbrOfFloor;
			totalFloors = nbrBasement + nbrFloor;
			currentFloor = nbrBasement;

			if (nbrFloor == 0)
			{
				currentFloor -= 1;
			}

			bossRoom = dungmaps[dungmapListbox.SelectedIndex].bossRoom;
			editedFromEditor = true;
			dungmaproomidTextbox.Text = currentFloorRooms[currentFloor][dungmapSelectedTile].ToString("X2");
			dungmapbossTextbox.Text = bossRoom.ToString("X2");
			editedFromEditor = false;
			//label8.Text = currentFloor.ToString();
			AssembleMapTiles();
			dungmapPicturebox.Refresh();
			floorselectorPicturebox.Refresh();
			dungmapSelected = dungmapListbox.SelectedIndex;
		}

		private static readonly float[][] matrixItems1 = {
				new float[] { 1f, 0, 0, 0, 0 },
				new float[] { 0, 1f, 0, 0, 0 },
				new float[] { 0, 0, 1f, 0, 0 },
				new float[] { 0, 0, 0, 0.35f, 0 },
				new float[] { 0, 0, 0, 0, 1 }
			};

		private static readonly float[][] matrixItems2 = new float[][] {
				new float[] { 0f, 0, 0, 0, 0 },
				new float[] { 0, 1f, 0, 0, 0 },
				new float[] { 0, 0, 0f, 0, 0 },
				new float[] { 0, 0, 0, 1f, 0 },
				new float[] { 0, 0, 0, 0, 1 }
			};
		private void floorselectorPicturebox_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
			e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;



			ColorMatrix colorMatrix = new ColorMatrix(matrixItems1);
			ImageAttributes ia = new ImageAttributes();
			ia.SetColorMatrix(colorMatrix);

			e.Graphics.DrawImage(floorSelector, Constants.Rect_0_0_24_240, 0, 0, 24, 240, GraphicsUnit.Pixel, ia);
			for (int i = 0; i < nbrFloor; i++)
			{
				e.Graphics.DrawImage(floorSelector, new Rectangle(0, 105 - (i * 15), 24, 15), new Rectangle(0, 105 - (i * 15), 24, 15), GraphicsUnit.Pixel);
			}

			for (int i = 0; i < nbrBasement; i++)
			{
				e.Graphics.DrawImage(floorSelector, new Rectangle(0, 121 + (i * 15), 24, 15), new Rectangle(0, 121 + (i * 15), 24, 15), GraphicsUnit.Pixel);
			}

			for (int i = 0; i < totalFloors; i++)
			{
				if (i == currentFloor)
				{
					colorMatrix = new ColorMatrix(matrixItems2);

					ia.SetColorMatrix(colorMatrix);
					e.Graphics.DrawImage(floorSelector,
						new Rectangle(0, (7 + nbrBasement  - i)* 15, 24, 15), 0,
						(7 + nbrBasement - i) * 15, 24,
						15, GraphicsUnit.Pixel, ia);
				}
			}
		}

		public unsafe void dungmapBuildtileset()
		{
			byte[] staticgfx = new byte[4];

			// Main Blocksets

			for (int i = 0; i < 4; i++)
			{
				staticgfx[i] = (byte) (ZScreamer.ActiveROM[ZScreamer.ActiveOffsets.sprite_blockset_pointer + ((128 + dungmapListbox.SelectedIndex) * 4) + i] + 115);
			}

			/*
            for (int i = 0; i < 4; i++)
            {
                
            }
            */
			// NEED TO BE EXECUTED AFTER THE TILESET ARE LOADED NOT BEFORE -_-
			byte* currentmapgfx8Data = (byte*) ZScreamer.ActiveGraphicsManager.currentTileScreengfx16Ptr.ToPointer(); // Loaded gfx for the current map (empty at this point)
			byte* allgfxData = (byte*) ZScreamer.ActiveGraphicsManager.allgfx16Ptr.ToPointer(); // All gfx of the game pack of 2048 bytes (4bpp)
			
			for (int i = 0; i < 4; i++)
			{
				int i2 = i * 2048;
				int i3 = staticgfx[i] * 2048;
				for (int j = 0; j < 2048; j++)
				{
					currentmapgfx8Data[i2 + j] = allgfxData[j + i3];
				}
			}
		}

		public void AssembleMapTiles() // 186 tiles?
		{
			/*
            for (int i = 0; i < 256; i++)
            {
                Tile16 t = ZScreamer.ActiveROM.ReadTile16(0x57009 + (i * 8));
            }
            */

			dungmapBuildtileset();
			dungmapupdateTiles();
			dungmapupdateTiles16();
			ColorPalette cp = dungmaptiles8Bitmap.Palette;

			for (int i = 128; i < 256; i++)
			{
				cp.Entries[i] = currentPalette[i];
			}

			for (int i = 0; i < 80; i++)
			{
				cp.Entries[i + 32] = ((i % 16) == 0) ?
					Color.Transparent :
					ZScreamer.ActiveROM.Read16(0xDE544 + (i * 2)).ToColor();
			}

			dungmaptiles8Bitmap.Palette = cp;
			dungmaptiles16Bitmap.Palette = cp;

			dungmaptilesPicturebox.Refresh();
			dungmaproomgfxPicturebox.Refresh();
		}

		public unsafe void dungmapupdateTiles()
		{
			byte p;

			p = 4;
			byte* destPtr = (byte*) dungmaptiles8Ptr.ToPointer();
			byte* srcPtr = (byte*) ZScreamer.ActiveGraphicsManager.currentTileScreengfx16Ptr.ToPointer();
			int xx = 0;
			int yy = 0;

			for (int i = 0; i < 256; i++)
			{
				for (int y = 0; y < 8; y++)
				{
					CopyTile(0, y, xx, yy, i, p, destPtr, srcPtr);
					CopyTile(1, y, xx, yy, i, p, destPtr, srcPtr);
					CopyTile(2, y, xx, yy, i, p, destPtr, srcPtr);
					CopyTile(3, y, xx, yy, i, p, destPtr, srcPtr);
				}

				xx += 8;
				if (xx >= 128)
				{
					yy += 1024;
					xx = 0;
				}
			}
		}

		public unsafe void dungmapupdateTiles16()
		{
			byte* destPtr = (byte*) dungmaptiles16Ptr.ToPointer();
			byte* srcPtr = (byte*) ZScreamer.ActiveGraphicsManager.currentTileScreengfx16Ptr.ToPointer();
			int xx = 0;
			int yy = 0;

			for (int i = 0; i < (186 * 8); i += 8) // 372 tiles / 2 because we'll do 2 tile at once
			{
				int addr = ZScreamer.ActiveOffsets.dungeonMap_tile16;
				if (ZScreamer.ActiveROM[ZScreamer.ActiveOffsets.dungeonMap_expCheck] != 0xB9)
				{
					addr = ZScreamer.ActiveOffsets.dungeonMap_tile16Exp;
				}

				Tile t1 = new Tile(ZScreamer.ActiveROM.Read16(addr + i)); // Top left
				Tile t2 = new Tile(ZScreamer.ActiveROM.Read16(addr + 2 + i)); // Top right
				Tile t3 = new Tile(ZScreamer.ActiveROM.Read16(addr + 4 + i)); // Bottom left
				Tile t4 = new Tile(ZScreamer.ActiveROM.Read16(addr + 6 + i)); // Bottom right

				for (int y = 0; y < 8; y++)
				{
					for (int x = 0; x < 4; x++)
					{
						CopyTile(x, y, xx, yy, t1.ID - 768, t1.Palette, t1.VFlip, t1.HFlip, destPtr, srcPtr);
						CopyTile(x, y, xx + 8, yy, t2.ID - 768, t2.Palette, t2.VFlip, t2.HFlip, destPtr, srcPtr);
						CopyTile(x, y, xx, yy + 2048, t3.ID - 768, t3.Palette, t3.VFlip, t3.HFlip, destPtr, srcPtr);
						CopyTile(x, y, xx + 8, yy + 2048, t4.ID - 768, t4.Palette, t4.VFlip, t4.HFlip, destPtr, srcPtr);
					}
				}

				xx += 16;
				if (xx >= 256)
				{
					yy += 4096; // Skip 2 line of tiles
					xx = 0;
				}
			}
		}

		private void dungmaptilesPicturebox_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
			e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
			e.Graphics.DrawImage(dungmaptiles8Bitmap, Constants.Rect_0_0_256_256, Constants.Rect_0_0_128_128, GraphicsUnit.Pixel);
		}

		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tabControl1.SelectedIndex == 0)
			{
				Buildtileset();
				updateTiles();
			}
			else if (tabControl1.SelectedIndex == 1)
			{
				Buildtilesetmap();
				updateTiles();
			}
			else if (tabControl1.SelectedIndex == 2)
			{
				AssembleMapTiles();
			}
		}

		private void dungmaproomgfxPicturebox_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
			e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
			e.Graphics.DrawImage(dungmaptiles16Bitmap, Constants.Rect_0_0_512_384, Constants.Rect_0_0_256_192, GraphicsUnit.Pixel);

			for (int i = 0; i < 16 * 32; i += 32)
			{
				e.Graphics.DrawLine(Constants.QuarterWhitePen, i, 0, i, 384);

				if (i < (10 * 32))
				{
					e.Graphics.DrawLine(Constants.QuarterWhitePen, 0, i, 512, i);
				}
			}
		}

		private void floorselectorPicturebox_MouseDown(object sender, MouseEventArgs e)
		{
			// TODO: Add something here?
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			currentFloor++;
			if (currentFloor >= totalFloors)
			{
				currentFloor = 0;
			}

			dungmapPicturebox.Refresh();
			floorselectorPicturebox.Refresh();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			if (currentFloor == 0)
			{
				currentFloor = (byte) (totalFloors - 1);
			}
			else
			{
				currentFloor--;
			}

			dungmapPicturebox.Refresh();
			floorselectorPicturebox.Refresh();
		}

		private void roomidshowCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			dungmapPicturebox.Refresh();
			floorselectorPicturebox.Refresh();
		}

		private void dungmaproomgfxPicturebox_MouseDown(object sender, MouseEventArgs e)
		{
			currentFloorGfx[currentFloor][dungmapSelectedTile] = (byte) ((e.Y / 32 * 16) + (e.X / 32));
			dungmapPicturebox.Refresh();
			floorselectorPicturebox.Refresh();
		}

		private void dungmapPicturebox_MouseDown(object sender, MouseEventArgs e)
		{
			dungmapSelectedTile = ((e.Y - 12) / 32 * 5) + ((e.X - 10) / 32);
			editedFromEditor = true;
			dungmaproomidTextbox.Text = currentFloorRooms[currentFloor][dungmapSelectedTile].ToString("X2");
			editedFromEditor = false;
			dungmapPicturebox.Refresh();
			floorselectorPicturebox.Refresh();
		}

		private void dungmaproomidTextbox_TextChanged(object sender, EventArgs e)
		{
			if (!editedFromEditor)
			{
				if (int.TryParse(dungmaproomidTextbox.Text, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out int i))
				{
					currentFloorRooms[currentFloor][dungmapSelectedTile] = (byte) i;
				}
				else
				{
					currentFloorRooms[currentFloor][dungmapSelectedTile] = 0x0F;
				}
				currentDungeonChanged = true;

				dungmapPicturebox.Refresh();
				floorselectorPicturebox.Refresh();
			}
		}

		private void dungmapbossTextbox_TextChanged(object sender, EventArgs e)
		{
			if (!editedFromEditor)
			{
				if (int.TryParse(dungmapbossTextbox.Text, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out int i))
				{
					dungmaps[dungmapListbox.SelectedIndex].bossRoom = bossRoom = (byte) i;
				}
				else
				{
					dungmaps[dungmapListbox.SelectedIndex].bossRoom = bossRoom = BossRoomNull;
				}

				dungmapPicturebox.Refresh();
				floorselectorPicturebox.Refresh();
			}
		}

		// TODO so many magic numbers
		public void dungmapSaveAllCurrentDungeon()
		{
			if (ZScreamer.ActiveROM[ZScreamer.ActiveOffsets.dungeonMap_expCheck] == 0xB9)
			{
				for (int i = 0; i < (372 * 4); i++)
				{
					//ZScreamer.ActiveROM.DATA[ZScreamer.ActiveOffsets.dungeonMap_tile16Exp + i] = ZScreamer.ActiveROM.DATA[ZScreamer.ActiveOffsets.dungeonMap_tile16 + i];
					ZScreamer.ActiveROM[ZScreamer.ActiveOffsets.dungeonMap_tile16Exp + i] = ZScreamer.ActiveROM[ZScreamer.ActiveOffsets.dungeonMap_tile16 + i];
				}

				// Replace all these address by JSRs
				// 0x56652
				// 0x566B6
				// 0x5671A
				// 0x5677E

				// TODO add to resources
				string expAsm =	@"
					org $0AE652
					JSR Load1
					org $0AE6B6
					JSR Load2
					org $0AE71A
					JSR Load3
					org $0AE77E
					JSR Load4
					org $219010
					NewTile16:
					org $0AF009
					Load1:
					PHX
					TYX
					LDA.l NewTile16, X
					TXY
					PLX
					RTS
					Load2:
					PHX
					TYX
					LDA.l NewTile16+2, X
					TXY
					PLX
					RTS
					Load3:
					PHX
					TYX
					LDA.l NewTile16+4, X
					TXY
					PLX
					RTS
					Load4:
					PHX
					TYX
					LDA.l NewTile16+6, X
					TXY
					PLX
					RTS"; // 48 bytes

				File.WriteAllText("tempPatch.asm", expAsm);
				ZScreamer.ActiveROM.ApplyPatch("tempPatch.asm");

			}

			// dungeonMap_rooms_ptr

			int pos = ZScreamer.ActiveOffsets.dungeonMap_datastart;

			for (int d = 0; d < 14; d++) // For all dungeons !
			{
				// Needs to write floors data
				ZScreamer.ActiveROM.Write16(ZScreamer.ActiveOffsets.dungeonMap_floors + (d * 2), (dungmaps[d].nbrOfFloor << 4) | dungmaps[d].nbrOfBasement);
				ZScreamer.ActiveROM.Write16(ZScreamer.ActiveOffsets.dungeonMap_bossrooms + (d * 2), dungmaps[d].bossRoom);

				bool searchBoss = true;
				if (dungmaps[d].bossRoom == BossRoomNull)
				{
					ZScreamer.ActiveROM.Write16(0x56E79 + (d * 2), 0xFFFF);
					searchBoss = false;
				}

				// Write that dungeon pointer
				ZScreamer.ActiveROM.Write16(ZScreamer.ActiveOffsets.dungeonMap_rooms_ptr + (d * 2), pos.PCtoSNES());

				for (int f = 0; f < dungmaps[d].nbrOfFloor + dungmaps[d].nbrOfBasement; f++) // For all floors in that dungeon
				{
					for (int r = 0; r < 25; r++) // For all rooms on that floor
					{
						if (searchBoss && dungmaps[d].bossRoom == dungmaps[d].FloorRooms[f][r])
						{
							ZScreamer.ActiveROM.Write16(0x56E79 + (d * 2), f);
							searchBoss = false;
						}

						ZScreamer.ActiveROM[pos++] = dungmaps[d].FloorRooms[f][r];

						if (pos >= 0x575D9 && pos <= 0x57620)
						{
							pos = 0x57621;
							f = 50; // Restart the room since it was in reserved space
							d -= 1;
							searchBoss = false;

							break;
						}
					}
				}

				// When it is done with the floors ROOMS do the gfx

				// Write that dungeon gfx pointer
				ZScreamer.ActiveROM.Write16(ZScreamer.ActiveOffsets.dungeonMap_gfx_ptr + (d * 2), pos.PCtoSNES());
				for (int f = 0; f < dungmaps[d].nbrOfFloor + dungmaps[d].nbrOfBasement; f++) // For all floors in that dungeon
				{
					for (int r = 0; r < 25; r++) // For all rooms on that floor
					{
						if (dungmaps[d].FloorGfx[f][r] != 0xFF)
						{
							//ZScreamer.ActiveROM.DATA[pos] = dungmaps[d].FloorGfx[f][r];
							ZScreamer.ActiveROM[pos++] = dungmaps[d].FloorGfx[f][r];

							if (pos >= 0x575D9 && pos <= 0x57620)
							{
								pos = 0x57621;
								ZScreamer.ActiveROM.Write16(ZScreamer.ActiveOffsets.dungeonMap_gfx_ptr + (d * 2), pos.PCtoSNES());
								f = 50; // Restart the room since it was in reserved space
								d--;
								searchBoss = false;

								break;
							}
						}
					}
				}

				// Protection here if we're over pointers location we need to decrease loop by one and continue further
				if (pos >= 0x57CE0) // We reached the limit uh oh
				{
					throw new ZeldaException("too many maps or something");
				}

				if (searchBoss)
				{
					throw new ZeldaException($"One of the boss room in the dungeon map editor can't be found in dungeon id {d:X2}");
				}
			}
		}

		public void shiftAllGfx()
		{
			//int nbrBasementShift = (byte) (ZScreamer.ActiveROM.ReadShort(ZScreamer.ActiveOffsets.dungeonMap_floors + (dungmapListbox.SelectedIndex * 2)) & 0xF);
			//int nbrFloorShift = (byte) ((ZScreamer.ActiveROM.ReadShort(ZScreamer.ActiveOffsets.dungeonMap_floors + (dungmapListbox.SelectedIndex * 2)) & 0xF0) >> 4);
		}

		private void dungmapaddfloorButton_Click(object sender, EventArgs e)
		{
			if (dungmaps[dungmapListbox.SelectedIndex].nbrOfFloor >= 8)
			{
				return;
			}

			byte[] rdata = new byte[Constants.RoomsPerFloorOnMap];
			byte[] gdata = new byte[Constants.RoomsPerFloorOnMap];
			for (int i = 0; i < Constants.RoomsPerFloorOnMap; i++)
			{
				rdata[i] = (byte) BossRoomNull;
				gdata[i] = 0xFF;
			}

			dungmaps[dungmapListbox.SelectedIndex].FloorRooms.Add(rdata);
			dungmaps[dungmapListbox.SelectedIndex].FloorGfx.Add(gdata);
			currentFloor = 0;
			dungmaps[dungmapListbox.SelectedIndex].nbrOfFloor++;
			updateDungMap();
		}

		private void button6_Click_1(object sender, EventArgs e)
		{
			OpenFileDialog of = new OpenFileDialog();

			if (of.ShowDialog() == DialogResult.OK)
			{
				FileStream fs = new FileStream(of.FileName, FileMode.Open, FileAccess.Read);

				fs.Read(ZScreamer.ActiveROM.DataStream, 0, (int) fs.Length);

				fs.Close();
			}

			//Constants.Init_Jp();
			//ZScreamer.ActiveGraphicsManager.CreateAllGfxData();
			Buildtileset();
			LoadTitleScreen(true);
		}

		// TODO merge into add room above
		private void dungmapaddbaseButton_Click(object sender, EventArgs e)
		{
			if (dungmaps[dungmapListbox.SelectedIndex].nbrOfBasement >= 8)
			{
				return;
			}

			byte[] rdata = new byte[Constants.RoomsPerFloorOnMap];
			byte[] gdata = new byte[Constants.RoomsPerFloorOnMap];

			for (int i = 0; i < 25; i++)
			{
				rdata[i] = 0x0F;
				gdata[i] = 0xFF;
			}

			dungmaps[dungmapListbox.SelectedIndex].FloorRooms.Insert(0, rdata);
			dungmaps[dungmapListbox.SelectedIndex].FloorGfx.Insert(0, gdata);
			currentFloor = 0;
			dungmaps[dungmapListbox.SelectedIndex].nbrOfBasement++;
			updateDungMap();
		}

		private void dungmaprembaseButton_Click(object sender, EventArgs e)
		{
			if (dungmaps[dungmapListbox.SelectedIndex].nbrOfBasement == 0)
			{
				return;
			}

			dungmaps[dungmapListbox.SelectedIndex].FloorRooms.RemoveAt(0);
			dungmaps[dungmapListbox.SelectedIndex].FloorGfx.RemoveAt(0);
			dungmaps[dungmapListbox.SelectedIndex].nbrOfBasement--;
			updateDungMap();
		}

		private void dungmapremfloorButton_Click(object sender, EventArgs e)
		{
			if (dungmaps[dungmapListbox.SelectedIndex].nbrOfFloor == 0)
			{
				return;
			}

			dungmaps[dungmapListbox.SelectedIndex].FloorRooms.RemoveAt(dungmaps[dungmapListbox.SelectedIndex].FloorRooms.Count - 1);
			dungmaps[dungmapListbox.SelectedIndex].FloorGfx.RemoveAt(dungmaps[dungmapListbox.SelectedIndex].FloorGfx.Count - 1);
			dungmaps[dungmapListbox.SelectedIndex].nbrOfFloor--;
			updateDungMap();
		}

		private void button8_Click(object sender, EventArgs e)
		{

			for (int i = 0; i < Constants.RoomsPerFloorOnMap; i++)
			{
				copiedDataRooms[i] = dungmaps[dungmapListbox.SelectedIndex].FloorRooms[currentFloor][i];
				copiedDataGfx[i] = dungmaps[dungmapListbox.SelectedIndex].FloorGfx[currentFloor][i];
			}

			updateDungMap();
		}

		private void button9_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < Constants.RoomsPerFloorOnMap; i++)
			{
				dungmaps[dungmapListbox.SelectedIndex].FloorRooms[currentFloor][i] = copiedDataRooms[i];
				dungmaps[dungmapListbox.SelectedIndex].FloorGfx[currentFloor][i] = copiedDataGfx[i];
			}

			updateDungMap();
		}

		private void button10_Click(object sender, EventArgs e)
		{
			/*
            if (File.Exists("temp.sfc"))
            {
                File.Delete("temp.sfc");
            }

            dungmapSaveAllCurrentDungeon();

            FileStream fs = new FileStream("temp.sfc", FileMode.OpenOrCreate, FileAccess.Write);
            fs.Write(ZScreamer.ActiveROM.DATA, 0, ZScreamer.ActiveROM.DATA.Length);
            fs.Close();
            Process p = Process.Start("temp.sfc");
            */
		}

		private void mapPicturebox_MouseDown(object sender, MouseEventArgs e)
		{
			selectedMapIcon = null;
			mxClick = (e.X - 256) / 2;
			myClick = (e.Y - 256) / 2;
			int id;
			for (id = 0; id < allMapIcons[overworldCombobox.SelectedIndex].Count; id++)
			{
				MapIcon mi = allMapIcons[overworldCombobox.SelectedIndex][id];
				if (mxClick >= mi.x && (mxClick <= mi.x + 24) && (myClick >= mi.y && myClick <= mi.y + 24))
				{
					selectedMapIcon = mi;
					mxDist = mxClick - mi.x;
					myDist = myClick - mi.y;
					break;
				}
			}

			if (selectedMapIcon == null)
			{
				mapiconGroupbox.Text = "Selected Icon Properties - No icon selected";
				xiconposLabel.Text = "X Position : ";
				yiconposLabel.Text = "Y Position : ";
				editedFromEditor = true;
				gfxiconTextbox.Text = "";
				editedFromEditor = false;
			}
			else
			{
				mapiconGroupbox.Text = "Selected Icon Properties - Icon " + id;
				xiconposLabel.Text = "X Position : " + selectedMapIcon.x.ToString();
				yiconposLabel.Text = "Y Position : " + selectedMapIcon.y.ToString();
				editedFromEditor = true;
				gfxiconTextbox.Text = selectedMapIcon.gfx.ToString("X4");
				editedFromEditor = false;
			}

			mapPicturebox.Refresh();
			mouseDown = true;
		}

		private void mapPicturebox_MouseUp(object sender, MouseEventArgs e)
		{
			if (overworldCombobox.SelectedIndex == 9)
			{
				mouseDown = false;
				return;
			}

			mxClick = (e.X - 256) / 2;
			myClick = (e.Y - 256) / 2;

			if (e.Button == MouseButtons.Right)
			{
				if (mouseDown)
				{
					ContextMenu cm;
					if (selectedMapIcon != null)
					{
						cm = new ContextMenu(
							new MenuItem[]
							{
								new MenuItem("Remove Map Icon",deleteMapIcon)
						});
					}
					else
					{
						cm = new ContextMenu(
							new MenuItem[]
							{
								new MenuItem("Insert Map Icon",insertMapIcon)
						});
					}

					mouseDown = false;
					cm.Show(mapPicturebox, new Point(e.X, e.Y));
				}
			}

			mouseDown = false;
		}

		public void insertMapIcon(object sender, EventArgs e)
		{
			if (allMapIcons[overworldCombobox.SelectedIndex].Count < 8)
			{
				allMapIcons[overworldCombobox.SelectedIndex].Add(new MapIcon((ushort) mxClick, (ushort) myClick, 0));
				mapPicturebox.Refresh();
			}
			else
			{
				MessageBox.Show("Can't add more than 8 icons per event");
			}
		}

		public void deleteMapIcon(object sender, EventArgs e)
		{
			allMapIcons[overworldCombobox.SelectedIndex].Remove(selectedMapIcon);
			mapPicturebox.Refresh();
		}

		private void mapPicturebox_MouseMove(object sender, MouseEventArgs e)
		{
			if (mouseDown)
			{
				if (selectedMapIcon != null)
				{
					mxClick = (e.X - 256) / 2;
					myClick = (e.Y - 256) / 2;
					if (mxClick <= 0)
					{
						mxClick = 0;
					}
					if (myClick <= 0)
					{
						myClick = 0;
					}
					if (mxClick >= 256)
					{
						mxClick = 256;
					}
					if (myClick >= 256)
					{
						myClick = 256;
					}

					selectedMapIcon.x = (ushort) (mxClick - mxDist);
					selectedMapIcon.y = (ushort) (myClick - myDist);
					mapPicturebox.Refresh();
				}
			}
		}

		private void gfxiconTextbox_TextChanged(object sender, EventArgs e)
		{
			if (!editedFromEditor)
			{
				if (int.TryParse(gfxiconTextbox.Text, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out int i))
				{
					selectedMapIcon.gfx = (ushort) i;
				}
				else
				{
					selectedMapIcon.gfx = 0;
				}
			}
		}

		private void button11_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog
			{
				Filter = UIText.BMP8Type
			};

			if (sfd.ShowDialog() == DialogResult.OK)
			{
				ZScreamer.ActiveGraphicsManager.overworldMapBitmap.Save(sfd.FileName, ImageFormat.Bmp);
			}
		}

		private unsafe void button12_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog
			{
				Filter = UIText.BMP8Type
			};

			if (ofd.ShowDialog() == DialogResult.OK)
			{
				Bitmap b = new Bitmap(ofd.FileName);
				BitmapData bd = b.LockBits(Constants.Rect_0_0_128_128, ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
				ZScreamer.ActiveGraphicsManager.overworldMapBitmap = new Bitmap(128, 128, 128, PixelFormat.Format8bppIndexed, ZScreamer.ActiveGraphicsManager.overworldMapPointer);
				int pos = 0;

				// Mode 7
				byte* ptr = (byte*) bd.Scan0.ToPointer();

				for (int sy = 0; sy < 16 * 1024; sy += 1024)
				{
					for (int sx = 0; sx < 16 * 8; sx += 8)
					{
						for (int y = 0; y < 8 * 128; y += 128)
						{
							for (int x = 0; x < 8; x++)
							{
								ZScreamer.ActiveROM[0x0C4000 + pos] = ptr[x + sx + y + sy];
								pos++;
							}
						}
					}
				}

				b.UnlockBits(bd);

				pos = darkWorld ? 0x55C27 : 0x55B27;

				ZScreamer.ActivePaletteManager.WritePalette(pos, b.Palette.Entries, 128);
				ZScreamer.ActiveGraphicsManager.loadOverworldMap();

				owMapTilesBox.Refresh();
				mapPicturebox.Refresh();
			}
		}

		private void triforcebox1_Paint(object sender, PaintEventArgs e)
		{
			for (int i = 0; i < 6; i++)
			{
				if (triforceRadio.Checked)
				{
					e.Graphics.DrawRectangle(Pens.Yellow, new Rectangle(126 + triforceVertices[i].x, 126 + triforceVertices[i].y, 4, 4));
					if (selectedVertex == triforceVertices[i])
					{
						e.Graphics.DrawRectangle(Pens.Blue, new Rectangle(126 + triforceVertices[i].x, 126 + triforceVertices[i].y, 4, 4));
					}
				}
				else
				{
					e.Graphics.DrawRectangle(Pens.Yellow, new Rectangle(126 + crystalVertices[i].x, 126 + crystalVertices[i].y, 4, 4));
					if (selectedVertex == crystalVertices[i])
					{
						e.Graphics.DrawRectangle(Pens.Blue, new Rectangle(126 + crystalVertices[i].x, 126 + crystalVertices[i].y, 4, 4));
					}
				}
			}
		}

		private void triforcebox2_Paint(object sender, PaintEventArgs e)
		{
			for (int i = 0; i < 6; i++)
			{
				if (triforceRadio.Checked)
				{
					e.Graphics.DrawRectangle(Pens.Yellow, new Rectangle(126 + triforceVertices[i].x, 126 + triforceVertices[i].z, 4, 4));
					if (selectedVertex  == triforceVertices[i])
					{
						e.Graphics.DrawRectangle(Pens.Blue, new Rectangle(126 + triforceVertices[i].x, 126 + triforceVertices[i].z, 4, 4));
					}
				}
				else
				{
					e.Graphics.DrawRectangle(Pens.Yellow, new Rectangle(126 + crystalVertices[i].x, 126 + crystalVertices[i].z, 4, 4));
					if (selectedVertex == crystalVertices[i])
					{
						e.Graphics.DrawRectangle(Pens.Blue, new Rectangle(126 + crystalVertices[i].x, 126 + crystalVertices[i].z, 4, 4));
					}
				}
			}
		}

		private void triforcebox3_Paint(object sender, PaintEventArgs e)
		{
			for (int i = 0; i < 6; i++)
			{
				if (triforceRadio.Checked)
				{
					e.Graphics.DrawRectangle(Pens.Yellow, new Rectangle(126 + triforceVertices[i].z, 126 + triforceVertices[i].y, 4, 4));

					if (selectedVertex == triforceVertices[i])
					{
						e.Graphics.DrawRectangle(Pens.Blue, new Rectangle(126 + triforceVertices[i].z, 126 + triforceVertices[i].y, 4, 4));
					}
				}
				else
				{
					e.Graphics.DrawRectangle(Pens.Yellow, new Rectangle(126 + crystalVertices[i].z, 126 + crystalVertices[i].y, 4, 4));

					if (selectedVertex == crystalVertices[i])
					{
						e.Graphics.DrawRectangle(Pens.Blue, new Rectangle(126 + crystalVertices[i].z, 126 + crystalVertices[i].y, 4, 4));
					}
				}
			}
		}

		private void triforcebox1_MouseDown(object sender, MouseEventArgs e)
		{
			for (int i = 0; i < 6; i++)
			{
				if (triforceRadio.Checked)
				{
					//e.Graphics.DrawRectangle(Pens.Yellow, new Rectangle(126 + triforceVertices[i].z, 126 + triforceVertices[i].y, 4, 4));

					if (e.X >= triforceVertices[i].x + 124 && e.X <= triforceVertices[i].x + 130)
					{
						if (e.Y >= triforceVertices[i].y + 124 && e.Y <= triforceVertices[i].y + 130)
						{
							selectedVertex = triforceVertices[i];
						}
					}
				}
				else
				{
					//e.Graphics.DrawRectangle(Pens.Yellow, new Rectangle(126 + triforceVertices[i].z, 126 + triforceVertices[i].y, 4, 4));

					if (e.X >= crystalVertices[i].x + 124 && e.X <= crystalVertices[i].x + 130)
					{
						if (e.Y >= crystalVertices[i].y + 124 && e.Y <= crystalVertices[i].y + 130)
						{
							selectedVertex = crystalVertices[i];
						}
					}
				}
			}

			triforcebox1.Refresh();
			triforcebox2.Refresh();
			triforcebox3.Refresh();
			mdown = true;
		}

		private void triforcebox1_MouseMove(object sender, MouseEventArgs e)
		{
			if (mdown)
			{
				selectedVertex.x = (sbyte) (e.X - 128);
				selectedVertex.y = (sbyte) (e.Y - 128);
				triforcebox1.Refresh();
				triforcebox2.Refresh();
				triforcebox3.Refresh();
			}
		}

		private void triforcebox1_MouseUp(object sender, MouseEventArgs e)
		{
			mdown = false;
		}

		private void triforcebox2_MouseDown(object sender, MouseEventArgs e)
		{
			if (triforceRadio.Checked)
			{
				for (int i = 0; i < 6; i++)
				{
					//e.Graphics.DrawRectangle(Pens.Yellow, new Rectangle(126 + triforceVertices[i].z, 126 + triforceVertices[i].y, 4, 4));

					if (e.X >= triforceVertices[i].x + 124 && e.X <= triforceVertices[i].x + 130)
					{
						if (e.Y >= triforceVertices[i].z + 124 && e.Y <= triforceVertices[i].z + 130)
						{
							selectedVertex = triforceVertices[i];
						}
					}
				}
			}
			else
			{
				for (int i = 0; i < 6; i++)
				{
					//e.Graphics.DrawRectangle(Pens.Yellow, new Rectangle(126 + triforceVertices[i].z, 126 + triforceVertices[i].y, 4, 4));

					if (e.X >= crystalVertices[i].x + 124 && e.X <= crystalVertices[i].x + 130)
					{
						if (e.Y >= crystalVertices[i].z + 124 && e.Y <= crystalVertices[i].z + 130)
						{
							selectedVertex = crystalVertices[i];
						}
					}
				}
			}

			triforcebox1.Refresh();
			triforcebox2.Refresh();
			triforcebox3.Refresh();
			mdown = true;
		}

		private void triforcebox3_MouseDown(object sender, MouseEventArgs e)
		{
			for (int i = 0; i < 6; i++)
			{
				if (triforceRadio.Checked)
				{
					//e.Graphics.DrawRectangle(Pens.Yellow, new Rectangle(126 + triforceVertices[i].z, 126 + triforceVertices[i].y, 4, 4));

					if (e.X >= triforceVertices[i].z + 124 && e.X <= triforceVertices[i].z + 130)
					{
						if (e.Y >= triforceVertices[i].y + 124 && e.Y <= triforceVertices[i].y + 130)
						{
							selectedVertex = triforceVertices[i];
						}
					}
				}
				else
				{
					//e.Graphics.DrawRectangle(Pens.Yellow, new Rectangle(126 + triforceVertices[i].z, 126 + triforceVertices[i].y, 4, 4));

					if (e.X >= crystalVertices[i].z + 124 && e.X <= crystalVertices[i].z + 130)
					{
						if (e.Y >= crystalVertices[i].y + 124 && e.Y <= crystalVertices[i].y + 130)
						{
							selectedVertex = crystalVertices[i];
						}
					}
				}
			}

			triforcebox1.Refresh();
			triforcebox2.Refresh();
			triforcebox3.Refresh();
			mdown = true;
		}

		// TODO merge these and other identical events
		private void triforcebox2_MouseUp(object sender, MouseEventArgs e)
		{
			mdown = false;
		}

		private void triforcebox3_MouseUp(object sender, MouseEventArgs e)
		{
			mdown = false;
		}

		private void triforcebox2_MouseMove(object sender, MouseEventArgs e)
		{
			if (mdown)
			{
				selectedVertex.x = (sbyte) (e.X - 128);
				selectedVertex.z = (sbyte) (e.Y - 128);
				triforcebox1.Refresh();
				triforcebox2.Refresh();
				triforcebox3.Refresh();
			}
		}

		private void triforcebox3_MouseMove(object sender, MouseEventArgs e)
		{
			if (mdown)
			{
				selectedVertex.z = (sbyte) (e.X - 128);
				selectedVertex.y = (sbyte) (e.Y - 128);
				triforcebox1.Refresh();
				triforcebox2.Refresh();
				triforcebox3.Refresh();
			}
		}

		public void saveTriforce()
		{
			for (int i = 0; i < 6; i++)
			{
				ZScreamer.ActiveROM.Write(ZScreamer.ActiveOffsets.triforceVertices + (i * 3),
					(byte) triforceVertices[i].x,
					(byte) triforceVertices[i].y,
					(byte) triforceVertices[i].z
				);

				ZScreamer.ActiveROM.Write(ZScreamer.ActiveOffsets.crystalVertices + (i * 3),
					(byte) crystalVertices[i].x,
					(byte) crystalVertices[i].y,
					(byte) crystalVertices[i].z
				);
			}
		}

		private void crystalRadio_CheckedChanged(object sender, EventArgs e)
		{
			triforcebox1.Refresh();
			triforcebox2.Refresh();
			triforcebox3.Refresh();
		}
	}
}
