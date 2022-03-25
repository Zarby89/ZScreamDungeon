using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using ZeldaFullEditor.Gui.TextEditorExtra;
using System.Text.RegularExpressions;
using System.Globalization;

namespace ZeldaFullEditor
{
	public partial class TextEditor : Gui.ScreamControl
	{
		readonly byte[] widthArray = new byte[100];
		private const int DefaultTextColor = 6;
		readonly string romname = "";

		private int textLine = 0;
		readonly List<MessageData> listOfTexts = new List<MessageData>();
		private List<MessageData> DisplayedMessages = new List<MessageData>();
		private MessageData CurrentMessage;

		private int textPos = 0;
		private bool skipNext = false;

		private int shownLines = 0;

		private bool fromForm = false;

		private int selectedTile = 0;

		public const string DICTIONARYTOKEN = "D";
		public const byte DICTOFF = 0x88;
		public const byte MessageTerminator = 0x7F;

		public TextEditor(ZScreamer parent) : base(parent)
		{
			InitializeComponent();
			TextCommandList.Items.AddRange(TCommands);
			SpecialsList.Items.AddRange(SpecialChars);
			pictureBox1.MouseWheel += new MouseEventHandler(pictureBox1_MouseWheel);
		}

		public class MessageData
		{
			private string str; public string Contents { get => str; }
			private string strp; public string ContentsParsed { get => strp; }
			private readonly int id; public int ID { get => id; }
			private byte[] dataraw; public byte[] Data { get => dataraw; }
			private byte[] dataparsed; public byte[] DataParsed { get => dataparsed; }
			private readonly int addr; public int Address { get => addr; }

			private string sout;
			public MessageData(int i, int a, string sraw, byte[] draw, string spar, byte[] dpar)
			{
				id = i;
				addr = a;
				dataraw = draw;
				dataparsed = dpar;
				str = sraw;
				strp = spar;
				SetToStringString();
			}

			public void SetMessage(string s)
			{
				strp = s;
				str = OptimizeMessageForDictionary(s);
				RecalculateData();
				SetToStringString();
			}

			private void RecalculateData()
			{
				dataraw = ParseMessageToData(str);
				dataparsed = ParseMessageToData(strp);
			}

			private void SetToStringString()
			{
				sout = string.Format("{0:X3} - {1}", id, strp);
			}
			public override string ToString()
			{
				return sout;
			}

			public string GetReadableDumpedContents()
			{
				StringBuilder d = new StringBuilder(dataraw.Length * 2 + 1);
				foreach (byte b in dataraw)
				{
					d.Append(b.ToString("X2"));
					d.Append(" ");
				}

				return string.Format("[[[[\r\nMessage {0:X3}]]]]\r\n[Contents]\r\n{1}\r\n\r\n[Data]\r\n{2}\r\n\r\n\r\n\r\n",
					id,
					AddNewLinesToCommands(strp),
					d.ToString()
					);
			}
			public string GetDumpedContents()
			{
				return string.Format("{0:X3} : {1}\r\n\r\n", id, strp);
			}
		}
		private class TextElement
		{
			private readonly string token; public string Token { get => token; }
			private readonly string pattern; public string Pattern { get => pattern; }
			private readonly string patternStrict; public string StrictPattern { get => patternStrict; }
			private readonly string desc; public string Description { get => desc; }
			private readonly bool hasParam; public bool HasArgument { get => hasParam; }
			private readonly byte b; public byte ID { get => b; }
			private readonly string gt; public string GenericToken { get => gt; }
			private readonly string strout;

			public TextElement(byte a, string t, bool arg, string d)
			{
				token = t;
				hasParam = arg;

				pattern = string.Format(
					arg ? "\\[{0}:?([0-9A-F]{{1,2}})\\]" : "\\[{0}\\]",
					Regex.Escape(token)); // need to escape to prevent bad with [...]

				patternStrict = string.Format("^{0}$", pattern);

				gt = string.Format(
						 arg ? "[{0}:##]" : "[{0}]",
						 token);

				desc = d;
				b = a;
				strout = string.Format("{0} {1}", gt, desc);
			}

			private const string TokenWithParam = "[{0}:{1:X2}]";
			private const string TokenWithoutParam = "[{0}]";
			public string GetParameterizedToken(byte b = 0)
			{
				if (hasParam)
				{
					return string.Format(TokenWithParam, token, b);
				}
				else
				{
					return string.Format(TokenWithoutParam, token);
				}
			}

