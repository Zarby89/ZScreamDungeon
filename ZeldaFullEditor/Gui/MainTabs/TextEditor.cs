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

namespace ZeldaFullEditor {
    public partial class TextEditor : UserControl {
        int[] addrTexts = new int[500];
        byte[] widthArray = new byte[100];
        List<StringKey> listOfTexts = new List<StringKey>();
        int defaultColor = 6;

        List<string> savedTexts = new List<string>();
        List<byte[]> savedBytes = new List<byte[]>();
        public List<string> dictionaries = new List<string>();
        public List<byte[]> dictionaries_bytes = new List<byte[]>();

        int[] dictionariesOrder = new int[97];

        string romname = "";

        int textLine = 0;

        int textPos = 0;
        bool skipNext = false;

        int shownLines = 0;

        bool fromForm = false;

        int selectedTile = 0;

        public static string[] tcommands = new string[]
        {
            "[W",
            "[N",
            "[P",
            "[SSD",
            "[C",
            "[K",
            "[Z",
            "[S",
            "[D",
            "[I",
            "[CH4",
            "[T",
            "[L",
            "[SEL",
            "[???",
            "[CH2",
            "[CH3",
            "[SCL",
            "[1",
            "[2",
            "[3",
            "[K",
            "[NNN"
       };

        public static string[] commandDesc = new string[] {
            "Window type",
            "BCD number",
            "Set position",
            "Scroll speed",
            "Set color",
            "Delay X",
            "Sound effect",
            "Speed", // TODO better description
            "Dictionary",
            "Swap image", // TODO better description
            "Choose", // TODO better description
            "Item choice",
            "Player name", // TODO better description
            "Selection", // TODO better description
            "Crash",
            "Choose2", // TODO better description
            "Choose3", // TODO better description
            "Scroll", // TODO better description
            "Line 1",
            "Line 2",
            "Line 3",
            "Wait", // TODO better description
            "Bank marker"
        };

        public static int MaxParamCommand = 8;

        public static string[] GetTextCommands() {
            string[] ret = new string[tcommands.Length];
            for (int i = 0; i < tcommands.Length; i++) {
                if (i <= MaxParamCommand) {
                    ret[i] = string.Format("{0}:#] {1}", tcommands[i], commandDesc[i]);
                } else {
                    ret[i] = string.Format("{0}] {1}", tcommands[i], commandDesc[i]);
                }
            }
            return ret;
        }


        public TextEditor() {
            InitializeComponent();
            this.TextCommandList.Items.AddRange(TextEditor.GetTextCommands());
        }

        private void TextEditor_Load(object sender, EventArgs e) {
            //TODO: Add something here?
        }

