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
            return _pieces[row,column];
        }
    }
}
