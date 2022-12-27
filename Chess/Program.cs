
using Chess;
using chessboard;
using game;


try
{
    ChessGame match = new ChessGame();

    while (!match.Finished)
    {
        Screen.PrintChessboard(match.Board);
        Position origin = Screen.ReadPosition("Origem: ");
        Screen.PrintChessboard(match.Board, match.Board.Piece(origin).PossibleMoves());
        Position destin = Screen.ReadPosition("Destino: ");

        match.MovePiece(origin, destin);
    }
}
catch (BoardException exception)
{
    Console.WriteLine(exception.Message);
}
Console.ReadLine();