			public override string ToString()
			{
				return strout;
			}

			public Match MatchMe(string dfrag)
			{
				return Regex.Match(dfrag, patternStrict);
			}
		}

		private class ParsedElement
		{
			private readonly TextElement parent; public TextElement Parent { get => parent; }
			private readonly byte val; public byte Value { get => val; }

			public ParsedElement(TextElement t, byte v)
			{
				parent = t;
				val = v;
			}
		}

		private static List<DictionaryEntry> AllDicts = new List<DictionaryEntry>();

		public class DictionaryEntry
		{
			private readonly byte id; public byte ID { get => id; }
			private readonly string str; public string Contents { get => str; }
			private readonly byte[] data; public byte[] Data { get => data; }
			private readonly int len; public int Length { get => len; }

			private readonly string token; public string Token { get => token; }

			public DictionaryEntry(byte i, string s)
			{
				str = s;
				id = i;
				len = s.Length;
				token = string.Format("[{0}:{1:X2}]", DICTIONARYTOKEN, id);
				data = ParseMessageToData(str);
			}

			public bool ContainedInString(string s)
			{
				return s.IndexOf(str) >= 0;
			}

			public string ReplaceInstancesOfIn(string s)
			{
				return s.Replace(str, token);
			}
		}

		private const char CHEESE = '\uBEBE'; // inserted into commands to protect them from dictionary replacements
		private static string OptimizeMessageForDictionary(string str)
		{

			// build a new copy of the string where commands have their characters padded with a protective character
			// this way, we can't accidentally replace anything as we do the dictionary stuff
			StringBuilder protons = new StringBuilder();
			bool cmd = false;
			foreach (char c in str)
			{
				if (c == '[')
				{
					cmd = true;
				}
				else if (c == ']')
				{
					cmd = false;
				}
				protons.Append(c);
				if (cmd)
				{
					protons.Append(CHEESE);
				}
			}
			return ReplaceAllDictionaryWords(protons.ToString()).Replace(CHEESE.ToString(), "");
		}

		private static string ReplaceAllDictionaryWords(string s)
		{
			string ret = s;
			foreach (DictionaryEntry w in AllDicts)
			{
				if (w.ContainedInString(ret))
				{
					ret = w.ReplaceInstancesOfIn(ret);
				}
			}
			return ret;
		}
		private static ParsedElement FindMatchingElement(string s)
		{
			Match g;
			foreach (TextElement t in TCommands.Concat(SpecialChars))
			{
				g = t.MatchMe(s);
				if (g.Success)
				{
					if (t.HasArgument)
					{
						return new ParsedElement(t, byte.Parse(g.Groups[1].Value, NumberStyles.HexNumber));
					}
					else
					{
						return new ParsedElement(t, 0);
					}
				}
			}

			// see if dictionary entry
			g = DictionaryElement.MatchMe(s);
			if (g.Success)
			{
				return new ParsedElement(DictionaryElement,
					(byte) (DICTOFF + (byte.Parse(g.Groups[1].Value, NumberStyles.HexNumber))
				));
			}

			return null;
		}
		private static TextElement FindMatchingCommand(byte b)
		{
			foreach (TextElement t in TCommands)
			{
				if (t.ID == b)
				{
					return t;
				}
			}

			return null;
		}

		private static TextElement FindMatchingSpecial(byte b)
		{
			foreach (TextElement t in SpecialChars)
			{
				if (t.ID == b)
				{
					return t;
				}
			}

			return null;
		}

		private int FindDictionaryEntry(byte b)
		{
			if (b < DICTOFF || b == 0xFF)
			{
				return -1;
			}

			return b - DICTOFF;
		}

		public DictionaryEntry GetDictionaryFromID(byte b)
		{
			return AllDicts.First(ddd => ddd.ID == b);
		}

		public static byte FindMatchingCharacter(char c)
		{
			foreach (KeyValuePair<byte, char> kt in CharEncoder)
			{
				if (kt.Value == c)
				{
					return kt.Key;
				}
			}

			return 0xFF;
		}

		private const string BANKToken = "BANK";
		private const byte BANKID = 0x80;

