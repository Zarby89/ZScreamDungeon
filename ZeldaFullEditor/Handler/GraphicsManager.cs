// TODO clean up all the magic numbers

namespace ZeldaFullEditor.Handler
{
	public class GraphicsManager
	{
		private const int SpriteSheetOffset = 0x73;


		// TODO move to cosntants or something
		public static Bitmap moveableBlock { get; } = new Bitmap(Resources.Mblock);
		public static Bitmap spriteFont { get; } = new Bitmap(Resources.spriteFont);
		public static Bitmap favStar1 { get; } = new Bitmap(Resources.starn);
		public static Bitmap favStar2 { get; } = new Bitmap(Resources.starl);




		static GraphicsManager()
		{
			favStar1.MakeTransparent(Color.Fuchsia);
			favStar2.MakeTransparent(Color.Fuchsia);
		}



		public BackgroundSet[] EntranceGraphicsSets { get; } = new BackgroundSet[37];
		public SheetSet[] LocalGraphicsSets { get; } = new SheetSet[82];
		public SheetSet[] SpriteGraphicsBlocks { get; } = new SheetSet[144];

		public GraphicsSheet[] EnvironmentSpriteSheets { get; } = new GraphicsSheet[10];

		public GraphicsSheet[] AnimatedGraphicsSheetsUW { get; } = new GraphicsSheet[24];


		public IntPtr allgfx16Ptr = Marshal.AllocHGlobal(128 * 7136 / 2);
		public Bitmap allgfxBitmap;

		public IntPtr currentgfx16Ptr = Marshal.AllocHGlobal(128 * 512 / 2);
		public Bitmap currentgfx16Bitmap;

		public IntPtr currentEditinggfx16Ptr = Marshal.AllocHGlobal(128 * 512 / 2);
		public Bitmap currentEditingfx16Bitmap;

		public IntPtr currentTileScreengfx16Ptr = Marshal.AllocHGlobal(128 * 512 / 2);
		public Bitmap currentTileScreengfx16Bitmap;

		public IntPtr currentOWgfx16Ptr = Marshal.AllocHGlobal(128 * 512 / 2);
		public Bitmap currentOWgfx16Bitmap;

		public IntPtr previewgfx16Ptr = Marshal.AllocHGlobal(128 * 512 / 2);
		public Bitmap previewgfx16Bitmap;

		public IntPtr editort16Ptr = Marshal.AllocHGlobal(128 * 512);
		public Bitmap editort16Bitmap;

		public IntPtr mapgfx16Ptr = Marshal.AllocHGlobal(1048576);
		public Bitmap mapgfx16Bitmap;

		public IntPtr fontgfx16Ptr; // = Marshal.AllocHGlobal((256 * 256));
		public Bitmap fontgfxBitmap;

		public IntPtr currentfontgfx16Ptr; // = Marshal.AllocHGlobal(172 * 20000);
		public Bitmap currentfontgfx16Bitmap;

		public PointeredImage OverworldScratchPadder { get; init; } = new PointeredImage(256, 4096);

		public IntPtr overworldMapPointer; // = Marshal.AllocHGlobal(0x4000);
		public Bitmap overworldMapBitmap;

		public IntPtr owactualMapPointer; // = Marshal.AllocHGlobal(0x40000);
		public Bitmap owactualMapBitmap;

		public IntPtr[] previewObjectsPtr;
		public Bitmap[] previewObjectsBitmap;

		public IntPtr[] previewSpritesPtr;
		public Bitmap[] previewSpritesBitmap;

		public IntPtr[] previewChestsPtr;
		public Bitmap[] previewChestsBitmap;

		public IntPtr roomObjectsPtr = Marshal.AllocHGlobal(512 * 512);
		public Bitmap roomObjectsBitmap;

		public IntPtr editingtile16 = Marshal.AllocHGlobal(16 * 16);
		public Bitmap editingtile16Bitmap;

		public Color[,] loadedPalettes = new Color[1, 1];

		public Color[,] loadedSprPalettes = new Color[1, 1];

		private readonly ZScreamer ZS;

