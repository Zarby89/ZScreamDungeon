using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;

namespace ZeldaFullEditor.Gui
{
    public partial class GfxImportExport : UserControl
    {
        DungeonMain mainForm;
        public int selectedSheet = 0;

        byte[][] modifiedSheets = new byte[Constants.NumberOfSheets][];
        byte[][] gfxSheets3bpp = new byte[Constants.NumberOfSheets][];

        int selectedPal = 0;

        Color[] palettes = new Color[8];

        public GfxImportExport(DungeonMain mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
        }

        private void pasteIndexed_Click(object sender, EventArgs e)
        {
            byte[] data = ImgClipboard.GetImageData();
            int nbrColor = 16;

            if (data[32] != 0x00)
            {
                nbrColor = data[32];
            }

            int pos = data[0] + (nbrColor * 4); // Palette data useless for now
            unsafe
            {
                byte* gdata = (byte*)GFX.allgfx16Ptr.ToPointer();
                int spos = 0;
                //byte* allgfx16Data2 = (byte*)allgfx16EDITPtr.ToPointer();

                for (int y = 31; y >= 0; y--)
                {
                    for (int x = 0; x < 64; x++)
                    {
                        gdata[spos + (selectedSheet * Constants.UncompressedSheetSize)] = data[pos + (x + (y * 64))];
                        spos++;
                    }
                }
            }

            allgfxPicturebox.Refresh();
        }

        private void allgfxPicturebox_MouseDown(object sender, MouseEventArgs e)
        {
            selectedSheet = (e.Y / 64);
            allgfxPicturebox.Refresh();
        }

        private void allgfxPicturebox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            e.Graphics.DrawImage(GFX.allgfxBitmap, Constants.Rect_0_0_256_14272, Constants.Rect_0_0_128_7136, GraphicsUnit.Pixel);
            e.Graphics.DrawRectangle(Constants.AquaPen2, new Rectangle(0, selectedSheet * 64, 256, 64));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int csize = 0;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "all *.bin |*.bin";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                byte[] ndata = ZCompressLibrary.Decompress.ALTTPDecompressGraphics(ROM.DATA, GFX.GetPCGfxAddress(ROM.DATA, (byte)selectedSheet), 0x1000, ref csize);
                FileStream fs = new FileStream(sfd.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                fs.Write(ndata, 0, ndata.Length);
                fs.Close();
            }

            byte[] sdata = new byte[Constants.UncompressedSheetSize];

            unsafe
            {
                byte* gdata = (byte*)GFX.allgfx16Ptr.ToPointer();
                for (int i = 0; i < Constants.UncompressedSheetSize; i++)
                {
                    sdata[i] = gdata[(selectedSheet * Constants.UncompressedSheetSize) + i];
                }
            }
        }

