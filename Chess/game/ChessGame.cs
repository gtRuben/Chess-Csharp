using chessboard;

namespace game
{
    internal class ChessGame
    {
        private HashSet<Piece> _pieces;
        private HashSet<Piece> _capturedPieces;
        public Board Board { get; private set; }
        public int Round { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }
        public bool InCheck { get; private set; }


        public ChessGame()
        {
            Board = new Board(8, 8);
            Round = 1;
            CurrentPlayer = Color.White;
            _pieces = new();
            _capturedPieces = new();
            PlacePieces();
        }


        private void PlacePieces()
        {
            // White
            NewPiece(new Bishop(Board, Color.White), new ChessPosition('c', 1));
            NewPiece(new Knight(Board, Color.White), new ChessPosition('c', 2));
            NewPiece(new Knight(Board, Color.White), new ChessPosition('d', 2));
            NewPiece(new Bishop(Board, Color.White), new ChessPosition('e', 1));
            NewPiece(new Queen(Board, Color.White), new ChessPosition('e', 2));
            NewPiece(new King(Board, Color.White), new ChessPosition('d', 1));

            // Black
            NewPiece(new Knight(Board, Color.Black), new ChessPosition('c', 7));
            NewPiece(new Bishop(Board, Color.Black), new ChessPosition('c', 8));
            NewPiece(new Knight(Board, Color.Black), new ChessPosition('d', 7));
            NewPiece(new Bishop(Board, Color.Black), new ChessPosition('e', 8));
            NewPiece(new Queen(Board, Color.Black), new ChessPosition('e', 7));
            NewPiece(new King(Board, Color.Black), new ChessPosition('d', 8));
        }


        private void NewPiece(Piece piece, ChessPosition chessPosition)
        {
            Board.PutPiece(piece, chessPosition.ToPosition());
            _pieces.Add(piece);
        }


        public void ToPlay(Position origin, Position target)
        {
            TryMove(origin, target);
            InCheck = Check(Opponent(CurrentPlayer));
            if (InCheck)
            {
                Finished = Checkmate();
            }
            if (!Finished)
            {
                Round++;
                ChangePlayer();
            }
        }


        private void TryMove(Position origin, Position target)
        {
            Piece piece = MovePiece(origin, target);
            if (Check(CurrentPlayer))
            {
                UndoMove(target, origin, piece);
                throw new BoardException(" You cannot leave your king in check!");
            }
        }


        private Piece MovePiece(Position origin, Position target)
        {
            Piece piece = Board.RemovePiece(origin);
            piece.IMoved();
            Piece capturedPiece = Board.RemovePiece(target);
            Board.PutPiece(piece, target);
            if (capturedPiece != null)
            {
                _capturedPieces.Add(capturedPiece);
            }
            return capturedPiece;
        }


        private bool Check(Color color)
        {
            HashSet<Piece> pieces = PiecesOnTheBoard(Opponent(color));
            Position king = Board.GetKingsPosition(color);
            foreach (Piece piece in pieces)
            {
                if (piece.PossibleMoves()[king.Row, king.Column])
                {
                    return true;
                }
            }
            return false;
        }


        private Color Opponent(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }


        private HashSet<Piece> PiecesOnTheBoard(Color color)
        {
            var pieces = new HashSet<Piece>(_pieces.Where(p => p.Color == color));
            pieces.ExceptWith(CapturedPieces(color));
            return pieces;
        }


        private void UndoMove(Position target, Position origin, Piece? capturedPiece)
        {
            Piece piece = Board.RemovePiece(target);
            piece.IMoved(false);
            Board.PutPiece(piece, origin);
            if (capturedPiece != null)
            {
                Board.PutPiece(capturedPiece, target);
                _capturedPieces.Remove(capturedPiece);
            }
        }


        private bool Checkmate()
        {
            Color opponent = Opponent(CurrentPlayer);
            var pieces = PiecesOnTheBoard(opponent);
            foreach (var piece in pieces)
            {
                var possibleMoves = piece.PossibleMoves();
                for (int i = 0; i < Board.Rows; i++)
                {
                    for (int j = 0; j < Board.Columns; j++)
                    {
                        if (possibleMoves[i, j])
                        {
                            Position _origin = piece.Position;
                            Position _target = new Position(i, j);
                            Piece captured = MovePiece(_origin, _target);
                            if (Check(opponent))
                            {
                                UndoMove(_target, _origin, captured);
                            }
                            else
                            {
                                UndoMove(_target, _origin, captured);
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
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
