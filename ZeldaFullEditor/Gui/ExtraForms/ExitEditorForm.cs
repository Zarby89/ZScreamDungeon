namespace ZeldaFullEditor;

public partial class ExitEditorForm : Form
{
	public OverworldExit editingExit;
	bool settingValues = false;
	int pixelMapx;
	int pixelMapy;
	public OverworldExit selectedExit;

	public ExitEditorForm()
	{
		InitializeComponent();
	}

	private void button1_Click(object sender, EventArgs e) //OK Button
	{
		editingExit.isAutomatic = automaticcheckBox.Checked;
		if (!automaticcheckBox.Checked)
		{
			editingExit.GlobalX = (ushort) (xPosUpDown.Value + pixelMapx);
			editingExit.GlobalY = (ushort) (yPosUpDown.Value + pixelMapy);

			editingExit.CameraX = (ushort) (xCameraUpDown.Value + pixelMapx);
			editingExit.CameraY = (ushort) (yCameraUpDown.Value + pixelMapy);

			editingExit.ScrollX = (ushort) (xScrollUpDown.Value + pixelMapx);
			editingExit.ScrollY = (ushort) (yScrollUpDown.Value + pixelMapy);

			editingExit.doorXEditor = (byte) doorxUpDown.Value;
			editingExit.doorYEditor = (byte) dooryUpDown.Value;
		}

		if (wooddoorradioButton.Checked)
		{
			editingExit.doorXEditor = (byte) doorxUpDown.Value;
			editingExit.doorYEditor = (byte) dooryUpDown.Value;
			editingExit.doorType1 = (ushort) ((((((byte) dooryUpDown.Value)) << 6) | (((byte) doorxUpDown.Value) & 0x3F)) << 1);
			editingExit.doorType2 = 0;
		}
		else if (sancdoorButton.Checked)
		{
			editingExit.doorXEditor = (byte) doorxUpDown.Value;
			editingExit.doorYEditor = (byte) dooryUpDown.Value;
			editingExit.doorType2 = (ushort) ((((((byte) dooryUpDown.Value)) << 6) | (((byte) doorxUpDown.Value) & 0x3F)) << 1);
			editingExit.doorType1 = 0;
		}
		else if (bombdoorradioButton.Checked)
		{
			editingExit.doorXEditor = (byte) doorxUpDown.Value;
			editingExit.doorYEditor = (byte) dooryUpDown.Value;
			editingExit.doorType1 = (ushort) (((((((byte) dooryUpDown.Value)) << 6) | (((byte) doorxUpDown.Value) & 0x3F)) << 1) + 0x8000);
			editingExit.doorType2 = 0;
		}
		else if (castledoorradioButton.Checked)
		{
			editingExit.doorXEditor = (byte) doorxUpDown.Value;
			editingExit.doorYEditor = (byte) dooryUpDown.Value;
			editingExit.doorType2 = (ushort) (((((((byte) dooryUpDown.Value)) << 6) | (((byte) doorxUpDown.Value) & 0x3F)) << 1) + 0x8000);
			editingExit.doorType1 = 0;
		}
		else
		{
			editingExit.doorXEditor = 0;
			editingExit.doorYEditor = 0;
			editingExit.doorType2 = 0;
			editingExit.doorType1 = 0;
		}
	}

	private void nodoorradioButton_CheckedChanged(object sender, EventArgs e)
	{
		doorxUpDown.Enabled = !nodoorradioButton.Checked;
		dooryUpDown.Enabled = !nodoorradioButton.Checked;
		setPositionButton.Enabled = !nodoorradioButton.Checked;
	}

