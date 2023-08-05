using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ZeldaFullEditor.Data;
using ZeldaFullEditor.Gui.TextEditorExtra;

namespace ZeldaFullEditor
{
    public partial class TextEditor : UserControl
    {
        readonly byte[] widthArray = new byte[100];
        static readonly int defaultColor = 6;
        readonly string romname = string.Empty;

        int textLine = 0;
        readonly List<MessageData> ListOfTexts = new List<MessageData>();
        public List<MessageData> DisplayedMessages = new List<MessageData>();
        private MessageData CurrentMessage;

        int textPos = 0;
        bool skipNext = false;

        int shownLines = 0;

        bool fromForm = false;

        int selectedTile = 0;

        public const string DICTIONARYTOKEN = "D";
        public const byte DICTOFF = 0x88;
        public const byte MESSAGETERMINATOR = 0x7F;

        private static readonly Pen CharHilite = new Pen(Brushes.HotPink, 2);
        private static readonly Pen GridHilite = new Pen(Color.FromArgb(0x77CCCCCC), 2);

        private const string BANKToken = "BANK";
        public static TextElement DictionaryElement = new TextElement(0x80, DICTIONARYTOKEN, true, "Dictionary");

        public static List<DictionaryEntry> AllDictionaries = new List<DictionaryEntry>();

        public TextEditor()
        {
            this.InitializeComponent();
            this.TextCommandList.Items.AddRange(TextCommands);
            this.SpecialsList.Items.AddRange(SpecialChars);
            this.pictureBox1.MouseWheel += new MouseEventHandler(this.PictureBox1_MouseWheel);
        }

        public class TextElement
        {
            public byte ID { get; internal set; }

            public string Token { get; internal set; }

            public string GenericToken { get; internal set; }

            public string Pattern { get; internal set; }

            public string StrictPattern { get; internal set; }

            public string Description { get; internal set; }

            public bool HasArgument { get; internal set; }

            public TextElement(byte id, string token, bool arg, string description)
            {
                this.ID = id;
                this.Token = token;
                this.GenericToken = string.Format(arg ? "[{0}:##]" : "[{0}]", this.Token);
                this.HasArgument = arg;
                this.Description = description;
                this.Pattern = string.Format(arg ? "\\[{0}:?([0-9A-F]{{1,2}})\\]" : "\\[{0}\\]", Regex.Escape(this.Token)); // Need to escape to prevent bad with [...]
                this.StrictPattern = string.Format("^{0}$", this.Pattern);
            }

            public string GetParameterizedToken(byte value = 0)
            {
                if (this.HasArgument)
                {
                    return string.Format("[{0}:{1:X2}]", this.Token, value);
                }
                else
                {
                    return string.Format("[{0}]", this.Token);
                }
            }

            public override string ToString()
            {
                return string.Format("{0} {1}", this.GenericToken, this.Description);
            }

            public Match MatchMe(string dfrag)
            {
                return Regex.Match(dfrag, this.StrictPattern);
            }
        }

        public class ParsedElement
        {
            public TextElement Parent { get; internal set; }

            public byte Value { get; internal set; }

            public ParsedElement(TextElement textElement, byte value)
            {
                this.Parent = textElement;
                this.Value = value;
            }
        }

        public class DictionaryEntry
        {
            public byte ID { get; internal set; }

            public string Contents { get; internal set; }

            public byte[] Data { get; internal set; }

            public int Length { get; internal set; }

            public string Token { get; internal set; }

            public DictionaryEntry(byte id, string contents)
            {
                this.Contents = contents;
                this.ID = id;
                this.Length = contents.Length;
                this.Token = string.Format("[{0}:{1:X2}]", DICTIONARYTOKEN, ID);
                this.Data = ParseMessageToData(this.Contents);
            }

            public bool ContainedInString(string str)
            {
                return str.IndexOf(this.Contents) >= 0;
            }

            public string ReplaceInstancesOfIn(string str)
            {
                return str.Replace(this.Contents, this.Token);
            }
        }

