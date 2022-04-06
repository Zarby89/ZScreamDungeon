using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeldaFullEditor.Gui.ExtraForms
{
	public class Hexbox : TextBox
	{
		private int hexValue;
		private int minValue;
		private int maxValue;

		private const string Format0 = "X";
		private const string Format1 = "X1";
		private const string Format2 = "X2";
		private const string Format3 = "X3";
		private const string Format4 = "X4";
		private bool enforcepad = false;

		public bool errorValue = false;
		// Just turn that on when updating the Hexvalue so the textchanged event is not called.
		private bool disableTextChanged = false;

		// value = max possible value with X digits
		public enum HexDigits
		{
			One = 15,
			Two = 255,
			Three = 4095,
			Four = 65535
		};
		private HexDigits digits;

		[Description("HexValue"), Category("Data")]
		public int HexValue
		{
			get => hexValue;
			set
			{
				hexValue = value;

				EnforceRange();
				UpdateText();
			}
		}

		[Description("MaxValue"), Category("Data")]
		public int MaxValue
		{
			get => maxValue;
			set
			{
				maxValue = value;

				EnforceRangeAndBoundaries();
				UpdateText();
			}
		}

		[Description("MinValue"), Category("Data")]
		public int MinValue
		{
			get => minValue;
			set
			{
				minValue = value;

				EnforceRangeAndBoundaries();
				UpdateText();
			}
		}

		[Description("MinValue"), Category("Data")]
		public HexDigits Digits
		{
			get => digits;
			set
			{
				digits = value;

				switch (Digits)
				{
					case HexDigits.One:
						MaxLength = 1;
						break;
					case HexDigits.Two:
						MaxLength = 2;
						break;
					case HexDigits.Three:
						MaxLength = 3;
						break;
					case HexDigits.Four:
						MaxLength = 4;
						break;
				}

				EnforceRangeAndBoundaries();
				UpdateText();
			}
		}

		public Hexbox() : base()
		{
			digits = HexDigits.Two;
			maxValue = 0xFF;
			minValue = 0x00;
			hexValue = 0x00;
			this.TextAlign = HorizontalAlignment.Right; // default to right alignment - don't fucking change this, Jared
			this.CharacterCasing = CharacterCasing.Upper;
		}

		protected override void InitLayout()
		{
			EnforceRangeAndBoundaries();
			UpdateText();

			base.InitLayout();
		}

		private void UpdateText()
		{
			bool pad = enforcepad || !Focused;
			switch (Digits)
			{
				case HexDigits.One:
					Text = hexValue.ToString(pad ? Format1 : Format0);
					break;
				case HexDigits.Two:
					Text = hexValue.ToString(pad ? Format2 : Format0);
					break;
				case HexDigits.Three:
					Text = hexValue.ToString(pad ? Format3 : Format0);
					break;
				case HexDigits.Four:
					Text = hexValue.ToString(pad ? Format4 : Format0);
					break;
			}
		}

		/// <summary>
		/// Enforces the min and max values to fall within a valid range for the number of digits.<br/>
		/// Enforces max > min.
		/// </summary>
		private void EnforceRangeAndBoundaries()
		{
			if (minValue > (int) digits)
			{
				minValue = 0;
			}

			if (maxValue > (int) digits)
			{
				maxValue = (int) digits;
			}

			if (minValue > maxValue)
			{
				int t = minValue;
				minValue = maxValue;
				maxValue = t;
			}

			EnforceRange();
		}

		/// <summary>
		/// Enforces the value of the box to be between the min and max values.
		/// </summary>
		private void EnforceRange()
		{
			if (hexValue < minValue)
			{
				hexValue = minValue;
			}
			else if (hexValue > maxValue)
			{
				hexValue = maxValue;
			}
		}

		protected override void OnTextChanged(EventArgs e)
		{
			errorValue = !int.TryParse(Text, System.Globalization.NumberStyles.HexNumber, null, out int tb);

			hexValue = tb;

			EnforceRange();
			UpdateText();

			if (!disableTextChanged)
			{
				base.OnTextChanged(e);
				disableTextChanged = false;
			}
		}

		protected override void OnMouseWheel(MouseEventArgs e)
		{
			if (e.Delta > 0)
			{
				hexValue++;
			}
			else
			{
				hexValue--;
			}

			EnforceRange();
			enforcepad = true;
			UpdateText();
			enforcepad = false;
			base.OnMouseWheel(e);
		}

		protected override void OnLeave(EventArgs e)
		{
			if (errorValue)
			{
				hexValue = minValue;
			}

			EnforceRange();
			enforcepad = true;
			UpdateText();
			enforcepad = false;
			base.OnLeave(e);
		}

		protected override void OnLostFocus(EventArgs e)
		{
			if (errorValue)
			{
				hexValue = minValue;
			}
			EnforceRange();
			enforcepad = true;
			UpdateText();
			enforcepad = false;
			base.OnLostFocus(e);
		}
	}
}