		public GraphicsManager(ZScreamer zs)
		{
			ZS = zs;
		}

		internal void OnROMLoad()
		{
			CreateAllGfxData();
			LoadGfxGroups();
		}

		public void initGfx()
		{
			allgfxBitmap = new Bitmap(128, 7104, 64, PixelFormat.Format4bppIndexed, allgfx16Ptr);
			currentgfx16Bitmap = new Bitmap(128, 512, 64, PixelFormat.Format4bppIndexed, currentgfx16Ptr);
			currentEditingfx16Bitmap = new Bitmap(128, 512, 64, PixelFormat.Format4bppIndexed, currentEditinggfx16Ptr);
			currentTileScreengfx16Bitmap = new Bitmap(128, 512, 64, PixelFormat.Format4bppIndexed, currentEditinggfx16Ptr);
			roomObjectsBitmap = new Bitmap(512, 512, 512, PixelFormat.Format8bppIndexed, roomObjectsPtr);
			editingtile16Bitmap = new Bitmap(16, 16, 16, PixelFormat.Format8bppIndexed, roomObjectsPtr);
			currentOWgfx16Bitmap = new Bitmap(128, 512, 64, PixelFormat.Format4bppIndexed, currentOWgfx16Ptr);
			previewgfx16Bitmap = new Bitmap(128, 512, 64, PixelFormat.Format4bppIndexed, previewgfx16Ptr);
			mapgfx16Bitmap = new Bitmap(128, 7520, 128, PixelFormat.Format8bppIndexed, mapgfx16Ptr);
			editort16Bitmap = new Bitmap(128, 512, 128, PixelFormat.Format8bppIndexed, editort16Ptr);


			previewObjectsPtr = new IntPtr[0x300];
			previewObjectsBitmap = new Bitmap[0x300];
			previewSpritesPtr = new IntPtr[256];
			previewSpritesBitmap = new Bitmap[256];
			previewChestsPtr = new IntPtr[76];
			previewChestsBitmap = new Bitmap[76];

			for (var i = 0; i < 0x300; i++)
			{
				previewObjectsPtr[i] = Marshal.AllocHGlobal(64 * 64);
				previewObjectsBitmap[i] = new Bitmap(64, 64, 64, PixelFormat.Format8bppIndexed, previewObjectsPtr[i]);
			}
			for (var i = 0; i < 256; i++)
			{
				previewSpritesPtr[i] = Marshal.AllocHGlobal(64 * 64);
				previewSpritesBitmap[i] = new Bitmap(64, 64, 64, PixelFormat.Format8bppIndexed, previewSpritesPtr[i]);
			}
			for (var i = 0; i < 76; i++)
			{
				previewChestsPtr[i] = Marshal.AllocHGlobal(64 * 64);
				previewChestsBitmap[i] = new Bitmap(64, 64, 64, PixelFormat.Format8bppIndexed, previewChestsPtr[i]);
			}
		}

		public void CreateFontGfxData()
		{
			var data = new byte[0x2000];
			for (var i = 0; i < 0x2000; i++)
			{
				data[i] = ZS.ROM[ZS.Offsets.gfx_font + i];
			}

			var newData = new byte[0x4000]; // NEED TO GET THE APPROPRIATE SIZE FOR THAT
			var mask = new byte[] { 0x80, 0x40, 0x20, 0x10, 0x08, 0x04, 0x02, 0x01 };
			var sheetPosition = 0;

			// 8x8 tile
			for (var s = 0; s < 4; s++) // Per Sheet
			{
				for (var j = 0; j < 4; j++) // Per Tile Line Y
				{
					for (var i = 0; i < 16; i++) // Per Tile Line X
					{
						for (var y = 0; y < 8; y++) // Per Pixel Line
						{
							var lineBits0 = data[y * 2 + i * 16 + j * 256 + sheetPosition];
							var lineBits1 = data[y * 2 + i * 16 + j * 256 + 1 + sheetPosition];

							for (var x = 0; x < 4; x++) // Per Pixel X
							{
								byte pixdata = 0;
								byte pixdata2 = 0;

								if ((lineBits0 & mask[x * 2]) == mask[x * 2]) { pixdata += 1; }
								if ((lineBits1 & mask[x * 2]) == mask[x * 2]) { pixdata += 2; }

								if ((lineBits0 & mask[x * 2 + 1]) == mask[x * 2 + 1]) { pixdata2 += 1; }
								if ((lineBits1 & mask[x * 2 + 1]) == mask[x * 2 + 1]) { pixdata2 += 2; }

								newData[y * 64 + x + i * 4 + j * 512 + s * 2048] = (byte) (pixdata << 4 | pixdata2);
							}
						}
					}
				}

				sheetPosition += 0x400;
			}

			unsafe
			{
				var fontgfx16Data = (byte*) fontgfx16Ptr.ToPointer();
				for (var i = 0; i < 0x4000; i++)
				{
					fontgfx16Data[i] = newData[i];
				}
			}
		}

