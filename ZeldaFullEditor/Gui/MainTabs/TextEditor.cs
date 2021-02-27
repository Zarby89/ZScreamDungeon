using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using ZeldaFullEditor.Gui.TextEditorExtra;
namespace ZeldaFullEditor
{
    public partial class TextEditor : UserControl
    {
        public TextEditor()
        {
            InitializeComponent();
        }

        private void TextEditor_Load(object sender, EventArgs e)
        {

        }

        int[] addrTexts = new int[500];
        byte[] widthArray = new byte[100];
        List<StringKey> listOfTexts = new List<StringKey>();
        int defaultColor = 6;

        public void readAllText()
        {
            int tt = 0;
            byte b = 0;
            int pos = Constants.text_data;
            bool endReached = false;
            string tempString = "";
            List<byte> tempBytes = new List<byte>();

            while (true)
            {

                b = ROM.DATA[pos];
                tempBytes.Add(b);
                string s = readNextTextByte(b);
                if (s == "[WIN") { pos += 1; s += ROM.DATA[pos].ToString("D2") + "]"; }
                else if (s == "[NBR") { pos += 1; s += ROM.DATA[pos].ToString("D2") + "]"; }
                else if (s == "[POS") { pos += 1; s += ROM.DATA[pos].ToString("D2") + "]"; }
                else if (s == "[SSD") { pos += 1; s += ROM.DATA[pos].ToString("D2") + "]"; }
                else if (s == "[COL") { pos += 1; s += ROM.DATA[pos].ToString("D2") + "]"; }
                else if (s == "[WAI") { pos += 1; s += ROM.DATA[pos].ToString("D2") + "]"; }
                else if (s == "[SND") { pos += 1; s += ROM.DATA[pos].ToString("D2") + "]"; }
                else if (s == "[SPD") { pos += 1; s += ROM.DATA[pos].ToString("D2") + "]"; }
                else if (s == "[NNN]") { tempString += s; pos = Constants.text_data2; continue; }
                else if (s.Length >= 5)
                {
                    if (s[0] == '[' && s[1] == 'D' && s[2] == 'I' && s[3] == 'C')
                    {
                        string nbr = "";
                        nbr += s[4];
                        nbr += s[5];
                        int nbrint = 0;
                        int addr = 0;
                        if (int.TryParse(nbr, out nbrint))
                        {
                            s = "";
                            //nbrint = 1;
                            addr = Utils.SnesToPc((0x0E << 16) +
                                (ROM.DATA[Constants.pointers_dictionaries + (nbrint * 2) + 1] << 8) +
                                ROM.DATA[Constants.pointers_dictionaries + (nbrint * 2)]);

                            int tempaddr = Utils.SnesToPc((0x0E << 16) +
                            (ROM.DATA[Constants.pointers_dictionaries + ((nbrint + 1) * 2) + 1] << 8) +
                            ROM.DATA[Constants.pointers_dictionaries + ((nbrint + 1) * 2)]);

                            while (addr < tempaddr)
                            {
                                byte bdictionary = ROM.DATA[addr];
                                tempBytes.Add(bdictionary);
                                string ds = readNextTextByte(bdictionary);
                                s += ds;
                                addr++;
                            }
                        }
                        addr++;
                    }
                }
                //text_dictionaries
                tempString += s;
                pos++;

                if (b == 0x7F)
                {
                    listOfTexts.Add(new StringKey(tempString, tempBytes.ToArray()));
                    tempBytes.Clear();
                    tempString = "";
                    addrTexts[tt] = pos;
                    tt++;
                    continue;

                }
                else if (b == 0xFF)
                {
                    break;
                }
                //pos++;


                /*if (listOfTexts.Count > 205)
                {
                    break;
                }*/
                //Check if reached the end of possible data then break

            }
            //00074703

        }
        List<string> savedTexts = new List<string>();
        List<byte[]> savedBytes = new List<byte[]>();
        public List<string> dictionaries = new List<string>();
        public List<byte[]> dictionaries_bytes = new List<byte[]>();
        public void buildDictionaries()
        {
            for (int i = 0; i < 97; i++)
            {
                int addr = 0;
                List<byte> bytes = new List<byte>();
                string s = "";
                //nbrint = 1;
                addr = Utils.SnesToPc((0x0E << 16) +
                    (ROM.DATA[Constants.pointers_dictionaries + (i * 2) + 1] << 8) +
                    ROM.DATA[Constants.pointers_dictionaries + (i * 2)]);

                int tempaddr = Utils.SnesToPc((0x0E << 16) +
                (ROM.DATA[Constants.pointers_dictionaries + ((i + 1) * 2) + 1] << 8) +
                ROM.DATA[Constants.pointers_dictionaries + ((i + 1) * 2)]);

                while (addr < tempaddr)
                {
                    byte bdictionary = ROM.DATA[addr];
                    bytes.Add(bdictionary);
                    string ds = readNextTextByte(bdictionary);
                    s += ds;
                    addr++;
                }
                dictionaries_bytes.Add(bytes.ToArray());
                dictionaries.Add(s);
            }

            string[] orderedDictionary = dictionaries.OrderBy(x => x.Length).ToArray();

            for (int i = 0; i < 97; i++)
            {
                dictionariesOrder[i] = dictionaries.FindIndex(x => x == orderedDictionary[i]);
            }

        }
        int[] dictionariesOrder = new int[97];
        public void setTextsDictionaries()
        {
            savedTexts.Clear();
            //this function scan for keyword existing in dictionaries
            //if we find one replace that text by [DICXX]
            foreach (StringKey texts in listOfTexts)
            {
                string s = texts.text;

                for (int i = 96; i >= 0; i--)
                {
                    s = s.Replace(dictionaries[dictionariesOrder[i]], "[DIC" + dictionariesOrder[i].ToString("D2") + "]");
                }


                savedTexts.Add(s);
            }
        }

