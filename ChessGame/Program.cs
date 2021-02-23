using ChessGame.chessboard;
using System;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {

            Chessboard chessboard = new Chessboard(8, 8);

            View.ShowChessboard(chessboard);

            Console.ReadLine();

            // Console.WriteLine("Hello world!");
        }
    }
}
