using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
    [Serializable]
    public class SaveObject
    {
        public byte x { get; set; }
        public byte y { get; set; }
        public byte layer { get; set; }
        public byte subtype { get; set; }
        public byte overlord { get; set; }
        public byte id { get; set; }
        public short tid { get; set; }
        public byte size { get; set; }
        public ObjectOption options { get; set; }

        public Type type;
        public SaveObject(Sprite sprite) //Sprite Format
        {
            this.x = sprite.x;
            this.y = sprite.y;
            this.id = sprite.id;
            this.layer = sprite.layer;
            this.subtype = sprite.subtype;
            this.overlord = sprite.overlord;
            type = typeof(Sprite);
        }

        public SaveObject(Room_Object o) //Room_Object
        {
            this.x = o.x;
            this.y = o.y;
            this.tid = o.id;
            this.layer = o.layer;
            this.size = o.size;
            this.options = o.options;
            type = typeof(Room_Object);
        }

        public SaveObject(PotItem o) //Pot Item
        {
            this.x = o.x;
            this.y = o.y;
            this.tid = o.id;
            this.layer = (byte)(o.bg2 == true ? 1 : 0);
            type = typeof(PotItem);
        }

        public void saveToFile(BinaryWriter bw)
        {
            if (type == typeof(Room_Object))
            {
                bw.Write(tid);
                bw.Write(x);
                bw.Write(y);
                bw.Write(layer);
                bw.Write(size);
                bw.Write((byte)options);
            }
        }

        public SaveObject(BinaryReader br, Type type) // from file
        {

            tid = br.ReadInt16();
            x = br.ReadByte();
            y = br.ReadByte();
            layer = br.ReadByte();
            size = br.ReadByte();
            options = (ObjectOption)br.ReadByte();
            this.type = type;
        }

    }
}
