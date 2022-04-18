using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
	public class GfxGroups
	{
		public byte[][] mainGfx = new byte[37][];
		public byte[][] roomGfx = new byte[82][];
		public byte[][] spriteGfx = new byte[144][];
		public byte[][] paletteGfx = new byte[72][];

		private readonly ZScreamer ZS;
		public GfxGroups(ZScreamer zs)
		{
			ZS = zs;
		}

		public void LoadGfxGroups()
		{
			int gfxPointer = ZS.ROM[ZS.Offsets.gfx_groups_pointer, 2];
			gfxPointer = gfxPointer.SNEStoPC();

			for (int i = 0; i < 37; i++)
			{
				mainGfx[i] = new byte[8];
				for (int j = 0; j < 8; j++)
				{
					mainGfx[i][j] = ZS.ROM[gfxPointer + (i * 8) + j];
				}
			}

			for (int i = 0; i < 82; i++)
			{
				roomGfx[i] = new byte[4];
				for (int j = 0; j < 4; j++)
				{
					roomGfx[i][j] = ZS.ROM[ZS.Offsets.overworldgfxGroups + (i * 4) + j];
				}
			}

			for (int i = 0; i < 144; i++)
			{
				spriteGfx[i] = new byte[4];
				for (int j = 0; j < 4; j++)
				{
					spriteGfx[i][j] = ZS.ROM[ZS.Offsets.sprite_blockset_pointer + (i * 4) + j];
				}
			}

			for (int i = 0; i < 72; i++)
			{
				paletteGfx[i] = new byte[4];
				for (int j = 0; j < 4; j++)
				{
					paletteGfx[i][j] = ZS.ROM[ZS.Offsets.dungeons_palettes_groups + (i * 4) + j];
				}
			}
		}

		public bool SaveGroupsToROM()
		{
			int gfxPointer = SNESFunctions.SNEStoPC(ZS.ROM[ZS.Offsets.gfx_groups_pointer, 2]);

			for (int i = 0; i < 37; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					ZS.ROM[gfxPointer + (i * 8) + j] = mainGfx[i][j];
				}
			}

			for (int i = 0; i < 82; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					ZS.ROM[ZS.Offsets.overworldgfxGroups + (i * 4) + j] = roomGfx[i][j];
				}
			}

			for (int i = 0; i < 144; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					ZS.ROM[ZS.Offsets.sprite_blockset_pointer + (i * 4) + j] = spriteGfx[i][j];
				}
			}

			for (int i = 0; i < 72; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					ZS.ROM[ZS.Offsets.dungeons_palettes_groups + (i * 4) + j] = paletteGfx[i][j];
				}
			}

			return false;
		}
	}
}
