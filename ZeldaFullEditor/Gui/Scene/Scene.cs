using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using ZeldaFullEditor.SceneModes;

namespace ZeldaFullEditor
{
	public abstract class Scene : PictureBox
	{
		public readonly ZScreamer ZS;

		public bool Active => ZS.ActiveScene == this;

		public bool IsUpdating { get; set; }
		public bool MouseIsDown { get; set; }
		public int MouseX { get; protected set; }
		public int MouseY { get; protected set; }
		public int MoveX { get; protected set; }
		public int MoveY { get; protected set; }
		public int LastX { get; protected set; }
		public int LastY { get; protected set; }
		public int DraggingX { get; protected set; }
		public int DraggingY { get; protected set; }

		public ModeActions ActiveMode { get; protected set; }

		public bool TriggerRefresh { get; set; }

		protected Scene(ZScreamer zs)
		{
			ZS = zs;

			MouseDown += new MouseEventHandler(OnMouseDown);
			MouseUp += new MouseEventHandler(OnMouseUp);
			MouseMove += new MouseEventHandler(OnMouseMove);
			MouseDoubleClick += new MouseEventHandler(OnMouseDoubleClick);
			MouseWheel += new MouseEventHandler(OnMouseWheel);
		}

		public virtual void drawText(Graphics g, int x, int y, string text, ImageAttributes ai = null, bool x2 = false)
		{
			text = text.ToUpper();
			int cpos = 0;
			int size = (ai == null && !x2) ? 16 : 8;
			int spacingmult = x2 ? 2 : 1;

			foreach (char c in text)
			{
				byte arrayPos = (byte) (c - 32);
				if ((byte) c == 10)
				{
					y += 10;
					cpos = 0;
					continue;
				}

				g.DrawImage(ZS.GFXManager.spriteFont,
					new Rectangle(x + cpos, y, size, size), arrayPos * 8, 0, 8, 8, GraphicsUnit.Pixel, ai);

				if (arrayPos >= Constants.FontSpacings.Length)
				{
					cpos += 8;
					continue;
				}

				cpos += Constants.FontSpacings[arrayPos] * spacingmult;
			}
		}

		protected abstract void RequestRefresh();


		protected virtual void OnMouseWheel(object o, MouseEventArgs e)
		{
			try
			{
				ActiveMode.OnMouseWheel(e);
			}
			catch (ZeldaException ze)
			{
				UIText.GeneralWarning(ze.Message);
			}
		}

		protected virtual void OnMouseDown(object sender, MouseEventArgs e)
		{
			try
			{
				ActiveMode.OnMouseDown(e);
			}
			catch (ZeldaException ze)
			{
				UIText.GeneralWarning(ze.Message);
			}

			base.OnMouseDown(e);
		}


		protected virtual void OnMouseUp(object sender, MouseEventArgs e)
		{
			try
			{
				ActiveMode.OnMouseUp(e);
			}
			catch (ZeldaException ze)
			{
				UIText.GeneralWarning(ze.Message);
			}
		}


		protected virtual void OnMouseMove(object sender, MouseEventArgs e)
		{
			try
			{
				ActiveMode.OnMouseMove(e);
			}
			catch (ZeldaException ze)
			{
				UIText.GeneralWarning(ze.Message);
			}
		}


		protected virtual void OnMouseDoubleClick(object sender, MouseEventArgs e)
		{
			
		}

		public abstract void Undo();
		public abstract void Redo();

		public virtual void Copy()
		{
			try
			{
				ActiveMode.Copy();
			}
			catch (ZeldaException ze)
			{
				UIText.GeneralWarning(ze.Message);
			}
		}

		public virtual void Paste()
		{
			try
			{
				ActiveMode.Paste();
			}
			catch (ZeldaException ze)
			{
				UIText.GeneralWarning(ze.Message);
			}

			RequestRefresh();
		}

		public virtual void Cut()
		{
			ActiveMode.Copy();
			ActiveMode.Delete();
		}


		public virtual void Insert()
		{
			try
			{
				ActiveMode.Insert();
			}
			catch (ZeldaException ze)
			{
				UIText.GeneralWarning(ze.Message);
			}

			RequestRefresh();
		}

		public virtual void Delete()
		{
			try
			{
				ActiveMode.Delete();
			}
			catch (ZeldaException ze)
			{
				UIText.GeneralWarning(ze.Message);
			}
			RequestRefresh();
		}

		public virtual void SelectAll()
		{
			ActiveMode.SelectAll();
		}
	}
}
