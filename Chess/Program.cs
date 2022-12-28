
using Chess;
using chessboard;
using game;


try
{
    ChessGame match = new ChessGame();

    while (!match.Finished)
    {
        Screen.PrintChessboard(match.Board);
        Screen.ShowPlayInfo(match, "Origin: ");
        Position origin = Screen.ReadPosition();

        Screen.PrintChessboard(match.Board, match.Board.Piece(origin).PossibleMoves());
        Screen.ShowPlayInfo(match, "Destination: ");
        Position destin = Screen.ReadPosition();

        match.ToPlay(origin, destin);
    }
}
catch (BoardException exception)
{
    Console.WriteLine(exception.Message);
}
Console.ReadLine();
