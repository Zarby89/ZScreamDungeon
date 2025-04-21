using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeldaFullEditor.Gui.ExtraForms
{
    public partial class ZsprImporter : Form
    {
        PointeredImage ptrImage = new PointeredImage(128, 448);
        Color[] pal1 = new Color[64];
        byte[] gfxData;
        byte[] bpp8Data;
        public ZsprImporter(string image)
        {
            InitializeComponent();

            BinaryReader br = new BinaryReader(new FileStream(image, FileMode.Open,FileAccess.Read));

            byte[] header = { br.ReadByte(), br.ReadByte(), br.ReadByte(), br.ReadByte() };
            if (header[0] == 0x5A && header[1] == 0x53 && header[2] == 0x50 && header[3] == 0x52) // this is a recognized ZSPR file
            {
                byte version = br.ReadByte();
                int checksum = br.ReadInt32();
                int dataStart = br.ReadInt32();
                ushort length = br.ReadUInt16();
                int dataPalStart = br.ReadInt32();
                ushort lengthPal = br.ReadUInt16();
                ushort sprType = br.ReadUInt16();
                br.ReadByte(); br.ReadByte(); br.ReadByte(); br.ReadByte(); br.ReadByte(); br.ReadByte(); // 6 empty bytes

                long npos = br.BaseStream.Position;

                byte b1 = br.ReadByte();
                byte b2 = br.ReadByte();
                int count = 2;
                while (true)
                {
                    b1 = br.ReadByte();
                    b2 = br.ReadByte();
                    if (b1 == 0 && b2 == 0)
                    {
                        break;
                    }

                    count += 2;
                }
                
                br.BaseStream.Seek(npos, SeekOrigin.Begin);
                byte[] displayTextBytes = br.ReadBytes(count);
                string displayText = Encoding.Unicode.GetString(displayTextBytes);
                br.ReadByte(); // burn the 2 zero bytes
                br.ReadByte();

                npos = br.BaseStream.Position;

                b1 = br.ReadByte();
                b2 = br.ReadByte();
                count = 2;
                while (true)
                {
                    b1 = br.ReadByte();
                    b2 = br.ReadByte();
                    if (b1 == 0 && b2 == 0)
                    {
                        break;
                    }

                    count += 2;
                }

                br.BaseStream.Seek(npos, SeekOrigin.Begin);
                byte[] displayAuthorBytes = br.ReadBytes(count);
                string author = Encoding.Unicode.GetString(displayAuthorBytes);
                //string displayText = br.ReadString();
                //string author = br.ReadString();

                labelInfos.Text = displayText + "\r\n" + author + "\r\n" + version.ToString();



                br.BaseStream.Seek(dataStart, SeekOrigin.Begin);
                gfxData = br.ReadBytes(0x7000);
                bpp8Data = GFX.SnesTilesToPc8bppTiles(gfxData, 0x380, 4);

                ptrImage.Draw8bppTiles(0, 0, bpp8Data, 16, 0, 0);


                br.BaseStream.Seek(dataPalStart, SeekOrigin.Begin);
                pal1[0] = Color.FromArgb(220, 220, 220);
                for (int i = 0; i < 15; i++)
                {
                    pal1[i+1] = GFX.getColor(br.ReadInt16());
                    ptrImage.UpdatePalettes(pal1);

                }
                for (int i = 0; i < 15; i++)
                {
                    pal1[i + 17] = GFX.getColor(br.ReadInt16());

                }
                for (int i = 0; i < 15; i++)
                {
                    pal1[i + 33] = GFX.getColor(br.ReadInt16());

                }
                for (int i = 0; i < 15; i++)
                {
                    pal1[i + 49] = GFX.getColor(br.ReadInt16());

                }
                //



            }

            //GFX.SnesTilesToPc8bppTiles()


        }

        private void ZsprImporter_Load(object sender, EventArgs e)
        {

        }

        private void gfxPicturebox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            e.Graphics.DrawImage(ptrImage.bitmap, new Rectangle(0, 0, 256, 896), new Rectangle(0, 0, 128, 448), GraphicsUnit.Pixel);
        }

        private void palettePicturebox_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < 64; i++)
            {
                e.Graphics.FillRectangle(new SolidBrush(pal1[i]), new Rectangle(((i%16) * 16), (i/16)*16, 16, 16));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                ROM.Write(0x80000, gfxData);
            }
            if (checkBox2.Checked)
            {
                for(int i = 0; i<15;i++)
                {
                    Palettes.ArmorPalettes[0][i] = pal1[i + 1];
                    Palettes.ArmorPalettes[1][i] = pal1[i + 17];
                    Palettes.ArmorPalettes[2][i] = pal1[i + 33];
                    Palettes.ArmorPalettes[3][i] = pal1[i + 49];
                }
            }

            this.Close();
        }

    }
}
