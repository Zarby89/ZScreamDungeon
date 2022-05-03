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

		private bool errorValue = false;

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
		[DefaultValue(HexDigits.Two)]
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

		[Description("MaxValue"), Category("Data")]
		[DefaultValue(0xFF)]
		public int MaxValue
		{
			get => maxValue;
			set
			{
				maxValue = value;

				EnforceRangeAndBoundaries();
				UpdateText(false);
			}
		}

		[Description("MinValue"), Category("Data")]
		[DefaultValue(0x00)]
		public int MinValue
		{
			get => minValue;
			set
			{
				minValue = value;

				EnforceRangeAndBoundaries();
				UpdateText(false);
			}
		}

		[Description("Digits"), Category("Data")]
		[DefaultValue(HexDigits.Two)]
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
				UpdateText(false);
			}
		}

		public Hexbox() : base()
		{
			TextAlign = HorizontalAlignment.Right; // default to right alignment - don't fucking change this, Jared
			CharacterCasing = CharacterCasing.Upper;
		}

		protected override void InitLayout()
		{
			EnforceRangeAndBoundaries();
			UpdateText(false);

			base.InitLayout();
		}

		private void UpdateText(bool enforcepad)
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
			errorValue = !int.TryParse(Text, System.Globalization.NumberStyles.HexNumber, null, out hexValue);

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
			e.ScrollByValue(ref hexValue, 1);

			StandardizeText();
			base.OnMouseWheel(e);
		}

		protected override void OnLeave(EventArgs e)
		{
			if (errorValue)
			{
				hexValue = minValue;
			}

			StandardizeText();
			base.OnLeave(e);
		}

		protected override void OnLostFocus(EventArgs e)
		{
			if (errorValue)
			{
				hexValue = minValue;
			}
			StandardizeText();
			base.OnLostFocus(e);
		}
	}
}
