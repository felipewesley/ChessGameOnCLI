using ChessGame.chess;
using ChessGame.chessboard;
using ChessGame.chessboard.chess.pieces;
using ChessGame.chessboard.exceptions;
using System;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                ChessMatch chessMatch = new ChessMatch();

                while (!chessMatch.Closed)
                {
                    Console.Clear();
                    View.ShowChessboard(chessMatch.Chessboard);

                    Console.WriteLine();

                    Console.Write("Source: ");
                    Position source = View.ReadPosition().ToPosition();

                    bool[,] availableMoves = chessMatch.Chessboard.GetPiece(source).AvailableMoves();

                    Console.Clear();
                    View.ShowChessboard(chessMatch.Chessboard, availableMoves);

                    Console.WriteLine();

                    Console.Write("Target: ");
                    Position target = View.ReadPosition().ToPosition();

                    chessMatch.DoMove(source, target);
                }

                

            } catch (ChessboardException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();

            // Console.WriteLine("Hello world!");
        }

    }
}
