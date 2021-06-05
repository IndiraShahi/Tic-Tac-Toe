using System;

namespace Tic_Tac_Toe
{
    public class Program
    {
        static void Main(string[] args)
        {
           // Console.WriteLine("Let's play Tic-Tac-Toe!");
            char[] board = createBoard();
            showBoard(board);
            char userLetter = chooseUserLetter();
            int userMove = getUserMove(board);

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
        private static void showBoard(char[] board)
        {
            Console.WriteLine("\n" + board[1] + " | " + board[2] + " | " + board[3]);
            Console.WriteLine("-----------");
            Console.WriteLine("\n" + board[4] + " | " + board[5] + " | " + board[6]);
            Console.WriteLine("-----------");
            Console.WriteLine("\n" + board[7] + " | " + board[8] + " | " + board[9]);
        }

    }
}
