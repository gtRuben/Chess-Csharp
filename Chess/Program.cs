
using Chess;
using chessboard;
using game;


try
{
    ChessGame match = new ChessGame();
    Screen.PrintChessboard(match.Board);
}
catch (BoardException exception)
{
    Console.WriteLine(exception.Message);
}
Console.ReadLine();
