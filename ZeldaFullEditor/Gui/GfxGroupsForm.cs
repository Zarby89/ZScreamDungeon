using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Windows.Forms;

namespace ZeldaFullEditor.Gui
{
    public partial class GfxGroupsForm : Panel
    {
        DungeonMain mainForm;

        public bool editedFromForm = false;
        public static byte[][] tempmainGfx = new byte[37][];
        public static byte[][] temproomGfx = new byte[82][];
        public static byte[][] tempspriteGfx = new byte[144][];
        public static byte[][] temppaletteGfx = new byte[72][];

        Color[] palettes = new Color[256];

        public GfxGroupsForm(DungeonMain mainForm)
        {
            this.InitializeComponent();
            this.mainForm = mainForm;
            this.BackColor = Color.FromKnownColor(KnownColor.Control);
            this.numericUpDown1.Hexadecimal = true;
            this.paletteUpDown.Hexadecimal = true;
            this.mainBlocksetUpDown.Hexadecimal = true;
            this.spriteUpDown.Hexadecimal = true;
            this.roomUpDown.Hexadecimal = true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will restore groups to the previously applied changes\r\n" +
                "Are you sure you want to restore Gfx Groups?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.LoadTempGfx();
                this.okButton_Click(null, e);
                this.reloadGfx();
                this.mainForm.activeScene.room.reloadGfx();
                this.mainForm.activeScene.DrawRoom();
                this.mainForm.activeScene.Refresh();
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
            this.editedFromForm = true;
            this.main1Box.Text = tempmainGfx[(int)this.mainBlocksetUpDown.Value][0].ToString("X2");
            this.main2Box.Text = tempmainGfx[(int)this.mainBlocksetUpDown.Value][1].ToString("X2");
            this.main3Box.Text = tempmainGfx[(int)this.mainBlocksetUpDown.Value][2].ToString("X2");
            this.main4Box.Text = tempmainGfx[(int)this.mainBlocksetUpDown.Value][3].ToString("X2");
            this.main5Box.Text = tempmainGfx[(int)this.mainBlocksetUpDown.Value][4].ToString("X2");
            this.main6Box.Text = tempmainGfx[(int)this.mainBlocksetUpDown.Value][5].ToString("X2");
            this.main7Box.Text = tempmainGfx[(int)this.mainBlocksetUpDown.Value][6].ToString("X2");
            this.main8Box.Text = tempmainGfx[(int)this.mainBlocksetUpDown.Value][7].ToString("X2");

            this.room1Box.Text = temproomGfx[(int)this.roomUpDown.Value][0].ToString("X2");
            this.room2Box.Text = temproomGfx[(int)this.roomUpDown.Value][1].ToString("X2");
            this.room3Box.Text = temproomGfx[(int)this.roomUpDown.Value][2].ToString("X2");
            this.room4Box.Text = temproomGfx[(int)this.roomUpDown.Value][3].ToString("X2");

            this.sprite1Box.Text = tempspriteGfx[(int)this.spriteUpDown.Value][0].ToString("X2");
            this.sprite2Box.Text = tempspriteGfx[(int)this.spriteUpDown.Value][1].ToString("X2");
            this.sprite3Box.Text = tempspriteGfx[(int)this.spriteUpDown.Value][2].ToString("X2");
            this.sprite4Box.Text = tempspriteGfx[(int)this.spriteUpDown.Value][3].ToString("X2");

            this.palette1Box.Text = temppaletteGfx[(int)this.paletteUpDown.Value][0].ToString("X2");
            this.palette2Box.Text = temppaletteGfx[(int)this.paletteUpDown.Value][1].ToString("X2");
            this.palette3Box.Text = temppaletteGfx[(int)this.paletteUpDown.Value][2].ToString("X2");
            this.palette4Box.Text = temppaletteGfx[(int)this.paletteUpDown.Value][3].ToString("X2");
            this.editedFromForm = false;
        }

