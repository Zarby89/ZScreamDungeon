using System;
using System.Collections.Generic;
using System.Text;

namespace ZCompressLibrary
{
	internal class Common
	{
		internal const int D_NINTENDO_C_MODE1 = 0;
		internal const int D_NINTENDO_C_MODE2 = 1;

		internal const int D_CMD_COPY = 0;
		internal const int D_CMD_BYTE_REPEAT = 1;
		internal const int D_CMD_WORD_REPEAT = 2;
		internal const int D_CMD_BYTE_INC = 3;
		internal const int D_CMD_COPY_EXISTING = 4;

		internal const int D_MAX_NORMAL_LENGTH = 32;
		internal const int D_MAX_LENGTH = 1024;

		internal const int INITIAL_ALLOC_SIZE = 1024;
	}
}