		private static TextElement DictionaryElement = new TextElement(0x80, DICTIONARYTOKEN, true, "Dictionary");

		private static readonly TextElement[] TCommands = new TextElement[] {
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
			new TextElement(BANKID, BANKToken, false, "Bank marker (automatic)"),
			new TextElement(0x70, "NONO", false, "Crash"),
		};

		private static readonly TextElement[] SpecialChars = new TextElement[] {
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

		private static readonly Dictionary<byte, char> CharEncoder = new Dictionary<byte, char> {
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

		public bool SelectMessageID(int i)
		{
			if (i < textListbox.Items.Count)
			{
				textListbox.SelectedIndex = i;
				return true;
			}
			return false;
		}
		private void TextEditor_Load(object sender, EventArgs e)
		{
			//TODO: Add something here?
		}

		public void ReadAllTextDataFromROM()
		{
			int tt = 0;
			byte b;
			int pos = Constants.text_data;
			List<byte> tempBytesRaw = new List<byte>();
			List<byte> tempBytesParsed = new List<byte>();

			StringBuilder currentMessageRaw = new StringBuilder();
			StringBuilder currentMessageParsed = new StringBuilder();
			TextElement t;

			while (true)
			{
				b = ZS.ROM[pos++];

				tempBytesRaw.Add(b);

				if (b == MessageTerminator)
				{
					tempBytesParsed.Add(b);
					listOfTexts.Add(new MessageData(tt++, pos,
						currentMessageRaw.ToString(),
						tempBytesRaw.ToArray(),
						currentMessageParsed.ToString(),
						tempBytesParsed.ToArray()
						));
					tempBytesRaw.Clear();
					tempBytesParsed.Clear();
					currentMessageRaw.Clear();
					currentMessageParsed.Clear();
					continue;
				}
				else if (b == 0xFF)
				{
					break;
				}


				// check for command
				if ((t = FindMatchingCommand(b)) != null)
				{
					tempBytesParsed.Add(b);
					if (t.HasArgument)
					{
						b = ZS.ROM[pos++];
						tempBytesRaw.Add(b);
						tempBytesParsed.Add(b);
					}

					currentMessageRaw.Append(t.GetParameterizedToken(b));
					currentMessageParsed.Append(t.GetParameterizedToken(b));

					if (t.Token == BANKToken)
					{
						pos = Constants.text_data2;
					}

					continue;
				}

				// check for special characters
				if ((t = FindMatchingSpecial(b)) != null)
				{
					currentMessageRaw.Append(t.GetParameterizedToken());
					currentMessageParsed.Append(t.GetParameterizedToken());
					tempBytesParsed.Add(b);
					continue;
				}

				// check for dictionary
				int dict = FindDictionaryEntry(b);

				if (dict >= 0)
				{
					currentMessageRaw.Append($"[{DICTIONARYTOKEN}:{dict:X2}]");

					int addr = SNESFunctions.SNEStoPC(0x0E0000 | ZS.ROM[Constants.pointers_dictionaries + (dict * 2), 2]);
					int addrend = SNESFunctions.SNEStoPC(0x0E0000 | ZS.ROM[Constants.pointers_dictionaries + ((dict + 1) * 2), 2]);

					for (int i = addr; i < addrend; i++)
					{
						byte dadd = ZS.ROM[i];
						tempBytesParsed.Add(dadd);
						currentMessageParsed.Append(ParseTextDataByte(dadd));
					}
					continue;
				}


				// everything else
				if (CharEncoder.ContainsKey(b))
				{
					currentMessageRaw.Append(CharEncoder[b]);
					currentMessageParsed.Append(CharEncoder[b]);
					tempBytesParsed.Add(b);
				}
			}

			//00074703
		}

		public void BuildDictionaryEntriesFromROM()
		{
			for (int i = 0; i < 97; i++)
			{
				List<byte> bytes = new List<byte>();
				StringBuilder s = new StringBuilder();

				int addr = SNESFunctions.SNEStoPC(0x0E0000 | ZS.ROM[Constants.pointers_dictionaries + (i * 2), 2]);
				int tempaddr = SNESFunctions.SNEStoPC(0x0E0000 | ZS.ROM[Constants.pointers_dictionaries + ((i + 1) * 2), 2]);

				while (addr < tempaddr)
				{
					byte bdictionary = ZS.ROM[addr++];
					bytes.Add(bdictionary);
					s.Append(ParseTextDataByte(bdictionary));
				}

				AllDicts.Add(new DictionaryEntry((byte) i, s.ToString()));
			}

			AllDicts.OrderByDescending(dic => dic.Length);
		}

		public static byte[] ParseMessageToData(string fullString)
		{
			List<byte> bytes = new List<byte>();
			string s = fullString;
			int pos = 0;
			ParsedElement p;

			while (pos < s.Length)
			{
				// get next text fragment
				if (s[pos] == '[')
				{
					int next = s.IndexOf(']', pos);
					if (next == -1)
					{
						break;
					}

					p = FindMatchingElement(s.Substring(pos, next - pos + 1));
					if (p == null)
					{
						break; // TODO handle badness
					}
					else if (p.Parent == DictionaryElement)
					{
						bytes.Add(p.Value);
					}
					else
					{
						bytes.Add(p.Parent.ID);

						if (p.Parent.HasArgument)
						{
							bytes.Add(p.Value);
						}
					}

					pos = next + 1;
					continue;
				}
				else
				{
					byte bb = FindMatchingCharacter(s[pos++]);

					if (bb != 0xFF)
					{ // TODO handle badness
						bytes.Add(bb);
					}
				}
			}

			bytes.Add(MessageTerminator);
			return bytes.ToArray();
		}


		public string ParseTextDataByte(byte b)
		{
			if (CharEncoder.ContainsKey(b))
			{
				return CharEncoder[b].ToString();
			}

			TextElement t;

			// check for command
			if ((t = FindMatchingCommand(b)) != null)
			{
				return t.GenericToken;
			}

			// check for special characters
			if ((t = FindMatchingSpecial(b)) != null)
			{
				return t.GenericToken;
			}

			// check for dictionary
			int dict = FindDictionaryEntry(b);

			if (dict >= 0)
			{
				return $"[{DICTIONARYTOKEN}:{dict:X2}]";
			}

			return "";
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//TODO: Add Something here?

			/* 
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Snes ROM|*.sfc;*.smc";

            if (of.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(of.FileName, FileMode.Open, FileAccess.Read))
                {
                    romname = of.FileName;
                    ZS.ROM.DATA = new byte[fs.Length];
                    fs.Read(ZS.ROM.DATA, 0, (int)fs.Length);
                    fs.Close();
                }
            }*/
		}

		private static readonly Color[] previewColors = new Color[] {
			Color.DimGray,
			Color.DarkBlue,
			Color.White,
			Color.DarkOrange
		};

		public void InitializeOnOpen()
		{
			panel1.Enabled = true;
			for (int i = 0; i < 100; i++)
			{
				widthArray[i] = ZS.ROM[Constants.characters_width + i];
			}

			ZS.GFXManager.fontgfxBitmap = new Bitmap(128, 128, 64, PixelFormat.Format4bppIndexed, ZS.GFXManager.fontgfx16Ptr);
			ZS.GFXManager.currentfontgfx16Bitmap = new Bitmap(172, 4096, 172, PixelFormat.Format8bppIndexed, ZS.GFXManager.currentfontgfx16Ptr);


			ColorPalette cp1 = ZS.GFXManager.fontgfxBitmap.Palette;
			for (int i = 0; i < previewColors.Length; i++)
			{
				cp1.Entries[i] = previewColors[i];
			}
			ZS.GFXManager.fontgfxBitmap.Palette = cp1;

			BuildDictionaryEntriesFromROM();
			ReadAllTextDataFromROM();

			foreach (MessageData s in listOfTexts)
			{
				DisplayedMessages.Add(s);
			}

			textListbox.BeginUpdate();
			textListbox.DataSource = DisplayedMessages;
			textListbox.EndUpdate();

			textListbox.DisplayMember = "Text";
			pictureBox2.Refresh();

			SelectedTileID.Text = selectedTile.ToString("X2");
			SelectedTileASCII.Text = ParseTextDataByte((byte) selectedTile);

			ZS.GFXManager.CreateFontGfxData(ZS.ROM.DataStream);
		}


		private static string AddNewLinesToCommands(string s)
		{
			return Regex.Replace(s, @"\[[123V]\]", "\r\n$0");
		}


		private void textListbox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (textListbox.SelectedIndex == -1)
			{
				//CurrentMessage = null;
				return;
			}
			//MessageData msg = listOfTexts[(int) (textListbox.Items[textListbox.SelectedIndex] as ListViewItem).Tag];
			CurrentMessage = textListbox.Items[textListbox.SelectedIndex] as MessageData;
			//Console.WriteLine(savedTexts[textListbox.SelectedIndex]);
			/*for (int i = 0; i < savedBytes[textListbox.SelectedIndex].Length; i++)
            {
                Console.Write(savedBytes[textListbox.SelectedIndex][i].ToString("X2") + " ");
            }*/
			//Console.WriteLine();

			// TODO need to adjust this because it keeps moving where the cursor is
			textBox1.Text = AddNewLinesToCommands(CurrentMessage.ContentsParsed);

			DrawMessagePreview();

			pictureBox1.Refresh();
		}

		private unsafe void DrawStringToPreview(string s)
		{
			foreach (char c in s)
			{
				DrawCharacterToPreview(c);
			}
		}

		private unsafe void DrawCharacterToPreview(char c)
		{
			DrawCharacterToPreview(FindMatchingCharacter(c));
		}

		/// <summary>
		/// Includes parentheses to be longer, since player names can be up to 6 characters.
		/// </summary>
		private const string NAMEPreview = "(NAME)";
		private unsafe void DrawCharacterToPreview(params byte[] text)
		{
			foreach (byte b in text)
			{
				if (skipNext)
				{
					skipNext = false;
					continue;
				}

				if (b < 100)
				{
					if (textPos >= 170)
					{
						textPos = 0;
						textLine++;
					}

					DrawTileToPreview(textPos, textLine * 16, b & 0xF, b / 16, 0, false, false, 1, 2);
					textPos += widthArray[b];
				}
				else if (b == 0x74)
				{
					textPos = 0;
					textLine = 0;
				}
				else if (b == 0x73)
				{
					textPos = 0;
					textLine++;
				}
				else if (b == 0x75)
				{
					textPos = 0;
					textLine = 1;
				}
				else if (b == 0x76)
				{
					textPos = 0;
					textLine = 2;
				}
				else if (b == 0x6B || b == 0x6D || b == 0x6E || b == 0x77 || b == 0x78 || b == 0x79 || b == 0x7A)
				{
					skipNext = true;
					continue;
				}
				else if (b == 0x6C) // BCD numbers
				{
					DrawCharacterToPreview('0');
					skipNext = true;
					continue;
				}
				else if (b == 0x6A)
				{
					DrawStringToPreview(NAMEPreview);
				}
				else if (b >= DICTOFF && b < (DICTOFF + 97))
				{
					DictionaryEntry d = GetDictionaryFromID((byte) (b - DICTOFF));
					if (d != null)
					{
						DrawCharacterToPreview(d.Data);
					}
				}
				else if (b == MessageTerminator)
				{
					return;
				}
			}
		}

		private unsafe void DrawMessagePreview() //From Parsing
		{
			//defaultColor = 6;
			textLine = 0;
			byte* ptr = (byte*) ZS.GFXManager.currentfontgfx16Ptr.ToPointer();

			for (int i = 0; i < (172 * 4096); i++)
			{
				ptr[i] = 0;
			}

			textPos = 0;
			DrawCharacterToPreview(CurrentMessage.Data);

			shownLines = 0;
		}

		private unsafe void DrawTileToPreview(int x, int y, int srcx, int srcy, int pal, bool mirror_x = false, bool mirror_y = false, int sizex = 1, int sizey = 1)
		{
			var alltilesData = (byte*) ZS.GFXManager.fontgfx16Ptr.ToPointer();

			byte* ptr = (byte*) ZS.GFXManager.currentfontgfx16Ptr.ToPointer();

			int drawid = srcx + (srcy * 32);
			int tx = (drawid / 16 * 512) + ((drawid & 0x0F) * 4);

			y *= 172;

			for (int yl = 0; yl < sizey * 8; yl++)
			{
				for (int xl = 0; xl < 4; xl++)
				{

					//Formula information to get tile index position in the array
					//((ID / nbrofXtiles) * (imgwidth/2) + (ID - ((ID/16)*16) ))
					byte pixel = alltilesData[tx + (yl * 64) + xl];
					//nx,ny = object position, xx,yy = tile position, xl,yl = pixel position

					int index = x + y + (xl * 2) + (yl * 172);

					if (pixel.BitIsOn(0x0F))
					{
						ptr[index + 1] = (byte) (pixel & 0x0F);
					}

					if (pixel.BitIsOn(0xF0))
					{
						ptr[index + 0] = (byte) (pixel >> 4);
					}
				}
			}
		}

		private void searchTextbox_TextChanged(object sender, EventArgs e)
		{
			DisplayedMessages.Clear();
			string searchText = searchTextbox.Text.ToLower();

			foreach (MessageData s in listOfTexts)
			{
				if (s.ContentsParsed.ToLower().Contains(searchText))
				{
					DisplayedMessages.Add(s);
				}
			}

			textListbox.BeginUpdate();
			textListbox.DataSource = null;
			textListbox.DataSource = DisplayedMessages;
			textListbox.EndUpdate();
		}

		private static readonly Pen CharHilite = new Pen(Brushes.HotPink, 2);
		private static readonly Pen GridHilite = new Pen(Color.FromArgb(0x77CCCCCC), 2);
		private void pictureBox2_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
			e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			e.Graphics.DrawImage(ZS.GFXManager.fontgfxBitmap, Constants.Rect_0_0_256_256);

			if (fontGridBox.Checked)
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

			int srcY = selectedTile / 16;
			int srcX = selectedTile - (srcY * 16);
			e.Graphics.DrawRectangle(CharHilite, new Rectangle(srcX * 16, srcY * 32, 16, 32));
		}


