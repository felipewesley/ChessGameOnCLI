using System;

namespace ChessGame.chessboard
{
    class Position
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public void SetPosition(int row, int col)
        {
            Row = row;
            Column = col;
        }


        public override string ToString()
        {
            return $"{ Row }, { Column }";
        }
    }
}
