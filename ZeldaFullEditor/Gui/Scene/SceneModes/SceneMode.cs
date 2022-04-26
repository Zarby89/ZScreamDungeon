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
	/// <summary>
	/// 
	/// </summary>
	public class ModeActions
	{
		public delegate void SceneActionMouse(MouseEventArgs e);
		public delegate void SceneAction();
		public delegate void SceneActionDraw(Graphics g);
		public ModeActions(SceneActionMouse mousedown, SceneActionMouse mouseup, SceneActionMouse mousemove, SceneActionMouse mousewheel,
			SceneAction copy, SceneAction paste, SceneAction insert, SceneAction delete, SceneAction selectall, SceneActionDraw draw)
		{
			OnMouseDown = mousedown ?? NoMouse;
			OnMouseUp = mouseup ?? NoMouse;
			OnMouseMove = mousemove ?? NoMouse;
			OnMouseWheel = mousewheel ?? NoMouse;
			Copy = copy ?? NoAct;
			Paste = paste ?? NoAct;
			Insert = insert ?? NoAct;
			Delete = delete ?? NoAct;
			SelectAll = selectall ?? NoAct;
			Draw = draw ?? NoGraphics;
		}

		private static void NoMouse(MouseEventArgs e) { }
		private static void NoAct() { }
		private static void NoGraphics(Graphics g) { }


		public SceneActionMouse OnMouseDown { get; }
		public SceneActionMouse OnMouseUp { get; }
		public SceneActionMouse OnMouseMove { get; }
		public SceneActionMouse OnMouseWheel { get; }
		public SceneAction Copy { get; }
		public SceneAction Paste { get; }
		public SceneAction Delete { get; }
		public SceneAction Insert { get; }
		public SceneAction SelectAll { get; }
		public SceneActionDraw Draw { get; }

	}
}
