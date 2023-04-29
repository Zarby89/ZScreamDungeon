using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
			// Removed as its not necessary, can be set in the properties tab under text align.
			//this.TextAlign = HorizontalAlignment.Right;
			this.CharacterCasing = CharacterCasing.Upper;
		}

		protected override void InitLayout()
		{
			EnforceRange();
			UpdateText();

			base.InitLayout();
		}

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
			string regex = "[^a-fA-F0-9]";
			Text = Regex.Replace(Text, regex, "");


			if (int.TryParse(Text, System.Globalization.NumberStyles.HexNumber, System.Globalization.CultureInfo.CurrentCulture, out int r))
			{
				hexValue = r;
			}
			else
			{
				hexValue = minValue;
			}

			//EnforceRange();
			//UpdateText();

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


		protected override void OnLostFocus(EventArgs e)
		{
			string regex = "[^a-fA-F0-9]";
			Text = Regex.Replace(Text, regex, "0");


			if (int.TryParse(Text, System.Globalization.NumberStyles.HexNumber, System.Globalization.CultureInfo.CurrentCulture, out int r))
			{
				hexValue = r;
			}
			else
			{
				hexValue = minValue;
			}

			EnforceRange();
			enforcepad = true;
			UpdateText();
			enforcepad = false;
			base.OnLostFocus(e);
		}

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Hexbox
            // 
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Hexbox_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Hexbox_KeyUp);
            this.Leave += new System.EventHandler(this.Hexbox_Leave);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Hexbox_PreviewKeyDown);
            this.ResumeLayout(false);

        }

        private void Hexbox_KeyUp(object sender, KeyEventArgs e)
        {


			base.OnKeyUp(e);
		}

		private void Hexbox_Leave(object sender, EventArgs e)
		{
			/*if (errorValue)
			{
				hexValue = minValue;
			}*/
			string regex = "[^a-fA-F0-9]";
			Text = Regex.Replace(Text, regex, "0");


			if (int.TryParse(Text, System.Globalization.NumberStyles.HexNumber, System.Globalization.CultureInfo.CurrentCulture, out int r))
			{
				hexValue = r;
			}
			else
			{
				hexValue = minValue;
			}

			EnforceRange();
			enforcepad = true;
			UpdateText();
			enforcepad = false;
			base.OnLeave(e);
		}

		private void Hexbox_KeyPress(object sender, KeyPressEventArgs e)
		{
			Console.WriteLine("HEX VALUE CHANGED!!!");
			string regex = "[^a-fA-F0-9]";
			Text = Regex.Replace(Text, regex, "0");


			if (int.TryParse(Text, System.Globalization.NumberStyles.HexNumber, System.Globalization.CultureInfo.CurrentCulture, out int r))
			{
				hexValue = r;
				
			}
			else
			{
				hexValue = minValue;
			}
			EnforceRange();
			UpdateText();

			base.OnKeyPress(e);
		}

		private void Hexbox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			
		}
	}
}