        /// <summary>
        /// Saves all gfx.
        /// </summary>
        /// <returns> True if saving failed.  </returns>
        public bool SaveAllGfx()
        {
            for (int i = 0; i < Constants.NumberOfSheets; i++)
            {
                byte[] sdata = new byte[Constants.UncompressedSheetSize];
                unsafe
                {
                    byte* gdata = (byte*)GFX.allgfx16Ptr.ToPointer();
                    for (int j = 0; j < Constants.UncompressedSheetSize; j++)
                    {
                        sdata[j] = gdata[(i * Constants.UncompressedSheetSize) + j];
                    }

                    if (GFX.isbpp3[i])
                    {
                        if (modifiedSheets[i] != null)
                        {
                            gfxSheets3bpp[i] = modifiedSheets[i];
                            modifiedSheets[i] = null;
                        }
                        else
                        {
                            gfxSheets3bpp[i] = GFX.pc4bppto3bppsnes(sdata);
                        }
                    }
                    else
                    {
                        if (modifiedSheets[i] != null)
                        {
                            // Console.WriteLine(i.ToString() + " Sheet has been modified");
                            gfxSheets3bpp[i] = modifiedSheets[i];
                            modifiedSheets[i] = null;
                        }
                        else
                        {
                            int compressedSize = 0;
                            gfxSheets3bpp[i] = ZCompressLibrary.Decompress.ALTTPDecompressGraphics(ROM.DATA,
                                GFX.GetPCGfxAddress(ROM.DATA, (byte)i),
                                Constants.UncompressedSheetSize,
                                ref compressedSize);
                        }
                    }
                }
            }

            Console.WriteLine("Reached");

            if (recompressAllGfx())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Recompresses all GFX.
        /// </summary>
        /// <returns> True if compressing failed. </returns>
        public bool recompressAllGfx()
        {
            int gfxPointer1 = Utils.SnesToPc((ROM.DATA[Constants.gfx_1_pointer + 1] << 8) + (ROM.DATA[Constants.gfx_1_pointer]));
            int gfxPointer2 = Utils.SnesToPc((ROM.DATA[Constants.gfx_2_pointer + 1] << 8) + (ROM.DATA[Constants.gfx_2_pointer]));
            int gfxPointer3 = Utils.SnesToPc((ROM.DATA[Constants.gfx_3_pointer + 1] << 8) + (ROM.DATA[Constants.gfx_3_pointer]));
            int pos = 0x8B800;
            int uPos = 0x87000;
            bool bpp2;

            for (int i = 0; i < Constants.NumberOfSheets; i++)
            {
                if (i < 115 || i > 126) // Not compressed
                {
                    bpp2 = false;
                    if (!GFX.isbpp3[i])
                    {
                        bpp2 = true;
                    }

                    if (ROM.DATA[gfxPointer1 + i] <= 0x20)
                    {
                        int saddr = Utils.PcToSnes(pos);
                        ROM.Write(gfxPointer3 + i, (byte)(saddr & 0xFF), WriteType.GFXPTR);
                        ROM.Write(gfxPointer2 + i, (byte)(saddr >> 8 & 0xFF), WriteType.GFXPTR);
                        ROM.Write(gfxPointer1 + i, (byte)(saddr >> 16 & 0xFF), WriteType.GFXPTR);
                        if (!bpp2)
                        {
                            byte[] cbytes = ZCompressLibrary.Compress.ALTTPCompressGraphics(gfxSheets3bpp[i], 0, Constants.Uncompressed3BPPSize);
                            if (cbytes == null)
                            {
                                return true;
                            }

                            int s = cbytes.Length;
                            cbytes.CopyTo(ROM.DATA, pos);
                            pos += s;
                        }
                        else
                        {
                            byte[] cbytes = ZCompressLibrary.Compress.ALTTPCompressGraphics(gfxSheets3bpp[i], 0, Constants.UncompressedSheetSize);
                            if (cbytes == null)
                            {
                                return true;
                            }

                            int s = cbytes.Length;
                            cbytes.CopyTo(ROM.DATA, pos);
                            pos += s;
                        }
                    }
                    else // Save it back in expanded data if it was already
                    {
                        if (!bpp2)
                        {
                            byte[] b = new byte[] { ROM.DATA[gfxPointer3 + i], ROM.DATA[gfxPointer2 + i], ROM.DATA[gfxPointer1 + i], 0 };
                            int addr = BitConverter.ToInt32(b, 0);

                            byte[] cbytes = ZCompressLibrary.Compress.ALTTPCompressGraphics(gfxSheets3bpp[i], 0, Constants.Uncompressed3BPPSize);
                            if (cbytes == null)
                            {
                                return true;
                            }

                            int s = cbytes.Length;
                            cbytes.CopyTo(ROM.DATA, Utils.SnesToPc(addr));
                            //pos += s;
                        }
                        else
                        {
                            byte[] b = new byte[] { ROM.DATA[gfxPointer3 + i], ROM.DATA[gfxPointer2 + i], ROM.DATA[gfxPointer1 + i], 0 };
                            int addr = BitConverter.ToInt32(b, 0);

                            byte[] cbytes = ZCompressLibrary.Compress.ALTTPCompressGraphics(gfxSheets3bpp[i], 0, Constants.UncompressedSheetSize);
                            if (cbytes == null)
                            {
                                return true;
                            }

                            int s = cbytes.Length;
                            cbytes.CopyTo(ROM.DATA, Utils.SnesToPc(addr));
                            //pos += s;
                        }
                    }
                }
                else
                {
                    if (ROM.DATA[gfxPointer1 + i] <= 0x20)
                    {
                        for (int j = 0; j < Constants.Uncompressed3BPPSize; j++)
                        {
                            ROM.Write(uPos + j, gfxSheets3bpp[i][j], WriteType.GFX);
                        }

                        uPos += Constants.Uncompressed3BPPSize;
                    }
                }
            }

            /*
            if (pos >= Constants.maxGfx)
            {
                MessageBox.Show("It is possible the gfx are overwriting data :( new gfx size is " + (pos - 0x8b800).ToString("X6"));
            }
            else
            {
                MessageBox.Show("Saved successfully total of remaining space for gfx : " + (Constants.maxGfx - pos).ToString("X6"));
            }
            */

            infoLabel.Text =
            "Compressed Size = " + (pos - 0x8b800).ToString("X6") + "\r\n" +
            "Available Space = " + (Constants.maxGfx - pos).ToString("X6");

            return false;
        }

        private void palettePicturebox_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < 256; i++)
            {
                if (radioButton1.Checked)
                {
                    e.Graphics.FillRectangle(new SolidBrush(GFX.roomBg1Bitmap.Palette.Entries[i]), new Rectangle((i % 16) * 16, (i / 16) * 16, 16, 16));
                }
                else
                {
                    e.Graphics.FillRectangle(new SolidBrush(GFX.mapgfx16Bitmap.Palette.Entries[i]), new Rectangle((i % 16) * 16, (i / 16) * 16, 16, 16));
                }
            }

