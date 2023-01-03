using chessboard;

namespace game
{
    internal class Knight : Piece
    {
        public Knight(Board board, Color? color) : base(board, color)
        {
        }


        public override bool[,] PossibleMoves()
        {
            bool[,] possibleMoves = new bool[Board.Rows, Board.Columns];
            Position aux = new Position(0, 0);

            // 2above + 1right
            aux.SetPosition(Position.Row - 2, Position.Column + 1);
            if (Board.ValidPosition(aux) && FreeWay(aux))
                possibleMoves[aux.Row, aux.Column] = true;

            // 1above + 2right
            aux.SetPosition(Position.Row - 1, Position.Column + 2);
            if (Board.ValidPosition(aux) && FreeWay(aux))
                possibleMoves[aux.Row, aux.Column] = true;

            // 1below + 2right
            aux.SetPosition(Position.Row + 1, Position.Column + 2);
            if (Board.ValidPosition(aux) && FreeWay(aux))
                possibleMoves[aux.Row, aux.Column] = true;

            // 2below + 1right
            aux.SetPosition(Position.Row + 2, Position.Column + 1);
            if (Board.ValidPosition(aux) && FreeWay(aux))
                possibleMoves[aux.Row, aux.Column] = true;

            // 2below + 1left
            aux.SetPosition(Position.Row + 2, Position.Column - 1);
            if (Board.ValidPosition(aux) && FreeWay(aux))
                possibleMoves[aux.Row, aux.Column] = true;

            // 1below + 2left
            aux.SetPosition(Position.Row + 1, Position.Column - 2);
            if (Board.ValidPosition(aux) && FreeWay(aux))
                possibleMoves[aux.Row, aux.Column] = true;

            // 1above + 2left
            aux.SetPosition(Position.Row - 1, Position.Column - 2);
            if (Board.ValidPosition(aux) && FreeWay(aux))
                possibleMoves[aux.Row, aux.Column] = true;

            // 2above + 1left
            aux.SetPosition(Position.Row - 2, Position.Column - 1);
            if (Board.ValidPosition(aux) && FreeWay(aux))
                possibleMoves[aux.Row, aux.Column] = true;

            return possibleMoves;
        }


        public override string ToString()
        {
            return "H";
        }
    }
}
