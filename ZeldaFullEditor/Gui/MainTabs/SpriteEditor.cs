using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeldaFullEditor.Data;

namespace ZeldaFullEditor.Gui.MainTabs
{
	public partial class SpriteEditor : UserControl
	{
		public SpriteEditor()
		{
			InitializeComponent();
			SpritePropChooser.DataSource = DefaultEntities.ListOfSprites;
		}

		private SpriteProperties SelectedSprite = SpriteProperties.Empty;

		private void SpritePropChooser_SelectedValueChanged(object sender, EventArgs e)
		{
			var s = (SpriteName) SpritePropChooser.SelectedItem;
			byte id = (byte) s.ID;

			var spr = ZScreamer.ActiveScreamer.SpriteProps[id];

			UpdatingFromPicker = true;

			JustRefreshEverything();

			UpdatingFromPicker = false;
		}


		private bool UpdatingFromPicker = false;
		// TODO use this bool to prevent changes from propogating back to the sprite unnecessarily when updating GUI for it?
		private void JustRefreshEverything()
		{

		}

		private void OnSpritePropertyChange(object sender, EventArgs e)
		{
			if (UpdatingFromPicker) return;
			JustRefreshEverything();
		}



		// TODO damage table: 06F42D jp
	}
}
