using System;
using System.Windows.Forms;

namespace ZeldaFullEditor.Gui
{
	public partial class SaveSettings : Form
	{
		private DungeonMain dungeonMain;

		private bool[] saveArr;

		/// <summary>
		///     Initializes a new instance of the <see cref="SaveSettings"/> class.
		/// </summary>
		/// <param name="_dungeonMain"> The dungeon main class. </param>
		public SaveSettings(DungeonMain _dungeonMain)
		{
			this.InitializeComponent();

			this.dungeonMain = _dungeonMain;

			this.LoadSaveSettings();
		}

		/// <summary>
		///     Called when the Apply button is clicked in the save settings window.
		/// </summary>
		/// <param name="sender"> </param>
		/// <param name="e"> </param>
		private void ApplyButtonClick(object sender, EventArgs e)
		{
			this.saveArr[0] = this.checkBox1.Checked;   // save dungeon sprites
			this.saveArr[1] = this.checkBox2.Checked;   // save dungeon pot items
			this.saveArr[2] = this.checkBox3.Checked;   // save dungeon chest items
			this.saveArr[3] = this.checkBox4.Checked;   // save dungeon tile objects
			this.saveArr[4] = this.checkBox5.Checked;   // save dungeon blocks
			this.saveArr[5] = this.checkBox6.Checked;   // save dungeon torches
			this.saveArr[6] = this.checkBox7.Checked;   // save dungeon damage pits
			this.saveArr[7] = this.checkBox8.Checked;   // save dungeon room headers
			this.saveArr[8] = this.checkBox9.Checked;   // save dungeon entrance data
			this.saveArr[9] = this.checkBox10.Checked;  // save overworld sprites
			this.saveArr[10] = this.checkBox11.Checked; // save overworld bush items
			this.saveArr[11] = this.checkBox12.Checked; // save overworld entrance data
			this.saveArr[12] = this.checkBox13.Checked; // save Whirlpool/Flute
			this.saveArr[13] = this.checkBox14.Checked; // save overworld exits
			this.saveArr[14] = this.checkBox15.Checked; // save overworld tiles
			this.saveArr[15] = this.checkBox16.Checked; // save Group Tiles
			this.saveArr[16] = this.checkBox17.Checked; // save overworld map header
			this.saveArr[17] = this.checkBox18.Checked; // save dungeon auto doors
			this.saveArr[18] = this.checkBox19.Checked; // save misc Adv. chests
			this.saveArr[19] = this.checkBox20.Checked; // save misc dungeon properties
			this.saveArr[20] = this.checkBox21.Checked; // load Texts
			this.saveArr[21] = this.checkBox22.Checked; // load Dung. items
			this.saveArr[22] = this.checkBox23.Checked; // load Dung. sprites
			this.saveArr[23] = this.checkBox24.Checked; // misc gfx groups
			this.saveArr[24] = this.checkBox25.Checked; // misc palettes
			this.saveArr[25] = this.checkBox26.Checked; // save misc texts
			this.saveArr[26] = this.checkBox27.Checked; // lond Dung. blocks
			this.saveArr[27] = this.checkBox28.Checked; // lond Dung. torches
			this.saveArr[28] = this.checkBox29.Checked; // save dungeon custom collision
			this.saveArr[29] = this.checkBox30.Checked; // load Over. sprites
			this.saveArr[30] = this.checkBox31.Checked; // load Over. items
			this.saveArr[31] = this.checkBox32.Checked; // save overworld overlays
			this.saveArr[32] = this.checkBox33.Checked; // save overworld music
			this.saveArr[33] = this.checkBox34.Checked; // save misc title screen
			this.saveArr[34] = this.checkBox35.Checked; // save misc mini map
			this.saveArr[35] = this.checkBox36.Checked; // save overworld tile types
			this.saveArr[36] = this.checkBox37.Checked; // save overworld properties
			this.saveArr[37] = this.checkBox38.Checked; // save misc grave stones
			this.saveArr[38] = this.checkBox39.Checked; // save dungeon maps
			this.saveArr[39] = this.checkBox40.Checked; // misc triforce
			this.saveArr[40] = this.checkBox41.Checked; // overworld message IDs
			this.saveArr[41] = this.checkBox42.Checked; // overworld area specific BG color
			this.saveArr[42] = this.checkBox43.Checked; // overworld main palette transition
			this.saveArr[43] = this.checkBox44.Checked; // overworld Ani. GFX transition
			this.saveArr[44] = this.checkBox45.Checked; // overworld subscreen overlay transition
			this.saveArr[45] = this.checkBox46.Checked; // sprite damage taken
			this.saveArr[46] = this.checkBox47.Checked; // sprite properties taken
			this.dungeonMain.saveSettingsArr = this.saveArr;

			this.Close();
		}

