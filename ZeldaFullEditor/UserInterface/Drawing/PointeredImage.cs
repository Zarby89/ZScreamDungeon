namespace ZeldaFullEditor.UserInterface.Drawing;

/// <summary>
/// Encapsulates a bitmap and its related pointer for <see langword="unsafe"/> zarby drawing
/// </summary>
public unsafe class PointeredImage : IGraphicsCanvas
{
	private readonly IntPtr ptr;
	private byte* Pointer => (byte*) ptr.ToPointer();

	public Bitmap Bitmap { get; }

	public int Width { get; }
	public int Height { get; }

	public byte this[int x, int y]
	{
		get => Pointer[x + y * Width];
		set
		{
			if (x < 0 || x >= Width || y < 0 || y >= Height) return;
			Pointer[x + y * Width] = value;
		}
	}

	public ColorPalette Palette
	{
		get => Bitmap.Palette;
		set => Bitmap.Palette = value;
	}

	public PointeredImage(int width, int height)
	{
		ptr = Marshal.AllocHGlobal(width * height);
		Width = width;
		Height = height;
		Bitmap = new Bitmap(width, height, width, PixelFormat.Format8bppIndexed, ptr);
	}

	public void ClearBitmap()
	{
		var a = Pointer;
		for (int i = 0; i < Width * Height; i++)
		{
			a[i] = 0;
		}
	}
}
