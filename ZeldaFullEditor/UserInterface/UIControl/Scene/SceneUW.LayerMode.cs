﻿namespace ZeldaFullEditor.UserInterface.UIControl.Scene
{
	public partial class SceneUW
	{
		private void OnMouseDown_Layer(MouseEventArgs e)
		{
			if (ObjectToPlace == null)
			{
				FindHoveredEntity(Room.GetLayerList(Layer), e);
				HandleSelectingHoveredObject();
			}

			CheckIfObjectIsInvalidForPlacement();

			Room.AttemptToAddEntityAsSelected(ObjectToPlace, CurrentMode);
			InvalidateRoomTilemapAndArtist();

			ResetPlacementProperties();
		}

		private void OnMouseUp_Layer(MouseEventArgs e)
		{

		}

		private void OnMouseMove_Layer(MouseEventArgs e)
		{



			InvalidateRoomTilemapAndArtist();
		}


		public void IncreaseSizeOfSelectedObject()
		{
			if (Room?.OnlySelectedObject is RoomObject r && r.IncreaseSize())
			{
				InvalidateRoomTilemapAndArtist();
			}
		}

		public void DecreaseSizeOfSelectedObject()
		{
			if (Room?.OnlySelectedObject is RoomObject r && r.DecreaseSize())
			{
				InvalidateRoomTilemapAndArtist();
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
