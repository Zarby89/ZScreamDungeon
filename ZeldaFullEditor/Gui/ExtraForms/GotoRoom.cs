using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeldaFullEditor
{
    public partial class GotoRoom : Form
    {
        private int _selectedRoom;

        public GotoRoom()
        {
            InitializeComponent();
        }

        public bool ParseAsHex
        {
            get
            {
                return chkParseAsHex.Checked;
            }
            set
            {
                chkParseAsHex.Checked = value;
            }
        }

        public int SelectedRoom
        {
            get
            {
                return _selectedRoom;
            }
            set
            {
                if (SelectedRoom == value)
                {
                    return;
                }

                if (value < 0)
                {
                    return;
                }

                _selectedRoom = value;
                UpdateText();
            }
        }

        private NumberStyles NumberStyle
        {
            get
            {
                return ParseAsHex
                    ? NumberStyles.HexNumber
                    : NumberStyles.Integer & ~NumberStyles.AllowLeadingSign;
            }
        }

        private void UpdateText()
        {
            tbxRoomNumber.Text = SelectedRoom.ToString
            (
                ParseAsHex ? "X" : String.Empty,
                CultureInfo.CurrentCulture
            );
        }

        private void RoomNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void ParseAsHex_CheckedChanged(object sender, EventArgs e)
        {
            if (chkParseAsHex.Checked)
            {
                tbxRoomNumber.Decimal = false;
            }
            else
            {
                tbxRoomNumber.Decimal = true;
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            _selectedRoom = tbxRoomNumber.HexValue;
        }
    }
}
