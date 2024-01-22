namespace ZeldaFullEditor;

public partial class TextEditor
{
	private const string BANKToken = "BANK";
	private const byte BANKID = 0x80;

	private static readonly TextElement DictionaryElement = new(0x80, DictionaryToken, true, "Dictionary");

	private static readonly TextElement[] TCommands = {
		new(0x6B, "W", true, "Window border"),
		new(0x6D, "P", true, "Window position"),
		new(0x6E, "SPD", true, "Scroll speed"),
		new(0x7A, "S", true, "Text draw speed"),
		new(0x77, "C", true, "Text color"),
		new(0x6A, "L", false, "Player name"),
		new(0x74, "1", false, "Line 1"),
		new(0x75, "2", false, "Line 2"),
		new(0x76, "3", false, "Line 3"),
		new(0x7E, "K", false, "Wait for key"),
		new(0x73, "V", false, "Scroll text"),
		new(0x78, "WT", true, "Delay X"),
		new(0x6C, "N", true, "BCD number"),
		new(0x79, "SFX", true, "Sound effect"),
		new(0x71, "CH3", false, "Choose 3"),
		new(0x72, "CH2", false, "Choose 2 high"),
		new(0x6F, "CH2L", false, "Choose 2 low"),
		new(0x68, "CH2I", false, "Choose 2 indented"),
		new(0x69, "CHI", false, "Choose item"),
		new(0x67, "IMG", false, "Next attract image"),
		new(BANKID, BANKToken, false, "Bank marker (automatic)"),
		new(0x70, "NONO", false, "Crash"),
	};

	private static readonly TextElement[] SpecialChars = {
		new(0x43, "...", false, "Ellipsis …"),
		new(0x4D, "UP", false, "Arrow ↑"),
		new(0x4E, "DOWN", false, "Arrow ↓"),
		new(0x4F, "LEFT", false, "Arrow ←"),
		new(0x50, "RIGHT", false, "Arrow →"),
		new(0x5B, "A", false, "Button Ⓐ"),
		new(0x5C, "B", false, "Button Ⓑ"),
		new(0x5D, "X", false, "Button ⓧ"),
		new(0x5E, "Y", false, "Button ⓨ"),
		new(0x52, "HP1L", false, "1 HP left" ),
		new(0x53, "HP1R", false, "1 HP right" ),
		new(0x54, "HP2L", false, "2 HP left" ),
		new(0x55, "HP3L", false, "3 HP left" ),
		new(0x56, "HP3R", false, "3 HP right" ),
		new(0x57, "HP4L", false, "4 HP left" ),
		new(0x58, "HP4R", false, "4 HP right" ),
		new(0x47, "HY0", false, "Hieroglyph ☥"),
		new(0x48, "HY1", false, "Hieroglyph 𓈗"),
		new(0x49, "HY2", false, "Hieroglyph Ƨ"),
		new(0x4A, "LFL", false, "Link face left"),
		new(0x4B, "LFR", false, "Link face right"),
	};

	private static readonly Dictionary<byte, char> CharEncoder = new()
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

	internal class MessageData
	{
		public int ID { get; }
		public string Contents { get; private set; }
		public string ContentsParsed { get; private set; }
		public byte[] Data { get; private set; }
		public byte[] DataParsed { get; private set; }

		public MessageData(int i, string sraw, byte[] draw, string spar, byte[] dpar)
		{
			ID = i;
			Data = draw;
			DataParsed = dpar;
			Contents = sraw;
			ContentsParsed = spar;
		}

		public void SetMessage(string s)
		{
			ContentsParsed = s;
			Contents = OptimizeMessageForDictionary(s);
			RecalculateData();
		}

		private void RecalculateData()
		{
			Data = ParseMessageToData(Contents);
			DataParsed = ParseMessageToData(ContentsParsed);
		}

		public override string ToString()
		{
			return $"{ID:X3} - {ContentsParsed}";
		}

