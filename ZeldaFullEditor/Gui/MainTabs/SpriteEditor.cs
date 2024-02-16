using System;
using System.Windows.Forms;
using ZeldaFullEditor.Data;

namespace ZeldaFullEditor.Gui.MainTabs
{
	public partial class SpriteEditor : UserControl
	{
		public SpriteEditor()
		{
			InitializeComponent();
		}

		private bool fromUser = false;

		private void SpriteEditor_Load(object sender, EventArgs e)
		{
			spriteListbox.Items.AddRange(Sprites_Names.name);
		}

		private void spriteListbox_SelectedIndexChanged(object sender, EventArgs e)
		{
			fromUser = false;

			groupBox1.Enabled = spriteListbox.SelectedIndex < 0xF3;
			if (!groupBox1.Enabled)
			{
				groupBox1.Text = "Selected sprite's properties";

				fromUser = true;
				return;
			}

			groupBox1.Text = "Selected sprite's properties: " + spriteListbox.SelectedItem.ToString();

			SpriteProperty selectedProperty = DungeonsData.SpriteProperties[spriteListbox.SelectedIndex];

			oamslotHexbox.HexValue = selectedProperty.OAMAllocation;
			damagetypeHexbox.HexValue = selectedProperty.BumpDamageClass;
			hitboxHexbox.HexValue = selectedProperty.Hitbox;
			inthitHexbox.HexValue = selectedProperty.TileHitBox;
			paletteHexbox.HexValue = selectedProperty.Palette;
			prizepackHexbox.HexValue = selectedProperty.PrizePack;
			healthHexbox.HexValue = selectedProperty.Health;

			harmlessCheckbox.Checked = selectedProperty.Harmless;
			smallshadowCheckbox.Checked = selectedProperty.SmallShadow;
			invulnerableCheckbox.Checked = selectedProperty.Invulnerable;
			customdeathanimationCheckbox.Checked = selectedProperty.CustomDeathAnimation;
			allowedbossfightCheckbox.Checked = selectedProperty.AllowedBossFight;
			immunepowderCheckbox.Checked = selectedProperty.ImmunePowder;
			beetargetCheckbox.Checked = selectedProperty.BeeTarget;
			recoilwithoutcollisionCheckbox.Checked = selectedProperty.RecoilWithoutCollision;
			invertpitbehaviorCheckbox.Checked = selectedProperty.Invertpitbehavior;
			dielikeabossCheckbox.Checked = selectedProperty.DieLikeABoss;
			overrideslashimmunityCheckbox.Checked = selectedProperty.ZeroDamageOverride;
			deflectarrowsCheckbox.Checked = selectedProperty.Deflectarrows;
			persistoffscreenowCheckbox.Checked = selectedProperty.Persistoffscreenow;
			ignoredbykillroomsCheckbox.Checked = selectedProperty.Ignoredbykillrooms;
			singlelayercollisionCheckbox.Checked = selectedProperty.Singlelayercollision;
			graphicspageCheckbox.Checked = selectedProperty.GraphicsPage;
			drawshadowCheckbox.Checked = selectedProperty.DrawShadow;
			immunearrowrumbleableCheckbox.Checked = selectedProperty.Bonkitem;
			immuneswordhammerCheckbox.Checked = selectedProperty.ImmuneToSwordHammer;
			projectilelikecollisionCheckbox.Checked = selectedProperty.ProjectileLikeCollision;
			dieoffscreenCheckbox.Checked = selectedProperty.DieOffScreen;
			activeoffscreenCheckbox.Checked = selectedProperty.ActiveOffScreen;
			bossdamagesoundCheckbox.Checked = selectedProperty.AltDamageSound;
			blockedbyshieldCheckbox.Checked = selectedProperty.BlockedByShield;
			checkforwaterCheckbox.Checked = selectedProperty.CheckForWater;
			nopermadeathindungeonsCheckbox.Checked = selectedProperty.NoPermaDeathInDungeons;

			DamageSubclassGroupBox.Enabled = spriteListbox.SelectedIndex < 0xD8;
			if (!DamageSubclassGroupBox.Enabled)
			{
				DamageSubclassGroupBox.Text = "Selected sprite's damage subclasses";

				fromUser = true;
				return;
			}

			DamageSubclassGroupBox.Text = "Selected sprite's damage subclasses: " + spriteListbox.SelectedItem.ToString();

			damage00Hexbox.HexValue = selectedProperty.DamagesTaken[0];
			damage01Hexbox.HexValue = selectedProperty.DamagesTaken[1];
			damage02Hexbox.HexValue = selectedProperty.DamagesTaken[2];
			damage03Hexbox.HexValue = selectedProperty.DamagesTaken[3];
			damage04Hexbox.HexValue = selectedProperty.DamagesTaken[4];
			damage05Hexbox.HexValue = selectedProperty.DamagesTaken[5];
			damage06Hexbox.HexValue = selectedProperty.DamagesTaken[6];
			damage07Hexbox.HexValue = selectedProperty.DamagesTaken[7];
			damage08Hexbox.HexValue = selectedProperty.DamagesTaken[8];
			damage09Hexbox.HexValue = selectedProperty.DamagesTaken[9];
			damage0AHexBox.HexValue = selectedProperty.DamagesTaken[10];
			damage0BHexBox.HexValue = selectedProperty.DamagesTaken[11];
			damage0CHexBox.HexValue = selectedProperty.DamagesTaken[12];
			damage0DHexBox.HexValue = selectedProperty.DamagesTaken[13];
			damage0EHexBox.HexValue = selectedProperty.DamagesTaken[14];
			damage0FHexBox.HexValue = selectedProperty.DamagesTaken[15];

			fromUser = true;
		}

