using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeldaFullEditor.Data;
using ZeldaFullEditor.Data.Underworld;

namespace ZeldaFullEditor
{
	public partial class SceneUW
	{

		private void OnMouseDown_Door(MouseEventArgs e)
		{

		}

		private void OnMouseUp_Door(MouseEventArgs e)
		{
			
		}

		private void OnMouseMove_Door(MouseEventArgs e)
		{

		}

		// TO make this change the door type
		private void OnMouseWheel_Door(MouseEventArgs e)
		{

		}

		private void Copy_Door()
		{

		}

		private void Paste_Door()
		{

		}

		private void Delete_Door()
		{
			Room.RemoveCurrentlySelectedObjectsFromList(Room.DoorsList);
		}
		
		private void Insert_Door()
		{
			var d = new DungeonDoor(DungeonDoorDraw.North00, ZS.TileLister.GetDoorTileSet(0));
			Room.AttemptToAddEntityAsSelected(d, CurrentMode);
		}

		private void SelectAll_Door()
		{
			Room.ClearSelectedList();
			Room.SelectedObjects.AddRange(Room.DoorsList);
		}
	}
}
