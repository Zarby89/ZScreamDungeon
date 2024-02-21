namespace ZeldaFullEditor
{
	public static partial class FastRomifier
	{
		public static int Fastify(byte[] rom)
		{
			int bytesChanged = 0;

			foreach (var (address, fixType) in FixList)
			{
				int byteCount;

				// Get a count of how many bytes need to be checked
				// We'll look for instructions that are exactly vanilla
				// otherwise we can't be certain they're actually what we have them marked as
				switch (fixType)
				{
					case Fix.JSL:
					case Fix.JML:
					case Fix.LoadW:
						byteCount = 4;
						break;

					case Fix.LoadB:
					case Fix.dl:
					case Fix.MVN:
						byteCount = 3;
						break;

					default:
						continue;
				}

				// compare the current rom to the vanilla rom
				if (!CompareToVanilla(address, address + byteCount))
				{
					continue;
				}

				// pick which byte needs to be moved to a fast bank
				switch (fixType)
				{
					case Fix.JSL:
					case Fix.JML:
						FixOneByte(address + 3);
						break;

					case Fix.LoadB:
					case Fix.LoadW:
						FixOneByte(address + 1);
						break;

					case Fix.dl:
						FixOneByte(address + 2);
						break;

					case Fix.MVN:
						FixOneByte(address + 1);
						FixOneByte(address + 2);
						break;

					default:
						continue;
				}

			}

			// Fix tabulated bytes that correspond to a bank
			foreach (var (start, end) in FixRanges)
			{
				if (!CompareToVanilla(start, end))
				{
					continue;
				}

				for (int addr = start; addr < end; addr++)
				{
					FixOneByte(addr);
				}
			}

			// dumb polyhedral bug fix
			// TODO maybe move this to a patch file
			if (CompareToVanilla(0x0CC376, 0x0CC37A))
			{
				// TODO see if this is really needed?
				// Needed it for the rewrite, but that also optimized a lot of other stuff
				rom[0x0CC377.SnesToPc()] = 0xA0;
			}


			return bytesChanged;


			// local function to compare ranges
			// arguments are SNES addresses
			bool CompareToVanilla(int addr, int end)
			{
				end = end.SnesToPc();
				addr = addr.SnesToPc();

				for (; addr < end; addr++)
				{
					if (rom[addr] != VanillaROM.Data[addr])
					{
						return false;
					}
				}

				return true;
			}

			// local function to fix banks
			// arguments are SNES addresses
			void FixOneByte(int offset)
			{
				offset = offset.SnesToPc();

				switch (rom[offset])
				{
					// these should never really happen, but just in case
					case 0x70: // Avoid SRAM, because I'm not 100% confident in how flashcarts use this bank

					case 0x7F: // Avoid WRAM, because it can never be fast, and flashcarts use this area sometimes (?)
					case 0x7E:
						return;
				}
				bytesChanged++;
				rom[offset] |= 0x80;
			}
		}

		private enum Fix
		{
			None = 0,   // nothing
			JSL = 1,    // JSL long
			JML = 2,    // JML long
			LoadB = 3,  // LD?.b #$ii
			LoadW = 4,  // LD?.w #$iiii
			dl = 5,	    // dl long
			MVN = 6,    // MVN ss,dd
		}
	}

	
}
