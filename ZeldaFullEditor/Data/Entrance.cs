﻿using System.ComponentModel;

namespace ZeldaFullEditor
{
	/// <summary>
	///     A data class containing all the info for dungeon entrance properties. Can be used for starting entrances as well.
	/// </summary>
	public class Entrance
	{
		// 8 bytes per room Q (quadrant) and F (full) for cardinal directions NSWE

		/// <summary>
		///     Gets or sets the north quadrant boundary.
		/// </summary>
		public byte CameraBoundaryQN { get; set; }

		/// <summary>
		///     Gets or sets the north full boundary.
		/// </summary>
		public byte CameraBoundaryFN { get; set; }

		/// <summary>
		///     Gets or sets the south quadrant boundary.
		/// </summary>
		public byte CameraBoundaryQS { get; set; }

		/// <summary>
		///     Gets or sets the south full boundary.
		/// </summary>
		public byte CameraBoundaryFS { get; set; }

		/// <summary>
		///     Gets or sets the west quadrant boundary.
		/// </summary>
		public byte CameraBoundaryQW { get; set; }

		/// <summary>
		///     Gets or sets the west full boundary.
		/// </summary>
		public byte CameraBoundaryFW { get; set; }

		/// <summary>
		///     Gets or sets the east quadrant boundary.
		/// </summary>
		public byte CameraBoundaryQE { get; set; }

		/// <summary>
		///     Gets or sets the east full boundary.
		/// </summary>
		public byte CameraBoundaryFE { get; set; }

		/// <summary>
		///     Gets or sets the entrance room.
		///     Word value for each room.
		/// </summary>
		[DisplayName("Room ID")]
		[Description("The room id the entrance is leading to.")]
		[Category("Entrance")]
		public short Room { get; set; }

		/// <summary>
		///     Gets or sets the CameraX value for the entrance.
		///     2bytes.
		/// </summary>
		[DisplayName("Background X scroll.")]
		[Description("FILL ME")]
		[Category("Entrance")]
		public ushort CameraX { get; set; }

		/// <summary>
		///     Gets or sets the CameraY value for the entrance.
		///     2bytes each room.
		/// </summary>
		[DisplayName("Background Y scroll.")]
		[Description("FILL ME")]
		[Category("Entrance")]
		public ushort CameraY { get; set; }

		/// <summary>
		///     Gets or sets the X position for the entrance.
		///     2bytes.
		/// </summary>
		[DisplayName("X Position")]
		[Description("The X position the player will enter the room (0,0) origin.")]
		[Category("Entrance")]
		public ushort XPosition { get; set; }

		/// <summary>
		///     Gets or sets the Y position for the entrance.
		///     2bytes.
		/// </summary>
		[DisplayName("Y Position")]
		[Description("The Y position the player will enter the room (0,0) origin.")]
		[Category("Entrance")]
		public ushort YPosition { get; set; }

		/// <summary>
		///     Gets or sets the X camera trigger for the entrance.
		///     2bytes.
		/// </summary>
		[DisplayName("X camera trigger")]
		[Description("Where the camera begins scrolling on the X-axis.")]
		[Category("Entrance")]
		public ushort CameraTriggerX { get; set; }

		/// <summary>
		///     Gets or sets the Y camera trigger for the entrance.
		///     2bytes.
		/// </summary>
		[DisplayName("Y camera trigger")]
		[Description("Where the camera begins scrolling on the X-axis.")]
		[Category("Entrance")]
		public ushort CameraTriggerY { get; set; }

		/// <summary>
		///     Gets or sets the blockset for the entrance.
		///     1byte.
		/// </summary>
		[DisplayName("Blockset")]
		[Description("Used to determine the walls gfx of the dungeon.")]
		[Category("Entrance")]
		public byte Blockset { get; set; }

		/// <summary>
		///     Gets or sets the floor for the entrance.
		///     1byte.
		/// </summary>
		[DisplayName("Floor")]
		[Description("The floor of the dungeon you enter into.")]
		[Category("Entrance")]
		public byte Floor { get; set; }

