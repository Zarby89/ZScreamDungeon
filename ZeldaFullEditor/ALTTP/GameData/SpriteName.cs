﻿namespace ZeldaFullEditor.ALTTP.GameData;

public record SpriteName(int ID, string Name) : EntityName(ID, Name)
{
	public override string ToString() => $"{ID:X2} {Name}";

	public static readonly SpriteName[] ListOfSprites =
	{
		new(0x00, "Raven"),
		new(0x01, "Vulture"),
		new(0x02, "Stalfos head"),
		new(0x03, "Null"),
		new(0x04, "Correct pull switch"),
		new(0x05, "Correct pull switch (unused)"),
		new(0x06, "Wrong pull switch"),
		new(0x07, "Wrong pull switch (unused)"),
		new(0x08, "Octorok"),
		new(0x09, "Moldorm"),
		new(0x0A, "Octorok (4-way)"),
		new(0x0B, "Cucco"),
		new(0x0C, "Octorok stone"),
		new(0x0D, "Buzzblob"),
		new(0x0E, "Snapdragon"),
		new(0x0F, "Octoballoon"),
		new(0x10, "Octobaby"),
		new(0x11, "Hinox"),
		new(0x12, "Moblin"),
		new(0x13, "Mini helmasaur"),
		new(0x14, "Thieves' Town grate"),
		new(0x15, "Antifairy"),
		new(0x16, "Sahasrahla / Aginah"),
		new(0x17, "Hoarder"),
		new(0x18, "Mini moldorm"),
		new(0x19, "Poe"),
		new(0x1A, "Smithy"),
		new(0x1B, "Arrow"),
		new(0x1C, "Statue"),
		new(0x1D, "Flute quest"),
		new(0x1E, "Crystal switch"),
		new(0x1F, "Sick kid"),
		new(0x20, "Sluggula"),
		new(0x21, "Water switch"),
		new(0x22, "Ropa"),
		new(0x23, "Red bari"),
		new(0x24, "Blue bari"),
		new(0x25, "Talking tree"),
		new(0x26, "Hardhat beetle"),
		new(0x27, "Deadrock"),
		new(0x28, "Dark World hint"),
		new(0x29, "Adult"),
		new(0x2A, "Sweeping lady"),
		new(0x2B, "Hobo"),
		new(0x2C, "Lumberjacks"),
		new(0x2D, "Telepathic tile (unused)"),
		new(0x2E, "Flute kid"),
		new(0x2F, "Race game lady"),
		new(0x30, "Race game guy"),
		new(0x31, "Fortune teller"),
		new(0x32, "Argue bros"),
		new(0x33, "Rupee pull"),
		new(0x34, "Young snitch"),
		new(0x35, "Innkeeper"),
		new(0x36, "Witch"),
		new(0x37, "Waterfall"),
		new(0x38, "Eye statue"),
		new(0x39, "Locksmith"),
		new(0x3A, "Magic bat"),
		new(0x3B, "Bonk item"),
		new(0x3C, "Child"),
		new(0x3D, "Old snitch"),
		new(0x3E, "Hoarder"),
		new(0x3F, "Tutorial guard"),
		new(0x40, "Lightning gate"),
		new(0x41, "Blue guard"),
		new(0x42, "Green guard"),
		new(0x43, "Red spear guard"),
		new(0x44, "Charging blue guard"),
		new(0x45, "Charging red guard"),
		new(0x46, "Blue archer"),
		new(0x47, "Green bush guard"),
		new(0x48, "Red javelin guard"),
		new(0x49, "Red bush guard"),
		new(0x4A, "Bomb guard"),
		new(0x4B, "Green knife guard"),
		new(0x4C, "Geldman"),
		new(0x4D, "Toppo"),
		new(0x4E, "Popo"),
		new(0x4F, "Popo"),
		new(0x50, "Cannonball"),
		new(0x51, "Armos statue"),
		new(0x52, "King Zora"),
		new(0x53, "Armos Knight"),
		new(0x54, "Lanmolas"),
		new(0x55, "Zora (fire ball)"),
		new(0x56, "Zora"),
		new(0x57, "Desert statue"),
		new(0x58, "Crab"),
		new(0x59, "Lost woods bird"),
		new(0x5A, "Lost woods squirrel"),
		new(0x5B, "Spark (clockwise)"),
		new(0x5C, "Spark (counterclockwise)"),
		new(0x5D, "Roller (vertical, down)"),
		new(0x5E, "Roller (vertical, up)"),
		new(0x5F, "Roller (horizontal, right)"),
		new(0x60, "Roller (horizontal, left)"),
		new(0x61, "Beamos"),
		new(0x62, "Mastersword"),
		new(0x63, "Debirando"),
		new(0x64, "Debirando"),
		new(0x65, "Archery guy"),
		new(0x66, "Wall cannon (vertical, left)"),
		new(0x67, "Wall cannon (vertical, right)"),
		new(0x68, "Wall cannon (horizontal, top)"),
		new(0x69, "Wall cannon (horizontal, bottom)"),
		new(0x6A, "Ball n chain"),
		new(0x6B, "Cannon guard"),
		new(0x6C, "Mirror portal"),
		new(0x6D, "Rat / cricket"),
		new(0x6E, "Snake"),
		new(0x6F, "Keese"),
		new(0x70, "King Helmasaur fireball"),
		new(0x71, "Leever"),
		new(0x72, "Faerie pond trigger"),
		new(0x73, "Uncle / Priest"),
		new(0x74, "Running man"),
		new(0x75, "Bottle merchant"),
		new(0x76, "Zelda"),
		new(0x77, "Antifairy"),
		new(0x78, "Sahasrahla's wife"),
		new(0x79, "Bee"),
		new(0x7A, "Agahnim"),
		new(0x7B, "Agahnim's balls"),
		new(0x7C, "Green stalfos"),
		new(0x7D, "Big spike"),
		new(0x7E, "Firebar (clockwise)"),
		new(0x7F, "Firebar (counterclockwise)"),
		new(0x80, "Firesnake"),
		new(0x81, "Hover"),
		new(0x82, "Antifairy circle"),
		new(0x83, "Green eyegore/mimic"),
		new(0x84, "Red eyegore/mimic"),
		new(0x85, "Yellow stalfos"),
		new(0x86, "Kodongo"),
		new(0x87, "Kondongo fire"),
		new(0x88, "Mothula"),
		new(0x89, "Mothula beam"),
		new(0x8A, "Spike block"),
		new(0x8B, "Gibdo"),
		new(0x8C, "Arrghus"),
		new(0x8D, "Arrghi"),
		new(0x8E, "Terrorpin"),
		new(0x8F, "Blob"),
		new(0x90, "Wallmaster"),
		new(0x91, "Stalfos knight"),
		new(0x92, "King Helmasaur"),
		new(0x93, "Bumper"),
		new(0x94, "Pirogusu"),
		new(0x95, "Laser eye (left)"),
		new(0x96, "Laser eye (right)"),
		new(0x97, "Laser eye (top)"),
		new(0x98, "Laser eye (bottom)"),
		new(0x99, "Pengator"),
		new(0x9A, "Kyameron"),
		new(0x9B, "Wizzrobe"),
		new(0x9C, "Zoro"),
		new(0x9D, "Babasu"),
		new(0x9E, "Haunted grove ostritch"),
		new(0x9F, "Haunted grove rabbit"),
		new(0xA0, "Haunted grove bird"),
		new(0xA1, "Freezor"),
		new(0xA2, "Kholdstare"),
		new(0xA3, "Kholdstare's shell"),
		new(0xA4, "Falling ice"),
		new(0xA5, "Blue zazak"),
		new(0xA6, "Red zazak"),
		new(0xA7, "Stalfos"),
		new(0xA8, "Green zirro"),
		new(0xA9, "Blue zirro"),
		new(0xAA, "Pikit"),
		new(0xAB, "Crystal maiden"),
		new(0xAC, "Apple"),
		new(0xAD, "Old man"),
		new(0xAE, "Pipe (down)"),
		new(0xAF, "Pipe (up)"),
		new(0xB0, "Pipe (right)"),
		new(0xB1, "Pipe (left)"),
		new(0xB2, "Good bee"),
		new(0xB3, "Pedestal plaque"),
		new(0xB4, "Purple chest"),
		new(0xB5, "Bomb shop guy"),
		new(0xB6, "Kiki"),
		new(0xB7, "Blind maiden"),
		new(0xB8, "Dialogue tester"),
		new(0xB9, "Bully / pink ball"),
		new(0xBA, "Whirlpool"),
		new(0xBB, "Shopkeeper"),
		new(0xBC, "Drunkard"),
		new(0xBD, "Vitreous"),
		new(0xBE, "Vitreous small eye"),
		new(0xBF, "Lightning"),
		new(0xC0, "Catfish"),
		new(0xC1, "Cutscene Agahnim"),
		new(0xC2, "Boulder"),
		new(0xC3, "Gibo"),
		new(0xC4, "Thief"),
		new(0xC5, "Medusa"),
		new(0xC6, "4-way shooter"),
		new(0xC7, "Pokey"),
		new(0xC8, "Big faerie"),
		new(0xC9, "Tektite"),
		new(0xCA, "Chain chomp"),
		new(0xCB, "Trinexx rock head"),
		new(0xCC, "Trinexx fire head"),
		new(0xCD, "Trinexx ice head"),
		new(0xCE, "Blind"),
		new(0xCF, "Swamola"),
		new(0xD0, "Lynel"),
		new(0xD1, "Bunnybeam (UW) / Smoke (OW)"),
		new(0xD2, "Flopping fish"),
		new(0xD3, "Stal"),
		new(0xD4, "Landmine"),
		new(0xD5, "Dig game guy"),
		new(0xD6, "Ganon"),
		new(0xD7, "Ganon"),
		new(0xD8, "Heart"),
		new(0xD9, "Green rupee"),
		new(0xDA, "Blue rupee"),
		new(0xDB, "Red rupee"),
		new(0xDC, "Bomb refill (1)"),
		new(0xDD, "Bomb refill (4)"),
		new(0xDE, "Bomb refill (8)"),
		new(0xDF, "Small magic decanter"),
		new(0xE0, "Large magic decanter"),
		new(0xE1, "Arrow refill (5)"),
		new(0xE2, "Arrow refill (10)"),
		new(0xE3, "Faerie"),
		new(0xE4, "Small key"),
		new(0xE5, "Big key"),
		new(0xE6, "Stolen shield"),
		new(0xE7, "Mushroom"),
		new(0xE8, "Fake master sword"),
		new(0xE9, "Magic shop assistant"),
		new(0xEA, "Heart container"),
		new(0xEB, "Heart piece"),
		new(0xEC, "Thrown item"),
		new(0xED, "Somaria platform"),
		new(0xEE, "Castle mantle"),
		new(0xEF, "Somaria platform (unused)"),
		new(0xF0, "Somaria platform (unused)"),
		new(0xF1, "Somaria platform (unused)"),
		new(0xF2, "Medallion tablet"),
		new(0xF3, "Position target (OW)"),
		new(0xF4, "Boulders (OW)")
	};

