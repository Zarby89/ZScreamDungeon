using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeldaFullEditor.SceneModes
{
	public abstract class SceneMode
	{
		protected readonly ZScreamer ZS;
		protected SceneMode(ZScreamer zs)
		{
			ZS = zs;
		}

		public abstract void OnMouseDown(MouseEventArgs e);
		public abstract void OnMouseUp(MouseEventArgs e);
		public abstract void OnMouseMove(MouseEventArgs e);
		public abstract void OnMouseWheel(MouseEventArgs e);
		public abstract void Copy();

		public virtual void Cut()
		{
			Copy();
			Delete();
		}

		public abstract void Paste();
		public abstract void Delete();
		public abstract void SelectAll();
	}
}
