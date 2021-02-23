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

        protected override bool CanMoveSelf(Position position)
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
            while (Chessboard.IsValidPosition(position) && CanMoveSelf(position))
            {
                availableMovesArray[position.Row, position.Column] = true;
                if (Chessboard.GetPiece(position) != null && Chessboard.GetPiece(position).Color != Color)
                    break;

                position.Row -= 1;
            }

            // Abaixo
            position.SetPosition(Position.Row + 1, Position.Column);
            while (Chessboard.IsValidPosition(position) && CanMoveSelf(position))
            {
                availableMovesArray[position.Row, position.Column] = true;
                if (Chessboard.GetPiece(position) != null && Chessboard.GetPiece(position).Color != Color)
                    break;

                position.Row += 1;
            }

            // Direita
            position.SetPosition(Position.Row, Position.Column + 1);
            while (Chessboard.IsValidPosition(position) && CanMoveSelf(position))
            {
                availableMovesArray[position.Row, position.Column] = true;
                if (Chessboard.GetPiece(position) != null && Chessboard.GetPiece(position).Color != Color)
                    break;

                position.Column += 1;
            }

            // Esquerda
            position.SetPosition(Position.Row, Position.Column - 1);
            while (Chessboard.IsValidPosition(position) && CanMoveSelf(position))
            {
                availableMovesArray[position.Row, position.Column] = true;
                if (Chessboard.GetPiece(position) != null && Chessboard.GetPiece(position).Color != Color)
                    break;

                position.Column -= 1;
            }

            return availableMovesArray;
        }
    }
}
