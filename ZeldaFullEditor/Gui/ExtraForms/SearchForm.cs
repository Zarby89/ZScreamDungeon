﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeldaFullEditor.Gui
{
	public partial class SearchForm : ScreamForm
	{
//
//		public SearchForm(ZScreamer zs) : base(zs)
//		{
//			InitializeComponent();
//		}
//
//		private void button2_Click(object sender, EventArgs e)
//		{
//			richTextBox1.Clear();
//		}
//
//		private void tileRadio_CheckedChanged(object sender, EventArgs e)
//		{
//			comboBox1.Items.Clear();
//			if (tileRadio.Checked)
//			{
//				for (int i = 0; i < ZS.MainForm.listoftilesobjects.Count; i++)
//				{
//					comboBox1.Items.Add(ZS.MainForm.listoftilesobjects[i].id.ToString("X4") + " " + ZS.MainForm.listoftilesobjects[i].name);
//				}
//			}
//			else if (spriteRadio.Checked)
//			{
//				comboBox1.Items.AddRange(Sprites_Names.name);
//			}
//			else if (itemRadio.Checked)
//			{
//				comboBox1.Items.AddRange(ItemsNames.name);
//			}
//			else if (chestRadio.Checked)
//			{
//				comboBox1.Items.AddRange(ChestItems_Name.name);
//			}
//		}
//
//		private void button1_Click(object sender, EventArgs e)
//		{
//			if (tileRadio.Checked)
//			{
//				for (int i = 0; i < Constants.NumberOfRooms; i++)
//				{
//					int l = DungeonsData.all_rooms[i].tilesObjects.Where(o => o.id == comboBox1.SelectedIndex).ToArray().Length;
//					if (l > 0)
//					{
//						richTextBox1.AppendText("Tile Object ID : " + ZS.MainForm.listoftilesobjects[comboBox1.SelectedIndex].id.ToString("X4") + " Found in room id " + i + " Count : " + l.ToString() + "\r\n");
//					}
//				}
//			}
//			else if (spriteRadio.Checked)
//			{
//				for (int i = 0; i < Constants.NumberOfRooms; i++)
//				{
//					int l = DungeonsData.all_rooms[i].SpritesList.Where(o => o.id == comboBox1.SelectedIndex).ToArray().Length;
//					if (l > 0)
//					{
//						richTextBox1.AppendText("Sprite ID : " + Sprites_Names.name[comboBox1.SelectedIndex] + " Found in room id " + i + " Count : " + l.ToString() + "\r\n");
//					}
//				}
//			}
//			else if (itemRadio.Checked)
//			{
//				for (int i = 0; i < Constants.NumberOfRooms; i++)
//				{
//					int l = DungeonsData.all_rooms[i].pot_items.Where(o => o.id == comboBox1.SelectedIndex).ToArray().Length;
//					if (l > 0)
//					{
//						richTextBox1.AppendText("Item ID : " + ItemsNames.name[comboBox1.SelectedIndex] + " Found in room id " + i + " Count : " + l.ToString() + "\r\n");
//					}
//				}
//			}
//			else if (chestRadio.Checked)
//			{
//				for (int i = 0; i < Constants.NumberOfRooms; i++)
//				{
//					int l = DungeonsData.all_rooms[i].chest_list.Where(o => o.item == comboBox1.SelectedIndex).ToArray().Length;
//					if (l > 0)
//					{
//						richTextBox1.AppendText("Chest Items : " + ChestItems_Name.name[comboBox1.SelectedIndex] + " Found in room id " + i + " Count : " + l.ToString() + "\r\n");
//					}
//				}
//			}
//		}
	}
}