	public static readonly SpriteName[] ListOfOverlords =
	{
		new(0x00, "Nothing"),
		new(0x01, "Position target"),
		new(0x02, "Full room cannons"),
		new(0x03, "Vertical cannon"),
		new(0x04, "Stalfos spawner"),
		new(0x05, "Falling stalfos"),
		new(0x06, "Bad switch snake"),
		new(0x07, "Moving floor"),
		new(0x08, "Blob spawner"),
		new(0x09, "Wallmaster"),
		new(0x0A, "Falling square"),
		new(0x0B, "Falling bridge"),
		new(0x0C, "Falling tiles west to easth"),
		new(0x0D, "Falling tiles north to south"),
		new(0x0E, "Falling tiles east to west"),
		new(0x0F, "Falling tiles south to north"),
		new(0x10, "Pirogusu spawner left"),
		new(0x11, "Pirogusu spawner right"),
		new(0x12, "Pirogusu spawner top"),
		new(0x13, "Pirogusu spawner bottom"),
		new(0x14, "Tile room"),
		new(0x15, "Wizzrobe spawner"),
		new(0x16, "Zoro spawner"),
		new(0x17, "Pot trap"),
		new(0x18, "Invisible stalfos"),
		new(0x19, "Armos coordinator"),
		new(0x1A, "Bad switch bomb"),
	};

}