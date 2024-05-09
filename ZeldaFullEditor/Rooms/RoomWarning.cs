using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
    public enum RoomWarning
    {
        None = 0,
        GeneralManipulable = 1,
        Chest = 2,
        Stairs = 4,
        StarTiles = 8,
        SpecialDoors = 16,
        Sprites = 32,
    }
}
