using ChessGame.chessboard;
using ChessGame.chessboard.chess.pieces;
using ChessGame.chessboard.exceptions;
using System;

namespace ChessGame.chess
{
    class ChessMatch
    {
        public Chessboard Chessboard { get; private set; }
        public int Step { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Closed;

        public ChessMatch()
        {
            Chessboard = new Chessboard(8, 8);
            Step = 1;
            CurrentPlayer = Color.White;
            Closed = false;
            StartPiecesOfMatch();
        }

        private void DoMove(Position sourcePosition, Position targetPosition)
        {
            Piece sourcePiece = Chessboard.RemovePiece(sourcePosition);
            sourcePiece.AddMoveCount();
            Piece capturedPiece = Chessboard.RemovePiece(targetPosition);

            Chessboard.AddPiece(sourcePiece, targetPosition);
        }

        public void PlayMove(Position sourcePosition, Position targetPosition)
        {
            DoMove(sourcePosition, targetPosition);
            Step++;
            ChangePlayer();
        }

        public void ToValidateSourcePosition(Position position)
        {
            if (Chessboard.GetPiece(position) == null)
            {
                throw new ChessboardException("Not exists pieces in selected position");
            }
            if (CurrentPlayer != Chessboard.GetPiece(position).Color)
            {
                throw new ChessboardException("The selected piece isn't your!");
            }
            if (!Chessboard.GetPiece(position).ExistsAvailableMoves())
            {
                throw new ChessboardException("Not exists available moves to selected piece!");
            }
        }

        public void ToValidateTargetPosition(Position source, Position target)
        {
            if (!Chessboard.GetPiece(source).CanMoveTo(target))
            {
                throw new ChessboardException("Invalid target position!");
            }
        }

        private void ChangePlayer()
        {
            CurrentPlayer = CurrentPlayer == Color.White ? Color.Black : Color.White;
        }

        private void StartPiecesOfMatch()
        {
            Chessboard.AddPiece(new Tower(Chessboard, Color.White), new ChessPosition('c', 1).ToPosition());
            Chessboard.AddPiece(new Tower(Chessboard, Color.White), new ChessPosition('c', 2).ToPosition());
            Chessboard.AddPiece(new Tower(Chessboard, Color.White), new ChessPosition('d', 2).ToPosition());
            Chessboard.AddPiece(new Tower(Chessboard, Color.White), new ChessPosition('e', 2).ToPosition());
            Chessboard.AddPiece(new Tower(Chessboard, Color.White), new ChessPosition('e', 1).ToPosition());
            Chessboard.AddPiece(new King(Chessboard, Color.White), new ChessPosition('d', 1).ToPosition());

            Chessboard.AddPiece(new Tower(Chessboard, Color.Black), new ChessPosition('c', 7).ToPosition());
            Chessboard.AddPiece(new Tower(Chessboard, Color.Black), new ChessPosition('c', 8).ToPosition());
            Chessboard.AddPiece(new Tower(Chessboard, Color.Black), new ChessPosition('d', 7).ToPosition());
            Chessboard.AddPiece(new Tower(Chessboard, Color.Black), new ChessPosition('e', 7).ToPosition());
            Chessboard.AddPiece(new Tower(Chessboard, Color.Black), new ChessPosition('e', 8).ToPosition());
            Chessboard.AddPiece(new King(Chessboard, Color.Black), new ChessPosition('d', 8).ToPosition());
        }
    }
}
