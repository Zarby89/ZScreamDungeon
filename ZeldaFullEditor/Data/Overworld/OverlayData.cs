using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
	public class OverlayData
	{
		public List<OverlayTile> tilesData = new();

		public OverlayData()
		{
		}

		public void CleanUp()
		{
			tilesData.RemoveAll(o => o.IsGarbage);
		}
	}
}
