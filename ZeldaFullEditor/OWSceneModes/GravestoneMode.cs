using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Lidgren.Network;
using ZeldaFullEditor.Data;
using ZeldaFullEditor.Properties;

namespace ZeldaFullEditor.OWSceneModes
{
    public class GravestoneMode
    {
        SceneOW scene;
        public Gravestone selectedGrave = null;
        public Gravestone lastselectedGrave = null;

        public GravestoneMode(SceneOW scene)
        {
            this.scene = scene;
        }

        public void onMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                for (int i = 0; i < 0x0F; i++)
                {
                    Gravestone en = scene.ow.AllGraves[i];
                    if (e.X >= en.XTilePos && e.X < en.XTilePos + 32 && e.Y >= en.YTilePos && e.Y < en.YTilePos + 32)
                    {
                        if (!scene.mouse_down)
                        {
                            selectedGrave = en;
                            lastselectedGrave = en;
                            //scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
                            scene.mouse_down = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Triggers on mouse move in gravestone mode.
        /// </summary>
        /// <param name="e"> Event args. </param>
        public void OnMouseMove(MouseEventArgs e)
        {
            if (this.scene.mouse_down)
            {
                int mouseTileX = e.X / 16;
                int mouseTileY = e.Y / 16;
                int mapX = mouseTileX / 32;
                int mapY = mouseTileY / 32;

                int tempMapHover = mapX + (mapY * 8);

                this.scene.mapHover = this.scene.ow.AllMaps[tempMapHover].ParentID;

                if (this.selectedGrave != null)
                {
                    this.selectedGrave.XTilePos = (ushort)e.X;
                    this.selectedGrave.YTilePos = (ushort)e.Y;
                    if (this.scene.snapToGrid)
                    {
                        this.selectedGrave.XTilePos = (ushort)((e.X / 8) * 8);
                        this.selectedGrave.YTilePos = (ushort)((e.Y / 8) * 8);
                    }
                }
            }
        }

        /// <summary>
        ///     Triggers on mouse up in gravestone mode. Calculates grave data.
        /// </summary>
        /// <param name="e"> Event args. </param>
        public void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.selectedGrave != null)
                {
                    if (this.scene.mapHover >= 64)
                    {
                        this.scene.mapHover -= 64;
                    }

                    int mx = this.scene.mapHover - ((this.scene.mapHover / 8) * 8);
                    int my = this.scene.mapHover / 8;

                    byte xx = (byte)((this.selectedGrave.XTilePos - (mx * 512)) / 16);
                    byte yy = (byte)((this.selectedGrave.YTilePos - (my * 512)) / 16);

                    this.selectedGrave.TilemapPos = (ushort)(((yy << 6) | (xx & 0x3F)) << 1);

                    this.lastselectedGrave = this.selectedGrave;
                    this.SendGraveData(this.lastselectedGrave);
                    this.selectedGrave = null;
                    this.scene.mouse_down = false;
                }
            }
        }

        public void Draw(Graphics g)
        {
            Pen bgrBrush = Constants.Magenta200Pen;
            g.CompositingMode = CompositingMode.SourceOver;

            for (int i = 0; i < scene.ow.AllGraves.Length; i++)
            {
                Gravestone e = scene.ow.AllGraves[i];

                if (selectedGrave != null)
                {
                    if (e == selectedGrave)
                    {
                        bgrBrush = Constants.MediumMint200Pen;
                        //scene.drawText(g, e.xTilePos + 8, e.yTilePos + 8, "ID : " + i.ToString("X2"));
                    }
                    else
                    {
                        bgrBrush = Constants.Magenta200Pen;
                    }
                }

                g.DrawRectangle(bgrBrush, new Rectangle(e.XTilePos, e.YTilePos, 32, 32));
                scene.drawText(g, e.XTilePos + 8, e.YTilePos + 8, i.ToString("X2"));

                //scene.drawText(g, e.xTilePos + 8, e.yTilePos + 40, e.tilemapPos.ToString("X4"));
                if (i == 0x0D) // Stairs
                {
                    scene.drawText(g, e.XTilePos + 8, e.YTilePos + 16, "SPECIAL STAIRS");
                }

                if (i == 0x0E) // Hole
                {
                    scene.drawText(g, e.XTilePos + 8, e.YTilePos + 16, "SPECIAL HOLE");
                }
            }
        }
        private void SendGraveData(Gravestone gravestone)
        {

            if (!NetZS.connected) { return; }
            NetZSBuffer buffer = new NetZSBuffer(24);
            buffer.Write((byte)11); // grave data
            buffer.Write((byte)NetZS.userID); //user ID
            buffer.Write((int)gravestone.UniqueID);
            buffer.Write((ushort)gravestone.YTilePos);
            buffer.Write((ushort)gravestone.XTilePos);
            buffer.Write((ushort)gravestone.TilemapPos);
            buffer.Write((ushort)gravestone.GFX);


            NetOutgoingMessage msg = NetZS.client.CreateMessage();
            msg.Write(buffer.buffer);
            NetZS.client.SendMessage(msg, NetDeliveryMethod.ReliableOrdered);
            NetZS.client.FlushSendQueue();


        }
    }
}
