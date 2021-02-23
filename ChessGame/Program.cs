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
                    try
                    {
                        Console.Clear();
                        View.ShowChessboard(chessMatch.Chessboard);

                        Console.WriteLine();
                        Console.WriteLine("Step: " + chessMatch.Step);
                        Console.WriteLine("Current player: " + chessMatch.CurrentPlayer);

                        Console.WriteLine();

                        Console.Write("Source: ");
                        Position source = View.ReadPosition().ToPosition();

                        chessMatch.ToValidateSourcePosition(source);

                        bool[,] availableMoves = chessMatch.Chessboard.GetPiece(source).AvailableMoves();

                        Console.Clear();
                        View.ShowChessboard(chessMatch.Chessboard, availableMoves);

                        Console.WriteLine();

                        Console.Write("Target: ");
                        Position target = View.ReadPosition().ToPosition();

                        chessMatch.ToValidateTargetPosition(source, target);

                        chessMatch.PlayMove(source, target);

                    } catch (ChessboardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                    
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
