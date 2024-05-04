using System;

namespace ZCompressLibrary
{
    internal class compression_piece
    {
        public byte command;
        public int length;
        public byte[] argument;
        public int argument_length;
        public compression_piece next;

        public compression_piece(byte command, int length, byte[] args, int argument_length)
        {
            this.command = command;
            this.length = length;
            this.argument = new byte[argument_length];
            Array.Copy(args, this.argument, argument_length);
            this.argument_length = argument_length;
            this.next = null;
        }

        public static compression_piece merge_copy(compression_piece start)
        {
            compression_piece piece = start;
            while (piece != null)
            {
                if (piece.command == Common.D_CMD_COPY && piece.next != null && piece.next.command == Common.D_CMD_COPY)
                {
                    if (piece.length + piece.next.length < Common.D_MAX_LENGTH)
                    {
                        int previous_length = piece.length;
                        piece.length += piece.next.length;
                        Array.Resize(ref piece.argument, piece.length);
                        piece.argument_length = piece.length;
                        Array.Copy(piece.next.argument, 0, piece.argument, previous_length, piece.next.argument_length);
                        piece.next = piece.next.next;
                        continue;
                    }
                }

                piece = piece.next;
            }

            return start;
        }
    }
}
