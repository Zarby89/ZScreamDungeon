using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeldaFullEditor.Gui.ExtraForms {
	public partial class PrizePackBox : UserControl {
		private int index = 0;
		[Browsable(true)]
		[DefaultValue(0)]
		public int PackIndex {
			get => index;
			set {
				index = value;
				Text = $"Prize pack {index + 1}";
			}
		}

		private string text = "Prize pack 0";
		[Browsable(false)]
		public override string Text {
			get => text;
			set => this.groupBox1.Text = base.Text = text = value;
		}

		private readonly _DropRateItem[] droprates = {
			new _DropRateItem(0, "100%"),
			new _DropRateItem(1, "50%"),
			new _DropRateItem(3, "25%")
		};

		[Browsable(false)]
		public byte DropRateMask {
			get => (DroprateBox.SelectedItem as _DropRateItem)?.mask ?? 1;
			set {
				var rate = droprates.FirstOrDefault(o => o.mask == value);

				DroprateBox.SelectedItem = rate ?? droprates[1];
			}
		}




		private readonly byte[] _prizes = new byte[8];

		public void SetPrize(int index, byte b) {
			_prizes[index] = b;
		}

		public PrizePackBox() {
			InitializeComponent();

			PackIndex = index;

			DroprateBox.DataSource = droprates;
		}

		private class _DropRateItem {
			public readonly byte mask = 0;
			public readonly string text = "";

			public _DropRateItem(byte m, string t) {
				mask = m;
				text = t;
			}

			public override string ToString() => text;
		}

		private void DroprateBox_SelectedIndexChanged(object sender, EventArgs e) {
			PrizePacks.PrizePackRarities[index] = (DroprateBox.SelectedItem as _DropRateItem)?.mask ?? 1;
		}

		private void PackItem0_SelectedIndexChanged(object sender, EventArgs e) {
			PrizePacks.PrizePackPrizes[index, 0] = (byte) PackItem0.SelectedIndex;
		}

		private void PackItem1_SelectedIndexChanged(object sender, EventArgs e) {
			PrizePacks.PrizePackPrizes[index, 1] = (byte) PackItem1.SelectedIndex;
		}

		private void PackItem2_SelectedIndexChanged(object sender, EventArgs e) {
			PrizePacks.PrizePackPrizes[index, 2] = (byte) PackItem2.SelectedIndex;
		}

		private void PackItem3_SelectedIndexChanged(object sender, EventArgs e) {
			PrizePacks.PrizePackPrizes[index, 3] = (byte) PackItem3.SelectedIndex;
		}

		private void PackItem4_SelectedIndexChanged(object sender, EventArgs e) {
			PrizePacks.PrizePackPrizes[index, 4] = (byte) PackItem4.SelectedIndex;
		}

		private void PackItem5_SelectedIndexChanged(object sender, EventArgs e) {
			PrizePacks.PrizePackPrizes[index, 5] = (byte) PackItem5.SelectedIndex;
		}

		private void PackItem6_SelectedIndexChanged(object sender, EventArgs e) {
			PrizePacks.PrizePackPrizes[index, 6] = (byte) PackItem6.SelectedIndex;
		}

		private void PackItem7_SelectedIndexChanged(object sender, EventArgs e) {
			PrizePacks.PrizePackPrizes[index, 7] = (byte) PackItem7.SelectedIndex;
		}
	}
}
