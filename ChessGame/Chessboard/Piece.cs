using System.Text;

namespace ChessGame.chessboard
{
    class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int MoveQuant { get; protected set; }
        public Chessboard Chessboard { get; protected set; }

        public Piece(Position position, Color color, Chessboard chessboard)
        {
            Position = position;
            Color = color;
            Chessboard = chessboard;
            MoveQuant = 0;
        }

        
    }
}
