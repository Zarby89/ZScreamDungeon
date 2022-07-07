namespace ZeldaFullEditor;

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
			ParseAsHex ? "X" : string.Empty,
			CultureInfo.CurrentCulture
		);
	}

	private void RoomNumber_TextChanged(object sender, EventArgs e)
	{
		if (TryGetValue(out var value) || value < 0)
		{
			SelectedRoom = value;
			btnGo.Enabled = true;
		}
		else
		{
			btnGo.Enabled = false;
		}

		bool TryGetValue(out int result)
		{
			return Int32.TryParse
			(
				tbxRoomNumber.Text,
				NumberStyle,
				CultureInfo.CurrentCulture,
				out result
			);
		}
	}

	private void ParseAsHex_CheckedChanged(object sender, EventArgs e)
	{
		UpdateText();
	}
}
