using System.Collections.Generic;

namespace ZeldaFullEditor
{
	public static class ROMStructure
	{
		public static string ProjectVersion = "v1.0";
		public static string ProjectName = "";
		public static string GameVersion = "us";

		// This class will be used to create a project file from a ROM, since ROM Size can be dynamic
		// The format data of the project will be first and the rom will be saved at the position 0x200000

		// ZScream Project <- static string to recognize the format
		// Constant Version <- dynamic string
		// Project Name - dynamic string
		// Game Version used - 2byte string
		// NO SIZE - Default Size will be 4mb
		// Dungeons Names - dynamic strings 17 dungeons?
		// Dungeons Rooms - short (2byte) * 17 - 34bytes
		// Rooms Names - 296 dynamic strings

		public static string[] dungeonsNames = new string[17];
		public static string[] roomsNames;
		public static string[] mapsNames;
		public static short[][] dungeonsRooms = new short[17][];
		public static List<DataRoom> dungeonsRoomList = new List<DataRoom>();

		// TODO move to default entities
		public static void defaultDungeonNames()
		{
			dungeonsNames[0] = "Sewers";
			dungeonsNames[1] = "Castle";
			dungeonsNames[2] = "Eastern Palace";
			dungeonsNames[3] = "Desert Palace";
			dungeonsNames[4] = "Agahnim Tower";
			dungeonsNames[5] = "Swamp Palace";
			dungeonsNames[6] = "Palace of Darkness";
			dungeonsNames[7] = "Misery Mire";
			dungeonsNames[8] = "Skull Woods";
			dungeonsNames[9] = "Ice Palace";
			dungeonsNames[10] = "Tower of Hera";
			dungeonsNames[11] = "Thieve Town";
			dungeonsNames[12] = "Turtle Rock";
			dungeonsNames[13] = "Ganon Tower";
			dungeonsNames[14] = "Unused1";
			dungeonsNames[15] = "Unused2";
			dungeonsNames[16] = "Caves and Houses";
		}

		public static void defaultDungeonRooms()
		{
			// 29,30,31,32,33,34
			dungeonsRooms[0] = new short[] { 2, 17, 18, 33, 34, 50, 65, 66 }; // Sewer
			dungeonsRooms[1] = new short[] { 1, 80, 81, 82, 85, 96, 97, 98, 112, 113, 114, 128, 129, 130 };
			dungeonsRooms[2] = new short[] { 137, 153, 168, 169, 170, 184, 185, 186, 200, 201, 216, 217, 218 };
			dungeonsRooms[3] = new short[] { 51, 67, 83, 99, 115, 116, 117, 131, 132, 133 };
			dungeonsRooms[4] = new short[] { 48, 32, 64, 176, 192, 208, 224 }; // Agah
			dungeonsRooms[5] = new short[] { 6, 22, 38, 40, 52, 53, 54, 55, 56, 70, 84, 102, 118 };
			dungeonsRooms[6] = new short[] { 9, 10, 11, 25, 26, 27, 42, 43, 58, 59, 74, 75, 90, 106 };
			dungeonsRooms[7] = new short[] { 144, 145, 146, 147, 151, 152, 160, 161, 162, 163, 177, 178, 179, 193, 194, 195, 209, 210 };
			dungeonsRooms[8] = new short[] { 41, 57, 73, 86, 87, 88, 89, 103, 104 };
			dungeonsRooms[9] = new short[] { 14, 30, 31, 46, 62, 63, 78, 79, 94, 95, 110, 126, 127, 142, 158, 159, 174, 175, 190, 191, 206, 222 };
			dungeonsRooms[10] = new short[] { 7, 23, 39, 49, 119, 135, 167 };
			dungeonsRooms[11] = new short[] { 68, 69, 100, 101, 171, 172, 187, 188, 203, 204, 219, 220 };
			dungeonsRooms[12] = new short[] { 4, 19, 20, 21, 35, 36, 164, 180, 181, 182, 183, 196, 197, 198, 199, 213, 214 };
			dungeonsRooms[13] = new short[] { 12, 13, 28, 29, 61, 76, 77, 91, 92, 93, 107, 108, 109, 123, 124, 125, 139, 140, 141, 149, 150, 155, 156, 157, 165, 166 };
			dungeonsRooms[14] = new short[] { };
			dungeonsRooms[15] = new short[] { };
			dungeonsRooms[16] = new short[] { 0, 3, 8, 16, 24, 44, 47, 60, 223, 225, 226, 227, 228, 229, 230, 231, 232, 234, 235, 237, 238, 239, 240, 241,
				248, 249, 250, 251, 253, 254, 255, 266, 267, 268, 269, 270, 274, 275, 276, 277, 278, 279, 283, 286, 288, 291, 292, 293, 294, 295, 242, 243,
				244, 245, 256, 257, 258, 259, 260, 261, 262, 263, 264, 265, 271, 272, 273, 280, 281, 282, 284, 285, 287, 5, 15, 37, 45, 71, 72, 105, 111, 120,
				121, 122, 134, 136, 138, 143, 148, 154, 173, 189, 202, 205, 207, 211, 212, 215, 221, 233, 236, 246, 247, 252,289,290 };

			for (int i = 0; i < 17; i++) // for all dungeons add rooms in list
			{
				for (int j = 0; j < dungeonsRooms[i].Length; j++)
				{
					dungeonsRoomList.Add(new DataRoom(dungeonsRooms[i][j], (byte) i, roomsNames[dungeonsRooms[i][j]]));
				}
			}
		}

