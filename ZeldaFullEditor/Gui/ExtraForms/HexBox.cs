using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ZeldaFullEditor.Gui.ExtraForms
{
	public class Hexbox : TextBox
	{
		private int hexValue;
		private int minValue;
		private int maxValue;
		private bool _decimal = false;

		private const string Format0 = "X";
		private const string Format1 = "X1";
		private const string Format2 = "X2";
		private const string Format3 = "X3";
		private const string Format4 = "X4";
		private const string Format5 = "X5";
		private const string Format6 = "X6";
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
			Four = 65535,
			Five = 1048575,
			Six = 16777215,
		};

		public bool Decimal
		{
			get => _decimal;
			set
			{
				_decimal = value;
				UpdateText();
			}
		}

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
			get => this.maxValue;
			set
			{
				this.maxValue = value;

				//this.EnforceRange();
				//this.UpdateText();
			}
		}

		[Description("MinValue"), Category("Data")]
		public int MinValue
		{
			get => this.minValue;
			set
			{
				this.minValue = value;

				//this.EnforceRange();
				//this.UpdateText();
			}
		}

		[Description("Digits"), Category("Data")]
		public HexDigits Digits
		{
			get => this.digits;
			set
			{
				this.digits = value;

				switch (this.Digits)
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
					case HexDigits.Five:
						this.MaxLength = 5;
						break;
					case HexDigits.Six:
						this.MaxLength = 6;
						break;
				}

				//this.EnforceRange();
				//this.UpdateText();
			}
		}



		public Hexbox()
			: base()
		{
			//TODO: move these
			/*this.digits = HexDigits.Two;
            this.maxValue = 0xFF;
            this.minValue = 0x00;
            this.hexValue = 0x00;*/

			// Removed as its not necessary, can be set in the properties tab under text align.
			//this.TextAlign = HorizontalAlignment.Right;
			this.CharacterCasing = CharacterCasing.Upper;
		}

		protected override void InitLayout()
		{
			this.EnforceRange();
			this.UpdateText();

			base.InitLayout();
		}

		private void UpdateText()
		{
			if (!_decimal)
			{
				bool pad = this.enforcepad | !this.Focused;
				switch (this.Digits)
				{
					case HexDigits.One:
						this.Text = this.hexValue.ToString(pad ? Format1 : Format0);
						break;
					case HexDigits.Two:
						this.Text = this.hexValue.ToString(pad ? Format2 : Format0);
						break;
					case HexDigits.Three:
						this.Text = this.hexValue.ToString(pad ? Format3 : Format0);
						break;
					case HexDigits.Four:
						this.Text = this.hexValue.ToString(pad ? Format4 : Format0);
						break;
					case HexDigits.Five:
						this.Text = this.hexValue.ToString(pad ? Format5 : Format0);
						break;
					case HexDigits.Six:
						this.Text = this.hexValue.ToString(pad ? Format6 : Format0);
						break;
				}
			}
			else
			{
				this.Text = this.hexValue.ToString();
			}
		}

		private void EnforceRange()
		{
			if (this.minValue > (int) this.digits)
			{
				this.minValue = 0;
			}

			if (this.maxValue > (int) this.digits)
			{
				this.maxValue = (int) this.digits;
			}

			if (this.minValue > this.maxValue)
			{
				int t = this.minValue;
				this.minValue = this.maxValue;
				this.maxValue = t;
			}

			if (this.hexValue < this.minValue)
			{
				this.hexValue = this.minValue;
			}
			else if (this.hexValue > this.MaxValue)
			{
				this.hexValue = this.maxValue;
			}
		}

		protected override void OnTextChanged(EventArgs e)
		{
			if (!Decimal)
			{
				string regex = "[^a-fA-F0-9]";
				this.Text = Regex.Replace(this.Text, regex, string.Empty);

				if (int.TryParse(this.Text, System.Globalization.NumberStyles.HexNumber, System.Globalization.CultureInfo.CurrentCulture, out int r))
				{
					this.hexValue = r;
				}
				else
				{
					this.hexValue = this.minValue;
				}
			}
			else
			{
				string regex = "[^0-9]";
				this.Text = Regex.Replace(this.Text, regex, string.Empty);

				this.hexValue = int.Parse(this.Text);
			}
			//EnforceRange();
			//UpdateText();

			if (!this.disableTextChanged)
			{
				base.OnTextChanged(e);
				this.disableTextChanged = false;
			}
		}

		protected override void OnMouseWheel(MouseEventArgs e)
		{
			if (e.Delta > 0)
			{
				this.hexValue++;
			}
			else
			{
				hexValue--;
			}

			this.EnforceRange();
			this.enforcepad = true;
			this.UpdateText();
			this.enforcepad = false;
			base.OnMouseWheel(e);
		}

		protected override void OnLostFocus(EventArgs e)
		{
			if (!Decimal)
			{
				string regex = "[^a-fA-F0-9]";
				this.Text = Regex.Replace(this.Text, regex, "0");

				if (int.TryParse(this.Text, System.Globalization.NumberStyles.HexNumber, System.Globalization.CultureInfo.CurrentCulture, out int r))
				{
					this.hexValue = r;
				}
				else
				{
					this.hexValue = this.minValue;
				}

				this.EnforceRange();
				this.enforcepad = true;
				this.UpdateText();
				this.enforcepad = false;
			}
			else
			{
				string regex = "[^0-9]";
				this.Text = Regex.Replace(this.Text, regex, "0");
				this.hexValue = int.Parse(this.Text);
				this.EnforceRange();
				this.enforcepad = true;
				this.UpdateText();
				this.enforcepad = false;
			}

			base.OnLostFocus(e);
		}

		private void InitializeComponent()
		{
			this.SuspendLayout();

			// Hexbox
			this.KeyPress += new KeyPressEventHandler(this.Hexbox_KeyPress);
			this.KeyUp += new KeyEventHandler(this.Hexbox_KeyUp);
			this.Leave += new EventHandler(this.Hexbox_Leave);
			this.PreviewKeyDown += new PreviewKeyDownEventHandler(this.Hexbox_PreviewKeyDown);
			this.ResumeLayout(false);
		}

		private void Hexbox_KeyUp(object sender, KeyEventArgs e)
		{
			this.OnKeyUp(e);
		}

		private void Hexbox_Leave(object sender, EventArgs e)
		{
			/*
            if (errorValue)
			{
				hexValue = minValue;
			}
            */
			if (!Decimal)
			{
				string regex = "[^a-fA-F0-9]";
				this.Text = Regex.Replace(this.Text, regex, "0");

				if (int.TryParse(this.Text, System.Globalization.NumberStyles.HexNumber, System.Globalization.CultureInfo.CurrentCulture, out int r))
				{
					this.hexValue = r;
				}
				else
				{
					this.hexValue = this.minValue;
				}

				this.EnforceRange();
				this.enforcepad = true;
				this.UpdateText();
				this.enforcepad = false;
			}
			else
			{
				string regex = "[^0-9]";
				this.Text = Regex.Replace(this.Text, regex, "0");
				this.hexValue = int.Parse(this.Text);
				this.EnforceRange();
				this.enforcepad = true;
				this.UpdateText();
				this.enforcepad = false;
			}
			this.OnLeave(e);
		}

		private void Hexbox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!Decimal)
			{
				string regex = "[^a-fA-F0-9]";
				this.Text = Regex.Replace(this.Text, regex, "0");

				if (int.TryParse(this.Text, System.Globalization.NumberStyles.HexNumber, System.Globalization.CultureInfo.CurrentCulture, out int r))
				{
					this.hexValue = r;
				}
				else
				{
					this.hexValue = this.minValue;
				}

				this.EnforceRange();
				this.UpdateText();
			}
			else
			{

				string regex = "[^0-9]";
				this.Text = Regex.Replace(this.Text, regex, "0");
				this.hexValue = int.Parse(this.Text);
				this.EnforceRange();
				this.UpdateText();
			}
			this.OnKeyPress(e);
		}

		private void Hexbox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{

		}
	}
}
