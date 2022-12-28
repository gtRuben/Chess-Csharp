namespace chessboard
{
    internal class Board
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        private Piece[,] _pieces;

        public Board(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            _pieces = new Piece[Rows, Columns];
        }

        public Piece Piece(int row, int column)
        {
            return _pieces[row, column];
        }

        public Piece Piece(Position position)
        {
            return _pieces[position.Row, position.Column];
        }

        public void PutPiece(Piece piece, Position position)
        {
            if (TheresAPiece(position))
            {
                throw new BoardException("There's already a piece in that position!");
            }
            piece.Position = position;
            _pieces[position.Row, position.Column] = piece;
        }

        public bool TheresAPiece(Position position)
        {
            ValidatePosition(position);
            return Piece(position) is not null;
        }

        public void ValidatePosition(Position position)
        {
            if (!ValidPosition(position))
            {
                throw new BoardException("Invalid position!");
            }
        }

        public bool ValidPosition(Position position)
        {
            if (position.Row < 0 || position.Column < 0 || position.Row >= Rows || position.Column >= Columns)
            {
                return false;
            }
            return true;
        }

        public Piece? RemovePiece(Position position)
        {
            if (Piece(position) is null)
            {
                return null;
            }
            chessboard.Piece aux = Piece(position);
            aux.Position = null;
            _pieces[position.Row, position.Column] = null;
            return aux;
        }
    }
}
