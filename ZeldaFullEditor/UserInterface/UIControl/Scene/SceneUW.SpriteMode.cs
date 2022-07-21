namespace ZeldaFullEditor.UserInterface.UIControl.Scene;

public partial class SceneUW
{
	private void OnMouseDown_Sprites(MouseEventArgs e)
	{
		if (ObjectToPlace == null)
		{
			FindHoveredEntity(Room.SpritesList, e);
			HandleSelectingHoveredObject();
		}

		CheckIfObjectIsInvalidForPlacement();

		Room.AttemptToAddEntityAsSelected(ObjectToPlace, CurrentMode);

		ResetPlacementProperties();
	}

	private void OnMouseWheel_Sprites(MouseEventArgs e)
	{
		return;

		// TODO do we want this?
		if (Room?.OnlySelectedObject is DungeonSprite d)
		{
			int i = d.ID;

			e.ScrollByValue(ref i, 1);

			i = i.Clamp(0,
				d.IsCurrentlyOverlord
				? OverlordType.ListOf.Length
				: SpriteType.ListOf.Length
			);
		}
	}


	private void OnMouseUp_Sprites(MouseEventArgs e)
	{
		SelectAllEntitiesInRectangle(Room.SpritesList);
	}

	private void OnMouseMove_Sprites(MouseEventArgs e)
	{
		if (!MouseIsDown)
		{
			FindHoveredEntity(Room.SpritesList, e);
		}
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
