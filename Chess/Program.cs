
using Chess;
using chessboard;
using game;


try
{
    ChessGame match = new ChessGame();

    while (!match.Finished)
    {
        Console.Clear();
        Screen.PrintChessboard(match.Board);

        Console.WriteLine();
        Position origin = Screen.ReadPosition("Origem: ");
        Position destin = Screen.ReadPosition("Destino: ");

        match.MovePiece(origin, destin);
    }
}
catch (BoardException exception)
{
    Console.WriteLine(exception.Message);
}
Console.ReadLine();
