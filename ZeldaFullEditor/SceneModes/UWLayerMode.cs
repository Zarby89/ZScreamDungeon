using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeldaFullEditor.Data.DungeonObjects;

namespace ZeldaFullEditor.SceneModes
{
	public class UWLayerMode : SceneMode
	{
		public byte Layer { get; }
		public UWLayerMode(ZScreamer zs, int layer) : base(zs)
		{
			Layer = Layer;
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
			if (ZS.UnderworldScene.Room.OnlySelectedObject is RoomObject r)
			{
				if ((e.Delta > 0 && r.IncreaseSize()) || (e.Delta < 0 && r.DecreaseSize()))
				{
					updateSelectionObject(r);
				}
			}
		}

		public override void Copy()
		{

		}

		public override void Paste()
		{

		}

		public override void Delete()
		{
			ZS.UnderworldScene.Room.RemoveCurrentlySelectedObjectsFromList(ZS.UnderworldScene.Room.GetLayerList(Layer));
		}

		public override void SelectAll()
		{
			DungeonRoom room = ZS.UnderworldScene.Room;
			room.SelectedObjects.Clear();
			room.SelectedObjects.AddRange(room.GetLayerList(Layer));
		}
	}
}
