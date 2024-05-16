using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using ZeldaFullEditor.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace ZeldaFullEditor.Gui.ExtraForms
{
    public partial class AnimationSetting : Form
    {
        public SceneOW scene;
        byte nbrFrames = 0;
        bool persist = false;
        AnimationFrame[] frames = new AnimationFrame[255];
        bool fromForm = false;
        public AnimationSetting()
        {
            InitializeComponent();

            for(int i = 0; i < 255; i++)
            {
                frames[i] = new AnimationFrame(0,0,0,30,false);
                listBox1.Items.Add("Frame " + i.ToString());
            }

        }

        private void AnimationSetting_Load(object sender, EventArgs e)
        {

        }

        private void exportzsaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = ".zsa ZS Animation (*.zsa)|*.zsa";
            
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                BinaryWriter bw = new BinaryWriter(new FileStream(sfd.FileName, FileMode.OpenOrCreate, FileAccess.Write));
                for(int i = 0; i < 255; i++) 
                {
                    bw.Write(scene.ow.AllAnimationOverlays[scene.selectedMapParent].FramesList[i].Count); //int nbr of tiles in that frame
                    foreach (TilePos tpos in scene.ow.AllAnimationOverlays[scene.selectedMapParent].FramesList[i])
                    {
                        bw.Write(tpos.tileId); // ushort tileid;
                        bw.Write(tpos.x); // byte x;
                        bw.Write(tpos.y); // byte y;
                    }
                    bw.Write(frames[i].sfx1); // byte
                    bw.Write(frames[i].sfx2); // byte
                    bw.Write(frames[i].sfx3); // byte
                    bw.Write(frames[i].wait); // byte
                    bw.Write(frames[i].shake); // bool
                }

                bw.Write(persist); // bool
                bw.Write(nbrFrames); // byte
                bw.Close();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fromForm = true;
            waitHexbox.HexValue = frames[listBox1.SelectedIndex].wait;
            sfx1Combobox.SelectedIndex = frames[listBox1.SelectedIndex].sfx1;
            sfx2Combobox.SelectedIndex = frames[listBox1.SelectedIndex].sfx2;
            sfx3Combobox.SelectedIndex = frames[listBox1.SelectedIndex].sfx3;
            screenshakeCheckbox.Checked = frames[listBox1.SelectedIndex].shake;

            fromForm = false;
        }

        private void importzsaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = ".zsa ZS Animation (*.zsa)|*.zsa";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                BinaryReader br = new BinaryReader(new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read));
                for (int i = 0; i < 255; i++)
                {
                    int tnbr = br.ReadInt32(); //int nbr of tiles in that frame
                    scene.ow.AllAnimationOverlays[scene.selectedMapParent].FramesList[i].Clear();
                    for(int t = 0; t < tnbr; t++)
                    {
                        ushort tid = br.ReadUInt16();
                        byte tx = br.ReadByte();
                        byte ty = br.ReadByte();
                        scene.ow.AllAnimationOverlays[scene.selectedMapParent].FramesList[i].Add(new TilePos(tx, ty, tid));
                    }
                    frames[i].sfx1 = br.ReadByte();
                    frames[i].sfx2 = br.ReadByte();
                    frames[i].sfx3 = br.ReadByte();
                    frames[i].wait = br.ReadByte();
                    frames[i].shake = br.ReadBoolean();
                }
                fromForm = true;
                persistCheckbox.Checked = persist = br.ReadBoolean();
                numberframeHexbox.HexValue = nbrFrames = br.ReadByte();
                fromForm = false;
                listBox1.SelectedIndex = 0;
                br.Close();
            }
        }

        private void generateASMInClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(";===============================================");
            sb.AppendLine("; Entrance Animation");
            sb.AppendLine(";===============================================");
            sb.AppendLine("; don't forget to set $C8 to zero (STZ.b $C8)");
            sb.AppendLine("; don't forget to set $B0 to zero (STZ.b $B0)");
            sb.AppendLine("");
            sb.AppendLine("; Rename this into something unique");
            sb.AppendLine("EntranceAnimation:");
            sb.AppendLine("LDA.b $B0 ; Get animation state");
            sb.AppendLine("ASL A");
            sb.AppendLine("TAX ; x2");
            sb.AppendLine("");
            sb.AppendLine("JMP.w (.AnimationFrames, X)");
            sb.AppendLine("");
            sb.AppendLine(".AnimationFrames");
            for (int i = 0; i <= nbrFrames; i++)
            {
                sb.AppendLine("dw " + "Frame" + i.ToString());
            }
            sb.AppendLine("");
            sb.AppendLine(";===================================================");
            sb.AppendLine("; Shake screen");
            sb.AppendLine(";===================================================");
            sb.AppendLine("; if you already have that function delete this one");
            sb.AppendLine("ShakeScreen:");
            sb.AppendLine("REP #$20");
            sb.AppendLine("LDA.b $1A");
            sb.AppendLine("AND.w #$0001");
            sb.AppendLine("ASL A");
            sb.AppendLine("TAX");
            sb.AppendLine("");
            sb.AppendLine("LDA.l $01C961, X");
            sb.AppendLine("STA.w $011A");
            sb.AppendLine("");
            sb.AppendLine("LDA.l $01C965, X");
            sb.AppendLine("STA.w $011C");
            sb.AppendLine("");
            sb.AppendLine(".exit");
            sb.AppendLine("SEP #$20");
            sb.AppendLine("RTS");
            sb.AppendLine("");
            for (int i = 0; i <= nbrFrames; i++)
            {
                sb.AppendLine("Frame" + i.ToString() + ":");
                // here's where the fun begin
                sb.AppendLine("LDA.b $C8 : BEQ .doInit ; Load the timer");
                sb.AppendLine("JMP .notfirstframe");
                sb.AppendLine(".doInit");
                sb.AppendLine("; Init code for the frame here");
                sb.AppendLine("REP #$30 ; 16 bit mode");

                for (int t = 0; t < scene.ow.AllAnimationOverlays[scene.selectedMapParent].FramesList[i].Count; t++)
                {
                    ushort addr = (ushort)((scene.ow.AllAnimationOverlays[scene.selectedMapParent].FramesList[i][t].x * 2) + (scene.ow.AllAnimationOverlays[scene.selectedMapParent].FramesList[i][t].y * 128));

                    sb.AppendLine("LDA.w #$" + scene.ow.AllAnimationOverlays[scene.selectedMapParent].FramesList[i][t].tileId.ToString("X4"));
                    sb.AppendLine("LDX.w #$" + (addr).ToString("X4"));
                    sb.AppendLine("JSL $1BC97C ; Overworld_DrawMap16_Persist");
                }

                sb.AppendLine("SEP #$30 ; 8 bit mode");
                sb.AppendLine("INC.b $14 ; Do tiles transfer");
                if (frames[i].sfx1 != 0) 
                {
                    sb.AppendLine("LDA.b #$" + frames[i].sfx1.ToString("X2") + " : " + " STA.w $012D");
                }
                if (frames[i].sfx2 != 0)
                {
                    sb.AppendLine("LDA.b #$" + frames[i].sfx2.ToString("X2") + " : " + " STA.w $012E");
                }
                if (frames[i].sfx3 != 0)
                {
                    sb.AppendLine("LDA.b #$" + frames[i].sfx3.ToString("X2") + " : " + " STA.w $012F");
                }
                sb.AppendLine(".notfirstframe");

                if (frames[i].shake)
                {
                    sb.AppendLine("JSR ShakeScreen ; make the screen shake");
                }

                if (frames[i].wait != 0)
                {
                    sb.AppendLine("INC.b $C8 : LDA.b $C8 : CMP.b #$" + frames[i].wait.ToString("X2") +" ; Load and compare timer");
                    sb.AppendLine("BNE .wait");
                    sb.AppendLine("INC.b $B0 ; increase frame");
                    sb.AppendLine("STZ.b $C8 ; reset timer for next frame");

                    if (i == nbrFrames)
                    {
                        sb.AppendLine("STZ.w $04C6");
                        sb.AppendLine("STZ.b $B0");
                        sb.AppendLine("STZ.w $0710");

                        sb.AppendLine("STZ.w $02E4");

                        sb.AppendLine("STZ.w $0FC1");

                        sb.AppendLine("STZ.w $011A");
                        sb.AppendLine("STZ.w $011B");
                        sb.AppendLine("STZ.w $011C");
                        sb.AppendLine("STZ.w $011D");
                        if (persist)
                        {
                            sb.AppendLine("; set the overlay");
                            sb.AppendLine("LDX.b $8A");

                            sb.AppendLine("LDA.l $7EF280,X");
                            sb.AppendLine("ORA.b #$20");
                            sb.AppendLine("STA.l $7EF280,X");
                        }
                    }


                    sb.AppendLine(".wait");
                    

                }
                else
                {
                    sb.AppendLine("INC.b $B0 ; increase frame");
                    sb.AppendLine("STZ.b $C8 ; reset timer for next frame");

                    if (i == nbrFrames)
                    {
                        sb.AppendLine("STZ.w $04C6");
                        sb.AppendLine("STZ.b $B0");
                        sb.AppendLine("STZ.w $0710");

                        sb.AppendLine("STZ.w $02E4");

                        sb.AppendLine("STZ.w $0FC1");

                        sb.AppendLine("STZ.w $011A");
                        sb.AppendLine("STZ.w $011B");
                        sb.AppendLine("STZ.w $011C");
                        sb.AppendLine("STZ.w $011D");

                        if (persist)
                        {
                            sb.AppendLine("; set the overlay");
                            sb.AppendLine("LDX.b $8A");

                            sb.AppendLine("LDA.l $7EF280,X");
                            sb.AppendLine("ORA.b #$20");
                            sb.AppendLine("STA.l $7EF280,X");
                        }
                    }
                }






                sb.AppendLine("RTS");
            }

            Clipboard.SetText(sb.ToString());
        }

        private void numberframeHexbox_TextChanged(object sender, EventArgs e)
        {
            if (!fromForm)
            {
                nbrFrames = (byte)numberframeHexbox.HexValue;
            }
        }

        private void persistCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (!fromForm)
            {
                persist = (bool)persistCheckbox.Checked;
            }
        }

        private void waitHexbox_TextChanged(object sender, EventArgs e)
        {
            if (!fromForm)
            {
                frames[listBox1.SelectedIndex].wait = (byte)waitHexbox.HexValue;
            }
        }

        private void sfx1Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!fromForm)
            {
                frames[listBox1.SelectedIndex].sfx1 = (byte)sfx1Combobox.SelectedIndex;
            }
        }

        private void sfx2Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!fromForm)
            {
                frames[listBox1.SelectedIndex].sfx2 = (byte)sfx2Combobox.SelectedIndex;
            }
        }

        private void sfx3Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!fromForm)
            {
                frames[listBox1.SelectedIndex].sfx3 = (byte)sfx3Combobox.SelectedIndex;
            }
        }

        private void screenshakeCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (!fromForm)
            {
                frames[listBox1.SelectedIndex].shake = screenshakeCheckbox.Checked;
            }
        }

        private void setTimerOfAllFramesToValueOfFrame00ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for(int i = 0; i< frames.Length; i++) 
            {
                frames[i].wait = frames[0].wait;
            }
        }
    }
}
