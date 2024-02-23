using System;
using System.Drawing;
using System.Windows.Forms;

namespace ZeldaFullEditor
{
	partial class AboutBox1 : Form
	{
		// TODO KAN REFACTOR - remove all the hardcoded label text and use an array of strings in this file
		// "

		private static readonly Font HeaderFont = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
		private static readonly Font CreditFont = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);

		public AboutBox1()
		{
			InitializeComponent();
			Text = $"About {UIText.APPNAME}";

			CreditsPanel.Controls.Clear();

			foreach (var s in Credits)
			{
				var text = s;
				bool header = false;

				if (s[0] is '#')
				{
					text = s.Substring(1);
					header = true;
				}

				var add = new Label()
				{
					Text = text,
					BackColor = Color.Transparent,
					ForeColor = Color.Black,
					Width = 500,
					Height = 17,
					Padding = new Padding(0, 0, 0, 0),
					Margin = new Padding(0, 0, 0, 0),
					MinimumSize = new Size(500, 17),
					Font = header ? HeaderFont : CreditFont,
					Dock = DockStyle.Top
				};

				CreditsPanel.Controls.Add(add);
			}

			CreditsPanel.PerformLayout();
			CreditsPanel.Invalidate();

			AboutVersion.Text = string.Format("Version: {0}", UIText.VERSION);
		}

		private static readonly string[] Credits =
		{
			// use # for headers
			"#Main author",
			"Zarby89",

			"#Other contributors",
			"kan - Code and logo",
			"Jared_Brian_ - Code",
			"Sosuke3 - Code and decompression library",
			"Scawful - Code",

			"#Beta testers",
			"Letterbomb",
			"Jeimuzu",

			"#Special thanks",
			"MathOnNapkins - Documentation and disassembly",
			"Sephiroth3 - Hyrule Magic (used as reference)",
			"SePH - Documentation",
			"The general ALttP hacking community and Zeldix"
		};


		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start(UIText.GITHUB);
		}

		private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start(UIText.DISCORD);
		}

		private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start(UIText.ASAR);
		}

		private void AboutBox1_Load(object sender, EventArgs e)
		{

		}
	}
}
