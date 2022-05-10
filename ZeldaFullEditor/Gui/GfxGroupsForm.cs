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

		public GfxGroupsForm()
		{
			InitializeComponent();
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

				Program.RoomPreviewArtist.HardRefresh();
				Program.RoomEditingArtist.HardRefresh();
				ZScreamer.ActiveUWScene.HardRefresh();
			}
		}

		private void GfxGroupsForm_Load(object sender, EventArgs e)
		{
			// TODO: Add something here?
		}

		public void CreateTempGfx()
		{
			throw new NotImplementedException();
		}

		private void LoadTempGfx()
		{
			editedFromForm = true;
			//main1Box.Text = tempmainGfx[(int) mainBlocksetUpDown.Value][0].ToString("X2");
			//main2Box.Text = tempmainGfx[(int) mainBlocksetUpDown.Value][1].ToString("X2");
			//main3Box.Text = tempmainGfx[(int) mainBlocksetUpDown.Value][2].ToString("X2");
			//main4Box.Text = tempmainGfx[(int) mainBlocksetUpDown.Value][3].ToString("X2");
			//main5Box.Text = tempmainGfx[(int) mainBlocksetUpDown.Value][4].ToString("X2");
			//main6Box.Text = tempmainGfx[(int) mainBlocksetUpDown.Value][5].ToString("X2");
			//main7Box.Text = tempmainGfx[(int) mainBlocksetUpDown.Value][6].ToString("X2");
			//main8Box.Text = tempmainGfx[(int) mainBlocksetUpDown.Value][7].ToString("X2");
			//
			//room1Box.Text = temproomGfx[(int) roomUpDown.Value][0].ToString("X2");
			//room2Box.Text = temproomGfx[(int) roomUpDown.Value][1].ToString("X2");
			//room3Box.Text = temproomGfx[(int) roomUpDown.Value][2].ToString("X2");
			//room4Box.Text = temproomGfx[(int) roomUpDown.Value][3].ToString("X2");
			//
			//sprite1Box.Text = tempspriteGfx[(int) spriteUpDown.Value][0].ToString("X2");
			//sprite2Box.Text = tempspriteGfx[(int) spriteUpDown.Value][1].ToString("X2");
			//sprite3Box.Text = tempspriteGfx[(int) spriteUpDown.Value][2].ToString("X2");
			//sprite4Box.Text = tempspriteGfx[(int) spriteUpDown.Value][3].ToString("X2");
			//
			//palette1Box.Text = temppaletteGfx[(int) paletteUpDown.Value][0].ToString("X2");
			//palette2Box.Text = temppaletteGfx[(int) paletteUpDown.Value][1].ToString("X2");
			//palette3Box.Text = temppaletteGfx[(int) paletteUpDown.Value][2].ToString("X2");
			//palette4Box.Text = temppaletteGfx[(int) paletteUpDown.Value][3].ToString("X2");
			editedFromForm = false;
		}

		private void LoadGfx()
		{
			editedFromForm = true;
			//main1Box.Text = ZScreamer.ActiveScreamer.GFXGroups.mainGfx[(int) mainBlocksetUpDown.Value][0].ToString("X2");
			//main2Box.Text = ZScreamer.ActiveScreamer.GFXGroups.mainGfx[(int) mainBlocksetUpDown.Value][1].ToString("X2");
			//main3Box.Text = ZScreamer.ActiveScreamer.GFXGroups.mainGfx[(int) mainBlocksetUpDown.Value][2].ToString("X2");
			//main4Box.Text = ZScreamer.ActiveScreamer.GFXGroups.mainGfx[(int) mainBlocksetUpDown.Value][3].ToString("X2");
			//main5Box.Text = ZScreamer.ActiveScreamer.GFXGroups.mainGfx[(int) mainBlocksetUpDown.Value][4].ToString("X2");
			//main6Box.Text = ZScreamer.ActiveScreamer.GFXGroups.mainGfx[(int) mainBlocksetUpDown.Value][5].ToString("X2");
			//main7Box.Text = ZScreamer.ActiveScreamer.GFXGroups.mainGfx[(int) mainBlocksetUpDown.Value][6].ToString("X2");
			//main8Box.Text = ZScreamer.ActiveScreamer.GFXGroups.mainGfx[(int) mainBlocksetUpDown.Value][7].ToString("X2");
			//
			//room1Box.Text = ZScreamer.ActiveScreamer.GFXGroups.roomGfx[(int) roomUpDown.Value][0].ToString("X2");
			//room2Box.Text = ZScreamer.ActiveScreamer.GFXGroups.roomGfx[(int) roomUpDown.Value][1].ToString("X2");
			//room3Box.Text = ZScreamer.ActiveScreamer.GFXGroups.roomGfx[(int) roomUpDown.Value][2].ToString("X2");
			//room4Box.Text = ZScreamer.ActiveScreamer.GFXGroups.roomGfx[(int) roomUpDown.Value][3].ToString("X2");
			//
			//sprite1Box.Text = ZScreamer.ActiveScreamer.GFXGroups.spriteGfx[(int) spriteUpDown.Value][0].ToString("X2");
			//sprite2Box.Text = ZScreamer.ActiveScreamer.GFXGroups.spriteGfx[(int) spriteUpDown.Value][1].ToString("X2");
			//sprite3Box.Text = ZScreamer.ActiveScreamer.GFXGroups.spriteGfx[(int) spriteUpDown.Value][2].ToString("X2");
			//sprite4Box.Text = ZScreamer.ActiveScreamer.GFXGroups.spriteGfx[(int) spriteUpDown.Value][3].ToString("X2");
			//
			//palette1Box.Text = ZScreamer.ActiveScreamer.GFXGroups.paletteGfx[(int) paletteUpDown.Value][0].ToString("X2");
			//palette2Box.Text = ZScreamer.ActiveScreamer.GFXGroups.paletteGfx[(int) paletteUpDown.Value][1].ToString("X2");
			//palette3Box.Text = ZScreamer.ActiveScreamer.GFXGroups.paletteGfx[(int) paletteUpDown.Value][2].ToString("X2");
			//palette4Box.Text = ZScreamer.ActiveScreamer.GFXGroups.paletteGfx[(int) paletteUpDown.Value][3].ToString("X2");
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
			if (editedFromForm) return;
			
			//ZScreamer.ActiveScreamer.GFXGroups.mainGfx[(int) mainBlocksetUpDown.Value][0] = getTextBoxValue(main1Box);
			//ZScreamer.ActiveScreamer.GFXGroups.mainGfx[(int) mainBlocksetUpDown.Value][1] = getTextBoxValue(main2Box);
			//ZScreamer.ActiveScreamer.GFXGroups.mainGfx[(int) mainBlocksetUpDown.Value][2] = getTextBoxValue(main3Box);
			//ZScreamer.ActiveScreamer.GFXGroups.mainGfx[(int) mainBlocksetUpDown.Value][3] = getTextBoxValue(main4Box);
			//ZScreamer.ActiveScreamer.GFXGroups.mainGfx[(int) mainBlocksetUpDown.Value][4] = getTextBoxValue(main5Box);
			//ZScreamer.ActiveScreamer.GFXGroups.mainGfx[(int) mainBlocksetUpDown.Value][5] = getTextBoxValue(main6Box);
			//ZScreamer.ActiveScreamer.GFXGroups.mainGfx[(int) mainBlocksetUpDown.Value][6] = getTextBoxValue(main7Box);
			//ZScreamer.ActiveScreamer.GFXGroups.mainGfx[(int) mainBlocksetUpDown.Value][7] = getTextBoxValue(main8Box);
			//
			//ZScreamer.ActiveScreamer.GFXGroups.roomGfx[(int) roomUpDown.Value][0] = getTextBoxValue(room1Box);
			//ZScreamer.ActiveScreamer.GFXGroups.roomGfx[(int) roomUpDown.Value][1] = getTextBoxValue(room2Box);
			//ZScreamer.ActiveScreamer.GFXGroups.roomGfx[(int) roomUpDown.Value][2] = getTextBoxValue(room3Box);
			//ZScreamer.ActiveScreamer.GFXGroups.roomGfx[(int) roomUpDown.Value][3] = getTextBoxValue(room4Box);
			//
			//ZScreamer.ActiveScreamer.GFXGroups.spriteGfx[(int) spriteUpDown.Value][0] = getTextBoxValue(sprite1Box);
			//ZScreamer.ActiveScreamer.GFXGroups.spriteGfx[(int) spriteUpDown.Value][1] = getTextBoxValue(sprite2Box);
			//ZScreamer.ActiveScreamer.GFXGroups.spriteGfx[(int) spriteUpDown.Value][2] = getTextBoxValue(sprite3Box);
			//ZScreamer.ActiveScreamer.GFXGroups.spriteGfx[(int) spriteUpDown.Value][3] = getTextBoxValue(sprite4Box);
			//
			//ZScreamer.ActiveScreamer.GFXGroups.paletteGfx[(int) paletteUpDown.Value][0] = getTextBoxValue(palette1Box);
			//ZScreamer.ActiveScreamer.GFXGroups.paletteGfx[(int) paletteUpDown.Value][1] = getTextBoxValue(palette2Box);
			//ZScreamer.ActiveScreamer.GFXGroups.paletteGfx[(int) paletteUpDown.Value][2] = getTextBoxValue(palette3Box);
			//ZScreamer.ActiveScreamer.GFXGroups.paletteGfx[(int) paletteUpDown.Value][3] = getTextBoxValue(palette4Box);

			reloadGfx();
			Program.RoomPreviewArtist.HardRefresh();
			Program.RoomEditingArtist.HardRefresh();
			ZScreamer.ActiveUWScene.Refresh();
			
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			//ZScreamer.ActiveScreamer.GFXGroups.mainGfx[(int) mainBlocksetUpDown.Value][0] = getTextBoxValue(main1Box);
			//ZScreamer.ActiveScreamer.GFXGroups.mainGfx[(int) mainBlocksetUpDown.Value][1] = getTextBoxValue(main2Box);
			//ZScreamer.ActiveScreamer.GFXGroups.mainGfx[(int) mainBlocksetUpDown.Value][2] = getTextBoxValue(main3Box);
			//ZScreamer.ActiveScreamer.GFXGroups.mainGfx[(int) mainBlocksetUpDown.Value][3] = getTextBoxValue(main4Box);
			//ZScreamer.ActiveScreamer.GFXGroups.mainGfx[(int) mainBlocksetUpDown.Value][4] = getTextBoxValue(main5Box);
			//ZScreamer.ActiveScreamer.GFXGroups.mainGfx[(int) mainBlocksetUpDown.Value][5] = getTextBoxValue(main6Box);
			//ZScreamer.ActiveScreamer.GFXGroups.mainGfx[(int) mainBlocksetUpDown.Value][6] = getTextBoxValue(main7Box);
			//ZScreamer.ActiveScreamer.GFXGroups.mainGfx[(int) mainBlocksetUpDown.Value][7] = getTextBoxValue(main8Box);
			//
			//ZScreamer.ActiveScreamer.GFXGroups.roomGfx[(int) roomUpDown.Value][0] = getTextBoxValue(room1Box);
			//ZScreamer.ActiveScreamer.GFXGroups.roomGfx[(int) roomUpDown.Value][1] = getTextBoxValue(room2Box);
			//ZScreamer.ActiveScreamer.GFXGroups.roomGfx[(int) roomUpDown.Value][2] = getTextBoxValue(room3Box);
			//ZScreamer.ActiveScreamer.GFXGroups.roomGfx[(int) roomUpDown.Value][3] = getTextBoxValue(room4Box);
			//
			//ZScreamer.ActiveScreamer.GFXGroups.spriteGfx[(int) spriteUpDown.Value][0] = getTextBoxValue(sprite1Box);
			//ZScreamer.ActiveScreamer.GFXGroups.spriteGfx[(int) spriteUpDown.Value][1] = getTextBoxValue(sprite2Box);
			//ZScreamer.ActiveScreamer.GFXGroups.spriteGfx[(int) spriteUpDown.Value][2] = getTextBoxValue(sprite3Box);
			//ZScreamer.ActiveScreamer.GFXGroups.spriteGfx[(int) spriteUpDown.Value][3] = getTextBoxValue(sprite4Box);
			//
			//ZScreamer.ActiveScreamer.GFXGroups.paletteGfx[(int) paletteUpDown.Value][0] = getTextBoxValue(palette1Box);
			//ZScreamer.ActiveScreamer.GFXGroups.paletteGfx[(int) paletteUpDown.Value][1] = getTextBoxValue(palette2Box);
			//ZScreamer.ActiveScreamer.GFXGroups.paletteGfx[(int) paletteUpDown.Value][2] = getTextBoxValue(palette3Box);
			//ZScreamer.ActiveScreamer.GFXGroups.paletteGfx[(int) paletteUpDown.Value][3] = getTextBoxValue(palette4Box);

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
		//bool main = false;
		//byte[] blocks = new byte[8];
		//
		//for (int i = 0; i < 8; i++)
		//{
		//	blocks[i] = 0;
		//}
		//
		//if (tabControl1.SelectedIndex == 0) // Main 
		//{
		//	main = true;
		//	byte blockset = (byte) mainBlocksetUpDown.Value;
		//
		//	for (int i = 0; i < 8; i++)
		//	{
		//		blocks[i] = ZScreamer.ActiveScreamer.GFXGroups.mainGfx[blockset][i];
		//	}
		//}
		//
		//if (tabControl1.SelectedIndex == 1) // Room ?
		//{
		//	byte blockset = (byte) roomUpDown.Value;
		//
		//	for (int i = 0; i < 4; i++)
		//	{
		//		blocks[i] = ZScreamer.ActiveScreamer.GFXGroups.roomGfx[blockset][i];
		//	} // 12-16 sprites
		//}
		//
		//if (tabControl1.SelectedIndex == 2) // Room ?
		//{
		//	byte blockset = (byte) spriteUpDown.Value;
		//
		//	for (int i = 0; i < 4; i++)
		//	{
		//		blocks[i] = (byte) (ZScreamer.ActiveScreamer.GFXGroups.spriteGfx[blockset][i] + 115);
		//	} // 12-16 sprites
		//}
		//
		//unsafe
		//{
		//	byte* newPdata = (byte*) ZScreamer.ActiveGraphicsManager.allgfx16Ptr.ToPointer(); // Turn gfx16 (all 222 of them)
		//	byte* sheetsData = (byte*) ZScreamer.ActiveGraphicsManager.currentEditinggfx16Ptr.ToPointer(); // Into "room gfx16" 16 of them
		//	int sheetPos = 0;
		//
		//	for (int i = 0; i < 8; i++)
		//	{
		//		int d = 0;
		//		while (d < 2048)
		//		{
		//			// NOTE LOAD BLOCKSETS SOMEWHERE FIRST
		//			byte mapByte = newPdata[d + (blocks[i] * 2048)];
		//			if (main)
		//			{
		//				if (i < 4)
		//				{
		//					mapByte += 0x88;
		//				} // Last line of 6, first line of 7 ?
		//			}
		//
		//			sheetsData[d + (sheetPos * 2048)] = mapByte;
		//			d++;
		//		}
		//
		//		sheetPos++;
		//	}
		//}

			pictureBox1.Refresh();
			pictureBox2.Refresh();
			pictureBox3.Refresh();
			pictureBox4.Refresh();
		}

		private void allpreviewPaint(object sender, PaintEventArgs e)
		{
			if (grayscaleRadioButton.Checked)
			{
				ColorPalette cp = ZScreamer.ActiveGraphicsManager.currentEditingfx16Bitmap.Palette;
				for (int i = 0; i < 16; i++)
				{
					cp.Entries[i] = Color.FromArgb(i * 15, i * 15, i * 15);
				}

				ZScreamer.ActiveGraphicsManager.currentEditingfx16Bitmap.Palette = cp;
			}
			else if (paletteRadioButton.Checked)
			{
				ColorPalette cp = ZScreamer.ActiveGraphicsManager.currentEditingfx16Bitmap.Palette;
				for (int i = 0; i < 16; i++)
				{
					cp.Entries[i] = palettes[i + ((int) numericUpDown1.Value * 16)];
				}

				ZScreamer.ActiveGraphicsManager.currentEditingfx16Bitmap.Palette = cp;
			}

			e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			e.Graphics.DrawImage(ZScreamer.ActiveGraphicsManager.currentEditingfx16Bitmap, 0, 0);
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
		//	for (int i = 0; i < 256; i++)
		//	{
		//		palettes[i] = Color.Black;
		//	}
		//
		//	if (paletteUpDown.Value <= 40)
		//	{
		//		label9.Text = "Dungeon Main";
		//		label10.Text = "Dungeon Sprite Pal1";
		//		label11.Text = "Dungeon Sprite Pal2";
		//		label12.Text = "Dungeon Sprite Pal3";
		//
		//		byte dungeon_palette_ptr = ZScreamer.ActiveScreamer.GFXGroups.paletteGfx[(byte) paletteUpDown.Value][0];
		//		ushort palette_pos;
		//		int pId;
		//		int pPos = 32;
		//
		//		if (ZScreamer.ActiveScreamer.GFXGroups.paletteGfx[(byte) paletteUpDown.Value][0] % 2 == 0)
		//		{
		//			palette_pos = ZScreamer.ActiveROM.Read16(0xDEC4B + dungeon_palette_ptr);
		//			pId = (palette_pos / 180);
		//
		//			for (int i = 0; i < 90; i++)
		//			{
		//				if (pPos % 16 == 0)
		//				{
		//					pPos++;
		//				}
		//
		//				if (pId < ZScreamer.ActivePaletteManager.UnderworldMain.Length)
		//				{
		//					palettes[pPos] = ZScreamer.ActivePaletteManager.UnderworldMain[pId][i];
		//				}
		//
		//				pPos++;
		//			}
		//		}
		//
		//		pPos = 128;
		//		if (ZScreamer.ActiveScreamer.GFXGroups.paletteGfx[(int) paletteUpDown.Value][1] != 255)
		//		{
		//			for (int i = 0; i < 7; i++)
		//			{
		//				if (pPos % 16 == 0)
		//				{
		//					pPos++;
		//				}
		//
		//				if (ZScreamer.ActiveScreamer.GFXGroups.paletteGfx[(int) paletteUpDown.Value][1] < ZScreamer.ActivePaletteManager.SpriteAux1.Length)
		//				{
		//					palettes[pPos++] = ZScreamer.ActivePaletteManager.SpriteAux1[ZScreamer.ActiveScreamer.GFXGroups.paletteGfx[(int) paletteUpDown.Value][1]][i];
		//				}
		//			}
		//		}
		//
		//		pPos = 208;
		//		if (ZScreamer.ActiveScreamer.GFXGroups.paletteGfx[(int) paletteUpDown.Value][2] != 255)
		//		{
		//			for (int i = 0; i < 7; i++)
		//			{
		//				if (pPos % 16 == 0)
		//				{
		//					pPos++;
		//				}
		//
		//				if (ZScreamer.ActiveScreamer.GFXGroups.paletteGfx[(int) paletteUpDown.Value][2] < ZScreamer.ActivePaletteManager.SpriteAux3.Length)
		//				{
		//					palettes[pPos++] = ZScreamer.ActivePaletteManager.SpriteAux3[ZScreamer.ActiveScreamer.GFXGroups.paletteGfx[(int) paletteUpDown.Value][2]][i];
		//				}
		//			}
		//		}
		//
		//		pPos = 224;
		//		if (ZScreamer.ActiveScreamer.GFXGroups.paletteGfx[(int) paletteUpDown.Value][3] != 255)
		//		{
		//			for (int i = 0; i < 7; i++)
		//			{
		//				if (pPos % 16 == 0)
		//				{
		//					pPos++;
		//				}
		//
		//				if (ZScreamer.ActiveScreamer.GFXGroups.paletteGfx[(int) paletteUpDown.Value][3] < ZScreamer.ActivePaletteManager.SpriteAux3.Length)
		//				{
		//					palettes[pPos] = ZScreamer.ActivePaletteManager.SpriteAux3[ZScreamer.ActiveScreamer.GFXGroups.paletteGfx[(int) paletteUpDown.Value][3]][i];
		//				}
		//
		//				pPos++;
		//			}
		//		}
		//
		//		pPos = 145;
		//		for (int i = 0; i < 15; i++)
		//		{
		//			/*
        //            if (pPos % 16 == 0)
        //            {
        //                pPos++;
        //            }
        //            */
		//
		//			palettes[pPos] = ZScreamer.ActivePaletteManager.SpriteGlobal[0][i];
		//			palettes[pPos + 16] = ZScreamer.ActivePaletteManager.SpriteGlobal[0][i + 15];
		//			palettes[pPos + 32] = ZScreamer.ActivePaletteManager.SpriteGlobal[0][i + 30];
		//			palettes[pPos + 48] = ZScreamer.ActivePaletteManager.SpriteGlobal[0][i + 45];
		//			pPos++;
		//		}
		//	}
		//	else
		//	{
		//		label9.Text = "Auxiliary Pal1";
		//		label10.Text = "Auxiliary Pal2";
		//		label11.Text = "Animated Pal";
		//		label12.Text = "???";
		//		int pPos = 40;
		//
		//		if (ZScreamer.ActiveScreamer.GFXGroups.paletteGfx[(int) paletteUpDown.Value][0] != 255)
		//		{
		//			for (int i = 0; i < 7; i++)
		//			{
		//				if (pPos % 16 == 0)
		//				{
		//					pPos++;
		//				}
		//
		//				palettes[pPos++] = ZScreamer.ActivePaletteManager.OverworldAux[ZScreamer.ActiveScreamer.GFXGroups.paletteGfx[(int) paletteUpDown.Value][0]][i];
		//			}
		//
		//			pPos = 56;
		//			for (int i = 0; i < 7; i++)
		//			{
		//				if (pPos % 16 == 0)
		//				{
		//					pPos++;
		//				}
		//
		//				palettes[pPos++] = ZScreamer.ActivePaletteManager.OverworldAux[ZScreamer.ActiveScreamer.GFXGroups.paletteGfx[(int) paletteUpDown.Value][0]][i + 7];
		//			}
		//
		//			pPos = 72;
		//			for (int i = 0; i < 7; i++)
		//			{
		//				if (pPos % 16 == 0)
		//				{
		//					pPos++;
		//				}
		//
		//				palettes[pPos++] = ZScreamer.ActivePaletteManager.OverworldAux[ZScreamer.ActiveScreamer.GFXGroups.paletteGfx[(int) paletteUpDown.Value][0]][i + 14];
		//			}
		//		}
		//
		//		pPos = 88;
		//		if (ZScreamer.ActiveScreamer.GFXGroups.paletteGfx[(int) paletteUpDown.Value][1] != 255)
		//		{
		//			for (int i = 0; i < 7; i++)
		//			{
		//				if (pPos % 16 == 0)
		//				{
		//					pPos++;
		//				}
		//
		//				palettes[pPos++] = ZScreamer.ActivePaletteManager.OverworldAux[ZScreamer.ActiveScreamer.GFXGroups.paletteGfx[(int) paletteUpDown.Value][1]][i];
		//			}
		//
		//			pPos = 104;
		//			for (int i = 0; i < 7; i++)
		//			{
		//				if (pPos % 16 == 0)
		//				{
		//					pPos++;
		//				}
		//
		//				palettes[pPos++] = ZScreamer.ActivePaletteManager.OverworldAux[ZScreamer.ActiveScreamer.GFXGroups.paletteGfx[(int) paletteUpDown.Value][1]][i + 7];
		//			}
		//
		//			pPos = 120;
		//			for (int i = 0; i < 7; i++)
		//			{
		//				if (pPos % 16 == 0)
		//				{
		//					pPos++;
		//				}
		//
		//				palettes[pPos++] = ZScreamer.ActivePaletteManager.OverworldAux[ZScreamer.ActiveScreamer.GFXGroups.paletteGfx[(int) paletteUpDown.Value][1]][i + 14];
		//			}
		//		}
		//
		//		pPos = 112;
		//		if (ZScreamer.ActiveScreamer.GFXGroups.paletteGfx[(int) paletteUpDown.Value][2] != 255)
		//		{
		//			for (int i = 0; i < 7; i++)
		//			{
		//				if (pPos % 16 == 0)
		//				{
		//					pPos++;
		//				}
		//
		//				palettes[pPos++] = ZScreamer.ActivePaletteManager.OverworldAnimated[ZScreamer.ActiveScreamer.GFXGroups.paletteGfx[(int) paletteUpDown.Value][2]][i];
		//			}
		//		}
		//
		//		pPos = 32;
		//		for (int i = 0; i < 7; i++)
		//		{
		//			if (pPos % 16 == 0)
		//			{
		//				pPos++;
		//			}
		//
		//			palettes[pPos++] = ZScreamer.ActivePaletteManager.OverworldMain[0][i];
		//		}
		//
		//		pPos = 48;
		//		for (int i = 0; i < 7; i++)
		//		{
		//			if (pPos % 16 == 0)
		//			{
		//				pPos++;
		//			}
		//
		//			palettes[pPos++] = ZScreamer.ActivePaletteManager.OverworldMain[0][i + 7];
		//		}
		//
		//		pPos = 64;
		//		for (int i = 0; i < 7; i++)
		//		{
		//			if (pPos % 16 == 0)
		//			{
		//				pPos++;
		//			}
		//
		//			palettes[pPos++] = ZScreamer.ActivePaletteManager.OverworldMain[0][i + 14];
		//		}
		//
		//		pPos = 80;
		//		for (int i = 0; i < 7; i++)
		//		{
		//			if (pPos % 16 == 0)
		//			{
		//				pPos++;
		//			}
		//
		//			palettes[pPos++] = ZScreamer.ActivePaletteManager.OverworldMain[0][i + 21];
		//		}
		//
		//		pPos = 96;
		//		for (int i = 0; i < 7; i++)
		//		{
		//			if (pPos % 16 == 0)
		//			{
		//				pPos++;
		//			}
		//
		//			palettes[pPos++] = ZScreamer.ActivePaletteManager.OverworldMain[0][i + 28];
		//		}
		//	}
		//
		//	if (paletteUpDown.Value <= 40)
		//	{
		//		if (ZScreamer.ActiveScreamer.GFXGroups.paletteGfx[(byte) paletteUpDown.Value][0] % 2 == 0)
		//		{
		//			ZScreamer.ActiveGraphicsManager.loadedPalettes = ZScreamer.ActivePaletteManager.LoadDungeonPalette(ZScreamer.ActiveUWScene.Room.Palette);
		//			ZScreamer.ActiveGraphicsManager.loadedSprPalettes = ZScreamer.ActivePaletteManager.GetSpritePaletteSet(ZScreamer.ActiveUWScene.Room.Palette);
		//		}
		//	}
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
