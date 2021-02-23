using System;

namespace ChessGame.chessboard
{
    class Chessboard
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public Piece[,] Pieces { get; set; }

        public Chessboard(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Pieces = new Piece[rows, columns];
        }

        public Piece GetPiece(Position position)
        {
            return Pieces[position.Row, position.Column];
        }
    }
}
