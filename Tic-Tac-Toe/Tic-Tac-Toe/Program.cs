using System;

namespace Tic_Tac_Toe
{
    public class Program
    {
        static void Main(string[] args)
        {
           // Console.WriteLine("Let's play Tic-Tac-Toe!");
            char[] board = createBoard();
        }
        private static char[]  createBoard()
        {
            char[] board = new char[10];
            for (int i = 0; i < board.Length; i++)
            {
                board[i] = ' ';
            }
            return board;

        }
    }
}
