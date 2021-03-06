using System;

namespace Tic_Tac_Toe
{
    public class Program
    {
        public const int HEAD = 0;
        public const int TAIL = 1;
        public enum Player { USER, COMPUTER };
        public enum GameStatus { WON, FULL_BOARD, CONTINUE };
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
            int[] cornerMoves = { 1, 3, 7, 9 };
            int computerMove = getRandomMoveFromList(board, cornerMoves);
            if (computerMove != 0) return computerMove;
            if (isSpaceFree(board, 5)) return 5;
            int[] sideMoves = { 2, 4, 6, 8 };
            computerMove = getRandomMoveFromList(board, sideMoves);
            if (computerMove != 0) return computerMove;
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
        private static int getRandomMoveFromList(char[] board, int[] moves)
        {
            for(int index = 0; index < moves.Length; index++)
            {
                if (isSpaceFree(board, moves[index])) return moves[index];
            }
            return 0;
        }
        private static GameStatus getGameStatus(char[] board, int move, char letter, String wonMessage)
        {
            makeMove(board, move, letter);
            if (isWinner(board, letter))
            {
                showBoard(board);
                Console.WriteLine(wonMessage);
                return GameStatus.WON;
            }
            if (isBoardFull(board))
            {
                showBoard(board);
                Console.WriteLine("Game is Tie");
                return GameStatus.FULL_BOARD;
            }
            return GameStatus.CONTINUE;
        }
        private static bool isBoardFull(char[] board)
        {
            for (int index = 1; index < board.Length; index++)
            {
                if (isSpaceFree(board, index)) return false;
            }
            return true;
        }
        private static bool playAgain()
        {
            Console.WriteLine("Do you want to play again? (yes or no)");
            string option = Console.ReadLine().ToLower();
            if (option.Equals("yes")) return true;
            return false;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Let's play Tic-Tac-Toe!");
            char[] board = createBoard();
            char userLetter = chooseUserLetter();
            char computerLetter = (userLetter == 'X') ? 'O' : 'X';
            Player player = getWhoStartsFirst();
            bool gameIsPlaying = true;
            GameStatus gameStatus;
            while (gameIsPlaying)
            {
                if (player.Equals(Player.USER))
                {
                    showBoard(board);
                    int userMove = getUserMove(board);
                    String wonMessage = "You have won the game!";
                    gameStatus = getGameStatus(board, userMove, userLetter, wonMessage);
                    player = Player.COMPUTER;
                }
                else
                {
                    String wonMessage = "The computer has beaten you!";
                    int computeMove = getComputerMove(board, computerLetter, userLetter);
                    gameStatus = getGameStatus(board, computeMove, computerLetter, wonMessage);
                    player = Player.USER;
                }
                if (gameStatus.Equals(GameStatus.CONTINUE)) continue;
                gameIsPlaying = false;
            }
        }
    }
}