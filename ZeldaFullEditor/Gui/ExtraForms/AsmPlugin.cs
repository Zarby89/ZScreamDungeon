using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using ZeldaFullEditor.Data;
using System.IO.Compression;
using System.Reflection;

namespace ZeldaFullEditor.Gui.ExtraForms
{
	// TODO: Magic strings everywhere
	public partial class AsmPlugin : Form
    {
        private byte[] bitmask = new byte[8] { 0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80 };
        internal List<AsmPatch> PatchList = new List<AsmPatch>();
        AsmPatch selectedPatch = null;
        public string ProjectPath = "";
        private string clientVersion = "0000";

        public AsmPlugin()
        {
            InitializeComponent();
        }

        private void AsmPlugin_Load(object sender, EventArgs e)
        {
            LoadPatches();
        }

        private void UpdatePatchList()
        {
            patchListbox.Items.Clear(); // clear all items
            patchListbox.Items.AddRange(PatchList.ToArray());
            patchListbox.DisplayMember = "PatchName";
            for (int i = 0; i < patchListbox.Items.Count; i++)
            {
                patchListbox.SetItemChecked(i, (patchListbox.Items[i] as AsmPatch).PatchEnabled);
            }
        }

        private void patchListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            propertyGroupbox.Controls.Clear();
            selectedPatch = patchListbox.SelectedItem as AsmPatch;
            if (selectedPatch == null)
            {
                return;
            }

            patchAuthorLabel.Text = "Patch author(s): " + selectedPatch.PatchAuthor;
            patchDescriptionTextbox.Text = selectedPatch.PatchDescription;


            foreach (KeyValuePair<string, Dictionary<string, string>> keyValue in selectedPatch.PatchDefines)
            {
                int value = 0;
                int min = 0;
                int max = 0xFF;
                bool rangeSetted = false;
                int checkedvalue = 1;
                int uncheckedvalue = 0;
                bool dec = false;
                string name = "";

                if (selectedPatch.PatchDefines[keyValue.Key].ContainsKey("_VALUE"))
                {
                    value = ReadStringInt(selectedPatch.PatchDefines[keyValue.Key]["_VALUE"]);
                }

                if (selectedPatch.PatchDefines[keyValue.Key].ContainsKey("name"))
                {
                    name = selectedPatch.PatchDefines[keyValue.Key]["name"];
                }

                if (selectedPatch.PatchDefines[keyValue.Key].ContainsKey("checkedvalue"))
                {
                    checkedvalue = ReadStringInt(selectedPatch.PatchDefines[keyValue.Key]["checkedvalue"]);
                }

                if (selectedPatch.PatchDefines[keyValue.Key].ContainsKey("uncheckedvalue"))
                {
                    uncheckedvalue = ReadStringInt(selectedPatch.PatchDefines[keyValue.Key]["uncheckedvalue"]);
                }

                if (selectedPatch.PatchDefines[keyValue.Key].ContainsKey("decimal"))
                {
                    Console.WriteLine("Decimal, baby!");
                    dec = true;
                }

                if (selectedPatch.PatchDefines[keyValue.Key].ContainsKey("range"))
                {
                    string[] range = selectedPatch.PatchDefines[keyValue.Key]["range"].Split(',');
                    min = ReadStringInt(range[0]);
                    max = ReadStringInt(range[1]);
                    rangeSetted = true;
                }

                if (selectedPatch.PatchDefines[keyValue.Key].ContainsKey("type"))
                {
                    if (selectedPatch.PatchDefines[keyValue.Key]["type"].Contains("byte"))
                    {
                        if (!rangeSetted)
                        {
                            min = 0;
                            max = 0xFF;
                            rangeSetted = true;
                        }

                        CreateNumericProperty(keyValue.Key, name, value, min, max, TypeSize.Byte, dec);
                    }
                    else if (selectedPatch.PatchDefines[keyValue.Key]["type"].Contains("word"))
                    {
                        if (!rangeSetted)
                        {
                            min = 0;
                            max = 0xFFFF;
                            rangeSetted = true;
                        }

                        CreateNumericProperty(keyValue.Key, name, value, min, max, TypeSize.Word, dec);
                    }
                    else if (selectedPatch.PatchDefines[keyValue.Key]["type"].Contains("long"))
                    {
                        if (!rangeSetted)
                        {
                            min = 0;
                            max = 0xFFFFFF;
                            rangeSetted = true;
                        }

                        CreateNumericProperty(keyValue.Key, name, value, min, max, TypeSize.Long, dec);
                    }
                    else if (selectedPatch.PatchDefines[keyValue.Key]["type"].Contains("bool"))
                    {
                        CreateBoolProperty(keyValue.Key, name, value, checkedvalue, uncheckedvalue);
                    }
                    else if (selectedPatch.PatchDefines[keyValue.Key]["type"].Contains("item"))
                    {
                        CreateItemProperty(keyValue.Key, name, value);
                    }
                    else if (selectedPatch.PatchDefines[keyValue.Key]["type"].Contains("choice"))
                    {
                        List<string> choices = new List<string>();
                        for (int i = 0; i < 10; i++)
                        {
                            if (selectedPatch.PatchDefines[keyValue.Key].ContainsKey("choice"+i.ToString()))
                            {
                                choices.Add(selectedPatch.PatchDefines[keyValue.Key]["choice" + i.ToString()]);
                            }
                        }

                        CreateChoicesProperty(keyValue.Key, name, value, choices);
                    }
                    else if (selectedPatch.PatchDefines[keyValue.Key]["type"].Contains("bitfield"))
                    {
                        List<string> choices = new List<string>();
                        for (int i = 0; i < 8; i++)
                        {
                            if (selectedPatch.PatchDefines[keyValue.Key].ContainsKey("bit" + i.ToString()))
                            {
                                choices.Add(selectedPatch.PatchDefines[keyValue.Key]["bit" + i.ToString()]);
                            }
                            else
                            {
                                choices.Add("_EMPTY");
                            }
                        }

                        CreateBitfieldProperty(keyValue.Key, name, value, choices);
                    }
                }
                else
                {
                    // no type were found default to byte value
                    if (!rangeSetted)
                    {
                        min = 0;
                        max = 0xFF;
                        rangeSetted = true;
                    }

                    CreateNumericProperty(keyValue.Key, name, value, min, max, TypeSize.Byte, dec);
                }
            }
        }

