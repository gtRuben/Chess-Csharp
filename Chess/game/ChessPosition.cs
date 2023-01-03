using chessboard;

namespace game
{
    internal class ChessPosition
    {
        public char Column { get; set; }
        public int Row { get; set; }


        public ChessPosition(char column, int row)
        {
            Column = column;
            Row = row;
        }


        public static Position ReadPosition()
        {
            try
            {
                string position = Console.ReadLine();
                if (position.Length != 2)
                {
                    throw new Exception();
                }
                char column = position[0];
                int _column = column - 'a';
                if (_column < 0 || _column > 7)
                {
                    throw new Exception();
                }
                int row = int.Parse($"{position[1]}");
                if (row < 1 || row > 8)
                {
                    throw new Exception();
                }
                return new ChessPosition(column, row).ToPosition();
            }
            catch
            {
                throw new BoardException(" Invalid coordinates.");
            }
        }


        public Position ToPosition()
        {
            return new Position(8 - Row, Column - 'a');
        }


        public override string ToString()
        {
            return $"{Column}{Row}";
        }
    }
}
