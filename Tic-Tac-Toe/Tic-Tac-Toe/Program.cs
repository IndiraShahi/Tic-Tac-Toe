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
            makeMove(board, userMove, userLetter);

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
        private static int getUserMove(char[] board)
        {
            int[] validCells = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            while (true)
            {
                Console.WriteLine("What is your next move? (1-9):");
                int index = Convert.ToInt32(Console.ReadLine());
                if (Array.Find<int>(validCells, element => element == index) != 0 && isSpaceFree(board, index))
                    return index;
            }
        }
        private static bool isSpaceFree(char[] board, int index)
        {
            return board[index] == ' ';
        }
        private static void makeMove(char[] board, int index, char letter)
        { 
            Boolean spaceFree = isSpaceFree(board, index);
            if (spaceFree) board[index] = letter;
        }
    }
}
