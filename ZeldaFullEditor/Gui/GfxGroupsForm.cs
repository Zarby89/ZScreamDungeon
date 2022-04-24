using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeldaFullEditor.Gui
{
	public partial class GfxGroupsForm : Panel
	{

		public bool editedFromForm = false;
		public static byte[][] tempmainGfx = new byte[37][];
		public static byte[][] temproomGfx = new byte[82][];
		public static byte[][] tempspriteGfx = new byte[144][];
		public static byte[][] temppaletteGfx = new byte[72][];

		Color[] palettes = new Color[256];

		private readonly ZScreamer ZS;
		public GfxGroupsForm(ZScreamer zs)
		{
			InitializeComponent();
			ZS = zs;
			this.BackColor = Color.FromKnownColor(KnownColor.Control);
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("This will restore groups to the previously applied changes\r\n" +
				"Are you sure you want to restore Gfx Groups?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				LoadTempGfx();
				okButton_Click(null, e);
				reloadGfx();
				ZS.UnderworldScene.Room.reloadGfx();
				ZS.UnderworldScene.NeedsRefreshing = true;
			}
		}

		private void GfxGroupsForm_Load(object sender, EventArgs e)
		{
			// TODO: Add something here?
		}

		public void CreateTempGfx()
		{
			for (int i = 0; i < 37; i++)
			{
				tempmainGfx[i] = new byte[8];
				for (int j = 0; j < 8; j++)
				{
					tempmainGfx[i][j] = ZS.GFXGroups.mainGfx[i][j];
				}
			}

			for (int i = 0; i < 82; i++)
			{
				temproomGfx[i] = new byte[4];
				for (int j = 0; j < 4; j++)
				{
					temproomGfx[i][j] = ZS.GFXGroups.roomGfx[i][j];
				}
			}

			for (int i = 0; i < 144; i++)
			{
				tempspriteGfx[i] = new byte[4];
				for (int j = 0; j < 4; j++)
				{
					tempspriteGfx[i][j] = ZS.GFXGroups.spriteGfx[i][j];
				}
			}

			for (int i = 0; i < 72; i++)
			{
				temppaletteGfx[i] = new byte[4];
				for (int j = 0; j < 4; j++)
				{
					temppaletteGfx[i][j] = ZS.GFXGroups.paletteGfx[i][j];
				}
			}
		}

		private void LoadTempGfx()
		{
			editedFromForm = true;
			main1Box.Text = tempmainGfx[(int) mainBlocksetUpDown.Value][0].ToString("X2");
			main2Box.Text = tempmainGfx[(int) mainBlocksetUpDown.Value][1].ToString("X2");
			main3Box.Text = tempmainGfx[(int) mainBlocksetUpDown.Value][2].ToString("X2");
			main4Box.Text = tempmainGfx[(int) mainBlocksetUpDown.Value][3].ToString("X2");
			main5Box.Text = tempmainGfx[(int) mainBlocksetUpDown.Value][4].ToString("X2");
			main6Box.Text = tempmainGfx[(int) mainBlocksetUpDown.Value][5].ToString("X2");
			main7Box.Text = tempmainGfx[(int) mainBlocksetUpDown.Value][6].ToString("X2");
			main8Box.Text = tempmainGfx[(int) mainBlocksetUpDown.Value][7].ToString("X2");

			room1Box.Text = temproomGfx[(int) roomUpDown.Value][0].ToString("X2");
			room2Box.Text = temproomGfx[(int) roomUpDown.Value][1].ToString("X2");
			room3Box.Text = temproomGfx[(int) roomUpDown.Value][2].ToString("X2");
			room4Box.Text = temproomGfx[(int) roomUpDown.Value][3].ToString("X2");

			sprite1Box.Text = tempspriteGfx[(int) spriteUpDown.Value][0].ToString("X2");
			sprite2Box.Text = tempspriteGfx[(int) spriteUpDown.Value][1].ToString("X2");
			sprite3Box.Text = tempspriteGfx[(int) spriteUpDown.Value][2].ToString("X2");
			sprite4Box.Text = tempspriteGfx[(int) spriteUpDown.Value][3].ToString("X2");

			palette1Box.Text = temppaletteGfx[(int) paletteUpDown.Value][0].ToString("X2");
			palette2Box.Text = temppaletteGfx[(int) paletteUpDown.Value][1].ToString("X2");
			palette3Box.Text = temppaletteGfx[(int) paletteUpDown.Value][2].ToString("X2");
			palette4Box.Text = temppaletteGfx[(int) paletteUpDown.Value][3].ToString("X2");
			editedFromForm = false;
		}

		private void LoadGfx()
		{
			editedFromForm = true;
			main1Box.Text = ZS.GFXGroups.mainGfx[(int) mainBlocksetUpDown.Value][0].ToString("X2");
			main2Box.Text = ZS.GFXGroups.mainGfx[(int) mainBlocksetUpDown.Value][1].ToString("X2");
			main3Box.Text = ZS.GFXGroups.mainGfx[(int) mainBlocksetUpDown.Value][2].ToString("X2");
			main4Box.Text = ZS.GFXGroups.mainGfx[(int) mainBlocksetUpDown.Value][3].ToString("X2");
			main5Box.Text = ZS.GFXGroups.mainGfx[(int) mainBlocksetUpDown.Value][4].ToString("X2");
			main6Box.Text = ZS.GFXGroups.mainGfx[(int) mainBlocksetUpDown.Value][5].ToString("X2");
			main7Box.Text = ZS.GFXGroups.mainGfx[(int) mainBlocksetUpDown.Value][6].ToString("X2");
			main8Box.Text = ZS.GFXGroups.mainGfx[(int) mainBlocksetUpDown.Value][7].ToString("X2");

			room1Box.Text = ZS.GFXGroups.roomGfx[(int) roomUpDown.Value][0].ToString("X2");
			room2Box.Text = ZS.GFXGroups.roomGfx[(int) roomUpDown.Value][1].ToString("X2");
			room3Box.Text = ZS.GFXGroups.roomGfx[(int) roomUpDown.Value][2].ToString("X2");
			room4Box.Text = ZS.GFXGroups.roomGfx[(int) roomUpDown.Value][3].ToString("X2");

			sprite1Box.Text = ZS.GFXGroups.spriteGfx[(int) spriteUpDown.Value][0].ToString("X2");
			sprite2Box.Text = ZS.GFXGroups.spriteGfx[(int) spriteUpDown.Value][1].ToString("X2");
			sprite3Box.Text = ZS.GFXGroups.spriteGfx[(int) spriteUpDown.Value][2].ToString("X2");
			sprite4Box.Text = ZS.GFXGroups.spriteGfx[(int) spriteUpDown.Value][3].ToString("X2");

			palette1Box.Text = ZS.GFXGroups.paletteGfx[(int) paletteUpDown.Value][0].ToString("X2");
			palette2Box.Text = ZS.GFXGroups.paletteGfx[(int) paletteUpDown.Value][1].ToString("X2");
			palette3Box.Text = ZS.GFXGroups.paletteGfx[(int) paletteUpDown.Value][2].ToString("X2");
			palette4Box.Text = ZS.GFXGroups.paletteGfx[(int) paletteUpDown.Value][3].ToString("X2");
			editedFromForm = false;
		}

		private void main1Box_TextChanged(object sender, EventArgs e)
		{
			// TODO: Add something here?
		}

		private byte getTextBoxValue(TextBox tb) // Changed to hex
		{
			byte.TryParse(tb.Text, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out byte r);
			return r;
		}

		private void allBox_TextChanged(object sender, EventArgs e)
		{
			if (!editedFromForm)
			{
				ZS.GFXGroups.mainGfx[(int) mainBlocksetUpDown.Value][0] = getTextBoxValue(main1Box);
				ZS.GFXGroups.mainGfx[(int) mainBlocksetUpDown.Value][1] = getTextBoxValue(main2Box);
				ZS.GFXGroups.mainGfx[(int) mainBlocksetUpDown.Value][2] = getTextBoxValue(main3Box);
				ZS.GFXGroups.mainGfx[(int) mainBlocksetUpDown.Value][3] = getTextBoxValue(main4Box);
				ZS.GFXGroups.mainGfx[(int) mainBlocksetUpDown.Value][4] = getTextBoxValue(main5Box);
				ZS.GFXGroups.mainGfx[(int) mainBlocksetUpDown.Value][5] = getTextBoxValue(main6Box);
				ZS.GFXGroups.mainGfx[(int) mainBlocksetUpDown.Value][6] = getTextBoxValue(main7Box);
				ZS.GFXGroups.mainGfx[(int) mainBlocksetUpDown.Value][7] = getTextBoxValue(main8Box);

				ZS.GFXGroups.roomGfx[(int) roomUpDown.Value][0] = getTextBoxValue(room1Box);
				ZS.GFXGroups.roomGfx[(int) roomUpDown.Value][1] = getTextBoxValue(room2Box);
				ZS.GFXGroups.roomGfx[(int) roomUpDown.Value][2] = getTextBoxValue(room3Box);
				ZS.GFXGroups.roomGfx[(int) roomUpDown.Value][3] = getTextBoxValue(room4Box);

				ZS.GFXGroups.spriteGfx[(int) spriteUpDown.Value][0] = getTextBoxValue(sprite1Box);
				ZS.GFXGroups.spriteGfx[(int) spriteUpDown.Value][1] = getTextBoxValue(sprite2Box);
				ZS.GFXGroups.spriteGfx[(int) spriteUpDown.Value][2] = getTextBoxValue(sprite3Box);
				ZS.GFXGroups.spriteGfx[(int) spriteUpDown.Value][3] = getTextBoxValue(sprite4Box);

				ZS.GFXGroups.paletteGfx[(int) paletteUpDown.Value][0] = getTextBoxValue(palette1Box);
				ZS.GFXGroups.paletteGfx[(int) paletteUpDown.Value][1] = getTextBoxValue(palette2Box);
				ZS.GFXGroups.paletteGfx[(int) paletteUpDown.Value][2] = getTextBoxValue(palette3Box);
				ZS.GFXGroups.paletteGfx[(int) paletteUpDown.Value][3] = getTextBoxValue(palette4Box);

				ZS.UnderworldScene.Room.reloadGfx();
				reloadGfx();
				ZS.UnderworldScene.NeedsRefreshing = true;
			}
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			ZS.GFXGroups.mainGfx[(int) mainBlocksetUpDown.Value][0] = getTextBoxValue(main1Box);
			ZS.GFXGroups.mainGfx[(int) mainBlocksetUpDown.Value][1] = getTextBoxValue(main2Box);
			ZS.GFXGroups.mainGfx[(int) mainBlocksetUpDown.Value][2] = getTextBoxValue(main3Box);
			ZS.GFXGroups.mainGfx[(int) mainBlocksetUpDown.Value][3] = getTextBoxValue(main4Box);
			ZS.GFXGroups.mainGfx[(int) mainBlocksetUpDown.Value][4] = getTextBoxValue(main5Box);
			ZS.GFXGroups.mainGfx[(int) mainBlocksetUpDown.Value][5] = getTextBoxValue(main6Box);
			ZS.GFXGroups.mainGfx[(int) mainBlocksetUpDown.Value][6] = getTextBoxValue(main7Box);
			ZS.GFXGroups.mainGfx[(int) mainBlocksetUpDown.Value][7] = getTextBoxValue(main8Box);

			ZS.GFXGroups.roomGfx[(int) roomUpDown.Value][0] = getTextBoxValue(room1Box);
			ZS.GFXGroups.roomGfx[(int) roomUpDown.Value][1] = getTextBoxValue(room2Box);
			ZS.GFXGroups.roomGfx[(int) roomUpDown.Value][2] = getTextBoxValue(room3Box);
			ZS.GFXGroups.roomGfx[(int) roomUpDown.Value][3] = getTextBoxValue(room4Box);

			ZS.GFXGroups.spriteGfx[(int) spriteUpDown.Value][0] = getTextBoxValue(sprite1Box);
			ZS.GFXGroups.spriteGfx[(int) spriteUpDown.Value][1] = getTextBoxValue(sprite2Box);
			ZS.GFXGroups.spriteGfx[(int) spriteUpDown.Value][2] = getTextBoxValue(sprite3Box);
			ZS.GFXGroups.spriteGfx[(int) spriteUpDown.Value][3] = getTextBoxValue(sprite4Box);

			ZS.GFXGroups.paletteGfx[(int) paletteUpDown.Value][0] = getTextBoxValue(palette1Box);
			ZS.GFXGroups.paletteGfx[(int) paletteUpDown.Value][1] = getTextBoxValue(palette2Box);
			ZS.GFXGroups.paletteGfx[(int) paletteUpDown.Value][2] = getTextBoxValue(palette3Box);
			ZS.GFXGroups.paletteGfx[(int) paletteUpDown.Value][3] = getTextBoxValue(palette4Box);

			CreateTempGfx();
		}

		private void GfxGroupsForm_Shown(object sender, EventArgs e)
		{
			// TODO: Add something here?
		}

		private void blocksetchanged(object sender, EventArgs e)
		{
			LoadGfx();
			reloadGfx();
		}

		private void allbox_click(object sender, EventArgs e)
		{
			// TODO: Add something here?
			//(sender as TextBox).SelectionStart = (sender as TextBox).Text.Length;
		}

		public void reloadGfx()
		{
			bool main = false;
			byte[] blocks = new byte[8];

			for (int i = 0; i < 8; i++)
			{
				blocks[i] = 0;
			}

			if (tabControl1.SelectedIndex == 0) // Main 
			{
				main = true;
				byte blockset = (byte) mainBlocksetUpDown.Value;

				for (int i = 0; i < 8; i++)
				{
					blocks[i] = ZS.GFXGroups.mainGfx[blockset][i];
				}
			}

			if (tabControl1.SelectedIndex == 1) // Room ?
			{
				byte blockset = (byte) roomUpDown.Value;

				for (int i = 0; i < 4; i++)
				{
					blocks[i] = ZS.GFXGroups.roomGfx[blockset][i];
				} // 12-16 sprites
			}

			if (tabControl1.SelectedIndex == 2) // Room ?
			{
				byte blockset = (byte) spriteUpDown.Value;

				for (int i = 0; i < 4; i++)
				{
					blocks[i] = (byte) (ZS.GFXGroups.spriteGfx[blockset][i] + 115);
				} // 12-16 sprites
			}

			unsafe
			{
				byte* newPdata = (byte*) ZS.GFXManager.allgfx16Ptr.ToPointer(); // Turn gfx16 (all 222 of them)
				byte* sheetsData = (byte*) ZS.GFXManager.currentEditinggfx16Ptr.ToPointer(); // Into "room gfx16" 16 of them
				int sheetPos = 0;

				for (int i = 0; i < 8; i++)
				{
					int d = 0;
					while (d < 2048)
					{
						// NOTE LOAD BLOCKSETS SOMEWHERE FIRST
						byte mapByte = newPdata[d + (blocks[i] * 2048)];
						if (main)
						{
							if (i < 4)
							{
								mapByte += 0x88;
							} // Last line of 6, first line of 7 ?
						}

						sheetsData[d + (sheetPos * 2048)] = mapByte;
						d++;
					}

					sheetPos++;
				}
			}

			pictureBox1.Refresh();
			pictureBox2.Refresh();
			pictureBox3.Refresh();
			pictureBox4.Refresh();
		}

		private void allpreviewPaint(object sender, PaintEventArgs e)
		{
			if (grayscaleRadioButton.Checked)
			{
				ColorPalette cp = ZS.GFXManager.currentEditingfx16Bitmap.Palette;
				for (int i = 0; i < 16; i++)
				{
					cp.Entries[i] = Color.FromArgb(i * 15, i * 15, i * 15);
				}

				ZS.GFXManager.currentEditingfx16Bitmap.Palette = cp;
			}
			else if (paletteRadioButton.Checked)
			{
				ColorPalette cp = ZS.GFXManager.currentEditingfx16Bitmap.Palette;
				for (int i = 0; i < 16; i++)
				{
					cp.Entries[i] = palettes[i + ((int) numericUpDown1.Value * 16)];
				}

				ZS.GFXManager.currentEditingfx16Bitmap.Palette = cp;
			}

			e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			e.Graphics.DrawImage(ZS.GFXManager.currentEditingfx16Bitmap, 0, 0);
		}

		private void palettepreviewPaint(object sender, PaintEventArgs e)
		{
			createPalette();

			e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			for (int i = 0; i < 256; i++)
			{
				e.Graphics.FillRectangle(new SolidBrush(palettes[i]), new Rectangle(((i % 16) * 8), (i / 16) * 8, 8, 8));
			}
		}

		private void createPalette()
		{

			for (int i = 0; i < 256; i++)
			{
				palettes[i] = Color.Black;
			}

			if (paletteUpDown.Value <= 40)
			{
				label9.Text = "Dungeon Main";
				label10.Text = "Dungeon Sprite Pal1";
				label11.Text = "Dungeon Sprite Pal2";
				label12.Text = "Dungeon Sprite Pal3";

				byte dungeon_palette_ptr = ZS.GFXGroups.paletteGfx[(byte) paletteUpDown.Value][0];
				ushort palette_pos;
				int pId;
				int pPos = 32;

				if (ZS.GFXGroups.paletteGfx[(byte) paletteUpDown.Value][0] % 2 == 0)
				{
					palette_pos = ZS.ROM.Read16(0xDEC4B + dungeon_palette_ptr);
					pId = (palette_pos / 180);

					for (int i = 0; i < 90; i++)
					{
						if (pPos % 16 == 0)
						{
							pPos++;
						}

						if (pId < ZS.PaletteManager.UnderworldMain.Length)
						{
							palettes[pPos] = ZS.PaletteManager.UnderworldMain[pId][i];
						}

						pPos++;
					}
				}

				pPos = 128;
				if (ZS.GFXGroups.paletteGfx[(int) paletteUpDown.Value][1] != 255)
				{
					for (int i = 0; i < 7; i++)
					{
						if (pPos % 16 == 0)
						{
							pPos++;
						}

						if (ZS.GFXGroups.paletteGfx[(int) paletteUpDown.Value][1] < ZS.PaletteManager.SpriteAux1.Length)
						{
							palettes[pPos++] = ZS.PaletteManager.SpriteAux1[ZS.GFXGroups.paletteGfx[(int) paletteUpDown.Value][1]][i];
						}
					}
				}

				pPos = 208;
				if (ZS.GFXGroups.paletteGfx[(int) paletteUpDown.Value][2] != 255)
				{
					for (int i = 0; i < 7; i++)
					{
						if (pPos % 16 == 0)
						{
							pPos++;
						}

						if (ZS.GFXGroups.paletteGfx[(int) paletteUpDown.Value][2] < ZS.PaletteManager.SpriteAux3.Length)
						{
							palettes[pPos++] = ZS.PaletteManager.SpriteAux3[ZS.GFXGroups.paletteGfx[(int) paletteUpDown.Value][2]][i];
						}
					}
				}

				pPos = 224;
				if (ZS.GFXGroups.paletteGfx[(int) paletteUpDown.Value][3] != 255)
				{
					for (int i = 0; i < 7; i++)
					{
						if (pPos % 16 == 0)
						{
							pPos++;
						}

						if (ZS.GFXGroups.paletteGfx[(int) paletteUpDown.Value][3] < ZS.PaletteManager.SpriteAux3.Length)
						{
							palettes[pPos] = ZS.PaletteManager.SpriteAux3[ZS.GFXGroups.paletteGfx[(int) paletteUpDown.Value][3]][i];
						}

						pPos++;
					}
				}

				pPos = 145;
				for (int i = 0; i < 15; i++)
				{
					/*
                    if (pPos % 16 == 0)
                    {
                        pPos++;
                    }
                    */

					palettes[pPos] = ZS.PaletteManager.SpriteGlobal[0][i];
					palettes[pPos + 16] = ZS.PaletteManager.SpriteGlobal[0][i + 15];
					palettes[pPos + 32] = ZS.PaletteManager.SpriteGlobal[0][i + 30];
					palettes[pPos + 48] = ZS.PaletteManager.SpriteGlobal[0][i + 45];
					pPos++;
				}
			}
			else
			{
				label9.Text = "Auxiliary Pal1";
				label10.Text = "Auxiliary Pal2";
				label11.Text = "Animated Pal";
				label12.Text = "???";
				int pPos = 40;

				if (ZS.GFXGroups.paletteGfx[(int) paletteUpDown.Value][0] != 255)
				{
					for (int i = 0; i < 7; i++)
					{
						if (pPos % 16 == 0)
						{
							pPos++;
						}

						palettes[pPos++] = ZS.PaletteManager.OverworldAux[ZS.GFXGroups.paletteGfx[(int) paletteUpDown.Value][0]][i];
					}

					pPos = 56;
					for (int i = 0; i < 7; i++)
					{
						if (pPos % 16 == 0)
						{
							pPos++;
						}

						palettes[pPos++] = ZS.PaletteManager.OverworldAux[ZS.GFXGroups.paletteGfx[(int) paletteUpDown.Value][0]][i + 7];
					}

					pPos = 72;
					for (int i = 0; i < 7; i++)
					{
						if (pPos % 16 == 0)
						{
							pPos++;
						}

						palettes[pPos++] = ZS.PaletteManager.OverworldAux[ZS.GFXGroups.paletteGfx[(int) paletteUpDown.Value][0]][i + 14];
					}
				}

				pPos = 88;
				if (ZS.GFXGroups.paletteGfx[(int) paletteUpDown.Value][1] != 255)
				{
					for (int i = 0; i < 7; i++)
					{
						if (pPos % 16 == 0)
						{
							pPos++;
						}

						palettes[pPos++] = ZS.PaletteManager.OverworldAux[ZS.GFXGroups.paletteGfx[(int) paletteUpDown.Value][1]][i];
					}

					pPos = 104;
					for (int i = 0; i < 7; i++)
					{
						if (pPos % 16 == 0)
						{
							pPos++;
						}

						palettes[pPos++] = ZS.PaletteManager.OverworldAux[ZS.GFXGroups.paletteGfx[(int) paletteUpDown.Value][1]][i + 7];
					}

					pPos = 120;
					for (int i = 0; i < 7; i++)
					{
						if (pPos % 16 == 0)
						{
							pPos++;
						}

						palettes[pPos++] = ZS.PaletteManager.OverworldAux[ZS.GFXGroups.paletteGfx[(int) paletteUpDown.Value][1]][i + 14];
					}
				}

				pPos = 112;
				if (ZS.GFXGroups.paletteGfx[(int) paletteUpDown.Value][2] != 255)
				{
					for (int i = 0; i < 7; i++)
					{
						if (pPos % 16 == 0)
						{
							pPos++;
						}

						palettes[pPos++] = ZS.PaletteManager.OverworldAnimated[ZS.GFXGroups.paletteGfx[(int) paletteUpDown.Value][2]][i];
					}
				}

				pPos = 32;
				for (int i = 0; i < 7; i++)
				{
					if (pPos % 16 == 0)
					{
						pPos++;
					}

					palettes[pPos++] = ZS.PaletteManager.OverworldMain[0][i];
				}

				pPos = 48;
				for (int i = 0; i < 7; i++)
				{
					if (pPos % 16 == 0)
					{
						pPos++;
					}

					palettes[pPos++] = ZS.PaletteManager.OverworldMain[0][i + 7];
				}

				pPos = 64;
				for (int i = 0; i < 7; i++)
				{
					if (pPos % 16 == 0)
					{
						pPos++;
					}

					palettes[pPos++] = ZS.PaletteManager.OverworldMain[0][i + 14];
				}

				pPos = 80;
				for (int i = 0; i < 7; i++)
				{
					if (pPos % 16 == 0)
					{
						pPos++;
					}

					palettes[pPos++] = ZS.PaletteManager.OverworldMain[0][i + 21];
				}

				pPos = 96;
				for (int i = 0; i < 7; i++)
				{
					if (pPos % 16 == 0)
					{
						pPos++;
					}

					palettes[pPos++] = ZS.PaletteManager.OverworldMain[0][i + 28];
				}
			}

			if (paletteUpDown.Value <= 40)
			{
				if (ZS.GFXGroups.paletteGfx[(byte) paletteUpDown.Value][0] % 2 == 0)
				{
					ZS.GFXManager.loadedPalettes = ZS.GFXManager.LoadDungeonPalette(ZS.UnderworldScene.Room.Palette);
					ZS.GFXManager.loadedSprPalettes = ZS.GFXManager.LoadSpritesPalette(ZS.UnderworldScene.Room.Palette);
				}
			}
		}

		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			reloadGfx();
		}

		private void GfxGroupsForm_VisibleChanged(object sender, EventArgs e)
		{
			CreateTempGfx();
			createPalette();
			reloadGfx();
			LoadGfx();
		}
	}
}
