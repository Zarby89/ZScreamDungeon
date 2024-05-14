using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
    /// <summary>
    /// Specifies which, if any, class of limits an object falls under.
    /// </summary>
    public enum DungeonLimits
    {
        /// <summary>
        /// No limits are placed on this object class.
        /// </summary>
        None,

        /// <summary>
        /// Applies to chests, big chests, etc.
        /// </summary>
        Chest,

        /// <summary>
        /// Applies only to star tiles which are active upon room load.
        /// </summary>
        StarTile,

        StairsNorth,
        StairsSouth,
        StairsTransition,

        /// <summary>
        /// Objects which are manipulable by the player in some generic way.
        /// </summary>
        GeneralManipulable,

        /// <summary>
        /// Large objects that fall under the <see cref="GeneralManipulable"/> class
        /// </summary>
        GeneralManipulable4x,

        /// <summary>
        /// Large objects that fall under the <see cref="GeneralManipulable"/> class
        /// </summary>
        GeneralManipulableLengthy,

        SomariaLine,

        Doors,
		SpecialDoors,
		ExitMods,
        Watergate,
        WaterVomit,
        MovingWalls,

		Sprites,
        Overlords,
    }

    public static class DungeonLimitsHelper {
        public static int GetLimitOfObjects(DungeonLimits lim) {
            switch (lim) {
				case DungeonLimits.Chest:
					return 5;

				case DungeonLimits.StarTile:
					return 8;

				case DungeonLimits.StairsNorth:
					return 4;

				case DungeonLimits.StairsSouth:
					return 4;

				case DungeonLimits.StairsTransition:
					return 4;

				case DungeonLimits.GeneralManipulable:
				case DungeonLimits.GeneralManipulable4x:
				case DungeonLimits.GeneralManipulableLengthy:
					return 16;

				case DungeonLimits.SomariaLine:
					return 256;

				case DungeonLimits.Doors:
					return 16;

				case DungeonLimits.ExitMods:
					return 4;

				case DungeonLimits.SpecialDoors:
					return 4;

				case DungeonLimits.MovingWalls:
					return 1;

				case DungeonLimits.Watergate:
					return 1;

				case DungeonLimits.WaterVomit:
					return 1;

				case DungeonLimits.Sprites:
					return 16;

				case DungeonLimits.Overlords:
					return 8;

			}

			return 99999;
        }

		public static string GetLimitName(DungeonLimits lim) {
			switch (lim) {
				case DungeonLimits.Chest:
					return "chests / key locks";

				case DungeonLimits.StarTile:
					return "active star tiles";

				case DungeonLimits.StairsNorth:
					return "northwards stairs";

				case DungeonLimits.StairsSouth:
					return "southwards stairs";

				case DungeonLimits.StairsTransition:
					return "interroom stairs";

				case DungeonLimits.GeneralManipulable:
				case DungeonLimits.GeneralManipulable4x:
				case DungeonLimits.GeneralManipulableLengthy:
					return "general manipulables";

				case DungeonLimits.SomariaLine:
					return "somaria end points";

				case DungeonLimits.Doors:
					return "doors";

				case DungeonLimits.SpecialDoors:
					return "special doors";

				case DungeonLimits.ExitMods:
					return "exit markers";

				case DungeonLimits.MovingWalls:
					return "moving walls";

				case DungeonLimits.Watergate:
					return "water gates (only the last will animate)";

				case DungeonLimits.WaterVomit:
					return "empty water mouths (only the last will animate)";

				case DungeonLimits.Sprites:
					return "sprites";

				case DungeonLimits.Overlords:
					return "overlords";

			}

			return "objects";
		}


		public static Dictionary<DungeonLimits, int> CreateCounter() {
            return new Dictionary<DungeonLimits, int>() {
                    { DungeonLimits.Chest, 0 },
                    { DungeonLimits.StarTile, 0 },
                    { DungeonLimits.StairsNorth, 0 },
                    { DungeonLimits.StairsSouth, 0 },
                    { DungeonLimits.StairsTransition, 0 },
                    { DungeonLimits.GeneralManipulable, 0 },
                    { DungeonLimits.SomariaLine, 0 },
                    { DungeonLimits.Doors, 0 },
                    { DungeonLimits.SpecialDoors, 0 },
                    { DungeonLimits.ExitMods, 0 },
                    { DungeonLimits.MovingWalls, 0 },
                    { DungeonLimits.Watergate, 0 },
                    { DungeonLimits.WaterVomit, 0 },
                    { DungeonLimits.Sprites, 0 },
                    { DungeonLimits.Overlords, 0 },
            };
        }
    }
}
