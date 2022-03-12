using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeldaFullEditor.Gui.ExtraForms {
    class Hexbox : TextBox {
        private int hexValue;
        private int minValue;
        private int maxValue;
        public enum hexDigits {
            One = 15,
            Two = 255,
            Three = 4095,
            Four = 65535
		};
        private hexDigits digits;

        public bool errorValue = false;
        //just turn that on when updating the Hexvalue so the textchanged event is not called
        private bool disableTextChanged = false;


        [Description("HexValue"), Category("Data")]
        public int HexValue {
            get => hexValue;
            set {
                hexValue = value;

                enforceRange();
                updateText();
            }
        }

        [Description("MaxValue"), Category("Data")]
        public int MaxValue {
            get => maxValue;
            set {
                maxValue = value;

                enforceRange();
                updateText();
            }
        }

        [Description("MinValue"), Category("Data")]
        public int MinValue {
            get => minValue;
            set {
                minValue = value;

                enforceRange();
                updateText();
            }
        }



        [Description("MinValue"), Category("Data")]
        public hexDigits Digits {
            get => digits;
            set {
                digits = value;

                enforceRange();
                updateText();
            }
        }

        public Hexbox() : base() {
            digits = hexDigits.Two;
            maxValue = 0xFF;
            minValue = 0x00;
            hexValue = 0x00;
            this.TextAlign = HorizontalAlignment.Right;
            this.CharacterCasing = CharacterCasing.Upper;
        }


        protected override void InitLayout() {
            enforceRange();
            updateText();

            base.InitLayout();
        }


        private const string Format0 = "X";
        private const string Format1 = "X1";
        private const string Format2 = "X2";
        private const string Format3 = "X3";
        private const string Format4 = "X4";
        private bool enforcepad = false;
        private void updateText(bool pad = false) {
            enforcepad = pad;
            switch (Digits) {
                case hexDigits.One:
                    this.Text = hexValue.ToString(pad ? Format1 : Format0);
                    this.MaxLength = 1;
                    break;
                case hexDigits.Two:
                    this.Text = hexValue.ToString(pad ? Format2 : Format0);
                    this.MaxLength = 2;
                    break;
                case hexDigits.Three:
                    this.Text = hexValue.ToString(pad ? Format3 : Format0);
                    this.MaxLength = 3;
                    break;
                case hexDigits.Four:
                    this.Text = hexValue.ToString(pad ? Format4 : Format0);
                    this.MaxLength = 4;
                    break;
            }
            enforcepad = false;
        }

        private void enforceRange() {
            if (minValue > (int) digits) {
                minValue = 0;
			}

            if (maxValue > (int) digits) {
                maxValue = (int) digits;
			}

            if (minValue > maxValue) {
                int t = minValue;
                minValue = maxValue;
                maxValue = t;
			}


            if (hexValue < minValue) {
                hexValue = minValue;
            } else if (hexValue > MaxValue) {
                hexValue = maxValue;
            }
        }

        protected override void OnTextChanged(EventArgs e) {
            errorValue = !Int32.TryParse(this.Text, System.Globalization.NumberStyles.HexNumber, null, out int tb);

            hexValue = tb;

            enforceRange();
            updateText(!enforcepad);

            if (!disableTextChanged) //
            {
                base.OnTextChanged(e);
                disableTextChanged = false;
            }


        }

        protected override void OnMouseWheel(MouseEventArgs e) {
            if (e.Delta > 0) {
                hexValue++;
            } else {
                hexValue--;
            }

            enforceRange();
            updateText(true);
            base.OnMouseWheel(e);
        }

        protected override void OnLeave(EventArgs e) {
            if (errorValue) {
                hexValue = minValue;
            }

            enforceRange();
            updateText(true);
            base.OnLeave(e);
        }

        protected override void OnLostFocus(EventArgs e) {
            if (errorValue) {
                hexValue = minValue;
            }
            enforceRange();
            updateText(true);
            base.OnLostFocus(e);
        }
    }
}
