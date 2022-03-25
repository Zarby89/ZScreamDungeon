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
	public partial class DungeonViewer : Gui.ScreamControl
	{
		public DungeonViewer(ZScreamer parent) : base(parent)
		{
			InitializeComponent();
		}

		//public Bitmap allmap;
	}
}
