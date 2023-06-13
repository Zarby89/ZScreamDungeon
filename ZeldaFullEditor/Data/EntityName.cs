namespace ZeldaFullEditor.Data
{
    /// <summary>
    ///     General class for defining names and properties of objects.
    /// </summary>
    public class EntityName
    {
        /// <summary>
        ///     Gets or sets the ID of the entity.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        ///     Gets or sets the Name of the entity.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="EntityName"/> class.
        /// </summary>
        /// <param name="id"> The ID. </param>
        /// <param name="name"> The Name. </param>
        public EntityName(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }

        /// <summary>
        ///     Returns a string containing the data stored in the entity.
        /// </summary>
        /// <returns> A string. </returns>
        public override string ToString()
        {
            return string.Format("{0:2X} {1}", this.ID, this.Name);
        }
    }

    /// <summary>
    ///     A sprite name based on an entity.
    /// </summary>
    public class SpriteName : EntityName
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpriteName"/> class.
        /// </summary>
        /// <param name="id"> The ID. </param>
        /// <param name="name"> The Name. </param>
        public SpriteName(int id, string name)
            : base(id, name)
        {
        }
    }

    /// <summary>
    ///     A tile type based on an entity.
    /// </summary>
    public class TileTypeName : EntityName
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TileTypeName"/> class.
        /// </summary>
        /// <param name="id"> The ID. </param>
        /// <param name="name"> The Name. </param>
        public TileTypeName(int id, string name)
            : base(id, name)
        {
        }
    }

    /// <summary>
    ///     A room object based on an entity.
    /// </summary>
    public class RoomObjectName : EntityName
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoomObjectName"/> class.
        /// </summary>
        /// <param name="id"> The ID. </param>
        /// <param name="name"> The Name. </param>
        public RoomObjectName(int id, string name)
            : base(id, name)
        {
        }

        /// <summary>
        ///     Returns a string containing the data stored in the entity.
        /// </summary>
        /// <returns> A string. </returns>
        public override string ToString()
        {
            return string.Format("{0:3X} {1}", this.ID, this.Name);
        }
    }

    /// <summary>
    ///     A room tag based on an entity.
    /// </summary>
    public class RoomTagName : EntityName
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoomTagName"/> class.
        /// </summary>
        /// <param name="id"> The ID. </param>
        /// <param name="name"> The Name. </param>
        public RoomTagName(int id, string name)
            : base(id, name)
        {
        }

        /// <summary>
        ///     Returns a string containing the data stored in the entity.
        /// </summary>
        /// <returns> A string. </returns>
        public override string ToString()
        {
            return this.Name;
        }
    }

    /// <summary>
    ///     A room effect based on an entity.
    /// </summary>
    public class RoomEffectName : EntityName
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoomEffectName"/> class.
        /// </summary>
        /// <param name="id"> The ID. </param>
        /// <param name="name"> The Name. </param>
        public RoomEffectName(int id, string name)
            : base(id, name)
        {
        }

        /// <summary>
        ///     Returns a string containing the data stored in the entity.
        /// </summary>
        /// <returns> A string. </returns>
        public override string ToString()
        {
            return this.Name;
        }
    }
}
