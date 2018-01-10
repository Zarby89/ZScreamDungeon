using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeldaFullEditor
{
    public partial class TextPreview : Form
    {
        byte[] tiles;
        public Charactertable table;
        public TextPreview(Charactertable table)
        {
            InitializeComponent();
            tiles = load(ROM.DATA, 0x70000, 0x73844);
            this.table = table;
        }
        //Thanks to smallhacker for his code to extra the particular format the fonts are
        public byte[] load(byte[] file, int startOfTileData, int startOfTileBitmask)
        {
            int tilePointer = startOfTileData;
            int bitmaskPointer = startOfTileBitmask;
            byte[] tiles = new byte[176 * 512];
            for (int tile = 0; tile < 512; tile++)
            {
                long bitmask = 0;
                for (int i = 0; i < 5; i++)
                {
                    bitmask <<= 8;
                    bitmask |= (file[bitmaskPointer++]);
                }

                byte[] packed = new byte[44];

                for (int i = 0; i < 40; i++)
                {
                    if ((bitmask & 0x8000000000) != 0)
                    {
                        packed[i + 4] = file[tilePointer++];
                    }
                    bitmask <<= 1;
                }

                byte[] unpacked = unpack(packed);
                for (int i = 0; i < 176; i++)
                {
                    tiles[tile * 176 + i] = unpacked[i];
                }
            }
            return tiles;
        }

        public static unsafe byte* currentData;
        public static IntPtr currentPtr;
        private PictureBox pictureBox1;
        public static BitmapData currentbmpData;
        public unsafe Bitmap getBitmap(int index,int colorIndex)
        {
            Bitmap b = new Bitmap(11, 16,PixelFormat.Format32bppArgb);
            currentbmpData = b.LockBits(new Rectangle(0, 0, 11, 16), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            currentData = (byte*)currentbmpData.Scan0.ToPointer();
            int pos = (176 * index);
            int ipos = 0;
            for (int y = 0; y < 16; y++)
            {
                for (int x = 0; x < 11; x++)
                {
                    currentData[ipos] = GFX.hudPalettes[tiles[pos], colorIndex].B;
                    currentData[ipos + 1] = GFX.hudPalettes[tiles[pos], colorIndex].G;
                    currentData[ipos + 2] = GFX.hudPalettes[tiles[pos], colorIndex].R;
                    currentData[ipos + 3] = 255;
                    ipos += 4;
                    pos++;
                }
            }

            b.UnlockBits(currentbmpData);
            return b;
        }

        public byte[] unpack(byte[] packed)
        {
            int length = 11 * 16 / 8;

            byte[] unpacked = new byte[11 * 16];
            for (int i = 0; i < length; i++)
            {
                byte low = packed[i * 2];
                byte high = packed[i * 2 + 1];
                for (int bit = 0; bit < 8; bit++)
                {
                    byte pixel = (byte)(((low >> 7) & 1) | ((high >> 6) & 2));

                    int index = toCoords(i, bit);

                    unpacked[index] = pixel;

                    low <<= 1;
                    high <<= 1;
                }
            }
            return unpacked;
        }


        private static int toCoords(int row, int bit)
        {
            if (row < 8)
            {
                return coordsToIndex(bit, row);
            }
            else if (row < 11)
            {
                return coordsToIndex(row, bit);
            }
            else if (row < 19)
            {
                return coordsToIndex(bit, row - 3);
            }
            else
            {
                return coordsToIndex(row - 19 + 8, bit + 8);
            }
        }

        public static int coordsToIndex(int x, int y)
        {
            return x + y * 11;
        }

        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(344, 104);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // TextPreview
            // 
            this.ClientSize = new System.Drawing.Size(368, 129);
            this.Controls.Add(this.pictureBox1);
            this.Name = "TextPreview";
            this.Text = "Text Preview";
            this.Load += new System.EventHandler(this.TextPreview_Load);
            this.Shown += new System.EventHandler(this.TextPreview_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private void TextPreview_Load(object sender, EventArgs e)
        {

        }
        public string text = "THE BLACK CATS[LN2]ARE HUNGRY.[LN3]COME BACK WITH";

        private void TextPreview_Shown(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap(172, 52, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(b);
            //3,11 starting draw pos
            //14 character * 3, 3 pixel between lines
            int pos = 0;
            int linePos = 0;
            int line = 0;
            int colorIndex = 6;
            text = text.Replace("\n", String.Empty).Replace("\t", String.Empty).Replace("\r", String.Empty);
            while (pos < text.Length)
            {

                //F7
                if ((text[pos] == '[') && (text[pos+1] == 'L') && (text[pos + 2] == 'N') && (text[pos + 3] == '1') && (text[pos + 4] == ']'))
                {
                    linePos = 0;
                    line = 0;
                    pos += 5;
                    continue;
                }
                //F8
                if ((text[pos] == '[') && (text[pos + 1] == 'L') && (text[pos + 2] == 'N') && (text[pos + 3] == '2') && (text[pos + 4] == ']'))
                {
                    linePos = 0;
                    line = 1;
                    pos += 5;
                    continue;
                }
                //F9
                if ((text[pos] == '[') && (text[pos + 1] == 'L') && (text[pos + 2] == 'N') && (text[pos + 3] == '3') && (text[pos + 4] == ']'))
                {
                    linePos = 0;
                    line = 2;
                    pos += 5;
                    continue;
                }
                if ((text[pos] == '[') && (text[pos + 1] == 'N') && (text[pos + 2] == 'W') && (text[pos + 3] == 'L') && (text[pos + 4] == ']'))
                {
                    pos += 5;
                    line++;
                    linePos = 0;
                    continue;
                }
                if ((text[pos] == '[') && (text[pos + 1] == 'S') && (text[pos + 2] == 'P') && (text[pos + 3] == 'D') && (text[pos + 4] == ' ') && (text[pos + 7] == ']'))
                {
                    //arguments = text[pos + 5], text[pos + 6]
                    pos += 8;
                    continue;
                }
                //F6
                if ((text[pos] == '[') && (text[pos + 1] == 'S') && (text[pos + 2] == 'C') && (text[pos + 3] == 'L') && (text[pos + 4] == ']'))
                {
                    linePos = 0;
                    line += 1;
                    pos += 6;
                    continue;
                }
                
                if ((text[pos] == '[') && (text[pos + 1] == 'P') && (text[pos + 2] == 'I') && (text[pos + 3] == 'C') && (text[pos + 4] == ']'))
                {
                    pos += 6;
                    continue;
                }

                if ((text[pos] == '[') && (text[pos + 1] == 'C') && (text[pos + 2] == 'H') && (text[pos + 3] == '1') && (text[pos + 4] == ']'))
                {
                    pos += 6;
                    continue;
                }
                if ((text[pos] == '[') && (text[pos + 1] == 'C') && (text[pos + 2] == 'H') && (text[pos + 3] == '2') && (text[pos + 4] == ']'))
                {
                    pos += 6;
                    continue;
                }
                if ((text[pos] == '[') && (text[pos + 1] == 'C') && (text[pos + 2] == 'H') && (text[pos + 3] == '3') && (text[pos + 4] == ']'))
                {
                    pos += 6;
                    continue;
                }
                if ((text[pos] == '[') && (text[pos + 1] == 'I') && (text[pos + 2] == 'T') && (text[pos + 3] == 'M') && (text[pos + 4] == ']'))
                {
                    pos += 6;
                    continue;
                }
                if ((text[pos] == '[') && (text[pos + 1] == 'N') && (text[pos + 2] == 'A') && (text[pos + 3] == 'M') && (text[pos + 4] == ']'))
                {
                    text = text.Replace("[NAM]", "NAME");
                    continue;
                }
                if ((text[pos] == '[') && (text[pos + 1] == 'W') && (text[pos + 2] == 'I') && (text[pos + 3] == 'N') && (text[pos + 4] == ' ') && (text[pos + 7] == ']'))
                {
                    //arguments = text[pos + 5], text[pos + 6]
                    pos += 8;
                    continue;
                }
                if ((text[pos] == '[') && (text[pos + 1] == 'N') && (text[pos + 2] == 'B') && (text[pos + 3] == 'R') && (text[pos + 4] == ' ') && (text[pos + 7] == ']'))
                {
                    //arguments = text[pos + 5], text[pos + 6]
                    text = text.Insert(pos + 8, "0");
                    pos += 8;
                    continue;
                }
                if ((text[pos] == '[') && (text[pos + 1] == 'W') && (text[pos + 2] == 'I') && (text[pos + 3] == 'N') && (text[pos + 4] == ' ') && (text[pos + 7] == ']'))
                {
                    //arguments = text[pos + 5], text[pos + 6]
                    pos += 8;
                    continue;
                }
                if ((text[pos] == '[') && (text[pos + 1] == 'P') && (text[pos + 2] == 'O') && (text[pos + 3] == 'S') && (text[pos + 4] == ' ') && (text[pos + 7] == ']'))
                {
                    //arguments = text[pos + 5], text[pos + 6]
                    pos += 8;
                    continue;
                }
                if ((text[pos] == '[') && (text[pos + 1] == 'S') && (text[pos + 2] == 'C') && (text[pos + 3] == 'S') && (text[pos + 4] == ' ') && (text[pos + 7] == ']'))
                {
                    //arguments = text[pos + 5], text[pos + 6]
                    pos += 8;
                    continue;
                }
                if ((text[pos] == '[') && (text[pos + 1] == 'S') && (text[pos + 2] == 'C') && (text[pos + 3] == 'H') && (text[pos + 4] == ' ') && (text[pos + 7] == ']'))
                {
                    //arguments = text[pos + 5], text[pos + 6]
                    pos += 8;
                    continue;
                }
                if ((text[pos] == '[') && (text[pos + 1] == 'C') && (text[pos + 2] == 'O') && (text[pos + 3] == 'L') && (text[pos + 4] == ' ') && (text[pos + 7] == ']'))
                {
                    //arguments = text[pos + 5], text[pos + 6]
                    colorIndex = byte.Parse(text[pos + 5].ToString() + text[pos + 6].ToString(), System.Globalization.NumberStyles.HexNumber);
                    pos += 8;
                    continue;
                }
                if ((text[pos] == '[') && (text[pos + 1] == 'W') && (text[pos + 2] == 'A') && (text[pos + 3] == 'I') && (text[pos + 4] == ' ') && (text[pos + 7] == ']'))
                {
                    //arguments = text[pos + 5], text[pos + 6]
                    pos += 8;
                    continue;
                }
                if ((text[pos] == '[') && (text[pos + 1] == 'S') && (text[pos + 2] == 'N') && (text[pos + 3] == 'D') && (text[pos + 4] == ' ') && (text[pos + 7] == ']'))
                {
                    //arguments = text[pos + 5], text[pos + 6]
                    pos += 8;
                    continue;
                }
                if ((text[pos] == '[') && (text[pos + 1] == 'M') && (text[pos + 2] == 'N') && (text[pos + 3] == 'U') && (text[pos + 4] == ' ') && (text[pos + 7] == ']'))
                {
                    //arguments = text[pos + 5], text[pos + 6]
                    pos += 8;
                    continue;
                }
                if ((text[pos] == '[') && (text[pos+3] == ']'))
                {
                    g.DrawImage(getBitmap(byte.Parse(text[pos + 1].ToString() + text[pos + 2].ToString(), System.Globalization.NumberStyles.HexNumber), colorIndex), 5 + (linePos * 11), 1 + (line * 16));
                    pos += 4;
                    linePos += 1;
                    continue;
                }
                /*

                [D2][D3] : Link's Face
                [E5][E7] : 1/4 Heart
                [E6][E7] : 1/2 Heart
                [E8][E9] : 3/4 Heart
                [EA][EB] : Full Heart
                */
                /*if (text[pos] == '.')
                {
                    g.DrawImage(getBitmap(0xCD, 6), 5 + (linePos * 11), 1 + (line * 16));
                    linePos++;
                    pos++;
                    continue;
                }*/


                if (text[pos] != ' ')
                {
                    ushort cvalue = table.charToHex(text[pos].ToString());
                    if ((cvalue & 0xFD00) == 0xFD00)
                    {
                        cvalue = (ushort)(0x100 | (cvalue & 0xFF));
                    }
                    g.DrawImage(getBitmap(cvalue, colorIndex), 5 + (linePos * 11), 1 + (line * 16));
                }

                linePos++;
                pos++;
                if (linePos>=15)
                {
                    linePos = 0;
                    line++;
                }
            }
            Bitmap bb = new Bitmap(344, 104, PixelFormat.Format32bppArgb);
            Graphics gg = Graphics.FromImage(bb);
            gg.Clear(Color.Black);
            gg.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            gg.DrawImage(b, new Rectangle(0, 0, 344, 104));
           
            pictureBox1.Image = bb;
            
            
        }
    }
}
