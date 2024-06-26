﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
	public static partial class Constants
	{
		//===========================================================================================
		// Magic numbers
		//===========================================================================================
		public const ushort TilePriorityBit = 0x2000;
		public const ushort TileHFlipBit = 0x4000;
		public const ushort TileVFlipBit = 0x8000;
		public const ushort TileNameMask = 0x03FF;

		public const int Uncompressed3BPPSize = 0x0600;
		public const int UncompressedSheetSize = 0x0800;

		public const int NumberOfSheets = 223;
		public const int LimitOfMap32 = 8864;
		public const int NumberOfRooms = 296;

		public const int NumberOfOWMaps = 160;
		public const int Map32PerScreen = 256;
		public const int NumberOfMap16 = 3752; // 4096
		public const int NumberOfMap32 = Map32PerScreen * NumberOfOWMaps;
		public const int NumberOfOWSprites = 352;
		public const int NumberOfColors = 3143;

		public const int NumberOfEntranceTypes = 0x2B;
		public const int NumberOfOverworldExits = 0x4F;
		public const int NumberOfOverworldGraves = 0x0F;
		public const int NumberOfEntrances = 0x85;
		public const int NumberOfChests = 168;


		public const int ROMSize = 0x200000;
		public const int ROMHeaderSize = 0x200;

		public const int RoomsPerFloorOnMap = 25;
		public const int TilesPerUnderworldRoom = 4096;
		public const int TilesPerTilemap = 4096;

		public const int ColorsPerPalette = 16;
		public const int ColorsPerHalfPalette = 8;
		public const int NumberOfPalettes = 16;
		public const int TotalPaletteSize = ColorsPerPalette * NumberOfPalettes;

		// TODO zarby stop making magic numbers
		public const int IDKZarby = 0x54727;

		public static byte[] FontSpacings = new byte[] {
			4, 3, 5, 7, 5, 6, 5, 3, 4, 4, 5, 5, 3, 5, 3, 5,
			5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 3, 3, 5, 5, 5, 5,
			5, 5, 5, 5, 5, 5, 5, 6, 5, 5, 6, 5, 5, 7, 6, 5,
			5, 5, 5, 5, 5, 5, 5, 7, 5, 5, 5, 4, 5, 4, 6, 6, 6, 6 };

		//===========================================================================================
		// Yes
		//===========================================================================================
		public const int OverworldSpritePointers = 0x09_0000;
		public const int DungeonSpritePointers = 0x09_0000;

		public const byte BigKeyDropToken = 0xFD;
		public const byte SmallKeyDropToken = 0xFE;
		public const byte KeyDropID = 0xE4;
		public const byte NumberOfValidSprites = 0xF3;

		public const ushort ObjectSentinel = 0xFFFF;

		//===========================================================================================
		// IDs
		//===========================================================================================
		public const ushort ChestID = 0x219;
		public const ushort BigChestID = 0x231;
		public const ushort TorchPseudoID = 0x0E00;

		public const byte SpriteSentinel = 0xFF;

		public const byte LayerMergeOff = 0x00;
		public const byte LayerMergeParallax = 0x01;
		public const byte LayerMergeDark = 0x02;
		public const byte LayerMergeOnTop = 0x03;
		public const byte LayerMergeTranslucent = 0x04;
		public const byte LayerMergeAddition = 0x05;
		public const byte LayerMergeNormal = 0x06;
		public const byte LayerMergeTransparent = 0x07;
		public const byte LayerMergeDarkRoom = 0x08;

		//===========================================================================================
		// Clipboard stuff
		//===========================================================================================
		public const string OverworldSpriteClipboardData = "owsprite";
		public const string OverworldTilesClipboardData = "owtiles";
		public const string OverworldEntranceClipboardData = "owentrance";
		public const string OverworldExitClipboardData = "owexit";
		public const string OverworldItemClipboardData = "owitem";

		public const string ObjectZClipboardData = "objectz";

		//===========================================================================================
		// Geometry - for consistency and we should probably give them better names
		//===========================================================================================
		public static readonly Point Point_0_0 = new Point(0, 0);
		public static readonly Point Point_512_0 = new Point(512, 0);

		public static readonly Rectangle Rect_0_0_24_24 = new Rectangle(0, 0, 24, 24);
		public static readonly Rectangle Rect_0_0_64_64 = new Rectangle(0, 0, 64, 64);
		public static readonly Rectangle Rect_0_0_64_128 = new Rectangle(0, 0, 64, 128);
		public static readonly Rectangle Rect_0_0_128_128 = new Rectangle(0, 0, 128, 128);
		public static readonly Rectangle Rect_0_0_128_512 = new Rectangle(0, 0, 128, 512);
		public static readonly Rectangle Rect_0_0_128_4096 = new Rectangle(0, 0, 128, 4096);
		public static readonly Rectangle Rect_0_0_256_192 = new Rectangle(0, 0, 256, 192);
		public static readonly Rectangle Rect_0_0_256_256 = new Rectangle(0, 0, 256, 256);
		public static readonly Rectangle Rect_0_0_256_1024 = new Rectangle(0, 0, 256, 1024);
		public static readonly Rectangle Rect_0_0_1024_1024 = new Rectangle(0, 0, 1024, 1024);
		public static readonly Rectangle Rect_0_0_512_384 = new Rectangle(0, 0, 512, 384);
		public static readonly Rectangle Rect_0_0_512_512 = new Rectangle(0, 0, 512, 512);
		public static readonly Rectangle Rect_0_0_128_40 = new Rectangle(0, 0, 128, 40);
		public static readonly Rectangle Rect_0_0_256_14272 = new Rectangle(0, 0, 256, 14272);
		public static readonly Rectangle Rect_0_0_128_7136 = new Rectangle(0, 0, 128, 7136);

		public static readonly Rectangle Rect_128_0_128_4096 = new Rectangle(128, 0, 128, 4096);
		public static readonly Rectangle Rect_0_4096_128_4096 = new Rectangle(0, 4096, 128, 4096);

		public static readonly Rectangle Rect_0_0_340_102 = new Rectangle(0, 0, 170, 102);
		public static readonly Rectangle Rect_0_0_170_51 = new Rectangle(0, 0, 170, 51);
		public static readonly Rectangle Rect_336_0_4_102 = new Rectangle(336, 0, 4, 102);

		public static readonly Rectangle Rect_1_1_182_182 = new Rectangle(1, 1, 182, 182);
		public static readonly Rectangle Rect_3_3_178_178 = new Rectangle(3, 3, 178, 178);
		public static readonly Rectangle Rect_0_0_24_240 = new Rectangle(0, 0, 24, 240);

		public static readonly Size Size340x102 = new Size(340, 102);
		public static readonly Size Size512x512 = new Size(512, 512);
		public static readonly Size Size1024x1024 = new Size(1024, 1024);
		public static readonly Size Size4096x4096 = new Size(4096, 4096);

		//===========================================================================================
		// Fonts
		//===========================================================================================
		public static readonly Font Arial7 = new Font("Arial", 7);

		//===========================================================================================
		// Colors - colors we use for consistency and we should probably give them better names
		//===========================================================================================
		public static readonly Color HalfWhite = Color.FromArgb(128, 255, 255, 255);
		public static readonly Color HalfWhite2 = Color.FromArgb(255, 255, 255);
		public static readonly Pen HalfWhitePen = new Pen(HalfWhite);

		public static readonly Color ThirdWhite = Color.FromArgb(85, 255, 255, 255);
		public static readonly Pen ThirdWhitePen = new Pen(ThirdWhite);
		public static readonly Pen ThirdWhitePen1 = new Pen(ThirdWhite, 1);

		public static readonly Color White100 = Color.FromArgb(100, 255, 255, 255);
		public static readonly Pen White100Pen = new Pen(White100);
		public static readonly Pen White100Pen1 = new Pen(White100, 1);

		public static readonly Color HalfRed = Color.FromArgb(128, 255, 0, 0);
		public static readonly Pen HalfRedPen = new Pen(HalfRed);
		public static readonly Brush HalfRedBrush = new SolidBrush(HalfRed);

		public static readonly Color ThirdGreen = Color.FromArgb(100, 0, 200, 0);
		public static readonly Pen ThirdGreenPen = new Pen(ThirdGreen);
		public static readonly Brush ThirdGreenBrush = new SolidBrush(ThirdGreen);

		public static readonly Color QuarterWhite = Color.FromArgb(60, 255, 255, 255);
		public static readonly Pen QuarterWhitePen = new Pen(QuarterWhite);

		public static readonly Color FifthBlue = Color.FromArgb(50, 0, 0, 255);
		public static readonly Brush FifthBlueBrush = new SolidBrush(FifthBlue);

		public static readonly Pen Orange220Pen1 = new Pen(Color.FromArgb(220, Color.Orange), 1);
		public static readonly Pen Red220Pen1 = new Pen(Color.FromArgb(220, Color.Red), 1);

		public static readonly Pen LimeGreenPen2 = new Pen(Brushes.LimeGreen, 2);
		public static readonly Pen AquaPen2 = new Pen(Brushes.Aqua, 2);
		public static readonly Pen BlackPen2 = new Pen(Brushes.Black, 2);
		public static readonly Pen AzurePen2 = new Pen(Color.Azure, 2);
		public static readonly Pen RedPen4 = new Pen(Color.Red, 2);

		public static readonly Color Magenta200 = Color.FromArgb(200, 222, 16, 145);
		public static readonly Pen Magenta200Pen = new Pen(Magenta200);
		public static readonly Brush Magenta200Brush = new SolidBrush(Magenta200);

		public static readonly Color MediumMint200 = Color.FromArgb(200, 14, 224, 146);
		public static readonly Pen MediumMint200Pen = new Pen(MediumMint200);
		public static readonly Brush MediumMint200Brush = new SolidBrush(MediumMint200);


	}
}
