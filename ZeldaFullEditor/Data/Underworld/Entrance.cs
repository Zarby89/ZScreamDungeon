using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
	public class Entrance
	{
		public byte cameraBoundaryQN { get; set; }
		public byte cameraBoundaryFN { get; set; }
		public byte cameraBoundaryQS { get; set; }
		public byte cameraBoundaryFS { get; set; }
		public byte cameraBoundaryQW { get; set; }
		public byte cameraBoundaryFW { get; set; }
		public byte cameraBoundaryQE { get; set; }
		public byte cameraBoundaryFE { get; set; }
		public ushort RoomID { get; set; }
		public ushort CameraX { get; set; }
		public ushort CameraY { get; set; }
		public ushort XPosition { get; set; }
		public ushort YPosition { get; set; }
		public ushort CameraTriggerX { get; set; }
		public ushort CameraTriggerY { get; set; }
		public byte Blockset { get; set; }
		public byte Floor { get; set; }
		public byte Dungeon { get; set; }
		public byte Ladderbg { get; set; }
		public byte Door { get; set; }

		public byte Scrolling { get; set; }

		public byte Scrollquadrant { get; set; }

		public ushort OverworldEntranceLocation { get; set; }

		private byte assent;
		public byte AssociatedEntrance
		{
			get => assent;
			set
			{
				if (!IsSpawnPoint) return;
				assent = value;
			}
		}

		public MusicName Music { get; set; }

		public bool IsSpawnPoint { get; }

		public Entrance(ZScreamer ZS, byte entranceId, bool isSpawnPoint = false)
		{
			IsSpawnPoint = isSpawnPoint;

			if (isSpawnPoint)
			{
				RoomID = ZS.ROM.Read16(ZS.Offsets.startingentrance_room + (entranceId * 2));
				YPosition = ZS.ROM.Read16(ZS.Offsets.startingentrance_yposition + (entranceId * 2));
				XPosition = ZS.ROM.Read16(ZS.Offsets.startingentrance_xposition + (entranceId * 2));
				CameraX = ZS.ROM.Read16(ZS.Offsets.startingentrance_camerax + (entranceId * 2));
				CameraY = ZS.ROM.Read16(ZS.Offsets.startingentrance_cameray + (entranceId * 2));
				CameraTriggerY = ZS.ROM.Read16(ZS.Offsets.startingentrance_cameraytrigger + (entranceId * 2));
				CameraTriggerX = ZS.ROM.Read16(ZS.Offsets.startingentrance_cameraxtrigger + (entranceId * 2));
				Blockset = ZS.ROM[ZS.Offsets.startingentrance_blockset + entranceId];
				Music = DefaultEntities.GetObjectFromVanillaList(DefaultEntities.ListOfUnderworldMusics, ZS.ROM[ZS.Offsets.startingentrance_music + entranceId]);
				Dungeon = ZS.ROM[ZS.Offsets.startingentrance_dungeon + entranceId];
				Floor = ZS.ROM[ZS.Offsets.startingentrance_floor + entranceId];
				Door = ZS.ROM[ZS.Offsets.startingentrance_door + entranceId];
				Ladderbg = ZS.ROM[ZS.Offsets.startingentrance_ladderbg + entranceId];
				Scrolling = ZS.ROM[ZS.Offsets.startingentrance_scrolling + entranceId];
				Scrollquadrant = ZS.ROM[ZS.Offsets.startingentrance_scrollquadrant + entranceId];
				assent = ZS.ROM[ZS.Offsets.startingentrance_entrance + entranceId * 2];
				OverworldEntranceLocation = ZS.ROM.Read16(ZS.Offsets.startingentrance_exit + (entranceId * 2));
				cameraBoundaryQN = ZS.ROM[ZS.Offsets.startingentrance_scrolledge + 0 + (entranceId * 8)];
				cameraBoundaryFN = ZS.ROM[ZS.Offsets.startingentrance_scrolledge + 1 + (entranceId * 8)];
				cameraBoundaryQS = ZS.ROM[ZS.Offsets.startingentrance_scrolledge + 2 + (entranceId * 8)];
				cameraBoundaryFS = ZS.ROM[ZS.Offsets.startingentrance_scrolledge + 3 + (entranceId * 8)];
				cameraBoundaryQW = ZS.ROM[ZS.Offsets.startingentrance_scrolledge + 4 + (entranceId * 8)];
				cameraBoundaryFW = ZS.ROM[ZS.Offsets.startingentrance_scrolledge + 5 + (entranceId * 8)];
				cameraBoundaryQE = ZS.ROM[ZS.Offsets.startingentrance_scrolledge + 6 + (entranceId * 8)];
				cameraBoundaryFE = ZS.ROM[ZS.Offsets.startingentrance_scrolledge + 7 + (entranceId * 8)];
			}
			else
			{
				RoomID = ZS.ROM.Read16(ZS.Offsets.entrance_room + (entranceId * 2));
				YPosition = ZS.ROM.Read16(ZS.Offsets.entrance_yposition + (entranceId * 2));
				XPosition = ZS.ROM.Read16(ZS.Offsets.entrance_xposition + (entranceId * 2));
				CameraX = ZS.ROM.Read16(ZS.Offsets.entrance_camerax + (entranceId * 2));
				CameraY = ZS.ROM.Read16(ZS.Offsets.entrance_cameray + (entranceId * 2));
				CameraTriggerY = ZS.ROM.Read16(ZS.Offsets.entrance_cameraytrigger + (entranceId * 2));
				CameraTriggerX = ZS.ROM.Read16(ZS.Offsets.entrance_cameraxtrigger + (entranceId * 2));
				Blockset = ZS.ROM[ZS.Offsets.entrance_blockset + entranceId];
				Music = DefaultEntities.GetObjectFromVanillaList(DefaultEntities.ListOfUnderworldMusics, ZS.ROM[ZS.Offsets.entrance_music + entranceId]);
				Dungeon = ZS.ROM[ZS.Offsets.entrance_dungeon + entranceId];
				Floor = ZS.ROM[ZS.Offsets.entrance_floor + entranceId];
				Door = ZS.ROM[ZS.Offsets.entrance_door + entranceId];
				Ladderbg = ZS.ROM[ZS.Offsets.entrance_ladderbg + entranceId];
				Scrolling = ZS.ROM[ZS.Offsets.entrance_scrolling + entranceId];
				Scrollquadrant = ZS.ROM[ZS.Offsets.entrance_scrollquadrant + entranceId];
				OverworldEntranceLocation = ZS.ROM.Read16(ZS.Offsets.entrance_exit + (entranceId * 2));
				assent = entranceId;

				cameraBoundaryQN = ZS.ROM[ZS.Offsets.entrance_scrolledge + 0 + (entranceId * 8)];
				cameraBoundaryFN = ZS.ROM[ZS.Offsets.entrance_scrolledge + 1 + (entranceId * 8)];
				cameraBoundaryQS = ZS.ROM[ZS.Offsets.entrance_scrolledge + 2 + (entranceId * 8)];
				cameraBoundaryFS = ZS.ROM[ZS.Offsets.entrance_scrolledge + 3 + (entranceId * 8)];
				cameraBoundaryQW = ZS.ROM[ZS.Offsets.entrance_scrolledge + 4 + (entranceId * 8)];
				cameraBoundaryFW = ZS.ROM[ZS.Offsets.entrance_scrolledge + 5 + (entranceId * 8)];
				cameraBoundaryQE = ZS.ROM[ZS.Offsets.entrance_scrolledge + 6 + (entranceId * 8)];
				cameraBoundaryFE = ZS.ROM[ZS.Offsets.entrance_scrolledge + 7 + (entranceId * 8)];
			}
		}

		public void AutoCalculateScrollBoundaries()
		{
			cameraBoundaryQN = (byte) (CameraY >> 8);
			cameraBoundaryFN = (byte) ((CameraY >> 8) & 0xFE);
			cameraBoundaryQS = (byte) (CameraY >> 8);
			cameraBoundaryFS = (byte) ((CameraY >> 8) | 0x01);
			cameraBoundaryQW = (byte) (CameraX >> 8);
			cameraBoundaryFW = (byte) ((CameraX >> 8) & 0xFE);
			cameraBoundaryQE = (byte) (CameraX >> 8);
			cameraBoundaryFE = (byte) ((CameraX >> 8) | 0x01);
		}

		public void save(ZScreamer ZS, int entranceId)
		{
			// TODO: Change these save
			if (IsSpawnPoint)
			{

				ZS.ROM.Write16(ZS.Offsets.startingentrance_room + (entranceId * 2), RoomID);
				ZS.ROM.Write16(ZS.Offsets.startingentrance_yposition + (entranceId * 2), YPosition);
				ZS.ROM.Write16(ZS.Offsets.startingentrance_xposition + (entranceId * 2), XPosition);
				ZS.ROM.Write16(ZS.Offsets.startingentrance_cameray + (entranceId * 2), CameraY);
				ZS.ROM.Write16(ZS.Offsets.startingentrance_camerax + (entranceId * 2), CameraX);
				ZS.ROM.Write16(ZS.Offsets.startingentrance_cameraxtrigger + (entranceId * 2), CameraTriggerY);
				ZS.ROM.Write16(ZS.Offsets.startingentrance_cameraytrigger + (entranceId * 2), CameraTriggerX);
				ZS.ROM.Write16(ZS.Offsets.startingentrance_exit + (entranceId * 2), OverworldEntranceLocation);

				ZS.ROM.Write16(ZS.Offsets.startingentrance_entrance + (entranceId * 2), AssociatedEntrance);

				ZS.ROM[ZS.Offsets.startingentrance_blockset + entranceId] = Blockset;
				ZS.ROM[ZS.Offsets.startingentrance_music + entranceId] = (byte) Music.ID;
				ZS.ROM[ZS.Offsets.startingentrance_dungeon + entranceId] = Dungeon;
				ZS.ROM[ZS.Offsets.startingentrance_door + entranceId] = Door;
				ZS.ROM[ZS.Offsets.startingentrance_floor + entranceId] = Floor;
				ZS.ROM[ZS.Offsets.startingentrance_ladderbg + entranceId] = Ladderbg;
				ZS.ROM[ZS.Offsets.startingentrance_scrolling + entranceId] = Scrolling;
				ZS.ROM[ZS.Offsets.startingentrance_scrollquadrant + entranceId] = Scrollquadrant;

				ZS.ROM.Write(ZS.Offsets.startingentrance_scrolledge + (entranceId * 8),
					cameraBoundaryQN, cameraBoundaryFN, cameraBoundaryQS, cameraBoundaryFS,
					cameraBoundaryQW, cameraBoundaryFW, cameraBoundaryQE, cameraBoundaryFE);
			}
			else
			{
				ZS.ROM.Write16(ZS.Offsets.entrance_room + (entranceId * 2), RoomID);
				ZS.ROM.Write16(ZS.Offsets.entrance_yposition + (entranceId * 2), YPosition);
				ZS.ROM.Write16(ZS.Offsets.entrance_xposition + (entranceId * 2), XPosition);
				ZS.ROM.Write16(ZS.Offsets.entrance_cameray + (entranceId * 2), CameraY);
				ZS.ROM.Write16(ZS.Offsets.entrance_camerax + (entranceId * 2), CameraX);
				ZS.ROM.Write16(ZS.Offsets.entrance_cameraxtrigger + (entranceId * 2), CameraTriggerY);
				ZS.ROM.Write16(ZS.Offsets.entrance_cameraytrigger + (entranceId * 2), CameraTriggerX);
				ZS.ROM.Write16(ZS.Offsets.entrance_exit + (entranceId * 2), OverworldEntranceLocation);

				ZS.ROM[ZS.Offsets.entrance_blockset + entranceId] = Blockset;
				ZS.ROM[ZS.Offsets.entrance_music + entranceId] = (byte) Music.ID;
				ZS.ROM[ZS.Offsets.entrance_dungeon + entranceId] = Dungeon;
				ZS.ROM[ZS.Offsets.entrance_door + entranceId] = Door;
				ZS.ROM[ZS.Offsets.entrance_floor + entranceId] = Floor;
				ZS.ROM[ZS.Offsets.entrance_ladderbg + entranceId] = Ladderbg;
				ZS.ROM[ZS.Offsets.entrance_scrolling + entranceId] = Scrolling;
				ZS.ROM[ZS.Offsets.entrance_scrollquadrant + entranceId] = Scrollquadrant;

				ZS.ROM.Write(ZS.Offsets.entrance_scrolledge + (entranceId * 8),
					cameraBoundaryQN, cameraBoundaryFN, cameraBoundaryQS, cameraBoundaryFS,
					cameraBoundaryQW, cameraBoundaryFW, cameraBoundaryQE, cameraBoundaryFE);
			}
		}
	}
}
