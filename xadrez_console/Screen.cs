using System;
using board;
using xadrez;

namespace xadrez_console
{
    internal class Screen
    {
        public static void PrintBoard(Board tab)
        {
            for (int i = 0; i < tab.NumberLines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.NumberColumns; j++)
                {
                    PrintPie(tab.Pie(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static void PrintBoard(Board tab, bool[,] possiblePosition)
        {
            ConsoleColor background = Console.BackgroundColor;
            ConsoleColor backgroundChange = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.NumberLines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.NumberColumns; j++)
                {
                    if (possiblePosition[i, j])
                    {
                        Console.BackgroundColor = backgroundChange;
                    }
                    else
                    {
                        Console.BackgroundColor = background;
                    }
                    PrintPie(tab.Pie(i, j));
                    Console.BackgroundColor = background;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
            Console.BackgroundColor = background;
        }

        public static PositionXadrez ReadPositionXadrez()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new PositionXadrez(column, line);
        }

        public static void PrintPie(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.Color == Color.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}
