using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Drawing.Imaging;

namespace ZeldaFullEditor
{
	class PaletteViewer
	{
		Color oldColor;
		int palX = 0;
		int palY = 0;
		PictureBox pb;
		bool palette_mouse_down = false;
		Random rand;
		byte dungeon_palette_id;
		public int xSize = 0;
		public Color[] colorpalettes = new Color[0];
		public Color[] tempColor = new Color[0];
		public bool changed = false;

		int mousePal = 0;
		bool middle = false;

		public PaletteViewer(PictureBox pb)
		{
			this.pb = pb;
		}

		public void setColor(Color[] c)
		{
			colorpalettes = c;
			tempColor = new Color[colorpalettes.Length];
			for (int i = 0; i < colorpalettes.Length; i++)
			{
				tempColor[i] = colorpalettes[i];
			}
		}

		public void update(bool currentRoom = false, bool isDungeon = false)
		{
			using (Graphics g = Graphics.FromImage(pb.Image))
			{
				g.Clear(pb.BackColor);

				//ColorPalette palettes = GFX.roomBg1Bitmap.Palette;
				if (currentRoom)
				{
					for (int i = 0; i < 256; i++)
					{
						ColorPalette palettes = GFX.mapgfx16Bitmap.Palette;
						if (isDungeon)
						{
							palettes = GFX.roomBg1Bitmap.Palette;
						}

						int x = i % 16;
						int y = i / 16;
						g.FillRectangle(new SolidBrush(palettes.Entries[i]), new Rectangle(x * 16, y * 16, 16, 16));
					}
				}
				else
				{
					for (int i = 0; i < 256; i++)
					{
						if (colorpalettes.Length > i)
						{
							int x = i % xSize;
							int y = i / xSize;
							g.FillRectangle(new SolidBrush(colorpalettes[i]), new Rectangle(x * 16, y * 16, 16, 16));
						}
					}
				}
			}

			pb.Refresh();
		}

		public bool mouseDown(MouseEventArgs e)
		{
			middle = false;
			if (e.Button == MouseButtons.Right)
			{

				int px = (e.X / 16);
				int py = (e.Y / 16);
				mousePal = px + (py * xSize);
				oldColor = colorpalettes[px + (py * xSize)];
				colorpalettes[px + (py * xSize)] = Color.FromArgb(255, 0, 254);
				update();
				palette_mouse_down = true;

				return true;
			}

			if (e.Button == MouseButtons.Middle)
			{
				changed = true;
				rand = new Random();
				randomize_castle_palette();
				update();
				palette_mouse_down = true;
				middle = true;
				return true;
			}

			return false;
		}

		public bool mouseUp(MouseEventArgs e)
		{
			if (palette_mouse_down)
			{
				if (middle == false)
				{
					colorpalettes[mousePal] = oldColor;
					update();
				}

				palette_mouse_down = false;
				return true;
			}

			return false;
		}

		public bool mouseDoubleclick(MouseEventArgs e, ColorDialog cd)
		{
			if (e.Button == MouseButtons.Left)
			{
				int px = (e.X / 16);
				int py = (e.Y / 16);
				cd.Color = colorpalettes[px + (py * xSize)];

				if (cd.ShowDialog() == DialogResult.OK)
				{
					colorpalettes[px + (py * xSize)] = cd.Color;
					update();
					changed = true;
				}

				palette_mouse_down = false;
				return true;
			}

			return false;
		}

		public void randomizePalette(byte palette)
		{
			dungeon_palette_id = ROM.DATA[Constants.dungeons_palettes_groups + (palette * 4)]; // ID of the 1st group of 4
																							   //randomize_wall(dungeon_palette_id);
			randomize_castle_palette();
			//randomize_floors();
			update();
		}