		// TODO magic numbers

		public GraphicsSheet[] AllSheets { get; } = new GraphicsSheet[Constants.NumberOfSheets];

		/// <summary>
		/// Creates every <see cref="GraphicsSheet"/> based on ROM data
		/// </summary>
		private void CreateAllGfxData()
		{
			//var mask = new byte[] { 0x80, 0x40, 0x20, 0x10, 0x08, 0x04, 0x02, 0x01 };

			var _ = 0;
			// 8x8 tile
			for (var s = 0; s < Constants.NumberOfSheets; s++) // Per Sheet
			{
				var sheetinfo = GFXSheetMeta.ListOf[s];

				byte[] data;

				var start = GetPCGfxAddress((byte) s);

				if (sheetinfo.IsCompressed)
				{
					data = Decompress.ALTTPDecompressGraphics(ZS.ROM.DataStream,
						start, Constants.UncompressedSheetSize, ref _);
				}
				else
				{
					data = ZS.ROM.Read8Many(start, Constants.Uncompressed3BPPSize);
				}

				var sheetdata = sheetinfo.BitDepth switch
				{
					SNESPixelFormat.SNES3BPP => new byte[4 * 16 * 8 * 8],
					_ => new byte[8 * 16 * 8 * 8],
				};

				int index = 0;
				for (int j = 0; j < 4; j++) // Per Tile Line Y
				{
					for (int i = 0; i < 16; i++) // Per Tile Line X
					{
						for (int y = 0; y < 8; y++) // Per Pixel Line
						{
							if (sheetinfo.BitDepth == SNESPixelFormat.SNES3BPP)
							{
								var lineBits0 = data[y * 2 + i * 24 + j * 384];
								var lineBits1 = data[y * 2 + i * 24 + j * 384 + 1];
								var lineBits2 = data[y + i * 24 + j * 384 + 16];

								for (byte mask = 0x80; mask > 0; mask >>= 1) // Per Pixel X
								{
									byte pixdata = 0;

									if (lineBits0.BitsAllSet(mask)) { pixdata |= 1; }
									if (lineBits1.BitsAllSet(mask)) { pixdata |= 2; }
									if (lineBits2.BitsAllSet(mask)) { pixdata |= 4; }

									sheetdata[index++] = pixdata;
								}
							}
							else
							{
								var lineBits0 = data[y * 2 + i * 16 + j * 256];
								var lineBits1 = data[y * 2 + i * 16 + j * 256 + 1];

								for (byte mask = 0x80; mask > 0; mask >>= 1) // Per Pixel X
								{
									byte pixdata = 0;

									if (lineBits0.BitsAllSet(mask)) { pixdata |= 1; }
									if (lineBits1.BitsAllSet(mask)) { pixdata |= 2; }

									sheetdata[index++] = pixdata;
								}
							}


						}
					}
				}
				AllSheets[s] = new GraphicsSheet(sheetdata, sheetinfo.BitDepth)
				{
					Info = sheetinfo
				};
			}
		}

