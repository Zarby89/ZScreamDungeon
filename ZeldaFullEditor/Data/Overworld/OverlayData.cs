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
