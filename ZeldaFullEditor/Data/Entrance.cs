using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
	public class Entrance // Can be used for starting entrance as well
	{
		ushort room; // word value for each room

		public byte cameraBoundaryQN; // 8 bytes per room Q (quadrant) and F (full) for cardinal directions NSWE
		public byte cameraBoundaryFN;
		public byte cameraBoundaryQS;
		public byte cameraBoundaryFS;
		public byte cameraBoundaryQW;
		public byte cameraBoundaryFW;
		public byte cameraBoundaryQE;
		public byte cameraBoundaryFE;

		ushort ycamera; // 2bytes each room
		ushort xcamera; // 2bytes
		ushort yposition; // 2bytes
		ushort xposition; // 2bytes
		ushort ytrigger; // 2bytes
		ushort xtrigger; // 2bytes
		byte blockset; // 1byte
		byte floor; // 1byte
		byte dungeon; // 1byte (dungeon id) // Same as music might use the project dungeon name instead
		byte door; // 1byte
		byte ladderbg; // 1 byte, ---b ---a b = bg2, a = need to check -_-
		byte scrolling; // 1byte --h- --v- 
		byte scrollquadrant; //1byte
		ushort exit; // 2byte word 
		byte music; // 1byte // Will need to be renamed and changed to add support to MSU1
		public ushort Room { get => room; set => room = value; }
		public ushort CameraX { get => xcamera; set => xcamera = value; }
		public ushort CameraY { get => ycamera; set => ycamera = value; }
		public ushort XPosition { get => xposition; set => xposition = value; }
		public ushort YPosition { get => yposition; set => yposition = value; }
		public ushort CameraTriggerX { get => xtrigger; set => xtrigger = value; }
		public ushort CameraTriggerY { get => ytrigger; set => ytrigger = value; }
		public byte Blockset { get => blockset; set => blockset = value; }
		public byte Floor { get => floor; set => floor = value; }
		public byte Dungeon { get => dungeon; set => dungeon = value; }
		public byte Ladderbg { get => ladderbg; set => ladderbg = value; }

		public byte Scrolling { get => scrolling; set => scrolling = value; }

		public byte Scrollquadrant { get => scrollquadrant; set => scrollquadrant = value; }

		public ushort Exit { get; set; }
		public byte Music { get => music; set => music = value; }

		private readonly ZScreamer ZS;
		public Entrance(ZScreamer parent, byte entranceId, bool isSpawnPoint = false)
		{
			ZS = parent;
			room = ZS.ROM[ZS.Offsets.entrance_room + (entranceId * 2), 2];
			yposition = ZS.ROM[ZS.Offsets.entrance_yposition + (entranceId * 2), 2];
			xposition = ZS.ROM[ZS.Offsets.entrance_xposition + (entranceId * 2), 2];
			xcamera = ZS.ROM[ZS.Offsets.entrance_camerax + (entranceId * 2), 2];
			ycamera = ZS.ROM[ZS.Offsets.entrance_cameray + (entranceId * 2), 2];
			ytrigger = ZS.ROM[ZS.Offsets.entrance_cameraytrigger + (entranceId * 2), 2];
			xtrigger = ZS.ROM[ZS.Offsets.entrance_cameraxtrigger + (entranceId * 2), 2];
			blockset = ZS.ROM[ZS.Offsets.entrance_blockset + entranceId];
			music = ZS.ROM[ZS.Offsets.entrance_music + entranceId];
			dungeon = ZS.ROM[ZS.Offsets.entrance_dungeon + entranceId];
			floor = ZS.ROM[ZS.Offsets.entrance_floor + entranceId];
			door = ZS.ROM[ZS.Offsets.entrance_door + entranceId];
			ladderbg = ZS.ROM[ZS.Offsets.entrance_ladderbg + entranceId];
			scrolling = ZS.ROM[ZS.Offsets.entrance_scrolling + entranceId];
			scrollquadrant = ZS.ROM[ZS.Offsets.entrance_scrollquadrant + entranceId];
			exit = ZS.ROM[ZS.Offsets.entrance_exit + (entranceId * 2), 2];

			cameraBoundaryQN = ZS.ROM[ZS.Offsets.entrance_scrolledge + 0 + (entranceId * 8)];
			cameraBoundaryFN = ZS.ROM[ZS.Offsets.entrance_scrolledge + 1 + (entranceId * 8)];
			cameraBoundaryQS = ZS.ROM[ZS.Offsets.entrance_scrolledge + 2 + (entranceId * 8)];
			cameraBoundaryFS = ZS.ROM[ZS.Offsets.entrance_scrolledge + 3 + (entranceId * 8)];
			cameraBoundaryQW = ZS.ROM[ZS.Offsets.entrance_scrolledge + 4 + (entranceId * 8)];
			cameraBoundaryFW = ZS.ROM[ZS.Offsets.entrance_scrolledge + 5 + (entranceId * 8)];
			cameraBoundaryQE = ZS.ROM[ZS.Offsets.entrance_scrolledge + 6 + (entranceId * 8)];
			cameraBoundaryFE = ZS.ROM[ZS.Offsets.entrance_scrolledge + 7 + (entranceId * 8)];


			if (isSpawnPoint)
			{
				room = ZS.ROM[ZS.Offsets.startingentrance_room + ((entranceId) * 2), 2];
				yposition = ZS.ROM[ZS.Offsets.startingentrance_yposition + (entranceId * 2), 2];
				xposition = ZS.ROM[ZS.Offsets.startingentrance_xposition + (entranceId * 2), 2];
				xcamera = ZS.ROM[ZS.Offsets.startingentrance_camerax + (entranceId * 2), 2];
				ycamera = ZS.ROM[ZS.Offsets.startingentrance_cameray + (entranceId * 2), 2];
				ytrigger = ZS.ROM[ZS.Offsets.startingentrance_cameraytrigger + (entranceId * 2), 2];
				xtrigger = ZS.ROM[ZS.Offsets.startingentrance_cameraxtrigger + (entranceId * 2), 2];
				blockset = ZS.ROM[ZS.Offsets.startingentrance_blockset + entranceId];
				music = ZS.ROM[ZS.Offsets.startingentrance_music + entranceId];
				dungeon = ZS.ROM[ZS.Offsets.startingentrance_dungeon + entranceId];
				floor = ZS.ROM[ZS.Offsets.startingentrance_floor + entranceId];
				door = ZS.ROM[ZS.Offsets.startingentrance_door + entranceId];
				ladderbg = ZS.ROM[ZS.Offsets.startingentrance_ladderbg + entranceId];
				scrolling = ZS.ROM[ZS.Offsets.startingentrance_scrolling + entranceId];
				scrollquadrant = ZS.ROM[ZS.Offsets.startingentrance_scrollquadrant + entranceId];
				exit = ZS.ROM[ZS.Offsets.startingentrance_exit + (entranceId * 2), 2];
				cameraBoundaryQN = ZS.ROM[ZS.Offsets.startingentrance_scrolledge + 0 + (entranceId * 8)];
				cameraBoundaryFN = ZS.ROM[ZS.Offsets.startingentrance_scrolledge + 1 + (entranceId * 8)];
				cameraBoundaryQS = ZS.ROM[ZS.Offsets.startingentrance_scrolledge + 2 + (entranceId * 8)];
				cameraBoundaryFS = ZS.ROM[ZS.Offsets.startingentrance_scrolledge + 3 + (entranceId * 8)];
				cameraBoundaryQW = ZS.ROM[ZS.Offsets.startingentrance_scrolledge + 4 + (entranceId * 8)];
				cameraBoundaryFW = ZS.ROM[ZS.Offsets.startingentrance_scrolledge + 5 + (entranceId * 8)];
				cameraBoundaryQE = ZS.ROM[ZS.Offsets.startingentrance_scrolledge + 6 + (entranceId * 8)];
				cameraBoundaryFE = ZS.ROM[ZS.Offsets.startingentrance_scrolledge + 7 + (entranceId * 8)];
			}
		}

		public void save(int entranceId, bool isSpawnPoint = false, bool jp = false)
		{
			// TODO: Change these save
			if (!isSpawnPoint)
			{
				ZS.ROM[ZS.Offsets.entrance_room + (entranceId * 2), 2] = room;
				ZS.ROM[ZS.Offsets.entrance_yposition + (entranceId * 2), 2] = yposition;
				ZS.ROM[ZS.Offsets.entrance_xposition + (entranceId * 2), 2] = xposition;
				ZS.ROM[ZS.Offsets.entrance_cameray + (entranceId * 2), 2] = ycamera;
				ZS.ROM[ZS.Offsets.entrance_camerax + (entranceId * 2), 2] = xcamera;
				ZS.ROM[ZS.Offsets.entrance_cameraxtrigger + (entranceId * 2), 2] = xtrigger;
				ZS.ROM[ZS.Offsets.entrance_cameraytrigger + (entranceId * 2), 2] = ytrigger;
				ZS.ROM[ZS.Offsets.entrance_exit + (entranceId * 2), 2] = exit;

				ZS.ROM[ZS.Offsets.entrance_blockset + entranceId] = blockset;
				ZS.ROM[ZS.Offsets.entrance_music + entranceId] = music;
				ZS.ROM[ZS.Offsets.entrance_dungeon + entranceId] = dungeon;
				ZS.ROM[ZS.Offsets.entrance_door + entranceId] = door;
				ZS.ROM[ZS.Offsets.entrance_floor + entranceId] = floor;
				ZS.ROM[ZS.Offsets.entrance_ladderbg + entranceId] = ladderbg;
				ZS.ROM[ZS.Offsets.entrance_scrolling + entranceId] = scrolling;
				ZS.ROM[ZS.Offsets.entrance_scrollquadrant + entranceId] = scrollquadrant;
				ZS.ROM[(ZS.Offsets.entrance_scrolledge + 0 + (entranceId * 8))] = cameraBoundaryQN;
				ZS.ROM[(ZS.Offsets.entrance_scrolledge + 1 + (entranceId * 8))] = cameraBoundaryFN;
				ZS.ROM[(ZS.Offsets.entrance_scrolledge + 2 + (entranceId * 8))] = cameraBoundaryQS;
				ZS.ROM[(ZS.Offsets.entrance_scrolledge + 3 + (entranceId * 8))] = cameraBoundaryFS;
				ZS.ROM[(ZS.Offsets.entrance_scrolledge + 4 + (entranceId * 8))] = cameraBoundaryQW;
				ZS.ROM[(ZS.Offsets.entrance_scrolledge + 5 + (entranceId * 8))] = cameraBoundaryFW;
				ZS.ROM[(ZS.Offsets.entrance_scrolledge + 6 + (entranceId * 8))] = cameraBoundaryQE;
				ZS.ROM[(ZS.Offsets.entrance_scrolledge + 7 + (entranceId * 8))] = cameraBoundaryFE;
			}
			else
			{

				ZS.ROM[ZS.Offsets.startingentrance_room + (entranceId * 2), 2] = room;
				ZS.ROM[ZS.Offsets.startingentrance_yposition + (entranceId * 2), 2] = yposition;
				ZS.ROM[ZS.Offsets.startingentrance_xposition + (entranceId * 2), 2] = xposition;
				ZS.ROM[ZS.Offsets.startingentrance_cameray + (entranceId * 2), 2] = ycamera;
				ZS.ROM[ZS.Offsets.startingentrance_camerax + (entranceId * 2), 2] = xcamera;
				ZS.ROM[ZS.Offsets.startingentrance_cameraxtrigger + (entranceId * 2), 2] = xtrigger;
				ZS.ROM[ZS.Offsets.startingentrance_cameraytrigger + (entranceId * 2), 2] = ytrigger;
				ZS.ROM[ZS.Offsets.startingentrance_exit + (entranceId * 2), 2] = exit;

				ZS.ROM[ZS.Offsets.startingentrance_blockset + entranceId] = blockset;
				ZS.ROM[ZS.Offsets.startingentrance_music + entranceId] = music;
				ZS.ROM[ZS.Offsets.startingentrance_dungeon + entranceId] = dungeon;
				ZS.ROM[ZS.Offsets.startingentrance_door + entranceId] = door;
				ZS.ROM[ZS.Offsets.startingentrance_floor + entranceId] = floor;
				ZS.ROM[ZS.Offsets.startingentrance_ladderbg + entranceId] = ladderbg;
				ZS.ROM[ZS.Offsets.startingentrance_scrolling + entranceId] = scrolling;
				ZS.ROM[ZS.Offsets.startingentrance_scrollquadrant + entranceId] = scrollquadrant;
				ZS.ROM[ZS.Offsets.startingentrance_scrolledge + 0 + (entranceId * 8)] = cameraBoundaryQN;
				ZS.ROM[ZS.Offsets.startingentrance_scrolledge + 1 + (entranceId * 8)] = cameraBoundaryFN;
				ZS.ROM[ZS.Offsets.startingentrance_scrolledge + 2 + (entranceId * 8)] = cameraBoundaryQS;
				ZS.ROM[ZS.Offsets.startingentrance_scrolledge + 3 + (entranceId * 8)] = cameraBoundaryFS;
				ZS.ROM[ZS.Offsets.startingentrance_scrolledge + 4 + (entranceId * 8)] = cameraBoundaryQW;
				ZS.ROM[ZS.Offsets.startingentrance_scrolledge + 5 + (entranceId * 8)] = cameraBoundaryFW;
				ZS.ROM[ZS.Offsets.startingentrance_scrolledge + 6 + (entranceId * 8)] = cameraBoundaryQE;
				ZS.ROM[ZS.Offsets.startingentrance_scrolledge + 7 + (entranceId * 8)] = cameraBoundaryFE;
			}
		}
	}
}
