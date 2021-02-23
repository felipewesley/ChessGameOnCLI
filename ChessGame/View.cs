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
                Console.Write((8 - i) + " ");
                for (int j = 0; j < chessboard.Columns; j++)
                {
                    Piece piece = chessboard.GetPiece(new Position(i, j));
                    if (piece == null)
                    {
                        Console.Write("- ");
                    } else
                    {
                        ShowPiece(piece);
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void ShowPiece(Piece piece)
        {
            if (piece.Color == Color.White)
            {
                Console.Write(piece);
            }
            else
            {
                ConsoleColor defaultColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(piece);
                Console.ForegroundColor = defaultColor;
            }
            Console.Write(" ");
        }
    }
}