        public byte[] parseTextToBytes(string fullString)
        {
            defaultColor = 6;
            List<byte> bytes = new List<byte>();
            string s = fullString;
            while (s.Length > 0)
            {
                if (s[0] == '[') //this is a command parsecommand
                {
                    StringByte sb = parseCommand(s);
                    if (sb.s != "ERROR")
                    {
                        foreach (byte b in sb.bytes)
                        {
                            bytes.Add(b);
                        }
                        s = sb.s;
                        //Console.WriteLine("CMD FOUND : " + s);
                    }
                    else
                    {
                        break;
                    }
                    continue;
                }

                else if ((byte)s[0] <= 0x39 && (byte)s[0] >= 0x30) //numbers
                {
                    bytes.Add((byte)((s[0] - 48) + 52));
                }
                else if ((byte)s[0] <= 0x5A && (byte)s[0] > 0x40) //capital letter
                {
                    bytes.Add((byte)(s[0] - 65));
                }
                else if ((char)s[0] <= 0x7A && (byte)s[0] > 0x5A) //small letters
                {
                    bytes.Add((byte)((s[0] - 97) + 26));
                }

                else if (s[0] == '!') { bytes.Add(0x3E); }
                else if (s[0] == '?') { bytes.Add(0x3F); }
                else if (s[0] == '-') { bytes.Add(0x40); }
                else if (s[0] == '.') { bytes.Add(0x41); }
                else if (s[0] == ',') { bytes.Add(0x42); }
                else if (s[0] == '…') { bytes.Add(0x43); }
                else if (s[0] == '>') { bytes.Add(0x44); }
                else if (s[0] == '(') { bytes.Add(0x45); }
                else if (s[0] == ')') { bytes.Add(0x46); }
                else if (s[0] == '"') { bytes.Add(0x4C); }
                else if (s[0] == '↑') { bytes.Add(0x4D); }
                else if (s[0] == '↓') { bytes.Add(0x4E); }
                else if (s[0] == '←') { bytes.Add(0x4F); }
                else if (s[0] == '→') { bytes.Add(0x50); }
                else if (s[0] == '\'') { bytes.Add(0x51); }
                else if (s[0] == ' ') { bytes.Add(0x59); }
                else if (s[0] == '<') { bytes.Add(0x5A); }
                else if (s[0] == 'Ⓐ') { bytes.Add(0x5B); }
                else if (s[0] == 'Ⓑ') { bytes.Add(0x5C); }
                else if (s[0] == 'ⓧ') { bytes.Add(0x5D); }
                else if (s[0] == 'ⓨ') { bytes.Add(0x5E); }
                else if (s[0] == '¡') { bytes.Add(0x5F); }
                else if (s[0] == '¡') { bytes.Add(0x60); }
                else if (s[0] == '¡') { bytes.Add(0x61); }
                else if (s[0] == ' ') { bytes.Add(0x62); }
                else if (s[0] == ' ') { bytes.Add(0x63); }
                else if (s[0] == ' ') { bytes.Add(0x64); }
                else if (s[0] == ' ') { bytes.Add(0x65); }
                else if (s[0] == '_') { bytes.Add(0x66); }
                s = s.Substring(1);
            }
            return bytes.ToArray();


        }

