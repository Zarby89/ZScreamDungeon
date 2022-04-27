using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeldaFullEditor.Data.Underworld;

namespace ZeldaFullEditor
{
	public partial class SceneUW
	{

		private void OnMouseDown_Layer(MouseEventArgs e)
		{
			if (ObjectToPlace == null)
			{
				return;
			}

			CheckIfObjectIsInvalidForPlacement();

			Room.AttemptToAddEntityAsSelected(ObjectToPlace, CurrentMode);

			MouseIsDown = true;

			ResetPlacementProperties();
		}

		private void OnMouseUp_Layer(MouseEventArgs e)
		{

		}

		private void OnMouseMove_Layer(MouseEventArgs e)
		{

		}


		public void IncreaseSizeOfSelectedObject()
		{
			if (Room.OnlySelectedObject is RoomObject r && r.IncreaseSize())
			{
				RedrawRoom();
			}
		}

		public void DecreaseSizeOfSelectedObject()
		{
			if (Room.OnlySelectedObject is RoomObject r && r.DecreaseSize())
			{
				RedrawRoom();
			}
		}


		private void OnMouseWheel_Layer(MouseEventArgs e)
		{
			if (e.Delta > 0)
			{
				IncreaseSizeOfSelectedObject();
			}
			else if (e.Delta < 0)
			{
				DecreaseSizeOfSelectedObject();
			}
		}

		private void Copy_Layer()
		{

		}

		private void Paste_Layer()
		{

		}

		private void Delete_Layer()
		{
			Room.RemoveCurrentlySelectedObjectsFromList(Room.GetLayerList(Layer));
		}

		private void SelectAll_Layer()
		{
			Room.ClearSelectedList();
			Room.SelectedObjects.AddRange(Room.GetLayerList(Layer));
		}
	}
}
