using System;
using chessboard;

namespace game
{
    internal class ChessGame
    {
        public Board Board { get; private set; }
        private int _turno;
        private Color? _currentPlayer;
        public bool Finished { get; private set; }

        public ChessGame()
        {
            Board = new Board(8, 8);
            _turno = 1;
            _currentPlayer = Color.White;
            Finished = false;
            PlacePieces();
        }

        private void PlacePieces()
        {
            Board.PutPiece(new Tower(Board, Color.White), new ChessPosition('a', 1).ToPosition());
            Board.PutPiece(new Tower(Board, Color.White), new ChessPosition('h', 1).ToPosition());
            Board.PutPiece(new Tower(Board, Color.Black), new ChessPosition('a', 8).ToPosition());
            Board.PutPiece(new Tower(Board, Color.Black), new ChessPosition('h', 8).ToPosition());
            Board.PutPiece(new King(Board, Color.White), new ChessPosition('d', 4).ToPosition());
            Board.PutPiece(new King(Board, Color.Black), new ChessPosition('e', 4).ToPosition());
        }

        public void MovePiece(Position origin, Position destination)
        {
            Piece piece = Board.RemovePiece(origin);
            piece.AddMovement();
            Piece capturedPiece = Board.RemovePiece(destination);
            Board.PutPiece(piece, destination);
        }
    }
}