		/// <summary>
		/// Loads up the graphics groups from ROM
		/// </summary>
		private void LoadGfxGroups()
		{
			int gfxPointer = ZS.ROM.Read16(ZS.Offsets.gfx_groups_pointer);
			gfxPointer = (0x00_0000 | gfxPointer).SNEStoPC(); // explicitly declare bank 00

			for (var i = 0; i < 37; i++)
			{
				EntranceGraphicsSets[i] = new()
				{
					Sheet0 = AllSheets[ZS.ROM[gfxPointer++]],
					Sheet1 = AllSheets[ZS.ROM[gfxPointer++]],
					Sheet2 = AllSheets[ZS.ROM[gfxPointer++]],
					Sheet3 = AllSheets[ZS.ROM[gfxPointer++]],

					Sheet4 = AllSheets[ZS.ROM[gfxPointer++]],
					Sheet5 = AllSheets[ZS.ROM[gfxPointer++]],
					Sheet6 = AllSheets[ZS.ROM[gfxPointer++]],
					Sheet7 = AllSheets[ZS.ROM[gfxPointer++]]
				};
			}

			gfxPointer = ZS.Offsets.GraphicsAA2Tables;
			for (var i = 0; i < 82; i++)
			{
				LocalGraphicsSets[i] = new()
				{
					Sheet0 = AllSheets[ZS.ROM[gfxPointer++]],
					Sheet1 = AllSheets[ZS.ROM[gfxPointer++]],
					Sheet2 = AllSheets[ZS.ROM[gfxPointer++]],
					Sheet3 = AllSheets[ZS.ROM[gfxPointer++]],
				};
			}

			gfxPointer = ZS.Offsets.sprite_blockset_pointer;
			for (var i = 0; i < 144; i++)
			{
				SpriteGraphicsBlocks[i] = new()
				{
					Sheet0 = AllSheets[ZS.ROM[gfxPointer++] + SpriteSheetOffset],
					Sheet1 = AllSheets[ZS.ROM[gfxPointer++] + SpriteSheetOffset],
					Sheet2 = AllSheets[ZS.ROM[gfxPointer++] + SpriteSheetOffset],
					Sheet3 = AllSheets[ZS.ROM[gfxPointer++] + SpriteSheetOffset],
				};
			}

			gfxPointer = ZS.Offsets.gfx_groups_environment;
			for (var i = 0; i < 10; i++)
			{
				EnvironmentSpriteSheets[i] = AllSheets[ZS.ROM[gfxPointer++] + SpriteSheetOffset];
			}

			gfxPointer = ZS.Offsets.gfx_anim_sheets;
			for (var i = 0; i < 24; i++)
			{
				AnimatedGraphicsSheetsUW[i] = AllSheets[ZS.ROM[gfxPointer++]];
			}
		}

		public void SaveGroupsToROM()
		{
			var gfxPointer = SNESFunctions.SNEStoPC(ZS.ROM.Read16(ZS.Offsets.gfx_groups_pointer));

			for (var i = 0; i < 37; i++)
			{
				ZS.ROM.WriteContinuous(ref gfxPointer, EntranceGraphicsSets[i].GetByteData());
			}

			gfxPointer = ZS.Offsets.GraphicsAA2Tables;
			for (var i = 0; i < 82; i++)
			{
				ZS.ROM.WriteContinuous(ref gfxPointer, LocalGraphicsSets[i].GetByteData());
			}

			gfxPointer = ZS.Offsets.sprite_blockset_pointer;
			for (var i = 0; i < 144; i++)
			{
				var set = SpriteGraphicsBlocks[i];
				ZS.ROM[gfxPointer++] = (byte) ((set.Sheet0.ID ?? 0x00) - SpriteSheetOffset);
				ZS.ROM[gfxPointer++] = (byte) ((set.Sheet1.ID ?? 0x00) - SpriteSheetOffset);
				ZS.ROM[gfxPointer++] = (byte) ((set.Sheet2.ID ?? 0x00) - SpriteSheetOffset);
				ZS.ROM[gfxPointer++] = (byte) ((set.Sheet3.ID ?? 0x00) - SpriteSheetOffset);
			}

			gfxPointer = ZS.Offsets.gfx_groups_environment;
			for (var i = 0; i < 10; i++)
			{
				ZS.ROM[gfxPointer++] = (byte) ((EnvironmentSpriteSheets[i].ID ?? 0x00) - SpriteSheetOffset);
		}
		}


