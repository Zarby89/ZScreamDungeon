namespace ZeldaFullEditor.ALTTP.GameData
{
	public class SecretItemType : IEntityType<SecretItemType>
	{
		public delegate void DrawSecret(Artist art, IDrawableSprite s);

		public byte ID { get; }
		public int ListID => ID;
		public string Name { get; init; }

		public DrawSecret Draw { get; }

		private SecretItemType(byte id, DrawSecret d)
		{
			ID = id;
			Name = DefaultEntities.ListOfSecrets.GetNameFromEntityList(id);
			Draw = d;
		}

		public override string ToString() => Name;

		public static ImmutableArray<SecretItemType> ListOf { get; }

		// Need to use static constructor for reflection to work properly
		static SecretItemType()
		{
			ListOf = Utils.GetSortedListOfPredefinedFields<SecretItemType>();
		}

		public static SecretItemType GetTypeFromID(int id) => ListOf.GetTypeFromID(id);

		[PredefinedInstance] public static readonly SecretItemType Secret00 = new(0x00, SecretDraw_Nothing);
		[PredefinedInstance] public static readonly SecretItemType Secret01 = new(0x01, SecretDraw_GreenRupee);
		[PredefinedInstance] public static readonly SecretItemType Secret02 = new(0x02, SecretDraw_Hoarder);
		[PredefinedInstance] public static readonly SecretItemType Secret03 = new(0x03, SecretDraw_Bee);
		[PredefinedInstance] public static readonly SecretItemType Secret04 = new(0x04, SecretDraw_HealthPack);
		[PredefinedInstance] public static readonly SecretItemType Secret05 = new(0x05, SecretDraw_Bomb);
		[PredefinedInstance] public static readonly SecretItemType Secret06 = new(0x06, SecretDraw_Heart);
		[PredefinedInstance] public static readonly SecretItemType Secret07 = new(0x07, SecretDraw_BlueRupee);
		[PredefinedInstance] public static readonly SecretItemType Secret08 = new(0x08, SecretDraw_Key);
		[PredefinedInstance] public static readonly SecretItemType Secret09 = new(0x09, SecretDraw_Arrow);
		[PredefinedInstance] public static readonly SecretItemType Secret0A = new(0x0A, SecretDraw_Bomb);
		[PredefinedInstance] public static readonly SecretItemType Secret0B = new(0x0B, SecretDraw_Heart);
		[PredefinedInstance] public static readonly SecretItemType Secret0C = new(0x0C, SecretDraw_SmallMagic);
		[PredefinedInstance] public static readonly SecretItemType Secret0D = new(0x0D, SecretDraw_FullMagic);
		[PredefinedInstance] public static readonly SecretItemType Secret0E = new(0x0E, SecretDraw_Cucco);
		[PredefinedInstance] public static readonly SecretItemType Secret0F = new(0x0F, SecretDraw_GreenSoldier);
		[PredefinedInstance] public static readonly SecretItemType Secret10 = new(0x10, SecretDraw_BushStal);
		[PredefinedInstance] public static readonly SecretItemType Secret11 = new(0x11, SecretDraw_BlueSldier);
		[PredefinedInstance] public static readonly SecretItemType Secret12 = new(0x12, SecretDraw_Landmine);
		[PredefinedInstance] public static readonly SecretItemType Secret13 = new(0x13, SecretDraw_Heart);
		[PredefinedInstance] public static readonly SecretItemType Secret14 = new(0x14, SecretDraw_Fairy);
		[PredefinedInstance] public static readonly SecretItemType Secret15 = new(0x15, SecretDraw_Heart);
		[PredefinedInstance] public static readonly SecretItemType Secret16 = new(0x16, SecretDraw_Nothing);
		[PredefinedInstance] public static readonly SecretItemType Secret80 = new(0x80, SecretDraw_Hole);
		[PredefinedInstance] public static readonly SecretItemType Secret82 = new(0x82, SecretDraw_Warp);
		[PredefinedInstance] public static readonly SecretItemType Secret84 = new(0x84, SecretDraw_Staircase);
		[PredefinedInstance] public static readonly SecretItemType Secret86 = new(0x86, SecretDraw_Bombable);
		[PredefinedInstance] public static readonly SecretItemType Secret88 = new(0x88, SecretDraw_Switch);


		public static unsafe void DrawTiles(Artist art, IDrawableSprite sec, params OAMDrawInfo[] instructions)
		{
			art.DrawSprite(sec, instructions);
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
	}
}
