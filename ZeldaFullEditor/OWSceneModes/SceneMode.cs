using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeldaFullEditor.OWSceneModes
{
	public abstract class SceneMode
	{
		protected readonly ZScreamer ZS;

		protected SceneMode(ZScreamer parent)
		{
			ZS = parent;
		}

		public abstract void OnMouseDown(MouseEventArgs e);
		public abstract void OnMouseUp(MouseEventArgs e);
		public abstract void OnMouseMove(MouseEventArgs e);
		public abstract void Copy();
		public abstract void Cut();
		public abstract void Paste();
		public abstract void Delete();
	}
}