        public StringByte parseCommand(string fullString)
        {
            if (fullString.Length >= 5)
            {
                string cmdstring = fullString.Substring(0, 4); //[ + cmd
                string argstring = "";
                int arg = 0;
                if (fullString.Length >= 7)
                {
                    argstring = fullString.Substring(4, 2);
                    int.TryParse(argstring, out arg);

                }
                //[WIN00]

                if (cmdstring == "[WIN")
                {
                    if (fullString.Length >= 7)
                    {
                        return new StringByte(fullString.Substring(7), new byte[] { 0x6B, (byte)arg });
                    }

                }
                else if (cmdstring == "[NBR")
                {
                    if (fullString.Length >= 7)
                    {
                        return new StringByte(fullString.Substring(7), new byte[] { 0x6C, (byte)arg });
                    }
                }
                else if (cmdstring == "[POS")
                {
                    if (fullString.Length >= 7)
                    {
                        return new StringByte(fullString.Substring(7), new byte[] { 0x6D, (byte)arg });
                    }
                }
                else if (cmdstring == "[SSD")
                {
                    if (fullString.Length >= 7)
                    {
                        return new StringByte(fullString.Substring(7), new byte[] { 0x6E, (byte)arg });
                    }
                }
                else if (cmdstring == "[COL")
                {
                    if (fullString.Length >= 7)
                    {
                        defaultColor = arg;
                        return new StringByte(fullString.Substring(7), new byte[] { 0x77, (byte)arg });

                    }
                }
                else if (cmdstring == "[WAI")
                {
                    if (fullString.Length >= 8)
                    {
                        return new StringByte(fullString.Substring(7), new byte[] { 0x78, (byte)arg });
                    }
                }
                else if (cmdstring == "[SND")
                {
                    if (fullString.Length >= 8)
                    {
                        return new StringByte(fullString.Substring(7), new byte[] { 0x79, (byte)arg });
                    }
                }
                else if (cmdstring == "[SPD")
                {
                    if (fullString.Length >= 8)
                    {
                        return new StringByte(fullString.Substring(7), new byte[] { 0x7A, (byte)arg });
                    }
                }
                //97 entries
                else if (cmdstring == "[DIC") { return new StringByte(fullString.Substring(7), new byte[] { (byte)(0x88 + (byte)arg) }); }

                else if (cmdstring == "[HY0") { return new StringByte(fullString.Substring(5), new byte[] { 0x47 }); }
                else if (cmdstring == "[HY1") { return new StringByte(fullString.Substring(5), new byte[] { 0x48 }); }
                else if (cmdstring == "[HY2") { return new StringByte(fullString.Substring(5), new byte[] { 0x49 }); }
                else if (cmdstring == "[LHL") { return new StringByte(fullString.Substring(5), new byte[] { 0x4A }); }
                else if (cmdstring == "[LHR") { return new StringByte(fullString.Substring(5), new byte[] { 0x4B }); }
                else if (cmdstring == "[HP0") { return new StringByte(fullString.Substring(5), new byte[] { 0x52 }); }
                else if (cmdstring == "[HP1") { return new StringByte(fullString.Substring(5), new byte[] { 0x53 }); }
                else if (cmdstring == "[HP2") { return new StringByte(fullString.Substring(5), new byte[] { 0x54 }); }
                else if (cmdstring == "[HP3") { return new StringByte(fullString.Substring(5), new byte[] { 0x55 }); }
                else if (cmdstring == "[HP4") { return new StringByte(fullString.Substring(5), new byte[] { 0x56 }); }
                else if (cmdstring == "[HP5") { return new StringByte(fullString.Substring(5), new byte[] { 0x57 }); }
                else if (cmdstring == "[HP6") { return new StringByte(fullString.Substring(5), new byte[] { 0x58 }); }
                else if (cmdstring == "[IMG") { return new StringByte(fullString.Substring(5), new byte[] { 0x67 }); }
                else if (cmdstring == "[CHS") { return new StringByte(fullString.Substring(5), new byte[] { 0x68 }); }
                else if (cmdstring == "[ITM") { return new StringByte(fullString.Substring(5), new byte[] { 0x69 }); }
                else if (cmdstring == "[NAM") { return new StringByte(fullString.Substring(5), new byte[] { 0x6A }); }
                else if (cmdstring == "[SEL") { return new StringByte(fullString.Substring(5), new byte[] { 0x6F }); }
                else if (cmdstring == "[???") { return new StringByte(fullString.Substring(5), new byte[] { 0x70 }); }
                else if (cmdstring == "[CH2") { return new StringByte(fullString.Substring(5), new byte[] { 0x71 }); }
                else if (cmdstring == "[CH3") { return new StringByte(fullString.Substring(5), new byte[] { 0x72 }); }
                else if (cmdstring == "[SCL") { return new StringByte(fullString.Substring(5), new byte[] { 0x73 }); }
                else if (cmdstring == "[LN1") { return new StringByte(fullString.Substring(5), new byte[] { 0x74 }); }
                else if (cmdstring == "[LN2") { return new StringByte(fullString.Substring(5), new byte[] { 0x75 }); }
                else if (cmdstring == "[LN3") { return new StringByte(fullString.Substring(5), new byte[] { 0x76 }); }
                else if (cmdstring == "[WFK") { return new StringByte(fullString.Substring(5), new byte[] { 0x7E }); }
                else if (cmdstring == "[NNN") { return new StringByte(fullString.Substring(5), new byte[] { 0x80 }); }
            }
            return new StringByte("ERROR", new byte[] { 0x7F });



        }


