using chessboard;

namespace game
{
    internal class ChessGame
    {
        public Board Board { get; private set; }
        public int Round { get; private set; }
        public Color? CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }

        public ChessGame()
        {
            Board = new Board(8, 8);
            Round = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            PlacePieces();
        }

        private void PlacePieces()
        {
            Board.PutPiece(new Tower(Board, Color.White), new ChessPosition('a', 1).ToPosition());
            Board.PutPiece(new Tower(Board, Color.White), new ChessPosition('b', 1).ToPosition());
            Board.PutPiece(new Tower(Board, Color.White), new ChessPosition('b', 2).ToPosition());
            Board.PutPiece(new Tower(Board, Color.White), new ChessPosition('a', 2).ToPosition());
            Board.PutPiece(new Tower(Board, Color.White), new ChessPosition('h', 1).ToPosition());
            Board.PutPiece(new Tower(Board, Color.Black), new ChessPosition('a', 8).ToPosition());
            Board.PutPiece(new Tower(Board, Color.Black), new ChessPosition('h', 8).ToPosition());
            Board.PutPiece(new King(Board, Color.White), new ChessPosition('d', 4).ToPosition());
            Board.PutPiece(new King(Board, Color.White), new ChessPosition('e', 4).ToPosition());
        }

        public void ToPlay(Position origin, Position destination)
        {
            MovePiece(origin, destination);
            Round++;
            ChangePlayer();
        }

        private void MovePiece(Position origin, Position destination)
        {
            Piece piece = Board.RemovePiece(origin);
            piece.AddMovement();
            Piece capturedPiece = Board.RemovePiece(destination);
            Board.PutPiece(piece, destination);
        }

        private void ChangePlayer()
        {
            if (CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
        }

        public void ValidateOriginPosition(Position position)
        {
            if (Board.Piece(position) is null)
            {
                throw new BoardException(" There's no piece there.");
            }
            if (!Board.Piece(position).Color.Equals(CurrentPlayer))
            {
                throw new BoardException($" The piece chosen isn't {CurrentPlayer}.");
            }
            if (!Board.Piece(position).FreeToMove())
            {
                throw new BoardException(" This piece cannot move.");
            }
        }
    }
}