		public GraphicsSet CreateUnderworldGraphicsSet(byte tileset, byte spriteset, byte entranceset)
		{
			var entset = EntranceGraphicsSets[entranceset];
			var bgset = LocalGraphicsSets[tileset];
			var sprset = SpriteGraphicsBlocks[spriteset];

			return new()
			{
				BGSheet0 = new(entset.Sheet0, true),
				BGSheet1 = new(entset.Sheet1, true),
				BGSheet2 = new(entset.Sheet2, true),
				BGSheet3 = new(GetLocalSheetIfNonzero(entset.Sheet3, bgset.Sheet0), true),
				BGSheet4 = new(GetLocalSheetIfNonzero(entset.Sheet4, bgset.Sheet1), false),
				BGSheet5 = new(GetLocalSheetIfNonzero(entset.Sheet5, bgset.Sheet2), false),
				BGSheet6 = new(GetLocalSheetIfNonzero(entset.Sheet6, bgset.Sheet3), false),
				BGSheet7 = new(entset.Sheet7, false),

				BGSheetA = new(AnimatedGraphicsSheetsUW[entranceset], false),

				SPRSheet0 = CreateRecordForSpriteSheet(AllSheets[0x73]),
				SPRSheet1 = CreateRecordForSpriteSheet(AllSheets[0x7D]),
				SPRSheet2 = CreateRecordForSpriteSheet(AllSheets[0x79]),
				SPRSheet3 = CreateRecordForSpriteSheet(AllSheets[0x7A]),

				SPRSheet4 = CreateRecordForSpriteSheet(sprset.Sheet0),
				SPRSheet5 = CreateRecordForSpriteSheet(sprset.Sheet1),
				SPRSheet6 = CreateRecordForSpriteSheet(sprset.Sheet2),
				SPRSheet7 = CreateRecordForSpriteSheet(sprset.Sheet3),
			};
		}

		public GraphicsSet CreateOverworldGraphicsSet(byte tileset, byte spriteset, bool darkworld)
		{
			var worldset = EntranceGraphicsSets[darkworld ? 0x21 : 0x20];
			var bgset = LocalGraphicsSets[tileset];
			var sprset = SpriteGraphicsBlocks[spriteset];

			return new()
			{
				BGSheet0 = new(worldset.Sheet0, true),
				BGSheet1 = new(worldset.Sheet1, false),
				BGSheet2 = new(worldset.Sheet2, false),
				BGSheet3 = new(GetLocalSheetIfNonzero(worldset.Sheet3, bgset.Sheet0), true),

				BGSheet4 = new(GetLocalSheetIfNonzero(worldset.Sheet4, bgset.Sheet1), true),
				BGSheet5 = new(GetLocalSheetIfNonzero(worldset.Sheet5, bgset.Sheet2), true),
				BGSheet6 = new(GetLocalSheetIfNonzero(worldset.Sheet6, bgset.Sheet3), false),
				BGSheet7 = new(worldset.Sheet7, false),

				SPRSheet0 = CreateRecordForSpriteSheet(AllSheets[0x73]),
				SPRSheet1 = CreateRecordForSpriteSheet(EnvironmentSpriteSheets[darkworld ? 0x08 : 0x00]),
				SPRSheet2 = CreateRecordForSpriteSheet(AllSheets[0x79]),
				SPRSheet3 = CreateRecordForSpriteSheet(AllSheets[0x7A]),

				SPRSheet4 = CreateRecordForSpriteSheet(sprset.Sheet0),
				SPRSheet5 = CreateRecordForSpriteSheet(sprset.Sheet1),
				SPRSheet6 = CreateRecordForSpriteSheet(sprset.Sheet2),
				SPRSheet7 = CreateRecordForSpriteSheet(sprset.Sheet3),
			};
		}

