﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZeldaFullEditor.Gui.ExtraForms
{
	public partial class RoomDataViewer : Form
	{
		private byte[] objectData = null;
		private byte[] layer1Data = null;
		private byte[] layer2Data = null;
		private byte[] layer3Data = null;
		private byte[] doorsData = null;
		private byte[] spritesData = null;

		private ViewType viewingAs = ViewType.Raw;

		public RoomDataViewer(Room room)
		{
			InitializeComponent();

			Text = $"Room data for room {room.RoomID:X4}";

			objectData = room.getTilesBytes();

			// split room data
			var sb = new List<byte>[3];
			var curList = new List<byte>();

			int layer = 0;
			int i = 2;

			while (layer < 3)
			{
				byte b1 = objectData[i++];
				byte b2 = objectData[i++];

				if (b2 is 0xFF && (b1 is 0xFF || b1 is 0xF0))
				{
					sb[layer++] = curList;
					curList = new List<byte>();
					continue;
				}

				curList.Add(b1);
				curList.Add(b2);
				curList.Add(objectData[i++]);
			}

			DoorOffsetBox.Text = $"${i:X4}";

			while (true)
			{
				byte b1 = objectData[i++];
				byte b2 = objectData[i++];

				if ((b2 & b1) == 0xFF)
				{
					break;
				}

				curList.Add(b1);
				curList.Add(b2);
			}

			layer1Data = sb[0].ToArray();
			layer2Data = sb[1].ToArray();
			layer3Data = sb[2].ToArray();
			doorsData = curList.ToArray();
			spritesData = room.GetSpritesData();

			ViewModeBox.DataSource = new ViewType[]
				{
					ViewType.Raw,
					ViewType.Spaced,
					ViewType.asm,
				};

			ViewModeBox.SelectedItem = ViewType.asm;
		}

		private void RefreshDataBoxes()
		{
			// Room objects
			if (viewingAs is ViewType.Raw)
			{
				RoomObjectsBox.Text = GetRawData(objectData);
				SpritesDataBox.Text = GetRawData(spritesData);


				return;
			}
			else if (viewingAs is ViewType.Spaced)
			{

				RoomObjectsBox.Text = GetSpacedData(objectData);
				SpritesDataBox.Text = GetSpacedData(spritesData);

				return;
			}
			else if (viewingAs is ViewType.asm)
			{
				var sb = new List<string>();

				for (int i = 0; i < layer1Data.Length; i += 3)
				{
					sb.Add($"db ${layer1Data[i]:X2}, ${layer1Data[i + 1]:X2}, ${layer1Data[i + 2]:X2}");
				}

				sb.Add("db $FF, $FF");

				for (int i = 0; i < layer2Data.Length; i += 3)
				{
					sb.Add($"db ${layer2Data[i]:X2}, ${layer2Data[i + 1]:X2}, ${layer2Data[i + 2]:X2}");
				}

				sb.Add("db $FF, $FF");

				for (int i = 0; i < layer3Data.Length; i += 3)
				{
					sb.Add($"db ${layer3Data[i]:X2}, ${layer3Data[i + 1]:X2}, ${layer3Data[i + 2]:X2}");
				}

				sb.Add("db $F0, $FF");

				for (int i = 0; i < doorsData.Length; i += 2)
				{
					sb.Add($"db ${doorsData[i]:X2}, ${doorsData[i + 1]:X2}");
				}

				sb.Add("db $FF, $FF");

				RoomObjectsBox.Text = string.Join("\r\n", sb);

				sb = new List<string>();

				sb.Add($"db {spritesData[0]}");
				for (int i = 1; i < (spritesData.Length - 1); i += 3)
				{
					sb.Add($"db ${spritesData[i]:X2}, ${spritesData[i + 1]:X2}, ${spritesData[i + 2]:X2}");
				}
				sb.Add("db $FF");
				SpritesDataBox.Text = string.Join("\r\n", sb);
			}
		}

		private string GetRawData(byte[] dat)
		{
			return string.Concat(dat.Select(b => $"{b:X2}"));
		}

		private string GetSpacedData(byte[] dat)
		{
			return string.Join(" ", dat.Select(b => $"{b:X2}"));
		}

		private enum ViewType
		{
			Raw,
			Spaced,
			asm,
		}

		private void ViewModeBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			viewingAs = (ViewType) ViewModeBox.SelectedItem;

			RefreshDataBoxes();
		}
	}
}