        public static string ReplaceAllDictionaryWords(string str)
        {
            string temp = str;
            foreach (DictionaryEntry dictionaryEntry in AllDictionaries)
            {
                if (dictionaryEntry.ContainedInString(temp))
                {
                    temp = dictionaryEntry.ReplaceInstancesOfIn(temp);
                }
            }

            return temp;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="str"> The string to find. </param>
        /// <returns></returns>
        public static ParsedElement FindMatchingElement(string str)
        {
            Match match;
            foreach (TextElement textElement in TextCommands.Concat(SpecialChars))
            {
                match = textElement.MatchMe(str);
                if (match.Success)
                {
                    if (textElement.HasArgument)
                    {
                        return new ParsedElement(textElement, byte.Parse(match.Groups[1].Value, NumberStyles.HexNumber));
                    }
                    else
                    {
                        return new ParsedElement(textElement, 0);
                    }
                }
            }

            // See if dictionary entry.
            match = DictionaryElement.MatchMe(str);
            if (match.Success)
            {
                return new ParsedElement(
                    DictionaryElement,
                    (byte)(DICTOFF + byte.Parse(match.Groups[1].Value, NumberStyles.HexNumber)));
            }

            return null;
        }

        public TextElement FindMatchingCommand(byte b)
        {
            foreach (TextElement textElement in TextCommands)
            {
                if (textElement.ID == b)
                {
                    return textElement;
                }
            }

            return null;
        }

        public TextElement FindMatchingSpecial(byte value)
        {
            foreach (TextElement textElement in SpecialChars)
            {
                if (textElement.ID == value)
                {
                    return textElement;
                }
            }

            return null;
        }

        public int FindDictionaryEntry(byte value)
        {
            if (value < DICTOFF || value == 0xFF)
            {
                return -1;
            }

            return value - DICTOFF;
        }

        public DictionaryEntry GetDictionaryFromID(byte value)
        {
            return AllDictionaries.First(dictionary => dictionary.ID == value);
        }

        public static byte FindMatchingCharacter(char value)
        {
            foreach (KeyValuePair<byte, char> pair in CharEncoder)
            {
                if (pair.Value == value)
                {
                    return pair.Key;
                }
            }

            return 0xFF;
        }

        public static TextElement[] TextCommands = new TextElement[]
        {
            new TextElement(0x6B, "W", true, "Window border"),
            new TextElement(0x6D, "P", true, "Window position"),
            new TextElement(0x6E, "SPD", true, "Scroll speed"),
            new TextElement(0x7A, "S", true, "Text draw speed"),
            new TextElement(0x77, "C", true, "Text color"),
            new TextElement(0x6A, "L", false, "Player name"),
            new TextElement(0x74, "1", false, "Line 1"),
            new TextElement(0x75, "2", false, "Line 2"),
            new TextElement(0x76, "3", false, "Line 3"),
            new TextElement(0x7E, "K", false, "Wait for key"),
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
            new TextElement(0x80, BANKToken, false, "Bank marker (automatic)"),
            new TextElement(0x70, "NONO", false, "Crash"),
        };

        public static TextElement[] SpecialChars = new TextElement[]
        {
            new TextElement(0x43, "...", false, "Ellipsis …"),
            new TextElement(0x4D, "UP", false, "Arrow ↑"),
            new TextElement(0x4E, "DOWN", false, "Arrow ↓"),
            new TextElement(0x4F, "LEFT", false, "Arrow ←"),
            new TextElement(0x50, "RIGHT", false, "Arrow →"),
            new TextElement(0x5B, "A", false, "Button Ⓐ"),
            new TextElement(0x5C, "B", false, "Button Ⓑ"),
            new TextElement(0x5D, "X", false, "Button ⓧ"),
            new TextElement(0x5E, "Y", false, "Button ⓨ"),
            new TextElement(0x52, "HP1L", false, "1 HP left" ),
            new TextElement(0x53, "HP1R", false, "1 HP right" ),
            new TextElement(0x54, "HP2L", false, "2 HP left" ),
            new TextElement(0x55, "HP3L", false, "3 HP left" ),
            new TextElement(0x56, "HP3R", false, "3 HP right" ),
            new TextElement(0x57, "HP4L", false, "4 HP left" ),
            new TextElement(0x58, "HP4R", false, "4 HP right" ),
            new TextElement(0x47, "HY0", false, "Hieroglyph ☥"),
            new TextElement(0x48, "HY1", false, "Hieroglyph 𓈗"),
            new TextElement(0x49, "HY2", false, "Hieroglyph Ƨ"),
            new TextElement(0x4A, "LFL", false, "Link face left"),
            new TextElement(0x4B, "LFR", false, "Link face right"),
        };

        public static Dictionary<byte, char> CharEncoder = new Dictionary<byte, char>
        {
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

        public bool SelectMessageID(int id)
        {
            if (id < this.textListbox.Items.Count)
            {
                this.textListbox.SelectedIndex = id;

                return true;
            }

            return false;
        }

        public void ReadAllTextDataFromROM()
        {
            int messageID = 0;
            byte value;
            int pos = Constants.text_data;
            var tempBytesRaw = new List<byte>();
            var tempBytesParsed = new List<byte>();

            var currentMessageRaw = new StringBuilder();
            var currentMessageParsed = new StringBuilder();
            TextElement textElement;

            while (true)
            {
                value = ROM.DATA[pos++];

                if (value == MESSAGETERMINATOR)
                {
                    var message = new MessageData(
                        messageID++,
                        pos,
                        currentMessageRaw.ToString(),
                        tempBytesRaw.ToArray(),
                        currentMessageParsed.ToString(),
                        tempBytesParsed.ToArray());

                    this.ListOfTexts.Add(message);

                    tempBytesRaw.Clear();
                    tempBytesParsed.Clear();
                    currentMessageRaw.Clear();
                    currentMessageParsed.Clear();

                    continue;
                }
                else if (value == 0xFF)
                {
                    break;
                }

                tempBytesRaw.Add(value);

                // Check for command.
                textElement = this.FindMatchingCommand(value);

                if (textElement != null)
                {
                    tempBytesParsed.Add(value);
                    if (textElement.HasArgument)
                    {
                        value = ROM.DATA[pos++];
                        tempBytesRaw.Add(value);
                        tempBytesParsed.Add(value);
                    }

                    currentMessageRaw.Append(textElement.GetParameterizedToken(value));
                    currentMessageParsed.Append(textElement.GetParameterizedToken(value));

                    if (textElement.Token == BANKToken)
                    {
                        pos = Constants.text_data2;
                    }

                    continue;
                }

                // Check for special characters.
                textElement = this.FindMatchingSpecial(value);

                if (textElement != null)
                {
                    currentMessageRaw.Append(textElement.GetParameterizedToken());
                    currentMessageParsed.Append(textElement.GetParameterizedToken());
                    tempBytesParsed.Add(value);
                    continue;
                }

                // Check for dictionary.
                int dictionary = this.FindDictionaryEntry(value);

                if (dictionary >= 0)
                {
                    currentMessageRaw.Append("[");
                    currentMessageRaw.Append(DICTIONARYTOKEN);
                    currentMessageRaw.Append(":");
                    currentMessageRaw.Append(dictionary.ToString("X2"));
                    currentMessageRaw.Append("]");

                    int address = Utils.Get24LocalFromPC(Constants.pointers_dictionaries + (dictionary * 2));
                    int addressEnd = Utils.Get24LocalFromPC(Constants.pointers_dictionaries + ((dictionary + 1) * 2));

                    for (int i = address; i < addressEnd; i++)
                    {
                        tempBytesParsed.Add(ROM.DATA[i]);
                        currentMessageParsed.Append(this.ParseTextDataByte(ROM.DATA[i]));
                    }

                    continue;
                }

                // Everything else.
                if (CharEncoder.ContainsKey(value))
                {
                    currentMessageRaw.Append(CharEncoder[value]);
                    currentMessageParsed.Append(CharEncoder[value]);
                    tempBytesParsed.Add(value);
                }
            }

            //00074703
        }

        public void BuildDictionaryEntriesFromROM()
        {
            for (int i = 0; i < 97; i++)
            {
                var bytes = new List<byte>();
                var stringBuilder = new StringBuilder();

                int address = Utils.SnesToPc(0x0E0000 +
                    (ROM.DATA[Constants.pointers_dictionaries + (i * 2) + 1] << 8) +
                    ROM.DATA[Constants.pointers_dictionaries + (i * 2)]);

                int tempAddress = Utils.SnesToPc(0x0E0000 +
                    (ROM.DATA[Constants.pointers_dictionaries + ((i + 1) * 2) + 1] << 8) +
                    ROM.DATA[Constants.pointers_dictionaries + ((i + 1) * 2)]);

                while (address < tempAddress)
                {
                    byte byteDictionary = ROM.DATA[address++];
                    bytes.Add(byteDictionary);
                    stringBuilder.Append(this.ParseTextDataByte(byteDictionary));
                }

                AllDictionaries.Add(new DictionaryEntry((byte)i, stringBuilder.ToString()));
            }

            AllDictionaries.OrderByDescending(dictionary => dictionary.Length);
        }

        public static byte[] ParseMessageToData(string str)
        {
            var bytes = new List<byte>();
            string tempString = str;
            int pos = 0;

            while (pos < tempString.Length)
            {
                // Get next text fragment.
                if (tempString[pos] == '[')
                {
                    int next = tempString.IndexOf(']', pos);
                    if (next == -1)
                    {
                        break;
                    }

                    ParsedElement parsedElement = FindMatchingElement(tempString.Substring(pos, next - pos + 1));
                    if (parsedElement == null)
                    {
                        break; // TODO: handle badness.
                    }
                    else if (parsedElement.Parent == DictionaryElement)
                    {
                        bytes.Add(parsedElement.Value);
                    }
                    else
                    {
                        bytes.Add(parsedElement.Parent.ID);

                        if (parsedElement.Parent.HasArgument)
                        {
                            bytes.Add(parsedElement.Value);
                        }
                    }

                    pos = next + 1;
                    continue;
                }
                else
                {
                    byte bb = FindMatchingCharacter(tempString[pos++]);

                    if (bb != 0xFF)
                    {
                        // TODO: handle badness.
                        bytes.Add(bb);
                    }
                }
            }

            return bytes.ToArray();
        }

        public string ParseTextDataByte(byte value)
        {
            if (CharEncoder.ContainsKey(value))
            {
                return CharEncoder[value].ToString();
            }

            // Check for command.
            TextElement textElement = this.FindMatchingCommand(value);

            if (textElement != null)
            {
                return textElement.GenericToken;
            }

            // Check for special characters.
            textElement = this.FindMatchingSpecial(value);

            if (textElement != null)
            {
                return textElement.GenericToken;
            }

            // Check for dictionary.
            int dictionary = this.FindDictionaryEntry(value);

            if (dictionary >= 0)
            {
                return string.Format("[{0}:{1:2X}", DICTIONARYTOKEN, dictionary);
            }

            return string.Empty;
        }

        public void InitializeOnOpen()
        {
            this.panel1.Enabled = true;
            for (int i = 0; i < 100; i++)
            {
                this.widthArray[i] = ROM.DATA[Constants.characters_width + i];
            }

            GFX.fontgfxBitmap = new Bitmap(128, 128, 64, PixelFormat.Format4bppIndexed, GFX.fontgfx16Ptr);
            GFX.currentfontgfx16Bitmap = new Bitmap(172, 4096, 172, PixelFormat.Format8bppIndexed, GFX.currentfontgfx16Ptr);

            var previewColors = new Color[]
            {
                Color.DimGray,
                Color.DarkBlue,
                Color.White,
                Color.DarkOrange,
            };

            ColorPalette colorPallete = GFX.fontgfxBitmap.Palette;
            for (int i = 0; i < previewColors.Length; i++)
            {
                colorPallete.Entries[i] = previewColors[i];
            }

            GFX.fontgfxBitmap.Palette = colorPallete;

            this.BuildDictionaryEntriesFromROM();
            this.ReadAllTextDataFromROM();

            foreach (MessageData messageData in this.ListOfTexts)
            {
                this.DisplayedMessages.Add(messageData);
            }

            this.textListbox.BeginUpdate();
            this.textListbox.DataSource = this.DisplayedMessages;
            this.textListbox.EndUpdate();

            this.textListbox.DisplayMember = "Text";
            this.pictureBox2.Refresh();

            this.SelectedTileID.Text = this.selectedTile.ToString("X2");
            this.SelectedTileASCII.Text = this.ParseTextDataByte((byte)this.selectedTile);

            GFX.CreateFontGfxData(ROM.DATA);
        }

        public static string AddNewLinesToCommands(string str)
        {
            return Regex.Replace(str, @"\[[123V]\]", "\r\n$0");
        }

        private void TextListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.textListbox.SelectedIndex == -1)
            {
                /*
                CurrentMessage = null;
                */

                return;
            }

            /*
            MessageData msg = listOfTexts[(int) (textListbox.Items[textListbox.SelectedIndex] as ListViewItem).Tag];
            */

            this.CurrentMessage = this.textListbox.Items[this.textListbox.SelectedIndex] as MessageData;

            /*
            Console.WriteLine(savedTexts[textListbox.SelectedIndex]);
            for (int i = 0; i < savedBytes[textListbox.SelectedIndex].Length; i++)
            {
                Console.Write(savedBytes[textListbox.SelectedIndex][i].ToString("X2") + " ");
            }

            Console.WriteLine();
            */

            // TODO: Need to adjust this because it keeps moving where the cursor is.
            this.textBox1.Text = AddNewLinesToCommands(this.CurrentMessage.ContentsParsed);

            this.DrawMessagePreview();

            this.pictureBox1.Refresh();
        }

