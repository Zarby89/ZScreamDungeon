using System;
using System.Drawing;
using System.Windows.Forms;
using ZeldaFullEditor.Data;
using ZeldaFullEditor.Properties;

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
            immunearrowrumbleableCheckbox.Checked = selectedProperty.Bonkitem;
            immuneswordhammerCheckbox.Checked = selectedProperty.Immunetoswordhammer;
            projectilelikecollisionCheckbox.Checked = selectedProperty.Projectilelikecollision;
            dieoffscreenCheckbox.Checked = selectedProperty.Dieoffscreen;
            activeoffscreenCheckbox.Checked = selectedProperty.Activeoffscreen;
            bossdamagesoundCheckbox.Checked = selectedProperty.Altdamagesound;
            blockedbyshieldCheckbox.Checked = selectedProperty.Blockedbyshield;
            checkforwaterCheckbox.Checked = selectedProperty.Checkforwater;
            nopermadeathindungeonsCheckbox.Checked = selectedProperty.Nopermadeathindungeons;


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
            damage0aHexbox.HexValue = selectedProperty.DamagesTaken[10];
            damage0bHexbox.HexValue = selectedProperty.DamagesTaken[11];
            damage0cHexbox.HexValue = selectedProperty.DamagesTaken[12];
            damage0dHexbox.HexValue = selectedProperty.DamagesTaken[13];
            damage0eHexbox.HexValue = selectedProperty.DamagesTaken[14];
            damage0fHexbox.HexValue = selectedProperty.DamagesTaken[15];
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
                selectedProperty.Bonkitem = immunearrowrumbleableCheckbox.Checked;
                selectedProperty.Immunetoswordhammer = immuneswordhammerCheckbox.Checked;
                selectedProperty.Projectilelikecollision = projectilelikecollisionCheckbox.Checked;
                selectedProperty.Dieoffscreen = dieoffscreenCheckbox.Checked;
                selectedProperty.Activeoffscreen = activeoffscreenCheckbox.Checked;
                selectedProperty.Altdamagesound = bossdamagesoundCheckbox.Checked;
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

                selectedProperty.DamagesTaken[0] = (byte)damage00Hexbox.HexValue;
                selectedProperty.DamagesTaken[1] = (byte)damage01Hexbox.HexValue;
                selectedProperty.DamagesTaken[2] = (byte)damage02Hexbox.HexValue;
                selectedProperty.DamagesTaken[3] = (byte)damage03Hexbox.HexValue;
                selectedProperty.DamagesTaken[4] = (byte)damage04Hexbox.HexValue;
                selectedProperty.DamagesTaken[5] = (byte)damage05Hexbox.HexValue;
                selectedProperty.DamagesTaken[6] = (byte)damage06Hexbox.HexValue;
                selectedProperty.DamagesTaken[7] = (byte)damage07Hexbox.HexValue;
                selectedProperty.DamagesTaken[8] = (byte)damage08Hexbox.HexValue;
                selectedProperty.DamagesTaken[9] = (byte)damage09Hexbox.HexValue;
                selectedProperty.DamagesTaken[10] = (byte)damage0aHexbox.HexValue;
                selectedProperty.DamagesTaken[11] = (byte)damage0bHexbox.HexValue;
                selectedProperty.DamagesTaken[12] = (byte)damage0cHexbox.HexValue;
                selectedProperty.DamagesTaken[13] = (byte)damage0dHexbox.HexValue;
                selectedProperty.DamagesTaken[14] = (byte)damage0eHexbox.HexValue;
                selectedProperty.DamagesTaken[15] = (byte)damage0fHexbox.HexValue;


            }
        }

        private void sprsaveButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < DungeonsData.SpriteProperties.Count; i++)
            {
                DungeonsData.SpriteProperties[i].SaveToROM((byte)i);
            }




        }

        private void damageClassControl1_Load(object sender, EventArgs e)
        {

        }

        private void damageClassControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
