﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{

    public static class Room_Name
    {
        public static void loadFromFile(string file = "DefaultNames.txt")
        {
            string[] s = File.ReadAllLines(file);
            int l = 0;
            bool found = false;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == "[Rooms Names]")
                {
                    l = 0;
                    found = true;
                    continue;
                }

                if (found)
                {
                    if (s[i].Length > 0)
                    {
                        if (s[i][0] == '/' && s[i][1] == '/')
                        {
                            continue;
                        }
                        if (l >= 0x4B)
                        {
                            break;
                        }

                        room_name[l] = s[i];
                        l++;
                    }
                }
            }
        }

        public static string[] room_name = new string[]
        {
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
            "Smith Peg Cave"
        };
    }
}