		private static SlottedSheet CreateRecordForSpriteSheet(GraphicsSheet sheet)
		{
			return new(sheet, sheet.Info.UsesBackPalette ?? false);
		}

		private static GraphicsSheet GetLocalSheetIfNonzero(GraphicsSheet globalSheet, GraphicsSheet localSheet)
		{
			return localSheet.ID == 0x00 ? globalSheet : localSheet;
		}


		public int GetPCGfxAddress(byte id)
		{
			var gfxGamePointer1 = ZS.ROM[SNESFunctions.SNEStoPC(ZS.ROM.Read16(ZS.Offsets.gfx_1_pointer)) + id];
			var gfxGamePointer2 = ZS.ROM[SNESFunctions.SNEStoPC(ZS.ROM.Read16(ZS.Offsets.gfx_2_pointer)) + id];
			var gfxGamePointer3 = ZS.ROM[SNESFunctions.SNEStoPC(ZS.ROM.Read16(ZS.Offsets.gfx_3_pointer)) + id];

			return Utils.AddressFromBytes(gfxGamePointer1, gfxGamePointer2, gfxGamePointer3).SNEStoPC();
		}

		// TODO fix these to do 8bpp (since that's what we're doing)
		public byte[] pc4bppto3bppsnes(byte[] sheetData)
		{
			// [r0, bp1], [r0, bp2], [r1, bp1], [r1, bp2], [r2, bp1], [r2, bp2], [r3, bp1], [r3, bp2]
			// [r4, bp1], [r4, bp2], [r5, bp1], [r5, bp2], [r6, bp1], [r6, bp2], [r7, bp1], [r7, bp2]
			// [r0, bp3], [r1, bp3], [r2, bp3], [r3, bp3], [r4, bp3], [r5, bp3], [r6, bp3], [r7, bp3]

			// 4 bytes = 1 line of a 8x8 tile
			int dpos;

			var blockdata = new byte[24 * 64];
			byte l1d, l2d, l3d;
			var bpos = 0;

			for (var b = 0; b < 64; b++)
			{
				var y = b / 16 * 512;
				var x = b % 16 * 4;
				// Do that x8 for each blocks

				dpos = 0;
				for (var l = 0; l < 8 * 64; l += 64)
				{
					l1d = 0;
					l2d = 0;
					l3d = 0;

					var lll = l + y + x;

					for (var i = 0; i < 4; i++) // 1 line
					{
						var d = sheetData[i + lll];
						// 1111 0000 | 3333 2222 | 5555 4444 | 7777 6666  (4 bytes (i))
						l1d += (byte) (d >> 4 & 0x01); // Load bpp1 of line1 pixel2 + i (pixel 4, 6, 7)
						l1d = (byte) (l1d << 1); // Put it in linebpp1data and shift it by 1
						l1d += (byte) (d & 0x01); // Load bpp1 of line1 pixel1 + i (pixel 3, 5, 7)

						l2d += (byte) (d >> 5 & 0x01); // Load bpp2 of line1 pixel2 + i (pixel 4, 6, 7)
						l2d = (byte) (l2d << 1); // Put it in linebpp2data and shift it by 1
						l2d += (byte) (d >> 1 & 0x01); // Load bpp2 of line1 pixel1 + i (pixel 3, 5, 7)

						l3d += (byte) (d >> 6 & 0x01); // Load bpp3 of line1 pixel2 + i (pixel 4, 6, 7)
						l3d = (byte) (l3d << 1); // Put it in linebpp3data and shift it by 1
						l3d += (byte) (d >> 2 & 0x01); // Load bpp3 of line1 pixel1 + i (pixel 3, 5, 7)


						if (i != 3) // Shift all the linebpp data for the next bit except for the last one
						{
							l1d = (byte) (l1d << 1);
							l2d = (byte) (l2d << 1);
							l3d = (byte) (l3d << 1);
						}
					}

					blockdata[bpos + dpos * 2] = l1d;
					blockdata[bpos + 1 + dpos * 2] = l2d;
					blockdata[bpos + 16 + dpos] = l3d;
					dpos++;
				}

				bpos += 24;
			}

			// l1d = byte0
			// l2d = byte1
			// l3d = byte16

			return blockdata;
		}