		public void randomize_castle_palette()
		{
			/*
             Castle [0]
             Wall Color : W
             Wall2 Color : E
             Wall Contour : C
             Floor1 Color: F
             Floor2 Color: G
             Pot Color: P
             Treasure Chest Color: T
            */
			Color W = Color.FromArgb(50 + rand.Next(180), 50 + rand.Next(180), 50 + rand.Next(180));
			Color E = Color.FromArgb(50 + rand.Next(180), 50 + rand.Next(180), 50 + rand.Next(180));
			Color C = Color.FromArgb(50 + rand.Next(180), 50 + rand.Next(180), 50 + rand.Next(180));
			Color F = Color.FromArgb(50 + rand.Next(180), 50 + rand.Next(180), 50 + rand.Next(180));
			Color G = Color.FromArgb(50 + rand.Next(180), 50 + rand.Next(180), 50 + rand.Next(180));
			Color P = Color.FromArgb(50 + rand.Next(180), 50 + rand.Next(180), 50 + rand.Next(180));
			Color T = Color.FromArgb(50 + rand.Next(180), 50 + rand.Next(180), 50 + rand.Next(180));
			bool N = false;

			Object[] colors = new Object[]
			{
				 W,08, W,06, W,04, W,02, W,00, E,02, E,06, N,00, W,08, W,06, W,04, W,02, W,00, W,02, W,06,
				 N,00, N,00, N,00, N,00, P,06, P,01, P,04, N,00, W,08, F,04, F,02, F,00, N,00, C,03, C,01,
				 W,08, W,06, W,04, W,00, N,00, N,00, N,00, N,00, W,08, F,07, F,05, F,03, N,00, C,05, C,03,
				 N,00, N,00, N,00, N,00, N,00, N,00, N,00, N,00, W,08, G,04, G,02, G,00, N,00, C,03, C,01,
				 N,00, T,02, T,00, N,00, N,00, N,00, N,00, N,00, W,08, G,07, G,05, G,03, N,00, C,05, C,03,
				 W,08, W,06, W,04, W,02, W,00, E,02, E,06, N,00, W,08, W,06, N,00, N,00, E,00, W,02, W,00,
			};

			int x = 0;
			int y = 0;
			for (int i = 0; i < 180; i += 2) // 180 in enemizer
			{
				if ((colors[(i)] is Color))
				{
					setColor((x), y, (Color) colors[(i)], (int) (colors[(i) + 1]));
				}

				x++;
				if (x >= 16)
				{
					y++;
					x = 0;
				}
			}
		}

		public void resetColor()
		{
			for (int i = 0; i < colorpalettes.Length; i++)
			{
				colorpalettes[i] = tempColor[i];
			}

			changed = false;
			update();
		}

		/*
        public void randomize_wall(int dungeon)
        {
            Color wall_color = Color.FromArgb(60 + rand.Next(180), 60 + rand.Next(180), 60 + rand.Next(180));

            for (int i = 0; i < 5; i++)
            {
                byte shadex = (byte)(10 - (i * 2));
                setColor(1 + i, 2, wall_color, shadex);
                setColor(9 + i, 2, wall_color, shadex);
                setColor(1 + i, 7, wall_color, shadex);
            }
            if ((GFX.paletteid / 180) == 4) { };

            setColor(9, 7, wall_color, (byte)(10)); // Outer wall darker
            setColor(10, 7, wall_color, (byte)(8)); // Outer wall darker

            setColor(14, 7, wall_color, (byte)(4)); // Outer wall darker
            setColor(15, 7, wall_color, (byte)(2)); // Outter wall brighter

            setColor(14, 4, wall_color, (byte)(8)); // Contour wall
            setColor(15, 4, wall_color, (byte)(6)); // Contour wall
            setColor(9, 4, wall_color, (byte)(10)); // Contour wall
            setColor(15, 2, wall_color, (byte)(6)); // Contour wall

            setColor(14, 3, wall_color, (byte)(4)); // Contour wall
            setColor(15, 3, wall_color, (byte)(2)); // Contour wall
            setColor(9, 3, wall_color, (byte)(10)); // Contour wall
            setColor(14, 2, wall_color, (byte)(4)); // Contour wall

            setColor(2, 4, wall_color, (byte)(8)); // Contour wall
        }

        public void randomize_floors()
        {
            Color floor_color1 = Color.FromArgb(60 + rand.Next(180), 60 + rand.Next(180), 60 + rand.Next(180));
            Color floor_color2 = Color.FromArgb(60 + rand.Next(180), 60 + rand.Next(180), 60 + rand.Next(180));
            Color floor_color3 = Color.FromArgb(60 + rand.Next(180), 60 + rand.Next(180), 60 + rand.Next(180));

            for (int i = 0; i < 3; i++)
            {
                byte shadex = (byte)(6 - (i * 2));
                setColor(10 + i, 3, floor_color1, shadex);
                setColor(10 + i, 4, floor_color1, (byte)(shadex + 3));

                //setColor(0x0DD7A0 + (0xB4 * dungeon) + (i * 2), floor_color2, shadex);
                //setColor(0x0DD7BE + (0xB4 * dungeon) + (i * 2), floor_color2, (byte)(shadex + 3));
            }

            setColor(13, 7, floor_color2, (byte)(2)); // Outer wall darker
            setColor(6, 2, floor_color2, (byte)(4)); // Outer wall darker
            setColor(7, 2, floor_color2, (byte)(6)); // Outer wall darker
            //setColor(0x0DD7E2 + (0xB4 * dungeon), floor_color3, 3);
            //setColor(0x0DD796 + (0xB4 * dungeon), floor_color3, 4);
        }
        */

		public void setColor(int x, int y, Color col, int shade)
		{
			int r = col.R;
			int g = col.G;
			int b = col.B;

			for (int i = 0; i < shade; i++)
			{
				r = (r - (r / 5));
				g = (g - (g / 5));
				b = (b - (b / 5));
			}

			r = (int) (r / 255f * 0x1F);
			g = (int) (g / 255f * 0x1F);
			b = (int) (b / 255f * 0x1F);

			colorpalettes[x + (y * 16)] = Color.FromArgb(r * 8, g * 8, b * 8);
		}
	}
}
