
using Chess;
using chessboard;
using game;


Board b = new Board(8, 8);

Tower t1 = new Tower(b, Color.Black);
Position p1 = new Position(0, 0);

Tower t2 = new Tower(b, Color.Black);
Position p2 = new Position(1, 3);

Piece k = new King(b, Color.Black);
Position p3 = new Position(2, 4);

b.PutPiece(t1, p1);
b.PutPiece(t2, p2);
b.PutPiece(k, p3);

Console.WriteLine(b.TheresAPiece(p1));
Console.WriteLine(b.TheresAPiece(new Position(5, 5)));

Console.ReadLine();
