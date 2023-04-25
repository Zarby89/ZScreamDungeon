using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mono.CSharp;
using ZeldaFullEditor.Data;

namespace ZeldaFullEditor.Gui.MainTabs
{
	public partial class MusicEditor : UserControl
	{
		public MusicEditor()
		{
			InitializeComponent();
		}
		List<SongAddress> addresses = new List<SongAddress>();
		byte[] ARAM;
		Color[] ARAMInfos;
		private void MusicEditor_Load(object sender, EventArgs e)
		{
			addresses.Add(new SongAddress(1, 0xD036, "Title", 0xD1F2F, 77));
			addresses.Add(new SongAddress(1, 0xD0FF, "Light World", 0xD1FF8, 826));
			addresses.Add(new SongAddress(1, 0xD86A, "Beginning", 0xD2763, 234));
			addresses.Add(new SongAddress(1, 0xDCA7, "Rabbit", 0xD2BA0, 253));
			addresses.Add(new SongAddress(1, 0xDEE5, "Forest", 0xD2DDE, 521));
			addresses.Add(new SongAddress(1, 0xE36A, "Intro", 0xD3263, 633));
			addresses.Add(new SongAddress(1, 0xE8DC, "Town", 0xD37D5, 1333));
			addresses.Add(new SongAddress(1, 0xEE11, "Warp", 0xD3D0A, 197));
			addresses.Add(new SongAddress(1, 0xEF6D, "Dark world", 0xD3E66, 741));
			addresses.Add(new SongAddress(1, 0xF813, "Master sword", 0xD470C, 91));
			addresses.Add(new SongAddress(1, 0x2880, "File select", 0xD1CE7, 244));
			addresses.Add(new SongAddress(1, 0xF8F6, "Soldier", 0xD47EF, 255));
			addresses.Add(new SongAddress(1, 0x2B00, "Mountain", 0xD4CAB, 364));
			addresses.Add(new SongAddress(1, 0x2FA6, "Shop", 0xD5151, 15));
			addresses.Add(new SongAddress(1, 0xFAFA, "Fanfare", 0xD49F3, 760));
			addresses.Add(new SongAddress(2, 0xD046, "Castle", 0xD804A, 2920));
			addresses.Add(new SongAddress(2, 0xDBEC, "Palace (Pendant)", 0xD8BF0, 1272));
			addresses.Add(new SongAddress(2, 0xE13A, "Cave (Same as Secret Way)", 0xD913E, 719));
			addresses.Add(new SongAddress(2, 0xE431, "Clear (Dungeon end)", 0xD9435, 788));
			addresses.Add(new SongAddress(2, 0xE6F9, "Church", 0xD96FD, 529));
			addresses.Add(new SongAddress(2, 0xE91E, "Boss", 0xD9922, 787));
			addresses.Add(new SongAddress(2, 0xEC0B, "Dungeon (Crystal)", 0xD9C0F, 1406));
			addresses.Add(new SongAddress(2, 0xF1D1, "Psychic", 0xDA1D5, 343));
			addresses.Add(new SongAddress(2, 0xE13A, "Secret Way (Same as Cave)", 0xD913E, 719));
			addresses.Add(new SongAddress(2, 0xF304, "Rescue", 0xDA308, 618));
			addresses.Add(new SongAddress(2, 0xF580, "Crystal", 0xDA584, 905));
			addresses.Add(new SongAddress(2, 0xF909, "Fountain", 0xDA90D, 611));
			addresses.Add(new SongAddress(2, 0xFB6A, "Pyramid", 0xDAB6E, 1111));
			addresses.Add(new SongAddress(2, 0x2B00, "Kill Agahnim", 0xDACC7, 255));
			addresses.Add(new SongAddress(2, 0x2F59, "Ganon Room", 0xDB120, 149));
			addresses.Add(new SongAddress(2, 0x2BB3, "Last Boss", 0xDAD7A, 868));



			songListbox.BeginUpdate();
			for (int i = 0; i < addresses.Count;i++)
			{
				songListbox.Items.Add(addresses[i].ToString());
			}
			songListbox.EndUpdate();
			songListbox.SelectedIndex = 0;
			

		}
		int pos = 0xD036;
		int posROM = 0xD1F2F;
		int count = 77;
		int nbrLine = 20;
		private void hexPicturebox_Paint(object sender, PaintEventArgs e)
		{
			if (songListbox.SelectedIndex != -1)
			{
				int pCount = 0;
				e.Graphics.Clear(Color.White);
				e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(0, 0, 32, hexPicturebox.Height));
				e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(0, 0, 336, 16));

				for (int i = 0; i < nbrLine; i++)
				{
					e.Graphics.DrawString((pos + (i * 0x10)).ToString("X4"), this.Font, Brushes.DarkGray, 0, 24 + (i * 18));
				}
				for (int i = 0; i < 16; i++)
				{
					e.Graphics.DrawString((i).ToString("X2"), this.Font, Brushes.DarkGray, 40 + (i * 18), 0);
				}

				for (int l = 0; l < nbrLine; l++)
				{
					for (int i = 0; i < 16; i++)
					{
						if ((i + (l * 16)) < ARAM.Length)
						{
							e.Graphics.FillRectangle(new SolidBrush(ARAMInfos[i + (l * 16)]), new Rectangle(40 + (i * 18), 24 + (l * 18), 20, 16));
							e.Graphics.DrawString(ARAM[i + (l * 16)].ToString("X2"), this.Font, Brushes.Black, 40 + (i * 18), 24 + (l * 18));
						}
					}
				}
			}
		}

		private void songListbox_SelectedIndexChanged(object sender, EventArgs e)
		{
			pos = addresses[songListbox.SelectedIndex].NSPCAddress;
			posROM = addresses[songListbox.SelectedIndex].PCOffset;
			count = addresses[songListbox.SelectedIndex].Length;
			nbrLine = (count / 16) + 1;

			if (nbrLine >  27) 
			{ 
				int expand = nbrLine - 27;
				hexPicturebox.Height = 512 + (expand * 18);


			}
			else
			{
				hexPicturebox.Height = 512;
			}

			ARAM = new byte[count];
			ARAMInfos = new Color[count];
			for (int i = 0;i < count;i++)
			{
				ARAM[i] = ROM.DATA[posROM + i];
				ARAMInfos[i] = Color.White;
			}
			parseSong(ARAM, ref ARAMInfos);


			hexPicturebox.Refresh();
		}


		private void parseSong(byte[] ARAM, ref Color[] infos)
		{
			bool aramheader = true;
			int pos = 0;
			while(aramheader)
			{
				if (pos >= ARAM.Length)
				{
					aramheader = false;
					break;
				}
				infos[pos] = Color.LightPink;
				if (ARAM[pos] == 0 && ARAM[pos+1] == 0)
				{
					infos[pos+1] = Color.LightPink;
					aramheader = false;
				}
				pos++;
			}

		}
	}
}
