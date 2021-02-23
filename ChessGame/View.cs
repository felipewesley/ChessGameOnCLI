using System;
using System.Collections.Generic;
using ChessGame.chess;
using ChessGame.chessboard;

namespace ChessGame
{
    class View
    {
        public static void ShowMatch(ChessMatch chessMatch)
        {
            ShowChessboard(chessMatch.Chessboard);

            Console.WriteLine();

            ShowCapturedPieces(chessMatch);

            Console.WriteLine();

            Console.WriteLine("Step: " + chessMatch.Step);
            Console.WriteLine("Current player: " + chessMatch.CurrentPlayer);
        }

        public static void ShowCapturedPieces(ChessMatch chessMatch)
        {
            Console.WriteLine("Captured pieces: ");
            Console.Write("White: ");
            ShowCollection(chessMatch.CapturedPieces(Color.White));
            Console.WriteLine();
            Console.Write("Black: ");
            ShowCollection(chessMatch.CapturedPieces(Color.Black));
        }

        public static void ShowCollection(HashSet<Piece> collection)
        {
            Console.Write("[ ");
            foreach (Piece piece in collection)
            {
                View.ShowPiece(piece);
                // Console.Write(piece + " ");
            }
            Console.Write("]");
        }

        public static void ShowChessboard(Chessboard chessboard)
        {
            for (int i = 0; i < chessboard.Rows; i++)
            {
                Console.Write((8 - i) + " ");
                for (int j = 0; j < chessboard.Columns; j++)
                {
                    ShowPiece(chessboard.GetPiece(new Position(i, j)));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void ShowChessboard(Chessboard chessboard, bool[,] availableMoves)
        {
            ConsoleColor defaultColor = Console.BackgroundColor;
            ConsoleColor changedColor = ConsoleColor.DarkGray;

            for (int i = 0; i < chessboard.Rows; i++)
            {
                Console.Write((8 - i) + " ");
                for (int j = 0; j < chessboard.Columns; j++)
                {
                    Console.BackgroundColor = availableMoves[i, j] ? changedColor : defaultColor;
                    
                    ShowPiece(chessboard.GetPiece(new Position(i, j)));
                    Console.BackgroundColor = defaultColor;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = defaultColor;
        }

        public static void ShowPiece(Piece piece)
        {
            if (piece == null)
            {
                    Console.Write("-");
                
            } else
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
            }
            Console.Write(" ");
        }

        public static ChessPosition ReadPosition()
        {
            string read = Console.ReadLine();

            char column = char.Parse(read[0].ToString());
            int row = int.Parse(read[1].ToString());

            return new ChessPosition(column, row);
        }
    }
}
