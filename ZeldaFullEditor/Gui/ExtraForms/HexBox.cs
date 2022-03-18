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

		// value = max possible value with X digits
		public enum HexDigits
		{
			One = 15,
			Two = 255,
			Three = 4095,
			Four = 65535
		};
		private HexDigits digits;

		public bool errorValue = false;
		//just turn that on when updating the Hexvalue so the textchanged event is not called
		private bool disableTextChanged = false;


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

				EnforceRange();
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

				EnforceRange();
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
						this.MaxLength = 1;
						break;
					case HexDigits.Two:
						this.MaxLength = 2;
						break;
					case HexDigits.Three:
						this.MaxLength = 3;
						break;
					case HexDigits.Four:
						this.MaxLength = 4;
						break;
				}

				EnforceRange();
				UpdateText();
			}
		}

		public Hexbox() : base()
		{
			digits = HexDigits.Two;
			maxValue = 0xFF;
			minValue = 0x00;
			hexValue = 0x00;
			this.TextAlign = HorizontalAlignment.Right;
			this.CharacterCasing = CharacterCasing.Upper;
		}


		protected override void InitLayout()
		{
			EnforceRange();
			UpdateText();

			base.InitLayout();
		}


		private const string Format0 = "X";
		private const string Format1 = "X1";
		private const string Format2 = "X2";
		private const string Format3 = "X3";
		private const string Format4 = "X4";
		private bool enforcepad = false;
		private void UpdateText()
		{
			bool pad = enforcepad | !this.Focused;
			switch (Digits)
			{
				case HexDigits.One:
					this.Text = hexValue.ToString(pad ? Format1 : Format0);
					break;
				case HexDigits.Two:
					this.Text = hexValue.ToString(pad ? Format2 : Format0);
					break;
				case HexDigits.Three:
					this.Text = hexValue.ToString(pad ? Format3 : Format0);
					break;
				case HexDigits.Four:
					this.Text = hexValue.ToString(pad ? Format4 : Format0);
					break;
			}
		}

		private void EnforceRange()
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


			if (hexValue < minValue)
			{
				hexValue = minValue;
			}
			else if (hexValue > MaxValue)
			{
				hexValue = maxValue;
			}
		}

		protected override void OnTextChanged(EventArgs e)
		{
			errorValue = !int.TryParse(this.Text, System.Globalization.NumberStyles.HexNumber, null, out int tb);

			hexValue = tb;

			EnforceRange();
			UpdateText();

			if (!disableTextChanged) //
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
