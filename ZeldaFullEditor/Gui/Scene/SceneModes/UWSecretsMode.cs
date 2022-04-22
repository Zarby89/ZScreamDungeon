using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeldaFullEditor.Data.Underworld;

namespace ZeldaFullEditor.SceneModes
{
	public class UWSecretsMode : SceneMode
	{
		public UWSecretsMode(ZScreamer zs) : base(zs)
		{

		}

		public override void OnMouseDown(MouseEventArgs e)
		{

		}

		public override void OnMouseUp(MouseEventArgs e)
		{

		}

		public override void OnMouseMove(MouseEventArgs e)
		{

		}

		public override void OnMouseWheel(MouseEventArgs e)
		{

		}

		public override void Copy()
		{

		}

		public override void Paste()
		{

		}

		public override void Delete()
		{
			ZS.UnderworldScene.Room.RemoveCurrentlySelectedObjectsFromList(ZS.UnderworldScene.Room.SecretsList);
		}

		public override void SelectAll()
		{
			DungeonRoom room = ZS.UnderworldScene.Room;
			room.SelectedObjects.Clear();
			room.SelectedObjects.AddRange(room.SecretsList);
		}
	}
}