		/// <summary>
		///     Gets or sets the Dungeon ID for the entrance.
		///     1byte.
		///     Same as music might use the project dungeon name instead.
		/// </summary>
		[DisplayName("Dungeon ID")]
		[Description("Used to determine what dungeon we are in when entering from that entrance.")]
		[Category("Entrance")]
		public byte DungeonID { get; set; }

		/// <summary>
		///     Gets or sets the ladder BG for the entrance.
		///     1 byte, ---b ---a b = bg2, a = need to check -_-.
		/// </summary>
		[DisplayName("Ladder Bg")]
		[Description("Used to determine the layer we will be on when entering.")]
		[Category("Entrance")]
		public byte LadderBG { get; set; }

		/// <summary>
		///     Gets or sets the scrolling byte for the entrance.
		///     1byte --h- --v-.
		/// </summary>
		[DisplayName("Scrolling")]
		[Description("Used to determine if you can scroll or not the room you are entering.")]
		[Category("Entrance")]
		public byte Scrolling { get; set; }

		/// <summary>
		///     Gets or sets the scroll quadrant for the entrance.
		///     1byte.
		/// </summary>
		[DisplayName("Scroll Quadrant")]
		[Description("Used to determine if you can scrollquadrant or not the room you are entering.")]
		[Category("Entrance")]
		public byte ScrollQuadrant { get; set; }

		/// <summary>
		///     Gets or sets the exit for the entrance.
		///     2byte word.
		/// </summary>
		[DisplayName("Exit")]
		[Description("Used to determine where you will exit?")]
		[Category("Entrance")]
		public short Exit { get; set; }

		/// <summary>
		///     Gets or sets the music for the entrance.
		///     1byte.
		///     Will need to be renamed and changed to add support to MSU1.
		/// </summary>
		[DisplayName("Music")]
		[Description("Determine the music playing when entering from that entrance.")]
		[Category("Entrance")]
		public byte Music { get; set; }

		/// <summary>
		///     Gets or sets the door bool for the entrance.
		///     1byte.
		///     TODO: The description needs to be verified, WTF is this for?.
		/// </summary>
		[DisplayName("Door")]
		[Description("Determine the 'use door' boolean from that entrance.")]
		[Category("Entrance")]
		public byte Door { get; set; }

