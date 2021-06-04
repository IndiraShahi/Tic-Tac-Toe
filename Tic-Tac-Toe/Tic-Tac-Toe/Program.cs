using System;

namespace Tic_Tac_Toe
{
    public class Program
    {
        static void Main(string[] args)
        {
           // Console.WriteLine("Let's play Tic-Tac-Toe!");
            char[] board = createBoard();
            char userLetter = chooseUserLetter();
        }
        private static char[] createBoard()
        {
            char[] board = new char[10];
            for (int i = 0; i < board.Length; i++)
            {
                board[i] = ' ';
            }
            return board;
        }
        private static char chooseUserLetter()
        {
            Console.WriteLine("Choose X or O: ");
            string userLetter = Console.ReadLine();
            return char.ToUpper(userLetter[0]);
        }
    }
}
