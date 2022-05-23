using static ZeldaFullEditor.View.Drawing.SNESGraphics.SNESPixelFormat;
using static ZeldaFullEditor.Modeling.GameData.Defaults.SheetType;

namespace ZeldaFullEditor.Modeling.GameData.Defaults
{
	/// <summary>
	/// Encapsulates information related to the usage and interpretation of a <see cref="GraphicsSheet"/>.
	/// </summary>
	public class GFXSheetMeta
	{
		/// <summary>
		/// Gets the ID of the graphics sheet.
		/// </summary>
		public byte? ID { get; init; } = 0xFF;

		/// <summary>
		/// Gets which of the standard SNES graphical formats this sheet should be interpreted as.
		/// </summary>
		public SNESPixelFormat BitDepth { get; init; }

		/// <summary>
		/// Gets the intended or expected usage of the graphics within this sheet.
		/// </summary>
		public SheetType GFXType { get; init; }

		/// <summary>
		/// Gets whether or not this sheet's data is expected to be compressed when read or written to ROM.
		/// </summary>
		public bool IsCompressed { get; init; }

		/// <summary>
		/// Gets the most preferred index this sheet should occupy in VRAM given its expected usage.
		/// </summary>
		public byte? PreferredIndex { get; init; }

		/// <summary>
		/// Whether this sheet should be forced to use the latter 7 colors when converted from 3BPP to 4BPP.
		/// Only applies to 3BPP sheets.
		/// </summary>
		public bool? UsesBackPalette { get; init; }

		/// <summary>
		/// <para>
		/// Creates a new <see cref="GFXSheetMeta"/> with the given properties.
		/// </para>
		/// <para>
		/// The <paramref name="depth"/> parameter should include both
		/// the sheet's expeted bit depth and its expected compression (<see cref="SNESPixelFormat.Compressed"/>),
		/// from which the <see cref="BitDepth">BitDepth</see> and <see cref="IsCompressed">IsCompressed</see> properties
		/// will be derived.
		/// </para>
		/// </summary>
		public GFXSheetMeta(byte? id, SheetType type, SNESPixelFormat depth, byte? index = null, bool backpal = false)
		{
			ID = id;
			BitDepth = depth & ~Compressed;
			IsCompressed = (depth & Compressed) == Compressed;
			PreferredIndex = index;
			UsesBackPalette = backpal & depth == SNES3BPP;
			GFXType = type;
		}

		/// <summary>
		/// Represents a nonspecial, placeholder sheet.
		/// </summary>
		public static readonly GFXSheetMeta MiscSheet = new(null, None, SNES3BPP);


