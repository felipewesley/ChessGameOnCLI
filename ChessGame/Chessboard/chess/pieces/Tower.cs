using System;

namespace ChessGame.chessboard.chess.pieces
{
    class Tower : Piece
    {
        private char PieceLabel;

        public Tower(Chessboard chessboard, Color color) : base(chessboard, color)
        {
            PieceLabel = 'T';
        }

        public override string ToString()
        {
            return PieceLabel.ToString();
        }
    }
}
