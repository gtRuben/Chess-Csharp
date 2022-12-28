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
            Screen.PrintMatch(match, "Origin: ");
            Position origin = ChessPosition.ReadPosition();
            match.ValidateOriginPosition(origin);

            Screen.PrintMatch(match, origin, "Destination: ");
            Position target = ChessPosition.ReadPosition();
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
