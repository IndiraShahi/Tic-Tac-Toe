using System;

namespace Tic_Tac_Toe
{
    public class Program
    {
        public const int HEAD = 0;
        public const int TAIL = 1;
        public enum Player { USER, COMPUTER };
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
        private static Player getWhoStartsFirst()
        {
            int toss = getOneFromRandomChoices(2);
            return (toss == HEAD) ? Player.USER : Player.COMPUTER;
        }
        private static int getOneFromRandomChoices(int choices)
        {
            Random random = new Random();
            return (int)(random.Next() * 10) % choices;
        }
        private static bool isWinner(char[] b, char ch)
        {
            return ((b[1] == ch && b[2] == ch && b[3] == ch) ||
                     (b[4] == ch && b[5] == ch && b[6] == ch) ||
                     (b[7] == ch && b[8] == ch && b[9] == ch) ||
                     (b[1] == ch && b[4] == ch && b[7] == ch) ||
                     (b[2] == ch && b[5] == ch && b[8] == ch) ||
                     (b[3] == ch && b[6] == ch && b[9] == ch) ||
                     (b[1] == ch && b[5] == ch && b[9] == ch) ||
                     (b[7] == ch && b[5] == ch && b[3] == ch));
        }
        private static int getComputerMove(char[] board, char computerLetter, char userLetter)
        {

            int winningMove = getWinningMove(board, computerLetter);
            if (winningMove != 0) return winningMove;
            int userWinningMove = getWinningMove(board, userLetter);
            if (userWinningMove != 0) return userWinningMove;
            return 0;
        }
        private static int getWinningMove(char[] board, char letter)
        {
            for (int index = 1; index < board.Length; index++)
            {
                char[] copyOfBoard = getCopyOfBoard(board);
                if (isSpaceFree(copyOfBoard, index))
                {
                    makeMove(copyOfBoard, index, letter);
                    if (isWinner(copyOfBoard, letter))
                        return index;
                }
            }
            return 0;

        }

        private static char[] getCopyOfBoard(char[] board )
        {
            char[] boardCopy = new char[10];
            Array.Copy(board, boardCopy, board.Length);
            return boardCopy;
        }

        static void Main(string[] args)
        {
            // Console.WriteLine("Let's play Tic-Tac-Toe!");
            char[] board = createBoard();
            showBoard(board);
            char userLetter = chooseUserLetter();
            int userMove = getUserMove(board);
            makeMove(board, userMove, userLetter);
            Player player = getWhoStartsFirst();
            Console.WriteLine("Check if Won " + isWinner(board, userLetter));
            char computerLetter = default;
            int computeMove = getComputerMove(board, computerLetter, userLetter);
        }
    }
}