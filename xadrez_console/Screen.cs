using System;
using board;

namespace xadrez_console
{
    internal class Screen
    {
        public static void PrintBoard(Board tab)
        {
            for (int i = 0; i < tab.NumberLines; i++)
            {
                for (int j = 0; j < tab.NumberColumns; j++)
                {
                    if (tab.Pie(i, j) == null) { Console.Write("- "); }
                    else { Console.Write(tab.Pie(i, j) + " "); }
                }
                Console.WriteLine();
            }
        }
    }
}
