
using Chess;
using chessboard;
using game;


try
{
    ChessGame match = new ChessGame();

    while (!match.Finished)
    {
        try
        {
            Screen.PrintChessboard(match.Board);
            Screen.ShowPlayInfo(match, "Origin: ");
            Position origin = Screen.ReadPosition();
            match.ValidateOriginPosition(origin);

            Screen.PrintChessboard(match.Board, match.Board.Piece(origin).PossibleMoves());
            Screen.ShowPlayInfo(match, "Destination: ");
            Position target = Screen.ReadPosition();
            match.ValidateTargetPosition(origin, target);

            match.ToPlay(origin, target);
        }
        catch (BoardException exception)
        {
            Console.WriteLine(exception.Message);
            Console.ReadLine();
        }
    }
}
catch (BoardException exception)
{
    Console.WriteLine(exception.Message);
}
Console.ReadLine();
