using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using ZeldaFullEditor.Data;

namespace ZeldaFullEditor.Gui.ExtraForms
{
    public partial class AsmPlugin : Form
    {
        public AsmPlugin()
        {
            InitializeComponent();
        }
        public string projectPath = "";
        private void AsmPlugin_Load(object sender, EventArgs e)
        {
            foreach (string f in Directory.EnumerateFiles(projectPath + "\\Plugins"))
            {
                pluginListbox.Items.Add(Path.GetFileNameWithoutExtension(f));

                string[] lines = File.ReadAllLines(f);
                bool startReadingDesc = false;
                string desc = "";
                string name = "";
                string version = "";
                string author = "";
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i] == ";#PLUGINEND_DESCRIPTION")
                    {
                        startReadingDesc = false;
                        pluginDescriptionTextbox.Text = desc;
                    }
                    else if (lines[i].Contains(";#PLUGIN_NAME="))
                    {
                        int scopy = lines[i].IndexOf('=');
                        name = lines[i].Substring(scopy+1);
                        
                    }
                    else if (lines[i].Contains(";#PLUGIN_AUTHOR="))
                    {
                        int scopy = lines[i].IndexOf('=');
                        author = lines[i].Substring(scopy + 1);
                        
                    }
                    else if (lines[i].Contains(";#PLUGIN_VERSION="))
                    {
                        int scopy = lines[i].IndexOf('=');
                        version = lines[i].Substring(scopy + 1);
                    }

                    if (startReadingDesc)
                    {
                        desc += lines[i] + "\r\n";
                    }

                    if (lines[i] == ";#PLUGIN_DESCRIPTION")
                    {
                        startReadingDesc = true;
                    }
                    if (lines[i].Length > 0)
                    {
                        if (lines[i][0] == '!') // this is a define
                        {
                            int scopy = lines[i].IndexOf('=');
                            string dname = lines[i].Substring(1, scopy - 1);
                            string dvalue = lines[i].Substring(scopy + 1);
                            int value = 0;
                            if (dvalue.Contains("$"))
                            {
                                dvalue = lines[i].Substring(lines[i].IndexOf('$') + 1);
                                value = int.Parse(dvalue, System.Globalization.NumberStyles.HexNumber);
                            }
                            else
                            {
                                value = int.Parse(dvalue);
                            }
                            if (dvalue.Length > 2)
                            {
                                this.AddHexProperty(value, dname, 0xFFFF);
                            }
                            else
                            {
                                this.AddHexProperty(value, dname, 0xFF);
                            }
                            
                        }
                    }

                }



                // for each values in the plugin
                pluginAuthorLabel.Text = "Author : " + author + "                Version : " + version;

            }




        }


        private void AddHexProperty(int value, string name, int maxSize = 0xFFFF)
        {
            Panel propertyPanel = new Panel();
            propertyPanel.Height = 24;
            propertyPanel.Dock = DockStyle.Top;

            Hexbox hexbox = new Hexbox();
            hexbox.Width = 48;
            hexbox.MinValue = 0;
            
            hexbox.MaxValue = 0xFFFF;
            hexbox.Digits = Hexbox.HexDigits.Four;
            hexbox.Dock = DockStyle.Left;
            propertyPanel.Controls.Add(hexbox);

            Label nameLabel = new Label();
            nameLabel.Text = name;
            nameLabel.Dock = DockStyle.Left;
            propertyPanel.Controls.Add(nameLabel);
            propertiesPanel.Controls.Add(propertyPanel);
            hexbox.MaxValue = 0xFFFF;
            hexbox.HexValue = value;

            Console.WriteLine(hexbox.MaxValue.ToString("X4"));


        }
    }

    public class Plugin
    {
        public Plugin(string name, string desc, string version, string author) 
        {
            
        }
    }
}
