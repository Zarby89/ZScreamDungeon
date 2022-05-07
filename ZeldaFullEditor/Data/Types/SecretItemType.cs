using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaFullEditor.Data.Underworld;

namespace ZeldaFullEditor.Data
{
	public class SecretItemType : IEntityType<SecretItemType>
	{
		public delegate void DrawSecret(Artist art, IDrawableSprite s);

		public byte ID { get; }
		public string VanillaName { get; }

		public DrawSecret Draw { get; }

		private SecretItemType(byte id, DrawSecret d)
		{
			ID = id;
			VanillaName = DefaultEntities.ListOfSecrets.GetNameFromVanillaList(id);
			Draw = d;
		}



		public static readonly SecretItemType Secret00 = new SecretItemType(0x00, SecretDraw_Nothing);
		public static readonly SecretItemType Secret01 = new SecretItemType(0x01, SecretDraw_GreenRupee);
		public static readonly SecretItemType Secret02 = new SecretItemType(0x02, SecretDraw_Hoarder);
		public static readonly SecretItemType Secret03 = new SecretItemType(0x03, SecretDraw_Bee);
		public static readonly SecretItemType Secret04 = new SecretItemType(0x04, SecretDraw_HealthPack);
		public static readonly SecretItemType Secret05 = new SecretItemType(0x05, SecretDraw_Bomb);
		public static readonly SecretItemType Secret06 = new SecretItemType(0x06, SecretDraw_Heart);
		public static readonly SecretItemType Secret07 = new SecretItemType(0x07, SecretDraw_BlueRupee);
		public static readonly SecretItemType Secret08 = new SecretItemType(0x08, SecretDraw_Key);
		public static readonly SecretItemType Secret09 = new SecretItemType(0x09, SecretDraw_Arrow);
		public static readonly SecretItemType Secret0A = new SecretItemType(0x0A, SecretDraw_Bomb);
		public static readonly SecretItemType Secret0B = new SecretItemType(0x0B, SecretDraw_Heart);
		public static readonly SecretItemType Secret0C = new SecretItemType(0x0C, SecretDraw_SmallMagic);
		public static readonly SecretItemType Secret0D = new SecretItemType(0x0D, SecretDraw_FullMagic);
		public static readonly SecretItemType Secret0E = new SecretItemType(0x0E, SecretDraw_Cucco);
		public static readonly SecretItemType Secret0F = new SecretItemType(0x0F, SecretDraw_GreenSoldier);
		public static readonly SecretItemType Secret10 = new SecretItemType(0x10, SecretDraw_BushStal);
		public static readonly SecretItemType Secret11 = new SecretItemType(0x11, SecretDraw_BlueSldier);
		public static readonly SecretItemType Secret12 = new SecretItemType(0x12, SecretDraw_Landmine);
		public static readonly SecretItemType Secret13 = new SecretItemType(0x13, SecretDraw_Heart);
		public static readonly SecretItemType Secret14 = new SecretItemType(0x14, SecretDraw_Fairy);
		public static readonly SecretItemType Secret15 = new SecretItemType(0x15, SecretDraw_Heart);
		public static readonly SecretItemType Secret16 = new SecretItemType(0x16, SecretDraw_Nothing);
		public static readonly SecretItemType Secret80 = new SecretItemType(0x80, SecretDraw_Hole);
		public static readonly SecretItemType Secret82 = new SecretItemType(0x82, SecretDraw_Warp);
		public static readonly SecretItemType Secret84 = new SecretItemType(0x84, SecretDraw_Staircase);
		public static readonly SecretItemType Secret86 = new SecretItemType(0x86, SecretDraw_Bombable);
		public static readonly SecretItemType Secret88 = new SecretItemType(0x88, SecretDraw_Switch);