		/// <summary>
		///     Initializes a new instance of the <see cref="Entrance"/> class.
		/// </summary>
		/// <param name="entranceID"> The entrance ID. </param>
		/// <param name="isSpawnPoint"> Whether the entrance is a spawn point or not. </param>
		public Entrance(byte entranceID, bool isSpawnPoint = false)
		{
			this.Room = (short) ((ROM.DATA[Constants.entrance_room + (entranceID * 2) + 1] << 8) + ROM.DATA[Constants.entrance_room + (entranceID * 2)]);
			this.YPosition = (ushort) ((ROM.DATA[Constants.entrance_yposition + (entranceID * 2) + 1] << 8) + ROM.DATA[Constants.entrance_yposition + (entranceID * 2)]);
			this.XPosition = (ushort) ((ROM.DATA[Constants.entrance_xposition + (entranceID * 2) + 1] << 8) + ROM.DATA[Constants.entrance_xposition + (entranceID * 2)]);
			this.CameraX = (ushort) ((ROM.DATA[Constants.entrance_camerax + (entranceID * 2) + 1] << 8) + ROM.DATA[Constants.entrance_camerax + (entranceID * 2)]);
			this.CameraY = (ushort) ((ROM.DATA[Constants.entrance_cameray + (entranceID * 2) + 1] << 8) + ROM.DATA[Constants.entrance_cameray + (entranceID * 2)]);
			this.CameraTriggerY = (ushort) ((ROM.DATA[(Constants.entrance_cameraytrigger + (entranceID * 2)) + 1] << 8) + ROM.DATA[Constants.entrance_cameraytrigger + (entranceID * 2)]);
			this.CameraTriggerX = (ushort) ((ROM.DATA[(Constants.entrance_cameraxtrigger + (entranceID * 2)) + 1] << 8) + ROM.DATA[Constants.entrance_cameraxtrigger + (entranceID * 2)]);
			this.Blockset = ROM.DATA[Constants.entrance_blockset + entranceID];
			this.Music = ROM.DATA[Constants.entrance_music + entranceID];
			this.DungeonID = ROM.DATA[Constants.entrance_dungeon + entranceID];
			this.Floor = ROM.DATA[Constants.entrance_floor + entranceID];
			this.Door = ROM.DATA[Constants.entrance_door + entranceID];
			this.LadderBG = ROM.DATA[Constants.entrance_ladderbg + entranceID];
			this.Scrolling = ROM.DATA[Constants.entrance_scrolling + entranceID];
			this.ScrollQuadrant = ROM.DATA[Constants.entrance_scrollquadrant + entranceID];
			this.Exit = (short) ((ROM.DATA[Constants.entrance_exit + (entranceID * 2) + 1] << 8) + ROM.DATA[Constants.entrance_exit + (entranceID * 2)]);

			this.CameraBoundaryQN = ROM.DATA[Constants.entrance_scrolledge + 0 + (entranceID * 8)];
			this.CameraBoundaryFN = ROM.DATA[Constants.entrance_scrolledge + 1 + (entranceID * 8)];
			this.CameraBoundaryQS = ROM.DATA[Constants.entrance_scrolledge + 2 + (entranceID * 8)];
			this.CameraBoundaryFS = ROM.DATA[Constants.entrance_scrolledge + 3 + (entranceID * 8)];
			this.CameraBoundaryQW = ROM.DATA[Constants.entrance_scrolledge + 4 + (entranceID * 8)];
			this.CameraBoundaryFW = ROM.DATA[Constants.entrance_scrolledge + 5 + (entranceID * 8)];
			this.CameraBoundaryQE = ROM.DATA[Constants.entrance_scrolledge + 6 + (entranceID * 8)];
			this.CameraBoundaryFE = ROM.DATA[Constants.entrance_scrolledge + 7 + (entranceID * 8)];

			if (isSpawnPoint)
			{
				this.Room = (short) ((ROM.DATA[Constants.startingentrance_room + (entranceID * 2) + 1] << 8) + ROM.DATA[Constants.startingentrance_room + (entranceID * 2)]);
				this.YPosition = (ushort) ((ROM.DATA[Constants.startingentrance_yposition + (entranceID * 2) + 1] << 8) + ROM.DATA[Constants.startingentrance_yposition + (entranceID * 2)]);
				this.XPosition = (ushort) ((ROM.DATA[Constants.startingentrance_xposition + (entranceID * 2) + 1] << 8) + ROM.DATA[Constants.startingentrance_xposition + (entranceID * 2)]);
				this.CameraX = (ushort) ((ROM.DATA[Constants.startingentrance_camerax + (entranceID * 2) + 1] << 8) + ROM.DATA[Constants.startingentrance_camerax + (entranceID * 2)]);
				this.CameraY = (ushort) ((ROM.DATA[Constants.startingentrance_cameray + (entranceID * 2) + 1] << 8) + ROM.DATA[Constants.startingentrance_cameray + (entranceID * 2)]);
				this.CameraTriggerY = (ushort) ((ROM.DATA[Constants.startingentrance_cameraytrigger + (entranceID * 2) + 1] << 8) + ROM.DATA[Constants.startingentrance_cameraytrigger + (entranceID * 2)]);
				this.CameraTriggerX = (ushort) ((ROM.DATA[Constants.startingentrance_cameraxtrigger + (entranceID * 2) + 1] << 8) + ROM.DATA[Constants.startingentrance_cameraxtrigger + (entranceID * 2)]);
				this.Blockset = ROM.DATA[Constants.startingentrance_blockset + entranceID];
				this.Music = ROM.DATA[Constants.startingentrance_music + entranceID];
				this.DungeonID = ROM.DATA[Constants.startingentrance_dungeon + entranceID];
				this.Floor = ROM.DATA[Constants.startingentrance_floor + entranceID];
				this.Door = ROM.DATA[Constants.startingentrance_door + entranceID];
				this.LadderBG = ROM.DATA[Constants.startingentrance_ladderbg + entranceID];
				this.Scrolling = ROM.DATA[Constants.startingentrance_scrolling + entranceID];
				this.ScrollQuadrant = ROM.DATA[Constants.startingentrance_scrollquadrant + entranceID];
				this.Exit = (short) (((ROM.DATA[Constants.startingentrance_exit + (entranceID * 2) + 1] & 0x01) << 8) + ROM.DATA[Constants.startingentrance_exit + (entranceID * 2)]);
				this.CameraBoundaryQN = ROM.DATA[Constants.startingentrance_scrolledge + 0 + (entranceID * 8)];
				this.CameraBoundaryFN = ROM.DATA[Constants.startingentrance_scrolledge + 1 + (entranceID * 8)];
				this.CameraBoundaryQS = ROM.DATA[Constants.startingentrance_scrolledge + 2 + (entranceID * 8)];
				this.CameraBoundaryFS = ROM.DATA[Constants.startingentrance_scrolledge + 3 + (entranceID * 8)];
				this.CameraBoundaryQW = ROM.DATA[Constants.startingentrance_scrolledge + 4 + (entranceID * 8)];
				this.CameraBoundaryFW = ROM.DATA[Constants.startingentrance_scrolledge + 5 + (entranceID * 8)];
				this.CameraBoundaryQE = ROM.DATA[Constants.startingentrance_scrolledge + 6 + (entranceID * 8)];
				this.CameraBoundaryFE = ROM.DATA[Constants.startingentrance_scrolledge + 7 + (entranceID * 8)];
			}
		}

