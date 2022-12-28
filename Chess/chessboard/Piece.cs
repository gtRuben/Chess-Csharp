namespace chessboard
{
    abstract class Piece
    {
        public Board Board { get; protected set; }
        public Position? Position { get; set; }
        public Color? Color { get; protected set; }
        public int SumMoves { get; protected set; }

        public Piece(Board board, Color? color)
        {
            Board = board;
            Position = null;
            Color = color;
            SumMoves = 0;
        }

        public abstract bool[,] PossibleMoves();

        public void AddMovement()
        {
            SumMoves++;
        }

        private protected bool CanMove(Position position)
        {
            Piece piece = Board.Piece(position);
            return piece is null || piece.Color != Color;
        }
    }
}
