using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeldaFullEditor.Gui;

namespace ZeldaFullEditor.OWSceneModes
{
    public class NoteMode
    {
        SceneOW scene;
        OWNote selectedNote = null;
        bool clickedOn = false;
        int mx = 0;
        int my = 0;
        public NoteMode(SceneOW scene)
        {
            this.scene = scene;
        }

        public void onMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                selectedNote = null;
                foreach (OWNote note in scene.owNotesList)
                {
                    if (e.X >= note.x && e.Y >= note.y && e.X <= note.x + note.size.Width && e.Y <= note.y + note.size.Height)
                    {
                        selectedNote = note;
                        clickedOn = true;
                        break;
                    }
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new ContextMenuStrip();
                menu.Items.Add("Add Note");
                menu.Items.Add("Delete Note");

                menu.Items[0].Click += NoteModeAdd_Click;
                menu.Items[1].Click += NoteModeDelete_Click;
                menu.Show(Cursor.Position);
            }

        }

        private void NoteModeDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void NoteModeAdd_Click(object sender, EventArgs e)
        {
            NoteAdd formAddNote = new NoteAdd();
            if (formAddNote.ShowDialog() == DialogResult.OK)
            {
                scene.owNotesList.Add(new OWNote(mx, my, formAddNote.textBox1.Text, formAddNote.fontDialog1.Font, formAddNote.color));
            }
        }

        public void onMouseUp(MouseEventArgs e)
        {
            clickedOn = false;
            scene.Refresh();
        }

        public void onMouseMove(MouseEventArgs e)
        {
            mx = e.X;
            my = e.Y;
            if (clickedOn)
            {
                if (selectedNote != null)
                {
                    selectedNote.x = e.X; 
                    selectedNote.y = e.Y;
                }
            }
            scene.Refresh();
        }

        public void Delete()
        {
            if (selectedNote != null)
            {
                scene.owNotesList.Remove(selectedNote);
            }
        }

        public void Draw(Graphics g)
        {
            foreach (OWNote note in scene.owNotesList)
            {

                g.DrawString(note.text, note.font, new SolidBrush(note.color), note.x, note.y);
                if (note == selectedNote)
                {
                    g.DrawRectangle(Pens.Lime, new Rectangle(note.x, note.y, (int)note.size.Width, (int)note.size.Height));
                }

            }

        }


        }
}
