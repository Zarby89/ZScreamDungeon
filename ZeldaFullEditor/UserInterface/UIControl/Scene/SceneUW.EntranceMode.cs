namespace ZeldaFullEditor.UserInterface.UIControl.Scene;

public partial class SceneUW
{
	private void OnMouseDown_Entrance(MouseEventArgs e)
	{
		ZGUI.DungeonEditor.UpdateFormForEntrance();
		ZS.CurrentUWMode = DungeonEditMode.LayerAll;
	}

	private void OnMouseMove_Entrance(MouseEventArgs e)
	{
		var sel = ZGUI.DungeonEditor.selectedEntrance;

		if (sel is null) return;

		int ey = 512 * (Room.RoomID >> 4);
		int ex = 512 * (Room.RoomID & 0xF);

		int MX = MouseX;
		int MY = MouseY;

		if (ZGUI.DungeonEditor.gridEntranceCheckbox.Checked)
		{
			MX &= ~0x7;
			MY &= ~0x7;
		}

		sel.XPosition = (ushort) (MX + ex);
		sel.YPosition = (ushort) (MY + ey);

		sel.RoomID = Room.RoomID;

		sel.CameraTriggerX = (ushort) (MX switch
		{
			> 383 => 383,
			< 128 => 128,
			_ => MX
		});

		sel.CameraTriggerY = (ushort) (MY switch
		{
			> 392 => 392,
			< 112 => 112,
			_ => MY
		});

		// TODO ???
		// sel.CameraY = (ushort) (sel.CameraTriggerX + (ex * 512));
		// sel.CameraX = (ushort) (sel.CameraTriggerY + (ey * 512));

		sel.Scrollquadrant = (MX < 256, MY < 256) switch
		{
			(true, true) => 0x00,
			(false, true) => 0x10,
			(true, false) => 0x02,
			(false, false) => 0x12,
		};

		sel.CameraX = (ushort) ((sel.YPosition % 512) switch
		{
			<= 150 => ey,
			>= 350 => ey + 256 + 16,
			_ => sel.YPosition - 112,
		});

		sel.CameraY = (ushort) ((sel.XPosition % 512) switch
		{
			<= 150 => ex,
			>= 350 => ex + 256,
			_ => sel.XPosition - 128,
		});

		sel.AutoCalculateScrollBoundaries();
	}
}
