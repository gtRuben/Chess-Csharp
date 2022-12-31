using chessboard;
using game;

namespace Chess
{
    internal class Screen
    {
        public static void PrintMatch(ChessGame match, string message)
        {
            PrintChessboard(match.Board);
            ShowPlayInfo(match, message);
        }


        public static void PrintMatch(ChessGame match, Position position, string message)
        {
            PrintChessboard(match.Board, position);
            ShowPlayInfo(match, message);
        }


        private static void PrintChessboard(Board board, Position? position = null)
        {
            Console.Clear();
            Console.WriteLine();
            ConsoleColor defaultBackColor = Console.BackgroundColor;
            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write("\t" + (8 - i) + "  ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (position != null)
                    {
                        if (board.Piece(position).PossibleMoves()[i, j])
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                        }
                    }
                    PrintPiece(board.Piece(i, j));
                    Console.BackgroundColor = defaultBackColor;
                }
                Console.WriteLine();
            }
            Console.WriteLine("\t   a b c d e f g h");
        }


        private static void PrintPiece(Piece piece)
        {
            if (piece is null)
            {
                Console.Write("- ");
            }
            else
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
                Console.Write(" ");
            }
        }


        private static void ShowPlayInfo(ChessGame match, string message)
        {
            if (!match.Finished)
            {
                if (match.CapturedPieces(Color.White).Count > 0)
                {
                    Console.WriteLine();
                    Console.Write(" White losses:");
                    PrintCapturedPieces(match.CapturedPieces(Color.White));
                }
                if (match.CapturedPieces(Color.Black).Count > 0)
                {
                    Console.WriteLine();
                    Console.Write(" Black losses:");
                    PrintCapturedPieces(match.CapturedPieces(Color.Black), true);
                }
                Console.WriteLine("\n");
                Console.WriteLine($" Round {match.Round}: {match.CurrentPlayer}'s turn.");
                if (match.InCheck)
                {
                    Console.WriteLine(" You're in check!");
                }
                Console.Write(" " + message);
            }
            else
            {
                Console.WriteLine($"\n Checkmate! {match.CurrentPlayer} won!");
                Console.WriteLine($"\n\t    {message}");
            }

        }


        private static void PrintCapturedPieces(IEnumerable<Piece> capturedPieces, bool isBlack = false)
        {
            Console.Write(" [");
            ConsoleColor aux = Console.ForegroundColor;
            if (!isBlack)
            {
                foreach (Piece piece in capturedPieces)
                {
                    Console.Write($" {piece}");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                foreach (Piece piece in capturedPieces)
                {
                    Console.Write($" {piece}");
                }
            }
            Console.ForegroundColor = aux;
            Console.Write(" ]");
        }
    }
}
