using ChessGame.chessboard;
using ChessGame.chessboard.chess.pieces;
using System;

namespace ChessGame.chess
{
    class ChessMatch
    {
        public Chessboard Chessboard { get; private set; }
        private int Step;
        private Color CurrentPlayer;
        public bool Closed;

        public ChessMatch()
        {
            Chessboard = new Chessboard(8, 8);
            Step = 1;
            CurrentPlayer = Color.White;
            Closed = false;
            StartPiecesOfMatch();
        }

        public void DoMove(Position sourcePosition, Position targetPosition)
        {
            Piece sourcePiece = Chessboard.RemovePiece(sourcePosition);
            sourcePiece.AddMoveCount();
            Piece capturedPiece = Chessboard.RemovePiece(targetPosition);

            Chessboard.AddPiece(sourcePiece, targetPosition);
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