		// TODO move to DefaultEntities
		public static void defaultRoomsNames()
		{
			roomsNames = new string[]{
				"Ganon","Hyrule Castle (North Corridor)","Behind Sanctuary (Switch)",
				"Houlihan","Turtle Rock (Crysta-Roller)",
				"Empty","Swamp Palace (Arrghus[Boss])",
				"Tower of Hera (Moldorm[Boss])","Cave (Healing Fairy)","Palace of Darkness",
				"Palace of Darkness (Stalfos Trap)","Palace of Darkness (Turtle)","Ganon's Tower (Entrance)",
				"Ganon's Tower (Agahnim2[Boss])","Ice Palace (Entrance )","Empty Clone ",
				"Ganon Evacuation Route","Hyrule Castle (Bombable Stock )",
				"Sanctuary","Turtle Rock (Hokku-Bokku Key 2)","Turtle Rock (Big Key )",
				"Turtle Rock","Swamp Palace (Swimming Treadmill)","Tower of Hera (Moldorm Fall )",
				"Cave","Palace of Darkness (Dark Maze)","Palace of Darkness (Big Chest )",
				"Palace of Darkness (Mimics / Moving Wall )","Ganon's Tower (Ice Armos)","Ganon's Tower (Final Hallway)",
				"Ice Palace (Bomb Floor / Bari )","Ice Palace (Pengator / Big Key )","Agahnim's Tower (Agahnim[Boss])",
				"Hyrule Castle (Key-rat )","Hyrule Castle (Sewer Text Trigger )","Turtle Rock (West Exit to Balcony)",
				"Turtle Rock (Double Hokku-Bokku / Big chest )","Empty Clone ","Swamp Palace (Statue )",
				"Tower of Hera (Big Chest)","Swamp Palace (Entrance )","Skull Woods (Mothula[Boss])",
				"Palace of Darkness (Big Hub )","Palace of Darkness (Map Chest / Fairy )","Cave",
				"Empty Clone ","Ice Palace (Compass )","Cave (Kakariko Well HP)",
				"Agahnim's Tower (Maiden Sacrifice Chamber)","Tower of Hera (Hardhat Beetles )","Hyrule Castle (Sewer Key Chest )",
				"Desert Palace (Lanmolas[Boss])","Swamp Palace (Push Block Puzzle / Pre-Big Key )","Swamp Palace (Big Key / BS )",
				"Swamp Palace (Big Chest )","Swamp Palace (Map Chest / Water Fill )","Swamp Palace (Key Pot )",
				"Skull Woods (Gibdo Key / Mothula Hole )","Palace of Darkness (Bombable Floor )",
				"Palace of Darkness (Spike Block / Conveyor )","Cave","Ganon's Tower (Torch 2)",
				"Ice Palace (Stalfos Knights / Conveyor Hellway)","Ice Palace (Map Chest )","Agahnim's Tower (Final Bridge )",
				"Hyrule Castle (First Dark )","Hyrule Castle (6 Ropes )","Desert Palace (Torch Puzzle / Moving Wall )",
				"Thieves Town (Big Chest )","Thieves Town (Jail Cells )","Swamp Palace (Compass Chest )",
				"Empty Clone ","Empty Clone ","Skull Woods (Gibdo Torch Puzzle )","Palace of Darkness (Entrance )",
				"Palace of Darkness (Warps / South Mimics )","Ganon's Tower (Mini-Helmasaur Conveyor )","Ganon's Tower (Moldorm )",
				"Ice Palace (Bomb-Jump )","Ice Palace Clone (Fairy )","Hyrule Castle (West Corridor)",
				"Hyrule Castle (Throne )","Hyrule Castle (East Corridor)","Desert Palace (Popos 2 / Beamos Hellway )",
				"Swamp Palace (Upstairs Pits )","Castle Secret Entrance / Uncle Death ","Skull Woods (Key Pot / Trap )",
				"Skull Woods (Big Key )","Skull Woods (Big Chest )","Skull Woods (Final Section Entrance )",
				"Palace of Darkness (Helmasaur King[Boss])","Ganon's Tower (Spike Pit )","Ganon's Tower (Ganon-Ball Z)",
				"Ganon's Tower (Gauntlet 1/2/3)","Ice Palace (Lonely Firebar)","Ice Palace (Hidden Chest / Spike Floor )",
				"Hyrule Castle (West Entrance )","Hyrule Castle (Main Entrance )","Hyrule Castle (East Entrance )",
				"Desert Palace (Final Section Entrance )","Thieves Town (West Attic )","Thieves Town (East Attic )",
				"Swamp Palace (Hidden Chest / Hidden Door )","Skull Woods (Compass Chest )","Skull Woods (Key Chest / Trap )",
				"Empty Clone ","Palace of Darkness (Rupee )","Ganon's Tower (Mimics s)","Ganon's Tower (Lanmolas )",
				"Ganon's Tower (Gauntlet 4/5)","Ice Palace (Pengators )","Empty Clone ","Hyrule Castle (Small Corridor to Jail Cells)",
				"Hyrule Castle (Boomerang Chest )","Hyrule Castle (Map Chest )","Desert Palace (Big Chest )",
				"Desert Palace (Map Chest )","Desert Palace (Big Key Chest )","Swamp Palace (Water Drain )",
				"Tower of Hera (Entrance )","Empty Clone ","Empty Clone ","Empty Clone ",
				"Ganon's Tower","Ganon's Tower (East Side Collapsing Bridge / Exploding Wall )","Ganon's Tower (Winder / Warp Maze )",
				"Ice Palace (Hidden Chest / Bombable Floor )","Ice Palace ( Big Spike Traps )","Hyrule Castle (Jail Cell )",
				"Hyrule Castle","Hyrule Castle (Basement Chasm )","Desert Palace (West Entrance )","Desert Palace (Main Entrance )",
				"Desert Palace (East Entrance )","Empty Clone ","Tower of Hera (Tile )","Empty Clone ",
				"Eastern Palace (Fairy )","Empty Clone ","Ganon's Tower (Block Puzzle / Spike Skip / Map Chest )",
				"Ganon's Tower (East and West Downstairs / Big Chest )","Ganon's Tower (Tile / Torch Puzzle )","Ice Palace",
				"Empty Clone ","Misery Mire (Vitreous[Boss])","Misery Mire (Final Switch )","Misery Mire (Dark Bomb Wall / Switches )",
				"Misery Mire (Dark Cane Floor Switch Puzzle )","Empty Clone ","Ganon's Tower (Final Collapsing Bridge )",
				"Ganon's Tower (Torches 1 )","Misery Mire (Torch Puzzle / Moving Wall )","Misery Mire (Entrance )",
				"Eastern Palace (Eyegore Key )","Empty Clone ","Ganon's Tower (Many Spikes / Warp Maze )",
				"Ganon's Tower (Invisible Floor Maze )","Ganon's Tower (Compass Chest / Invisible Floor )",
				"Ice Palace (Big Chest )","Ice Palace","Misery Mire (Pre-Vitreous )","Misery Mire (Fish )",
				"Misery Mire (Bridge Key Chest )","Misery Mire","Turtle Rock (Trinexx[Boss])","Ganon's Tower (Wizzrobes s)",
				"Ganon's Tower (Moldorm Fall )","Tower of Hera (Fairy )","Eastern Palace (Stalfos Spawn )",
				"Eastern Palace (Big Chest )","Eastern Palace (Map Chest )","Thieves Town (Moving Spikes / Key Pot )",
				"Thieves Town (Blind The Thief[Boss])","Empty Clone ","Ice Palace","Ice Palace (Ice Bridge )",
				"Agahnim's Tower (Circle of Pots)","Misery Mire (Hourglass )","Misery Mire (Slug )",
				"Misery Mire (Spike Key Chest )","Turtle Rock (Pre-Trinexx )","Turtle Rock (Dark Maze)",
				"Turtle Rock (Chain Chomps )","Turtle Rock (Map Chest / Key Chest / Roller )","Eastern Palace (Big Key )",
				"Eastern Palace (Lobby Cannonballs )","Eastern Palace (Dark Antifairy / Key Pot )","Thieves Town (Hellway)","Thieves Town (Conveyor Toilet)",
				"Empty Clone ","Ice Palace (Block Puzzle )","Ice Palace Clone (Switch )",
				"Agahnim's Tower (Dark Bridge )","Misery Mire (Compass Chest / Tile )","Misery Mire (Big Hub )",
				"Misery Mire (Big Chest )","Turtle Rock (Final Crystal Switch Puzzle )","Turtle Rock (Laser Bridge)",
				"Turtle Rock","Turtle Rock (Torch Puzzle)","Eastern Palace (Armos Knights[Boss])","Eastern Palace (Entrance )",
				"??","Thieves Town (North West Entrance )","Thieves Town (North East Entrance )",
				"Empty Clone ","Ice Palace (Hole to Kholdstare )","Empty Clone ","Agahnim's Tower (Dark Maze)",
				"Misery Mire (Conveyor Slug / Big Key )","Misery Mire (Mire02 / Wizzrobes )","Empty Clone ","Empty Clone ",
				"Turtle Rock (Laser Key )","Turtle Rock (Entrance )","Empty Clone ","Eastern Palace (Zeldagamer / Pre-Armos Knights )",
				"Eastern Palace (Canonball ","Eastern Palace","Thieves Town (Main (South West) Entrance )",
				"Thieves Town (South East Entrance )","Empty Clone ","Ice Palace (Kholdstare[Boss])",
				"Cave","Agahnim's Tower (Entrance )","Cave (Lost Woods HP)","Cave (Lumberjack's Tree HP)",
				"Cave (1/2 Magic)","Cave (Lost Old Man Final Cave)","Cave (Lost Old Man Final Cave)",
				"Cave","Cave","Cave","Empty Clone ","Cave (Spectacle Rock HP)",
				"Cave","Empty Clone ","Cave","Cave (Spiral Cave)","Cave (Crystal Switch / 5 Chests )",
				"Cave (Lost Old Man Starting Cave)","Cave (Lost Old Man Starting Cave)","House","House (Old Woman (Sahasrahla's Wife?))",
				"House (Angry Brothers)","House (Angry Brothers)","Empty Clone ","Empty Clone ",
				"Cave","Cave","Cave","Cave","Empty Clone ","Cave",
				"Cave","Cave",

				"Chest Minigame","Houses","Sick Boy house","Tavern","Link's House","Sarashrala Hut","Chest Minigame","Library",
				"Chicken House","Witch Shop","A Aginah's Cave","Dam","Mimic Cave","Mire Shed","Cave","Shop","Shop",
				"Archery Minigame","DW Church/Shop","Grave Cave","Fairy Fountain","Fairy Upgrade","Pyramid Fairy","Spike Cave",
				"Chest Minigame","Blind Hut","Bonzai Cave","Circle of bush Cave","Big Bomb Shop, C-House","Blind Hut 2","Hype Cave",
				"Shop","Ice Cave","Smith","Fortune Teller","MiniMoldorm Cave","Under Rock Caves","Smith","Cave","Mazeblock Cave",
				"Smith Peg Cave",
			};
		}

