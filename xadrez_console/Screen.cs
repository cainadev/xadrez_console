using System;
using System.Net.NetworkInformation;
using board;

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

                    if (tab.Pie(i, j) == null)
                    {
                        Console.Write("- "); 
                    }
                    else
                    {
                        PrintPie(tab.Pie(i, j));
                        Console.Write(" ");
                    }
                }

                Console.WriteLine();

            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintPie(Piece piece )
        {
            if ( piece.Color == Color.White)
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
        }
    }
}
