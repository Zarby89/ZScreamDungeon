using System.Collections.Generic;

namespace ZeldaFullEditor
{
    /// <summary>
    ///     A class containing all of the overlay data.
    /// </summary>
    public class OverlayData
    {
        /// <summary>
        ///     Gets or sets the list of TilePos for the overlay.
        /// </summary>
        public List<TilePos> TileDataList { get; set; } = new List<TilePos>();
    }
}
