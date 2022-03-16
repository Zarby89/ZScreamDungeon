using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeldaFullEditor;

namespace ZeldaFullEditor
{
	public partial class ExitEditorForm : Form
	{
		public ExitOW editingExit;
		bool settingValues = false;
		int pixelMapx;
		int pixelMapy;
		public ExitOW selectedExit;

		public ExitEditorForm()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e) //OK Button
		{
			editingExit.isAutomatic = automaticcheckBox.Checked;
			if (!automaticcheckBox.Checked)
			{
				editingExit.playerX = (ushort) (xPosUpDown.Value + pixelMapx);
				editingExit.playerY = (ushort) (yPosUpDown.Value + pixelMapy);

				editingExit.cameraX = (short) (xCameraUpDown.Value + pixelMapx);
				editingExit.cameraY = (short) (yCameraUpDown.Value + pixelMapy);

				editingExit.xScroll = (short) (xScrollUpDown.Value + pixelMapx);
				editingExit.yScroll = (short) (yScrollUpDown.Value + pixelMapy);

				editingExit.doorXEditor = (byte) doorxUpDown.Value;
				editingExit.doorYEditor = (byte) dooryUpDown.Value;
			}

			if (wooddoorradioButton.Checked)
			{
				editingExit.doorXEditor = (byte) doorxUpDown.Value;
				editingExit.doorYEditor = (byte) dooryUpDown.Value;
				editingExit.doorType1 = (short) ((((((byte) dooryUpDown.Value)) << 6) | (((byte) doorxUpDown.Value) & 0x3F)) << 1);
				editingExit.doorType2 = 0;
			}
			else if (sancdoorButton.Checked)
			{
				editingExit.doorXEditor = (byte) doorxUpDown.Value;
				editingExit.doorYEditor = (byte) dooryUpDown.Value;
				editingExit.doorType2 = (short) ((((((byte) dooryUpDown.Value)) << 6) | (((byte) doorxUpDown.Value) & 0x3F)) << 1);
				editingExit.doorType1 = 0;
			}
			else if (bombdoorradioButton.Checked)
			{
				editingExit.doorXEditor = (byte) doorxUpDown.Value;
				editingExit.doorYEditor = (byte) dooryUpDown.Value;
				editingExit.doorType1 = (short) (((((((byte) dooryUpDown.Value)) << 6) | (((byte) doorxUpDown.Value) & 0x3F)) << 1) + 0x8000);
				editingExit.doorType2 = 0;
			}
			else if (castledoorradioButton.Checked)
			{
				editingExit.doorXEditor = (byte) doorxUpDown.Value;
				editingExit.doorYEditor = (byte) dooryUpDown.Value;
				editingExit.doorType2 = (short) (((((((byte) dooryUpDown.Value)) << 6) | (((byte) doorxUpDown.Value) & 0x3F)) << 1) + 0x8000);
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

		public void SetExit(ExitOW exit)
		{
			settingValues = true;
			selectedExit = exit;
			editingExit = new ExitOW(exit.roomId, exit.mapId, exit.vramLocation, exit.yScroll, exit.xScroll, exit.playerY, exit.playerX, exit.cameraY, exit.cameraX, exit.unk1, exit.unk2, exit.doorType1, exit.doorType2);
			roomUpDown.Value = editingExit.roomId;
			mapUpDown.Value = editingExit.mapId;

			int mapy = (editingExit.mapId / 8);
			int mapx = editingExit.mapId - (mapy * 8);

			pixelMapx = ((mapx) * 512);
			pixelMapy = ((mapy) * 512);

			xPosUpDown.Value = (editingExit.playerX - pixelMapx); //editingExit.playerX;
			yPosUpDown.Value = (editingExit.playerY - ((pixelMapy))); //editingExit.playerY;
			xCameraUpDown.Value = (editingExit.cameraX - (pixelMapx));
			yCameraUpDown.Value = (editingExit.cameraY - (pixelMapy));
			xScrollUpDown.Value = (editingExit.xScroll - (pixelMapx));
			yScrollUpDown.Value = (editingExit.yScroll - (pixelMapy));
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
				editingExit.roomId = (short) roomUpDown.Value;
				editingExit.mapId = (byte) mapUpDown.Value;
				editingExit.playerX = (ushort) (xPosUpDown.Value + pixelMapx);
				editingExit.playerY = (ushort) (yPosUpDown.Value + pixelMapy);
				editingExit.cameraX = (short) (xCameraUpDown.Value + pixelMapx);
				editingExit.cameraY = (short) (yCameraUpDown.Value + pixelMapy);
				editingExit.xScroll = (short) (xScrollUpDown.Value + pixelMapx);
				editingExit.yScroll = (short) (yScrollUpDown.Value + pixelMapy);

				if (wooddoorradioButton.Checked)
				{
					editingExit.doorXEditor = (byte) doorxUpDown.Value;
					editingExit.doorYEditor = (byte) dooryUpDown.Value;

					editingExit.doorType1 = (short) ((((((byte) dooryUpDown.Value)) << 6) | (((byte) doorxUpDown.Value) & 0x3F)) << 1);
					editingExit.doorType2 = 0;

				}
				else if (sancdoorButton.Checked)
				{
					editingExit.doorXEditor = (byte) doorxUpDown.Value;
					editingExit.doorYEditor = (byte) dooryUpDown.Value;
					editingExit.doorType2 = (short) ((((((byte) dooryUpDown.Value)) << 6) | (((byte) doorxUpDown.Value) & 0x3F)) << 1);
					editingExit.doorType1 = 0;
				}
				else if (bombdoorradioButton.Checked)
				{
					editingExit.doorXEditor = (byte) doorxUpDown.Value;
					editingExit.doorYEditor = (byte) dooryUpDown.Value;
					editingExit.doorType1 = (short) (((((((byte) dooryUpDown.Value)) << 6) | (((byte) doorxUpDown.Value) & 0x3F)) << 1) + 0x8000);
					editingExit.doorType2 = 0;
				}
				else if (castledoorradioButton.Checked)
				{
					editingExit.doorXEditor = (byte) doorxUpDown.Value;
					editingExit.doorYEditor = (byte) dooryUpDown.Value;
					editingExit.doorType2 = (short) (((((((byte) dooryUpDown.Value)) << 6) | (((byte) doorxUpDown.Value) & 0x3F)) << 1) + 0x8000);
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
					editingExit.doorType1 = (short) ((((((byte) doorxUpDown.Value)) << 6) | (((byte) dooryUpDown.Value) & 0x3F)) << 1);
					editingExit.doorType2 = 0;
				}
				else if (sancdoorButton.Checked)
				{
					editingExit.doorXEditor = (byte) doorxUpDown.Value;
					editingExit.doorYEditor = (byte) dooryUpDown.Value;
					editingExit.doorType2 = (short) ((((((byte) doorxUpDown.Value)) << 6) | (((byte) dooryUpDown.Value) & 0x3F)) << 1);
					editingExit.doorType1 = 0;
				}
				else if (bombdoorradioButton.Checked)
				{
					editingExit.doorXEditor = (byte) doorxUpDown.Value;
					editingExit.doorYEditor = (byte) dooryUpDown.Value;
					editingExit.doorType1 = (short) (((((((byte) doorxUpDown.Value)) << 6) | (((byte) dooryUpDown.Value) & 0x3F)) << 1) + 0x8000);
					editingExit.doorType2 = 0;
				}
				else if (castledoorradioButton.Checked)
				{
					editingExit.doorXEditor = (byte) doorxUpDown.Value;
					editingExit.doorYEditor = (byte) dooryUpDown.Value;
					editingExit.doorType2 = (short) (((((((byte) doorxUpDown.Value)) << 6) | (((byte) dooryUpDown.Value) & 0x3F)) << 1) + 0x8000);
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
}
