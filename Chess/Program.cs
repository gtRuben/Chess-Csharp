
using Chess;
using chessboard;
using game;


Board b = new Board(8, 8);

b.PutPiece(new Tower(b, Color.Black), new Position(0, 0));
b.PutPiece(new Tower(b, Color.Black), new Position(0, 7));
b.PutPiece(new Tower(b, Color.White), new Position(7, 0));
b.PutPiece(new Tower(b, Color.White), new Position(7, 7));

Screen.PrintChessboard(b);