        private void LoadGfx()
        {
            this.editedFromForm = true;
            this.main1Box.Text = GfxGroups.mainGfx[(int)this.mainBlocksetUpDown.Value][0].ToString("X2");
            this.main2Box.Text = GfxGroups.mainGfx[(int)this.mainBlocksetUpDown.Value][1].ToString("X2");
            this.main3Box.Text = GfxGroups.mainGfx[(int)this.mainBlocksetUpDown.Value][2].ToString("X2");
            this.main4Box.Text = GfxGroups.mainGfx[(int)this.mainBlocksetUpDown.Value][3].ToString("X2");
            this.main5Box.Text = GfxGroups.mainGfx[(int)this.mainBlocksetUpDown.Value][4].ToString("X2");
            this.main6Box.Text = GfxGroups.mainGfx[(int)this.mainBlocksetUpDown.Value][5].ToString("X2");
            this.main7Box.Text = GfxGroups.mainGfx[(int)this.mainBlocksetUpDown.Value][6].ToString("X2");
            this.main8Box.Text = GfxGroups.mainGfx[(int)this.mainBlocksetUpDown.Value][7].ToString("X2");

            this.room1Box.Text = GfxGroups.roomGfx[(int)this.roomUpDown.Value][0].ToString("X2");
            this.room2Box.Text = GfxGroups.roomGfx[(int)this.roomUpDown.Value][1].ToString("X2");
            this.room3Box.Text = GfxGroups.roomGfx[(int)this.roomUpDown.Value][2].ToString("X2");
            this.room4Box.Text = GfxGroups.roomGfx[(int)this.roomUpDown.Value][3].ToString("X2");

            this.sprite1Box.Text = GfxGroups.spriteGfx[(int)this.spriteUpDown.Value][0].ToString("X2");
            this.sprite2Box.Text = GfxGroups.spriteGfx[(int)this.spriteUpDown.Value][1].ToString("X2");
            this.sprite3Box.Text = GfxGroups.spriteGfx[(int)this.spriteUpDown.Value][2].ToString("X2");
            this.sprite4Box.Text = GfxGroups.spriteGfx[(int)this.spriteUpDown.Value][3].ToString("X2");

            this.palette1Box.Text = GfxGroups.paletteGfx[(int)this.paletteUpDown.Value][0].ToString("X2");
            this.palette2Box.Text = GfxGroups.paletteGfx[(int)this.paletteUpDown.Value][1].ToString("X2");
            this.palette3Box.Text = GfxGroups.paletteGfx[(int)this.paletteUpDown.Value][2].ToString("X2");
            this.palette4Box.Text = GfxGroups.paletteGfx[(int)this.paletteUpDown.Value][3].ToString("X2");
            this.editedFromForm = false;
        }

        private void main1Box_TextChanged(object sender, EventArgs e)
        {
            // TODO: Add something here?
        }

        private byte getTextBoxValue(TextBox tb) // Changed to hex
        {
            byte r = 0;
            byte.TryParse(tb.Text, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out r);
            return r;
        }