		/// <summary>
		///     Saves the entrance to the ROM.
		/// </summary>
		/// <param name="entranceID"> The entrance ID. </param>
		/// <param name="isSpawnPoint"> Whether the entrance is a spawn point or not. </param>
		public void Save(int entranceID, bool isSpawnPoint = false)
		{
			if (!isSpawnPoint)
			{
				ROM.WriteShort(Constants.entrance_room + (entranceID * 2), this.Room, WriteType.EntranceProperties);
				ROM.WriteShort(Constants.entrance_yposition + (entranceID * 2), this.YPosition, WriteType.EntranceProperties);
				ROM.WriteShort(Constants.entrance_xposition + (entranceID * 2), this.XPosition, WriteType.EntranceProperties);
				ROM.WriteShort(Constants.entrance_cameray + (entranceID * 2), this.CameraY, WriteType.EntranceProperties);
				ROM.WriteShort(Constants.entrance_camerax + (entranceID * 2), this.CameraX, WriteType.EntranceProperties);
				ROM.WriteShort(Constants.entrance_cameraxtrigger + (entranceID * 2), this.CameraTriggerX, WriteType.EntranceProperties);
				ROM.WriteShort(Constants.entrance_cameraytrigger + (entranceID * 2), this.CameraTriggerY, WriteType.EntranceProperties);

				ROM.WriteShort(Constants.entrance_exit + (entranceID * 2), Exit, WriteType.EntranceProperties);
				ROM.Write(Constants.entrance_blockset + entranceID, Blockset, WriteType.EntranceProperties);
				ROM.Write(Constants.entrance_music + entranceID, Music, WriteType.EntranceProperties);
				ROM.Write(Constants.entrance_dungeon + entranceID, DungeonID, WriteType.EntranceProperties);
				ROM.Write(Constants.entrance_door + entranceID, Door, WriteType.EntranceProperties);
				ROM.Write(Constants.entrance_floor + entranceID, Floor, WriteType.EntranceProperties);
				ROM.Write(Constants.entrance_ladderbg + entranceID, LadderBG, WriteType.EntranceProperties);
				ROM.Write(Constants.entrance_scrolling + entranceID, Scrolling, WriteType.EntranceProperties);
				ROM.Write(Constants.entrance_scrollquadrant + entranceID, ScrollQuadrant, WriteType.EntranceProperties);

				ROM.Write(Constants.entrance_scrolledge + 0 + (entranceID * 8), this.CameraBoundaryQN, WriteType.EntranceProperties);
				ROM.Write(Constants.entrance_scrolledge + 1 + (entranceID * 8), this.CameraBoundaryFN, WriteType.EntranceProperties);
				ROM.Write(Constants.entrance_scrolledge + 2 + (entranceID * 8), this.CameraBoundaryQS, WriteType.EntranceProperties);
				ROM.Write(Constants.entrance_scrolledge + 3 + (entranceID * 8), this.CameraBoundaryFS, WriteType.EntranceProperties);
				ROM.Write(Constants.entrance_scrolledge + 4 + (entranceID * 8), this.CameraBoundaryQW, WriteType.EntranceProperties);
				ROM.Write(Constants.entrance_scrolledge + 5 + (entranceID * 8), this.CameraBoundaryFW, WriteType.EntranceProperties);
				ROM.Write(Constants.entrance_scrolledge + 6 + (entranceID * 8), this.CameraBoundaryQE, WriteType.EntranceProperties);
				ROM.Write(Constants.entrance_scrolledge + 7 + (entranceID * 8), this.CameraBoundaryFE, WriteType.EntranceProperties);
			}
			else
			{
				ROM.WriteShort(Constants.startingentrance_room + (entranceID * 2), this.Room, WriteType.SpawnProperties);
				ROM.WriteShort(Constants.startingentrance_yposition + (entranceID * 2), this.YPosition, WriteType.SpawnProperties);
				ROM.WriteShort(Constants.startingentrance_xposition + (entranceID * 2), this.XPosition, WriteType.SpawnProperties);
				ROM.WriteShort(Constants.startingentrance_cameray + (entranceID * 2), this.CameraY, WriteType.SpawnProperties);
				ROM.WriteShort(Constants.startingentrance_camerax + (entranceID * 2), this.CameraX, WriteType.SpawnProperties);
				ROM.WriteShort(Constants.startingentrance_cameraxtrigger + (entranceID * 2), this.CameraTriggerX, WriteType.SpawnProperties);
				ROM.WriteShort(Constants.startingentrance_cameraytrigger + (entranceID * 2), this.CameraTriggerY, WriteType.SpawnProperties);
				ROM.WriteShort(Constants.startingentrance_exit + (entranceID * 2), this.Exit, WriteType.SpawnProperties);

				ROM.Write(Constants.startingentrance_blockset + entranceID, Blockset, WriteType.SpawnProperties);
				ROM.Write(Constants.startingentrance_music + entranceID, Music, WriteType.SpawnProperties);
				ROM.Write(Constants.startingentrance_dungeon + entranceID, DungeonID, WriteType.SpawnProperties);
				ROM.Write(Constants.startingentrance_door + entranceID, Door, WriteType.SpawnProperties);
				ROM.Write(Constants.startingentrance_floor + entranceID, Floor, WriteType.SpawnProperties);
				ROM.Write(Constants.startingentrance_ladderbg + entranceID, LadderBG, WriteType.SpawnProperties);
				ROM.Write(Constants.startingentrance_scrolling + entranceID, Scrolling, WriteType.SpawnProperties);
				ROM.Write(Constants.startingentrance_scrollquadrant + entranceID, ScrollQuadrant, WriteType.SpawnProperties);
				ROM.Write(Constants.startingentrance_scrolledge + 0 + (entranceID * 8), this.CameraBoundaryQN, WriteType.SpawnProperties);
				ROM.Write(Constants.startingentrance_scrolledge + 1 + (entranceID * 8), this.CameraBoundaryFN, WriteType.SpawnProperties);
				ROM.Write(Constants.startingentrance_scrolledge + 2 + (entranceID * 8), this.CameraBoundaryQS, WriteType.SpawnProperties);
				ROM.Write(Constants.startingentrance_scrolledge + 3 + (entranceID * 8), this.CameraBoundaryFS, WriteType.SpawnProperties);
				ROM.Write(Constants.startingentrance_scrolledge + 4 + (entranceID * 8), this.CameraBoundaryQW, WriteType.SpawnProperties);
				ROM.Write(Constants.startingentrance_scrolledge + 5 + (entranceID * 8), this.CameraBoundaryFW, WriteType.SpawnProperties);
				ROM.Write(Constants.startingentrance_scrolledge + 6 + (entranceID * 8), this.CameraBoundaryQE, WriteType.SpawnProperties);
				ROM.Write(Constants.startingentrance_scrolledge + 7 + (entranceID * 8), this.CameraBoundaryFE, WriteType.SpawnProperties);
			}
		}
	}
}
