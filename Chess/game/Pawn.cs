using chessboard;

namespace game
{
    internal class Pawn : Piece
    {
        public Pawn(Board board, Color? color) : base(board, color)
        {
        }


        public override bool[,] PossibleMoves()
        {
            bool[,] possibleMoves = new bool[Board.Rows, Board.Columns];
            Position aux = new(0, 0);

            if (Color == chessboard.Color.White)
            {
                // first move
                if (SumMoves == 0)
                {
                    aux.SetPosition(Position.Row - 2, Position.Column);
                    if (!Board.TheresAPiece(aux))
                        possibleMoves[aux.Row, aux.Column] = true;
                }
                // above
                aux.SetPosition(Position.Row - 1, Position.Column);
                if (Board.ValidPosition(aux) && !Board.TheresAPiece(aux))
                    possibleMoves[aux.Row, aux.Column] = true;

                // north east
                aux.SetPosition(Position.Row - 1, Position.Column + 1);
                if (Board.ValidPosition(aux) && Board.TheresAPiece(aux))
                    if (Board.Piece(aux).Color != Color)
                        possibleMoves[aux.Row, aux.Column] = true;

                // northwest
                aux.SetPosition(Position.Row - 1, Position.Column - 1);
                if (Board.ValidPosition(aux) && Board.TheresAPiece(aux))
                    if (Board.Piece(aux).Color != Color)
                        possibleMoves[aux.Row, aux.Column] = true;
            }
            else
            {
                // first move
                if (SumMoves == 0)
                {
                    aux.SetPosition(Position.Row + 2, Position.Column);
                    if (!Board.TheresAPiece(aux))
                        possibleMoves[aux.Row, aux.Column] = true;
                }
                // below
                aux.SetPosition(Position.Row + 1, Position.Column);
                if (Board.ValidPosition(aux) && !Board.TheresAPiece(aux))
                    possibleMoves[aux.Row, aux.Column] = true;

                // northwest
                aux.SetPosition(Position.Row + 1, Position.Column - 1);
                if (Board.ValidPosition(aux) && Board.TheresAPiece(aux))
                    if (Board.Piece(aux).Color != Color)
                        possibleMoves[aux.Row, aux.Column] = true;

                // southeast
                aux.SetPosition(Position.Row + 1, Position.Column + 1);
                if (Board.ValidPosition(aux) && Board.TheresAPiece(aux))
                    if (Board.Piece(aux).Color != Color)
                        possibleMoves[aux.Row, aux.Column] = true;
            }

            return possibleMoves;
        }


        public override string? ToString()
        {
            return "p";
        }
    }
}
