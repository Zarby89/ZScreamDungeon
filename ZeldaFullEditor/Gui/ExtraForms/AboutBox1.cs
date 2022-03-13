﻿using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ZeldaFullEditor
{
	partial class AboutBox1 : Form
	{
		public AboutBox1()
		{
			InitializeComponent();
			this.AboutVersion.Text = string.Format("Version: {0}", Constants.VERSION);
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start(Constants.GITHUB);
		}

		private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start(Constants.DISCORD);
		}
	}
}
