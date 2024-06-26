﻿using System;
using System.IO;

namespace ZeldaFullEditor
{
    [Serializable]
    public static class ChestItems_Name
    {
        public static void loadFromFile(string file = "DefaultNames.txt")
        {
            string[] s = File.ReadAllLines(file);
            int l = 0;
            bool found = false;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == "[Chests Items]")
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
                        name[l] = s[i];
                        l++;
                    }
                }
            }
        }

        public static string[] name = new string[]{
            "L1SwordAndShield",
            "L2 master Sword",
            "L3 tempered Sword",
            "L4 butter Sword",
            "Blue Shield",
            "Red Shield",
            "Mirror Shield",
            "Fire Rod",
            "Ice Rod",
            "Hammer",
            "Hookshot",
            "Bow",
            "Blue Boomerang",
            "Powder",
            "Bee for bottle (no bottle)",
            "Bombos",
            "Ether",
            "Quake",
            "Lamp",
            "Shovel",
            "Ocarina Inactive",
            "Cane of Somaria",
            "Bottle",
            "Piece of Heart",
            "Cane of Byrna",
            "Magic Cape",
            "Magic Mirror",
            "Power Gloves",
            "Titans Mitt",
            "Book of Mudora", // 29
            "Flippers",
            "Moon Pearl",
            "Crystal - Crash Game",
            "Bug Net",
            "Blue Mail",
            "Red Mail",
            "Key",
            "Compass",
            "Heart Container no dialog",
            "Bomb",
            "3 Bombs", // 40
            "Mushroom",
            "Red Boomerang",
            "Bottle with Red Potion", // 43
            "Bottle with Green Potion",
            "Bottle with Blue Potion",
            "Red Potion - fill bottle",
            "Green Potion - fill bottle",
            "Blue Potion - fill bottle",
            "10 Bombs",
            "Big Key",
            "Map",
            "1 Rupee",
            "5 Rupees",
            "20 Rupees",
            "Pendant of Courage",
            "Pendant of Wisdom",
            "Pendant of Power",
            "Bow And Arrows",
            "Bow And Silver Arrows",
            "Bottle With Bee",
            "Bottle With Fairy",
            "Boss Heart",
            "Sanc Heart",
            "100 Rupees",
            "50 Rupees",
            "Heart",
            "1 Arrow",
            "10 Arrows",
            "Small Magic",
            "300 Rupees",
            "20 Rupee2",
            "Bottle with Gold Bee",
            "L1 fighter Sword",
            "Ocarina Active",
            "Pegasus Boots", // 75
            "Max Bombs(VT)",
            "Max Arrows(VT)",
            "Half Magic(VT)",
            "Quarter Magic(VT)",
            "L2 master Sword (VT)",
            "+5 max bombs(VT)",
            "+10 max bombs(VT)",
            "+5 max arrows(VT)",
            "+10 max arrows(VT)",
            "Trap1(VT)",
            "Trap2(VT)",
            "Trap3(VT)",
            "Silver Arrows(VT)",
            "Rupoor(VT)",
            "Null Item?(VT)",
            "Red Clock(VT)",
            "Blue Clock(VT)",
            "Green Clock(VT)",
            "Progressive Sword(VT)",
            "Progressive Shield(VT)",
            "Progressive Armor(VT)",
            "Progressive Lifting Glove(VT)",
            "RNG Pool Item (Single)(VT)",
            "RNG Pool Item (Multi)(VT)" ,// 99
            "","","","","","","",
            "Goal Item (Single/Triforce)(VT)", //
            "Goal Item (Multi/Power Star)(VT)", // 6B
            "","","",
            "Escape Map(VT)",
            "Hyrule Castle Map(VT)",
            "Eastern Map(VT)",
            "Desert Map",
            "Hyrule Castle2 Map(VT)",
            "Swamp Map(VT)",
            "Dark Map(VT)",
            "Mire Map(VT)",
            "Skull Map(VT)",
            "Ice Map(VT)",
            "Hera Map(VT)",
            "Thieve Map(VT)",
            "Turtle Map(VT)",
            "GanonTower Map(VT)",
            "??? Map(VT)",
            "??? Map(VT)",
            "Escape Compass(VT)",
            "Hyrule Castle Compass(VT)",
            "Eastern Compass(VT)",
            "Desert Compass(VT)",
            "Hyrule Castle2 Compass(VT)",
            "Swamp Compass(VT)",
            "Dark Compass(VT)",
            "Mire Compass(VT)",
            "Skull Compass(VT)",
            "Ice Compass(VT)",
            "Hera Compass(VT)",
            "Thieve Compass(VT)",
            "Turtle Compass(VT)",
            "GanonTower Compass(VT)",
            "??? Compass(VT)",
            "??? Compass(VT)",
            "Escape Big Key(VT)",
            "Hyrule Castle Big Key(VT)",
            "Eastern Big Key(VT)",
            "Desert Big Key(VT)",
            "Hyrule Castle2 Big Key(VT)",
            "Swamp Big Key(VT)",
            "Dark Big Key(VT)",
            "Mire Big Key(VT)",
            "Skull Big Key(VT)",
            "Ice Big Key(VT)",
            "Hera Big Key(VT)",
            "Thieve Big Key(VT)",
            "Turtle Big Key(VT)",
            "GanonTower Big Key(VT)",
            "??? Big Key(VT)",
            "??? Big Key(VT)",
            "Escape Key(VT)",
            "Hyrule Castle Key(VT)",
            "Eastern Key(VT)",
            "Desert Key(VT)",
            "Hyrule Castle2 Key(VT)",
            "Swamp Key(VT)",
            "Dark Key(VT)",
            "Mire Key(VT)",
            "Skull Key(VT)",
            "Ice Key(VT)",
            "Hera Key(VT)",
            "Thieve Key(VT)",
            "Turtle Key(VT)",
            "GanonTower Key(VT)",
            "??? Key(VT)",
            "??? Key(VT)"
        };



        public static string[] Defaultnames = new string[]{
            "L1SwordAndShield",
            "L2 master Sword",
            "L3 tempered Sword",
            "L4 butter Sword",
            "Blue Shield",
            "Red Shield",
            "Mirror Shield",
            "Fire Rod",
            "Ice Rod",
            "Hammer",
            "Hookshot",
            "Bow",
            "Blue Boomerang",
            "Powder",
            "Bee for bottle (no bottle)",
            "Bombos",
            "Ether",
            "Quake",
            "Lamp",
            "Shovel",
            "Ocarina Inactive",
            "Cane of Somaria",
            "Bottle",
            "Piece of Heart",
            "Cane of Byrna",
            "Magic Cape",
            "Magic Mirror",
            "Power Gloves",
            "Titans Mitt",
            "Book of Mudora", // 29
            "Flippers",
            "Moon Pearl",
            "Crystal - Crash Game",
            "Bug Net",
            "Blue Mail",
            "Red Mail",
            "Key",
            "Compass",
            "Heart Container no dialog",
            "Bomb",
            "3 Bombs", // 40
            "Mushroom",
            "Red Boomerang",
            "Bottle with Red Potion", // 43
            "Bottle with Green Potion",
            "Bottle with Blue Potion",
            "Red Potion - fill bottle",
            "Green Potion - fill bottle",
            "Blue Potion - fill bottle",
            "10 Bombs",
            "Big Key",
            "Map",
            "1 Rupee",
            "5 Rupees",
            "20 Rupees",
            "Pendant of Courage",
            "Pendant of Wisdom",
            "Pendant of Power",
            "Bow And Arrows",
            "Bow And Silver Arrows",
            "Bottle With Bee",
            "Bottle With Fairy",
            "Boss Heart",
            "Sanc Heart",
            "100 Rupees",
            "50 Rupees",
            "Heart",
            "1 Arrow",
            "10 Arrows",
            "Small Magic",
            "300 Rupees",
            "20 Rupee2",
            "Bottle with Gold Bee",
            "L1 fighter Sword",
            "Ocarina Active",
            "Pegasus Boots", // 75
            "Max Bombs(VT)",
            "Max Arrows(VT)",
            "Half Magic(VT)",
            "Quarter Magic(VT)",
            "L2 master Sword (VT)",
            "+5 max bombs(VT)",
            "+10 max bombs(VT)",
            "+5 max arrows(VT)",
            "+10 max arrows(VT)",
            "Trap1(VT)",
            "Trap2(VT)",
            "Trap3(VT)",
            "Silver Arrows(VT)",
            "Rupoor(VT)",
            "Null Item?(VT)",
            "Red Clock(VT)",
            "Blue Clock(VT)",
            "Green Clock(VT)",
            "Progressive Sword(VT)",
            "Progressive Shield(VT)",
            "Progressive Armor(VT)",
            "Progressive Lifting Glove(VT)",
            "RNG Pool Item (Single)(VT)",
            "RNG Pool Item (Multi)(VT)" ,// 99
            "","","","","","","",
            "Goal Item (Single/Triforce)(VT)", //
            "Goal Item (Multi/Power Star)(VT)", // 6B
            "","","",
            "Escape Map(VT)",
            "Hyrule Castle Map(VT)",
            "Eastern Map(VT)",
            "Desert Map",
            "Hyrule Castle2 Map(VT)",
            "Swamp Map(VT)",
            "Dark Map(VT)",
            "Mire Map(VT)",
            "Skull Map(VT)",
            "Ice Map(VT)",
            "Hera Map(VT)",
            "Thieve Map(VT)",
            "Turtle Map(VT)",
            "GanonTower Map(VT)",
            "??? Map(VT)",
            "??? Map(VT)",
            "Escape Compass(VT)",
            "Hyrule Castle Compass(VT)",
            "Eastern Compass(VT)",
            "Desert Compass(VT)",
            "Hyrule Castle2 Compass(VT)",
            "Swamp Compass(VT)",
            "Dark Compass(VT)",
            "Mire Compass(VT)",
            "Skull Compass(VT)",
            "Ice Compass(VT)",
            "Hera Compass(VT)",
            "Thieve Compass(VT)",
            "Turtle Compass(VT)",
            "GanonTower Compass(VT)",
            "??? Compass(VT)",
            "??? Compass(VT)",
            "Escape Big Key(VT)",
            "Hyrule Castle Big Key(VT)",
            "Eastern Big Key(VT)",
            "Desert Big Key(VT)",
            "Hyrule Castle2 Big Key(VT)",
            "Swamp Big Key(VT)",
            "Dark Big Key(VT)",
            "Mire Big Key(VT)",
            "Skull Big Key(VT)",
            "Ice Big Key(VT)",
            "Hera Big Key(VT)",
            "Thieve Big Key(VT)",
            "Turtle Big Key(VT)",
            "GanonTower Big Key(VT)",
            "??? Big Key(VT)",
            "??? Big Key(VT)",
            "Escape Key(VT)",
            "Hyrule Castle Key(VT)",
            "Eastern Key(VT)",
            "Desert Key(VT)",
            "Hyrule Castle2 Key(VT)",
            "Swamp Key(VT)",
            "Dark Key(VT)",
            "Mire Key(VT)",
            "Skull Key(VT)",
            "Ice Key(VT)",
            "Hera Key(VT)",
            "Thieve Key(VT)",
            "Turtle Key(VT)",
            "GanonTower Key(VT)",
            "??? Key(VT)",
            "??? Key(VT)"
        };
    }
}
