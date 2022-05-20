namespace ZeldaFullEditor.View.UserInterface.Scene
{
	public partial class SceneUW
	{
		private void OnMouseDown_Entrance(MouseEventArgs e)
		{
			ZGUI.DungeonEditor.entrancetreeView_AfterSelect(null, null);
			ZS.CurrentUWMode = DungeonEditMode.LayerAll;
		}

		private void OnMouseUp_Entrance(MouseEventArgs e)
		{

		}

		private void OnMouseMove_Entrance(MouseEventArgs e)
		{

			Entrance sel = ZGUI.DungeonEditor.selectedEntrance;

			if (sel == null) return;

			int ey = Room.RoomID >> 4;
			int ex = Room.RoomID & 0xF;


			int MX = MouseX;
			int MY = MouseY;

			if (ZGUI.DungeonEditor.gridEntranceCheckbox.Checked)
			{
				MX &= ~0x7;
				MY &= ~0x7;
			}

			sel.XPosition = (ushort) (MX + (ex * 512));
			sel.YPosition = (ushort) (MY + (ey * 512));
			sel.CameraTriggerX = (ushort) MX;
			sel.CameraTriggerY = (ushort) MY;
			sel.RoomID = Room.RoomID;

			if (sel.CameraTriggerX > 383)
			{
				sel.CameraTriggerX = 383;
			}
			if (sel.CameraTriggerY > 392)
			{
				sel.CameraTriggerY = 392;
			}
			if (sel.CameraTriggerX < 128)
			{
				sel.CameraTriggerX = 128;
			}
			if (sel.CameraTriggerY < 112)
			{
				sel.CameraTriggerY = 112;
			}

			sel.CameraY = (ushort) (sel.CameraTriggerX + (ex * 512));
			sel.CameraX = (ushort) (sel.CameraTriggerY + (ey * 512));

			if (MX < 256 && MY < 256) // Top left quadrant
			{
				sel.Scrollquadrant = 0x00;
			}
			else if (MX > 256 && MY < 256) // Top right quadrant
			{
				sel.Scrollquadrant = 0x10;
			}
			else if (MX < 256 && MY > 256) // Bottom left quadrant
			{
				sel.Scrollquadrant = 0x02;
			}
			else if (MX > 256 && MY > 256) // Bottom right quadrant
			{
				sel.Scrollquadrant = 0x12;
			}

			sel.CameraY = sel.XPosition;
			sel.CameraX = sel.YPosition;

			int scrollXRange = sel.CameraX % 512;
			if (scrollXRange >= 350)
			{
				sel.CameraX = (ushort) ((ey * 512) + 256 + 16);
			}
			else if (scrollXRange <= 150)
			{
				sel.CameraX = (ushort) (ey * 512);
			}
			else
			{
				sel.CameraX = (ushort) (sel.YPosition - 112);
			}

			int scrollYRange = sel.CameraY % 512;
			if (scrollYRange >= 350)
			{
				sel.CameraY = (ushort) ((ex * 512) + 256);
			}
			else if (scrollYRange <= 150)
			{
				sel.CameraY = (ushort) (ex * 512);
			}
			else
			{
				sel.CameraY = (ushort) (sel.XPosition - 128);
			}

			sel.AutoCalculateScrollBoundaries();

			TriggerRefresh = true;
		}
	}
}
