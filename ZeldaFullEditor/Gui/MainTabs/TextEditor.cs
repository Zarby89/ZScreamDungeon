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

		private const string BankSwapToken = "BANK";
		public const string DictionaryToken = "D";
		public const byte DictionaryBase = 0x88;
		public const byte NumberOfDictionaryEntries = 0x61;
		private const int DictionarySize = 0xEC8D9 - 0xEC7C7;
		public const byte MessageTerminator = 0x7F;
		public const byte NumberOfCharacters = 100;

		readonly byte[] widthArray = new byte[NumberOfCharacters];
		static readonly int defaultColor = 6;
		readonly string romname = string.Empty;

		int textLine = 0;
		int textPos = 0;
		int shownLines = 0;
		int selectedTile = 0;
		bool skipNext = false;
		bool fromForm = false;

		readonly List<MessageData> ListOfTexts = new List<MessageData>();
		public List<MessageData> DisplayedMessages = new List<MessageData>();
		private MessageData CurrentMessage;

		private static readonly Pen CharHilite = new Pen(Brushes.HotPink, 2);
		private static readonly Pen GridHilite = new Pen(Color.FromArgb(0x77CCCCCC), 2);

		public static TextElement DictionaryElement = new TextElement(0x80, DictionaryToken, true, "Dictionary");

		public static List<DictionaryEntry> AllDictionaries = new List<DictionaryEntry>();

		public TextEditor()
		{
			InitializeComponent();
			TextCommandList.Items.AddRange(TextCommands);
			SpecialsList.Items.AddRange(SpecialChars);
			pictureBox1.MouseWheel += new MouseEventHandler(PictureBox1_MouseWheel);
		}

		public class TextElement
		{
			public byte ID { get; }

			public string Token { get; }

			public string GenericToken { get; }

			public string Pattern { get; }

			public string StrictPattern { get; }

			public string Description { get; }

			public bool HasArgument { get; }

			public TextElement(byte id, string token, bool arg, string description)
			{
				ID = id;
				Token = token;
				GenericToken = string.Format(arg ? "[{0}:##]" : "[{0}]", Token);
				HasArgument = arg;
				Description = description;
				Pattern = string.Format(arg ? "\\[{0}:?([0-9A-F]{{1,2}})\\]" : "\\[{0}\\]", Regex.Escape(Token)); // Need to escape to prevent bad with [...]
				StrictPattern = $"^{Pattern}$";
			}

			public string GetParameterizedToken(byte value = 0)
			{
				if (HasArgument)
				{
					return $"[{Token}:{value:X2}]";
				}
				else
				{
					return $"[{Token}]";
				}
			}

			public override string ToString()
			{
				return $"{GenericToken} {Description}";
			}

			public Match MatchMe(string dfrag)
			{
				return Regex.Match(dfrag, StrictPattern);
			}
		}

		public class ParsedElement
		{
			public TextElement ElementType { get; }

			public byte Value { get; }

			public ParsedElement(TextElement textElement, byte value)
			{
				ElementType = textElement;
				Value = value;
			}
		}

		public class DictionaryEntry
		{
			public byte ID { get; }

			public int RealID => ID + DictionaryBase;

			public string Contents { get; }

			public byte[] Data { get; }

			public int Length { get; }

			public string Token { get; }

			public DictionaryEntry(byte id, string contents)
			{
				Contents = contents;
				ID = id;
				Length = contents.Length;
				Token = $"[{DictionaryToken}:{ID:X2}]";
				Data = ParseMessageToData(Contents);
			}

			public bool ContainedInString(string str)
			{
				return str.IndexOf(Contents) >= 0;
			}

			public string ReplaceInstancesOfIn(string str)
			{
				return str.Replace(Contents, Token);
			}

			public string ToPrettyString()
			{
				return $"{ID:X2} [{ID + DictionaryBase:X2}] - {Contents.Replace(" ", "[Space]")}";
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
					(byte) (DictionaryBase + byte.Parse(match.Groups[1].Value, NumberStyles.HexNumber)));
			}

			return null;
		}

		public TextElement FindMatchingCommand(byte b)
		{
			return TextCommands.FirstOrDefault(e => e.ID == b);
		}

		public TextElement FindMatchingSpecial(byte value)
		{
			return SpecialChars.FirstOrDefault(e => e.ID == value);
		}

        // TODO: Modify this routine to take the dictionary as argument and return the value rather than the position.
        public int FindDictionaryEntry(byte value)
		{
			if (value < DictionaryBase || value == 0xFF)
			{
				return -1;
			}

			return value - DictionaryBase;
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
			new TextElement(0x80, BankSwapToken, false, "Bank marker (automatic)"),
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
			if (id < textListbox.Items.Count)
			{
				textListbox.SelectedIndex = id;

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

				if (value == MessageTerminator)
				{
					var message = new MessageData(
						messageID++,
						pos,
						currentMessageRaw.ToString(),
						tempBytesRaw.ToArray(),
						currentMessageParsed.ToString(),
						tempBytesParsed.ToArray());

					ListOfTexts.Add(message);

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
				textElement = FindMatchingCommand(value);

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

					if (textElement.Token == BankSwapToken)
					{
						pos = Constants.text_data2;
					}

					continue;
				}

				// Check for special characters.
				textElement = FindMatchingSpecial(value);

				if (textElement != null)
				{
					currentMessageRaw.Append(textElement.GetParameterizedToken());
					currentMessageParsed.Append(textElement.GetParameterizedToken());
					tempBytesParsed.Add(value);
					continue;
				}

				// Check for dictionary.
				int dictionary = FindDictionaryEntry(value);

				if (dictionary >= 0)
				{
					currentMessageRaw.Append($"[{DictionaryToken}:{dictionary:X2}]");

					int address = Utils.Get24LocalFromPC(Constants.pointers_dictionaries + (dictionary * 2));
					int addressEnd = Utils.Get24LocalFromPC(Constants.pointers_dictionaries + ((dictionary + 1) * 2));

					for (int i = address; i < addressEnd; i++)
					{
						tempBytesParsed.Add(ROM.DATA[i]);
						currentMessageParsed.Append(ParseTextDataByte(ROM.DATA[i]));
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

		// TODO this needs to handle pointers being the same and considering that a stopping point probably
		public void BuildDictionaryEntriesFromROM()
		{
			for (int i = 0; i < NumberOfDictionaryEntries; i++)
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
					stringBuilder.Append(ParseTextDataByte(byteDictionary));
				}

				AllDictionaries.Add(new DictionaryEntry((byte) i, stringBuilder.ToString()));
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
					else if (parsedElement.ElementType == DictionaryElement)
					{
						bytes.Add(parsedElement.Value);
					}
					else
					{
						bytes.Add(parsedElement.ElementType.ID);

						if (parsedElement.ElementType.HasArgument)
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
			TextElement textElement = FindMatchingCommand(value);

			if (textElement != null)
			{
				return textElement.GenericToken;
			}

			// Check for special characters.
			textElement = FindMatchingSpecial(value);

			if (textElement != null)
			{
				return textElement.GenericToken;
			}

			// Check for dictionary.
			int dictionary = FindDictionaryEntry(value);

			if (dictionary >= 0)
			{
				return $"[{DictionaryToken}:{dictionary:X2}";
			}

			return string.Empty;
		}




















		// TODO have a way to restore vanilla
		// TODO have a warning about time (if this takes too long during testing)
		// TODO add a progress bar?
		// TODO test and integrate
		private void ReoptimizeDictionary()
		{
			var startOptimization =
				MessageBox.Show(
					"You are about to replace the optimization dictionary with new data.\r\n" +
					"It may be posssible to further optimize the dictionary at a later point if message data is changed.\r\n" +
					"Do you wish to continue?",
					"Begin optimization?",
					MessageBoxButtons.OKCancel,
					MessageBoxIcon.Warning
				);

			if (startOptimization == DialogResult.Cancel)
			{
				MessageBox.Show(
					"Dictionary optimization cancelled.",
					"Optimization cancelled",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information
				);
				return;
			}

			var newCandidates = new Dictionary<string, int>();
			var allSubstrings = new List<string>();

			// count bytes saved for current dictionary
			int originalParsedsize = 0;
			int originalCompressedsize = 0;

			var sub = new StringBuilder();

			// collect all valid substrings for parsing from the existing messages
			foreach (var msg in ListOfTexts)
			{

				originalCompressedsize += msg.Data.Length + 1; // +1 because message data doesn't include the terminator
				originalParsedsize += msg.DataParsed.Length + 1;

				foreach (var b in msg.DataParsed) // check each byte
				{
					// if the byte is a valid character
					// add it
					// valid characters are nonspecial and encoded as space or below
					if (b < 0x5A && CharEncoder.ContainsKey(b))
					{
						sub.Append(CharEncoder[b]);
						continue;
					}

					// if the byte is not a valid character
					// add the substring and start a new one
					// don't add anything that's empty or only 1 character, because that should never be an entry
					if (sub.Length > 1)
					{
						allSubstrings.Add(sub.ToString());
					}

					sub.Clear();
				}

				// add any leftovers
				if (sub.Length > 1)
				{
					allSubstrings.Add(sub.ToString());
				}

				sub.Clear();
			}

			// count up all the possible substrings
			foreach (var s in allSubstrings)
			{
				for (int start = 0; start < s.Length - 1; start++)
				{
					for (int length = 2; length < s.Length - start; length++)
					{
						string subD = s.Substring(start, length);

						if (newCandidates.ContainsKey(subD))
						{
							newCandidates[subD]++;
						}
						else
						{
							newCandidates[subD] = 1;
						}
					}
				}
			}

			// project the substrings with their counts into a sortable thing
			// also, remove anything with only 1 entry, since it's useless
			var sortableCandidates = newCandidates.Where(kv => kv.Value > 1).Select(kv => kv).ToList();

			SortSelectedCandidates(); // sorting should help with the scraping, but maybe not, depending on the algo

			// TODO this number can be fine-tuned later for time
			for (int passes = 0; passes < 5; passes++)
			{
				// remove candidates that are strict substrings of higher scoring entries
				// TODO there's probably a better way to optimize this

				var removedCandidates = new List<KeyValuePair<string, int>>();

				foreach (var a in sortableCandidates)
				{
					if (removedCandidates.Contains(a)) // skip removed entries
					{
						continue;
					}

					foreach (var b in sortableCandidates)
					{
						if (a.Key == b.Key) // skip self
						{
							continue;
						}

						if (removedCandidates.Contains(b)) // skip removed entries
						{
							continue;
						}

						// spaces are kinda special, so they shouldn't be too grossly optimized
						// TODO or maybe they should?

						if (a.Key.Contains(b.Key))
						{
							int ascore = ScoreEntry(a);
							int bscore = ScoreEntry(b);

							// TODO this is going to be the most important algorithm here
							if (a.Value > (b.Value * 5) && (ascore > bscore * 2))
							{
								removedCandidates.Add(b); // don't use this substring
							}
						}
					}
				}

				// remove deleted candidates
				int changed = sortableCandidates.RemoveAll(kv => removedCandidates.Contains(kv));

				// short circuit if too few removals
				if (changed < 5)
				{
					break;
				}
			}

			// one more sort for good measure
			SortSelectedCandidates();

			// select candidates by score first, then try to optimize space
			var selectedCandidates = new List<KeyValuePair<string, int>>();
			int usedspace = 0;
			int tokencount = 0;
			int newCompressedSavings = 0;

			foreach (var cand in sortableCandidates)
			{
				// check size
				if (usedspace + cand.Key.Length > DictionarySize)
				{
					continue;
				}

				usedspace += cand.Key.Length; 
				tokencount++;

				selectedCandidates.Add(cand);

				// count up total dictionary savings
				newCompressedSavings += cand.Value * (cand.Key.Length - 1); // -1 because it's a 1 byte token

				// stop at max tokens or space
				if (tokencount == NumberOfDictionaryEntries || usedspace >= (DictionarySize - 1))
				{
					break;
				}
			}

			var replaceDictionary = MessageBox.Show(
				$"You are about to replace the optimization dictionary with new data.\r\n" +
				$"Your current message data is {originalParsedsize:D} bytes" +
				$"or {originalCompressedsize:D} bytes with the existing dictionary" +
				$"for a total savings of {originalParsedsize-originalCompressedsize:D} bytes\r\n" +
				$"With the new dictionary, your savings will be {newCompressedSavings:D} bytes.\r\n" +
				$"It may be possible to further optimize the message data if it is changed.\r\n\r\n" +
				$"Do you wish to continue?",

				"Confirm replacement",
				MessageBoxButtons.OKCancel,
				MessageBoxIcon.Warning);


			// sort the dictionary by size, so that the longest phrases are the first to be checked
			selectedCandidates.Sort((a, b) =>
			{

				int baseCompare = b.Key.Length.CompareTo(a.Key.Length); // compare it backwards to get a free descending sort

				if (baseCompare == 0) // if both have the same length, just go alphabetically
				{
					return b.Key.CompareTo(a.Key);
				}

				return baseCompare;
			});

			// create the new dictionary
			AllDictionaries.Clear();
			byte dID = 0; // dictionary ID
			selectedCandidates.ForEach(kv =>
			{
				AllDictionaries.Add(new DictionaryEntry(dID++, kv.Key));
			});

			// refresh messages for the new dictionary
			foreach (var msg in ListOfTexts)
			{
				msg.Refresh();
			}


			// sorts candidates by a score that indicates how much they help optimize the data
			void SortSelectedCandidates()
			{
				sortableCandidates.Sort((a, b) =>
				{
					int baseCompare = ScoreEntry(b).CompareTo(ScoreEntry(a)); // compare it backwards to get a free descending sort

					if (baseCompare == 0) // if both have the same score, give a better score to the shorter phrase
					{
						baseCompare = b.Key.Length.CompareTo(a.Key.Length);

						if (baseCompare == 0) // if they still have the same score, just go alphabetically
						{
							return b.Key.CompareTo(a.Key);
						}

					}

					return baseCompare;
				});
			}

			// creates a score for how many bytes are saved by doing count*length
			int ScoreEntry(KeyValuePair<string, int> scoredCandidate)
			{
				return scoredCandidate.Key.Length * scoredCandidate.Value;
			}
		}







		public void InitializeOnOpen()
		{
			panel1.Enabled = true;
			for (int i = 0; i < NumberOfCharacters; i++)
			{
				widthArray[i] = ROM.DATA[Constants.characters_width + i];
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

			BuildDictionaryEntriesFromROM();
			ReadAllTextDataFromROM();

			// TODO AddRange
			foreach (MessageData messageData in ListOfTexts)
			{
				DisplayedMessages.Add(messageData);
			}

			textListbox.BeginUpdate();
			textListbox.DataSource = DisplayedMessages;
			textListbox.EndUpdate();

			textListbox.DisplayMember = "Text";
			pictureBox2.Refresh();

			SelectedTileID.Text = $"{selectedTile:X2}";
			SelectedTileASCII.Text = ParseTextDataByte((byte) selectedTile);

			GFX.CreateFontGfxData(ROM.DATA);
		}

		public static string AddNewLinesToCommands(string str)
		{
			return Regex.Replace(str, @"\[[123V]\]", "\r\n$0");
		}

		private void TextListbox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (textListbox.SelectedIndex == -1)
			{
				/*
                CurrentMessage = null;
                */

				return;
			}

			/*
            MessageData msg = listOfTexts[(int) (textListbox.Items[textListbox.SelectedIndex] as ListViewItem).Tag];
            */

			CurrentMessage = textListbox.Items[textListbox.SelectedIndex] as MessageData;

			/*
            Console.WriteLine(savedTexts[textListbox.SelectedIndex]);
            for (int i = 0; i < savedBytes[textListbox.SelectedIndex].Length; i++)
            {
                Console.Write(savedBytes[textListbox.SelectedIndex][i].ToString("X2") + " ");
            }

            Console.WriteLine();
            */

			// TODO: Need to adjust this because it keeps moving where the cursor is.
			textBox1.Text = AddNewLinesToCommands(CurrentMessage.ContentsParsed);

			DrawMessagePreview();

			pictureBox1.Refresh();
		}

		public void DrawStringToPreview(string str)
		{
			foreach (char c in str)
			{
				DrawCharacterToPreview(c);
			}
		}

		public void DrawCharacterToPreview(char c)
		{
			DrawCharacterToPreview(FindMatchingCharacter(c));
		}

		public void DrawCharacterToPreview(params byte[] text)
		{
			foreach (byte value in text)
			{
				if (skipNext)
				{
					skipNext = false;
					continue;
				}

				if (value < NumberOfCharacters)
				{
					int srcy = value >> 4;
					int srcx = value & 0xF;

					if (textPos >= 170)
					{
						textPos = 0;
						textLine++;
					}

					DrawTileToPreview(textPos, textLine * 16, srcx, srcy, 0, 1, 2);
					textPos += widthArray[value];
				}
				else if (value == 0x73) // scroll text
				{
					textPos = 0;
					textLine += 1;
				}
				else if (value == 0x74) // line 1
				{
					textPos = 0;
					textLine = 0;
				}
				else if (value == 0x75) // line 2
				{
					textPos = 0;
					textLine = 1;
				}
				else if (value == 0x76) // line 3
				{
					textPos = 0;
					textLine = 2;
				}
				// command with parameters
				else if (value == 0x6B || value == 0x6D || value == 0x6E || value == 0x77 || value == 0x78 || value == 0x79 || value == 0x7A)
				{
					skipNext = true;

					continue;
				}
				else if (value == 0x6C) // BCD numbers
				{
					DrawCharacterToPreview('0'); // draw a big character since this command draws characters
					skipNext = true;

					continue;
				}
				else if (value == 0x6A) // player name
				{
					// Includes parentheses to be longer, since player names can be up to 6 characters.
					DrawStringToPreview("(NAME)");
				}
				else if (value >= DictionaryBase && value < (DictionaryBase + NumberOfDictionaryEntries))
				{
					var dictionaryEntry = AllDictionaries.FirstOrDefault(dictionary => dictionary.RealID == value);
					if (dictionaryEntry != null)
					{
						DrawCharacterToPreview(dictionaryEntry.Data);
					}
				}
			}
		}

		public unsafe void DrawMessagePreview() // From Parsing.
		{
			textLine = 0;
			// TODO try Span<byte> ?
			byte* ptr = (byte*) GFX.currentfontgfx16Ptr.ToPointer();

			for (int i = 0; i < (172 * 4096); i++)
			{
				ptr[i] = 0;
			}

			textPos = 0;
			DrawCharacterToPreview(CurrentMessage.Data);

			shownLines = 0;
		}

		public unsafe void DrawTileToPreview(int x, int y, int srcx, int srcy, int pal, int sizex = 1, int sizey = 1)
		{
			var allTileData = (byte*) GFX.fontgfx16Ptr.ToPointer();

			byte* pointer = (byte*) GFX.currentfontgfx16Ptr.ToPointer();

			int drawid = srcx + (srcy * 32);
			for (int yl = 0; yl < sizey * 8; yl++)
			{
				for (int xl = 0; xl < 4; xl++)
				{
					int mx = xl;
					int my = yl;

					// Formula information to get tile index position in the array.
					// ((ID / nbrofXtiles) * (imgwidth/2) + (ID - ((ID/16)*16) ))
					int tx = ((drawid / 16) * 512) + ((drawid & 0xF) << 2);
					byte pixel = allTileData[tx + (yl * 64) + xl];

					// nx,ny = object position, xx,yy = tile position, xl,yl = pixel position
					int index = x + (y * 172) + (mx * 2) + (my * 172);
					if ((pixel & 0x0F) != 0)
					{
						pointer[index + 1] = (byte) ((pixel & 0x0F) + (0 * 4));
					}

					if (((pixel >> 4) & 0x0F) != 0)
					{
						pointer[index + 0] = (byte) (((pixel >> 4) & 0x0F) + (0 * 4));
					}
				}
			}
		}

		private void SearchTextbox_TextChanged(object sender, EventArgs e)
		{
			DisplayedMessages.Clear();
			string searchText = searchTextbox.Text.ToLower();

			// TODO use Where
			foreach (MessageData messageData in ListOfTexts)
			{
				if (messageData.ContentsParsed.ToLower().Contains(searchText))
				{
					DisplayedMessages.Add(messageData);
				}
			}

			textListbox.BeginUpdate();
			textListbox.DataSource = null;
			textListbox.DataSource = DisplayedMessages;
			textListbox.EndUpdate();
		}

		private void PictureBox2_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
			e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
			e.Graphics.DrawImage(GFX.fontgfxBitmap, Constants.Rect_0_0_256_256);

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

		private void PictureBox3_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
			e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
			e.Graphics.DrawImage(
				GFX.fontgfxBitmap,
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
				new Rectangle(0, 0, 340, pictureBox2.Height),
				new Rectangle(0, shownLines * 16, 170, pictureBox2.Height / 2),
				GraphicsUnit.Pixel);

			e.Graphics.FillRectangle(
				Constants.HalfRedBrush,
				new Rectangle(344 - 8, 0, 4, pictureBox2.Height));
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
						fs.Write(widthArray, 0, NumberOfCharacters);
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
					byte[] data = new byte[0x1000 + NumberOfCharacters];

					// TODO read directly into ROM instead of using data[]
					using (var fileStream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
					{
						fileStream.Read(data, 0, 0x1000 + NumberOfCharacters);
						fileStream.Close();
					}
					// TODO use Write(addr, byte[])
					for (int i = 0; i < 0x1000; i++)
					{
						/*
                        ROM.DATA[Constants.gfx_font + i] = data[i];
                        */

						ROM.Write(Constants.gfx_font + i, data[i], WriteType.FontData);
					}

					for (int i = 0; i < NumberOfCharacters; i++)
					{
						/*
                        ROM.DATA[Constants.characters_width + i] = data[i + 0x1000];
                        */

						ROM.Write(Constants.characters_width + i, data[i + 0x1000], WriteType.FontData);
					}

					GFX.CreateFontGfxData(ROM.DATA);
					pictureBox2.Refresh();
				}
			}
		}

		public bool Save()
		{
			byte[] backup = (byte[]) ROM.DATA.Clone();

			// TODO use Write(addr, byte[])
			for (int i = 0; i < NumberOfCharacters; i++)
			{
				/*
                ROM.DATA[Constants.characters_width + i] = widthArray[i];
                */

				ROM.Write(Constants.characters_width + i, widthArray[i], WriteType.FontData);
			}

			int pos = Constants.text_data;
			bool inSecondBank = false;

			foreach (MessageData message in ListOfTexts)
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
							CryAboutTooMuchText(pos, true);
							ROM.DATA = (byte[]) backup.Clone();
							return true;
						}

						// Switch to the second block.
						pos = Constants.text_data2 - 1;
						inSecondBank = true;
					}

					pos++;
				}

				ROM.Write(pos++, MessageTerminator, true, "Terminator text");
			}

			// Verify that we didn't go over the space available for the second block. 0x14BF available.
			if (inSecondBank & pos > Constants.text_data2_end)
			{
				CryAboutTooMuchText(pos, false);
				ROM.DATA = (byte[]) backup.Clone();
				return true;
			}

			ROM.Write(pos, 0xFF, true, "End of text");

			// TODO test
