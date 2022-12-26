using chessboard;
using game;

namespace Chess
{
    internal class Screen
    {
        public static void PrintPiece(Piece piece)
        {
            if (piece.Color == Color.White)
            {
                Console.Write(piece);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = aux;
            }
        }

        public static void PrintChessboard(Board board)
        {
            Console.WriteLine();
            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write("\t" + (8 - i) + "  ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (board.Piece(i, j) is null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        PrintPiece(board.Piece(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("\t   a b c d e f g h");
        }

        public static Position ReadPosition(string message)
        {
            Console.Write(" " + message);
            string position = Console.ReadLine();
            char column = position[0];
            int row = int.Parse($"{position[1]}");
            return new ChessPosition(column, row).ToPosition();
        }
    }
}
