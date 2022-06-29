using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
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
		public SaveObject(Sprite sprite) // Sprite Format
		{
			this.x = sprite.x;
			this.y = sprite.y;
			this.id = sprite.id;
			this.layer = sprite.layer;
			this.subtype = sprite.subtype;
			type = typeof(Sprite);
		}

		public SaveObject(Room_Object o) // Room_Object
		{
			this.x = o.x;
			this.y = o.y;
			this.tid = o.id;
			this.layer = o.layer;
			this.size = o.size;
			this.options = o.options;
			type = typeof(Room_Object);
		}

		public SaveObject(PotItem o) // Pot Item
		{
			this.x = o.x;
			this.y = o.y;
			this.tid = o.id;
			this.layer = (byte) (o.bg2 ? 1 : 0);
			type = typeof(PotItem);
		}

		public string toStr()
		{
			string a = "NULLDAT";
			if (type == typeof(Sprite)) 
			{ 
				a += "S";
				a += (char) id;
				a += (char) x;
				a += (char) y;
				a += (char) layer;
				a += (char) subtype;
				a += "Z";
			}
			if (type == typeof(Room_Object)) { 
				a += "O";
				a += (char) (tid & 0xFF);
				a += (char) (tid >> 8);
				a += (char) x;
				a += (char) y;
				a += (char) layer;
				a += (char) size;
			}
			if (type == typeof(PotItem)) { 
				
				a += "P";
				a += (char) tid;
				a += (char) x;
				a += (char) y;
				a += (char) layer;
				a += "ZZ";
			}
			return a;
		}

		public void fromStr(string s)
		{
			if (s[0] == 'S')
			{
				id = (byte) s[1];
				x = (byte) s[2];
				y = (byte) s[3];
				layer = (byte) s[4];
				subtype = (byte) s[5];
			}
			if (s[0] == 'O')
			{
				short tempId = (short)((byte) s[2] << 8);
				tempId += (byte) s[1];
				tid = tempId;
				x = (byte) s[3];
				y = (byte) s[4];
				layer = (byte) s[5];
				size = (byte) s[6];
			}
			if (s[0] == 'P')
			{
				tid = (byte) s[1];
				x = (byte) s[2];
				y = (byte) s[3];
				layer = (byte) s[4];
			}
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
				bw.Write((byte) options);
			}
		}

		public SaveObject(BinaryReader br, Type type) // From file
		{
			tid = br.ReadInt16();
			x = br.ReadByte();
			y = br.ReadByte();
			layer = br.ReadByte();
			size = br.ReadByte();
			options = (ObjectOption) br.ReadByte();
			this.type = type;
		}
	}
}
