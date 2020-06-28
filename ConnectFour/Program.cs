using System;

namespace ConnectFour
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int[,] board = new int[7, 6];

            board[3, 0] = 1;
            board[2, 0] = 2;

            PrintBoard(board);

            Console.Write("   Which column? ");
            int move = Int32.Parse(Console.ReadLine()) - 1;

            for (int i = 0; i <= 5; i++)
            {
                if (board[move, i] == 0)
                {
                    board[move, i] = 1;
                    break;
                }
            }

            PrintBoard(board);

/*
┌───┬───┬───┬───┬───┬───┬───┐
│   │   │   │   │   │   │   │
├───┼───┼───┼───┼───┼───┼───┤
│   │   │   │   │   │   │   │
├───┼───┼───┼───┼───┼───┼───┤
│   │   │   │   │   │   │   │
├───┼───┼───┼───┼───┼───┼───┤
│   │   │   │   │   │   │   │
├───┼───┼───┼───┼───┼───┼───┤
│   │   │   │ O │   │   │   │
├───┼───┼───┼───┼───┼───┼───┤
│   │   │   │ X │   │   │   │
└───┴───┴───┴───┴───┴───┴───┘
*/

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
                    switch(boardData[j, i])
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
