using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor {
    [Serializable]
    public class Subtype2_Multiple : Room_Object {
        public int tx = 0;
        public int ty = 0;

        public Subtype2_Multiple(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer) {
            byte oid = (byte) (id & 0xFF);

            switch (oid) {
                case 0x00:
                    setdata(Constants.Type2RoomObjectNames[0x00], 4, 4);
                    sort = Sorting.Wall | Sorting.NonScalable;
                    break;
                case 0x01:
                    setdata(Constants.Type2RoomObjectNames[0x01], 4, 4);
                    sort = Sorting.Wall | Sorting.NonScalable;
                    break;
                case 0x02:
                    setdata(Constants.Type2RoomObjectNames[0x02], 4, 4);
                    sort = Sorting.Wall | Sorting.NonScalable;
                    break;
                case 0x03:
                    setdata(Constants.Type2RoomObjectNames[0x03], 4, 4);
                    sort = Sorting.Wall | Sorting.NonScalable;
                    break;
                case 0x04:
                    setdata(Constants.Type2RoomObjectNames[0x04], 4, 4);
                    sort = Sorting.Wall | Sorting.NonScalable;
                    break;
                case 0x05:
                    setdata(Constants.Type2RoomObjectNames[0x05], 4, 4);
                    sort = Sorting.Wall | Sorting.NonScalable;
                    break;
                case 0x06:
                    setdata(Constants.Type2RoomObjectNames[0x06], 4, 4);
                    sort = Sorting.Wall | Sorting.NonScalable;
                    break;
                case 0x07:
                    setdata(Constants.Type2RoomObjectNames[0x07], 4, 4);
                    sort = Sorting.Wall | Sorting.NonScalable;
                    break;
                case 0x08:
                    setdata(Constants.Type2RoomObjectNames[0x08], 4, 4, true);
                    sort = Sorting.Wall | Sorting.NonScalable;
                    break;
                case 0x09:
                    setdata(Constants.Type2RoomObjectNames[0x09], 4, 4, true);
                    sort = Sorting.Wall | Sorting.NonScalable;
                    break;
                case 0x0A:
                    setdata(Constants.Type2RoomObjectNames[0x0A], 4, 4, true);
                    sort = Sorting.Wall | Sorting.NonScalable;
                    break;
                case 0x0B:
                    setdata(Constants.Type2RoomObjectNames[0x0B], 4, 4, true);
                    sort = Sorting.Wall | Sorting.NonScalable;
                    break;
                case 0x0D:
                    setdata(Constants.Type2RoomObjectNames[0x0C], 4, 4, true);
                    sort = Sorting.Wall | Sorting.NonScalable;
                    break;
                case 0x0C:
                    setdata(Constants.Type2RoomObjectNames[0x0D], 4, 4, true);
                    sort = Sorting.Wall | Sorting.NonScalable;
                    break;
                case 0x0E:
                    setdata(Constants.Type2RoomObjectNames[0x0E], 4, 4, true);
                    sort = Sorting.Wall | Sorting.NonScalable;
                    break;
                case 0x0F:
                    setdata(Constants.Type2RoomObjectNames[0x0F], 4, 4, true);
                    sort = Sorting.Wall | Sorting.NonScalable;
                    break;
                case 0x10:
                    setdata(Constants.Type2RoomObjectNames[0x10], 3, 4, true);
                    sort = Sorting.Wall | Sorting.NonScalable;
                    break;
                case 0x11:
                    setdata(Constants.Type2RoomObjectNames[0x11], 3, 4, true);
                    sort = Sorting.Wall | Sorting.NonScalable;
                    break;
                case 0x12:
                    setdata(Constants.Type2RoomObjectNames[0x12], 3, 4, true);
                    sort = Sorting.Wall | Sorting.NonScalable;
                    break;
                case 0x13:
                    setdata(Constants.Type2RoomObjectNames[0x13], 3, 4, true);
                    sort = Sorting.Wall | Sorting.NonScalable;
                    break;
                case 0x14:
                    setdata(Constants.Type2RoomObjectNames[0x14], 4, 3, true);
                    sort = Sorting.Wall | Sorting.NonScalable;
                    break;
                case 0x15:
                    setdata(Constants.Type2RoomObjectNames[0x15], 4, 3, true);
                    sort = Sorting.Wall | Sorting.NonScalable;
                    break;
                case 0x16:
                    setdata(Constants.Type2RoomObjectNames[0x16], 4, 3, true);
                    sort = Sorting.Wall | Sorting.NonScalable;
                    break;
                case 0x17:
                    setdata(Constants.Type2RoomObjectNames[0x17], 4, 3, true);
                    sort = Sorting.Wall | Sorting.NonScalable;
                    break;
                case 0x18:
                    setdata(Constants.Type2RoomObjectNames[0x18], 2, 2);
                    sort = Sorting.Wall | Sorting.NonScalable;
                    break;
                case 0x19:
                    setdata(Constants.Type2RoomObjectNames[0x19], 2, 2);
                    sort = Sorting.Wall | Sorting.NonScalable;
                    break;
                case 0x1A:
                    setdata(Constants.Type2RoomObjectNames[0x1A], 2, 2);
                    sort = Sorting.Wall | Sorting.NonScalable;
                    break;
                case 0x1B:
                    setdata(Constants.Type2RoomObjectNames[0x1B], 2, 2);
                    sort = Sorting.Wall | Sorting.NonScalable;
                    break;
                case 0x1C:
                    setdata(Constants.Type2RoomObjectNames[0x1C], 4, 4);
                    sort = Sorting.Dungeons | Sorting.NonScalable;
                    break;
                case 0x1D:
                    setdata(Constants.Type2RoomObjectNames[0x1D], 2, 3);
                    sort = Sorting.Dungeons | Sorting.NonScalable;
                    break;
                case 0x1E:
                    setdata(Constants.Type2RoomObjectNames[0x1E], 2, 2);
                    sort = Sorting.Dungeons | Sorting.NonScalable;
                    break;
                case 0x1F:
                    setdata(Constants.Type2RoomObjectNames[0x1F], 2, 2);
                    sort = Sorting.Dungeons | Sorting.NonScalable;
                    break;
                case 0x20:
                    setdata(Constants.Type2RoomObjectNames[0x20], 2, 2);
                    sort = Sorting.Dungeons | Sorting.NonScalable;
                    break;
                case 0x21:
                    setdata(Constants.Type2RoomObjectNames[0x21], 2, 3);
                    sort = Sorting.NonScalable;
                    break;
                case 0x22:
                    setdata(Constants.Type2RoomObjectNames[0x22], 4, 5);
                    sort = Sorting.NonScalable;
                    break;
                case 0x23:
                    setdata(Constants.Type2RoomObjectNames[0x23], 4, 3);
                    sort = Sorting.NonScalable;
                    break;
                case 0x24:
                    setdata(Constants.Type2RoomObjectNames[0x24], 4, 4);
                    sort = Sorting.NonScalable;
                    break;
                case 0x25:
                    setdata(Constants.Type2RoomObjectNames[0x25], 4, 4);
                    sort = Sorting.NonScalable;
                    break;
                case 0x26:
                    setdata(Constants.Type2RoomObjectNames[0x26], 2, 3);
                    sort = Sorting.NonScalable;
                    break;
                case 0x27:
                    setdata(Constants.Type2RoomObjectNames[0x27], 2, 2);
                    sort = Sorting.NonScalable;
                    break;
                case 0x28:
                    setdata(Constants.Type2RoomObjectNames[0x28], 4, 5);
                    sort = Sorting.NonScalable;
                    break;
                case 0x29:
                    setdata(Constants.Type2RoomObjectNames[0x29], 4, 4);
                    sort = Sorting.NonScalable;
                    break;
                case 0x2A:
                    setdata(Constants.Type2RoomObjectNames[0x2A], 4, 2);
                    sort = Sorting.NonScalable;
                    break;
                case 0x2B:
                    setdata(Constants.Type2RoomObjectNames[0x2B], 2, 2);
                    sort = Sorting.NonScalable;
                    break;
                case 0x2C:
                    setdata(Constants.Type2RoomObjectNames[0x2C], 6, 3);
                    sort = Sorting.NonScalable;
                    break;
                case 0x2D:
                    setdata(Constants.Type2RoomObjectNames[0x2D], 4, 4);
                    sort = Sorting.Stairs | Sorting.NonScalable;
                    break;
                case 0x2E:
                    setdata(Constants.Type2RoomObjectNames[0x2E], 4, 4);
                    sort = Sorting.Stairs | Sorting.NonScalable;
                    break;
                case 0x2F:
                    setdata(Constants.Type2RoomObjectNames[0x2F], 4, 4);
                    sort = Sorting.Stairs | Sorting.NonScalable;
                    break;
                case 0x30:
                    setdata(Constants.Type2RoomObjectNames[0x30], 4, 4, true);
                    sort = Sorting.Stairs | Sorting.NonScalable;
                    break;
                case 0x31:
                    setdata(Constants.Type2RoomObjectNames[0x31], 4, 4, true);
                    sort = Sorting.Stairs | Sorting.NonScalable;
                    break;
                case 0x32:
                    setdata(Constants.Type2RoomObjectNames[0x32], 4, 4);
                    sort = Sorting.Stairs | Sorting.NonScalable;
                    break;
                case 0x33:
                    setdata(Constants.Type2RoomObjectNames[0x33], 4, 4);
                    sort = Sorting.Stairs | Sorting.NonScalable;
                    break;
                case 0x34:
                    setdata(Constants.Type2RoomObjectNames[0x34], 2, 2);
                    sort = Sorting.NonScalable;
                    break;
                case 0x35:
                    setdata(Constants.Type2RoomObjectNames[0x35], 4, 2);
                    sort = Sorting.Stairs | Sorting.NonScalable;
                    break;
                case 0x36:
                    setdata(Constants.Type2RoomObjectNames[0x36], 4, 2, true);
                    sort = Sorting.Stairs | Sorting.NonScalable;
                    break;
                case 0x37:
                    setdata(Constants.Type2RoomObjectNames[0x37], 10, 4);
                    sort = Sorting.NonScalable;
                    break;
                case 0x38:
                    setdata(Constants.Type2RoomObjectNames[0x38], 4, 3);
                    sort = Sorting.Stairs | Sorting.NonScalable;
                    break;
                case 0x39:
                    setdata(Constants.Type2RoomObjectNames[0x39], 4, 3);
                    sort = Sorting.Stairs | Sorting.NonScalable;
                    break;
                case 0x3A:
                    setdata(Constants.Type2RoomObjectNames[0x3A], 4, 3);
                    sort = Sorting.Stairs | Sorting.NonScalable;
                    break;
                case 0x3B:
                    setdata(Constants.Type2RoomObjectNames[0x3B], 4, 3);
                    sort = Sorting.Stairs | Sorting.NonScalable;
                    break;
                case 0x3C:
                    setdata(Constants.Type2RoomObjectNames[0x3C], 4, 6);
                    sort = Sorting.NonScalable;
                    break;
                case 0x3D:
                    setdata(Constants.Type2RoomObjectNames[0x3D], 4, 3);
                    sort = Sorting.NonScalable;
                    break;
                case 0x3E:
                    setdata(Constants.Type2RoomObjectNames[0x3E], 6, 3);
                    sort = Sorting.NonScalable;
                    break;
                case 0x3F:
                    setdata(Constants.Type2RoomObjectNames[0x3F], 8, 7);
                    sort = Sorting.NonScalable;
                    break;
                case 0x50: // special object id doesnt matter (Torches)
                    //setdata("Torch", 2, 2);
                    tiles.Add(new Tile(480, 0, 0, 0, 3));
                    tiles.Add(new Tile(496, 0, 0, 0, 3));
                    tiles.Add(new Tile(480, 1, 0, 0, 3));
                    tiles.Add(new Tile(496, 1, 0, 0, 3));
                    options |= ObjectOption.Torch;
                    this.name = "Torch";
                    tx = 2;
                    ty = 2;
                    break;
                default:
                    // TODO should we handle this?
                    break;
            }
        }

        public override void Draw() {
            base.Draw();

            byte oid = (byte) (id & 0xFF);
            if (oid == 0x3C) {
                //collumn
                for (int i = 0; i < 2; i++) {
                    for (int xx = 0; xx < 2; xx++) {
                        for (int yy = 0; yy < 6; yy++) {
                            tiles[yy].mirror_x = (ushort) (xx & 0x01);
                            tiles[yy + 6].mirror_x = (ushort) (xx & 0x01);
                            draw_tile(tiles[(yy)], ((xx + (i * 14))) * 8, (yy) * 8);
                            draw_tile(tiles[(yy + 6)], (((xx + (i * 14) + 2))) * 8, (yy) * 8);

                            draw_tile(tiles[(yy)], ((xx + (i * 14) + 4)) * 8, (yy) * 8);
                            draw_tile(tiles[(yy + 6)], (((xx + (i * 14) + 6))) * 8, (yy) * 8);

                            draw_tile(tiles[(yy)], ((xx + (i * 14) + 8)) * 8, (yy) * 8);
                        }
                    }
                }

                int tid = 12;
                for (int xx = 0; xx < 4; xx++) {
                    for (int yy = 0; yy < 3; yy++) {
                        draw_tile(tiles[(tid)], (xx + 10) * 8, (yy) * 8);
                        tid++;
                    }
                }

                return;
            }

            if (oid == 0x28 || oid == 0x35 || oid == 0x36 || oid == 0x2A) {
                //bed ? WTF WHY THIS IS REVERSED...
                int tid = 0;
                for (int yy = 0; yy < ty; yy++) {
                    for (int xx = 0; xx < tx; xx++) {

                        draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                        tid++;
                    }
                }
            } else {
                int tid = 0;
                for (int xx = 0; xx < tx; xx++) {
                    for (int yy = 0; yy < ty; yy++) {
                        draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                        tid++;
                    }
                }
            }
        }

        public void setdata(string name, int tx, int ty, bool allbg = false) {
            int pos = Constants.tile_address + (short) ((ROM.DATA[Constants.subtype2_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype2_tiles + ((id & 0xFF) * 2)]);
            addTiles(tx * ty, pos);
            this.name = name;
            this.tx = tx;
            this.ty = ty;
            this.allBgs = allbg;
        }
    }
}
