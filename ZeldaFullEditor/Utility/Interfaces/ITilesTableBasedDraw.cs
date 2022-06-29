namespace ZeldaFullEditor
{
	/// <summary>
	/// Represents objects that have draw routines based on the Bank00 tiles tables.
	/// </summary>
	public interface ITilesTableBasedDraw
	{
		TilesList Tiles { get; set; }
	}
}