        public unsafe void DrawStringToPreview(string str)
        {
            foreach (char c in str)
            {
                this.DrawCharacterToPreview(c);
            }
        }

        public unsafe void DrawCharacterToPreview(char c)
        {
            this.DrawCharacterToPreview(FindMatchingCharacter(c));
        }

        public unsafe void DrawCharacterToPreview(params byte[] text)
        {
            foreach (byte value in text)
            {
                if (this.skipNext)
                {
                    this.skipNext = false;
                    continue;
                }

                if (value < 100)
                {
                    int srcy = value / 16;
                    int srcx = value - (value & (~0xF));

                    if (this.textPos >= 170)
                    {
                        this.textPos = 0;
                        this.textLine++;
                    }

                    this.DrawTileToPreview(this.textPos, this.textLine * 16, srcx, srcy, 0, false, false, 1, 2);
                    this.textPos += this.widthArray[value];
                }
                else if (value == 0x74)
                {
                    this.textPos = 0;
                    this.textLine = 0;
                }
                else if (value == 0x73)
                {
                    this.textPos = 0;
                    this.textLine += 1;
                }
                else if (value == 0x75)
                {
                    this.textPos = 0;
                    this.textLine = 1;
                }
                else if (value == 0x76)
                {
                    this.textPos = 0;
                    this.textLine = 2;
                }
                else if (value == 0x6B || value == 0x6D || value == 0x6E || value == 0x77 || value == 0x78 || value == 0x79 || value == 0x7A)
                {
                    this.skipNext = true;

                    continue;
                }
                else if (value == 0x6C) // BCD numbers.
                {
                    this.DrawCharacterToPreview('0');
                    this.skipNext = true;

                    continue;
                }
                else if (value == 0x6A)
                {
                    // Includes parentheses to be longer, since player names can be up to 6 characters.
                    this.DrawStringToPreview("(NAME)");
                }
                else if (value >= DICTOFF && value < (DICTOFF + 97))
                {
                    DictionaryEntry dictionaryEntry = this.GetDictionaryFromID((byte)(value - DICTOFF));
                    if (dictionaryEntry != null)
                    {
                        this.DrawCharacterToPreview(dictionaryEntry.Data);
                    }
                }
            }
        }

