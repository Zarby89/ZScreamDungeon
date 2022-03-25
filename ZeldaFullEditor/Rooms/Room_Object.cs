using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ZeldaFullEditor
{
	[Serializable]
	public unsafe class Room_Object
	{
		//==========================================================================================
		// Game Related Variables that are used to save data in the rom 
		//==========================================================================================
		public byte x, y; // Position of the object in the room (*8 for draw)
		public byte layer = 0;
		public byte size; // Size of the object
		public bool allBgs = false; // If the object is drawn on BG1 and BG2 regardless of type of BG
									//==========================================================================================
									// Editor Related Variables that are used to draw/position objects
									//==========================================================================================
		public bool lit = false;
		public List<Tile> tiles = new List<Tile>();
		public ushort id;
		public int tileIndex = 0;
		public string name; // Name of the object will be shown on the form
		public byte nx, ny;
		public byte ox, oy;
		public int width, height;
		public int basewidth, baseheight;
		public int sizewidth, sizeheight;
		public Room room;
		public ObjectOption options = 0;
		public int offsetX = 0;
		public int offsetY = 0;
		public bool diagonalFix = false;
		public bool selected = false;
		public bool redraw = false;
		public Sorting sort = Sorting.All;
		public bool preview = false;
		public int previewId = 0;
		byte previousSize = 0;
		public bool showRectangle = false;
		public List<Point> collisionPoint = new List<Point>();

		protected readonly ZScreamer ZS;
		public Room_Object(ZScreamer parent, ushort id, byte x, byte y, byte size, byte layer = 0)
		{
			ZS = parent;
			this.x = x;
			this.y = y;
			this.size = size;
			this.id = id;
			this.layer = layer;
			this.nx = x;
			this.ny = y;
			this.ox = x;
			this.oy = y;
			width = 16;
			height = 16;
		}

		public void getObjectSize()
		{
			previousSize = size;
			size = 1;
			Draw();
			getBaseSize(); // 48
			UpdateSize();
			size = 2;
			Draw();
			getSizeSized(); // 64 - 48
			UpdateSize();
			size = previousSize;
			collisionPoint.Clear();
		}

		public void getBaseSize()
		{
			// Set size on 1
			basewidth = width;
			baseheight = height;
		}

		public void getSizeSized()
		{
			sizeheight = (height - baseheight);
			sizewidth = (width - basewidth);
		}

		public void setRoom(Room r)
		{
			room = r;
		}

		public virtual void Draw()
		{
			collisionPoint.Clear();
		}

		public void GetTileCollision()
		{
			// TODO: Add something here?
		}

		public void UpdateSize()
		{
			width = 8;
			height = 8;
		}

		/// <summary>
		/// Decreases the object's size by 1.
		/// </summary>
		/// <returns><see langword="true"/> when successful</returns>
		public bool DecreaseSize()
		{
			UpdateSize();
			if (size > 0)
			{
				size--;
				return true;
			}
			return false;
		}

		/// <summary>
		/// Increases the object's size by 1.
		/// </summary>
		/// <returns><see langword="true"/> when successful</returns>
		public bool IncreaseSize()
		{
			UpdateSize();

			if (size < 15)
			{
				size++;
				return true;
			}
			return false;
		}


		public void addTiles(int nbr, int pos)
		{
			for (int i = 0; i < nbr; i++)
			{
				tiles.Add(new Tile(ZS.ROM[pos + ((i * 2))], ZS.ROM[pos + ((i * 2)) + 1]));
			}
		}

		public void draw_diagonal_up()
		{
			height = (size + 10) * 8;
			width = (size + 6) * 8;
			diagonalFix = true;

			for (int s = 0; s < size + 6; s++)
			{
				draw_tile(tiles[0], ((s)) * 8, (0 - s) * 8);
				draw_tile(tiles[1], ((s)) * 8, (1 - s) * 8);
				draw_tile(tiles[2], ((s)) * 8, (2 - s) * 8);
				draw_tile(tiles[3], ((s)) * 8, (3 - s) * 8);
				draw_tile(tiles[4], ((s)) * 8, (4 - s) * 8);
			}
		}

		public void draw_diagonal_down()
		{
			for (int s = 0; s < size + 6; s++)
			{
				draw_tile(tiles[0], ((s)) * 8, (0 + s) * 8);
				draw_tile(tiles[1], ((s)) * 8, (1 + s) * 8);
				draw_tile(tiles[2], ((s)) * 8, (2 + s) * 8);
				draw_tile(tiles[3], ((s)) * 8, (3 + s) * 8);
				draw_tile(tiles[4], ((s)) * 8, (4 + s) * 8);
			}
		}

		// Object Initialization (Tiles and special stuff)
		public void init_objects()
		{
			// TODO: Add something here?
		}

		public void updatePos()
		{
			x = nx;
			y = ny;
		}

		public unsafe void draw_tile(Tile t, int xx, int yy, ushort tileUnder = 0xFFFF)
		{
			if (width < xx + 8)
			{
				width = xx + 8;
			}
			if (height < yy + 8)
			{
				height = yy + 8;
			}
			if (preview)
			{
				if (xx < 57 && yy < 57 && xx >= 0 && yy >= 0)
				{
					var alltilesData = (byte*) ZS.GFXManager.currentgfx16Ptr.ToPointer();
					byte* ptr = (byte*) ZS.GFXManager.previewObjectsPtr[previewId].ToPointer();
					TileInfo ti = t.GetTileInfo();
					for (int yl = 0; yl < 8; yl++)
					{
						for (int xl = 0; xl < 4; xl++)
						{
							int mx = xl;
							int my = yl;
							byte r = 0;

							if (ti.H)
							{
								mx = 3 - xl;
								r = 1;
							}
							if (ti.V)
							{
								my = 7 - yl;
							}

							// Formula information to get tile index position in the array
							//((ID / nbrofXtiles) * (imgwidth/2) + (ID - ((ID/16)*16) ))
							int tx = ((ti.id / 16) * 512) + ((ti.id - ((ti.id / 16) * 16)) * 4);
							var pixel = alltilesData[tx + (yl * 64) + xl];
							//nx,ny = object position, xx,yy = tile position, xl,yl = pixel position

							int index = ((xx / 8) * 8) + ((yy / 8) * 512) + ((mx * 2) + (my * 64));
							ptr[index + r ^ 1] = (byte) ((pixel & 0x0F) + ti.palette * 16);
							ptr[index + r] = (byte) (((pixel >> 4) & 0x0F) + ti.palette * 16);
						}
					}
				}
			}
			else
			{
				if (((xx / 8) + nx + offsetX) + ((ny + offsetY + (yy / 8)) * 64) < 4096 && ((xx / 8) + nx + offsetX) + ((ny + offsetY + (yy / 8)) * 64) >= 0)
				{
					ushort td = Tile.GetGFXTileInfo(t.GetTileInfo());

					collisionPoint.Add(new Point(xx + ((nx + offsetX) * 8), yy + ((ny + +offsetY) * 8)));

					if (layer == 0 || layer == 2 || allBgs)
					{
						if (tileUnder == ZS.GFXManager.tilesBg1Buffer[((xx / 8) + offsetX + nx) + ((ny + offsetY + (yy / 8)) * 64)])
						{
							return;
						}

						ZS.GFXManager.tilesBg1Buffer[((xx / 8) + offsetX + nx) + ((ny + offsetY + (yy / 8)) * 64)] = td;
					}

					if (layer == 1 || allBgs)
					{
						if (tileUnder == ZS.GFXManager.tilesBg2Buffer[((xx / 8) + nx + offsetX) + ((ny + offsetY + (yy / 8)) * 64)])
						{
							return;
						}

						ZS.GFXManager.tilesBg2Buffer[((xx / 8) + nx) + offsetX + ((ny + offsetY + (yy / 8)) * 64)] = td;
					}
				}
			}
		}
	}

	[Flags]
	public enum Sorting
	{
		All = 0,
		Wall = 1,
		Horizontal = 2,
		Vertical = 4,
		NonScalable = 8,
		Dungeons = 16,
		Floors = 32,
		Stairs = 64
	}

	[Flags]
	public enum ObjectOption
	{
		Nothing = 0,
		Door = 1,
		Chest = 2,
		Block = 4,
		Torch = 8,
		Bgr = 16,
		Stairs = 32
	}
}