        private void allBox_TextChanged(object sender, EventArgs e)
        {
            if (!this.editedFromForm)
            {
                GfxGroups.mainGfx[(int)this.mainBlocksetUpDown.Value][0] = this.getTextBoxValue(this.main1Box);
                GfxGroups.mainGfx[(int)this.mainBlocksetUpDown.Value][1] = this.getTextBoxValue(this.main2Box);
                GfxGroups.mainGfx[(int)this.mainBlocksetUpDown.Value][2] = this.getTextBoxValue(this.main3Box);
                GfxGroups.mainGfx[(int)this.mainBlocksetUpDown.Value][3] = this.getTextBoxValue(this.main4Box);
                GfxGroups.mainGfx[(int)this.mainBlocksetUpDown.Value][4] = this.getTextBoxValue(this.main5Box);
                GfxGroups.mainGfx[(int)this.mainBlocksetUpDown.Value][5] = this.getTextBoxValue(this.main6Box);
                GfxGroups.mainGfx[(int)this.mainBlocksetUpDown.Value][6] = this.getTextBoxValue(this.main7Box);
                GfxGroups.mainGfx[(int)this.mainBlocksetUpDown.Value][7] = this.getTextBoxValue(this.main8Box);

                GfxGroups.roomGfx[(int)this.roomUpDown.Value][0] = this.getTextBoxValue(this.room1Box);
                GfxGroups.roomGfx[(int)this.roomUpDown.Value][1] = this.getTextBoxValue(this.room2Box);
                GfxGroups.roomGfx[(int)this.roomUpDown.Value][2] = this.getTextBoxValue(this.room3Box);
                GfxGroups.roomGfx[(int)this.roomUpDown.Value][3] = this.getTextBoxValue(this.room4Box);

                GfxGroups.spriteGfx[(int)this.spriteUpDown.Value][0] = this.getTextBoxValue(this.sprite1Box);
                GfxGroups.spriteGfx[(int)this.spriteUpDown.Value][1] = this.getTextBoxValue(this.sprite2Box);
                GfxGroups.spriteGfx[(int)this.spriteUpDown.Value][2] = this.getTextBoxValue(this.sprite3Box);
                GfxGroups.spriteGfx[(int)this.spriteUpDown.Value][3] = this.getTextBoxValue(this.sprite4Box);

                GfxGroups.paletteGfx[(int)this.paletteUpDown.Value][0] = this.getTextBoxValue(this.palette1Box);
                GfxGroups.paletteGfx[(int)this.paletteUpDown.Value][1] = this.getTextBoxValue(this.palette2Box);
                GfxGroups.paletteGfx[(int)this.paletteUpDown.Value][2] = this.getTextBoxValue(this.palette3Box);
                GfxGroups.paletteGfx[(int)this.paletteUpDown.Value][3] = this.getTextBoxValue(this.palette4Box);

                this.mainForm.activeScene.room.reloadGfx();
                this.reloadGfx();
                this.mainForm.activeScene.DrawRoom();
                this.mainForm.activeScene.Refresh();
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            GfxGroups.mainGfx[(int)this.mainBlocksetUpDown.Value][0] = this.getTextBoxValue(this.main1Box);
            GfxGroups.mainGfx[(int)this.mainBlocksetUpDown.Value][1] = this.getTextBoxValue(this.main2Box);
            GfxGroups.mainGfx[(int)this.mainBlocksetUpDown.Value][2] = this.getTextBoxValue(this.main3Box);
            GfxGroups.mainGfx[(int)this.mainBlocksetUpDown.Value][3] = this.getTextBoxValue(this.main4Box);
            GfxGroups.mainGfx[(int)this.mainBlocksetUpDown.Value][4] = this.getTextBoxValue(this.main5Box);
            GfxGroups.mainGfx[(int)this.mainBlocksetUpDown.Value][5] = this.getTextBoxValue(this.main6Box);
            GfxGroups.mainGfx[(int)this.mainBlocksetUpDown.Value][6] = this.getTextBoxValue(this.main7Box);
            GfxGroups.mainGfx[(int)this.mainBlocksetUpDown.Value][7] = this.getTextBoxValue(this.main8Box);

            GfxGroups.roomGfx[(int)this.roomUpDown.Value][0] = this.getTextBoxValue(this.room1Box);
            GfxGroups.roomGfx[(int)this.roomUpDown.Value][1] = this.getTextBoxValue(this.room2Box);
            GfxGroups.roomGfx[(int)this.roomUpDown.Value][2] = this.getTextBoxValue(this.room3Box);
            GfxGroups.roomGfx[(int)this.roomUpDown.Value][3] = this.getTextBoxValue(this.room4Box);

            GfxGroups.spriteGfx[(int)this.spriteUpDown.Value][0] = this.getTextBoxValue(this.sprite1Box);
            GfxGroups.spriteGfx[(int)this.spriteUpDown.Value][1] = this.getTextBoxValue(this.sprite2Box);
            GfxGroups.spriteGfx[(int)this.spriteUpDown.Value][2] = this.getTextBoxValue(this.sprite3Box);
            GfxGroups.spriteGfx[(int)this.spriteUpDown.Value][3] = this.getTextBoxValue(this.sprite4Box);

            GfxGroups.paletteGfx[(int)this.paletteUpDown.Value][0] = this.getTextBoxValue(this.palette1Box);
            GfxGroups.paletteGfx[(int)this.paletteUpDown.Value][1] = this.getTextBoxValue(this.palette2Box);
            GfxGroups.paletteGfx[(int)this.paletteUpDown.Value][2] = this.getTextBoxValue(this.palette3Box);
            GfxGroups.paletteGfx[(int)this.paletteUpDown.Value][3] = this.getTextBoxValue(this.palette4Box);

            this.CreateTempGfx();
        }

        private void GfxGroupsForm_Shown(object sender, EventArgs e)
        {
            // TODO: Add something here?
        }

        private void blocksetchanged(object sender, EventArgs e)
        {
            this.LoadGfx();
            this.reloadGfx();
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

            if (this.tabControl1.SelectedIndex == 0) // Main 
            {
                main = true;
                byte blockset = (byte)this.mainBlocksetUpDown.Value;

                for (int i = 0; i < 8; i++)
                {
                    blocks[i] = GfxGroups.mainGfx[blockset][i];
                }
            }

            if (this.tabControl1.SelectedIndex == 1) // Room ?
            {
                byte blockset = (byte)this.roomUpDown.Value;

                for (int i = 0; i < 4; i++)
                {
                    blocks[i] = GfxGroups.roomGfx[blockset][i];
                } // 12-16 sprites
            }

            if (this.tabControl1.SelectedIndex == 2) // Room ?
            {
                byte blockset = (byte)this.spriteUpDown.Value;

                for (int i = 0; i < 4; i++)
                {
                    blocks[i] = (byte)(GfxGroups.spriteGfx[blockset][i] + 115);
                } // 12-16 sprites
            }

            unsafe
            {
                byte* newPdata = (byte*)GFX.allgfx16Ptr.ToPointer(); // Turn gfx16 (all 222 of them)
                byte* sheetsData = (byte*)GFX.currentEditinggfx16Ptr.ToPointer(); // Into "room gfx16" 16 of them
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

            this.pictureBox1.Refresh();
            this.pictureBox2.Refresh();
            this.pictureBox3.Refresh();
            this.pictureBox4.Refresh();
        }

        private void allpreviewPaint(object sender, PaintEventArgs e)
        {
            if (this.grayscaleRadioButton.Checked)
            {
                ColorPalette cp = GFX.currentEditingfx16Bitmap.Palette;
                for (int i = 0; i < 16; i++)
                {
                    cp.Entries[i] = Color.FromArgb(i * 15, i * 15, i * 15);
                }

                GFX.currentEditingfx16Bitmap.Palette = cp;
            }
            else if (this.paletteRadioButton.Checked)
            {
                ColorPalette cp = GFX.currentEditingfx16Bitmap.Palette;
                for (int i = 0; i < 16; i++)
                {
                    cp.Entries[i] = this.palettes[i + ((int)this.numericUpDown1.Value * 16)];
                }

                GFX.currentEditingfx16Bitmap.Palette = cp;
            }

            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.DrawImage(GFX.currentEditingfx16Bitmap, 0, 0);
        }

        private void palettepreviewPaint(object sender, PaintEventArgs e)
        {
            this.createPalette();

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
                this.palettes[i] = Color.Black;
            }

            if (paletteUpDown.Value <= 42)
            {
                this.label9.Text = "Dungeon Main";
                this.label10.Text = "Dungeon Sprite Pal1";
                this.label11.Text = "Dungeon Sprite Pal2";
                this.label12.Text = "Dungeon Sprite Pal3";

                byte dungeon_palette_ptr = GfxGroups.paletteGfx[(byte)paletteUpDown.Value][0];
                short palette_pos = 0;
                int pId = 0;
                int pPos = 32;

                if (GfxGroups.paletteGfx[(byte)this.paletteUpDown.Value][0] % 2 == 0)
                {
                    palette_pos = (short)((ROM.DATA[0xDEC4B + dungeon_palette_ptr + 1] << 8) + ROM.DATA[0xDEC4B + dungeon_palette_ptr]);
                    pId = (palette_pos / 180);

                    for (int i = 0; i < 90; i++)
                    {
                        if (pPos % 16 == 0)
                        {
                            pPos++;
                        }

                        if (pId < Palettes.DungeonsMainPalettes.Length)
                        {
                            this.palettes[pPos] = Palettes.DungeonsMainPalettes[pId][i];
                        }

                        pPos++;
                    }
                }

                pPos = 128;
                if (GfxGroups.paletteGfx[(int)this.paletteUpDown.Value][1] != 255)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        if (pPos % 16 == 0)
                        {
                            pPos++;
                        }

                        if (GfxGroups.paletteGfx[(int)this.paletteUpDown.Value][1] < Palettes.SpritesAux1Palettes.Length)
                        {
                            this.palettes[pPos++] = Palettes.SpritesAux1Palettes[GfxGroups.paletteGfx[(int)this.paletteUpDown.Value][1]][i];
                        }
                    }
                }

                pPos = 208;
                if (GfxGroups.paletteGfx[(int)this.paletteUpDown.Value][2] != 255)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        if (pPos % 16 == 0)
                        {
                            pPos++;
                        }

                        if (GfxGroups.paletteGfx[(int)this.paletteUpDown.Value][2] < Palettes.SpritesAux3Palettes.Length)
                        {
                            this.palettes[pPos++] = Palettes.SpritesAux3Palettes[GfxGroups.paletteGfx[(int)this.paletteUpDown.Value][2]][i];
                        }
                    }
                }

