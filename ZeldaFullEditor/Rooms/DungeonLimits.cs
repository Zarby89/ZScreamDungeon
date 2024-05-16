﻿using System;
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
        StarTiles,

        // TODO there are like 20 fucking stair limits
        Stairs,

        /// <summary>
        /// Objects which are manipulable by the player in some generic way.
        /// </summary>
        GeneralManipulable,

        /// <summary>
        /// Large objects that fall under the <see cref="GeneralManipulable"/> class
        /// </summary>
        GeneralManipulable4x,
    }
}