	public void SetExit(OverworldExit exit)
	{
		settingValues = true;
		selectedExit = exit;
		editingExit = new OverworldExit(exit.TargetRoomID, exit.MapID, exit.VRAMBase, exit.ScrollY, exit.ScrollX, exit.GlobalY, exit.GlobalX, exit.CameraY, exit.CameraX, exit.unk1, exit.unk2, exit.doorType1, exit.doorType2);
		roomUpDown.HexValue = editingExit.TargetRoomID;
		mapUpDown.Value = editingExit.MapID;

		int mapy = (editingExit.MapID / 8);
		int mapx = editingExit.MapID - (mapy * 8);

		pixelMapx = mapx * 512;
		pixelMapy = mapy * 512;

		xPosUpDown.Value = (editingExit.GlobalX - pixelMapx); //editingExit.GlobalX;
		yPosUpDown.Value = (editingExit.GlobalY - ((pixelMapy))); //editingExit.GlobalY;
		xCameraUpDown.Value = (editingExit.CameraX - (pixelMapx));
		yCameraUpDown.Value = (editingExit.CameraY - (pixelMapy));
		xScrollUpDown.Value = (editingExit.ScrollX - (pixelMapx));
		yScrollUpDown.Value = (editingExit.ScrollY - (pixelMapy));
		editingExit.doorXEditor = exit.doorXEditor;
		editingExit.doorYEditor = exit.doorYEditor;
		doorxUpDown.Value = editingExit.doorXEditor;
		dooryUpDown.Value = editingExit.doorYEditor;
		editingExit.isAutomatic = exit.isAutomatic;
		automaticcheckBox.Checked = editingExit.isAutomatic;
		nodoorradioButton.Checked = true;

		if ((editingExit.doorType1 & 0x8000) != 0) { bombdoorradioButton.Checked = true; }
		else if (editingExit.doorType1 != 0) { wooddoorradioButton.Checked = true; }
		else if ((editingExit.doorType2 & 0x8000) != 0) { castledoorradioButton.Checked = true; }
		else if (editingExit.doorType2 != 0) { sancdoorButton.Checked = true; }

		settingValues = false;
	}

	private void checkBox1_CheckedChanged(object sender, EventArgs e)
	{
		//mapUpDown.Enabled = !automaticcheckBox.Checked;
		xPosUpDown.Enabled = !automaticcheckBox.Checked;
		yPosUpDown.Enabled = !automaticcheckBox.Checked;
		xScrollUpDown.Enabled = !automaticcheckBox.Checked;
		yScrollUpDown.Enabled = !automaticcheckBox.Checked;
		xCameraUpDown.Enabled = !automaticcheckBox.Checked;
		yCameraUpDown.Enabled = !automaticcheckBox.Checked;
		editingExit.isAutomatic = automaticcheckBox.Checked;
	}

