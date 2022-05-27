namespace ZeldaFullEditor.UserInterface.UserControl.Scene
{
	/// <summary>
	/// Provides a container for quickly switching between mouse, copy/cut/paste, etc. methods as the edit mode changes.
	/// </summary>
	public class ModeActions
	{
		public delegate void SceneAction();
		public delegate void SceneActionMouse(MouseEventArgs e);

		public ModeActions(SceneActionMouse mousedown, SceneActionMouse mouseup, SceneActionMouse mousemove, SceneActionMouse mousewheel,
			SceneAction copy, SceneAction paste, SceneAction insert, SceneAction delete, SceneAction selectall)
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
		}

		public static readonly ModeActions Nothing = new(null, null, null, null, null, null, null, null, null);

		private static void NoMouse(MouseEventArgs e) { }
		private static void NoAct() { }

		public SceneActionMouse OnMouseDown { get; }
		public SceneActionMouse OnMouseUp { get; }
		public SceneActionMouse OnMouseMove { get; }
		public SceneActionMouse OnMouseWheel { get; }
		public SceneAction Copy { get; }
		public SceneAction Paste { get; }
		public SceneAction Delete { get; }
		public SceneAction Insert { get; }
		public SceneAction SelectAll { get; }
	}
}