		public string GetReadableDumpedContents()
		{
			StringBuilder d = new (Data.Length * 2 + 1);
			foreach (byte b in Data)
			{
				d.Append(b.ToString("X2"));
				d.Append(' ');
			}

			return string.Format("[[[[\r\nMessage {0:X3}]]]]\r\n[Contents]\r\n{1}\r\n\r\n[Data]\r\n{2}\r\n\r\n\r\n\r\n",
				ID,
				AddNewLinesToCommands(ContentsParsed),
				d.ToString()
				);
		}

		public string GetDumpedContents()
		{
			return $"[{ID:X3}]{ContentsParsed}\r\n\r\n";
		}
	}

	private class TextElement
	{
		public string Token { get; }
		public string Pattern { get; }
		public string StrictPattern { get; }
		public string Description { get; }
		public bool HasArgument { get; }
		public byte ID { get; }
		public string GenericToken { get; }

		public TextElement(byte a, string t, bool arg, string d)
		{
			Token = t;
			HasArgument = arg;

			Pattern = string.Format(
				arg ? "\\[{0}:?([0-9A-F]{{1,2}})\\]" : "\\[{0}\\]",
				Regex.Escape(Token)); // need to escape to prevent bad with [...]

			StrictPattern = string.Format("^{0}$", Pattern);

			GenericToken = string.Format(
					 arg ? "[{0}:##]" : "[{0}]",
					 Token);

			Description = d;
			ID = a;
		}

		private const string TokenWithParam = "[{0}:{1:X2}]";
		private const string TokenWithoutParam = "[{0}]";

		public string GetParameterizedToken(byte b = 0) => HasArgument switch
		{
			true => string.Format(TokenWithParam, Token, b),
			false => string.Format(TokenWithoutParam, Token)
		};

		public override string ToString()
		{
			return $"{GenericToken} {Description}";
		}

		public Match MatchMe(string dfrag)
		{
			return Regex.Match(dfrag, StrictPattern);
		}
	}

	private record ParsedElement(TextElement Parent, byte Value);

	private static List<DictionaryEntry> AllDicts = new();

	public class DictionaryEntry
	{
		public byte ID { get; }
		public string Contents { get; }
		public byte[] Data { get; }
		public int Length { get; }

		public string Token { get; }

		public DictionaryEntry(byte i, string s)
		{
			Contents = s;
			ID = i;
			Length = s.Length;
			Token = $"[{DictionaryToken}:{ID:X2}]";
			Data = ParseMessageToData(Contents);
		}

		public bool ContainedInString(string s)
		{
			return s.Contains(Contents);
		}

		public string ReplaceInstancesOfIn(string s)
		{
			return s.Replace(Contents, Token);
		}
	}

	private static string OptimizeMessageForDictionary(string str)
	{
		const char CHEESE = '\uBEBE'; // inserted into commands to protect them from dictionary replacements

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
		return ReplaceAllDictionaryWords(protons.ToString()).Replace(CHEESE.ToString(), string.Empty);
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
				(byte) (DictionaryBaseValue + byte.Parse(g.Groups[1].Value, NumberStyles.HexNumber)
			));
		}

		return null;
	}
	private static TextElement FindMatchingCommand(byte b)
	{
		return TCommands.FirstOrDefault(t => t.ID == b);
	}

	private static TextElement FindMatchingSpecial(byte b)
	{
		return SpecialChars.FirstOrDefault(t => t.ID == b);
	}

	public static DictionaryEntry GetDictionaryFromID(byte b)
	{
		return AllDicts.FirstOrDefault(ddd => ddd.ID == b);
	}

	private static int FindDictionaryEntry(byte b) => b switch
	{
		< DictionaryBaseValue => -1,
		0xFF => -1,
		_ => b - DictionaryBaseValue
	};

	public static byte FindMatchingCharacter(char c)
	{
		return CharEncoder.FirstOrDefault(kt => kt.Value == c, new(0xFF, '?')).Key;
	}
}
