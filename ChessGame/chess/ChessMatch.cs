using ChessGame.chessboard;
using ChessGame.chessboard.chess.pieces;
using ChessGame.chessboard.exceptions;
using System;
using System.Collections.Generic;

namespace ChessGame.chess
{
    class ChessMatch
    {
        public Chessboard Chessboard { get; private set; }
        public int Step { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Closed { get; set; }
        private HashSet<Piece> Pieces;
        private HashSet<Piece> Captured;

        public ChessMatch()
        {
            Chessboard = new Chessboard(8, 8);
            Step = 1;
            CurrentPlayer = Color.White;
            Closed = false;

            Pieces = new HashSet<Piece>();
            Captured = new HashSet<Piece>();

            StartPiecesOfMatch();
        }

        private void DoMove(Position sourcePosition, Position targetPosition)
        {
            Piece sourcePiece = Chessboard.RemovePiece(sourcePosition);
            sourcePiece.AddMoveCount();
            
            Piece capturedPiece = Chessboard.RemovePiece(targetPosition);

            Chessboard.AddPiece(sourcePiece, targetPosition);

            if (capturedPiece != null)
            {
                Captured.Add(capturedPiece);
            }
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

        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> capturedPieces = new HashSet<Piece>();
            foreach (Piece piece in Captured)
            {
                if (piece.Color == color)
                {
                    capturedPieces.Add(piece);
                }
            }
            return capturedPieces;
        }

        public HashSet<Piece> ActivePieces(Color color)
        {
            HashSet<Piece> activePieces = new HashSet<Piece>();
            foreach (Piece piece in Pieces)
            {
                if (piece.Color == color)
                {
                    activePieces.Add(piece);
                }
            }
            activePieces.ExceptWith(CapturedPieces(color));

            return activePieces;
        }

        public void InsertNewPiece(char column, int row, Piece piece)
        {
            Chessboard.AddPiece(piece, new ChessPosition(column, row).ToPosition());
            Pieces.Add(piece);
        }

        private void StartPiecesOfMatch()
        {

            InsertNewPiece('c', 1, new Tower(Chessboard, Color.White));
            InsertNewPiece('c', 2, new Tower(Chessboard, Color.White));
            InsertNewPiece('d', 2, new Tower(Chessboard, Color.White));
            InsertNewPiece('e', 2, new Tower(Chessboard, Color.White));
            InsertNewPiece('e', 1, new Tower(Chessboard, Color.White));
            InsertNewPiece('d', 1, new King(Chessboard, Color.White));

            InsertNewPiece('c', 7, new Tower(Chessboard, Color.Black));
            InsertNewPiece('c', 8, new Tower(Chessboard, Color.Black));
            InsertNewPiece('d', 7, new Tower(Chessboard, Color.Black));
            InsertNewPiece('e', 7, new Tower(Chessboard, Color.Black));
            InsertNewPiece('e', 8, new Tower(Chessboard, Color.Black));
            InsertNewPiece('d', 8, new King(Chessboard, Color.Black));

        }
    }
}
