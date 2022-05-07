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

			JustRefreshEverything();
		}


		private bool UpdatingFromPicker = false;
		// TODO use this bool to prevent changes from propogating back to the sprite unnecessarily when updating GUI for it?
		private void JustRefreshEverything()
		{
			UpdatingFromPicker = true;

			DamageSFXBox.Checked = SelectedSprite.UseBossSFX;
			IgnoreConveyorBox.Checked = SelectedSprite.IgnoreMovingFloors;
			OverworldPersistBox.Checked = SelectedSprite.PersistOnOverworld;
			IgnoreForKillBox.Checked = SelectedSprite.IgnoreKillRoom;
			HasShadowBox.Checked = SelectedSprite.DrawShadow;
			ImmuneToAttacksBox.Checked = SelectedSprite.Impervious;
			AllowWithBossesBox.Checked = SelectedSprite.AllowWithBoss;
			PowderImmuneBox.Checked = SelectedSprite.ImperviousToPowder;
			BeeBox.Checked = SelectedSprite.BeeTarget;
			IgnoreCollisionBox.Checked = SelectedSprite.IgnoreRecoilCollision;
			HarmlessBox.Checked = SelectedSprite.Harmless;
			ActiveOffscreenBox.Checked = SelectedSprite.ActiveOffScreen;
			NoPermaDeathBox.Checked = SelectedSprite.NoPermaDeath;
			DieOffScreenBox.Checked = SelectedSprite.DieOffScreen;
			ImmuneToSwordBox.Checked = SelectedSprite.ImperviousToSword;

			HealthField.HexValue = SelectedSprite.Health;
			PaletteField.HexValue = SelectedSprite.Palette;
			PrizePackField.HexValue = SelectedSprite.PrizePack;
			DamageClassField.HexValue = SelectedSprite.BumpClass;

			UpdatingFromPicker = false;
		}

		// Just add everything who cares
		private void OnSpritePropertyChange(object sender, EventArgs e)
		{
			if (UpdatingFromPicker) return;

			SelectedSprite.UseBossSFX = DamageSFXBox.Checked;
			SelectedSprite.IgnoreMovingFloors = IgnoreConveyorBox.Checked;
			SelectedSprite.PersistOnOverworld = OverworldPersistBox.Checked;
			SelectedSprite.IgnoreKillRoom = IgnoreForKillBox.Checked;
			SelectedSprite.DrawShadow = HasShadowBox.Checked;
			SelectedSprite.Impervious = ImmuneToAttacksBox.Checked;
			SelectedSprite.AllowWithBoss = AllowWithBossesBox.Checked;
			SelectedSprite.ImperviousToPowder = PowderImmuneBox.Checked;
			SelectedSprite.BeeTarget = BeeBox.Checked;
			SelectedSprite.IgnoreRecoilCollision = IgnoreCollisionBox.Checked;
			SelectedSprite.Harmless = HarmlessBox.Checked;
			SelectedSprite.ActiveOffScreen = ActiveOffscreenBox.Checked;
			SelectedSprite.NoPermaDeath = NoPermaDeathBox.Checked;
			SelectedSprite.DieOffScreen = DieOffScreenBox.Checked;
			SelectedSprite.ImperviousToSword = ImmuneToSwordBox.Checked;
		}



		// TODO damage table: 06F42D jp
	}
}
