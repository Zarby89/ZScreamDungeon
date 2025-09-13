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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = ".zsa ZS Animation (*.zsa)|*.zsa";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                BinaryReader binaryReader = new BinaryReader(new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read));
                for (int i = 0; i < scene.ow.AllAnimationOverlays[scene.selectedMapParent].FramesList.Length; i++)
                {
                    int tnbr = binaryReader.ReadInt32(); // int nbr of tiles in that frame.
                    scene.ow.AllAnimationOverlays[scene.selectedMapParent].FramesList[i].Clear();
                    for(int t = 0; t < tnbr; t++)
                    {
                        ushort tid = binaryReader.ReadUInt16();
                        byte tx = binaryReader.ReadByte();
                        byte ty = binaryReader.ReadByte();
                        scene.ow.AllAnimationOverlays[scene.selectedMapParent].FramesList[i].Add(new TilePos(tx, ty, tid));
                    }

                    frames[i].sfx1 = binaryReader.ReadByte();
                    frames[i].sfx2 = binaryReader.ReadByte();
                    frames[i].sfx3 = binaryReader.ReadByte();
                    frames[i].wait = binaryReader.ReadByte();
                    frames[i].shake = binaryReader.ReadBoolean();
                }

                fromForm = true;
                persistCheckbox.Checked = persist = binaryReader.ReadBoolean();
                numberframeHexbox.HexValue = nbrFrames = binaryReader.ReadByte();
                fromForm = false;
                listBox1.SelectedIndex = 0;

                binaryReader.Close();
            }
        }

        private void generateASMInClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(";===============================================");
            stringBuilder.AppendLine("; Entrance Animation");
            stringBuilder.AppendLine(";===============================================");
            stringBuilder.AppendLine("; don't forget to set $C8 to zero (STZ.b $C8)");
            stringBuilder.AppendLine("; don't forget to set $B0 to zero (STZ.b $B0)");
            stringBuilder.AppendLine("");
            stringBuilder.AppendLine("; Rename this into something unique");
            stringBuilder.AppendLine("EntranceAnimation:");
            stringBuilder.AppendLine("LDA.b $B0 ; Get animation state");
            stringBuilder.AppendLine("ASL A");
            stringBuilder.AppendLine("TAX ; x2");
            stringBuilder.AppendLine("");
            stringBuilder.AppendLine("JMP.w (.AnimationFrames, X)");
            stringBuilder.AppendLine("");
            stringBuilder.AppendLine(".AnimationFrames");
            for (int i = 0; i <= nbrFrames; i++)
            {
                stringBuilder.AppendLine("dw " + "Frame" + i.ToString());
            }
            stringBuilder.AppendLine("");
            stringBuilder.AppendLine(";===================================================");
            stringBuilder.AppendLine("; Shake screen");
            stringBuilder.AppendLine(";===================================================");
            stringBuilder.AppendLine("; if you already have that function delete this one");
            stringBuilder.AppendLine("ShakeScreen:");
            stringBuilder.AppendLine("REP #$20");
            stringBuilder.AppendLine("LDA.b $1A");
            stringBuilder.AppendLine("AND.w #$0001");
            stringBuilder.AppendLine("ASL A");
            stringBuilder.AppendLine("TAX");
            stringBuilder.AppendLine("");
            stringBuilder.AppendLine("LDA.l $01C961, X");
            stringBuilder.AppendLine("STA.w $011A");
            stringBuilder.AppendLine("");
            stringBuilder.AppendLine("LDA.l $01C965, X");
            stringBuilder.AppendLine("STA.w $011C");
            stringBuilder.AppendLine("");
            stringBuilder.AppendLine(".exit");
            stringBuilder.AppendLine("SEP #$20");
            stringBuilder.AppendLine("RTS");
            stringBuilder.AppendLine("");
            for (int i = 0; i <= nbrFrames; i++)
            {
                stringBuilder.AppendLine("Frame" + i.ToString() + ":");
                // here's where the fun begin
                stringBuilder.AppendLine("LDA.b $C8 : BEQ .doInit ; Load the timer");
                stringBuilder.AppendLine("JMP .notfirstframe");
                stringBuilder.AppendLine(".doInit");
                stringBuilder.AppendLine("; Init code for the frame here");
                stringBuilder.AppendLine("REP #$30 ; 16 bit mode");

                for (int t = 0; t < scene.ow.AllAnimationOverlays[scene.selectedMapParent].FramesList[i].Count; t++)
                {
                    ushort addr = (ushort)((scene.ow.AllAnimationOverlays[scene.selectedMapParent].FramesList[i][t].x * 2) + (scene.ow.AllAnimationOverlays[scene.selectedMapParent].FramesList[i][t].y * 128));

                    stringBuilder.AppendLine("LDA.w #$" + scene.ow.AllAnimationOverlays[scene.selectedMapParent].FramesList[i][t].tileId.ToString("X4"));
                    stringBuilder.AppendLine("LDX.w #$" + addr.ToString("X4"));
                    stringBuilder.AppendLine("JSL $1BC97C ; Overworld_DrawMap16_Persist");
                }

                stringBuilder.AppendLine("SEP #$30 ; 8 bit mode");
                stringBuilder.AppendLine("INC.b $14 ; Do tiles transfer");
                if (frames[i].sfx1 != 0) 
                {
                    stringBuilder.AppendLine("LDA.b #$" + frames[i].sfx1.ToString("X2") + " : " + " STA.w $012D");
                }

                if (frames[i].sfx2 != 0)
                {
                    stringBuilder.AppendLine("LDA.b #$" + frames[i].sfx2.ToString("X2") + " : " + " STA.w $012E");
                }

                if (frames[i].sfx3 != 0)
                {
                    stringBuilder.AppendLine("LDA.b #$" + frames[i].sfx3.ToString("X2") + " : " + " STA.w $012F");
                }

                stringBuilder.AppendLine(".notfirstframe");

                if (frames[i].shake)
                {
                    stringBuilder.AppendLine("JSR ShakeScreen ; make the screen shake");
                }

                if (frames[i].wait != 0)
                {
                    stringBuilder.AppendLine("INC.b $C8 : LDA.b $C8 : CMP.b #$" + frames[i].wait.ToString("X2") +" ; Load and compare timer");
                    stringBuilder.AppendLine("BNE .wait");
                    stringBuilder.AppendLine("INC.b $B0 ; increase frame");
                    stringBuilder.AppendLine("STZ.b $C8 ; reset timer for next frame");

                    if (i == nbrFrames)
                    {
                        stringBuilder.AppendLine("STZ.w $04C6");
                        stringBuilder.AppendLine("STZ.b $B0");
                        stringBuilder.AppendLine("STZ.w $0710");

                        stringBuilder.AppendLine("STZ.w $02E4");

                        stringBuilder.AppendLine("STZ.w $0FC1");

                        stringBuilder.AppendLine("STZ.w $011A");
                        stringBuilder.AppendLine("STZ.w $011B");
                        stringBuilder.AppendLine("STZ.w $011C");
                        stringBuilder.AppendLine("STZ.w $011D");
                        if (persist)
                        {
                            stringBuilder.AppendLine("; set the overlay");
                            stringBuilder.AppendLine("LDX.b $8A");

                            stringBuilder.AppendLine("LDA.l $7EF280,X");
                            stringBuilder.AppendLine("ORA.b #$20");
                            stringBuilder.AppendLine("STA.l $7EF280,X");
                        }
                    }

                    stringBuilder.AppendLine(".wait");
                }
                else
                {
                    stringBuilder.AppendLine("INC.b $B0 ; increase frame");
                    stringBuilder.AppendLine("STZ.b $C8 ; reset timer for next frame");

                    if (i == nbrFrames)
                    {
                        stringBuilder.AppendLine("STZ.w $04C6");
                        stringBuilder.AppendLine("STZ.b $B0");
                        stringBuilder.AppendLine("STZ.w $0710");

                        stringBuilder.AppendLine("STZ.w $02E4");

                        stringBuilder.AppendLine("STZ.w $0FC1");

                        stringBuilder.AppendLine("STZ.w $011A");
                        stringBuilder.AppendLine("STZ.w $011B");
                        stringBuilder.AppendLine("STZ.w $011C");
                        stringBuilder.AppendLine("STZ.w $011D");

                        if (persist)
                        {
                            stringBuilder.AppendLine("; set the overlay");
                            stringBuilder.AppendLine("LDX.b $8A");

                            stringBuilder.AppendLine("LDA.l $7EF280,X");
                            stringBuilder.AppendLine("ORA.b #$20");
                            stringBuilder.AppendLine("STA.l $7EF280,X");
                        }
                    }
                }

                stringBuilder.AppendLine("RTS");
            }

            Clipboard.SetText(stringBuilder.ToString());
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