        public void readAllText() {
            int tt = 0;
            byte b = 0;
            int pos = Constants.text_data;
            bool endReached = false;
            string tempString = "";
            List<byte> tempBytes = new List<byte>();

            while (true) {
                b = ROM.DATA[pos];
                tempBytes.Add(b);
                string s = readNextTextByte(b);

                if (s == tcommands[0x00] || s == tcommands[0x01] || s == tcommands[0x02] ||
                    s == tcommands[0x03] || s == tcommands[0x04] || s == tcommands[0x05] ||
                    s == tcommands[0x06] || s == tcommands[0x07]) {

                    s += ":";
                    s += ROM.DATA[++pos].ToString("X2");
                    s += "]";
                } else if (s == tcommands[0x16] + "]") {
                    tempString += s;
                    pos = Constants.text_data2;
                    continue;
                } else if (s.Length > tcommands[0x08].Length && s.Substring(0, tcommands[0x08].Length) == tcommands[0x08]) {
                    string nbr = s.Substring(tcommands[0x08].Length, 2);
                    int nbrint = 0;
                    int addr = 0;

                    if (int.TryParse(nbr, out nbrint)) {
                        s = "";
                        //nbrint = 1;
                        addr = Utils.SnesToPc((0x0E << 16) +
                            (ROM.DATA[Constants.pointers_dictionaries + (nbrint * 2) + 1] << 8) +
                            ROM.DATA[Constants.pointers_dictionaries + (nbrint * 2)]
                        );

                        int tempaddr = Utils.SnesToPc((0x0E << 16) +
                            (ROM.DATA[Constants.pointers_dictionaries + ((nbrint + 1) * 2) + 1] << 8) +
                            ROM.DATA[Constants.pointers_dictionaries + ((nbrint + 1) * 2)]
                        );

                        while (addr < tempaddr) {
                            byte bdictionary = ROM.DATA[addr];
                            tempBytes.Add(bdictionary);
                            string ds = readNextTextByte(bdictionary);
                            s += ds;
                            addr++;
                        }
                    }

                    addr++;
                }

                //text_dictionaries
                tempString += s;
                pos++;

                if (b == 0x7F) {
                    listOfTexts.Add(new StringKey(tempString, tempBytes.ToArray()));
                    tempBytes.Clear();
                    tempString = "";
                    addrTexts[tt] = pos;
                    tt++;
                    continue;
                } else if (b == 0xFF) {
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

        public void buildDictionaries() {
            for (int i = 0; i < 97; i++) {
                int addr = 0;
                List<byte> bytes = new List<byte>();
                string s = "";
                //nbrint = 1;

                addr = Utils.SnesToPc((0x0E << 16) +
                    (ROM.DATA[Constants.pointers_dictionaries + (i * 2) + 1] << 8) +
                    ROM.DATA[Constants.pointers_dictionaries + (i * 2)]
                );

                int tempaddr = Utils.SnesToPc((0x0E << 16) +
                    (ROM.DATA[Constants.pointers_dictionaries + ((i + 1) * 2) + 1] << 8) +
                    ROM.DATA[Constants.pointers_dictionaries + ((i + 1) * 2)]
                );

                while (addr < tempaddr) {
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

            for (int i = 0; i < 97; i++) {
                dictionariesOrder[i] = dictionaries.FindIndex(x => x == orderedDictionary[i]);
            }
        }

        public void setTextsDictionaries() {
            savedTexts.Clear();
            //this function scan for keyword existing in dictionaries
            //if we find one replace that text by [DICXX]
            foreach (StringKey texts in listOfTexts) {
                string s = texts.text;

                for (int i = 96; i >= 0; i--) {
                    s = s.Replace(dictionaries[dictionariesOrder[i]], tcommands[0x08] + ":" + dictionariesOrder[i].ToString("D2") + "]");
                }

                savedTexts.Add(s);
            }
        }

        public byte[] parseTextToBytes(string fullString) {
            defaultColor = 6;
            List<byte> bytes = new List<byte>();
            string s = fullString;

            while (s.Length > 0) {
                if (s[0] == '[') //this is a command parsecommand
                {
                    StringByte sb = parseCommand(s);
                    if (sb.s != "ERROR") {
                        foreach (byte b in sb.bytes) {
                            bytes.Add(b);
                        }
                        s = sb.s;
                        //Console.WriteLine("CMD FOUND : " + s);
                    } else {
                        break;
                    }

                    continue;
                } else if ((byte) s[0] <= 0x39 && (byte) s[0] >= 0x30) //numbers
                  {
                    bytes.Add((byte) ((s[0] - 48) + 52));
                } else if ((byte) s[0] <= 0x5A && (byte) s[0] > 0x40) //capital letter
                  {
                    bytes.Add((byte) (s[0] - 65));
                } else if ((char) s[0] <= 0x7A && (byte) s[0] > 0x5A) //small letters
                  {
                    bytes.Add((byte) ((s[0] - 97) + 26));
                } else if (s[0] == '!') { bytes.Add(0x3E); } else if (s[0] == '?') { bytes.Add(0x3F); } else if (s[0] == '-') { bytes.Add(0x40); } else if (s[0] == '.') { bytes.Add(0x41); } else if (s[0] == ',') { bytes.Add(0x42); } else if (s[0] == '…') { bytes.Add(0x43); } else if (s[0] == '>') { bytes.Add(0x44); } else if (s[0] == '(') { bytes.Add(0x45); } else if (s[0] == ')') { bytes.Add(0x46); } else if (s[0] == '"') { bytes.Add(0x4C); } else if (s[0] == '↑') { bytes.Add(0x4D); } else if (s[0] == '↓') { bytes.Add(0x4E); } else if (s[0] == '←') { bytes.Add(0x4F); } else if (s[0] == '→') { bytes.Add(0x50); } else if (s[0] == '\'') { bytes.Add(0x51); } else if (s[0] == ' ') { bytes.Add(0x59); } else if (s[0] == '<') { bytes.Add(0x5A); } else if (s[0] == 'Ⓐ') { bytes.Add(0x5B); } else if (s[0] == 'Ⓑ') { bytes.Add(0x5C); } else if (s[0] == 'ⓧ') { bytes.Add(0x5D); } else if (s[0] == 'ⓨ') { bytes.Add(0x5E); } else if (s[0] == '¡') { bytes.Add(0x5F); } else if (s[0] == '¡') { bytes.Add(0x60); } else if (s[0] == '¡') { bytes.Add(0x61); } else if (s[0] == ' ') { bytes.Add(0x62); } else if (s[0] == ' ') { bytes.Add(0x63); } else if (s[0] == ' ') { bytes.Add(0x64); } else if (s[0] == ' ') { bytes.Add(0x65); } else if (s[0] == '_') { bytes.Add(0x66); }
                s = s.Substring(1);
            }

            return bytes.ToArray();
        }

        public StringByte parseCommand(string fullString) {
            if (fullString.Length >= 2) {
                string cmdstring = fullString.Substring(0, 4); //[ + cmd
                string argstring = "";
                int arg = 0;
                if (fullString.Length >= 7) {
                    argstring = fullString.Substring(4, 2);
                    int.TryParse(argstring, out arg);
                }
                //[WIN00]

                if (cmdstring == tcommands[0x00]) {
                    if (fullString.Length >= 7) {
                        return new StringByte(fullString.Substring(7), new byte[] { 0x6B, (byte) arg });
                    }
                } else if (cmdstring == tcommands[0x01]) {
                    if (fullString.Length >= 7) {
                        return new StringByte(fullString.Substring(7), new byte[] { 0x6C, (byte) arg });
                    }
                } else if (cmdstring == tcommands[0x02]) {
                    if (fullString.Length >= 7) {
                        return new StringByte(fullString.Substring(7), new byte[] { 0x6D, (byte) arg });
                    }
                } else if (cmdstring == tcommands[0x03]) {
                    if (fullString.Length >= 7) {
                        return new StringByte(fullString.Substring(7), new byte[] { 0x6E, (byte) arg });
                    }
                } else if (cmdstring == tcommands[0x04]) {
                    if (fullString.Length >= 7) {
                        defaultColor = arg;
                        return new StringByte(fullString.Substring(7), new byte[] { 0x77, (byte) arg });
                    }
                } else if (cmdstring == tcommands[0x05]) {
                    if (fullString.Length >= 8) {
                        return new StringByte(fullString.Substring(7), new byte[] { 0x78, (byte) arg });
                    }
                } else if (cmdstring == tcommands[0x06]) {
                    if (fullString.Length >= 8) {
                        return new StringByte(fullString.Substring(7), new byte[] { 0x79, (byte) arg });
                    }
                } else if (cmdstring == tcommands[0x07]) {
                    if (fullString.Length >= 8) {
                        return new StringByte(fullString.Substring(7), new byte[] { 0x7A, (byte) arg });
                    }
                }

                  //97 entries
                  else if (cmdstring == tcommands[0x08]) { return new StringByte(fullString.Substring(7), new byte[] { (byte) (0x88 + (byte) arg) }); } else if (cmdstring == "[HY0") { return new StringByte(fullString.Substring(5), new byte[] { 0x47 }); } else if (cmdstring == "[HY1") { return new StringByte(fullString.Substring(5), new byte[] { 0x48 }); } else if (cmdstring == "[HY2") { return new StringByte(fullString.Substring(5), new byte[] { 0x49 }); } else if (cmdstring == "[LHL") { return new StringByte(fullString.Substring(5), new byte[] { 0x4A }); } else if (cmdstring == "[LHR") { return new StringByte(fullString.Substring(5), new byte[] { 0x4B }); } else if (cmdstring == "[HP0") { return new StringByte(fullString.Substring(5), new byte[] { 0x52 }); } else if (cmdstring == "[HP1") { return new StringByte(fullString.Substring(5), new byte[] { 0x53 }); } else if (cmdstring == "[HP2") { return new StringByte(fullString.Substring(5), new byte[] { 0x54 }); } else if (cmdstring == "[HP3") { return new StringByte(fullString.Substring(5), new byte[] { 0x55 }); } else if (cmdstring == "[HP4") { return new StringByte(fullString.Substring(5), new byte[] { 0x56 }); } else if (cmdstring == "[HP5") { return new StringByte(fullString.Substring(5), new byte[] { 0x57 }); } else if (cmdstring == "[HP6") { return new StringByte(fullString.Substring(5), new byte[] { 0x58 }); } else if (cmdstring == tcommands[0x09]) { return new StringByte(fullString.Substring(5), new byte[] { 0x67 }); } else if (cmdstring == tcommands[0x0A]) { return new StringByte(fullString.Substring(5), new byte[] { 0x68 }); } else if (cmdstring == tcommands[0x0B]) { return new StringByte(fullString.Substring(5), new byte[] { 0x69 }); } else if (cmdstring == tcommands[0x0C]) { return new StringByte(fullString.Substring(5), new byte[] { 0x6A }); } else if (cmdstring == tcommands[0x0D]) { return new StringByte(fullString.Substring(5), new byte[] { 0x6F }); } else if (cmdstring == tcommands[0x0E]) { return new StringByte(fullString.Substring(5), new byte[] { 0x70 }); } else if (cmdstring == tcommands[0x0F]) { return new StringByte(fullString.Substring(5), new byte[] { 0x71 }); } else if (cmdstring == tcommands[0x10]) { return new StringByte(fullString.Substring(5), new byte[] { 0x72 }); } else if (cmdstring == tcommands[0x11]) { return new StringByte(fullString.Substring(5), new byte[] { 0x73 }); } else if (cmdstring == tcommands[0x12]) { return new StringByte(fullString.Substring(5), new byte[] { 0x74 }); } else if (cmdstring == tcommands[0x13]) { return new StringByte(fullString.Substring(5), new byte[] { 0x75 }); } else if (cmdstring == tcommands[0x14]) { return new StringByte(fullString.Substring(5), new byte[] { 0x76 }); } else if (cmdstring == tcommands[0x15]) { return new StringByte(fullString.Substring(5), new byte[] { 0x7E }); } else if (cmdstring == tcommands[0x16]) { return new StringByte(fullString.Substring(5), new byte[] { 0x80 }); }
            }

            return new StringByte("ERROR", new byte[] { 0x7F });
        }

        public static Dictionary<byte, string> CharEncoder = new Dictionary<byte, string> {
                { 0x00, "A" },
                { 0x01, "B" },
                { 0x02, "C" },
                { 0x03, "D" },
                { 0x04, "E" },
                { 0x05, "F" },
                { 0x06, "G" },
                { 0x07, "H" },
                { 0x08, "I" },
                { 0x09, "J" },
                { 0x0A, "K" },
                { 0x0B, "L" },
                { 0x0C, "M" },
                { 0x0D, "N" },
                { 0x0E, "O" },
                { 0x0F, "P" },
                { 0x10, "Q" },
                { 0x11, "R" },
                { 0x12, "S" },
                { 0x13, "T" },
                { 0x14, "U" },
                { 0x15, "V" },
                { 0x16, "W" },
                { 0x17, "X" },
                { 0x18, "Y" },
                { 0x19, "Z" },
                { 0x1A, "a" },
                { 0x1B, "b" },
                { 0x1C, "c" },
                { 0x1D, "d" },
                { 0x1E, "e" },
                { 0x1F, "f" },
                { 0x20, "g" },
                { 0x21, "h" },
                { 0x22, "i" },
                { 0x23, "j" },
                { 0x24, "k" },
                { 0x25, "l" },
                { 0x26, "m" },
                { 0x27, "n" },
                { 0x28, "o" },
                { 0x29, "p" },
                { 0x2A, "q" },
                { 0x2B, "r" },
                { 0x2C, "s" },
                { 0x2D, "t" },
                { 0x2E, "u" },
                { 0x2F, "v" },
                { 0x30, "w" },
                { 0x31, "x" },
                { 0x32, "y" },
                { 0x33, "z" },
                { 0x34, "0" },
                { 0x35, "1" },
                { 0x36, "2" },
                { 0x37, "3" },
                { 0x38, "4" },
                { 0x39, "5" },
                { 0x3A, "6" },
                { 0x3B, "7" },
                { 0x3C, "8" },
                { 0x3D, "9" },
                { 0x3E, "!" },
                { 0x3F, "?" },
                { 0x40, "-" },
                { 0x41, "." },
                { 0x42, "," },
                { 0x43, "…" },
                { 0x44, ">" },
                { 0x45, "(" },
                { 0x46, ")" },
                { 0x47, "[HY0]" },
                { 0x48, "[HY1]" },
                { 0x49, "[HY2]" },
                { 0x4A, "[LHL]" },
                { 0x4B, "[LHR]" },
                { 0x4C, "\"" },
                { 0x4D, "↑" },
                { 0x4E, "↓" },
                { 0x4F, "←" },
                { 0x50, "→" },
                { 0x51, "'" },
                { 0x52, "[HP0]" },
                { 0x53, "[HP1]" },
                { 0x54, "[HP2]" },
                { 0x55, "[HP3]" },
                { 0x56, "[HP4]" },
                { 0x57, "[HP5]" },
                { 0x58, "[HP6]" },
                { 0x59, " " },
                { 0x5A, "<" },
                { 0x5B, "[A]" },
                { 0x5C, "[B]" },
                { 0x5D, "[X]" },
                { 0x5E, "[Y]" },
                { 0x5F, "¡" },
                { 0x60, "¡" },
                { 0x61, "¡" },
                { 0x62, " " },
                { 0x63, " " },
                { 0x64, " " },
                { 0x65, " " },
                { 0x66, "_" },
                { 0x67, "" },
                { 0x68, "" },
                { 0x69, "" },
                { 0x6A, "" },
                { 0x6B, "" },
                { 0x6C, "" },
                { 0x6D, "" },
                { 0x6E, "" },
                { 0x6F, "" },
                { 0x70, "" },
                { 0x71, "" },
                { 0x72, "" },
                { 0x73, "" },
                { 0x74, "" },
                { 0x75, "" },
                { 0x76, "" },
                { 0x77, "" },
                { 0x78, "" },
                { 0x79, "" },
                { 0x7A, "" },
                { 0x7B, "" },
                { 0x7C, "" },
                { 0x7D, "" },
                { 0x7E, "" },
                { 0x7F, "" },
                { 0x80, "" },
                { 0x81, "" },
                { 0x82, "" },
                { 0x83, "" },
                { 0x84, "" },
                { 0x85, "" },
                { 0x86, "" },
                { 0x87, "" },
                { 0x88, "[D00]" },
                { 0x89, "[D01]" },
                { 0x8A, "[D02]" },
                { 0x8B, "[D03]" },
                { 0x8C, "[D04]" },
                { 0x8D, "[D05]" },
                { 0x8E, "[D06]" },
                { 0x8F, "[D07]" },
                { 0x90, "[D08]" },
                { 0x91, "[D09]" },
                { 0x92, "[D0A]" },
                { 0x93, "[D0B]" },
                { 0x94, "[D0C]" },
                { 0x95, "[D0D]" },
                { 0x96, "[D0E]" },
                { 0x97, "[D0F]" },
                { 0x98, "[D10]" },
                { 0x99, "[D11]" },
                { 0x9A, "[D12]" },
                { 0x9B, "[D13]" },
                { 0x9C, "[D14]" },
                { 0x9D, "[D15]" },
                { 0x9E, "[D16]" },
                { 0x9F, "[D17]" },
                { 0xA0, "[D18]" },
                { 0xA1, "[D19]" },
                { 0xA2, "[D1A]" },
                { 0xA3, "[D1B]" },
                { 0xA4, "[D1C]" },
                { 0xA5, "[D1D]" },
                { 0xA6, "[D1E]" },
                { 0xA7, "[D1F]" },
                { 0xA8, "[D20]" },
                { 0xA9, "[D21]" },
                { 0xAA, "[D22]" },
                { 0xAB, "[D23]" },
                { 0xAC, "[D24]" },
                { 0xAD, "[D25]" },
                { 0xAE, "[D26]" },
                { 0xAF, "[D27]" },
                { 0xB0, "[D28]" },
                { 0xB1, "[D29]" },
                { 0xB2, "[D2A]" },
                { 0xB3, "[D2B]" },
                { 0xB4, "[D2C]" },
                { 0xB5, "[D2D]" },
                { 0xB6, "[D2E]" },
                { 0xB7, "[D2F]" },
                { 0xB8, "[D30]" },
                { 0xB9, "[D31]" },
                { 0xBA, "[D32]" },
                { 0xBB, "[D33]" },
                { 0xBC, "[D34]" },
                { 0xBD, "[D35]" },
                { 0xBE, "[D36]" },
                { 0xBF, "[D37]" },
                { 0xC0, "[D38]" },
                { 0xC1, "[D39]" },
                { 0xC2, "[D3A]" },
                { 0xC3, "[D3B]" },
                { 0xC4, "[D3C]" },
                { 0xC5, "[D3D]" },
                { 0xC6, "[D3E]" },
                { 0xC7, "[D3F]" },
                { 0xC8, "[D40]" },
                { 0xC9, "[D41]" },
                { 0xCA, "[D42]" },
                { 0xCB, "[D43]" },
                { 0xCC, "[D44]" },
                { 0xCD, "[D45]" },
                { 0xCE, "[D46]" },
                { 0xCF, "[D47]" },
                { 0xD0, "[D48]" },
                { 0xD1, "[D49]" },
                { 0xD2, "[D4A]" },
                { 0xD3, "[D4B]" },
                { 0xD4, "[D4C]" },
                { 0xD5, "[D4D]" },
                { 0xD6, "[D4E]" },
                { 0xD7, "[D4F]" },
                { 0xD8, "[D50]" },
                { 0xD9, "[D51]" },
                { 0xDA, "[D52]" },
                { 0xDB, "[D53]" },
                { 0xDC, "[D54]" },
                { 0xDD, "[D55]" },
                { 0xDE, "[D56]" },
                { 0xDF, "[D57]" },
                { 0xE0, "[D58]" },
                { 0xE1, "[D59]" },
                { 0xE2, "[D5A]" },
                { 0xE3, "[D5B]" },
                { 0xE4, "[D5C]" },
                { 0xE5, "[D5D]" },
                { 0xE6, "[D5E]" },
                { 0xE7, "[D5F]" },
                { 0xE8, "[D60]" },
                { 0xE9, "[D61]" },
                { 0xEA, "[D62]" },
                { 0xEB, "[D63]" },
                { 0xEC, "[D64]" },
                { 0xED, "[D65]" },
                { 0xEE, "[D66]" },
                { 0xEF, "[D67]" },
                { 0xF0, "[D68]" },
                { 0xF1, "[D69]" },
                { 0xF2, "[D6A]" },
                { 0xF3, "[D6B]" },
                { 0xF4, "[D6C]" },
                { 0xF5, "[D6D]" },
                { 0xF6, "[D6E]" },
                { 0xF7, "[D6F]" },
                { 0xF8, "[D70]" },
                { 0xF9, "[D71]" },
                { 0xFA, "[D72]" },
                { 0xFB, "[D73]" },
                { 0xFC, "[D74]" },
                { 0xFD, "[D75]" },
                { 0xFE, "[D76]" },
        };
        public string readNextTextByte(byte b) {
            if (b == 0x80) //switch to 2nd sets of messages
            {
                return tcommands[0x16] + "]";
            } else if (b <= 0x66)  // literals
            {
                return CharEncoder[b];
            } else if (b >= 0x67 && b <= 0x7A) // commands
            {
                byte b2;
                switch (b) { // TODO having to remap this is stupid
                    case 0x67: b2 = 0x09; break;
                    case 0x68: b2 = 0x0A; break;
                    case 0x69: b2 = 0x0B; break;
                    case 0x6A: b2 = 0x0C; break;
                    case 0x6B: b2 = 0x00; break;
                    case 0x6C: b2 = 0x01; break;
                    case 0x6D: b2 = 0x02; break;
                    case 0x6E: b2 = 0x03; break;
                    case 0x6F: b2 = 0x0D; break;
                    case 0x70: b2 = 0x0E; break;
                    case 0x71: b2 = 0x0F; break;
                    case 0x72: b2 = 0x10; break;
                    case 0x73: b2 = 0x11; break;
                    case 0x74: b2 = 0x12; break;
                    case 0x75: b2 = 0x13; break;
                    case 0x76: b2 = 0x14; break;
                    case 0x77: b2 = 0x04; break;
                    case 0x78: b2 = 0x05; break;
                    case 0x79: b2 = 0x06; break;
                    case 0x7A: b2 = 0x07; break;
                    default: return "";
				}
                if (b2 <= MaxParamCommand) {
                    return tcommands[b2];
				} else {
                    return tcommands[b2] + "]";
				}
            } else if (b == 0x7E)
            {
               return tcommands[0x15] + "]";
            } else if (b >= 0x88) // glossary
            {
                return tcommands[0x08] + (b - 0x88).ToString("D2") + "]";
            }

            return "";

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e) {
            //TODO: Add Something here?

            /* 
            OpenFileDialog of = new OpenFileDialog();
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

        public void initOpen() {
            panel1.Enabled = true;
            for (int i = 0; i < 100; i++) {
                widthArray[i] = ROM.DATA[Constants.characters_width + i];
            }

            GFX.fontgfxBitmap = new Bitmap(128, 128, 64, PixelFormat.Format4bppIndexed, GFX.fontgfx16Ptr);
            GFX.currentfontgfx16Bitmap = new Bitmap(172, 4096, 172, PixelFormat.Format8bppIndexed, GFX.currentfontgfx16Ptr);
            string[] alllines = new string[255];

            readAllText();
            savedBytes.Clear();
            buildDictionaries();
            setTextsDictionaries();

            for (int i = 0; i < savedTexts.Count; i++) {
                savedBytes.Add(parseTextToBytes(savedTexts[i]));
            }

            textListbox.BeginUpdate();
            textListbox.Items.Clear();

            for (int i = 0; i < listOfTexts.Count; i++) {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = i.ToString("X3") + " : " + listOfTexts[i].text;
                lvi.Tag = i;
                textListbox.Items.Add(lvi);
            }

            textListbox.EndUpdate();
            textListbox.DisplayMember = "Text";
            pictureBox2.Refresh();

            GFX.CreateFontGfxData(ROM.DATA);
        }

        private void textListbox_SelectedIndexChanged(object sender, EventArgs e) {
            StringKey sk = listOfTexts[(int) (textListbox.Items[textListbox.SelectedIndex] as ListViewItem).Tag];
            //Console.WriteLine(savedTexts[textListbox.SelectedIndex]);
            /*for (int i = 0; i < savedBytes[textListbox.SelectedIndex].Length; i++)
            {
                Console.Write(savedBytes[textListbox.SelectedIndex][i].ToString("X2") + " ");
            }*/
            //Console.WriteLine();
            textBox1.Text = sk.text;

            drawTextPreview();
            label9.Text = "Address: " + addrTexts[textListbox.SelectedIndex].ToString("X6");

            pictureBox1.Refresh();
        }

        public unsafe void drawLetter(byte b) {
            if (skipNext) {
                skipNext = false;
                return;

            }

            int srcy = 0;
            int srcx = 0;
            if (b < 100) {
                srcy = ((b / 16));
                srcx = b - ((b / 16) * 16);

                if (textPos >= 170) {
                    textPos = 0;
                    textLine++;
                }
                draw_item_tile(textPos, textLine * 16, srcx, srcy, 0, false, false, 1, 2);
                textPos += widthArray[b];
            } else if (b == 0x74) { textPos = 0; textLine = 0; } else if (b == 0x73) { textPos = 0; textLine += 1; } else if (b == 0x75) { textPos = 0; textLine = 1; } else if (b == 0x6B) { skipNext = true; return; } else if (b == 0x6C) { skipNext = true; return; } else if (b == 0x6D) { skipNext = true; return; } else if (b == 0x6E) { skipNext = true; return; } else if (b == 0x77) { skipNext = true; return; } else if (b == 0x78) { skipNext = true; return; } else if (b == 0x79) { skipNext = true; return; } else if (b == 0x7A) { skipNext = true; return; } else if (b == 0x76) { textPos = 0; textLine = 2; } else if (b == 0x6A) {
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
            } else if (b >= 0x88 && b <= (0x88 + 97)) {
                byte bdict = (byte) (b - 0x88);
                foreach (byte bd in dictionaries_bytes[bdict]) {
                    drawLetter(bd);
                }
            }
        }

        public unsafe void drawTextPreview() //From Parsing
        {
            //defaultColor = 6;
            textLine = 0;
            byte* ptr = (byte*) GFX.currentfontgfx16Ptr.ToPointer();
            for (int i = 0; i < (172 * 4096); i++) {
                ptr[i] = 0;
            }

            textPos = 0;
            int t = 0;
            foreach (byte b in savedBytes[(int) (textListbox.SelectedItem as ListViewItem).Tag]) {
                drawLetter(b);
            }

            shownLines = 0;
            upButton.Enabled = false;

            if (textLine > 2) {
                downButton.Enabled = true;
            } else {
                downButton.Enabled = false;
            }
        }

        public unsafe void draw_item_tile(int x, int y, int srcx, int srcy, int pal, bool mirror_x = false, bool mirror_y = false, int sizex = 1, int sizey = 1) {
            var alltilesData = (byte*) GFX.fontgfx16Ptr.ToPointer();

            byte* ptr = (byte*) GFX.currentfontgfx16Ptr.ToPointer();

            int drawid = (srcx + (srcy * 32));
            for (var yl = 0; yl < sizey * 8; yl++) {
                for (var xl = 0; xl < 4; xl++) {
                    int mx = xl;
                    int my = yl;
                    byte r = 0;

                    //Formula information to get tile index position in the array
                    //((ID / nbrofXtiles) * (imgwidth/2) + (ID - ((ID/16)*16) ))
                    int tx = ((drawid / 16) * 512) + ((drawid - ((drawid / 16) * 16)) * 4);
                    var pixel = alltilesData[tx + (yl * 64) + xl];
                    //nx,ny = object position, xx,yy = tile position, xl,yl = pixel position
                    int index = (x) + (y * 172) + ((mx * 2) + (my * (172)));
                    if ((pixel & 0x0F) != 0) {
                        ptr[index + 1] = (byte) ((pixel & 0x0F) + (0 * 4));
                    }
                    if (((pixel >> 4) & 0x0F) != 0) {
                        ptr[index + 0] = (byte) (((pixel >> 4) & 0x0F) + (0 * 4));
                    }
                }
            }
        }

        private void searchTextbox_TextChanged(object sender, EventArgs e) {
            sortText();
        }

        public void sortText() {
            textListbox.BeginUpdate();
            textListbox.Items.Clear();
            //Sorting sort;
            string searchText = searchTextbox.Text.ToLower();
            //listView1
            StringKey[] texts = listOfTexts
                .Where(x => x != null)
                .Where(x => (x.text.ToLower().Contains(searchText)))
                .ToArray();

            foreach (StringKey s in texts) {
                for (int i = 0; i < listOfTexts.Count; i++) {
                    if (s.text == listOfTexts[i].text) {
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

        private void pictureBox2_Paint(object sender, PaintEventArgs e) {
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.DrawImage(GFX.fontgfxBitmap, new Rectangle(0, 0, 256, 256));
            int srcY = (selectedTile / 16);
            int srcX = selectedTile - (srcY * 16);
            e.Graphics.DrawRectangle(new Pen(Brushes.GreenYellow, 2), new Rectangle(srcX * 16, srcY * 32, 16, 32));
            label6.Text = "ID: " + selectedTile.ToString("X2");
            label7.Text = "ASCII: " + readNextTextByte((byte) selectedTile);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e) {
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            ColorPalette cp = GFX.currentfontgfx16Bitmap.Palette;

            for (int i = 0; i < 4; i++) {
                if (i == 0) {
                    cp.Entries[i] = Color.Transparent;
                } else {
                    cp.Entries[i] = GFX.roomBg1Bitmap.Palette.Entries[(defaultColor * 4) + i];

                }
            }

            GFX.currentfontgfx16Bitmap.Palette = cp;

            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.DrawImage(GFX.currentfontgfx16Bitmap, new Rectangle(0, 0, 340, pictureBox2.Height), new Rectangle(0, shownLines * 16, 170, pictureBox2.Height / 2), GraphicsUnit.Pixel);
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(128, 255, 0, 0)), new Rectangle(344 - 8, 0, 4, pictureBox2.Height));
        }

        private void downButton_Click(object sender, EventArgs e) {
            if (shownLines < textLine - 2) {
                shownLines++;
                upButton.Enabled = true;
            }
            if (shownLines == textLine - 2) {
                downButton.Enabled = false;
            }
            pictureBox1.Refresh();
        }

        private void upButton_Click(object sender, EventArgs e) {
            if (shownLines > 0) {
                shownLines--;
                downButton.Enabled = true;
            }
            if (shownLines == 0) {
                upButton.Enabled = false;
            }

            pictureBox1.Refresh();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e) {
            //TODO: Add something here?
        }

        private void button2_Click(object sender, EventArgs e) {
            using (var sf = new SaveFileDialog()) {
                if (sf.ShowDialog() == DialogResult.OK) {
                    byte[] data = new byte[0x1000];
                    for (int i = 0; i < 0x1000; i++) {
                        data[i] = ROM.DATA[Constants.gfx_font + i];
                    }
                    using (var fs = new FileStream(sf.FileName, FileMode.OpenOrCreate, FileAccess.Write)) {
                        fs.Write(data, 0, 0x1000);
                        fs.Write(widthArray, 0, 100);
                        fs.Close();
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e) {
            using (var of = new OpenFileDialog()) {
                if (of.ShowDialog() == DialogResult.OK) {
                    byte[] data = new byte[0x1000 + 100];
                    using (var fs = new FileStream(of.FileName, FileMode.Open, FileAccess.Read)) {
                        fs.Read(data, 0, 0x1000 + 100);
                        fs.Close();
                    }
                    for (int i = 0; i < 0x1000; i++) {
                        //ROM.DATA[Constants.gfx_font + i] = data[i];
                        ROM.Write(Constants.gfx_font + i, data[i], true, "Gfx Font");
                    }
                    for (int i = 0; i < 100; i++) {
                        //ROM.DATA[Constants.characters_width + i] = data[i + 0x1000];
                        ROM.Write(Constants.characters_width + i, data[i + 0x1000], true, "Gfx Width");
                    }

                    GFX.CreateFontGfxData(ROM.DATA);
                    pictureBox2.Refresh();
                }
            }
        }

        public bool save() {
            byte[] backup = (byte[]) ROM.DATA.Clone();
            for (int i = 0; i < 100; i++) {
                // ROM.DATA[Constants.characters_width + i] = widthArray[i];
                ROM.Write(Constants.characters_width + i, widthArray[i], true, "Gfx Width");
            }

            savedBytes.Clear();
            setTextsDictionaries();
            for (int i = 0; i < savedTexts.Count; i++) {
                savedBytes.Add(parseTextToBytes(savedTexts[i]));
            }

            int pos = Constants.text_data;
            bool expandedRegion = false;
            bool first = false;
            bool second = false;

            for (int i = 0; i < savedTexts.Count; i++) {
                foreach (byte b in savedBytes[i]) {
                    if (expandedRegion == false) {
                        if (pos > Constants.text_data + 0x8000) {
                            first = true;
                        }
                    } else {
                        if (pos > Constants.text_data2 + 0x14BF) {
                            second = false;
                        }
                    }


                    //ROM.DATA[pos] = b;
                    ROM.Write(pos, b, true, "Text Data");

                    if (b == 0x80) {
                        if (first) {
                            MessageBox.Show("Too much text data in 1st group to save;\nAvailable Space = 0x8000, Used Space = " + (pos - 0xE0000).ToString("X4"));
                            ROM.DATA = (byte[]) backup.Clone();
                            return true;
                        }

                        pos += 1;
                        while (pos < Constants.text_data + 0x8000) {
                            //ROM.DATA[pos] = 0xFF;
                            pos++;
                        }

                        pos = Constants.text_data2 - 1;

                        expandedRegion = true;
                    }
                    pos++;
                }

                // ROM.DATA[pos] = 0x7F;
                ROM.Write(pos, 0x7F, true, "Terminator text");
                pos++;
            }

            ROM.Write(pos, 0xFF, true, "End of text");
            //ROM.DATA[pos] = 0xFF;

            while (pos < Constants.text_data2 + 0x14BF) {
                pos++;
            }

            if (second) {
                MessageBox.Show("Too many text data in 1st group impossible to save Available Space = 0x8000, Used Space = " + (pos - 0xE0000).ToString("X4"));
                ROM.DATA = (byte[]) backup.Clone();
                return true;
            }

            return false;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e) {
            if (fromForm == false) {
                widthArray[selectedTile] = (byte) numericUpDown1.Value;
            }
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e) {
            selectedTile = (e.X / 16) + ((e.Y / 32) * 16);

            if (selectedTile >= 98) {
                selectedTile = 98;
            }

            fromForm = true;
            numericUpDown1.Value = widthArray[selectedTile];
            fromForm = false;
            pictureBox2.Refresh();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            if (fromForm == false) {
                listOfTexts[(int) (textListbox.SelectedItem as ListViewItem).Tag].text = textBox1.Text;
                setTextsDictionaries();
                savedBytes[(int) (textListbox.SelectedItem as ListViewItem).Tag] = parseTextToBytes(textBox1.Text);
                drawTextPreview();
                pictureBox1.Refresh();
            }
        }

        private void InsertCommandButton_Click_1(object sender, EventArgs e) {
            int textboxPos = textBox1.SelectionStart;
            string textAdd = tcommands[TextCommandList.SelectedIndex];

            if (TextCommandList.SelectedIndex <= MaxParamCommand) {
                Byte.TryParse(ParamsBox.Text, out byte par);

                textAdd += ":";
                textAdd += par.ToString("X2");
            }
            textAdd += "]";
            fromForm = true;
            textBox1.Text = textBox1.Text.Insert(textboxPos, textAdd);
            listOfTexts[textListbox.SelectedIndex].text = textBox1.Text;
            setTextsDictionaries();
            savedBytes[textListbox.SelectedIndex] = parseTextToBytes(textBox1.Text);
            drawTextPreview();
            pictureBox1.Refresh();
            fromForm = false;
        }

        private void button4_Click(object sender, EventArgs e) {
            DictionariesForm df = new DictionariesForm();
            df.listBox1.Items.Clear();

            int i = 0;
            foreach (string s in dictionaries) {
                df.listBox1.Items.Add(i.ToString("D2") + " : " + s.Replace(" ", "[Space]"));
                i++;
            }

            df.ShowDialog();
        }

        private void dumpTextsToolStripMenuItem_Click(object sender, EventArgs e) {
            string[] alltexts = new string[listOfTexts.Count];
            for (int i = 0; i < listOfTexts.Count; i++) {
                alltexts[i] = i.ToString("D3") + " :" + listOfTexts[i].text + "\r\n\r\n";

            }

            File.WriteAllLines("dump.txt", alltexts);
        }

        private void button5_Click(object sender, EventArgs e) {
            for (int i = 0; i < 100; i++) {
                //ROM.DATA[Constants.characters_width + i] = widthArray[i];
                ROM.Write(Constants.characters_width + i, widthArray[i], true, "Width Font");
            }

            using (var fs = new FileStream(romname, FileMode.OpenOrCreate, FileAccess.Write)) {
                fs.Write(ROM.DATA, 0, ROM.DATA.Length);
                fs.Close();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e) {
            //TODO: Add something here?
        }

        private void toolStripButton2_Click(object sender, EventArgs e) {
            using (OpenFileDialog of = new OpenFileDialog()) {
                of.DefaultExt = ".txt";
                if (of.ShowDialog() == DialogResult.OK) {
                    string[] alltexts = File.ReadAllLines(of.FileName);
                    for (int i = 0; i < alltexts.Length; i++) {
                        if (alltexts[i].Length > 3) {
                            int id = int.Parse(alltexts[i].Substring(0, 3));
                            listOfTexts[id] = new StringKey(alltexts[i].Substring(5, alltexts[i].Length - 5), new byte[] { });
                        }
                    }

                    sortText();
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e) {
            using (SaveFileDialog sf = new SaveFileDialog()) {
                sf.DefaultExt = ".txt";
                if (sf.ShowDialog() == DialogResult.OK) {
                    string[] alltexts = new string[listOfTexts.Count];
                    for (int i = 0; i < listOfTexts.Count; i++) {
                        alltexts[i] = i.ToString("D3") + " :" + listOfTexts[i].text + "\r\n\r\n";

                    }

                    File.WriteAllLines(sf.FileName, alltexts);
                }
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {
            //TODO: Add something here?
        }

        public void delete() {
            // Determine if any text is selected in the TextBox control.
            if (textBox1.SelectionLength == 0) {
                //clear all of the text in the textbox
                textBox1.Clear();
            }
        }

        public void selectAll() {
            // Determine if any text is selected in the TextBox control.
            if (textBox1.SelectionLength == 0) {
                // Select all text in the text box.
                textBox1.SelectAll();
                // Move the cursor to the text box.
                textBox1.Focus();
            }
        }

        public void cut() {
            // Ensure that text is currently selected in the text box.   
            if (textBox1.SelectedText != "") {
                // Cut the selected text in the control and paste it into the Clipboard.
                textBox1.Cut();
            }
        }

        public void paste() {
            // Determine if there is any text in the Clipboard to paste into the textbox        
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true) {
                textBox1.Paste();
            }
        }

        public void copy() {
            // Ensure that text is selected in the text box.   
            if (textBox1.SelectionLength > 0) {
                // Copy the selected text to the Clipboard.
                textBox1.Copy();
            }
        }

        public void undo() {
            // Determine if last operation can be undone in text box.   
            if (textBox1.CanUndo == true) {
                // Undo the last operation.
                textBox1.Undo();
                // Clear the undo buffer to prevent last action from being redone.
                textBox1.ClearUndo();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
            ParamsBox.Enabled = (TextCommandList.SelectedIndex <= 8);
        }
	}
}
