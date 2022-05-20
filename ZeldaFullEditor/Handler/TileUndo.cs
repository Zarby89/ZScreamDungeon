﻿namespace ZeldaFullEditor.Handler
{
	class TileUndo : ICloneable
	{
		public int mouseXDown { get; set; }
		public int mouseYDown { get; set; }
		public int lengthX { get; set; }
		public ushort[] savedTiles { get; set; }
		public ushort[] redosavedTiles { get; set; }
		public ushort[,] usedTiles { get; set; }

		public TileUndo(int mouseXDown, int mouseYDown, int lengthX, ushort[] savedTiles, ushort[] redosavedTiles, ref ushort[,] usedTiles)
		{
			this.mouseXDown = mouseXDown;
			this.mouseYDown = mouseYDown;
			this.lengthX = lengthX;
			this.savedTiles = savedTiles;
			this.usedTiles = usedTiles;
			this.redosavedTiles = redosavedTiles;
		}

		public void Restore(Overworld ow)
		{
			//int i = 0;
			//for (int y = 0; y < savedTiles.Length / lengthX; y++)
			//{
			//	for (int x = 0; x < lengthX; x++)
			//	{
			//		int superX = ((mouseXDown + x) / 32);
			//		int superY = ((mouseYDown + y) / 32);
			//		int mapId = (superY * 8) + superX + ow.WorldOffset;
			//		usedTiles[x + mouseXDown, y + mouseYDown] = savedTiles[i];
			//		ow.allmaps[mapId].BuildMap();
			//		ow.allmaps[mapId].CopyTile8bpp16(((mouseXDown + x) * 16) - (superX * 512), ((mouseYDown + y) * 16) - (superY * 512), savedTiles[i],
			//			ow.allmaps[mapId].gfxPtr, ow.ZS.GFXManager.mapblockset16);
			//		i++;
			//	}
			//}
		}

		public void RestoreRedo(Overworld ow)
		{
			//int i = 0;
			//for (int y = 0; y < redosavedTiles.Length / lengthX; y++)
			//{
			//	for (int x = 0; x < lengthX; x++)
			//	{
			//		int superX = ((mouseXDown + x) / 32);
			//		int superY = ((mouseYDown + y) / 32);
			//		int mapId = (superY * 8) + superX + ow.WorldOffset; ;
			//		usedTiles[x + mouseXDown, y + mouseYDown] = redosavedTiles[i];
			//		ow.allmaps[mapId].CopyTile8bpp16(((mouseXDown + x) * 16) - (superX * 512), ((mouseYDown + y) * 16) - (superY * 512),
			//			redosavedTiles[i], ow.allmaps[mapId].gfxPtr, ow.ZS.GFXManager.mapblockset16);
			//		i++;
			//	}
			//}
		}

		public object Clone()
		{
			return MemberwiseClone();
		}
	}
}