		public static void defaultMapsNames()
		{
			// DP = Duplicate
			mapsNames = new string[]{
                // LW
                "Lost Woods","DP","Lumberjack","DM Hera Tower","DP","DM Wall of Caves","DP","DM Turtle Rock",
				"DP","DP","Death Mountain Entrance","DP","DP","DP","DP","Hidden Waterfall",
				"Woods Entrance","Top of Kakariko","Whirlpool Lake","Sanctuary","Cemetery","River","Witch","Way to Zora",
				"Kakariko","DP","West of Castle","Castle","DP","Wooden Bridge","Eastern Palace","DP",
				"DP","DP","Blacksmith","DP","DP","Octoroks","DP","DP",
				"Race Game","Library","Flute Grove","West of Link's House","Link's House","Stone Bridge","Top of Hylia Lake","Flute #5",
				"Desert","DP","Grove Ledge","North of Dam","South of Links House","Lake Hylia","DP","Shopping Mall",
				"DP","DP","Purple Chest Guy","Dam","East of Dam","DP","DP","South East Hylia",

                // DW
                "Skulls Woods","DP","Lumberjack","DM Ganon Tower","DP","DM Wall of Caves","DP","DM Turtle Rock",
				"DP","DP","Death Mountain Entrance","DP","DP","DP","DP","Catfish",
				"Woods Entrance","Top of Village of Outcast","Lake","Sanctuary Cave","Cemetery","River","Witch","Way to Catfish",
				"Village of Outcast","DP","Lost Shop","Pyramid","DP","Wooden Bridge","Palace of Darkness","DP",
				"DP","DP","Smith House","DP","DP","Rocky Area","DP","DP",
				"Digging","Archery Minigame","Haunted Grove","West of Link's House","Links House","Peg Bridge","Top of Hylia Lake","Flute #5",
				"Misery Mire","DP","South of Grove","North of Swamp Palace","South of Link's House","Ice Palace","DP","Shopping Mall",
				"DP","DP","Purple Chest Guy","Swamp","East of Swamp","DP","DP","South East Ice Palace",

                // Specials
                "Master Sword/Under Bridge","Zora Domain","Unused","Unused","Unused","Unused","Unused","Unused",
				"Unused","Unused","Unused","Unused","Unused","Unused","Unused","Unused","Unused","Unused","Unused",

                // Backgrounds
                "Triforce Room", "Master Sword/Under Bridge Mask", "Death Mountain BGR", "Pyramid BGR", "Forest BGR",
				"Unused", "Unused", "Unused", "Unused", "???", "Cloud Overlay", "Tree Overlay", "Rain Overlay",
			};
		}

		public static void loadDefaultProject()
		{
			defaultDungeonNames();
			defaultRoomsNames();
			defaultMapsNames();
			defaultDungeonRooms();
		}
	}
}
