namespace ZeldaFullEditor
{
    public class WriteType
    {
        public readonly string Text;

        private WriteType(string t)
        {
            Text = t;
        }

        public static readonly WriteType Unknown = new WriteType("No information available");
        public static readonly WriteType GFX = new WriteType("Unspecific graphics");
        public static readonly WriteType Palette = new WriteType("Unspecific palettes");

        public static readonly WriteType GFXPTR = new WriteType("Graphics pointers");

        public static readonly WriteType OverworldMapData = new WriteType("Overworld map data");
        public static readonly WriteType OverworldMapPointer = new WriteType("Overworld map pointer");
        public static readonly WriteType OverworldMapIcon = new WriteType("Overworld map icon");
        public static readonly WriteType Tile32 = new WriteType("Tile32 data");
        public static readonly WriteType Tile16 = new WriteType("Tile16 data");
        public static readonly WriteType Gravestone = new WriteType("Gravestone data");
        public static readonly WriteType SpriteData = new WriteType("Sprite data");

        public static readonly WriteType EntranceProperties = new WriteType("Entrance properties");
        public static readonly WriteType ExitProperties = new WriteType("Dungeon exit properties");
        public static readonly WriteType SpawnProperties = new WriteType("Spawn point properties");

        public static readonly WriteType ChestData = new WriteType("Chest items data");
        public static readonly WriteType TorchData = new WriteType("Torch data");
        public static readonly WriteType PotItemData = new WriteType("Pot item data");
        public static readonly WriteType SpriteSet = new WriteType("Sprite set");
        public static readonly WriteType SpritePalette = new WriteType("Sprite palette");
        public static readonly WriteType DungeonMap = new WriteType("Dungeon map data");
        public static readonly WriteType DungeonPrize = new WriteType("Dungeon prize data");

        public static readonly WriteType TitleScreenData = new WriteType("Title screen data");
        public static readonly WriteType TitleScreenSprites = new WriteType("Title screen sprites data");
        public static readonly WriteType TitleScreenPointer = new WriteType("Title screen pointer");

        public static readonly WriteType Polyhedral = new WriteType("Polyhedral parameters");

        public static readonly WriteType FontData = new WriteType("Font data");
    }
}
