using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeldaFullEditor.Gui.ExtraForms;

namespace ZeldaFullEditor.Gui.MainTabs {
	public partial class PrizePacksEditor : UserControl {
		public PrizePacksEditor() {
			InitializeComponent();
		}


		public void Initialize() {
			int rarityx = Utils.SnesToPc(0x06FA5C);
			int prizesx = Utils.SnesToPc(0x06FA72);

			for (int i = 0; i < 7; i++) {
				var box = GetBox(i);

				box.DropRateMask = PrizePacks.PrizePackRarities[i] = ROM.ReadByte(rarityx++);
				


				for (int j = 0; j < 8; j++) {
					box.SetPrize(j, ROM.ReadByte(prizesx++));
				}
			}
		}


		private PrizePackBox GetBox(int i) {
			switch (i) {
				case 0 : return prizePackBox1;
				case 1 : return prizePackBox2;
				case 2 : return prizePackBox3;
				case 3 : return prizePackBox4;
				case 4 : return prizePackBox5;
				case 5 : return prizePackBox6;
				case 6 : return prizePackBox7;
			};
			return null;
		}


	}
}
