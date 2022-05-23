﻿using static ZeldaFullEditor.Modeling.GameData.GraphicsData.Palettes.PaletteType;

namespace ZeldaFullEditor.Modeling.GameData.GraphicsData.Palettes
{
	/// <summary>
	/// Represents an incomplete palette that may be loaded into a <see cref="FullPalette"/>.
	/// </summary>
	public class PartialPalette : IByteable
	{
		/// <summary>
		/// Encapsulates a method used by <see cref="GetNextColor"/> to help iterate over the real palette and the virtual palette
		/// simultaneously in such a way that virtual entries with no corresponding real entry yield <see langword="null"/>. 
		/// </summary>
		/// <param name="virtualindex">The virtual index of the palette the enumator is currently delivering.</param>
		/// <param name="realindex">A reference to the real index of the palette that the method is responsible for incrementing.</param>
		/// <returns>
		/// A <see cref="SNESColor"/> structure in the real palette corresponding to the entry in the virtual palette;
		/// or <see langword="null"/> if the virtual palette entry is omitted from the real palette.
		/// </returns>
		private delegate SNESColor? GetNextEntry(int virtualindex, ref int realindex);

		private SNESColor[] Palette { get; init; }

		/// <summary>
		/// The number of colors this palette represents when written to CGRAM, including omitted transparency values.
		/// </summary>
		public int VirtualSize { get; }

		/// <summary>
		/// The actual, physical size of this palette in colors.
		/// </summary>
		public int RealSize { get; }

		public PaletteInfo Info { get; }

		/// <summary>
		/// A delegate function assigned based on the palette type that will help an enumerator
		/// consume the real values in a palette and skip over the virtual, omitted transparent values.
		/// </summary>
		private GetNextEntry NextColor { get; }

		/// <summary>
		/// <para>
		/// Initializes a new instance of the <see cref="PartialPalette"/> class with the specified CGRAM color data that will
		/// be converted into an array of <see cref="SNESColor"/> structures.
		/// </para>
		/// <para>
		/// If <paramref name="colors"/> is not of the correct length, an <see cref="ArgumentException"/> error will be thrown.
		/// </para>
		/// </summary>
		/// <param name="colors">An array of <see langword="ushort"/> values that </param>
		/// <param name="info">A <see cref="PaletteInfo"/> record detailing the palette type and ROM location.</param>
		/// <exception cref="ArgumentException"></exception>
		public PartialPalette(ushort[] colors, PaletteInfo info)
		{
			NextColor = (Info = info).Type switch
			{
				DungeonPalette => GetNextColorTrans0,
				SpriteAux1Palette  => GetNextColorNormal,
				SpriteAux2Palette => GetNextColorNormal,
				SpriteAux3Palette => GetNextColorNormal,
				FullSpritePalette => GetNextColorTrans0,
				MailPalette => GetNextColorNormal,
				SwordPalette => GetNextColorNormal,
				ShieldPalette => GetNextColorNormal,
				HUDPalette => GetNextColorNormal,
				OWAnim => GetNextColorNormal,
				OWMapPalette => GetNextColorNormal,
				UWMapPalette => GetNextColorNormal,
				PolyhedralPalette => GetNextColorNormal,
				OWMain => GetNextColorBigHalves,
				OWAux => GetNextColorBigHalves,
				UWMapSpritePalette => GetNextColorBigHalves,
				_ => throw new ArgumentException($"Unrecognized {typeof(PaletteType).Name}: {Info.Type}"),
			};

			if (colors.Length != RealSize)
			{
				throw new ArgumentException($"The {nameof(colors)} argument must be of exactly length {RealSize} for palette type {Info.Type}.");
			}

			RealSize = Info.Type.GetRealSize();
			VirtualSize = Info.Type.GetVirtualSize();
			Palette = new SNESColor[RealSize];
		}

		public void SetColorAt(int index, byte r, byte g, byte b)
		{
			Palette[index] = new(r, g, b);
		}

		public void SetColorAt(int index, Color c)
		{
			Palette[index] = new(c.To555Short());
		}

		public Color GetRealColorAt(int index)
		{
			return Palette[index].RealColor;
		}


		/// <summary>
		/// Creates an enumerator that delivers values with the following criteria:
		/// <list type="bullet">
		/// <item>The enumerator iterates over the virtual palette.</item>
		/// <item>The enumator invokes a delegate assigned at instantiation to consume the real palette.</item>
		/// <item>When the enumerator is delivering a color only present in the virtual palette, it will yield <see langword="null"/></item>
		/// </list>
		/// </summary>
		public IEnumerable<SNESColor?> GetNextColor()
		{
			int virtualindex = 0;
			int realindex = 0;

			while (virtualindex < VirtualSize)
			{
				yield return NextColor(virtualindex++, ref realindex);
			}
		}

		private SNESColor? GetNextColorTrans0(int virtualindex, ref int realindex)
		{
			return (virtualindex % 16) switch
			{
				0 => null,
				_ => Palette[realindex++],
			};
		}
		
		private SNESColor? GetNextColorBigHalves(int virtualindex, ref int realindex)
		{
			return (virtualindex % 16) switch
			{
				0 or > 8 => null,
				_ => Palette[realindex++],
			};
		}

		private SNESColor? GetNextColorNormal(int virtualindex, ref int realindex)
		{
			return Palette[virtualindex++];
		}

		public byte[] GetByteData()
		{
			List<byte> ret = new(RealSize * 2);

			foreach (var c in Palette)
			{
				ret.Add(c.CGRAMValue);
			}

			return ret.ToArray();
		}
	}
}
