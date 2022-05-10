using ZeldaFullEditor.SceneModes;

namespace ZeldaFullEditor
{
	public class Scene : PictureBox
	{
		public readonly ZScreamer ZS;

		public bool IsActive => ZS.ActiveScene == this;
		public bool IsUpdating { get; set; }
		public bool MouseIsDown { get; set; }

		protected int MouseX;
		protected int MouseY;
		protected int MoveX;
		protected int MoveY;
		protected int LastX;
		protected int LastY;

		protected int RightClickedXAt;
		protected int RightClickedYAt;

		protected bool IsLeftPress = false;

		protected ModeActions ActiveMode { get; set; } = ModeActions.Nothing;

		public bool TriggerRefresh { get; set; }

		protected Scene() { }

		protected Scene(ZScreamer zs)
		{
			ZS = zs;

			MouseDown += new MouseEventHandler(OnMouseDown);
			MouseUp += new MouseEventHandler(OnMouseUp);
			MouseMove += new MouseEventHandler(OnMouseMove);
			MouseDoubleClick += new MouseEventHandler(OnMouseDoubleClick);
			MouseWheel += new MouseEventHandler(OnMouseWheel);
		}

		public override void Refresh()
		{
			base.Refresh();
		}

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
			if (!MouseIsDown)
			{
				IsLeftPress = e.Button == MouseButtons.Left;
			}

			if (e.Button == MouseButtons.Right)
			{
				RightClickedXAt = e.X;
				RightClickedYAt = e.Y;
			}

			try
			{
				ActiveMode.OnMouseDown(e);
				MouseIsDown = true;
			}
			catch (ZeldaException ze)
			{
				MouseIsDown = false;
				UIText.GeneralWarning(ze.Message);
			}
		}


		protected virtual void OnMouseUp(object sender, MouseEventArgs e)
		{
			try
			{
				ActiveMode.OnMouseUp(e);
				MouseIsDown = false;
			}
			catch (ZeldaException ze)
			{
				UIText.GeneralWarning(ze.Message);
			}
		}


		protected virtual void OnMouseMove(object sender, MouseEventArgs e)
		{
			MouseX = e.X;
			MouseY = e.Y;

			try
			{
				ActiveMode.OnMouseMove(e);
			}
			catch (ZeldaException ze)
			{
				UIText.GeneralWarning(ze.Message);
			}
			finally
			{
				Refresh();
			}
		}


		protected virtual void OnMouseDoubleClick(object sender, MouseEventArgs e)
		{

		}

		public virtual void Undo() { }

		public virtual void Redo() { }

		public virtual void Copy()
		{
			MouseIsDown = false;
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
			MouseIsDown = false;
			try
			{
				ActiveMode.Paste();
			}
			catch (ZeldaException ze)
			{
				UIText.GeneralWarning(ze.Message);
			}

			Refresh();
		}

		public virtual void Cut()
		{
			ActiveMode.Copy();
			ActiveMode.Delete();
		}


		public virtual void Insert()
		{
			MouseIsDown = false;
			try
			{
				ActiveMode.Insert();
			}
			catch (ZeldaException ze)
			{
				UIText.GeneralWarning(ze.Message);
			}

			Refresh();
		}

		public virtual void Delete()
		{
			MouseIsDown = false;
			try
			{
				ActiveMode.Delete();
			}
			catch (ZeldaException ze)
			{
				UIText.GeneralWarning(ze.Message);
			}
			Refresh();
		}

		public virtual void SelectAll()
		{
			MouseIsDown = false;
			ActiveMode.SelectAll();
		}
	}
}
