namespace ZCompressLibrary
{
	internal static class fake_mem
	{
		internal static void memcpy(byte[] dest, int dest_offset, byte[] source, int source_offset, int length)
		{
			for (int i = 0; i < length; ++i)
			{
				dest[dest_offset + i] = source[source_offset + i];
			}
		}

		internal static void memcpy(byte[] dest, int dest_offset, byte[] source, int length)
		{
			for (int i = 0; i < length; ++i)
			{
				dest[i + dest_offset] = source[i];
			}
		}

		internal static void memset(byte[] dest, int offset, byte value, int length)
		{
			for (int i = 0; i < length; ++i)
			{
				dest[i + offset] = value;
			}
		}

		internal static void memset(int[] dest, int value, int length)
		{
			for (int i = 0; i < length; ++i)
			{
				dest[i] = value;
			}
		}

		internal static void memset(byte[][] dest, byte value)
		{
			for (int i = 0; i < dest.GetLength(0); ++i)
			{
				for (int j = 0; j < dest[i].Length; ++j)
				{
					dest[i][j] = value;
				}
			}
		}

		internal static bool memcmp(byte[] buf1, int buf1offset, byte[] buf2, int buf2offset, int size)
		{
			int i = 0;
			while (i < size)
			{
				if (buf1[buf1offset + i] != buf2[buf2offset + i])
				{
					return false;
				}
				++i;
			}

			return true;
		}
	}
}
