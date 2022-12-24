
using Chess;
using chessboard;
using game;


Board b = new Board(8, 8);

b.PutPiece(new Tower(b, Color.Black), new Position(0, 0));
b.PutPiece(new Tower(b, Color.Black), new Position(1, 3));
b.PutPiece(new King(b, Color.Black), new Position(2, 4));

Screen.printChessboard(b);
Console.ReadLine();
