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
    }
}
