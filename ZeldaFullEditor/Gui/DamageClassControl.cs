using System;
using System.Drawing;
using System.Windows.Forms;
using ZeldaFullEditor.Properties;

namespace ZeldaFullEditor.Gui
{
    public partial class DamageClassControl : UserControl
    {
        private Bitmap controlBitmap;
        private byte[] origDamages = new byte[0x80];
        private int selectedX = 0;
        private int selectedY = 0;
        private int prevselectedX = 0;
        private int prevselectedY = 0;
        private int selectedIndex = -1;
        private int lastselectedIndex = -1;
        private bool top = false;
        private bool mouseDown = false;

        public DamageClassControl()
        {
            InitializeComponent();
            controlBitmap = new Bitmap(Resources.damageclass);
            MouseWheel += DamageClassControl_MouseWheel;
        }

        private void DamageClassControl_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(controlBitmap, new Rectangle(0,0,302,272), new Rectangle(0, 0, 302, 272), GraphicsUnit.Pixel);
            for (int j = 0; j < 16; j++)
            {
                // e.Graphics.DrawString(globalDamages[i + (j * 8)].ToString("X2"), this.Font, Brushes.Black, new Point(40 + (j * 32), ));
                for (int i = 0; i < 8; i++)
                {
                    if (DungeonsData.GlobalDamages[i + (j * 8)] != origDamages[i + (j * 8)])
                    {
                        e.Graphics.DrawString(DungeonsData.GlobalDamages[i + (j * 8)].ToString("X2"), this.Font, Brushes.Blue, new Point(48 + (i * 32), 18 + (j * 16)));
                    }
                    else
                    {
                        e.Graphics.DrawString(DungeonsData.GlobalDamages[i + (j * 8)].ToString("X2"), this.Font, Brushes.Black, new Point(48 + (i * 32), 18 + (j * 16)));
                    }
                }
            }

            if (selectedIndex != -1)
            {
                if (selectedIndex >= 128) // below 128 are the boxes themselves
                {
                    if (top)
                    {
                        e.Graphics.DrawImage(controlBitmap, new Rectangle(selectedX, selectedY, 9, 7), new Rectangle(9, 272, 9, 7), GraphicsUnit.Pixel);
                    }
                    else
                    {
                        e.Graphics.DrawImage(controlBitmap, new Rectangle(selectedX, selectedY, 9, 7), new Rectangle(27, 272, 9, 7), GraphicsUnit.Pixel);
                    }
                }
                else
                {
                    e.Graphics.DrawRectangle(Pens.Yellow, new Rectangle(selectedX, selectedY, 23, 15));
                }
            }
        }

        private void DamageClassControl_MouseMove(object sender, MouseEventArgs e)
        {
            selectedIndex = -1;
            for (int y = 0; y < 16; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if (e.X >= 68 + (x * 32) && e.X <= 78 + (x * 32))
                    {
                        if (e.Y >= 16 + (y * 16) && e.Y <= 24 + (y * 16)) // 1st top arrow
                        {
                            top = true;
                            selectedIndex = 0 + (x * 2) + (y * 16) + 128;
                            selectedX = 69 + (x * 32);
                            selectedY = 17 + (y * 16);
                        }

                        if (e.Y >= 25 + (y * 16) && e.Y <= 32 + (y * 16)) // 1st bottom arrow
                        {
                            top = false;
                            selectedIndex = 1 + (x * 2) + (y * 16) + 128;
                            selectedX = 69 + (x * 32);
                            selectedY = 25 + (y * 16);
                        }
                    }
                    else if (e.X >= 46 + (x * 32) && e.X <= 67 + (x * 32))
                    {
                        if (e.Y >= 16 + (y * 16) && e.Y <= 32 + (y * 16)) // 1st top arrow
                        {
                            top = true;
                            selectedIndex = 0 + (x * 1) + (y * 8);
                            selectedX = 46 + (x * 32);
                            selectedY = 17 + (y * 16);
                        }
                    }
                }
            }

            if (lastselectedIndex != selectedIndex)
            {
                lastselectedIndex = selectedIndex;
                if (selectedIndex >= 128)
                {
                    this.Invalidate(new Rectangle(selectedX, selectedY - 8, 16, 32));
                    this.Invalidate(new Rectangle(prevselectedX, prevselectedY - 8, 16, 32));
                }
                else
                {
                    this.Invalidate(new Rectangle(selectedX - 32, selectedY - 32, 64, 64));
                    this.Invalidate(new Rectangle(prevselectedX - 32, prevselectedY - 32, 64, 64));
                }

                prevselectedX = selectedX;
                prevselectedY = selectedY;
            }
        }

        private void DamageClassControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (selectedIndex >= 128)
            {
                buttonStartTimer.Enabled = true;
                mouseDown = true;
                if (((selectedIndex - 128) & 1) == 1)
                {
                    DungeonsData.GlobalDamages[(selectedIndex - 128) / 2] -= 1;
                    this.Invalidate(new Rectangle(selectedX - 32, selectedY - 12, 32, 28));
                }
                else
                {
                    DungeonsData.GlobalDamages[(selectedIndex - 128) / 2] += 1;
                    this.Invalidate(new Rectangle(selectedX - 32, selectedY - 12, 32, 28));
                }
            }
        }

        private void DamageClassControl_MouseWheel(object sender, MouseEventArgs e)
        {
            int index = selectedIndex;
            if (selectedIndex >= 128)
            {
                index = (selectedIndex - 128) / 2;
                this.Invalidate(new Rectangle(selectedX - 32, selectedY - 12, 32, 28));
            }

            if (index < 0)
            {
                return;
            }

            if (e.Delta > 0)
            {
                DungeonsData.GlobalDamages[index] += 1;
                
            }
            else if (e.Delta < 0)
            {
                DungeonsData.GlobalDamages[index] -= 1;
            }

            this.Invalidate(new Rectangle(selectedX, selectedY, 32, 28));
        }

        private void DamageClassControl_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            buttonStartTimer.Enabled = false;
            buttonTimer.Enabled = false;
        }

        private void buttonStartTimer_Tick(object sender, EventArgs e)
        {
            buttonTimer.Enabled = true;
        }

        private void buttonTimer_Tick(object sender, EventArgs e)
        {
            if (mouseDown)
            {
                if (selectedIndex >= 128)
                { 
                    if (((selectedIndex - 128) & 1) == 1)
                    {
                        DungeonsData.GlobalDamages[(selectedIndex - 128) / 2] -= 1;
                        this.Invalidate(new Rectangle(selectedX - 32, selectedY - 12, 32, 28));
                    }
                    else
                    {
                        DungeonsData.GlobalDamages[(selectedIndex - 128) / 2] += 1;
                        this.Invalidate(new Rectangle(selectedX - 32, selectedY - 12, 32, 28));
                    }
                }
            }
        }

        private void DamageClassControl_MouseLeave(object sender, EventArgs e)
        {
            buttonTimer.Enabled = false;
            buttonStartTimer.Enabled = false;
            this.Refresh();
        }

        private void DamageClassControl_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < origDamages.Length; i++)
            {
                origDamages[i] = DungeonsData.GlobalDamages[i];
            }
        }
    }
}
