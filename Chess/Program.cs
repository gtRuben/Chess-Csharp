
using Chess;
using chessboard;
using game;


ChessPosition cp1 = new('a', 1);
ChessPosition cp2 = new('c', 7);

Console.WriteLine(cp1 + " = " + cp1.ToPosition());
Console.WriteLine(cp2 + " = " + cp2.ToPosition());