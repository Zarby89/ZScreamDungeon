using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data
{
	/// <summary>
	/// General class for defining names and properties of objects
	/// </summary>
	public class EntityName
	{
		protected readonly int id; public int ID { get => id; }
		protected readonly string name; public string Name { get => name; }

		public EntityName(int id, string name)
		{
			this.id = id;
			this.name = name;
		}

		public override string ToString() => string.Format("{0:2X} {1}", id, name);
	}

	public class SpriteName : EntityName
	{
		public SpriteName(int i, string n) : base(i, n) { }
	}

	public class TileTypeName : EntityName
	{
		public TileTypeName(int i, string n) : base(i, n) { }
	}

	public class RoomObjectName : EntityName
	{
		public RoomObjectName(int i, string n) : base(i, n) { }
		public override string ToString() => string.Format("{0:3X} {1}", id, name);

	}

	public class RoomTagName : EntityName
	{
		public RoomTagName(int i, string n) : base(i, n) { }
		public override string ToString() => name;
	}

	public class RoomEffectName : EntityName
	{
		public RoomEffectName(int i, string n) : base(i, n) { }
		public override string ToString() => name;
	}
}
