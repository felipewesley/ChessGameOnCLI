using System;

namespace ChessGame.chessboard.chess.pieces
{
    class King : Piece
    {
        private char PieceLabel;

        public King(Chessboard chessboard, Color color) : base(chessboard, color)
        {
            PieceLabel = 'R';
        }

        public override string ToString()
        {
            return PieceLabel.ToString();
        }
    }
}
