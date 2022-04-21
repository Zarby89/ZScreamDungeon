using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data
{
	public interface OverworldEntity
	{
		byte MapX { get; set; }
		byte MapY { get; set; }
		
		byte MapID { get; set; }
		void UpdateMapID(ushort mapid);
	}
}