		public static unsafe void DrawTiles(Artist art, IDrawableSprite sec, params OAMDrawInfo[] instructions)
		{
			var alltilesData = (byte*) art.LoadedGraphicsPointer.ToPointer();

			var ptr = (byte*) art.SpriteCanvasPointer.ToPointer();

			// TODO poorly copied and shit
			foreach (OAMDrawInfo ti in instructions)
			{
				int size = ti.RectSideSize;
				byte r = (byte) (ti.HFlip ? 1 : 0);
				int tx = (ti.TileIndex / 16 * 512) + ((ti.TileIndex & 0xF) << 2); // TODO verify
				int indexoff = sec.RealX + ti.XOff + (512 * (sec.RealY + ti.YOff));
				byte pal = (byte) (ti.Palette << 3);


				for (int yl = 0, yl2 = tx; yl < size; yl++, yl2 += 64)
				{
					int my = (512 * (ti.VFlip ? size - 1 - yl : yl)) + indexoff; // this is alltilesData additive, so it can go here

					for (int xl = 0, xl2 = yl2; xl < size; xl++, xl2++)
					{
						int mx = ti.HFlip ? size - 1 - xl : xl;
						var pixel = alltilesData[xl2];
						int index = (mx * 2) + my;

						if (pixel.BitIsOn(0x0F))
						{
							ptr[index + r ^ 1] = (byte) ((pixel & 0x0F) + 112 + pal);
						}
						if (pixel.BitIsOn(0xF0))
						{
							ptr[index + r] = (byte) ((pixel >> 4) + 112 + pal);
						}
					}
				}
			}
		}

		/*
		 * 			else if (id == 1)// Rupee
			{
				draw_item_tile(x * 8 + 4, y * 8, 0, 828, 11, false, false, 1);
			}
			else if (id == 2) // Rock Crab
			{
				draw_item_tile(x * 8, y * 8, 10, 520, 5);
			}
			else if (id == 3) // Bee
			{
				drawSpriteTile((x * 8) + 4, (y * 8) + 4, 4, 14, 11, false, false, 1, 1);
			}
			else if (id == 4) // Random
			{
				//draw_item_tile(x*8+4, y*8+4, 8, 8);
			}
			else if (id == 5) // Bomb
			{
				draw_item_tile(x * 8 + 0, y * 8 + 0, 4, 824, 7);
			}
			else if (id == 6) // Rupee
			{
				draw_item_tile(x * 8 + 4, y * 8, 0, 828, 11, false, false, 1);
			}
			else if (id == 7) // Blue rupee
			{
				draw_item_tile(x * 8 + 4, y * 8, 0, 828, 7, false, false, 1);
			}
			else if (id == 8) // Key*8
			{
				draw_item_tile(x * 8 + 4, y * 8 + 0, 14, 822, 11, false, false, 1);
			}
			else if (id == 9) // Arrow
			{
				draw_item_tile(x * 8 + 4, y * 8, 8, 830, 11, false, false, 1);
			}
			else if (id == 10) // 1bomb
			{
				draw_item_tile(x * 8 + 0, y * 8 + 0, 4, 824, 7);
			}
			else if (id == 11) // Heart
			{
				draw_item_tile(x * 8 + 4, y * 8, 6, 830, 5, false, false, 1);
			}
			else if (id == 12) // Magic
			{
				draw_item_tile(x * 8 + 4, y * 8, 7, 830, 11, false, false, 1);
			}
			else if (id == 13) // Big magic - need gfx
			{
				draw_item_tile(x * 8 + 4, y * 8, 2, 466, 11, false, false, 1);
			}
			else if (id == 14) // Chicken 
			{
				drawSpriteTile((x * 8), (y * 8), 10, 30, 5);
			}
			else if (id == 15) // Green soldier
			{
				drawSpriteTile((x * 8), (y * 8), 0, 20, 12);
			}
			else if (id == 16) // Alive rock
			{
				draw_item_tile(x * 8, y * 8, 10, 520, 5);
			}
			else if (id == 17) // Blue soldier
			{
				drawSpriteTile((x * 8), (y * 8), 0, 20, 10);
			}
			else if (id == 18) // Ground bomb
			{
				draw_item_tile(x * 8, y * 8 + 4, 0, 467, 7, false, false, 1, 1);
				draw_item_tile(x * 8 + 8, y * 8 + 4, 0, 467, 7, true, false, 1, 1);
			}
			else if (id == 19) // Heart
			{
				draw_item_tile(x * 8 + 4, y * 8, 6, 830, 5, false, false, 1);
			}
			else if (id == 20) // Fairy*8
			{
				draw_item_tile(x * 8, y * 8, 10, 490, 10);
			}
			else if (id == 21) // Heart
			{
				draw_item_tile(x * 8 + 4, y * 8, 6, 830, 5, false, false, 1);
			}
			else if (id == 22) // Nothing
			{
				//draw_item_tile(x*8, y*8, 16, 16, 0x6C, 10, true);
			}
			else if (id == 23) // Hole
			{
				//draw_item_tile(x * 8, y * 8, 16, 16, 0x60, 9, false);
			}
			else if (id == 24) // Warp
			{
				draw_item_tile(x * 8, y * 8, 6, 832, 11);
			}
			else if (id == 25) // Staircase
			{
				// TODO: Add draw here?
			}
			else if (id == 26) // Bombale
			{
				// TODO: Add draw here?
			}
			else if (id == 27) // Switch
			{
				draw_item_tile(x * 8, y * 8, 11, 56, 5, false, false, 1);
			}
		*/






