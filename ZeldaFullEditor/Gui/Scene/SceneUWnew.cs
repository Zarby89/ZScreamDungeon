﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using ZeldaFullEditor.Properties;
using Microsoft.VisualBasic;
using System.IO.Compression;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Globalization;

using ZeldaFullEditor.SceneModes;
using ZeldaFullEditor.Data.Underworld;

namespace ZeldaFullEditor
{
	public partial class SceneUW : Scene
	{
		public Bitmap tempBitmap = new Bitmap(512, 512);
		Rectangle lastSelectedRectangle;

		public DungeonEditMode CurrentMode => ZS.CurrentUWMode;

		public bool forPreview = false;

		bool resizing = false;
		public bool showLayer1;
		public bool showLayer2;

		private readonly ModeActions layer1Mode;
		private readonly ModeActions layer2Mode;
		private readonly ModeActions layer3Mode;
		private readonly ModeActions layerAllMode;
		private readonly ModeActions doorMode;
		private readonly ModeActions spriteMode;
		private readonly ModeActions secretsMode;
		private readonly ModeActions blockMode;
		private readonly ModeActions torchMode;
		private readonly ModeActions entranceMode;
		private readonly ModeActions collisionMode;

		public IDungeonPlaceable ObjectToPlace { get; set; }

		public DungeonRoom Room { get; set; }

		private readonly Rectangle[] DoorRectangles;
		public SceneUW(ZScreamer zs) : base(zs)
		{
			DoorRectangles = BuildDoorRectangles();

			layer1Mode = layer2Mode = layer3Mode =
			layerAllMode = new ModeActions(OnMouseDown_Layer, OnMouseUp_Layer, OnMouseMove_Layer, OnMouseWheel_Layer,
				Copy_Layer, Paste_Layer, null, Delete_Layer, SelectAll_Layer);

			doorMode = new ModeActions(OnMouseDown_Door, OnMouseUp_Door, OnMouseMove_Door, OnMouseWheel_Door,
				Copy_Door, Paste_Door, Insert_Door, Delete_Door, SelectAll_Door);

			spriteMode = new ModeActions(OnMouseDown_Sprites, OnMouseUp_Sprites, OnMouseMove_Sprites, null,
				Copy_Sprites, Paste_Sprites, null, Delete_Sprites, SelectAll_Sprites);

			secretsMode = new ModeActions(OnMouseDown_Secrets, OnMouseUp_Secrets, OnMouseMove_Secrets, OnMouseWheel_Secrets,
				Copy_Secrets, Paste_Secrets, Insert_Secrets, Delete_Secrets, SelectAll_Secrets);

			blockMode = new ModeActions(OnMouseDown_Blocks, OnMouseUp_Blocks, OnMouseMove_Blocks, null,
				Copy_Blocks, Paste_Blocks, Insert_Blocks, Delete_Blocks, SelectAll_Blocks);

			torchMode = new ModeActions(OnMouseDown_Torch, OnMouseUp_Torch, OnMouseMove_Torch, null,
				Copy_Torch, Paste_Torch, Insert_Torch, Delete_Torch, SelectAll_Torch);

			entranceMode = new ModeActions(OnMouseDown_Entrance, OnMouseUp_Entrance, OnMouseMove_Entrance,
				null, null, null, null, null, null);

			collisionMode = new ModeActions(OnMouseDown_Collision, OnMouseUp_Collision, OnMouseMove_Collision, null,
				null, null, null, null, null);

			Paint += SceneUW_Paint;
		}

		public RoomLayer Layer { get; private set; }

		public void UpdateForMode(DungeonEditMode e)
		{
			Layer = RoomLayer.None;
			switch (e)
			{
				case DungeonEditMode.Layer1:
					ActiveMode = layer1Mode;
					Layer = RoomLayer.Layer1;
					break;
				case DungeonEditMode.Layer2:
					ActiveMode = layer2Mode;
					Layer = RoomLayer.Layer2;
					break;
				case DungeonEditMode.Layer3:
					ActiveMode = layer3Mode;
					Layer = RoomLayer.Layer3;
					break;
				case DungeonEditMode.LayerAll:
					ActiveMode = layerAllMode;
					break;
				case DungeonEditMode.Sprites:
					ActiveMode = spriteMode;
					break;
				case DungeonEditMode.Secrets:
					ActiveMode = secretsMode;
					break;
				case DungeonEditMode.Blocks:
					ActiveMode = blockMode;
					break;
				case DungeonEditMode.Torches:
					ActiveMode = torchMode;
					break;
				case DungeonEditMode.Doors:
					ActiveMode = doorMode;
					break;
				case DungeonEditMode.CollisionMap:
					ActiveMode = collisionMode;
					break;
				case DungeonEditMode.Entrances:
					ActiveMode = entranceMode;
					break;
			}

			// Room.update();
			// TriggerRefresh = true;
		}

