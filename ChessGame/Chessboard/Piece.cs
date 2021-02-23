using System.Text;

namespace ChessGame.chessboard
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int MoveQuant { get; protected set; }
        public Chessboard Chessboard { get; protected set; }

        public Piece(Chessboard chessboard, Color color)
        {
            Position = null;
            Color = color;
            Chessboard = chessboard;
            MoveQuant = 0;
        }

        
    }
}