		private static void SecretDraw_Arrow(Artist art, IDrawableSprite sec)
		{

		}

		private static void SecretDraw_Bee(Artist art, IDrawableSprite sec)
		{

		}

		private static void SecretDraw_BlueRupee(Artist art, IDrawableSprite sec)
		{

		}

		private static void SecretDraw_BlueSldier(Artist art, IDrawableSprite sec)
		{

		}

		private static void SecretDraw_Bomb(Artist art, IDrawableSprite sec)
		{

		}

		private static void SecretDraw_Bombable(Artist art, IDrawableSprite sec)
		{

		}

		private static void SecretDraw_BushStal(Artist art, IDrawableSprite sec)
		{

		}

		private static void SecretDraw_Cucco(Artist art, IDrawableSprite sec)
		{

		}

		private static void SecretDraw_Fairy(Artist art, IDrawableSprite sec)
		{

		}

		private static void SecretDraw_FullMagic(Artist art, IDrawableSprite sec)
		{

		}

		private static void SecretDraw_GreenRupee(Artist art, IDrawableSprite sec)
		{

		}

		private static void SecretDraw_GreenSoldier(Artist art, IDrawableSprite sec)
		{

		}

		private static void SecretDraw_HealthPack(Artist art, IDrawableSprite sec)
		{

		}

		private static void SecretDraw_Heart(Artist art, IDrawableSprite sec)
		{

		}

		private static void SecretDraw_Hoarder(Artist art, IDrawableSprite sec)
		{

		}

		private static void SecretDraw_Hole(Artist art, IDrawableSprite sec)
		{

		}

		private static void SecretDraw_Key(Artist art, IDrawableSprite sec)
		{

		}

		private static void SecretDraw_Landmine(Artist art, IDrawableSprite sec)
		{

		}

		private static void SecretDraw_Nothing(Artist art, IDrawableSprite sec)
		{

		}

		private static void SecretDraw_SmallMagic(Artist art, IDrawableSprite sec)
		{

		}

		private static void SecretDraw_Staircase(Artist art, IDrawableSprite sec)
		{

		}

		private static void SecretDraw_Switch(Artist art, IDrawableSprite sec)
		{

		}

		private static void SecretDraw_Warp(Artist art, IDrawableSprite sec)
		{

		}


		public static SecretItemType GetTypeFromID(int id)
		{
			switch (id)
			{
				case 0x00: return Secret00;
				case 0x01: return Secret01;
				case 0x02: return Secret02;
				case 0x03: return Secret03;
				case 0x04: return Secret04;
				case 0x05: return Secret05;
				case 0x06: return Secret06;
				case 0x07: return Secret07;
				case 0x08: return Secret08;
				case 0x09: return Secret09;
				case 0x0A: return Secret0A;
				case 0x0B: return Secret0B;
				case 0x0C: return Secret0C;
				case 0x0D: return Secret0D;
				case 0x0E: return Secret0E;
				case 0x0F: return Secret0F;
				case 0x10: return Secret10;
				case 0x11: return Secret11;
				case 0x12: return Secret12;
				case 0x13: return Secret13;
				case 0x14: return Secret14;
				case 0x15: return Secret15;
				case 0x16: return Secret16;
				case 0x80: return Secret80;
				case 0x82: return Secret82;
				case 0x84: return Secret84;
				case 0x86: return Secret86;
				case 0x88: return Secret88;
			}
			return Secret00;
		}
	}
}
