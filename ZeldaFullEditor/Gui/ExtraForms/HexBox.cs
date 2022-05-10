namespace ZeldaFullEditor.Gui.ExtraForms
{
	public class Hexbox : TextBox
	{
		private int hexValue;

		private bool errorValue = false;

		public new bool Multiline = false;

		private ValueRange range = new ValueRange(0x00, 0xFF);
		[Description("ValueRange"), Category("Data")]
		public ValueRange Range
		{
			get => range;
			set
			{
				range = value;
				EnforceRangeAndBoundaries();
			}
		}

		[Description("HexValue"), Category("Data")]
		public int HexValue
		{
			get => hexValue;
			set
			{
				hexValue = value;

				EnforceRange();
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

			if (MaxValue < 0x10)
			{
				digitsFormat = Format1;
				MaxLength = 1;
			}
			else if (MaxValue < 0x100)
			{
				digitsFormat = Format2;
				MaxLength = 2;
			}
			else if (MaxValue < 0x1000)
			{
				digitsFormat = Format3;
				MaxLength = 3;
			}
			else
			{
				digitsFormat = Format4;
				MaxLength = 4;
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
				hexValue = MinValue;
			}
			else if (hexValue > MaxValue)
			{
				hexValue = MaxValue;
			}
		}

		protected override void OnTextChanged(EventArgs e)
		{
			errorValue = !int.TryParse(Text, NumberStyles.HexNumber, null, out hexValue);

			EnforceRange();
			UpdateText(false);

			base.OnTextChanged(e);
		}

		private void StandardizeText()
		{
			EnforceRange();
			UpdateText(true);
		}

		protected override void OnMouseWheel(MouseEventArgs e)
		{
			hexValue = e.ScrollByValue(hexValue, 1);

			StandardizeText();
			base.OnMouseWheel(e);
		}

		protected override void OnLeave(EventArgs e)
		{
			if (errorValue)
			{
				hexValue = MinValue;
			}

			StandardizeText();
			base.OnLeave(e);
		}

		protected override void OnLostFocus(EventArgs e)
		{
			if (errorValue)
			{
				hexValue = MinValue;
			}
			StandardizeText();
			base.OnLostFocus(e);
		}
	}
}
