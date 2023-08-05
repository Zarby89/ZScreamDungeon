using System;
using System.IO;

namespace ZeldaFullEditor
{
    /// <summary>
    ///     A data class containing data for individual dungeon sprites, objects, and pot items when saving.
    /// </summary>
    [Serializable]
    public class SaveObject
    {
        /// <summary>
        ///     Gets or sets the Y position of the object.
        /// </summary>
        public byte X { get; set; }

        /// <summary>
        ///     Gets or sets the Y position of the object.
        /// </summary>
        public byte Y { get; set; }

        /// <summary>
        ///     Gets or sets the layer the object is on.
        /// </summary>
        public byte Layer { get; set; }

        /// <summary>
        ///     Gets or sets the sub type of the sprite.
        /// </summary>
        public byte Subtype { get; set; }

        /// <summary>
        ///     Gets or sets the overlord byte of the sprite.
        /// </summary>
        public byte Overlord { get; set; }

        /// <summary>
        ///     Gets or sets the ID of the sprite.
        /// </summary>
        public byte ID { get; set; }

        /// <summary>
        ///     Gets or sets the tile ID of the room object or pot item.
        /// </summary>
        public short TileID { get; set; }

        /// <summary>
        ///     Gets or sets the size of the room object.
        /// </summary>
        public byte Size { get; set; }

        /// <summary>
        ///     Gets or sets the room object options.
        /// </summary>
        public ObjectOption Options { get; set; }

        /// <summary>
        ///     Gets or sets the type of object (pot item, room object, or sprite).
        /// </summary>
        public Type Type { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SaveObject"/> class as a sprite.
        /// </summary>
        /// <param name="sprite"> The sprite. </param>
        public SaveObject(Sprite sprite) // Sprite Format
        {
            this.X = sprite.x;
            this.Y = sprite.y;
            this.ID = sprite.id;
            this.Layer = sprite.layer;
            this.Subtype = sprite.subtype;
            this.Type = typeof(Sprite);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SaveObject"/> class as a room object.
        /// </summary>
        /// <param name="roomObject"> The room object. </param>
        public SaveObject(Room_Object roomObject) // Room_Object
        {
            this.X = roomObject.X;
            this.Y = roomObject.Y;
            this.TileID = roomObject.id;
            this.Layer = (byte)roomObject.Layer;
            this.Size = roomObject.Size;
            this.Options = roomObject.options;
            this.Type = typeof(Room_Object);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SaveObject"/> class as a pot item.
        /// </summary>
        /// <param name="potItem"> The pot item. </param>
        public SaveObject(PotItem potItem) // Pot Item
        {
            this.X = potItem.x;
            this.Y = potItem.y;
            this.TileID = potItem.id;
            this.Layer = (byte)(potItem.bg2 ? 1 : 0);
            this.Type = typeof(PotItem);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SaveObject"/> class.
        /// </summary>
        /// <param name="br"> The BinaryReader handeling the data from ROM. </param>
        /// <param name="type"> The type of object. </param>
        public SaveObject(BinaryReader br, Type type) // From file
        {
            this.TileID = br.ReadInt16();
            this.X = br.ReadByte();
            this.Y = br.ReadByte();
            this.Layer = br.ReadByte();
            this.Size = br.ReadByte();
            this.Options = (ObjectOption)br.ReadByte();
            this.Type = type;
        }

        /// <summary>
        ///     Saves the object data to ROM.
        /// </summary>
        /// <param name="bw"> A BinaryWriter that handles the writing to ROM. </param>
        public void SaveToFile(BinaryWriter bw)
        {
            if (this.Type == typeof(Room_Object))
            {
                bw.Write(this.TileID);
                bw.Write(this.X);
                bw.Write(this.Y);
                bw.Write(this.Layer);
                bw.Write(this.Size);
                bw.Write((byte)this.Options);
            }
        }

        #region Unused

        /// <summary>
        ///     Returns all the data from the object as a string.
        /// </summary>
        /// <returns> A string with all the data from the object. </returns>
        public override string ToString()
        {
            string a = "NULLDAT";
            if (this.Type == typeof(Sprite))
            {
                a += "S";
                a += (char)this.ID;
                a += (char)this.X;
                a += (char)this.Y;
                a += (char)this.Layer;
                a += (char)this.Subtype;
                a += "Z";
            }
            else if (this.Type == typeof(Room_Object))
            {
                a += "O";
                a += (char)(this.TileID & 0xFF);
                a += (char)(this.TileID >> 8);
                a += (char)this.X;
                a += (char)this.Y;
                a += (char)this.Layer;
                a += (char)this.Size;
            }
            else if (this.Type == typeof(PotItem))
            {
                a += "P";
                a += (char)this.TileID;
                a += (char)this.X;
                a += (char)this.Y;
                a += (char)this.Layer;
                a += "ZZ";
            }

            return a;
        }

        /// <summary>
        ///     Reads in and applies data from the given string.
        /// </summary>
        /// <param name="s"> The string to get the data from. </param>
        public void FromString(string s)
        {
            if (s[0] == 'S')
            {
                this.ID = (byte)s[1];
                this.X = (byte)s[2];
                this.Y = (byte)s[3];
                this.Layer = (byte)s[4];
                this.Subtype = (byte)s[5];
            }

            if (s[0] == 'O')
            {
                short tempId = (short)((byte)s[2] << 8);
                tempId += (byte)s[1];
                this.TileID = tempId;
                this.X = (byte)s[3];
                this.Y = (byte)s[4];
                this.Layer = (byte)s[5];
                this.Size = (byte)s[6];
            }

            if (s[0] == 'P')
            {
                this.TileID = (byte)s[1];
                this.X = (byte)s[2];
                this.Y = (byte)s[3];
                this.Layer = (byte)s[4];
            }
        }

        #endregion
    }
}
