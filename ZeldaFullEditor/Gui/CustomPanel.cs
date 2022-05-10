namespace ZeldaFullEditor
{
	public class CustomPanel : System.Windows.Forms.Panel
	{
		protected override System.Drawing.Point ScrollToControl(System.Windows.Forms.Control activeControl)
		{
			// Returning the current location prevents the panel from
			// Scrolling to the active control when the panel loses and regains focus
			return this.DisplayRectangle.Location;
		}
	}
}