		private void pictureBox3_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
			e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			e.Graphics.DrawImage(ZS.GFXManager.fontgfxBitmap,
				Constants.Rect_0_0_64_128,
				new Rectangle((selectedTile - (selectedTile & 0xF0)) * 8, selectedTile & 0xF0, 8, 16),
				GraphicsUnit.Pixel);

			if (fontGridBox.Checked)
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

		private void pictureBox1_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
			ColorPalette cp = ZS.GFXManager.currentfontgfx16Bitmap.Palette;

			for (int i = 0; i < 4; i++)
			{
				if (i == 0)
				{
					cp.Entries[i] = Color.Transparent;
				}
				else
				{
					cp.Entries[i] = ZS.GFXManager.roomBg1Bitmap.Palette.Entries[(DefaultTextColor * 4) + i];
				}
			}

			ZS.GFXManager.currentfontgfx16Bitmap.Palette = cp;

			e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			e.Graphics.DrawImage(
				ZS.GFXManager.currentfontgfx16Bitmap,
				new Rectangle(0, 0, 340, pictureBox2.Height),
				new Rectangle(0, shownLines * 16, 170, pictureBox2.Height / 2),
				GraphicsUnit.Pixel);
			e.Graphics.FillRectangle(
				Constants.HalfRedBrush,
				new Rectangle(344 - 8, 0, 4, pictureBox2.Height));
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
						data[i] = ZS.ROM[Constants.gfx_font + i];
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
						ZS.ROM[Constants.gfx_font + i] = data[i];
					}

