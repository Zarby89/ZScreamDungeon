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

        bool fromUser = false;

        private void SpriteEditor_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Sprites_Names.name.Length; i++)
            {
                spriteListbox.Items.Add(Sprites_Names.name[i]);
            }
        }
        private void spriteListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            fromUser = false;

            SpriteProperty selectedProperty = DungeonsData.SpriteProperties[spriteListbox.SelectedIndex];

            oamslotHexbox.HexValue = selectedProperty.OamAllocation;
            damagetypeHexbox.HexValue = selectedProperty.Bumpdamageclass;
            hitboxHexbox.HexValue = selectedProperty.Hitbox;
            inthitHexbox.HexValue = selectedProperty.Tilehitbox;
            paletteHexbox.HexValue = selectedProperty.Palette;
            prizepackHexbox.HexValue = selectedProperty.Prizepack;
            healthHexbox.HexValue = selectedProperty.Health;



            harmlessCheckbox.Checked = selectedProperty.Harmless;
            smallshadowCheckbox.Checked = selectedProperty.Smallshadow;
            invulnerableCheckbox.Checked = selectedProperty.Invulnerable;
            customdeathanimationCheckbox.Checked = selectedProperty.Customdeathanimation;
            allowedbossfightCheckbox.Checked = selectedProperty.Allowedbossfight;
            immunepowderCheckbox.Checked = selectedProperty.Immunepowder;
            beetargetCheckbox.Checked = selectedProperty.Beetarget;
            recoilwithoutcollisionCheckbox.Checked = selectedProperty.Recoilwithoutcollision;
            invertpitbehaviorCheckbox.Checked = selectedProperty.Invertpitbehavior;
            dielikeabossCheckbox.Checked = selectedProperty.Dielikeaboss;
            overrideslashimmunityCheckbox.Checked = selectedProperty.Overrideslashimminuty;
            deflectarrowsCheckbox.Checked = selectedProperty.Deflectarrows;
            persistoffscreenowCheckbox.Checked = selectedProperty.Persistoffscreenow;
            ignoredbykillroomsCheckbox.Checked = selectedProperty.Ignoredbykillrooms;
            singlelayercollisionCheckbox.Checked = selectedProperty.Singlelayercollision;
            graphicspageCheckbox.Checked = selectedProperty.Graphicspage;
            drawshadowCheckbox.Checked = selectedProperty.Drawshadow;
            immunearrowrumbleableCheckbox.Checked = selectedProperty.Immunetoarrowrumbleable;
            immuneswordhammerCheckbox.Checked = selectedProperty.Immunetoswordhammer;
            projectilelikecollisionCheckbox.Checked = selectedProperty.Projectilelikecollision;
            dieoffscreenCheckbox.Checked = selectedProperty.Dieoffscreen;
            activeoffscreenCheckbox.Checked = selectedProperty.Activeoffscreen;
            bossdamagesoundCheckbox.Checked = selectedProperty.Bossdamagesound;
            blockedbyshieldCheckbox.Checked = selectedProperty.Blockedbyshield;
            checkforwaterCheckbox.Checked = selectedProperty.Checkforwater;
            nopermadeathindungeonsCheckbox.Checked = selectedProperty.Nopermadeathindungeons;

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
            if (fromUser)
            {
                SpriteProperty selectedProperty = DungeonsData.SpriteProperties[spriteListbox.SelectedIndex];

                selectedProperty.Harmless = harmlessCheckbox.Checked;
                selectedProperty.Smallshadow = smallshadowCheckbox.Checked;
                selectedProperty.Invulnerable = invulnerableCheckbox.Checked;
                selectedProperty.Customdeathanimation = customdeathanimationCheckbox.Checked;
                selectedProperty.Allowedbossfight = allowedbossfightCheckbox.Checked;
                selectedProperty.Immunepowder = immunepowderCheckbox.Checked;
                selectedProperty.Beetarget = beetargetCheckbox.Checked;
                selectedProperty.Recoilwithoutcollision = recoilwithoutcollisionCheckbox.Checked;
                selectedProperty.Invertpitbehavior = invertpitbehaviorCheckbox.Checked;
                selectedProperty.Dielikeaboss = dielikeabossCheckbox.Checked;
                selectedProperty.Overrideslashimminuty = overrideslashimmunityCheckbox.Checked;
                selectedProperty.Deflectarrows = deflectarrowsCheckbox.Checked;
                selectedProperty.Persistoffscreenow = persistoffscreenowCheckbox.Checked;
                selectedProperty.Ignoredbykillrooms = ignoredbykillroomsCheckbox.Checked;
                selectedProperty.Singlelayercollision = singlelayercollisionCheckbox.Checked;
                selectedProperty.Graphicspage = graphicspageCheckbox.Checked;
                selectedProperty.Drawshadow = drawshadowCheckbox.Checked;
                selectedProperty.Immunetoarrowrumbleable = immunearrowrumbleableCheckbox.Checked;
                selectedProperty.Immunetoswordhammer = immuneswordhammerCheckbox.Checked;
                selectedProperty.Projectilelikecollision = projectilelikecollisionCheckbox.Checked;
                selectedProperty.Dieoffscreen = dieoffscreenCheckbox.Checked;
                selectedProperty.Activeoffscreen = activeoffscreenCheckbox.Checked;
                selectedProperty.Bossdamagesound = bossdamagesoundCheckbox.Checked;
                selectedProperty.Blockedbyshield = blockedbyshieldCheckbox.Checked;
                selectedProperty.Checkforwater = checkforwaterCheckbox.Checked;
                selectedProperty.Nopermadeathindungeons = nopermadeathindungeonsCheckbox.Checked;


                selectedProperty.OamAllocation = (byte)oamslotHexbox.HexValue;
                selectedProperty.Bumpdamageclass = (byte)damagetypeHexbox.HexValue;
                selectedProperty.Hitbox = (byte)hitboxHexbox.HexValue;
                selectedProperty.Tilehitbox = (byte)inthitHexbox.HexValue;
                selectedProperty.Palette = (byte)paletteHexbox.HexValue;
                selectedProperty.Prizepack = (byte)prizepackHexbox.HexValue;
                selectedProperty.Health = (byte)healthHexbox.HexValue;
            }
        }

        private void sprsaveButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < DungeonsData.SpriteProperties.Count; i++)
            {
                DungeonsData.SpriteProperties[i].SaveToROM((byte)i);
            }
        }
    }
}
