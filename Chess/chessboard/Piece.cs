namespace chessboard
{
    internal class Piece
    {
        public Board? Board { get; protected set; }
        public Position? Position { get; set; }
        public Color? Color { get; protected set; }
        public int SumMoves { get; set; }

        public Piece(Board? board, Position? position, Color? color)
        {
            Board = board;
            Position = position;
            Color = color;
            SumMoves = 0;
        }
    }
}
