using System;

namespace ConnectFour
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int[,] board = new int[7, 6];

            GameLoop(board);
        }

        private static void GameLoop(int[,] board)
        {
            PrintBoard(board);

            while (true)
            {
                // X moves

                Console.Write("   X's move. Which column? ");
                int xmove = Int32.Parse(Console.ReadLine()) - 1;

                for (int i = 0; i <= 5; i++)
                {
                    if (board[xmove, i] == 0)
                    {
                        board[xmove, i] = 1;
                        break;
                    }
                }

                // Check for X win

                PrintBoard(board);
                CheckForWin(1, board);

                // O moves

                Console.Write("   O's move. Which column? ");
                int ymove = Int32.Parse(Console.ReadLine()) - 1;

                for (int i = 0; i <= 5; i++)
                {
                    if (board[ymove, i] == 0)
                    {
                        board[ymove, i] = 2;
                        break;
                    }
                }
                
                // Check for O win
                PrintBoard(board);
                CheckForWin(2, board);
            }
        }

        static void CheckForWin(int player, int[,] board)
        {
            // Check columns

            for (int i = 0; i <= 6; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    if (board[i, j] == player && board[i, j + 1] == player && board[i, j + 2] == player && board[i, j + 3] == player)
                    {
                        Console.WriteLine("Winner!");
                    }
                }
            }

            // Check rows

            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j <= 5; j++)
                {
                    if (board[i, j] == player && board[i + 1, j] == player && board[i + 2, j] == player && board[i + 3, j] == player)
                    {
                        Console.WriteLine("Winner!");
                    }
                }
            }

            // Check diagonals from lower left

            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    if (board[i, j] == player && board[i + 1, j + 1] == player && board[i + 2, j + 2] == player && board[i + 3, j + 3] == player)
                    {
                        Console.WriteLine("Winner!");
                    }
                }
            }

            // Check diagonals from upper left

            for (int i = 0; i <= 3; i++)
            {
                for (int j = 5; j >= 3; j--)
                {
                    if (board[i, j] == player && board[i + 1, j - 1] == player && board[i + 2, j - 2] == player && board[i + 3, j - 3] == player)
                    {
                        Console.WriteLine("Winner!");
                    }
                }
            }
        }

        static void PrintBoard(int[,] boardData)
        {
            Console.Clear();
            Console.WriteLine("\r\n           Connect Four\r\n");

            Console.WriteLine("     1   2   3   4   5   6   7");
            Console.WriteLine("   ┌───┬───┬───┬───┬───┬───┬───┐");

            for (int i = 5; i >= 0; i--)
            {
                Console.Write("   │ ");
                for (int j = 0; j <= 6; j++)
                {
                    switch (boardData[j, i])
                    {
                        case 0:
                            Console.Write("  │ ");
                            break;
                        case 1:
                            Console.Write("X │ ");
                            break;
                        case 2:
                            Console.Write("O │ ");
                            break;
                    }
                }
                Console.WriteLine("");

                if (i > 0)
                {
                    Console.WriteLine("   ├───┼───┼───┼───┼───┼───┼───┤");
                }
            }
            Console.WriteLine("   └───┴───┴───┴───┴───┴───┴───┘");
            Console.WriteLine("");
        }
    }
}