	private void xPosUpDown_ValueChanged(object sender, EventArgs e)
	{
		if (!settingValues)
		{
			editingExit.TargetRoomID = (ushort) roomUpDown.HexValue;
			editingExit.MapID = (byte) mapUpDown.Value;
			editingExit.GlobalX = (ushort) (xPosUpDown.Value + pixelMapx);
			editingExit.GlobalY = (ushort) (yPosUpDown.Value + pixelMapy);
			editingExit.CameraX = (ushort) (xCameraUpDown.Value + pixelMapx);
			editingExit.CameraY = (ushort) (yCameraUpDown.Value + pixelMapy);
			editingExit.ScrollX = (ushort) (xScrollUpDown.Value + pixelMapx);
			editingExit.ScrollY = (ushort) (yScrollUpDown.Value + pixelMapy);

			if (wooddoorradioButton.Checked)
			{
				editingExit.doorXEditor = (byte) doorxUpDown.Value;
				editingExit.doorYEditor = (byte) dooryUpDown.Value;

				editingExit.doorType1 = (ushort) ((((((byte) dooryUpDown.Value)) << 6) | (((byte) doorxUpDown.Value) & 0x3F)) << 1);
				editingExit.doorType2 = 0;

			}
			else if (sancdoorButton.Checked)
			{
				editingExit.doorXEditor = (byte) doorxUpDown.Value;
				editingExit.doorYEditor = (byte) dooryUpDown.Value;
				editingExit.doorType2 = (ushort) ((((((byte) dooryUpDown.Value)) << 6) | (((byte) doorxUpDown.Value) & 0x3F)) << 1);
				editingExit.doorType1 = 0;
			}
			else if (bombdoorradioButton.Checked)
			{
				editingExit.doorXEditor = (byte) doorxUpDown.Value;
				editingExit.doorYEditor = (byte) dooryUpDown.Value;
				editingExit.doorType1 = (ushort) (((((((byte) dooryUpDown.Value)) << 6) | (((byte) doorxUpDown.Value) & 0x3F)) << 1) + 0x8000);
				editingExit.doorType2 = 0;
			}
			else if (castledoorradioButton.Checked)
			{
				editingExit.doorXEditor = (byte) doorxUpDown.Value;
				editingExit.doorYEditor = (byte) dooryUpDown.Value;
				editingExit.doorType2 = (ushort) (((((((byte) dooryUpDown.Value)) << 6) | (((byte) doorxUpDown.Value) & 0x3F)) << 1) + 0x8000);
				editingExit.doorType1 = 0;
			}
			else
			{
				editingExit.doorXEditor = 0;
				editingExit.doorYEditor = 0;
				editingExit.doorType2 = 0;
				editingExit.doorType1 = 0;
			}

			editingExit.isAutomatic = automaticcheckBox.Checked;
		}

		//editingExit.doorType1 = (byte)doorxUpDown.Value;
		//editingExit.doorType2 = (byte)doorxUpDown.Value;
		//(byte)dooryUpDown.Value;
	}

	private void setPositionButton_Click(object sender, EventArgs e)
	{
		selectedExit.doorType1 = editingExit.doorType1;
		selectedExit.doorType2 = editingExit.doorType2;
	}

	private void wooddoorradioButton_CheckedChanged(object sender, EventArgs e)
	{
		if (!settingValues)
		{
			if (doorxUpDown.Value == 0 && dooryUpDown.Value == 0)
			{
				doorxUpDown.Value = 1;
			}

			if (wooddoorradioButton.Checked)
			{
				editingExit.doorXEditor = (byte) doorxUpDown.Value;
				editingExit.doorYEditor = (byte) dooryUpDown.Value;
				editingExit.doorType1 = (ushort) ((((((byte) doorxUpDown.Value)) << 6) | (((byte) dooryUpDown.Value) & 0x3F)) << 1);
				editingExit.doorType2 = 0;
			}
			else if (sancdoorButton.Checked)
			{
				editingExit.doorXEditor = (byte) doorxUpDown.Value;
				editingExit.doorYEditor = (byte) dooryUpDown.Value;
				editingExit.doorType2 = (ushort) ((((((byte) doorxUpDown.Value)) << 6) | (((byte) dooryUpDown.Value) & 0x3F)) << 1);
				editingExit.doorType1 = 0;
			}
			else if (bombdoorradioButton.Checked)
			{
				editingExit.doorXEditor = (byte) doorxUpDown.Value;
				editingExit.doorYEditor = (byte) dooryUpDown.Value;
				editingExit.doorType1 = (ushort) (((((((byte) doorxUpDown.Value)) << 6) | (((byte) dooryUpDown.Value) & 0x3F)) << 1) + 0x8000);
				editingExit.doorType2 = 0;
			}
			else if (castledoorradioButton.Checked)
			{
				editingExit.doorXEditor = (byte) doorxUpDown.Value;
				editingExit.doorYEditor = (byte) dooryUpDown.Value;
				editingExit.doorType2 = (ushort) (((((((byte) doorxUpDown.Value)) << 6) | (((byte) dooryUpDown.Value) & 0x3F)) << 1) + 0x8000);
				editingExit.doorType1 = 0;
			}
			else if (nodoorradioButton.Checked)
			{
				editingExit.doorXEditor = 0;
				editingExit.doorYEditor = 0;
				editingExit.doorType2 = 0;
				editingExit.doorType1 = 0;
			}
		}
	}
}
