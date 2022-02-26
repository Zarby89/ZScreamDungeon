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
using System.Text.RegularExpressions;
using System.Globalization;

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
        public const string DICTIONARYTOKEN = "D";
        public const byte DICTOFF = 0x88;

        public TextEditor() {
            InitializeComponent();
            this.TextCommandList.Items.AddRange(TextEditor.GetElementListing(TCommands));
            this.SpecialsList.Items.AddRange(TextEditor.GetElementListing(SpecialChars));
        }



        public class TextElement {
            private string token; public string Token { get => token; }
            private string pattern; public string Pattern { get => pattern; }
            private string patternStrict; public string StrictPattern { get => patternStrict; }
            private string desc; public string Description { get => desc; }
            private bool hasParam; public bool HasArgument { get => hasParam; }
            private byte b; public byte ID { get => b; }
            private string gt; public string GenericToken { get => gt; }

            public TextElement(byte a, string t, bool arg, string d) {
                token = t;
                hasParam = arg;
                pattern = string.Format(
                    arg ? "\\[{0}:?([0-9A-F]{{1,2}})\\]" : "\\[{0}\\]",
                    token);
                patternStrict = string.Format("^{0}$", pattern);
                gt = string.Format(
                         arg ? "[{0}:##]" : "[{0}]",
                         token);
                desc = d;
                b = a;
			}

            public string GetParameterizedToken(byte b) {
                if (hasParam) {
                    return string.Format("[{0}:{1:X2}]", token, b);
                } else {
                    return string.Format("[{0}]", token);
                }
            }

            public Match MatchMe(string dfrag) {
                return Regex.Match(dfrag, patternStrict);
			}
		}

        public class ParsedElement {
            private TextElement parent; public TextElement Parent { get => parent; }
            private byte val; public byte Value { get => val; }

            public ParsedElement(TextElement t, byte v) {
                parent = t;
                val = v;
			}
		}

        public ParsedElement FindMatchingElement(string s) {
            Match g;
            foreach (TextElement t in TCommands.Concat(SpecialChars)) {
                g = t.MatchMe(s);
                if (g.Success) {
                    if (t.HasArgument) {
                        return new ParsedElement(t, Byte.Parse(g.Groups[1].Value, NumberStyles.HexNumber));
					} else {
                        return new ParsedElement(t, 0);
					}
				}
			}

            // see if dictionary entry
            g = DictionaryElement.MatchMe(s);
            if (g.Success) {
                return new ParsedElement(DictionaryElement,
                    (byte) (DICTOFF + (Byte.Parse(g.Groups[1].Value, NumberStyles.HexNumber))
                ));
			}
            return null;
		}
        public TextElement FindMatchingCommand(byte b) {
            foreach (TextElement t in TCommands) {
                if (t.ID == b) {
                    return t;
                }
            }
            return null;
        }
        public TextElement FindMatchingSpecial(byte b) {
            foreach (TextElement t in SpecialChars) {
                if (t.ID == b) {
                    return t;
                }
            }
            return null;
        }

        public int FindDictionaryEntry(byte b) {
            if (b < DICTOFF) {
                return -1;
			} else if (b == 0xFF) {
                return -1;
			}
            return b - DICTOFF;
		}

        public byte FindMatchingCharacter(char c) {
            foreach (KeyValuePair<byte, char> kt in CharEncoder) {
                if (kt.Value == c) {
                    return kt.Key;
				}
			}
            return 0xFF;
		}

        public static TextElement DictionaryElement = new TextElement(0x80, DICTIONARYTOKEN, true, "Dictionary");

        public static TextElement[] TCommands = new TextElement[] {
            new TextElement(0x6B, "W", true, "Window border"),
            new TextElement(0x6D, "P", true, "Window position"),
            new TextElement(0x6E, "SPD", true, "Scroll speed"),
            new TextElement(0x7A, "S", true, "Text draw speed"),
            new TextElement(0x77, "C", true, "Text color"),
            new TextElement(0x6A, "L", false, "Player name"),
            new TextElement(0x74, "1", false, "Line 1"),
            new TextElement(0x75, "2", false, "Line 2"),
            new TextElement(0x76, "3", false, "Line 3"),
            new TextElement(0x7B, "K", false, "Wait for key"),
            new TextElement(0x73, "V", false, "Scroll text"),
            new TextElement(0x78, "WT", true, "Delay X"),
            new TextElement(0x6C, "N", true, "BCD number"),
            new TextElement(0x79, "SFX", true, "Sound effect"),
            new TextElement(0x71, "CH3", false, "Choose 3"),
            new TextElement(0x72, "CH2", false, "Choose 2 high"),
            new TextElement(0x6F, "CH2L", false, "Choose 2 low"),
            new TextElement(0x68, "CH2I", false, "Choose 2 indented"),
            new TextElement(0x69, "CHI", false, "Choose item"),
            new TextElement(0x67, "IMG", false, "Next attract image"),
            new TextElement(0x80, "BANK", false, "Bank marker (automatic)"),
            new TextElement(0x70, "NONO", false, "Crash"),
        };

        public static TextElement[] SpecialChars = new TextElement[] {
            new TextElement(0x43, "...", false, "Ellipsis …"),
            new TextElement(0x4D, "UP", false, "Arrow ↑"),
            new TextElement(0x4E, "DOWN", false, "Arrow ↓"),
            new TextElement(0x4F, "LEFT", false, "Arrow ←"),
            new TextElement(0x50, "RIGHT", false, "Arrow →"),
            new TextElement(0x5B, "A", false, "Button Ⓐ"),
            new TextElement(0x5C, "B", false, "Button Ⓑ"),
            new TextElement(0x5D, "X", false, "Button ⓧ"),
            new TextElement(0x5E, "Y", false, "Button ⓨ"),
            new TextElement(0x52, "HP0", false, "1 HP left" ),
            new TextElement(0x53, "HP1", false, "1 HP right" ),
            new TextElement(0x54, "HP2", false, "2 HP left" ),
            new TextElement(0x55, "HP3", false, "3 HP left" ),
            new TextElement(0x56, "HP4", false, "3 HP right" ),
            new TextElement(0x57, "HP5", false, "4 HP left" ),
            new TextElement(0x58, "HP6", false, "4 HP right" ),
            new TextElement(0x47, "HY0", false, "Hieroglyph ☥"),
            new TextElement(0x48, "HY1", false, "Hieroglyph 𓈗"),
            new TextElement(0x49, "HY2", false, "Hieroglyph Ƨ"),
            new TextElement(0x4A, "LHL", false, "Link face left"),
            new TextElement(0x4B, "LHR", false, "Link face right"),

        };

        public static Dictionary<byte, char> CharEncoder = new Dictionary<byte, char> {
                { 0x00, 'A' },
                { 0x01, 'B' },
                { 0x02, 'C' },
                { 0x03, 'D' },
                { 0x04, 'E' },
                { 0x05, 'F' },
                { 0x06, 'G' },
                { 0x07, 'H' },
                { 0x08, 'I' },
                { 0x09, 'J' },
                { 0x0A, 'K' },
                { 0x0B, 'L' },
                { 0x0C, 'M' },
                { 0x0D, 'N' },
                { 0x0E, 'O' },
                { 0x0F, 'P' },
                { 0x10, 'Q' },
                { 0x11, 'R' },
                { 0x12, 'S' },
                { 0x13, 'T' },
                { 0x14, 'U' },
                { 0x15, 'V' },
                { 0x16, 'W' },
                { 0x17, 'X' },
                { 0x18, 'Y' },
                { 0x19, 'Z' },
                { 0x1A, 'a' },
                { 0x1B, 'b' },
                { 0x1C, 'c' },
                { 0x1D, 'd' },
                { 0x1E, 'e' },
                { 0x1F, 'f' },
                { 0x20, 'g' },
                { 0x21, 'h' },
                { 0x22, 'i' },
                { 0x23, 'j' },
                { 0x24, 'k' },
                { 0x25, 'l' },
                { 0x26, 'm' },
                { 0x27, 'n' },
                { 0x28, 'o' },
                { 0x29, 'p' },
                { 0x2A, 'q' },
                { 0x2B, 'r' },
                { 0x2C, 's' },
                { 0x2D, 't' },
                { 0x2E, 'u' },
                { 0x2F, 'v' },
                { 0x30, 'w' },
                { 0x31, 'x' },
                { 0x32, 'y' },
                { 0x33, 'z' },
                { 0x34, '0' },
                { 0x35, '1' },
                { 0x36, '2' },
                { 0x37, '3' },
                { 0x38, '4' },
                { 0x39, '5' },
                { 0x3A, '6' },
                { 0x3B, '7' },
                { 0x3C, '8' },
                { 0x3D, '9' },
                { 0x3E, '!' },
                { 0x3F, '?' },
                { 0x40, '-' },
                { 0x41, '.' },
                { 0x42, ',' },
                { 0x43, '…' },
                { 0x44, '>' },
                { 0x45, '(' },
                { 0x46, ')' },
                { 0x4C, '"' },
                { 0x51, '\'' },
                { 0x59, ' ' },
                { 0x5A, '<' },
                { 0x5F, '¡' },
                { 0x60, '¡' },
                { 0x61, '¡' },
                { 0x62, ' ' },
                { 0x63, ' ' },
                { 0x64, ' ' },
                { 0x65, ' ' },
                { 0x66, '_' },
        };

        public static string[] GetElementListing(TextElement[] list) {
            string[] ret = new string[list.Length];
            int i = 0;
            foreach (TextElement t in list) {
                ret[i++] =
                    string.Format(
                        "{0} {1}",
                        t.GenericToken,
                        t.Description);
            }
            return ret;
        }

        private void TextEditor_Load(object sender, EventArgs e) {
            //TODO: Add something here?
        }

        public void readAllText() {
            int tt = 0;
            byte b = 0;
            int pos = Constants.text_data;
            List<byte> tempBytes = new List<byte>();

            StringBuilder currentMessage = new StringBuilder();
            TextElement t;

            while (true) {
                b = ROM.DATA[pos++];
                tempBytes.Add(b);

                // check for end of message
                if (b == 0x7F) {
                    listOfTexts.Add(new StringKey(currentMessage.ToString(), tempBytes.ToArray()));
                    tempBytes.Clear();
                    currentMessage.Clear();
                    addrTexts[tt++] = pos;
                    continue;
                } else if (b == 0xFF) {
                    break;
                }

                // check for command
                t = FindMatchingCommand(b);

                if (t != null) {
                    if (t.HasArgument) {
                        b = ROM.DATA[pos++];
                        tempBytes.Add(b);
                    }
                    currentMessage.Append(t.GetParameterizedToken(b));

                    if (t.Token == "BANK") {
                        pos = Constants.text_data2;
                    }

                    continue;
                }

                // check for special characters
                t = FindMatchingSpecial(b);

                if (t != null) {
                    currentMessage.Append(t.GetParameterizedToken(0));
                    continue;
                }

                // check for dictionary
                int dict = FindDictionaryEntry(b);

                if (dict >= 0) {
                    // currentMessage.Append("[");
                    // currentMessage.Append(DICTIONARYTOKEN);
                    // currentMessage.Append(":");
                    // currentMessage.Append(dict);
                    // currentMessage.Append("]");
                    int addr = Utils.SnesToPc(0x0E0000 |
                       (ROM.DATA[Constants.pointers_dictionaries + (dict * 2) + 1] << 8) |
                       (ROM.DATA[Constants.pointers_dictionaries + (dict * 2)])
                       );
                    int addrend = Utils.SnesToPc(0x0E0000 |
                       (ROM.DATA[Constants.pointers_dictionaries + ((dict+1) * 2) + 1] << 8) |
                       (ROM.DATA[Constants.pointers_dictionaries + ((dict+1) * 2)])
                       );
                    byte dadd;
                    for (int i = addr; i < addrend; i++) {
                        dadd = ROM.DATA[i];
                        tempBytes.Add(dadd);
                        currentMessage.Append(readNextTextByte(dadd));
					}
                    continue;
                }


                // everything else
                if (CharEncoder.ContainsKey(b)) {
                    currentMessage.Append(CharEncoder[b]);
                }
            }

            //00074703
        }

        public void buildDictionaries() {
            for (int i = 0; i < 97; i++) {
                int addr = 0;
                List<byte> bytes = new List<byte>();
                StringBuilder s = new StringBuilder();
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
                    byte bdictionary = ROM.DATA[addr++];
                    bytes.Add(bdictionary);
                    s.Append(readNextTextByte(bdictionary));
                }

                dictionaries_bytes.Add(bytes.ToArray());
                dictionaries.Add(s.ToString());
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
                    s = s.Replace(dictionaries[dictionariesOrder[i]], DICTIONARYTOKEN + ":" + dictionariesOrder[i].ToString("D2") + "]");
                }

                savedTexts.Add(s);
            }
        }

        public byte[] parseTextToBytes(string fullString) {
            defaultColor = 6;
            List<byte> bytes = new List<byte>();
            string s = fullString;
            int pos = 0;
            ParsedElement p;
            while (pos < s.Length) {
                // get next text fragment
                string dfrag;
                if (s[pos] == '[') {
                    int next = s.IndexOf(']', pos);
                    if (next == -1) {
                        break;
					}
                    dfrag = s.Substring(pos, next - pos + 1);
                    p = FindMatchingElement(dfrag);
                    if (p == null) {
                        break; // TODO handle badness
					} else if (p.Parent == DictionaryElement) {
                        bytes.Add(p.Value);
					} else {
                        bytes.Add(p.Parent.ID);
                        if (p.Parent.HasArgument) {
                            bytes.Add(p.Value);
						}
					}

                    pos = next + 1;
                    continue;

				} else {
                    byte bb = FindMatchingCharacter(s[pos++]);
                    if (bb != 0xFF) { // TODO handle badness
                        bytes.Add(bb);
					}
				}
            }

            return bytes.ToArray();
        }


        public string readNextTextByte(byte b) {
            if (CharEncoder.ContainsKey(b)) {
                return CharEncoder[b] + "";
            }

            TextElement t;

            // check for command
            t = FindMatchingCommand(b);

            if (t != null) {
                return t.GenericToken;
            }

            // check for special characters
            t = FindMatchingSpecial(b);

            if (t != null) {
                return t.GenericToken;
            }

            // check for dictionary
            int dict = FindDictionaryEntry(b);

            if (dict >= 0) {
                return string.Format("[{0}:{1:2X}",
                    DICTIONARYTOKEN,
                    dict);
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
            } else if (b == 0x74) { textPos = 0; textLine = 0; }
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
            else if (b == 0x6A) {
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
            e.Graphics.DrawImage(
                GFX.currentfontgfx16Bitmap,
                new Rectangle(0, 0, 340, pictureBox2.Height),
                new Rectangle(0, shownLines * 16, 170, pictureBox2.Height / 2),
                GraphicsUnit.Pixel);
            e.Graphics.FillRectangle(
                new SolidBrush(Color.FromArgb(128, 255, 0, 0)),
                new Rectangle(344 - 8, 0, 4,
                pictureBox2.Height));
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
                            MessageBox.Show("Too much text data in 1st group to save;\n" +
                                "Available Space = 0x8000, Used Space = " + (pos & 0xFFFF).ToString("X4"));
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
                MessageBox.Show("Too many text data in 1st group impossible to save;\n" +
                    "available space = 0x8000, Used Space = " + (pos & 0xFFFF).ToString("X4"));
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
                UpdateTextBox();
            }
        }

        private void InsertCommandButton_Click_1(object sender, EventArgs e) {
            byte par = 0;
            Byte.TryParse(ParamsBox.Text, NumberStyles.HexNumber, null, out par);

            InsertSelectedText(TCommands[TextCommandList.SelectedIndex].GetParameterizedToken(par));
        }

        private void InsertSpecialButton_Click(object sender, EventArgs e) {
            InsertSelectedText(SpecialChars[SpecialsList.SelectedIndex].GetParameterizedToken(0));
        }

        private void InsertSelectedText(string s) {
            int textboxPos = textBox1.SelectionStart;
            fromForm = true;
            textBox1.Text = textBox1.Text.Insert(textboxPos, s);
            fromForm = false;
            textBox1.SelectionStart = textboxPos + s.Length;
        }

        private void UpdateTextBox() {
            listOfTexts[(int) (textListbox.SelectedItem as ListViewItem).Tag].text = textBox1.Text;
            setTextsDictionaries();
            savedBytes[(int) (textListbox.SelectedItem as ListViewItem).Tag] = parseTextToBytes(textBox1.Text);
            drawTextPreview();
            pictureBox1.Refresh();
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
