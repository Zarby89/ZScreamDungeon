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
			room = ZS.ROM[Constants.entrance_room + (entranceId * 2), 2];
			yposition = ZS.ROM[Constants.entrance_yposition + (entranceId * 2), 2];
			xposition = ZS.ROM[Constants.entrance_xposition + (entranceId * 2), 2];
			xcamera = ZS.ROM[Constants.entrance_camerax + (entranceId * 2), 2];
			ycamera = ZS.ROM[Constants.entrance_cameray + (entranceId * 2), 2];
			ytrigger = ZS.ROM[Constants.entrance_cameraytrigger + (entranceId * 2), 2];
			xtrigger = ZS.ROM[Constants.entrance_cameraxtrigger + (entranceId * 2), 2];
			blockset = ZS.ROM[Constants.entrance_blockset + entranceId];
			music = ZS.ROM[Constants.entrance_music + entranceId];
			dungeon = ZS.ROM[Constants.entrance_dungeon + entranceId];
			floor = ZS.ROM[Constants.entrance_floor + entranceId];
			door = ZS.ROM[Constants.entrance_door + entranceId];
			ladderbg = ZS.ROM[Constants.entrance_ladderbg + entranceId];
			scrolling = ZS.ROM[Constants.entrance_scrolling + entranceId];
			scrollquadrant = ZS.ROM[Constants.entrance_scrollquadrant + entranceId];
			exit = ZS.ROM[Constants.entrance_exit + (entranceId * 2), 2];

			cameraBoundaryQN = ZS.ROM[Constants.entrance_scrolledge + 0 + (entranceId * 8)];
			cameraBoundaryFN = ZS.ROM[Constants.entrance_scrolledge + 1 + (entranceId * 8)];
			cameraBoundaryQS = ZS.ROM[Constants.entrance_scrolledge + 2 + (entranceId * 8)];
			cameraBoundaryFS = ZS.ROM[Constants.entrance_scrolledge + 3 + (entranceId * 8)];
			cameraBoundaryQW = ZS.ROM[Constants.entrance_scrolledge + 4 + (entranceId * 8)];
			cameraBoundaryFW = ZS.ROM[Constants.entrance_scrolledge + 5 + (entranceId * 8)];
			cameraBoundaryQE = ZS.ROM[Constants.entrance_scrolledge + 6 + (entranceId * 8)];
			cameraBoundaryFE = ZS.ROM[Constants.entrance_scrolledge + 7 + (entranceId * 8)];


			if (isSpawnPoint)
			{
				room = ZS.ROM[Constants.startingentrance_room + ((entranceId) * 2), 2];
				yposition = ZS.ROM[Constants.startingentrance_yposition + (entranceId * 2), 2];
				xposition = ZS.ROM[Constants.startingentrance_xposition + (entranceId * 2), 2];
				xcamera = ZS.ROM[Constants.startingentrance_camerax + (entranceId * 2), 2];
				ycamera = ZS.ROM[Constants.startingentrance_cameray + (entranceId * 2), 2];
				ytrigger = ZS.ROM[Constants.startingentrance_cameraytrigger + (entranceId * 2), 2];
				xtrigger = ZS.ROM[Constants.startingentrance_cameraxtrigger + (entranceId * 2), 2];
				blockset = ZS.ROM[Constants.startingentrance_blockset + entranceId];
				music = ZS.ROM[Constants.startingentrance_music + entranceId];
				dungeon = ZS.ROM[Constants.startingentrance_dungeon + entranceId];
				floor = ZS.ROM[Constants.startingentrance_floor + entranceId];
				door = ZS.ROM[Constants.startingentrance_door + entranceId];
				ladderbg = ZS.ROM[Constants.startingentrance_ladderbg + entranceId];
				scrolling = ZS.ROM[Constants.startingentrance_scrolling + entranceId];
				scrollquadrant = ZS.ROM[Constants.startingentrance_scrollquadrant + entranceId];
				exit = ZS.ROM[Constants.startingentrance_exit + (entranceId * 2), 2];
				cameraBoundaryQN = ZS.ROM[Constants.startingentrance_scrolledge + 0 + (entranceId * 8)];
				cameraBoundaryFN = ZS.ROM[Constants.startingentrance_scrolledge + 1 + (entranceId * 8)];
				cameraBoundaryQS = ZS.ROM[Constants.startingentrance_scrolledge + 2 + (entranceId * 8)];
				cameraBoundaryFS = ZS.ROM[Constants.startingentrance_scrolledge + 3 + (entranceId * 8)];
				cameraBoundaryQW = ZS.ROM[Constants.startingentrance_scrolledge + 4 + (entranceId * 8)];
				cameraBoundaryFW = ZS.ROM[Constants.startingentrance_scrolledge + 5 + (entranceId * 8)];
				cameraBoundaryQE = ZS.ROM[Constants.startingentrance_scrolledge + 6 + (entranceId * 8)];
				cameraBoundaryFE = ZS.ROM[Constants.startingentrance_scrolledge + 7 + (entranceId * 8)];
			}
		}

		public void save(int entranceId, bool isSpawnPoint = false, bool jp = false)
		{
			// TODO: Change these save
			if (!isSpawnPoint)
			{
				ZS.ROM[Constants.entrance_room + (entranceId * 2), 2] = room;
				ZS.ROM[Constants.entrance_yposition + (entranceId * 2), 2] = yposition;
				ZS.ROM[Constants.entrance_xposition + (entranceId * 2), 2] = xposition;
				ZS.ROM[Constants.entrance_cameray + (entranceId * 2), 2] = ycamera;
				ZS.ROM[Constants.entrance_camerax + (entranceId * 2), 2] = xcamera;
				ZS.ROM[Constants.entrance_cameraxtrigger + (entranceId * 2), 2] = xtrigger;
				ZS.ROM[Constants.entrance_cameraytrigger + (entranceId * 2), 2] = ytrigger;
				ZS.ROM[Constants.entrance_exit + (entranceId * 2), 2] = exit;

				ZS.ROM[Constants.entrance_blockset + entranceId] = blockset;
				ZS.ROM[Constants.entrance_music + entranceId] = music;
				ZS.ROM[Constants.entrance_dungeon + entranceId] = dungeon;
				ZS.ROM[Constants.entrance_door + entranceId] = door;
				ZS.ROM[Constants.entrance_floor + entranceId] = floor;
				ZS.ROM[Constants.entrance_ladderbg + entranceId] = ladderbg;
				ZS.ROM[Constants.entrance_scrolling + entranceId] = scrolling;
				ZS.ROM[Constants.entrance_scrollquadrant + entranceId] = scrollquadrant;
				ZS.ROM[(Constants.entrance_scrolledge + 0 + (entranceId * 8))] = cameraBoundaryQN;
				ZS.ROM[(Constants.entrance_scrolledge + 1 + (entranceId * 8))] = cameraBoundaryFN;
				ZS.ROM[(Constants.entrance_scrolledge + 2 + (entranceId * 8))] = cameraBoundaryQS;
				ZS.ROM[(Constants.entrance_scrolledge + 3 + (entranceId * 8))] = cameraBoundaryFS;
				ZS.ROM[(Constants.entrance_scrolledge + 4 + (entranceId * 8))] = cameraBoundaryQW;
				ZS.ROM[(Constants.entrance_scrolledge + 5 + (entranceId * 8))] = cameraBoundaryFW;
				ZS.ROM[(Constants.entrance_scrolledge + 6 + (entranceId * 8))] = cameraBoundaryQE;
				ZS.ROM[(Constants.entrance_scrolledge + 7 + (entranceId * 8))] = cameraBoundaryFE;
			}
			else
			{

				ZS.ROM[Constants.startingentrance_room + (entranceId * 2), 2] = room;
				ZS.ROM[Constants.startingentrance_yposition + (entranceId * 2), 2] = yposition;
				ZS.ROM[Constants.startingentrance_xposition + (entranceId * 2), 2] = xposition;
				ZS.ROM[Constants.startingentrance_cameray + (entranceId * 2), 2] = ycamera;
				ZS.ROM[Constants.startingentrance_camerax + (entranceId * 2), 2] = xcamera;
				ZS.ROM[Constants.startingentrance_cameraxtrigger + (entranceId * 2), 2] = xtrigger;
				ZS.ROM[Constants.startingentrance_cameraytrigger + (entranceId * 2), 2] = ytrigger;
				ZS.ROM[Constants.startingentrance_exit + (entranceId * 2), 2] = exit;

				ZS.ROM[Constants.startingentrance_blockset + entranceId] = blockset;
				ZS.ROM[Constants.startingentrance_music + entranceId] = music;
				ZS.ROM[Constants.startingentrance_dungeon + entranceId] = dungeon;
				ZS.ROM[Constants.startingentrance_door + entranceId] = door;
				ZS.ROM[Constants.startingentrance_floor + entranceId] = floor;
				ZS.ROM[Constants.startingentrance_ladderbg + entranceId] = ladderbg;
				ZS.ROM[Constants.startingentrance_scrolling + entranceId] = scrolling;
				ZS.ROM[Constants.startingentrance_scrollquadrant + entranceId] = scrollquadrant;
				ZS.ROM[Constants.startingentrance_scrolledge + 0 + (entranceId * 8)] = cameraBoundaryQN;
				ZS.ROM[Constants.startingentrance_scrolledge + 1 + (entranceId * 8)] = cameraBoundaryFN;
				ZS.ROM[Constants.startingentrance_scrolledge + 2 + (entranceId * 8)] = cameraBoundaryQS;
				ZS.ROM[Constants.startingentrance_scrolledge + 3 + (entranceId * 8)] = cameraBoundaryFS;
				ZS.ROM[Constants.startingentrance_scrolledge + 4 + (entranceId * 8)] = cameraBoundaryQW;
				ZS.ROM[Constants.startingentrance_scrolledge + 5 + (entranceId * 8)] = cameraBoundaryFW;
				ZS.ROM[Constants.startingentrance_scrolledge + 6 + (entranceId * 8)] = cameraBoundaryQE;
				ZS.ROM[Constants.startingentrance_scrolledge + 7 + (entranceId * 8)] = cameraBoundaryFE;
			}
		}
	}
}
