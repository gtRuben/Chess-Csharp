using chessboard;

namespace game
{
    internal class ChessGame
    {
        public Board Board { get; private set; }
        public int Round { get; private set; }
        public Color? CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }
        private HashSet<Piece> _pieces;
        private HashSet<Piece> _capturedPieces;

        public ChessGame()
        {
            Board = new Board(8, 8);
            Round = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            _pieces = new();
            _capturedPieces = new();
            PlacePieces();
        }

        private void PlacePieces()
        {
            // White
            NewPiece(new Tower(Board, Color.White), new ChessPosition('c', 1));
            NewPiece(new Tower(Board, Color.White), new ChessPosition('c', 2));
            NewPiece(new Tower(Board, Color.White), new ChessPosition('d', 2));
            NewPiece(new Tower(Board, Color.White), new ChessPosition('e', 1));
            NewPiece(new Tower(Board, Color.White), new ChessPosition('e', 2));
            NewPiece(new King(Board, Color.White), new ChessPosition('d', 1));

            // Black
            NewPiece(new Tower(Board, Color.Black), new ChessPosition('c', 7));
            NewPiece(new Tower(Board, Color.Black), new ChessPosition('c', 8));
            NewPiece(new Tower(Board, Color.Black), new ChessPosition('d', 7));
            NewPiece(new Tower(Board, Color.Black), new ChessPosition('e', 8));
            NewPiece(new Tower(Board, Color.Black), new ChessPosition('e', 7));
            NewPiece(new King(Board, Color.Black), new ChessPosition('d', 8));
        }

        public void NewPiece(Piece piece, ChessPosition chessPosition)
        {
            Board.PutPiece(piece, chessPosition.ToPosition());
            _pieces.Add(piece);
        }

        public void ToPlay(Position origin, Position target)
        {
            MovePiece(origin, target);
            Round++;
            ChangePlayer();
        }

        private void MovePiece(Position origin, Position target)
        {
            Piece piece = Board.RemovePiece(origin);
            piece.AddMovement();
            Piece capturedPiece = Board.RemovePiece(target);
            Board.PutPiece(piece, target);
            if (capturedPiece != null)
            {
                _capturedPieces.Add(capturedPiece);
            }
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

        public HashSet<Piece> PiecesOnTheBoard(Color color)
        {
            var pieces = new HashSet<Piece>(_pieces.Where(p => p.Color == color));
            pieces.ExceptWith(CapturedPieces(color));
            return pieces;
        }

        public HashSet<Piece> CapturedPieces(Color color)
        {
            return new HashSet<Piece>(_capturedPieces.Where(p => p.Color == color));
        }

        public void ValidateOriginPosition(Position position)
        {
            if (Board.Piece(position) is null)
            {
                throw new BoardException(" There's no piece there.");
            }
            if (!Board.Piece(position).Color.Equals(CurrentPlayer))
            {
                throw new BoardException($" You need to choose a {CurrentPlayer} piece.");
            }
            if (!Board.Piece(position).FreeToMove())
            {
                throw new BoardException(" This piece cannot move.");
            }
        }

        public void ValidateTargetPosition(Position origin, Position target)
        {
            if (!Board.Piece(origin).CanMoveTo(target))
            {
                throw new BoardException(" Invalid move.");
            }
        }
    }
}
