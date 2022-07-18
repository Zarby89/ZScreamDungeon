namespace ZeldaFullEditor.UserInterface.UIControl.Scene;

public partial class SceneUW
{
	private void OnMouseDown_Blocks(MouseEventArgs e)
	{
		if (ObjectToPlace is null)
		{
			FindHoveredEntity(Room.BlocksList, e);
			HandleSelectingHoveredObject();
		}

		// TODO
	}

	private void OnMouseUp_Blocks(MouseEventArgs e)
	{
		// Nothing
	}

	private void OnMouseMove_Blocks(MouseEventArgs e)
	{
		if (!MouseIsDown)
		{
			FindHoveredEntity(Room.BlocksList, e);
		}
	}

	private void Copy_Blocks()
	{

	}

	private void Paste_Blocks()
	{

	}

	private void Delete_Blocks()
	{
		Room.RemoveCurrentlySelectedObjectsFromList(Room.BlocksList);
	}

	private void Insert_Blocks()
	{
		var b = new PushableBlock()
		{
			GridX = (byte) MouseX,
			GridY = (byte) MouseY,
			Layer = 0,
		};

		Room.AttemptToAddEntityAsSelected(b, CurrentMode);
	}

	private void SelectAll_Blocks()
	{
		Room.ClearSelectedList();
		Room.SelectedObjects.AddRange(Room.BlocksList);
	}
}
