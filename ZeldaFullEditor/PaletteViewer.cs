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

        public PaletteViewer(PictureBox pb)
        {
            this.pb = pb;
        }

        public void update()
        {
            using (Graphics g = Graphics.FromImage(pb.Image))
            {
                g.Clear(pb.BackColor);
                GFX.LoadHudPalettes();

                //blockset
                if (GFX.editingPalettes != null)
                {
                    for (int y = 0; y < GFX.editingPalettes.GetLength(1); y++)
                    {
                        for (int x = 0; x < GFX.editingPalettes.GetLength(0); x++)
                        {
                            g.FillRectangle(new SolidBrush(GFX.editingPalettes[x, y]), new Rectangle(x * 16, y * 16, 16, 16));
                        }
                    }
                }
                //spriteset
                /*for (int y = 0; y < 16; y++)
                {
                    for (int x = 0; x < 8; x++)
                    {
                        //g.FillRectangle(new SolidBrush(GFX.spritesPalettes[x, y]), new Rectangle(x * 16, y * 16, 16, 16));
                        //g.FillRectangle(new SolidBrush(GFX.hudPalettes[x, y]), new Rectangle(x * 16, y * 16, 16, 16));
                    }
                }*/
                //g.DrawString((GFX.paletteid/180).ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.White, new Point(4, 4));
            }

            pb.Refresh();
        }

        public bool mouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int px = (e.X / 16);
                int py = (e.Y / 16);
                palX = px;
                palY = py;
                oldColor = GFX.loadedPalettes[px, py];
                GFX.loadedPalettes[px, py] = Color.FromArgb(255, 0, 254);
                update();
                palette_mouse_down = true;
                return true;
            }
            return false;
        }

        public bool mouseUp(MouseEventArgs e)
        {
            if (palette_mouse_down)
            {
                GFX.loadedPalettes[palX, palY] = oldColor;
                update();
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
                palX = px;
                palY = py;
                cd.Color = GFX.loadedPalettes[palX, palY];
                cd.ShowDialog();
                GFX.loadedPalettes[palX, palY] = cd.Color;
                update();
                palette_mouse_down = false;
                return true;
            }
            return false;
        }

        public void randomizePalette(byte palette)
        {
           
            rand = new Random();
            dungeon_palette_id = ROM.DATA[Constants.dungeons_palettes_groups + (palette * 4)]; //id of the 1st group of 4
            //randomize_wall(dungeon_palette_id);
            randomize_castle_palette();
            //randomize_floors();
            update();
        }

        public void randomize_castle_palette()
        {
            /*Castle [0]
            Wall Color : W
            Wall2 Color : E
            Wall Contour : C
            Floor1 Color: F
            Floor2 Color: G
            Pot Color: P
            Treasure Chest Color: T*/
            Color W = Color.FromArgb(60 + rand.Next(180), 60 + rand.Next(180), 60 + rand.Next(180));
            Color E = Color.FromArgb(60 + rand.Next(180), 60 + rand.Next(180), 60 + rand.Next(180));
            Color C = Color.FromArgb(60 + rand.Next(180), 60 + rand.Next(180), 60 + rand.Next(180));
            Color F = Color.FromArgb(60 + rand.Next(180), 60 + rand.Next(180), 60 + rand.Next(180));
            Color G = Color.FromArgb(60 + rand.Next(180), 60 + rand.Next(180), 60 + rand.Next(180));
            Color P = Color.FromArgb(60 + rand.Next(180), 60 + rand.Next(180), 60 + rand.Next(180));
            Color T = Color.FromArgb(60 + rand.Next(180), 60 + rand.Next(180), 60 + rand.Next(180));
            bool N = false;
            Object[] colors = new Object[] 
            {
                N,00, W,08, W,06, W,04, W,02, W,00, E,02, E,06, N,00, W,08, W,06, W,04, W,02, W,00, W,02, W,06,
                N,00, N,00, N,00, N,00, N,00, P,06, P,01, P,04, N,00, W,08, F,04, F,02, F,00, N,00, C,03, C,01,
                N,00, W,08, W,06, W,04, W,00, N,00, N,00, N,00, N,00, W,08, F,07, F,05, F,03, N,00, C,05, C,03,
                N,00, N,00, N,00, N,00, N,00, N,00, N,00, N,00, N,00, W,08, G,04, G,02, G,00, N,00, C,03, C,01,
                N,00, N,00, T,02, T,00, N,00, N,00, N,00, N,00, N,00, W,08, G,07, G,05, G,03, N,00, C,05, C,03,
                N,00, W,08, W,06, W,04, W,02, W,00, E,02, E,06, N,00, W,08, W,06, N,00, N,00, E,00, W,02, W,00,
            };

            int x = 0;
            int y = 2;
            for(int i = 0;i < 192;i+=2) //180 in enemizer
            {
                if ((colors[(i)] is Color))
                {
                    setColor((x), y, (Color)colors[(i)], (int)(colors[(i)+1]));
                }
                x++;
                if (x >= 16)
                {
                    y++;
                    x = 0;
                }

            }

        }


        /*public void randomize_wall(int dungeon)
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
                setColor(9, 7, wall_color, (byte)(10)); //outer wall darker
            setColor(10, 7, wall_color, (byte)(8)); //outer wall darker

            setColor(14, 7, wall_color, (byte)(4)); //outer wall darker
            setColor(15, 7, wall_color, (byte)(2)); //outter wall brighter

            setColor(14, 4, wall_color, (byte)(8)); //contour wall
            setColor(15, 4, wall_color, (byte)(6)); //contour wall
            setColor(9, 4, wall_color, (byte)(10)); //contour wall
            setColor(15, 2, wall_color, (byte)(6)); //contour wall

            setColor(14, 3, wall_color, (byte)(4)); //contour wall
            setColor(15, 3, wall_color, (byte)(2)); //contour wall
            setColor(9, 3, wall_color, (byte)(10)); //contour wall
            setColor(14, 2, wall_color, (byte)(4)); //contour wall

            setColor(2, 4, wall_color, (byte)(8)); //contour wall
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

            setColor(13, 7, floor_color2, (byte)(2)); //outer wall darker
            setColor(6, 2, floor_color2, (byte)(4)); //outer wall darker
            setColor(7, 2, floor_color2, (byte)(6)); //outer wall darker
            //setColor(0x0DD7E2 + (0xB4 * dungeon), floor_color3, 3);
            //setColor(0x0DD796 + (0xB4 * dungeon), floor_color3, 4);
        }*/

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

            r = (int)((float)r / 255f * 0x1F);
            g = (int)((float)g / 255f * 0x1F);
            b = (int)((float)b / 255f * 0x1F);

            GFX.loadedPalettes[x, y] = Color.FromArgb(r * 8, g * 8, b * 8);
        }


    }
}
