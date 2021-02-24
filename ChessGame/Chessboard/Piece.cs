using System.Text;

namespace ChessGame.chessboard
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int MoveCount { get; protected set; }
        public Chessboard Chessboard { get; protected set; }

        public Piece(Chessboard chessboard, Color color)
        {
            Position = null;
            Color = color;
            Chessboard = chessboard;
            MoveCount = 0;
        }

        public void AddMoveCount()
        {
            MoveCount++;
        }

        public void SubtractMoveCount()
        {
            MoveCount--;
        }

        public bool ExistsAvailableMoves()
        {
            bool[,] availableMoves = AvailableMoves();
            for (int i = 0; i < Chessboard.Rows; i++)
            {
                for (int j = 0; j < Chessboard.Columns; j++)
                {
                    if (availableMoves[i, j]) return true;
                }
            }
            return false;
        }

        protected abstract bool CanMoveSelf(Position position);

        public bool CanMoveTo(Position position)
        {
            return AvailableMoves()[position.Row, position.Column];
        }

        public abstract bool[,] AvailableMoves();
    }
}