		/// <summary>
		///     Called when the cancel button is clicked in the.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CancelButtonClick(object sender, EventArgs e)
		{
			this.Close();
		}

		public void LoadSaveSettings()
		{
			this.saveArr = this.dungeonMain.saveSettingsArr;

			this.checkBox1.Checked = this.saveArr[0];   // save dungeon sprites
			this.checkBox2.Checked = this.saveArr[1];   // save dungeon pot items
			this.checkBox3.Checked = this.saveArr[2];   // save dungeon chest items
			this.checkBox4.Checked = this.saveArr[3];   // save dungeon tile objects
			this.checkBox5.Checked = this.saveArr[4];   // save dungeon blocks
			this.checkBox6.Checked = this.saveArr[5];   // save dungeon torches
			this.checkBox7.Checked = this.saveArr[6];   // save dungeon damage pits
			this.checkBox8.Checked = this.saveArr[7];   // save dungeon room headers
			this.checkBox9.Checked = this.saveArr[8];   // save dungeon entrance data
			this.checkBox10.Checked = this.saveArr[9];  // save overworld sprites
			this.checkBox11.Checked = this.saveArr[10]; // save overworld bush items
			this.checkBox12.Checked = this.saveArr[11]; // save overworld entrance data
			this.checkBox13.Checked = this.saveArr[12]; // save Whirlpool/Flute
			this.checkBox14.Checked = this.saveArr[13]; // save overworld exits
			this.checkBox15.Checked = this.saveArr[14]; // save overworld tiles
			this.checkBox16.Checked = this.saveArr[15]; // save Group Tiles
			this.checkBox17.Checked = this.saveArr[16]; // save overworld map header
			this.checkBox18.Checked = this.saveArr[17]; // save dungeon auto doors
			this.checkBox19.Checked = this.saveArr[18]; // save misc Adv. chests
			this.checkBox20.Checked = this.saveArr[19]; // save misc dungeon properties
			this.checkBox21.Checked = this.saveArr[20]; // load Texts
			this.checkBox22.Checked = this.saveArr[21]; // load Dung. items
			this.checkBox23.Checked = this.saveArr[22]; // load Dung. sprites
			this.checkBox24.Checked = this.saveArr[23]; // misc gfx groups
			this.checkBox25.Checked = this.saveArr[24]; // misc palettes
			this.checkBox26.Checked = this.saveArr[25]; // save misc texts
			this.checkBox27.Checked = this.saveArr[26]; // load Dung. blocks
			this.checkBox28.Checked = this.saveArr[27]; // load Dung. torches
			this.checkBox29.Checked = this.saveArr[28]; // save dungeon custom collision
			this.checkBox30.Checked = this.saveArr[29]; // load Over. sprites
			this.checkBox31.Checked = this.saveArr[30]; // load Over. items
			this.checkBox32.Checked = this.saveArr[31]; // save overworld overlays
			this.checkBox33.Checked = this.saveArr[32]; // save overworld music
			this.checkBox34.Checked = this.saveArr[33]; // save misc title screen
			this.checkBox35.Checked = this.saveArr[34]; // save misc mini map
			this.checkBox36.Checked = this.saveArr[35]; // save overworld tile types
			this.checkBox37.Checked = this.saveArr[36]; // save overworld properties
			this.checkBox38.Checked = this.saveArr[37]; // save misc grave stones
			this.checkBox39.Checked = this.saveArr[38]; // save dungeon maps
			this.checkBox40.Checked = this.saveArr[39]; // save misc triforce
			this.checkBox41.Checked = this.saveArr[40]; // overworld message IDs
			this.checkBox42.Checked = this.saveArr[41]; // overworld area specific BG color
			this.checkBox43.Checked = this.saveArr[42]; // overworld main palette transition
			this.checkBox44.Checked = this.saveArr[43]; // overworld Ani. GFX transition
			this.checkBox45.Checked = this.saveArr[44]; // overworld subscreen overlay transition
			this.checkBox46.Checked = this.saveArr[45]; // sprite damage taken
			this.checkBox47.Checked = this.saveArr[46]; // sprite properties
		}

