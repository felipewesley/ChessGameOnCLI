using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.chessboard.exceptions
{
    class ChessboardException : Exception
    {
        public ChessboardException(string message) : base(message)
        {

        }
    }
}