        public string readNextTextByte(byte b)
        {
            string tempString = "";
            if (b == 0x80) //switch to 2nd sets of messages
            {
                tempString = "[NNN]";
            }

            if (b <= 0x19) //Caps 
            {
                //65-90
                tempString += (char)(b + 65);
            }
            else if (b > 0x19 && b <= 0x33) //Small Letters
            {
                //97-122
                tempString += (char)((b - 26) + 97);
            }
            else if (b > 0x33 && b <= 0x3D) //Numbers
            {
                //48-57
                tempString += (char)((b - 52) + 48);
            }
            else if (b == 0x3E) { tempString += "!"; }
            else if (b == 0x3F) { tempString += "?"; }
            else if (b == 0x40) { tempString += "-"; }
            else if (b == 0x41) { tempString += "."; }
            else if (b == 0x42) { tempString += ","; }
            else if (b == 0x43) { tempString += "…"; }
            else if (b == 0x44) { tempString += ">"; }
            else if (b == 0x45) { tempString += "("; }
            else if (b == 0x46) { tempString += ")"; }
            else if (b == 0x47) { tempString += "[HY0]"; }
            else if (b == 0x48) { tempString += "[HY1]"; }
            else if (b == 0x49) { tempString += "[HY2]"; }
            else if (b == 0x4A) { tempString += "[LHL]"; }
            else if (b == 0x4B) { tempString += "[LHR]"; }
            else if (b == 0x4C) { tempString += "\""; }
            else if (b == 0x4D) { tempString += "↑"; }
            else if (b == 0x4E) { tempString += "↓"; }
            else if (b == 0x4F) { tempString += "←"; }
            else if (b == 0x50) { tempString += "→"; }
            else if (b == 0x51) { tempString += "\'"; }
            else if (b == 0x52) { tempString += "[HP0]"; }
            else if (b == 0x53) { tempString += "[HP1]"; }
            else if (b == 0x54) { tempString += "[HP2]"; }
            else if (b == 0x55) { tempString += "[HP3]"; }
            else if (b == 0x56) { tempString += "[HP4]"; }
            else if (b == 0x57) { tempString += "[HP5]"; }
            else if (b == 0x58) { tempString += "[HP6]"; }
            else if (b == 0x59) { tempString += " "; }
            else if (b == 0x5A) { tempString += "<"; }
            else if (b == 0x5B) { tempString += "Ⓐ"; }
            else if (b == 0x5C) { tempString += "Ⓑ"; }
            else if (b == 0x5D) { tempString += "ⓧ"; }
            else if (b == 0x5E) { tempString += "ⓨ"; }
            else if (b == 0x5F) { tempString += "¡"; }
            else if (b == 0x60) { tempString += "¡"; }
            else if (b == 0x61) { tempString += "¡"; }
            else if (b == 0x62) { tempString += " "; }
            else if (b == 0x63) { tempString += " "; }
            else if (b == 0x64) { tempString += " "; }
            else if (b == 0x65) { tempString += " "; }
            else if (b == 0x66) { tempString += "_"; }
            //Start of the commands list

            else if (b == 0x67) { tempString += "[IMG]"; }

            else if (b == 0x68) { tempString += "[CHS]"; }

            else if (b == 0x69) { tempString += "[ITM]"; }

            else if (b == 0x6A) { tempString += "[NAM]"; }

            else if (b == 0x6B)
            {
                tempString += "[WIN";
            }

            else if (b == 0x6C)
            {
                tempString += "[NBR";
            }

            else if (b == 0x6D)
            {
                tempString += "[POS";
            }

            else if (b == 0x6E)
            {
                tempString += "[SSD";
            }



            else if (b == 0x6F) { tempString += "[SEL]"; }

            else if (b == 0x70) { tempString += "[???]"; }

            else if (b == 0x71) { tempString += "[CH2]"; }

            else if (b == 0x72) { tempString += "[CH3]"; }

            else if (b == 0x73) { tempString += "[SCL]"; }

            else if (b == 0x74) { tempString += "[LN1]"; }

            else if (b == 0x75) { tempString += "[LN2]"; }

            else if (b == 0x76) { tempString += "[LN3]"; }

            else if (b == 0x77)
            {
                tempString += "[COL";
            }

            else if (b == 0x78)
            {
                tempString += "[WAI";
            }

            else if (b == 0x79)
            {
                tempString += "[SND";
            }

            else if (b == 0x7A)
            {
                tempString += "[SPD";
            }

            else if (b == 0x7E) { tempString += "[WFK]"; }

            //Dictionary 
            else if (b >= 0x88)
            {
                tempString += "[DIC" + (b - 0x88).ToString("D2") + "]";
            }
            return tempString;

        }
        string romname = "";
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
           /* OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Snes ROM|*.sfc;*.smc";
            if (of.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(of.FileName, FileMode.Open, FileAccess.Read))
                {
                    romname = of.FileName;
                    ROM.DATA = new byte[fs.Length];
                    fs.Read(ROM.DATA, 0, (int)fs.Length);
                    fs.Close();
                    
                }
                
            }*/
        }

