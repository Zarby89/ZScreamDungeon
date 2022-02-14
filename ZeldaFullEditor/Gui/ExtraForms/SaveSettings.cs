using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeldaFullEditor.Gui
{
    public partial class SaveSettings : Form
    {
        private DungeonMain dungeonMain;

        bool[] saveArr;

        public SaveSettings(DungeonMain _dungeonMain)
        {
            InitializeComponent();

            this.dungeonMain = _dungeonMain;

            LoadSaveSettings();
        }

        // @author: Jared_Brian_
        /// <summary>
        /// Called when the Apply button is clicked in the save settings window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            saveArr[0] = checkBox1.Checked;   //save dungeon sprites
            saveArr[1] = checkBox2.Checked;   //save dungeon pot items
            saveArr[2] = checkBox3.Checked;   //save dungeon chest items
            saveArr[3] = checkBox4.Checked;   //save dungeon tile objects
            saveArr[4] = checkBox5.Checked;   //save dungeon blocks
            saveArr[5] = checkBox6.Checked;   //save dungeon torches
            saveArr[6] = checkBox7.Checked;   //save dungeon damage pits
            saveArr[7] = checkBox8.Checked;   //save dungeon room headers
            saveArr[8] = checkBox9.Checked;   //save dungeon entrance data
            saveArr[9] = checkBox10.Checked;  //save overworld sprites
            saveArr[10] = checkBox11.Checked; //save overworld bush items
            saveArr[11] = checkBox12.Checked; //save overworld entrance data
            saveArr[12] = checkBox13.Checked; //save Whirlpool/Flute
            saveArr[13] = checkBox14.Checked; //save overworld exits
            saveArr[14] = checkBox15.Checked; //save overworld tiles
            saveArr[15] = checkBox16.Checked; //save Group Tiles
            saveArr[16] = checkBox17.Checked; //save overworld map header
            saveArr[17] = checkBox18.Checked; //save dungeon auto doors
            saveArr[18] = checkBox19.Checked; //save misc Adv. chests
            saveArr[19] = checkBox20.Checked; //save misc dungeon properties
            saveArr[20] = checkBox21.Checked; //load Texts
            saveArr[21] = checkBox22.Checked; //load Dung. items
            saveArr[22] = checkBox23.Checked; //load Dung. sprites
            saveArr[23] = checkBox24.Checked; //misc gfx groups
            saveArr[24] = checkBox25.Checked; //misc palettes
            saveArr[25] = checkBox26.Checked; //save misc texts
            saveArr[26] = checkBox27.Checked; //lond Dung. blocks
            saveArr[27] = checkBox28.Checked; //lond Dung. torches
            saveArr[28] = checkBox29.Checked; //save dungeon custom collision
            saveArr[29] = checkBox30.Checked; //load Over. sprites
            saveArr[30] = checkBox31.Checked; //load Over. items
            saveArr[31] = checkBox32.Checked; //save overworld overlays
            saveArr[32] = checkBox33.Checked; //save overworld music
            saveArr[33] = checkBox34.Checked; //save misc title screen 
            saveArr[34] = checkBox35.Checked; //save misc mini map
            saveArr[35] = checkBox36.Checked; //save overworld tile types
            saveArr[36] = checkBox37.Checked; //save overworld properties
            saveArr[37] = checkBox38.Checked; //save misc grave stones
            saveArr[38] = checkBox39.Checked; //save dungeon maps
            saveArr[39] = checkBox40.Checked; //misc triforce
            saveArr[40] = checkBox41.Checked; //overworld message IDs

            dungeonMain.saveSettingsArr = saveArr;

            this.Close();
        }

        /// <summary>
        /// Called when the cancel button is clicked in the 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LoadSaveSettings()
        {
            saveArr = dungeonMain.saveSettingsArr;

            checkBox1.Checked = saveArr[0];   //save dungeon sprites
            checkBox2.Checked = saveArr[1];   //save dungeon pot items
            checkBox3.Checked = saveArr[2];   //save dungeon chest items
            checkBox4.Checked = saveArr[3];   //save dungeon tile objects
            checkBox5.Checked = saveArr[4];   //save dungeon blocks
            checkBox6.Checked = saveArr[5];   //save dungeon torches
            checkBox7.Checked = saveArr[6];   //save dungeon damage pits
            checkBox8.Checked = saveArr[7];   //save dungeon room headers
            checkBox9.Checked = saveArr[8];   //save dungeon entrance data
            checkBox10.Checked = saveArr[9];  //save overworld sprites
            checkBox11.Checked = saveArr[10]; //save overworld bush items
            checkBox12.Checked = saveArr[11]; //save overworld entrance data
            checkBox13.Checked = saveArr[12]; //save Whirlpool/Flute
            checkBox14.Checked = saveArr[13]; //save overworld exits
            checkBox15.Checked = saveArr[14]; //save overworld tiles
            checkBox16.Checked = saveArr[15]; //save Group Tiles
            checkBox17.Checked = saveArr[16]; //save overworld map header
            checkBox18.Checked = saveArr[17]; //save dungeon auto doors
            checkBox19.Checked = saveArr[18]; //save misc Adv. chests
            checkBox20.Checked = saveArr[19]; //save misc dungeon properties
            checkBox21.Checked = saveArr[20]; //load Texts
            checkBox22.Checked = saveArr[21]; //load Dung. items
            checkBox23.Checked = saveArr[22]; //load Dung. sprites
            checkBox24.Checked = saveArr[23]; //misc gfx groups
            checkBox25.Checked = saveArr[24]; //misc palettes
            checkBox26.Checked = saveArr[25]; //save misc texts
            checkBox27.Checked = saveArr[26]; //load Dung. blocks
            checkBox28.Checked = saveArr[27]; //load Dung. torches
            checkBox29.Checked = saveArr[28]; //save dungeon custom collision
            checkBox30.Checked = saveArr[29]; //load Over. sprites
            checkBox31.Checked = saveArr[30]; //load Over. items
            checkBox32.Checked = saveArr[31]; //save overworld overlays
            checkBox33.Checked = saveArr[32]; //save overworld music
            checkBox34.Checked = saveArr[33]; //save misc title screen 
            checkBox35.Checked = saveArr[34]; //save misc mini map
            checkBox36.Checked = saveArr[35]; //save overworld tile types
            checkBox37.Checked = saveArr[36]; //save overworld properties
            checkBox38.Checked = saveArr[37]; //save misc grave stones
            checkBox39.Checked = saveArr[38]; //save dungeon maps
            checkBox40.Checked = saveArr[39]; //save misc triforce
            checkBox41.Checked = saveArr[40]; //overworld message IDs
        }

        private void button3_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = true;  //save dungeon sprites
            checkBox2.Checked = true;  //save dungeon pot items
            checkBox3.Checked = true;  //save dungeon chest items
            checkBox4.Checked = true;  //save dungeon tile objects
            checkBox5.Checked = true;  //save dungeon blocks
            checkBox6.Checked = true;  //save dungeon torches
            checkBox7.Checked = true;  //save dungeon damage pits
            checkBox8.Checked = true;  //save dungeon room headers
            checkBox9.Checked = true;  //save dungeon entrance data
            checkBox10.Checked = true; //save overworld sprites
            checkBox11.Checked = true; //save overworld bush items
            checkBox12.Checked = true; //save overworld entrance data
            checkBox13.Checked = true; //save Whirlpool/Flute
            checkBox14.Checked = true; //save overworld exits
            checkBox15.Checked = true; //save overworld tiles
            checkBox16.Checked = true; //save Group Tiles
            checkBox17.Checked = true; //save overworld map header
            checkBox18.Checked = true; //save dungeon auto doors
            checkBox19.Checked = true; //save misc Adv. chests
            checkBox20.Checked = true; //save misc dungeon properties
            checkBox21.Checked = true; //load Texts
            checkBox22.Checked = true; //load Dung. items
            checkBox23.Checked = true; //load Dung. sprites
            checkBox24.Checked = true; //misc gfx groups
            checkBox25.Checked = true; //misc palettes
            checkBox26.Checked = true; //save misc texts
            checkBox27.Checked = true; //load Dung. blocks
            checkBox28.Checked = true; //load Dung. torches
            checkBox29.Checked = true; //save dungeon custom collision
            checkBox30.Checked = true; //load Over. sprites
            checkBox31.Checked = true; //load Over. items
            checkBox32.Checked = true; //save overworld overlays
            checkBox33.Checked = true; //save overworld music
            checkBox34.Checked = true; //save misc title screen 
            checkBox35.Checked = true; //save misc mini map
            checkBox36.Checked = true; //save overworld tile types
            checkBox37.Checked = true; //save overworld properties
            checkBox38.Checked = true; //save misc grave stones
            checkBox39.Checked = true; //save dungeon maps
            checkBox40.Checked = true; //save misc triforce
            checkBox41.Checked = true; //overworld message IDs
        }

        private void button4_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;  //save dungeon sprites
            checkBox2.Checked = false;  //save dungeon pot items
            checkBox3.Checked = false;  //save dungeon chest items
            checkBox4.Checked = false;  //save dungeon tile objects
            checkBox5.Checked = false;  //save dungeon blocks
            checkBox6.Checked = false;  //save dungeon torches
            checkBox7.Checked = false;  //save dungeon damage pits
            checkBox8.Checked = false;  //save dungeon room headers
            checkBox9.Checked = false;  //save dungeon entrance data
            checkBox10.Checked = false; //save overworld sprites
            checkBox11.Checked = false; //save overworld bush items
            checkBox12.Checked = false; //save overworld entrance data
            checkBox13.Checked = false; //save Whirlpool/Flute
            checkBox14.Checked = false; //save overworld exits
            checkBox15.Checked = false; //save overworld tiles
            checkBox16.Checked = false; //save Group Tiles
            checkBox17.Checked = false; //save overworld map header
            checkBox18.Checked = false; //save dungeon auto doors
            checkBox19.Checked = false; //save misc Adv. chests
            checkBox20.Checked = false; //save misc dungeon properties
            checkBox21.Checked = false; //load Texts
            checkBox22.Checked = false; //load Dung. items
            checkBox23.Checked = false; //load Dung. sprites
            checkBox24.Checked = false; //misc gfx groups
            checkBox25.Checked = false; //misc palettes
            checkBox26.Checked = false; //save misc texts
            checkBox27.Checked = false; //load Dung. blocks
            checkBox28.Checked = false; //load Dung. torches
            checkBox29.Checked = false; //save dungeon custom collision
            checkBox30.Checked = false; //load Over. sprites
            checkBox31.Checked = false; //load Over. items
            checkBox32.Checked = false; //save overworld overlays
            checkBox33.Checked = false; //save overworld music
            checkBox34.Checked = false; //save misc title screen 
            checkBox35.Checked = false; //save misc mini map
            checkBox36.Checked = false; //save overworld tile types
            checkBox37.Checked = false; //save overworld properties
            checkBox38.Checked = false; //save misc grave stones
            checkBox39.Checked = false; //save dungeon maps
            checkBox40.Checked = false; //save misc triforce
            checkBox41.Checked = false; //overworld message IDs
        }
    }
}
