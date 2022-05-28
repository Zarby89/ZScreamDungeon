namespace ZeldaFullEditor.UserInterface.UIControl.Scene
{
	public partial class SceneUW
	{
		private void OnMouseDown_Sprites(MouseEventArgs e)
		{
			if (ObjectToPlace == null) return;

			CheckIfObjectIsInvalidForPlacement();

			Room.AttemptToAddEntityAsSelected(ObjectToPlace, CurrentMode);

			ResetPlacementProperties();
		}

		private void OnMouseUp_Sprites(MouseEventArgs e)
		{

		}

		private void OnMouseMove_Sprites(MouseEventArgs e)
		{

		}

		private void Copy_Sprites()
		{

		}

		private void Paste_Sprites()
		{

		}

		private void Delete_Sprites()
		{
			Room.RemoveCurrentlySelectedObjectsFromList(Room.SpritesList);
		}

		private void SelectAll_Sprites()
		{
			Room.ClearSelectedList();
			Room.SelectedObjects.AddRange(Room.SpritesList);
		}

	}
}