        public void initOpen()
        {

            panel1.Enabled = true;
            for (int i = 0; i < 100; i++)
            {
                widthArray[i] = ROM.DATA[Constants.characters_width + i];
            }

            GFX.fontgfxBitmap = new Bitmap(128, 128, 64, PixelFormat.Format4bppIndexed, GFX.fontgfx16Ptr);
            GFX.currentfontgfx16Bitmap = new Bitmap(172, 4096, 172, PixelFormat.Format8bppIndexed, GFX.currentfontgfx16Ptr);
            string[] alllines = new string[255];

            readAllText();
            savedBytes.Clear();
            buildDictionaries();
            setTextsDictionaries();
            for (int i = 0; i < savedTexts.Count; i++)
            {
                savedBytes.Add(parseTextToBytes(savedTexts[i]));
            }
            textListbox.BeginUpdate();
            textListbox.Items.Clear();
            for (int i = 0; i < listOfTexts.Count; i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = i.ToString("D3") + " : " + listOfTexts[i].text;
                lvi.Tag = i;
                textListbox.Items.Add(lvi);
            }
            textListbox.EndUpdate();
            textListbox.DisplayMember = "Text";
            pictureBox2.Refresh();

            GFX.CreateFontGfxData(ROM.DATA);
        }


        int textLine = 0;
        private void textListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            StringKey sk = listOfTexts[(int)(textListbox.Items[textListbox.SelectedIndex] as ListViewItem).Tag];
            //Console.WriteLine(savedTexts[textListbox.SelectedIndex]);
            /*for (int i = 0; i < savedBytes[textListbox.SelectedIndex].Length; i++)
            {
                Console.Write(savedBytes[textListbox.SelectedIndex][i].ToString("X2") + " ");
            }*/
            //Console.WriteLine();
            textBox1.Text = sk.text;

            drawTextPreview();
            label9.Text = "Address : " + addrTexts[textListbox.SelectedIndex].ToString("X6");


