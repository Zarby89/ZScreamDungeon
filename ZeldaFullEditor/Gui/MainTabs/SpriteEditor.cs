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
        }

        bool fromUser = false;

        private void SpriteEditor_Load(object sender, EventArgs e)
        {
            for(int i = 0;i <Sprites_Names.name.Length;i++)
            {
                spriteListbox.Items.Add(Sprites_Names.name[i]);
            }
        }
        private void spriteListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            fromUser = false;

            SpriteProperty selectedProperty = DungeonsData.SpriteProperties[spriteListbox.SelectedIndex];
            oamslotHexbox.HexValue = selectedProperty.oamSlot;
            healthHexbox.HexValue = selectedProperty.health;
            hitboxHexbox.HexValue = selectedProperty.hitbox;
            inthitHexbox.HexValue = selectedProperty.inthitbox;
            paletteHexbox.HexValue = selectedProperty.palette;
            damagetypeHexbox.HexValue = selectedProperty.damagetype;
            prizepackHexbox.HexValue = selectedProperty.prizepack;

            drawshadowCheckbox.Checked = selectedProperty.drawShadow;
            nodeathanimationCheckbox.Checked = selectedProperty.deathAnim;
            dieslikeabossCheckbox.Checked = selectedProperty.boss;
            isshieldblockableCheckbox.Checked = selectedProperty.blockable;
            statisCheckbox.Checked = selectedProperty.statis;
            persistCheckbox.Checked = selectedProperty.persist;
            fallinholesCheckbox.Checked = selectedProperty.fall;
            alternatedamagesoundCheckbox.Checked = selectedProperty.alternatesound;
            ignorecollisionCheckbox.Checked = selectedProperty.ignorecollision;
            tileinteractionCheckbox.Checked = selectedProperty.tileinteraction;
            imperswordhammerCheckbox.Checked = selectedProperty.imperviousswordhammer;
            deflectprojectileCheckbox.Checked = selectedProperty.deflectprojectile;
            impervarrowsCheckbox.Checked = selectedProperty.imperviousarrow;
            collidelessCheckbox.Checked = selectedProperty.collideless;
            harmlessCheckbox.Checked = selectedProperty.harmless;
            invulnerableCheckbox.Checked = selectedProperty.invulnerable;
            childcoordinateCheckbox.Checked = selectedProperty.adjcoord;
            watersprCheckbox.Checked = selectedProperty.waterspr;
            isstatueCheckbox.Checked = selectedProperty.statue;
            highvelocityCheckbox.Checked = selectedProperty.highspeed;

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
                selectedProperty.oamSlot = (byte)oamslotHexbox.HexValue;
                selectedProperty.health = (byte)healthHexbox.HexValue;
                selectedProperty.hitbox = (byte)hitboxHexbox.HexValue;
                selectedProperty.inthitbox = (byte)inthitHexbox.HexValue;
                selectedProperty.palette = (byte)paletteHexbox.HexValue;
                selectedProperty.damagetype = (byte)damagetypeHexbox.HexValue;
                selectedProperty.prizepack = (byte)prizepackHexbox.HexValue;

                selectedProperty.drawShadow = drawshadowCheckbox.Checked;
                selectedProperty.deathAnim = nodeathanimationCheckbox.Checked;
                selectedProperty.boss = dieslikeabossCheckbox.Checked;
                selectedProperty.blockable = isshieldblockableCheckbox.Checked;
                selectedProperty.statis = statisCheckbox.Checked;
                selectedProperty.persist = persistCheckbox.Checked;
                selectedProperty.fall = fallinholesCheckbox.Checked;
                selectedProperty.alternatesound = alternatedamagesoundCheckbox.Checked;
                selectedProperty.ignorecollision = ignorecollisionCheckbox.Checked;
                selectedProperty.tileinteraction = tileinteractionCheckbox.Checked;
                selectedProperty.imperviousswordhammer = imperswordhammerCheckbox.Checked;
                selectedProperty.deflectprojectile = deflectprojectileCheckbox.Checked;
                selectedProperty.imperviousarrow = impervarrowsCheckbox.Checked;
                selectedProperty.collideless = collidelessCheckbox.Checked;
                selectedProperty.harmless = harmlessCheckbox.Checked;
                selectedProperty.invulnerable = invulnerableCheckbox.Checked;
                selectedProperty.adjcoord = childcoordinateCheckbox.Checked;
                selectedProperty.waterspr = watersprCheckbox.Checked;
                selectedProperty.statue = isstatueCheckbox.Checked;
                selectedProperty.highspeed = highvelocityCheckbox.Checked;
            }
        }
    }
}
