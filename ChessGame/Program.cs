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
            if (true)
            {

                ChessPosition p = new ChessPosition('c', 7);

                Console.WriteLine(p);
                Console.WriteLine(p.ToPosition());

            } else
            {

            
            try
            {
                Chessboard chessboard = new Chessboard(8, 8);

                chessboard.AddPiece(new King(chessboard, Color.Black), new Position(0, 0));
                chessboard.AddPiece(new Tower(chessboard, Color.Black), new Position(1, 9));
                chessboard.AddPiece(new King(chessboard, Color.White), new Position(0, 1));

                View.ShowChessboard(chessboard);

                Console.ReadLine();
            } catch (ChessboardException e)
            {
                Console.WriteLine(e.Message);
            }
            }

            // Console.WriteLine("Hello world!");
        }
    }
}
