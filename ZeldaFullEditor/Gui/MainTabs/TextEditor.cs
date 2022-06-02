namespace ZeldaFullEditor
{
	// TODO make a text handler, separate from the UserControl
	public partial class TextEditor : UserControl
	{
		readonly byte[] widthArray = new byte[100];
		private const int DefaultTextColor = 6;
		readonly string romname = "";

		private readonly List<MessageData> listOfTexts = new();
		private readonly List<MessageData> DisplayedMessages = new();
		private MessageData CurrentMessage;

		private int textPos = 0;
		private bool skipNext = false;

		private int textLine = 0;
		private int shownLines = 0;

		private bool fromForm = false;

		private int selectedTile = 0;

		public const string DictionaryToken = "D";
		public const byte DictionaryBaseValue = 0x88;
		public const byte MessageTerminator = 0x7F;

		public TextEditor()
		{
			InitializeComponent();
			TextCommandList.Items.AddRange(TCommands);
			SpecialsList.Items.AddRange(SpecialChars);
			pictureBox1.MouseWheel += new MouseEventHandler(pictureBox1_MouseWheel);
		}

		

		public bool SelectMessageID(int i)
		{
			if (i < textListbox.Items.Count)
			{
				textListbox.SelectedIndex = i;
				return true;
			}
			return false;
		}

		public void ReadAllTextDataFromROM()
		{
			int tt = 0;
			int pos = ZScreamer.ActiveOffsets.text_data;
			List<byte> tempBytesRaw = new List<byte>();
			List<byte> tempBytesParsed = new List<byte>();

			StringBuilder currentMessageRaw = new StringBuilder();
			StringBuilder currentMessageParsed = new StringBuilder();

			while (true)
			{
				byte b = ZScreamer.ActiveROM[pos++];

				tempBytesRaw.Add(b);

				if (b == MessageTerminator)
				{
					tempBytesParsed.Add(b);
					listOfTexts.Add(new MessageData(tt++,
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

				TextElement t;

				// check for command
				if ((t = FindMatchingCommand(b)) != null)
				{
					tempBytesParsed.Add(b);
					if (t.HasArgument)
					{
						b = ZScreamer.ActiveROM[pos++];
						tempBytesRaw.Add(b);
						tempBytesParsed.Add(b);
					}

					currentMessageRaw.Append(t.GetParameterizedToken(b));
					currentMessageParsed.Append(t.GetParameterizedToken(b));

					if (t.Token == BANKToken)
					{
						pos = ZScreamer.ActiveOffsets.text_data2;
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
					currentMessageRaw.Append($"[{DictionaryToken}:{dict:X2}]");

					int addr = SNESFunctions.SNEStoPC(0x0E0000 | ZScreamer.ActiveROM.Read16(ZScreamer.ActiveOffsets.pointers_dictionaries + (dict * 2)));
					int addrend = SNESFunctions.SNEStoPC(0x0E0000 | ZScreamer.ActiveROM.Read16(ZScreamer.ActiveOffsets.pointers_dictionaries + ((dict + 1) * 2)));

					for (int i = addr; i < addrend; i++)
					{
						byte dadd = ZScreamer.ActiveROM[i];
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

		public static void BuildDictionaryEntriesFromROM()
		{
			for (int i = 0; i < 97; i++)
			{
				List<byte> bytes = new List<byte>();
				StringBuilder s = new StringBuilder();

				int addr = (0x0E0000 | ZScreamer.ActiveROM.Read16(ZScreamer.ActiveOffsets.pointers_dictionaries + (i * 2))).SNEStoPC();
				int tempaddr = (0x0E0000 | ZScreamer.ActiveROM.Read16(ZScreamer.ActiveOffsets.pointers_dictionaries + ((i + 1) * 2))).SNEStoPC();

				while (addr < tempaddr)
				{
					byte bdictionary = ZScreamer.ActiveROM[addr++];
					bytes.Add(bdictionary);
					s.Append(ParseTextDataByte(bdictionary));
				}

				AllDicts.Add(new DictionaryEntry((byte) i, s.ToString()));
			}

			AllDicts = AllDicts.OrderByDescending(dic => dic.Length).ToList();
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

		public static string ParseTextDataByte(byte b)
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
				return $"[{DictionaryToken}:{dict:X2}]";
			}

			return "[SOMETHINGBADHAPPENED]";
		}

		private static readonly Color[] previewColors = {
			Color.DimGray,
			Color.DarkBlue,
			Color.White,
			Color.DarkOrange
		};

		public void OnProjectLoad()
		{
			for (int i = 0; i < 100; i++)
			{
				widthArray[i] = ZScreamer.ActiveROM[ZScreamer.ActiveOffsets.characters_width + i];
			}

			ZScreamer.ActiveGraphicsManager.fontgfxBitmap = new Bitmap(128, 128, 64, PixelFormat.Format4bppIndexed, ZScreamer.ActiveGraphicsManager.fontgfx16Ptr);
			ZScreamer.ActiveGraphicsManager.currentfontgfx16Bitmap = new Bitmap(172, 4096, 172, PixelFormat.Format8bppIndexed, ZScreamer.ActiveGraphicsManager.currentfontgfx16Ptr);

			ColorPalette cp1 = ZScreamer.ActiveGraphicsManager.fontgfxBitmap.Palette;
			for (int i = 0; i < previewColors.Length; i++)
			{
				cp1.Entries[i] = previewColors[i];
			}
			ZScreamer.ActiveGraphicsManager.fontgfxBitmap.Palette = cp1;

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

			ZScreamer.ActiveGraphicsManager.CreateFontGfxData();
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

			// TODO need to adjust this because it keeps moving where the cursor is
			textBox1.Text = AddNewLinesToCommands(CurrentMessage.ContentsParsed);

			DrawMessagePreview();

			pictureBox1.Refresh();
		}

		private void DrawStringToPreview(string s)
		{
			foreach (char c in s)
			{
				DrawCharacterToPreview(c);
			}
		}

		private void DrawCharacterToPreview(char c)
		{
			DrawCharacterToPreview(FindMatchingCharacter(c));
		}

		/// <summary>
		/// Includes parentheses to be longer, since player names can be up to 6 characters.
		/// </summary>
		private const string NAMEPreview = "(NAME)";

		private void DrawCharacterToPreview(params byte[] text)
		{
			foreach (byte b in text)
			{
				if (skipNext)
				{
					skipNext = false;
					continue;
				}

				switch (b)
				{
					case < 100:
						if (textPos >= 170)
						{
							textPos = 0;
							textLine++;
						}

						DrawTileToPreview(textPos, textLine * 16, b & 0xF, b / 16);
						textPos += widthArray[b];
						break;

					case 0x74:
						textPos = 0;
						textLine = 0;
						break;

					case 0x73:
						textPos = 0;
						textLine++;
						break;

					case 0x75:
						textPos = 0;
						textLine = 1;
						break;

					case 0x76:
						textPos = 0;
						textLine = 2;
						break;

					case 0x6B:
					case 0x6D:
					case 0x6E:
					case 0x77:
					case 0x78:
					case 0x79:
					case 0x7A:
						skipNext = true;
						continue;

					case 0x6C:
						DrawCharacterToPreview('0');
						skipNext = true;
						continue;

					case 0x6A:
						DrawStringToPreview(NAMEPreview);
						break;

					case >= DictionaryBaseValue when b < (DictionaryBaseValue + 97):
						DictionaryEntry d = GetDictionaryFromID((byte) (b - DictionaryBaseValue));
						if (d != null)
						{
							DrawCharacterToPreview(d.Data);
						}
						break;

					case MessageTerminator:
						return;
				}
			}
		}

		private unsafe void DrawMessagePreview() //From Parsing
		{
			//defaultColor = 6;
			textLine = 0;
			byte* ptr = (byte*) ZScreamer.ActiveGraphicsManager.currentfontgfx16Ptr.ToPointer();

			for (int i = 0; i < (172 * 4096); i++)
			{
				ptr[i] = 0;
			}

			textPos = 0;
			DrawCharacterToPreview(CurrentMessage.Data);

			shownLines = 0;
		}

		private unsafe void DrawTileToPreview(int x, int y, int srcx, int srcy)
		{
			var alltilesData = (byte*) ZScreamer.ActiveGraphicsManager.fontgfx16Ptr.ToPointer();

			byte* ptr = (byte*) ZScreamer.ActiveGraphicsManager.currentfontgfx16Ptr.ToPointer();

			int drawid = srcx + (srcy * 32);
			int tx = ((drawid & ~0xF) * 32) + ((drawid & 0x0F) * 4);

			int ioff = x + y * 172;

			for (int yl = 0; yl < 16; yl++)
			{
				for (int xl = 0; xl < 4; xl++)
				{
					byte pixel = alltilesData[tx + (yl * 64) + xl];

					int index = ioff + (xl * 2) + (yl * 172);

					if (pixel.BitIsOn(0x0F))
					{
						ptr[index + 1] = (byte) (pixel & 0x0F);
					}

					if (pixel.BitIsOn(0xF0))
					{
						ptr[index] = (byte) (pixel >> 4);
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

		private static readonly Pen CharHilite = new(Brushes.HotPink, 2);
		private static readonly Pen GridHilite = new(Color.FromArgb(0x77CCCCCC), 2);
		private void pictureBox2_Paint(object sender, PaintEventArgs e)
		{
			if (!ZScreamer.Active) return;

			e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
			e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
			e.Graphics.DrawImage(ZScreamer.ActiveGraphicsManager.fontgfxBitmap, Constants.RoomSizedRectangle);

			if (fontGridBox.Checked)
			{
				for (int i = 0; i < 16; i++)
				{
					e.Graphics.DrawLine(GridHilite, 16 * i, 0, 16 * i, 128 * 4);
					e.Graphics.DrawLine(GridHilite, 0, 32 * i, 64 * 4, 32 * i);
				}
			}

			int srcY = selectedTile / 16;
			int srcX = selectedTile & 0xF;
			e.Graphics.DrawRectangle(CharHilite, new Rectangle(srcX * 16, srcY * 32, 16, 32));
		}

		private void pictureBox3_Paint(object sender, PaintEventArgs e)
		{
			if (!ZScreamer.Active) return;

			e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
			e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
			e.Graphics.DrawImage(ZScreamer.ActiveGraphicsManager.fontgfxBitmap,
				Constants.Rect_0_0_64_128,
				new Rectangle((selectedTile - (selectedTile & 0xF0)) * 8, selectedTile & 0xF0, 8, 16),
				GraphicsUnit.Pixel);

			if (fontGridBox.Checked)
			{
				for (int i = 0; i < 8 * 8; i += 8)
				{
					e.Graphics.DrawLine(GridHilite, i, 0, i, 128);
				}

				for (int j = 0; j < 16 * 8; j += 8)
				{
					e.Graphics.DrawLine(GridHilite, 0, j, 64, j);
				}
			}
		}

		private void pictureBox1_Paint(object sender, PaintEventArgs e)
		{
			if (!ZScreamer.Active) return;

			e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
			ColorPalette cp = ZScreamer.ActiveGraphicsManager.currentfontgfx16Bitmap.Palette;

			for (int i = 0; i < 4; i++)
			{
				if (i == 0)
				{
					cp.Entries[i] = Color.Transparent;
				}
				else
				{
					//cp.Entries[i] = RoomPreviewArtist.Layer1Canvas.Palette.Entries[(DefaultTextColor * 4) + i];
					cp.Entries[i] = previewColors[i];
				}
			}

			ZScreamer.ActiveGraphicsManager.currentfontgfx16Bitmap.Palette = cp;

			e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
			e.Graphics.DrawImage(
				ZScreamer.ActiveGraphicsManager.currentfontgfx16Bitmap,
				new Rectangle(0, 0, 340, pictureBox2.Height),
				new Rectangle(0, shownLines * 16, 170, pictureBox2.Height / 2),
				GraphicsUnit.Pixel);
			e.Graphics.FillRectangle(
				Constants.HalfRedBrush,
				new Rectangle(344 - 8, 0, 4, pictureBox2.Height));
		}

		private void button2_Click(object sender, EventArgs e)
		{
			using var sf = new SaveFileDialog();
			if (sf.ShowDialog() == DialogResult.OK)
			{
				byte[] data = new byte[0x1000];
				for (int i = 0; i < 0x1000; i++)
				{
					data[i] = ZScreamer.ActiveROM[ZScreamer.ActiveOffsets.gfx_font + i];
				}

				using var fs = new FileStream(sf.FileName, FileMode.OpenOrCreate, FileAccess.Write);
				fs.Write(data, 0, 0x1000);
				fs.Write(widthArray, 0, 100);
				fs.Close();
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			using var of = new OpenFileDialog();
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
					ZScreamer.ActiveROM[ZScreamer.ActiveOffsets.gfx_font + i] = data[i];
				}

				for (int i = 0; i < 100; i++)
				{
					ZScreamer.ActiveROM[ZScreamer.ActiveOffsets.characters_width + i] = data[i + 0x1000];
				}

				ZScreamer.ActiveGraphicsManager.CreateFontGfxData();
				pictureBox2.Refresh();
			}
		}

		private const int SpaceForBank1Text = 0x8000;
		private const int SpaceForBank2Text = 0x14BF;

		public void Save()
		{
			ZScreamer.ActiveROM.Write(ZScreamer.ActiveOffsets.characters_width, widthArray);

			int pos = ZScreamer.ActiveOffsets.text_data;
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
						if (!expandedRegion && pos >= (ZScreamer.ActiveOffsets.text_data + SpaceForBank1Text - 1))
						{
							ZScreamer.ActiveROM[pos] = BANKID;
							pos = ZScreamer.ActiveOffsets.text_data2;
							expandedRegion = true;
							continue;
						}
						// oh no! way too much space
						else if (expandedRegion && (pos >= (ZScreamer.ActiveOffsets.text_data2 + SpaceForBank2Text - 1)))
						{
							int spaceused = 0;

							foreach (MessageData m2 in listOfTexts)
							{
								spaceused += m2.Data.Length;
							}

							throw new ZeldaException(string.Format(
								"There is too much text data to save.\n" +
								"Available: {0:X4} | Used: {1:X4}",
								SpaceForBank1Text + SpaceForBank2Text, spaceused));
						}

						ZScreamer.ActiveROM[pos++] = m.Data[i++];
						ZScreamer.ActiveROM[pos++] = m.Data[i++];
						continue;
					}

					// add the bank byte when we hit this spot
					if (!expandedRegion && pos == ZScreamer.ActiveOffsets.text_data + SpaceForBank1Text)
					{
						if (b == BANKID) // catch user-inserted bank token
						{
							i++; // increment to skip it from being written in second text bank
						}

						ZScreamer.ActiveROM[pos] = BANKID;
						pos = ZScreamer.ActiveOffsets.text_data2;
						expandedRegion = true;
						continue;
					}

					// TODO warnings about bank markers when a lot of space remains
					if (b == BANKID)
					{
						if (expandedRegion)
						{
							throw new ZeldaException($"A second bank marker was found in Message {m.ID:X3}.\nThis is not a legal move.");
						}
					}

					ZScreamer.ActiveROM[pos++] = b;
					i++;

					// never get too close to the end
				}
			}
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
			if (!ZScreamer.Active) return;

			selectedTile = (e.X / 16) + (e.Y / 32 * 16);

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
		private void InsertCommandButton_Click_1(object sender, EventArgs e)
		{
			InsertSelectedText(TCommands[TextCommandList.SelectedIndex].GetParameterizedToken((byte) ParamsBox.HexValue));
		}

		/// <summary>
		/// Adds a special character to the text field when the Add command button is pressed or the character is double clicked in the list.
		/// </summary>
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

		private void UpdateTextBox()
		{
			if (textListbox.SelectedItem != null)
			{
				CurrentMessage.SetMessage(Regex.Replace(textBox1.Text, @"[\r\n]", ""));

				textListbox.BeginUpdate();
				textListbox.DataSource = null;
				textListbox.DataSource = DisplayedMessages;
				textListbox.EndUpdate();

				DrawMessagePreview();
				pictureBox1.Refresh();
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			DictionariesForm df = new DictionariesForm();
			df.listBox1.Items.Clear();

			foreach (DictionaryEntry d in AllDicts.OrderByDescending(d => d.Length))
			{
				df.listBox1.Items.Add(
					string.Format($"{d.ID:X2} [{d.ID + DictionaryBaseValue:X2}] - {d.Contents.Replace(" ", "_")}"));
			}

			df.ShowDialog();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			ZScreamer.ActiveROM.Write(ZScreamer.ActiveOffsets.characters_width, widthArray);

			using var fs = new FileStream(romname, FileMode.OpenOrCreate, FileAccess.Write);
			fs.Write(ZScreamer.ActiveROM.DataStream, 0, ZScreamer.ActiveROM.Length);
			fs.Close();
		}

		// TODO needs a rewrite
		private void toolStripButton2_Click(object sender, EventArgs e)
		{
			using OpenFileDialog of = new()
			{
				DefaultExt = ".txt"
			};

			if (of.ShowDialog() == DialogResult.OK)
			{
				textListbox.SelectedIndex = -1;
				textListbox.BeginUpdate();
				textListbox.DataSource = null;

				string[] alltexts = File.ReadAllLines(of.FileName);
				for (int i = 0; i < alltexts.Length; i++)
				{
					if (alltexts[i].Length > 3)
					{
						int id = int.Parse(alltexts[i][..3]);
						listOfTexts[id].SetMessage(alltexts[i][5..]);
					}
				}

				textListbox.DataSource = listOfTexts;
				textListbox.EndUpdate();
			}
		}

		private void dumpTextsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using SaveFileDialog sf = new SaveFileDialog()
			{
				DefaultExt = ".txt"
			};
			if (sf.ShowDialog() == DialogResult.OK)
			{
				List<string> alltexts = new(listOfTexts.Count);
				foreach (MessageData m in listOfTexts)
				{
					alltexts.Add(m.GetDumpedContents());
				}
				File.WriteAllLines("dump.txt", alltexts);
			}
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

		readonly MessageAsBytes byter = new();
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

		private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
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
