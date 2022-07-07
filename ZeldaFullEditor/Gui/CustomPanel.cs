namespace ZeldaFullEditor;

public class CustomPanel : Panel
{
	protected override Point ScrollToControl(Control activeControl)
	{
		// Returning the current location prevents the panel from
		// Scrolling to the active control when the panel loses and regains focus
		return DisplayRectangle.Location;
	}
}
