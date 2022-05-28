namespace ZeldaFullEditor.UserInterface.UIControl.Scene
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

		private Rectangle[] BuildDoorRectangles()
		{
			Rectangle[] recturn = new Rectangle[48];
			int pos;
			float n;

			for (int i = 0, j = 0; i < 12; i++, j += 2) // Left
			{
				pos = ZS.ROM.Read16(0x197E + j) / 2;
				n = (((float) pos / 64) - (byte) (pos / 64)) * 64;
				recturn[i] = new Rectangle(((byte) n) * 8, (byte) (pos / 64) * 8, 32, 24);

				pos = ZS.ROM.Read16(0x1996 + j) / 2;
				n = (((float) pos / 64) - (byte) (pos / 64)) * 64;
				recturn[i + 12] = new Rectangle(((byte) n) * 8, (byte) ((pos / 64) + 1) * 8, 32, 24);

				pos = ZS.ROM.Read16(0x19AE + j) / 2;
				n = (((float) pos / 64) - (byte) (pos / 64)) * 64;
				recturn[i + 24] = new Rectangle(((byte) n) * 8, (byte) (pos / 64) * 8, 24, 32);

				pos = ZS.ROM.Read16(0x19C6 + j) / 2;
				n = (((float) pos / 64) - (byte) (pos / 64)) * 64;
				recturn[i + 36] = new Rectangle(((byte) n + 1) * 8, (byte) (pos / 64) * 8, 24, 32);
			}

			return recturn;
		}


	}
}