					for (int i = 0; i < 100; i++)
					{
						ZS.ROM[Constants.characters_width + i] = data[i + 0x1000];
					}

					ZS.GFXManager.CreateFontGfxData(ZS.ROM.DataStream);
					pictureBox2.Refresh();
				}
			}
		}

		private const int SpaceForBank1Text = 0x8000;
		private const int SpaceForBank2Text = 0x14BF;
		public bool Save()
		{
			byte[] backup = ZS.ROM.DataStream.DeepCopy();

			ZS.ROM.Write(Constants.characters_width, widthArray);

			int pos = Constants.text_data;
			bool expandedRegion = false;

			foreach (MessageData m in listOfTexts)
			{
				for (int i = 0; i < m.Data.Length;)
				{
					byte b = m.Data[i];

					// check if this byte corresponds to a command with an argument or not
					bool hasarg = FindMatchingCommand(b)?.HasArgument ?? false;
					if (hasarg)
					{
						// not much space, add the bank token
						if (!expandedRegion && pos >= (Constants.text_data + SpaceForBank1Text - 1))
						{
							ZS.ROM[pos] = BANKID;
							pos = Constants.text_data2;
							expandedRegion = true;
							continue;
						}
						// oh no! way too much space
						else if (expandedRegion && (pos >= (Constants.text_data2 + SpaceForBank2Text - 1)))
						{
							int spaceused = 0;

							foreach (MessageData m2 in listOfTexts)
							{
								spaceused += m2.Data.Length;
							}

							MessageBox.Show(string.Format(
								"There is too much text data to save.\n" +
								"Available: {0:X4} | Used: {1:X4}",
								SpaceForBank1Text + SpaceForBank2Text, spaceused));

							return ZS.ROM.OhShitLastResortBackup(backup);
						}

						ZS.ROM[pos++] = m.Data[i++];
						ZS.ROM[pos++] = m.Data[i++];
						continue;
					}

					// add the bank byte when we hit this spot
					if (!expandedRegion && pos == Constants.text_data + SpaceForBank1Text)
					{
						if (b == BANKID) // catch user-inserted bank token
						{
							i++; // increment to skip it from being written in second text bank
						}

						ZS.ROM[pos] = BANKID;
						pos = Constants.text_data2;
						expandedRegion = true;
						continue;
					}

					// TODO warnings about bank markers when a lot of space remains
					if (b == BANKID)
					{
						if (expandedRegion)
						{
							MessageBox.Show(
								$"A second bank marker was found in Message {m.ID:X3}.\nThis is not a legal move.");

							return ZS.ROM.OhShitLastResortBackup(backup);
						}
					}

					ZS.ROM[pos++] = b;
					i++;

					// never get too close to the end
				}
			}

			return false;
		}

		private void CryAboutTooMuchText(int pos, bool bank2)
		{

		}

		private void numericUpDown1_ValueChanged(object sender, EventArgs e)
		{
			if (!fromForm)
			{
				widthArray[selectedTile] = (byte) numericUpDown1.Value;
			}
		}

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
			SelectedTileID.Text = selectedTile.ToString("X2");
			SelectedTileASCII.Text = ParseTextDataByte((byte) selectedTile);
			pictureBox2.Refresh();
			pictureBox3.Refresh();
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			// TODO is fromForm necessary?
			//if (!fromForm) 
			//{
			UpdateTextBox();
			//}
		}

		/// <summary>
		/// Adds a command to the text field when the Add command button is pressed or the command is double clicked in the list.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void InsertCommandButton_Click_1(object sender, EventArgs e)
		{
			InsertSelectedText(TCommands[TextCommandList.SelectedIndex].GetParameterizedToken((byte) ParamsBox.HexValue));
		}

		/// <summary>
		/// Adds a special character to the text field when the Add command button is pressed or the character is double clicked in the list.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void InsertSpecialButton_Click(object sender, EventArgs e)
		{
			InsertSelectedText(SpecialChars[SpecialsList.SelectedIndex].GetParameterizedToken());
		}

		private void InsertSelectedText(string s)
		{
			int textboxPos = textBox1.SelectionStart;
			fromForm = true;
			textBox1.Text = textBox1.Text.Insert(textboxPos, s);
			fromForm = false;
			textBox1.SelectionStart = textboxPos + s.Length;
			textBox1.Focus();
		}

		/// <summary>
		/// Is called when the text box is updated, updates the preview and writes the char byts to an array.
		/// </summary>
		private void UpdateTextBox()
		{
			if (textListbox.SelectedItem != null)
			{
				CurrentMessage.SetMessage(Regex.Replace(textBox1.Text, @"[\r\n]", ""));

				textListbox.BeginUpdate();
				textListbox.DataSource = null;
				textListbox.DataSource = DisplayedMessages;
				textListbox.EndUpdate();

				//savedBytes[(int)selectedTextTag] = parseTextToBytes(textBox1.Text);

				DrawMessagePreview();
				pictureBox1.Refresh();
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			DictionariesForm df = new DictionariesForm(ZS);
			df.listBox1.Items.Clear();

			foreach (DictionaryEntry d in AllDicts)
			{
				df.listBox1.Items.Insert(
					d.ID,
					string.Format("{0:X2} [{1:X2}] - {2}",
					d.ID,
					d.ID + DICTOFF,
					d.Contents.Replace(" ", "[Space]")));
			}

			df.ShowDialog();
		}

		private void dumpTextsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string[] alltexts = new string[listOfTexts.Count];
			int i = 0;
			foreach (MessageData m in listOfTexts)
			{
				alltexts[i++] = m.GetDumpedContents();
			}

			File.WriteAllLines("dump.txt", alltexts);
		}

		private void button5_Click(object sender, EventArgs e)
		{
			ZS.ROM.Write(Constants.characters_width, widthArray);

			using (var fs = new FileStream(romname, FileMode.OpenOrCreate, FileAccess.Write))
			{
				fs.Write(ZS.ROM.DataStream, 0, ZS.ROM.Length);
				fs.Close();
			}
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			//TODO: Add something here?
		}

		// TODO needs a rewrite
		private void toolStripButton2_Click(object sender, EventArgs e)
		{
			//using (OpenFileDialog of = new OpenFileDialog()) 
			//{
			//    of.DefaultExt = ".txt";
			//    if (of.ShowDialog() == DialogResult.OK) 
			//    {
			//        string[] alltexts = File.ReadAllLines(of.FileName);
			//        for (int i = 0; i < alltexts.Length; i++)
			//        {
			//            if (alltexts[i].Length > 3)
			//            {
			//                int id = int.Parse(alltexts[i].Substring(0, 3));
			//                listOfTexts[id] = new StringKey(alltexts[i].Substring(5, alltexts[i].Length - 5), new byte[] { });
			//            }
			//        }
			//
			//        sortText();
			//    }
			//}
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
						alltexts[i] = i.ToString("X3") + " : " + listOfTexts[i].ContentsParsed + "\r\n\r\n";
					}

					File.WriteAllLines(sf.FileName, alltexts);
				}
			}
		}

		private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			//TODO: Add something here?
		}

		public void delete()
		{
			// Determine if any text is selected in the TextBox control.
			if (textBox1.SelectionLength == 0)
			{
				//clear all of the text in the textbox
				textBox1.Clear();
			}
		}

		public void selectAll()
		{
			// Determine if any text is selected in the TextBox control.
			if (textBox1.SelectionLength == 0)
			{
				// Select all text in the text box.
				textBox1.SelectAll();
				// Move the cursor to the text box.
				textBox1.Focus();
			}
		}

		public void cut()
		{
			// Ensure that text is currently selected in the text box.   
			if (textBox1.SelectedText != "")
			{
				// Cut the selected text in the control and paste it into the Clipboard.
				textBox1.Cut();
			}
		}

		public void paste()
		{
			// Determine if there is any text in the Clipboard to paste into the textbox        
			if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
			{
				textBox1.Paste();
			}
		}

		public void copy()
		{
			// Ensure that text is selected in the text box.   
			if (textBox1.SelectionLength > 0)
			{
				// Copy the selected text to the Clipboard.
				textBox1.Copy();
			}
		}

		public void undo()
		{
			// Determine if last operation can be undone in text box.   
			if (textBox1.CanUndo)
			{
				// Undo the last operation.
				textBox1.Undo();
				// Clear the undo buffer to prevent last action from being redone.
				textBox1.ClearUndo();
			}
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			ParamsBox.Enabled = TCommands[TextCommandList.SelectedIndex].HasArgument;
		}

		readonly MessageAsBytes byter = new MessageAsBytes();
		private void BytesDDD_Click(object sender, EventArgs e)
		{
			if (textListbox.SelectedIndex < 0)
			{
				return;
			}

			byter.ShowBytes(CurrentMessage);
		}

		private void fontGridBox_CheckedChanged(object sender, EventArgs e)
		{
			pictureBox2.Refresh();
			pictureBox3.Refresh();
		}


		private void pictureBox1_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Delta > 1)
			{
				ScrollTextPreviewUp();
			}
			else if (e.Delta < 1)
			{
				ScrollTextPreviewDown();
			}
		}


		private void downButton_Click(object sender, EventArgs e)
		{
			ScrollTextPreviewDown();
		}
		private void ScrollTextPreviewDown()
		{
			if (shownLines < textLine - 2)
			{
				shownLines++;
			}

			pictureBox1.Refresh();
		}

		private void upButton_Click(object sender, EventArgs e)
		{
			ScrollTextPreviewUp();
		}

		private void ScrollTextPreviewUp()
		{
			if (shownLines > 0)
			{
				shownLines--;
			}

			pictureBox1.Refresh();
		}
	}
}
