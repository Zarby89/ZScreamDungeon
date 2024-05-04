using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeldaFullEditor.Gui
{
    public partial class WindowPanel : UserControl
    {
        public bool isClosing = false;
        public bool isMoving = false;
        public int xDragOffset = 0;
        public int yDragOffset = 0;

        public WindowPanel()
        {
            InitializeComponent();
            this.BackColor = Color.FromKnownColor(KnownColor.Control);
        }

        private void titleBarPanel_MouseDown(object sender, MouseEventArgs e)
        {
            Rectangle xRect = new Rectangle(titleBarPanel.Width - 16, 2, 20, 20);
            if (xRect.Contains(e.Location))
            {
                isClosing = true;
                Parent.Controls.Remove(this);
            }
            else
            {
                xDragOffset = e.X;
                yDragOffset = e.Y;
                isMoving = true;
            }
        }

        private void titleBarPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString((Tag as string), Font, Brushes.Black, new Point(4, 4));
            e.Graphics.DrawString("X", Font, Brushes.Black, new Point(titleBarPanel.Width - 16, 4));
        }

        private void titleBarPanel_MouseUp(object sender, MouseEventArgs e)
        {
            isMoving = false;
        }

        private void titleBarPanel_MouseLeave(object sender, EventArgs e)
        {
            // TODO: Add something here?
        }

        private void titleBarPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMoving)
            {
                int x = this.Location.X;
                int y = this.Location.Y;
                int mx = e.X;
                int my = e.Y;
                while (mx < xDragOffset - 2)
                {
                    mx++;
                    x -= 1;
                }
                while (mx > xDragOffset + 2)
                {
                    mx--;
                    x += 1;
                }
                while (my < yDragOffset - 2)
                {
                    my++;
                    y -= 1;
                }
                while (my > yDragOffset + 2)
                {
                    my--;
                    y += 1;
                }
                if (y < 0)
                {
                    y = 0;
                }
                if (x < 0)
                {
                    x = 0;
                }

                this.Location = new Point(x, y);
            }
        }
    }
}