        public unsafe void DrawMessagePreview() // From Parsing.
        {
            // defaultColor = 6;
            this.textLine = 0;
            byte* ptr = (byte*)GFX.currentfontgfx16Ptr.ToPointer();

            for (int i = 0; i < (172 * 4096); i++)
            {
                ptr[i] = 0;
            }

            this.textPos = 0;
            this.DrawCharacterToPreview(this.CurrentMessage.Data);

            this.shownLines = 0;
        }

        public unsafe void DrawTileToPreview(int x, int y, int srcx, int srcy, int pal, bool mirror_x = false, bool mirror_y = false, int sizex = 1, int sizey = 1)
        {
            var allTileData = (byte*)GFX.fontgfx16Ptr.ToPointer();

            byte* pointer = (byte*)GFX.currentfontgfx16Ptr.ToPointer();

            int drawid = srcx + (srcy * 32);
            for (int yl = 0; yl < sizey * 8; yl++)
            {
                for (int xl = 0; xl < 4; xl++)
                {
                    int mx = xl;
                    int my = yl;

                    // Formula information to get tile index position in the array.
                    // ((ID / nbrofXtiles) * (imgwidth/2) + (ID - ((ID/16)*16) ))
                    int tx = ((drawid / 16) * 512) + ((drawid - ((drawid / 16) * 16)) * 4);
                    byte pixel = allTileData[tx + (yl * 64) + xl];

                    // nx,ny = object position, xx,yy = tile position, xl,yl = pixel position
                    int index = x + (y * 172) + (mx * 2) + (my * 172);
                    if ((pixel & 0x0F) != 0)
                    {
                        pointer[index + 1] = (byte)((pixel & 0x0F) + (0 * 4));
                    }

                    if (((pixel >> 4) & 0x0F) != 0)
                    {
                        pointer[index + 0] = (byte)(((pixel >> 4) & 0x0F) + (0 * 4));
                    }
                }
            }
        }