		public void MoveSelectedObjects()
		{
			foreach (var o in Room.SelectedObjects)
			{
				if (o is IFreelyPlaceable gg)
				{
					gg.RealX = (byte) (gg.GridX + MoveX).Clamp(0, 80);
					gg.RealY = (byte) (gg.GridY + MoveY).Clamp(0, 80);
				}
			}

			RedrawRoom();
		}

		public void Clear()
		{
			// TODO: Add something here?
			//graphics.Clear(this.BackColor);
		}

		public unsafe void ClearBgGfx()
		{
			byte* bg1data = (byte*) ZS.GFXManager.roomBg1Ptr.ToPointer();
			byte* bg2data = (byte*) ZS.GFXManager.roomBg2Ptr.ToPointer();

			for (int i = 0; i < 512 * 512; i++)
			{
				bg1data[i] = 0;
				bg2data[i] = 0;
			}
		}

		private void RedrawRoom()
		{
			Program.DungeonForm.UpdateFormForSelectedObject(Room.OnlySelectedObject);

			// TODO ROOM.DRAW()

			Refresh();
		}

		public override void Refresh()
		{
			Program.DungeonForm.UpdateUIForRoom(Room, true);
			base.Refresh();
		}


		protected override void OnMouseDown(object sender, MouseEventArgs e)
		{
			if (Room == null)
			{
				return;
			}

			base.OnMouseDown(sender, e);
		}

		protected override void OnMouseMove(object sender, MouseEventArgs e)
		{
			if (MouseIsDown)
			{
				if (MouseX != LastX || MouseY != LastY)
				{
					MoveSelectedObjects();
				}
			}
			base.OnMouseDown(sender, e);
		}

		public void clearCustomCollisionMap()
		{
			throw new NotImplementedException();
		}

		public bool isMouseCollidingWith(IMouseCollidable o, MouseEventArgs e)
		{
			Program.MainForm.GetXYMouseBasedOnZoom(e, out int MX, out int MY);

			// TODO

			return o.PointIsInHitbox(MX, MY);
		}

		public void getObjectsRectangle()
		{
			throw new NotImplementedException();
		}

		public override void Undo()
		{
			throw new NotImplementedException();
		}

		public override void Redo()
		{
			throw new NotImplementedException();
		}



		private static readonly float[][] TranslucencyMatrix = {
			new float[] { 1f, 0, 0, 0, 0 },
			new float[] { 0, 1f, 0, 0, 0 },
			new float[] { 0, 0, 1f, 0, 0 },
			new float[] { 0, 0, 0, 0.5f, 0 },
			new float[] { 0, 0, 0, 0, 1 }
		};

		private void SceneUW_Paint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;

			if (Room == null)
			{
				g.Clear(BackColor);
				return;
			}

			// TODO ????
			//if (Program.MainForm.x2zoom)
			//{
			//	e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
			//	e.Graphics.DrawImage(tempBitmap, Constants.Rect_0_0_1024_1024);
			//}

			if (Program.DungeonForm.x2zoom)
			{
				g = Graphics.FromImage(tempBitmap);
			}

			g.SetClip(Constants.Rect_0_0_512_512);
			g.Clear(Color.Black);

			ImageAttributes draw = null;

			if (Room.LayerMerging.Layer2Translucent)
			{
				draw = new ImageAttributes();
				draw.SetColorMatrix(
					new ColorMatrix(TranslucencyMatrix),
					ColorMatrixFlag.Default,
					ColorAdjustType.Bitmap
				);
			}

			Bitmap top;
			Bitmap bottom;

			if (Room.LayerMerging.Layer2Visible)
			{
				top = ZS.GFXManager.roomBg1Bitmap;
				bottom = null;
			}
			else if (Room.LayerMerging.Layer2OnTop)
			{
				top = ZS.GFXManager.roomBg2Bitmap;
				bottom = ZS.GFXManager.roomBg1Bitmap;
			}
			else
			{
				top = ZS.GFXManager.roomBg1Bitmap;
				bottom = ZS.GFXManager.roomBg2Bitmap;
			}

			g.DrawImage(top, Constants.Rect_0_0_512_512, 0, 0, 512, 512, GraphicsUnit.Pixel, draw);
			if (bottom != null)
			{
				g.DrawImage(bottom, Constants.Rect_0_0_512_512, 0, 0, 512, 512, GraphicsUnit.Pixel, draw);
			}

			// Draw selection
			Pen selectionColor = MouseIsDown ? Pens.LimeGreen : Pens.Green;
			foreach (var o in Room.SelectedObjects)
			{
				g.DrawRectangle(selectionColor, o.SquareHitbox);
			}

			// Draw BG2 outlines
			if (Program.DungeonForm.ShowBG2Outline)
			{
				foreach (var l in Room.AllObjects)
				{
					foreach (var o in l)
					{
						if (o.ObjectType.Specialness == SpecialObjectType.LayerMask)
						{
							g.DrawRectangle(Pens.DarkCyan, o.SquareHitbox);
						}
					}
				}
			}

