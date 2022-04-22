using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Rooms
{
//	class RoomLayout : Room
//	{
//		public RoomLayout(ZScreamer zs) : base(zs, -1)
//		{
//			// TODO: Add something here?
//		}
//
//		public void loadLayout(int layout)
//		{
//			int pointer = SNESFunctions.SNEStoPC(ZS.ROM[ZS.Offsets.room_object_layout_pointer, 3]);
//			int layout_address = ZS.ROM[pointer + (layout * 3), 3];
//
//			int layout_location = layout_address.SNEStoPC();
//
//			int pos = layout_location;
//			byte b1, b2, b3;
//			byte posX, posY;
//			byte sizeX, sizeY, sizeXY;
//			ushort oid;
//			int layer = 0;
//
//			while (true)
//			{
//				b1 = ZS.ROM[pos];
//				b2 = ZS.ROM[pos + 1];
//				if ((b1 & b2) == 0xFF)
//				{
//					break;
//				}
//
//				b3 = ZS.ROM[pos + 2];
//				pos += 3; // We jump to layer2
//
//				if (b3 >= 0xF8)
//				{
//					oid = (ushort) ((b3 << 4) | 0x80 + (((b2 & 0x03) << 2) + ((b1 & 0x03))));
//					posX = (byte) ((b1 & 0xFC) >> 2);
//					posY = (byte) ((b2 & 0xFC) >> 2);
//					sizeXY = (byte) ((((b1 & 0x03) << 2) + (b2 & 0x03)));
//				}
//				else // Subtype1
//				{
//					oid = b3;
//					posX = (byte) ((b1 & 0xFC) >> 2);
//					posY = (byte) ((b2 & 0xFC) >> 2);
//					sizeX = (byte) ((b1 & 0x03));
//					sizeY = (byte) ((b2 & 0x03));
//					sizeXY = (byte) (((sizeX << 2) + sizeY));
//				}
//
//				if (b1 >= 0xFC) // Subtype2 (not scalable? )
//				{
//					oid = (ushort) ((b3 & 0x3F) + 0x100);
//					posX = (byte) (((b2 & 0xF0) >> 4) + ((b1 & 0x3) << 4));
//					posY = (byte) (((b2 & 0x0F) << 2) + ((b3 & 0xC0) >> 6));
//					sizeXY = 0;
//				}
//
//				Room_Object r = addObject(oid, posX, posY, sizeXY, (byte) layer);
//				if (r != null)
//				{
//					r.options |= ObjectOption.Bgr;
//					tilesLayoutObjects.Add(r);
//				}
//			}
//		}
//	}
}
