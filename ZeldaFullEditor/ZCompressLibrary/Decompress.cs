using System;
using System.Collections.Generic;

namespace ZCompressLibrary
{
	public static class Decompress
	{
		public static byte[] ALTTPDecompressGraphics(byte[] c_data, int start, int max_length, ref int compressedsize)
		{
			return std_nintendo_decompress(c_data, start, max_length, Common.D_NINTENDO_C_MODE2, ref compressedsize);
		}

		public static byte[] ALTTPDecompressOverworld(byte[] c_data, int start, int max_length, ref int compressedsize)
		{
			return std_nintendo_decompress(c_data, start, max_length, Common.D_NINTENDO_C_MODE1, ref compressedsize);
		}

		internal static byte[] std_nintendo_decompress(byte[] c_data, int start, int max_length, byte mode, ref int compressedsize)
		{
			byte[] u_data = new byte[Common.INITIAL_ALLOC_SIZE];
			int allocated_memory = Common.INITIAL_ALLOC_SIZE;

			byte header;
			int c_data_pos;
			int u_data_pos;
			int max_offset;

			max_offset = 0;
			if (max_length != 0)
			{
				max_offset = start + max_length;
			}

			header = c_data[start];
			u_data_pos = 0;
			c_data_pos = start;

			while (header != 0xFF)
			{
				int length;
				byte command;

				command = (byte) (header >> 5); // 3 hightest bits are the command
				length = (header & 0x1F); // The rest is the length

				// Extended header, to allow for bigger length value than 32
				if (command == 7)
				{
					// The command are the next 3 bits
					command = (byte) ((header >> 2) & 7);
					// 2 bits in the original header are the height bit for the new length
					// The next byte is added to this length

					length = ((header & 3) << 8) + c_data[c_data_pos + 1];
					c_data_pos++;
				}

				//length value starts at 0, 0 is 1
				length++;
				//printf("%d[%d]", command, length);
				//s_debug("header %02X - Command : %d , length : %d\n", header, command, length);
				if (c_data_pos >= max_offset && max_offset != 0)
				{
					//std_nintendo_decompression_error = "Compression string exceed the max_length specified";
					//goto error;
					throw new Exception("Compression string exceed the max_length specified");
				}

				if (u_data_pos + length + 1 > allocated_memory) // Adjust allocated memory
				{
					//s_debug("Memory get reallocated by %d was %d\n", INITIAL_ALLOC_SIZE, allocated_memory);
					Array.Resize(ref u_data, allocated_memory + Common.INITIAL_ALLOC_SIZE);
					allocated_memory += Common.INITIAL_ALLOC_SIZE;
				}

				switch (command)
				{
					case Common.D_CMD_COPY:
						// No compression, data are copied as
						if (max_offset != 0 && c_data_pos + 1 + length > max_offset)
						{
							//std_nintendo_decompression_error = my_asprintf("A copy command exceed the available data %d > %d (max_length specified)\n", c_data_pos + 1 + length, max_offset);
							//goto error;
							throw new Exception(string.Format("A copy command exceed the available data {0} > {1} (max_length specified)\n", c_data_pos + 1 + length, max_offset));
						}

						//memcpy(u_data + u_data_pos, c_data + c_data_pos + 1, length);
						fake_mem.memcpy(u_data, u_data_pos, c_data, c_data_pos + 1, length);
						c_data_pos += length + 1;
						break;

					case Common.D_CMD_BYTE_REPEAT:
						// Copy the same byte length time
						//memset(u_data + u_data_pos, c_data[c_data_pos + 1], length);
						fake_mem.memset(u_data, u_data_pos, c_data[c_data_pos + 1], length);
						c_data_pos += 2;
						break;

					case Common.D_CMD_WORD_REPEAT:
						// Next byte is A, the one after is B, copy the sequence AB length times
						byte a = c_data[c_data_pos + 1];
						byte b = c_data[c_data_pos + 2];
						for (int i = 0; i < length; i = i + 2)
						{
							u_data[u_data_pos + i] = a;
							if ((i + 1) < length)
							{
								u_data[u_data_pos + i + 1] = b;
							}
						}

						c_data_pos += 3;
						break;

					case Common.D_CMD_BYTE_INC:
						// Next byte is copied and incremented length time
						for (int i = 0; i < length; i++)
						{
							u_data[u_data_pos + i] = (byte) (c_data[c_data_pos + 1] + i);
						}

						c_data_pos += 2;
						break;

					case Common.D_CMD_COPY_EXISTING:
						// Next 2 bytes form an offset to pick data from the output
						//printf("%02X,%02X\n", (unsigned char) c_data[c_data_pos + 1], (unsigned char) c_data[c_data_pos + 2]);
						ushort offset = 0;
						if (mode == Common.D_NINTENDO_C_MODE2)
						{
							offset = (ushort) (c_data[c_data_pos + 1] | (c_data[c_data_pos + 2] << 8));
						}
						if (mode == Common.D_NINTENDO_C_MODE1)
						{
							offset = (ushort) (c_data[c_data_pos + 2] | (c_data[c_data_pos + 1] << 8));
						}
						if (offset > u_data_pos)
						{
							//std_nintendo_decompression_error = my_asprintf("Offset for command copy existing is larger than the current position (Offset : 0x%04X | Pos : 0x%06X\n", offset, u_data_pos);
							//goto error;
							throw new Exception(string.Format("Offset for command copy existing is larger than the current position (Offset : {0} | Pos : {1}\n", offset.ToString("X4"), u_data_pos.ToString("X6")));
						}
						if (u_data_pos + length + 1 > allocated_memory) // Adjust allocated memory
						{
							//s_debug("Memory get reallocated by %d was %d\n", INITIAL_ALLOC_SIZE, allocated_memory);
							Array.Resize(ref u_data, allocated_memory + Common.INITIAL_ALLOC_SIZE);
							allocated_memory += Common.INITIAL_ALLOC_SIZE;
						}

						//memcpy(u_data + u_data_pos, u_data + offset, length);
						fake_mem.memcpy(u_data, u_data_pos, u_data, offset, length);
						c_data_pos += 3;
						break;

					default:
						/*
                        {
                            std_nintendo_decompression_error = "Invalid command in the header for decompression";
                            goto error;
                        }
                        */

						throw new Exception("Invalid command in the header for decompression");
				}

				u_data_pos += length;
				//printf("%d|%d\n", c_data_pos, u_data_pos);
				header = c_data[c_data_pos];
			}

			Array.Resize(ref u_data, u_data_pos);

			compressedsize = c_data_pos + 1 - start;
			return u_data;
		}
	}
}
