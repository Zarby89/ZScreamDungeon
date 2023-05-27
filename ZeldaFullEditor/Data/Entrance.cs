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
		short room; // word value for each room

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
		short exit; // 2byte word 
		byte music; // 1byte // Will need to be renamed and changed to add support to MSU1

		[DisplayName("Room ID"), Description("The room id the entrance is leading to"), Category("Entrance")]
		public short Room { get => room; set => room = value; }

		[DisplayName("Background X scroll"), Description("FILL ME"), Category("Entrance")]
		public ushort CameraX { get => xcamera; set => xcamera = value; }


		[DisplayName("Background Y scroll"), Description("FILL ME"), Category("Entrance")]
		public ushort CameraY { get => ycamera; set => ycamera = value; }

		[DisplayName("X Position"), Description("The X position the player will enter the room (0,0) origin"), Category("Entrance")]
		public ushort XPosition { get => xposition; set => xposition = value; }

		[DisplayName("Y Position"), Description("The Y position the player will enter the room (0,0) origin"), Category("Entrance")]
		public ushort YPosition { get => yposition; set => yposition = value; }

		[DisplayName("X camera trigger"), Description("Where the camera begins scrolling on the X-axis"), Category("Entrance")]
		public ushort CameraTriggerX { get => xtrigger; set => xtrigger = value; }

		[DisplayName("Y camera trigger"), Description("Where the camera begins scrolling on the X-axis"), Category("Entrance")]
		public ushort CameraTriggerY { get => ytrigger; set => ytrigger = value; }

		[DisplayName("Blockset"), Description("Used to determine the walls gfx of the dungeon"), Category("Entrance")]
		public byte Blockset { get => blockset; set => blockset = value; }


		[DisplayName("Floor"), Description("FILL ME ?"), Category("Entrance")]
		public byte Floor { get => floor; set => floor = value; }

		[DisplayName("Dungeon ID"), Description("Used to determine what dungeon we are in when entering from that entrance"), Category("Entrance")]
		public byte Dungeon { get => dungeon; set => dungeon = value; }

		[DisplayName("Ladder Bg"), Description("Used to determine the layer we will be on when entering"), Category("Entrance")]
		public byte Ladderbg
		{
			get
			{
				return ladderbg;
			}
			set
			{
				ladderbg = value;
				/*if (ladderbg >= 2)
                {
                    ladderbg = 1;
                }*/
			}
		}

		[DisplayName("Scrolling"), Description("Used to determine if you can scroll or not the room you are entering"), Category("Entrance")]
		public byte Scrolling
		{
			get
			{
				return scrolling;
			}
			set
			{
				scrolling = value;
				/*if (scrolling >= 2)
                {
                    scrolling = 1;
                }*/
			}
		}

		[DisplayName("Scroll Quadrant"), Description("Used to determine if you can scrollquadrant or not the room you are entering"), Category("Entrance")]
		public byte Scrollquadrant
		{
			get
			{
				return scrollquadrant;
			}
			set
			{
				scrollquadrant = value;
				/*if (scrollquadrant >= 2)
                {
                    scrollquadrant = 1;
                }*/
			}
		}

		// Why is that even a thing?
		[DisplayName("Exit"), Description("Used to determine where you will exit ?"), Category("Entrance")]
		public short Exit
		{
			get
			{
				return exit;
			}
			set
			{
				exit = value;
			}
		}

		[DisplayName("Music"), Description("Determine the music playing when entering from that entrance"), Category("Entrance")]
		public byte Music { get => music; set => music = value; }

		public Entrance(byte entranceId, bool isSpawnPoint = false)
		{
			room = (short) ((ROM.DATA[(Constants.entrance_room + (entranceId * 2)) + 1] << 8) + ROM.DATA[Constants.entrance_room + (entranceId * 2)]);
			yposition = (ushort) (((ROM.DATA[(Constants.entrance_yposition + (entranceId * 2)) + 1]) << 8) + ROM.DATA[Constants.entrance_yposition + (entranceId * 2)]);
			xposition = (ushort) (((ROM.DATA[(Constants.entrance_xposition + (entranceId * 2)) + 1]) << 8) + ROM.DATA[Constants.entrance_xposition + (entranceId * 2)]);
			xcamera = (ushort) (((ROM.DATA[(Constants.entrance_camerax + (entranceId * 2)) + 1]) << 8) + ROM.DATA[Constants.entrance_camerax + (entranceId * 2)]);
			ycamera = (ushort) (((ROM.DATA[(Constants.entrance_cameray + (entranceId * 2)) + 1]) << 8) + ROM.DATA[Constants.entrance_cameray + (entranceId * 2)]);
			ytrigger = (ushort) (((ROM.DATA[(Constants.entrance_cameraytrigger + (entranceId * 2)) + 1]) << 8) + ROM.DATA[Constants.entrance_cameraytrigger + (entranceId * 2)]);
			xtrigger = (ushort) (((ROM.DATA[(Constants.entrance_cameraxtrigger + (entranceId * 2)) + 1]) << 8) + ROM.DATA[Constants.entrance_cameraxtrigger + (entranceId * 2)]);
			blockset = ROM.DATA[(Constants.entrance_blockset + entranceId)];
			music = ROM.DATA[(Constants.entrance_music + entranceId)];
			dungeon = ROM.DATA[(Constants.entrance_dungeon + entranceId)];
			floor = ROM.DATA[(Constants.entrance_floor + entranceId)];
			door = ROM.DATA[(Constants.entrance_door + entranceId)];
			ladderbg = ROM.DATA[(Constants.entrance_ladderbg + entranceId)];
			scrolling = ROM.DATA[(Constants.entrance_scrolling + entranceId)];
			scrollquadrant = ROM.DATA[(Constants.entrance_scrollquadrant + entranceId)];
			exit = (short) (((ROM.DATA[(Constants.entrance_exit + (entranceId * 2)) + 1]) << 8) + ROM.DATA[Constants.entrance_exit + (entranceId * 2)]);

			cameraBoundaryQN = (ROM.DATA[(Constants.entrance_scrolledge + 0 + (entranceId * 8))]);
			cameraBoundaryFN = (ROM.DATA[(Constants.entrance_scrolledge + 1 + (entranceId * 8))]);
			cameraBoundaryQS = (ROM.DATA[(Constants.entrance_scrolledge + 2 + (entranceId * 8))]);
			cameraBoundaryFS = (ROM.DATA[(Constants.entrance_scrolledge + 3 + (entranceId * 8))]);
			cameraBoundaryQW = (ROM.DATA[(Constants.entrance_scrolledge + 4 + (entranceId * 8))]);
			cameraBoundaryFW = (ROM.DATA[(Constants.entrance_scrolledge + 5 + (entranceId * 8))]);
			cameraBoundaryQE = (ROM.DATA[(Constants.entrance_scrolledge + 6 + (entranceId * 8))]);
			cameraBoundaryFE = (ROM.DATA[(Constants.entrance_scrolledge + 7 + (entranceId * 8))]);


			if (isSpawnPoint)
			{
				room = (short) ((ROM.DATA[(Constants.startingentrance_room + ((entranceId) * 2)) + 1] << 8) + ROM.DATA[Constants.startingentrance_room + ((entranceId) * 2)]);
				//yposition = (short)(((ROM.DATA[(Constants.startingentrance_yposition + ((entranceId) * 2)) + 1] & 0x01) << 8) + ROM.DATA[Constants.startingentrance_yposition + ((entranceId) * 2)]);
				//xposition = (short)(((ROM.DATA[(Constants.startingentrance_xposition + ((entranceId) * 2)) + 1] & 0x01) << 8) + ROM.DATA[Constants.startingentrance_xposition + ((entranceId) * 2)]);
				//xscroll = (short)(((ROM.DATA[(Constants.startingentrance_xscroll + ((entranceId) * 2)) + 1] & 0x01) << 8) + ROM.DATA[Constants.startingentrance_xscroll + ((entranceId) * 2)]);
				//yscroll = (short)(((ROM.DATA[(Constants.startingentrance_yscroll + ((entranceId) * 2)) + 1] & 0x01) << 8) + ROM.DATA[Constants.startingentrance_yscroll + ((entranceId) * 2)]);
				//ycamera = (short)(((ROM.DATA[(Constants.startingentrance_camerayposition + ((entranceId) * 2)) + 1] & 0x01) << 8) + ROM.DATA[Constants.startingentrance_camerayposition + ((entranceId) * 2)]);
				//xcamera = (short)(((ROM.DATA[(Constants.startingentrance_cameraxposition + ((entranceId) * 2)) + 1] & 0x01) << 8) + ROM.DATA[Constants.startingentrance_cameraxposition + ((entranceId) * 2)]);
				yposition = (ushort) (((ROM.DATA[(Constants.startingentrance_yposition + (entranceId * 2)) + 1]) << 8) + ROM.DATA[Constants.startingentrance_yposition + (entranceId * 2)]);
				xposition = (ushort) (((ROM.DATA[(Constants.startingentrance_xposition + (entranceId * 2)) + 1]) << 8) + ROM.DATA[Constants.startingentrance_xposition + (entranceId * 2)]);
				xcamera = (ushort) (((ROM.DATA[(Constants.startingentrance_camerax + (entranceId * 2)) + 1]) << 8) + ROM.DATA[Constants.startingentrance_camerax + (entranceId * 2)]);
				ycamera = (ushort) (((ROM.DATA[(Constants.startingentrance_cameray + (entranceId * 2)) + 1]) << 8) + ROM.DATA[Constants.startingentrance_cameray + (entranceId * 2)]);
				ytrigger = (ushort) (((ROM.DATA[(Constants.startingentrance_cameraytrigger + (entranceId * 2)) + 1]) << 8) + ROM.DATA[Constants.startingentrance_cameraytrigger + (entranceId * 2)]);
				xtrigger = (ushort) (((ROM.DATA[(Constants.startingentrance_cameraxtrigger + (entranceId * 2)) + 1]) << 8) + ROM.DATA[Constants.startingentrance_cameraxtrigger + (entranceId * 2)]);
				blockset = ROM.DATA[(Constants.startingentrance_blockset + entranceId)];
				music = ROM.DATA[(Constants.startingentrance_music + entranceId)];
				dungeon = ROM.DATA[(Constants.startingentrance_dungeon + entranceId)];
				floor = ROM.DATA[(Constants.startingentrance_floor + entranceId)];
				door = ROM.DATA[(Constants.startingentrance_door + entranceId)];
				ladderbg = ROM.DATA[(Constants.startingentrance_ladderbg + entranceId)];
				scrolling = ROM.DATA[(Constants.startingentrance_scrolling + entranceId)];
				scrollquadrant = ROM.DATA[(Constants.startingentrance_scrollquadrant + entranceId)];
				exit = (short) (((ROM.DATA[(Constants.startingentrance_exit + (entranceId * 2)) + 1] & 0x01) << 8) + ROM.DATA[Constants.startingentrance_exit + (entranceId * 2)]);
				cameraBoundaryQN = (ROM.DATA[(Constants.startingentrance_scrolledge + 0 + (entranceId * 8))]);
				cameraBoundaryFN = (ROM.DATA[(Constants.startingentrance_scrolledge + 1 + (entranceId * 8))]);
				cameraBoundaryQS = (ROM.DATA[(Constants.startingentrance_scrolledge + 2 + (entranceId * 8))]);
				cameraBoundaryFS = (ROM.DATA[(Constants.startingentrance_scrolledge + 3 + (entranceId * 8))]);
				cameraBoundaryQW = (ROM.DATA[(Constants.startingentrance_scrolledge + 4 + (entranceId * 8))]);
				cameraBoundaryFW = (ROM.DATA[(Constants.startingentrance_scrolledge + 5 + (entranceId * 8))]);
				cameraBoundaryQE = (ROM.DATA[(Constants.startingentrance_scrolledge + 6 + (entranceId * 8))]);
				cameraBoundaryFE = (ROM.DATA[(Constants.startingentrance_scrolledge + 7 + (entranceId * 8))]);
			}
		}

		public void save(int entranceId, bool isSpawnPoint = false, bool jp = false)
		{
			// TODO: Change these save
			if (!isSpawnPoint)
			{
				ROM.WriteShort(Constants.entrance_room + (entranceId * 2), room, WriteType.EntranceProperties);
				//ROM.DATA[(Constants.entrance_room + (entranceId * 2) + 1)] = (byte)((room >> 8) & 0xFF);
				//ROM.DATA[Constants.entrance_room + (entranceId * 2)] = (byte)(room & 0xFF);

				ROM.WriteShort(Constants.entrance_yposition + (entranceId * 2), yposition, WriteType.EntranceProperties);
				//ROM.DATA[(Constants.entrance_yposition + (entranceId * 2)) + 1] = (byte)((yposition >> 8) & 0xFF);
				//ROM.DATA[Constants.entrance_yposition + (entranceId * 2)] = (byte)(yposition & 0xFF);

				ROM.WriteShort(Constants.entrance_xposition + (entranceId * 2), xposition, WriteType.EntranceProperties);
				//ROM.DATA[(Constants.entrance_xposition + (entranceId * 2)) + 1] = (byte)((xposition >> 8) & 0xFF);
				//ROM.DATA[Constants.entrance_xposition + (entranceId * 2)] = (byte)(xposition & 0xFF);

				ROM.WriteShort(Constants.entrance_cameray + (entranceId * 2), ycamera, WriteType.EntranceProperties);
				//ROM.DATA[(Constants.entrance_xscroll + (entranceId * 2)) + 1] = (byte)((xscroll >> 8) & 0xFF);
				//ROM.DATA[Constants.entrance_xscroll + (entranceId * 2)] = (byte)(xscroll & 0xFF);

				ROM.WriteShort(Constants.entrance_camerax + (entranceId * 2), xcamera, WriteType.EntranceProperties);
				//ROM.DATA[(Constants.entrance_yscroll + (entranceId * 2)) + 1] = (byte)((yscroll >> 8) & 0xFF);
				//ROM.DATA[Constants.entrance_yscroll + (entranceId * 2)] = (byte)(yscroll & 0xFF);

				ROM.WriteShort(Constants.entrance_cameraxtrigger + (entranceId * 2), xtrigger, WriteType.EntranceProperties);
				//ROM.DATA[(Constants.entrance_cameraxposition + (entranceId * 2)) + 1] = (byte)((xcamera >> 8) & 0xFF);
				//ROM.DATA[Constants.entrance_cameraxposition + (entranceId * 2)] = (byte)(xcamera & 0xFF);

				ROM.WriteShort(Constants.entrance_cameraytrigger + (entranceId * 2), ytrigger, WriteType.EntranceProperties);
				//ROM.DATA[(Constants.entrance_camerayposition + (entranceId * 2)) + 1] = (byte)((ycamera >> 8) & 0xFF);
				//ROM.DATA[Constants.entrance_camerayposition + (entranceId * 2)] = (byte)(ycamera & 0xFF);

				ROM.WriteShort(Constants.entrance_exit + (entranceId * 2), exit, WriteType.EntranceProperties);
				//ROM.DATA[(Constants.entrance_exit + (entranceId * 2) + 1)] = (byte)((exit >> 8) & 0xFF);
				//ROM.DATA[Constants.entrance_exit + (entranceId * 2)] = (byte)(exit & 0xFF);
				ROM.Write(Constants.entrance_blockset + entranceId, (byte) (blockset & 0xFF), WriteType.EntranceProperties);
				//ROM.DATA[Constants.entrance_blockset + entranceId] = (byte)(blockset & 0xFF);
				ROM.Write(Constants.entrance_music + entranceId, (byte) (music & 0xFF), WriteType.EntranceProperties);
				//ROM.DATA[Constants.entrance_music + entranceId] = (byte)(music & 0xFF);
				ROM.Write(Constants.entrance_dungeon + entranceId, (byte) (dungeon & 0xFF), WriteType.EntranceProperties);
				//ROM.DATA[Constants.entrance_dungeon + entranceId] = (byte)(dungeon & 0xFF);
				ROM.Write(Constants.entrance_door + entranceId, (byte) (door & 0xFF), WriteType.EntranceProperties);
				//ROM.DATA[Constants.entrance_door + entranceId] = (byte)(door & 0xFF);
				ROM.Write(Constants.entrance_floor + entranceId, (byte) (floor & 0xFF), WriteType.EntranceProperties);
				//ROM.DATA[Constants.entrance_floor + entranceId] = (byte)(floor & 0xFF);
				ROM.Write(Constants.entrance_ladderbg + entranceId, (byte) (ladderbg & 0xFF), WriteType.EntranceProperties);
				//ROM.DATA[Constants.entrance_ladderbg + entranceId] = (byte)(ladderbg & 0xFF);
				ROM.Write(Constants.entrance_scrolling + entranceId, (byte) (scrolling & 0xFF), WriteType.EntranceProperties);
				//ROM.DATA[Constants.entrance_scrolling + entranceId] = (byte)(scrolling & 0xFF);
				ROM.Write(Constants.entrance_scrollquadrant + entranceId, (byte) (scrollquadrant & 0xFF), WriteType.EntranceProperties);
				//ROM.DATA[Constants.entrance_scrollquadrant + entranceId] = (byte)(scrollquadrant & 0xFF);
				ROM.Write((Constants.entrance_scrolledge + 0 + (entranceId * 8)), cameraBoundaryQN, WriteType.EntranceProperties);
				//ROM.DATA[(Constants.entrance_scrolledge + 0 + (entranceId * 8))] = scrolledge_HU;
				ROM.Write((Constants.entrance_scrolledge + 1 + (entranceId * 8)), cameraBoundaryFN, WriteType.EntranceProperties);
				//ROM.DATA[(Constants.entrance_scrolledge + 1 + (entranceId * 8))] = scrolledge_FU;
				ROM.Write((Constants.entrance_scrolledge + 2 + (entranceId * 8)), cameraBoundaryQS, WriteType.EntranceProperties);
				//ROM.DATA[(Constants.entrance_scrolledge + 2 + (entranceId * 8))] = scrolledge_HD;
				ROM.Write((Constants.entrance_scrolledge + 3 + (entranceId * 8)), cameraBoundaryFS, WriteType.EntranceProperties);
				//ROM.DATA[(Constants.entrance_scrolledge + 3 + (entranceId * 8))] = scrolledge_FD;
				ROM.Write((Constants.entrance_scrolledge + 4 + (entranceId * 8)), cameraBoundaryQW, WriteType.EntranceProperties);
				//ROM.DATA[(Constants.entrance_scrolledge + 4 + (entranceId * 8))] = scrolledge_HL;
				ROM.Write((Constants.entrance_scrolledge + 5 + (entranceId * 8)), cameraBoundaryFW, WriteType.EntranceProperties);
				//ROM.DATA[(Constants.entrance_scrolledge + 5 + (entranceId * 8))] = scrolledge_FL;
				ROM.Write((Constants.entrance_scrolledge + 6 + (entranceId * 8)), cameraBoundaryQE, WriteType.EntranceProperties);
				//ROM.DATA[(Constants.entrance_scrolledge + 6 + (entranceId * 8))] = scrolledge_HR;
				ROM.Write((Constants.entrance_scrolledge + 7 + (entranceId * 8)), cameraBoundaryFE, WriteType.EntranceProperties);
				//ROM.DATA[(Constants.entrance_scrolledge + 7 + (entranceId * 8))] = scrolledge_FR;
			}
			else
			{

				ROM.WriteShort(Constants.startingentrance_room + (entranceId * 2), room, WriteType.SpawnProperties);

				ROM.WriteShort(Constants.startingentrance_yposition + (entranceId * 2), yposition, WriteType.SpawnProperties);

				ROM.WriteShort(Constants.startingentrance_xposition + (entranceId * 2), xposition, WriteType.SpawnProperties);

				ROM.WriteShort(Constants.startingentrance_cameray + (entranceId * 2), ycamera, WriteType.SpawnProperties);

				ROM.WriteShort(Constants.startingentrance_camerax + (entranceId * 2), xcamera, WriteType.SpawnProperties);

				ROM.WriteShort(Constants.startingentrance_cameraxtrigger + (entranceId * 2), xtrigger, WriteType.SpawnProperties);

				ROM.WriteShort(Constants.startingentrance_cameraytrigger + (entranceId * 2), ytrigger, WriteType.SpawnProperties);

				ROM.WriteShort(Constants.startingentrance_exit + (entranceId * 2), exit, WriteType.SpawnProperties);

				ROM.Write(Constants.startingentrance_blockset + entranceId, (byte) (blockset & 0xFF), WriteType.SpawnProperties);
				ROM.Write(Constants.startingentrance_music + entranceId, (byte) (music & 0xFF), WriteType.SpawnProperties);
				ROM.Write(Constants.startingentrance_dungeon + entranceId, (byte) (dungeon & 0xFF), WriteType.SpawnProperties);
				ROM.Write(Constants.startingentrance_door + entranceId, (byte) (door & 0xFF), WriteType.SpawnProperties);
				ROM.Write(Constants.startingentrance_floor + entranceId, (byte) (floor & 0xFF), WriteType.SpawnProperties);
				ROM.Write(Constants.startingentrance_ladderbg + entranceId, (byte) (ladderbg & 0xFF), WriteType.SpawnProperties);
				ROM.Write(Constants.startingentrance_scrolling + entranceId, (byte) (scrolling & 0xFF), WriteType.SpawnProperties);
				ROM.Write(Constants.startingentrance_scrollquadrant + entranceId, (byte) (scrollquadrant & 0xFF), WriteType.SpawnProperties);
				ROM.Write((Constants.startingentrance_scrolledge + 0 + (entranceId * 8)), cameraBoundaryQN, WriteType.SpawnProperties);
				ROM.Write((Constants.startingentrance_scrolledge + 1 + (entranceId * 8)), cameraBoundaryFN, WriteType.SpawnProperties);
				ROM.Write((Constants.startingentrance_scrolledge + 2 + (entranceId * 8)), cameraBoundaryQS, WriteType.SpawnProperties);
				ROM.Write((Constants.startingentrance_scrolledge + 3 + (entranceId * 8)), cameraBoundaryFS, WriteType.SpawnProperties);
				ROM.Write((Constants.startingentrance_scrolledge + 4 + (entranceId * 8)), cameraBoundaryQW, WriteType.SpawnProperties);
				ROM.Write((Constants.startingentrance_scrolledge + 5 + (entranceId * 8)), cameraBoundaryFW, WriteType.SpawnProperties);
				ROM.Write((Constants.startingentrance_scrolledge + 6 + (entranceId * 8)), cameraBoundaryQE, WriteType.SpawnProperties);
				ROM.Write((Constants.startingentrance_scrolledge + 7 + (entranceId * 8)), cameraBoundaryFE, WriteType.SpawnProperties);
			}
		}
	}
}
