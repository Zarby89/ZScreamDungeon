using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
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

        public void Restore(SceneOW scene)
        {
            int i = 0;
            for (int y = 0; y < savedTiles.Length / lengthX; y++)
            {
                for (int x = 0; x < lengthX; x++)
                {
                    int superX = ((mouseXDown + x) / 32);
                    int superY = ((mouseYDown + y) / 32);
                    int mapId = (superY * 8) + superX + scene.ow.WorldOffset;
                    usedTiles[x + mouseXDown, y + mouseYDown] = savedTiles[i];
                    scene.ow.AllMaps[mapId].BuildMap();
                    scene.ow.AllMaps[mapId].CopyTile8bpp16(((mouseXDown + x) * 16) - (superX * 512), ((mouseYDown + y) * 16) - (superY * 512), savedTiles[i], scene.ow.AllMaps[mapId].gfxPtr, GFX.mapblockset16);
                    i++;
                }
            }

            //scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
        }

        public void RestoreRedo(SceneOW scene)
        {
            int i = 0;
            for (int y = 0; y < redosavedTiles.Length / lengthX; y++)
            {
                for (int x = 0; x < lengthX; x++)
                {
                    int superX = ((mouseXDown + x) / 32);
                    int superY = ((mouseYDown + y) / 32);
                    int mapId = (superY * 8) + superX + scene.ow.WorldOffset; ;
                    usedTiles[x + mouseXDown, y + mouseYDown] = redosavedTiles[i];
                    scene.ow.AllMaps[mapId].CopyTile8bpp16(((mouseXDown + x) * 16) - (superX * 512), ((mouseYDown + y) * 16) - (superY * 512), redosavedTiles[i], scene.ow.AllMaps[mapId].gfxPtr, GFX.mapblockset16);
                    i++;
                }
            }

            //scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
