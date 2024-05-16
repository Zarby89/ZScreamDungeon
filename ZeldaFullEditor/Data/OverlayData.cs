using System.Collections.Generic;
using System.Windows.Controls;

namespace ZeldaFullEditor
{
    /// <summary>
    ///     A data class containing all of the info for overlay data.
    /// </summary>
    public class OverlayData
    {
        /// <summary>
        ///     Gets or sets the list of TilePos for the overlay.
        /// </summary>
        public List<TilePos> TileDataList { get; set; } = new List<TilePos>();
    }


    /// <summary>
    ///     A data class containing all of the info for overlay animation data.
    /// </summary>
    public class OverlayAnimationData
    {
        /// <summary>
        ///     Gets or sets the list of TilePos for the overlay.
        /// </summary>

        public List<TilePos>[] FramesList { get; set; } = new List<TilePos>[255];
    }
}