                pPos = 224;
                if (GfxGroups.paletteGfx[(int)this.paletteUpDown.Value][3] != 255)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        if (pPos % 16 == 0)
                        {
                            pPos++;
                        }

                        if (GfxGroups.paletteGfx[(int)this.paletteUpDown.Value][3] < Palettes.SpritesAux3Palettes.Length)
                        {
                            this.palettes[pPos] = Palettes.SpritesAux3Palettes[GfxGroups.paletteGfx[(int)this.paletteUpDown.Value][3]][i];
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

                    this.palettes[pPos] = Palettes.GlobalSpritePalettes[0][i];
                    this.palettes[pPos + 16] = Palettes.GlobalSpritePalettes[0][i + 15];
                    this.palettes[pPos + 32] = Palettes.GlobalSpritePalettes[0][i + 30];
                    this.palettes[pPos + 48] = Palettes.GlobalSpritePalettes[0][i + 45];
                    pPos++;
                }
            }
            else
            {
                this.label9.Text = "Auxiliary Pal1";
                this.label10.Text = "Auxiliary Pal2";
                this.label11.Text = "Animated Pal";
                this.label12.Text = "???";
                int pPos = 40;

                if (GfxGroups.paletteGfx[(int)this.paletteUpDown.Value][0] != 255)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        if (pPos % 16 == 0)
                        {
                            pPos++;
                        }

                        int value = GfxGroups.paletteGfx[(int)this.paletteUpDown.Value][0];
                        value = value.Clamp(0, Palettes.OverworldAuxPalettes.Length - 1);

                        this.palettes[pPos] = Palettes.OverworldAuxPalettes[value][i];
                        pPos++;
                    }

                    pPos = 56;
                    for (int i = 0; i < 7; i++)
                    {
                        if (pPos % 16 == 0)
                        {
                            pPos++;
                        }

                        int value = GfxGroups.paletteGfx[(int)this.paletteUpDown.Value][0];
                        value = value.Clamp(0, Palettes.OverworldAuxPalettes.Length - 1);

                        this.palettes[pPos] = Palettes.OverworldAuxPalettes[value][i + 7];
                        pPos++;
                    }

                    pPos = 72;
                    for (int i = 0; i < 7; i++)
                    {
                        if (pPos % 16 == 0)
                        {
                            pPos++;
                        }

                        int value = GfxGroups.paletteGfx[(int)this.paletteUpDown.Value][0];
                        value = value.Clamp(0, Palettes.OverworldAuxPalettes.Length - 1);

                        this.palettes[pPos] = Palettes.OverworldAuxPalettes[value][i + 14];
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

                        int value = GfxGroups.paletteGfx[(int)this.paletteUpDown.Value][1];
                        value = value.Clamp(0, Palettes.OverworldAuxPalettes.Length - 1);

                        this.palettes[pPos] = Palettes.OverworldAuxPalettes[value][i];
                        pPos++;
                    }

                    pPos = 104;
                    for (int i = 0; i < 7; i++)
                    {
                        if (pPos % 16 == 0)
                        {
                            pPos++;
                        }

                        int value = GfxGroups.paletteGfx[(int)this.paletteUpDown.Value][1];
                        value = value.Clamp(0, Palettes.OverworldAuxPalettes.Length - 1);

                        this.palettes[pPos] = Palettes.OverworldAuxPalettes[value][i + 7];
                        pPos++;
                    }

                    pPos = 120;
                    for (int i = 0; i < 7; i++)
                    {
                        if (pPos % 16 == 0)
                        {
                            pPos++;
                        }

                        int value = GfxGroups.paletteGfx[(int)this.paletteUpDown.Value][1];
                        value = value.Clamp(0, Palettes.OverworldAuxPalettes.Length - 1);

                        this.palettes[pPos] = Palettes.OverworldAuxPalettes[value][i + 14];
                        pPos++;
                    }
                }

                pPos = 112;
                if (GfxGroups.paletteGfx[(int)this.paletteUpDown.Value][2] != 255)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        if (pPos % 16 == 0)
                        {
                            pPos++;
                        }

                        int value = GfxGroups.paletteGfx[(int)this.paletteUpDown.Value][2];
                        this.palettes[pPos] = Palettes.OverworldAnimatedPalettes[value][i];
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

                    this.palettes[pPos] = Palettes.OverworldMainPalettes[0][i];
                    pPos++;
                }

                pPos = 48;
                for (int i = 0; i < 7; i++)
                {
                    if (pPos % 16 == 0)
                    {
                        pPos++;
                    }

                    this.palettes[pPos] = Palettes.OverworldMainPalettes[0][i + 7];
                    pPos++;
                }

                pPos = 64;
                for (int i = 0; i < 7; i++)
                {
                    if (pPos % 16 == 0)
                    {
                        pPos++;
                    }

                    this.palettes[pPos] = Palettes.OverworldMainPalettes[0][i + 14];
                    pPos++;
                }

                pPos = 80;
                for (int i = 0; i < 7; i++)
                {
                    if (pPos % 16 == 0)
                    {
                        pPos++;
                    }

                    this.palettes[pPos] = Palettes.OverworldMainPalettes[0][i + 21];
                    pPos++;
                }

                pPos = 96;
                for (int i = 0; i < 7; i++)
                {
                    if (pPos % 16 == 0)
                    {
                        pPos++;
                    }

                    this.palettes[pPos] = Palettes.OverworldMainPalettes[0][i + 28];
                    pPos++;
                }
            }

            if (this.paletteUpDown.Value <= 40)
            {
                if (GfxGroups.paletteGfx[(byte)this.paletteUpDown.Value][0] % 2 == 0)
                {
                    GFX.loadedPalettes = GFX.LoadDungeonPalette(this.mainForm.activeScene.room.palette);
                    GFX.loadedSprPalettes = GFX.LoadSpritesPalette(this.mainForm.activeScene.room.palette);
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.reloadGfx();
        }

        private void GfxGroupsForm_VisibleChanged(object sender, EventArgs e)
        {
            this.CreateTempGfx();
            this.createPalette();
            this.reloadGfx();
            this.LoadGfx();
        }
    }
}