        private void SearchTextbox_TextChanged(object sender, EventArgs e)
        {
            this.DisplayedMessages.Clear();
            string searchText = this.searchTextbox.Text.ToLower();

            foreach (MessageData messageData in this.ListOfTexts)
            {
                if (messageData.ContentsParsed.ToLower().Contains(searchText))
                {
                    this.DisplayedMessages.Add(messageData);
                }
            }

            this.textListbox.BeginUpdate();
            this.textListbox.DataSource = null;
            this.textListbox.DataSource = this.DisplayedMessages;
            this.textListbox.EndUpdate();
        }

        private void PictureBox2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.DrawImage(GFX.fontgfxBitmap, Constants.Rect_0_0_256_256);

            if (this.fontGridBox.Checked)
            {
                for (int i = 0; i < 16; i++)
                {
                    e.Graphics.DrawLine(GridHilite, 16 * i, 0, 16 * i, 128 * 4);
                }

                for (int j = 0; j < 16; j++)
                {
                    e.Graphics.DrawLine(GridHilite, 0, 32 * j, 64 * 4, 32 * j);
                }
            }

            int srcY = this.selectedTile / 16;
            int srcX = this.selectedTile - (srcY * 16);
            e.Graphics.DrawRectangle(CharHilite, new Rectangle(srcX * 16, srcY * 32, 16, 32));
        }

