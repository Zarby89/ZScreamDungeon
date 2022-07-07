namespace ZeldaFullEditor.UserInterface.UIControl.Scene;

public class Scene : PictureBox
{
	protected ZScreamer ZS { get; }
	public bool IsUpdating { get; set; }
	public bool MouseIsDown { get; set; }

	protected int MouseX { get; set; }
	protected int MouseY { get; set; }
	protected int MoveX { get; set; }
	protected int MoveY { get; set; }
	protected int LastX { get; set; }
	protected int LastY { get; set; }

	protected int RightClickedXAt { get; set; }
	protected int RightClickedYAt { get; set; }

	protected bool IsLeftPress { get; set; } = false;

	protected ModeActions ActiveMode { get; set; } = ModeActions.Nothing;

	public bool TriggerRefresh { get; set; }

	protected Scene()
	{
		DoubleBuffered = true;
	}

	protected Scene(ZScreamer zs)
	{
		ZS = zs;

		MouseDown += new MouseEventHandler(OnMouseDown);
		MouseUp += new MouseEventHandler(OnMouseUp);
		MouseMove += new MouseEventHandler(OnMouseMove);
		MouseDoubleClick += new MouseEventHandler(OnMouseDoubleClick);
		MouseWheel += new MouseEventHandler(OnMouseWheel);
	}

	private DateTimeOffset _canrefresh = DateTimeOffset.Now;
	public override void Refresh()
	{
		if (!CanIRefresh()) return;
		_canrefresh = DateTimeOffset.Now.AddMilliseconds(100);
		base.Refresh();
	}

	protected bool CanIRefresh() => _canrefresh < DateTimeOffset.Now;

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
		finally
		{
			Refresh();
		}
	}

	protected virtual void OnMouseDown(object sender, MouseEventArgs e)
	{
		if (!MouseIsDown)
		{
			IsLeftPress = e.Button == MouseButtons.Left;
		}

		switch (e.Button)
		{
			case MouseButtons.Right:
				RightClickedXAt = e.X;
				RightClickedYAt = e.Y;
				// TODO context menu
				return;

			case MouseButtons.Left:
				LastX = e.X;
				LastY = e.Y;
				break;
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
		finally
		{
			Refresh();
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

		MoveX = MouseX - LastX;
		MoveY = MouseY - LastY;

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
