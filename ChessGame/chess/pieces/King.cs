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

        private bool CanMove(Position position)
        {
            Piece piece = Chessboard.GetPiece(position);
            return piece == null || piece.Color != Color;
        }

        public override bool[,] AvailableMoves()
        {
            bool[,] availableMovesArray = new bool[Chessboard.Rows, Chessboard.Columns];

            Position position = new Position(0, 0);

            // Acima
            position.SetPosition(Position.Row - 1, Position.Column);
            if (Chessboard.IsValidPosition(position) && CanMove(position))
                availableMovesArray[position.Row, position.Column] = true;

            // Superior Direita
            position.SetPosition(Position.Row - 1, Position.Column + 1);
            if (Chessboard.IsValidPosition(position) && CanMove(position))
                availableMovesArray[position.Row, position.Column] = true;

            // Direita
            position.SetPosition(Position.Row, Position.Column + 1);
            if (Chessboard.IsValidPosition(position) && CanMove(position))
                availableMovesArray[position.Row, position.Column] = true;

            // Inferior Direita
            position.SetPosition(Position.Row + 1, Position.Column + 1);
            if (Chessboard.IsValidPosition(position) && CanMove(position))
                availableMovesArray[position.Row, position.Column] = true;

            // Abaixo
            position.SetPosition(Position.Row + 1, Position.Column);
            if (Chessboard.IsValidPosition(position) && CanMove(position))
                availableMovesArray[position.Row, position.Column] = true;

            // Inferior Esquerda
            position.SetPosition(Position.Row + 1, Position.Column - 1);
            if (Chessboard.IsValidPosition(position) && CanMove(position))
                availableMovesArray[position.Row, position.Column] = true;

            // Esquerda
            position.SetPosition(Position.Row, Position.Column - 1);
            if (Chessboard.IsValidPosition(position) && CanMove(position))
                availableMovesArray[position.Row, position.Column] = true;

            // Superior Esquerda
            position.SetPosition(Position.Row - 1, Position.Column - 1);
            if (Chessboard.IsValidPosition(position) && CanMove(position))
                availableMovesArray[position.Row, position.Column] = true;

            return availableMovesArray;
        }
    }
}
