﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeldaFullEditor.Gui
{
	public partial class Tile16Editor : ScreamForm
	{
		ushort tile8selected = 0;
		bool fromForm = false;
		byte[] tempTiletype = new byte[0x200];

		Tile16[] allTiles = new Tile16[Constants.NumberOfMap16];

		ushort searchedTile = 0xFFFF;
		public Tile16Editor(ZScreamer zs) : base(zs)
		{
			InitializeComponent();

			panel1.VerticalScroll.SmallChange = 32;
			panel1.VerticalScroll.LargeChange = 32;
		}

		/// <summary>
		/// Called every frame? updates the appearance of the tile 8 window
		/// </summary>
		public unsafe void updateTiles()
		{
			ushort.TryParse(tileUpDown.Text, System.Globalization.NumberStyles.HexNumber, null, out ushort tempTile);

			tile8selected = tempTile;

			byte p = (byte) paletteUpDown.Value;
			byte* destPtr = (byte*) ZS.GFXManager.editort16Ptr.ToPointer();
			byte* srcPtr = (byte*) ZS.GFXManager.currentOWgfx16Ptr.ToPointer();
			int xx = 0;
			int yy = 0;

			for (int i = 0; i < 1024; i++)
			{
				for (var y = 0; y < 8; y++)
				{
					for (var x = 0; x < 4; x++)
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

			ZS.GFXManager.editort16Bitmap.Palette = ZS.OverworldManager.allmaps[ZS.OverworldScene.selectedMap].gfxBitmap.Palette;
			pictureboxTile8.Refresh();
		}

		private unsafe void CopyTile(int x, int y, int xx, int yy, int id, byte p, byte* gfx16Pointer, byte* gfx8Pointer)
		{
			int mx;
			int my = mirrorYCheckbox.Checked ? 7 - y : y;
			byte r;

			if (mirrorXCheckbox.Checked)
			{
				mx = 3 - x;
				r = 1;
			}
			else
			{
				mx = x;
				r = 0;
			}

			int tx = ((id & ~0xF) << 5) | ((id & 0xF) << 2);
			int index = xx + yy + (x * 2) + (my * 128);
			int pixel = gfx8Pointer[tx + (y * 64) + x];

			gfx16Pointer[index + r ^ 1] = (byte) ((pixel & 0x0F) | (p << 4));
			gfx16Pointer[index + r] = (byte) ((pixel >> 4) | (p << 4));
		}

		private void pictureboxTile8_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
			e.Graphics.DrawImage(ZS.GFXManager.editort16Bitmap, Constants.Rect_0_0_256_1024);

			if (gridcheckBox.Checked)
			{
				for (int xs = 0; xs < 16; xs++)
				{
					e.Graphics.DrawLine(Constants.ThirdWhitePen1, xs * 16, 0, xs * 16, 1024);

				}
				for (int ys = 0; ys < 256; ys++)
				{
					e.Graphics.DrawLine(Constants.ThirdWhitePen1, 0, ys * 16, 256, ys * 16);
				}
			}

			int y = (tile8selected / 16);
			int x = tile8selected - (y * 16);

			e.Graphics.DrawRectangle(Pens.GreenYellow, new Rectangle(x * 16, y * 16, 16, 16));
		}

		private void mirrorXCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (!fromForm)
			{
				updateTiles();
			}

			if (tile8selected >= 512)
			{
				tileTypeBox.Enabled = false;
			}
			else
			{
				tileTypeBox.Enabled = true;
				tileTypeBox.SelectedIndex = tempTiletype[tile8selected];
			}
		}

		private static readonly RectangleF RectF1 = new RectangleF(0f, 0f, 256.5f, 16000f);
		private static readonly RectangleF RectF2 = new RectangleF(0, 0, 128, 8000);
		private void pictureboxTile16_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.AssumeLinear;
			//e.Graphics.DrawImage(GFX.editortileBitmap, new Rectangle(0, 0, 64, 64));
			e.Graphics.DrawImage(ZS.GFXManager.mapblockset16Bitmap, RectF1, RectF2, GraphicsUnit.Pixel);
			//e.Graphics.DrawImage(GFX.mapblockset16Bitmap, new RectangleF(256f, 0f, 256.5f, 8000f), new RectangleF(0, 4000, 128, 4000-192), GraphicsUnit.Pixel);

			if (gridcheckBox.Checked)
			{
				for (int x = 0; x < 16; x++)
				{
					e.Graphics.DrawLine(Constants.White100Pen1, x * 32, 0, x * 32, 16000);

				}
				for (int y = 0; y < 512; y++)
				{
					e.Graphics.DrawLine(Constants.White100Pen1, 0, y * 32, 256, y * 32);
				}
			}

			int xP = (ZS.OverworldScene.selectedTile[0] % 8) * 32;
			int yP = (ZS.OverworldScene.selectedTile[0] / 8) * 32;

			if (searchedTile != 0xFFFF)
			{
				int xP2 = (searchedTile % 8) * 32;
				int yP2 = ((searchedTile / 8)) * 32;
				e.Graphics.DrawRectangle(Constants.Orange220Pen1, new Rectangle(xP2, yP2, 32, 32));
			}

			/*
            if (scene.selectedTile[0] >= 2000)
            {
                yP -= 8000;
                xP += 256;
            }
            */
			e.Graphics.DrawRectangle(Constants.Red220Pen1, new Rectangle(xP, yP, 32, 32));

			//e.Graphics.DrawLine(new Pen(Color.FromArgb(80, Color.White), 1), 32, 0, 32, 64);
			//e.Graphics.DrawLine(new Pen(Color.FromArgb(80, Color.White), 1), 0, 32, 64, 32);
		}

		/// <summary>
		/// Called when the tile 8 window is single left clicked
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pictureboxTile8_MouseDown(object sender, MouseEventArgs e)
		{
			int tid = (e.X / 16) + ((e.Y / 16) * 16);
			tileUpDown.Text = tid.ToString("X2");
			pictureboxTile8.Refresh();

			updateTiles();
		}

		/// <summary>
		/// Called when the tile 16 window is clicked
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pictureboxTile16_MouseDown(object sender, MouseEventArgs e)
		{
			int offset = (e.X < 256) ? 0 : 1992;
			int yp = e.Y;

			int t16 = offset + (e.X / 32) + ((e.Y / 32) * 8);
			int t8x = (e.X / 16) & 0x01;
			int t8y = (e.Y / 16) & 0x01;

			// When left clicked, draw the tile 8 selected in the corrisponding quadrant of the tile 16
			if (e.Button == MouseButtons.Left)
			{
				Tile t = new Tile(
					tile8selected,
					(byte) paletteUpDown.Value,
					inFrontCheckbox.Checked,
					mirrorXCheckbox.Checked,
					mirrorYCheckbox.Checked);
				if (t8x == 0 && t8y == 0)
				{
					allTiles[t16] = new Tile16(t, allTiles[t16].tile1, allTiles[t16].tile2, allTiles[t16].tile3);
				}
				else if (t8x == 1 && t8y == 0)
				{
					allTiles[t16] = new Tile16(allTiles[t16].tile0, t, allTiles[t16].tile2, allTiles[t16].tile3);
				}
				else if (t8x == 0 && t8y == 1)
				{
					allTiles[t16] = new Tile16(allTiles[t16].tile0, allTiles[t16].tile1, t, allTiles[t16].tile3);
				}
				else if (t8x == 1 && t8y == 1)
				{
					allTiles[t16] = new Tile16(allTiles[t16].tile0, allTiles[t16].tile1, allTiles[t16].tile2, t);
				}

				BuildTiles16Gfx();
				pictureboxTile16.Refresh();
			}
			// When right clicked, get the select the tile 8 from the corrisponding quadrant of the tile 16
			else
			{
				if (t8x == 0 && t8y == 0)
				{
					updateTileInfoFrom16(allTiles[t16].tile0);
				}
				else if (t8x == 1 && t8y == 0)
				{
					updateTileInfoFrom16(allTiles[t16].tile1);
				}
				else if (t8x == 0 && t8y == 1)
				{
					updateTileInfoFrom16(allTiles[t16].tile2);
				}
				else if (t8x == 1 && t8y == 1)
				{
					updateTileInfoFrom16(allTiles[t16].tile3);
				}
			}
		}

		private void updateTileInfoFrom16(in Tile t)
		{
			fromForm = true;
			tileUpDown.Text = t.ID.ToString("X2");
			paletteUpDown.Value = t.Palette;
			mirrorXCheckbox.Checked = t.HFlip;
			mirrorYCheckbox.Checked = t.VFlip;
			inFrontCheckbox.Checked = t.Priority;
			tileTypeBox.SelectedIndex = tempTiletype[t.ID];
			fromForm = false;

			updateTiles();
		}

		private unsafe void BuildTiles16Gfx()
		{
			var gfx16Data = (byte*) ZS.GFXManager.mapblockset16.ToPointer(); //(byte*)allgfx8Ptr.ToPointer();
			var gfx8Data = (byte*) ZS.GFXManager.currentOWgfx16Ptr.ToPointer(); //(byte*)allgfx16Ptr.ToPointer();
			int[] offsets = { 0, 8, 1024, 1032 };
			var yy = 0;
			var xx = 0;

			for (var i = 0; i < Constants.NumberOfMap16; i++) // Number of tiles16 3748? // its 3752
			{
				// 8x8 tile draw
				// gfx8 = 4bpp so everyting is /2
				var tiles = allTiles[i];

				for (int tile = 0; tile < 4; tile++)
				{
					Tile info = tiles[tile];
					int offset = offsets[tile];

					for (var y = 0; y < 8; y++)
					{
						for (var x = 0; x < 4; x++)
						{
							CopyTile16(x, y, xx, yy, offset, info, gfx16Data, gfx8Data);
						}
					}
				}

				xx += 16;
				if (xx >= 128)
				{
					yy += 2048;
					xx = 0;
				}
			}
		}

		private unsafe void CopyTile16(int x, int y, int xx, int yy, int offset, in Tile tile, byte* gfx16Pointer, byte* gfx8Pointer) // map,current
		{
			int mx = tile.HFlip ? 3 - x : x;
			int my = tile.VFlip ? 7 - y : y;

			int tx = (tile.ID / 16 * 512) + ((tile.ID & 0xF) * 4);
			var index = xx + yy + offset + (mx * 2) + (my * 128);
			var pixel = gfx8Pointer[tx + (y * 64) + x];

			gfx16Pointer[index + tile.HFlipByte ^ 1] = (byte) ((pixel & 0x0F) | (tile.Palette << 4));
			gfx16Pointer[index + tile.HFlipByte] = (byte) (((pixel >> 4)) |( tile.Palette << 4));
		}

		private void Tile16Editor_Load(object sender, EventArgs e)
		{
			for (int i = 0; i < 0xFF; i++)
			{
				tilesTypesNames[i] = i.ToString("X2") + " - ????";
			}

			loadTilesNames();

			for (int i = 0; i < 0x200; i++)
			{
				tempTiletype[i] = ZS.OverworldManager.allTilesTypes[i];
			}

			ZS.OverworldManager.Tile16List.CopyTo(allTiles);

			unsafe
			{
				// Update gfx to be on selected map
				byte* currentmapgfx8Data = (byte*) ZS.GFXManager.currentOWgfx16Ptr.ToPointer(); // Loaded gfx for the current map (empty at this point)
				byte* allgfxData = (byte*) ZS.GFXManager.allgfx16Ptr.ToPointer(); // All gfx of the game pack of 2048 bytes (4bpp)
				for (int i = 0; i < 16; i++)
				{
					for (int j = 0; j < 2048; j++)
					{
						byte mapByte = allgfxData[j + (ZS.OverworldManager.allmaps[ZS.OverworldScene.selectedMap].staticgfx[i] * 2048)];
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
		}

		private void button1_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < Constants.NumberOfMap16; i++)
			{
				ZS.OverworldManager.Tile16List[i] = allTiles[i];
			}

			for (int i = 0; i < 0x200; i++)
			{
				ZS.OverworldManager.allTilesTypes[i] = tempTiletype[i];
			}

			for (int i = 0; i < 159; i++)
			{
				ZS.OverworldManager.allmaps[i].needRefresh = true;
			}

			ZS.OverworldManager.allmaps[ZS.OverworldScene.selectedMap].BuildMap();
			ZS.OverworldManager.allmaps[ZS.OverworldScene.selectedMap].needRefresh = false;

			Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void tileTypeBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!fromForm)
			{
				tempTiletype[tile8selected] = (byte) tileTypeBox.SelectedIndex;
			}
		}

		// TODO for kan ah fuck
		public void loadTilesNames()
		{
			tilesTypesNames[0x00] = "0x00 - Normal tile(no interaction)";
			tilesTypesNames[0x01] = "0x01 - Blocked";
			tilesTypesNames[0x02] = "0x02 - Blocked)";
			tilesTypesNames[0x03] = "0x03 - Blocked";
			tilesTypesNames[0x04] = "0x04 - Normal? Unknown";
			tilesTypesNames[0x05] = "0x05 - Normal tile(no interaction)";
			tilesTypesNames[0x06] = "0x06 - Normal tile(no interaction)";
			tilesTypesNames[0x07] = "0x07 - Normal tile(no interaction)";

			tilesTypesNames[0x08] = "0x08 - Deep Water";
			tilesTypesNames[0x09] = "0x09 - Shallow Water";

			tilesTypesNames[0x0C] = "0x0C - Moving Floor";
			tilesTypesNames[0x0D] = "0x0D - Sprite Floor";

			tilesTypesNames[0x1C] = "0x1C - Top of in room staircase";

			tilesTypesNames[0x20] = "0x20 - Hole Tile";
			tilesTypesNames[0x22] = "0x22 - Wooden steps(slow you down)";
			tilesTypesNames[0x27] = "0x27 - (empty chest and maybe others)";

			tilesTypesNames[0x28] = "0x28 - Ledge leading up";
			tilesTypesNames[0x29] = "0x29 - Ledge leading down";
			tilesTypesNames[0x2A] = "0x2A - Ledge leading left";
			tilesTypesNames[0x2B] = "0x2B - Ledge leading right";
			tilesTypesNames[0x2C] = "0x2C - Ledge leading up + left";
			tilesTypesNames[0x2D] = "0x2D - Ledge leading down + left";
			tilesTypesNames[0x2E] = "0x2E - Ledge leading up + right";
			tilesTypesNames[0x2F] = "0x2F - Ledge leading down + right";

			tilesTypesNames[0x40] = "0x40 - Grass Tile";
			tilesTypesNames[0x44] = "0x44 - Cactus Tile";
			tilesTypesNames[0x48] = "0x48 - aftermath tiles of picking things up?";
			tilesTypesNames[0x4A] = "0x4A - aftermath tiles of picking things up?";
			tilesTypesNames[0x4B] = "0x4B - Warp Tile";
			tilesTypesNames[0x4C] = "0x4C - Certain mountain tiles?";
			tilesTypesNames[0x4D] = "0x4D - Certain mountain tiles?";
			tilesTypesNames[0x4E] = "0x4E - Certain mountain tiles?";
			tilesTypesNames[0x4F] = "0x4F - Certain mountain tiles?";


			tilesTypesNames[0x50] = "0x50 - bush";
			tilesTypesNames[0x51] = "0x51 - off color bush";
			tilesTypesNames[0x52] = "0x52 - small light rock";
			tilesTypesNames[0x53] = "0x53 - small heavy rock";
			tilesTypesNames[0x54] = "0x54 - sign";
			tilesTypesNames[0x55] = "0x55 - large light rock";
			tilesTypesNames[0x56] = "0x56 - large heavy rock";

			tilesTypesNames[0x58] = "0x58 - Chest block";
			tilesTypesNames[0x59] = "0x59 - Chest block";
			tilesTypesNames[0x5A] = "0x5A - Chest block";
			tilesTypesNames[0x5B] = "0x5B - Chest block";
			tilesTypesNames[0x5C] = "0x5C - Chest block";
			tilesTypesNames[0x5D] = "0x5D - Chest block";

			tilesTypesNames[0x63] = "0x63 - Minigame chest tile";
			tilesTypesNames[0xB0] = "0xB0 - Hole Tile or Somaria?";

			tilesTypesNames[0xC0] = "0xC0 - Torch";
			tilesTypesNames[0xC1] = "0xC1 - Torch";
			tilesTypesNames[0xC2] = "0xC2 - Torch";
			tilesTypesNames[0xC3] = "0xC3 - Torch";
			tilesTypesNames[0xC4] = "0xC4 - Torch";
			tilesTypesNames[0xC5] = "0xC5 - Torch";
			tilesTypesNames[0xC6] = "0xC6 - Torch";
			tilesTypesNames[0xC7] = "0xC7 - Torch";
			tilesTypesNames[0xC8] = "0xC8 - Torch";
			tilesTypesNames[0xC9] = "0xC9 - Torch";
			tilesTypesNames[0xCA] = "0xCA - Torch";
			tilesTypesNames[0xCB] = "0xCB - Torch";
			tilesTypesNames[0xCC] = "0xCC - Torch";
			tilesTypesNames[0xCD] = "0xCD - Torch";
			tilesTypesNames[0xCE] = "0xCE - Torch";
			tilesTypesNames[0xCF] = "0xCF - Torch";

			tilesTypesNames[0xF0] = "0xF0 - Key door 1";
			tilesTypesNames[0xF1] = "0xF1 - Key door 2";

			tileTypeBox.Items.Clear();
			tileTypeBox.Items.AddRange(tilesTypesNames);
		}

		// TODO switch to entities.cs version, etc
		string[] tilesTypesNames = new string[0xFF];

		private void gridcheckBox_CheckedChanged(object sender, EventArgs e)
		{
			pictureboxTile16.Refresh();
			pictureboxTile8.Refresh();
		}

		private void pictureboxTile8_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			ZS.MainForm.editorsTabControl.SelectedIndex = 2;
			ZS.MainForm.gfxEditor.selectedSheet = ZS.OverworldManager.allmaps[ZS.OverworldScene.selectedMap].staticgfx[(e.Y / 64)];
			ZS.MainForm.gfxEditor.allgfxPicturebox.Refresh();
			this.Close();
		}

		private void Tile16Editor_Shown(object sender, EventArgs e)
		{
			panel1.VerticalScroll.Value = ((ZS.OverworldScene.selectedTile[0] / 8) * 32);
			panel1.PerformLayout();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			ushort.TryParse(tile16searchTextbox.Text, System.Globalization.NumberStyles.HexNumber, null, out searchedTile);
			panel1.VerticalScroll.Value = searchedTile / 8 * 32;
			panel1.PerformLayout();
		}
	}
}
