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
        private Button button1;
        private Button button2;
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(281, 122);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Scroll";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(200, 122);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Scroll Back";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // TextPreview
            // 
            this.ClientSize = new System.Drawing.Size(368, 161);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "TextPreview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        public int scroll_max = 0;
        public int scroll = 0;
        Bitmap previewBitmap = new Bitmap(172, 520, PixelFormat.Format32bppArgb); //TODO : Add dynamic bitmap size
        private void TextPreview_Shown(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (scroll < 10)
            {
                scroll++;
                Bitmap bb = new Bitmap(344, 104, PixelFormat.Format32bppArgb);
                Graphics gg = Graphics.FromImage(bb);
                gg.Clear(Color.Black);
                gg.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                gg.DrawImage(previewBitmap, new Rectangle(0, 0, 344, 104), 0, (16 * scroll), 172, 52, GraphicsUnit.Pixel);
                pictureBox1.Image = bb;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (scroll > 0)
            {
                scroll--;
                Bitmap bb = new Bitmap(344, 104, PixelFormat.Format32bppArgb);
                Graphics gg = Graphics.FromImage(bb);
                gg.Clear(Color.Black);
                gg.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                gg.DrawImage(previewBitmap, new Rectangle(0, 0, 344, 104), 0, (16 * scroll), 172, 52, GraphicsUnit.Pixel);
                pictureBox1.Image = bb;
            }
        }
    }
}
