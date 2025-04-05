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
            editingExit.IsAutomatic = automaticcheckBox.Checked;
            if (!automaticcheckBox.Checked)
            {
                editingExit.PlayerX = (ushort)((int)(xPosUpDown.Value + pixelMapx)).Clamp(0, 4088);
                editingExit.PlayerY = (ushort)((int)(yPosUpDown.Value + pixelMapy)).Clamp(0, 4088);

                editingExit.CameraX = (ushort)(xCameraUpDown.Value + pixelMapx);
                editingExit.CameraY = (ushort)(yCameraUpDown.Value + pixelMapy);

                editingExit.XScroll = (ushort)(xScrollUpDown.Value + pixelMapx);
                editingExit.YScroll = (ushort)(yScrollUpDown.Value + pixelMapy);

                editingExit.DoorXEditor = (byte)doorxUpDown.Value;
                editingExit.DoorYEditor = (byte)dooryUpDown.Value;
            }

            if (wooddoorradioButton.Checked)
            {
                editingExit.DoorXEditor = (byte)doorxUpDown.Value;
                editingExit.DoorYEditor = (byte)dooryUpDown.Value;
                editingExit.DoorType1 = (ushort)((((((byte)dooryUpDown.Value)) << 6) | (((byte)doorxUpDown.Value) & 0x3F)) << 1);
                editingExit.DoorType2 = 0;
            }
            else if (sancdoorButton.Checked)
            {
                editingExit.DoorXEditor = (byte)doorxUpDown.Value;
                editingExit.DoorYEditor = (byte)dooryUpDown.Value;
                editingExit.DoorType2 = (ushort)((((((byte)dooryUpDown.Value)) << 6) | (((byte)doorxUpDown.Value) & 0x3F)) << 1);
                editingExit.DoorType1 = 0;
            }
            else if (bombdoorradioButton.Checked)
            {
                editingExit.DoorXEditor = (byte)doorxUpDown.Value;
                editingExit.DoorYEditor = (byte)dooryUpDown.Value;
                editingExit.DoorType1 = (ushort)(((((((byte)dooryUpDown.Value)) << 6) | (((byte)doorxUpDown.Value) & 0x3F)) << 1) + 0x8000);
                editingExit.DoorType2 = 0;
            }
            else if (castledoorradioButton.Checked)
            {
                editingExit.DoorXEditor = (byte)doorxUpDown.Value;
                editingExit.DoorYEditor = (byte)dooryUpDown.Value;
                editingExit.DoorType2 = (ushort)(((((((byte)dooryUpDown.Value)) << 6) | (((byte)doorxUpDown.Value) & 0x3F)) << 1) + 0x8000);
                editingExit.DoorType1 = 0;
            }
            else
            {
                editingExit.DoorXEditor = 0;
                editingExit.DoorYEditor = 0;
                editingExit.DoorType2 = 0;
                editingExit.DoorType1 = 0;
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
            editingExit = new ExitOW(exit.RoomID, exit.MapID, exit.VRAMLocation, exit.YScroll, exit.XScroll, exit.PlayerY, exit.PlayerX, exit.CameraY, exit.CameraX, exit.ScrollModY, exit.ScrollModX, exit.DoorType1, exit.DoorType2);
            roomUpDown.HexValue = editingExit.RoomID;
            mapUpDown.Value = editingExit.MapID;

            int mapy = (editingExit.MapID / 8);
            int mapx = editingExit.MapID - (mapy * 8);

            pixelMapx = ((mapx) * 512);
            pixelMapy = ((mapy) * 512);

            xPosUpDown.Value = (editingExit.PlayerX - pixelMapx); //editingExit.playerX;
            yPosUpDown.Value = (editingExit.PlayerY - ((pixelMapy))); //editingExit.playerY;
            xCameraUpDown.Value = (editingExit.CameraX - (pixelMapx));
            yCameraUpDown.Value = (editingExit.CameraY - (pixelMapy));
            xScrollUpDown.Value = (editingExit.XScroll - (pixelMapx));
            yScrollUpDown.Value = (editingExit.YScroll - (pixelMapy));
            editingExit.DoorXEditor = exit.DoorXEditor;
            editingExit.DoorYEditor = exit.DoorYEditor;
            doorxUpDown.Value = editingExit.DoorXEditor;
            dooryUpDown.Value = editingExit.DoorYEditor;
            editingExit.IsAutomatic = exit.IsAutomatic;
            automaticcheckBox.Checked = editingExit.IsAutomatic;
            nodoorradioButton.Checked = true;

            if ((editingExit.DoorType1 & 0x8000) != 0) { bombdoorradioButton.Checked = true; }
            else if (editingExit.DoorType1 != 0) { wooddoorradioButton.Checked = true; }
            else if ((editingExit.DoorType2 & 0x8000) != 0) { castledoorradioButton.Checked = true; }
            else if (editingExit.DoorType2 != 0) { sancdoorButton.Checked = true; }

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
            editingExit.IsAutomatic = automaticcheckBox.Checked;
        }

        private void xPosUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!settingValues)
            {
                editingExit.RoomID = (ushort)roomUpDown.HexValue;
                editingExit.MapID = (byte)mapUpDown.Value;
                editingExit.PlayerX = (ushort)((int)(xPosUpDown.Value + pixelMapx)).Clamp(0, 4088);
                editingExit.PlayerY = (ushort)((int)(yPosUpDown.Value + pixelMapy)).Clamp(0, 4088);
                editingExit.CameraX = (ushort)(xCameraUpDown.Value + pixelMapx);
                editingExit.CameraY = (ushort)(yCameraUpDown.Value + pixelMapy);
                editingExit.XScroll = (ushort)(xScrollUpDown.Value + pixelMapx);
                editingExit.YScroll = (ushort)(yScrollUpDown.Value + pixelMapy);

                if (wooddoorradioButton.Checked)
                {
                    editingExit.DoorXEditor = (byte)doorxUpDown.Value;
                    editingExit.DoorYEditor = (byte)dooryUpDown.Value;

                    editingExit.DoorType1 = (ushort)((((((byte)dooryUpDown.Value)) << 6) | (((byte)doorxUpDown.Value) & 0x3F)) << 1);
                    editingExit.DoorType2 = 0;

                }
                else if (sancdoorButton.Checked)
                {
                    editingExit.DoorXEditor = (byte)doorxUpDown.Value;
                    editingExit.DoorYEditor = (byte)dooryUpDown.Value;
                    editingExit.DoorType2 = (ushort)((((((byte)dooryUpDown.Value)) << 6) | (((byte)doorxUpDown.Value) & 0x3F)) << 1);
                    editingExit.DoorType1 = 0;
                }
                else if (bombdoorradioButton.Checked)
                {
                    editingExit.DoorXEditor = (byte)doorxUpDown.Value;
                    editingExit.DoorYEditor = (byte)dooryUpDown.Value;
                    editingExit.DoorType1 = (ushort)(((((((byte)dooryUpDown.Value)) << 6) | (((byte)doorxUpDown.Value) & 0x3F)) << 1) + 0x8000);
                    editingExit.DoorType2 = 0;
                }
                else if (castledoorradioButton.Checked)
                {
                    editingExit.DoorXEditor = (byte)doorxUpDown.Value;
                    editingExit.DoorYEditor = (byte)dooryUpDown.Value;
                    editingExit.DoorType2 = (ushort)(((((((byte)dooryUpDown.Value)) << 6) | (((byte)doorxUpDown.Value) & 0x3F)) << 1) + 0x8000);
                    editingExit.DoorType1 = 0;
                }
                else
                {
                    editingExit.DoorXEditor = 0;
                    editingExit.DoorYEditor = 0;
                    editingExit.DoorType2 = 0;
                    editingExit.DoorType1 = 0;
                }

                editingExit.IsAutomatic = automaticcheckBox.Checked;
            }

            //editingExit.doorType1 = (byte)doorxUpDown.Value;
            //editingExit.doorType2 = (byte)doorxUpDown.Value;
            //(byte)dooryUpDown.Value;
        }

        private void setPositionButton_Click(object sender, EventArgs e)
        {
            selectedExit.DoorType1 = editingExit.DoorType1;
            selectedExit.DoorType2 = editingExit.DoorType2;
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
                    editingExit.DoorXEditor = (byte)doorxUpDown.Value;
                    editingExit.DoorYEditor = (byte)dooryUpDown.Value;
                    editingExit.DoorType1 = (ushort)((((((byte)doorxUpDown.Value)) << 6) | (((byte)dooryUpDown.Value) & 0x3F)) << 1);
                    editingExit.DoorType2 = 0;
                }
                else if (sancdoorButton.Checked)
                {
                    editingExit.DoorXEditor = (byte)doorxUpDown.Value;
                    editingExit.DoorYEditor = (byte)dooryUpDown.Value;
                    editingExit.DoorType2 = (ushort)((((((byte)doorxUpDown.Value)) << 6) | (((byte)dooryUpDown.Value) & 0x3F)) << 1);
                    editingExit.DoorType1 = 0;
                }
                else if (bombdoorradioButton.Checked)
                {
                    editingExit.DoorXEditor = (byte)doorxUpDown.Value;
                    editingExit.DoorYEditor = (byte)dooryUpDown.Value;
                    editingExit.DoorType1 = (ushort)(((((((byte)doorxUpDown.Value)) << 6) | (((byte)dooryUpDown.Value) & 0x3F)) << 1) + 0x8000);
                    editingExit.DoorType2 = 0;
                }
                else if (castledoorradioButton.Checked)
                {
                    editingExit.DoorXEditor = (byte)doorxUpDown.Value;
                    editingExit.DoorYEditor = (byte)dooryUpDown.Value;
                    editingExit.DoorType2 = (ushort)(((((((byte)doorxUpDown.Value)) << 6) | (((byte)dooryUpDown.Value) & 0x3F)) << 1) + 0x8000);
                    editingExit.DoorType1 = 0;
                }
                else if (nodoorradioButton.Checked)
                {
                    editingExit.DoorXEditor = 0;
                    editingExit.DoorYEditor = 0;
                    editingExit.DoorType2 = 0;
                    editingExit.DoorType1 = 0;
                }
            }
        }
    }
}
