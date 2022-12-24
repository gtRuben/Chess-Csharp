
using Chess;
using chessboard;
using game;


try
{
    Board b = new Board(8, 8);

    Tower t1 = new Tower(b, Color.Black);
    Position p1 = new Position(0, 0);

    Tower t2 = new Tower(b, Color.Black);
    Position p2 = new Position(1, 1);

    b.PutPiece(t1, p1);
    b.PutPiece(t2, p2);

    Screen.printChessboard(b);

    Console.ReadLine();
}
catch (BoardException exception)
{
    Console.WriteLine(exception.Message);
}
