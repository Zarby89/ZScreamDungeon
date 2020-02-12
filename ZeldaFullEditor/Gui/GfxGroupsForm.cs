using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeldaFullEditor.Gui
{
    public partial class GfxGroupsForm : Panel
    {
        public GfxGroupsForm(DungeonMain mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.BackColor = Color.FromKnownColor(KnownColor.Control);
        }
        DungeonMain mainForm;
        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will restore groups to the previously applied changes\r\n" +
                "Are you sure you want to restore Gfx Groups?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                LoadTempGfx();
                okButton_Click(null, e);
                reloadGfx();
                mainForm.activeScene.room.reloadGfx();
                mainForm.activeScene.DrawRoom();
                mainForm.activeScene.Refresh();
            }
        }
        public bool editedFromForm = false;
        public static byte[][] tempmainGfx = new byte[37][];
        public static byte[][] temproomGfx = new byte[82][];
        public static byte[][] tempspriteGfx = new byte[144][];
        public static byte[][] temppaletteGfx = new byte[72][];

        private void GfxGroupsForm_Load(object sender, EventArgs e)
        {

        }



        private void CreateTempGfx()
        {
            for (int i = 0; i < 37; i++)
            {
                tempmainGfx[i] = new byte[8];
                for (int j = 0; j < 8; j++)
                {
                    tempmainGfx[i][j] = GfxGroups.mainGfx[i][j];
                }
            }

            for (int i = 0; i < 82; i++)
            {
                temproomGfx[i] = new byte[4];
                for (int j = 0; j < 4; j++)
                {
                    temproomGfx[i][j] = GfxGroups.roomGfx[i][j];
                }
            }

            for (int i = 0; i < 144; i++)
            {
                tempspriteGfx[i] = new byte[4];
                for (int j = 0; j < 4; j++)
                {
                    tempspriteGfx[i][j] = GfxGroups.spriteGfx[i][j];
                }
            }

            for (int i = 0; i < 72; i++)
            {
                temppaletteGfx[i] = new byte[4];
                for (int j = 0; j < 4; j++)
                {
                    temppaletteGfx[i][j] = GfxGroups.paletteGfx[i][j];
                }
            }
        }

        private void LoadTempGfx()
        {
            editedFromForm = true;
            main1Box.Text = tempmainGfx[(int)mainBlocksetUpDown.Value][0].ToString();
            main2Box.Text = tempmainGfx[(int)mainBlocksetUpDown.Value][1].ToString();
            main3Box.Text = tempmainGfx[(int)mainBlocksetUpDown.Value][2].ToString();
            main4Box.Text = tempmainGfx[(int)mainBlocksetUpDown.Value][3].ToString();
            main5Box.Text = tempmainGfx[(int)mainBlocksetUpDown.Value][4].ToString();
            main6Box.Text = tempmainGfx[(int)mainBlocksetUpDown.Value][5].ToString();
            main7Box.Text = tempmainGfx[(int)mainBlocksetUpDown.Value][6].ToString();
            main8Box.Text = tempmainGfx[(int)mainBlocksetUpDown.Value][7].ToString();

            room1Box.Text = temproomGfx[(int)roomUpDown.Value][0].ToString();
            room2Box.Text = temproomGfx[(int)roomUpDown.Value][1].ToString();
            room3Box.Text = temproomGfx[(int)roomUpDown.Value][2].ToString();
            room4Box.Text = temproomGfx[(int)roomUpDown.Value][3].ToString();

            sprite1Box.Text = tempspriteGfx[(int)spriteUpDown.Value][0].ToString();
            sprite2Box.Text = tempspriteGfx[(int)spriteUpDown.Value][1].ToString();
            sprite3Box.Text = tempspriteGfx[(int)spriteUpDown.Value][2].ToString();
            sprite4Box.Text = tempspriteGfx[(int)spriteUpDown.Value][3].ToString();

            palette1Box.Text = temppaletteGfx[(int)paletteUpDown.Value][0].ToString();
            palette2Box.Text = temppaletteGfx[(int)paletteUpDown.Value][1].ToString();
            palette3Box.Text = temppaletteGfx[(int)paletteUpDown.Value][2].ToString();
            palette4Box.Text = temppaletteGfx[(int)paletteUpDown.Value][3].ToString();
            editedFromForm = false;
        }

        private void LoadGfx()
        {
            editedFromForm = true;
            main1Box.Text = GfxGroups.mainGfx[(int)mainBlocksetUpDown.Value][0].ToString();
            main2Box.Text = GfxGroups.mainGfx[(int)mainBlocksetUpDown.Value][1].ToString();
            main3Box.Text = GfxGroups.mainGfx[(int)mainBlocksetUpDown.Value][2].ToString();
            main4Box.Text = GfxGroups.mainGfx[(int)mainBlocksetUpDown.Value][3].ToString();
            main5Box.Text = GfxGroups.mainGfx[(int)mainBlocksetUpDown.Value][4].ToString();
            main6Box.Text = GfxGroups.mainGfx[(int)mainBlocksetUpDown.Value][5].ToString();
            main7Box.Text = GfxGroups.mainGfx[(int)mainBlocksetUpDown.Value][6].ToString();
            main8Box.Text = GfxGroups.mainGfx[(int)mainBlocksetUpDown.Value][7].ToString();

            room1Box.Text = GfxGroups.roomGfx[(int)roomUpDown.Value][0].ToString();
            room2Box.Text = GfxGroups.roomGfx[(int)roomUpDown.Value][1].ToString();
            room3Box.Text = GfxGroups.roomGfx[(int)roomUpDown.Value][2].ToString();
            room4Box.Text = GfxGroups.roomGfx[(int)roomUpDown.Value][3].ToString();

            sprite1Box.Text = GfxGroups.spriteGfx[(int)spriteUpDown.Value][0].ToString();
            sprite2Box.Text = GfxGroups.spriteGfx[(int)spriteUpDown.Value][1].ToString();
            sprite3Box.Text = GfxGroups.spriteGfx[(int)spriteUpDown.Value][2].ToString();
            sprite4Box.Text = GfxGroups.spriteGfx[(int)spriteUpDown.Value][3].ToString();

            palette1Box.Text = GfxGroups.paletteGfx[(int)paletteUpDown.Value][0].ToString();
            palette2Box.Text = GfxGroups.paletteGfx[(int)paletteUpDown.Value][1].ToString();
            palette3Box.Text = GfxGroups.paletteGfx[(int)paletteUpDown.Value][2].ToString();
            palette4Box.Text = GfxGroups.paletteGfx[(int)paletteUpDown.Value][3].ToString();
            editedFromForm = false;
        }

        private void main1Box_TextChanged(object sender, EventArgs e)
        {

        }

        private byte getTextBoxValue(TextBox tb)
        {
            byte r = 0;
            byte.TryParse(tb.Text, out r);
            return r;
        }

        private void allBox_TextChanged(object sender, EventArgs e)
        {
            if (editedFromForm == false)
            {
                GfxGroups.mainGfx[(int)mainBlocksetUpDown.Value][0] = getTextBoxValue(main1Box);
                GfxGroups.mainGfx[(int)mainBlocksetUpDown.Value][1] = getTextBoxValue(main2Box);
                GfxGroups.mainGfx[(int)mainBlocksetUpDown.Value][2] = getTextBoxValue(main3Box);
                GfxGroups.mainGfx[(int)mainBlocksetUpDown.Value][3] = getTextBoxValue(main4Box);
                GfxGroups.mainGfx[(int)mainBlocksetUpDown.Value][4] = getTextBoxValue(main5Box);
                GfxGroups.mainGfx[(int)mainBlocksetUpDown.Value][5] = getTextBoxValue(main6Box);
                GfxGroups.mainGfx[(int)mainBlocksetUpDown.Value][6] = getTextBoxValue(main7Box);
                GfxGroups.mainGfx[(int)mainBlocksetUpDown.Value][7] = getTextBoxValue(main8Box);

                GfxGroups.roomGfx[(int)roomUpDown.Value][0] = getTextBoxValue(room1Box);
                GfxGroups.roomGfx[(int)roomUpDown.Value][1] = getTextBoxValue(room2Box);
                GfxGroups.roomGfx[(int)roomUpDown.Value][2] = getTextBoxValue(room3Box);
                GfxGroups.roomGfx[(int)roomUpDown.Value][3] = getTextBoxValue(room4Box);

                GfxGroups.spriteGfx[(int)spriteUpDown.Value][0] = getTextBoxValue(sprite1Box);
                GfxGroups.spriteGfx[(int)spriteUpDown.Value][1] = getTextBoxValue(sprite2Box);
                GfxGroups.spriteGfx[(int)spriteUpDown.Value][2] = getTextBoxValue(sprite3Box);
                GfxGroups.spriteGfx[(int)spriteUpDown.Value][3] = getTextBoxValue(sprite4Box);

                GfxGroups.paletteGfx[(int)paletteUpDown.Value][0] = getTextBoxValue(palette1Box);
                GfxGroups.paletteGfx[(int)paletteUpDown.Value][1] = getTextBoxValue(palette2Box);
                GfxGroups.paletteGfx[(int)paletteUpDown.Value][2] = getTextBoxValue(palette3Box);
                GfxGroups.paletteGfx[(int)paletteUpDown.Value][3] = getTextBoxValue(palette4Box);

                mainForm.activeScene.room.reloadGfx();
                reloadGfx();
                mainForm.activeScene.DrawRoom();
                mainForm.activeScene.Refresh();

            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            GfxGroups.mainGfx[(int)mainBlocksetUpDown.Value][0] = getTextBoxValue(main1Box);
            GfxGroups.mainGfx[(int)mainBlocksetUpDown.Value][1] = getTextBoxValue(main2Box);
            GfxGroups.mainGfx[(int)mainBlocksetUpDown.Value][2] = getTextBoxValue(main3Box);
            GfxGroups.mainGfx[(int)mainBlocksetUpDown.Value][3] = getTextBoxValue(main4Box);
            GfxGroups.mainGfx[(int)mainBlocksetUpDown.Value][4] = getTextBoxValue(main5Box);
            GfxGroups.mainGfx[(int)mainBlocksetUpDown.Value][5] = getTextBoxValue(main6Box);
            GfxGroups.mainGfx[(int)mainBlocksetUpDown.Value][6] = getTextBoxValue(main7Box);
            GfxGroups.mainGfx[(int)mainBlocksetUpDown.Value][7] = getTextBoxValue(main8Box);

            GfxGroups.roomGfx[(int)roomUpDown.Value][0] = getTextBoxValue(room1Box);
            GfxGroups.roomGfx[(int)roomUpDown.Value][1] = getTextBoxValue(room2Box);
            GfxGroups.roomGfx[(int)roomUpDown.Value][2] = getTextBoxValue(room3Box);
            GfxGroups.roomGfx[(int)roomUpDown.Value][3] = getTextBoxValue(room4Box);

            GfxGroups.spriteGfx[(int)spriteUpDown.Value][0] = getTextBoxValue(sprite1Box);
            GfxGroups.spriteGfx[(int)spriteUpDown.Value][1] = getTextBoxValue(sprite2Box);
            GfxGroups.spriteGfx[(int)spriteUpDown.Value][2] = getTextBoxValue(sprite3Box);
            GfxGroups.spriteGfx[(int)spriteUpDown.Value][3] = getTextBoxValue(sprite4Box);

            GfxGroups.paletteGfx[(int)paletteUpDown.Value][0] = getTextBoxValue(palette1Box);
            GfxGroups.paletteGfx[(int)paletteUpDown.Value][1] = getTextBoxValue(palette2Box);
            GfxGroups.paletteGfx[(int)paletteUpDown.Value][2] = getTextBoxValue(palette3Box);
            GfxGroups.paletteGfx[(int)paletteUpDown.Value][3] = getTextBoxValue(palette4Box);

            CreateTempGfx();
        }

        private void GfxGroupsForm_Shown(object sender, EventArgs e)
        {

        }

        private void blocksetchanged(object sender, EventArgs e)
        {
            LoadGfx();
            reloadGfx();
        }

        private void allbox_click(object sender, EventArgs e)
        {
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
            if (tabControl1.SelectedIndex == 0) //main 
            {
                main = true;
                byte blockset = (byte)mainBlocksetUpDown.Value;
                for (int i = 0; i < 8; i++)
                {
                    blocks[i] = GfxGroups.mainGfx[blockset][i];
                }
            }
            if (tabControl1.SelectedIndex == 1) //room ?
            {
                byte blockset = (byte)roomUpDown.Value;
                for (int i = 0; i < 4; i++)
                {
                    blocks[i] = GfxGroups.roomGfx[blockset][i];
                } //12-16 sprites
            }

            if (tabControl1.SelectedIndex == 2) //room ?
            {
                byte blockset = (byte)spriteUpDown.Value;
                for (int i = 0; i < 4; i++)
                {
                    blocks[i] = (byte)(GfxGroups.spriteGfx[blockset][i] + 115);
                } //12-16 sprites
            }


            unsafe
            {
                byte* newPdata = (byte*)GFX.allgfx16Ptr.ToPointer(); //turn gfx16 (all 222 of them)
                byte* sheetsData = (byte*)GFX.currentEditinggfx16Ptr.ToPointer(); //into "room gfx16" 16 of them
                int sheetPos = 0;
                for (int i = 0; i < 8; i++)
                {
                    int d = 0;
                    while (d < 2048)
                    {
                        //NOTE LOAD BLOCKSETS SOMEWHERE FIRST
                        byte mapByte = newPdata[d + (blocks[i] * 2048)];
                        if (main)
                        {
                            switch (i)
                            {
                                case 0:
                                case 1:
                                case 2:
                                case 3:

                                    //case 5:
                                    mapByte += 0x88;
                                    break;

                            } //last line of 6, first line of 7 ?
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
                ColorPalette cp = GFX.currentEditingfx16Bitmap.Palette;
                for (int i = 0; i < 16; i++)
                {
                    cp.Entries[i] = Color.FromArgb(i * 15, i * 15, i * 15);
                }
                GFX.currentEditingfx16Bitmap.Palette = cp;
            }
            else if (paletteRadioButton.Checked)
            {
                ColorPalette cp = GFX.currentEditingfx16Bitmap.Palette;
                for (int i = 0; i < 16; i++)
                {
                    cp.Entries[i] = palettes[i + ((int)numericUpDown1.Value * 16)];
                }
                GFX.currentEditingfx16Bitmap.Palette = cp;
            }
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.DrawImage(GFX.currentEditingfx16Bitmap, 0, 0);
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
        Color[] palettes = new Color[256];
        private void createPalette()
        {

            for(int i = 0; i<256;i++)
            {
                palettes[i] = Color.Black;
            }
            if (paletteUpDown.Value <= 40)
            {

                label9.Text = "Dungeon Main";
                label10.Text = "Dungeon Sprite Pal1";
                label11.Text = "Dungeon Sprite Pal2";
                label12.Text = "Dungeon Sprite Pal3";
                
                byte dungeon_palette_ptr = (byte)(GfxGroups.paletteGfx[(byte)paletteUpDown.Value][0]);
                short palette_pos = 0;
                int pId = 0;
                int pPos = 32;
                if (GfxGroups.paletteGfx[(byte)paletteUpDown.Value][0] % 2 == 0)
                {
                    palette_pos = (short)((ROM.DATA[0xDEC4B + dungeon_palette_ptr + 1] << 8) + ROM.DATA[0xDEC4B + dungeon_palette_ptr]);
                    pId = (palette_pos / 180);

                    
                    for (int i = 0; i < 90; i++)
                    {
                        if (pPos % 16 == 0)
                        {
                            pPos++;
                        }
                        if (pId < Palettes.dungeonsMain_Palettes.Length)
                        {
                            palettes[pPos] = Palettes.dungeonsMain_Palettes[pId][i];
                        }
                        pPos++;
                    }

                }
                pPos = 128;
                if (GfxGroups.paletteGfx[(int)paletteUpDown.Value][1] != 255)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        if (pPos % 16 == 0)
                        {
                            pPos++;
                        }
                        if (GfxGroups.paletteGfx[(int)paletteUpDown.Value][1] < Palettes.spritesAux1_Palettes.Length)
                        {
                            palettes[pPos++] = Palettes.spritesAux1_Palettes[GfxGroups.paletteGfx[(int)paletteUpDown.Value][1]][i];
                        }
                    }
                }
                pPos = 208;
                if (GfxGroups.paletteGfx[(int)paletteUpDown.Value][2] != 255)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        if (pPos % 16 == 0)
                        {
                            pPos++;
                        }
                        if (GfxGroups.paletteGfx[(int)paletteUpDown.Value][2] < Palettes.spritesAux3_Palettes.Length)
                        {
                            palettes[pPos++] = Palettes.spritesAux3_Palettes[GfxGroups.paletteGfx[(int)paletteUpDown.Value][2]][i];
                        }
                    }
                }
                pPos = 224;
                if (GfxGroups.paletteGfx[(int)paletteUpDown.Value][3] != 255)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        if (pPos % 16 == 0)
                        {
                            pPos++;
                        }
                        if (GfxGroups.paletteGfx[(int)paletteUpDown.Value][3] < Palettes.spritesAux3_Palettes.Length)
                        {
                            palettes[pPos] = Palettes.spritesAux3_Palettes[GfxGroups.paletteGfx[(int)paletteUpDown.Value][3]][i];
                        }
                        pPos++;
                    }
                }
            }
            else
            {
                label9.Text = "Auxiliary Pal1";
                label10.Text = "Auxiliary Pal2";
                label11.Text = "Animated Pal";
                label12.Text = "???";
                int pPos = 40;
                if (GfxGroups.paletteGfx[(int)paletteUpDown.Value][0] != 255)
                {
                    
                    for (int i = 0; i < 7; i++)
                    {
                        if (pPos % 16 == 0)
                        {
                            pPos++;
                        }
                        palettes[pPos] = Palettes.overworld_AuxPalettes[GfxGroups.paletteGfx[(int)paletteUpDown.Value][0]][i];
                        pPos++;
                    }
                    pPos = 56;
                    for (int i = 0; i < 7; i++)
                    {
                        if (pPos % 16 == 0)
                        {
                            pPos++;
                        }
                        palettes[pPos] = Palettes.overworld_AuxPalettes[GfxGroups.paletteGfx[(int)paletteUpDown.Value][0]][i + 7];
                        pPos++;
                    }
                    pPos = 72;
                    for (int i = 0; i < 7; i++)
                    {
                        if (pPos % 16 == 0)
                        {
                            pPos++;
                        }
                        palettes[pPos] = Palettes.overworld_AuxPalettes[GfxGroups.paletteGfx[(int)paletteUpDown.Value][0]][i + 14];
                        pPos++;
                    }
                }

                pPos = 88;
                if (GfxGroups.paletteGfx[(int)paletteUpDown.Value][1] != 255)
                {

                    for (int i = 0; i < 7; i++)
                    {
                        if (pPos % 16 == 0)
                        {
                            pPos++;
                        }
                        palettes[pPos] = Palettes.overworld_AuxPalettes[GfxGroups.paletteGfx[(int)paletteUpDown.Value][1]][i];
                        pPos++;
                    }
                    pPos = 104;
                    for (int i = 0; i < 7; i++)
                    {
                        if (pPos % 16 == 0)
                        {
                            pPos++;
                        }
                        palettes[pPos] = Palettes.overworld_AuxPalettes[GfxGroups.paletteGfx[(int)paletteUpDown.Value][1]][i + 7];
                        pPos++;
                    }
                    pPos = 120;
                    for (int i = 0; i < 7; i++)
                    {
                        if (pPos % 16 == 0)
                        {
                            pPos++;
                        }
                        palettes[pPos] = Palettes.overworld_AuxPalettes[GfxGroups.paletteGfx[(int)paletteUpDown.Value][1]][i + 14];
                        pPos++;
                    }
                }
                pPos = 112;
                if (GfxGroups.paletteGfx[(int)paletteUpDown.Value][2] != 255)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        if (pPos % 16 == 0)
                        {
                            pPos++;
                        }
                        palettes[pPos] = Palettes.overworld_AnimatedPalettes[GfxGroups.paletteGfx[(int)paletteUpDown.Value][2]][i];
                        pPos++;
                    }
                }
                pPos = 32;
                for (int i = 0; i < 7; i++)
                {
                    if (pPos % 16 == 0)
                    {
                        pPos++;
                    }
                    palettes[pPos] = Palettes.overworld_MainPalettes[0][i];
                    pPos++;
                }
                pPos = 48;
                for (int i = 0; i < 7; i++)
                {
                    if (pPos % 16 == 0)
                    {
                        pPos++;
                    }
                    palettes[pPos] = Palettes.overworld_MainPalettes[0][i+7];
                    pPos++;
                }
                pPos = 64;
                for (int i = 0; i < 7; i++)
                {
                    if (pPos % 16 == 0)
                    {
                        pPos++;
                    }
                    palettes[pPos] = Palettes.overworld_MainPalettes[0][i+14];
                    pPos++;
                }
                pPos = 80;
                for (int i = 0; i < 7; i++)
                {
                    if (pPos % 16 == 0)
                    {
                        pPos++;
                    }
                    palettes[pPos] = Palettes.overworld_MainPalettes[0][i+21];
                    pPos++;
                }
                pPos = 96;
                for (int i = 0; i < 7; i++)
                {
                    if (pPos % 16 == 0)
                    {
                        pPos++;
                    }
                    palettes[pPos] = Palettes.overworld_MainPalettes[0][i+28];
                    pPos++;
                }


            }
            if (paletteUpDown.Value <= 40)
            {
                if (GfxGroups.paletteGfx[(byte)paletteUpDown.Value][0] % 2 == 0)
                {
                    GFX.loadedPalettes = GFX.LoadDungeonPalette(mainForm.activeScene.room.Palette);
                    GFX.loadedSprPalettes = GFX.LoadSpritesPalette(mainForm.activeScene.room.Palette);
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
