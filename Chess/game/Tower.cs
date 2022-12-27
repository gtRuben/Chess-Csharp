using chessboard;
using System.Runtime.Intrinsics.X86;

namespace game
{
    internal class Tower : Piece
    {
        public Tower(Board board, Color? color) : base(board, color)
        {
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] possibleMoves = new bool[Board.Rows, Board.Columns];
            Position aux = new Position(0, 0);

            // above
            aux.SetPosition(Position.Row - 1, Position.Column);
            while (Board.ValidPosition(aux) && CanMove(aux))
            {
                possibleMoves[aux.Row, aux.Column] = true;

                //if (!Board.ValidPosition(aux) || !CanMove(aux)) break;

                aux.Row--;
            }


            // right
            aux.SetPosition(Position.Row, Position.Column + 1);
            while (Board.ValidPosition(aux) && CanMove(aux))
            {
                possibleMoves[aux.Row, aux.Column] = true;

                //if (!Board.ValidPosition(aux) || !CanMove(aux)) break;

                aux.Column++;
            }

            // below
            aux.SetPosition(Position.Row + 1, Position.Column);
            while (Board.ValidPosition(aux) && CanMove(aux))
            {
                possibleMoves[aux.Row, aux.Column] = true;

                //if (!Board.ValidPosition(aux) || !CanMove(aux)) break;

                aux.Row++;
            }

            // left
            aux.SetPosition(Position.Row, Position.Column - 1);
            while (Board.ValidPosition(aux) && CanMove(aux))
            {
                possibleMoves[aux.Row, aux.Column] = true;

                //if (!Board.ValidPosition(aux) || !CanMove(aux)) break;

                aux.Column--;
            }

            return possibleMoves;
        }

        public override string? ToString()
        {
            return "T";
        }
    }
}
