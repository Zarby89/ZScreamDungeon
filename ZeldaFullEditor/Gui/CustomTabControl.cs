using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeldaFullEditor
{
	public partial class CustomTabControl : Gui.ScreamControl
	{
		public CustomTabControl(ZScreamer zs) : base(zs)
		{
			InitializeComponent();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			// TODO: Add something here?
			//e.Graphics.DrawLine(,0,0,0,0)
		}
	}
}
