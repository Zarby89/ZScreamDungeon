using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace ZeldaFullEditor.Gui
{
	public partial class GfxEditor : UserControl
	{
		int zoomLevel = 1;
		Color[] bigPalettes = new Color[1280];
		Color[] selectedPalette = new Color[16];
		int selectedPal = 0;
		int selectedColor = 0;

		int[] zoomValues = new int[] { 1, 2, 4, 8, 16 };

		bool mDown = false;

		string[] palettesGroups = new string[3] { "Dungeons BG", "Overworld BG", "Sprites" };

		public GfxEditor()
		{
			InitializeComponent();
		}

		private void pictureBox1_Paint(object sender, PaintEventArgs e)
		{
			mainscreenPicturebox.Width = 128 * zoomLevel;
			mainscreenPicturebox.Height = 7136 * zoomLevel;

			//pictureBox1.Image = GFX.allgfxBitmap;
			e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			e.Graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
			e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
			//e.Graphics.DrawImage(GFX.allgfxEDITBitmap, new Rectangle(4, 4, 128 * zoomLevel, 7136*zoomLevel),new Rectangle(0,0,128, 7136),GraphicsUnit.Pixel);
		}

		private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			zoomLevel = zoomValues[toolStripComboBox1.SelectedIndex];
			mainscreenPicturebox.Refresh();
		}

		private void mainscreenPicturebox_MouseDown(object sender, MouseEventArgs e)
		{
			mDown = true;
			mainscreenPicturebox.Invalidate();
		}

		private void pictureBox2_Paint(object sender, PaintEventArgs e)
		{
			// Dungeons Palettes
			for (int i = 0; i < bigPalettes.Length; i++)
			{
				if (bigPalettes[i] != null)
				{
					e.Graphics.FillRectangle(new SolidBrush(bigPalettes[i]), new Rectangle((i % 16) * 8, (i / 16) * 8, 8, 8));
				}
			}

			e.Graphics.DrawRectangle(Pens.Red, new Rectangle(0, selectedPal * 8, 128, 8));
		}

		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboBox2.SelectedIndex == 0) // Dungeons
			{
				int ColorPos = 0;
				for (int i = 0; i < 6; i++) // 6 pack of palettes
				{
					for (int k = 0; k < 6; k++) // 6 lines per pack
					{
						// Black default + // read7 + read8
						bigPalettes[ColorPos++] = Color.Black; // Color0

						for (int j = 0; j < 7; j++)
						{
							bigPalettes[ColorPos++] = Palettes.dungeonsMain_Palettes[i][j + (k * 15)];
						}

						ColorPos += 8;

						for (int j = 0; j < 8; j++)
						{
							bigPalettes[ColorPos++] = Palettes.dungeonsMain_Palettes[i][j + (k * 15) + 7];
						}

						ColorPos += 8;
					}
				}
			}
			else if (comboBox2.SelectedIndex == 1)
			{
				int ColorPos = 0;
				for (int i = 0; i < 4; i++) // 6 pack of palettes
				{
					for (int k = 0; k < 5; k++) // 6 lines per pack
					{
						// Black default + // read7 + read8
						bigPalettes[ColorPos++] = Palettes.overworld_GrassPalettes[0]; // Color0

						for (int j = 0; j < 7; j++)
						{
							bigPalettes[ColorPos++] = Palettes.overworld_MainPalettes[i][j + (k * 7)];
						}

						ColorPos += 8;
					}
				}

				for (int i = 0; i < 4; i++) //6 pack of palettes
				{
					for (int k = 0; k < 3; k++) //6 lines per pack
					{
						// black default + // read7 + read8
						bigPalettes[ColorPos++] = Palettes.overworld_GrassPalettes[0]; // Color0

						for (int j = 0; j < 7; j++)
						{
							bigPalettes[ColorPos++] = Palettes.overworld_AuxPalettes[i][j + (k * 7)];
						}

						ColorPos += 8;
					}
				}
			}
			else if (comboBox2.SelectedIndex == 2) // Sprites
			{
				int ColorPos = 0;
				for (int i = 0; i < 2; i++) // 6 pack of palettes
				{
					for (int k = 0; k < 4; k++) // 6 lines per pack
					{
						// Black default + // read7 + read8
						bigPalettes[ColorPos++] = Color.Black; // Color0

						for (int j = 0; j < 7; j++)
						{
							bigPalettes[ColorPos++] = Palettes.globalSprite_Palettes[i][j + (k * 15)];
						}

						ColorPos += 8;

						for (int j = 0; j < 8; j++)
						{
							bigPalettes[ColorPos++] = Palettes.globalSprite_Palettes[i][j + (k * 15) + 7];
						}

						ColorPos += 8;
					}
				}
			}

			palettesPicturebox.Refresh();
		}

		private void palettesPicturebox_MouseDown(object sender, MouseEventArgs e)
		{
			selectedPal = (e.Y / 8);
			//ColorPalette cp = GFX.allgfxEDITBitmap.Palette;
			for (int i = 0; i < 16; i++)
			{
				//cp.Entries[i] = bigPalettes[i + (selectedPal * 16)];
				selectedPalette[i] = bigPalettes[i + (selectedPal * 16)];
			}

			//GFX.allgfxEDITBitmap.Palette = cp;

			palettesPicturebox.Refresh();
			mainpalettePicturebox.Refresh();
			mainscreenPicturebox.Refresh();
		}

		private void mainpalettePicturebox_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			for (int i = 0; i < selectedPalette.Length; i++)
			{
				if (selectedPalette[i] != null)
				{
					e.Graphics.FillRectangle(new SolidBrush(selectedPalette[i]), new Rectangle(i * 32, 0, 32, 32));
				}
			}

			e.Graphics.DrawRectangle(Constants.LimeGreenPen2, new Rectangle((32 * selectedColor) + 1, 1, 31, 31));
		}

		private void mainpalettePicturebox_MouseDown(object sender, MouseEventArgs e)
		{
			selectedColor = (e.X / 32);
			mainpalettePicturebox.Refresh();
		}

		private void mainscreenPicturebox_MouseMove(object sender, MouseEventArgs e)
		{
			if (mDown)
			{
				unsafe
				{
					//byte* allgfx16Data = (byte*)GFX.allgfx16EDITPtr.ToPointer();
					int index = ((e.X) / zoomLevel) + ((e.Y / zoomLevel) * 128);
					//allgfx16Data[index] = (byte)(0x04);
				}

				mainscreenPicturebox.Invalidate(); //(new Rectangle(panel2.VerticalScroll.Value, panel2.HorizontalScroll.Value, panel2.Width, panel2.Height));
			}
		}

		private void mainscreenPicturebox_MouseUp(object sender, MouseEventArgs e)
		{
			mDown = false;
		}
	}
}