            pictureBox1.Refresh();
        }
        int textPos = 0;
        bool skipNext = false;
        public unsafe void drawLetter(byte b)
        {
            if (skipNext)
            {
                skipNext = false;
                return;

            }

            int srcy = 0;
            int srcx = 0;
            if (b < 100)
            {
                srcy = ((b / 16));
                srcx = b - ((b / 16) * 16);

                if (textPos >= 170)
                {
                    textPos = 0;
                    textLine++;
                }
                draw_item_tile(textPos, textLine * 16, srcx, srcy, 0, false, false, 1, 2);
                textPos += widthArray[b];
            }
            else if (b == 0x74) { textPos = 0; textLine = 0; }
            else if (b == 0x73) { textPos = 0; textLine += 1; }
            else if (b == 0x75) { textPos = 0; textLine = 1; }
            else if (b == 0x6B) { skipNext = true; return; }
            else if (b == 0x6C) { skipNext = true; return; }
            else if (b == 0x6D) { skipNext = true; return; }
            else if (b == 0x6E) { skipNext = true; return; }
            else if (b == 0x77) { skipNext = true; return; }
            else if (b == 0x78) { skipNext = true; return; }
            else if (b == 0x79) { skipNext = true; return; }
            else if (b == 0x7A) { skipNext = true; return; }
            else if (b == 0x76) { textPos = 0; textLine = 2; }
            else if (b == 0x6A)
            {
                //NAME
                srcy = ((13 / 16));
                srcx = 13 - ((13 / 16) * 16);
                draw_item_tile(textPos, textLine * 16, srcx, srcy, 0, false, false, 1, 2);
                textPos += widthArray[13];

                srcy = ((0 / 16));
                srcx = 0 - ((0 / 16) * 16);
                draw_item_tile(textPos, textLine * 16, srcx, srcy, 0, false, false, 1, 2);
                textPos += widthArray[0];

                srcy = ((12 / 16));
                srcx = 12 - ((12 / 16) * 16);
                draw_item_tile(textPos, textLine * 16, srcx, srcy, 0, false, false, 1, 2);
                textPos += widthArray[12];

                srcy = ((4 / 16));
                srcx = 4 - ((13 / 16) * 16);
                draw_item_tile(textPos, textLine * 16, srcx, srcy, 0, false, false, 1, 2);
                textPos += widthArray[4];
            }
            else if (b >= 0x88 && b <= (0x88 + 97))
            {
                byte bdict = (byte)(b - 0x88);
                foreach (byte bd in dictionaries_bytes[bdict])
                {
                    drawLetter(bd);
                }
            }
        }



        public unsafe void drawTextPreview() //From Parsing
        {
            //defaultColor = 6;
            textLine = 0;
            byte* ptr = (byte*)GFX.currentfontgfx16Ptr.ToPointer();
            for (int i = 0; i < (172 * 4096); i++)
            {
                ptr[i] = 0;
            }
            textPos = 0;
            int t = 0;
            foreach (byte b in savedBytes[(int)(textListbox.SelectedItem as ListViewItem).Tag])
            {
                drawLetter(b);
            }
            shownLines = 0;
            upButton.Enabled = false;
            if (textLine > 2)
            {
                downButton.Enabled = true;
            }
            else
            {
                downButton.Enabled = false;
            }
        }

        public unsafe void draw_item_tile(int x, int y, int srcx, int srcy, int pal, bool mirror_x = false, bool mirror_y = false, int sizex = 1, int sizey = 1)
        {
            var alltilesData = (byte*)GFX.fontgfx16Ptr.ToPointer();

            byte* ptr = (byte*)GFX.currentfontgfx16Ptr.ToPointer();

            int drawid = (srcx + (srcy * 32));
            for (var yl = 0; yl < sizey * 8; yl++)
            {
                for (var xl = 0; xl < 4; xl++)
                {
                    int mx = xl;
                    int my = yl;
                    byte r = 0;

                    //Formula information to get tile index position in the array
                    //((ID / nbrofXtiles) * (imgwidth/2) + (ID - ((ID/16)*16) ))
                    int tx = ((drawid / 16) * 512) + ((drawid - ((drawid / 16) * 16)) * 4);
                    var pixel = alltilesData[tx + (yl * 64) + xl];
                    //nx,ny = object position, xx,yy = tile position, xl,yl = pixel position
                    int index = (x) + (y * 172) + ((mx * 2) + (my * (172)));
                    if ((pixel & 0x0F) != 0)
                    {
                        ptr[index + 1] = (byte)((pixel & 0x0F) + (0 * 4));
                    }
                    if (((pixel >> 4) & 0x0F) != 0)
                    {
                        ptr[index + 0] = (byte)(((pixel >> 4) & 0x0F) + (0 * 4));
                    }
                }
            }
        }

        private void searchTextbox_TextChanged(object sender, EventArgs e)
        {
            sortText();
        }

        public void sortText()
        {
            textListbox.BeginUpdate();
            textListbox.Items.Clear();
            //Sorting sort;
            string searchText = searchTextbox.Text.ToLower();
            //listView1
            StringKey[] texts = listOfTexts
                .Where(x => x != null)
                .Where(x => (x.text.ToLower().Contains(searchText)))
                .ToArray();

            foreach (StringKey s in texts)
            {
                for (int i = 0; i < listOfTexts.Count; i++)
                {
                    if (s.text == listOfTexts[i].text)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = i.ToString("D3") + " : " + listOfTexts[i].text;
                        lvi.Tag = i;
                        textListbox.Items.Add(lvi);
                        break;
                    }
                }
            }
            textListbox.EndUpdate();

        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.DrawImage(GFX.fontgfxBitmap, new Rectangle(0, 0, 256, 256));
            int srcY = (selectedTile / 16);
            int srcX = selectedTile - (srcY * 16);
            e.Graphics.DrawRectangle(new Pen(Brushes.GreenYellow, 2), new Rectangle(srcX * 16, srcY * 32, 16, 32));
            label6.Text = "ID : " + selectedTile.ToString("X2");
            label7.Text = "ASCII : " + readNextTextByte((byte)selectedTile);

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            ColorPalette cp = GFX.currentfontgfx16Bitmap.Palette;


            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    cp.Entries[i] = Color.Transparent;
                }
                else
                {
                    cp.Entries[i] = GFX.roomBg1Bitmap.Palette.Entries[(defaultColor * 4) + i];

                }
            }
            GFX.currentfontgfx16Bitmap.Palette = cp;

            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.DrawImage(GFX.currentfontgfx16Bitmap, new Rectangle(0, 0, 340, pictureBox2.Height), new Rectangle(0, shownLines * 16, 170, pictureBox2.Height / 2), GraphicsUnit.Pixel);
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(128, 255, 0, 0)), new Rectangle(344 - 8, 0, 4, pictureBox2.Height));
        }
        int shownLines = 0;
        private void downButton_Click(object sender, EventArgs e)
        {
            if (shownLines < textLine - 2)
            {
                shownLines++;
                upButton.Enabled = true;
            }
            if (shownLines == textLine - 2)
            {
                downButton.Enabled = false;
            }
            pictureBox1.Refresh();
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            if (shownLines > 0)
            {
                shownLines--;
                downButton.Enabled = true;
            }
            if (shownLines == 0)
            {
                upButton.Enabled = false;
            }
            pictureBox1.Refresh();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var sf = new SaveFileDialog())
            {
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    byte[] data = new byte[0x1000];
                    for (int i = 0; i < 0x1000; i++)
                    {
                        data[i] = ROM.DATA[Constants.gfx_font + i];
                    }
                    using (var fs = new FileStream(sf.FileName, FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        fs.Write(data, 0, 0x1000);
                        fs.Write(widthArray, 0, 100);
                        fs.Close();
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var of = new OpenFileDialog())
            {
                if (of.ShowDialog() == DialogResult.OK)
                {
                    byte[] data = new byte[0x1000 + 100];
                    using (var fs = new FileStream(of.FileName, FileMode.Open, FileAccess.Read))
                    {
                        fs.Read(data, 0, 0x1000 + 100);
                        fs.Close();
                    }
                    for (int i = 0; i < 0x1000; i++)
                    {
                        ROM.DATA[Constants.gfx_font + i] = data[i];
                    }
                    for (int i = 0; i < 100; i++)
                    {
                        ROM.DATA[Constants.characters_width + i] = data[i + 0x1000];
                    }

                    GFX.CreateFontGfxData(ROM.DATA);
                    pictureBox2.Refresh();
                }
            }
        }

        public bool save()
        {

            byte[] backup = (byte[])ROM.DATA.Clone();
            for (int i = 0; i < 100; i++)
            {
                ROM.DATA[Constants.characters_width + i] = widthArray[i];
            }

            savedBytes.Clear();
            setTextsDictionaries();
            for (int i = 0; i < savedTexts.Count; i++)
            {
                savedBytes.Add(parseTextToBytes(savedTexts[i]));
            }
            int pos = Constants.text_data;
            bool expandedRegion = false;
            bool first = false;
            bool second = false;
            for (int i = 0; i < savedTexts.Count; i++)
            {

                foreach (byte b in savedBytes[i])
                {



                    if (expandedRegion == false)
                    {
                        if (pos > Constants.text_data + 0x8000)
                        {
                            
                            first = true;
                        }
                    }
                    else
                    {
                        if (pos > Constants.text_data2 + 0x14BF)
                        {
                            second = false;
                        }
                    }



                    ROM.DATA[pos] = b;
                    if (b == 0x80)
                    {
                        if (first)
                        {
                            MessageBox.Show("Too many text data in 1st group impossible to save Available Space = 0x8000, Used Space = " + (pos - 0xE0000).ToString("X4"));
                            ROM.DATA = (byte[])backup.Clone();
                            return true;
                        }
                        pos += 1;
                        while (pos < Constants.text_data + 0x8000)
                        {
                            //ROM.DATA[pos] = 0xFF;
                            pos++;
                        }
                        pos = Constants.text_data2 - 1;

                        expandedRegion = true;
                    }
                    pos++;
                }
                ROM.DATA[pos] = 0x7F;
                pos++;


            }
            ROM.DATA[pos] = 0xFF;
            while (pos < Constants.text_data2 + 0x14BF)
            {
                
                pos++;
            }


            if (second)
            {
                MessageBox.Show("Too many text data in 1st group impossible to save Available Space = 0x8000, Used Space = " + (pos - 0xE0000).ToString("X4"));
                ROM.DATA = (byte[])backup.Clone();
                return true;
            }
            return false;



        }
        bool fromForm = false;
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (fromForm == false)
            {
                widthArray[selectedTile] = (byte)numericUpDown1.Value;
            }
        }

        int selectedTile = 0;
        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            selectedTile = (e.X / 16) + ((e.Y / 32) * 16);
            if (selectedTile >= 98)
            {
                selectedTile = 98;
            }
            fromForm = true;
            numericUpDown1.Value = widthArray[selectedTile];
            fromForm = false;
            pictureBox2.Refresh();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (fromForm == false)
            {
                listOfTexts[(int)(textListbox.SelectedItem as ListViewItem).Tag].text = textBox1.Text;
                setTextsDictionaries();
                savedBytes[(int)(textListbox.SelectedItem as ListViewItem).Tag] = parseTextToBytes(textBox1.Text);
                drawTextPreview();
                pictureBox1.Refresh();
            }
        }
        string[] tcommands = new string[]
        {
            "[WIN",
            "[NBR",
            "[POS",
            "[SSD",
            "[COL",
            "[WAI",
            "[SND",
            "[SPD",
            "[DIC",
            "[IMG]",
            "[CHS]",
            "[ITM]",
            "[NAM]",
            "[SEL]",
            "[???]",
            "[CH2]",
            "[CH3]",
            "[SCL]",
            "[LN1]",
            "[LN2]",
            "[LN3]",
            "[WFK]",
            "[NNN]"
        };
        private void button1_Click(object sender, EventArgs e)
        {
            int textboxPos = textBox1.SelectionStart;
            TextCommands textCommands = new TextCommands();
            if (textCommands.ShowDialog() == DialogResult.OK)
            {

                string textAdd = "";
                textAdd = tcommands[textCommands.selectedCommand];
                if (textCommands.selectedCommand <= 8)
                {
                    textAdd += textCommands.cvalue.ToString("D2") + "]";
                }
                fromForm = true;
                textBox1.Text = textBox1.Text.Insert(textboxPos, textAdd);
                listOfTexts[textListbox.SelectedIndex].text = textBox1.Text;
                setTextsDictionaries();
                savedBytes[textListbox.SelectedIndex] = parseTextToBytes(textBox1.Text);
                drawTextPreview();
                pictureBox1.Refresh();
                fromForm = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DictionariesForm df = new DictionariesForm();
            df.listBox1.Items.Clear();
            int i = 0;
            foreach (string s in dictionaries)
            {

                df.listBox1.Items.Add(i.ToString("D2") + " : " + s.Replace(" ", "[Space]"));
                i++;
            }
            df.ShowDialog();
        }

        private void dumpTextsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] alltexts = new string[listOfTexts.Count];
            for (int i = 0; i < listOfTexts.Count; i++)
            {
                alltexts[i] = i.ToString("D3") + " :" + listOfTexts[i].text + "\r\n\r\n";

            }
            File.WriteAllLines("dump.txt", alltexts);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                ROM.DATA[Constants.characters_width + i] = widthArray[i];
            }

            using (var fs = new FileStream(romname, FileMode.OpenOrCreate, FileAccess.Write))
            {
                fs.Write(ROM.DATA, 0, ROM.DATA.Length);
                fs.Close();
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog of = new OpenFileDialog())
            {
                of.DefaultExt = ".txt";
                if (of.ShowDialog() == DialogResult.OK)
                {
                    
                    string[] alltexts = File.ReadAllLines(of.FileName);
                    for (int i = 0; i < alltexts.Length; i++)
                    {
                        if (alltexts[i].Length > 3)
                        {
                            int id = int.Parse(alltexts[i].Substring(0, 3));
                            listOfTexts[id] = new StringKey(alltexts[i].Substring(5, alltexts[i].Length - 5), new byte[] { });
                        }
                    }
                    sortText();
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sf = new SaveFileDialog())
            {
                sf.DefaultExt = ".txt";
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    string[] alltexts = new string[listOfTexts.Count];
                    for (int i = 0; i < listOfTexts.Count; i++)
                    {
                        alltexts[i] = i.ToString("D3") + " :" + listOfTexts[i].text + "\r\n\r\n";

                    }
                    File.WriteAllLines(sf.FileName, alltexts);
                }
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
