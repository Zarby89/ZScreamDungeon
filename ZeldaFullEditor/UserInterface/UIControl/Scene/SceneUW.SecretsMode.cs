﻿namespace ZeldaFullEditor.UserInterface.UIControl.Scene;

public partial class SceneUW
{
	private void OnMouseDown_Secrets(MouseEventArgs e)
	{
		if (ObjectToPlace == null)
		{
			FindHoveredEntity(Room.SecretsList, e);
			HandleSelectingHoveredObject();
		}

		// TODO
	}

	private void OnMouseUp_Secrets(MouseEventArgs e)
	{

	}

	private void OnMouseMove_Secrets(MouseEventArgs e)
	{
		if (!MouseIsDown)
		{
			FindHoveredEntity(Room.SecretsList, e);
		}
	}

	// TODO make this change secrets type
	private void OnMouseWheel_Secrets(MouseEventArgs e)
	{
		if (Room.OnlySelectedObject is DungeonSecret s)
		{
			int i = e.ScrollByValue(s.ID, 1);
			var sn = SecretItemType.ListOf.GetNextOrPreviousInGlobalList(s.SecretType, i);

			if (sn is null) return;

			s.SecretType = sn;
			Room.Redrawing |= NeedsNewArt.UpdatedSpritesLayer;
		}
	}

	private void Copy_Secrets()
	{

	}

	private void Paste_Secrets()
	{

	}

	private void Delete_Secrets()
	{
		Room.RemoveCurrentlySelectedObjectsFromList(Room.SecretsList);
	}

	private void Insert_Secrets()
	{
		var b = new DungeonSecret(SecretItemType.Secret00)
		{
			GridX = (byte) MouseX,
			GridY = (byte) MouseY,
			Layer = 0,
		};

		Room.AttemptToAddEntityAsSelected(b, CurrentMode);
	}

	private void SelectAll_Secrets()
	{
		Room.ClearSelectedList();
		Room.SelectedObjects.AddRange(Room.SecretsList);
	}
}
