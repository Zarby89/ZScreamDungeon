namespace ZeldaFullEditor
{
    /// <summary>
    ///		Simple object containing Room data. Used to populate the entrance list.
    ///		TODO: This object is probably redundant and can be removed. -Jared_Brian_.
    /// </summary>
    public class DataRoom
    {
        /// <summary>
        ///		Gets or Sets the ID of the object.
        /// </summary>
        public short ID { get; set; }

        /// <summary>
        ///		Gets or Sets the DungeonID of the object.
        /// </summary>
        public byte DungeonID { get; set; }

        /// <summary>
        ///		Gets or Sets the Name of the object.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///		Initializes a new instance of the <see cref="DataRoom"/> class.
        /// </summary>
        /// <param name="id"> The ID. </param>
        /// <param name="dungeonId"> The Dungeon ID. </param>
        /// <param name="name"> The Name. </param>
        public DataRoom(short id, byte dungeonId, string name)
        {
            this.ID = id;
            this.DungeonID = dungeonId;
            this.Name = name;
        }
    }
}