			// Draw BG2 annotations
			if (Program.DungeonForm.invisibleObjectsTextToolStripMenuItem.Checked)
			{
				foreach (var l in Room.AllObjects)
				{
					foreach (var o in l)
					{
						if (o.ObjectType.Specialness == SpecialObjectType.LayerMask)
						{
							drawText(g, o.RealX, o.RealY, "BG2 mask");
						}
					}
				}
			}

			// Draw chest numbers
			int id = 0;
			if (Program.DungeonForm.showChestIDs)
			{
				foreach (var c in Room.ChestList)
				{
					if (c.IsAssociated)
					{
						drawText(g, c.RealX + 6, c.RealY + 8, id.ToString());
					}
					id++;
				}
			}

			// TODO deal with overlapping shit
			// Draw door text
			id = 0;
			if (Program.DungeonForm.showDoorsIDs)
			{
				foreach (var d in Room.DoorsList)
				{
					drawText(g, d.RealX + 12, d.RealY + 8, id.ToString());

					if (d.DoorType.IsExit)
					{
						drawText(g, d.RealX + 6, d.RealY + 10, "Exit");
					}
					else if (d.DoorType.Category == DoorCategory.LayerSwap)
					{
						drawText(g, d.RealX + 6, d.RealY + 10, "Layer swap");
					}
					else if (d.DoorType.Category == DoorCategory.DungeonSwap)
					{
						drawText(g, d.RealX + 6, d.RealY + 10, "Dungeon swap");
					}

					id++;
				}
			}

			// Draw blocks with Ms
			foreach (var b in Room.BlocksList)
			{
				g.DrawImage(ZS.GFXManager.moveableBlock, b.RealX, b.RealY);
			}

			// Draw staircase targets
			foreach (var s in Room.AllStairs)
			{
				if (s.IsAssociated)
				{
					drawText(g, s.RealX, s.RealY + 18, s.ToString());
				}
			}

			// Draw secret item names
			if (Program.MainForm.showItemsText)
			{
				foreach (var s in Room.SecretsList)
				{
					drawText(g, s.RealX, s.RealY, s.Name);
				}
			}

			// Draw sprite names
			if (Program.MainForm.showSpriteText)
			{
				foreach (var s in Room.SpritesList)
				{
					drawText(g, s.RealX, s.RealY, s.Name);
				}
			}

			// Draw selected entrance position
			if (Program.MainForm.selectedEntrance != null && Program.MainForm.entrancePositionToolStripMenuItem.Checked)
			{
				var n = Program.MainForm.selectedEntrance;
				if (n.RoomID == Room.RoomID)
				{
					g.DrawRectangle(Pens.Orange, n.CameraTriggerX - 128, n.CameraTriggerY - 116, 256, 224);
					int xx = n.XPosition & 0x1FF;
					int yy = n.YPosition & 0x1FF;
					g.DrawLine(Pens.White, xx - 4, yy, xx + 4, yy);
					g.DrawLine(Pens.White, xx, yy - 4, xx, yy + 4);
				}
			}

			// Draw grid
			int wh = (512 / Program.MainForm.gridSize) + 1;

			for (int x = 0, l = 0; x < wh; x++, l += Program.MainForm.gridSize)
			{
				g.DrawLine(Constants.HalfWhitePen, l, 0, l, 512);
				g.DrawLine(Constants.HalfWhitePen, 0, l, 512, l);
			}

			// Done
			if (CurrentMode == DungeonEditMode.Doors)
			{
				g.DrawRectangles(Constants.ThirdGreenPen, DoorRectangles);
			}
			else if (CurrentMode == DungeonEditMode.CollisionMap)
			{
				Draw_Collision(g);
			}

		} // End Paint();


		private void ResetPlacementProperties()
		{
			ObjectToPlace = null;
		}

		// TODO
		private bool CheckIfObjectIsInvalidForPlacement()
		{
			ZeldaException spaghetti = null;

			// TODO probably a switch statement here
			// or maybe even delegates? idk
			if (ObjectToPlace is DungeonSprite && ZS.CurrentUWMode != DungeonEditMode.Sprites)
			{
				spaghetti = new ZeldaException("Sprites can only be placed while working in sprite mode.");
			}
			else if (ObjectToPlace is RoomObject && ZS.CurrentUWMode > DungeonEditMode.Layer3)
			{
				spaghetti = new ZeldaException("Objects can only be placed while working on backgrounds 1, 2, or 3.");
			}
			else if (ObjectToPlace is DungeonTorch && ZS.CurrentUWMode != DungeonEditMode.Torches)
			{
				spaghetti = new ZeldaException("TORCHES");
			}
			else if (ObjectToPlace is DungeonBlock && ZS.CurrentUWMode != DungeonEditMode.Blocks)
			{
				spaghetti = new ZeldaException("BLOCKS");
			}

			if (spaghetti != null)
			{
				MouseIsDown = false;
				ObjectToPlace = null;
				throw spaghetti;
			}

			return true;
		}
	}
}
