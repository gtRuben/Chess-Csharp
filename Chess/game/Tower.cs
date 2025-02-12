﻿using chessboard;

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
            while (Board.ValidPosition(aux) && FreeWay(aux))
            {
                possibleMoves[aux.Row, aux.Column] = true;
                if (Board.Piece(aux) != null) break;
                aux.Row--;
            }
            
            // right
            aux.SetPosition(Position.Row, Position.Column + 1);
            while (Board.ValidPosition(aux) && FreeWay(aux))
            {
                possibleMoves[aux.Row, aux.Column] = true;
                if (Board.Piece(aux) != null) break;
                aux.Column++;
            }
            
            // below
            aux.SetPosition(Position.Row + 1, Position.Column);
            while (Board.ValidPosition(aux) && FreeWay(aux))
            {
                possibleMoves[aux.Row, aux.Column] = true;
                if (Board.Piece(aux) != null) break;
                aux.Row++;
            }
            
            // left
            aux.SetPosition(Position.Row, Position.Column - 1);
            while (Board.ValidPosition(aux) && FreeWay(aux))
            {
                possibleMoves[aux.Row, aux.Column] = true;
                if (Board.Piece(aux) != null) break;
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
