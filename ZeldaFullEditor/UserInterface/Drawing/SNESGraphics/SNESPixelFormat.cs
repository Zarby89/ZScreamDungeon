namespace ZeldaFullEditor.UserInterface.Drawing.SNESGraphics;

/// <summary>
/// Specifies the pixel format for graphics data.
/// </summary>
public enum SNESPixelFormat
{
	NoImageType = 0,

	Compressed = 0b0000_0001,

	SNES2BPP = 0b0000_0010,
	SNES2BPPCompressed = SNES2BPP | Compressed,

	SNES3BPP = 0b0000_0100,
	SNES3BPPCompressed = SNES3BPP | Compressed,

	SNES4BPP = 0b0000_1000,
	SNES4BPPCompressed = SNES4BPP | Compressed,

	SNES8BPP = 0b0001_0000,
	SNES8BPPCompressed = SNES8BPP | Compressed,

	SNESMode7 = 0b0010_0000,
	SNESMode7Compressed = SNESMode7 | Compressed,
}
