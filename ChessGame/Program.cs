using ChessGame.chessboard;
using ChessGame.chessboard.chess.pieces;
using System;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {

            Chessboard chessboard = new Chessboard(8, 8);

            chessboard.AddPiece(new King(chessboard, Color.Black), new Position(0, 0));
            chessboard.AddPiece(new Tower(chessboard, Color.Black), new Position(1, 3));
            chessboard.AddPiece(new King(chessboard, Color.White), new Position(2, 4));

            View.ShowChessboard(chessboard);

            Console.ReadLine();

            // Console.WriteLine("Hello world!");
        }
    }
}
