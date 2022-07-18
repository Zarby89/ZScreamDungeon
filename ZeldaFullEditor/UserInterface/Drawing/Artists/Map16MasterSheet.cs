﻿namespace ZeldaFullEditor.UserInterface.Drawing.Artists;

public unsafe class Tile16MasterSheet : IByteable
{
	internal const int TileSpan = 17;
	internal const int TilesPerRow = 8;
	internal const int TilesPerColumn = 0xE1;
	internal const int TilesPerBlock = TilesPerRow * TilesPerColumn;
	internal const int ImageWidth = TilesPerRow * TileSpan;
	internal const int ImageHeight = TilesPerColumn * TileSpan;

	private readonly Tile16[] ListOf = new Tile16[Constants.NumberOfUniqueTile16Definitions];

	public GraphicsSet Graphics { get; private set; }

	public PointeredImage PreviewCanvas { get; }

	public ColorPalette Palette
	{
		get => PreviewCanvas.Palette;
		set => PreviewCanvas.Palette = value;
	}

	public Tile16MasterSheet()
	{
		PreviewCanvas = new PointeredImage(ImageWidth, ImageHeight * 2);
		PreviewCanvas.ClearBitmap();
	}

	public void UpdateToMatchScreen(OverworldScreen screen)
	{
		Graphics = screen.LoadedGraphics;
		screen.CGPaletteState0.CopyToImagePalette(PreviewCanvas.Bitmap);
		RedrawImageForGraphicsSet();
	}

	public void RedrawImageForGraphicsSet()
	{
		RefreshGraphicsSheet();
	}

	public void RedrawImageForPaletteChange()
	{
		RefreshGraphicsSheet();
	}

	private static int GetIndexFromXY(int x, int y)
	{
		int X = x / TileSpan / TilesPerRow;
		int block = X / TilesPerBlock * TilesPerBlock;
		X %= TilesPerBlock;
		int Y = TilesPerRow * (y / TileSpan / TilesPerColumn);
		return block + X + Y;
	}

	public void SetTile16At(int id, Tile16 t) => ListOf[id] = t;
	public void SetTile16At(MouseEventArgs e, Tile16 t) => ListOf[GetIndexFromXY(e.X, e.Y)] = t;
	public void SetTile16At(int x, int y, Tile16 t) => ListOf[GetIndexFromXY(x, y)] = t;
	public Tile16 GetTile16At(int id) => ListOf[id];
	public Tile16 SetTile16At(MouseEventArgs e) => ListOf[GetIndexFromXY(e.X, e.Y)];
	public Tile16 GetTile16At(int x, int y) => ListOf[GetIndexFromXY(x, y)];

	public void RefreshGraphicsSheet()
	{
		var x = 0;
		var y = 0;

		foreach (var t in ListOf)
		{
			DrawTile16ToCanvas(PreviewCanvas, x, y, t);

			x += TileSpan;

			if (x >= TileSpan * TilesPerRow)
			{
				x = 0;
				y += TileSpan;
			}
		}
	}

	public void DrawTile16ToCanvas(IGraphicsCanvas canvas, int x, int y, Tile16 t16)
	{
		var (tnw, pnw) = Graphics.GetBackgroundTileWithPalette(t16.Tile0);
		var (tne, pne) = Graphics.GetBackgroundTileWithPalette(t16.Tile1);
		var (tsw, psw) = Graphics.GetBackgroundTileWithPalette(t16.Tile2);
		var (tse, pse) = Graphics.GetBackgroundTileWithPalette(t16.Tile3);

		tnw.DrawToCanvas(canvas, x, y, (byte) pnw, t16.Tile0.HFlip, t16.Tile0.VFlip);
		tne.DrawToCanvas(canvas, x + 8, y, (byte) pne, t16.Tile1.HFlip, t16.Tile1.VFlip);
		tsw.DrawToCanvas(canvas, x, y + 8, (byte) psw, t16.Tile2.HFlip, t16.Tile2.VFlip);
		tse.DrawToCanvas(canvas, x + 8, y + 8, (byte) pse, t16.Tile3.HFlip, t16.Tile3.VFlip);
	}

	public void DrawTile16ToCanvas(IGraphicsCanvas canvas, int x, int y, ushort t16)
	{
		DrawTile16ToCanvas(canvas, x, y, ListOf[t16]);
	}

	public byte[] GetByteData()
	{
		var ret = new List<byte>();

		foreach (var tile in ListOf)
		{
			ret.AddRange(tile.GetByteData());
		}

		return ret.ToArray();
	}
}
