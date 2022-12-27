using chessboard;

namespace game
{
    internal class King : Piece
    {
        public King(Board board, Color? color) : base(board, color)
        {
        }

        private bool CanMove(Position position)
        {
            Piece piece = Board.Piece(position);
            return piece is null || piece.Color != Color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] possibleMoves = new bool[Board.Rows, Board.Columns];
            Position aux = new Position(0, 0);

            // above
            aux.SetPosition(Position.Row - 1, Position.Column);
            if (Board.ValidPosition(aux) && CanMove(aux))
                possibleMoves[aux.Row, aux.Column] = true;

            // north east
            aux.SetPosition(Position.Row - 1, Position.Column + 1);
            if (Board.ValidPosition(aux) && CanMove(aux))
                possibleMoves[aux.Row, aux.Column] = true;

            // right
            aux.SetPosition(Position.Row, Position.Column + 1);
            if (Board.ValidPosition(aux) && CanMove(aux))
                possibleMoves[aux.Row, aux.Column] = true;

            // southeast
            aux.SetPosition(Position.Row + 1, Position.Column + 1);
            if (Board.ValidPosition(aux) && CanMove(aux))
                possibleMoves[aux.Row, aux.Column] = true;

            // below
            aux.SetPosition(Position.Row + 1, Position.Column);
            if (Board.ValidPosition(aux) && CanMove(aux))
                possibleMoves[aux.Row, aux.Column] = true;

            // south-west
            aux.SetPosition(Position.Row + 1, Position.Column - 1);
            if (Board.ValidPosition(aux) && CanMove(aux))
                possibleMoves[aux.Row, aux.Column] = true;

            // left
            aux.SetPosition(Position.Row, Position.Column - 1);
            if (Board.ValidPosition(aux) && CanMove(aux))
                possibleMoves[aux.Row, aux.Column] = true;

            // northwest
            aux.SetPosition(Position.Row - 1, Position.Column - 1);
            if (Board.ValidPosition(aux) && CanMove(aux))
                possibleMoves[aux.Row, aux.Column] = true;

            return possibleMoves;
        }

        public override string? ToString()
        {
            return "K";
        }
    }
}