		private void SelectAllButtonClick(object sender, EventArgs e)
		{
			this.SetEveryBox(true);
		}

		private void DeselectAllButtonClick(object sender, EventArgs e)
		{
			this.SetEveryBox(false);
		}

		private void SetEveryBox(bool v)
		{
			this.checkBox1.Checked = v;  // save dungeon sprites
			this.checkBox2.Checked = v;  // save dungeon pot items
			this.checkBox3.Checked = v;  // save dungeon chest items
			this.checkBox4.Checked = v;  // save dungeon tile objects
			this.checkBox5.Checked = v;  // save dungeon blocks
			this.checkBox6.Checked = v;  // save dungeon torches
			this.checkBox7.Checked = v;  // save dungeon damage pits
			this.checkBox8.Checked = v;  // save dungeon room headers
			this.checkBox9.Checked = v;  // save dungeon entrance data
			this.checkBox10.Checked = v; // save overworld sprites
			this.checkBox11.Checked = v; // save overworld bush items
			this.checkBox12.Checked = v; // save overworld entrance data
			this.checkBox13.Checked = v; // save Whirlpool/Flute
			this.checkBox14.Checked = v; // save overworld exits
			this.checkBox15.Checked = v; // save overworld tiles
			this.checkBox16.Checked = v; // save Group Tiles
			this.checkBox17.Checked = v; // save overworld map header
			this.checkBox18.Checked = v; // save dungeon auto doors
			this.checkBox19.Checked = v; // save misc Adv. chests
			this.checkBox20.Checked = v; // save misc dungeon properties
			this.checkBox21.Checked = v; // load Texts
			this.checkBox22.Checked = v; // load Dung. items
			this.checkBox23.Checked = v; // load Dung. sprites
			this.checkBox24.Checked = v; // misc gfx groups
			this.checkBox25.Checked = v; // misc palettes
			this.checkBox26.Checked = v; // save misc texts
			this.checkBox27.Checked = v; // load Dung. blocks
			this.checkBox28.Checked = v; // load Dung. torches
			this.checkBox29.Checked = v; // save dungeon custom collision
			this.checkBox30.Checked = v; // load Over. sprites
			this.checkBox31.Checked = v; // load Over. items
			this.checkBox32.Checked = v; // save overworld overlays
			this.checkBox33.Checked = v; // save overworld music
			this.checkBox34.Checked = v; // save misc title screen
			this.checkBox35.Checked = v; // save misc mini map
			this.checkBox36.Checked = v; // save overworld tile types
			this.checkBox37.Checked = v; // save overworld properties
			this.checkBox38.Checked = v; // save misc grave stones
			this.checkBox39.Checked = v; // save dungeon maps
			this.checkBox40.Checked = v; // save misc triforce
			this.checkBox41.Checked = v; // overworld message IDs
			this.checkBox42.Checked = v; // overworld area specific BG color
			this.checkBox43.Checked = v; // overworld main palette transition
			this.checkBox44.Checked = v; // overworld Ani. GFX transition
			this.checkBox45.Checked = v; // overworld subscreen overlay transition
			this.checkBox46.Checked = v; // Sprite Damages taken
			this.checkBox47.Checked = v; // Sprite properties
		}

		private void checkBox35_CheckedChanged(object sender, EventArgs e)
		{

		}
	}
}