		public byte[] pc4bppto2bppsnes(byte[] sheetData)
		{
			// [r0, bp1], [r0, bp2], [r1, bp1], [r1, bp2], [r2, bp1], [r2, bp2], [r3, bp1], [r3, bp2]
			// [r4, bp1], [r4, bp2], [r5, bp1], [r5, bp2], [r6, bp1], [r6, bp2], [r7, bp1], [r7, bp2]

			// 4 bytes = 1 line of a 8x8 tile
			int dpos; // Destination pos

			var blockdata = new byte[16 * 128];
			byte l1d, l2d;
			var bpos = 0;

			for (var b = 0; b < 128; b++)
			{
				var y = b / 16 * 512;
				var x = b % 16 * 4;
				// Do that x8 for each blocks

				dpos = 0;
				for (var l = 0; l < 8 * 64; l += 64)
				{
					l1d = 0;
					l2d = 0;

					var lll = l + y + x;

					for (var i = 0; i < 4; i++) // 1 line
					{
						var d = sheetData[i + lll];
						// 1111 0000 | 3333 2222 | 5555 4444 | 7777 6666  (4 bytes (i))
						l1d += (byte) (d >> 4 & 0x01); // Load bpp1 of line1 pixel2 + i (pixel 4, 6, 7)
						l1d = (byte) (l1d << 1); // Put it in linebpp1data and shift it by 1
						l1d += (byte) (d & 0x01); // Load bpp1 of line1 pixel1 + i (pixel 3, 5, 7)

						l2d += (byte) (d >> 5 & 0x01);// Load bpp2 of line1 pixel2 + i (pixel 4, 6, 7)
						l2d = (byte) (l2d << 1); // Put it in linebpp2data and shift it by 1
						l2d += (byte) (d >> 1 & 0x01);// Load bpp2 of line1 pixel1 + i (pixel 3, 5, 7)

						if (i != 3) // Shift all the linebpp data for the next bit except for the last one
						{
							l1d = (byte) (l1d << 1);
							l2d = (byte) (l2d << 1);
						}
					}

					blockdata[bpos + dpos] = l1d;
					blockdata[bpos + dpos + 1] = l2d;
					dpos += 2;
				}

				bpos += 16;
			}

			return blockdata;
		}

		// TODO magic numbers
		public unsafe void loadOverworldMap()
		{
			return;

			throw new NotImplementedException();
			overworldMapBitmap = new Bitmap(128, 128, 128, PixelFormat.Format8bppIndexed, overworldMapPointer);
			owactualMapBitmap = new Bitmap(512, 512, 512, PixelFormat.Format8bppIndexed, owactualMapPointer);

			// Mode 7
			var ptr = (byte*) overworldMapPointer.ToPointer();

			var pos = 0;
			for (var sy = 0; sy < 16 * 1024; sy += 1024)
			{
				for (var sx = 0; sx < 16 * 8; sx += 8)
				{
					for (var y = 0; y < 8 * 128; y += 128)
					{
						for (var x = 0; x < 8; x++)
						{
							ptr[x + sx + y + sy] = ZS.ROM[0x0C4000 + pos];
							pos++;
						}
					}
				}
			}

			var cp = overworldMapBitmap.Palette;
			for (var i = 0; i < 256; i += 2)
			{
				// 55B27 = US LW
				// 55C27 = US DW
				cp.Entries[i / 2] = ZS.ROM.Read16(0x55B27 + i).ToColor();

				var k = 0;
				var j = 0;
				for (var y = 10; y < 14; y++)
				{
					for (var x = 0; x < 15; x++)
					{
						cp.Entries[145 + k] = ZS.PaletteManager.SpriteGlobal[0][j++];
						k++;
					}
					k++;
				}
			}

			overworldMapBitmap.Palette = cp;
			owactualMapBitmap.Palette = cp;
		}
	}
}
