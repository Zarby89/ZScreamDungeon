using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data.DungeonObjects
{
	public class SecretItemType
	{
		public delegate void DrawSecret(ZScreamer ZS, DungeonSecret s);

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


		public static unsafe void DrawTiles(ZScreamer ZS, DungeonSecret sec, params OAMDrawInfo[] instructions)
		{
			var alltilesData = (byte*) ZS.GFXManager.currentOWgfx16Ptr.ToPointer();

			byte* ptr = (byte*) ZS.GFXManager.roomBg1Ptr.ToPointer(); ;

			// TODO poorly copied and shit
			foreach (OAMDrawInfo ti in instructions)
			{
				int size = ti.RectSideSize;
				byte r = (byte) (ti.HFlip ? 1 : 0);
				int tx = (ti.TileIndex / 16 * 512) + ((ti.TileIndex & 0xF) << 2); // TODO verify
				int indexoff = sec.X + ti.XOff + (512 * (sec.Y + ti.YOff));
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

		private static void SecretDraw_Arrow(ZScreamer ZS, DungeonSecret s)
		{

		}

		private static void SecretDraw_Bee(ZScreamer ZS, DungeonSecret s)
		{

		}

		private static void SecretDraw_BlueRupee(ZScreamer ZS, DungeonSecret s)
		{

		}

		private static void SecretDraw_BlueSldier(ZScreamer ZS, DungeonSecret s)
		{

		}

		private static void SecretDraw_Bomb(ZScreamer ZS, DungeonSecret s)
		{

		}

		private static void SecretDraw_Bombable(ZScreamer ZS, DungeonSecret s)
		{

		}

		private static void SecretDraw_BushStal(ZScreamer ZS, DungeonSecret s)
		{

		}

		private static void SecretDraw_Cucco(ZScreamer ZS, DungeonSecret s)
		{

		}

		private static void SecretDraw_Fairy(ZScreamer ZS, DungeonSecret s)
		{

		}

		private static void SecretDraw_FullMagic(ZScreamer ZS, DungeonSecret s)
		{

		}

		private static void SecretDraw_GreenRupee(ZScreamer ZS, DungeonSecret s)
		{

		}

		private static void SecretDraw_GreenSoldier(ZScreamer ZS, DungeonSecret s)
		{

		}

		private static void SecretDraw_HealthPack(ZScreamer ZS, DungeonSecret s)
		{

		}

		private static void SecretDraw_Heart(ZScreamer ZS, DungeonSecret s)
		{

		}

		private static void SecretDraw_Hoarder(ZScreamer ZS, DungeonSecret s)
		{

		}

		private static void SecretDraw_Hole(ZScreamer ZS, DungeonSecret s)
		{

		}

		private static void SecretDraw_Key(ZScreamer ZS, DungeonSecret s)
		{

		}

		private static void SecretDraw_Landmine(ZScreamer ZS, DungeonSecret s)
		{

		}

		private static void SecretDraw_Nothing(ZScreamer ZS, DungeonSecret s)
		{

		}

		private static void SecretDraw_SmallMagic(ZScreamer ZS, DungeonSecret s)
		{

		}

		private static void SecretDraw_Staircase(ZScreamer ZS, DungeonSecret s)
		{

		}

		private static void SecretDraw_Switch(ZScreamer ZS, DungeonSecret s)
		{

		}

		private static void SecretDraw_Warp(ZScreamer ZS, DungeonSecret s)
		{

		}


		public static SecretItemType FindSecretFromID(byte id)
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