            e.Graphics.DrawRectangle(Pens.Lime, new Rectangle(0, selectedPal * 16, 256, 16));
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            palettePicturebox.Refresh();
        }

        private void palettePicturebox_MouseDown(object sender, MouseEventArgs e)
        {
            selectedPal = (e.Y / 16);

            ColorPalette cp = GFX.allgfxBitmap.Palette;
            for (int i = 0; i < 16; i++)
            {
                if (radioButton1.Checked)
                {
                    cp.Entries[i] = GFX.roomBg1Bitmap.Palette.Entries[i + selectedPal * 16];
                }
                else
                {

                    cp.Entries[i] = GFX.mapgfx16Bitmap.Palette.Entries[i + selectedPal * 16];
                }
            }

            GFX.allgfxBitmap.Palette = cp;
            allgfxPicturebox.Refresh();
            palettePicturebox.Refresh();
        }

        private void copyIndexed_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            byte[] sdata = new byte[Constants.UncompressedSheetSize];

            unsafe
            {
                byte* gdata = (byte*)GFX.allgfx16Ptr.ToPointer();
                for (int i = 0; i < Constants.UncompressedSheetSize; i++)
                {
                    sdata[i] = gdata[(selectedSheet * Constants.UncompressedSheetSize) + i];
                }
            }

            byte[] pdata = new byte[64];
            for (int i = 0; i < 16; i++)
            {
                pdata[(i * 4) + 0] = GFX.allgfxBitmap.Palette.Entries[i].B;
                pdata[(i * 4) + 1] = GFX.allgfxBitmap.Palette.Entries[i].G;
                pdata[(i * 4) + 2] = GFX.allgfxBitmap.Palette.Entries[i].R;
                pdata[(i * 4) + 3] = GFX.allgfxBitmap.Palette.Entries[i].A;
            }

            ImgClipboard.SetImageData(sdata, pdata);
        }

        private void copy24bpp_Click(object sender, EventArgs e)
        {
            byte[] sdata = new byte[Constants.UncompressedSheetSize];
            unsafe
            {
                byte* gdata = (byte*)GFX.allgfx16Ptr.ToPointer();
                for (int i = 0; i < Constants.UncompressedSheetSize; i++)
                {
                    sdata[i] = gdata[(selectedSheet * Constants.UncompressedSheetSize) + i];
                }
            }

            byte[] pdata = new byte[64];
            for (int i = 0; i < 16; i++)
            {
                pdata[(i * 4) + 0] = GFX.allgfxBitmap.Palette.Entries[i].B;
                pdata[(i * 4) + 1] = GFX.allgfxBitmap.Palette.Entries[i].G;
                pdata[(i * 4) + 2] = GFX.allgfxBitmap.Palette.Entries[i].R;
                pdata[(i * 4) + 3] = GFX.allgfxBitmap.Palette.Entries[i].A;
            }

            ImgClipboard.SetImageDataWithPal(sdata, pdata);
        }

        public void copy()
        {
            copy24bpp_Click(null, null);
        }

        public void paste()
        {
            paste24bpp_Click(null, null);
        }

        private void paste24bpp_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsImage())
            {
                Bitmap b = (Bitmap)Clipboard.GetImage();
                BitmapData bd = b.LockBits(Constants.Rect_0_0_128_40, ImageLockMode.ReadOnly, PixelFormat.Format32bppRgb);

                unsafe
                {
                    byte* gdata = (byte*)GFX.allgfx16Ptr.ToPointer();
                    byte* data = (byte*)bd.Scan0.ToPointer();
                    // One line is 512 - palette (32 bytes per palettes)
                    for (int i = 0; i < 8; i++)
                    {
                        palettes[i] = Color.FromArgb(data[(i * 32) + 2 - 0x4800], data[(i * 32) + 1 - 0x4800], data[(i * 32) - 0x4800]);
                        Console.WriteLine("R: " + palettes[i].R + " G: " + palettes[i].G + " B: " + palettes[i].B);
                    }

                    int pos = 0; // Should be line where data start inverted
                    for (int y = 0; y < 32; y++) // for each line
                    {
                        for (int x = 0; x < 64; x++) // Advance by 64 pixel but merge them together
                        {
                            byte pix1 = matchPalette(Color.FromArgb(data[(x * 8) + 2 - (y * 512)], data[(x * 8) + 1 - (y * 512)], data[(x * 8) - (y * 512)]));
                            byte pix2 = matchPalette(Color.FromArgb(data[(x * 8) + 6 - (y * 512)], data[(x * 8) + 5 - (y * 512)], data[(x * 8) + 4 - (y * 512)]));
                            byte mpix = (byte)((pix1 << 4) + pix2);
                            gdata[pos + (selectedSheet * Constants.UncompressedSheetSize)] = mpix;
                            pos++;
                        }
                    }
                }

                b.UnlockBits(bd);
                mainForm.activeScene.room.reloadGfx();
                mainForm.activeScene.DrawRoom();
                mainForm.activeScene.Refresh();
                allgfxPicturebox.Refresh();

                for (int i = 0; i < 159; i++)
                {
                    mainForm.overworldEditor.overworld.AllMaps[i].needRefresh = true;
                }
            }
        }

        public byte matchPalette(Color c)
        {
            for (int i = 0; i < 8; i++)
            {
                if (palettes[i].R == c.R && palettes[i].G == c.G && palettes[i].B == c.B)
                {
                    return (byte)i;
                }
            }

            return 1;
        }

        private void GfxImportExport_Load(object sender, EventArgs e)
        {
            GfxGroupsForm gfxgf = new GfxGroupsForm(this.mainForm);
            gfxgf.Location = Constants.Point_0_0;
            this.panel2.Controls.Add(mainForm.gfxGroupsForm);

            PaletteEditor palf = new PaletteEditor(mainForm);
            palf.Location = new Point(0, 354);
            this.panel2.Controls.Add(palf);
            Refresh();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "all *.bin |*.bin";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                if (fs.Length > Constants.UncompressedSheetSize)
                {
                    if (MessageBox.Show("This graphic file seems to be bigger than expected do you still want to proceed?", "Warning", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        fs.Close();
                        return;
                    }
                }

                modifiedSheets[selectedSheet] = new byte[(int)fs.Length];
                fs.Read(modifiedSheets[selectedSheet], 0, (int)fs.Length);
                fs.Close();
            }
        }
    }
}