        private void PictureBox3_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.DrawImage(
                GFX.fontgfxBitmap,
                Constants.Rect_0_0_64_128,
                new Rectangle((this.selectedTile - (this.selectedTile & 0xF0)) * 8, this.selectedTile & 0xF0, 8, 16),
                GraphicsUnit.Pixel);

            if (this.fontGridBox.Checked)
            {
                for (int i = 0; i < 8; i++)
                {
                    e.Graphics.DrawLine(GridHilite, 8 * i, 0, 8 * i, 128);
                }

                for (int j = 0; j < 16; j++)
                {
                    e.Graphics.DrawLine(GridHilite, 0, 8 * j, 64, 8 * j);
                }
            }
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
            ColorPalette colorPallete = GFX.currentfontgfx16Bitmap.Palette;

            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    colorPallete.Entries[i] = Color.Transparent;
                }
                else
                {
                    colorPallete.Entries[i] = GFX.roomBg1Bitmap.Palette.Entries[(defaultColor * 4) + i];
                }
            }

            GFX.currentfontgfx16Bitmap.Palette = colorPallete;

            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;

            e.Graphics.DrawImage(
                GFX.currentfontgfx16Bitmap,
                new Rectangle(0, 0, 340, this.pictureBox2.Height),
                new Rectangle(0, this.shownLines * 16, 170, this.pictureBox2.Height / 2),
                GraphicsUnit.Pixel);

            e.Graphics.FillRectangle(
                Constants.HalfRedBrush,
                new Rectangle(344 - 8, 0, 4, this.pictureBox2.Height));
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            using (var saveFileDialog = new SaveFileDialog())
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    byte[] data = new byte[0x1000];
                    for (int i = 0; i < 0x1000; i++)
                    {
                        data[i] = ROM.DATA[Constants.gfx_font + i];
                    }

                    using (var fs = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        fs.Write(data, 0, 0x1000);
                        fs.Write(this.widthArray, 0, 100);
                        fs.Close();
                    }
                }
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    byte[] data = new byte[0x1000 + 100];
                    using (var fileStream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        fileStream.Read(data, 0, 0x1000 + 100);
                        fileStream.Close();
                    }

                    for (int i = 0; i < 0x1000; i++)
                    {
                        /*
                        ROM.DATA[Constants.gfx_font + i] = data[i];
                        */

                        ROM.Write(Constants.gfx_font + i, data[i], WriteType.FontData);
                    }

                    for (int i = 0; i < 100; i++)
                    {
                        /*
                        ROM.DATA[Constants.characters_width + i] = data[i + 0x1000];
                        */

                        ROM.Write(Constants.characters_width + i, data[i + 0x1000], WriteType.FontData);
                    }

                    GFX.CreateFontGfxData(ROM.DATA);
                    this.pictureBox2.Refresh();
                }
            }
        }

        public bool Save()
        {
            byte[] backup = (byte[])ROM.DATA.Clone();

            for (int i = 0; i < 100; i++)
            {
                /*
                ROM.DATA[Constants.characters_width + i] = widthArray[i];
                */

                ROM.Write(Constants.characters_width + i, this.widthArray[i], WriteType.FontData);
            }

            int pos = Constants.text_data;
            bool inSecondBank = false;

            foreach (MessageData message in this.ListOfTexts)
            {
                foreach (byte value in message.Data)
                {
                    ROM.Write(pos, value, true, "Text data");

                    // TODO: 0x80 somehow means the end of the first block. Need to ask Zarby for clarification as to why this is the case.
                    // Check for the end of the first block.
                    if (value == 0x80)
                    {
                        // Make sure we didn't go over the space available in the first block. 0x7FFF available.
                        if (!inSecondBank & pos > Constants.text_data_end)
                        {
                            this.CryAboutTooMuchText(pos, true);
                            ROM.DATA = (byte[])backup.Clone();
                            return true;
                        }

                        // Switch to the second block.
                        pos = Constants.text_data2 - 1;
                        inSecondBank = true;
                    }

                    pos++;
                }

                ROM.Write(pos++, MESSAGETERMINATOR, true, "Terminator text");
            }

            // Verify that we didn't go over the space available for the second block. 0x14BF available.
            if (inSecondBank & pos > Constants.text_data2_end)
            {
                this.CryAboutTooMuchText(pos, false);
                ROM.DATA = (byte[])backup.Clone();
                return true;
            }

            ROM.Write(pos, 0xFF, true, "End of text");

            return false;
        }

        /// <summary>
        ///		The error text box that shows when you have too much text.
        /// </summary>
        /// <param name="pos"> The last position written to. </param>
        /// <param name="bank"> True = first bank of text, False = second bank of text. </param>
        private void CryAboutTooMuchText(int pos, bool bank)
        {
            int space = bank ? Constants.text_data_end - Constants.text_data : Constants.text_data2_end - Constants.text_data2;
            string bankSTR = bank ? "1st" : "2nd";
            string posSTR = bank ? (pos & 0xFFFF).ToString("X4") : ((pos - Constants.text_data2) & 0xFFFF).ToString("X4");
            string message = "There is too much text data in the " + bankSTR + " block to save.\n" +
                "Available: " + space.ToString("X4") + " | Used: " + posSTR;

            MessageBox.Show(message);
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (!this.fromForm)
            {
                this.widthArray[this.selectedTile] = (byte)this.numericUpDown1.Value;
            }
        }

        private void PictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            this.selectedTile = (e.X / 16) + ((e.Y / 32) * 16);

            if (this.selectedTile >= 98)
            {
                this.selectedTile = 98;
            }

            this.fromForm = true;
            this.numericUpDown1.Value = this.widthArray[this.selectedTile];
            this.fromForm = false;
            this.SelectedTileID.Text = this.selectedTile.ToString("X2");
            this.SelectedTileASCII.Text = this.ParseTextDataByte((byte)this.selectedTile);
            this.pictureBox2.Refresh();
            this.pictureBox3.Refresh();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            // TODO is fromForm necessary?
            //if (!fromForm) 
            //{
            this.UpdateTextBox();
            //}
        }

        /// <summary>
        /// Adds a command to the text field when the Add command button is pressed or the command is double clicked in the list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InsertCommandButton_Click_1(object sender, EventArgs e)
        {
            this.InsertSelectedText(TextCommands[this.TextCommandList.SelectedIndex].GetParameterizedToken((byte)this.ParamsBox.HexValue));
        }

        /// <summary>
        /// Adds a special character to the text field when the Add command button is pressed or the character is double clicked in the list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InsertSpecialButton_Click(object sender, EventArgs e)
        {
            this.InsertSelectedText(SpecialChars[this.SpecialsList.SelectedIndex].GetParameterizedToken());
        }

        private void InsertSelectedText(string str)
        {
            int textboxPos = this.textBox1.SelectionStart;
            this.fromForm = true;
            this.textBox1.Text = this.textBox1.Text.Insert(textboxPos, str);
            this.fromForm = false;
            this.textBox1.SelectionStart = textboxPos + str.Length;
            this.textBox1.Focus();
        }

        /// <summary>
        ///		This is called when the text box is updated, updates the preview and writes the char byts to an array.
        /// </summary>
        private void UpdateTextBox()
        {
            if (this.textListbox.SelectedItem != null)
            {
                this.CurrentMessage.SetMessage(Regex.Replace(this.textBox1.Text, @"[\r\n]", string.Empty));
                this.DrawMessagePreview();
                this.pictureBox1.Refresh();
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            var dictionariesForm = new DictionariesForm();
            dictionariesForm.listBox1.Items.Clear();

            foreach (DictionaryEntry dictionaryEntry in AllDictionaries)
            {
                dictionariesForm.listBox1.Items.Insert(
                    dictionaryEntry.ID,
                    string.Format(
                        "{0:X2} [{1:X2}] - {2}",
                        dictionaryEntry.ID,
                        dictionaryEntry.ID + DICTOFF,
                        dictionaryEntry.Contents.Replace(" ", "[Space]")));
            }

            dictionariesForm.ShowDialog();
        }

        private void DumpTextsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] alltexts = new string[this.ListOfTexts.Count];
            int i = 0;
            foreach (MessageData messageData in this.ListOfTexts)
            {
                alltexts[i++] = messageData.GetDumpedContents();
            }

            File.WriteAllLines("dump.txt", alltexts);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                //ROM.DATA[Constants.characters_width + i] = widthArray[i];
                ROM.Write(Constants.characters_width + i, this.widthArray[i], true, "Width Font");
            }

            using (var fileStream = new FileStream(this.romname, FileMode.OpenOrCreate, FileAccess.Write))
            {
                fileStream.Write(ROM.DATA, 0, ROM.DATA.Length);
                fileStream.Close();
            }
        }

        // TODO: needs a rewrite.
        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            /*
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
            */
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.DefaultExt = ".txt";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] alltexts = new string[this.ListOfTexts.Count];
                    for (int i = 0; i < this.ListOfTexts.Count; i++)
                    {
                        alltexts[i] = i.ToString("X3") + " : " + this.ListOfTexts[i].ContentsParsed + "\r\n\r\n";
                    }

                    File.WriteAllLines(saveFileDialog.FileName, alltexts);
                }
            }
        }

        private void ToolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // TODO: Add something here?
        }

        public void Delete()
        {
            // Determine if any text is selected in the TextBox control.
            if (this.textBox1.SelectionLength == 0)
            {
                // Clear all of the text in the textbox.
                this.textBox1.Clear();
            }
        }

        public void SelectAll()
        {
            // Determine if any text is selected in the TextBox control.
            if (this.textBox1.SelectionLength == 0)
            {
                // Select all text in the text box.
                this.textBox1.SelectAll();

                // Move the cursor to the text box.
                this.textBox1.Focus();
            }
        }

        public void Cut()
        {
            // Ensure that text is currently selected in the text box.
            if (this.textBox1.SelectedText != string.Empty)
            {
                // Cut the selected text in the control and paste it into the Clipboard.
                this.textBox1.Cut();
            }
        }

        public void Paste()
        {
            // Determine if there is any text in the Clipboard to paste into the textbox.
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
            {
                this.textBox1.Paste();
            }
        }

        public void Copy()
        {
            // Ensure that text is selected in the text box.
            if (this.textBox1.SelectionLength > 0)
            {
                // Copy the selected text to the Clipboard.
                this.textBox1.Copy();
            }
        }

        public void Undo()
        {
            // Determine if last operation can be undone in text box.
            if (this.textBox1.CanUndo)
            {
                // Undo the last operation.
                this.textBox1.Undo();

                // Clear the undo buffer to prevent last action from being redone.
                this.textBox1.ClearUndo();
            }
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ParamsBox.Enabled = TextCommands[this.TextCommandList.SelectedIndex].HasArgument;
        }

        private void BytesDDD_Click(object sender, EventArgs e)
        {
            if (this.textListbox.SelectedIndex < 0)
            {
                return;
            }

            var byter = new MessageAsBytes();
            byter.ShowBytes(this.CurrentMessage);
        }

        private void FontGridBox_CheckedChanged(object sender, EventArgs e)
        {
            this.pictureBox2.Refresh();
            this.pictureBox3.Refresh();
        }

        private void PictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 1)
            {
                this.ScrollTextPreviewUp();
            }
            else if (e.Delta < 1)
            {
                this.ScrollTextPreviewDown();
            }
        }

        private void DownButton_Click(object sender, EventArgs e)
        {
            this.ScrollTextPreviewDown();
        }

        private void ScrollTextPreviewDown()
        {
            if (this.shownLines < this.textLine - 2)
            {
                this.shownLines++;
            }

            this.pictureBox1.Refresh();
        }

        private void UpButton_Click(object sender, EventArgs e)
        {
            this.ScrollTextPreviewUp();
        }

        private void ScrollTextPreviewUp()
        {
            if (this.shownLines > 0)
            {
                this.shownLines--;
            }

            this.pictureBox1.Refresh();
        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            this.textListbox.BeginUpdate();
            this.textListbox.DataSource = null;
            this.textListbox.DataSource = this.DisplayedMessages;
            this.textListbox.EndUpdate();
        }
    }
}
