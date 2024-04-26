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

namespace ZeldaFullEditor.Gui.ExtraForms
{
    public partial class GfxEditor : Form
    {
        PointeredImage editingImage = new PointeredImage(128, 64);
        Color[] palette = new Color[8];
        byte selectedColor = 0;
        PaintingTools selectedTool = PaintingTools.Pen; // 0 pen, 1 selection
        bool changeOccured = false;
        public byte[] imageData;

        public GfxEditor()
        {
            InitializeComponent();
            zoomCombobox.SelectedIndex = 3;
        }
        int zoom = 1;
        private void mainPicturebox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            e.Graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
            e.Graphics.DrawImage(editingImage.bitmap, new Rectangle(0,0, 128 * zoom, 32 * zoom),new Rectangle(0,0,128,32),GraphicsUnit.Pixel);
            Rectangle selectionRectZoom = new Rectangle(selectionRect.X*zoom, selectionRect.Y*zoom, selectionRect.Width*zoom, selectionRect.Height*zoom);
            e.Graphics.DrawRectangle(Pens.White, selectionRectZoom);

        }

        private void GfxEditor_Load(object sender, EventArgs e)
        {

        }

        public void UpdateImage(byte[] data, Color[] colors)
        {
            colors[0] = Color.FromArgb(120, 120, 120);
            ColorPalette cp = editingImage.bitmap.Palette;

            for(int i = 0; i < palette.Length; i++) 
            {
                palette[i] = colors[i];
                cp.Entries[i] = palette[i];
                
            }
            editingImage.bitmap.Palette = cp;




            for (int i = 0; i < data.Length; i++)
            {
                editingImage[i] = data[i];
            }
            imageData = new byte[data.Length];
            for (int i = 0; i < data.Length; i++)
            {

                imageData[(i)] = (byte)((editingImage[(i * 2)] << 4) | editingImage[(i * 2) + 1]);
            }

            palettePicturebox.Invalidate();
        }
        int[] zooms = new int[5] { 1, 2, 4, 8, 16 };
        int[] zoomsFix = new int[5] { 0, 1, 2, 3, 4};
        private void zoomCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            zoom = zooms[zoomCombobox.SelectedIndex];
            mainPicturebox.Size = new Size(128*zoom,32*zoom);
            mainPicturebox.Invalidate();
        }

        private void palettePicturebox_Paint(object sender, PaintEventArgs e)
        {
            for(int i = 0;i < palette.Length;i++) 
            {
                e.Graphics.FillRectangle(new SolidBrush(palette[i]), new Rectangle(i*32, 0, 32, 32));
                
            }

            e.Graphics.DrawRectangle(new Pen(Brushes.LimeGreen, 2), new Rectangle(32*selectedColor,0,32,32));
        }


        bool mouseDown = false;
        int lastX = -1;
        int lastY = -1;
        int currentX = 0;
        int currentY = 0;
        Rectangle selectionRect = new Rectangle();
        
        private void mainPicturebox_MouseDown(object sender, MouseEventArgs e)
        {

            currentX = (e.X / zoom).Clamp(0, editingImage.bitmap.Width);
            currentY = (e.Y / zoom).Clamp(0, editingImage.bitmap.Height);
            lastX = currentX;
            lastY = currentY;
            if (e.Button == MouseButtons.Right)
            {
                selectedColor = editingImage[currentX, currentY];
                palettePicturebox.Invalidate();
                return;
            }

            if (selectedTool == PaintingTools.Pen)
            {
                changeOccured = true;
                mouseDown = true;
                editingImage[currentX, currentY] = selectedColor;
                mainPicturebox.Invalidate();
               
            }
            else if (selectedTool == PaintingTools.Selection)
            {
                mouseDown = true;
                selectionRect = new Rectangle(currentX, currentY, 0, 0);
            }
        }

        private void mainPicturebox_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                currentX = (e.X / zoom).Clamp(0,editingImage.bitmap.Width);
                currentY = (e.Y / zoom).Clamp(0, editingImage.bitmap.Height);
                if (selectedTool == PaintingTools.Pen)
                {
                    changeOccured = true;

                    if (lastX != currentX || lastY != currentY)
                    {
                        IEnumerable<Point> points = DrawLine.GetPointsOnLine(lastX, lastY, currentX, currentY);
                        foreach (Point p in points)
                        {
                            editingImage[p.X, p.Y] = selectedColor;
                        }

                        mainPicturebox.Invalidate();
                    }

                }
                else if (selectedTool == PaintingTools.Selection)
                {
                    if (lastX != currentX || lastY != currentY)
                    {
                        selectionRect.Width = (currentX - selectionRect.X);
                        selectionRect.Height = (currentY - selectionRect.Y);
                        mainPicturebox.Invalidate();
                    }


                }

                lastX = currentX;
                lastY = currentY;
            }
        }

        private void mainPicturebox_MouseUp(object sender, MouseEventArgs e)
        {
            currentX = (e.X / zoom).Clamp(0, editingImage.bitmap.Width);
            currentY = (e.Y / zoom).Clamp(0, editingImage.bitmap.Height);
            if (selectedTool == PaintingTools.Selection)
            {
                selectionRect.Width = (currentX - selectionRect.X);
                selectionRect.Height = (currentY - selectionRect.Y);

                mainPicturebox.Invalidate();
            }
            mouseDown = false;
        }

        private void palettePicturebox_MouseDown(object sender, MouseEventArgs e)
        {
            selectedColor = (byte)(e.X / 32);
            palettePicturebox.Invalidate();
        }

        private void GfxEditor_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (changeOccured)
            {
                DialogResult dr = MessageBox.Show("Sheet has been modified do you want to keep the changes?", "Warning", MessageBoxButtons.YesNoCancel);

                if (dr == DialogResult.Yes) 
                {
                    for(int i = 0;i<0x800;i++)
                    {
                        imageData[(i)] = (byte)((editingImage[(i * 2)]<<4) | editingImage[(i * 2)+1]);
                    }

                }
                else if (dr == DialogResult.No)
                {
                
                }
                else
                {
                    e.Cancel = true;
                }
            }

            
        }

        private void penButton_Click(object sender, EventArgs e)
        {
            penButton.Checked = false;
            selButton.Checked = false;
            (sender as ToolStripButton).Checked = true;
            if (penButton.Checked ) { selectedTool = PaintingTools.Pen; }
            if (selButton.Checked) { selectedTool = PaintingTools.Selection; }
        }

        private void fliphButton_Click(object sender, EventArgs e)
        {
            if (selectionRect.Width !=0 && selectionRect.Height !=0)
            {
                byte[] tempData = new byte[selectionRect.Width * selectionRect.Height];
;
                for (int h = 0; h < selectionRect.Height; h++)
                {
                    for (int w = 0; w < selectionRect.Width; w++)
                    {

                        tempData[(h * selectionRect.Width)+w] = editingImage[selectionRect.X+w, selectionRect.Y+h];

                    }
                }
               
                for (int h = 0; h < selectionRect.Height; h++)
                {
                    int x = 0;
                    for (int w = selectionRect.Width-1; w >=0 ; w--)
                    {
                        
                        editingImage[selectionRect.X + x, selectionRect.Y + h] = tempData[(h * selectionRect.Width) + w];
                        x++;
                    }
                }
            }
            mainPicturebox.Invalidate();
        }

        private void flipvButton_Click(object sender, EventArgs e)
        {
            if (selectionRect.Width != 0 && selectionRect.Height != 0)
            {
                byte[] tempData = new byte[selectionRect.Width * selectionRect.Height];
                ;
                for (int h = 0; h < selectionRect.Height; h++)
                {
                    for (int w = 0; w < selectionRect.Width; w++)
                    {

                        tempData[(h * selectionRect.Width) + w] = editingImage[selectionRect.X + w, selectionRect.Y + h];

                    }
                }
                int y = 0;
                for (int h = selectionRect.Height-1; h >=0; h--)
                {
                    
                    for (int w = 0; w < selectionRect.Width; w++)
                    {

                        editingImage[selectionRect.X + w, selectionRect.Y + y] = tempData[(h * selectionRect.Width) + w];
                        
                    }
                    y++;
                }
            }
            mainPicturebox.Invalidate();
        }
    }
    public static class DrawLine
    {
        public static IEnumerable<Point> GetPointsOnLine(int x0, int y0, int x1, int y1)
        {
            bool steep = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);
            if (steep)
            {
                int t;
                t = x0; // swap x0 and y0
                x0 = y0;
                y0 = t;
                t = x1; // swap x1 and y1
                x1 = y1;
                y1 = t;
            }
            if (x0 > x1)
            {
                int t;
                t = x0; // swap x0 and x1
                x0 = x1;
                x1 = t;
                t = y0; // swap y0 and y1
                y0 = y1;
                y1 = t;
            }
            int dx = x1 - x0;
            int dy = Math.Abs(y1 - y0);
            int error = dx / 2;
            int ystep = (y0 < y1) ? 1 : -1;
            int y = y0;
            for (int x = x0; x <= x1; x++)
            {
                yield return new Point((steep ? y : x), (steep ? x : y));
                error = error - dy;
                if (error < 0)
                {
                    y += ystep;
                    error += dx;
                }
            }
            yield break;
        }
    }

    enum PaintingTools
    {
        Pen, Selection
    }
}
