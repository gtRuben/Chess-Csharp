using chessboard;

namespace Chess
{
    internal class Screen
    {
        public static void printChessboard(Board board)
        {
            for (int i=0; i < board.Rows; i++)
            {
                for (int j=0; j < board.Columns; j++)
                {
                    if (board.Piece(i, j) is null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(board.Piece(i, j) + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