/*
			// Save dictionary data

			var dictSave = AllDictionaries.ToList(); // get a copy that we can sort
			dictSave.Sort((a, b) => a.ID.CompareTo(b.ID)); // so that the original stays sorted by length

			int dictPtr = Constants.pointers_dictionaries;
			int dictAddr = dictPtr + 2 * NumberOfDictionaryEntries;
			int dictCount = 0;
			int dictSize = 0;

			foreach (var d in AllDictionaries)
			{
				ROM.WriteShort(dictPtr, dictAddr.PcToSnes());
				ROM.Write(dictAddr, d.Data);
				dictPtr += 2;
				dictAddr += d.Data.Length;

				dictCount++;
				dictSize += d.Data.Length;
			}

			if (dictCount > NumberOfDictionaryEntries || dictSize > Dictionarysize)
			{
				ROM.DATA = (byte[]) backup.Clone();
				UIText.CryAboutSaving("The dictionary is too big.");
				return true;
			}

			for (; dictCount <= NumberOfDictionaryEntries + 1; dictCount++) // add remaining end pointers
			{
				ROM.WriteShort(dictPtr, dictAddr.PcToSnes()); // add end pointer
				dictPtr += 2;
			}

			// TODO breakpoint with this to make sure everything is good
			var gggg = ROM.DATA[Constants.pointers_dictionaries + 2 * NumberOfDictionaryEntries];

*/
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
			int posOut = (bank ? pos : pos - Constants.text_data2) & 0xFFFF;

			// TODO UIText.CryAboutSaving
			MessageBox.Show($"There is too much text data in the {bankSTR} block to save.\r\nAvailable: {space:X4} | Used: {posOut:X4}");
		}

		private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
		{
			if (!fromForm)
			{
				widthArray[selectedTile] = (byte) numericUpDown1.Value;
			}
		}

		private void PictureBox2_MouseDown(object sender, MouseEventArgs e)
		{
			selectedTile = (e.X / 16) + ((e.Y / 32) * 16);

			if (selectedTile > 98)
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

		private void TextBox1_TextChanged(object sender, EventArgs e)
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
			InsertSelectedText(TextCommands[TextCommandList.SelectedIndex].GetParameterizedToken((byte) ParamsBox.HexValue));
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

		private void InsertSelectedText(string str)
		{
			int textboxPos = textBox1.SelectionStart;
			fromForm = true;
			textBox1.Text = textBox1.Text.Insert(textboxPos, str);
			fromForm = false;
			textBox1.SelectionStart = textboxPos + str.Length;
			textBox1.Focus();
		}

		/// <summary>
		///		This is called when the text box is updated, updates the preview and writes the char byts to an array.
		/// </summary>
		private void UpdateTextBox()
		{
			if (textListbox.SelectedItem != null)
			{
				CurrentMessage.SetMessage(Regex.Replace(textBox1.Text, @"[\r\n]", string.Empty));
				DrawMessagePreview();
				pictureBox1.Refresh();
			}
		}

		private void Button4_Click(object sender, EventArgs e)
		{
			var dictionariesForm = new DictionariesForm();
			dictionariesForm.listBox1.Items.Clear();

			foreach (var dictEnt in AllDictionaries)
			{
				dictionariesForm.listBox1.Items.Insert(dictEnt.ID, dictEnt.ToPrettyString());
			}

			dictionariesForm.ShowDialog();
		}

		private void DumpTextsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			File.WriteAllLines("dump.txt", ListOfTexts.Select(msg => msg.GetDumpedContents()));
		}

		private void Button5_Click(object sender, EventArgs e)
		{
			// TODO use Write(addr, byte[])
			for (int i = 0; i < NumberOfCharacters; i++)
			{
				//ROM.DATA[Constants.characters_width + i] = widthArray[i];
				ROM.Write(Constants.characters_width + i, widthArray[i], true, "Font widths");
			}

			// TODO isn't this wrong...?
			using (var fileStream = new FileStream(romname, FileMode.OpenOrCreate, FileAccess.Write))
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
					File.WriteAllLines(saveFileDialog.FileName,
						ListOfTexts.Select(msg =>
						$"{msg.ID:x3} : {msg.ContentsParsed}\r\n\r\n"));
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
			if (textBox1.SelectionLength == 0)
			{
				// Clear all of the text in the textbox.
				textBox1.Clear();
			}
		}

		public void SelectAll()
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

		public void Cut()
		{
			// Ensure that text is currently selected in the text box.
			if (textBox1.SelectedText != string.Empty)
			{
				// Cut the selected text in the control and paste it into the Clipboard.
				textBox1.Cut();
			}
		}

		public void Paste()
		{
			// Determine if there is any text in the Clipboard to paste into the textbox.
			if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
			{
				textBox1.Paste();
			}
		}

		public void Copy()
		{
			// Ensure that text is selected in the text box.
			if (textBox1.SelectionLength > 0)
			{
				// Copy the selected text to the Clipboard.
				textBox1.Copy();
			}
		}

		public void Undo()
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

		private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			ParamsBox.Enabled = TextCommands[TextCommandList.SelectedIndex].HasArgument;
		}

		private void BytesDDD_Click(object sender, EventArgs e)
		{
			if (textListbox.SelectedIndex < 0)
			{
				return;
			}

			var byter = new MessageAsBytes();
			byter.ShowBytes(CurrentMessage);
		}

		private void FontGridBox_CheckedChanged(object sender, EventArgs e)
		{
			pictureBox2.Refresh();
			pictureBox3.Refresh();
		}

		private void PictureBox1_MouseWheel(object sender, MouseEventArgs e)
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

		private void DownButton_Click(object sender, EventArgs e)
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

		private void UpButton_Click(object sender, EventArgs e)
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

		private void TextBox1_Leave(object sender, EventArgs e)
		{
			textListbox.BeginUpdate();
			textListbox.DataSource = null;
			textListbox.DataSource = DisplayedMessages;
			textListbox.EndUpdate();
		}
	}
}