		public static readonly GFXSheetMeta GFXSheet00 = new(0x00, UnderworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet01 = new(0x01, UnderworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet02 = new(0x02, UnderworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet03 = new(0x03, UnderworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet04 = new(0x04, UnderworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet05 = new(0x05, UnderworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet06 = new(0x06, UnderworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet07 = new(0x07, UnderworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet08 = new(0x08, UnderworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet09 = new(0x09, UnderworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet0A = new(0x0A, UnderworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet0B = new(0x0B, UnderworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet0C = new(0x0C, UnderworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet0D = new(0x0D, UnderworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet0E = new(0x0E, UnderworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet0F = new(0x0F, UnderworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet10 = new(0x10, UnderworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet11 = new(0x11, UnderworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet12 = new(0x12, UnderworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet13 = new(0x13, UnderworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet14 = new(0x14, UnderworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet15 = new(0x15, UnderworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet16 = new(0x16, UnderworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet17 = new(0x17, UnderworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet18 = new(0x18, UnderworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet19 = new(0x19, UnderworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet1A = new(0x1A, UnderworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet1B = new(0x1B, UnderworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet1C = new(0x1C, UnderworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet1D = new(0x1D, UnderworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet1E = new(0x1E, UnderworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet1F = new(0x1F, UnderworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet20 = new(0x20, UnderworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet21 = new(0x21, UnderworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet22 = new(0x22, UnderworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet23 = new(0x23, UnderworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet24 = new(0x24, UnderworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet25 = new(0x25, UnderworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet26 = new(0x26, UnderworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet27 = new(0x27, UnderworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet28 = new(0x28, UnderworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet29 = new(0x29, UnderworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet2A = new(0x2A, UnderworldTile, SNES3BPPCompressed);

		public static readonly GFXSheetMeta GFXSheet2B = new(0x2B, OverworldTile, SNES3BPPCompressed); // TODO verify
		public static readonly GFXSheetMeta GFXSheet2C = new(0x2C, OverworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet2D = new(0x2D, OverworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet2E = new(0x2E, OverworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet2F = new(0x2F, OverworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet30 = new(0x30, OverworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet31 = new(0x31, OverworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet32 = new(0x32, OverworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet33 = new(0x33, OverworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet34 = new(0x34, OverworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet35 = new(0x35, OverworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet36 = new(0x36, OverworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet37 = new(0x37, OverworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet38 = new(0x38, OverworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet39 = new(0x39, OverworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet3A = new(0x3A, OverworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet3B = new(0x3B, OverworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet3C = new(0x3C, OverworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet3D = new(0x3D, OverworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet3E = new(0x3E, OverworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet3F = new(0x3F, OverworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet40 = new(0x40, OverworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet41 = new(0x41, OverworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet42 = new(0x42, OverworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet43 = new(0x43, OverworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet44 = new(0x44, OverworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet45 = new(0x45, OverworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet46 = new(0x46, OverworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet47 = new(0x47, OverworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet48 = new(0x48, OverworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet49 = new(0x49, OverworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet4A = new(0x4A, OverworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet4B = new(0x4B, OverworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet4C = new(0x4C, OverworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet4D = new(0x4D, OverworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet4E = new(0x4E, OverworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet4F = new(0x4F, OverworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet50 = new(0x50, OverworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet51 = new(0x51, OverworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet52 = new(0x52, OverworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet53 = new(0x53, OverworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet54 = new(0x54, OverworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet55 = new(0x55, OverworldTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet56 = new(0x56, OverworldTile, SNES3BPPCompressed);

		public static readonly GFXSheetMeta GFXSheet57 = new(0x57, DynamicBackground, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet58 = new(0x58, DynamicBackground, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet59 = new(0x59, DynamicBackground, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet5A = new(0x5A, DynamicBackground, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet5B = new(0x5B, DynamicBackground, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet5C = new(0x5C, DynamicBackground, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet5D = new(0x5D, DynamicBackground, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet5E = new(0x5E, DynamicBackground, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet5F = new(0x5F, DynamicBackground, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet60 = new(0x60, DynamicBackground, SNES3BPPCompressed);

		public static readonly GFXSheetMeta GFXSheet61 = new(0x61, Empty, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet62 = new(0x62, Empty, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet63 = new(0x63, Empty, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet64 = new(0x64, Empty, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet65 = new(0x65, Empty, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet66 = new(0x66, Empty, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet67 = new(0x67, Empty, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet68 = new(0x68, Empty, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet69 = new(0x69, Empty, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet6A = new(0x6A, Empty, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet6B = new(0x6B, Empty, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet6C = new(0x6C, Empty, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet6D = new(0x6D, Empty, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet6E = new(0x6E, Empty, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet6F = new(0x6F, Empty, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet70 = new(0x70, Empty, SNES3BPPCompressed);

		public static readonly GFXSheetMeta GFXSheet71 = new(0x71, Garbage, SNES2BPPCompressed);
		public static readonly GFXSheetMeta GFXSheet72 = new(0x72, Garbage, SNES2BPPCompressed);

		public static readonly GFXSheetMeta GFXSheet73 = new(0x73, DynamicSprite, SNES3BPP, backpal: true, index: 0);
		public static readonly GFXSheetMeta GFXSheet74 = new(0x74, Sprite, SNES3BPP, backpal: true, index: 1);
		public static readonly GFXSheetMeta GFXSheet75 = new(0x75, Sprite, SNES3BPP, backpal: true);
		public static readonly GFXSheetMeta GFXSheet76 = new(0x76, Sprite, SNES3BPP, backpal: true);
		public static readonly GFXSheetMeta GFXSheet77 = new(0x77, Sprite, SNES3BPP, backpal: true);
		public static readonly GFXSheetMeta GFXSheet78 = new(0x78, Sprite, SNES3BPP, backpal: false);
		public static readonly GFXSheetMeta GFXSheet79 = new(0x79, Sprite, SNES3BPP, backpal: false, index: 2);
		public static readonly GFXSheetMeta GFXSheet7A = new(0x7A, Sprite, SNES3BPP, backpal: false, index: 3);
		public static readonly GFXSheetMeta GFXSheet7B = new(0x7B, Sprite, SNES3BPP, backpal: true);
		public static readonly GFXSheetMeta GFXSheet7C = new(0x7C, Sprite, SNES3BPP, backpal: false);
		public static readonly GFXSheetMeta GFXSheet7D = new(0x7D, Sprite, SNES3BPP, backpal: true, index: 1);
		public static readonly GFXSheetMeta GFXSheet7E = new(0x7E, Sprite, SNES3BPP, backpal: true, index: 1);

		public static readonly GFXSheetMeta GFXSheet7F = new(0x7F, Sprite, SNES3BPPCompressed, backpal: false, index: 6);
		public static readonly GFXSheetMeta GFXSheet80 = new(0x80, Sprite, SNES3BPPCompressed, backpal: false);
		public static readonly GFXSheetMeta GFXSheet81 = new(0x81, Sprite, SNES3BPPCompressed, backpal: false, index: 7);
		public static readonly GFXSheetMeta GFXSheet82 = new(0x82, Sprite, SNES3BPPCompressed, backpal: false);
		public static readonly GFXSheetMeta GFXSheet83 = new(0x83, Sprite, SNES3BPPCompressed, backpal: false, index: 7);
		public static readonly GFXSheetMeta GFXSheet84 = new(0x84, Sprite, SNES3BPPCompressed, backpal: false, index: 7);
		public static readonly GFXSheetMeta GFXSheet85 = new(0x85, Sprite, SNES3BPPCompressed, backpal: false, index: 6);
		public static readonly GFXSheetMeta GFXSheet86 = new(0x86, Sprite, SNES3BPPCompressed, backpal: false, index: 6);
		public static readonly GFXSheetMeta GFXSheet87 = new(0x87, Sprite, SNES3BPPCompressed, backpal: false, index: 7);
		public static readonly GFXSheetMeta GFXSheet88 = new(0x88, Sprite, SNES3BPPCompressed, backpal: false, index: 7);
		public static readonly GFXSheetMeta GFXSheet89 = new(0x89, Sprite, SNES3BPPCompressed, backpal: false, index: 4);
		public static readonly GFXSheetMeta GFXSheet8A = new(0x8A, Sprite, SNES3BPPCompressed, backpal: false, index: 6);
		public static readonly GFXSheetMeta GFXSheet8B = new(0x8B, Sprite, SNES3BPPCompressed, backpal: false, index: 6);
		public static readonly GFXSheetMeta GFXSheet8C = new(0x8C, Sprite, SNES3BPPCompressed, backpal: false, index: 7);
		public static readonly GFXSheetMeta GFXSheet8D = new(0x8D, Sprite, SNES3BPPCompressed, backpal: false, index: 5);
		public static readonly GFXSheetMeta GFXSheet8E = new(0x8E, Sprite, SNES3BPPCompressed, backpal: false, index: 7);
		public static readonly GFXSheetMeta GFXSheet8F = new(0x8F, Sprite, SNES3BPPCompressed, backpal: false, index: 6);
		public static readonly GFXSheetMeta GFXSheet90 = new(0x90, Sprite, SNES3BPPCompressed, backpal: false, index: 7);
		public static readonly GFXSheetMeta GFXSheet91 = new(0x91, Sprite, SNES3BPPCompressed, backpal: false, index: 5);
		public static readonly GFXSheetMeta GFXSheet92 = new(0x92, Sprite, SNES3BPPCompressed, backpal: false, index: 4);
		public static readonly GFXSheetMeta GFXSheet93 = new(0x93, Sprite, SNES3BPPCompressed, backpal: false, index: 5);
		public static readonly GFXSheetMeta GFXSheet94 = new(0x94, Sprite, SNES3BPPCompressed, backpal: false, index: 4);
		public static readonly GFXSheetMeta GFXSheet95 = new(0x95, Sprite, SNES3BPPCompressed, backpal: false, index: 6);
		public static readonly GFXSheetMeta GFXSheet96 = new(0x96, Sprite, SNES3BPPCompressed, backpal: false, index: 6);
		public static readonly GFXSheetMeta GFXSheet97 = new(0x97, Sprite, SNES3BPPCompressed, backpal: false, index: 6);
		public static readonly GFXSheetMeta GFXSheet98 = new(0x98, Sprite, SNES3BPPCompressed, backpal: false, index: 6);
		public static readonly GFXSheetMeta GFXSheet99 = new(0x99, Sprite, SNES3BPPCompressed, backpal: false, index: 6);
		public static readonly GFXSheetMeta GFXSheet9A = new(0x9A, Sprite, SNES3BPPCompressed, backpal: false, index: 6);
		public static readonly GFXSheetMeta GFXSheet9B = new(0x9B, Sprite, SNES3BPPCompressed, backpal: false, index: 6);
		public static readonly GFXSheetMeta GFXSheet9C = new(0x9C, Sprite, SNES3BPPCompressed, backpal: false, index: 6);
		public static readonly GFXSheetMeta GFXSheet9D = new(0x9D, Sprite, SNES3BPPCompressed, backpal: false, index: 6);
		public static readonly GFXSheetMeta GFXSheet9E = new(0x9E, Sprite, SNES3BPPCompressed, backpal: false); // TODO IS THIS EMPTY???
		public static readonly GFXSheetMeta GFXSheet9F = new(0x9F, Sprite, SNES3BPPCompressed, backpal: false, index: 5);
		public static readonly GFXSheetMeta GFXSheetA0 = new(0xA0, Sprite, SNES3BPPCompressed, backpal: false);
		public static readonly GFXSheetMeta GFXSheetA1 = new(0xA1, Sprite, SNES3BPPCompressed, backpal: false, index: 6);
		public static readonly GFXSheetMeta GFXSheetA2 = new(0xA2, Sprite, SNES3BPPCompressed, backpal: false, index: 4);
		public static readonly GFXSheetMeta GFXSheetA3 = new(0xA3, Sprite, SNES3BPPCompressed, backpal: false, index: 6);
		public static readonly GFXSheetMeta GFXSheetA4 = new(0xA4, Sprite, SNES3BPPCompressed, backpal: false, index: 7);
		public static readonly GFXSheetMeta GFXSheetA5 = new(0xA5, Sprite, SNES3BPPCompressed, backpal: false);
		public static readonly GFXSheetMeta GFXSheetA6 = new(0xA6, Sprite, SNES3BPPCompressed, backpal: false);
		public static readonly GFXSheetMeta GFXSheetA7 = new(0xA7, Sprite, SNES3BPPCompressed, backpal: false);
		public static readonly GFXSheetMeta GFXSheetA8 = new(0xA8, Sprite, SNES3BPPCompressed, backpal: false);
		public static readonly GFXSheetMeta GFXSheetA9 = new(0xA9, Sprite, SNES3BPPCompressed, backpal: false, index: 7);
		public static readonly GFXSheetMeta GFXSheetAA = new(0xAA, Sprite, SNES3BPPCompressed, backpal: false, index: 6);
		public static readonly GFXSheetMeta GFXSheetAB = new(0xAB, Sprite, SNES3BPPCompressed, backpal: false, index: 6);
		public static readonly GFXSheetMeta GFXSheetAC = new(0xAC, Sprite, SNES3BPPCompressed, backpal: false, index: 6);
		public static readonly GFXSheetMeta GFXSheetAD = new(0xAD, Sprite, SNES3BPPCompressed, backpal: false, index: 6);
		public static readonly GFXSheetMeta GFXSheetAE = new(0xAE, Sprite, SNES3BPPCompressed, backpal: false, index: 6);
		public static readonly GFXSheetMeta GFXSheetAF = new(0xAF, Sprite, SNES3BPPCompressed, backpal: false, index: 6);
		public static readonly GFXSheetMeta GFXSheetB0 = new(0xB0, Sprite, SNES3BPPCompressed, backpal: false, index: 7);
		public static readonly GFXSheetMeta GFXSheetB1 = new(0xB1, Sprite, SNES3BPPCompressed, backpal: false, index: 7);
		public static readonly GFXSheetMeta GFXSheetB2 = new(0xB2, Sprite, SNES3BPPCompressed, backpal: false, index: 7);
		public static readonly GFXSheetMeta GFXSheetB3 = new(0xB3, Sprite, SNES3BPPCompressed, backpal: false, index: 4);
		public static readonly GFXSheetMeta GFXSheetB4 = new(0xB4, Sprite, SNES3BPPCompressed, backpal: false, index: 5);
		public static readonly GFXSheetMeta GFXSheetB5 = new(0xB5, Sprite, SNES3BPPCompressed, backpal: false, index: 6);
		public static readonly GFXSheetMeta GFXSheetB6 = new(0xB6, Sprite, SNES3BPPCompressed, backpal: false, index: 7);
		public static readonly GFXSheetMeta GFXSheetB7 = new(0xB7, Sprite, SNES3BPPCompressed, backpal: false, index: 7);
		public static readonly GFXSheetMeta GFXSheetB8 = new(0xB8, Sprite, SNES3BPPCompressed, backpal: false, index: 6);
		public static readonly GFXSheetMeta GFXSheetB9 = new(0xB9, Sprite, SNES3BPPCompressed, backpal: false, index: 4);
		public static readonly GFXSheetMeta GFXSheetBA = new(0xBA, Sprite, SNES3BPPCompressed, backpal: false, index: 4);
		public static readonly GFXSheetMeta GFXSheetBB = new(0xBB, Sprite, SNES3BPPCompressed, backpal: false, index: 4);
		public static readonly GFXSheetMeta GFXSheetBC = new(0xBC, Sprite, SNES3BPPCompressed, backpal: false, index: 5);
		public static readonly GFXSheetMeta GFXSheetBD = new(0xBD, Sprite, SNES3BPPCompressed, backpal: false, index: 6);
		public static readonly GFXSheetMeta GFXSheetBE = new(0xBE, Sprite, SNES3BPPCompressed, backpal: false, index: 4);
		public static readonly GFXSheetMeta GFXSheetBF = new(0xBF, Sprite, SNES3BPPCompressed, backpal: false, index: 6);
		public static readonly GFXSheetMeta GFXSheetC0 = new(0xC0, Sprite, SNES3BPPCompressed, backpal: false, index: 5);
		public static readonly GFXSheetMeta GFXSheetC1 = new(0xC1, Sprite, SNES3BPPCompressed, backpal: false, index: 6);
		public static readonly GFXSheetMeta GFXSheetC2 = new(0xC2, Sprite, SNES3BPPCompressed, backpal: false, index: 4);
		public static readonly GFXSheetMeta GFXSheetC3 = new(0xC3, Sprite, SNES3BPPCompressed, backpal: false, index: 7);
		public static readonly GFXSheetMeta GFXSheetC4 = new(0xC4, Sprite, SNES3BPPCompressed, backpal: false, index: 4);
		public static readonly GFXSheetMeta GFXSheetC5 = new(0xC5, Sprite, SNES3BPPCompressed, backpal: true, index: 6);
		public static readonly GFXSheetMeta GFXSheetC6 = new(0xC6, Sprite, SNES3BPPCompressed, backpal: true, index: 6);
		public static readonly GFXSheetMeta GFXSheetC7 = new(0xC7, DynamicSprite, SNES3BPPCompressed, backpal: true); // TODO verify
		public static readonly GFXSheetMeta GFXSheetC8 = new(0xC8, Sprite, SNES3BPPCompressed, backpal: false, index: 4);
		public static readonly GFXSheetMeta GFXSheetC9 = new(0xC9, DungeonMapTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheetCA = new(0xCA, DungeonMapTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheetCB = new(0xCB, DynamicSprite, SNES3BPPCompressed, backpal: false);
		public static readonly GFXSheetMeta GFXSheetCC = new(0xCC, DynamicSprite, SNES3BPPCompressed, backpal: false);
		public static readonly GFXSheetMeta GFXSheetCD = new(0xCD, DynamicSprite, SNES3BPPCompressed, backpal: true, index: 7);
		public static readonly GFXSheetMeta GFXSheetCE = new(0xCE, DynamicSprite, SNES3BPPCompressed, backpal: true);
		public static readonly GFXSheetMeta GFXSheetCF = new(0xCF, DynamicSprite, SNES3BPPCompressed, backpal: true);
		public static readonly GFXSheetMeta GFXSheetD0 = new(0xD0, DynamicSprite, SNES3BPPCompressed, backpal: false, index: 4);
		public static readonly GFXSheetMeta GFXSheetD1 = new(0xD1, DynamicSprite, SNES3BPPCompressed, backpal: true);
		public static readonly GFXSheetMeta GFXSheetD2 = new(0xD2, DynamicSprite, SNES3BPPCompressed, backpal: true);
		public static readonly GFXSheetMeta GFXSheetD3 = new(0xD3, DynamicSprite, SNES3BPPCompressed, backpal: true);
		public static readonly GFXSheetMeta GFXSheetD4 = new(0xD4, DungeonMapTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheetD5 = new(0xD5, DungeonMapTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheetD6 = new(0xD6, DungeonMapTile, SNES3BPPCompressed);
		public static readonly GFXSheetMeta GFXSheetD7 = new(0xD7, DynamicSprite, SNES3BPPCompressed, backpal: false);
		public static readonly GFXSheetMeta GFXSheetD8 = new(0xD8, DynamicSprite, SNES3BPPCompressed, backpal: false);
		public static readonly GFXSheetMeta GFXSheetD9 = new(0xD9, DynamicSprite, SNES3BPPCompressed, backpal: false);

		public static readonly GFXSheetMeta GFXSheetDA = new(0xDA, HUDTile, SNES2BPPCompressed);
		public static readonly GFXSheetMeta GFXSheetDB = new(0xDB, HUDTile, SNES2BPPCompressed);
		public static readonly GFXSheetMeta GFXSheetDC = new(0xDC, HUDTile, SNES2BPPCompressed);
		public static readonly GFXSheetMeta GFXSheetDD = new(0xDD, HUDTile, SNES2BPPCompressed);
		public static readonly GFXSheetMeta GFXSheetDE = new(0xDE, HUDTile, SNES2BPPCompressed);


		public static readonly GFXSheetMeta[] ListOf =
		{
			GFXSheet00,
			GFXSheet01,
			GFXSheet02,
			GFXSheet03,
			GFXSheet04,
			GFXSheet05,
			GFXSheet06,
			GFXSheet07,
			GFXSheet08,
			GFXSheet09,
			GFXSheet0A,
			GFXSheet0B,
			GFXSheet0C,
			GFXSheet0D,
			GFXSheet0E,
			GFXSheet0F,
			GFXSheet10,
			GFXSheet11,
			GFXSheet12,
			GFXSheet13,
			GFXSheet14,
			GFXSheet15,
			GFXSheet16,
			GFXSheet17,
			GFXSheet18,
			GFXSheet19,
			GFXSheet1A,
			GFXSheet1B,
			GFXSheet1C,
			GFXSheet1D,
			GFXSheet1E,
			GFXSheet1F,
			GFXSheet20,
			GFXSheet21,
			GFXSheet22,
			GFXSheet23,
			GFXSheet24,
			GFXSheet25,
			GFXSheet26,
			GFXSheet27,
			GFXSheet28,
			GFXSheet29,
			GFXSheet2A,
			GFXSheet2B,
			GFXSheet2C,
			GFXSheet2D,
			GFXSheet2E,
			GFXSheet2F,
			GFXSheet30,
			GFXSheet31,
			GFXSheet32,
			GFXSheet33,
			GFXSheet34,
			GFXSheet35,
			GFXSheet36,
			GFXSheet37,
			GFXSheet38,
			GFXSheet39,
			GFXSheet3A,
			GFXSheet3B,
			GFXSheet3C,
			GFXSheet3D,
			GFXSheet3E,
			GFXSheet3F,
			GFXSheet40,
			GFXSheet41,
			GFXSheet42,
			GFXSheet43,
			GFXSheet44,
			GFXSheet45,
			GFXSheet46,
			GFXSheet47,
			GFXSheet48,
			GFXSheet49,
			GFXSheet4A,
			GFXSheet4B,
			GFXSheet4C,
			GFXSheet4D,
			GFXSheet4E,
			GFXSheet4F,
			GFXSheet50,
			GFXSheet51,
			GFXSheet52,
			GFXSheet53,
			GFXSheet54,
			GFXSheet55,
			GFXSheet56,
			GFXSheet57,
			GFXSheet58,
			GFXSheet59,
			GFXSheet5A,
			GFXSheet5B,
			GFXSheet5C,
			GFXSheet5D,
			GFXSheet5E,
			GFXSheet5F,
			GFXSheet60,
			GFXSheet61,
			GFXSheet62,
			GFXSheet63,
			GFXSheet64,
			GFXSheet65,
			GFXSheet66,
			GFXSheet67,
			GFXSheet68,
			GFXSheet69,
			GFXSheet6A,
			GFXSheet6B,
			GFXSheet6C,
			GFXSheet6D,
			GFXSheet6E,
			GFXSheet6F,
			GFXSheet70,
			GFXSheet71,
			GFXSheet72,
			GFXSheet73,
			GFXSheet74,
			GFXSheet75,
			GFXSheet76,
			GFXSheet77,
			GFXSheet78,
			GFXSheet79,
			GFXSheet7A,
			GFXSheet7B,
			GFXSheet7C,
			GFXSheet7D,
			GFXSheet7E,
			GFXSheet7F,
			GFXSheet80,
			GFXSheet81,
			GFXSheet82,
			GFXSheet83,
			GFXSheet84,
			GFXSheet85,
			GFXSheet86,
			GFXSheet87,
			GFXSheet88,
			GFXSheet89,
			GFXSheet8A,
			GFXSheet8B,
			GFXSheet8C,
			GFXSheet8D,
			GFXSheet8E,
			GFXSheet8F,
			GFXSheet90,
			GFXSheet91,
			GFXSheet92,
			GFXSheet93,
			GFXSheet94,
			GFXSheet95,
			GFXSheet96,
			GFXSheet97,
			GFXSheet98,
			GFXSheet99,
			GFXSheet9A,
			GFXSheet9B,
			GFXSheet9C,
			GFXSheet9D,
			GFXSheet9E,
			GFXSheet9F,
			GFXSheetA0,
			GFXSheetA1,
			GFXSheetA2,
			GFXSheetA3,
			GFXSheetA4,
			GFXSheetA5,
			GFXSheetA6,
			GFXSheetA7,
			GFXSheetA8,
			GFXSheetA9,
			GFXSheetAA,
			GFXSheetAB,
			GFXSheetAC,
			GFXSheetAD,
			GFXSheetAE,
			GFXSheetAF,
			GFXSheetB0,
			GFXSheetB1,
			GFXSheetB2,
			GFXSheetB3,
			GFXSheetB4,
			GFXSheetB5,
			GFXSheetB6,
			GFXSheetB7,
			GFXSheetB8,
			GFXSheetB9,
			GFXSheetBA,
			GFXSheetBB,
			GFXSheetBC,
			GFXSheetBD,
			GFXSheetBE,
			GFXSheetBF,
			GFXSheetC0,
			GFXSheetC1,
			GFXSheetC2,
			GFXSheetC3,
			GFXSheetC4,
			GFXSheetC5,
			GFXSheetC6,
			GFXSheetC7,
			GFXSheetC8,
			GFXSheetC9,
			GFXSheetCA,
			GFXSheetCB,
			GFXSheetCC,
			GFXSheetCD,
			GFXSheetCE,
			GFXSheetCF,
			GFXSheetD0,
			GFXSheetD1,
			GFXSheetD2,
			GFXSheetD3,
			GFXSheetD4,
			GFXSheetD5,
			GFXSheetD6,
			GFXSheetD7,
			GFXSheetD8,
			GFXSheetD9,
			GFXSheetDA,
			GFXSheetDB,
			GFXSheetDC,
			GFXSheetDD,
			GFXSheetDE,
		};
	}
}
