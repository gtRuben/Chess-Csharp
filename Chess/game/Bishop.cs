using chessboard;

namespace game
{
    internal class Bishop : Piece
    {
        public Bishop(Board board, Color? color) : base(board, color)
        {
        }


        public override bool[,] PossibleMoves()
        {
            bool[,] possibleMoves = new bool[Board.Rows, Board.Columns];
            Position aux = new Position(0,0);

            // north east
            aux.SetPosition(Position.Row - 1, Position.Column + 1);
            while (Board.ValidPosition(aux) && FreeWay(aux))
            {
                possibleMoves[aux.Row, aux.Column] = true;
                if (Board.Piece(aux) != null) break;
                aux.Row--;
                aux.Column++;
            }

            // southeast
            aux.SetPosition(Position.Row + 1, Position.Column + 1);
            while (Board.ValidPosition(aux) && FreeWay(aux))
            {
                possibleMoves[aux.Row, aux.Column] = true;
                if (Board.Piece(aux) != null) break;
                aux.Row++;
                aux.Column++;
            }

            // south-west
            aux.SetPosition(Position.Row + 1, Position.Column - 1);
            while (Board.ValidPosition(aux) && FreeWay(aux))
            {
                possibleMoves[aux.Row, aux.Column] = true;
                if (Board.Piece(aux) != null) break;
                aux.Row++;
                aux.Column--;
            }

            // northwest
            aux.SetPosition(Position.Row - 1, Position.Column - 1);
            while (Board.ValidPosition(aux) && FreeWay(aux))
            {
                possibleMoves[aux.Row, aux.Column] = true;
                if (Board.Piece(aux) != null) break;
                aux.Row--;
                aux.Column--;
            }

            return possibleMoves;
        }


        public override string? ToString()
        {
            return "B";
        }
    }
}
