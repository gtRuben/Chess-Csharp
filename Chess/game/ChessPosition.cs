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
            string position = Console.ReadLine();
            char column = position[0];
            int row = int.Parse($"{position[1]}");
            return new ChessPosition(column, row).ToPosition();
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
