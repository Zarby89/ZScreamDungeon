namespace ZeldaFullEditor.UserInterface.GeneralControls;

[DefaultEvent(nameof(HexValueChanged))]
public class Hexbox : TextBox
{
	private int hexValue;

	private bool errorValue = false;

	public new bool Multiline = false;

	private ValueRange range = new(0x00, 0xFF);
	[Description("ValueRange"), Category("Data")]
	public ValueRange Range
	{
		get => range;
		set
		{
			if (range == value) return;
			range = value;
			EnforceRangeAndBoundaries();
		}
	}

	private EventHandler _valueChanged;

	[Browsable(true)]
	public event EventHandler HexValueChanged
	{
		add => _valueChanged += value;
		remove => _valueChanged -= value;
	}

	protected virtual void OnValueChanged(EventArgs e)
	{
		_valueChanged?.Invoke(this, e);
	}


	[Description("HexValue"), Category("Data")]
	public int HexValue
	{
		get => hexValue;
		set
		{
			if (hexValue == value) return;

			hexValue = value;

			EnforceRange();

			OnValueChanged(new());

			UpdateText(false);
		}
	}

	[Browsable(false)]
	public int MaxValue
	{
		get => range.Max;
		//set
		//{
		//	range.Max = value;
		//	EnforceRangeAndBoundaries();
		//}
	}

	[Browsable(false)]
	public int MinValue
	{
		get => range.Min;
		//set
		//{
		//	range.Min = value;
		//	EnforceRangeAndBoundaries();
		//}
	}

	private string digitsFormat;

	public Hexbox() : base()
	{
		TextAlign = HorizontalAlignment.Right; // default to right alignment - don't fucking change this, Jared
		CharacterCasing = CharacterCasing.Upper;
	}

	protected override void InitLayout()
	{
		EnforceRangeAndBoundaries();
		UpdateText(true);

		base.InitLayout();
	}

	private const string Format0 = "X";
	private const string Format1 = "X1";
	private const string Format2 = "X2";
	private const string Format3 = "X3";
	private const string Format4 = "X4";

	private void UpdateText(bool enforcepad)
	{
		Text = hexValue.ToString(enforcepad || !Focused ? digitsFormat : Format0);
	}

	/// <summary>
	/// Enforces the min and max values to fall within a valid range for the number of digits.<br/>
	/// Enforces max > min.
	/// </summary>
	private void EnforceRangeAndBoundaries()
	{
		if (MinValue > MaxValue)
		{
			range = new ValueRange(MaxValue, MinValue);
		}

		switch (MaxValue)
		{
			case < 0x10:
				digitsFormat = Format1;
				MaxLength = 1;
				break;

			case < 0x100:
				digitsFormat = Format2;
				MaxLength = 2;
				break;

			case < 0x1000:
				digitsFormat = Format3;
				MaxLength = 3;
				break;

			default:
				digitsFormat = Format4;
				MaxLength = 4;
				break;
		}

		EnforceRange();
	}

	/// <summary>
	/// Enforces the value of the box to be between the min and max values.
	/// </summary>
	private void EnforceRange()
	{
		if (hexValue < MinValue)
		{
			HexValue = MinValue;
		}
		else if (hexValue > MaxValue)
		{
			HexValue = MaxValue;
		}
	}

	protected override void OnTextChanged(EventArgs e)
	{
		errorValue = !int.TryParse(Text, NumberStyles.HexNumber, null, out int n);
		HexValue = n;

		base.OnTextChanged(e);
	}

	private void StandardizeText()
	{
		EnforceRange();
		UpdateText(true);
	}

	protected override void OnMouseWheel(MouseEventArgs e)
	{
		HexValue = e.ScrollByValue(hexValue, 1);

		StandardizeText();
		base.OnMouseWheel(e);
	}

	protected override void OnLeave(EventArgs e)
	{
		if (errorValue)
		{
			HexValue = MinValue;
		}

		StandardizeText();
		base.OnLeave(e);
	}

	protected override void OnLostFocus(EventArgs e)
	{
		if (errorValue)
		{
			HexValue = MinValue;
		}
		StandardizeText();
		base.OnLostFocus(e);
	}
}