        private void patchListbox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            (patchListbox.Items[e.Index] as AsmPatch).PatchEnabled = e.NewValue == 0 ? false : true;
        }

        private void CreateNumericProperty(string defineName, string displayName, int value, int min, int max, TypeSize tsize, bool dec)
        {
            // make a hexbox tie the event textchanged to it
            Panel panel = new Panel();
            panel.Height = 32;
            panel.Dock = DockStyle.Top;

            Label label = new Label();
            label.Text = displayName;
            label.Width = 260;
            label.Dock = DockStyle.Left;

            Label labelType = new Label();
            if (dec)
            {
                labelType.Text = "(dec)";
            }
            else
            {
                labelType.Text = "(hex)";
            }
            labelType.Width = 40;
            labelType.Dock = DockStyle.Left;

            Hexbox byteHexbox = new Hexbox();
            byteHexbox.Digits = Hexbox.HexDigits.Two;
            if (tsize == TypeSize.Word)
            {
                byteHexbox.Digits = Hexbox.HexDigits.Four;
                byteHexbox.Width = 48;
            }
            else if (tsize == TypeSize.Long)
            {
                byteHexbox.Digits = Hexbox.HexDigits.Six;
                byteHexbox.Width = 64;
            }
            if (dec)
            {
                byteHexbox.Digits = Hexbox.HexDigits.Six;
                byteHexbox.Width = 64;
            }

            byteHexbox.Dock = DockStyle.Left;
            byteHexbox.Tag = defineName;
            byteHexbox.Width = 32;
            byteHexbox.MinValue = min;
            byteHexbox.MaxValue = max;
            byteHexbox.HexValue = value;
            byteHexbox.Decimal = dec;
            byteHexbox.TextChanged += ByteHexbox_TextChanged;

            panel.Controls.Add(labelType);
            panel.Controls.Add(byteHexbox);
            panel.Controls.Add(label);

            propertyGroupbox.Controls.Add(panel);
            propertyGroupbox.Controls.SetChildIndex(panel, 0);
        }

        private void ByteHexbox_TextChanged(object sender, EventArgs e)
        {
            selectedPatch.PatchDefines[(sender as Hexbox).Tag as string]["_VALUE"] = "$" + (sender as Hexbox).HexValue.ToString("X2");
        }

        private void CreateChoicesProperty(string defineName, string displayName, int value, List<string> choices)
        {
            Panel panel = new Panel();
            panel.Height = (22 * choices.Count) + 24;

            Label label = new Label();
            label.Text = displayName;
            label.Height = 16;
            label.Dock = DockStyle.Top;

            RadioButton[] radioButtons = new RadioButton[choices.Count];
            for (int i = choices.Count-1; i >= 0; i--)
            {

                radioButtons[i] = new RadioButton();
                radioButtons[i].Text = choices[i];
                radioButtons[i].Tag = new object[2] { defineName, i };
                radioButtons[i].Dock = DockStyle.Top;
                radioButtons[i].Height = 18;
                if (value == i)
                {
                    radioButtons[i].Checked = true;
                }

                radioButtons[i].CheckedChanged += Choice_CheckedChanged;

                panel.Controls.Add(radioButtons[i]);
            }

            panel.Controls.Add(label);
            panel.Dock = DockStyle.Top;
            propertyGroupbox.Controls.Add(panel);
            propertyGroupbox.Controls.SetChildIndex(panel, 0);
        }

        private void Choice_CheckedChanged(object sender, EventArgs e)
        {
            object[] data = (sender as RadioButton).Tag as object[];
            if ((sender as RadioButton).Checked == true)
            {
                selectedPatch.PatchDefines[data[0] as string]["_VALUE"] = "$" + ((int)data[1]).ToString("X2");
            }

        }

        private void CreateBoolProperty(string defineName, string displayName, int value, int checkedValue, int uncheckedValue)
        {
            // make a hexbox tie the event textchanged to it
            Panel panel = new Panel();
            panel.Height = 24;
            panel.Dock = DockStyle.Top;

            CheckBox boolCheckbox = new CheckBox();
            boolCheckbox.Text = displayName;
            boolCheckbox.Width = 260;
            boolCheckbox.Dock = DockStyle.Left;

            if (value == checkedValue)
            {
                boolCheckbox.Checked = true;
            }
            else
            {
                boolCheckbox.Checked = false;
            }

            boolCheckbox.Tag = new object[3] { defineName, checkedValue, uncheckedValue };
            boolCheckbox.CheckedChanged += BoolCheckbox_CheckedChanged;
            panel.Controls.Add(boolCheckbox);
            propertyGroupbox.Controls.Add(panel);
            propertyGroupbox.Controls.SetChildIndex(panel, 0);
        }

        private void BoolCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            object[] data = (sender as CheckBox).Tag as object[];
            if ((sender as CheckBox).Checked)
            {
                selectedPatch.PatchDefines[data[0] as string]["_VALUE"] = "$" + ((int)data[1]).ToString("X2");
            }
            else
            {
                selectedPatch.PatchDefines[data[0] as string]["_VALUE"] = "$" + ((int)data[2]).ToString("X2");
            }
        }

        private void CreateItemProperty(string defineName, string displayName, int value)
        {
            Panel panel = new Panel();
            panel.Height = 24;
            panel.Dock = DockStyle.Top;

            Label label = new Label();
            label.Text = displayName;
            label.Dock = DockStyle.Left;
            label.Width = 260;

            ComboBox itemCombobox = new ComboBox();
            itemCombobox.Items.AddRange(ChestItems_Name.name);
            itemCombobox.SelectedIndex = value;
            itemCombobox.Width = 200;
            itemCombobox.Tag = defineName;
            itemCombobox.Dock = DockStyle.Left;
            itemCombobox.SelectedIndexChanged += ItemCombobox_SelectedIndexChanged;

            panel.Controls.Add(itemCombobox);
            panel.Controls.Add(label);

            propertyGroupbox.Controls.Add(panel);
            propertyGroupbox.Controls.SetChildIndex(panel, 0);
        }

        private void ItemCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedPatch.PatchDefines[(sender as ComboBox).Tag as string]["_VALUE"] = "$" + (sender as ComboBox).SelectedIndex.ToString("X2");
        }

        private void CreateBitfieldProperty(string defineName, string displayName, int value, List<string> choices)
        {
            Panel panel = new Panel();
            panel.Height = (16 * choices.Count) + 24;
            Label label = new Label();
            label.Text = displayName;
            label.Height = 16;
            label.Dock = DockStyle.Top;

            CheckBox[] checkboxes = new CheckBox[choices.Count];
            for (int i = 0; i<choices.Count; i++)
            {
                if (choices[i] != "_EMPTY")
                {
                    checkboxes[i] = new CheckBox();
                    checkboxes[i].Text = choices[i];
                    checkboxes[i].Dock = DockStyle.Top;
                    checkboxes[i].Height = 16;
                    if ((value & bitmask[i]) == bitmask[i])
                    {
                        checkboxes[i].Checked = true;
                    }

                    checkboxes[i].CheckedChanged += AsmPlugin_BitfieldCheckedChanged;

                    panel.Controls.Add(checkboxes[i]);
                    panel.Controls.SetChildIndex(checkboxes[i], 0);
                }
                else
                {
                    checkboxes[i] = new CheckBox();
                    checkboxes[i].Checked = false;
                }
            }
            for (int i = 0; i < choices.Count; i++)
            {
                checkboxes[i].Tag = new object[2] { defineName, checkboxes };
            }

            panel.Controls.Add(label);
            panel.Dock = DockStyle.Top;

            propertyGroupbox.Controls.Add(panel);
            propertyGroupbox.Controls.SetChildIndex(panel, 0);
        }

        

        private void AsmPlugin_BitfieldCheckedChanged(object sender, EventArgs e)
        {
            object[] data = (sender as CheckBox).Tag as object[];
            int value = 0;
            for(int i = 0; i < 8; i++)
            {
                if ((data[1] as CheckBox[])[i].Checked)
                {
                    value |= bitmask[i];
                }
            }

            selectedPatch.PatchDefines[data[0] as string]["_VALUE"] = "$" + ((int)value).ToString("X2");
        }

        private void LoadPatches()
        {
            if (!Directory.Exists(ProjectPath + "\\Patches"))
            {
                Directory.CreateDirectory(ProjectPath + "\\Patches");
            }

            string[] patchfiles = Directory.GetFiles(ProjectPath + "\\Patches", "*.asm");
            foreach (string patch in patchfiles)
            {
                if (patch.Contains("generated.asm")) { continue; };
                PatchList.Add(new AsmPatch(patch));
            }

            UpdatePatchList();
        }


        private void SavePatches()
        {
            StringBuilder generatedAsmFile = new StringBuilder();
            generatedAsmFile.AppendLine("lorom");

            generatedAsmFile.AppendLine("org $3C8000"); // need to do something about it
            foreach (AsmPatch patch in PatchList)
            {
                patch.Save(ProjectPath);
                if (patch.PatchEnabled)
                {
                    string relativeFilename = patch.FileName.Substring(patch.FileName.IndexOf("Patches")+8);
                    generatedAsmFile.AppendLine("incsrc" + patch.FileName);
                }
            }

            File.WriteAllText(ProjectPath + "\\Patches\\generated.asm", generatedAsmFile.ToString());
        }

        private int ReadStringInt(string s)
        {
            if (s.Contains('$'))
            {
                s = s.Substring(s.IndexOf('$') + 1);
                return int.Parse(s, System.Globalization.NumberStyles.HexNumber);
            }
            else
            {
                return int.Parse(s);
            }
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            SavePatches();
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void morepatchButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will bring you to the ZScreamPatches github to download more patch", "Open in browser",MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                System.Diagnostics.Process.Start("https://github.com/Zarby89/ZScreamPatches");
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to save your current changes before reloading patches?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SavePatches();
            }
            PatchList.Clear();
            LoadPatches();
        }

        private void addasmPatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog of = new OpenFileDialog())
            {
                of.Filter = "ASM source files (*.asm)|*.asm";
                of.Multiselect = true;
                of.DefaultExt = "asm";
                if (Directory.Exists("ZS_Patches"))
                {
                    of.InitialDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\ZS_Patches";
                }
                else
                {
                    of.InitialDirectory = ProjectPath;
                }
                if (of.ShowDialog() == DialogResult.OK)
                {
                    PatchList.Add(new AsmPatch(of.FileName));
                }

                UpdatePatchList();
            }
        }

        private void deleteSelectedPatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedPatch != null)
            {
                File.Delete(selectedPatch.FileName);
                PatchList.Remove(selectedPatch);
                selectedPatch = null;
                UpdatePatchList();
            }
        }
    }

    enum TypeSize
    {
        Byte,
        Word,
        Long
    }

}