		private void properties_CheckedChanged(object sender, EventArgs e)
		{
			updateAllProperties();
		}

		private void properties_TextChanged(object sender, EventArgs e)
		{
			updateAllProperties();
		}

		private void updateAllProperties()
		{
			if (!fromUser)
			{
				return;
			}

			var selectedProperty = DungeonsData.SpriteProperties[spriteListbox.SelectedIndex];

			selectedProperty.Harmless = harmlessCheckbox.Checked;
			selectedProperty.SmallShadow = smallshadowCheckbox.Checked;
			selectedProperty.Invulnerable = invulnerableCheckbox.Checked;
			selectedProperty.CustomDeathAnimation = customdeathanimationCheckbox.Checked;
			selectedProperty.AllowedBossFight = allowedbossfightCheckbox.Checked;
			selectedProperty.ImmunePowder = immunepowderCheckbox.Checked;
			selectedProperty.BeeTarget = beetargetCheckbox.Checked;
			selectedProperty.RecoilWithoutCollision = recoilwithoutcollisionCheckbox.Checked;
			selectedProperty.Invertpitbehavior = invertpitbehaviorCheckbox.Checked;
			selectedProperty.DieLikeABoss = dielikeabossCheckbox.Checked;
			selectedProperty.ZeroDamageOverride = overrideslashimmunityCheckbox.Checked;
			selectedProperty.Deflectarrows = deflectarrowsCheckbox.Checked;
			selectedProperty.Persistoffscreenow = persistoffscreenowCheckbox.Checked;
			selectedProperty.Ignoredbykillrooms = ignoredbykillroomsCheckbox.Checked;
			selectedProperty.Singlelayercollision = singlelayercollisionCheckbox.Checked;
			selectedProperty.GraphicsPage = graphicspageCheckbox.Checked;
			selectedProperty.DrawShadow = drawshadowCheckbox.Checked;
			selectedProperty.Bonkitem = immunearrowrumbleableCheckbox.Checked;
			selectedProperty.ImmuneToSwordHammer = immuneswordhammerCheckbox.Checked;
			selectedProperty.ProjectileLikeCollision = projectilelikecollisionCheckbox.Checked;
			selectedProperty.DieOffScreen = dieoffscreenCheckbox.Checked;
			selectedProperty.ActiveOffScreen = activeoffscreenCheckbox.Checked;
			selectedProperty.AltDamageSound = bossdamagesoundCheckbox.Checked;
			selectedProperty.BlockedByShield = blockedbyshieldCheckbox.Checked;
			selectedProperty.CheckForWater = checkforwaterCheckbox.Checked;
			selectedProperty.NoPermaDeathInDungeons = nopermadeathindungeonsCheckbox.Checked;

			selectedProperty.OAMAllocation = (byte) oamslotHexbox.HexValue;
			selectedProperty.BumpDamageClass = (byte) damagetypeHexbox.HexValue;
			selectedProperty.Hitbox = (byte) hitboxHexbox.HexValue;
			selectedProperty.TileHitBox = (byte) inthitHexbox.HexValue;
			selectedProperty.Palette = (byte) paletteHexbox.HexValue;
			selectedProperty.PrizePack = (byte) prizepackHexbox.HexValue;
			selectedProperty.Health = (byte) healthHexbox.HexValue;

			selectedProperty.DamagesTaken[0] = (byte) damage00Hexbox.HexValue;
			selectedProperty.DamagesTaken[1] = (byte) damage01Hexbox.HexValue;
			selectedProperty.DamagesTaken[2] = (byte) damage02Hexbox.HexValue;
			selectedProperty.DamagesTaken[3] = (byte) damage03Hexbox.HexValue;
			selectedProperty.DamagesTaken[4] = (byte) damage04Hexbox.HexValue;
			selectedProperty.DamagesTaken[5] = (byte) damage05Hexbox.HexValue;
			selectedProperty.DamagesTaken[6] = (byte) damage06Hexbox.HexValue;
			selectedProperty.DamagesTaken[7] = (byte) damage07Hexbox.HexValue;
			selectedProperty.DamagesTaken[8] = (byte) damage08Hexbox.HexValue;
			selectedProperty.DamagesTaken[9] = (byte) damage09Hexbox.HexValue;
			selectedProperty.DamagesTaken[10] = (byte) damage0AHexBox.HexValue;
			selectedProperty.DamagesTaken[11] = (byte) damage0BHexBox.HexValue;
			selectedProperty.DamagesTaken[12] = (byte) damage0CHexBox.HexValue;
			selectedProperty.DamagesTaken[13] = (byte) damage0DHexBox.HexValue;
			selectedProperty.DamagesTaken[14] = (byte) damage0EHexBox.HexValue;
			selectedProperty.DamagesTaken[15] = (byte) damage0FHexBox.HexValue;
		}
	}
}
