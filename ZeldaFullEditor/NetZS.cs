using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lidgren.Network;

namespace ZeldaFullEditor.Properties
{
	internal static class NetZS
	{

		internal static NetClient client;
		internal static byte userID;
		internal static bool connected = false;
	}

	internal class NetZSBuffer
	{
		public byte[] buffer;
		int bufferPos = 0;
		public NetZSBuffer(short size) 
		{
			buffer = new byte[size];
			bufferPos = 0;
		}

		public NetZSBuffer(byte[] data)
		{
			buffer = new byte[data.Length];
			Array.Copy(data, buffer, data.Length);
			bufferPos = 0;
		}


		public byte ReadByte()
		{
			byte b = buffer[bufferPos];
			bufferPos += 1;
			return b;
		}

		public short ReadShort()
		{
			short s = (short)(buffer[bufferPos] | (buffer[bufferPos+1]<<8));
			bufferPos += 2;
			return s;
		}
		public ushort ReadUShort()
		{
			ushort s = (ushort) (buffer[bufferPos] | (buffer[bufferPos + 1] << 8));
			bufferPos += 2;
			return s;
		}

		public int ReadInt()
		{
			int i = buffer[bufferPos] | (buffer[bufferPos + 1] << 8) | (buffer[bufferPos + 2] << 16) | (buffer[bufferPos + 3] << 24);
			bufferPos += 4;
			return i;
		}


		public void Write(byte data)
		{
			buffer[bufferPos++] = data;
		}

		public void Write(ushort data)
		{
			buffer[bufferPos++] = (byte)data;
			buffer[bufferPos++] = (byte)(data>>8);
		}

		public void Write(short data)
		{
			buffer[bufferPos++] = (byte) data;
			buffer[bufferPos++] = (byte) (data >> 8);
		}

		public void Write(int data)
		{
			buffer[bufferPos++] = (byte) data;
			buffer[bufferPos++] = (byte) (data >> 8);
			buffer[bufferPos++] = (byte) (data >> 16);
			buffer[bufferPos++] = (byte) (data >> 24);
		}

		public void Write(ulong data)
		{
			buffer[bufferPos++] = (byte) data;
			buffer[bufferPos++] = (byte) (data >> 8);
			buffer[bufferPos++] = (byte) (data >> 16);
			buffer[bufferPos++] = (byte) (data >> 24);
			buffer[bufferPos++] = (byte) (data >> 32);
			buffer[bufferPos++] = (byte) (data >> 40);
			buffer[bufferPos++] = (byte) (data >> 48);
			buffer[bufferPos++] = (byte) (data >> 56);
		}
	}

}
