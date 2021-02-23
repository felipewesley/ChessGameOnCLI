using System;
using ChessGame.chessboard;

namespace ChessGame
{
    class View
    {
        public static void ShowChessboard(Chessboard chessboard)
        {
            for (int i = 0; i < chessboard.Rows; i++)
            {

                for (int j = 0; j < chessboard.Columns; j++)
                {
                    Piece piece = chessboard.GetPiece(new Position(i, j));
                    if (piece == null)
                    {
                        Console.Write("- ");
                    } else
                    {
                        Console.Write(piece + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
