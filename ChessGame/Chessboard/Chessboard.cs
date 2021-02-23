using ChessGame.chessboard.exceptions;
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

        public void AddPiece(Piece piece, Position position)
        {
            if (PieceExists(position))
            {
                throw new ChessboardException("Already exists a piece in this position!");
            }
            Pieces[position.Row, position.Column] = piece;
            piece.Position = position;
        }

        public Piece RemovePiece(Position position)
        {
            if (GetPiece(position) == null)
            {
                return null;
            }
            Piece piece = GetPiece(position);
            piece.Position = null;
            
            Pieces[position.Row, position.Column] = null;
            
            return piece;
        }

        public bool PieceExists(Position position)
        {
            ToValidPosition(position);
            return GetPiece(position) != null;
        }

        public bool IsValidPosition(Position position)
        {
            return !(
                position.Row < 0 ||
                position.Row >= Rows ||
                position.Column < 0 ||
                position.Column >= Columns
                );
        }

        public void ToValidPosition(Position position)
        {
            if (!IsValidPosition(position))
            {
                throw new ChessboardException("Invalid position!");
            }
        }
    }
}
